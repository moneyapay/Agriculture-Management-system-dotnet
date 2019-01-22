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
    public class BuyFertilizersController : Controller
    {
        private AgricultureEntities7 db = new AgricultureEntities7();

        // GET: BuyFertilizers
        public ActionResult Index()
        {
            return View(db.BuyFertilizers.ToList());
        }

        // GET: BuyFertilizers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyFertilizer buyFertilizer = db.BuyFertilizers.Find(id);
            if (buyFertilizer == null)
            {
                return HttpNotFound();
            }
            return View(buyFertilizer);
        }

        // GET: BuyFertilizers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuyFertilizers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fertilizer_id,id,UserName,Phno,Address,Email,Quantity")] BuyFertilizer buyFertilizer)
        {
            if (ModelState.IsValid)
            {
                db.BuyFertilizers.Add(buyFertilizer);
                db.SaveChanges();
                TempData["orderresult"] = "Your order has been successfully placed";
            }

            return View(buyFertilizer);
        }

        // GET: BuyFertilizers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyFertilizer buyFertilizer = db.BuyFertilizers.Find(id);
            if (buyFertilizer == null)
            {
                return HttpNotFound();
            }
            return View(buyFertilizer);
        }

        // POST: BuyFertilizers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fertilizer_id,id,UserName,Phno,Address,Email,Quantity")] BuyFertilizer buyFertilizer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyFertilizer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buyFertilizer);
        }

        // GET: BuyFertilizers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyFertilizer buyFertilizer = db.BuyFertilizers.Find(id);
            if (buyFertilizer == null)
            {
                return HttpNotFound();
            }
            return View(buyFertilizer);
        }

        // POST: BuyFertilizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuyFertilizer buyFertilizer = db.BuyFertilizers.Find(id);
            db.BuyFertilizers.Remove(buyFertilizer);
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
