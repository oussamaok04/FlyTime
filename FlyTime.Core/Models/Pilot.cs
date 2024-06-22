using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Models
{
    public class Pilot
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Matricule { get; set; } = "";
        
        [Required]
        public string Email { get; set; } = "";
        
        [Required]
        public string Password { get; set; } = "";
        
        public List<Vol>? Vols { get; set; }
    }
}
