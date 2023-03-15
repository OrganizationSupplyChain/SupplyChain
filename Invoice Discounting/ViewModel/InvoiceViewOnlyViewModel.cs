using Invoice_Discounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.ViewModel
{
    public class InvoiceViewOnlyViewModel
    {
        public IEnumerable<InvoiceList> InvoiceDetails { get; set; }
        public IEnumerable<InvoiceLoan> InvoiceDiscounting { get; set; }
        public IEnumerable<RecourseFactoring> ReverseFactoring { get; set; }
        public string InvoiceDiscountingGL { get; set; }
        public string ReverseFactoringGL { get; set; }
    }
}
