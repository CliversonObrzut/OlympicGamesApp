using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class VenueSector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Multiplier { get; set; }
        public int VenueId { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual List<TicketEvent> TicketEvents { get; set; }

        public VenueSector()
        {
            TicketEvents = new List<TicketEvent>();
        }
        
    }
}
