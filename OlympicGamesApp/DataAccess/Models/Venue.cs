using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressStreet { get; set; }
        public string Suburb { get; set; }
        public int Postal { get; set; }
        public string State { get; set; }
    }
}
