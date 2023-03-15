using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Models;
using Invoice_Discounting.Services;
using Invoice_Discounting.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using static Invoice_Discounting.Utility.Enums;

namespace Invoice_Discounting.Controllers
{
	public class RoleController : BaseController
	{
		private readonly IRepository repo;
		private readonly IDatabaseCalls dbCall;
        public RoleController(IRepository repository, IDatabaseCalls databaseCalls)
        {
			repo = repository;
			dbCall = databaseCalls;
		}
		public ActionResult Index()
		{
			if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
			{
				return RedirectToAction("Index", "Login", new { errorMsg = "Session Timeout" });
			}
			int roleId = (int)HttpContext.Session.GetInt32("RoleId");
			RoleViewModel viewModel = new RoleViewModel();
			List<string> role = new List<string>();
			var roles = dbCall.GetRoles(roleId);
			//if (roles != null)
			//{
			//	var distRole = roles.Select(a => a.ROLENAME).ToList();
			//	role.AddRange(distRole);
			//}

			List<string> status = new List<string>();
			status.Add(Status.ACTIVE.ToString());
			status.Add(Status.DISABLED.ToString());
			viewModel.Roles = roles;
			viewModel.Stat = status;
			viewModel.RoleNameList = role;
			viewModel.Modules = repo.GetModuleDDLList();
			return View(viewModel);
		}

		public ActionResult AddRole()
		{
			CreateRoleViewModel model = new CreateRoleViewModel();
			Roles role = new Roles();
			List<string> status = new List<string>();
			status.Add("-- Select -- ");
			status.Add(Status.ACTIVE.ToString());
			status.Add(Status.DISABLED.ToString());
			model.Stat = status;
			role.CREATORNAME = HttpContext.Session.GetString("UserName");
			model.Role = role;
			model.Modules = dbCall.GetModules().Select(x => x.MODULENAME).ToList();

			return PartialView("_Create", model);
		}

		public ActionResult ModifyRole(int id)
		{
            int roleId = (int)HttpContext.Session.GetInt32("RoleId");
			CreateRoleViewModel model = new CreateRoleViewModel();
			var roles = dbCall.GetRoles(roleId);
			model.Role = roles.Where(r => r.ID == id).FirstOrDefault();
			List<string> status = new List<string>();
			status.Add("-- Select -- ");
			status.Add(Status.ACTIVE.ToString());
			status.Add(Status.DISABLED.ToString());
			model.Stat = status;
			model.RoleStatus = model.Role.STATUS == '1' ? Status.ACTIVE.ToString() : Status.DISABLED.ToString();
			model.Modules = dbCall.GetModules().Select(x => x.MODULENAME).ToList();
			return PartialView("EditRole", model);
		}

