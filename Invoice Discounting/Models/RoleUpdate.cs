using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class RoleUpdate
    {
		public int RoleId { get; set; }
		public string Name { get; set; }
		public string RoleModules { get; set; }
		public char RoleStatus { get; set; }
		public string InitiatorName { get; set; }
		public string InitiatorEmail { get; set; }
	}
}
