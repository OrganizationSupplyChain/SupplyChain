using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class VendorResponseDetails
    {
        public ContractDetails ContractDetails { get; set; }
        public ContractResponse ContractResponse { get; set; }
        public IEnumerable<ContractUDFResponse> UdfResponse { get; set; }
        public string AuthStatus { get; set; }
    }
}
