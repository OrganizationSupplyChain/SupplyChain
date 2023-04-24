using Invoice_Discounting.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace InvoiceDiscounting.RepaymentService
{
    class Program
    {
        //public readonly IRepository repo;
        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public IConfiguration config;
        public Program(IConfiguration configuration)
        {
            config = configuration;
        }
        static void Main(string[] args)
         {

            //setup our Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IRepository, Repository>()
               .BuildServiceProvider();

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appSettings.json");
            IConfiguration configuration = configurationBuilder.Build();

            var dbCalls = new DatabaseCalls(configuration);
            var apiImpl = new ApiImplementation(configuration);
            var repo = new Repository(configuration, dbCalls, apiImpl, null);

            //process both reverse factoring and Invoice discounting repayents in parallel
            Parallel.Invoke(
                () => repo.ProcessInvoiceDiscountingRepayment(),
                () => repo.ProcessReverseFactoringRepayment());
            
        }
    }
}
