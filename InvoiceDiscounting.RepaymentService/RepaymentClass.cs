using Invoice_Discounting.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceDiscounting.RepaymentService
{
    public class RepaymentClass
    {
        private readonly IRepository repo;
        public RepaymentClass(IRepository repository)
        {
            repo = repository;
        }

        public void ProcessRepayments()
        {
            //process invoce discounting repayment
            repo.ProcessInvoiceDiscountingRepayment();

            //process reverse factoring repayment
            repo.ProcessInvoiceDiscountingRepayment();
        }

    }
}
