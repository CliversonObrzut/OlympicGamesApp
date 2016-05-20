using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models.Mapping
{
    public class TicketOrderMap : EntityTypeConfiguration<TicketOrder>
    {
        public TicketOrderMap()
        {
            this.Property(t => t.PurchaseDate)
                .HasColumnType("datetime")
                .IsRequired();

            this.Property(t => t.TotalCost)
                .HasColumnType("money")
                .HasPrecision(18, 2)
                .IsRequired();

        }
    }
}
