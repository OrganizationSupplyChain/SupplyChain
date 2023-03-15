using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
	public class LoginModel
	{
		[Required(ErrorMessage ="*")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "*")]
		public string Password { get; set; }
		[DataType(DataType.Text)]
		public string LoggedInAs { get; set; }
		[MaxLength(100)]
		[BindRequired]
		public string ErrorMsg { get; set; }
	}
}
