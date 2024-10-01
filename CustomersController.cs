using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers

        //the default verb with every action is GET

        public ActionResult Login()
        {
            //return Content("now will show the login screen here");
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userid, string password)
        {
            if (userid.Length == 0 && password.Length == 0)
            {

                return Content("Error");
            }
            else if (userid == "Ankita" && password == "Ankita@123")
            {
                return Content("Userid and password is valid");
            }
            else
            {
                return Content("Check the credentials");
            }
        }

        public ActionResult Register()
        {
            return View();

        }


        [HttpPost]
        public ActionResult Register(string name, string city, string email)
        {
            if (name.Length > 0 && city.Length > 0 && email.Length > 0)
            {
                return RedirectToAction("Cart");
            }
            else
            {
                return View();
            }

        }


        public ActionResult Cart()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Cart(int id)
        {
            return RedirectToAction("ProductList", "Products");


        }

    }
}