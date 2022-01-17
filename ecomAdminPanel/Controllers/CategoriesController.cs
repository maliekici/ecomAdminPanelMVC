using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecomAdminPanel.Models.Entity;

namespace ecomAdminPanel.Controllers
{
    
    public class CategoriesController : Controller
    {
        ecomAdminPanelDBEntities db = new ecomAdminPanelDBEntities();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Add2(Categories c)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            
                db.Categories.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            
            
        }

        public ActionResult UpdateInfo(Categories c)
        {
            var model = db.Categories.Find(c.ID);
            if (model==null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Update(Categories c)
        {
            db.Entry(c).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteInfo(Categories c)
        {
            var model = db.Categories.Find(c.ID);//bilgileri ID ye göre view'a aktarıyoruz.
            if (model==null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Delete(Categories c)
        {
            db.Entry(c).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
} 