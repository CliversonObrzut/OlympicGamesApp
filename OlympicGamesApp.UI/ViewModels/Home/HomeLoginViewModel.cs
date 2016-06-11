using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.UI.ViewModels.Home
{
    public class HomeLoginViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "The password is required")]
        public string Password { get; set; }
    }
}
