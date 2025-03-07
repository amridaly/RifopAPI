using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RifopLibrary
{
    public class Personne
    {
        public Personne() { }

        public Personne(ONICitoyenData citoyen) 
        { 

            NINU=long.Parse( citoyen.NINU);
            LastName=citoyen.LastName;
            MiddleName=citoyen.MiddleName;
            FirstName=citoyen.FirstName;
            BirthDate = citoyen.DateOfBirth ;
            Gender=citoyen.Gender;
            PlaceOfBirth = citoyen.PlaceOfBirthAbroad;
            ResidenceCodLoc=citoyen.ResidenceCodLoc;
            ResidenceAddress=citoyen.ResidenceAddress;
            CountryOfBirth=citoyen.CountryOfBirth;
            PhoneNumber=citoyen.PhoneNumber;
            CommuneOfBirth = citoyen.CommuneOfBirth;
            DepartmentOfBirth = citoyen.DepartmentOfBirth;

            OldNIN=citoyen.OldNIN;
        }

        public Personne(NifNinu nifNinu)
        {

            NINU = nifNinu.Nin.HasValue?nifNinu.Nin.Value:0;
            LastName = nifNinu.Name;
            MiddleName = nifNinu.MiddleName;
            FirstName = nifNinu.Prenom;
            BirthDate = nifNinu.BirthDate;
            Gender = nifNinu.Gender;
            PlaceOfBirth = nifNinu.PlaceOfBirth;
            ResidenceCodLoc = nifNinu.ResidenceCodLoc;
            ResidenceAddress = nifNinu.ResidenceAddress;
            CountryOfBirth = nifNinu.CountryOfBirth;
            PhoneNumber = nifNinu.PhoneNumber;
            CommuneOfBirth = nifNinu.CommuneOfBirth;
            DepartmentOfBirth = nifNinu.DepartmentOfBirth;

            OldNIN = nifNinu.OldNIN;
        }

        public Personne(ONICitizenIdentity citoyen)
        {

            NINU = citoyen.NINU;
            LastName = citoyen.LastName;
            MiddleName = citoyen.MiddleName;
            FirstName = citoyen.FirstName;
            BirthDate =DateTime.TryParse( citoyen.DateOfBirth,out DateTime d)?d:null;
            Gender = citoyen.Gender;
            PlaceOfBirth = citoyen.PlaceOfBirth;
            ResidenceCodLoc = citoyen.ResidenceCodLoc.ToString();
            ResidenceAddress = citoyen.ResidenceAddress;
            CountryOfBirth = citoyen.CountryOfBirth;
            PhoneNumber = citoyen.PhoneNumber;
        }

        public int Id { get; set; }

        [Required]
        public long NINU { get; set; }

        [Required]
        [StringLength(20)]
        public string NIF { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }


        public string? MiddleName { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }


        public string? Gender { get; set; }


        public string? PlaceOfBirth { get; set; }


        public string? ResidenceCodLoc { get; set; }


        public string? ResidenceAddress { get; set; }


        public string? DepartmentOfBirth { get; set; }


        public string? CommuneOfBirth { get; set; }

        public string? CountryOfBirth { get; set; }


        public string? PhoneNumber { get; set; }

        public string? OldNIN { get; set; }
    }


    public class Photo
    {
        public string Ninu { get; set; }

        public string? Data { get; set; }

        public double Score { get; set; }

    }
}
