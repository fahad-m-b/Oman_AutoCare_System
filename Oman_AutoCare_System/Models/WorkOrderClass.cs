using Oman_AutoCare_System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oman_AutoCare_System.Models
{
    public class WorkOrderClass
    {
        public int WorkOrder_ID { get; set; }
        public DateOnly Date { get; set; }
        public Status status { get; set; }
        public double TotalCost;
        public CustomerClass CustromerCivil_ID { get; set; }
        public VehicleClass Vehicle_PlateNumber { get; set; }
        public MechanicClass Mechanic_ID { get; set; }


    }
}
