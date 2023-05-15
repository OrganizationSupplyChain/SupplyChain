using System.ComponentModel;

namespace Invoice_Discounting.Utility
{
	public class Enums
	{
		public enum Status
		{
			ACTIVE,
			DISABLED
		}

		public enum UpdateTypes
		{
			NEW,
			UPDATE
		}
		public enum AuthorizationStatus
		{
			INITIATED = 0,
			APPROVED = 1,
			REJECTED = 2
		}
		public enum UserClass
		{
			[Description("VENDOR")]
			VENDOR = 0,
			[Description("ACCESS BANK REP")]
			ACCESSREP = 1,
			[Description("CORPORATE")]
			CORPORATE = 2,
			[Description("VENDOR AND CORPORATE")]
			VENDORCORPORATE = 3,
			INVESTOR = 4
		}
		public enum UserType
        {
			INTERNAL ,
			EXTERNAL 
        }
		public enum DiscountingType
		{
			[Description("INVOICE DISCOUNTING")]
			INVOICEDISCOUNTING = 0,
			[Description("RECOURSE FACTORING")]
			RECOURSEFACTORING = 1
		}
		public enum InvoiceAuthorizationStatus
		{
			PENDING = 0,
			COMPLETED = 1,
			REJECTED = 2
		}

		public enum LoanStatus
		{
			PENDING = 0,
			DISBURSED = 1,
			REPAYED = 2,
			[Description("FAILED DISBURSEMENT")]
			FAILEDDISBURSEMENT = 3,
			[Description("FAILED REPAYMENT")]
			FAILEDREPAYMENT = 3,
			APPROVED = 4,
			REJECTED = 5,
            [Description("BID ONGOING")]
            BIDONGOING = 6,
            [Description("BID ACCEPTED")]
            BIDACCEPTED = 7
        }

		public enum PaymentType
		{
			DISBURSEMENT = 0,
			REPAYMENT = 1
		}

        public enum BidStatus
        {
            INITIATED = 0,
            ACCEPTED = 1,
            REJECTED = 2,
        }
    }
}
