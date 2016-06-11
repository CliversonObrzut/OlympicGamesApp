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
        public int? PictureId { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual List<Athlete> Athletes { get; set; }
        public virtual List<Customer> Customers { get; set; }
        
        public Country()
        {
            Athletes = new List<Athlete>();
            Customers = new List<Customer>();
        }
    }
}
