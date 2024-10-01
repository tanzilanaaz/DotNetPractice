using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class MathsController : Controller
    {
        // GET: Calcu;ator
        public ActionResult AddNumbers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNumbers(int firstno, int secondno)
        {
            int ans = firstno + secondno;

            return Content(ans.ToString());
        }


        public ActionResult SubtractNumbers()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SubtractNumbers(int fno, int sno)
        {
            if (fno != 0)
            {
                int ans = fno - sno;

                return Content(ans.ToString());
            }
            else
            {
                return Content("Subtraction not posssible");
            }
        }


        public ActionResult OpenGoogle()
        {

            return RedirectPermanent("https://www.google.com");

        }
    }
}