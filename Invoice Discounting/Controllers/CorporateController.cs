using System;
using System.Collections.Generic;
using System.Linq;
using Invoice_Discounting.Models;
using Invoice_Discounting.Services;
using Invoice_Discounting.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static Invoice_Discounting.Utility.Enums;

namespace Invoice_Discounting.Controllers
{
    public class CorporateController : BaseController
	{
		private readonly IConfiguration _config;
		private readonly IRepository repo;
		private readonly IDatabaseCalls dbCall;

		public CorporateController(IConfiguration config, IRepository repository, IDatabaseCalls databaseCalls)
		{
			_config = config;
			repo = repository;
			dbCall = databaseCalls;
		}
		public IActionResult Index()
		{
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Index", "Login", new { errorMsg = "Session Timeout" });
            }
            var currentuseremail = HttpContext.Session.GetString("UserEmail");
            var model = dbCall.GetApprovedCorporates();
            foreach(var corporate in model)
            {
                corporate.STATUSBOOL = corporate.STATUS == '1' ? true : false;
            }
            var pendingModel = dbCall.GetPendingCorporates(currentuseremail);
            var approvedpendingCorporate = new CorporatePendingApproveModel();
            approvedpendingCorporate.corporateapproved = model;
            approvedpendingCorporate.corporatepending = pendingModel;
            AuditDetails detail = new AuditDetails()
            {
                USERNAME = HttpContext.Session.GetString("UserName"),
                ACTIVITIES = "Loaded All pending Approved Corporate",
                DATECREATED = DateTime.UtcNow

            };
            dbCall.InsertAudit(detail);
			return View(approvedpendingCorporate);
		}

		//public ActionResult AddCorporate()
		//{
		//	CorporateViewModel model = new CorporateViewModel();
		//	List<string> status = new List<string>();
		//	CorporateDetails corporate = new CorporateDetails();
		//	corporate.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
		//	corporate.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
		//	corporate.CREATEDDATE = DateTime.UtcNow;
		//	status.Add(Status.ACTIVE.ToString());
		//	status.Add(Status.DISABLED.ToString());
		//	model.Status = status;
		//	model.Corporate = corporate;

		//	AuditDetails detail = new AuditDetails()
  //          {
  //              USERNAME = HttpContext.Session.GetString("UserName"),
  //              ACTIVITIES = "Created a new  Corporate",
  //              DATECREATED = DateTime.UtcNow

  //          };
  //          dbCall.InsertAudit(detail);

		//	return PartialView("_Create", model);
		//}

		public ActionResult ModifyCorporate(int id)
		{
			if (id == 0)
			{
				return View("Index");
			}
			IEnumerable<CorporateDetails> allCorporates = dbCall.GetApprovedCorporates();
			CorporateDetails corporate = allCorporates.Where(c => c.ID == id).FirstOrDefault();
			CorporateViewModel model = new CorporateViewModel();
			List<string> status = new List<string>();
			corporate.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
			corporate.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
			corporate.CREATEDDATE = DateTime.UtcNow;
			status.Add(Status.ACTIVE.ToString());
			status.Add(Status.DISABLED.ToString());
			model.Status = status;
			model.Corporate = corporate;

            AuditDetails detail = new AuditDetails()
            {
                USERNAME = HttpContext.Session.GetString("UserName"),
                ACTIVITIES = "Corporate was modify",
                DATECREATED = DateTime.UtcNow

            };
            dbCall.InsertAudit(detail);

			return PartialView("EditCorporate", model);
		}

		public ActionResult _Details(int id)
		{
			IEnumerable<CorporateDetails> allCorporates = dbCall.GetApprovedCorporates();
			CorporateDetails corporate = allCorporates.FirstOrDefault(c => c.ID == id);
            AuditDetails detail = new AuditDetails()
            {
                USERNAME = HttpContext.Session.GetString("UserName"),
                ACTIVITIES = $"A corporate was viewed. ID: {id}",
                DATECREATED = DateTime.UtcNow

            };
            dbCall.InsertAudit(detail);
			return PartialView(corporate);
		}
		//[HttpPost]
		//public ActionResult _Create([Bind("File,Corporate,Status")]CorporateViewModel model)
		//{
  //          var corpRandomNo = repo.GenerateRandomNos();
  //          UpdateCorporate corporate = new UpdateCorporate();
            
