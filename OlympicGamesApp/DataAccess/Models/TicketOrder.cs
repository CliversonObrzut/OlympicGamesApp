using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class TicketOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalCost { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<TicketOrderItem> TicketOrderItems { get; set; }

        public TicketOrder()
        {
            TicketOrderItems = new List<TicketOrderItem>();
        }
    }
}
