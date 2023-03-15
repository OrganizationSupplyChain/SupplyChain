using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class VendorBreakdown
    {
        public string VendorName { get; set; }
        public string VendorEmail { get; set; }
        public int ContractResponseCount { get; set; }
        public int InvoiceDiscountingCount { get; set; }
        public int InvoiceCount { get; set; }
        
    }
}
