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

namespace Project.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        private VehicleContext db = new VehicleContext();

        // GET: VehicleModel
        public ActionResult Index(string searchBy, string search, int? page, string sortBy)//search-riječ koja dolazi iz buttona. page-koji je broj str ako je null (1), koliko elemenata u jednom(3), sortBy-kojim redom sortiraš, searchBy-radio
        {
          ViewBag.SortNameParameter = string.IsNullOrEmpty(searchBy) ? "Name desc" : "";
          ViewBag.SortAbrvParameter = sortBy == "Abrv" ? "Abrv_desc" : "Abrv";

          //var VehicleModels = db.VehicleModels.AsQueryable();

            if (searchBy == null)
            {
                return View(VehicleService.GetInstance().OperationsModel(search, page, sortBy, searchBy));
            }
            else
            {
                return View(VehicleService.GetInstance().OperationsModel(search, page, sortBy, searchBy));

            }
           
        }

        // GET: VehicleModel/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // GET: VehicleModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdVehicleMake,Name,Abrv")] VehicleModelVM vehicleModelVM)
        {
            if (ModelState.IsValid)
            {
                VehicleService.GetInstance().CreateModel(vehicleModelVM);
                return RedirectToAction("Index");
            }

            return View(vehicleModelVM);
        }

        // GET: VehicleModel/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: VehicleModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdVehicleMake,Name,Abrv")] VehicleModelVM vehicleModelVM)
        {
            if (ModelState.IsValid)
            {
                VehicleService.GetInstance().EditModel(vehicleModelVM);
                return RedirectToAction("Index");
            }
            return View(vehicleModelVM);
        }

        // GET: VehicleModel/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: VehicleModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VehicleService.GetInstance().DeleteModel(id);
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
