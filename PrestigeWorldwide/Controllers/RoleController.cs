using Microsoft.AspNet.Identity.EntityFramework;
using PrestigeWorldwide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrestigeWorldwide.Controllers
{   
    public class RoleController : Controller
    {
        ApplicationDbContext _context;
        // GET: Role

        public RoleController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var Roles = _context.Roles.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            _context.Roles.Add(Role);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}