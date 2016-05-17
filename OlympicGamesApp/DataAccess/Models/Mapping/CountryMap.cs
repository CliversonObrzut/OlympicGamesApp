using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models.Mapping
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
        {
            this.Property(c => c.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.GoldMedal)
                .HasColumnType("int")
                .IsRequired();

            this.Property(c => c.SilverMedal)
                .HasColumnType("int")
                .IsRequired();

            this.Property(c => c.BronzeMedal)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
