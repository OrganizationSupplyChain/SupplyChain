using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class ContractInvoice
    {
       // [DataType(DataType.Text)]
        public int id { get; set; }
        public int contractid { get; set; }
        [Required(ErrorMessage ="*")]
        public string invoicenumber { get; set; }
        //[DataType(DataType.DateTime)]
        public DateTime? invoicedate { get; set; }
        [Required(ErrorMessage ="*")]
        public string vatregistrationno { get; set; }
        [Required(ErrorMessage ="*")]
        public string vendorcode { get; set; }
        [Required(ErrorMessage ="*")]
        public string tin { get; set; }
        [Required(ErrorMessage ="*")]
        public string contractnumber { get; set; }
        [Required(ErrorMessage ="*")]
        public string ponumber { get; set; }
        [Required(ErrorMessage ="*")]
        public string projectname { get; set; }
        //[DataType(DataType.Text)]
        public string vendorname { get; set; }
        [Required(ErrorMessage ="*")]
        //[DataType(DataType.EmailAddress)]
        public string vendoremail { get; set; }
        [Required(ErrorMessage ="*")]
        public string vendoraddress { get; set; }
        [Required(ErrorMessage ="*")]
        public string vendorphoneno { get; set; }
        [Required(ErrorMessage ="*")]
       // [DataType(DataType.MultilineText)]
        public string description { get; set; }
        [Required(ErrorMessage ="*")]
        public int days { get; set; }
        //[DataType(DataType.Text)]
        public decimal unitprice { get; set; }
        [Required(ErrorMessage ="*")]
        public decimal totalexcludingvat { get; set; }
        [Required(ErrorMessage ="*")]
        public decimal totalincludingvat { get; set; }
        //[DataType(DataType.Text)]
        public string totalamountinwords { get; set; }
        [Required(ErrorMessage ="*")]
        public string accountnumber { get; set; }
        [Required(ErrorMessage ="*")]
        public string accountname { get; set; }
        [Required(ErrorMessage ="*")]
        public string bankname { get; set; }
        //[DataType(DataType.Text)]
        public string invoicestatus { get; set; }
        [Required(ErrorMessage ="*")]
        public string vatrate { get; set; }
        //[DataType(DataType.Text)]
        public string AUTHORIZERNAME { get; set; }
        //[DataType(DataType.EmailAddress)]
        public string AUTHORIZEREMAIL { get; set; }
        //[DataType(DataType.Text)]
        public string AUTHORIZERCOMMENT { get; set; }
        //[DataType(DataType.DateTime)]
        public DateTime? DATEAUTHORIZED { get; set; }
        //[DataType(DataType.Text)]
        public int requestdiscounting { get; set; } 
        //[DataType(DataType.Text)]
        public int ISAUTOREPAYMENT { get; set; } 
        //[DataType(DataType.DateTime)]
        public DateTime? EXPECTEDREPAYMENTDATE { get; set; } 
        //[DataType(DataType.Text)]
        public int PAYMENTSETTLED { get; set; }
        //[DataType(DataType.DateTime)]
        public DateTime? REPAYMENTDATE { get; set; }
        public byte[] SUPPORTINGDOCUMENT1 { get; set; }
        public byte[] SUPPORTINGDOCUMENT2 { get; set; }
        public string SUPPORTINGDOC1FILENAME { get; set; }
        public string SUPPORTINGDOC2FILENAME { get; set; }
        public int CORPORATEID { get; set; }
    }
}
