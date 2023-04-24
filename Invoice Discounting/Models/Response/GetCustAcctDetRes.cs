using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models.Response
{
	public class GetCustAcctDetRes
	{
		public string ResponseCode { get; set; }
		public string ResponseMessage { get; set; }
		public Getcustomeracctsdetailsresp[] getcustomeracctsdetailsresp { get; set; }
	}

	public class Getcustomeracctsdetailsresp
	{
		public string AccountClassType { get; set; }
		public string accountName { get; set; }
		public string accountNo { get; set; }
		public string AccountOfficer { get; set; }
		public string AccountStatus { get; set; }
		public decimal amountCreditMTD { get; set; }
		public decimal amountCreditYTD { get; set; }
		public decimal amountDebitMTD { get; set; }
		public decimal amountDebitYTD { get; set; }
		public float amountHold { get; set; }
		public decimal amountLastCredit { get; set; }
		public decimal amountLastDebit { get; set; }
		public string aTMStatus { get; set; }
		public decimal availableBalance { get; set; }
		public string branchCode { get; set; }
		public string branchName { get; set; }
		public string BVN { get; set; }
		public float clearedBalance { get; set; }
		public float closingBalance { get; set; }
		public string COMP_MIS_2 { get; set; }
		public string COMP_MIS_4 { get; set; }
		public string COMP_MIS_8 { get; set; }
		public string currency { get; set; }
		public string currencyCode { get; set; }
		public string custID { get; set; }
		public string CustomerCategory { get; set; }
		public string CustomerCategoryDesc { get; set; }
		public string customerName { get; set; }
		public string customerNo { get; set; }
		public string dateofbirth { get; set; }
		public string dateOpened { get; set; }
		public decimal daueLimit { get; set; }
		public object dAUEStartDate { get; set; }
		public string e_mail { get; set; }
		public decimal decimalerestPaidYTD { get; set; }
		public decimal decimalerestReceivedYTD { get; set; }
		public string lastCreditDate { get; set; }
		public decimal lastCreditdecimalerestAccrued { get; set; }
		public string lastDebitDate { get; set; }
		public decimal lastDebitdecimalerestAccrued { get; set; }
		public string lastMadecimalainedBy { get; set; }
		public decimal lastSerialofCheque { get; set; }
		public decimal lastUsedChequeNo { get; set; }
		public string madecimalenanceAuthorizedBy { get; set; }
		public decimal netBalance { get; set; }
		public decimal oDLimit { get; set; }
		public float openingBalance { get; set; }
		public string phone { get; set; }
		public string productCode { get; set; }
		public string productName { get; set; }
		public string profitCenter { get; set; }
		public decimal serviceChargeYTD { get; set; }
		public string signatory { get; set; }
		public string staff { get; set; }
		public string strAdd1 { get; set; }
		public string strAdd2 { get; set; }
		public string strAdd3 { get; set; }
		public object strCity { get; set; }
		public string strCountry { get; set; }
		public object strState { get; set; }
		public object strZip { get; set; }
		public decimal taxAccrued { get; set; }
		public decimal unavailableBalance { get; set; }
		public decimal unclearedBalance { get; set; }
		public string customersegment { get; set; }
		public string PNDReasonANDCode { get; set; }
		public string TierDetails { get; set; }
		public string hasSweep { get; set; }
		public decimal sweepAmt { get; set; }
		public string sweepData { get; set; }
		public string LoanPrequalifyInfo { get; set; }
		public string migrateacctPrompt { get; set; }
		public string gender { get; set; }
		public object custAddress1 { get; set; }
		public object custAddress2 { get; set; }
		public object custAddress3 { get; set; }
		public object custAddress4 { get; set; }
		public string maritalStatus { get; set; }
		public string firstName { get; set; }
		public string middleName { get; set; }
		public string lastName { get; set; }
		public string customerType { get; set; }
	}
 
}
