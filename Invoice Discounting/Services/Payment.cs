using Invoice_Discounting.Models.Request;
using Invoice_Discounting.Models.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Invoice_Discounting.Services
{
    public class Payment : IPayment
    {
        private readonly IConfiguration _config;
        private IDatabaseCalls dbCalls;
        private IApiImplementation apiImpl;
        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public Payment(IConfiguration config, IDatabaseCalls dbCalls, IApiImplementation apiImplementation)
        {
            _config = config;
            this.dbCalls = dbCalls;
            apiImpl = apiImplementation;
        }
        public string GeneratePostingMsgID()
        {
            try
            {
               
                string randomNo = GetSecureRandom();
                string dateString = DateTime.UtcNow.ToString("ddMMYY");
                string msgId = $"IDP{dateString}{randomNo}";
                return msgId;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return "";
            }
        }

        public static string GetSecureRandom()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[10000000];
                rng.GetBytes(randomNumber);
                int value = BitConverter.ToInt32(randomNumber, 0);
                return value.ToString().Replace('-', ' ').Trim();
            }
        }

        public SinglePostAPIRes DisburseLoan(SinglePostAPIReq postAPIReq)
        {
            SinglePostAPIRes response = new SinglePostAPIRes();
            try
            {
                postAPIReq.debitAccountType = _config["AccountingEntries:AccessPoolAcctType"];
                postAPIReq.debitAccountCCY = _config["AccountingEntries:AccessPoolAcctCCY"];
                postAPIReq.debitAccountBranch = _config["AccountingEntries:AccessPoolAcctBrnch"];
                postAPIReq.debitAccountNumber = _config["AccountingEntries:AccessPoolAccount"];
                postAPIReq.moduleName = _config["AccountingEntries:PostingAPIModule"];
                postAPIReq.requestTime = DateTime.UtcNow.ToLongDateString();
                postAPIReq.creditAccountType = "CASA";

                response = apiImpl.SingleTransfer(postAPIReq);

                //postAPIReq.amount = amount
                //postAPIReq.creditAccountBranch = "099"
                //postAPIReq.creditAccountCCY = "NGN"
                //postAPIReq.creditAccountNumber = vendorAccount 
                //postAPIReq.msgId = accessIngr.GeneratePostMsgId()
                //postAPIReq.narration = dNarration
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return response;
        }

        public MultiJrnlTransferRes LoanSettlement(MultiJrnlTransferReq multiJrnlReq)
        {
            throw new NotImplementedException();
        }
    }
}
