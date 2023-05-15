using Invoice_Discounting.Models;
using Invoice_Discounting.Models.Request;
using Invoice_Discounting.Services;
using Invoice_Discounting.Utility;
using Invoice_Discounting.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Controllers
{
    public class InvestorController : BaseController
    {
        private readonly IRepository _repo;
        private readonly IDatabaseCalls _dbCall;
        private readonly IConfiguration _config;

        public InvestorController(IRepository repo, IDatabaseCalls dbCall, IConfiguration config)
        {
            _repo = repo;
            _dbCall = dbCall;
            _config = config;

        }


        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Index", "Login", new { errorMsg = "Session Timeout" });
            }
            //Get all Approved Investors and Get all Pending Investors
            var currentuseremail = HttpContext.Session.GetString("UserEmail");
            var model = Enumerable.Empty<InvestorDetails>();

            model = _dbCall.GetApprovedInvestors();

            if (model != null)
            {
                foreach (var investor in model)
                {
                    investor.STATUSBOOL = investor.STATUS.Trim() == "1" ? true : false;
                }
            }
            var pendingModel = _dbCall.GetPendingInvestors(currentuseremail);
            var approvependinginvestor = new InvestorPendingApproveModel();

            approvependinginvestor.investorapproved = model;
            approvependinginvestor.investorpending = pendingModel;

            AuditDetails detail = new AuditDetails()
            {
                USERNAME = HttpContext.Session.GetString("UserName"),
                ACTIVITIES = "Loaded All pending Approved Investors",
                DATECREATED = DateTime.UtcNow

            };
            _dbCall.InsertAudit(detail);

            return View(approvependinginvestor);
        }


        public ActionResult _AddInvestor()
        {
            InvestorViewModel model = new InvestorViewModel();
            var venRandomNo = _repo.GenerateRandomNos();
            List<string> status = new List<string>();
            model._investmentPreferenceList = _dbCall.GetInvestmentPreferenceLists();
            model._investmentRestrictionList = _dbCall.GetInvestmentRestrictionLists();
            model._banklists = _dbCall.GetAllBanksNew();
            InvestorDetails investor = new InvestorDetails();
            investor.UNIQUEINVESTORID = $"INV{venRandomNo}".Trim();
            investor.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
            investor.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
            investor.DATECREATED = DateTime.UtcNow;
            status.Add(Enums.Status.ACTIVE.ToString());
            status.Add(Enums.Status.DISABLED.ToString());
            model.Status = status;
            model.Investor = investor;

            return PartialView("AddNewInvestor", model);
        }

        [HttpPost]
        public ActionResult _AddNewInvestor(InvestorViewModel model)
        {
            var _newRepo = new Repository();
            string password = _newRepo.GenerateReference();  //CreateTempPass(9);
            string hashedPassword = _newRepo.GetHashedPassword(password);

            model._banklists = _dbCall.GetAllBanksNew();
            model._investmentPreferenceList = _dbCall.GetInvestmentPreferenceLists();
            model._investmentRestrictionList = _dbCall.GetInvestmentRestrictionLists();
            var selectedPreference = model._investmentPreferenceList.Find(v => v.ID == model.SelectedInvestmentPreferenceId);
            var selectedRestriction = model._investmentRestrictionList.Find(v => v.ID == model.SelectedInvestmentRestrictionId);
            var selectedBank = model._banklists.Find(b => b.ID == model.SelectedBankId);

            UpdateInvestor investor = new UpdateInvestor();

            investor.UNIQUEINVESTORID = model.Investor.UNIQUEINVESTORID;
            investor.Location = model.Investor.Location;
            investor.userName = model.Investor.userName;
            investor.hashPassword = hashedPassword;
            investor.AccountNo = model.Investor.AccountNo;
            investor.PhoneNumber = model.Investor.PhoneNumber;
            investor.CompanyName = model.Investor.CompanyName;
            investor.InvestmentPreferences = selectedPreference?.InvestmentPreferenceName;
            investor.InvestmentRestrictions = selectedRestriction?.InvestmentRestrictionName;
            investor.Email = model.Investor.Email;
            investor.InvestmentExperienceInYears = model.Investor.InvestmentExperienceInYears;
            investor.InterestRate = model.Investor.InterestRate;
            investor.STATUS = Convert.ToInt32(model.Investor.STATUS);
            investor.BANK = selectedBank?.BankName;
            investor.FundingCapacity = model.Investor.FundingCapacity;
            investor.AccountName = model.Investor.AccountName;
            investor.DATECREATED = model.Investor.DATECREATED;
            investor.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
            investor.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
            //investor.CORPORATEID = (int)HttpContext.Session.GetInt32("corporateId");
            investor.UPDATETYPE = Enums.UpdateTypes.NEW.ToString();
            investor.AUTHORIZERCOMMENT = "";
            investor.AUTHORIZEREMAIL = "";
            investor.AUTHORIZERNAME = "";

            var created = _repo.CreateUpdateInvestor(investor);
            if (created)
            {
                var supplyChainUrl = _config["SupplyChainUrl"];
                SendMailReq mailReq = new SendMailReq()
                {
                    Content = $"<p>Good day {investor.CompanyName},</p><p>You have been created on the Access Bank Supply Chain platform.  Please login <a href={supplyChainUrl}>here</a> with the  credential below</p><p>Username: {investor.userName} <br/> Password: {password}</p><p>Kindly wait for confirmation email before logon</><p> Regards, Supply Chain Platform Admin</p>",
                    CopyAddress = "",
                    From = "no-reply@accessbankplc.com",
                    Subject = "Supply Chain Portal Credential",
                    Recipient = investor.Email,
                    attachment = "",
                    DisplayAsHtml = true,
                    DisplayName = "Access Bank"

                };
                var mailSent = _repo.SendMail(mailReq);


                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Investor successfully created. Investor Name: {investor.CompanyName} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);

                Alert("Investor successfully created, awaiting authorization", NotificationType.success);

            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Unable to create investor Vendor Name: {investor.CompanyName} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);

                Alert("Unable to create Investor", NotificationType.error);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ViewInvestorDetailsModal(int investorId)
        {
            IEnumerable<InvestorDetails> allinvestors = _dbCall.GetApprovedInvestors(investorId);
            InvestorDetails investor = allinvestors.FirstOrDefault(v => v.ID == investorId);
            return PartialView("_investorDetailsdisplay", investor);
        }

        public IActionResult ViewInvestorDetailsApprovalModal(int investorId)
        {
            var currentuseremail = HttpContext.Session.GetString("UserEmail");
            var pending = _dbCall.GetPendingInvestors(currentuseremail).FirstOrDefault(v => v.ID == investorId);
            pending.AUTHORIZERNAME = HttpContext.Session.GetString("UserName");
            pending.AUTHORIZEREMAIL = HttpContext.Session.GetString("UserEmail");

            return PartialView("_investorDetailapproval", pending);
        }

        [HttpPost]
        public ActionResult _Authorize([Bind("ID,AUTHORIZERCOMMENT,AUTHORIZATIONSTATUS,NAME")] InvestorDetailsPending model)
        {
            if (!ModelState.IsValid)
            {
                Alert("Unable to authorized vendor details", NotificationType.error);
                return PartialView("Index");
            }
            AuthorizeInvestor pending = new AuthorizeInvestor();
            pending.AuthName = HttpContext.Session.GetString("UserName");
            pending.AuthEmail = HttpContext.Session.GetString("UserEmail");
            pending.Idt = model.ID;
            pending.AuthComment = model.AUTHORIZERCOMMENT;
            pending.AuthStatus = model.AUTHORIZATIONSTATUS;

            var authorized = _dbCall.AuthorizeInvestor(pending);
            if (authorized)
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Investor successfully authorized. Investor Name: {model.CompanyName} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);
                Alert("Investor details successfully authorized", NotificationType.success);
            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Unable to authorize Vendor. Vendor Name: {model.CompanyName} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);

                Alert("Unable to authorized Investor", NotificationType.error);
            }
            return RedirectToAction("Index");
        }

        public IActionResult InvestorStatusChange(int id, bool status)
        {
            var updated = _dbCall.UpdateInvestorStatus(id, status);
            return Json(updated);
        }

        public ActionResult ModifyInvestor(int id)
        {
            if (id == 0)
            {
                return View("Index");
            }
            IEnumerable<InvestorDetails> allInvestors = _dbCall.GetApprovedInvestors();
            InvestorDetails investor = allInvestors.FirstOrDefault(v => v.ID == id);
            InvestorViewModel model = new InvestorViewModel();
            model._banklists = _dbCall.GetAllBanksNew();
            model._investmentPreferenceList = _dbCall.GetInvestmentPreferenceLists();
            model._investmentRestrictionList = _dbCall.GetInvestmentRestrictionLists();
            var selectedPreference = model._investmentPreferenceList.Find(v => v.InvestmentPreferenceName == investor.InvestmentPreferences);
            var selectedRestriction = model._investmentRestrictionList.Find(v => v.InvestmentRestrictionName == investor.InvestmentRestrictions);
            var selectedBank = model._banklists.Find(b => b.ID == model.SelectedBankId);
            List<string> status = new List<string>();
            investor.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
            investor.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
            investor.InvestmentPreferences = selectedPreference?.InvestmentPreferenceName;
            investor.DATECREATED = DateTime.UtcNow;
            status.Add(Enums.Status.ACTIVE.ToString());
            status.Add(Enums.Status.DISABLED.ToString());
            model.Status = status;
            model.Investor = investor;

            return PartialView("EditInvestor", model);
        }

        [HttpPost]
        public ActionResult _EditInvestor([Bind("Investor")] InvestorViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            UpdateInvestor investor = new UpdateInvestor();
            investor.CompanyName = model.Investor.CompanyName;
            investor.Email = model.Investor.Email;
            investor.AccountNo = model.Investor.AccountNo;
            investor.PhoneNumber = model.Investor.PhoneNumber;
            investor.FundingCapacity = model.Investor.FundingCapacity;
            investor.STATUS = Convert.ToInt32(model.Investor.STATUS);
            investor.Location = model.Investor.Location;
            investor.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
            investor.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
            investor.UPDATETYPE = Enums.UpdateTypes.UPDATE.ToString();
            investor.BANK = model.Investor.BANK;
            investor.InvestmentPreferences = model.Investor.InvestmentPreferences;
            investor.InterestRate = model.Investor.InterestRate;
            investor.InvestmentRestrictions = model.Investor.InvestmentRestrictions;
            investor.InvestmentExperienceInYears = model.Investor.InvestmentExperienceInYears;
            investor.AccountName = model.Investor.AccountName;
            investor.InvestmentRestrictions = model.Investor.InvestmentRestrictions;


            var updated = _repo.CreateUpdateInvestor(investor);

            if (updated)
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Vendor successfully modified. Vendor Name: {investor.CompanyName} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);
                Alert("Investor successfully modified, awaiting authorization", NotificationType.success);



            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Unable to modify vendor. Investor Name: {investor.CompanyName} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);
                Alert("Unable to modify investor", NotificationType.error);

            }
            return RedirectToAction("Index");
        }

        //public ActionResult ModifyInvestor(int id)
        //{
        //    if (id == 0)
        //    {
        //        return View("Index");
        //    }
        //    IEnumerable<InvestorDetails> allInvestors = _dbCall.GetApprovedInvestors();
        //    InvestorDetails investor = allInvestors.FirstOrDefault(v => v.ID == id);
        //    InvestorViewModel model = new InvestorViewModel();
        //    List<string> status = new List<string>();
        //    investor.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
        //    investor.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
        //    investor.DATECREATED = DateTime.UtcNow;
        //    status.Add(Enums.Status.ACTIVE.ToString());
        //    status.Add(Enums.Status.DISABLED.ToString());
        //    model.Status = status;
        //    model.Investor = investor;

        //    return PartialView("EditInvestor", model);
        //}
        public IActionResult ValidateAccount(string accountNo)
        {
            var accountName = _repo.FetchAccountNameByAccountNo(accountNo);

            string jsonString = JsonConvert.SerializeObject(accountName);
            return Json(jsonString);

        }
    }
}
