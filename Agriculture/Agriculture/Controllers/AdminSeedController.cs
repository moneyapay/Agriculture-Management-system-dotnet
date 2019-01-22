using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Agriculture.Models;

namespace Agriculture.Controllers
{
    public class AdminSeedController : Controller
    {
        private AgricultureEntities1 db = new AgricultureEntities1();

        // GET: AdminSeed
        public ActionResult Index()
        {
            return View(db.AddSeeds.ToList());
        }

        // GET: AdminSeed/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddSeed addSeed = db.AddSeeds.Find(id);
            if (addSeed == null)
            {
                return HttpNotFound();
            }
            return View(addSeed);
        }

        // GET: AdminSeed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminSeed/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Seed_id,SeedName,Season,Yield,Description,Price")] AddSeed addSeed)
        {
            if (ModelState.IsValid)
            {
                db.AddSeeds.Add(addSeed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addSeed);
        }

        // GET: AdminSeed/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddSeed addSeed = db.AddSeeds.Find(id);
            if (addSeed == null)
            {
                return HttpNotFound();
            }
            return View(addSeed);
        }

        // POST: AdminSeed/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Seed_id,SeedName,Season,Yield,Description,Price")] AddSeed addSeed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addSeed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addSeed);
        }

        // GET: AdminSeed/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddSeed addSeed = db.AddSeeds.Find(id);
            if (addSeed == null)
            {
                return HttpNotFound();
            }
            return View(addSeed);
        }

        // POST: AdminSeed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddSeed addSeed = db.AddSeeds.Find(id);
            db.AddSeeds.Remove(addSeed);
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
