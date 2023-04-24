using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class UpdateVendor
    {
        public int IDT { get; set; }
        public string CATEGORY { get; set; }
        public string UNIQUEVENDORID { get; set; }
        public string NAME { get; set; }
        public string PHONENO { get; set; }
        public string EMAIL { get; set; }
        public string ACCOUNTNO { get; set; }
        public string ADDRESS { get; set; }
        public string BANK { get; set; }
        public string TIN_RC { get; set; }
        public string SERVICENATURE { get; set; }
        public DateTime DATECREATED { get; set; }
        public int STATUS { get; set; }
        public string CREATEDBYNAME { get; set; }
        public string CREATEDBYEMAIL { get; set; }
        public string UPDATETYPE { get; set; }
        public string AUTHORIZERCOMMENT { get; set; }
        public string AUTHORIZEREMAIL { get; set; }
        public string AUTHORIZERNAME { get; set; }
        public int CORPORATEID { get; set; }

    }
}
