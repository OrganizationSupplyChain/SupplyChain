using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    [Serializable]
    public class CorporateDetails
    {
        public int ID { get; set; }
        [Required]
        public string CORPORATENAME { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [RegularExpression(@"^((\+91-?)|0)?[0-9]{10}$", ErrorMessage = "Entered phone format is not valid.")]
        public string PRINCIPALPHONENO { get; set; }
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string PRINCIPALEMAIL { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Required(ErrorMessage = "The Account Number Field is required")]
        [StringLength(10, ErrorMessage = "Max 10 digits")]
        public string PRINCIPALACCOUNTNO { get; set; }
        [Required]
        public char STATUS { get; set; }
        [Required]
        public bool STATUSBOOL { get; set; }
        public string CREATEDBYNAME { get; set; }
        public string CREATEDBYEMAIL { get; set; }
        public DateTime CREATEDDATE { get; set; }
        public string AUTHORIZERNAME { get; set; }
        public string AUTHORIZEREMAIL { get; set; }
        public string UNIQUECORPORATEID { get; set; }
        public DateTime DATEAUTHORIZED { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        public decimal INTERESTRATE { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        public decimal AVAILABLELINEOFCREDIT { get; set; }
        public string CORPORATEID { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        [Required]
        public decimal FEESRATE { get; set; }

        public string accountname { get; set; }
        
    }
}
