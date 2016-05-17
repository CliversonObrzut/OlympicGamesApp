using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class AthleteModality
    {
        public int AthleteId { get; set; }
        public int ModalityId { get; set; }
        public virtual Athlete Athlete { get; set; }
        public virtual Modality Modality { get; set; }
    }
}
