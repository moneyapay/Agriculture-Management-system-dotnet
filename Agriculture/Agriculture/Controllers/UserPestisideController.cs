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
    public class UserPestisideController : Controller
    {
        private AgricultureEntities4 db = new AgricultureEntities4();

        // GET: UserPestiside
        public ActionResult Index()
        {
            return View(db.AddPestisides.ToList());
        }

        // GET: UserPestiside/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddPestiside addPestiside = db.AddPestisides.Find(id);
            if (addPestiside == null)
            {
                return HttpNotFound();
            }
            return View(addPestiside);
        }

        // GET: UserPestiside/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserPestiside/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Used,Price,Description")] AddPestiside addPestiside)
        {
            if (ModelState.IsValid)
            {
                db.AddPestisides.Add(addPestiside);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addPestiside);
        }

        // GET: UserPestiside/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddPestiside addPestiside = db.AddPestisides.Find(id);
            if (addPestiside == null)
            {
                return HttpNotFound();
            }
            return View(addPestiside);
        }

        // POST: UserPestiside/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Used,Price,Description")] AddPestiside addPestiside)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addPestiside).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addPestiside);
        }

        // GET: UserPestiside/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddPestiside addPestiside = db.AddPestisides.Find(id);
            if (addPestiside == null)
            {
                return HttpNotFound();
            }
            return View(addPestiside);
        }

        // POST: UserPestiside/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddPestiside addPestiside = db.AddPestisides.Find(id);
            db.AddPestisides.Remove(addPestiside);
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
