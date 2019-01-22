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
    public class BuyPestisidesController : Controller
    {
        private AgricultureEntities11 db = new AgricultureEntities11();

        // GET: BuyPestisides
        public ActionResult Index()
        {
            return View(db.BuyPestisides.ToList());
        }

        // GET: BuyPestisides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyPestiside buyPestiside = db.BuyPestisides.Find(id);
            if (buyPestiside == null)
            {
                return HttpNotFound();
            }
            return View(buyPestiside);
        }

        // GET: BuyPestisides/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuyPestisides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Pestiside_id,UserName,Phno,Address,Email,Quantity")] BuyPestiside buyPestiside)
        {
            if (ModelState.IsValid)
            {
                db.BuyPestisides.Add(buyPestiside);
                db.SaveChanges();
                TempData["orderresult"] = "Your order has been successfully placed";
            }

            return View(buyPestiside);
        }

        // GET: BuyPestisides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyPestiside buyPestiside = db.BuyPestisides.Find(id);
            if (buyPestiside == null)
            {
                return HttpNotFound();
            }
            return View(buyPestiside);
        }

        // POST: BuyPestisides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Pestiside_id,UserName,Phno,Address,Email,Quantity")] BuyPestiside buyPestiside)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyPestiside).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buyPestiside);
        }

        // GET: BuyPestisides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyPestiside buyPestiside = db.BuyPestisides.Find(id);
            if (buyPestiside == null)
            {
                return HttpNotFound();
            }
            return View(buyPestiside);
        }

        // POST: BuyPestisides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuyPestiside buyPestiside = db.BuyPestisides.Find(id);
            db.BuyPestisides.Remove(buyPestiside);
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
