using Invoice_Discounting.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.ViewModel
{
    public class InvoiceViewModel
    {
      
        public ContractInvoice InvoiceDetails { get; set; }
        public InvoiceLoan LoanDetails { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public bool requestdiscounting { get; set; }
        [Display(Name = "Accept Loan Term")]
        public bool acceptLoanTerms { get; set; }
        [DataType(DataType.Text)]
        public decimal InterestRate { get; set; }
        [DataType(DataType.Text)]
        public decimal FeesRate { get; set; }
        [DataType(DataType.Text)]
        public string TermsAndConditions { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "*")]
        public string totalexcludingvat { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "*")]
        public string totalincludingvat { get; set; }
        [DataType(DataType.Text)]
        public IEnumerable<string> Banks { get; set; }
        public IFormFile SupportingDocument1 { get; set; }
        public IFormFile SupportingDocument2 { get; set; }

        public InvoiceViewModel()
        {
            Items = new List<InvoiceItem>();
        }
    }
}
