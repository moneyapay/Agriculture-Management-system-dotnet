using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agriculture.Models;
namespace Agriculture.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Log_in(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Log_in(User userModel)
        {

            using (DbModels dbModel = new DbModels())
            {
                var log = dbModel.Users.Where(a => a.Username.Equals(userModel.Username) && a.Password.Equals(userModel.Password)).FirstOrDefault();
                if (log != null)
                {
                    if (log.isAdmin == true)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                else
                {
                    Response.Write("<script>alert('Invalid Password')</script>");
                }
            }



            return View();
        }

    }
}