using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Invoice_Discounting.Models;
using Invoice_Discounting.Services;
using Invoice_Discounting.Utility;
using Invoice_Discounting.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;

namespace Invoice_Discounting.Controllers
{
    public class VendorBulkUploadController : Controller
    {
        private IConfiguration _config;
        private IDatabaseCalls _dbcall;

        public VendorBulkUploadController(IConfiguration config, IDatabaseCalls dbcalls)
        {
            _config = config;
            _dbcall = dbcalls;
        }

        public IActionResult Index()
        {

            return View();
        }

        public ActionResult Auth(int id)
        {
            var pending = _dbcall.GetPendingBulkVendors().FirstOrDefault(v => v.ID == id);
            pending.AUTHORIZERNAME = HttpContext.Session.GetString("UserName");
            pending.AUTHORIZEREMAIL = HttpContext.Session.GetString("UserEmail");

            return PartialView("_Authorize", pending);
        }

        [HttpPost]
        public ActionResult _Authorize([Bind("ID,AUTHORIZERCOMMENT,AUTHORIZATIONSTATUS")]VendorBatchDetailsPending model)
        {
            if (!ModelState.IsValid)
            {
                TempData["authMessage"] = "Unable to authorized vendor details";
                return PartialView("Index");
            }
            AuthorizeBulkVendor pending = new AuthorizeBulkVendor();
            pending.AuthName = HttpContext.Session.GetString("UserName");
            pending.AuthEmail = HttpContext.Session.GetString("UserEmail");
            pending.Idt = model.ID;
            pending.AuthComment = model.AUTHORIZERCOMMENT;
            pending.AuthStatus = model.AUTHORIZATIONSTATUS;

            var authorized = _dbcall.AuthorizeBulkVendor(pending);
            if (authorized)
            {
                TempData["authMessage"] = "Vendor details successfully authorized";
            }
            else
            {
                TempData["authMessage"] = "Unable to authorized Vendor";
            }
            return RedirectToAction("AuthorizeBulkVendor");
        }
        public ActionResult AuthorizeBulkVendor()
        {
            var model = _dbcall.GetPendingBulkVendors();
            return View(model);
        }

        public IActionResult ViewUploadedExcel(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("AuthorizeBulkVendor");
            }
            var details = _dbcall.GetPendingBatchVendor(id);
            byte[] dataAsBytes = details.vendorbulk;
            Object resp = new ByteConverter().ByteArrayToObject(dataAsBytes);
            
            return PartialView("_ViewExcelDoc", resp);
        }

        public IActionResult _Create([Bind("File,_cateorylist,vendorbulk,Vendor,Status,SelectedCategoryId,Category,DefaultCategory")]VendorViewModel vvm)
        {
            try
            {
                UpdateVendorBulk vendorBulk = new UpdateVendorBulk();
                var list = new List<VendorDetails>();
                using (var stream = new MemoryStream())
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    vvm.File.CopyToAsync(stream);
                    // await vvm.File.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowcount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowcount; row++)
                        {
                            list.Add(new VendorDetails()
                            {
                                NAME = worksheet.Cells[row, 1].Value.ToString().Trim(),
                                PHONENO = worksheet.Cells[row, 2].Value.ToString().Trim(),
                                CATEGORY = worksheet.Cells[row, 3].Value.ToString().Trim(),
                                ACCOUNTNO = worksheet.Cells[row, 4].Value.ToString().Trim(),
                                BANK = worksheet.Cells[row, 5].Value.ToString().Trim(),
                                ADDRESS = worksheet.Cells[row, 6].Value.ToString().Trim(),
                                TIN_RC = worksheet.Cells[row, 7].Value.ToString().Trim()
                            });
                        }
                    }
                }

                byte[] dataAsBytes = new ByteConverter().ObjectToByteArray(list);

                vendorBulk.vendorbulk = dataAsBytes;
                vendorBulk.STATUS = vvm.Vendor.STATUS;
                vendorBulk.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
                vendorBulk.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
                vendorBulk.DATECREATED = DateTime.UtcNow;

                var created = _dbcall.InsertVendorBulk(vendorBulk);
                if (created)
                {
                    AuditDetails detail = new AuditDetails()
                    {
                        USERNAME = HttpContext.Session.GetString("UserName"),
                        ACTIVITIES = $"Vendor Bulk Upload successfully created.",
                        DATECREATED = DateTime.UtcNow

                    };
                    _dbcall.InsertAudit(detail);
                    TempData["message"] = "Bulk Upload successfully created, awaiting authorization";
                }
                else
                {
                    AuditDetails detail = new AuditDetails()
                    {
                        USERNAME = HttpContext.Session.GetString("UserName"),
                        ACTIVITIES = $"Vendor Bulk Upload failed. ",
                        DATECREATED = DateTime.UtcNow

                    };
                    _dbcall.InsertAudit(detail);
                    TempData["message"] = "Unable to Bulk Upload";
                }
                


            }
            catch (InvalidDataException ex)
            {
                TempData["message"] = "Invalid File Uploaded. Kindly upload an excel file"; //ex.Message;
            }

            return RedirectToAction("Index");

            //Object resp = ByteArrayToObject(dataAsBytes);


            //return list;
        }

        //// Convert an object to a byte array
        //private byte[] ObjectToByteArray(object obj)
        //{
        //    if (obj == null)
        //        return null;
        //    BinaryFormatter bf = new BinaryFormatter();
        //    MemoryStream ms = new MemoryStream();
        //    bf.Serialize(ms, obj);
        //    return ms.ToArray();
        //}

        //// Convert a byte array to an Object
        //private Object ByteArrayToObject(byte[] arrBytes)
        //{
        //    MemoryStream memStream = new MemoryStream();
        //    BinaryFormatter binForm = new BinaryFormatter();
        //    memStream.Write(arrBytes, 0, arrBytes.Length);
        //    memStream.Seek(0, SeekOrigin.Begin);
        //    Object obj = (Object)binForm.Deserialize(memStream);
        //    return obj;
        //}
    }




}
