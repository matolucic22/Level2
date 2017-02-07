using Project.Service.DAL;
using Project.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        public void Create(VehicleMakeViewModel VehicleMakeViewModel)
        {
            VehicleMakeViewModel.Id = Guid.NewGuid();
            db.VehiclMakes.Add()

        }
    }
}
