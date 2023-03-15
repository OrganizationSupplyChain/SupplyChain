using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models.Response
{
	public class QueryUserRes
	{
		public string ResponseCode { get; set; }
		public string UserID { get; set; }
		public string CustomerID { get; set; }
		public string UserName { get; set; }
		public string UserRole { get; set; }
		public string UserStatus { get; set; }
		public string Mobile { get; set; }
		public string Email { get; set; }
		public string Duplicate { get; set; }
	}

}
