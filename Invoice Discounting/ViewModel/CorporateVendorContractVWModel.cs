using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Models;

namespace Invoice_Discounting.ViewModel
{
    public class CorporateVendorContractVWModel
    {
        public CorporateDetails Corporatedetails { get; set; }
        public IEnumerable<VendorBreakdown> VendoBreakDown { get; set; }
        public IEnumerable<ContractDetails> Contracts { get; set; }

    }
}
