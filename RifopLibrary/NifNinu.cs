using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RifopLibrary
{


    [Table("NIF_NINU")]
    public class NifNinu
    {
        [Key]
        public int Id { get; set; }

        [Column(name: "TAXPAYER_NIF")]
        public string TaxpayerNif { get; set; }

        public string Name { get; set; }

        public string Firstname { get; set; }
        
        [Column(name: "BIRTH_DATE")]
        public DateTime? BirthDate { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        [Column(name: "DAT_NAIS")]
        public DateTime? DateNaissance { get; set; }

        public long? Nin { get; set; }


        public string MiddleName { get; set; }

        public string ResidenceCodLoc { get; set; }

        public string ResidenceAddress { get; set; }

        public string Gender { get; set; }

        public string PlaceOfBirth { get; set; }

        public string CountryOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string CommuneOfBirth { get; set; }

        public string DepartmentOfBirth { get; set; }

        public string OldNIN { get; set; }


    }

}
