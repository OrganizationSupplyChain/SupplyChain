using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models.Response
{
    public class SinglePostAPIRes
    {
		public string responseCode { get; set; }
		public string responseMessage { get; set; }
		public string transactionReference { get; set; }
		public string institutionReference { get; set; }
		public string processingTime { get; set; }
		public string responseTime { get; set; }
	}
}
