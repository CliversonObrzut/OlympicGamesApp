using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class CompetitionEvent
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int ModalityId { get; set; }
        public int CompetitionSessionId { get; set; }
        public int CompetitionPhaseId { get; set; }
        public int VenueId { get; set; }
        public decimal BasePrice { get; set; }
        public virtual Modality Modality { get; set; }
        public virtual CompetitionSession CompetitionSession { get; set; }
        public virtual CompetitionPhase CompetitionPhase { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual List<TicketEvent> TicketEvents { get; set; }

        public CompetitionEvent()
        {
            TicketEvents = new List<TicketEvent>();
        }

    }
}
