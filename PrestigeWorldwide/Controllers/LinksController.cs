using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrestigeWorldwide.Models;

namespace PrestigeWorldwide.Controllers
{
    public class LinksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Links
        public ActionResult Index()
        {
            //PortalAdmin
            if (User.IsInRole("PortalAdmin"))
            {
                var collection1 = db.Links.Where(r => r.Role == "PortalAdmin").ToList<Links>();
                var collection2 = db.Links.Where(r => r.Role == "User").ToList<Links>();
                var combine = collection1.Concat(collection2);
                return View(combine);
            }
            else if (User.IsInRole("User"))
            {
                var collection = db.Links.Where(r => r.Role == "User").ToList<Links>();
                return View(collection);
            }
            else
            {
                return View(db.Links.ToList());
            }
        }

        // GET: Links/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Links links = db.Links.Find(id);
            if (links == null)
            {
                return HttpNotFound();
            }
            return View(links);
        }

        // GET: Links/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Links/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "LinkId,LinkUrl,Role")] Links links)
        {
            if (ModelState.IsValid)
            {
                db.Links.Add(links);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(links);
        }

        // GET: Links/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Links links = db.Links.Find(id);
            if (links == null)
            {
                return HttpNotFound();
            }
            return View(links);
        }

        // POST: Links/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "LinkId,LinkUrl,Role")] Links links)
        {
            if (ModelState.IsValid)
            {
                db.Entry(links).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(links);
        }

        // GET: Links/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Links links = db.Links.Find(id);
            if (links == null)
            {
                return HttpNotFound();
            }
            return View(links);
        }

        // POST: Links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Links links = db.Links.Find(id);
            db.Links.Remove(links);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
