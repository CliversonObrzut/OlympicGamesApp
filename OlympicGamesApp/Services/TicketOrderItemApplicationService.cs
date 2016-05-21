using OlympicGamesApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGamesApp.Services
{
    public class TicketOrderItemApplicationService
    {
        protected OlympicDbContext _context;

        public TicketOrderItemApplicationService(OlympicDbContext context)
        {
            _context = context;
        }

        public TicketOrderItem CreateTicketOrderItem(int ticketOrderId, int ticketEventId, int quantity, TicketEvent ticketEvent)
        {
            var ticketOrderItem = new TicketOrderItem()
            {
                TicketOrderId = ticketOrderId,
                TicketEventId = ticketEventId,
                UnitItemPrice = ticketEvent.TicketPrice,
                Quantity = quantity,
                TotalItemPrice = ticketEvent.TicketPrice * quantity
            };

            _context.TicketOrderItems.Add(ticketOrderItem);
            _context.SaveChanges();

            return ticketOrderItem;
        }

        public TicketOrderItem UpdateTicketOrderItem(int id, int ticketOrderId, int ticketEventId, int quantity, TicketEvent ticketEvent)
        {
            var ticketOrderItem = _context.TicketOrderItems.Find(id);

            if (ticketOrderItem == null)
            {
                throw new InvalidOperationException("No customer with the provided id was found!");
            }

            ticketOrderItem.TicketOrderId = ticketOrderId;
            ticketOrderItem.TicketEventId = ticketEventId;
            ticketOrderItem.UnitItemPrice = ticketEvent.TicketPrice;
            ticketOrderItem.Quantity = quantity;
            ticketOrderItem.TotalItemPrice = ticketEvent.TicketPrice * quantity;

            _context.SaveChanges();
            return ticketOrderItem;
        }

        public void DeleteTicketOrderItem(int? id)
        {
            var ticketOrderItem = _context.TicketOrderItems.Find(id);

            if (ticketOrderItem == null)
            {
                throw new InvalidOperationException("No customer with the provided id was found!");
            }

            _context.TicketOrderItems.Remove(ticketOrderItem);
            _context.SaveChanges();
        }
    }
}
