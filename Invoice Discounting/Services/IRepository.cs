using Invoice_Discounting.Models;
using Invoice_Discounting.Models.Request;
using Invoice_Discounting.Models.Response;
using Invoice_Discounting.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using Invoice_Discounting.Utility;

namespace Invoice_Discounting.Services
{
    public interface IRepository
	{
		bool AuthenticateUser(string username, string password, Users userDetails);
		Users GetUserDet(string username);
		Users GetUserById(int userId);
		QueryUserRes QueryUser(string userId);
		bool UpdateLastLoginDate(string username);
		SendMailRes SendMail(SendMailReq req);
		string GetUserBranch(string username);
		ADUserValidationDet GetUserADDetails(string username, string branchCode);
		IEnumerable<SelectListItem> GetModuleDDLList();
		bool ModifyRole(RoleUpdate roleDetails);
		IEnumerable<Users> GetAllUsers();
		string GetHashedPassword(string password);
		IEnumerable<UsersPending> GetUnapprovedUsers(string currentuseremail,string userclass, int roleId,int corporateid);
		UsersPending GetUnapprovedUsersById(int id,string currentuseremail,string userclass, int roleId,int corporateid);
		Roles GetRoleById(int id);
		bool CreateContract(ContractViewModel model);
		bool UpdateContract(ContractViewModel model);
		ContractResponseViewModel InitiateContractResponse(int contractId);
		IList<ContractResponseViewModel> GetVendorContractListOld(string vendorEmail);
		IEnumerable<VendorContractListModel> GetVendorContractList(string vendorEmail);
		bool SaveContractResponse(ContractResponseViewModel response);
		VendorResponseDetails GetVendorResponseById(int responseId);
		string GenerateRandomNos();
		string[] GetLandingPage(string roleModules);
		bool CreateUpdateUser(UpdateUser user, bool isSingleCorporate);
		bool IsUsernameUnique(string username);
		genericResponse IsUsernameUniquefinal(string username);
		string getpendinguserinitiatoremail(string username);
		bool IsEmailUnique(string username);
		bool AuthorizeUser(UsersPending user);
		bool AuthorizeContractResponse(ContractResponse details);
		InvoiceViewModel InitiateCreateInvoice(string vendoremail, int contractId, string discountingType);
		InvoiceViewModel InitiateCreateExternalInvoice(string uniqueVendorId, string discountingType);
		bool CreateInvoice(InvoiceViewModel invoiceModel);
		ValidateDiscountingModel ValidateDiscountingRequest(decimal interestRate, string accountNo, decimal invoiceAmount, int duration, decimal feesRate);
		InvoiceViewModel GetInvoiceDetails(int invoiceId);
		bool ProcessInvoiceDiscounting(int invoiceId);
		decimal ComputeInterest(decimal invoiceAmount, decimal interestRate, int duration);
		string SaveSingleRecourseFactoring(RecourseFactorinViewModel model);
		void ProcessInvoiceDiscountingRepayment();
		bool AuthorizeInvoice(ContractInvoice model, string authStatus);
		bool ChangePassword(PasswordChangeModel model);
		ReverseFactoringContractInvoice GetReverseFactoringInvoiceById(int invoiceId);
		Getcustomeracctsdetailsresp GetAccountDetByAccountNo(string accountNo);
		string FetchAccountNameByAccountNo(string accountNo);
		bool IsCorporateEnabled(int corporateId);
		bool IsVendorEnabled(string vendorId);
		UserPendingApproveModel GetUserViewModel(string userEmail, string userClass, int corporateId, int roleId,int corporateid);
		void ProcessReverseFactoringRepayment();
		InvoiceVendorViewModel GetVendorInvoiceDetailsByEmail(string email);
        List<string> GetLandingPages(string roleModules);
        VendorDetails GetVendorbyCorporateId(string corporateID);
		bool CreateUpdateVendor(UpdateVendor vendor, bool isSingleCorporate);
        bool AuthourizeContract(int responseId, string authStatus, string authorizerEmail, string AuthorizerName);
		IEnumerable<BidViewModel> GetLoanBidListByVendor(string vendorCode);
		IEnumerable<BidViewModel> GetAllAvailableLoanBidList();
        IEnumerable<BidModel> GetBidsByLoanId(int loanIdt);
        bool PlaceBid(InsertBid bidDetails);
        bool AcceptBid(int bidIdt, int loanIdt, int invoiceId);
    }
}
