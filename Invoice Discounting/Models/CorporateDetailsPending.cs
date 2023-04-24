using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace Invoice_Discounting.Models
{
    public class CorporateDetailsPending
    {
        [DataType(DataType.Text)]
        public int ID { get; set; }
        [DataType(DataType.Text)]
        public int CORPORATEID { get; set; }
        [Required(ErrorMessage ="*")]
        [DataType(DataType.Text)]
        public string CORPORATENAME { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string PRINCIPALPHONENO { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string PRINCIPALEMAIL { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string PRINCIPALACCOUNTNO { get; set; }
        public char STATUS { get; set; }
        [DataType(DataType.Text)]
        public string CREATEDBYNAME { get; set; }
        [DataType(DataType.Text)]
        public string CREATEDBYEMAIL { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CREATEDDATE { get; set; }
        [DataType(DataType.Text)]
        public string AUTHORIZERNAME { get; set; }
        [DataType(DataType.Text)]
        public string AUTHORIZEREMAIL { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DATEAUTHORIZED { get; set; }
        [DataType(DataType.Text)]
        public int AUTHORIZATIONSTATUS { get; set; }
        [DataType(DataType.Text)]
        public string AUTHORIZERCOMMENT { get; set; }
        [DataType(DataType.Text)]
        public string UPDATETYPE { get; set; }
        [DataType(DataType.Text)]
        public decimal INTERESTRATE { get; set; }
        [DataType(DataType.Text)]
        public decimal AVAILABLELINEOFCREDIT { get; set; }
        [DataType(DataType.Text)]
        public decimal FEESRATE { get; set; }
    }
}
