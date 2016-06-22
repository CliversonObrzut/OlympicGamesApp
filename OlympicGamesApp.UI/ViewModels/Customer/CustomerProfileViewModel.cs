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

        public List<OlympicGamesApp.DataAccess.Models.Country> FavoriteCountries { get; set; }

        public List<OlympicGamesApp.DataAccess.Models.Athlete> FavoriteAthletes { get; set; }

        public List<OlympicGamesApp.DataAccess.Models.Sport> FavoriteSports { get; set; }

        public List<OlympicGamesApp.DataAccess.Models.Modality> FavoriteModalities { get; set; }

        public List<CompetitionEvent> CompetitionEvents { get; set; }
    }
}
