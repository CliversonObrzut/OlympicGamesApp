using OlympicGamesApp.DataAccess.Models;
using SharpRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.Services
{
    public class CustomerApplicationService
    {
        private IRepository<Customer> _customerRepository;
        private IRepository<Picture> _pictureRepository;

        public CustomerApplicationService(IRepository<Customer> customerRepository, IRepository<Picture> pictureRepository)
        {
            _customerRepository = customerRepository;
            _pictureRepository = pictureRepository;
        }

        public Customer CreateCustomer(string firstName, string lastName, DateTime dateOfBirth, int genderId, string streetAddress, string suburb, string city, string state, string country, string postCode, string login, string password, int? pictureId, string middleNames = null)
        {
            var customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleNames = middleNames,
                DateOfBirth = dateOfBirth,
                GenderId = genderId,
                StreetAddress = streetAddress,
                Suburb = suburb,
                City = city,
                State = state,
                Country = country,
                PostCode = postCode,
                Login = login,
                Password = password,
                PictureId = genderId
            };

            _customerRepository.Add(customer);

            return customer;
        }

        public Customer UpdateCustomer(int id, string firstName, string lastName, DateTime dateOfBirth, int genderId, string streetAddress, string suburb, string city, string state, string country, string postCode, string password, string middleNames /*List<Country> favoriteCountries, List<Athlete> favoriteAthletes, List<Sport> favoriteSports, List<Modality> favoriteModalities*/)
        {
            var customer = _customerRepository.Get(id);

            if (customer == null)
            {
                throw new InvalidOperationException("No customer with the provided id was found!");
            }

            customer.FirstName = firstName;
            customer.MiddleNames = middleNames;
            customer.LastName = lastName;
            customer.DateOfBirth = dateOfBirth;
            customer.GenderId = genderId;
            customer.StreetAddress = streetAddress;
            customer.Suburb = suburb;
            customer.City = city;
            customer.State = state;
            customer.Country = country;
            customer.PostCode = postCode;
            customer.Password = password;
            //customer.Athletes = favoriteAthletes;
            //customer.Countries = favoriteCountries;
            //customer.Sports = favoriteSports;
            //customer.Modalities = favoriteModalities;

            _customerRepository.Update(customer);
            return customer;
        }

        public Customer UpdateCustomerPicture(int id, int pictureId)
        {
            var customer = _customerRepository.Get(id);

            if (customer == null)
            {
                throw new InvalidOperationException("No customer with the provided id was found!");
            }

            customer.PictureId = pictureId;

            _customerRepository.Update(customer);
            return customer;
        }

        public void DeleteCustomer(int id)
        {
            var customer = _customerRepository.Get(id);

            if (customer == null)
            {
                throw new InvalidOperationException("No customer with the provided id was found!");
            }

            var pictureId = customer.PictureId;

            _customerRepository.Delete(customer);

            if (pictureId > 2)
            {
                var picture = _pictureRepository.Get((int)pictureId);
                _pictureRepository.Delete(picture);
            }
        }
    }
}
