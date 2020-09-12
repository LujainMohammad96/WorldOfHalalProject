using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldOfHalalWebUI.Models;

namespace WorldOfHalalWebUI.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RestuarantAdministrator()
        {
            return RedirectToAction("RestaurantList", "Restaurant");
        }

        public ActionResult HotelAdministrator()
        {
            return RedirectToAction("HotelList", "Hotel");
        }

        public ActionResult DrinkAdministrator()
        {
            return RedirectToAction("DrinkList", "Drink");
        }

        public ActionResult FoodAdministrator()
        {
            return RedirectToAction("FoodList", "Food");
        }
    }
}