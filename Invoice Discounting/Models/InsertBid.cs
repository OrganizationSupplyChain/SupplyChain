using System.ComponentModel.DataAnnotations;

namespace Invoice_Discounting.Models
{
    public class InsertBid
    {
        public int INVESTORID { get; set; }
        public int LOANID { get; set; }
        public string VENDORCODE { get; set; }
        public string LOANTYPE { get; set; }
        [Required]
        public decimal INTERESTRATE { get; set; }
        public string INVOICENUMBER { get; set; }
        public string INVESTORNAME { get; set; }
        public int INVOICEID { get; set; }
        public decimal LOANAMOUNT { get; set; }
    }
}
