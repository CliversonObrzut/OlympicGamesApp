using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models.Mapping
{
    public class VenueMap : EntityTypeConfiguration<Venue>
    {
        public VenueMap()
        {
            this.Property(t => t.Name)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            this.Property(t => t.AddressStreet)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            this.Property(t => t.Suburb)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.City)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.State)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.Postal)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
