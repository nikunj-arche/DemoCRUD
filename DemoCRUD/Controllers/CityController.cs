using DemoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DemoCRUD.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        WorldEntities db = new WorldEntities();
        public ActionResult Index()
        {
            List<CityViewModel> cityViewModels = (from c in db.CityTable
                                                  join
                                                  s in db.StateTable on c.StateId equals s.StateId
                                                  join
                                                  d in db.Country on s.CountryId equals d.CountryId
                                                  select new { c, s,d }).ToList().Select(x => new CityViewModel
                                                  {
                                                      countryId = x.s.CountryId,
                                                      countryname = x.d.CountryName,
                                                      stateId = x.c.StateId,
                                                      statename = x.s.StatName,
                                                      CityId=x.c.CityId,
                                                      City=x.c.City
                                                  }).ToList();
            return View(cityViewModels);
        }
        public ActionResult AddCity()
        {
            var context = db.Country.Select(x => new SelectListItem { Text = x.CountryName, Value = x.CountryId.ToString() }).ToList();
            List<SelectListItem> list = new List<SelectListItem>().ToList();
            ViewBag.countryList = context;
            var cont = db.StateTable.Select(x => new SelectListItem { Text = x.StatName, Value = x.StateId.ToString() }).ToList();
            List<SelectListItem> list1 = new List<SelectListItem>().ToList();
            ViewBag.statelist = cont;
            return View();
        }
        [HttpPost]
        public ActionResult AddCity(CityTable model)
        {
            if (ModelState.IsValid)
            {
                db.CityTable.Add(model);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");

            }
            return View();
        }
        public ActionResult EditCity(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityTable table = db.CityTable.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            var context = db.Country.Select(x => new SelectListItem { Text = x.CountryName, Value = x.CountryId.ToString() }).ToList();
            List<SelectListItem> list = new List<SelectListItem>().ToList();
            ViewBag.countryList = context;
            var cont = db.StateTable.Select(x => new SelectListItem { Text = x.StatName, Value = x.StateId.ToString() }).ToList();
            List<SelectListItem> list1 = new List<SelectListItem>().ToList();
            ViewBag.stateList = cont;
            return View(table);
            
        }
        [HttpPost]
        public ActionResult EditCity(CityTable model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");

            }
            return View();
        }
        public ActionResult DeleteCity(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //WorldEntities db = new WorldEntities();
            CityTable state = db.CityTable.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }
        [HttpPost,ActionName("DeleteCity")]
        public ActionResult DeleteCity(int id)
        {
            CityTable table = db.CityTable.Find(id);
            db.CityTable.Remove(table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult FillState(int CountryDetail)
        {
            var States = db.StateTable.Where(c => c.CountryId == CountryDetail);
            return Json(States, JsonRequestBehavior.AllowGet);
        }
    }
}