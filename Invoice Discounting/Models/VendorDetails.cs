using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    [Serializable]
    public class VendorDetails
    {
        public int ID { get; set; }
        [Required]
        public string CATEGORY { get; set; }
        [Required]
        public string NAME { get; set; }
        [Required]
        public string PHONENO { get; set; }
        [Required]
        public string EMAIL { get; set; }
        [Required]
        public string ACCOUNTNO { get; set; }
        public string accountname { get; set; }
        
        [Required]
        public string ADDRESS { get; set; }
        [Required]
        public string BANK { get; set; }
        [Required(ErrorMessage = "TIN/RC is a required Field")]
        public string TIN_RC { get; set; }

        public string SERVICENATURE { get; set; } 
        public DateTime DATECREATED { get; set; }
        public string CREATEDBYNAME { get; set; }
        public string CREATEDBYEMAIL { get; set; }
        //public DateTime CREATEDDATE { get; set; }
        public string STATUS { get; set; }
        public bool STATUSBOOL { get; set; }
        public string AUTHORIZERNAME { get; set; }
        public DateTime DATEAUTHORIZED { get; set; }
        public int AUTHORIZATIONSTATUS { get; set; }
        public string UNIQUEVENDORID { get; set; }
        public int CORPORATEID { get; set; }
    }
}
