using Invoice_Discounting.Models;
using Microsoft.VisualBasic;
using System;

namespace Invoice_Discounting.ViewModel
{
    public class InsertBidViewModel
    {
        public InsertBid InsertBid { get; set; }
        public string VendorName { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime BidDate { get; set; }
    }
}
