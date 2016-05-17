using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class TicketEvent
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal TicketPrice { get; set; }
        public int TicketsAvailable { get; set; }
        public int VenueSectorId { get; set; }
        public VenueSector VenueSector { get; set; }
    }
}
