using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class InvoiceList
    {        
        public int invoiceid { get; set; }
        public int contractid { get; set; }
        public string invoicenumber { get; set; }
        public DateTime? invoicedate { get; set; }
        public string contractnumber { get; set; }
        public string vendorname { get; set; }
        public string vendoremail { get; set; }
        public string projectname { get; set; }
        public decimal totalincludingvat { get; set; }
        public string CorporateName { get; set; }
        public string invoicestatus { get; set; }
        public DateTime? expectedrepaymentdate { get; set; }
    }
}
