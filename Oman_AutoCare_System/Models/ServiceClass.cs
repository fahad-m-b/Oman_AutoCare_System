using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oman_AutoCare_System.Models
{
    public class ServiceClass
    {
        [Key]
        public int serviceID { get; set; }
        public string Name { get; set; }
        public int estimatedTime { get; set; }
        public decimal Cost { get; set; }

        public List<MechanicClass> Mechanics { get; set; } = new List<MechanicClass>();
        public void AssignMechanic(MechanicClass mechanic)
        {
            Mechanics.Add(mechanic);
        }
    }
}
