using Agriculture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Agriculture.Controllers
{
    public class AdminMachineOrderViewController : Controller
    {
        // GET: AdminMachineOrderView

        private AgricultureEntities10 db = new AgricultureEntities10();
        // GET: AdminOrderView
        public ActionResult Index()
        {
            return View(db.BuyMachines.ToList());
        }

        // GET: Buyseed/Delete/5
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

        // POST: Buyseed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuyMachine buyseed = db.BuyMachines.Find(id);
            db.BuyMachines.Remove(buyseed);
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