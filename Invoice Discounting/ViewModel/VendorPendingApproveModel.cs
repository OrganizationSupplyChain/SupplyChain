using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Models;

namespace Invoice_Discounting.ViewModel
{
    public class VendorPendingApproveModel
    {
        public IEnumerable<VendorDetails> vendorapproved { get; set; }

        public IEnumerable<VendorDetailsPending> vendorpending { get; set; }

    }
}
