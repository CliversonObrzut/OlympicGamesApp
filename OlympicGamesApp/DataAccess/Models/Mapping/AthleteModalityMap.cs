using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models.Mapping
{
    public class AthleteModalityMap : EntityTypeConfiguration<AthleteModality>
    {
        public AthleteModalityMap()
        {
            this.HasKey(a => new { a.AthleteId, a.ModalityId });
        }
    }
}
