using Invoice_Discounting.Models.Request;
using Invoice_Discounting.Models.Response;

namespace Invoice_Discounting.Services
{
	public interface IApiImplementation
	{
		GetCustAcctDetRes GetCustAcctDet(GetCustAcctDetReq req);
		QueryUserRes QueryUser(QueryUserReq req);
		TokenAuthRes TokenAuthentication(TokenAuthReq req);
		SendMailRes SendMail(SendMailReq req);
		ADBranchAuthRes GetADUserBranch(ADBranchAuthReq req);
		SinglePostAPIRes SingleTransfer(SinglePostAPIReq req);
		MultiJrnlTransferRes MultiJrnlTransfer(MultiJrnlTransferReq multiJrnlReq);
	}
}