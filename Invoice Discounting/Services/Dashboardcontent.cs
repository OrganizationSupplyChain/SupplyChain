using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice_Discounting.Models;
using Invoice_Discounting.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;

namespace Invoice_Discounting.Services
{
    public class Dashboardcontent : ControllerBase, IDashboardcontent
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly IConfiguration _config;
        private IDatabaseCalls _dbCalls;
        private IApiImplementation _apiImpl;
        private IRepository _repo;

        public Dashboardcontent(IConfiguration config, IDatabaseCalls dbCalls, IApiImplementation apiImpl,IRepository repo)
        {
            _config = config;
            _dbCalls = dbCalls;
            _apiImpl = apiImpl;
            _repo = repo;
        }

        public async Task<DashboardViewModel> GetDashboardDetails(string usercurrentemail, string userclass, string usertype, int corporateID, string loggedInAsCorp, string loggedInAsVendor, string uniqueVendorCode)
        {
           
            if (userclass.ToLower() == "vendor" || loggedInAsVendor == "1")
            {
                //var vendorId = _repo.GetVendorbyCorporateId(corporateID.ToString()).UNIQUEVENDORID;
                //var vendorId = _repo.GetVendorbyCorporateId(corporateID.ToString()).UNIQUEVENDORID;
                var vendor = _dbCalls.GetApprovedVendors().Where(v => v.STATUS == "1" && v.UNIQUEVENDORID == uniqueVendorCode).FirstOrDefault();
                try
                {
                    DashboardViewModel dashboarddet = new DashboardViewModel();
                    var totalInvoices = _dbCalls.GetInvoiceListByVendorEmail(usercurrentemail);
                    var totalContract = _dbCalls.GetAllContractsbyVendoremail(usercurrentemail);
                    var totalVendor = _dbCalls.GetApprovedVendors(usercurrentemail);
                    // var contractstatus = _dbCalls.GetAllCorporateContractList();
                    var contractstatus = _dbCalls.GetVendorContractList(vendor.EMAIL, usercurrentemail);
                    var tenderinvitation = _dbCalls.GetAllContractResponse(usercurrentemail);

                    //Notification List of vendor
                    List<notification> allpendingInvoices = new List<notification>();
                    if (!string.IsNullOrEmpty(uniqueVendorCode))
                    {
                        allpendingInvoices = _dbCalls.GetAllpendingInvoicesbyvendorcode(uniqueVendorCode);
                    }
                    //else { allpendingInvoices = _dbCalls.GetAllpendingInvoices(); }

                    var countcontractstatus = contractstatus == null ? 0 : contractstatus.Count();
                    if (totalInvoices != null)
                    {
                        dashboarddet.completedInvoice = totalInvoices.Count(a => a.invoicestatus == "COMPLETED");
                        dashboarddet.rejectedInvoice = totalInvoices.Count(a => a.invoicestatus == "REJECTED");
                        dashboarddet.pendingInvoice = totalInvoices.Count(a => a.invoicestatus == "PENDING");
                    }

                    if (totalContract != null) dashboarddet.totalcontract = totalContract.Count();
                    if (totalVendor != null) dashboarddet.registeredVendor = totalVendor.Count();
                    dashboarddet.invitationtotender = tenderinvitation.Count();
                    dashboarddet.generalnotification = allpendingInvoices;

                    if (countcontractstatus != 0)
                    {
                        double percentageAwarded = 0;
                        double percentageInProgess = 0;
                       
                        var awarded = Convert.ToDouble(contractstatus.Count(a => a.CONTRACTSTATUS.ToUpper() == "AWARDED" || a.CONTRACTSTATUS.ToUpper() == "COMPLETED"));
                        var Inprogress = Convert.ToDouble(contractstatus.Count(a => a.CONTRACTSTATUS.ToUpper() == "IN PROGRESS"));
                        
                        if(awarded == 0 && Inprogress == 0)
                        {
                            dashboarddet.awarded = "0%";
                            dashboarddet.Inprogress = "0%";
                        }
                        else
                        {
                            var total = awarded + Inprogress;
                            var xplyvalue = awarded / total;
                            var xplyvalueinprogress = Inprogress / total;
                            percentageAwarded = xplyvalue * 100;
                            percentageInProgess = xplyvalueinprogress * 100;
                            dashboarddet.awarded = Math.Round(percentageAwarded, 2) + "%";
                            dashboarddet.Inprogress = Math.Round(percentageInProgess, 2) + "%";
                        }

                        
                    }

                    return dashboarddet;
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    return null;
                }
            }
            else if (userclass.ToLower() == "corporate" || loggedInAsCorp == "1")
            {
                try
                {
                    var vendorId = _repo.GetVendorbyCorporateId(corporateID.ToString())?.UNIQUEVENDORID;
                    DashboardViewModel dashboarddet = new DashboardViewModel();
                    var totalInvoices = _dbCalls.GetInvoiceListByCorporate(Convert.ToInt32(corporateID));
                    var totalContract = _dbCalls.GetAllContracts();
                    var totalVendor = _dbCalls.GetApprovedVendors();
                    var contractstatus = _dbCalls.GetCorporateContractList(Convert.ToInt32(corporateID));
                    
                    //Notification List of corporate
                    List<notification> allpendingInvoices = new List<notification>();
                    
                    allpendingInvoices = _dbCalls.GetAllpendingInvoicesByCorporate(corporateID); 


                    var countcontractstatus = contractstatus == null ? 0 : contractstatus.Count();
                    dashboarddet.completedInvoice = totalInvoices.Count(a => a.invoicestatus == "COMPLETED");
                    dashboarddet.rejectedInvoice = totalInvoices.Count(a => a.invoicestatus == "REJECTED");
                    dashboarddet.pendingInvoice = totalInvoices.Count(a => a.invoicestatus == "PENDING");
                    if (totalContract != null) dashboarddet.totalcontract = totalContract.Count();
                    if (totalVendor != null) dashboarddet.registeredVendor = totalVendor.Count();
                    if (allpendingInvoices != null) dashboarddet.generalnotification = allpendingInvoices;

                    if (countcontractstatus != 0)
                    {
                        var awarded = Convert.ToDouble(contractstatus.Count(a => a.CONTRACTSTATUS == "Awarded"));
                        var Inprogress = Convert.ToDouble(contractstatus.Count(a => a.CONTRACTSTATUS == "In Progress"));
                        var total = awarded + Inprogress;
                        var xplyvalue = awarded / total;
                        var xplyvalueinprogress = Inprogress / total;
                        var percentageAwarded = xplyvalue * 100;
                        var percentageInProgess = xplyvalueinprogress * 100;

                        dashboarddet.awarded = Math.Round(percentageAwarded, 2) + "%";
                        dashboarddet.Inprogress = Math.Round(percentageInProgess, 2) + "%";
                    }

                    return dashboarddet;
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    return null;
                }
            }
            else //AccessRep
            {
                try
                {
                    DashboardViewModel dashboarddet = new DashboardViewModel();
                    var totalInvoices = _dbCalls.GetInvoiceList();
                    var totalContract = _dbCalls.GetAllContracts();
                    var totalVendor = _dbCalls.GetApprovedVendors();
                    var contractstatus = _dbCalls.GetAllCorporateContractList();
                    
                    // Notification List of all
                    List<notification> allpendingInvoices = _dbCalls.GetAllpendingInvoices();
                    var tenderinvitation = _dbCalls.GetAllContractResponse();
                    var corporatedetails = _dbCalls.GetApprovedCorporates();

                    var sumofinvoicesdiscounting = _dbCalls.GetSumOfInvoice();
                    var sumofrefactoring = _dbCalls.GetSumOfRecourseFactoring();

                    dashboarddet.transactionamt = sumofinvoicesdiscounting + sumofrefactoring;
                    dashboarddet.allCorporate = corporatedetails.Count();
                    dashboarddet.invitationtotender = tenderinvitation.Count();
                    dashboarddet.completedInvoice = totalInvoices.Count(a => a.invoicestatus == "COMPLETED");
                    dashboarddet.rejectedInvoice = totalInvoices.Count(a => a.invoicestatus == "REJECTED");
                    dashboarddet.pendingInvoice = totalInvoices.Count(a => a.invoicestatus == "PENDING");
                    if (totalContract != null) dashboarddet.totalcontract = totalContract.Count();
                    if (totalVendor != null) dashboarddet.registeredVendor = totalVendor.Count();
                    if (allpendingInvoices != null) dashboarddet.generalnotification = allpendingInvoices;

                    if (contractstatus != null)
                    {
                        var awarded = Convert.ToDouble(contractstatus.Count(a => a.CONTRACTSTATUS == "Awarded"));
                        var Inprogress = Convert.ToDouble(contractstatus.Count(a => a.CONTRACTSTATUS == "In Progress"));
                        var total = awarded + Inprogress;
                        var xplyvalue = awarded / total;
                        var xplyvalueinprogress = Inprogress / total;
                        var percentageAwarded = xplyvalue * 100;
                        var percentageInProgess = xplyvalueinprogress * 100;

                        dashboarddet.awarded = Math.Round(percentageAwarded, 2) + "%";
                        dashboarddet.Inprogress = Math.Round(percentageInProgess, 2) + "%";
                    }

                    return dashboarddet;
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    return null;
                }

            }

        }


    }
}
