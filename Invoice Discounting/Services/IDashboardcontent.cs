using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.ViewModel;

namespace Invoice_Discounting.Services
{
    public interface IDashboardcontent
    {

        Task<DashboardViewModel> GetDashboardDetails(string useremailcurrent,string userclass, string usertype,Int32 corporateID, string loggedInAsCorp, string loggedInAsVendor, string uniqueVendorCode);

    }
}
