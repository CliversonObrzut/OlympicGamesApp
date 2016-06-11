using OlympicGamesApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.UI.ViewModels.Customer
{
    public class CustomerProfileViewModel
    {
        public int Id { get; set; }

        [Display(Name = "")]
        public string ThumStringData { get; set; }

        public int? PictureId { get; set; }

        [Display(Name = "")]
        public string FullName { get; set; }

        [Display(Name = "")]
        public string FirstName { get; set; }

        [Display(Name = "Favorite Countries")]
        public List<Country> FavoriteCountries { get; set; }

        [Display(Name = "Favorite Athletes")]
        public List<Athlete> FavoriteAthletes { get; set; }

        [Display(Name = "Favorite Sports")]
        public List<Sport> FavoriteSports { get; set; }

        [Display(Name = "Favorite Modalities")]
        public List<Modality> FavoriteModalities { get; set; }
    }
}
