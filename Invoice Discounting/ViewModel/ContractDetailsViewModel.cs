using Invoice_Discounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.ViewModel
{
    public class ContractDetailsViewModel
    {
        public ContractDetails Contract { get; set; }
        public IEnumerable<ContractResponse> ResponseList { get; set; }
        
    }
}
