using Invoice_Discounting.Models;
using Invoice_Discounting.Services;
using Invoice_Discounting.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using static Invoice_Discounting.Utility.Enums;
using Microsoft.Extensions.Configuration;

namespace Invoice_Discounting.Controllers
{
    public class InvoiceController : BaseController
    {
        private readonly IRepository _repo;
        private readonly IDatabaseCalls _dbCall;
        private readonly IConfiguration _config;

        public InvoiceController(IRepository repository, IDatabaseCalls databaseCalls, IConfiguration config)
        {
            _repo = repository;
            _dbCall = databaseCalls;
            _config = config;
        }
        public IActionResult Index()
        {
            var invoicevendormodel = new InvoiceVendorViewModel();
       

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Index", "Login", new { errorMsg = "Session Timeout" });
            }
            string email = HttpContext.Session.GetString("UserEmail");
            InvoiceVendorViewModel model = _repo.GetVendorInvoiceDetailsByEmail(email);
            return View(model);
        }

        public IActionResult CorporateIndex()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Index", "Login", new { errorMsg = "Session Timeout" });
            }

            CorporateInvoiceViewModel model = new CorporateInvoiceViewModel();
            int corporateId = (int) HttpContext.Session.GetInt32("corporateId");
            var availableLimit = _dbCall.GetApprovedCorporates().FirstOrDefault(x => x.ID == corporateId).AVAILABLELINEOFCREDIT;
            model.CorporateAvailableLine = availableLimit;
            IEnumerable<InvoiceList> invoices = _dbCall.GetInvoiceListByCorporate(corporateId);
            IEnumerable<RecourseFactoring> recourseFactorings = _dbCall.GetRecourseFactoringByCorporateId(corporateId);
            model.InvoiceList = invoices;
            model.RecourseFactoringList = recourseFactorings;
            return View(model);
        }
        //public IActionResult CreateInvoice(int contractId)
        //{
        //    string email = HttpContext.Session.GetString("UserEmail");
        //    string discType = DiscountingType.INVOICEDISCOUNTING.ToString();
        //    string termsAndConditions = _config["TermsAndCondition"];
        //    InvoiceViewModel model = _repo.InitiateCreateInvoice(email, contractId, discType);
        //    model.TermsAndConditions = termsAndConditions;
        //    model.Banks = _dbCall.GetAllBanks();
        //    model.Items.Add(new InvoiceItem());
        //    return View(model);
        //}

        public IActionResult CreateInvoice(int contractId)
        { 
            var email = HttpContext.Session.GetString("UserEmail");
            var discType = DiscountingType.INVOICEDISCOUNTING.ToString();
            var termsAndConditions = _config["TermsAndCondition"];
            var contractDetails = _dbCall.GetContractById(contractId);
            var model = _repo.InitiateCreateInvoice(email, contractId, discType);
            if (contractDetails != null)
            {
                model.InvoiceDetails.totalexcludingvat = contractDetails.ContractAmount;
                model.totalexcludingvat = contractDetails.ContractAmount.ToString("#,###");
                model.InvoiceDetails.vatrate = _config["VAT"].ToString();
                decimal vatAmount = (Decimal.Divide(decimal.Parse(model.InvoiceDetails.vatrate), 100M)) * contractDetails.ContractAmount;
                decimal totalIncludingVat = vatAmount + contractDetails.ContractAmount;
                model.totalincludingvat = totalIncludingVat.ToString("#,###");
                model.InvoiceDetails.totalincludingvat = totalIncludingVat;

            }
            model.TermsAndConditions = termsAndConditions;
            model.Banks = _dbCall.GetAllBanks();
            model.Items.Add(new InvoiceItem());
            return View(model);

        }

        [HttpPost]
        public IActionResult CreateInvoice([Bind("InvoiceDetails,LoanDetails,Items,requestdiscounting,acceptLoanTerms")]InvoiceViewModel viewModel)
        {
            string email = HttpContext.Session.GetString("UserEmail");
            int corporateId = (int) HttpContext.Session.GetInt32("corporateId");
            viewModel.InvoiceDetails.vendoremail = email;
            viewModel.InvoiceDetails.CORPORATEID = corporateId;

            // By default set autorepayment as true for now
            viewModel.InvoiceDetails.ISAUTOREPAYMENT = 1; 
            bool invoiceCreated = _repo.CreateInvoice(viewModel);
            if(invoiceCreated)
            {
                //Success message
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Invoice successfully created. Invoice Number: {viewModel.InvoiceDetails.invoicenumber}",
                    DATECREATED = DateTime.UtcNow
                };
                _dbCall.InsertAudit(detail);
                
                Alert("Invoice successfully created", NotificationType.success);
            }
            else
            {
                //failure message
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = "Unable to create Invoice",
                    DATECREATED = DateTime.UtcNow
                };
                _dbCall.InsertAudit(detail);
                Alert("Unable to create Invoice", NotificationType.error);
            }
            return RedirectToAction("Index", "ContractResponse");
        }
        public IActionResult RequestDiscounting(int contractId, string vendorAccountNo, string vendorEmail)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInvoiceItem([Bind("Items")] InvoiceViewModel invoiceModel)
        {
            invoiceModel.Items.Add(new InvoiceItem());
            return PartialView("_InvoiceItems", invoiceModel);
        }

        [HttpPost]
        //public IActionResult ValidateInvoiceDiscounting( InvoiceViewModel invoiceModel)
        public IActionResult ValidateInvoiceDiscounting([Bind("InvoiceDetails, LoanDetails,InterestRate,FeesRate")] InvoiceViewModel invoiceModel)
        { 
            ValidateDiscountingModel validateResponse = _repo.ValidateDiscountingRequest(invoiceModel.InterestRate, invoiceModel.InvoiceDetails.accountnumber, invoiceModel.InvoiceDetails.totalincludingvat, invoiceModel.InvoiceDetails.days, invoiceModel.FeesRate);

            string jsonString = JsonConvert.SerializeObject(validateResponse);
            return Json(jsonString);

        }
        
        public IActionResult AuthorizeInvoice(int invoiceId)
        {
            return View();
        }

        public IActionResult GetVendorInvoiceModal(int invoiceId)
        {
            InvoiceViewModel invoiceDetails = _repo.GetInvoiceDetails(invoiceId);
            
            return PartialView("_VendorInvoiceDetails", invoiceDetails);
        }

        public IActionResult GetCorporateInvoiceModal(int invoiceId)
        {
            InvoiceViewModel invoiceDetails = _repo.GetInvoiceDetails(invoiceId);
            invoiceDetails.InvoiceDetails.invoicedate = invoiceDetails.InvoiceDetails.invoicedate == null ? invoiceDetails.InvoiceDetails.invoicedate : ((DateTime)invoiceDetails.InvoiceDetails.invoicedate).AddDays(invoiceDetails.InvoiceDetails.days);

            return PartialView("_CorporateInvoiceDetail", invoiceDetails);
        }

        [HttpPost]
        //public IActionResult ApproveInvoice( InvoiceViewModel model)
        public IActionResult ApproveInvoice([Bind("InvoiceDetails")] InvoiceViewModel model)
        {
            model.InvoiceDetails.AUTHORIZEREMAIL = HttpContext.Session.GetString("UserEmail");
            model.InvoiceDetails.AUTHORIZERNAME = HttpContext.Session.GetString("UserName");

            var authorized = _repo.AuthorizeInvoice(model.InvoiceDetails, InvoiceAuthorizationStatus.COMPLETED.ToString());
            if (authorized)
            {
                Alert("Invoice successfully authorized", NotificationType.success);                
            }
            else
            {
                Alert("Unable to authorize Invoice. Please try again later.", NotificationType.error);
            }

            return Json(authorized);
        }
        //public IActionResult RejectInvoice( InvoiceViewModel model)
        public IActionResult RejectInvoice([Bind("InvoiceDetails")] InvoiceViewModel model)
        {
            model.InvoiceDetails.AUTHORIZEREMAIL = HttpContext.Session.GetString("UserEmail");
            model.InvoiceDetails.AUTHORIZERNAME = HttpContext.Session.GetString("UserName");


            var authorized = _repo.AuthorizeInvoice(model.InvoiceDetails, InvoiceAuthorizationStatus.REJECTED.ToString());
            if(authorized)
            {
                 Alert("Invoice successfully authorized", NotificationType.success);
            }
            else
            {
                Alert("Unable to authorize Invoice. Please try again later.", NotificationType.error);
            }
            
            return Json(authorized);
        }
        public IActionResult AddRecourseFactoring()
        {
            RecourseFactorinViewModel model = new RecourseFactorinViewModel();
            int corporateId = (int)HttpContext.Session.GetInt32("corporateId");

            var corporateDet = _dbCall.GetApprovedCorporates().Where(x =>  x.ID == corporateId).FirstOrDefault();

            //Get List of completed invoices with no loan
            var invoiceList = _dbCall.GetInvoicesWithNoLoan(corporateId).Select(x => new DropdownTextModel() { Value = x.id.ToString(), Text = x.invoicenumber }).ToList();
            RecourseFactoring recourseFactoring = new RecourseFactoring();
            recourseFactoring.disbursementDate = DateTime.Now.Date;
            model.DisbursementDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            model.RecourseFDetails = recourseFactoring;
            model.InvoiceList = invoiceList;
            model.CorporateAvailableLimit = corporateDet == null ? 0 : corporateDet.AVAILABLELINEOFCREDIT;
            //Load bank list  ***

            return View("RecourseFactoring", model);
        }
        [HttpPost]
        //public IActionResult AddNewRecourseFactoring( RecourseFactorinViewModel model)
        public IActionResult AddNewRecourseFactoring([Bind("RecourseFDetails,CorporateLoanDetails,InvoiceList,CorporateAvailableLimit,totalamount")] RecourseFactorinViewModel model)
        {
            int corporateId = (int)HttpContext.Session.GetInt32("corporateId");
            model.RecourseFDetails.corporateid = corporateId;
            model.RecourseFDetails.totalamount = decimal.Parse(model.totalamount.Replace(",", ""));
            //save
            var saveResponse = _repo.SaveSingleRecourseFactoring(model);
            if (saveResponse ==  "")
            {
                //success message
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = "Single Recourse Factoring successfully requested",
                    DATECREATED = DateTime.UtcNow
                };
                _dbCall.InsertAudit(detail);
                Alert("Recourse Factoring successfully requested", NotificationType.success);

            }
            else
            {
                // error message
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = "Unable to request single Recourse Factoring",
                    DATECREATED = DateTime.UtcNow
                };
                _dbCall.InsertAudit(detail);
                Alert(saveResponse, NotificationType.error);
            }

            return RedirectToAction("AddRecourseFactoring");
        }

        public IActionResult AccessRepIndex()
        {
            InvoiceViewOnlyViewModel model = new InvoiceViewOnlyViewModel();
            IEnumerable<InvoiceList> invoices = _dbCall.GetAllInvoiceList();
            IEnumerable<InvoiceLoan> invoiceDiscounting = _dbCall.GetAllInvoiceLoan();
            IEnumerable<RecourseFactoring> reverseFactoring = _dbCall.GetAllRecourseFactoring();

            model.InvoiceDetails = invoices;
            model.InvoiceDiscounting = invoiceDiscounting;
            model.ReverseFactoring = reverseFactoring;
            model.InvoiceDiscountingGL = _config["AccountingEntries:AccessBankPoolAccount"];

            return View(model);
        }

        public IActionResult GetInvoiceDiscountingById(int invoiceId)
        {
            string accessPostingGL = _config["AccountingEntries:AccessBankPoolAccount"];
            InvoiceDiscountingVM model = _dbCall.GetAccessRepInvoiceDiscByInvoiceId(invoiceId);
            model.GL = accessPostingGL;

            return PartialView("_InvoiceDiscountingDetails", model);
        }

        public IActionResult GetReverseFactoringById(int invoiceId)
        {
            string accessPostingGL = _config["AccountingEntries:AccessBankPoolAccount"];
            ReverseFactoringVM model = _dbCall.GetAccessRepReverseFactByInvoiceId(invoiceId);
            model.GL = accessPostingGL;

            return PartialView("_ReverseFactoringDetails", model);
        }

        public IActionResult GetInvoiceDetailsByID(int invoiceId)
        {
            ReverseFactoringContractInvoice invoiceDet = _repo.GetReverseFactoringInvoiceById(invoiceId);
            string invoiceJson = JsonConvert.SerializeObject(invoiceDet);
            return Json(invoiceJson);
        }

        public IActionResult GetAccountDetailsByAccountNo(string accountNo)
        {
            var accountDet = _repo.GetAccountDetByAccountNo(accountNo);
            string accountJson = JsonConvert.SerializeObject(accountDet);
            return Json(accountJson);
        }

        public IActionResult ValidateAccount(string accountNo)
        {
            var accountName = _repo.FetchAccountNameByAccountNo(accountNo);

            string jsonString = JsonConvert.SerializeObject(accountName);
            return Json(jsonString);

        }

        public IActionResult ModifyInvoice(int id)
        {
            InvoiceViewModel model = _repo.GetInvoiceDetails(id);
            string termsAndConditions = _config["TermsAndCondition"];
            InvoiceLoan loanDet = _dbCall.GetInvoiceLoanByInvoiceId(id);
            model.LoanDetails = loanDet;
            model.requestdiscounting = model.InvoiceDetails.requestdiscounting == 1 ? true : false;
            model.totalexcludingvat = model.InvoiceDetails.totalexcludingvat.ToString("N2");
            model.totalincludingvat = model.InvoiceDetails.totalincludingvat.ToString("N2");
            model.TermsAndConditions = termsAndConditions;
            model.Banks = _dbCall.GetAllBanks();
            // get corporateDetails
            ContractDetails contract = _dbCall.GetContractById(model.InvoiceDetails.contractid);
            CorporateDetails corporate = _dbCall.GetApprovedCorporates().Where(c => c.ID == contract.CORPORATEID).FirstOrDefault();
            model.InterestRate = corporate.INTERESTRATE;
            model.FeesRate = corporate.FEESRATE;
            return View("CreateInvoice", model);
        }
        public IActionResult CreateExternalInvoice()
        {
            string uniqueVendorId = HttpContext.Session.GetString("VendorId");
            string discType = DiscountingType.INVOICEDISCOUNTING.ToString();
            string termsAndConditions = _config["TermsAndCondition"];
            InvoiceViewModel model = _repo.InitiateCreateExternalInvoice(uniqueVendorId, discType);
            model.TermsAndConditions = termsAndConditions;
            model.Banks = _dbCall.GetAllBanks();
            model.Items.Add(new InvoiceItem());
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateExternalInvoice(InvoiceViewModel viewModel)
        {
            string email = HttpContext.Session.GetString("UserEmail");
            int corporateId = (int)HttpContext.Session.GetInt32("corporateId");
            viewModel.InvoiceDetails.vendoremail = email;
            viewModel.InvoiceDetails.CORPORATEID = corporateId;


            // By default set autorepayment as true for now
            viewModel.InvoiceDetails.ISAUTOREPAYMENT = 1;
            bool invoiceCreated = _repo.CreateInvoice(viewModel);
            if (invoiceCreated)
            {
                //Success message
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Invoice successfully created. Invoice Number: {viewModel.InvoiceDetails.invoicenumber}",
                    DATECREATED = DateTime.UtcNow
                };
                _dbCall.InsertAudit(detail);

                Alert("Invoice successfully created", NotificationType.success);
            }
            else
            {
                //failure message
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = "Unable to create Invoice",
                    DATECREATED = DateTime.UtcNow
                };
                _dbCall.InsertAudit(detail);
                Alert("Unable to create Invoice", NotificationType.error);
            }
            return RedirectToAction("Index", "ContractResponse");
        }

        public IActionResult ViewSupportingDocument1(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("CorporateIndex");
            }

            ContractInvoice invoiceDetails = _dbCall.GetInvoiceById(id);
            byte[] suppDoc = invoiceDetails.SUPPORTINGDOCUMENT1;
            string img = Convert.ToBase64String(suppDoc);
            var fnameArray = invoiceDetails.SUPPORTINGDOC1FILENAME.Split(".");
            var ext = fnameArray[fnameArray.Length - 1].Trim();
            ImageModel model = new ImageModel()
            {
                Image = img,
                Extension = ext,
                Header = "Uploaded Invoice"
            };
            return PartialView("_ViewSupDoc", model);
        }
        public IActionResult ViewSupportingDocument2(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("CorporateIndex");
            }
            ContractInvoice invoiceDetails = _dbCall.GetInvoiceById(id);
            
            byte[] suppDoc = invoiceDetails.SUPPORTINGDOCUMENT2;
            string img = Convert.ToBase64String(suppDoc);
            var fnameArray = invoiceDetails.SUPPORTINGDOC2FILENAME.Split(".");
            var ext = fnameArray[fnameArray.Length - 1].Trim();
            ImageModel model = new ImageModel()
            {
                Image = img,
                Extension = ext,
                Header = "Uploaded Invoice"
            };
            return PartialView("_ViewSupDoc", model);
        }

        public IActionResult DownloadSupportingDocument1(int id)
        {
            if (id == 0)
            {
                return View("CorporateIndex");
            }
            ContractInvoice details = _dbCall.GetInvoiceById(id);
            byte[] suppDoc = details.SUPPORTINGDOCUMENT1;
            string fileName = details.SUPPORTINGDOC1FILENAME;
            string contentType = MimeTypes.GetMimeType(fileName);

            string fileDownloadName = $"{details.contractnumber}_Invoice{fileName}";

            return File(suppDoc, contentType, fileDownloadName);
        }
        public IActionResult DownloadSupportingDocument2(int id)
        {
            if (id == 0)
            {
                return View("CorporateIndex");
            }
            ContractInvoice details = _dbCall.GetInvoiceById(id);
            byte[] suppDoc = details.SUPPORTINGDOCUMENT2;
            string fileName = details.SUPPORTINGDOC2FILENAME;
            string contentType = MimeTypes.GetMimeType(fileName);

            string fileDownloadName = $"{details.contractnumber}_Invoice2{fileName}";


            return File(suppDoc, contentType, fileDownloadName);
        }
    }
}
