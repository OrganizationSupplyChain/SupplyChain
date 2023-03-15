using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Models;
using Invoice_Discounting.Services;
using Invoice_Discounting.Utility;
using Invoice_Discounting.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_Discounting.Controllers
{
    public class ContractController : BaseController
    {
        private readonly IRepository repo;
        private readonly IDatabaseCalls dbCall;

        public ContractController(IRepository repository, IDatabaseCalls databaseCalls)
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
			int corporateId = (int) HttpContext.Session.GetInt32("corporateId");
			var model = dbCall.GetCorporateContractList(corporateId);
            return View("Index", model);
        }
		public ActionResult AddContract()
		{
			ContractViewModel model = new ContractViewModel();
			ContractDetails contract = new ContractDetails();
			List<UDFDetails> udfDetails = new List<UDFDetails>();
			HttpContext.Session.SetComplexData("udfDetails", udfDetails);
			string poRandomNo = repo.GenerateRandomNos();
			string contractRandomNo = repo.GenerateRandomNos();
			contract.CREATEDBYNAME = HttpContext.Session.GetString("UserName");
			contract.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
			contract.CREATEDDATE = DateTime.Now;
			contract.PONUMBER = $"PO{poRandomNo}";
			contract.CONTRACTNUMBER = $"CO{contractRandomNo}";
			var vendorCategory = dbCall.GetCategoryLists().Select(x => new DropdownTextModel() { Value = x.CategoryName, Text = x.CategoryName }).ToList();
			model.Contract = contract;
			model.VendorCategory = vendorCategory;
			model.UdfDetails = udfDetails;
			model.UpdateType = Enums.UpdateTypes.NEW.ToString();

			return View("CreateEdit", model);
		}

		public ActionResult ModifyContract(int id)
		{
			if (id == 0)
			{
				return RedirectToAction("Index");
			}
			ContractViewModel model = new ContractViewModel();
			IEnumerable<ContractDetails> allContracts = dbCall.GetAllContracts();
			ContractDetails contract = allContracts.Where(c => c.ID == id).FirstOrDefault();
			contract.LASTMODIFIEDBY = HttpContext.Session.GetString("UserName");
			contract.LASTMODIFIEDDATE = DateTime.Now;
			var vendorCategory = dbCall.GetCategoryLists().Select(x => new DropdownTextModel() { Value = x.CategoryName, Text = x.CategoryName }).ToList();
			List<UDFDetails> udfDetails = dbCall.GetUdfByContractId(id);
			HttpContext.Session.SetComplexData("udfDetails", udfDetails);
			model.Contract = contract;
			model.VendorCategory = vendorCategory;
			model.UdfDetails = udfDetails;
			model.UpdateType = Enums.UpdateTypes.UPDATE.ToString();

			return View("CreateEdit", model);
		}

		public ActionResult _Details(int id)
		{
			ContractViewModel model = new ContractViewModel();
			IEnumerable<ContractDetails> allContracts = dbCall.GetAllContracts();
			ContractDetails contract = allContracts.Where(c => c.ID == id).FirstOrDefault();
			List<UDFDetails> udfDetails = dbCall.GetUdfByContractId(id);
			model.Contract = contract;
			model.UdfDetails = udfDetails;
			return PartialView("_Details", model);
		}
		
		[HttpPost]
		//public IActionResult CreateEditContract([Bind("Contract,VendorCategory,UdfDetails,UpdateType")] ContractViewModel model)
		public IActionResult CreateEditContract( ContractViewModel model)
        {

           
			model.Contract.CREATEDBYEMAIL = HttpContext.Session.GetString("UserEmail");
			model.Contract.CREATEDBYNAME = HttpContext.Session.GetString("UserName");

			if (HttpContext.Session.GetInt32("corporateId") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			model.Contract.CORPORATEID = (int)HttpContext.Session.GetInt32("corporateId");
			model.UdfDetails = HttpContext.Session.GetComplexData<List<UDFDetails>>("udfDetails");
			if (model.UpdateType == "NEW")
            {				
				bool created = repo.CreateContract(model);

				if (created)
				{
					AuditDetails detail = new AuditDetails()
					{
						USERNAME = HttpContext.Session.GetString("UserName"),
						ACTIVITIES = $"Contract was Successfully created. Contract Name: {model.Contract.CONTRACTNAME} ",
						DATECREATED = DateTime.UtcNow

					};
					dbCall.InsertAudit(detail);
					Alert("Contract successfully created", NotificationType.success);
				}
				else
				{
					AuditDetails detail = new AuditDetails()
					{
						USERNAME = HttpContext.Session.GetString("UserName"),
						ACTIVITIES = $"Failed to create Contract. Contract Name: {model.Contract.CONTRACTNAME} ",
						DATECREATED = DateTime.UtcNow

					};
					dbCall.InsertAudit(detail);
					Alert("Unable to create Contract", NotificationType.error);

				}
				return RedirectToAction("Index");
			}
			else // Update
            {
				bool updated = repo.UpdateContract(model);
				if (updated)
				{
					AuditDetails detail = new AuditDetails()
					{
						USERNAME = HttpContext.Session.GetString("UserName"),
						ACTIVITIES = $"Contract was successfully modifed. Contract ID: {model.Contract.ID} ",
						DATECREATED = DateTime.UtcNow

					};
					dbCall.InsertAudit(detail);
					Alert("Contract successfully modified", NotificationType.success);

				}
				else
				{
					AuditDetails detail = new AuditDetails()
					{
						USERNAME = HttpContext.Session.GetString("UserName"),
						ACTIVITIES = $"Failed to modify contract. Contract ID: {model.Contract.ID} ",
						DATECREATED = DateTime.UtcNow

					};
					dbCall.InsertAudit(detail);
					Alert("Unable to modify Contract", NotificationType.error);
				}
				return RedirectToAction("Index");

			}
		}
		[HttpPost]
		public IActionResult AddUDF(string UdfLabel, string UdfType)
        {
			var udfList = HttpContext.Session.GetComplexData<List<UDFDetails>>("udfDetails");
			UDFDetails udf = new UDFDetails()
			{
				UDFLABEL = UdfLabel,
				UDFTYPE = UdfType,
				ISDELETED = '0'
			};
			udfList.Add(udf);
			//Reset the session
			HttpContext.Session.SetComplexData("udfDetails", udfList);
			return PartialView("_UDF", udfList);
		}

		public IActionResult DeleteUDF(string udfLabel, string udfType, int id)
		{
			var udfList = HttpContext.Session.GetComplexData<List<UDFDetails>>("udfDetails");
			UDFDetails udf = udfList.FirstOrDefault(u => u.UDFLABEL == udfLabel && u.UDFTYPE == udfType);
			udfList.Remove(udf);
			if(id > 0)
            {
				//set value as deleted
				var deleted = dbCall.DeleteUdfById(id);
			}
			//Reset the session
			HttpContext.Session.SetComplexData("udfDetails", udfList);
			return PartialView("_Create", udf);
		}

		//public IActionResult AddNewUDF([Bind("Contract,UdfLabel,UdfType")] AddUDFViewModel udfModel)
		public IActionResult AddNewUDF(AddUDFViewModel udfModel)
        {
			ContractViewModel model = new ContractViewModel();
			var udfList = HttpContext.Session.GetComplexData<List<UDFDetails>>("udfDetails");
			var contractDet = HttpContext.Session.GetComplexData<ContractViewModel>("udfContractDetails");
			if(contractDet == null)
            {
				return View("CreateEdit");
            }
			var vendorCategory = dbCall.GetCategoryLists().Select(x => new DropdownTextModel() { Value = x.CategoryName, Text = x.CategoryName }).ToList();
			contractDet.VendorCategory = vendorCategory;
			UDFDetails udf = new UDFDetails()
			{
				UDFLABEL = udfModel.UdfLabel,
				UDFTYPE =  udfModel.UdfType,
				ISDELETED = '0'
			};
			udfList.Add(udf);
			//Reset the session
			HttpContext.Session.SetComplexData("udfDetails", udfList);
			contractDet.UdfDetails = udfList;
			model = contractDet;
			return View("CreateEdit", model);
		}

		public IActionResult AddContractDetails(  ContractViewModel model)
        {
			return View("CreateEdit", model);
		}

		//public IActionResult AddNewFields([Bind("Contract,VendorCategory,UdfDetails,UpdateType")]  ContractViewModel contractDet)
		public IActionResult AddNewFields( ContractViewModel contractDet)
        {
			AddUDFViewModel model = new AddUDFViewModel();
			model.Contract = contractDet;
			HttpContext.Session.SetComplexData("udfContractDetails", contractDet);
			return PartialView("_AddUDF", model);
		}
	}
}
