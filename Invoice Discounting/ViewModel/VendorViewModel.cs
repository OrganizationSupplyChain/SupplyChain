using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Models;
using Invoice_Discounting.Models.Response;
using Invoice_Discounting.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Invoice_Discounting.ViewModel
{
    public class VendorViewModel : IEnumerable
    {
        [Required(ErrorMessage = "*")]
        public string bankname { get; set; }

        [Required(ErrorMessage = "Please select a file.")]
        public IFormFile File { get; set; }
        public List<CategoryList> _cateorylist;
        public List<BankList> _banklists;
        public byte[] vendorbulk { get; set;}
        public VendorDetails Vendor { get; set; }
        public IEnumerable<string> Status { get; set; }

        public int SelectedCategoryId { get; set; }
        public int SelectedBankId{ get; set; }

        public IEnumerable<SelectListItem> Bank
        {
            get
            {
                //return new SelectList(_cateorylist, "ID", "CategoryName");
                if (_banklists != null)
                {
                    var allBanks = _banklists.Select(C => new SelectListItem
                    {
                        Value = C.ID.ToString(),
                        Text = C.BankName
                    });

                    return DefaultBank.Concat(allBanks);
                }

                return null;
            }

        }

        public IEnumerable<SelectListItem> DefaultBank
        {
            get
            {
                return Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "Select a Bank"
                }, count: 1);
            }
        }
        public IEnumerable<SelectListItem> Category
        {
            get
            {
                //return new SelectList(_cateorylist, "ID", "CategoryName");
                if (_cateorylist != null)
                {
                    var allCategory = _cateorylist.Select(C=>new SelectListItem
                    {
                        Value = C.ID.ToString(),
                        Text = C.CategoryName
                    });

                    return DefaultCategory.Concat(allCategory);
                }

                return null;
            }
            
        }

        public IEnumerable<SelectListItem> DefaultCategory
        {
            get
            {
                return Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "Select a Category"
                }, count: 1);
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
