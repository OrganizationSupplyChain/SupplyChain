using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models.Response
{
    public class AuthorizeBulkCorporate
    {
        public int Idt { get; set; }
        public string AuthName { get; set; }
        public string AuthEmail { get; set; }
        public string AuthComment { get; set; }
        public int AuthStatus { get; set; }
    }
}
