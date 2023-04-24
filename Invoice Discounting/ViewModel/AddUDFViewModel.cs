using Invoice_Discounting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Invoice_Discounting.ViewModel
{
    public class AddUDFViewModel
    {
        
        public ContractViewModel Contract { get; set; }
      
        public string UdfLabel { get; set; }
       
        public string UdfType { get; set; }
    }
}
