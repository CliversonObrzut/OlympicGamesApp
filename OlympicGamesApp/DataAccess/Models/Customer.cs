using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.DataAccess.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleNames { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryId { get; set; }
        public int GenderId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string AddressStreet { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public string State { get; set; }
        public virtual Country Country { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual List<TicketOrder> TicketOrders { get; set; }
        public virtual List<FavoriteAthlete> FavoriteAthletes { get; set; }
        public virtual List<FavoriteCountry> FavoriteCountries { get; set; }
        public virtual List<FavoriteModality> FavoriteModalities { get; set; }
        public virtual List<FavoriteSport> FavoriteSports { get; set; }

        public Customer()
        {
            TicketOrders = new List<TicketOrder>();
            FavoriteAthletes = new List<FavoriteAthlete>();
            FavoriteCountries = new List<FavoriteCountry>();
            FavoriteModalities = new List<FavoriteModality>();
            FavoriteSports = new List<FavoriteSport>();
        }
    }
}
