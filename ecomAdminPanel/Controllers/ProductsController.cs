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

        public ActionResult Add()
        {
            return View();
        }
    }
}