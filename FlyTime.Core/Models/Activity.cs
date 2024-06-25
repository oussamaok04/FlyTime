using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VolId { get; set; }
        
        [ForeignKey("VolId")]
        public Vol? Vol { get; set; }

        [Required]
        public Aeroport? FromDestination { get; set; }
        
        [Required]
        public Aeroport? ToDestination { get; set; }
        
        [Required]
        public TimeSpan StartTime { get; set; }
        
        [Required]
        public TimeSpan EndTime { get; set; }
        
        public TimeSpan CalculateDuration() 
        {
            return TimeSpan.Zero;
        }
    }
}
