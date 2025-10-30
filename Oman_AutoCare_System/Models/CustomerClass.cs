using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oman_AutoCare_System.Models
{
    public class CustomerClass
    {
        //constructer
        public CustomerClass(int CustomerId, int civil_ID, string name, string phoneNumber, string email, string street, string city)
        {
            this.CustomerId = CustomerId;
            Civil_ID = civil_ID;
            Name = name;
            this.phoneNumber = phoneNumber;
            Email = email;
            Street = street;
            City = city;
        }

        [Key]
        public int CustomerId { get; set; } //PK
        //public ICollection<VehicleClass> Vehicles { get; set; } = new HashSet<VehicleClass>(); // Navigation property
        public int Civil_ID { get; set; }
        public string Name { get; set; }
        public string phoneNumber { get; set; }
        public string Email { get; set; }
        public string Street { get; set; } // From composite Address
        public string City { get; set; } // From composite Address

        public List<VehicleClass> vehicles { get; set; } = new List<VehicleClass>();
        public void AddVehicale(VehicleClass vehicle) { vehicles.Add(vehicle); }
    }
}
