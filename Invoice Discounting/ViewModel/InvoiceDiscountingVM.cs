using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.ViewModel
{
    public class InvoiceDiscountingVM
    {
        public int id { get; set; }
        public decimal interest { get; set; }
        public decimal totalamount { get; set; }
        public string requestorname { get; set; }
        public string requestoremail { get; set; }
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
        public int loantenor { get; set; }
        public decimal interestrate { get; set; }
        public string corporatename { get; set; }
        public string GL { get; set; }
    }
}
