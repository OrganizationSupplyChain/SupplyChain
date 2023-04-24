using Invoice_Discounting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.ViewModel
{
    public class UserViewModel
    {
        public Users User { get; set; }
        public IEnumerable<string> Status { get; set; }
        public IEnumerable<DropdownModel> roles { get; set; }
        public IEnumerable<DropdownModel> corporates { get; set; }
        public IEnumerable<DropdownTextModel> vendor { get; set; }
        [DataType(DataType.Text)]
        public string password { get; set; }
        public userclass UserClass { get; set; }
        [DataType(DataType.Text)]
        public string UserType { get; set; }
    }
    
    public enum userclass
    {
        VENDOR,
        CORPORATE,
        ACCESSREP
    
    }

    public enum usertype
    {
        INTERNAL,
        EXTERNAL
    }
}
