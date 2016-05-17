using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models.Mapping
{
    public class CompetitionEventTicketMap : EntityTypeConfiguration<CompetitionEventTicket>
    {
        public CompetitionEventTicketMap()
        {
            this.HasKey(c => new { c.CompetitionEventId, c.TicketEventId });
        }
    }
}
