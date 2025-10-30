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
        public CustomerClass CustromerCivil_ID { get; set; }
        public VehicleClass Vehicle_PlateNumber { get; set; }
        public MechanicClass Mechanic { get; set; }

        public List<ServiceAssignmentClass> ServiceAssignments { get; set; } = new List<ServiceAssignmentClass>();

        public decimal TotalCost()
        {
            return ServiceAssignments.Sum(sa => sa.Service.Cost);
        }
        public void AddServiceAssignment(ServiceClass service, MechanicClass mechanic)
        {
            if(Mechanic.Specialization.Contains(service) && mechanic.CanTakeWorkOrder())
            {
                ServiceAssignments.Add(new ServiceAssignmentClass { Service = service, AssignedMechanic = mechanic });
                mechanic.AssignWorkOrder(this);
            }
        }
    }
}
