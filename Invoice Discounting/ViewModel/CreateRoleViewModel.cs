using Invoice_Discounting.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoice_Discounting.ViewModel
{
    public class CreateRoleViewModel
    {
        public Roles Role { get; set; }
        public List<string> Stat { get; set; }
        public List<string> Modules { get; set; }
        [DataType(DataType.Text)]
        public string RoleStatus { get; set; }
    }
}
