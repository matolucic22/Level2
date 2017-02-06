using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class VehicleService
    {
        private static VehicleService Instance;
        
        public static VehicleService GetInstance()
        {
                if (Instance == null)
                {
                    Instance = new VehicleService();
                }
                return Instance;
        }
    }
}
