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
    public class BuyMachinesController : Controller
    {
        private AgricultureEntities10 db = new AgricultureEntities10();

        // GET: BuyMachines
        public ActionResult Index()
        {
            return View(db.BuyMachines.ToList());
        }

        // GET: BuyMachines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyMachine buyMachine = db.BuyMachines.Find(id);
            if (buyMachine == null)
            {
                return HttpNotFound();
            }
            return View(buyMachine);
        }

        // GET: BuyMachines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuyMachines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Machine_id,UserName,Phno,Address,Email,Quantity")] BuyMachine buyMachine)
        {
            if (ModelState.IsValid)
            {
                db.BuyMachines.Add(buyMachine);
                db.SaveChanges();
                TempData["orderresult"] = "Your order has been successfully placed";
            }

            return View(buyMachine);
        }

        // GET: BuyMachines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyMachine buyMachine = db.BuyMachines.Find(id);
            if (buyMachine == null)
            {
                return HttpNotFound();
            }
            return View(buyMachine);
        }

        // POST: BuyMachines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Machine_id,UserName,Phno,Address,Email,Quantity")] BuyMachine buyMachine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyMachine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buyMachine);
        }

        // GET: BuyMachines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyMachine buyMachine = db.BuyMachines.Find(id);
            if (buyMachine == null)
            {
                return HttpNotFound();
            }
            return View(buyMachine);
        }

        // POST: BuyMachines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuyMachine buyMachine = db.BuyMachines.Find(id);
            db.BuyMachines.Remove(buyMachine);
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
