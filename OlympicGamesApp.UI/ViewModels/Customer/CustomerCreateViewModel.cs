using OlympicGamesApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OlympicGamesApp.UI.ViewModels.Customer
{
    public class CustomerCreateViewModel
    {
        [Required(ErrorMessage = "First Name is required!")]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage ="First name must not be longer than 50 characters!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        [Display(Name ="Last Name")]
        [StringLength(50, ErrorMessage = "Last name must not be longer than 50 characters!")]
        public string LastName { get; set; }

        [Display(Name = "Middle Names")]
        [StringLength(100, ErrorMessage = "Middle names must not be longer than 100 characters!")]
        public string MiddleNames { get; set; }

        [Required(ErrorMessage = "Gender is required!")]
        public int GenderId { get; set; }

        public SelectList Genders { get; set; }

        [Required(ErrorMessage = "Date of birth is required!")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Street Address is required!")]
        [Display(Name = "Street Address")]
        [StringLength(100, ErrorMessage = "Street Address must have less than 100 characters!")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Suburb is required!")]
        [StringLength(50, ErrorMessage = "Suburb must not be longer than 50 characters!")]
        public string Suburb { get; set; }

        [Required(ErrorMessage = "City is required!")]
        [StringLength(50, ErrorMessage = "City must not be longer than 50 characters!")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required!")]
        [StringLength(50, ErrorMessage = "State must not be longer than 50 characters!")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required!")]
        [StringLength(50, ErrorMessage = "Country must not be longer than 50 characters!")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Post Code is required!")]
        [Display(Name = "Post Code")]
        [StringLength(10, ErrorMessage = "Post code must not be longer than 10 characters!")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "Login is required!")]
        [StringLength(100, ErrorMessage = "Login must not be longer than 100 characters!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [StringLength(50, ErrorMessage = "Password must not be longer than 50 characters!")]
        public string Password { get; set; }

        public int? PictureId { get; set; }

        public bool ExistingUser { get; set; }
    }
}
