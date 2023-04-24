using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class VendorContractListModel
    {
        [DataType(DataType.Text)]
        public decimal CONTRACTAMOUNT { get; set; }
        [DataType(DataType.Text)]
        public int ID { get; set; }
        [DataType(DataType.Text)]
        public string CONTRACTNUMBER { get; set; }
        [DataType(DataType.Text)]
        public string PONUMBER { get; set; }
        [DataType(DataType.Text)]
        public string CONTRACTNAME { get; set; }
        [DataType(DataType.Text)]
        public string QUALITYSPECIFICATION { get; set; }
        [DataType(DataType.Text)]
        public string DESCRIPTION { get; set; }
        [DataType(DataType.Text)]
        public int PAYMENTTENOR { get; set; }
        [DataType(DataType.Text)]
        public int TIMELINEDAYS { get; set; }
        [DataType(DataType.Text)]
        public DateTime CREATEDDATE { get; set; }
        [DataType(DataType.Text)]
        public string VENDORNAME { get; set; }
        [DataType(DataType.Text)]
        public string VENDORCATEGORY { get; set; }
        [DataType(DataType.Text)]
        public string VENDOREMAIL { get; set; }
        [DataType(DataType.Text)]
        public string OTHERINFORMATION { get; set; }
        [DataType(DataType.Text)]
        public string REQUIREDDOCUMENTS { get; set; }
        [DataType(DataType.Text)]
        public string CREATEDBYNAME { get; set; }
        [DataType(DataType.Text)]
        public string CREATEDBYEMAIL { get; set; }
        [DataType(DataType.Text)]
        public string LASTMODIFIEDBY { get; set; }
        [DataType(DataType.Text)]
        public DateTime LASTMODIFIEDDATE { get; set; }
        [DataType(DataType.Text)]
        public int CORPORATEID { get; set; }
        [DataType(DataType.Text)]
        public string NAMEOFITEM { get; set; }
        [DataType(DataType.Text)]
        public string CORPORATENAME { get; set; }
        [DataType(DataType.Text)]
        public string CONTRACTSTATUS { get; set; }
        [DataType(DataType.Text)]
        public int? RESPONSEID { get; set; }
        [DataType(DataType.Text)]
        public string AWARDVENDORNAME { get; set; }
    }
}
