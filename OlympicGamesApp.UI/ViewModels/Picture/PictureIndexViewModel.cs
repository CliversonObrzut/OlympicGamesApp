using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.UI.ViewModels.Picture
{
    public class PictureIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Picture")]
        public string ThumStringData { get; set; }

        [Display(Name = "File name")]
        public string ImageFileName { get; set; }

        [Display(Name ="Content Type")]
        public string ImageContentType { get; set; }
    }
}
