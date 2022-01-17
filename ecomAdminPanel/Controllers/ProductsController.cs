using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecomAdminPanel.Models.Entity;

namespace ecomAdminPanel.Controllers
{
    
    public class ProductsController : Controller
    {
        ecomAdminPanelDBEntities db = new ecomAdminPanelDBEntities();   
        public ActionResult Index()
        {
            var model = db.Products1.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new Products1();
            Again(model);
            return View(model);
        }


        private void Again(Products1 model)
        {
            List<Categories> categoryList = db.Categories.OrderBy(x => x.Category).ToList();
            model.CategoryList = (from x in categoryList
                                  select new SelectListItem
                                  {
                                      Text = x.Category,
                                      Value = x.ID.ToString()
                                  }
        ).ToList();
            List<Units> unitList = db.Units.OrderBy(x => x.Unit).ToList();
            model.UnitList = (from x in unitList
                              select new SelectListItem
                              {
                                  Text = x.Unit,
                                  Value = x.ID.ToString()
                              }
        ).ToList();
        }

        [HttpPost]
        public ActionResult Add(Products1 p)
        {
            if (!ModelState.IsValid)
            {
                var model = new Products1();
                Again(model);
                return View(model);
            }
            db.Entry(p).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddAmount(int id)
        {
            var model = db.Products1.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult AddAmount(Products1 p)
        {
            var model = db.Products1.Find(p.ID);
            model.Amount = model.Amount + p.Amount;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        //modelimizdeki caegori ve birim drop dowlnlarını doldurmak için kullanıdğımız kısım
        public JsonResult GetBrand(int id2)
        {
            var model = new Products1();
            List<Brands> brandList = db.Brands.Where(x => x.CategoryID == id2).OrderBy(x => x.Brand).ToList();
            model.BrandList = (from x in brandList
                               select new SelectListItem
                               {
                                   Text = x.Brand,
                                   Value = x.ToString()
                               }
            ).ToList();
            model.BrandList.Insert(0, new SelectListItem { Text = "Seçiniz", Value = "" });
            return Json(model.BrandList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult UpdateInfo(int id)
        {
            var model = db.Products1.Find(id);
            Again(model);
            List<Brands> brandList = db.Brands.Where(x => x.CategoryID == model.CategoryID).OrderBy(x => x.Brand).ToList();
            model.BrandList = (from x in brandList select new SelectListItem {
                Text = x.Brand, Value = x.ID.ToString()
            }).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Products1 p)
        {
            if (!ModelState.IsValid)
            {
                var model = db.Products1.Find(p.ID);
                Again(model);
                List<Brands> brandList = db.Brands.Where(x => x.CategoryID == model.CategoryID).OrderBy(x => x.Brand).ToList();
                model.BrandList = (from x in brandList
                                   select new SelectListItem
                                   {
                                       Text = x.Brand,
                                       Value = x.ID.ToString()
                                   }).ToList();
                return View(model);
            }
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteInfo(Products1 p)
        {
            var model = db.Products1.Find(p.ID);
            if (model==null)
            {
                return HttpNotFound();
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            var model = db.Products1.FirstOrDefault(x => x.ID == id);
            db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}