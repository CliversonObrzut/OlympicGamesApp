using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models.Mapping
{
    public class GenderMap : EntityTypeConfiguration<Gender>
    {
        public GenderMap()
        {
            this.Property(g => g.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
