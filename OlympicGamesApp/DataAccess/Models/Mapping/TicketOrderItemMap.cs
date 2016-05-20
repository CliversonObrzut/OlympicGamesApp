using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models.Mapping
{
    public class TicketOrderItemMap : EntityTypeConfiguration<TicketOrderItem>
    {
        public TicketOrderItemMap()
        {
            this.Property(t => t.Quantity)
                .HasColumnType("int")
                .IsRequired();

            this.Property(t => t.TotalLinePrice)
                .HasColumnType("money")
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}
