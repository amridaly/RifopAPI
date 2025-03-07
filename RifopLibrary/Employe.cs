using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RifopLibrary
{

    [Table("SYSPAY_EMPLOYES")]
    public class Employe
    {
        [Key]

        [MaxLength(15)]
        public string EMPLOYE_ID { get; set; }
        
        [MaxLength(13)]
        public string? TAXPAYER_NIF { get; set; }

        [MaxLength(60)]
        public string? POSTE { get; set; }

        [Required]
        [MaxLength(25)]
        public string NOM { get; set; }
        [Required]
        [MaxLength(25)]
        public string PRENOM { get; set; }

        public DateTime? DATE_NOMINATION { get; set; }

        
        [MaxLength(30)]
        public string? AFFECTATION { get; set; }

        [MaxLength(1)]
        public string? SEXE { get; set; }

        [MaxLength(15)]
        public string? CIN { get; set; }


        public DateTime?  DATE_NAISSANCE { get; set; }

        [MaxLength(50)]
        public string? LIEU_NAISSANCE { get; set; }

        [Required]
        [MaxLength(20)]
        public string STATUT {  get; set; }
    }
}
