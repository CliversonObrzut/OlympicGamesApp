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
    public class TicketOrderApplicationServiceTests
    {
        [Fact]
        public void CreateTicketOrder_ShouldCreateValidTicketOrder()
        {
            //Fixture Setup
            var ticketOrderRepo = new InMemoryRepository<TicketOrder>();
            var ticketOrderService = new TicketOrderApplicationService(ticketOrderRepo);

            var ticketOrderItems = new List<TicketOrderItem>()
            {
                new TicketOrderItem { Id = 1, TicketEventId = 1, TicketOrderId = 1, UnitItemPrice = 45.5m, Quantity = 3, TotalItemPrice = 136.5m},
                new TicketOrderItem { Id = 2, TicketEventId = 2, TicketOrderId = 1, UnitItemPrice = 180m, Quantity = 5, TotalItemPrice = 900m},
                new TicketOrderItem { Id = 3, TicketEventId = 3, TicketOrderId = 1, UnitItemPrice = 160m, Quantity = 4, TotalItemPrice = 640m}
            };

            var expected = new TicketOrder()
            {
                CustomerId = 1,
                PurchaseDate = DateTime.Parse("05/05/2016 19:15:23"),
                TicketOrderItems = ticketOrderItems,
                TotalCost = 1676.5m
            };

            //Exercise the SUT (system under test)
            ticketOrderService.CreateTicketOrder(
                expected.CustomerId,
                expected.PurchaseDate,
                expected.TicketOrderItems
                );
                
            
            // State Verification
            var actual = ticketOrderRepo.AsQueryable().FirstOrDefault();

            Assert.Equal(1, ticketOrderRepo.Count());
            Assert.Equal(expected.CustomerId, actual.CustomerId);
            Assert.Equal(expected.PurchaseDate, actual.PurchaseDate);
            //Assert.Equal(expected.TicketOrderItems, actual.TicketOrderItems);
            Assert.Equal(expected.TotalCost, actual.TotalCost);
        }

        [Fact]
        public void UpdateTicketOrder_ShouldUpdateValidTicketOrder()
        {
            //Fixture Setup
            var ticketOrderItems = new List<TicketOrderItem>()
            {
                new TicketOrderItem { Id = 1, TicketEventId = 1, TicketOrderId = 1, UnitItemPrice = 45.5m, Quantity = 3, TotalItemPrice = 136.5m},
                new TicketOrderItem { Id = 2, TicketEventId = 2, TicketOrderId = 1, UnitItemPrice = 180m, Quantity = 5, TotalItemPrice = 900m},
                new TicketOrderItem { Id = 3, TicketEventId = 3, TicketOrderId = 1, UnitItemPrice = 160m, Quantity = 4, TotalItemPrice = 640m}
            };

            var ticketOrder = new TicketOrder()
            {
                CustomerId = 1,
                PurchaseDate = DateTime.Parse("05/05/2016 19:15:23"),
                TicketOrderItems = ticketOrderItems,
                TotalCost = 1676.5m
            };

            var ticketOrderRepo = new InMemoryRepository<TicketOrder>();
            ticketOrderRepo.Add(ticketOrder);
            var ticketOrderService = new TicketOrderApplicationService(ticketOrderRepo);
            //added the fourth line
            var ticketOrderItemsUpdated = new List<TicketOrderItem>()
            {
                new TicketOrderItem { Id = 1, TicketEventId = 1, TicketOrderId = 1, UnitItemPrice = 45.5m, Quantity = 3, TotalItemPrice = 136.5m},
                new TicketOrderItem { Id = 2, TicketEventId = 2, TicketOrderId = 1, UnitItemPrice = 180m, Quantity = 5, TotalItemPrice = 900m},
                new TicketOrderItem { Id = 3, TicketEventId = 3, TicketOrderId = 1, UnitItemPrice = 160m, Quantity = 4, TotalItemPrice = 640m},
                new TicketOrderItem { Id = 4, TicketEventId = 4, TicketOrderId = 2, UnitItemPrice = 120m, Quantity = 8, TotalItemPrice = 960m}
            };

            var expected = new TicketOrder() //changed the date and time
            {
                CustomerId = 1,
                PurchaseDate = DateTime.Parse("10/05/2016 10:12:55"),
                TicketOrderItems = ticketOrderItemsUpdated,
                TotalCost = 2636.5m
            };

            //Exercise the SUT (system under test)
            ticketOrderService.UpdateTicketOrder(
                ticketOrder.Id,
                expected.CustomerId,
                expected.PurchaseDate,
                expected.TicketOrderItems);

            // State Verification
            var actual = ticketOrderRepo.Get(ticketOrder.Id);

            Assert.Equal(1, ticketOrderRepo.Count());
            Assert.Equal(expected.CustomerId, actual.CustomerId);
            Assert.Equal(expected.PurchaseDate, actual.PurchaseDate);
            //Assert.Equal(expected.TicketOrderItems, actual.TicketOrderItems);
            Assert.Equal(expected.TotalCost, actual.TotalCost);
        }
    }
}