		//	corporate.CORPORATEID = 0;
		//	corporate.CORPORATENAME = model.Corporate.CORPORATENAME;
		//	corporate.PRINCIPALACCOUNTNO = model.Corporate.PRINCIPALACCOUNTNO;
		//	corporate.PRINCIPALEMAIL = model.Corporate.PRINCIPALEMAIL;
		//	corporate.PRINCIPALPHONENO = model.Corporate.PRINCIPALPHONENO;
		//	corporate.STATUS = model.Corporate.STATUS;
		//	corporate.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
		//	corporate.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
		//	corporate.UPDATETYPE = UpdateTypes.NEW.ToString();
		//	corporate.INTERESTRATE = model.Corporate.INTERESTRATE;
		//	corporate.AVAILABLELINEOFCREDIT = model.Corporate.AVAILABLELINEOFCREDIT;

		//	var created = dbCall.UpdateInsertCorporate(corporate);
		//	if (created)
		//	{
  //              AuditDetails detail = new AuditDetails()
  //              {
  //                  USERNAME = HttpContext.Session.GetString("UserName"),
  //                  ACTIVITIES = "Corporate was Successfully Created and Approved",
  //                  DATECREATED = DateTime.UtcNow

  //              };
  //              dbCall.InsertAudit(detail);
  //              Alert("Corporate successfully created, awaiting authorization", NotificationType.success);
  //          }
		//	else
		//	{
  //              AuditDetails detail = new AuditDetails()
  //              {
  //                  USERNAME = HttpContext.Session.GetString("UserName"),
  //                  ACTIVITIES = "Corporate creation failed",
  //                  DATECREATED = DateTime.UtcNow

  //              };
  //              dbCall.InsertAudit(detail);
  //              Alert("Unable to create corporate", NotificationType.error);

  //          }
		//	return RedirectToAction("Index");
		//}

		//[HttpPost]
		//public ActionResult _Edit([Bind("File,Corporate,Status")]CorporateViewModel model)
		//{
		
		//	UpdateCorporate corporate = new UpdateCorporate();
		//	corporate.CORPORATEID = model.Corporate.ID;
		//	corporate.CORPORATENAME = model.Corporate.CORPORATENAME;
		//	corporate.PRINCIPALACCOUNTNO = model.Corporate.PRINCIPALACCOUNTNO;
		//	corporate.PRINCIPALEMAIL = model.Corporate.PRINCIPALEMAIL;
		//	corporate.PRINCIPALPHONENO = model.Corporate.PRINCIPALPHONENO;
		//	corporate.STATUS = model.Corporate.STATUS;
		//	corporate.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
		//	corporate.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
		//	corporate.UPDATETYPE = UpdateTypes.UPDATE.ToString();
		//	corporate.INTERESTRATE = model.Corporate.INTERESTRATE;
		//	corporate.AVAILABLELINEOFCREDIT = model.Corporate.AVAILABLELINEOFCREDIT;

		//	var updated = dbCall.UpdateInsertCorporate(corporate);

		//	if (updated)
		//	{
  //              AuditDetails detail = new AuditDetails()
  //              {
  //                  USERNAME = HttpContext.Session.GetString("UserName"),
  //                  ACTIVITIES = "Corporate was Successfully modified and await approval",
  //                  DATECREATED = DateTime.UtcNow

  //              };
  //              dbCall.InsertAudit(detail);
				
  //              Alert("corporate successfully modified, awaiting authorization", NotificationType.success);
  //          }
		//	else
		//	{
  //              AuditDetails detail = new AuditDetails()
  //              {
  //                  USERNAME = HttpContext.Session.GetString("UserName"),
  //                  ACTIVITIES = "Corporate was unable to be modified",
  //                  DATECREATED = DateTime.UtcNow

  //              };
  //              dbCall.InsertAudit(detail);
			
  //              Alert("Unable to modify corporate", NotificationType.error);
  //          }
		//	return RedirectToAction("Index");
		//}

        [HttpPost]
        public ActionResult _EditCorporate([Bind("File,Corporate,Status")]CorporateViewModel model)
        {
            
            UpdateCorporate corporate = new UpdateCorporate();
            corporate.CORPORATEID = model.Corporate.ID;
            corporate.CORPORATENAME = model.Corporate.CORPORATENAME;
            corporate.PRINCIPALACCOUNTNO = model.Corporate.PRINCIPALACCOUNTNO;
            corporate.PRINCIPALEMAIL = model.Corporate.PRINCIPALEMAIL;
            corporate.PRINCIPALPHONENO = model.Corporate.PRINCIPALPHONENO;
            corporate.STATUS = model.Corporate.STATUS;
            corporate.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
            corporate.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
            corporate.UPDATETYPE = UpdateTypes.UPDATE.ToString();
            corporate.INTERESTRATE = model.Corporate.INTERESTRATE;
            corporate.AVAILABLELINEOFCREDIT = model.Corporate.AVAILABLELINEOFCREDIT;
            corporate.FEESRATE = model.Corporate.FEESRATE;

            var updated = dbCall.UpdateInsertCorporate(corporate);

            if (updated)
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = "Corporate was Successfully modified and await approval",
                    DATECREATED = DateTime.UtcNow

                };
                dbCall.InsertAudit(detail);
               
