using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models.Response
{
	public class ADBranchAuthRes
	{
		public string response_code { get; set; }
		public string response_message { get; set; }
		public Authenticatecbauserresponse[] AuthenticateCBAUserResponse { get; set; }
	}

	public class Authenticatecbauserresponse
	{
		public string user_id { get; set; }
		public string user_name { get; set; }
		public string home_branch { get; set; }
		public string user_email { get; set; }
		public string user_status { get; set; }
	}

}
