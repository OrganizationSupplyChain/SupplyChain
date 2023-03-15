using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class UDFResponse
    {
        public UDFDetails UdfDetails { get; set; }
        public IFormFile SupportingDoc { get; set; }
        public string TextValue { get; set; }
    }
}
