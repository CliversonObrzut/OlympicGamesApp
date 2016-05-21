using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class TicketOrderItem
    {
        public int Id { get; set; }
        public int TicketOrderId { get; set; }
        public int TicketEventId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitItemPrice { get; set; }
        public decimal TotalItemPrice { get; set; }
        public virtual TicketOrder TicketOrder { get; set; }
        public virtual TicketEvent TicketEvent { get; set; }
    }
}
