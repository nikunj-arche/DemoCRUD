using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoCRUD.Controllers
{
    public class PersonalInfoController : Controller
    {
        public ActionResult Index()
        {
            WorldEntities db = new WorldEntities();
            return View(db.Country.ToList();
        }
    }
}