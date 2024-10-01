using Phase4Project.Models;
using PizzaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Phase4Project.Controllers
{
    public class PizzaController : Controller
    {
        public PizzaManager pizzaManager;
        public PizzaController()
        {
            pizzaManager = new PizzaManager();
        }
        public ActionResult Index()
        {
            List<PizzaModel> pizzaModelList = new List<PizzaModel>();
            List<PizzaProperties> pizzaList = pizzaManager.ListOfPizza();
            foreach (PizzaProperties pizza in pizzaList)
            {
                PizzaModel pModel = new PizzaModel()
                {
                    Id = pizza.Id,
                    Type = pizza.Type,
                    Price = pizza.Price
                };
                pizzaModelList.Add(pModel);
            }
            return View(pizzaModelList);
        }

        public ActionResult SelectedItems(int id)
        {
            List<PizzaProperties> pizzaList = pizzaManager.ListOfPizza();
            PizzaProperties pizzaItem = pizzaList.Find(p => p.Id == id);
            PizzaModel model = new PizzaModel()
            {
                Id = pizzaItem.Id,
                Type = pizzaItem.Type,
                Price = pizzaItem.Price
            };
            TempData["Price"] = pizzaItem.Price;
            TempData["PizzaType"] = pizzaItem.Type;
            TempData.Keep();

            return View(model);
        }

        [HttpPost]
        public ActionResult SelectedItems(string deliveryAddress, int itemQuantity)
        {
            string price = TempData["Price"].ToString();
            float totalPrice = float.Parse(price) * itemQuantity;
            TempData["TotalPrice"] = totalPrice;
            TempData["Address"] = deliveryAddress;
            TempData.Keep();

            return RedirectToAction("PaymentMode");
        }

        public ActionResult PaymentMode()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int length = 10;
            string randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            TempData["orderid"] = randomString;
            ViewBag.TotalPrice = Convert.ToSingle(TempData["TotalPrice"]);
            ViewBag.Address = TempData["Address"].ToString();
            return View();
        }

        public ActionResult OrderSuccess()
        {
            TempData["RandomOrderId"] = TempData["orderid"];
            return View("OrderSuccess");
        }
    }
}