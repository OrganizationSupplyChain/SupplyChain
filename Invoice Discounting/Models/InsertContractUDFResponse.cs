using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class InsertContractUDFResponse
    {
        public int CONTRACTID { get; set; }
        public long CONTRACTRESPONSEID { get; set; }
        public string TEXTVALUE { get; set; }
        public byte[] UPLOADVALUE { get; set; }
        public string UPLOADFILENAME { get; set; }
        public string RESPONSETYPE { get; set; }
        public string UDFLABEL { get; set; }
    }
}
