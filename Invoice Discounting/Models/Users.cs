using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
	public class Users
	{
        public int ID { get; set; }
        [Required]
		public string USERNAME { get; set; }
		[Required]
		[EmailAddress]
		public string EMAIL { get; set; }
		[DataType(DataType.Text)]
		public string FIRSTNAME { get; set; }
		[DataType(DataType.Text)]
		public string LASTNAME { get; set; }
		[BindRequired]
		public int ROLEID { get; set; }
		[DataType(DataType.Text)]
		public string ROLENAME { get; set; }
		public string USERTYPE { get; set; }
		public string USERCLASS { get; set; }
		public int CORPORATECORPID { get; set; }
		public int VENDORCORPID { get; set; }
		[BindRequired]
		public int STATUS { get; set; }
		public int FAILURETRIES { get; set; }
		[DataType(DataType.PhoneNumber)]
		public char LOCKSTATUS { get; set; }
		public char DEVICESTATUS { get; set; }
		public DateTime LASTLOCKTIME { get; set; }
		public string HASHEDPASSWORD { get; set; }
		public char ISPASSWORDNEWLYCREATED { get; set; }
		[DataType(DataType.Text)] 
		public string INPUTTEREMAIL { get; set; }
		[DataType(DataType.Text)] 
		public string INPUTTERNAME { get; set; }
		[DataType(DataType.Text)]
		public string AUTHORIZEREMAIL { get; set; }
		[DataType(DataType.Text)]
		public string AUTHORIZERNAME { get; set; }
		public DateTime CREATEDDATE { get; set; }
		public DateTime? LASTLOGINDATE { get; set; }
		public DateTime? LASTUPDATETIME { get; set; }
		public DateTime? DATEAUTHORIZED { get; set; }
		[DataType(DataType.Text)]
		public string VENDORID { get; set; }
		public string VENDORNAME { get; set; }
		public string CORPORATEUSERSCORP { get; set; }
		public string VENDORUSERSCORP { get; set; }
		public string INVESTORID { get; set; }
	}
}
