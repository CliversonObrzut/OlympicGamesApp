using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OlympicGamesApp.UI.ViewModels.TicketOrderItem
{
    public class TicketOrderItemIndexViewModel
    {
        [Required(ErrorMessage = "The ticket is required!")]
        [Display(Name = "Ticket Name")]
        public int TicketEventId { get; set; }

        public SelectList TicketEvents { get; set; }

        [Required(ErrorMessage = "The quantity is required")]
        [Range(1, 10, ErrorMessage = "The quantity should be between 1 and 10!")]
        public int Quantity { get; set; }

        [Display(Name = "Unit Price")]
        [DataType(DataType.Currency)]
        public decimal UnitItemPrice { get; set; }

        [Display(Name = "Total Item Price")]
        [DataType(DataType.Currency)]
        public decimal TotalItemPrice { get; set; }
                
    }
}
