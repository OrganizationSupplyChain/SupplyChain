using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.ViewModel
{
    public class ReverseFactoringVM
    {
        public int id { get; set; }
        public int contractid { get; set; }
        public int invoiceid { get; set; }
        public decimal totalamount { get; set; }
        public string vendorname { get; set; }
        public string vendoremail { get; set; }
        public int maturityperiod { get; set; }
        public int corporateid { get; set; }
        public string corporatename { get; set; }
        public int loanid { get; set; }
        public DateTime? daterequested { get; set; }
        public int FundsDisbursed { get; set; }
        public DateTime? disbursementDate { get; set; }
        public DateTime? ExpectedRepaymentDate { get; set; }
        public int LoanRepaid { get; set; }
        public DateTime? RepaymentDate { get; set; }
        public string loanstatus { get; set; }
        public string invoicenumber { get; set; }
        public string vendoraccountno { get; set; }
        public string description { get; set; }
        public string fcubsexternalref { get; set; }
        public string GL { get; set; }
        public string corporateacctno { get; set; }
        public string corporateacctname { get; set; }
    }
}
