using OlympicGamesApp.DataAccess.Models;
using OlympicGamesApp.Services;
using OlympicGamesApp.UI.ViewModels.Athlete;
using SharpRepository.EfRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlympicGamesApp.UI.Controllers
{
    public class AthleteController : Controller
    {
        protected OlympicDbContext _context;
        protected EfRepository<Customer> _customerRepository;
        protected EfRepository<Picture> _pictureRepository;
        protected CustomerApplicationService _customerService;
        protected PictureApplicationService _pictureService;

        public AthleteController()
        {
            _context = new OlympicDbContext();
            _customerRepository = new EfRepository<Customer>(_context);
            _pictureRepository = new EfRepository<Picture>(_context);
            _pictureService = new PictureApplicationService(_pictureRepository, _customerRepository);
            _customerService = new CustomerApplicationService(_customerRepository, _pictureRepository);
        }

        // GET: Athlete
        public ActionResult Index(int? id)
        {
            var customer = _context.Customers.Find(id);

            var model = _context.Athletes
                .Select(a => new AthleteIndexViewModel()
                {
                    Id = a.Id,
                    PictureId = a.PictureId,
                    CountryPictureId = a.Country.PictureId,
                    CountryName = a.Country.Name,
                    FullName = a.FirstName + " " + a.MiddleNames + " " + a.LastName,
                    DateOfBirth = a.DateOfBirth,
                    Gender = a.Gender.Name,
                    GoldMedal = a.GoldMedal,
                    SilverMedal = a.SilverMedal,
                    BronzeMedal = a.BronzeMedal,
                    CountryId = a.CountryId                                   
                })
                .OrderBy(a => a.CountryName).ToList();

            foreach (var athlete in model)
            {
                foreach (var favoriteAthlete in customer.Athletes)
                {
                    if (favoriteAthlete.Id == athlete.Id)
                    {
                        var i = model.IndexOf(athlete);
                        model[i].Favorite = true;
                    }
                }
            }
            ViewBag.CustomerName = customer.FirstName;
            ViewBag.CustomerId = customer.Id;

            return View(model);
        }

        //[HttpPost]
        //public ActionResult Index(IEnumerable<AthleteIndexViewModel> model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var customer = _context.Customers.Find(ViewBag.CustomerId);
        //            //var customerUpdated = _customerService.UpdateCustomer()
        //            return RedirectToAction("cProfile", new { id = customer.Id });
        //        }
        //        catch (Exception e)
        //        {
        //            ModelState.AddModelError("", e);
        //        }
        //    }
        //    return View(model);
        //}

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