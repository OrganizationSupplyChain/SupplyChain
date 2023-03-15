using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class RecourseFactoring
    {
        public int id { get; set; }
        public int contractid { get; set; }
        public int invoiceid { get; set; }
        [Required]
        //[Range(1, decimal.MaxValue, ErrorMessage = "Please enter valid amount")]
        //[DataType(DataType.Currency)]
        public decimal totalamount { get; set; }
        [Required]
        public string vendorname { get; set; }
        [Required]
        public string vendoremail { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid maturity period")]
        public int maturityperiod { get; set; }
        public int corporateid { get; set; }
        public string corporatename { get; set; }
        public int loanid { get; set; }
        public DateTime? daterequested { get; set; }
        public int FundsDisbursed { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? disbursementDate { get; set; }
        public DateTime? ExpectedRepaymentDate { get; set; }
        public int LoanRepaid { get; set; }
        public DateTime? RepaymentDate { get; set; }
        public string loanstatus { get; set; }
        public string invoicenumber { get; set; }
        [Required]
        public string vendoraccountno { get; set; }
        [Required]
        public string vendoraccountname { get; set; }
        public string description { get; set; }
        public string fcubsexternalref { get; set; }
    }
}
