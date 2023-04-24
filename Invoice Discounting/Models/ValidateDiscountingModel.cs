using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class ValidateDiscountingModel
    {
        public string AccountName { get; set; }
        public decimal EligibleAmount { get; set; }
        public decimal Interest { get; set; }
        public decimal Fees { get; set; }
    }
}
