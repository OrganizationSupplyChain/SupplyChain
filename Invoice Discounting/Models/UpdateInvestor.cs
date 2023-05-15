using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class UpdateInvestor
    {
        public int IDT { get; set; }
        public string UNIQUEINVESTORID { get; set; }
        public string CompanyName { get; set; }
        public string userName { get; set; }
        public string hashPassword { get; set; }
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
        public string AccountName { get; set; }
        public DateTime DATECREATED { get; set; }
        public int STATUS { get; set; }
        public string CREATEDBYNAME { get; set; }
        public string CREATEDBYEMAIL { get; set; }
        public string UPDATETYPE { get; set; }
        public string AUTHORIZERCOMMENT { get; set; }
        public string AUTHORIZEREMAIL { get; set; }
        public string AUTHORIZERNAME { get; set; }
       
    }
}
