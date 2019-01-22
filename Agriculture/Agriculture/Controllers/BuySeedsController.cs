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
    public class BuySeedsController : Controller
    {
        private AgricultureEntities6 db = new AgricultureEntities6();

        // GET: BuySeeds
        public ActionResult Index()
        {
            return View(db.BuySeeds.ToList());
        }

        // GET: BuySeeds/Details/5
        public ActionResult Details(int? email)
        {
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuySeed buySeed = db.BuySeeds.Find(email);
            if (buySeed == null)
            {
                return HttpNotFound();
            }
            return View(buySeed);
        }

        // GET: BuySeeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuySeeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Seed_id,UserName,Phno,Address,Email,Quantity")] BuySeed buySeed)
        {
            if (ModelState.IsValid)
            {
                db.BuySeeds.Add(buySeed);
                db.SaveChanges();
                TempData["orderresult"] = "Your order has been successfully placed";
                
            }
           
            return View(buySeed);
        }

        // GET: BuySeeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuySeed buySeed = db.BuySeeds.Find(id);
            if (buySeed == null)
            {
                return HttpNotFound();
            }
            return View(buySeed);
        }

        // POST: BuySeeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Seed_id,UserName,Phno,Address,Email,Quantity")] BuySeed buySeed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buySeed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buySeed);
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
