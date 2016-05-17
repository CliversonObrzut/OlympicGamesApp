using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class FavoriteSport
    {
        public int CustomerId { get; set; }
        public int SportId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Sport Sport { get; set; }
    }
}
