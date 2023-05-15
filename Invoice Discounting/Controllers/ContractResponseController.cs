using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Models;
using Invoice_Discounting.Services;
using Invoice_Discounting.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeMapping;
using OfficeOpenXml;

namespace Invoice_Discounting.Controllers
{
    public class ContractResponseController : BaseController
    {
        private readonly IRepository repo;
        private readonly IDatabaseCalls dbCall;

        public ContractResponseController(IRepository repository, IDatabaseCalls databaseCalls)
        {
            repo = repository;
            dbCall = databaseCalls;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Index", "Login", new { errorMsg = "Session Timeout" });
            }
            string vendorEmail = HttpContext.Session.GetString("UserEmail");
            string vendorCode = HttpContext.Session.GetString("VendorId");
            IEnumerable<VendorContractListModel> model = repo.GetVendorContractList(vendorEmail, vendorCode);
            HttpContext.Session.SetComplexData("VendorContractList", model);
            return View(model);
        }

        public IActionResult ContractResponse(int contractId)
        {
            ContractResponseViewModel model = repo.InitiateContractResponse(contractId);

            return View(model);
        }

        [HttpPost]
        //public IActionResult ContractResponse([Bind("ContractDetails,ContractResponse,UdfDetails,SupportingDocument1,SupportingDocument2")]ContractResponseViewModel model)
        public IActionResult ContractResponse(ContractResponseViewModel model)
        {
            model.ContractResponse.VENDORNAME = HttpContext.Session.GetString("UserName");
            model.ContractResponse.VENDOREMAIL = HttpContext.Session.GetString("UserEmail");
            model.ContractResponse.RESPONSESTATUS = "Ongoing";

            bool saved = repo.SaveContractResponse(model);

            if (saved)
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Bid successfully saved. Contract Number: {model.ContractDetails.CONTRACTNUMBER} ",
                    DATECREATED = DateTime.UtcNow

                };
                dbCall.InsertAudit(detail);
                Alert("Bid successfully submitted", NotificationType.success);
            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Bid failed to submit. Contract Number: {model.ContractDetails.CONTRACTNUMBER} ",
                    DATECREATED = DateTime.UtcNow

                };
                dbCall.InsertAudit(detail);
                Alert("Unable to save bid details", NotificationType.error);

            }
            return RedirectToAction("Index");
        }
        public IActionResult GetVendorResponseList(int contractId)
        {
            ContractDetailsViewModel model = new ContractDetailsViewModel();
            model.ResponseList = dbCall.GetContractResponseByContractID(contractId);
            model.Contract = dbCall.GetContractById(contractId);

            HttpContext.Session.SetInt32("ContractId", contractId);
            return View("ContractDetails", model);
        }
        public IActionResult GetVendorResponseById(int responseId)
        {
            var model = repo.GetVendorResponseById(responseId);
            HttpContext.Session.SetComplexData("ResponseDetails", model);
            return PartialView("_VendorResponseSingle", model);
        }
        public IActionResult ViewSupportingDocument1(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("GetVendorResponseList");
            }
            VendorResponseDetails details = HttpContext.Session.GetComplexData<VendorResponseDetails>("ResponseDetails");
            if (details == null)
            {
                details = repo.GetVendorResponseById(id);
            }
            byte[] suppDoc = details.ContractResponse.SUPPORTINGDOCUMENT1;
            string img = Convert.ToBase64String(suppDoc);
            var fnameArray = details.ContractResponse.SUPPORTINGDOC1FILENAME.Split(".");
            var ext = fnameArray[fnameArray.Length - 1].Trim();
            ImageModel model = new ImageModel()
            {
                Image = img,
                Extension = ext,
                Header = "Supporting Document"
            };
            return PartialView("_ViewSupDoc", model);
        }
        public IActionResult ViewSupportingDocument2(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("GetVendorResponseList");
            }
            VendorResponseDetails details = HttpContext.Session.GetComplexData<VendorResponseDetails>("ResponseDetails");
            if (details == null)
            {
                details = repo.GetVendorResponseById(id);
            }
            byte[] suppDoc = details.ContractResponse.SUPPORTINGDOCUMENT2;
            string img = Convert.ToBase64String(suppDoc);
            var fnameArray = details.ContractResponse.SUPPORTINGDOC2FILENAME.Split(".");
            var ext = fnameArray[fnameArray.Length - 1].Trim();
            ImageModel model = new ImageModel()
            {
                Image = img,
                Extension = ext,
                Header = "Supporting Document"
            };
            return PartialView("_ViewSupDoc", model);
        }


        public IActionResult ViewUDFSupportingDocument(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("GetVendorResponseList");
            }
            ContractUDFResponse udfDet = new ContractUDFResponse();
            VendorResponseDetails details = HttpContext.Session.GetComplexData<VendorResponseDetails>("ResponseDetails");
            if (details != null)
            {
                udfDet = details.UdfResponse.Where(u => u.ID == id).FirstOrDefault();
            }
            else
            {
                udfDet = dbCall.GetContractUDFResponseByID(id);
            }
            byte[] suppDoc = udfDet.UPLOADVALUE;
            string img = Convert.ToBase64String(suppDoc);
            var fnameArray = udfDet.UPLOADFILENAME.Split(".");
            var ext = fnameArray[fnameArray.Length - 1].Trim();
            ImageModel model = new ImageModel()
            {
                Image = img,
                Extension = ext,
                Header = udfDet.UDFLABEL
            };
            return PartialView("_ViewSupDoc", model);
        }

        [HttpPost]
        public IActionResult AuthorizeContract(int responseId, string authStatus)
        {
            var AuthEmail = HttpContext.Session.GetString("UserEmail");
            var AuthName = HttpContext.Session.GetString("UserName");
            bool authorize = repo.AuthourizeContract(responseId, authStatus, AuthEmail, AuthName);

            if (authorize)
            {
                Alert("Contract Bid Successfully Authorized", BaseController.NotificationType.success);
            }
            else
            {
                Alert("Unable to authorize contract bid", BaseController.NotificationType.error);
            }
            int contrId = (int)HttpContext.Session.GetInt32("ContractId");
            return RedirectToAction("GetVendorResponseList", new { contractId = contrId });

        }

        public IActionResult GetVendorContractModal(int contractId, string contractStatus)
        {
            string vendorEmail = HttpContext.Session.GetString("UserEmail");
            string vendorCode = HttpContext.Session.GetString("VendorId");
            //Raise Invoice
            IEnumerable<VendorContractListModel> contractList = HttpContext.Session.GetComplexData<IEnumerable<VendorContractListModel>>("VendorContractList");
            if (contractList == null)
            {
                //get the contract list again
                contractList = repo.GetVendorContractList(vendorEmail, vendorCode);
            }
            var model = contractList.Where(c => c.ID == contractId).FirstOrDefault();
            return PartialView("_ContractDetailsAwarded", model);
        }

        [HttpPost]
        //public IActionResult ContractDetailsRedirect([Bind("CONTRACTNUMBER,PONUMBER,CONTRACTNAME,QUALITYSPECIFICATION,DESCRIPTION,PAYMENTTENOR,TIMELINEDAYS,CREATEDDATE,VENDORNAME," +
        //    "VENDORCATEGORY,VENDOREMAIL,OTHERINFORMATION,REQUIREDDOCUMENTS,CREATEDBYNAME,CREATEDBYEMAIL,LASTMODIFIEDBY,LASTMODIFIEDDATE,CORPORATEID,NAMEOFITEM,CORPORATENAME," +
        //    "CONTRACTSTATUS,RESPONSEID,AWARDVENDORNAME")]VendorContractListModel model)

        public IActionResult ContractDetailsRedirect(VendorContractListModel model)

        {
            if (model.CONTRACTSTATUS == "Awarded")
            {
                return RedirectToAction("CreateInvoice", "Invoice", new { contractId = model.ID });
            }
            else //New
            {
                return RedirectToAction("ContractResponse", new { contractId = model.ID });
            }
        }

        [HttpPost]
        //public IActionResult ContractResponseDecined([Bind("ID,CONTRACTNUMBER,PONUMBER,CONTRACTNAME,QUALITYSPECIFICATION,DESCRIPTION,PAYMENTTENOR,TIMELINEDAYS,CREATEDDATE,VENDORNAME," +
        //    "VENDORCATEGORY,VENDOREMAIL,OTHERINFORMATION,REQUIREDDOCUMENTS,CREATEDBYNAME,CREATEDBYEMAIL,LASTMODIFIEDBY,LASTMODIFIEDDATE,CORPORATEID,NAMEOFITEM,CORPORATENAME," +
        //    "CONTRACTSTATUS,RESPONSEID,AWARDVENDORNAME")]VendorContractListModel viewmodel)
        public IActionResult ContractResponseDecined(VendorContractListModel viewmodel)
        {
            ContractResponseViewModel model = new ContractResponseViewModel();
            ContractResponse response = new ContractResponse();
            response.VENDORNAME = HttpContext.Session.GetString("UserName");
            response.VENDOREMAIL = HttpContext.Session.GetString("UserEmail");
            response.CONTRACTID = viewmodel.ID;
            response.RESPONSESTATUS = "Declined";
            model.ContractResponse = response;

            bool saved = repo.SaveContractResponse(model);

            if (saved)
            {
                Alert("Contract was successfully declined", NotificationType.success);
            }
            else
            {
                Alert("Unable to decline contract", NotificationType.error);
            }
            return Json(saved);
        }

        public IActionResult DownloadSupportingDocument1(int id)
        {
            if (id == 0)
            {
                return View("ContractDetails");
            }
            VendorResponseDetails details = repo.GetVendorResponseById(id);
            byte[] suppDoc = details.ContractResponse.SUPPORTINGDOCUMENT1;
            string fileName = details.ContractResponse.SUPPORTINGDOC1FILENAME;
            string contentType = MimeTypes.GetMimeType(fileName);

            string fileDownloadName = $"{details.ContractDetails.CONTRACTNUMBER}_SupportingDoc{fileName}";

            return File(suppDoc, contentType, fileDownloadName);
        }
        public IActionResult DownloadSupportingDocument2(int id)
        {
            if (id == 0)
            {
                return View("ContractDetails");
            }
            VendorResponseDetails details = repo.GetVendorResponseById(id);
            byte[] suppDoc = details.ContractResponse.SUPPORTINGDOCUMENT2;
            string fileName = details.ContractResponse.SUPPORTINGDOC2FILENAME;
            string contentType = MimeTypes.GetMimeType(fileName);

            string fileDownloadName = $"{details.ContractDetails.CONTRACTNUMBER}_SupportingDoc{fileName}";

            return File(suppDoc, contentType, fileDownloadName);
        }
        public IActionResult DownloadUDFDocument(int id, string contractNumber)
        {
            if (id == 0)
            {
                return View("ContractDetails");
            }
            var resp = dbCall.GetContractResponseByID(id);
            ContractUDFResponse details = dbCall.GetContractUDFResponseByID(id);

            var fnameArray = details.UPLOADFILENAME.Split(".");
            var ext = fnameArray[fnameArray.Length - 1].Trim();
            byte[] suppDoc = details.UPLOADVALUE;
            string fileName = details.UPLOADFILENAME;
            string contentType = MimeTypes.GetMimeType(fileName);

            string fileDownloadName = $"{contractNumber}_SupportingDoc{ext}";

            return File(suppDoc, contentType, fileDownloadName);
        }
    }
}
