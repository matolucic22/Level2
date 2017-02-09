using PagedList;
using Project.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.DAL
{
    public interface IVehicleService
    {
        void CreateMake(VehicleMakeVM VehicleMakeVM);
        void EditMake(VehicleMakeVM VehicleMakeVM);
        void DeleteMake(Guid id);
        IPagedList<VehicleMakeVM> OperationsMake(string search, int? page, string sortBy, string searchBy);
        void CreateModel(VehicleModelVM VehicleModelVM);
        void EditModel(VehicleModelVM VehicleModelVM);
        void DeleteModel(Guid id);
        IPagedList<VehicleModelVM> OperationsModel(string search, int? page, string sortBy, string searchBy);
        IEnumerable<VehicleMakeVM> GetVehicleMakes();
        IEnumerable<VehicleModelVM> GetVehicleModels();
        VehicleMakeVM FindVehicleMake(Guid id);
        VehicleModelVM FindVehicleModel(Guid id);


    }
}
