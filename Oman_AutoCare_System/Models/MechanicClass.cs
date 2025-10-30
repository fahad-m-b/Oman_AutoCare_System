using Oman_AutoCare_System.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oman_AutoCare_System.Models
{
    public class MechanicClass
    {
        [Key]
        public int Mechanic_ID { get; set; }
        public string Name { get; set; }
        public string Phone_Number { get; set; }
        public int Experience_Year { get; set; }
        public List<ServiceClass> Specialization { get; set; } = new List<ServiceClass>();
        public List<WorkOrderClass> ActiveWorkOrders { get; set; } = new List<WorkOrderClass>();

        public bool CanTakeWorkOrder()
        {
            return ActiveWorkOrders.Count < 3;
        }
        public void AssignWorkOrder(WorkOrderClass workOrderClass)
        {
            if (CanTakeWorkOrder())
            {
                ActiveWorkOrders.Add(workOrderClass);
            }
        }
    }
}
