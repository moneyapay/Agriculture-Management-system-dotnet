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
    public class AdminMachineController : Controller
    {
        private AgricultureEntities9 db = new AgricultureEntities9();

        // GET: AdminMachine
        public ActionResult Index()
        {
            return View(db.AddMachines.ToList());
        }

        // GET: AdminMachine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddMachine addMachine = db.AddMachines.Find(id);
            if (addMachine == null)
            {
                return HttpNotFound();
            }
            return View(addMachine);
        }

        // GET: AdminMachine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminMachine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MachineId,Name,Type,Price,Description")] AddMachine addMachine)
        {
            if (ModelState.IsValid)
            {
                db.AddMachines.Add(addMachine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addMachine);
        }

        // GET: AdminMachine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddMachine addMachine = db.AddMachines.Find(id);
            if (addMachine == null)
            {
                return HttpNotFound();
            }
            return View(addMachine);
        }

        // POST: AdminMachine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MachineId,Name,Type,Price,Description")] AddMachine addMachine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addMachine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addMachine);
        }

        // GET: AdminMachine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddMachine addMachine = db.AddMachines.Find(id);
            if (addMachine == null)
            {
                return HttpNotFound();
            }
            return View(addMachine);
        }

        // POST: AdminMachine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddMachine addMachine = db.AddMachines.Find(id);
            db.AddMachines.Remove(addMachine);
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
