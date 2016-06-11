using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PictureId { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual List<Modality> Modalities { get; set; }
        public virtual List<Customer> Customers { get; set; }
        
        public Sport()
        {
            Modalities = new List<Modality>();
            Customers = new List<Customer>();
        }        
    }
}
