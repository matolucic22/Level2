using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;

namespace Project.Service.DAL
{
   class VehicleInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<VehicleContext>
    {
      /*protected override void Seed(VehicleContext context)
        {
            var VehicleMakes = new List<VehicleMake>
            {
                new VehicleMake {Name="Skoda", Abrv="Skoda"}
                         
            };

            VehicleMakes.ForEach(v => context.VehiclMakes.Add(v));
            context.SaveChanges();

            var VehicleModels = new List<VehicleModel>
            {
                new VehicleModel { Name="Bla", Abrv="BBB" }
            
            };
            VehicleModels.ForEach(v => context.VehicleModels.Add(v));
            context.SaveChanges();
        }*/

    }
}
