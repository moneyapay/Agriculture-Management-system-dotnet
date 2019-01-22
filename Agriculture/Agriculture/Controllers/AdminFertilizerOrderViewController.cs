using Agriculture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Agriculture.Controllers
{
    public class AdminFertilizerOrderViewController : Controller
    {
        // GET: AdminFertilizerOrderView

        private AgricultureEntities7 db = new AgricultureEntities7();
        // GET: AdminOrderView
        public ActionResult Index()
        {
            return View(db.BuyFertilizers.ToList());
        }

        // GET: Buyseed/Delete/5
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

        // POST: Buyseed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuyFertilizer buyfertilizer = db.BuyFertilizers.Find(id);
            db.BuyFertilizers.Remove(buyfertilizer);
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