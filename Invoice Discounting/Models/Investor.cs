using System;

namespace Invoice_Discounting.Models
{
    public class Investor
    {
        public int ID { get; set; }
        public string COMPANYNAME { get; set; }
        public string UNIQUEINVESTORID { get; set; }
        public string ACCOUNTNO { get; set; }
        public string PHONENUMBER { get; set; }
        public string EMAIL { get; set; }
        public string LOCATION { get; set; }
        public string BANK { get; set; }
        public string FUNDINGCAPACITY { get; set; }
        public DateTime DATECREATED { get; set; }
        public string CREATEDBYNAME { get; set; }
        public string CREATEDBYEMAIL { get; set; }
        public string STATUS { get; set; }
        public string ACCOUNTNAME { get; set; }
        public string INVESTMENTEXPERIENCEINYEARS { get; set; }
        public string INVESTMENTRESTRICTIONS { get; set; }
        public string INVESTMENTPREFERENCES { get; set; }
        public string INTERESTRATE { get; set; }
        public string AUTHORIZERNAME { get; set; }
        public DateTime DATEAUTHORIZED { get; set; }
    }
}
