using Invoice_Discounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.ViewModel
{
    public class InvestorPendingApproveModel
    {
        public IEnumerable<InvestorDetails> investorapproved { get; set; }

        public IEnumerable<InvestorDetailsPending> investorpending { get; set; }
    }
}
