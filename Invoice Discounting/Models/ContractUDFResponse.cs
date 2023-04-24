using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class ContractUDFResponse
    {
        public int ID { get; set; }
        public int CONTRACTID { get; set; }
        public int CONTRACTRESPONSEID { get; set; }
        public string TEXTVALUE { get; set; }
        public byte[] UPLOADVALUE { get; set; }
        public string UPLOADFILENAME { get; set; }
        public string RESPONSETYPE { get; set; }
        public DateTime CREATEDDATE { get; set; }
        public string UDFLABEL { get; set; }
    }
}
