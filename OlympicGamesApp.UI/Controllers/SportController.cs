﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlympicGamesApp.UI.Controllers
{
    public class SportController : Controller
    {
        // GET: Sport
        public ActionResult Index()
        {
            return View();
        }
    }
}