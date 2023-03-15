using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Models;
using Invoice_Discounting.Models.Response;
using Invoice_Discounting.Services;
using Invoice_Discounting.Utility;
using Invoice_Discounting.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Invoice_Discounting.Controllers
{
    public class VendorCategoryListController : Controller
    {

        private readonly IConfiguration _config;
        private readonly IRepository _repo;
        private readonly IDatabaseCalls _dbCall;

        public VendorCategoryListController(IConfiguration config, IRepository repo, IDatabaseCalls dbCall)
        {
            _config = config;
            _repo = repo;
            _dbCall = dbCall;
        }


        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                return RedirectToAction("Index", "Login", new { errorMsg = "Session Timeout" });
            }

            var model = _dbCall.GetCategoryLists();
            return View(model);
        }
        public ActionResult AddCategory()
        {
            CategoryListViewModel model = new CategoryListViewModel();
            List<string> status = new List<string>();
            CategoryList categorylist = new CategoryList();
            categorylist.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
            categorylist.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
            categorylist.DATECREATED = DateTime.UtcNow;
            status.Add(Enums.Status.ACTIVE.ToString());
            status.Add(Enums.Status.DISABLED.ToString());
            model.Status = status;
            model.categoryList = categorylist;

            return PartialView("_Create", model);
        }

        public ActionResult ModifyCategory(int id)
        {
            CategoryListViewModel model = new CategoryListViewModel();
            List<string> status = new List<string>();
            
            if (id == 0)
            {
                return View("Index");
            }
            IEnumerable<CategoryList> categoryLists  = _dbCall.GetCategoryLists();
            CategoryList category = categoryLists.FirstOrDefault(c => c.ID == id);
            
          
            category.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
            category.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
            category.DATECREATED = DateTime.UtcNow;
            status.Add(Enums.Status.ACTIVE.ToString());
            status.Add(Enums.Status.DISABLED.ToString());
            model.Status = status;
            model.categoryList = category;

            return PartialView("_Edit", model);
        }

        [HttpPost]
        public ActionResult _Create([Bind("categoryList,Status")] CategoryListViewModel model)
        {
            UpdateCategoryList category = new UpdateCategoryList();

            category.CATEGORYNAME = model.categoryList.CategoryName;
            category.CREATEDBYEMAIL = model.categoryList.CREATEDBYEMAIL;
            category.CREATEDBYNAME = model.categoryList.CREATEDBYNAME;
            category.STATUS = model.categoryList.STATUS == "1" ? "A" : "D"; ;
            category.UPDATETYPE = Enums.UpdateTypes.NEW.ToString();
            category.DATECREATED = DateTime.Now;



        var created = _dbCall.UpdateInsertCategoryList(category);
            if (created)
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Vendor Category successfully created. Category Name: {category.CATEGORYNAME} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);
                TempData["message"] = "Category successfully created";
            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Unable to created Vendor. Category Name: {category.CATEGORYNAME} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);
                TempData["message"] = "Unable to create category";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult _Edit([Bind("categoryList,Status")] CategoryListViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            UpdateCategoryList category = new UpdateCategoryList();

            category.ID = model.categoryList.ID;
            category.CATEGORYNAME = model.categoryList.CategoryName;
            category.CREATEDBYEMAIL = model.categoryList.CREATEDBYEMAIL;
            category.CREATEDBYNAME = model.categoryList.CREATEDBYNAME;
            category.STATUS = model.categoryList.STATUS;
            category.UPDATETYPE = Enums.UpdateTypes.UPDATE.ToString();
          
            var updated = _dbCall.UpdateInsertCategoryList(category);

            if (updated)
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Vendor Category successfully modified. Category Name: {category.CATEGORYNAME} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);
                TempData["message"] = "Category successfully modified";
            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Unable to modify Vendor Category. Category Name: {category.CATEGORYNAME} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbCall.InsertAudit(detail);
                TempData["message"] = "Unable to modify Category";
            }
            return RedirectToAction("Index");
        }
    }
}
