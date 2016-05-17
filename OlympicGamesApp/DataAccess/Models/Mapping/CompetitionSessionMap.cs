using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models.Mapping
{
    public class CompetitionSessionMap : EntityTypeConfiguration<CompetitionSession>
    {
        public CompetitionSessionMap()
        {
            this.Property(c => c.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
