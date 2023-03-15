using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Controllers
{
    public abstract class BaseController : Controller
    {

        public void Alert(string message, NotificationType notificationType)
        {
            var msg = "swal('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "";
            TempData["message"] = msg;
        }


        public enum NotificationType
        {
            error,
            success,
            warning,
            info
        }

    }
}
