using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class PaymentDetails
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Msgid { get; set; }
        public string Paymentreference { get; set; }
        public string Invoiceno { get; set; }
        public string Responsecode { get; set; }
        public string Responsemsg { get; set; }
        public string Paymenttype { get; set; }
        public string Requestjson { get; set; }
        public DateTime? Paymentdate { get; set; }
        public decimal Interest { get; set; }
    }
}
