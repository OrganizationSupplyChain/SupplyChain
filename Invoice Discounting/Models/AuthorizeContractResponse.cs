using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class AuthorizeContractResponse
    {
        public int Idt { get; set; }
        public string AuthName { get; set; }
        public string AuthEmail { get; set; }
        public string AuthComment { get; set; }
        public string AuthStatus { get; set; }
    }
}
