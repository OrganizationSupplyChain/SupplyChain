using Invoice_Discounting.Models;
using System.Collections.Generic;

namespace Invoice_Discounting.ViewModel
{
    public class BidModalViewModel
    {
        public IEnumerable<BidModel> BidDetails { get; set; }
        public bool IsHistory { get; set; }
    }
}
