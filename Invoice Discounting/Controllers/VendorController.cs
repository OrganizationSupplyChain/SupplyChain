using Invoice_Discounting.Models;
using Invoice_Discounting.Services;
using Invoice_Discounting.Utility;
using Invoice_Discounting.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using static Invoice_Discounting.Utility.Enums;

namespace Invoice_Discounting.Controllers
{
    public class VendorController : BaseController
    {
        private readonly IRepository _repo;
        private readonly IDatabaseCalls _dbCall;

        public VendorController(IRepository repo, IDatabaseCalls dbCall)
        {
            _repo = repo;
            _dbCall = dbCall;
        }


        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Index", "Login", new { errorMsg = "Session Timeout" });
            }
            //Get all Approved Vendor__ and Get all Pending Vendors
            var currentuseremail = HttpContext.Session.GetString("UserEmail");
            var corporateId = (int) HttpContext.Session.GetInt32("corporateId");
            var model = Enumerable.Empty<VendorDetails>();
            if (corporateId != 0)
            {
                model = _dbCall.GetApprovedVendorsbyCorporateId(corporateId);
            }
            else { model = _dbCall.GetApprovedVendors(); }

            if (model != null)
            {
                foreach (var vendor in model)
                {
                    vendor.STATUSBOOL = vendor.STATUS == "1" ? true : false;
                }
            }
            
            var pendingModel = _dbCall.GetPendingVendors(currentuseremail, corporateId);
            var approvependingvendor = new VendorPendingApproveModel();

            approvependingvendor.vendorapproved = model;
            approvependingvendor.vendorpending = pendingModel;

