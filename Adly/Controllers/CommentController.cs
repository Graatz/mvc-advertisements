using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adly.Models;
using Adly.ViewModels;

namespace Adly.Controllers
{
    public class CommentController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Table()
        {
            return View(db.Comments);
        }

        public ActionResult Remove(int id)
        {
            Comment commentToRemove = db.Comments.Single(c => c.Id == id);

            db.Comments.Remove(commentToRemove);
            db.SaveChanges();

            return RedirectToAction("Table", "Comment", db.Comments);
        }

        public ActionResult Edit(int id)
        {
            var comment = db.Comments.SingleOrDefault(a => a.Id == id);

            if (comment == null)
                return HttpNotFound();
            else
            {
                return View("Form", comment);
            }
        }

        public ActionResult New()
        {
            var comment = new Category();

            return View("Form", comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(int advertisementId, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Display", "Advertisement", new { id = advertisementId });
            }
            else
            {
                comment.AdvertisementId = advertisementId;
                comment.Date = DateTime.Now;

                db.Comments.Add(comment);
                db.SaveChanges();

                return RedirectToAction("Display", "Advertisement", new { id = advertisementId });
            }
        }
    }
}