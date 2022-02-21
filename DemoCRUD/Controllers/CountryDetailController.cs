using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoCRUD;
using DemoCRUD.Models;


namespace DemoCRUD.Controllers
{
    public class CountryDetailController : Controller
    {
        // GET: CountryDetail
        
        public ActionResult Index()
        {
            WorldEntities db = new WorldEntities();
            return View(db.Country.ToList());
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Country model)
        {
            WorldEntities db = new WorldEntities();
                if (ModelState.IsValid)
                {
                    db.Country.Add(model);
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorldEntities db = new WorldEntities();
            Country country = db.Country.Find(id);
            if (db == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }
        [HttpPost]
        public ActionResult Edit(Country model)
        {
            WorldEntities db = new WorldEntities();
            Country country = db.Country.Find(model.CountryId);
            if (country != null)
            {
                if (ModelState.IsValid)
                {
                    country.CountryName = model.CountryName;
                    db.Entry(country).State = EntityState.Modified;
                    db.SaveChanges();

                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorldEntities db = new WorldEntities();
            Country country = db.Country.Find(id);
            if (db == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            WorldEntities db = new WorldEntities();
            Country country = db.Country.Find(id);
            db.Country.Remove(country);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}