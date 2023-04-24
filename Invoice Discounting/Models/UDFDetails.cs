using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class UDFDetails
    {
        public int ID { get; set; }
        public string UDFLABEL { get; set; }
        public string UDFTYPE { get; set; }
        public string CREATORNAME { get; set; }
        public string CREATOREMAIL { get; set; }
        public char ISDELETED { get; set; }
        public int CONTRACTID { get; set; }
    }
}
