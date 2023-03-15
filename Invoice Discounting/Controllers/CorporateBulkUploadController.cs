using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Invoice_Discounting.Models;
using Invoice_Discounting.Models.Response;
using Invoice_Discounting.Services;
using Invoice_Discounting.Utility;
using Invoice_Discounting.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;

namespace Invoice_Discounting.Controllers
{
    public class CorporateBulkUploadController : Controller
    {
        private IConfiguration _config;
        private readonly IDatabaseCalls _dbCall;

        public CorporateBulkUploadController(IConfiguration config, IDatabaseCalls dbCall)
        {
            _config = config;
            _dbCall = dbCall;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Auth(int id)
        {
            var pending = _dbCall.GetPendingBulkCorporate().FirstOrDefault(v => v.ID == id);
            if (pending == null) return null;
            pending.AUTHORIZERNAME = HttpContext.Session.GetString("UserName");
            pending.AUTHORIZEREMAIL = HttpContext.Session.GetString("UserEmail");

            var detail = new AuditDetails()
            {
                USERNAME = HttpContext.Session.GetString("UserName"),
                ACTIVITIES = "Loaded All pending Bulk Corporate for approval",
                DATECREATED = DateTime.UtcNow
            };
            _dbCall.InsertAudit(detail);

            return PartialView("_Authorize", pending);

        }

        [HttpPost]
        public ActionResult _Authorize([Bind("ID,corporatebulk,DATECREATED,AUTHORIZATIONSTATUS,DATEAUTHORIZED,CREATEDBYNAME,AUTHORIZERNAME,AUTHORIZEREMAIL,AUTHORIZERCOMMENT")]CorporateBatchDetailsPending model)
        {
            if (!ModelState.IsValid)
            {
                TempData["authMessage"] = "Unable to authorized Corporate details";
                return PartialView("Index");
            }
            AuthorizeBulkCorporate pending = new AuthorizeBulkCorporate();
            pending.AuthName = HttpContext.Session.GetString("UserName");
            pending.AuthEmail = HttpContext.Session.GetString("UserEmail");
            pending.Idt = model.ID;
            pending.AuthComment = model.AUTHORIZERCOMMENT;
            pending.AuthStatus = model.AUTHORIZATIONSTATUS;

            var authorized = _dbCall.AuthorizeBulkCorporate(pending);
            if (authorized)
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = pending.AuthName,
                    ACTIVITIES = $"Bulk Corporate was Successfully Authorized. ID: {model.ID}",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);
                TempData["authMessage"] = "Corporate details successfully authorized";
            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = pending.AuthName,
                    ACTIVITIES = $"Bulk Corporate was Successfully Rejected. ID: {model.ID} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);
                TempData["authMessage"] = "Unable to Authorize Corporate";
            }
            return RedirectToAction("AuthorizeBulkCorporate");
        }

        public ActionResult AuthorizeBulkCorporate()
        {
            var model = _dbCall.GetPendingBulkCorporate();
            return View(model);
        }

        public IActionResult ViewUploadedExcel(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("AuthorizeBulkCorporate");
            }
            var details = _dbCall.GetPendingBatchCorporate(id);
            byte[] dataAsBytes = details.corporatebulk;
            Object resp = new ByteConverter().ByteArrayToObject(dataAsBytes);

            AuditDetails detail = new AuditDetails()
            {
                USERNAME = HttpContext.Session.GetString("UserName"),
                ACTIVITIES = $"Bulk corporate was viewed. ID: {id} ",
                DATECREATED = DateTime.UtcNow

            };
            _dbCall.InsertAudit(detail);

            return PartialView("_ViewExcelCorpDoc", resp);
        }

        public IActionResult _Create(CorporateViewModel corpVm)
        {
            UpdateCorporateBulk corporateBulk = new UpdateCorporateBulk();
            try
            {
                
                var list = new List<CorporateDetails>();
                using (var stream = new MemoryStream())
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    corpVm.File.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowcount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowcount; row++)
                        {
                            list.Add(new CorporateDetails()
                            {
                                CORPORATENAME = worksheet.Cells[row, 1].Value.ToString()?.Trim(),
                                PRINCIPALEMAIL = worksheet.Cells[row, 2].Value.ToString()?.Trim(),
                                PRINCIPALACCOUNTNO = worksheet.Cells[row, 3].Value.ToString()?.Trim(),
                                PRINCIPALPHONENO = worksheet.Cells[row, 4].Value.ToString()?.Trim(),
                                CREATEDBYNAME = worksheet.Cells[row, 5].Value.ToString()?.Trim()

                            });
                        }
                    }
                }

                byte[] dataAsBytes = new ByteConverter().ObjectToByteArray(list);

                corporateBulk.corporatebulk = dataAsBytes;
                corporateBulk.STATUS = corpVm.Corporate.STATUS;
                corporateBulk.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
                corporateBulk.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
                corporateBulk.DATECREATED = DateTime.UtcNow;

                var created = _dbCall.InsertCorporateBulk(corporateBulk);
                if (created)
                {
                    AuditDetails detail = new AuditDetails()
                    {
                        USERNAME = corporateBulk.CREATEDBYNAME,
                        ACTIVITIES = $"Bulk Corporate was Successfully uploaded ",
                        DATECREATED = DateTime.UtcNow

                    };
                    _dbCall.InsertAudit(detail);
                    TempData["message"] = "Bulk Upload successfully created, awaiting authorization";
                }
                else
                {
                    var detail = new AuditDetails()
                    {
                        USERNAME = corporateBulk.CREATEDBYNAME,
                        ACTIVITIES = "Bulk Corporate failed during upload ",
                        DATECREATED = DateTime.UtcNow

                    };
                    _dbCall.InsertAudit(detail);
                    TempData["message"] = "Unable to perform Bulk Upload";
                }
            }
            catch (InvalidDataException ex)
            {
                var detail = new AuditDetails()
                {
                    USERNAME = corporateBulk.CREATEDBYNAME,
                    ACTIVITIES = "An attempt to load an invalid excel file ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);
                TempData["message"] = "Invalid File Uploaded. Kindly upload an excel file";
            }
           
            return RedirectToAction("Index");

            
        }
    }
}
