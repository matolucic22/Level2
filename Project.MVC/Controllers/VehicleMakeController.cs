using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Service.DAL;
using Project.Service.Models;
using Project.Service;
using Project.Service.ViewModels;
using AutoMapper;

namespace Project.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private VehicleContext db = new VehicleContext();

        // GET: VehicleMake
      public ActionResult Index(string searchBy, string search, int? page, string sortBy)//search-riječ koja dolazi iz buttona. page-koji je broj str ako je null (1), koliko elemenata u jednom(3), sortBy-kojim redom sortiraš, searchBy-radio
        {
            ViewBag.SortNameMakeParameter = string.IsNullOrEmpty(sortBy) ? "Name_desc" : "";//if-than-else
            ViewBag.SortAbrvMakeParameter = sortBy == "Abrv" ? "Abrv_desc" : "Abrv";
            if (search == null)
            {
               return View(VehicleService.GetInstance().OperationsMake("", page, sortBy, ""));
            }
            else
            {
               return View(VehicleService.GetInstance().OperationsMake(search, page, sortBy, searchBy));
            }

        }
        

        // GET: VehicleMake/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = db.VehiclMakes.Find(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // GET: VehicleMake/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMake/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Abrv")] VehicleMakeVM vehicleMakeVM)
        {
            if (ModelState.IsValid)
            {
               
                VehicleService.GetInstance().CreateMake(vehicleMakeVM);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Krivo unesen maker");
            }

            return View(vehicleMakeVM);
        }

        // GET: VehicleMake/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = db.VehiclMakes.Find(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMake/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Abrv")] VehicleMakeVM vehicleMakeVM)
        {
            if (ModelState.IsValid)
            {
                VehicleService.GetInstance().EditMake(vehicleMakeVM);
                return RedirectToAction("Index");
            }
            return View(vehicleMakeVM);
        }

        // GET: VehicleMake/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = db.VehiclMakes.Find(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VehicleService.GetInstance().DeleteMake(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
