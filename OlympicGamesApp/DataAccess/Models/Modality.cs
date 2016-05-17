using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class Modality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModalityCategoryId { get; set; }
        public int SportId { get; set; }
        public virtual ModalityCategory ModalityCategory { get; set; }
        public virtual Sport Sport { get; set; }
    }
}
