using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hackathon.Feature.CustomNavigationController.Controllers
{
    public class CustomNavigationController : Controller
    {
        // GET: Navigation
        public ActionResult Index()
        {
            return View("navigation");
        }
    }
}