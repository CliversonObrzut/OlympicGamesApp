using OlympicGamesApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.UI.ViewModels.TicketOrder
{
    public class TicketOrderDetailsViewModel
    {
        [Display(Name = "Order Number")]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Product Code")]
        public int TicketEventId { get; set; }

        public string FirstName { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Total Cost")]
        [DataType(DataType.Currency)]
        public decimal TotalCost { get; set; }

        [Display(Name = "Ticket Name")]
        public string TicketDescription { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Unit Price")]
        [DataType(DataType.Currency)]
        public decimal UnitItemPrice { get; set; }

        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        public decimal TotalItemPrice { get; set; }

        public List<OlympicGamesApp.DataAccess.Models.TicketOrderItem> TicketOrderItems { get; set; }
    }
}
