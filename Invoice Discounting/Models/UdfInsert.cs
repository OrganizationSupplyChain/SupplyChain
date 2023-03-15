using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class UdfInsert
    {
        
        public string UdfLabel{ get; set; }
        public string UdfType { get; set; }
        public string CreatorName { get; set; }
        public string CreatorEmail { get; set; }
        public int ContractId { get; set; }
    }
}
