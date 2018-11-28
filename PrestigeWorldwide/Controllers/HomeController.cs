using PrestigeWorldwide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrestigeWorldwide.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Administrator, PortalAdmin, User")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Administrator, PortalAdmin, User")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Administrator, PortalAdmin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Role()
        {
            ViewBag.Message = "Role Access";

            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Register()
        {
            ViewBag.Message = "Register Employees";

            return View();
        }
    }
}