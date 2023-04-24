using System;
using System.Collections.Generic;
using System.Linq;
using Invoice_Discounting.Models;
using Invoice_Discounting.Services;
using Invoice_Discounting.Utility;
using Invoice_Discounting.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using static Invoice_Discounting.Utility.Enums;
using Newtonsoft.Json;

namespace Invoice_Discounting.Controllers
{
    public class UserController : BaseController
    {
        private readonly IConfiguration _config;
        private readonly IRepository _repo;
        private readonly IDatabaseCalls _dbCall;

        public UserController(IConfiguration config, IRepository repository, IDatabaseCalls databaseCalls)
        {
            _config = config;
            _repo = repository;
            _dbCall = databaseCalls;
        }
        public IActionResult Index()
        {
            var currentuseremail = HttpContext.Session.GetString("UserEmail");
            if (currentuseremail == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var currentUserClass = HttpContext.Session.GetString("UserClass");
          
            var currentUserCorporateId = (int)HttpContext.Session.GetInt32("corporateId");
            int roleId = (int)HttpContext.Session.GetInt32("RoleId");

            var model = _repo.GetUserViewModel(currentuseremail, currentUserClass, currentUserCorporateId, roleId, currentUserCorporateId);

            return View(model);
        }

        public ActionResult ModifyUser(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Index", "Login", new { errorMsg = "Session Timeout" });
            }

            int roleId = (int)HttpContext.Session.GetInt32("RoleId");
            if (id == 0)
            {
                return View("Index");
            }
            var user = _repo.GetUserById(id);
            UserViewModel model = new UserViewModel();
            List<string> status = new List<string>();
            var roles = _dbCall.GetRoles(roleId).Select(x => new DropdownModel() { Value = x.ID, Text = x.ROLENAME }).ToList();
            var corporates = _dbCall.GetApprovedCorporates()
                .Select(x => new DropdownModel() { Value = x.ID, Text = x.CORPORATENAME }).ToList();
            var vendors = _dbCall.GetApprovedVendors()
                .Select(x => new DropdownTextModel() { Value = x.UNIQUEVENDORID, Text = x.NAME }).ToList();
            if (user != null)
            {
                user.INPUTTERNAME = HttpContext.Session.GetString("UserName");
                user.INPUTTEREMAIL = HttpContext.Session.GetString("UserEmail");
                status.Add(Status.ACTIVE.ToString());
                status.Add(Status.DISABLED.ToString());
                model.Status = status;
                model.roles = roles;
                model.User = user;
                model.corporates = corporates;
                model.vendor = vendors;
            }

            return PartialView("_EditUser", model);
        }

        public ActionResult _Details(int id)
        {
            int rolId = (int)HttpContext.Session.GetInt32("RoleId");
            var users = _repo.GetAllUsers();
            var roles = _dbCall.GetRoles(rolId).Select(x => new DropdownModel() { Value = x.ID, Text = x.ROLENAME }).ToList();
            var corporates = _dbCall.GetApprovedCorporates().Select(x => new DropdownModel() { Value = x.ID, Text = x.CORPORATENAME }).ToList();
            var model = users.FirstOrDefault(u => u.ID == id);
            int roleId = model.ROLEID;
            var roleDet = roles.FirstOrDefault(r => r.Value == roleId);
            if (roleDet != null) model.ROLENAME = roleDet.Text;

            //model.STATUS = model.STATUS ==1
            return PartialView(model);
        }

