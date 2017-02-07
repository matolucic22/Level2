using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.ViewModels
{
   public class VehicleMakeViewModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Abrv { get; set; }

        public virtual ICollection<VehicleModel> VehicleModels { get; set; }//1 make ima vise modela
    }
}
