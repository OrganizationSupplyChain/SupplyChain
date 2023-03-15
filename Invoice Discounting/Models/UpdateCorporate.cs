using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class UpdateCorporate
    {
        public int CORPORATEID { get; set; }
        public string CORPORATENAME { get; set; }
        public string PRINCIPALPHONENO { get; set; }
        public string PRINCIPALEMAIL { get; set; }
        public string PRINCIPALACCOUNTNO { get; set; }
        public char STATUS { get; set; }
        public string CREATEDBYNAME { get; set; }
        public string CREATEDBYEMAIL { get; set; }
        public string UPDATETYPE { get; set; }
        public decimal INTERESTRATE { get; set; }
        public decimal AVAILABLELINEOFCREDIT { get; set; }
        public string UNIQUECORPORATEID { get; set; }
        public decimal FEESRATE { get; set; }
    }
}
