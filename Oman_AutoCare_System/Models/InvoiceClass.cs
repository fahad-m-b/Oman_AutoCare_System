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
        public WorkOrderClass WorkOrder { get; set; }
        public static decimal VAT = 0.05m;

        public InvoiceClass(int invoice_ID, WorkOrderClass workOrder, PaymentMethod paymentMethod, DateOnly invoice_Date)
        {
            Invoice_ID = invoice_ID;
            WorkOrder = workOrder;
            this.paymentMethod = paymentMethod;
            Invoice_Date = invoice_Date;
        }

        public PaymentMethod paymentMethod { get; set; }
        public DateOnly Invoice_Date { get; set; }
        public decimal Total_Amount
        {
            get { 
            return WorkOrder.TotalCost * VAT;
             }
        }
    }
}
