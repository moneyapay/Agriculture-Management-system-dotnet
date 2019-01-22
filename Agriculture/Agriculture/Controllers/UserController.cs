using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agriculture.Models;
namespace Agriculture.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        // GET: User
        public ActionResult Register(int id=0)
        {
            User userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Register(User userModel)
        {
            using (DbModels dbmodel = new DbModels())
            {
                
                if (dbmodel.Users.Any(x => x.Username == userModel.Username))
                {
                    ViewBag.DuplicateMessage = "Username already exist";
                    return View("register",userModel);
                }
                dbmodel.Users.Add(userModel);
                dbmodel.SaveChanges();
            }
            ViewBag.SuccessMessage = "Registration Successfull";
            return View("register",new User());
        }
    }
}