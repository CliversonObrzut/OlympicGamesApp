using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.UI.ViewModels.TicketOrder
{
    public class TicketOrderIndexViewModel
    {
        [Display(Name = "Order Number")]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Total Cost")]
        [DataType(DataType.Currency)]
        public decimal TotalCost { get; set; }
    }
}
