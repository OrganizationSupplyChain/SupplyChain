using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models.Request
{
	public class TokenAuthReq
	{
		public string UserId { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string GroupName { get; set; }
	}

}
