using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models.Mapping
{
    public class CompetitionEventMap : EntityTypeConfiguration<CompetitionEvent>
    {
        public CompetitionEventMap()
        {
            this.Property(c => c.Date)
                .HasColumnType("date")
                .IsRequired();

            this.Property(c => c.Time)
                .HasColumnType("time")
                .IsRequired();

            this.Property(c => c.BasePrice)
                .HasColumnType("money")
                .HasPrecision(18,2)
                .IsRequired();
        }
    }
}
