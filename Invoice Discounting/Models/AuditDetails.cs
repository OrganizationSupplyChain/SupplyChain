using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class AuditDetails
    {
       // public int ID { set; get; }
        public string USERNAME { set; get; }
        public string ACTIVITIES { set; get; }
        public DateTime DATECREATED { set; get; }
    }
}
