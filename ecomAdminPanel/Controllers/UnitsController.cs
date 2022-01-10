using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecomAdminPanel.Models.Entity;

namespace ecomAdminPanel.Controllers
{
    public class UnitsController : Controller
    {
        ecomAdminPanelDBEntities db = new ecomAdminPanelDBEntities();

        public ActionResult Index()
        {
            return View(db.Units.ToList());
        }

        public ActionResult Add()
        {
            return View("Save");
        }
        [HttpPost]
        public ActionResult Save(Units u)
        {
            //Ekleme işlemi yapıcağımız zaman ID değeri 0 olarak yakalanır bunu kullanarak ekleme ve güncellemeyi if ile sorgulayıp yapabiliriz.
            if (u.ID==0)
            {
                db.Units.Add(u);
            }
            else
            {
                db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            }
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Updateİnfo(Units u)
        {
            var model = db.Units.Find(u.ID);
            if (model==null)//yani bu ID den farklı bir değer alırsa
            {
                return HttpNotFound();  
            }
            return View("Save", model);//en sonda view içerisine model'i ekledik
        }

        public ActionResult Deleteİnfo(Units u)
        {
            var model = db.Units.Find(u.ID);//bilgileri ID ye göre view'a aktarıyoruz.
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Delete(Units u)
        {
            db.Entry(u).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}