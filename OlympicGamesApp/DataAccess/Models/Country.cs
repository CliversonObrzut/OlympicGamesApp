using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GoldMedal { get; set; }
        public int SilverMedal { get; set; }
        public int BronzeMedal { get; set; }
    }
}
