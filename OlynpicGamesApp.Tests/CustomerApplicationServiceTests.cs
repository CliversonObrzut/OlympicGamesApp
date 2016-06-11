using OlympicGamesApp.DataAccess.Models;
using OlympicGamesApp.Services;
using SharpRepository.InMemoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OlynpicGamesApp.Tests
{
    public class CustomerApplicationServiceTests
    {
        [Fact]
        public void CreateCustomer_ShouldCreateValidCustomer()
        {
            //Fixture Setup
            var customerRepo = new InMemoryRepository<Customer>();
            var pictureRepo = new InMemoryRepository<Picture>();
            var customerService = new CustomerApplicationService(customerRepo, pictureRepo);

            var expected = new Customer()
            {
                FirstName = "Cliverson",
                MiddleNames = "Thomas",
                LastName = "Obrzut",
                DateOfBirth = DateTime.Parse("30/04/1982"),
                GenderId = 1,
                StreetAddress = "57, Howard Ave",
                Suburb = "Dee Why",
                City = "Sydney",
                State = "NSW",
                Country = "Australia",
                PostCode = "2099",
                Login = "cliver_82@hotmail.com",
                Password = "olympic1",
                PictureId = 1

            };

            //Exercise the SUT (system under test)
            customerService.CreateCustomer(
                expected.FirstName,
                expected.LastName, 
                expected.DateOfBirth, 
                expected.GenderId, 
                expected.StreetAddress, 
                expected.Suburb, 
                expected.City, 
                expected.State, 
                expected.Country, 
                expected.PostCode, 
                expected.Login, 
                expected.Password, 
                expected.PictureId, 
                expected.MiddleNames);
            
            // State Verification
            var actual = customerRepo.AsQueryable().FirstOrDefault();

            Assert.Equal(1, customerRepo.Count());
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal(expected.DateOfBirth, actual.DateOfBirth);
            Assert.Equal(expected.GenderId, actual.GenderId);
            Assert.Equal(expected.StreetAddress, actual.StreetAddress);
            Assert.Equal(expected.Suburb, actual.Suburb);
            Assert.Equal(expected.City, actual.City);
            Assert.Equal(expected.State, actual.State);
            Assert.Equal(expected.Country, actual.Country);
            Assert.Equal(expected.PostCode, actual.PostCode);
            Assert.Equal(expected.Login, actual.Login);
            Assert.Equal(expected.Password, actual.Password);
            Assert.Equal(expected.PictureId, actual.PictureId);
            Assert.Equal(expected.MiddleNames, actual.MiddleNames);

        }

        [Fact]
        public void UpdateCustomer_ShouldUpdateValidCustomer()
        {
            //Fixture Setup
            var customer = new Customer()
            {
                FirstName = "Vera",
                MiddleNames = "Lucia",
                LastName = "Obrzut",
                DateOfBirth = DateTime.Parse("25/01/1959"),
                GenderId = 2,
                StreetAddress = "456, Alberto Panek",
                Suburb = "Orleans",
                City = "Curitiba",
                State = "PR",
                Country = "Brasil",
                PostCode = "81280-270",
                Login = "vera_obrzut@yahoo.com.br",
                Password = "olympic2",
                PictureId = 4
            };
            var customerRepo = new InMemoryRepository<Customer>();
            var pictureRepo = new InMemoryRepository<Picture>();
            customerRepo.Add(customer);
            var customerService = new CustomerApplicationService(customerRepo, pictureRepo);

            var expected = new Customer()
            {
                FirstName = "Cliverson",
                MiddleNames = "Thomas",
                LastName = "Obrzut",
                DateOfBirth = DateTime.Parse("30/04/1982"),
                GenderId = 1,
                StreetAddress = "57, Howard Ave",
                Suburb = "Dee Why",
                City = "Sydney",
                State = "NSW",
                Country = "Australia",
                PostCode = "2099",
                Login = "cliver_82@hotmail.com",
                Password = "olympic1",
                PictureId = 3
            };

            //Exercise the SUT (system under test)
            customerService.UpdateCustomer(
                customer.Id,
                expected.FirstName,
                expected.LastName,
                expected.DateOfBirth,
                expected.GenderId,
                expected.StreetAddress,
                expected.Suburb,
                expected.City,
                expected.State,
                expected.Country,
                expected.PostCode,
                expected.Password,
                expected.MiddleNames);

            // State Verification
            var actual = customerRepo.Get(customer.Id);

            Assert.Equal(1, customerRepo.Count());
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal(expected.DateOfBirth, actual.DateOfBirth);
            Assert.Equal(expected.GenderId, actual.GenderId);
            Assert.Equal(expected.StreetAddress, actual.StreetAddress);
            Assert.Equal(expected.Suburb, actual.Suburb);
            Assert.Equal(expected.City, actual.City);
            Assert.Equal(expected.State, actual.State);
            Assert.Equal(expected.Country, actual.Country);
            Assert.Equal(expected.PostCode, actual.PostCode);
            Assert.Equal(expected.Password, actual.Password);
            Assert.Equal(expected.MiddleNames, actual.MiddleNames);
        }
    }
}
