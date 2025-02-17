using Microsoft.Extensions.Configuration;
using RifopLibrary;
using Serilog;
using System.Diagnostics;

namespace RifopImportForms
{
    public partial class MainForm : Form
    {
        private readonly OracleDatabase _db;
        private readonly CitizenApiClient _apiClient;
        private readonly Serilog.ILogger _logger;
        private string _oracleConnectionString;
        private Stopwatch stopwatch = new Stopwatch();
        private CancellationTokenSource _cts;

        private int delayRetries = 2;
        private int currentAttempt = 0;

        public MainForm()
        {
            InitializeComponent();

            string _oracleConnectionString = Program.Configuration.GetConnectionString("DefaultConnection");


            _logger = Serilog.Log.Logger;

            _db = new OracleDatabase(_oracleConnectionString, _logger);
            _apiClient = new CitizenApiClient(_logger);

        }



        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (_cts != null)
            {
                _logger.Information("Le traitement est déjà en cours.");
                return;
            }

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            delayRetries = 2;
            currentAttempt = 0;

            bool completed = false;

            while (delayRetries < 60 && !completed && !token.IsCancellationRequested)
            {
                try
                {
                    await ProcessAllDataAsync(token);
                    completed = true; // Si on arrive ici, c'est que tout s'est bien passé
                }
                catch (OperationCanceledException)
                {
                    _logger.Information("Mise à jour annulée par l'utilisateur.");
                    MessageBox.Show("Le traitement a été annulé.");
                    break; // On sort définitivement
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException oex)
                {
                    currentAttempt++;

                    if (delayRetries < 60)
                    {
                        _logger.Error($"Erreur réseau Oracle {oex.Number} (tentative {currentAttempt}). Pause de {delayRetries} minutes avant reprise.");
                        await Task.Delay(TimeSpan.FromMinutes(delayRetries), token);
                        delayRetries += 5;
                        // On relance depuis le début, donc on continue la boucle
                        continue;
                    }
                    else
                    {
                        _logger.Error($"Erreur réseau Oracle après {delayRetries} minutes : {oex.Message}");
                        MessageBox.Show("Echec après trop de tentatives réseau.");
                    }
                    break; // On sort de la boucle
                }
                catch (Exception ex)
                {
                    currentAttempt++;
                    // Tester si c'est un code HTTP 500 dans l'exception 
                    // (vous pouvez lever une exception custom quand l'API renvoie 500)

                    if (delayRetries < 60)
                    {
                        _logger.Error($"Erreur : {ex.Message}. (tentative {currentAttempt}). Pause de {delayRetries} minutes avant reprise.");
                        await Task.Delay(TimeSpan.FromMinutes(delayRetries), token);
                        delayRetries += 5;
                        continue;
                    }
                    else
                    {
                        _logger.Error($"Erreur après {delayRetries} minutes de tentatives : {ex.Message}");
                        MessageBox.Show("Echec après trop de tentatives API.");
                    }

                    break;
                }
            }

            // On libère le CancellationTokenSource
            _cts.Dispose();
            _cts = null;
        }

        private bool IsHttp500Error(Exception ex)
        {
            // Vous pourriez lever une exception custom "Http500Exception" dans l'appel API
            // ou vérifier l'InnerException, etc.
            // Exemple simpliste :
            return ex.Message.Contains("Internal Server Error");
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_cts != null)
            {
                _logger.Information("Interruption en cours...");
                _cts.Cancel(); // Demande l'annulation
            }
            else
            {
                _logger.Information("Aucun traitement en cours à interrompre.");
            }
        }


        private void UpdateProgressBar(int count)
        {
            progressBar1.Invoke((Action)(() =>
            {
                progressBar1.Value += count;

                var current = progressBar1.Value;
                var total = progressBar1.Maximum;

                lblProgress.Text = $"Progression : {current}/{total} ({(current * 100.0 / total):F2}%)";

                // Temps moyen par enregistrement (en secondes)
                double averageTimePerRecord = stopwatch.Elapsed.TotalSeconds / current;

                // Temps restant estimé
                double remainingTimeInSeconds = (total - current) * averageTimePerRecord;

                TimeSpan remainingTime = TimeSpan.FromSeconds(remainingTimeInSeconds);

                lblTimeRemaining.Text = $"Temps restant : {remainingTime:hh\\:mm\\:ss}";
            }));

            Application.DoEvents(); // Met à jour l'interface utilisateur
        }

        private async Task<List<(long nin, Personne? data)>> FetchBatchCitizenData(List<long> batch, CancellationToken token)
        {
            var batchData = new List<(long, Personne?)>();

            foreach (var nin in batch)
            {
                token.ThrowIfCancellationRequested(); // Vérifie si l'annulation a été demandée

                try
                {
                    var data = await _apiClient.GetCitizenDataAsync(nin);
                    if (data != null)
                    {
                        batchData.Add((nin, data));
                    }
                    else
                    {
                        batchData.Add((nin, data));
                        _logger.Error($"Données manquantes pour le NIN {nin}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"Erreur lors de la récupération des données pour le NIN {nin}: {ex.Message}");
                }
            }

            return batchData;
        }

        private async Task ProcessAllDataAsync(CancellationToken token)
        {
            int batchSize = 20; // Taille d'un lot
            int offset = 0;
            bool hasMoreRecords = true;

            // Récupérer le nombre total d'enregistrements
            int totalRecords = _db.GetTotalNinsCount();
            progressBar1.Maximum = totalRecords;
            progressBar1.Value = 0; // On repart à zéro
            stopwatch.Restart();

            while (hasMoreRecords && !token.IsCancellationRequested)
            {
                // Récupérer les NINs par lot
                var nins = _db.GetNinsBatch(offset, batchSize);
                if (nins.Count == 0)
                {
                    hasMoreRecords = false;
                    break;
                }

                // Récupérer les données pour le batch
                var batchData = await FetchBatchCitizenData(nins, token);

                // Mettre à jour en batch
                await _db.UpdateNifNinuBatch(batchData);

                // Mise à jour de la progression
                UpdateProgressBar(nins.Count);

                currentAttempt = 0;
                delayRetries = 2;
                //offset += batchSize;
            }

            stopwatch.Stop();
            if (!token.IsCancellationRequested)
            {
                _logger.Information("Mise à jour terminée avec succès.");
                MessageBox.Show("Mise à jour terminée.");
            }
            else
            {
                _logger.Information("Mise à jour interrompue par l'utilisateur.");
            }
        }


    }
}
