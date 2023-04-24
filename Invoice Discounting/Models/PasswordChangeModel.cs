using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class PasswordChangeModel
    {
        [Required(ErrorMessage = "*")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "*")]
        public string Username { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "*")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage ="*")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.Text)]
        public string ErrorMsg { get; set; }
    }
}
