using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Project.Service.DAL
{
    public class VehicleContext : DbContext
    {
        public VehicleContext() : base("VehicleContext")//connection string - dodat ces ga u Web.config
        {
        }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleMake> VehiclMakes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
