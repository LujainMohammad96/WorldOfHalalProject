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
    public class DrinkController : Controller
    {
        ApplicationDbContext context;

        public DrinkController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Drink
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DrinkList()
        {
            var model = context.Drinks.ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddDrink()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDrink(Drink drink, HttpPostedFileBase drinkImage)
        {
            string fileName = Path.GetFileNameWithoutExtension(drinkImage.FileName);
            string extension = Path.GetExtension(drinkImage.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;

            drink.CertificateDrinkUrl = "~/Images/DrinkImages/" + fileName;

            fileName = Path.Combine(Server.MapPath("~/Images/DrinkImages/"), fileName);

            drinkImage.SaveAs(fileName);

            context.Drinks.Add(drink);
            context.SaveChanges();


            return RedirectToAction("DrinkList");
        }

        public ActionResult EditDrink(int id)
        {
            var model = context.Drinks.Where(h => h.DrinkId == id).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditDrink(Drink drink, HttpPostedFileBase drinkImage)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(drinkImage.FileName);
                string extension = Path.GetExtension(drinkImage.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;

                drink.CertificateDrinkUrl = "~/Images/DrinkImages/" + fileName;

                fileName = Path.Combine(Server.MapPath("~/Images/DrinkImages/"), fileName);

                drinkImage.SaveAs(fileName);

                context.Entry(drink).State = EntityState.Modified;
                context.SaveChanges();
            }

            return RedirectToAction("DrinkList");
        }

        public ActionResult DrinkDetail()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DrinkDetail(int id)
        {
            Drink drink = new Drink();
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                drink = _context.Drinks.Where(f => f.DrinkId == id).FirstOrDefault();
            }

            return View(drink);
        }

        public ActionResult DeleteDrink(int? id)
        {
            if (id == null) 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Drink drink = context.Drinks.Find(id);

            if (drink == null)
                return HttpNotFound();

            return View(drink);
        }

        [HttpPost, ActionName("DeleteDrink")]
        public ActionResult DeletedConfirmed(int id)
        {
            Drink drink = context.Drinks.Find(id);
            context.Drinks.Remove(drink);
            context.SaveChanges();

            return RedirectToAction("DrinkList");
        }
    }
}