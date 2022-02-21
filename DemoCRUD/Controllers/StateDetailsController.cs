using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoCRUD.Models;
using System.Data.Entity;

namespace DemoCRUD.Controllers
{
    public class StateDetailsController : Controller
    {
        WorldEntities db = new WorldEntities();
        // GET: StateDetails
        public ActionResult Index()
        {
            //WorldEntities db = new WorldEntities();
            List<StateViewModeel> StatListModel = (from c in db.StateTable
                                 join
                                    d in db.Country on c.CountryId equals d.CountryId
                                 select new { c, d }).ToList().Select(x=>new StateViewModeel {
                                     CountyryId = x.c.CountryId,
                                     CountryName =x.d.CountryName,
                                     StateId=x.c.StateId,
                                     StateName=x.c.StatName
                                 }).ToList();
            return View(StatListModel);
        }
        public ActionResult StateInsert()
        {
            
            var context = db.Country.Select(x => new SelectListItem { Text = x.CountryName,Value=x.CountryId.ToString()}).ToList();
            List<SelectListItem> list = new List<SelectListItem>().ToList();
            ViewBag.countryList = context;
            return View();
        }
        [HttpPost]
        public ActionResult StateInsert(StateTable model)
        {
         
            if (ModelState.IsValid)
            {
                db.StateTable.Add(model);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            return View();
            
        }
        public ActionResult EditInsert(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorldEntities db = new WorldEntities();
            StateTable state = db.StateTable.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            //return View();
            var context = db.Country.Select(x => new SelectListItem { Text = x.CountryName, Value = x.CountryId.ToString() }).ToList();
            List<SelectListItem> list = new List<SelectListItem>().ToList();
            ViewBag.countryList = context;
            return View(state);
        }
        [HttpPost]
        public ActionResult EditInsert(StateTable model)
        {
            StateTable table = db.StateTable.Find(model.StateId);
            if(table!=null)
            {
                if (ModelState.IsValid)
                {
                    table.StatName = model.StatName;
                    db.Entry(table).State = EntityState.Modified;
                    db.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();

        }
        public ActionResult StateDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //WorldEntities db = new WorldEntities();
            StateTable state = db.StateTable.Find(id);
            if (db == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }
        [HttpPost, ActionName("StateDelete")]
        public ActionResult StateDeleteConfirmed(int id)
        {
            //WorldEntities db = new WorldEntities();
            StateTable table = db.StateTable.Find(id);
            db.StateTable.Remove(table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      

    }

}