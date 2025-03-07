using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RifopLibrary
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public String Nom { get; set; }

        [Required]
        [StringLength(50)]
        public String Login { get; set; }

        [Required]
        [StringLength(100)]
        [JsonPropertyName("pwd")]
        public String Password { get; set; }

        [Required]
        [StringLength(20)]

        public String Status { get; set; }
    }
}
