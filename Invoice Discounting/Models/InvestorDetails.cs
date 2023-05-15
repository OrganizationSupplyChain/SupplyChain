using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class InvestorDetails
    {
        public int ID { get; set; }
        public string UNIQUEINVESTORID { get; set; }
        public string userName { get; set; }
        public string hashPassword { get; set; }
        public string CompanyName { get; set; }
        public string AccountNo { get; set; }
        public string AccessAccountNo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        //public List<Investment> Portfolio { get; set; }
        public decimal FundingCapacity { get; set; }
       // public List<Investment> InvestmentHistory { get; set; }
        public string Location { get; set; }
        public string InvestmentPreferences { get; set; } // "Technology", "Real Estate"
        public decimal InterestRate { get; set; }
        //public bool Accredited { get; set; }
        // public string InvestmentStrategy { get; set; } //"Value Investing"
        ///public int InvestmentHorizonInMonths { get; set; }
        public string InvestmentRestrictions { get; set; } //"No Investment in tobacco Companies", "No Investment in Betting"
        public int InvestmentExperienceInYears { get; set; }
        public string BANK { get; set; }
        public string AccountName { get; set; }
        public string AUTHORIZERNAME { get; set; }
        public DateTime DATEAUTHORIZED { get; set; }
        public int AUTHORIZATIONSTATUS { get; set; }
        public bool STATUSBOOL { get; internal set; }
        public string STATUS { get; internal set; }
        public string CREATEDBYNAME { get; internal set; }
        public string CREATEDBYEMAIL { get; internal set; }
        public DateTime DATECREATED { get; internal set; }
        
    }

    public class Investment
    {
        public string CompanyName { get; set; }
        public string InvestmentAmount { get; set; }
        public string InvestmentDate { get; set; }
        public string InvestmentType { get; set; }
        public string Industry { get; set; }     

    }
}
