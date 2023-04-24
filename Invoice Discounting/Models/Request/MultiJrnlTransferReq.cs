using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models.Request
{
    public class MultiJrnlTransferReq
    {
        public string msg_id { get; set; }
        public string channel_code { get; set; }
        public string tran_narration { get; set; }
        public string user_loginid { get; set; }
        public Dataentry[] DataEntries { get; set; }
    }

    public class Dataentry
    {
        public string txn_indicator { get; set; }
        public string txn_accountno { get; set; }
        public string tran_amount { get; set; }
        public string tran_remark { get; set; }
        public string gl_branchcode { get; set; }
        public string gl_ccycode { get; set; }
        public string tran_code { get; set; }
    }



}
