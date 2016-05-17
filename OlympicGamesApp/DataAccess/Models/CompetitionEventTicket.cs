using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class CompetitionEventTicket
    {
        public int CompetitionEventId { get; set; }
        public int TicketEventId { get; set; }
        public CompetitionEvent CompetitionEvent { get; set; }
        public TicketEvent TicketEvent { get; set; }
    }
}
