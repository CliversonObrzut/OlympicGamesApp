using OlympicGamesApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.Services
{
    public class CustomerApplicationService
    {
        protected OlympicDbContext _context;

        public CustomerApplicationService(OlympicDbContext context)
        {
            _context = context;
        }

        public Customer CreateCustomer(string firstName, string lastName, DateTime dateOfBirth, int genderId, string streetAddress, string suburb, string city, string state, string country, string postCode, string login, string password, string middleNames = null)
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
                Password = password
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public Customer UpdateCustomer(int id, string firstName, string lastName, DateTime dateOfBirth, int genderId, string streetAddress, string suburb, string city, string state, string country, string postCode, string login, string password, string middleNames = null)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                throw new InvalidOperationException("No customer with the provided id was found!");
            }

            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.MiddleNames = middleNames;
            customer.DateOfBirth = dateOfBirth;
            customer.GenderId = genderId;
            customer.StreetAddress = streetAddress;
            customer.Suburb = suburb;
            customer.City = city;
            customer.State = state;
            customer.Country = country;
            customer.PostCode = postCode;
            customer.Login = login;
            customer.Password = password;


            _context.SaveChanges();
            return customer;
        }

        public void DeleteCustomer(int? id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                throw new InvalidOperationException("No customer with the provided id was found!");
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
