using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Models.Response;

namespace Invoice_Discounting.ViewModel
{
    public class CategoryListViewModel
    {
        public CategoryList categoryList { get; set; }
        public IEnumerable<string> Status { get; set; }
    }
}
