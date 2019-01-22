using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agriculture.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Irrigation()
        {

            return View();
        }
        public ActionResult Facilities()
        {

            return View();
        }
        public ActionResult Cattle()
        {

            return View();
        }
        public ActionResult poultry()
        {

            return View();

        }
        public ActionResult Sericulture()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Agriculture()
        {
            return View();

        }
        public ActionResult DripIrrigation()
        {
            return View();
        }
        public ActionResult SprinklerIrrigation()
        {
            return View();
        }
        public ActionResult Cow()
        {
            return View();
        }
        public ActionResult Sheep()
        {
            return View();
        }
        public ActionResult Goat()
        {
            return View();
        }
    }
}