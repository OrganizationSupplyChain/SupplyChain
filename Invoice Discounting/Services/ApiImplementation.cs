using Invoice_Discounting.Models.Response;
using Invoice_Discounting.Models.Request;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Security.Cryptography.X509Certificates;
using System.Net;

namespace Invoice_Discounting.Services
{
	public class ApiImplementation : IApiImplementation
	{
		NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
		private readonly IConfiguration _config;
		private readonly string baseUrl;
		private readonly string baseUrl1;
		private readonly string emailBaseUrl;

		public ApiImplementation(IConfiguration config)
		{
			_config = config;
			baseUrl = _config["APISettings:BaseURL"];
			baseUrl1 = _config["APISettings:BaseURL1"];
			emailBaseUrl = _config["APISettings:EmailBaseURL"];
		}

		public ApiImplementation()
		{
		}

		public QueryUserRes QueryUser(QueryUserReq req)
		{
			try
			{
				string fullUrl = $"{baseUrl}/cr2usermgt/v1/QueryUser";
				string reqBody = JsonConvert.SerializeObject(req);
				RestClient client = new RestClient(fullUrl);
				RestRequest request = new RestRequest(Method.POST);

				request.AddHeader("Accept", "application/json");
				request.AddHeader("Content-Type", "application/json");
				request.AddParameter("reqBody", reqBody, ParameterType.RequestBody);
				IRestResponse<QueryUserRes> response = client.Execute<QueryUserRes>(request);

				return response.Data;
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return null;
			}
		}
		public GetCustAcctDetRes GetCustAcctDet(GetCustAcctDetReq req)
		{
			try
			{
				string fullUrl = $"{baseUrl1}/AccessBankMaintenancenEnquiry/v1/GetCustomerAcctsDetail";
				string reqBody = JsonConvert.SerializeObject(req);
				RestClient client = new RestClient(fullUrl);
				RestRequest request = new RestRequest(Method.POST);

				request.AddHeader("Accept", "application/json");
				request.AddHeader("Content-Type", "application/json");
				request.AddParameter("reqBody", reqBody, ParameterType.RequestBody);

				IRestResponse<GetCustAcctDetRes> response = client.Execute<GetCustAcctDetRes>(request);
				GetCustAcctDetRes resp = JsonConvert.DeserializeObject<GetCustAcctDetRes>(response.Content);

				return resp;
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return null;
			}
		}
		public TokenAuthRes TokenAuthentication(TokenAuthReq req)
		{
			try
			{
				string fullUrl = $"{baseUrl}/entrustservice/v1/EntrustService";
				string reqBody = JsonConvert.SerializeObject(req);
				RestClient client = new RestClient(fullUrl);
				RestRequest request = new RestRequest(Method.POST);

				request.AddHeader("Accept", "application/json");
				request.AddHeader("Content-Type", "application/json");
				request.AddParameter("reqBody", reqBody, ParameterType.RequestBody);

				IRestResponse<TokenAuthRes> response = client.Execute<TokenAuthRes>(request);

				return response.Data;
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return null;
			}
		}

		public ADBranchAuthRes GetADUserBranch(ADBranchAuthReq req)
		{
			try
			{
				string serviceURL = $"{baseUrl}/AccessBankMaintenancenEnquiry/v1/AuthenticateCBAUser";
				RestClient client = new RestClient(serviceURL);
				RestRequest request = new RestRequest(Method.POST);
				string reqBody = JsonConvert.SerializeObject(req);
				request.AddHeader("Accept", "application/json");
				request.AddHeader("Content-Type", "application/json");
				request.AddParameter("reqBody", reqBody, ParameterType.RequestBody);

				IRestResponse<ADBranchAuthRes> response = client.Execute<ADBranchAuthRes>(request);
				ADBranchAuthRes resp = JsonConvert.DeserializeObject<ADBranchAuthRes>(response.Content);
				return resp;
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return null;
			}
		}

		public SendMailRes SendMail(SendMailReq req)
		{
			try
			{
				req.From = "no-reply@accessbankplc.com";
				req.DisplayAsHtml = true;
				req.DisplayName = "SupplyChain";
				string serviceURL = $"{emailBaseUrl}/api/EmailRelay/SendEmail";
				var client = new RestClient(serviceURL);
				var request = new RestRequest(Method.POST);
				var reqbody = JsonConvert.SerializeObject(req);
				request.AddHeader("Accept", "application/json");
				request.AddHeader("Content-Type", "application/json");
                logger.Info($"The user details is {reqbody}");
				request.AddParameter("reqbody", reqbody,ParameterType.RequestBody);

				IRestResponse<SendMailRes> response = client.Execute<SendMailRes>(request);
				SendMailRes resp = JsonConvert.DeserializeObject<SendMailRes>(response.Content);
				return resp;
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return null;
			}
		}

        public SinglePostAPIRes SingleTransfer(SinglePostAPIReq req)
        {
			SinglePostAPIRes apiResponse = new SinglePostAPIRes();
			try
			{
				string postingBaseUrl = _config["APISettings:PostingBaseURL"];
				string serviceURL = $"{postingBaseUrl}/accounts/transfers/singlepost";
				var client = new RestClient(serviceURL);
				var request = new RestRequest(Method.POST);
				var reqbody = JsonConvert.SerializeObject(req);
				request.AddHeader("Accept", "application/json");
				request.AddHeader("Content-Type", "application/json");
				request.AddParameter("reqbody", reqbody, ParameterType.RequestBody);

				IRestResponse<SinglePostAPIRes> response = client.Execute<SinglePostAPIRes>(request);
				logger.Info("Single Post Response:: " + response.Content);
				if(response.StatusCode == HttpStatusCode.OK)
                {
					apiResponse = JsonConvert.DeserializeObject<SinglePostAPIRes>(response.Content);
				}
                else
                {
					apiResponse.responseCode = response.StatusCode.ToString();
					apiResponse.responseMessage = response.StatusDescription;
				}				
			}
			catch (Exception ex)
			{
				logger.Error(ex);
			}
			return apiResponse;
		}

        public MultiJrnlTransferRes MultiJrnlTransfer(MultiJrnlTransferReq multiJrnlReq)
        {
			MultiJrnlTransferRes apiResponse = new MultiJrnlTransferRes();
			try
			{
				string postingBaseUrl = _config["APISettings:PostingBaseURL"];
				string postingAuthKey = _config["APISettings:PostingAuthKey"];
				multiJrnlReq.channel_code = _config["APISettings:PostingChannelCode"];
				string serviceURL = $"{postingBaseUrl}/postingserviceng/v1/accounts/transfers/batchpost";
				var client = new RestClient(serviceURL);
				var request = new RestRequest(Method.POST);
				var reqbody = JsonConvert.SerializeObject(multiJrnlReq);
				request.AddHeader("Accept", "application/json");
				request.AddHeader("Content-Type", "application/json");
				request.AddHeader("Authorization", postingAuthKey);
				request.AddParameter("reqbody", reqbody, ParameterType.RequestBody);

				IRestResponse<MultiJrnlTransferRes> response = client.Execute<MultiJrnlTransferRes>(request);
				logger.Info("Multi JournalEntry Response:::: " + response.Content);
				if (response.StatusCode == HttpStatusCode.OK)
				{
					apiResponse = JsonConvert.DeserializeObject<MultiJrnlTransferRes>(response.Content);
				}
				else
				{
					apiResponse.response_code = response.StatusCode.ToString();
					apiResponse.response_message = response.StatusDescription;
				}

			}
			catch (Exception ex)
			{
				logger.Error(ex);
			}
			return apiResponse;
		}
    }
}  
