using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adly.Models;
using Adly.ViewModels;

namespace Adly.Controllers
{
    public class AdvertisementController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Table()
        {
            return View(db.Advertisements.ToList());
        }

        public ActionResult Index()
        {
            var advertisements = db.Advertisements;

            return View(advertisements);
        }

        public ActionResult Display(int id)
        {
            if (id == 0)
                return HttpNotFound();

            var advertisement = db.Advertisements.SingleOrDefault(a => a.Id == id);

            var queryComments = from queryComment in db.Comments
                                where queryComment.AdvertisementId == id
                                select queryComment;

            var comment = new Comment();

            var viewModel = new DisplayViewModel(advertisement, queryComments, comment);

            if (advertisement == null)
                return HttpNotFound();
            else
            {
                var advertisementInDb = db.Advertisements.Single(a => a.Id == id);
                advertisementInDb.Views = advertisementInDb.Views + 1;
                db.SaveChanges();
                return View(viewModel);
            }
        }

        public ActionResult New()
        {
            var viewModel = new AdvertisementViewModel(db.Categories, new Advertisement());

            return View("Form", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var advertisement = db.Advertisements.SingleOrDefault(a => a.Id == id);

            if (advertisement == null)
                return HttpNotFound();
            else
            {
                var viewModel = new AdvertisementViewModel(db.Categories, advertisement);
                return View("Form", viewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Advertisement advertisement)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AdvertisementViewModel(db.Categories, advertisement);
                return View("Form", viewModel);
            }

            if (advertisement.Id == 0)
            {
                advertisement.Date = DateTime.Now;
                advertisement.Views = 0;

                db.Advertisements.Add(advertisement);
                db.SaveChanges();
            }
            else
            {
                var advertisementInDb = db.Advertisements.Single(a => a.Id == advertisement.Id);
                advertisementInDb.Name = advertisement.Name;
                advertisementInDb.Description = advertisement.Description;
                advertisementInDb.Image = advertisement.Image;
                advertisementInDb.CategoryId = advertisement.CategoryId;
                advertisementInDb.Category = advertisement.Category;

                db.SaveChanges();
                
            }

            return RedirectToAction("Table", "Advertisement");
        }

        public ActionResult Remove(int id)
        {
            var advertisementToRemove = db.Advertisements.SingleOrDefault(a => a.Id == id);

            if (advertisementToRemove == null)
                return HttpNotFound();
            else
            {
                db.Advertisements.Remove(advertisementToRemove);
                db.SaveChanges();

                return View("Table", db.Advertisements.ToList());
            }
        }
    }
}