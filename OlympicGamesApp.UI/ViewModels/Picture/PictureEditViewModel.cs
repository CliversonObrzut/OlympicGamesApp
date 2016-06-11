using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.UI.ViewModels.Picture
{
    public class PictureEditViewModel
    {
        [Display(Name = "Select New File")]
        public int PictureId { get; set; }

        [Display(Name = "Picture")]
        public string ThumStringData { get; set; }
    }
}
