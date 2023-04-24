using Invoice_Discounting.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.ViewModel
{
    public class ContractResponseViewModel
    {
        [DataType(DataType.Text)]
        public ContractDetails ContractDetails { get; set; }
        [DataType(DataType.Text)]
        public ContractResponse ContractResponse { get; set; }
        [DataType(DataType.Text)]
        public List<UDFResponse> UdfDetails { get; set; }
        
        public IFormFile SupportingDocument1 { get; set; }
        public IFormFile SupportingDocument2 { get; set; }
    }
}
