using Invoice_Discounting.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.ViewModel
{
    public class ContractViewModel
    {
        [DataType(DataType.Text)]
        public ContractDetails Contract { get; set; }
        [DataType(DataType.Text)]
        public IEnumerable<DropdownTextModel> VendorCategory { get; set; }
        [DataType(DataType.Text)]
        public List<UDFDetails> UdfDetails { get; set; }
        [DataType(DataType.Text)]
        public string UpdateType { get; set; }
    }
}

