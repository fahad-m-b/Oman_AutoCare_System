using Oman_AutoCare_System.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oman_AutoCare_System.Models
{
    public class WorkOrderClass
    {
        public WorkOrderClass(int workOrder_ID, DateOnly date, Status status, CustomerClass custromer, VehicleClass vehicle)
        {
            WorkOrder_ID = workOrder_ID;
            Date = date;
            this.status = status;
            Custromer = custromer;
            Vehicle = vehicle;
        }

        public int WorkOrder_ID { get; set; }
        public DateOnly Date { get; set; }
        public Status status { get; set; }
        public CustomerClass Custromer { get; set; }
        public VehicleClass Vehicle { get; set; }

        public List<ServiceAssignmentClass> ServiceAssignments { get; set; } = new List<ServiceAssignmentClass>();

        public decimal TotalCost
        {
            get{
                return ServiceAssignments.Sum(sa => sa.Service.Cost);
            }
        }
        public void AddServiceAssignment(ServiceClass service, MechanicClass mechanic)
        {
            if(mechanic.Specialization.Contains(service) && mechanic.CanTakeWorkOrder())
            {
                ServiceAssignments.Add(new ServiceAssignmentClass { Service = service, AssignedMechanic = mechanic });
                mechanic.AssignWorkOrder(this);
            }
        }
    }
}
