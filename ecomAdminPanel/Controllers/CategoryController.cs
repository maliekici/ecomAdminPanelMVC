using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecomAdminPanel.Models.Entity;

namespace ecomAdminPanel.Controllers
{
    public class CategoryController : Controller
    {
        ecomAdminPanelEntities db = new ecomAdminPanelEntities();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

    }
}