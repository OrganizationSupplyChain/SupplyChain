using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Invoice_Discounting.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Invoice_Discounting.Controllers
{
    public class DashboardController : BaseController
    {
        //private Timer timer;
        private readonly IDashboardcontent _dashboardcontent;
        private readonly IConfiguration _config;

        public DashboardController(IDashboardcontent dashboardcontent, IConfiguration config)
        {
            
            _dashboardcontent = dashboardcontent;
            _config = config;
        }

		public async Task<ActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Index", "Login", new { errorMsg = "Session Timeout" });
            }
            string userclass = HttpContext.Session.GetString("UserClass");
            string usertype = HttpContext.Session.GetString("UserType");
            var currentuseremail = HttpContext.Session.GetString("UserEmail");
            int corporateID = (int) HttpContext.Session.GetInt32("corporateId");
            string loggedInAsCorp = HttpContext.Session.GetString("LoggedInAsCorporate");
            string loggedInAsVendor = HttpContext.Session.GetString("LoggedInAsVendor");
            string uniqueVendorCode = HttpContext.Session.GetString("VendorId");
            var model = await _dashboardcontent.GetDashboardDetails(currentuseremail,userclass,usertype,corporateID,loggedInAsCorp,loggedInAsVendor, uniqueVendorCode);

            return View(model);
        }
	}
}
