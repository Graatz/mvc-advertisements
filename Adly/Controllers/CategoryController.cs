using Adly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adly.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Table()
        {
            return View(db.Categories.ToList());
        }

       
        public ActionResult Edit(int id)
        {
            var category = db.Categories.SingleOrDefault(a => a.Id == id);

            if (category == null)
                return HttpNotFound();
            else
            {
                return View("Form", category);
            }
        }

        public ActionResult New()
        {
            var category = new Category();

            return View("Form", category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", category);
            }

            if (category.Id == 0)
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
            else
            {
                var categoryInDb = db.Categories.Single(a => a.Id == category.Id);
                categoryInDb.Name = category.Name;

                db.SaveChanges();
            }

            return RedirectToAction("Table", "Category");
        }

        public ActionResult Remove(int id)
        {
            var categoryToRemove = db.Categories.SingleOrDefault(c => c.Id == id);

            if (categoryToRemove == null)
                return HttpNotFound();
            else
            {
                db.Categories.Remove(categoryToRemove);
                db.SaveChanges();

                return View("Table", db.Categories);
            }
        }
    }
}