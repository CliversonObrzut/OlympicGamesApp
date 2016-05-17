using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class FavoriteAthlete
    {
        public int CustomerId { get; set; }
        public int AthleteId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Athlete Athlete { get; set; }
    }
}
