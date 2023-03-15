using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Invoice_Discounting.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _config;
        private IRepository _repository;
        private IDatabaseCalls _databaseCalls;
       
      
        public AccountController(IConfiguration config, IRepository repository, IDatabaseCalls databaseCalls)
        {
            _config = config;
            _repository = repository;
            _databaseCalls = databaseCalls;
        }
            
            public  IActionResult Logout()
            {

                var username = HttpContext.Session.GetString("UserLogon");

            //update the device status to zero
            bool updateLogon = _databaseCalls.UpdateLogonStatusbyUsername(username);

            return RedirectToAction("Index", "Login");
            }
        
    }
}
