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
    }
}