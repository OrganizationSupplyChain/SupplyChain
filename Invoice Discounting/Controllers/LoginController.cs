using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Models;
using Invoice_Discounting.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static Invoice_Discounting.Utility.Enums;

namespace Invoice_Discounting.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        private IRepository _repository;
        private IDatabaseCalls _databaseCalls;
        public LoginController(IConfiguration config, IRepository repository, IDatabaseCalls databaseCalls)
        {
            _config = config;
            _repository = repository;
            _databaseCalls = databaseCalls;
        }
        public IActionResult Index(string errorMsg = "")
        {
            HttpContext.Session.Clear();
            LoginModel model = new LoginModel();
            model.ErrorMsg = errorMsg;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index([Bind("UserName,Password,LoggedInAs")] LoginModel model)
        {
            //**********Comment after test
            //HttpContext.Session.SetString("UserName", "Olamide Adekoya");
            //HttpContext.Session.SetString("UserEmail", "JJ@GMAIL.COM");

            //return RedirectToAction("Index", "User");
            //*********End comment
            if (!ModelState.IsValid)
            {
                string msg = "Kindly fill all required fields";
                return RedirectToAction("Index", new { errorMsg = msg });
            }
            if (model == null)
            {
                string msg = "Kindly fill all required fields";
                return RedirectToAction("Index", new { errorMsg = msg });
            }
            Users userDetails = _repository.GetUserDet(model.UserName);
            //Get Vendor Details with corporateID
           // var vendordetails = _repository.GetVendorbyCorporateId(userDetails.CORPORATEID.ToString());
            HttpContext.Session.SetString("UserLogon", model.UserName);

            if (userDetails == null)
            {
                //User does not exist or is disabled
                return RedirectToAction("Index", new { errorMsg = "Invalid username or password." });
            }

            if (userDetails.USERTYPE != null)
            {
                HttpContext.Session.SetString("UserType", userDetails.USERTYPE);
            }
            if (userDetails.USERCLASS != null)
            {
                HttpContext.Session.SetString("UserClass", userDetails.USERCLASS);
            }
           
            //check if the users account is lock
            if (userDetails.LOCKSTATUS == '1')
            {
                return RedirectToAction("Index", new { errorMsg = "User's Account is locked. Please try again in 5 minutes" });
            }
            //if (userDetails.DEVICESTATUS == '1')
            //{
            //    return RedirectToAction("Index", new { errorMsg = "User is currently Logged On. Kindly Log out on the previous Device" });
            //}
            //For external users validate the corporate and vendor mapped to the user is enabled
            int corporateId = 0;
            bool loggedInAsVendor = model.LoggedInAs == "Vendor" ? true : false;

            if (userDetails.USERCLASS == UserClass.CORPORATE.ToString())
            {
                corporateId = userDetails.CORPORATECORPID;
            }
            else if (userDetails.USERCLASS == UserClass.VENDOR.ToString())
            {
                corporateId = userDetails.VENDORCORPID;
            }
            else if (userDetails.USERCLASS == UserClass.VENDORCORPORATE.ToString())
            {
                // if logged in as vendor, pick vendor corporateId else pick corporate corpId 
                corporateId = loggedInAsVendor ? userDetails.VENDORCORPID : userDetails.CORPORATECORPID;
                if (loggedInAsVendor)
                {
                    HttpContext.Session.SetString("LoggedInAsVendor", "1");
                }
                else
                {
                    HttpContext.Session.SetString("LoggedInAsCorporate", "1");
                }
            }

            if (userDetails.USERTYPE == UserType.EXTERNAL.ToString())
            {
                if (userDetails.USERCLASS == UserClass.CORPORATE.ToString() || userDetails.USERCLASS == UserClass.VENDOR.ToString() || userDetails.USERCLASS == UserClass.VENDORCORPORATE.ToString())
                {
                    
                    var isCorporateEnabled = _repository.IsCorporateEnabled(corporateId);
                    if(!isCorporateEnabled)
                    {
                        return RedirectToAction("Index", new { errorMsg = "User's Corporate is disabled. Kindly contact the administrator" });
                    }

                    // if user type is vendor or vendorCorporate, validate mapped vendor is enabled
                    if (userDetails.USERCLASS == UserClass.VENDOR.ToString() || (userDetails.USERCLASS == UserClass.VENDORCORPORATE.ToString() && loggedInAsVendor))
                    {
                        var isvendorEnabled = _repository.IsVendorEnabled(userDetails.VENDORID);
                        if (!isvendorEnabled  &&  loggedInAsVendor )
                        {
                            return RedirectToAction("Index", new { errorMsg = "The User has no Vendor Mapped to it" });
                            //return RedirectToAction("Index", new { errorMsg = "User's Vendor is disabled. Kindly contact the administrator" });
                        }
                        HttpContext.Session.SetString("VendorId", userDetails.VENDORID);
                    }
                        
                }
            }
            
            //Authenticate user based on their user type
            var authenticated = _repository.AuthenticateUser(model.UserName, model.Password, userDetails);
            //var authenticated = true;
            if (authenticated)//Successfully authenticated
            {
                string fullName = $"{userDetails.FIRSTNAME} {userDetails.LASTNAME}";
                HttpContext.Session.SetString("UserName", fullName);
                HttpContext.Session.SetString("UserClass", userDetails.USERCLASS);
                HttpContext.Session.SetString("UserEmail", userDetails.EMAIL);
                HttpContext.Session.SetInt32("corporateId", corporateId);
                HttpContext.Session.SetInt32("RoleId", userDetails.ROLEID);

                //HttpContext.Session.SetString("RoleName", userDetails.ROLENAME);
                bool sessionSet = SetSessionByRole(userDetails.ROLEID);
                if (!sessionSet)
                {
                    string msg1 = "Invalid user role. Kindly contact administrator.";
                    return RedirectToAction("Index", new { errorMsg = msg1 });
                }
                
                //Update last login date
                bool updated = _repository.UpdateLastLoginDate(model.UserName);
                if(userDetails.USERCLASS == UserClass.CORPORATE.ToString() || userDetails.USERCLASS == UserClass.VENDOR.ToString() || userDetails.USERCLASS == UserClass.VENDORCORPORATE.ToString())
                {
                    if(userDetails.ISPASSWORDNEWLYCREATED == '1')
                    {
                        //Change password
                        PasswordChangeModel pcModel = new PasswordChangeModel()
                        {
                            UserId = userDetails.ID,
                            Username = userDetails.USERNAME,
                            Password = model.Password
                        };
                        return View("PasswordChange", pcModel);
                    }
                }
               
                string roleModules = HttpContext.Session.GetString("RoleModule");
                string[] route = _repository.GetLandingPage(roleModules);

                List<string> resourceroute = _repository.GetLandingPages(roleModules);
                string userResources = string.Join(",",resourceroute);
                HttpContext.Session.SetString("ResourceRoleModule", userResources);

                if (route == null)
                {
                    string msg1 = "No module set for user. Kindly contact administrator.";
                    return RedirectToAction("Index", new { errorMsg = msg1 });
                }
                else if (route[0] == null || route[1] == null)
                {
                    string msg1 = "No module set for user. Kindly contact administrator.";
                    return RedirectToAction("Index", new { errorMsg = msg1 });
                }
                else
                {
                    //Update Successful Logon and lock to a device.....
                   // bool updateLogon = _databaseCalls.UpdateLogonStatus(userDetails.ID);
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            else
            {
                bool updateFailuTries = _databaseCalls.UpdateFailureTries(userDetails.ID);
                return RedirectToAction("Index", new { errorMsg = "Invalid username or password." });
            }

        }

        [HttpPost]
        public IActionResult ChangePassword([Bind("UserId,NewPassword,ConfirmPassword")] PasswordChangeModel model)
        {
            if(model.UserId == 0)
            {
                return RedirectToAction("Index", new { errorMsg = "Unable to change pasword" });
            }

            if(model.NewPassword != model.ConfirmPassword)
            {
                model.ConfirmPassword = "";
                model.ErrorMsg = "New password and confirm passwords do not match.";
                return View(model);
            }

            var passwordUpdated = _repository.ChangePassword(model);
            if(passwordUpdated)
            {
                return View("PasswordChangeSuccess");
            }
            else
            {
                return RedirectToAction("Index", new { errorMsg = "Unable to change password" });
            }
           
        }

        [HttpPost]
        public IActionResult ChangePasswordSuccess()
        {
            return RedirectToAction("Index", "Dashboard");
        }
        public bool SetSessionByRole(int roleId)
        {
            try
            {
                if (roleId == 0)
                {
                    return false;
                }
                var roleDet = _repository.GetRoleById(roleId);

                if(roleDet == null)
                {
                    return false;
                }
                HttpContext.Session.SetString("UserRole", roleDet.ROLENAME);
                HttpContext.Session.SetString("RoleModule", roleDet.MODULES);
                string[] modules = roleDet.MODULES.Split(',');
                var allModules = _databaseCalls.GetModules().Select(x=>x.MODULENAME).ToList();
                foreach (var m in allModules)
                {
                    if (modules.Contains(m))
                    {
                        HttpContext.Session.SetInt32(m, 1);
                    }
                    else
                    {
                        HttpContext.Session.SetInt32(m, 0);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IActionResult GetUserClassByUsername(string username)
        {
            Users userDetails = _repository.GetUserDet(username);
            if (userDetails == null)
            {
                return Json(null);
            }
            else
            {
                return Json(userDetails.USERCLASS);
            }
        }
    }
}
