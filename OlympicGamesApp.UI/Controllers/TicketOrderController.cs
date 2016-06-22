using OlympicGamesApp.DataAccess.Models;
using OlympicGamesApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OlympicGamesApp.UI.ViewModels.TicketOrder;
using SharpRepository.EfRepository;
using System.Net;
using OlympicGamesApp.UI.ViewModels.TicketOrderItem;

namespace OlympicGamesApp.UI.Controllers
{
    public class TicketOrderController : Controller
    {
        protected OlympicDbContext _context;
        protected TicketOrderApplicationService _ticketOrderService;
        protected EfRepository<TicketOrder> _ticketOrderRepository;

        public TicketOrderController()
        {
            _context = new OlympicDbContext();
            _ticketOrderRepository = new EfRepository<TicketOrder>(_context);
            _ticketOrderService = new TicketOrderApplicationService(_ticketOrderRepository);
        }

        // GET: Index
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                var model = _context.TicketOrders.ToList()
                    .Select(t => new TicketOrderIndexViewModel()
                    {
                        Id = t.Id,
                        PurchaseDate = t.PurchaseDate,
                        TotalCost = t.TotalCost,                        
                    });
                ViewBag.Name = "Manager,";
                ViewBag.Id = null;
                return View(model);
            }
            else
            {
                var model = _context.TicketOrders.ToList()
                    .Select(t => new TicketOrderIndexViewModel()
                    {
                        Id = t.Id,
                        FirstName = t.Customer.FirstName,
                        PurchaseDate = t.PurchaseDate,
                        TotalCost = t.TotalCost,
                        CustomerId = t.CustomerId
                    })
                    .Where(t => t.CustomerId == id);

                var customer = _context.Customers.Find(id);
                ViewBag.Name = customer.FirstName + ",";
                ViewBag.Id = id;
                return View(model);
            }
        }

        //GET: Details
        public ActionResult Details (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ticketOrder = _ticketOrderRepository.Get((int)id);
            
            if (ticketOrder == null)
            {
                return HttpNotFound();
            }

            var model = new TicketOrderDetailsViewModel()
            {
                Id = ticketOrder.Id,
                CustomerId = ticketOrder.CustomerId,
                FirstName = ticketOrder.Customer.FirstName,
                PurchaseDate = ticketOrder.PurchaseDate,
                TotalCost = ticketOrder.TotalCost,
                TicketOrderItems = ticketOrder.TicketOrderItems
            };

            return View(model);
        }

        //GET: Create
        public ActionResult Create (int id)
        {
            var customer = _context.Customers.Find(id);

            var model = new TicketOrderCreateViewModel()
            {
                FirstName = customer.FirstName,
                PurchaseDate = DateTime.Now,
                CustomerId = customer.Id,
                lineNumber = 1
            };
            model.TicketEvents = new SelectList(_context.TicketEvents, "Id", "Description", null);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(TicketOrderCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    List<TicketOrderItem> ticketOrderItems = new List<TicketOrderItem>();

                    foreach (var item in model.TicketOrderItemModel)
                    {
                        var ticket = new TicketOrderItem()
                        {
                            TicketEventId = item.TicketEventId,
                            Quantity = item.Quantity,
                        };
                        var thisTicket = _context.TicketEvents.Find(ticket.TicketEventId);
                        ticket.UnitItemPrice = thisTicket.TicketPrice;
                        ticket.TotalItemPrice = ticket.UnitItemPrice * ticket.Quantity;
                        ticketOrderItems.Add(ticket);
                    }

                    _ticketOrderService.CreateTicketOrder(model.CustomerId, model.PurchaseDate, ticketOrderItems);
                    return RedirectToAction("Index", new { id = model.CustomerId });
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e);
                }
            }

            foreach (var item in model.TicketOrderItemModel)
            {
                item.TicketEvents = new SelectList(_context.TicketEvents, "Id", "Description", item.TicketEventId);
            }

            model.TicketEvents = new SelectList(_context.TicketEvents, "Id", "Description", null);           
            return View(model);
        }

        public ActionResult GetTicketOrderItemForm(int pos)
        {
            var model = new TicketOrderCreateViewModel();
            model.TicketEvents = new SelectList(_context.TicketEvents, "Id", "Description", null);
            ViewBag.Pos = pos;
            return PartialView("_TicketOrderItemForm", model);
        }

        public string GetTicketUnitPrice(int ticketId)
        {
            var ticketEvent = _context.TicketEvents.Find(ticketId);
            var unitItemPrice = ticketEvent.TicketPrice;
            var unitItemPriceString = String.Format("{0:c}", unitItemPrice);
            
            return unitItemPriceString;
        }

        public string GetTicketTotalPrice(int ticketId, int quantity)
        {
            var ticketEvent = _context.TicketEvents.Find(ticketId);
            var totalItemPrice = ticketEvent.TicketPrice * quantity;
            var totalItemPriceString = String.Format("{0:c}", totalItemPrice);

            return totalItemPriceString;
        }

        public string ConvertTotalCostToCurrency(decimal totalCost)
        {
            var totalCostAsCurrency = String.Format("{0:c}", totalCost);
            return totalCostAsCurrency;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
                _context = null;
            }
            base.Dispose(disposing);
        }
    }
}