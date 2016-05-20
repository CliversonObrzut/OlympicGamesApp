using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models.Mapping
{
    public class ModalityCategoryMap : EntityTypeConfiguration<ModalityCategory>
    {
        public ModalityCategoryMap()
        {
            this.Property(m => m.Name)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
