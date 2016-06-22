using OlympicGamesApp.UI.ViewModels.TicketOrderItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OlympicGamesApp.UI.ViewModels.TicketOrder
{
    public class TicketOrderCreateViewModel
    {
        public int CustomerId { get; set; }

        public int lineNumber { get; set; }

        public SelectList TicketEvents { get; set; }

        public string FirstName { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Total Cost")]
        [DataType(DataType.Currency)]
        public decimal TotalCost { get; set; }

        public List<TicketOrderItemIndexViewModel> TicketOrderItemModel { get; set; }
 
    }
}