                Alert("corporate successfully modified, awaiting authorization", NotificationType.success);
            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = "Corporate was unable to be modified",
                    DATECREATED = DateTime.UtcNow

                };
                dbCall.InsertAudit(detail);
               
                Alert("Unable to modify corporate", NotificationType.error);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Auth(int id)
		{
            var currentuseremail = HttpContext.Session.GetString("UserEmail");
            var pending = dbCall.GetPendingCorporates(currentuseremail).FirstOrDefault(c => c.ID == id);
			pending.AUTHORIZERNAME = HttpContext.Session.GetString("UserName");
			pending.AUTHORIZEREMAIL = HttpContext.Session.GetString("UserEmail");

            AuditDetails detail = new AuditDetails()
            {
                USERNAME = HttpContext.Session.GetString("UserName"),
                ACTIVITIES = "Load pending Corporate for approval",
                DATECREATED = DateTime.UtcNow

            };
            dbCall.InsertAudit(detail);
			return PartialView("_Authorize", pending);
		}
		[HttpPost]
		public ActionResult _Authorize([Bind("ID,CORPORATENAME,PRINCIPALPHONENO,PRINCIPALEMAIL,PRINCIPALACCOUNTNO,CREATEDBYNAME,CREATEDDATE," +
            "AUTHORIZATIONSTATUS,AUTHORIZERCOMMENT,INTERESTRATE,AVAILABLELINEOFCREDIT")] CorporateDetailsPending model)
		{
			if (!ModelState.IsValid)
			{
				
                Alert("Unable to authorized corporate details", NotificationType.info);
                return PartialView("Index");
			}
			AuthorizeCorporate pending = new AuthorizeCorporate();
			pending.AuthName = HttpContext.Session.GetString("UserName");
			pending.AuthEmail = HttpContext.Session.GetString("UserEmail");
			pending.Idt = model.ID;
			pending.AuthComment = model.AUTHORIZERCOMMENT;
			pending.AuthStatus = model.AUTHORIZATIONSTATUS;

			var authorized = dbCall.AuthorizeCorporate(pending);
			if (authorized)
			{
                if (model.AUTHORIZATIONSTATUS == 1)
                {
                    AuditDetails detail = new AuditDetails()
                    {
                        USERNAME = HttpContext.Session.GetString("UserName"),
                        ACTIVITIES = "Corporate was Successfully Approved",
                        DATECREATED = DateTime.UtcNow

                    };
                    dbCall.InsertAudit(detail);
                    TempData["authMessage"] = "corporate details successfully Approved";
                    Alert("corporate details successfully Approved", NotificationType.success);
                }
                else
                {
                    AuditDetails detail = new AuditDetails()
                    {
                        USERNAME = HttpContext.Session.GetString("UserName"),
                        ACTIVITIES = "Corporate was Successfully Rejected",
                        DATECREATED = DateTime.UtcNow

                    };
                    dbCall.InsertAudit(detail);
                    TempData["authMessage"] = "corporate details successfully Rejected";
                    Alert("corporate details successfully Rejected", NotificationType.success);
                }

                
            }
			else
			{
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = "Unable to authorized corporate",
                    DATECREATED = DateTime.UtcNow

                };
                dbCall.InsertAudit(detail);
				TempData["authMessage"] = "Unable to authorized corporate";
                Alert("Unable to authorized corporate", NotificationType.error);
            }

            return RedirectToAction("Index");
           
		}
		public ActionResult AuthorizeCorporate()
		{
            var currentuseremail = HttpContext.Session.GetString("UserEmail");
            var model = dbCall.GetPendingCorporates(currentuseremail);

            AuditDetails detail = new AuditDetails()
            {
                USERNAME = HttpContext.Session.GetString("UserName"),
                ACTIVITIES = "Fetched all pending Corporate for Authorization",
                DATECREATED = DateTime.UtcNow

            };
            dbCall.InsertAudit(detail);
			return View(model);
		}

        public ActionResult _AddCorporate()
        {
            var corpRandomNo = repo.GenerateRandomNos();
            CorporateViewModel model = new CorporateViewModel();
            List<string> status = new List<string>();
            CorporateDetails corporate = new CorporateDetails();
            corporate.UNIQUECORPORATEID = $"COR{corpRandomNo}";
            corporate.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
            corporate.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
            corporate.CREATEDDATE = DateTime.UtcNow;
            status.Add(Status.ACTIVE.ToString());
            status.Add(Status.DISABLED.ToString());
            model.Status = status;
            model.Corporate = corporate;

            AuditDetails detail = new AuditDetails()
            {
                USERNAME = HttpContext.Session.GetString("UserName"),
                ACTIVITIES = "Created a new  Corporate",
                DATECREATED = DateTime.UtcNow

            };
            dbCall.InsertAudit(detail);

            return PartialView("_Create", model);
        }


        [HttpPost]
        public ActionResult _AddNewCorporate([Bind("File,Corporate,Status")]CorporateViewModel model)
        {
            UpdateCorporate corporate = new UpdateCorporate();
            corporate.CORPORATEID = 0;
            corporate.CORPORATENAME = model.Corporate.CORPORATENAME;
            corporate.PRINCIPALACCOUNTNO = model.Corporate.PRINCIPALACCOUNTNO;
            corporate.PRINCIPALEMAIL = model.Corporate.PRINCIPALEMAIL;
            corporate.PRINCIPALPHONENO = model.Corporate.PRINCIPALPHONENO;
            corporate.STATUS = model.Corporate.STATUS;
            corporate.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
            corporate.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
            corporate.UPDATETYPE = UpdateTypes.NEW.ToString();
            corporate.INTERESTRATE = model.Corporate.INTERESTRATE;
            corporate.AVAILABLELINEOFCREDIT = model.Corporate.AVAILABLELINEOFCREDIT;
            corporate.UNIQUECORPORATEID = model.Corporate.UNIQUECORPORATEID;
            corporate.FEESRATE = model.Corporate.FEESRATE;

            var created = dbCall.UpdateInsertCorporate(corporate);
            if (created)
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = "Corporate was Successfully Created and Approved",
                    DATECREATED = DateTime.UtcNow

                };
                dbCall.InsertAudit(detail);
               
                Alert("Corporate successfully created, awaiting authorization", NotificationType.success);
            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = "Corporate creation failed",
                    DATECREATED = DateTime.UtcNow

                };
                dbCall.InsertAudit(detail);
             
                Alert("Unable to create corporate", NotificationType.success);
            }
            return RedirectToAction("Index");
        }

		public ActionResult _AddCorporates()
         {
            var corpRandomNo = repo.GenerateRandomNos();
            CorporateViewModel model = new CorporateViewModel();
            List<string> status = new List<string>();
            CorporateDetails corporate = new CorporateDetails();
            corporate.UNIQUECORPORATEID = $"COR{corpRandomNo}";
            corporate.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
            corporate.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
            corporate.CREATEDDATE = DateTime.UtcNow;
            status.Add(Status.ACTIVE.ToString());
            status.Add(Status.DISABLED.ToString());
            model.Status = status;
            model.Corporate = corporate;

            AuditDetails detail = new AuditDetails()
            {
                USERNAME = HttpContext.Session.GetString("UserName"),
                ACTIVITIES = "Created a new  Corporate",
                DATECREATED = DateTime.UtcNow

            };
            dbCall.InsertAudit(detail);

            return PartialView("AddNewCorporate", model);

			
			
        }

		public IActionResult ViewCorporateDetailsApprovalModal(int corporateId)
        {
            var currentuseremail = HttpContext.Session.GetString("UserEmail");
            var pending = dbCall.GetPendingCorporates(currentuseremail).FirstOrDefault(c => c.ID == corporateId);
			
            pending.AUTHORIZERNAME = HttpContext.Session.GetString("UserName");
            pending.AUTHORIZEREMAIL = HttpContext.Session.GetString("UserEmail");

           
            return PartialView("_corporateDetailsapproval", pending);

        }

        public IActionResult ViewCorporateDetailsModal(int corporateId)
        {
            CorporateVendorContractVWModel vendorTransactions = new CorporateVendorContractVWModel();

            IEnumerable<CorporateDetails> allcorporates = dbCall.GetApprovedCorporates();
            CorporateDetails corporate = allcorporates.FirstOrDefault(v => v.ID == corporateId);

            var contracts = dbCall.GetContractResponseByCorporateID(corporateId);
            var vendorBreakdown = dbCall.GetVendorBreakdownByCorporate(corporateId);


            vendorTransactions.Corporatedetails = corporate;
            vendorTransactions.Contracts = contracts;
            vendorTransactions.VendoBreakDown = vendorBreakdown;
            
            return View("VendorTransactionBreakdown", vendorTransactions);
        }

        public IActionResult CorporateStatusChange(int id, bool status)
        {
            var updated = dbCall.UpdateCorporateStatus(id, status);
            return Json(updated);
        }
    }
}
