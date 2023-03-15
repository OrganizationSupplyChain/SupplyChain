using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models.Request
{
	public class SendMailReq
	{
		public string From { get; set; }
		public string Recipient { get; set; }
		public string Subject { get; set; }
		public string Content { get; set; }
		public bool DisplayAsHtml { get; set; }
		public string DisplayName { get; set; }
		public string CopyAddress { get; set; }
		public string attachment { get; set; }
	}

}
