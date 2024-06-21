using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Models
{
    public class Vol
    {
        public int Id { get; set; }
        public Pilot? Pilot { get; set; }
        public List<Activity>? Activities { get; set; }


        public string DeterminerTypeVol()
        {
            return "";
        }
        public DateTime CalculerFdp()
        {
            return DateTime.Now;
        }
        public Aeroport GetFromDestination()
        {
            return new Aeroport();
        }
        public Aeroport GetToDestination()
        {
            return new Aeroport();
        }
        public DateTime GetStartTime()
        {
            return DateTime.Now;
        }
        public DateTime GetEndTime()
        {
            return DateTime.Now;
        }
        public TimeSpan GetFlightDuration()
        {
            // Implémentez la logique pour calculer la durée du vol
            return TimeSpan.Zero;

        }
    }
}
