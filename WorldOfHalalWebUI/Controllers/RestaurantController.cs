using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldOfHalalWebUI.Models;

namespace WorldOfHalalWebUI.Controllers
{
    [AllowAnonymous]
    public class RestaurantController : Controller
    {
        ApplicationDbContext context;

        public RestaurantController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RestaurantList()
        {
            var model = context.Restaurants.ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddRestaurant()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRestaurant(Restaurant restaurant, HttpPostedFileBase restaurantImage)
        {
            string fileName = Path.GetFileNameWithoutExtension(restaurantImage.FileName);
            string extension = Path.GetExtension(restaurantImage.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;

            restaurant.ImagePath = "~/Images/RestaurantImages/" + fileName;

            fileName = Path.Combine(Server.MapPath("~/Images/RestaurantImages/"), fileName);

            restaurantImage.SaveAs(fileName);

            context.Restaurants.Add(restaurant);
            context.SaveChanges();

            return RedirectToAction("RestaurantList");
        }

        public ActionResult EditRestaurant(int id)
        {
            var model = context.Restaurants.Where(r => r.RestaurantId == id).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditRestaurant(Restaurant restaurant, HttpPostedFileBase restaurantImage)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(restaurantImage.FileName);
                string extension = Path.GetExtension(restaurantImage.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;

                restaurant.ImagePath = "~/Images/RestaurantImages/" + fileName;

                fileName = Path.Combine(Server.MapPath("~/Images/RestaurantImages/"), fileName);

                restaurantImage.SaveAs(fileName);

                context.Entry(restaurant).State = EntityState.Modified;
                context.SaveChanges();
            }

            return RedirectToAction("RestaurantList");
        }

        public ActionResult RestaurantDetail()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RestaurantDetail(int id)
        {
            Restaurant restaurant = new Restaurant();
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                restaurant = _context.Restaurants.Where(r => r.RestaurantId == id).FirstOrDefault();
            }

            return View(restaurant);
        }

        public ActionResult DeleteRestaurant(int? id)
        {
            if (id == null) 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Restaurant restaurant = context.Restaurants.Find(id);

            if (restaurant == null)
                return HttpNotFound();

            return View(restaurant);
        }

        [HttpPost, ActionName("DeleteRestaurant")]
        public ActionResult DeletedConfirmed(int id)
        {
            Restaurant restaurant = context.Restaurants.Find(id);
            context.Restaurants.Remove(restaurant);
            context.SaveChanges();

            return RedirectToAction("RestaurantList");
        }
    }
}