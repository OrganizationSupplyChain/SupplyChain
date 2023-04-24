using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Invoice_Discounting.Models.Response
{
    public class CategoryList
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string CREATEDBYNAME { get; set; }
        public string CREATEDBYEMAIL { get; set; }
        public DateTime DATECREATED { get; set; }
        public string STATUS { get; set; }
    }
}
