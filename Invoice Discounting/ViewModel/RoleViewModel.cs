using Invoice_Discounting.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.ViewModel
{
    public class RoleViewModel
    {
        public IEnumerable<Roles> Roles { get; set; }
        public List<string> RoleNameList { get; set; }
        public List<string> Stat { get; set; }
        public IEnumerable<SelectListItem> Modules { get; set; }
    }
}
