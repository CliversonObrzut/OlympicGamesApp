using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models.Mapping
{
    public class ModalityMap : EntityTypeConfiguration<Modality>
    {
        public ModalityMap()
        {
            this.Property(m => m.Name)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
