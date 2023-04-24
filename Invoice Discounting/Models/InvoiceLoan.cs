using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class InvoiceLoan
    {
        public int id { get; set; }
        public int contractid { get; set; }
        public int invoiceid { get; set; }
        public decimal eligibleamount { get; set; }
        public decimal interest { get; set; }
        public decimal totalamount { get; set; }
        public string discountingtype { get; set; } // Invoice Discounting or reverse factoring
        public string requestorname { get; set; } 
        public string requestoremail { get; set; } 
        public int acceptterms { get; set; } 
        public DateTime? daterequested { get; set; }
        public decimal requestedamount { get; set; }
        public int FundsDisbursed { get; set; }
        public DateTime? disbursementDate { get; set; }
        public DateTime? ExpectedRepaymentDate { get; set; }
        public int LoanRepaid { get; set; }
        public DateTime? RepaymentDate { get; set; }
        public string loanstatus { get; set; }
        public string invoicenumber { get; set; }
        public string vendoraccountno { get; set; }
        public string vendoraccountname { get; set; }
        public decimal fees { get; set; }
    }
}
