using OlympicGamesApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.Services
{
    public class TicketOrderApplicationService
    {
        protected OlympicDbContext _context;

        public TicketOrderApplicationService(OlympicDbContext context)
        {
            _context = context;
        }

        public TicketOrder CreateTicketOrder(int customerId, DateTime purchaseDate, List<TicketOrderItem> ticketOrderItems)
        {
            decimal totalCost = ticketOrderItems.Sum(t => t.TotalItemPrice);
            var ticketOrder = new TicketOrder()
            {
                CustomerId = customerId,
                PurchaseDate = purchaseDate,
                TotalCost = totalCost
            };

            _context.TicketOrders.Add(ticketOrder);
            _context.SaveChanges();

            return ticketOrder;
        }

        public TicketOrder UpdateTicketOrder(int id, int customerId, DateTime purchaseDate, List<TicketOrderItem> ticketOrderItems)
        {
            var ticketOrder = _context.TicketOrders.Find(id);

            if (ticketOrder == null)
            {
                throw new InvalidOperationException("No customer with the provided id was found!");
            }

            decimal totalCost = ticketOrderItems.Sum(t => t.TotalItemPrice);
            ticketOrder.CustomerId = customerId;
            ticketOrder.PurchaseDate = purchaseDate;
            ticketOrder.TotalCost = totalCost;

            _context.SaveChanges();
            return ticketOrder;
        }

        public void DeleteTicketOrder(int? id)
        {
            var ticketOrder = _context.TicketOrders.Find(id);

            if (ticketOrder == null)
            {
                throw new InvalidOperationException("No customer with the provided id was found!");
            }

            _context.TicketOrders.Remove(ticketOrder);
            _context.SaveChanges();
        }
    }
}
