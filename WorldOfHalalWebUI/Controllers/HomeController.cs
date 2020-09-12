using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldOfHalalWebUI.Models;

namespace WorldOfHalalWebUI.Controllers
{

    [AllowAnonymous]
    public class HomeController : Controller
    {
        ApplicationDbContext context;

        public HomeController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us";

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