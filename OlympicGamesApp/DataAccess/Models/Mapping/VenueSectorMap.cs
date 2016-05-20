using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models.Mapping
{
    public class VenueSectorMap : EntityTypeConfiguration<VenueSector>
    {
        public VenueSectorMap()
        {
            this.Property(v => v.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(v => v.Multiplier)
                .HasColumnType("money")
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}
