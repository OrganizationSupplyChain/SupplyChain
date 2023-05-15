using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class InvestorDetailsPending
    {              
        public int ID { get; set; }
        public string UNIQUEINVESTORID { get; set; }
        public string userName { get; set; }
        public string hashPassword { get; set; }
        public string CompanyName { get; set; }
        public string AccountNo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal FundingCapacity { get; set; }
        public string Location { get; set; }
        public string InvestmentPreferences { get; set; } // "Technology", "Real Estate"
        public decimal InterestRate { get; set; }
        public string InvestmentRestrictions { get; set; } //"No Investment in tobacco Companies", "No Investment in Betting"
        public int InvestmentExperienceInYears { get; set; }
        public string BANK { get; set; }
        public string AUTHORIZERNAME { get; set; }
        public DateTime DATEAUTHORIZED { get; set; }
        public int AUTHORIZATIONSTATUS { get; set; }
        public bool STATUSBOOL { get; internal set; }
        public string STATUS { get; internal set; }
        [DataType(DataType.Text)]
        public string DATECREATED { get; set; }
        [DataType(DataType.Text)]
        public string CREATEDBYNAME { get; set; }
        [DataType(DataType.Text)]
        public string AUTHORIZEREMAIL { get; set; }
        [DataType(DataType.Text)]
        public string AUTHORIZERCOMMENT { get; set; }        
    }


}
