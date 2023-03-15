using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class ContractDetails
    {
        public int ID { get; set; }
        public string CONTRACTNUMBER { get; set; }
        public string PONUMBER { get; set; }
        public string CONTRACTNAME { get; set; }
        public string QUALITYSPECIFICATION { get; set; }
        public string DESCRIPTION { get; set; }
        [Range(1, Int32.MaxValue,ErrorMessage = "Payment Tenor must be greater than 1")]
        public int PAYMENTTENOR { get; set; }
        public int TIMELINEDAYS { get; set; }
        public DateTime CREATEDDATE { get; set; }
        public string VENDORNAME { get; set; }
        public string VENDORCATEGORY { get; set; }
        public string VENDOREMAIL { get; set; }
        public string OTHERINFORMATION { get; set; }
        public string REQUIREDDOCUMENTS { get; set; }
        public string CREATEDBYNAME { get; set; }
        public string CREATEDBYEMAIL { get; set; }
        public string LASTMODIFIEDBY { get; set; }
        public DateTime LASTMODIFIEDDATE { get; set; }
        public int CORPORATEID { get; set; }
        public decimal ContractAmount{ get; set; }
    }
}
