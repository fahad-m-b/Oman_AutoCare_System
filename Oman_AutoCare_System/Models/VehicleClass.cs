using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Oman_AutoCare_System.Models
{
    public class VehicleClass
    {
        [Key]
        public int vehicaleID{ get; set; }
        public int plateNumber { get; set; }
        public string Models { get; set; } // From composite MOD
        public string Brand { get; set; }  // From composite MOD
        public string Year { get; set; }  // From composite MOD
        public DateOnly LastServiceTime { get; set; }


        [ForeignKey(nameof(CustomerId))] // Refers to the navigation property name
        public int CustomerId { get; set; } // FK column
        public CustomerClass customers { get; set; } // Navigation property


        //____________________ Note _______________________________________________________________________//
        //CustomerId The FK column in the Vehicle table                                                    //
        //[ForeignKey(nameof(Customer))] Tells EF that this FK links to the Customer navigation property   //
        //Customer    The navigation property(object reference)                                            //
        //Vehicles The reverse navigation(one-to-many) in CustomerClass                                    //
        //-------------------------------------------------------------------------------------------------//
    }
}
