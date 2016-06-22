using OlympicGamesApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.UI.ViewModels.Customer
{
    public class CustomerDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Picture")]
        public string ThumStringData { get; set; }

        public int? PictureId { get; set; }

        public string FirstName { get; set; }

        [Display(Name = "Name")]
         public string FullName { get; set; }

        [Display(Name ="Gender")]
        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        public string Password { get; set; }

        [Display(Name = "Favorite Countries")]
        public List<OlympicGamesApp.DataAccess.Models.Country> FavoriteCountries { get; set; }

        [Display(Name = "Favorite Athletes")]
        public List<OlympicGamesApp.DataAccess.Models.Athlete> FavoriteAthletes { get; set; }

        [Display(Name = "Favorite Sports")]
        public List<OlympicGamesApp.DataAccess.Models.Sport> FavoriteSports { get; set; }

        [Display(Name = "Favorite Modalities")]
        public List<OlympicGamesApp.DataAccess.Models.Modality> FavoriteModalities { get; set; }
    }
}
