using Invoice_Discounting.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Invoice_Discounting.ViewModel
{
    public class InvestorViewModel : IEnumerable
    {
        [Required(ErrorMessage = "*")]
        public string bankname { get; set; }

        //[Required(ErrorMessage = "Please select a file.")]
        //public IFormFile File { get; set; }
        public List<InvestmentPreferenceList> _investmentPreferenceList;
        public List<InvestmentRestrictionList> _investmentRestrictionList;
        public List<BankList> _banklists;
        public InvestorDetails Investor { get; set; }
        public IEnumerable<string> Status { get; set; }
        public int SelectedInvestmentPreferenceId { get; set; }
        public int SelectedInvestmentRestrictionId { get; set; }       
        public int SelectedBankId { get; set; }
        public bool IsAccessBankAccount { get; set; }

        public IEnumerable<SelectListItem> investmentPreference
        {
            get
            {
                
                if (_investmentPreferenceList != null)
                {
                    var allInvestmentPreference = _investmentPreferenceList.Select(C => new SelectListItem
                    {
                        Value = C.ID.ToString(),
                        Text = C.InvestmentPreferenceName
                    });

                    return DefaultInvestmentPreference.Concat(allInvestmentPreference);
                }

                return null;
            }

        }

        public IEnumerable<SelectListItem> investmentRestriction
        {
            get
            {

                if (_investmentRestrictionList != null)
                {
                    var allInvestmentRestriction = _investmentRestrictionList.Select(C => new SelectListItem
                    {
                        Value = C.ID.ToString(),
                        Text = C.InvestmentRestrictionName
                    });

                    return DefaultInvestmentRestriction.Concat(allInvestmentRestriction);
                }

                return null;
            }

        }

        public IEnumerable<SelectListItem> Bank
        {
            get
            {
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

        public IEnumerable<SelectListItem> DefaultInvestmentPreference
        {
            get
            {
                return Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "Select an InvestmentPreference"
                }, count: 1);
            }
        }

        public IEnumerable<SelectListItem> DefaultInvestmentRestriction
        {
            get
            {
                return Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "Select an InvestmentRestriction"
                }, count: 1);
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

