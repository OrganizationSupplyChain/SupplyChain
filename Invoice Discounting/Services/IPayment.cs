using Invoice_Discounting.Models.Request;
using Invoice_Discounting.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Services
{
    public interface IPayment
    {
        SinglePostAPIRes DisburseLoan(SinglePostAPIReq postAPIReq);
        MultiJrnlTransferRes LoanSettlement(MultiJrnlTransferReq multiJrnlReq);
    }
}
