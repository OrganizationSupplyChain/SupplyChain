using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Models;
using Invoice_Discounting.Services;
using Invoice_Discounting.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_Discounting.Controllers
{
    public class ContractBidsController : Controller
    {
        private readonly IRepository repo;
        private readonly IDatabaseCalls dbCall;

        public ContractBidsController(IRepository repository, IDatabaseCalls databaseCalls)
        {
            repo = repository;
            dbCall = databaseCalls;
        }        

        public IActionResult Index()
        {
            var vendorEmail = string.Empty;
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Index", "Login", new { errorMsg = "Session Timeout" });
            }
            // Validate logged in user, if Vendor only display user's bid else if corporate, display all bids for the contract
            string userClass = HttpContext.Session.GetString("UserClass");
            bool LoggedInAsCorporate = HttpContext.Session.GetString("LoggedInAsCorporate") == "1" ? true : false;
            if (userClass == Enums.UserClass.VENDOR.ToString() || (userClass == Enums.UserClass.VENDORCORPORATE.ToString() && !LoggedInAsCorporate))
            {
                // return only vendor bid
                // Get vendor ID mapped to the vendor user
                string vendorId = HttpContext.Session.GetString("VendorId");
                // fetch vendor email
               // VendorDetails vendorDetails = dbCall.GetApprovedVendors().Where(x => x.UNIQUEVENDORID == vendorId).FirstOrDefault();
                vendorEmail = HttpContext.Session.GetString("UserEmail");  //vendorDetails != null ? $"'{vendorDetails.EMAIL}'" : "''";
            }
            else
            {
                // Corporate, display all bid for the contract
                int corporateId = (int)HttpContext.Session.GetInt32("corporateId");
                //Use the corporate id to get the email address of the vendors and then get the 
                // email to use to the vendor bids
                var ListvendorEmail = dbCall.GetVendorEmailByContractId(corporateId);
                //concatenate the email if more than one
                vendorEmail = string.Format("'{0}'", string.Join("','", ListvendorEmail)); // string.Join(',', ListvendorEmail);
            }

            var model = dbCall.GetContractbidsbyVendorEmail(vendorEmail);
            return View("Index", model);
        }

    }
}
