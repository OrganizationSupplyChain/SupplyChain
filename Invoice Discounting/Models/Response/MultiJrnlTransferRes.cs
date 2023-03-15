using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models.Response
{
    public class MultiJrnlTransferRes
    {
        public string response_code { get; set; }
        public string response_message { get; set; }
        public string response_time { get; set; }
        public string transaction_reference { get; set; }
        public string institution_reference { get; set; }
        public string flex_reply_code { get; set; }
        public string flex_reply_msg { get; set; }
    }

}
