using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Agriculture.Models;
namespace Agriculture.Controllers
{
    public class AdminPestisideOrderViewController : Controller
    {
        private AgricultureEntities11 db = new AgricultureEntities11();
        // GET: AdminPestisideOrderView
        public ActionResult Index()
        {
            return View(db.BuyPestisides.ToList());
        }

        // GET: Buyseed/Delete/5
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

        // POST: Buyseed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuyPestiside buypestiside = db.BuyPestisides.Find(id);
            db.BuyPestisides.Remove(buypestiside);
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