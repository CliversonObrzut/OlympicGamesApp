using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Athlete> Athletes { get; set; }
        public virtual List<Customer> Customers { get; set; }

        public Gender()
        {
            Athletes = new List<Athlete>();
            Customers = new List<Customer>();
        }

    }
}
