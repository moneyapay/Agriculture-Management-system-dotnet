using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agriculture.Models;

namespace Agriculture.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
       
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        
        public ActionResult AddSeed()
        {
            AddSeed seedModel = new AddSeed();
            return View(seedModel);
        }

        [HttpPost]
        public ActionResult AddSeed(AddSeed seedModel)
        {
            
            AgricultureEntities1 dbseed = new AgricultureEntities1();
            dbseed.AddSeeds.Add(seedModel);
            dbseed.SaveChanges();
           TempData["result"]="Data added Successfully";
            return RedirectToAction("AddSeed", "Admin");
        }
        [HttpGet]

        public ActionResult AddMachine()
        {
            AddMachine machineModel = new AddMachine();
            return View(machineModel);
        }

        [HttpPost]
        public ActionResult AddMachine(AddMachine machineModel)
        {
            
            AgricultureEntities9 dbmachine = new AgricultureEntities9();
            dbmachine.AddMachines.Add(machineModel);
            dbmachine.SaveChanges();
            TempData["result"] = "Data added Successfully";
            return RedirectToAction("AddMachine", "Admin");
        }

        [HttpGet]

        public ActionResult AddFertilizer()
        {
           AddFertilizer fertilizerModel = new AddFertilizer();
            return View(fertilizerModel);
        }

        [HttpPost]
        public ActionResult AddFertilizer(AddFertilizer fertilizerModel)
        {

            AgricultureEntities3 dbfertilizer = new AgricultureEntities3();
            dbfertilizer.AddFertilizers.Add(fertilizerModel);
            dbfertilizer.SaveChanges();
            TempData["result"] = "Data added Successfully";
            return RedirectToAction("AddFertilizer", "Admin");
        }
        [HttpGet]

        public ActionResult AddPestiside()
        {
            AddPestiside pestisideModel = new AddPestiside();
            return View(pestisideModel);
        }
        [HttpPost]
        public ActionResult AddPestiside(AddPestiside pestisideModel)
        {
            AgricultureEntities4 dbpestiside = new AgricultureEntities4();
            dbpestiside.AddPestisides.Add(pestisideModel);
            dbpestiside.SaveChanges();
            TempData["result"] = "Data Added Successfully";
            return RedirectToAction("AddPestiside", "Admin");
        }

    }
}
 