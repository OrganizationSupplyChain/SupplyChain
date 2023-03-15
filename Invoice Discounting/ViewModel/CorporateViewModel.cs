using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Invoice_Discounting.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Invoice_Discounting.ViewModel
{
    public class CorporateViewModel
    {
        [Required(ErrorMessage = "Please select a file.")]
        public IFormFile File { get; set; }
        public CorporateDetails Corporate { get; set; }
        public IEnumerable<string> Status { get; set; }
    }
}
