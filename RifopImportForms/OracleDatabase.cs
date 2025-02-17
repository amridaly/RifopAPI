using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Logging;
using Oracle.ManagedDataAccess.Client;
using RifopLibrary;

namespace RifopImportForms
{


    public class OracleDatabase
    {
        private readonly string _connectionString;
        private readonly OracleCommand _updateCommand;
        private readonly OracleCommand _updateScoreCommand;
        private readonly Serilog.ILogger _logger;
        private int _batchSize = 100;

        public OracleDatabase(string connectionString, Serilog.ILogger logger)
        {
            _connectionString = connectionString;
            _logger = logger;

            _updateCommand = new OracleCommand(@"
            UPDATE NIF_NINU
            SET FIRSTNAME = :FIRSTNAME,
                NAME = :NAME,
                GENDER = :GENDER,
                MIDDLENAME = :MIDDLENAME,
                PHONENUMBER = :PHONENUMBER,
                DAT_NAIS = :BIRTH_DATE,
                OLDNIN = :OLDNIN,
                RESIDENCECODLOC = :RESIDENCECODLOC,
                RESIDENCEADDRESS = :RESIDENCEADDRESS,
                COUNTRYOFBIRTH = :COUNTRYOFBIRTH,
                DEPARTMENTOFBIRTH = :DEPARTMENTOFBIRTH,
                COMMUNEOFBIRTH = :COMMUNEOFBIRTH,
                PLACEOFBIRTH = :PLACEOFBIRTH,
                SCORE = :SCORE
            WHERE NIN = :NIN");

            // Paramètres de la commande
            _updateCommand.Parameters.Add(":FIRSTNAME", OracleDbType.Varchar2);
            _updateCommand.Parameters.Add(":NAME", OracleDbType.Varchar2);
            _updateCommand.Parameters.Add(":GENDER", OracleDbType.Char);
            _updateCommand.Parameters.Add(":MIDDLENAME", OracleDbType.Varchar2);
            _updateCommand.Parameters.Add(":PHONENUMBER", OracleDbType.Varchar2);
            _updateCommand.Parameters.Add(":BIRTH_DATE", OracleDbType.Date);
            _updateCommand.Parameters.Add(":OLDNIN", OracleDbType.Varchar2);
            _updateCommand.Parameters.Add(":RESIDENCECODLOC", OracleDbType.Varchar2);
            _updateCommand.Parameters.Add(":RESIDENCEADDRESS", OracleDbType.Varchar2);
            _updateCommand.Parameters.Add(":COUNTRYOFBIRTH", OracleDbType.Varchar2);
            _updateCommand.Parameters.Add(":DEPARTMENTOFBIRTH", OracleDbType.Varchar2);
            _updateCommand.Parameters.Add(":COMMUNEOFBIRTH", OracleDbType.Varchar2);
            _updateCommand.Parameters.Add(":PLACEOFBIRTH", OracleDbType.Varchar2);
            _updateCommand.Parameters.Add(":SCORE", OracleDbType.Int32);
            _updateCommand.Parameters.Add(":NIN", OracleDbType.Int64);

            _updateScoreCommand = new OracleCommand(@"UPDATE NIF_NINU SET  SCORE =-1 WHERE NIN = :NIN");
            _updateScoreCommand.Parameters.Add(":NIN", OracleDbType.Int64);
        }

        public List<long> GetNins()
        {
            List<long> nins = new List<long>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand("SELECT NIN FROM nifninu.NIF_NINU WHERE SCORE=0", connection))
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nins.Add(reader.GetInt64(0)); // Utilisation de GetInt64 car NIN est NUMBER(11,0)
                    }
                }
            }
            return nins;
        }


        public List<long> GetNinsBatch(int offset, int batchSize)
        {
            var nins = new List<long>();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                        SELECT NIN
                        FROM (
                            SELECT NIN, ROW_NUMBER() OVER (ORDER BY NIN) AS row_num
                            FROM NIF_NINU
                            WHERE SCORE = 0
                        )
                        WHERE row_num BETWEEN :StartRow AND :EndRow";

                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(":StartRow", OracleDbType.Int32).Value = offset;
                    command.Parameters.Add(":EndRow", OracleDbType.Int32).Value = offset + batchSize - 1;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nins.Add(reader.GetInt64(0)); // Récupérer la colonne NIN
                        }
                    }
                }
            }

            return nins;
        }

        public int GetTotalNinsCount()
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM NIF_NINU WHERE SCORE = 0";

                using (var command = new OracleCommand(query, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }


        public async Task<bool> UpdateNifNinu(long nin, Personne data)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    _updateCommand.Connection = connection;

                    _updateCommand.Parameters[":FIRSTNAME"].Value = data.FirstName;
                    _updateCommand.Parameters[":NAME"].Value = data.LastName;
                    _updateCommand.Parameters[":GENDER"].Value = data.Gender;
                    _updateCommand.Parameters[":MIDDLENAME"].Value = data.MiddleName;
                    _updateCommand.Parameters[":PHONENUMBER"].Value = data.PhoneNumber;
                    _updateCommand.Parameters[":BIRTH_DATE"].Value = data.BirthDate;
                    _updateCommand.Parameters[":OLDNIN"].Value = data.OldNIN;
                    _updateCommand.Parameters[":RESIDENCECODLOC"].Value = data.ResidenceCodLoc;
                    _updateCommand.Parameters[":RESIDENCEADDRESS"].Value = data.ResidenceAddress;
                    _updateCommand.Parameters[":COUNTRYOFBIRTH"].Value = data.CountryOfBirth;
                    _updateCommand.Parameters[":DEPARTMENTOFBIRTH"].Value = data.DepartmentOfBirth;
                    _updateCommand.Parameters[":COMMUNEOFBIRTH"].Value = data.CommuneOfBirth;
                    _updateCommand.Parameters[":PLACEOFBIRTH"].Value = data.PlaceOfBirth;
                    _updateCommand.Parameters[":SCORE"].Value = 95;
                    _updateCommand.Parameters[":NIN"].Value = nin;
                    await _updateCommand.ExecuteNonQueryAsync();
                    return true;
                }

            }
            catch (Exception ex)
            {
                _logger.Information($"Mise à jour réussie pour NIN {nin}");
                return false;
            }




        }


        public async Task UpdateNifNinuBatch(List<(long nin, Personne? data)> batchData)
        {
            int batchCount = 0;

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    _updateCommand.Connection = connection;
                    _updateCommand.Transaction = transaction;

                    _updateScoreCommand.Connection = connection;
                    _updateScoreCommand.Transaction = transaction;

                    try
                    {

                        foreach (var record in batchData)
                        {
                            if (record.data == null)
                            {
                                _updateScoreCommand.Parameters[":NIN"].Value = record.nin;
                                await _updateScoreCommand.ExecuteNonQueryAsync();
                            }
                            else
                            {
                                _updateCommand.Parameters[":FIRSTNAME"].Value = record.data.FirstName;
                                _updateCommand.Parameters[":NAME"].Value = record.data.LastName;
                                _updateCommand.Parameters[":GENDER"].Value = record.data.Gender;
                                _updateCommand.Parameters[":MIDDLENAME"].Value = record.data.MiddleName;
                                _updateCommand.Parameters[":PHONENUMBER"].Value = record.data.PhoneNumber;
                                _updateCommand.Parameters[":BIRTH_DATE"].Value = record.data.BirthDate;
                                _updateCommand.Parameters[":OLDNIN"].Value = record.data.OldNIN;
                                _updateCommand.Parameters[":RESIDENCECODLOC"].Value = record.data.ResidenceCodLoc;
                                _updateCommand.Parameters[":RESIDENCEADDRESS"].Value = record.data.ResidenceAddress;
                                _updateCommand.Parameters[":COUNTRYOFBIRTH"].Value = record.data.CountryOfBirth;
                                _updateCommand.Parameters[":DEPARTMENTOFBIRTH"].Value = record.data.DepartmentOfBirth;
                                _updateCommand.Parameters[":COMMUNEOFBIRTH"].Value = record.data.CommuneOfBirth;
                                _updateCommand.Parameters[":PLACEOFBIRTH"].Value = record.data.PlaceOfBirth;
                                _updateCommand.Parameters[":SCORE"].Value = 95;
                                _updateCommand.Parameters[":NIN"].Value = record.nin;

                                await _updateCommand.ExecuteNonQueryAsync();
                            }
                            batchCount++;
                        }

                        transaction.Commit();
                        _logger.Information($"Batch de {batchCount} enregistrements mis à jour avec succès.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _logger.Error($"Erreur lors de la mise à jour batch : {ex.Message}");
                    }
                }
            }
        }


        //public async Task UpdateNifNinuBatch(List<(long nin, Personne data)> records)
        //{
        //    int batchCount = 0;

        //    using (OracleConnection connection = new OracleConnection(_connectionString))
        //    {
        //        await connection.OpenAsync();
        //        var transaction = connection.BeginTransaction();

        //        _updateCommand.Connection = connection;
        //        _updateCommand.Transaction = transaction;

        //        try
        //        {
        //            foreach (var record in records)
        //            {
        //                // Paramétrer la commande avec les données de l'enregistrement
        //                _updateCommand.Parameters[":FIRSTNAME"].Value = record.data.FirstName;
        //                _updateCommand.Parameters[":NAME"].Value = record.data.LastName;
        //                _updateCommand.Parameters[":GENDER"].Value = record.data.Gender;
        //                _updateCommand.Parameters[":MIDDLENAME"].Value = record.data.MiddleName;
        //                _updateCommand.Parameters[":PHONENUMBER"].Value = record.data.PhoneNumber;
        //                _updateCommand.Parameters[":BIRTH_DATE"].Value = record.data.BirthDate;
        //                _updateCommand.Parameters[":OLDNIN"].Value = record.data.OldNIN;
        //                _updateCommand.Parameters[":RESIDENCECODLOC"].Value = record.data.ResidenceCodLoc;
        //                _updateCommand.Parameters[":RESIDENCEADDRESS"].Value = record.data.ResidenceAddress;
        //                _updateCommand.Parameters[":COUNTRYOFBIRTH"].Value = record.data.CountryOfBirth;
        //                _updateCommand.Parameters[":DEPARTMENTOFBIRTH"].Value = record.data.DepartmentOfBirth;
        //                _updateCommand.Parameters[":COMMUNEOFBIRTH"].Value = record.data.CommuneOfBirth;
        //                _updateCommand.Parameters[":PLACEOFBIRTH"].Value = record.data.PlaceOfBirth;
        //                _updateCommand.Parameters[":SCORE"].Value = 95;
        //                _updateCommand.Parameters[":NIN"].Value = record.nin;

        //                await _updateCommand.ExecuteNonQueryAsync();

        //                batchCount++;

        //                // Commit après chaque batch de 100
        //                if (batchCount % _batchSize == 0)
        //                {
        //                    transaction.Commit();
        //                    _logger.Information($"{batchCount} mises à jour validées.");
        //                    transaction.Dispose();

        //                    transaction = connection.BeginTransaction();
        //                    _updateCommand.Transaction = transaction;
        //                }
        //            }

        //            // Commit final seulement s'il y a des mises à jour restantes
        //            if (batchCount % _batchSize != 0)
        //            {
        //                transaction.Commit();
        //                _logger.Information("Dernières mises à jour validées.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            _logger.Error($"Erreur lors de la mise à jour en batch : {ex.Message}");
        //        }
        //        finally
        //        {
        //            transaction.Dispose(); // Assurez-vous que la transaction est toujours nettoyée
        //        }
        //    }

        //}


    }
}