        public ActionResult Auth(int id)
        {
            int corporateid = (int)HttpContext.Session.GetInt32("corporateId");
            var userClass = HttpContext.Session.GetString("UserClass");
            var currentuseremail = HttpContext.Session.GetString("UserEmail");
            int roleId = (int)HttpContext.Session.GetInt32("RoleId");

            var pending = _repo.GetUnapprovedUsersById(id, currentuseremail, userClass, roleId, corporateid);
            pending.AUTHORIZERNAME = HttpContext.Session.GetString("UserName");
            pending.AUTHORIZEREMAIL = HttpContext.Session.GetString("UserEmail");
            var roleName = _repo.GetRoleById(pending.ROLEID).ROLENAME;
            pending.ROLENAME = roleName;

            return PartialView("_Authorize", pending);
        }
        [HttpPost]
        public ActionResult _Authorize([Bind("ID,AUTHORIZERNAME,AUTHORIZEREMAIL,AUTHORIZATIONSTATUS,AUTHORIZERCOMMENT,USERNAME,EMAIL,FIRSTNAME,LASTNAME,STATUS,INPUTTEREMAIL")] UsersPending model)
        {

            //do the validation to ensure only one user exist in the database
            var confirmUserExist = UsernameUniquefinal(model.USERNAME);
            var pendingUserEmail = getPendingUserEmail(model.USERNAME);

            if (confirmUserExist.errorCode == "00")
            {
                Alert(confirmUserExist.errorMessage, NotificationType.info);
                return RedirectToAction("Index");
            }


            model.AUTHORIZERNAME = HttpContext.Session.GetString("UserName");
            model.AUTHORIZEREMAIL = HttpContext.Session.GetString("UserEmail");

            ///check the authorizer email is different from the Inputer Email

            if (!string.IsNullOrEmpty(pendingUserEmail))
            {
                if (pendingUserEmail == model.AUTHORIZEREMAIL)
                {
                    Alert("Initiator cannot be same as Authorizer", NotificationType.info);
                    return RedirectToAction("Index");
                }
            }


            var authorized = _repo.AuthorizeUser(model);
            if (authorized)
            {
                if (model.AUTHORIZATIONSTATUS == 1)
                {
                    AuditDetails detail = new AuditDetails()
                    {
                        USERNAME = HttpContext.Session.GetString("UserName"),
                        ACTIVITIES = $"User was successfully Approved. User Email: {model.EMAIL} ",
                        DATECREATED = DateTime.UtcNow

                    };
                    _dbCall.InsertAudit(detail);
                    TempData["authMessage"] = "User details successfully Approved";
                    Alert("User details successfully authorized", NotificationType.success);
                }
                else
                {
                    AuditDetails detail = new AuditDetails()
                    {
                        USERNAME = HttpContext.Session.GetString("UserName"),
                        ACTIVITIES = $"User was successfully Rejected. User Email: {model.EMAIL} ",
                        DATECREATED = DateTime.UtcNow

                    };
                    _dbCall.InsertAudit(detail);
                    TempData["authMessage"] = "User details successfully Rejected";
                    Alert("User details successfully authorized", NotificationType.success);
                }

            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Unable to authorize user. User Email: {model.EMAIL} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);
                //TempData["authMessage"] = "Unable to authorized user";
                Alert("Unable to authorized user", NotificationType.error);
            }
            // return RedirectToAction("AuthorizeUser");
            return RedirectToAction("Index");
        }
        public ActionResult AuthorizeUser()
        {
            var currentuseremail = HttpContext.Session.GetString("UserEmail");
            var userClass = HttpContext.Session.GetString("UserClass");
            int roleId = (int)HttpContext.Session.GetInt32("RoleId");
            int corporateid = (int)HttpContext.Session.GetInt32("corporateId");
            var model = _repo.GetUnapprovedUsers(currentuseremail, userClass, roleId, corporateid);
            return View(model);
        }
        public IActionResult IsUsernameUnique(string username)
        {
            var isUnique = _repo.IsUsernameUnique(username);
            //var isUniqueJson = JsonConvert.SerializeObject(isUnique);

            return Json(isUnique);

        }

        public string UsernameUnique(string username)
        {
            var isUnique = _repo.IsUsernameUnique(username);
            var isUniqueJson = JsonConvert.SerializeObject(isUnique);

            return isUniqueJson;

        }

        public string getPendingUserEmail(string username)
        {
            var initiatorEmail = _repo.getpendinguserinitiatoremail(username);


            return initiatorEmail;
        }

        public genericResponse UsernameUniquefinal(string username)
        {

            var isUnique = _repo.IsUsernameUniquefinal(username);


            return isUnique;

        }

        public IActionResult IsEmailUnique(string email)
        {
            var isUnique = _repo.IsEmailUnique(email);
            //var isUniqueJson = JsonConvert.SerializeObject(isUnique);
            return Json(isUnique);
        }

        public IActionResult ViewUserDetailsModal(int userId)
        {
            Users userDetails = _dbCall.GetUserDetailsVM(userId);
            return PartialView("_userDetailsdisplay", userDetails);
        }
        public IActionResult ViewUserDetailsApprovalModal(int userId)
        {
            var userClass = HttpContext.Session.GetString("UserClass");
            var currentuseremail = HttpContext.Session.GetString("UserEmail");
            int roleId = (int)HttpContext.Session.GetInt32("RoleId");
            int corporateid = (int)HttpContext.Session.GetInt32("corporateId");



            var pending = _dbCall.GetPendingUsers(currentuseremail, userClass, roleId, corporateid).FirstOrDefault(v => v.ID == userId);
            pending.AUTHORIZERNAME = HttpContext.Session.GetString("UserName");
            pending.AUTHORIZEREMAIL = HttpContext.Session.GetString("UserEmail");

            //return PartialView("_Authorize", pending);
            return PartialView("_userDetailsapproval", pending);

        }

