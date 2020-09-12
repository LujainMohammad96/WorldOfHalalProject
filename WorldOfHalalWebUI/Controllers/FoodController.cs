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
    public class FoodController : Controller
    {
        ApplicationDbContext context;

        public FoodController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Food
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FoodList()
        {
            var model = context.Foods.ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult AddFood()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFood(Food food, HttpPostedFileBase foodImage)
        {
            string fileName = Path.GetFileNameWithoutExtension(foodImage.FileName);
            string extension = Path.GetExtension(foodImage.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;

            food.CertificateFoodUrl = "~/Images/FoodImages/" + fileName;

            fileName = Path.Combine(Server.MapPath("~/Images/FoodImages/"), fileName);

            foodImage.SaveAs(fileName);

            context.Foods.Add(food);
            context.SaveChanges();


            return RedirectToAction("FoodList");
        }

        public ActionResult EditFood(int id)
        {
            var model = context.Foods.Where(h => h.FoodId == id).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditFood(Food food, HttpPostedFileBase foodImage)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(foodImage.FileName);
                string extension = Path.GetExtension(foodImage.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;

                food.CertificateFoodUrl = "~/Images/FoodImages/" + fileName;

                fileName = Path.Combine(Server.MapPath("~/Images/FoodImages/"), fileName);

                foodImage.SaveAs(fileName);

                context.Entry(food).State = EntityState.Modified;
                context.SaveChanges();
            }

            return RedirectToAction("FoodList");
        }

        public ActionResult FoodDetail()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FoodDetail(int id)
        {
            Food food = new Food();
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                food = _context.Foods.Where(f => f.FoodId == id).FirstOrDefault();
            }

            return View(food);
        }

        public ActionResult DeleteFood(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Food food = context.Foods.Find(id);

            if (food == null)
                return HttpNotFound();

            return View(food);
        }

        [HttpPost, ActionName("DeleteFood")]
        public ActionResult DeletedConfirmed(int id)
        {
            Food food = context.Foods.Find(id);
            context.Foods.Remove(food);
            context.SaveChanges();

            return RedirectToAction("FoodList");
        }
    }
}