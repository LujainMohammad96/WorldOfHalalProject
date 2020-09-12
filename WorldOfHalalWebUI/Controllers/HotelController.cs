using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldOfHalalWebUI.Models;

namespace WorldOfHalalWebUI.Controllers
{
    [AllowAnonymous]
    public class HotelController : Controller
    {
        ApplicationDbContext context;

        public HotelController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Hotel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HotelList()
        {
            var model = context.Hotels.ToList();

            return View(model);
        }

        public ActionResult AddHotel()
        {
            var model = new Hotel();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddHotel(Hotel hotel)
        {
            context.Hotels.Add(hotel);
            context.SaveChanges();

            return RedirectToAction("HotelList");
        }

        public ActionResult EditHotel(int id)
        {
            var model = context.Hotels.Where(h => h.HotelId == id).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditHotel(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                context.Entry(hotel).State = EntityState.Modified;
                context.SaveChanges();
            }

            return RedirectToAction("HotelList");
        }

        public ActionResult DeleteHotel(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Hotel hotel = context.Hotels.Find(id);

            if (hotel == null)
                return HttpNotFound();

            return View(hotel);
        }

        [HttpPost, ActionName("DeleteHotel")]
        public ActionResult DeletedConfirmed(int id)
        {
            Hotel hotel = context.Hotels.Find(id);
            context.Hotels.Remove(hotel);
            context.SaveChanges();

            return RedirectToAction("HotelList");
        }
    }
}