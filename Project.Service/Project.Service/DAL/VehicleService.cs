using Project.Service.DAL;
using Project.Service.Models;
using Project.Service.ViewModels;
using System;
using System.Data;
using AutoMapper;
using System.Data.Entity;
using System.Data.Entity.Migrations;

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
            
               // VehicleMakeViewModel.Id = Guid.NewGuid();
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

        public VehicleMakeVM FindMake(Guid id)
        {
            VehicleMake vehicleMake = db.VehiclMakes.Find(id);
            return Mapper.Map<VehicleMakeVM>(vehicleMake);
        }




        //Sad radim za model


        public void CreateModel(VehicleModelVM VehicleModelVM)
        {

            // VehicleMakeViewModel.Id = Guid.NewGuid();
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

        public VehicleModelVM FindModel(Guid id)
        {
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            return Mapper.Map<VehicleModelVM>(vehicleModel);
        }


    }
}
