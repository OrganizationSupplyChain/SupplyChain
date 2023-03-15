using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class VendorContractBidsDetails
    {
        public int id { get; set; }
        public string VendorName { get; set; }
        public string ResponseStatus { get; set; }
        public string CorporateName { get; set; }
        public string UniqueCorporateId { get; set; }
        public string ContractNumber { get; set; }
        public string ContractName { get; set; }

    }
}
