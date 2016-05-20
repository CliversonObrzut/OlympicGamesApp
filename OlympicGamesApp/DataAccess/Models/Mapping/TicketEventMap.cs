using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models.Mapping
{
    public class TicketEventMap : EntityTypeConfiguration<TicketEvent>
    {
        public TicketEventMap()
        {
            this.Property(t => t.Description)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            this.Property(t => t.TicketPrice)
                .HasColumnType("money")
                .HasPrecision(18, 2)
                .IsRequired();

            this.Property(t => t.TicketsAvailable)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
