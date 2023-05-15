using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class AuthorizeInvestor
    {
        public int Idt { get; set; }
        public string AuthName { get; set; }
        public string AuthEmail { get; set; }
        public string AuthComment { get; set; }
        public int AuthStatus { get; set; }
    }
}
