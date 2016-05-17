using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class FavoriteCountry
    {
        public int CustomerId { get; set; }
        public int CountryId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Country Country { get; set; }
    }
}
