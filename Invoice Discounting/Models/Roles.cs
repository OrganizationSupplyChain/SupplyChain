using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class Roles
    {
		public int ID { get; set; }
		public string ROLENAME { get; set; }
		public string MODULES { get; set; }
		public string CREATORNAME { get; set; }
		public DateTime CREATEDDATE { get; set; }
		public char STATUS { get; set; }
	}
}
