using Project.Service.DAL;
using Project.Service.Models;
using Project.Service.ViewModels;
using System;
using System.Data;
using AutoMapper;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Collections;
using System.Linq;
using PagedList;
using PagedList.Mvc;
using System.Collections.Generic;

namespace Project.Service
{
    public class VehicleService
    {
        private static VehicleService Instance;
        private VehicleContext db = new VehicleContext();

        public static VehicleService GetInstance()
        {
                if (Instance == null)
                {
                    Instance = new VehicleService();
                }
                return Instance;
        }

        public void CreateMake(VehicleMakeVM VehicleMakeVM)
        {
            
                VehicleMakeVM.Id = Guid.NewGuid();
                db.VehiclMakes.Add(Mapper.Map<VehicleMake>(VehicleMakeVM));
                db.SaveChanges();

        }
        public void EditMake(VehicleMakeVM VehicleMakeVM)
        {
            // db.Entry(Mapper.Map<VehicleMake>(VehicleMakeVM)).State = EntityState.Modified;
            //db.SaveChanges();

            db.Set<VehicleMake>().AddOrUpdate(Mapper.Map<VehicleMake>(VehicleMakeVM));
            db.SaveChanges();
        }

        public void DeleteMake(Guid id)
        {
            VehicleMake vehicleMake = db.VehiclMakes.Find(id);
            db.VehiclMakes.Remove(vehicleMake);
            db.SaveChanges();
        }

        

        public IPagedList<VehicleMakeVM> FindMakeName(string search, int? page)
        {
            return Mapper.Map<IEnumerable<VehicleMakeVM>>(db.VehiclMakes.Where(x => x.Name.Contains(search) || search == null)).ToPagedList(page ?? 1, 3);

        }
        public IPagedList<VehicleMakeVM> FindMakeAbrv(string search, int? page)
        {
            return Mapper.Map<IEnumerable<VehicleMakeVM>>(db.VehicleModels.Where(x => x.Abrv.Contains(search) || search == null)).ToPagedList(page ?? 1, 3);

        }




        //Sad radim za model


        public void CreateModel(VehicleModelVM VehicleModelVM)
        {

            VehicleModelVM.Id = Guid.NewGuid();
            db.VehicleModels.Add(Mapper.Map<VehicleModel>(VehicleModelVM));
            db.SaveChanges();
            

        }
        public void EditModel(VehicleModelVM VehicleModelVM)
        {
            //  db.Entry(Mapper.Map<VehicleModel>(VehicleModelVM)).State = EntityState.Modified;
            // db.SaveChanges();
            db.Set<VehicleModel>().AddOrUpdate(Mapper.Map<VehicleModel>(VehicleModelVM));
            db.SaveChanges();
        }

        public void DeleteModel(Guid id)
        {
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            db.VehicleModels.Remove(vehicleModel);
            db.SaveChanges();
        }

        public IPagedList<VehicleModelVM> FindModelName(string search, int? page)
        {
            return Mapper.Map<IEnumerable<VehicleModelVM>>( db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).ToPagedList(page ?? 1, 3);

        }
        public IPagedList<VehicleModelVM> FindModelAbrv(string search, int? page)
        {
            return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Abrv.Contains(search) || search == null)).ToPagedList(page ?? 1, 3);

        }


    }
}