		public ActionResult _Details(int id)
		{
            int roleId = (int)HttpContext.Session.GetInt32("RoleId");
			Roles model = new Roles();
			var roles = dbCall.GetRoles(roleId);
			model = roles.FirstOrDefault(r => r.ID == id);

			return PartialView(model);
		}
		[HttpPost]
		public ActionResult _Create([Bind("Role,Stat,Modules,RoleStatus")] CreateRoleViewModel model)
		{
            string Modulelist = string.Join(",", model.Modules);
			RoleUpdate role = new RoleUpdate();
			role.RoleStatus = model.Role.STATUS ;
			role.Name = model.Role.ROLENAME;
            role.RoleModules = Modulelist;//model.Role.MODULES;
			role.InitiatorName = HttpContext.Session.GetString("UserName") ; 
			role.InitiatorEmail = HttpContext.Session.GetString("UserEmail") ; 
			role.RoleId = 0;
			var created = repo.ModifyRole(role);
			if(created)
            {
				AuditDetails detail = new AuditDetails()
				{
					USERNAME = HttpContext.Session.GetString("UserName"),
					ACTIVITIES = $"Role was successfully created. Role: {role.Name} ",
					DATECREATED = DateTime.UtcNow

				};
				dbCall.InsertAudit(detail);
				TempData["message"] = "Role successfully created.";
			}
            else
            {
				AuditDetails detail = new AuditDetails()
				{
					USERNAME = HttpContext.Session.GetString("UserName"),
					ACTIVITIES = $"Unable to created Role. Role: {role.Name} ",
					DATECREATED = DateTime.UtcNow

				};
				dbCall.InsertAudit(detail);
				TempData["message"] = "Unable to create role.";
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult _Edit([Bind("Role,Modules")] CreateRoleViewModel model)
		{
            string Modulelist = string.Join(",", model.Modules);
			RoleUpdate role = new RoleUpdate();
			role.RoleStatus = model.Role.STATUS;
			role.Name = model.Role.ROLENAME;
            role.RoleModules = Modulelist; //model.Role.MODULES;
			role.InitiatorName = HttpContext.Session.GetString("UserName");
			role.InitiatorEmail = HttpContext.Session.GetString("UserEmail");
			role.RoleId = model.Role.ID;
			var updated = repo.ModifyRole(role);
			if (updated)
			{
				AuditDetails detail = new AuditDetails()
				{
					USERNAME = HttpContext.Session.GetString("UserName"),
					ACTIVITIES = $"Role was successfully updated. Role: {role.RoleId} ",
					DATECREATED = DateTime.UtcNow

				};
				dbCall.InsertAudit(detail);
				TempData["message"] = "Role successfully updated.";
			}
			else
			{
				AuditDetails detail = new AuditDetails()
				{
					USERNAME = HttpContext.Session.GetString("UserName"),
					ACTIVITIES = $"Unable to modify Role. Role: {role.RoleId} ",
					DATECREATED = DateTime.UtcNow

				};
				dbCall.InsertAudit(detail);
				TempData["message"] = "Unable to modify role.";
			}
			return RedirectToAction("Index");
		}


        public IActionResult ViewRoleDetailsModal(int roleId)
        {
            int rolId = (int)HttpContext.Session.GetInt32("RoleId");
			Roles model = new Roles();
            var roles = dbCall.GetRoles(rolId);
            model = roles.FirstOrDefault(r => r.ID == roleId);
			
            return PartialView("_roleDetailsdisplay", model);
        }

        public ActionResult _AddRole()
        {
            CreateRoleViewModel model = new CreateRoleViewModel();
            Roles role = new Roles();
            List<string> status = new List<string>();
            status.Add("-- Select -- ");
            status.Add(Status.ACTIVE.ToString());
            status.Add(Status.DISABLED.ToString());
            model.Stat = status;
            role.CREATORNAME = HttpContext.Session.GetString("UserName");
            model.Role = role;
            model.Modules = dbCall.GetModules().Select(x => x.MODULENAME).ToList();

           
			

            return PartialView("AddNewRole", model);
        }

        [HttpPost]
        public ActionResult _AddNewRole([Bind("Role,Stat,Modules,RoleStatus")] CreateRoleViewModel model)
        {
            string Modulelist = string.Join(",", model.Modules);
            RoleUpdate role = new RoleUpdate();
            role.RoleStatus = model.Role.STATUS;
            role.Name = model.Role.ROLENAME;
            role.RoleModules = Modulelist;//model.Role.MODULES;
            role.InitiatorName = HttpContext.Session.GetString("UserName");
            role.InitiatorEmail = HttpContext.Session.GetString("UserEmail");
            role.RoleId = 0;
            if (string.IsNullOrEmpty(role.Name))
            {
                Alert("RoleName is Mandatory.", NotificationType.error);
			}
            else
            {
                var created = repo.ModifyRole(role);
                if (created)
                {
                    AuditDetails detail = new AuditDetails()
                    {
                        USERNAME = HttpContext.Session.GetString("UserName"),
                        ACTIVITIES = $"Role was successfully created. Role: {role.Name} ",
                        DATECREATED = DateTime.UtcNow

                    };
                    dbCall.InsertAudit(detail);
                    Alert("Role successfully created.", NotificationType.success);
                    //TempData["message"] = "Role successfully created.";
                }
                else
                {
                    AuditDetails detail = new AuditDetails()
                    {
                        USERNAME = HttpContext.Session.GetString("UserName"),
                        ACTIVITIES = $"Unable to created Role. Role: {role.Name} ",
                        DATECREATED = DateTime.UtcNow

                    };
                    dbCall.InsertAudit(detail);
                    Alert("Unable to create role.", NotificationType.error);
                    //TempData["message"] = "Unable to create role.";
                }
                return RedirectToAction("Index");

			}

			return RedirectToAction("Index");
		}

        public ActionResult ModifyRolenew(int id)
        {
            int roleId = (int)HttpContext.Session.GetInt32("RoleId");
			CreateRoleViewModel model = new CreateRoleViewModel();
            var roles = dbCall.GetRoles(roleId);
            model.Role = roles.Where(r => r.ID == id).FirstOrDefault();
            List<string> status = new List<string>();
            status.Add("-- Select -- ");
            status.Add(Status.ACTIVE.ToString());
            status.Add(Status.DISABLED.ToString());
            model.Stat = status;
            model.RoleStatus = model.Role.STATUS == '1' ? Status.ACTIVE.ToString() : Status.DISABLED.ToString();
            model.Modules = dbCall.GetModules().Select(x => x.MODULENAME).ToList();
            return PartialView("EditRole", model);
        }

        [HttpPost]
        public ActionResult _EditRole([Bind("Role,Modules")] CreateRoleViewModel model)
        {
            string Modulelist = string.Join(",", model.Modules);
            RoleUpdate role = new RoleUpdate();
            role.RoleStatus = model.Role.STATUS;
            role.Name = model.Role.ROLENAME;
            role.RoleModules = Modulelist; //model.Role.MODULES;
            role.InitiatorName = HttpContext.Session.GetString("UserName");
            role.InitiatorEmail = HttpContext.Session.GetString("UserEmail");
            role.RoleId = model.Role.ID;
            var updated = repo.ModifyRole(role);
            if (updated)
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Role was successfully updated. Role: {role.RoleId} ",
                    DATECREATED = DateTime.UtcNow

                };
                dbCall.InsertAudit(detail);
                Alert("Role successfully updated.", NotificationType.success);
            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = HttpContext.Session.GetString("UserName"),
                    ACTIVITIES = $"Unable to modify Role. Role: {role.RoleId} ",
                    DATECREATED = DateTime.UtcNow

                };
                dbCall.InsertAudit(detail);
				Alert("Unable to modify role.", NotificationType.success);
            }
            return RedirectToAction("Index");
        }
	}
}
