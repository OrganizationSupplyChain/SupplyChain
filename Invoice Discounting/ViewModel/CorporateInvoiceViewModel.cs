using Invoice_Discounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.ViewModel
{
    public class CorporateInvoiceViewModel
    {
        public IEnumerable<InvoiceList> InvoiceList { get; set; }
        public IEnumerable<RecourseFactoring> RecourseFactoringList { get; set; }
        public decimal CorporateAvailableLine { get; set; }
    }
}
