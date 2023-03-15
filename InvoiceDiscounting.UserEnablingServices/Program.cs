using System;
using System.Reflection;
using System.Threading;
using InvoiceDiscounting.BusinessLogic.Service;
using log4net;

namespace InvoiceDiscounting.UserEnablingServices
{
    class Program
    {
        protected static ILog Logger;
        static void Main(string[] args)
        {
            IUserService userRepo = new UserService();
            Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.Name);
            Console.WriteLine("About to call a service that does the user enabling for users locked for 5min and more");

            var resp = userRepo.EnableUser();

            Console.WriteLine("Done enabling users");

        }
    }
}
