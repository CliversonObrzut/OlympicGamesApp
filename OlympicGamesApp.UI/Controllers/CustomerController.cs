using OlympicGamesApp.DataAccess.Models;
using OlympicGamesApp.Services;
using OlympicGamesApp.UI.ViewModels.Customer;
using SharpRepository.EfRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OlympicGamesApp.UI.Controllers
{
    public class CustomerController : Controller
    {
        protected OlympicDbContext _context;
        protected EfRepository<Customer> _customerRepository;
        protected EfRepository<Picture> _pictureRepository;
        protected CustomerApplicationService _customerService;
        protected PictureApplicationService _pictureService;

        public CustomerController()
        {
            _context = new OlympicDbContext();
            _customerRepository = new EfRepository<Customer>(_context);
            _pictureRepository = new EfRepository<Picture>(_context);
            _pictureService = new PictureApplicationService(_pictureRepository, _customerRepository);
            _customerService = new CustomerApplicationService(_customerRepository, _pictureRepository);
        }
        
        // GET: Index
        public ActionResult Index()
        {
            var model = _customerRepository.AsQueryable().ToList()
                .Select(c => new CustomerIndexViewModel()
                {
                    Id = c.Id,
                    FullName = c.FirstName + " " + c.MiddleNames + " " + c.LastName,
                    City = c.City,
                    State = c.State,
                    Country = c.Country,
                    PictureId = c.PictureId,
                    FileName = c.Picture.ImageFileName,
                    ThumStringData = String.Format("data:{0};base64,{1}", c.Picture.ThumbnailContentType, Convert.ToBase64String(c.Picture.Thumbnail))
                });
            return View(model);
        }

        //GET: Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = _customerRepository.Get((int)id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var model = new CustomerDetailsViewModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                FullName = customer.FirstName + " " + customer.MiddleNames + " " + customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender.Name,
                StreetAddress = customer.StreetAddress,
                Suburb = customer.Suburb,
                City = customer.City,
                State = customer.State,
                Country = customer.Country,
                PostCode = customer.PostCode,
                PictureId = customer.PictureId                
            };

            return View(model);
        }
        // GET: Customer Profile
        public ActionResult cProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = _customerRepository.Get((int)id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            List<Athlete> athletes = _context.Athletes.ToList()
                .Where(a => a.Customers
                .Any(c => c.Id == customer.Id))
                .ToList();

            List<Country> countries = _context.Countries.ToList()
                .Where(a => a.Customers
                .Any(c => c.Id == customer.Id))
                .ToList();

            List<Sport> sports = _context.Sports.ToList()
                .Where(a => a.Customers
                .Any(c => c.Id == customer.Id))
                .ToList();

            List<Modality> modalities = _context.Modalities.ToList()
                .Where(a => a.Customers
                .Any(c => c.Id == customer.Id))
                .ToList();

            List<CompetitionEvent> competitionEvents = _context.CompetitionEvents.ToList()
                .Where(a => a.Date >= DateTime.Now)
                .OrderBy(a => a.Date).ToList();

            var model = new CustomerProfileViewModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                FullName = customer.FirstName + " " + customer.MiddleNames + " " + customer.LastName,       
                PictureId = customer.PictureId,
                FavoriteAthletes = athletes,
                FavoriteCountries = countries,
                FavoriteSports = sports,
                FavoriteModalities = modalities,
                CompetitionEvents = competitionEvents
            };

            return View(model);
        }

        //GET: Create
        public ActionResult Create()
        {
            var model = new CustomerCreateViewModel();
            model.Genders = new SelectList(_context.Genders, "Id", "Name", null);
            return View(model);
        }

        //POST: Create
        [HttpPost]
        public ActionResult Create(CustomerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var identity = _context.Customers.FirstOrDefault(c => c.Login == model.Login);
                    if (identity == null)
                    {
                        var customer = _customerService.CreateCustomer(model.FirstName, model.LastName, model.DateOfBirth, model.GenderId, model.StreetAddress, model.Suburb, model.City, model.State, model.Country, model.PostCode, model.Login, model.Password, model.PictureId, model.MiddleNames);
                        return RedirectToAction("cProfile", new { id = customer.Id });
                    }
                    model.ExistingUser = true;                   
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e);
                }
            }
            model.Genders = new SelectList(_context.Genders, "Id", "Name", model.GenderId);
            return View(model);
        }

        //GET: Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var model = new CustomerEditViewModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                MiddleNames = customer.MiddleNames,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                GenderId = customer.GenderId,
                StreetAddress = customer.StreetAddress,
                Suburb = customer.Suburb,
                City = customer.City,
                State = customer.State,
                Country = customer.Country,
                PostCode = customer.PostCode,
                Password = customer.Password
            };
            model.Genders = new SelectList(_context.Genders, "Id", "Name", model.GenderId);

            return View(model);
        }

        //POST: Edit
        [HttpPost]
        public ActionResult Edit(int? id, CustomerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _customerService.UpdateCustomer(model.Id, model.FirstName, model.LastName, model.DateOfBirth, model.GenderId, model.StreetAddress, model.Suburb, model.City, model.State, model.Country, model.PostCode, model.Password, model.MiddleNames);
                    return RedirectToAction("Details", new { id = model.Id});
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e);
                }
            }
            model.Genders = new SelectList(_context.Genders, "Id", "Name", model.GenderId);
            return View(model);
        }

        //GET: Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var model = new CustomerDetailsViewModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                FullName = customer.FirstName + " " + customer.MiddleNames + " " + customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender.Name,
                StreetAddress = customer.StreetAddress,
                Suburb = customer.Suburb,
                City = customer.City,
                State = customer.State,
                Country = customer.Country,
                PostCode = customer.PostCode,
                PictureId = customer.PictureId
            };

            return View(model);
        }

        //POST: Delete
        [HttpPost]
        public ActionResult Delete(CustomerDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _customerService.DeleteCustomer(model.Id);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e);
                }
            }

            return View(model);
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