using Oman_AutoCare_System.Enums;
using Oman_AutoCare_System.Models;

namespace Oman_AutoCare_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var oilChange = new ServiceClass { serviceID = 1, Name = "Oil Change", estimatedTime = 30, Cost = 15 };
            var tireReplacement = new ServiceClass { serviceID = 2, Name = "Tire Replacement", estimatedTime = 60, Cost = 50 };
            var engineCheck = new ServiceClass { serviceID = 3, Name = "Engine Check", estimatedTime = 120, Cost = 100 };

            var services = new List<ServiceClass> { oilChange, tireReplacement, engineCheck };

            // Create mechanics and assign specializations
            var mechanic1 = new MechanicClass { Name = "Ahmed", Phone_Number = "91111", Experience_Year = 5, Specialization = new List<ServiceClass> { oilChange, tireReplacement } };
            var mechanic2 = new MechanicClass { Name = "Salim", Phone_Number = "92222", Experience_Year = 8, Specialization = new List<ServiceClass> { engineCheck } };

            var mechanics = new List<MechanicClass> { mechanic1, mechanic2 };

            // Create a customer and vehicle
            var customer = new CustomerClass(1, 123456789, "Ali", "90001", "ali@email.com", "ali street", "Muscat");
            var vehicle = new VehicleClass{plateNumber = 12345,Models = "Civic",Brand = "Honda",Year = "2020",LastServiceTime = DateOnly.FromDateTime(DateTime.Now.AddMonths(-8)),customers = customer};
            customer.AddVehicale(vehicle);

            var vehicles = new List<VehicleClass> { vehicle };
            var customers = new List<CustomerClass> { customer };

            // Change WorkOrderClass instantiation to use the required constructor parameters
            var workOrder = new WorkOrderClass(
                1, // WorkOrder_ID
                DateOnly.FromDateTime(DateTime.Now), // Date
                Status.Pending, // status
                customer, // Custromer
                vehicle // Vehicle
            );

            // Assign services to mechanics
            workOrder.AddServiceAssignment(oilChange, mechanic1);
            workOrder.AddServiceAssignment(tireReplacement, mechanic1);

            var workOrders = new List<WorkOrderClass> { workOrder };

            // Output work order info
            Console.WriteLine($"Work Order {workOrder.WorkOrder_ID} created for vehicle {vehicle.plateNumber}");
            Console.WriteLine("Services Assigned:");
            foreach (var sa in workOrder.ServiceAssignments)
                Console.WriteLine($"- {sa.Service.Name} -> Mechanic: {sa.AssignedMechanic.Name}");
            Console.WriteLine($"Total Cost (without VAT): {workOrder.TotalCost:C}");

            // Replace the object initializer with a constructor call for InvoiceClass
            var invoice = new InvoiceClass(
                1, // Invoice_ID
                workOrder, // WorkOrder
                PaymentMethod.card, // paymentMethod
                DateOnly.FromDateTime(DateTime.Now) // Invoice_Date
            );

            Console.WriteLine($"Invoice {invoice.Invoice_ID} generated. Total Amount (with VAT 5%): {invoice.Total_Amount:C}");

            // List overdue vehicles
            var overdue = vehicles.Where(v => v.LastServiceTime < DateOnly.FromDateTime(DateTime.Now.AddMonths(-6))).ToList();
            Console.WriteLine("\nVehicles not serviced in last 6 months:");
            foreach (var v in overdue)
                Console.WriteLine($"{v.plateNumber} - {v.Brand} {v.Models} - Last Service: {v.LastServiceTime.ToShortDateString()}");
        
    }
    }
}
