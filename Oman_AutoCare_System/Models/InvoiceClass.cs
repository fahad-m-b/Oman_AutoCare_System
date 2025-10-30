using Oman_AutoCare_System.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oman_AutoCare_System.Models
{
    public class InvoiceClass
    {
        [Key]
        public int Invoice_ID { get; set; }
        
        public static decimal VAT = 0.05m;
        public PaymentMethod paymentMethod { get; set; }
        public DateOnly Invoice_Date { get; set; }
        public WorkOrderClass WorkOrder { get; set; }

        public decimal TotalWithVAT()
        {
            decimal total = (decimal)WorkOrder.TotalCost * VAT;
            return total;
        }
    }
}
