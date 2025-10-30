using Oman_AutoCare_System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oman_AutoCare_System.Models
{
    public class InvoiceClass
    {
        public int Invoice_ID { get; set; }
        public decimal Total_Amount { get; set; }
        public static decimal VAT = 0.05m;
        public PaymentMethod paymentMethod { get; set; }
        public DateOnly Invoice_Date { get; set; }
        public WorkOrderClass WorkOrder_ID { get; set; }
    }
}
