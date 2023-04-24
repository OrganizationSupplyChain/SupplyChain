using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Models;

namespace Invoice_Discounting.ViewModel
{
    public class CorporatePendingApproveModel
    {
        public IEnumerable<CorporateDetails> corporateapproved { get; set; }

        public IEnumerable<CorporateDetailsPending> corporatepending { get; set; }
        public bool IsEnabled { get; set; }

    }
}
