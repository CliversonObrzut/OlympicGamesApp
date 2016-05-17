using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class FavoriteModality
    {
        public int CustomerId { get; set; }
        public int ModalityId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Modality Modality { get; set; }
    }
}
