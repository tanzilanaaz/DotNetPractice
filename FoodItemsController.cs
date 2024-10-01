using KitchenDALLibrary;
using Phase3KitchenStory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Phase3KitchenStory.Controllers
{
    public class FoodItemsController : Controller
    {
        FoodItemsDAL foodItemsDal = new FoodItemsDAL();
        List<FoodItemsModel> foodItemModelList = new List<FoodItemsModel>();
        List<FoodItems> foodItemsList;

        // GET: FoodItem
        public ActionResult Index()
        {
            foodItemsList = foodItemsDal.GetAllFoodItem();
            foreach (var item in foodItemsList)
            {
                FoodItemsModel foodItemsModel = new FoodItemsModel();

                foodItemsModel.Id = item.Id;
                foodItemsModel.Name = item.Name;
                foodItemsModel.Price = item.Price;

                foodItemModelList.Add(foodItemsModel);
            }
            return View(foodItemModelList);
        }

        // GET: FoodItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Content("Id not found");
            }

            try
            {
                FoodItems foodItems = foodItemsDal.GetFoodItemById(id.Value);
                if (foodItems != null)
                {
                    FoodItemsModel foodItemModel = new FoodItemsModel()
                    {
                        Id = foodItems.Id,
                        Name = foodItems.Name,
                        Price = foodItems.Price
                    };
                    return View(foodItemModel);
                }
                else
                {
                    return Content("Invalid FoodItem id");
                }
            }
            catch (Exception)
            {
                return Content("Error finding the FoodItem details");
            }
        }

        // GET: FoodItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodItem/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                FoodItemsModel foodItemsModel = new FoodItemsModel()
                {
                    Name = collection["Name"].ToString(),
                    Price = Convert.ToSingle(collection["Price"])
                };
                FoodItems foodItems = new FoodItems()
                {
                    Name = foodItemsModel.Name,
                    Price = foodItemsModel.Price
                };

                bool result = foodItemsDal.AddFoodItem(foodItems);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                return Content("Invalid Food Item entry");
            }
            return View();
        }

        // GET: FoodItem/Edit/5
        public ActionResult Edit(int id)
        {
            FoodItems foodItems = foodItemsDal.GetFoodItemById(id);
            FoodItemsModel foodItemsModel = new FoodItemsModel()
            {
                Id = foodItems.Id,
                Name = foodItems.Name,
                Price = foodItems.Price
            };
            return View(foodItemsModel);
        }

        // POST: FoodItem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                FoodItemsModel foodItemsModel = new FoodItemsModel()
                {
                    Id = int.Parse(collection["Id"]),
                    Name = collection["Name"].ToString(),
                    Price = Convert.ToSingle(collection["Price"])
                };
                FoodItems foodItems = new FoodItems()
                {
                    Id = foodItemsModel.Id,
                    Name = foodItemsModel.Name,
                    Price = foodItemsModel.Price
                };
                bool result = foodItemsDal.UpdateFoodItem(foodItems);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                return Content("Invalid entry of the item to be Updated");
            }
            return View();
        }

        // GET: FoodItem/Delete/5
        public ActionResult Delete(int id)
        {
            FoodItems foodItems = foodItemsDal.GetFoodItemById(id);
            FoodItemsModel foodItemsModel = new FoodItemsModel()
            {
                Id = foodItems.Id,
                Name = foodItems.Name,
                Price = foodItems.Price
            };
            return View(foodItemsModel);
        }

        // POST: FoodItem/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                bool result = foodItemsDal.DeleteFoodItem(id);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                return Content("No item with this id");
            }
            return View();
        }

        public ActionResult Menu()
        {
            var foodItems = foodItemsDal.GetAllFoodItem();

            var foodItemsModels = new List<FoodItemsModel>();
            foreach (var foodItem in foodItems)
            {
                var foodItemsModel = new FoodItemsModel
                {
                    Id = foodItem.Id,
                    Name = foodItem.Name,
                    Price = foodItem.Price
                };
                foodItemsModels.Add(foodItemsModel);
            }
            return View(foodItemsModels);
        }

        [HttpPost]
        public ActionResult Menu(string searchString)
        {
            var foodItems = foodItemsDal.GetAllFoodItem();

            if (!string.IsNullOrEmpty(searchString))
            {
                string searchLower = searchString.ToLower();
                foodItems = foodItems.Where(f => f.Name.ToLower().Contains(searchLower)).ToList();
            }

            var foodItemsModels = foodItems.Select(foodItem => new FoodItemsModel
            {
                Id = foodItem.Id,
                Name = foodItem.Name,
                Price = foodItem.Price
            }).ToList();

            if (!foodItemsModels.Any())
            {
                ViewBag.NoResultsMessage = "No products found";
            }
            return View(foodItemsModels);
        }

        public ActionResult ItemsChosed(int id)
        {
            foodItemsList = foodItemsDal.GetAllFoodItem();
            FoodItems foodItems = foodItemsList.Find(f => f.Id == id);
            TempData["Price"] = foodItems.Price;
            TempData["Name"] = foodItems.Name;
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public ActionResult ItemsChosed(string Address, int Quantity)
        {
            string price = TempData["Price"].ToString();
            float totalPrice = float.Parse(price) * Quantity;
            TempData["TotalPrice"] = totalPrice;
            TempData["Address"] = Address;
            TempData.Keep();
            return RedirectToAction("Payment");
        }

        public ActionResult Payment()
        {
            return View();

        }

        public ActionResult OrderConfirmation()
        {
            return View();

        }
    }

}
