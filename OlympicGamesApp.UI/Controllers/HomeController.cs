using OlympicGamesApp.DataAccess.Models;
using OlympicGamesApp.UI.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlympicGamesApp.UI.Controllers
{
    public class HomeController : Controller
    {
        protected OlympicDbContext _context = new OlympicDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            var model = new HomeLoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeLoginViewModel model)
        {
            var identity = _context.Customers.FirstOrDefault(c => c.Login == model.Login && c.Password == model.Password);
            if (identity == null)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("cProfile", "Customer", new { id = identity.Id});
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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