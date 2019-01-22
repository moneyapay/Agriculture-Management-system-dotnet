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
    public class AdminFertilizerController : Controller
    {
        private AgricultureEntities3 db = new AgricultureEntities3();

        // GET: AdminFertilizer
        public ActionResult Index()
        {
            return View(db.AddFertilizers.ToList());
        }

        // GET: AdminFertilizer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddFertilizer addFertilizer = db.AddFertilizers.Find(id);
            if (addFertilizer == null)
            {
                return HttpNotFound();
            }
            return View(addFertilizer);
        }

        // GET: AdminFertilizer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminFertilizer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Used,Price,Description")] AddFertilizer addFertilizer)
        {
            if (ModelState.IsValid)
            {
                db.AddFertilizers.Add(addFertilizer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addFertilizer);
        }

        // GET: AdminFertilizer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddFertilizer addFertilizer = db.AddFertilizers.Find(id);
            if (addFertilizer == null)
            {
                return HttpNotFound();
            }
            return View(addFertilizer);
        }

        // POST: AdminFertilizer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Used,Price,Description")] AddFertilizer addFertilizer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addFertilizer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addFertilizer);
        }

        // GET: AdminFertilizer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddFertilizer addFertilizer = db.AddFertilizers.Find(id);
            if (addFertilizer == null)
            {
                return HttpNotFound();
            }
            return View(addFertilizer);
        }

        // POST: AdminFertilizer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddFertilizer addFertilizer = db.AddFertilizers.Find(id);
            db.AddFertilizers.Remove(addFertilizer);
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