            return View(approvependingvendor);
            //return View(model);
        }
        
        public ActionResult ModifyVendor(int id)
        {
            if (id == 0)
            {
                return View("Index");
            }
            IEnumerable<VendorDetails> allVendors = _dbCall.GetApprovedVendors();
            VendorDetails vendor = allVendors.FirstOrDefault(v => v.ID == id);
            VendorViewModel model = new VendorViewModel();
            List<string> status = new List<string>();
            vendor.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
            vendor.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
            vendor.DATECREATED = DateTime.UtcNow;
            status.Add(Enums.Status.ACTIVE.ToString());
            status.Add(Enums.Status.DISABLED.ToString());
            model.Status = status;
            model.Vendor = vendor;

            return PartialView("EditVendor", model);
        }

        public ActionResult _Details(int id)
        {
            IEnumerable<VendorDetails> allvendors = _dbCall.GetApprovedVendors();
            VendorDetails vendor = allvendors.FirstOrDefault(v => v.ID == id);
            return PartialView(vendor);
        }

        [HttpPost]
        public ActionResult _EditVendor([Bind("Vendor")] VendorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            // Check if corporate is a single corporate
            bool isSingleCorporate = GetIsSingleCorporate();

            UpdateVendor vendor = new UpdateVendor();
            vendor.CATEGORY = model.Vendor.CATEGORY;
            vendor.EMAIL = model.Vendor.EMAIL;
            vendor.ACCOUNTNO = model.Vendor.EMAIL;
            vendor.ACCOUNTNO = model.Vendor.ACCOUNTNO;
            vendor.ADDRESS = model.Vendor.ADDRESS;
            vendor.STATUS = Convert.ToInt32(model.Vendor.STATUS);
            vendor.TIN_RC = model.Vendor.TIN_RC;
            vendor.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
            vendor.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
            vendor.UPDATETYPE = Enums.UpdateTypes.UPDATE.ToString();
            vendor.CORPORATEID = (int)HttpContext.Session.GetInt32("corporateId");
            vendor.BANK = model.Vendor.BANK;
            vendor.SERVICENATURE = model.Vendor.SERVICENATURE;
            vendor.PHONENO = model.Vendor.PHONENO;
            vendor.NAME = model.Vendor.NAME;

            var updated = _repo.CreateUpdateVendor(vendor, isSingleCorporate);

            if (updated)
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Vendor successfully modified. Vendor Name: {vendor.NAME} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);

                if (isSingleCorporate)
                {
                    Alert("Vendor successfully modified", NotificationType.success);
                }
                else
                {
                    Alert("Vendor successfully modified, awaiting authorization", NotificationType.success);
                }

            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Unable to modify vendor. Vendor Name: {vendor.NAME} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);
                Alert("Unable to modify vendor", NotificationType.error);
                //TempData["message"] = "Unable to modify vendor";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Auth(int id)
        {
            var corporateId = (int)HttpContext.Session.GetInt32("corporateId");
            var currentuseremail = HttpContext.Session.GetString("UserEmail");
            var pending = _dbCall.GetPendingVendors(currentuseremail, corporateId).FirstOrDefault(v => v.ID == id);
            pending.AUTHORIZERNAME = HttpContext.Session.GetString("UserName");
            pending.AUTHORIZEREMAIL = HttpContext.Session.GetString("UserEmail");

            return PartialView("_Authorize", pending);
        }
        [HttpPost]
        public ActionResult _Authorize([Bind("ID,AUTHORIZERCOMMENT,AUTHORIZATIONSTATUS,NAME")] VendorDetailsPending model)
        {
            if (!ModelState.IsValid)
            {
                Alert("Unable to authorized vendor details", NotificationType.error);
                return PartialView("Index");
            }
            AuthorizeVendor pending = new AuthorizeVendor();
            pending.AuthName = HttpContext.Session.GetString("UserName");
            pending.AuthEmail = HttpContext.Session.GetString("UserEmail");
            pending.Idt = model.ID;
            pending.AuthComment = model.AUTHORIZERCOMMENT;
            pending.AuthStatus = model.AUTHORIZATIONSTATUS;

            var authorized = _dbCall.AuthorizeVendor(pending);
            if (authorized)
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Vendor successfully authorized. Vendor Name: {model.NAME} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);
                Alert("Vendor details successfully authorized", NotificationType.success);
            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Unable to authorize Vendor. Vendor Name: {model.NAME} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);

                Alert("Unable to authorized Vendor", NotificationType.error);
            }
            return RedirectToAction("Index");
        }

        public ActionResult AuthorizeVendor()
        {
            var currentuseremail = HttpContext.Session.GetString("UserEmail");
            var corporateId = (int)HttpContext.Session.GetInt32("corporateId");
            var model = _dbCall.GetPendingVendors(currentuseremail, corporateId);
            return View(model);
        }


        [HttpPost]
        public ActionResult _AddNewVendor(VendorViewModel model)
        {
            // Check if corporate is a single corporate
            bool isSingleCorporate = GetIsSingleCorporate();

            model._banklists = _dbCall.GetAllBanksNew();
            model._cateorylist = _dbCall.GetCategoryLists();
            var selectedItem = model._cateorylist.Find(v => v.ID == model.SelectedCategoryId);
            var selectedBank = model._banklists.Find(b => b.ID == model.SelectedBankId);

            UpdateVendor vendor = new UpdateVendor();

            vendor.UNIQUEVENDORID = model.Vendor.UNIQUEVENDORID;
            vendor.ADDRESS = model.Vendor.ADDRESS;
            vendor.PHONENO = model.Vendor.PHONENO;
            vendor.NAME = model.Vendor.NAME;
            vendor.CATEGORY = selectedItem?.CategoryName;//model.Vendor.CATEGORY;
            vendor.EMAIL = model.Vendor.EMAIL;
            vendor.SERVICENATURE = model.Vendor.SERVICENATURE;
            vendor.TIN_RC = model.Vendor.TIN_RC;
            vendor.STATUS = Convert.ToInt32(model.Vendor.STATUS);
            vendor.BANK = selectedBank?.BankName;
            vendor.ACCOUNTNO = model.Vendor.ACCOUNTNO;
            vendor.DATECREATED = model.Vendor.DATECREATED;
            vendor.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
            vendor.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
            vendor.CORPORATEID = (int) HttpContext.Session.GetInt32("corporateId");
            vendor.UPDATETYPE = Enums.UpdateTypes.NEW.ToString();
            vendor.AUTHORIZERCOMMENT = "";
            vendor.AUTHORIZEREMAIL = "";
            vendor.AUTHORIZERNAME = "";

            var created = _repo.CreateUpdateVendor(vendor, isSingleCorporate);
            if (created)
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Vendor successfully created. Vendor Name: {vendor.NAME} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);

                if (isSingleCorporate)
                {
                    Alert("Vendor successfully created", NotificationType.success);
                }
                else
                {
                    Alert("Vendor successfully created, awaiting authorization", NotificationType.success);
                }

            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Unable to create vendor. Vendor Name: {vendor.NAME} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);

                Alert("Unable to create vendor", NotificationType.error);
            }
            return RedirectToAction("Index");
        }
        public ActionResult _AddVendor()
        {
            VendorViewModel model = new VendorViewModel();
            var venRandomNo = _repo.GenerateRandomNos();
            List<string> status = new List<string>();
            model._cateorylist = _dbCall.GetCategoryLists();
            model._banklists = _dbCall.GetAllBanksNew();
            VendorDetails vendor = new VendorDetails();
            vendor.UNIQUEVENDORID = $"VEN{venRandomNo}";
            vendor.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
            vendor.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
            vendor.CORPORATEID = (int)HttpContext.Session.GetInt32("corporateId");
            vendor.DATECREATED = DateTime.UtcNow;
            status.Add(Enums.Status.ACTIVE.ToString());
            status.Add(Enums.Status.DISABLED.ToString());
            model.Status = status;
            model.Vendor = vendor;

            return PartialView("AddNewVendor", model);
        }

        public IActionResult ViewVendorDetailsModal(int vendorId)
        {
            IEnumerable<VendorDetails> allvendors = _dbCall.GetApprovedVendors();
            VendorDetails vendor = allvendors.FirstOrDefault(v => v.ID == vendorId);
            return PartialView("_vendorDetailsdisplay", vendor);
        }

        public IActionResult ViewVendorDetailsApprovalModal(int vendorId)
        {
            var currentuseremail = HttpContext.Session.GetString("UserEmail");
            var corporateId = (int)HttpContext.Session.GetInt32("corporateId");
            var pending = _dbCall.GetPendingVendors(currentuseremail, corporateId).FirstOrDefault(v => v.ID == vendorId);
            pending.AUTHORIZERNAME = HttpContext.Session.GetString("UserName");
            pending.AUTHORIZEREMAIL = HttpContext.Session.GetString("UserEmail");

            //return PartialView("_Authorize", pending);
            return PartialView("_vendorDetailsapproval", pending);

        }

        public IActionResult VendorStatusChange(int id, bool status)
        {
            var updated = _dbCall.UpdateVendorStatus(id, status);
            return Json(updated);
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
