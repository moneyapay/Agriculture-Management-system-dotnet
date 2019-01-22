using Agriculture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Agriculture.Controllers
{
    public class AdminSeedOrderViewController : Controller
    {
        private AgricultureEntities6 db = new AgricultureEntities6();
        // GET: AdminOrderView
        public ActionResult Index()
        {
            return View(db.BuySeeds.ToList());
        }

        // GET: Buyseed/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Buyseed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuySeed buyseed = db.BuySeeds.Find(id);
            db.BuySeeds.Remove(buyseed);
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