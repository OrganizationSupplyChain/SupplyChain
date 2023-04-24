using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Models;

namespace Invoice_Discounting.ViewModel
{
    public class DashboardViewModel
    {
        public decimal transactionamt{ get; set; }
        public int completedInvoice{ get; set; }
        public int pendingInvoice{ get; set; }
        public int rejectedInvoice{ get; set; }
        public int totalConfirminvoices{ get; set; }
        public int totalcontract { get; set; }
        public int invitationtotender { get; set; }
        public int allCorporate { get; set; }
        public int registeredVendor { get; set; }
        public List<notification> generalnotification { get; set; }
        public string Inprogress { get; set; }
        public string awarded { get; set; }

    }
}
