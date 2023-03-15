using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class UpdateContract
    {
        public int Id { get; set; }
        public string ContractNumber { get; set; }
        public string PONumber { get; set; }
        public decimal ContractAmount { get; set; }
        public string ContractName { get; set; }
        public string QualitySpecification { get; set; }
        public string Description { get; set; }
        public int PaymentTenor { get; set; }
        public int TimelineDays { get; set; }
        public string VendorName { get; set; }
        public string VendorCategory { get; set; }
        public string VendorEmail { get; set; }
        public string OtherInformation { get; set; }
        public string RequiredDocuments { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedByEmail { get; set; }
        public string LastModifiedBy { get; set; }
        public int CorporateId { get; set; }
    }
}
