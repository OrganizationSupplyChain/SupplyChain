using Invoice_Discounting.Models;
using System.Collections.Generic;
using Invoice_Discounting.Models.Response;
using Invoice_Discounting.ViewModel;

namespace Invoice_Discounting.Services
{
	public interface IDatabaseCalls
	{

		IEnumerable<Users> GetAllUsers();
		Users GetUserByUsername(string username);
		Users GetUserById(int userId);

		IEnumerable<Users> GetAllUsers(int roleId, string userClass);
		bool UpdateLastLoginDate(string username);
		IEnumerable<Roles> GetRoles();
		IEnumerable<Roles> GetRoles(int roleid);
		IEnumerable<Modules> GetModules();
		int UpdateInsertUser(UpdateUser userDetails);
		bool AuthorizeUser(AuthorizeUser user);
		IEnumerable<CorporateDetails> GetApprovedCorporates();
        IEnumerable<AuditDetails> GetAuditDetails();
		IEnumerable<CorporateDetailsPending> GetPendingCorporates(string currentuseremail);
        List<CategoryList> GetCategoryLists();
        bool UpdateInsertCategoryList(UpdateCategoryList categoryList);
		bool UpdateInsertCorporate(UpdateCorporate corporateDetails);
        bool InsertVendorBulk(UpdateVendorBulk vendorBulk);
        bool InsertCorporateBulk(UpdateCorporateBulk corporateBulk);
        bool InsertAudit(AuditDetails audit);
		bool AuthorizeCorporate(AuthorizeCorporate corporate);
		bool UpdateFailureTries(int idt);
		bool UpdateLoginFailureCount(int id);
		bool LockUserProfile(int id);
		bool InsertUpdateRole(RoleUpdate role);
		Users GetUserDetailsVM(int id);
		IEnumerable<UsersPending> GetPendingUsers( string currentuseremail,string userlass, int roleId,int corporateId);
		IEnumerable<UsersPending> GetPendingUsers();
		Users GetLoginUser(string username, string password);
        bool AuthorizeVendor(AuthorizeVendor vendor);
        bool AuthorizeBulkVendor(AuthorizeBulkVendor vendor);
        bool AuthorizeBulkCorporate(AuthorizeBulkCorporate corporate);
        int UpdateInsertVendor(UpdateVendor vendorDetails);
        IEnumerable<VendorDetails> GetApprovedVendors();
        List<string> GetVendorEmailByContractId(int corporateID);
        string GetCorporateNameByCorporateID(int GetCorporateNameByCorporateID);
		
		IEnumerable<string> GetDefinedUDFbyCorporateID(int corporateID);
        IEnumerable<VendorDetails> GetApprovedVendorsbyCorporateId(int? corporateId);
        IEnumerable<vendoruser> GetApprovedVendorusers();
        IEnumerable<VendorDetails> GetApprovedVendors(string vendoremail);
        VendorDetails GetVendorByEmail(string currentuseremail);
		IEnumerable<VendorDetailsPending> GetPendingVendors(string currentuseremail, int corporateId);
		List<notification> GetAllpendingInvoicesByCorporate(int corporateId);

		List<notification> GetAllpendingInvoices();
        List<notification> GetAllpendingInvoicesbyvendorcode(string vendorcode);
        List<notification> GetAllpendingInvoices(string vendoremail);

		IEnumerable<VendorBatchDetailsPending> GetPendingBulkVendors();
        IEnumerable<CorporateBatchDetailsPending> GetPendingBulkCorporate();

        VendorBatchDetailsPending GetPendingBatchVendor(int id);
        CorporateBatchDetailsPending GetPendingBatchCorporate(int id);
		IEnumerable<ContractDetails> GetAllContracts();
		ContractDetails GetContractById(int contractId);
		IEnumerable<ContractDetails> GetAllContractsbyVendoremail(string currentuseremail);
		int UpdateInsertContract(UpdateContract contractDetails, string updateType);
		List<UDFDetails> GetUdfByContractId(int contractId);
		bool DeleteUdfById(int udfId);
		bool InsertContractUDF(UdfInsert udfDetails);
		IEnumerable<ContractResponse> GetContractResponseByContractID(int contractId);
        IEnumerable<ContractDetails> GetContractResponseByCorporateID(int corporateId);
        IEnumerable<ContractResponse> GetAllContractResponse();
        IEnumerable<ContractResponse> GetAllContractResponse(string vendoremail);
		ContractResponse GetContractResponseByID(int responseId);
		IEnumerable<ContractUDFResponse> GetContractUDFResponseByResponseID(int responsetId);
		ContractUDFResponse GetContractUDFResponseByID(int id);
		long InsertContractResponse(InsertContractResponse contractRespDetails);
		bool InsertUDFResponse(InsertContractUDFResponse udfRespDetails);
		bool AuthorizeContractResponse(AuthorizeContractResponse authDetails);
		List<ContractDetails> GetAwardedContractByVendor(string vendorEmail);
		IEnumerable<VendorContractListModel> GetVendorContractList(string vendorEmail);
		int InsertInvoiceDetails(ContractInvoice invoiceDetails);
		bool InsertInvoiceLoanDetails(InvoiceLoan loanDetails);
		bool InsertInvoiceItemDetails(InvoiceItem invoiceItem);
		IEnumerable<InvoiceList> GetInvoiceListByCorporate(int corporateId);
		ContractInvoice GetInvoiceById(int id);
		IEnumerable<InvoiceList> GetInvoiceList();
		IEnumerable<InvoiceList> GetInvoiceList(string currentuseremail);
		IEnumerable<InvoiceList> GetInvoiceListByVendorEmail(string vendorEmail);
		IEnumerable<InvoiceList> GetAllInvoiceList();
		bool AuthorizeInvoice(AuthorizeInvoice invoice);
		IEnumerable<ContractInvoice> GetAllInvoices();
		IEnumerable<VendorBreakdown> GetVendorBreakdownByCorporate(int CorporateID);
		List<InvoiceItem> GetInvoiceItemsByInvoiceId(int invoiceId);
		InvoiceLoan GetInvoiceLoanByInvoiceId(int invoiceId);
		IEnumerable<VendorContractListModel> GetCorporateContractList(int corporateId);
		IEnumerable<VendorContractListModel> GetAllCorporateContractList();

