using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecomAdminPanel.Models.Entity;

namespace ecomAdminPanel.Controllers
{
    public class BrandsController : Controller
    {
        ecomAdminPanelDBEntities db = new ecomAdminPanelDBEntities();

        public ActionResult Index()
        {
            var model = db.Brands.ToList();
            return View(model);
        }

        public ActionResult Add()
        {
            var model = new Brands();
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Category", model.CategoryID);
            return View();
        }

        [HttpPost]
        public ActionResult Add(Brands b)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Category", b.CategoryID);
                return View("Add");
            }
            db.Entry(b).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void SelectInfo()
        {
            var model = new Brands();
            List<SelectListItem> liste = new List<SelectListItem>(from x in db.Categories
                                                                  select new SelectListItem
                                                                  {
                                                                      Value=x.ID.ToString(),
                                                                      Text=x.Category
                                                                  }
                                                                  ).ToList();
            ViewBag.l = liste;
        }

        public ActionResult UpdateInfo(int id)
        {
            SelectInfo();
            var search = db.Brands.Find(id);
            return View(search);
        }

        public ActionResult Update(Brands b)
        {
            if (!ModelState.IsValid)
            {
                SelectInfo();
                return View("UpdateInfo");
            }
            db.Entry(b).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteInfo(Brands b)
        {
            var bring = db.Brands.Find(b.ID); 
            return View(bring);
              
        }

        public ActionResult Delete(Brands b)
        {
            db.Entry(b).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}