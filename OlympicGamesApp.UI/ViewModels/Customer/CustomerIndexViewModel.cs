using OlympicGamesApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.UI.ViewModels.Customer
{
    public class CustomerIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Picture")]
        public string ThumStringData { get; set; }

        public int? PictureId { get; set; }

        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        [Display(Name ="City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

    }
}
