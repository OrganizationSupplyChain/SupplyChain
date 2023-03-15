using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
	public class ADAuthModel
	{
		public string ErrorMessage { get; set; }
		public UserPrincipal UserDetails { get; set; }
	}
}
