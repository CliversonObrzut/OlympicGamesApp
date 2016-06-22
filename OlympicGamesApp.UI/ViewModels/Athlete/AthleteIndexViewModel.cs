using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.UI.ViewModels.Athlete
{
    public class AthleteIndexViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name ="Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name ="Gender")]
        public string Gender { get; set; }

        [Display(Name ="Gold Medal")]
        public int GoldMedal { get; set; }

        [Display(Name ="Silver Medal")]
        public int SilverMedal { get; set; }

        [Display(Name ="Bronze Medal")]
        public int BronzeMedal { get; set; }

        [Display(Name ="Picture")]
        public int? PictureId { get; set; }

        public int? CountryPictureId { get; set; }

        [Display(Name =" My Favorites")]
        public bool Favorite { get; set; }

        public List<bool> FavoriteAthletes { get; set; }
    }
}
