using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oman_AutoCare_System.Models
{
    public class ServiceAssignmentClass
    {
        public ServiceClass Service { get; set; }
        public MechanicClass AssignedMechanic { get; set; }
    }
}