        [HttpPost]
        public ActionResult _AddNewUser([Bind("User,Status,roles")] UserViewModel model)
        {
            var confirmUserExist = UsernameUniquefinal(model.User.USERNAME);
            if (confirmUserExist.errorCode == "00")
            {
                Alert(confirmUserExist.errorMessage, NotificationType.info);
                return RedirectToAction("Index");
            }

            // Check if Corporate user is a the only corporate user mapped to the corporate
            bool isSingleCorporate = GetIsSingleCorporate();

            string inputterName = string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")) ? model.User.INPUTTERNAME : HttpContext.Session.GetString("UserName");
            string inputterEmail = string.IsNullOrEmpty(HttpContext.Session.GetString("UserEmail")) ? model.User.INPUTTEREMAIL : HttpContext.Session.GetString("UserEmail");
            if (model.User.USERCLASS == UserClass.ACCESSREP.ToString())
            {
                UpdateUser user = new UpdateUser
                {
                    USERNAME = model.User.USERNAME,
                    EMAIL = model.User.EMAIL,
                    FIRSTNAME = model.User.FIRSTNAME,
                    LASTNAME = model.User.LASTNAME,
                    ROLEID = model.User.ROLEID,
                    USERTYPE = "INTERNAL",
                    USERCLASS = model.User.USERCLASS,
                    CORPORATECORPID = 0,
                    VENDORCORPID = 0,
                    STATUS = model.User.STATUS,
                    VENDORID = "",
                    INPUTTEREMAIL = inputterEmail,
                    INPUTTERNAME = inputterName,
                    UPDATETYPE = UpdateTypes.NEW.ToString()
                };
                user.ROLENAME = model.User.ROLEID == 0 ? "" : _repo.GetRoleById(user.ROLEID).ROLENAME;

                var created = _repo.CreateUpdateUser(user, isSingleCorporate);

                if (created)
                {
                    AuditDetails detail = new AuditDetails()
                    {
                        USERNAME = HttpContext.Session.GetString("UserName"),
                        ACTIVITIES = $"User was successfully created. User Email: {user.EMAIL} ",
                        DATECREATED = DateTime.UtcNow

                    };
                    _dbCall.InsertAudit(detail);

                    if (isSingleCorporate)
                    {
                        Alert("User successfully created", NotificationType.success);
                    }
                    else
                    {
                        Alert("User successfully created, awaiting authorization", NotificationType.success);
                    }

                }
                else
                {
                    AuditDetails detail = new AuditDetails()
                    {
                        USERNAME = HttpContext.Session.GetString("UserName"),
                        ACTIVITIES = $"Unable to create user. User Email: {user.EMAIL} ",
                        DATECREATED = DateTime.UtcNow

                    };
                    _dbCall.InsertAudit(detail);
                    Alert("Unable to create user", NotificationType.error);
                }

                return RedirectToAction("Index");
            }
            else
            {
                int corporateCorpId = 0;
                int vendorCorpId = 0;
                string vendorId = "";

                if (model.User.USERCLASS == UserClass.CORPORATE.ToString())
                {
                    corporateCorpId = model.User.CORPORATECORPID;
                }
                else if (model.User.USERCLASS == UserClass.VENDOR.ToString())
                {
                    vendorCorpId = model.User.VENDORCORPID;
                    vendorId = model.User.VENDORID;
                }
                else if (model.User.USERCLASS == UserClass.VENDORCORPORATE.ToString())
                {
                    vendorCorpId = model.User.VENDORCORPID;
                    vendorId = model.User.VENDORID;
                    corporateCorpId = model.User.CORPORATECORPID;
                }

                UpdateUser user = new UpdateUser
                {
                    USERNAME = model.User.USERNAME,
                    EMAIL = model.User.EMAIL,
                    FIRSTNAME = model.User.FIRSTNAME,
                    LASTNAME = model.User.LASTNAME,
                    ROLEID = model.User.ROLEID,
                    USERTYPE = "EXTERNAL",
                    USERCLASS = model.User.USERCLASS,
                    CORPORATECORPID = corporateCorpId,
                    VENDORCORPID = vendorCorpId,
                    STATUS = model.User.STATUS,
                    VENDORID = vendorId,
                    INPUTTEREMAIL = inputterEmail,
                    INPUTTERNAME = inputterName,
                    UPDATETYPE = UpdateTypes.NEW.ToString()
                };
                user.ROLENAME = model.User.ROLEID == 0 ? "" : _repo.GetRoleById(user.ROLEID).ROLENAME;

                var created = _repo.CreateUpdateUser(user, isSingleCorporate);

                if (created)
                {
                    AuditDetails detail = new AuditDetails()
                    {
                        USERNAME = HttpContext.Session.GetString("UserName"),
                        ACTIVITIES = $"User was successfully created. User Email: {user.EMAIL} ",
                        DATECREATED = DateTime.UtcNow

                    };
                    _dbCall.InsertAudit(detail);

                    if (isSingleCorporate)
                    {
                        Alert("User successfully created", NotificationType.success);
                    }
                    else
                    {
                        Alert("User successfully created, awaiting authorization", NotificationType.success);
                    }
                }
                else
                {
                    AuditDetails detail = new AuditDetails()
                    {
                        USERNAME = HttpContext.Session.GetString("UserName"),
                        ACTIVITIES = $"Unable to create user. User Email: {user.EMAIL} ",
                        DATECREATED = DateTime.UtcNow

                    };
                    _dbCall.InsertAudit(detail);
                    Alert("Unable to create user", NotificationType.error);
                }

                return RedirectToAction("Index");
            }
        }

