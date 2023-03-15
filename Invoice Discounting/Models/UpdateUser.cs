using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class UpdateUser
    {
        public int IDT { get; set; }
        public int USERID { get; set; }
        public string USERNAME { get; set; }
		public string EMAIL { get; set; }
		public string FIRSTNAME { get; set; }
		public string LASTNAME { get; set; }
		public int ROLEID { get; set; }
		public string ROLENAME { get; set; }
		public string USERTYPE { get; set; }
		public string USERCLASS { get; set; }
		public int CORPORATECORPID { get; set; }
		public int VENDORCORPID { get; set; }
		public int STATUS { get; set; }
		public string HASHEDPASSWORD { get; set; }
		public string INPUTTEREMAIL { get; set; }
		public string INPUTTERNAME { get; set; }
		public string UPDATETYPE { get; set; }
		public string VENDORID { get; set; }
	}
}
