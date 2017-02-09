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
    public class VehicleService:IVehicleService
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


        public IPagedList<VehicleMakeVM> OperationsMake(string search, int? page, string sortBy, string searchBy) //search-riječ koja dolazi iz buttona. page-koji je broj str ako je null (1), koliko elemenata u jednom(3), sortBy-kojim redom sortiraš searchBy radio
        {
           switch(searchBy)
            {
                case "Name":
                    switch (sortBy)
                    {
                        case "Name_desc": return Mapper.Map<IEnumerable<VehicleMakeVM>>(db.VehiclMakes.Where(x => x.Name.Contains(search) || search == null)).OrderByDescending(x=>x.Name).ToPagedList(page ?? 1, 3);
                        case "Abrv":return Mapper.Map<IEnumerable<VehicleMakeVM>>(db.VehiclMakes.Where(x => x.Name.Contains(search) || search == null)).OrderBy(x => x.Abrv).ToPagedList(page ?? 1, 3);
                        case "Abrv_desc": return Mapper.Map<IEnumerable<VehicleMakeVM>>(db.VehiclMakes.Where(x => x.Name.Contains(search) || search == null)).OrderByDescending(x => x.Abrv).ToPagedList(page ?? 1, 3);
                        default: return Mapper.Map<IEnumerable<VehicleMakeVM>>(db.VehiclMakes.Where(x => x.Name.Contains(search) || search == null)).OrderBy(x => x.Name).ToPagedList(page ?? 1, 3);

                    }
                case "Abrv":
                    switch(sortBy)
                    {
                        case "Name_desc": return Mapper.Map<IEnumerable<VehicleMakeVM>>(db.VehiclMakes.Where(x => x.Abrv.Contains(search) || search == null)).OrderByDescending(x => x.Name).ToPagedList(page ?? 1, 3);
                        case "Abrv": return Mapper.Map<IEnumerable<VehicleMakeVM>>(db.VehiclMakes.Where(x => x.Abrv.Contains(search) || search == null)).OrderBy(x => x.Abrv).ToPagedList(page ?? 1, 3);
                        case "Abrv_desc": return Mapper.Map<IEnumerable<VehicleMakeVM>>(db.VehiclMakes.Where(x => x.Abrv.Contains(search) || search == null)).OrderByDescending(x => x.Abrv).ToPagedList(page ?? 1, 3);
                        default: return Mapper.Map<IEnumerable<VehicleMakeVM>>(db.VehiclMakes.Where(x => x.Abrv.Contains(search) || search == null)).OrderBy(x => x.Name).ToPagedList(page ?? 1, 3);
                    }
                default:
                    switch (sortBy)
                    {
                        case "Name_desc":return Mapper.Map<IEnumerable<VehicleMakeVM>>(db.VehiclMakes.OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "Abrv": return Mapper.Map<IEnumerable<VehicleMakeVM>>(db.VehiclMakes.OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "Abrv_desc": return Mapper.Map<IEnumerable<VehicleMakeVM>>(db.VehiclMakes.OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        default: return Mapper.Map<IEnumerable<VehicleMakeVM>>(db.VehiclMakes.OrderBy(x => x.Name)).ToPagedList(page ?? 1, 3);
                    }
            }

        }



        

        

     /*   public IPagedList<VehicleMakeVM> FindMakeName(string search, int? page, string sortBy)
        {
           

            return 

        }
        public IPagedList<VehicleMakeVM> FindMakeAbrv(string search, int? page)
        {
            return 

        }*/




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


        public IPagedList<VehicleModelVM> OperationsModel(string search, int? page, string sortBy, string searchBy) //search-riječ koja dolazi iz buttona. page-koji je broj str ako je null (1), koliko elemenata u jednom(3), sortBy-kojim redom sortiraš, searchBy-radio
        {
            switch (searchBy)
            {
                case "Name":
                    switch (sortBy)
                    {
                        case "MakeName":return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.VehicleMake.Name.Contains(search) || search == null)).OrderBy(x => x.VehicleMake.Name).ToPagedList(page ?? 1, 3);
                        case "MakeName_desc": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.VehicleMake.Name.Contains(search) || search == null)).OrderByDescending(x => x.VehicleMake.Name).ToPagedList(page ?? 1, 3);
                        case "Name_desc": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderByDescending(x => x.Name).ToPagedList(page ?? 1, 3);
                        case "Abrv": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderBy(x => x.Abrv).ToPagedList(page ?? 1, 3);
                        case "Abrv_desc": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderByDescending(x => x.Abrv).ToPagedList(page ?? 1, 3);
                        default: return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderBy(x => x.Name).ToPagedList(page ?? 1, 3);

                    }
                case "Abrv":
                    switch (sortBy)
                    {
                        case "MakeName": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.VehicleMake.Name.Contains(search) || search == null)).OrderBy(x => x.VehicleMake.Name).ToPagedList(page ?? 1, 3);
                        case "MakeName_desc": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.VehicleMake.Name.Contains(search) || search == null)).OrderByDescending(x => x.VehicleMake.Name).ToPagedList(page ?? 1, 3);
                        case "Name_desc": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderByDescending(x => x.Name).ToPagedList(page ?? 1, 3);
                        case "Abrv": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderBy(x => x.Abrv).ToPagedList(page ?? 1, 3);
                        case "Abrv_desc": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderByDescending(x => x.Abrv).ToPagedList(page ?? 1, 3);
                        default: return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderBy(x => x.Name).ToPagedList(page ?? 1, 3);
                    }
                case "MakeName":
                    switch (sortBy)
                    {
                        case "MakeName": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.VehicleMake.Name.Contains(search) || search == null)).OrderBy(x => x.VehicleMake.Name).ToPagedList(page ?? 1, 3);
                        case "MakeName_desc": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.VehicleMake.Name.Contains(search) || search == null)).OrderByDescending(x => x.VehicleMake.Name).ToPagedList(page ?? 1, 3);
                        case "Name_desc": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderByDescending(x => x.Name).ToPagedList(page ?? 1, 3);
                        case "Abrv": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderBy(x => x.Abrv).ToPagedList(page ?? 1, 3);
                        case "Abrv_desc": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderByDescending(x => x.Abrv).ToPagedList(page ?? 1, 3);
                        default: return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderBy(x => x.Name).ToPagedList(page ?? 1, 3);
                    }
                default:
                    switch (sortBy)
                    {
                        case "MakeName": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.VehicleMake.Name.Contains(search) || search == null)).OrderBy(x => x.VehicleMake.Name).ToPagedList(page ?? 1, 3);
                        case "MakeName_desc": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.VehicleMake.Name.Contains(search) || search == null)).OrderByDescending(x => x.VehicleMake.Name).ToPagedList(page ?? 1, 3);
                        case "Name_desc": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderByDescending(x => x.Name).ToPagedList(page ?? 1, 3);
                        case "Abrv": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderBy(x => x.Abrv).ToPagedList(page ?? 1, 3);
                        case "Abrv_desc": return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderByDescending(x => x.Abrv).ToPagedList(page ?? 1, 3);
                        default: return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).OrderBy(x => x.Name).ToPagedList(page ?? 1, 3);
                    }
            }

        }
        /*     public IPagedList<VehicleModelVM> FindModelName(string search, int? page)
             {
                 return Mapper.Map<IEnumerable<VehicleModelVM>>( db.VehicleModels.Where(x => x.Name.Contains(search) || search == null)).ToPagedList(page ?? 1, 3);

             }
             public IPagedList<VehicleModelVM> FindModelAbrv(string search, int? page)
             {
                 return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.Where(x => x.Abrv.Contains(search) || search == null)).ToPagedList(page ?? 1, 3);

             }*/


        public IEnumerable<VehicleMakeVM> GetVehicleMakes()
        {

            return Mapper.Map<IEnumerable<VehicleMakeVM>>(db.VehiclMakes.ToList());
        }
        public IEnumerable<VehicleModelVM> GetVehicleModels()
        {
            return Mapper.Map<IEnumerable<VehicleModelVM>>(db.VehicleModels.ToList());
        }

        public VehicleMakeVM FindVehicleMake(Guid id)
        {
            VehicleMake vehicleMake = db.VehiclMakes.Find(id);
            return Mapper.Map<VehicleMakeVM>(vehicleMake);//mapping iz source(vehicleMake model) u VehicleMakeViewModel

        }
        public VehicleModelVM FindVehicleModel(Guid id)
        {
            VehicleModel vehicleModel = db.VehicleModels.Find(id);
            return Mapper.Map<VehicleModelVM>(vehicleModel);
        }



    }
}
