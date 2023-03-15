using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Models;

namespace Invoice_Discounting.ViewModel
{
    public class UserPendingApproveModel
    {
        public IEnumerable<Users> userapproved { get; set; }

        public IEnumerable<UsersPending> userpending { get; set; }

    }
}
