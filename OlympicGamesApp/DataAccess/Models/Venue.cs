using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressStreet { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public string State { get; set; }
        public virtual List<CompetitionEvent> CompetitionEvents { get; set; }
        public virtual List<VenueSector> VenueSectors { get; set; }

        public Venue()
        {
            CompetitionEvents = new List<CompetitionEvent>();
            VenueSectors = new List<VenueSector>();
        }
    }
}
