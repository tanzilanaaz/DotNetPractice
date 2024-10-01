using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products



        public ActionResult ProductList()
        {
            List<ElectronicProducts> plist = new List<ElectronicProducts>();
            plist.Add(new ElectronicProducts { Productid = 1, ProductName = "charger", Price = 1000 });
            plist.Add(new ElectronicProducts { Productid = 2, ProductName = "power bank", Price = 4000 });
            plist.Add(new ElectronicProducts { Productid = 3, ProductName = "keyboard", Price = 2000 });
            plist.Add(new ElectronicProducts { Productid = 4, ProductName = "mouse", Price = 1000 });


            //ViewModel
            return View(plist);


        }


        public ActionResult ShowNumbers()
        {

            List<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ViewBag.data = intList;
            return View();

        }

        public ActionResult AvailableProducts()
        {
            List<ElectronicProducts> available = new List<ElectronicProducts>();
            available.Add(new ElectronicProducts { Productid = 10, ProductName = "Laptops", Price = 90000 });
            available.Add(new ElectronicProducts { Productid = 11, ProductName = "Printers", Price = 20000 });
            available.Add(new ElectronicProducts { Productid = 12, ProductName = "Scanner", Price = 30000 });

            ViewBag.availableProdList = available;
            return View();



        }



        public ActionResult PendingProductsToDeliver()
        {
            List<ElectronicProducts> pendingProducts = new List<ElectronicProducts>();
            pendingProducts.Add(new ElectronicProducts { Productid = 9, ProductName = "Tablets", Price = 90000 });
            pendingProducts.Add(new ElectronicProducts { Productid = 17, ProductName = "Mobiles", Price = 20000 });
            pendingProducts.Add(new ElectronicProducts { Productid = 129, ProductName = "TVs", Price = 30000 });

            ViewData["PendingProductList"] = pendingProducts;
            return View();




        }

    }
}