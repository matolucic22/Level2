using AutoMapper;
using Project.Service.Models;
using Project.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Project.MVC.App_Start
{
    public static class MapConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<VehicleMake, VehicleMakeVM>().ReverseMap();//source-destination
                cfg.CreateMap<VehicleModel, VehicleModelVM>().ReverseMap();
             });

        }
    }
}