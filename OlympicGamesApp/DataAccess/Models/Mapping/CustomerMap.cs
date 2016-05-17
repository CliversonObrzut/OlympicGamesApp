using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.Property(c => c.FirstName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.MiddleNames)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            this.Property(c => c.LastName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.DateOfBirth)
                .HasColumnType("datetime")
                .IsRequired();

            this.Property(c => c.Login)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            this.Property(c => c.Password)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.AddressStreet)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            this.Property(c => c.Suburb)
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
