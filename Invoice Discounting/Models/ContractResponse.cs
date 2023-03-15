using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class ContractResponse
    {
        public int ID { get; set; }
        public int CONTRACTID { get; set; }
        public byte[] SUPPORTINGDOCUMENT1 { get; set; }
        public byte[] SUPPORTINGDOCUMENT2 { get; set; }
        public string SUPPORTINGDOC1FILENAME { get; set; }
        public string SUPPORTINGDOC2FILENAME { get; set; }
        public string VENDORCOMMENT { get; set; }
        public string RESPONSESTATUS { get; set; }
        public string VENDORNAME { get; set; }
        public string VENDOREMAIL { get; set; }
        public DateTime DATECREATED { get; set; }
        public string AUTHORIZERNAME { get; set; }
        public string AUTHORIZEREMAIL { get; set; }
        public string AUTHORIZERCOMMENT { get; set; }
        public DateTime DATEAUTHORIZED { get; set; }
    }
}
