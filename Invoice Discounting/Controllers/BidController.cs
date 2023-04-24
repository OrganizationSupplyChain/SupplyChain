using Invoice_Discounting.Models;
using Invoice_Discounting.Services;
using Invoice_Discounting.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Invoice_Discounting.Controllers.BaseController;

namespace Invoice_Discounting.Controllers
{
    public class BidController : BaseController
    {
        private readonly IRepository _repo;
        public BidController(IRepository repository)
        {
            _repo = repository;
        }
        public IActionResult Index()
        {
            // Fetch all available bids for investors
            IEnumerable<BidViewModel> model = _repo.GetAllAvailableLoanBidList();
            HttpContext.Session.SetComplexData("AvailableLoan", model);
            return View(model);
        }

        public IActionResult PlaceBidModal(int loanId)
        {
            int investorId = HttpContext.Session.GetInt32("InvestorId") == null ? 0 : (int)HttpContext.Session.GetInt32("InvestorId");
            string investorName = HttpContext.Session.GetString("InvestorName");
            IEnumerable<BidViewModel> loanList = HttpContext.Session.GetComplexData<IEnumerable<BidViewModel>>("AvailableLoan");
            InsertBidViewModel model = new InsertBidViewModel();

            InsertBid bid = new InsertBid();
            if (loanList != null && loanList.Count() > 0)
            {
                BidViewModel loadDet = loanList.Where(x => x.id == loanId).FirstOrDefault();

                bid.INVOICENUMBER = loadDet != null ? loadDet.invoicenumber : string.Empty;
                bid.VENDORCODE = loadDet != null ? loadDet.VendorCode : string.Empty;
                bid.INVOICEID = loadDet != null ? loadDet.invoiceid : 0;
                bid.LOANAMOUNT = loadDet != null ? loadDet.requestedamount : 0;
                model.VendorName = loadDet != null ? loadDet.VendorName : string.Empty;
                model.LoanAmount = loadDet != null ? loadDet.requestedamount : 0;
            }
            
            bid.INVESTORID = investorId;
            bid.INVESTORNAME = investorName;
            bid.LOANID = loanId;

            model.InsertBid = bid;
            model.BidDate = DateTime.Now;
            

            return PartialView("_PlaceBid", model);
        }

        [HttpPost]
        public IActionResult _PlaceBid(InsertBidViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            // Place bid for investor
            bool bidPlaced = _repo.PlaceBid(model.InsertBid);

            if (bidPlaced)
            {
                Alert("Bid successfully Placed", NotificationType.success);
            }
            else
            {
                Alert("Unable to place bid, please try again", NotificationType.error);
            }

            return RedirectToAction("Index");
        }

        public IActionResult VendorIndex()
        {
            string vendorCode = HttpContext.Session.GetString("VendorId");

            if (string.IsNullOrEmpty(vendorCode))
            {
                return RedirectToAction("Index", "Login", new { errorMsg = "Invalid Access" });
            }

            // Fetch all approved loans awaiting bid
            IEnumerable<BidViewModel> model = _repo.GetLoanBidListByVendor(vendorCode);
            return View(model);

        }

        public IActionResult GetBidListModal(int loanId)
        {
            IEnumerable<BidModel> bidList = _repo.GetBidsByLoanId(loanId);

            return PartialView("_BidList", bidList);
        }

        public IActionResult AcceptBid(int bidId, int loanId, int invoiceId)
        {
            // Accept bid placed by investor. Other bids for the loan will be automatically rejected
            // Payment are also processed -- debit investor and credit vendor
            bool bidAccepted = _repo.AcceptBid(bidId, loanId, invoiceId);

            if (bidAccepted)
            {
                Alert("Bid successfully Accepted", NotificationType.success);
            }
            else
            {
                Alert("Unable to accept bid, please try again", NotificationType.error);
            }

            return RedirectToAction("VendorIndex");
        }
    }
}
