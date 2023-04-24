using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class InvoiceItem
    {
        public int ID { get; set; }
        public int INVOICEID { get; set; }
        public decimal UNITPRICE { get; set; }
        public int QUANTITY { get; set; }
        public string DESCRIPTION { get; set; }
    }
}
