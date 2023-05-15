using System;

namespace Invoice_Discounting.Models
{
    public class BidModel
    {
        public int ID { get; set; }
        public int INVESTORID { get; set; }
        public string INVESTORNAME { get; set; }
        public int LOANID { get; set; }
        public int INVOICEID { get; set; }
        public string INVOICENUMBER { get; set; }
        public string VENDORCODE { get; set; }
        public string LOANTYPE { get; set; }
        public decimal INTERESTRATE { get; set; }
        public decimal LOANAMOUNT { get; set; }
        public string STATUS { get; set; }
        public DateTime ADDDATETIME { get; set; }
        public DateTime LASTUPDATETIME { get; set; }
       
        
    }
}
