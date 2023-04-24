using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Services;
using Microsoft.Extensions.Configuration;

namespace Invoice_Discounting.Controllers
{
    public class AuditController : Controller
    {
        private IDatabaseCalls _dbCall;

        public AuditController(IDatabaseCalls dbCalls)
        {
            _dbCall = dbCalls;
        }


        public IActionResult Index()
        {

            var model = _dbCall.GetAuditDetails();
            return View(model);
        }
    }
}
