using OlympicGamesApp.DataAccess.Models;
using SharpRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.Services
{
    public class TicketOrderApplicationService
    {
        private IRepository<TicketOrder> _ticketOrderRepository;
        private OlympicDbContext _context = new OlympicDbContext();

        public TicketOrderApplicationService(IRepository<TicketOrder> ticketOrderRepository)
        {
            _ticketOrderRepository = ticketOrderRepository;
        }

        public TicketOrder CreateTicketOrder(int customerId, DateTime purchaseDate, List<TicketOrderItem> ticketOrderItems)
        {
            decimal totalCost = ticketOrderItems.Sum(t => t.TotalItemPrice);
            var ticketOrder = new TicketOrder()
            {
                CustomerId = customerId,
                PurchaseDate = purchaseDate,
                TotalCost = totalCost,
                TicketOrderItems = ticketOrderItems
            };

            _ticketOrderRepository.Add(ticketOrder);

            return ticketOrder;
        }

        public TicketOrder UpdateTicketOrder(int id, int customerId, DateTime purchaseDate, List<TicketOrderItem> ticketOrderItems)
        {
            var ticketOrder = _ticketOrderRepository.Get(id);

            if (ticketOrder == null)
            {
                throw new InvalidOperationException("No customer with the provided id was found!");
            }

            decimal totalCost = ticketOrderItems.Sum(t => t.TotalItemPrice);
            ticketOrder.CustomerId = customerId;
            ticketOrder.PurchaseDate = purchaseDate;
            ticketOrder.TotalCost = totalCost;
            ticketOrder.TicketOrderItems = ticketOrderItems;

            _ticketOrderRepository.Update(ticketOrder);
            return ticketOrder;
        }

        public void DeleteTicketOrder(int? id)
        {
            var ticketOrder = _ticketOrderRepository.Get((int)id);

            if (ticketOrder == null)
            {
                throw new InvalidOperationException("No customer with the provided id was found!");
            }

            _ticketOrderRepository.Delete(ticketOrder);
        }
    }
}
