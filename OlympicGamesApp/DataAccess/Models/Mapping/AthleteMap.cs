using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models.Mapping
{
    public class AthleteMap : EntityTypeConfiguration<Athlete>
    {
        public AthleteMap()
        {
            this.Property(a => a.FirstName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(a => a.MiddleNames)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            this.Property(a => a.LastName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(a => a.DateOfBirth)
                .HasColumnType("datetime")
                .IsRequired();

            this.Property(a => a.GoldMedal)
                .HasColumnType("int")
                .IsRequired();

            this.Property(a => a.SilverMedal)
                .HasColumnType("int")
                .IsRequired();

            this.Property(a => a.BronzeMedal)
                .HasColumnType("int")
                .IsRequired();

        }
    }
}
