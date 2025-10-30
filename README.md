# 🚗 Oman AutoCare Center Management System

### 🧾 Overview
**Oman AutoCare** is a chain of car maintenance and repair centers operating across **Muscat** and **Sohar**.  
This project was developed to **digitize their daily operations** — managing customers, vehicles, mechanics, services, and invoices — to replace manual paper-based records.

---

## 🏢 Business Scenario

### 1️⃣ Customers & Vehicles
- A **customer** can own multiple vehicles.  
- Each **vehicle** belongs to exactly one customer.  
- **Customer Details:** Name, Phone, Civil ID, Email, Address  
- **Vehicle Details:** Plate Number (unique), Model, Brand, Year, Last Service Date  

---

### 2️⃣ Services & Mechanics
**Services offered include:**
- Oil Change  
- Tire Replacement  
- Engine Check  
- Brake Service  
- Full Inspection  

**Each Service has:**
- Service ID  
- Name  
- Estimated Duration  
- Cost  

**Mechanics have:**
- Name  
- Phone  
- Experience (years)  
- Specializations  

Relationships:  
- A mechanic can perform multiple services.  
- A service can be handled by multiple mechanics (**many-to-many**).

---

### 3️⃣ Work Orders (Service Orders)
When a vehicle arrives, a **Work Order** is created linking the:
- Customer  
- Vehicle  
- Requested Services  

Each Work Order includes:
- WorkOrder ID  
- Date  
- Status (Pending, In Progress, Completed)  
- Total Cost  

Each service in the order is assigned to a **mechanic**.

---

### 4️⃣ Invoices & Payments
After completing a Work Order, an **Invoice** is generated containing:
- Invoice ID  
- WorkOrder ID  
- Total Amount  
- VAT (5%)  
- Payment Method (Cash / Card / Online)  
- Invoice Date  

---

### 5️⃣ Business Rules
✅ A mechanic cannot work on more than **3 active Work Orders** at the same time.  
✅ Services must be assigned only to mechanics **specialized** in that service.  
✅ The system automatically calculates **Total Invoice Cost** = sum of all service costs + 5% VAT.  
✅ The system lists **vehicles not serviced in the last 6 months**.

---

## 💻 Implementation (C# Code Example)

```csharp
var oilChange = new ServiceClass { serviceID = 1, Name = "Oil Change", estimatedTime = 30, Cost = 15 };
var tireReplacement = new ServiceClass { serviceID = 2, Name = "Tire Replacement", estimatedTime = 60, Cost = 50 };
var engineCheck = new ServiceClass { serviceID = 3, Name = "Engine Check", estimatedTime = 120, Cost = 100 };

var services = new List<ServiceClass> { oilChange, tireReplacement, engineCheck };

// Mechanics and their specializations
var mechanic1 = new MechanicClass { Name = "Ahmed", Phone_Number = "91111", Experience_Year = 5, Specialization = new List<ServiceClass> { oilChange, tireReplacement } };
var mechanic2 = new MechanicClass { Name = "Salim", Phone_Number = "92222", Experience_Year = 8, Specialization = new List<ServiceClass> { engineCheck } };

var mechanics = new List<MechanicClass> { mechanic1, mechanic2 };

// Customer and vehicle
var customer = new CustomerClass(1, 123456789, "Ali", "90001", "ali@email.com", "ali street", "Muscat");
var vehicle = new VehicleClass { plateNumber = 12345, Models = "Civic", Brand = "Honda", Year = "2020", LastServiceTime = DateOnly.FromDateTime(DateTime.Now.AddMonths(-8)), customers = customer };
customer.AddVehicale(vehicle);

var vehicles = new List<VehicleClass> { vehicle };
var customers = new List<CustomerClass> { customer };

// Work order creation
var workOrder = new WorkOrderClass(
    1,
    DateOnly.FromDateTime(DateTime.Now),
    Status.Pending,
    customer,
    vehicle
);

// Assign services
workOrder.AddServiceAssignment(oilChange, mechanic1);
workOrder.AddServiceAssignment(tireReplacement, mechanic1);

var workOrders = new List<WorkOrderClass> { workOrder };

// Display work order
Console.WriteLine($"Work Order {workOrder.WorkOrder_ID} created for vehicle {vehicle.plateNumber}");
Console.WriteLine("Services Assigned:");
foreach (var sa in workOrder.ServiceAssignments)
    Console.WriteLine($"- {sa.Service.Name} -> Mechanic: {sa.AssignedMechanic.Name}");
Console.WriteLine($"Total Cost (without VAT): {workOrder.TotalCost:C}");

// Generate invoice
var invoice = new InvoiceClass(
    1,
    workOrder,
    PaymentMethod.card,
    DateOnly.FromDateTime(DateTime.Now)
);

Console.WriteLine($"Invoice {invoice.Invoice_ID} generated. Total Amount (with VAT 5%): {invoice.Total_Amount:C}");

// List overdue vehicles
var overdue = vehicles.Where(v => v.LastServiceTime < DateOnly.FromDateTime(DateTime.Now.AddMonths(-6))).ToList();
Console.WriteLine("\nVehicles not serviced in last 6 months:");
foreach (var v in overdue)
    Console.WriteLine($"{v.plateNumber} - {v.Brand} {v.Models} - Last Service: {v.LastServiceTime.ToShortDateString()}");
