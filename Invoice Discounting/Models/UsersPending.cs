using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class UsersPending
    {
		[DataType(DataType.Text)]
		public int ID { get; set; }
		[DataType(DataType.Text)]
		public int USERID { get; set; }
		[DataType(DataType.Text)]
		public string VENDORID { get; set; }
		[DataType(DataType.Text)]
		public string USERNAME { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string EMAIL { get; set; }
		[DataType(DataType.Text)]
		public string FIRSTNAME { get; set; }
		[DataType(DataType.Text)]
		public string LASTNAME { get; set; }
		[DataType(DataType.Text)]
		public int ROLEID { get; set; }
		[DataType(DataType.Text)]
		public string ROLENAME { get; set; }
		[DataType(DataType.Text)]
		public string USERTYPE { get; set; }
		[DataType(DataType.Text)]
		public string USERCLASS { get; set; }
		[DataType(DataType.Text)]
		public int CORPORATECORPID { get; set; }
		[DataType(DataType.Text)]
		public int VENDORCORPID { get; set; }
		[DataType(DataType.Text)]
		public int STATUS { get; set; }
		[DataType(DataType.Text)]
		public int FAILURETRIES { get; set; }
		[DataType(DataType.Text)]
		public char LOCKSTATUS { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime LASTLOCKTIME { get; set; }
		[DataType(DataType.Text)]
		public string HASHEDPASSWORD { get; set; }
		[DataType(DataType.Text)]
		public char ISPASSWORDNEWLYCREATED { get; set; }
		[DataType(DataType.Text)]
		public string INPUTTEREMAIL { get; set; }
		[DataType(DataType.Text)]
		public string INPUTTERNAME { get; set; }
		[DataType(DataType.Text)]
		public string AUTHORIZEREMAIL { get; set; }
		[DataType(DataType.Text)]
		public int AUTHORIZATIONSTATUS { get; set; }
		[DataType(DataType.Text)]
		public string AUTHORIZERCOMMENT { get; set; }
		[DataType(DataType.Text)]
		public string AUTHORIZERNAME { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime CREATEDDATE { get; set; }
		public DateTime? DATEAUTHORIZED { get; set; }
        public string VENDORNAME { get; set; }
        public string CORPORATEUSERSCORP { get; set; }
        public string VENDORUSERSCORP { get; set; }
    }
}
