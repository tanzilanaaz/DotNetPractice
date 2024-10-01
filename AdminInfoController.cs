using KitchenDALLibrary;
using Phase3KitchenStory.Models;
using System;
using System.Web.Mvc;

namespace Phase3KitchenStory.Controllers
{
    public class AdminInfoController : Controller
    {
        AdminInfoDAL adminInfoDal = new AdminInfoDAL();
        // GET: AdminInfo
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminInfoModel adminInfoModel)
        {
            AdminInfo adminInfo = new AdminInfo()
            {
                Email = adminInfoModel.Email,
                Password = adminInfoModel.Password,
            };
            try
            {
                bool result = adminInfoDal.AdminLogin(adminInfo);
                if (result)
                {
                    return RedirectToAction("Index", "FoodItems");
                }
                else
                {
                    return Content("Invalid Login Details");
                }
            }
            catch (Exception)
            {
                return Content("Invalid Login");
            }
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(AdminInfoModel adminInfoModel)
        {
            bool validEmail = adminInfoDal.ValidateEmail(adminInfoModel.Email);
            if (validEmail)
            {
                AdminInfo adminInfo = new AdminInfo()
                {
                    Email = adminInfoModel.Email,
                    Password = adminInfoModel.Password,
                };
                try
                {
                    bool result = adminInfoDal.UpdatePassword(adminInfo);
                    if (result)
                    {
                        return RedirectToAction("SuccessPage");
                    }
                }
                catch (Exception)
                {
                    return Content("Invalid Login");
                }
            }
            return View();
        }

        public ActionResult SuccessPage()
        {
            return View();
        }
    }


}
