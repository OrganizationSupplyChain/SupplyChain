using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class ADUserValidationDet
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string BranchCode { get; set; }
        public bool CanProceed { get; set; }
    }
}
