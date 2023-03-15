using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class InsertContractResponse
    {
        public int CONTRACTID { get; set; }
        public byte[] SUPPORTINGDOCUMENT1 { get; set; }
        public byte[] SUPPORTINGDOCUMENT2 { get; set; }
        public string SUPPORTINGDOC1FILENAME { get; set; }
        public string SUPPORTINGDOC2FILENAME { get; set; }
        public string VENDORCOMMENT { get; set; }
        public string VENDORNAME { get; set; }
        public string VENDOREMAIL { get; set; }
        public string CONTRACTSTATUS { get; set; }
        public decimal CONTRACTAMOUNT { get; set; }
    }
}
