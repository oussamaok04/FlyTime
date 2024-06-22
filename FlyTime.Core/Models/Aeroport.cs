using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Models
{
    public class Aeroport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Code { get; set; } = "";

        [Required]
        public string City { get; set; } = "";

        [Required]
        public string Country { get; set; } = "";
    }
}
