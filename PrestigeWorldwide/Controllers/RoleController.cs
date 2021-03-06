﻿using Microsoft.AspNet.Identity.EntityFramework;
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
        private ApplicationDbContext context = new ApplicationDbContext();
        // GET: Role

        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Roles
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(context.Roles.ToList());
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {


            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                context.Roles.Add(new IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                context.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully !";
                return View("Create");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(string RoleName)
        {
            var thisRole = context.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(thisRole);
            context.SaveChanges();
            return RedirectToAction("Create");
        }

        [Authorize(Roles = "Administrator")]
        // GET: /Roles/Edit/5
        public ActionResult Edit(string roleName)
        {
            var thisRole = context.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            return View(thisRole);
        }

        [Authorize(Roles = "Administrator")]
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}