        public ActionResult _AddUser()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Index", "Login", new { errorMsg = "Session Timeout" });
            }
            //check the user usertype and user class to know the value to display
            var userType = HttpContext.Session.GetString("UserType");
            var userClass = HttpContext.Session.GetString("UserClass");
            int roleId = (int)HttpContext.Session.GetInt32("RoleId");
            int corporateid = (int)HttpContext.Session.GetInt32("corporateId"); ;

            var enumlistuserType = Enum.GetValues(typeof(UserType)).Cast<UserType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            });

            var enumlistuserClass = Enum.GetValues(typeof(UserType)).Cast<UserType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            });

            if (userType == "INTERNAL")
            {
                enumlistuserType = enumlistuserType.Skip(0);

            }
            else if (userClass == "CORPORATE")
            {
                enumlistuserClass = enumlistuserClass.Skip(2);
            }

            ViewBag.enumlistusertype = enumlistuserType;

            ViewBag.enumlistuseclass = enumlistuserClass;


            UserViewModel model = new UserViewModel();
            var corporates = new List<DropdownModel>();
            var vendors = new List<DropdownTextModel>();
            List<string> status = new List<string>();
            var roles = _dbCall.GetRoles(roleId).Select(x => new DropdownModel() { Value = x.ID, Text = x.ROLENAME }).ToList();
            if (userClass == "CORPORATE")
            {
                corporates = _dbCall.GetApprovedCorporatesbyCorporateID(corporateid)
                   .Select(x => new DropdownModel() { Value = x.ID, Text = x.CORPORATENAME }).ToList();
                vendors = _dbCall.GetApprovedVendorsbyCorporateId(corporateid)
                   .Select(x => new DropdownTextModel() { Value = x.UNIQUEVENDORID, Text = x.NAME }).ToList();
            }
            else
            {
                corporates = _dbCall.GetApprovedCorporates()
                   .Select(x => new DropdownModel() { Value = x.ID, Text = x.CORPORATENAME }).ToList();
                vendors = _dbCall.GetApprovedVendors()
                   .Select(x => new DropdownTextModel() { Value = x.UNIQUEVENDORID, Text = x.NAME }).ToList();
            }



            Users user = new Users
            {
                INPUTTERNAME = HttpContext.Session.GetString("UserName"),
                INPUTTEREMAIL = HttpContext.Session.GetString("UserEmail"),
                CREATEDDATE = DateTime.UtcNow,
                STATUS = 1
            };


            status.Add(Status.ACTIVE.ToString());
            status.Add(Status.DISABLED.ToString());
            model.Status = status;
            model.roles = roles;
            model.corporates = corporates;
            model.User = user;
            model.vendor = vendors;
            model.UserType = userType;


            //var isUserNameUqiue = UsernameUniquefinal(user.USERNAME);

            //if (isUserNameUqiue.errorCode == "00")
            //{
            //    Alert("UserID already exist on the System", NotificationType.info); 
            //    return RedirectToAction("Index");
            //}
            return PartialView("AddNewUser", model);


        }


        [HttpPost]
        public ActionResult _EditUser([Bind("User,Status,roles")] UserViewModel model)
        {
            string inputterName = string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")) ? model.User.INPUTTERNAME : HttpContext.Session.GetString("UserName");
            string inputterEmail = string.IsNullOrEmpty(HttpContext.Session.GetString("UserEmail")) ? model.User.INPUTTEREMAIL : HttpContext.Session.GetString("UserEmail");

            // Check if Corporate user is a the only corporate user mapped to the corporate
            bool isSingleCorporate = GetIsSingleCorporate();

            UpdateUser user = new UpdateUser();
            if (model.User.USERCLASS == "ACCESSREP")
            {
                user.USERNAME = model.User.USERNAME;
                user.EMAIL = model.User.EMAIL;
                user.FIRSTNAME = model.User.FIRSTNAME;
                user.LASTNAME = model.User.LASTNAME;
                user.ROLEID = model.User.ROLEID;
                user.USERTYPE = "INTERNAL";//model.User.USERTYPE;
                user.USERCLASS = model.User.USERCLASS;
                user.CORPORATECORPID = 0;
                user.VENDORCORPID = 0;
                user.VENDORID = model.User.VENDORID;
                user.STATUS = model.User.STATUS;
                user.INPUTTEREMAIL = inputterEmail;
                user.INPUTTERNAME = inputterName;
                user.UPDATETYPE = UpdateTypes.UPDATE.ToString();
                user.USERID = model.User.ID;
            }
            else
            {
                int corporateCorpId = 0;
                int vendorCorpId = 0;
                string vendorId = "";

                if (model.User.USERCLASS == "CORPORATE")
                {
                    corporateCorpId = model.User.CORPORATECORPID;
                }
                else if (model.User.USERCLASS == "VENDOR")
                {
                    vendorCorpId = model.User.VENDORCORPID;
                    vendorId = model.User.VENDORID;
                }
                else if (model.User.USERCLASS == "VENDORCORPORATE")
                {
                    vendorCorpId = model.User.VENDORCORPID;
                    vendorId = model.User.VENDORID;
                    corporateCorpId = model.User.CORPORATECORPID;
                }
                user.USERNAME = model.User.USERNAME;
                user.EMAIL = model.User.EMAIL;
                user.FIRSTNAME = model.User.FIRSTNAME;
                user.LASTNAME = model.User.LASTNAME;
                user.ROLEID = model.User.ROLEID;
                user.USERTYPE = "EXTERNAL";
                user.USERCLASS = model.User.USERCLASS;
                user.CORPORATECORPID = corporateCorpId;
                user.VENDORCORPID = vendorCorpId;
                user.VENDORID = vendorId;
                user.STATUS = model.User.STATUS;
                user.INPUTTEREMAIL = inputterEmail;
                user.INPUTTERNAME = inputterName;
                user.UPDATETYPE = UpdateTypes.UPDATE.ToString();
                user.USERID = model.User.ID;
            }

            user.ROLENAME = model.User.ROLEID == 0 ? "" : _repo.GetRoleById(user.ROLEID).ROLENAME;
            var updated = _repo.CreateUpdateUser(user, isSingleCorporate);

            if (updated)
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"User was successfully modified. User Email: {user.EMAIL} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);

                if (isSingleCorporate)
                {
                    Alert("User successfully modified", NotificationType.success);
                }
                else
                {
                    Alert("User successfully modified, awaiting authorization", NotificationType.success);
                }

            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Unable to modify user. User Email: {user.EMAIL} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);
                Alert("Unable to modify user", NotificationType.error);
            }
            return RedirectToAction("Index");
        }

        public bool GetIsSingleCorporate()
        {
            //Get userclass and corporateid
            bool isSingleCorporate = false;
            string userClass = HttpContext.Session.GetString("UserClass");
            bool LoggedInAsCorporate = HttpContext.Session.GetString("LoggedInAsCorporate") == "1" ? true : false;

            if (userClass == UserClass.CORPORATE.ToString() || (userClass == UserClass.VENDORCORPORATE.ToString() && LoggedInAsCorporate))
            {
                int corporateId = (int)HttpContext.Session.GetInt32("corporateId");
                isSingleCorporate = _dbCall.IsSingleCorporate(corporateId);
            }
            return isSingleCorporate;
        }
    }
}
