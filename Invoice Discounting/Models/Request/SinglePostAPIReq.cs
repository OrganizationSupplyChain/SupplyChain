using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models.Request
{
    public class SinglePostAPIReq
    {
		public string msgId { get; set; }
		public string debitAccountNumber { get; set; }
		public string debitAccountType { get; set; }
		public string debitAccountCCY { get; set; }
		public string debitAccountBranch { get; set; }
		public string creditAccountNumber { get; set; }
		public string creditAccountType { get; set; }
		public string creditAccountCCY { get; set; }
		public string creditAccountBranch { get; set; }
		public string narration { get; set; }
		public string currencyCode { get; set; }
		public string moduleName { get; set; }
		public string requestTime { get; set; }
		public string amount { get; set; }
	}
}
