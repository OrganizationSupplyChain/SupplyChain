using Invoice_Discounting.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.ViewModel
{
    public class RecourseFactorinViewModel
    {
        public RecourseFactoring RecourseFDetails { get; set; }
        public CorporateLoan CorporateLoanDetails { get; set; }
        public IEnumerable<DropdownTextModel> InvoiceList { get; set; }
        [DataType(DataType.Text)]
        public decimal CorporateAvailableLimit { get; set; }
        [DataType(DataType.Text)]
        [Required]
        public string totalamount { get; set; }
        public string ContractNumber { get; set; }
        public string ContractName { get; set; }
        public string InvoiceAmount { get; set; }
        public string DisbursementDate { get; set; }
    }
}
