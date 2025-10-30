using Oman_AutoCare_System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oman_AutoCare_System.Models
{
    public class MechanicClass
    {
        public int Mechanic_ID { get; set; }
        public string Name { get; set; }
        public string Phone_Number { get; set; }
        public Specialization Specialization { get; set; }
        public int Experience_Year { get; set; }
    }
}