        decimal GetSumOfInvoice();
        decimal GetSumOfRecourseFactoring();
		//IEnumerable<VendorContractListModel> GetAllCorporateContractListbyContractID();
		int InsertCorporateLoan(CorporateLoan loanDetails);
		bool UpdateCorporateLoanDisbursement(int loanId);
		IEnumerable<CorporateLoan> GetCorporateLoanByCorporateId(int corporateId);
		bool InsertRecourseFactoring(RecourseFactoring loanDetails);
		IEnumerable<RecourseFactoring> GetRecourseFactoringByCorporateId(int corporateId);
		IEnumerable<ContractInvoice> GetInvoicesWithNoLoan(int corporateId);
		bool UpdateInvoiceLoanStatus(int invoiceId, string loanStatus);

        IEnumerable<ContractInvoice> GetInvoicesWithPendingRepayment();
		bool UpdateInvoiceLoanDisbursement(int invoiceId, bool isDisbursed, int repaymentDays);
		bool UpdateInvoiceLoanRepayment(int invoiceId, bool isRepayed);
		string GetCorporateAccountByInvoiceId(int invoiceid);
		IEnumerable<CorporateLoan> GetCorporateLoanWithPendingRepayment();
		IEnumerable<RecourseFactoring> GetReverseFactoringWithPendingRepayment(int loanId);
		public InvoiceDiscountingVM GetAccessRepInvoiceDiscByInvoiceId(int invoiceId);
		public ReverseFactoringVM GetAccessRepReverseFactByInvoiceId(int invoiceId);
		IEnumerable<InvoiceLoan> GetAllInvoiceLoan();
		IEnumerable<RecourseFactoring> GetAllRecourseFactoring();
		bool UpdateUserPassword(int userId, string hashedPwrd);
		bool UpdateCorporateAvailableLimit(int corporateId, decimal newLineOfCredit);
		IEnumerable<string> GetAllBanks();
        List<BankList> GetAllBanksNew();
		bool UpdateInvoiceDetails(ContractInvoice invoiceDetails);
		bool ArchiveInvoiceDetails(int invoiceId);
		bool UpdateVendorStatus(int vendorId, bool status);
		bool UpdateCorporateStatus(int corporateId, bool status);
		bool SavePaymentDetails(PaymentDetails payment);
		bool UpdateInvoiceRepaymentStatus(int invoiceId, bool status);
		bool UpdateCorporateLoanRepaymentStatus(int loanId, bool status);
		bool UpdateRecourseFactoringRepaymentStatus(int loanId, bool loanRepayed, string loanStatus);

        bool UpdateLogonStatus(int userDetailsId);
        bool UpdateLogonStatusbyUsername(string username);
		bool IsSingleCorporate(int corporateId);
		IEnumerable<BidViewModel> GetLoanBidListByVendor(string vendorCode);
		IEnumerable<BidViewModel> GetAllAvailableLoanBidList();
        IEnumerable<BidModel> GetBidByLoanId(int loanIdt);
        bool PlaceBid(InsertBid bidDetails);
        bool AcceptBid(int bidIdt, int loanIdt);
        bool UpdateLoanStatusAfterSubmittingBid(int loanId);
        IEnumerable<CorporateDetails> GetApprovedCorporatesbyCorporateID(int corporateid);
        IEnumerable<VendorDetails> GetApprovedVendorsbyCorporateID(int corporateid);

        IEnumerable<VendorContractBidsDetails> GetContractbidsbyVendorEmail(string vendoremail);
    }
}
