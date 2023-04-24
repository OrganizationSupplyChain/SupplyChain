using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class CorporateLoan
    {
        public int id { get; set; }
        public int contractid { get; set; }
        public int corporateid { get; set; }
        public string corporatename { get; set; }
        [Required]
        public string accountnumber { get; set; }
        public int loanid { get; set; }
        public decimal availablelimit { get; set; }
        public decimal interest { get; set; }
        public decimal totalamount { get; set; }
        public int maturityperiod { get; set; } // Invoice Discounting or reverse factoring
        public DateTime? daterequested { get; set; }
        public decimal requestedamount { get; set; }
        public int fundsdisbursed { get; set; }
        public DateTime? disbursementDate { get; set; }
        public DateTime? expectedrepaymentDate { get; set; }
        public int loanrepaid { get; set; }
        public DateTime? repaymentdate { get; set; }
        [Required]
        public string accountname { get; set; }
        public decimal fees { get; set; }
    }
}
