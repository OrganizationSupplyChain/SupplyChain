using Invoice_Discounting.Models;
using Invoice_Discounting.Models.Request;
using Invoice_Discounting.Models.Response;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Invoice_Discounting.ViewModel;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Invoice_Discounting.Utility;
using Microsoft.AspNetCore.Http;
using static Invoice_Discounting.Utility.Enums;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Reflection;
using Invoice_Discounting.Controllers;

namespace Invoice_Discounting.Services
{
    public class Repository : IRepository
    {
        private readonly IConfiguration _config;
        private IApiImplementation apiImpl;
        private IActiveDirectoryService ADService;
        private IDatabaseCalls _dbcalls;
        private readonly string portalUrl;
        private readonly string postingGL;
        private readonly string postingGLBranch;
        private readonly string feesGL;
        private readonly string feesGLBranch;
        private readonly string interestGL;
        private readonly string interestGLBranch;
        private readonly string postingTrnCode;
        private readonly string disbursementTrnCode;
        private readonly string postingUsername;
        private readonly string supplyChainUrl;
        private readonly string principalIDFNarration;
        private readonly string interestIDFNarration;
        private readonly string rfinterestNarration;
        private readonly string feeIDFNarration;
        private readonly string rffeeNarration;
        private readonly string principaReverseFactoringNarration;
        private readonly string repaymentIDFNarration;
        private readonly string supplyChainRepaymentNarration;
         
        private static Random random = new Random();
        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public Repository()
        {

        }
        public Repository(IConfiguration config, IDatabaseCalls dbcalls, IApiImplementation apiImpl, IActiveDirectoryService ADService)
        {
            _config = config;
            _dbcalls = dbcalls;
            this.apiImpl = apiImpl;
            this.ADService = ADService;
            portalUrl = _config["PortalUrl"];
            postingGL = _config["AccountingEntries:AccessBankPoolAccount"];
            postingGLBranch = _config["AccountingEntries:AccessBankPoolAccountBranchCode"];
            feesGL = _config["AccountingEntries:AccessBankFeesAccount"];
            feesGLBranch = _config["AccountingEntries:AccessBankFeesAccountBranchCode"];
            interestGL = _config["AccountingEntries:AccessBankInterestAccount"];
            interestGLBranch = _config["AccountingEntries:AccessBankInterestAccountBranchCode"];
            postingTrnCode = _config["APISettings:PostingTransactionCode"];
            disbursementTrnCode = _config["APISettings:DisbursementTransactionCode"];
            postingUsername = _config["APISettings:PostingUserLoginId"];
            supplyChainUrl = _config["SupplyChainUrl"];
            principalIDFNarration = _config["Narrations:principalIDFNarration"];
            rfinterestNarration = _config["Narrations:rfinterestNarration"];
            interestIDFNarration = _config["Narrations:interestIDFNarration"];
            feeIDFNarration = _config["Narrations:feeIDFNarration"];
            rffeeNarration = _config["Narrations:rffeeNarration"];
            principaReverseFactoringNarration = _config["Narrations:principaReverseFactoringNarration"];
            repaymentIDFNarration = _config["Narrations:repaymentIDFNarration"];
            supplyChainRepaymentNarration = _config["Narrations:supplyChainRepaymentNarration"];


        }


        /// <summary>
        /// Authenticate users to access the portal
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool AuthenticateUser(string username, string password, Users userDetails)
        {
            try
            {
                if (userDetails.USERTYPE == "INTERNAL")
                {
                    //AD Validation
                    var authenticated = ADService.Login(username, password);
                    if (authenticated == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
                else
                {
                    //validate with system generated password
                    string hashedPassword = GetHashedPassword(password.Trim());

                    if (hashedPassword == userDetails.HASHEDPASSWORD)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public Users GetUserDet(string username)
        {
            try
            {
                UserAccessDet det = new UserAccessDet();
                Users user = _dbcalls.GetUserByUsername(username);
                //Users user = _dbcalls.GetAllUsers().Where(u => u.STATUS == 1 && u.USERNAME.ToUpper().Trim() == username.ToUpper().Trim()).FirstOrDefault();

                return user;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public Users GetUserById(int userId)
        {
            try
            {
                UserAccessDet det = new UserAccessDet();
                Users user = _dbcalls.GetUserById(userId);
                return user;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public VendorDetails GetVendorbyCorporateId(string corporateId)
        {
            try
            {
                VendorDetails det = new VendorDetails();
                VendorDetails vendordetails = _dbcalls.GetApprovedVendors().FirstOrDefault(u => corporateId != null && (u.CORPORATEID != null && u.CORPORATEID.ToString() == corporateId));

                return vendordetails;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public QueryUserRes QueryUser(string userId)
        {
            try
            {
                QueryUserReq req = new QueryUserReq()
                {
                    UserID = userId
                };
                var response = apiImpl.QueryUser(req);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public bool UpdateLastLoginDate(string username)
        {
            try
            {
                bool updated = _dbcalls.UpdateLastLoginDate(username);
                return updated;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public string GenerateReference()
        {
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[6];
            crypto.GetBytes(bytes);
            int randVal = BitConverter.ToInt32(bytes, 1);
            string randNo = randVal.ToString().Substring(1, 8);
            //string refNo = $"BRA{randNo}";
            return randNo;
        }
        public SendMailRes SendMail(SendMailReq request)
        {
            try
            {
                var response = apiImpl.SendMail(request);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public string GetUserBranch(string username)
        {
            try
            {
                string bCode = "";
                ADBranchAuthReq req = new ADBranchAuthReq()
                {
                    ldap_id = username
                };
                ADBranchAuthRes response = apiImpl.GetADUserBranch(req);
                if (response.response_code == "00")
                {
                    bCode = response.AuthenticateCBAUserResponse.FirstOrDefault().home_branch;
                }
                return bCode;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return "";
            }
        }
        public ADUserValidationDet GetUserADDetails(string username, string branchCode)
        {
            ADUserValidationDet userDetails = new ADUserValidationDet();
            try
            {
                if (branchCode == "099" || branchCode == "99")
                {
                    string adUserName = _config["ADSettings:adusername"];
                    string adPassword = _config["ADSettings:adpassword"];
                    //Call AD directly to get user details
                    username = string.IsNullOrEmpty(username) ? "" : username.Trim();
                    UserPrincipal userDet = ADService.GetUser(username, adUserName, adPassword);
                    if (userDet != null)
                    {
                        userDetails.BranchCode = "099";
                        userDetails.UserId = username;
                        userDetails.FullName = userDet.Surname + " " + userDet.GivenName;
                        userDetails.Email = userDet.EmailAddress;
                    }
                }
                else
                {
                    ADBranchAuthReq req = new ADBranchAuthReq()
                    {
                        ldap_id = username
                    };
                    ADBranchAuthRes response = apiImpl.GetADUserBranch(req);
                    if (response.response_code == "00" && response.AuthenticateCBAUserResponse[0].user_status != "D")
                    {
                        Authenticatecbauserresponse details = response.AuthenticateCBAUserResponse.FirstOrDefault();
                        userDetails.BranchCode = details.home_branch;
                        userDetails.UserId = details.user_id;
                        userDetails.FullName = details.user_name;
                        userDetails.Email = details.user_email;
                    }
                }

                return userDetails;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public IEnumerable<SelectListItem> GetModuleDDLList()
        {
            IEnumerable<SelectListItem> moduleList = null;
            try
            {
                var modules = _dbcalls.GetModules();
                if (modules != null && modules.Count() > 0)
                {
                    moduleList = modules.Select(x => new SelectListItem()
                    {
                        Value = x.ID.ToString(),
                        Text = x.MODULENAME
                    });
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return new SelectList(moduleList, "Value", "Text");
        }
        public bool ModifyRole(RoleUpdate roleDetails)
        {
            try
            {
                var modified = _dbcalls.InsertUpdateRole(roleDetails);
                return modified;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public IEnumerable<Users> GetAllUsers()
        {
            try
            {
                IEnumerable<Users> users = _dbcalls.GetAllUsers();
                return users;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public string GetHashedPassword(string password)
        {
            try
            {

                // generate a 128-bit salt using a secure PRNG
                string saltKey = "hF8Yoey651=";
                byte[] salt = Encoding.Unicode.GetBytes(saltKey);

                // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password.Trim(),
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));
                return hashed;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return "";
            }
        }
        public IEnumerable<UsersPending> GetUnapprovedUsers(string currentuseremail, string userclass, int roleId ,int corporateid)
        {
        
            try
            {
                IEnumerable<UsersPending> users = _dbcalls.GetPendingUsers(currentuseremail, userclass, roleId,corporateid);
                return users;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public UsersPending GetUnapprovedUsersById(int id, string currentuseremail, string userclass, int roleId, int corporateid)
        {
            
            try
            {

                UsersPending users = _dbcalls.GetPendingUsers(currentuseremail, userclass, roleId,corporateid).Where(u => u.ID == id).FirstOrDefault();
                return users;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public Roles GetRoleById(int id)
        {
            //int roleId = (int)HttpContext.Session.GetInt32("RoleId");
            try
            {
                Roles role = _dbcalls.GetRoleById(id);
                return role;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public bool CreateContract(ContractViewModel model)
        {
            try
            {
                UpdateContract Contract = new UpdateContract();
                string vendorCategory = model.Contract.VENDORCATEGORY;
                ///var vendorEmailList = _dbcalls.GetApprovedVendors().Where(v => v.CATEGORY == vendorCategory).Select(x => x.EMAIL).ToList();
                var vendorEmailList = _dbcalls.GetVendorEmailByContractId(model.Contract.CORPORATEID);
                var CorporateName = _dbcalls.GetCorporateNameByCorporateID(model.Contract.CORPORATEID);
                
                string vendorEmailString = string.Join(',', vendorEmailList);
                Contract.Id = 0;
                Contract.ContractNumber = model.Contract.CONTRACTNUMBER;
                Contract.PONumber = model.Contract.PONUMBER;
                Contract.ContractName = model.Contract.CONTRACTNAME;
                Contract.ContractAmount = model.Contract.ContractAmount;
                Contract.QualitySpecification = model.Contract.QUALITYSPECIFICATION;
                Contract.Description = model.Contract.DESCRIPTION;
                Contract.PaymentTenor = model.Contract.PAYMENTTENOR;
                Contract.TimelineDays = model.Contract.TIMELINEDAYS;
                Contract.VendorCategory = vendorCategory;
                Contract.VendorEmail = vendorEmailString;
                Contract.OtherInformation = model.Contract.OTHERINFORMATION;
                Contract.RequiredDocuments = model.Contract.REQUIREDDOCUMENTS;
                Contract.CreatedByEmail = model.Contract.CREATEDBYEMAIL;
                Contract.CreatedByName = model.Contract.CREATEDBYNAME;
                Contract.CorporateId = model.Contract.CORPORATEID;

                int createdId = _dbcalls.UpdateInsertContract(Contract, Enums.UpdateTypes.NEW.ToString());
                if (createdId > 0)
                {
                    //save udf if any
                    foreach (var u in model.UdfDetails)
                    {
                        UdfInsert udfInsert = new UdfInsert()
                        {
                            ContractId = createdId,
                            CreatorEmail = model.Contract.CREATEDBYEMAIL,
                            CreatorName = model.Contract.CREATEDBYNAME,
                            UdfLabel = u.UDFLABEL,
                            UdfType = u.UDFTYPE
                        };

                        var inserted = _dbcalls.InsertContractUDF(udfInsert);
                    }
                    string vendorEmails = string.Join(';', vendorEmailList);
                    SendMailReq mailReq = new SendMailReq()
                    {
                        Content = $"<p>Good day,</p><p>A contract has been created  on the Access Bank Supply Chain platform. <p>ContractName: {Contract.ContractName}</p> <p>CorporateName: {CorporateName }</p>. <p>Please log in <a href={supplyChainUrl}>here</a> to bid for it</p> <p></p> <p> Regards, Supply Chain Platform Admin</p>",
                        CopyAddress = "",
                        From = "no-reply@accessbankplc.com",
                        Subject = "Supply Chain Contract Creation",
                        Recipient = vendorEmails,
                        attachment = "",
                        DisplayAsHtml = true,
                        DisplayName = "Access Bank"
                        
                    };
                    var mailSent = SendMail(mailReq);
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public bool UpdateContract(ContractViewModel model)
        {
            try
            {
                //Get Saved UDF for the Corporate ID
                var registeredUDF = string.Empty;
                UpdateContract Contract = new UpdateContract();
                string vendorCategory = model.Contract.VENDORCATEGORY;
                var vendorEmailList = _dbcalls.GetApprovedVendors().Where(v => v.CATEGORY == vendorCategory).Select(x => x.EMAIL).ToList();
                
                var udfdefined = _dbcalls.GetDefinedUDFbyCorporateID(model.Contract.ID);
                if (udfdefined != null)
                {
                    registeredUDF = string.Join<string>(",", udfdefined);
                }
                string vendorEmailString = string.Join(',', vendorEmailList);
                Contract.Id = model.Contract.ID;
                Contract.ContractNumber = model.Contract.CONTRACTNUMBER;
                Contract.PONumber = model.Contract.PONUMBER;
                Contract.ContractName = model.Contract.CONTRACTNAME;
                Contract.QualitySpecification = model.Contract.QUALITYSPECIFICATION;
                Contract.Description = model.Contract.DESCRIPTION;
                Contract.PaymentTenor = model.Contract.PAYMENTTENOR;
                Contract.TimelineDays = model.Contract.TIMELINEDAYS;
                Contract.ContractAmount = model.Contract.ContractAmount;
                Contract.VendorCategory = vendorCategory;
                Contract.VendorEmail = vendorEmailString;
                Contract.VendorEmail = model.Contract.VENDORNAME;
                Contract.OtherInformation = model.Contract.OTHERINFORMATION;
                Contract.RequiredDocuments = model.Contract.REQUIREDDOCUMENTS;
                Contract.LastModifiedBy = model.Contract.CREATEDBYNAME;

                int contractId = _dbcalls.UpdateInsertContract(Contract, Enums.UpdateTypes.UPDATE.ToString());

                if (contractId > 0)
                {
                    //save udf if any
                    foreach (var u in model.UdfDetails)
                    {
                        if (registeredUDF.Contains(u.UDFLABEL)) continue;
                        UdfInsert udfInsert = new UdfInsert()
                        {
                            ContractId = contractId,
                            CreatorEmail = model.Contract.CREATEDBYEMAIL,
                            CreatorName = model.Contract.CREATEDBYNAME,
                            UdfLabel = u.UDFLABEL,
                            UdfType = u.UDFTYPE
                        };

                        var inserted = _dbcalls.InsertContractUDF(udfInsert);

                    }
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public ContractResponseViewModel InitiateContractResponse(int contractId)
        {
            try
            {
                ContractResponseViewModel model = new ContractResponseViewModel();
                ContractDetails contractDet = _dbcalls.GetContractById(contractId);
                List<UDFResponse> udfResp = new List<UDFResponse>();
                var udfDet = _dbcalls.GetUdfByContractId(contractDet.ID).ToList();
                foreach (var u in udfDet)
                {
                    UDFResponse resp = new UDFResponse()
                    {
                        UdfDetails = u
                    };
                    udfResp.Add(resp);
                }
                model.UdfDetails = udfResp;
                model.ContractDetails = contractDet;
                model.ContractResponse = new ContractResponse();
                return model;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<VendorContractListModel> GetVendorContractList(string currentUserEmail, string uniqueVendorCode)
        {
            try
            {
                //var vendor = _dbcalls.GetApprovedVendors().Where(v => v.EMAIL == vendorEmail).FirstOrDefault();
                //var vendor = _dbcalls.GetApprovedVendorusers().Where(v => v.VENDOREMAIL == vendorEmail).FirstOrDefault();
               //var vendor = _dbcalls.GetApprovedVendorusers().Where(v => v.LOGINUSEREMAIL == vendorEmail).FirstOrDefault();
                var vendor = _dbcalls.GetApprovedVendors().Where(v => v.STATUS == "1" && v.UNIQUEVENDORID == uniqueVendorCode).FirstOrDefault();
                if (vendor != null)
                {
                    var contractDetails = _dbcalls.GetVendorContractList(vendor.EMAIL, currentUserEmail);
                    return contractDetails;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public IList<ContractResponseViewModel> GetVendorContractListOld(string vendorEmail)
        {
            try
            {
                IList<ContractResponseViewModel> viewModel = new List<ContractResponseViewModel>();
                var vendor = _dbcalls.GetApprovedVendors().Where(v => v.EMAIL == vendorEmail).FirstOrDefault();
                var contractDetails = _dbcalls.GetAllContracts().Where(x => vendor != null && (x.VENDOREMAIL != null && (x.VENDORCATEGORY == vendor.CATEGORY
                                                                && x.VENDOREMAIL.Contains(vendor.EMAIL)))).OrderByDescending(y => y.CREATEDDATE).ToList();

                foreach (var c in contractDetails)
                {
                    ContractResponseViewModel modelDetails = new ContractResponseViewModel();
                    var responses = _dbcalls.GetContractResponseByContractID(c.ID);
                    var vendorResponse = responses.Where(r => r.VENDOREMAIL == vendorEmail).FirstOrDefault();
                    modelDetails.ContractDetails = c;
                    modelDetails.ContractResponse = vendorResponse;
                    viewModel.Add(modelDetails);
                }

                return viewModel;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public bool SaveContractResponse(ContractResponseViewModel response)
        {
            try
            {
                byte[] byteData1 = null;
                byte[] byteData2 = null;

                if (response.SupportingDocument1 != null)
                {
                    //First supporting document
                    var fileStream1 = response.SupportingDocument1.OpenReadStream();
                    byteData1 = new byte[fileStream1.Length];
                    fileStream1.Read(byteData1, 0, Convert.ToInt32(fileStream1.Length));
                }

                if (response.SupportingDocument2 != null)
                {
                    //Second supporting document
                    var fileStream2 = response.SupportingDocument2.OpenReadStream();
                    byteData2 = new byte[fileStream2.Length];
                    fileStream2.Read(byteData2, 0, Convert.ToInt32(fileStream2.Length));
                }

                InsertContractResponse resp = new InsertContractResponse();

                resp.CONTRACTID = response.ContractDetails != null ? response.ContractDetails.ID : response.ContractResponse.CONTRACTID;
                resp.SUPPORTINGDOC1FILENAME = response.SupportingDocument1 == null ? "" : Path.GetExtension(response.SupportingDocument1.FileName);
                resp.SUPPORTINGDOC2FILENAME = response.SupportingDocument2 == null ? "" : Path.GetExtension(response.SupportingDocument2.FileName);
                resp.SUPPORTINGDOCUMENT1 = byteData1;
                resp.SUPPORTINGDOCUMENT2 = byteData2;
                resp.VENDORCOMMENT = response.ContractResponse.VENDORCOMMENT;
                resp.VENDOREMAIL = response.ContractResponse.VENDOREMAIL;
                resp.VENDORNAME = response.ContractResponse.VENDORNAME;
                resp.CONTRACTSTATUS = response.ContractResponse.RESPONSESTATUS;
                resp.CONTRACTAMOUNT = response.ContractDetails.ContractAmount;

                var responseId = _dbcalls.InsertContractResponse(resp);
                if (responseId > 0) //successfully saved
                {
                    AuditDetails detail = new AuditDetails()
                    {
                        USERNAME = resp.VENDORNAME,
                        ACTIVITIES = $"Contract Response was successfully saved. Response ID: {responseId} ",
                        DATECREATED = DateTime.UtcNow

                    };
                    _dbcalls.InsertAudit(detail);
                    if (response.UdfDetails != null)
                    {
                        //save udf response
                        foreach (var u in response.UdfDetails)
                        {
                            string fileName = "";
                            byte[] byteData = null;
                            //get upload details if os type upload
                            if (u.UdfDetails.UDFTYPE == "Upload")
                            {
                                var fileStream = u.SupportingDoc.OpenReadStream();
                                byteData = new byte[fileStream.Length];
                                fileStream.Read(byteData, 0, Convert.ToInt32(fileStream.Length));
                                fileName = u.SupportingDoc.FileName;
                            }
                            InsertContractUDFResponse udfResp = new InsertContractUDFResponse()
                            {
                                UPLOADFILENAME = fileName,
                                CONTRACTID = response.ContractDetails.ID,
                                UPLOADVALUE = byteData,
                                TEXTVALUE = u.TextValue,
                                CONTRACTRESPONSEID = responseId,
                                RESPONSETYPE = u.UdfDetails.UDFTYPE,
                                UDFLABEL = u.UdfDetails.UDFLABEL
                            };
                            var saved = _dbcalls.InsertUDFResponse(udfResp);
                            if (saved)
                            {
                                AuditDetails detail2 = new AuditDetails()
                                {
                                    USERNAME = resp.VENDORNAME,
                                    ACTIVITIES = $"Contract Response UDF was successfully saved. UDF LABEL: {udfResp.UDFLABEL} ",
                                    DATECREATED = DateTime.UtcNow

                                };
                                _dbcalls.InsertAudit(detail2);
                            }
                        }
                    }

                }
                else
                { return false; }

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public VendorResponseDetails GetVendorResponseById(int responseId)
        {
            try
            {
                VendorResponseDetails model = new VendorResponseDetails();
                var vendorResponse = _dbcalls.GetContractResponseByID(responseId);
                var contractDetails = _dbcalls.GetContractById(vendorResponse.CONTRACTID);
                var udfResponse = _dbcalls.GetContractUDFResponseByResponseID(vendorResponse.ID);
                model.ContractDetails = contractDetails;
                model.ContractResponse = vendorResponse;
                model.UdfResponse = udfResponse;

                return model;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        //public string GenerateRandomNos()
        //      {
        //          try
        //          {
        //		Random random = new Random();
        //		var rand = random.Next(23111111, 99999999);
        //		return rand.ToString();
        //          }
        //          catch (Exception ex)
        //          {
        //		logger.Error(ex);
        //		return "";
        //          }
        //      }

        public string GenerateRandomNos()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[10000000];
                rng.GetBytes(randomNumber);
                int value = BitConverter.ToInt32(randomNumber, 0);
                return value.ToString().Replace('-', ' ');
            }
        }


        public List<string> GetLandingPages(string roleModules)
        {
            int count = roleModules.Length;
            string[] pageDet = new string[count];
            List<string> moduleList = new List<string>();
            List<string> rolemagmt = new List<string>();
            string[] roleSplit = roleModules.Split(',');

            foreach (var pageval in roleSplit)
            {
                try
                {

                    if (pageval == "Corporate Management")
                    {
                        moduleList.Add("Corporate");
                        //pageDet[0] = "Corporate";
                        //pageDet[1] = "Index";
                    }
                    if (pageval == "Contract Management")
                    {
                        moduleList.Add("Contract");
                        //pageDet[0] = "Contract";
                        //pageDet[1] = "Index";
                    }
                    if (pageval == "Vendor Response")
                    {
                        moduleList.Add("ContractResponse");
                        //pageDet[0] = "ContractResponse";
                        //pageDet[1] = "Index";
                    }
                    if (pageval == "User Management")
                    {
                        moduleList.Add("User");
                        //pageDet[0] = "User";
                        //pageDet[1] = "Index";
                    }
                    if (pageval == "Report")
                    {
                        moduleList.Add("Audit");
                        //pageDet[0] = "Audit";
                        //pageDet[1] = "Index";
                    }
                    if (pageval == "Vendor Management")
                    {
                        moduleList.Add("Vendor");
                        //pageDet[0] = "Vendor";
                        //pageDet[1] = "Index";
                    }

                    if (pageval == "Role Management")
                    {
                        moduleList.Add("Role");
                        //pageDet[0] = "Role";
                        //pageDet[1] = "Index";
                    }
                    if (pageval == "Authorize User")
                    {
                        moduleList.Add("AuthorizeUser");
                        //pageDet[0] = "User";
                        //pageDet[1] = "AuthorizeUser";
                    }
                    if (pageval == "Authorize Corporate")
                    {
                        moduleList.Add("AuthorizeCorporate");
                        //pageDet[0] = "Corporate";
                        //pageDet[1] = "AuthorizeCorporate";
                    }
                    if (pageval == "Corporate Bulk Upload")
                    {
                        moduleList.Add("CorporateBulkUpload");
                        //pageDet[0] = "CorporateBulkUpload";
                        //pageDet[1] = "Index";
                    }
                    if (pageval == "Authorize Corporate Upload")
                    {
                        moduleList.Add("AuthorizeBulkCorporate");
                        //pageDet[0] = "CorporateBulkUpload";
                        //pageDet[1] = "AuthorizeBulkCorporate";
                    }
                    if (pageval == "Vendor Category")
                    {
                        moduleList.Add("VendorCategoryList");
                        //pageDet[0] = "VendorCategoryList";
                        //pageDet[1] = "Index";
                    }
                    if (pageval == "Vendor Bulk Upload")
                    {
                        moduleList.Add("VendorBulkUpload");
                        //pageDet[0] = "VendorBulkUpload";
                        //pageDet[1] = "Index";
                    }

                    if (pageval == "Authorize Vendor Upload")
                    {
                        moduleList.Add("AuthorizeBulkVendor");
                        //pageDet[0] = "VendorBulkUpload";
                        //pageDet[1] = "AuthorizeBulkVendor";
                    }
                    if (pageval == "Invitation To Tender")
                    {
                        moduleList.Add("ContractResponse");
                        //pageDet[0] = "ContractResponse";
                        //pageDet[1] = "Index";
                    }
                    if (pageval == "Authorize Vendor")
                    {
                        moduleList.Add("AuthorizeVendor");
                        //pageDet[0] = "Vendor";
                        //pageDet[1] = "AuthorizeVendor";
                    }
                    if (pageval == "Generate Invoice")
                    {
                        moduleList.Add("Invoice");
                        //pageDet[0] = "Invoice";
                        //pageDet[1] = "Index";
                    }
                    if (pageval == "Audit")
                    {
                        moduleList.Add("Audit");
                        //pageDet[0] = "Invoice";
                        //pageDet[1] = "Index";
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    return null;
                }

                moduleList.Add(pageval);

            }

            return moduleList;


        }
        public string[] GetLandingPage(string roleModules)
        {
            string[] pageDet = new string[2];
            try
            {
                string[] roleSplit = roleModules.Split(',');
                if (roleSplit.Contains("Corporate Management"))
                {
                    pageDet[0] = "Corporate";
                    pageDet[1] = "Index";
                }
                else if (roleSplit.Contains("Contract Management"))
                {
                    pageDet[0] = "Contract";
                    pageDet[1] = "Index";
                }
                else if (roleSplit.Contains("Vendor Response"))
                {
                    pageDet[0] = "ContractResponse";
                    pageDet[1] = "Index";
                }
                else if (roleSplit.Contains("User Management"))
                {
                    pageDet[0] = "User";
                    pageDet[1] = "Index";
                }
                else if (roleSplit.Contains("Report"))
                {
                    pageDet[0] = "Audit";
                    pageDet[1] = "Index";
                }
                else if (roleSplit.Contains("Vendor Management"))
                {
                    pageDet[0] = "Vendor";
                    pageDet[1] = "Index";
                }

                else if (roleSplit.Contains("Role Management"))
                {
                    pageDet[0] = "Role";
                    pageDet[1] = "Index";
                }
                else if (roleSplit.Contains("Authorize User"))
                {
                    pageDet[0] = "User";
                    pageDet[1] = "AuthorizeUser";
                }
                else if (roleSplit.Contains("Authorize Corporate"))
                {
                    pageDet[0] = "Corporate";
                    pageDet[1] = "AuthorizeCorporate";
                }
                else if (roleSplit.Contains("Corporate Bulk Upload"))
                {
                    pageDet[0] = "CorporateBulkUpload";
                    pageDet[1] = "Index";
                }
                else if (roleSplit.Contains("Authorize Corporate Upload"))
                {
                    pageDet[0] = "CorporateBulkUpload";
                    pageDet[1] = "AuthorizeBulkCorporate";
                }
                else if (roleSplit.Contains("Vendor Category"))
                {
                    pageDet[0] = "VendorCategoryList";
                    pageDet[1] = "Index";
                }
                else if (roleSplit.Contains("Vendor Bulk Upload"))
                {
                    pageDet[0] = "VendorBulkUpload";
                    pageDet[1] = "Index";
                }

                else if (roleSplit.Contains("Authorize Vendor Upload"))
                {
                    pageDet[0] = "VendorBulkUpload";
                    pageDet[1] = "AuthorizeBulkVendor";
                }
                else if (roleSplit.Contains("Invitation To Tender"))
                {
                    pageDet[0] = "ContractResponse";
                    pageDet[1] = "Index";
                }
                else if (roleSplit.Contains("Authorize Vendor"))
                {
                    pageDet[0] = "Vendor";
                    pageDet[1] = "AuthorizeVendor";
                }
                else if (roleSplit.Contains("Generate Invoice"))
                {
                    pageDet[0] = "Invoice";
                    pageDet[1] = "Index";
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
            return pageDet;
        }
        public bool CreateUpdateUser(UpdateUser user, bool isSingleCorporate)
        {
            try
            {
                var createUpdateId = _dbcalls.UpdateInsertUser(user);

                if(createUpdateId > 0)
                {
                    // If there is a single user corporate, authorize user
                    if(isSingleCorporate)
                    {
                        UsersPending pendingUser = new UsersPending();
                        pendingUser.AUTHORIZERNAME = user.INPUTTERNAME;
                        pendingUser.AUTHORIZEREMAIL = user.INPUTTEREMAIL;
                        pendingUser.ID = createUpdateId;
                        pendingUser.AUTHORIZERCOMMENT = "";
                        pendingUser.AUTHORIZATIONSTATUS = 1;
                        pendingUser.FIRSTNAME = user.FIRSTNAME;
                        pendingUser.EMAIL = user.EMAIL;
                        pendingUser.USERNAME = user.USERNAME;

                        var authorized = AuthorizeUser(pendingUser);
                        return authorized;
                    }
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public bool AuthorizeUser(UsersPending user)
        {

            if (user.USERCLASS == "ACCESSREP")
            {
                try
                {
                    AuthorizeUser pending = new AuthorizeUser();
                    pending.Auth = user.AUTHORIZERNAME;
                    pending.AuthEmail = user.AUTHORIZEREMAIL;
                    pending.Idt = user.ID;
                    pending.AuthComment = user.AUTHORIZERCOMMENT;
                    pending.AuthStatus = user.AUTHORIZATIONSTATUS;

                    var authorized = _dbcalls.AuthorizeUser(pending);
                    if (authorized)
                    {
                        if (user.AUTHORIZATIONSTATUS == 1) // Approved
                        {
                            //send email to user with password
                            SendMailReq mailReq = new SendMailReq()
                            {
                                Content = $"<p>Good day {user.FIRSTNAME},</p><p>You have been created on the Access Bank Supply Chain platform. Please logon <a href={supplyChainUrl}>here</a> with your AD credentials with</p><p>Username: {user.USERNAME}</p><p> Regards, Supply Chain Platform Admin</p>",
                                CopyAddress = "",
                                From = "no-reply@accessbankplc.com",
                                Subject = "Supply Chain Portal Credential",
                                Recipient = user.EMAIL,
                                attachment = "",
                                DisplayAsHtml = true,
                                DisplayName = "Access Bank"
                            };
                            var mailSent = SendMail(mailReq);
                        }
                    }
                    return authorized;
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    return false;
                }
            }

            try
            {
                //generate password
                string password = GenerateReference();  //CreateTempPass(9);
                string hashedPassword = GetHashedPassword(password);
                AuthorizeUser pending = new AuthorizeUser();
                pending.Auth = user.AUTHORIZERNAME;
                pending.AuthEmail = user.AUTHORIZEREMAIL;
                pending.Idt = user.ID;
                pending.AuthComment = user.AUTHORIZERCOMMENT;
                pending.AuthStatus = user.AUTHORIZATIONSTATUS;
                pending.HashedPword = hashedPassword;

                var authorized = _dbcalls.AuthorizeUser(pending);
                if (authorized)
                {
                    if (user.AUTHORIZATIONSTATUS == 1) // Approved
                    {
                        //send email to user with password
                        SendMailReq mailReq = new SendMailReq()
                        {
                            Content = $"<p>Good day {user.FIRSTNAME},</p><p>You have been created on the Access Bank Supply Chain platform.  Please login <a href={supplyChainUrl}>here</a> with the  credential below</p><p>Username: {user.USERNAME} <br/> Password: {password}</p><p> Regards, Supply Chain Platform Admin</p>",
                            CopyAddress = "",
                            From = "no-reply@accessbankplc.com",
                            Subject = "Supply Chain Portal Credential",
                            Recipient = user.EMAIL,
                            attachment = "",
                            DisplayAsHtml = true,
                            DisplayName = "Access Bank"
                        };
                        logger.Info($"The UserName is {user.USERNAME} and the password is {password}");
                        var mailSent = SendMail(mailReq);
                    }
                }
                return authorized;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }

        }



        public bool IsUsernameUnique(string username)
        {
            try
            {
                Users user = _dbcalls.GetAllUsers().Where(u => u.USERNAME.ToUpper() == username.Trim().ToUpper()).FirstOrDefault();
                if (user != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public genericResponse IsUsernameUniquefinal(string username)
        {
            try
            {
                Users user = _dbcalls.GetAllUsers()
                    .FirstOrDefault(u => String.Equals(u.USERNAME, username.Trim(), StringComparison.CurrentCultureIgnoreCase));
                if (user != null)
                {
                    return new genericResponse()
                    {
                        errorCode = "00",
                        errorMessage = "User already exist on the Platform",
                       
                    };
                }
                else
                {
                    return new genericResponse()
                    {
                        errorCode = "99",
                        errorMessage = "New User",

                    };
                }
               
            }
            catch (Exception ex)
            {
                logger.Debug($"An exception occur trying to get the user details {ex.Message}");
            }

            return null;
        }

        public string getpendinguserinitiatoremail(string username)
        {
            string InitiatorEmail = string.Empty;
            try
            {
                UsersPending userpending = _dbcalls.GetPendingUsers()
                    .FirstOrDefault(u => String.Equals(u.USERNAME, username.Trim(), StringComparison.CurrentCultureIgnoreCase));

                if (userpending != null)
                {
                    InitiatorEmail = userpending.INPUTTEREMAIL;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return InitiatorEmail;
        }

        public bool IsEmailUnique(string email)
        {
            try
            {
                Users user = _dbcalls.GetAllUsers().Where(u => u.EMAIL.ToUpper() == email.Trim().ToUpper()).FirstOrDefault();
                if (user != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool AuthorizeContractResponse(ContractResponse details)
        {
            try
            {
                AuthorizeContractResponse authDet = new AuthorizeContractResponse()
                {
                    AuthComment = details.AUTHORIZERCOMMENT,
                    AuthEmail = details.AUTHORIZEREMAIL,
                    AuthName = details.AUTHORIZERNAME,
                    Idt = details.ID,
                    AuthStatus = details.RESPONSESTATUS
                };
                var authorized = _dbcalls.AuthorizeContractResponse(authDet);
                return authorized;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public InvoiceViewModel InitiateCreateInvoice(string vendoremail, int contractId, string discountingType, string vendorCode)
        {
            InvoiceViewModel viewModel = new InvoiceViewModel();
            try
            {
                string refNo = GenerateReference();

                ContractDetails contract = _dbcalls.GetContractById(contractId);
                VendorDetails vendor = _dbcalls.GetApprovedVendors().Where(v => v.UNIQUEVENDORID == vendorCode && v.STATUS == "1").FirstOrDefault();
                CorporateDetails corporate = _dbcalls.GetApprovedCorporates().Where(c => c.ID == contract.CORPORATEID).FirstOrDefault();
                
                if(vendor == null || corporate == null)
                {
                    return null;
                }
                ContractInvoice contractInvoice = new ContractInvoice()
                {
                    accountname = vendor.NAME,
                    accountnumber = vendor.ACCOUNTNO,
                    bankname = vendor.BANK,
                    contractid = contractId,
                    contractnumber = contract.CONTRACTNUMBER,
                    days = contract.PAYMENTTENOR, //.TIMELINEDAYS,
                    description = contract.DESCRIPTION,
                    invoicedate = DateTime.UtcNow,
                    invoicenumber = $"10{refNo}", //Generate invoice Number,
                    ponumber = contract.PONUMBER,
                    vendoraddress = vendor.ADDRESS,
                    vendoremail = vendor.EMAIL,
                    vendorname = vendor.NAME,
                    vendorphoneno = vendor.PHONENO,
                    vendorcode = vendor.UNIQUEVENDORID,
                    tin = vendor.TIN_RC,
                    projectname = contract.CONTRACTNAME
                    //vatregistrationno = vendor.nu
                };
                viewModel.InvoiceDetails = contractInvoice;

                InvoiceLoan loan = new InvoiceLoan()
                {
                    discountingtype = discountingType,
                };
                viewModel.InterestRate = corporate.INTERESTRATE;
                viewModel.FeesRate = corporate.FEESRATE;
                viewModel.LoanDetails = loan;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return viewModel;
        }

        public InvoiceViewModel InitiateCreateExternalInvoice(string uniqueVendorId, string discountingType)
        {
            InvoiceViewModel viewModel = new InvoiceViewModel();
            try
            {
                VendorDetails vendor = _dbcalls.GetApprovedVendors().Where(v => v.UNIQUEVENDORID == uniqueVendorId).FirstOrDefault();
                ContractInvoice contractInvoice = new ContractInvoice();

                if (vendor != null)
                {
                    contractInvoice.accountname = vendor.NAME;
                    contractInvoice.accountnumber = vendor.ACCOUNTNO;
                    contractInvoice.bankname = vendor.BANK;
                    contractInvoice.vendoraddress = vendor.ADDRESS;
                    contractInvoice.vendoremail = vendor.EMAIL;
                    contractInvoice.vendorname = vendor.NAME;
                    contractInvoice.vendorphoneno = vendor.PHONENO;
                    contractInvoice.vendorcode = vendor.UNIQUEVENDORID;
                    contractInvoice.tin = vendor.TIN_RC;
                }
                
                viewModel.InvoiceDetails = contractInvoice;

                InvoiceLoan loan = new InvoiceLoan()
                {
                    discountingtype = discountingType,
                };
                viewModel.LoanDetails = loan;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return viewModel;
        }

        public bool CreateInvoice(InvoiceViewModel invoiceModel)
        {
            try
            {
                bool canProceed = false;
                var invoiceId = invoiceModel.InvoiceDetails.id;
                invoiceModel.InvoiceDetails.invoicedate = null;
                invoiceModel.InvoiceDetails.requestdiscounting = invoiceModel.requestdiscounting ? 1 : 0;

                if (invoiceId > 0) // invoice update
                {
                    // archive data
                    var archived = _dbcalls.ArchiveInvoiceDetails(invoiceId);

                    // Update invoice details
                    var updated = _dbcalls.UpdateInvoiceDetails(invoiceModel.InvoiceDetails);
                    if (updated && archived)
                    {
                        canProceed = true;
                    }
                }
                else // insert new invoice record
                {
                    byte[] byteData1 = null;
                    byte[] byteData2 = null;

                    if (invoiceModel.SupportingDocument1 != null)
                    {
                        //First uploaded document
                        var fileStream1 = invoiceModel.SupportingDocument1.OpenReadStream();
                        byteData1 = new byte[fileStream1.Length];
                        fileStream1.Read(byteData1, 0, Convert.ToInt32(fileStream1.Length));
                    }

                    if (invoiceModel.SupportingDocument2 != null)
                    {
                        //Second uploaded document
                        var fileStream2 = invoiceModel.SupportingDocument2.OpenReadStream();
                        byteData2 = new byte[fileStream2.Length];
                        fileStream2.Read(byteData2, 0, Convert.ToInt32(fileStream2.Length));
                    }

                    InsertContractResponse resp = new InsertContractResponse();

                    invoiceModel.InvoiceDetails.SUPPORTINGDOC1FILENAME = invoiceModel.SupportingDocument1 == null ? "" : Path.GetFileName(invoiceModel.SupportingDocument1.FileName);
                    invoiceModel.InvoiceDetails.SUPPORTINGDOC2FILENAME = invoiceModel.SupportingDocument2 == null ? "" : Path.GetFileName(invoiceModel.SupportingDocument2.FileName);
                    invoiceModel.InvoiceDetails.SUPPORTINGDOCUMENT1 = byteData1;
                    invoiceModel.InvoiceDetails.SUPPORTINGDOCUMENT2 = byteData2;
                    //Save Invoice
                    invoiceId = _dbcalls.InsertInvoiceDetails(invoiceModel.InvoiceDetails);

                    if (invoiceId != 0)
                    {
                        canProceed = true;
                    }
                }

                if (canProceed)
                {
                    //Save Item
                    if (invoiceModel.Items != null)
                    {
                        foreach (var item in invoiceModel.Items)
                        {
                            item.INVOICEID = invoiceId;
                            _dbcalls.InsertInvoiceItemDetails(item);
                        }
                    }
                    //save loan details if any
                    if (invoiceModel.requestdiscounting)
                    {
                        invoiceModel.LoanDetails.invoiceid = invoiceId;
                        invoiceModel.LoanDetails.contractid = invoiceModel.InvoiceDetails.contractid;
                        invoiceModel.LoanDetails.vendoraccountno = invoiceModel.InvoiceDetails.accountnumber;
                        invoiceModel.LoanDetails.invoicenumber = invoiceModel.InvoiceDetails.invoicenumber;
                        invoiceModel.LoanDetails.loanstatus = LoanStatus.PENDING.ToString();
                        invoiceModel.LoanDetails.daterequested = null;
                        invoiceModel.LoanDetails.ExpectedRepaymentDate = null;
                        invoiceModel.LoanDetails.RepaymentDate = null;
                        invoiceModel.LoanDetails.disbursementDate = null;
                        invoiceModel.LoanDetails.vendoraccountname = invoiceModel.InvoiceDetails.accountname;
                        invoiceModel.LoanDetails.acceptterms = invoiceModel.acceptLoanTerms == true ? 1 : 0;
                        invoiceModel.LoanDetails.requestoremail = invoiceModel.InvoiceDetails.vendoremail;
                        invoiceModel.LoanDetails.requestorname = invoiceModel.InvoiceDetails.vendorname;
                        invoiceModel.LoanDetails.fees = invoiceModel.LoanDetails.fees;

                        _dbcalls.InsertInvoiceLoanDetails(invoiceModel.LoanDetails);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public ValidateDiscountingModel ValidateDiscountingRequest(decimal interestRate, string accountNo, decimal invoiceAmount, int duration, decimal feesRate)
        {
            ValidateDiscountingModel validateModel = new ValidateDiscountingModel();
            try
            {
                // Validate user's account number is access bank account
                GetCustAcctDetReq req = new GetCustAcctDetReq()
                {
                    account_no = accountNo
                };
                var accountDet = apiImpl.GetCustAcctDet(req);
                if (accountDet != null && accountDet.ResponseCode == "00" && accountDet.getcustomeracctsdetailsresp != null)
                {
                    validateModel.AccountName = accountDet.getcustomeracctsdetailsresp.FirstOrDefault().accountName;

                    // Compute eligible amount - (80% of invoice amount)
                    decimal eligibleAmt = decimal.Multiply((decimal)0.8, invoiceAmount);

                    // Compute fees using the corporate's fees rate
                    decimal fees = decimal.Divide(feesRate,100) * eligibleAmt;

                    // Compute interest using the corporate's interest rate
                    //Comment because process has changed and investors decide interest rate
                   // decimal interest = (eligibleAmt * interestRate * duration) / (100 * 365);

                    validateModel.Interest = 0;
                    validateModel.Fees = fees;
                    validateModel.EligibleAmount = eligibleAmt;

                    return validateModel;
                }
                else
                { return null; }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public InvoiceViewModel GetInvoiceDetails(int invoiceId)
        {
            InvoiceViewModel invoiceVM = new InvoiceViewModel();
            try
            {
                ContractInvoice invoiceDet = _dbcalls.GetInvoiceById(invoiceId);
                if (invoiceDet != null)
                {
                    var invoiceItems = _dbcalls.GetInvoiceItemsByInvoiceId(invoiceId);
                    invoiceVM.LoanDetails = _dbcalls.GetInvoiceLoanByInvoiceId(invoiceId);
                    invoiceVM.InvoiceDetails = invoiceDet;
                    invoiceVM.Items = invoiceItems;
                    return invoiceVM;
                }
                else
                {
                    return invoiceVM;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return invoiceVM;
            }
        }
        public bool ProcessInvoiceDiscounting(int invoiceId)
        {
            bool processed = false;
            try
            {
                // Get Invoice details using InvoiceId
                ContractInvoice invoicedetails = _dbcalls.GetInvoiceById(invoiceId);

                if (invoicedetails.requestdiscounting == 0)
                {
                    return true;
                }
                InvoiceLoan loanDetails = _dbcalls.GetInvoiceLoanByInvoiceId(invoiceId);
                GetCustAcctDetReq acctReq = new GetCustAcctDetReq()
                {
                    account_no = invoicedetails.accountnumber.Trim()
                };
                GetCustAcctDetRes vendorAccountDetails = apiImpl.GetCustAcctDet(acctReq);
                if (loanDetails == null || vendorAccountDetails == null || vendorAccountDetails.ResponseCode != "00" || vendorAccountDetails.getcustomeracctsdetailsresp == null)
                {
                    return false;
                }

                //string narration = "IDF Principal disbursement";
                string narration = principalIDFNarration;
                string branchCode = vendorAccountDetails.getcustomeracctsdetailsresp.FirstOrDefault().branchCode;
                
                // Debit fees upon authorization and debit loan amount and interest at maturity
                var postingRes = PostLoanTransaction(invoicedetails.accountnumber, branchCode, invoicedetails.invoicenumber, loanDetails.requestedamount, loanDetails.fees, narration, "NGN");

                if (postingRes != null && postingRes.response_code == "00")
                {
                    processed = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return processed;
        }
        private MultiJrnlTransferRes PostLoanTransaction(string vendorAccount, string vendorAcctBranchCode, string invoiceNo, decimal principalAmount, decimal fees, string narration, string currency)
        {
            try
            {
                var randNo = GenerateReference();
                MultiJrnlTransferReq postingRequest = new MultiJrnlTransferReq()
                {
                    tran_narration = $"{invoiceNo}/{narration}",
                    msg_id = $"SCP{randNo}",
                    user_loginid = postingUsername
                };

                List<Dataentry> dataentries = new List<Dataentry>();

                //debit Access pool account the full loan amount
                Dataentry entry1 = new Dataentry()
                {
                    gl_branchcode = postingGLBranch,
                    gl_ccycode = currency,
                    tran_amount = principalAmount.ToString(),
                    tran_remark = principalIDFNarration,//"Supply Chain Amount",
                    tran_code = disbursementTrnCode,
                    txn_accountno = postingGL,
                    txn_indicator = "D"
                };

                //Credit Vendor account the full loan amount
                Dataentry entry2 = new Dataentry()
                {
                    gl_branchcode = vendorAcctBranchCode,
                    gl_ccycode = currency,
                    tran_amount = principalAmount.ToString(),
                    tran_remark = principalIDFNarration,//"Supply Chain Amount",
                    tran_code = disbursementTrnCode,
                    txn_accountno = vendorAccount.Trim(),
                    txn_indicator = "C"
                };

                dataentries.Add(entry1);
                dataentries.Add(entry2);

                if (fees > 0)
                {
                    // Debit Vendor account for fee
                    Dataentry entry3 = new Dataentry()
                    {
                        gl_branchcode = vendorAcctBranchCode,
                        gl_ccycode = currency,
                        tran_amount = fees.ToString(),
                        tran_remark = feeIDFNarration,//"Supply Chain fee",
                        tran_code = disbursementTrnCode,
                        txn_accountno = vendorAccount.Trim(),
                        txn_indicator = "D"
                    };

                    // Credit Access Bank Fees GL with fee amount
                    Dataentry entry4 = new Dataentry()
                    {
                        gl_branchcode = feesGLBranch,
                        gl_ccycode = currency,
                        tran_amount = fees.ToString(),
                        tran_remark = feeIDFNarration,
                        tran_code = disbursementTrnCode,
                        txn_accountno = feesGL,
                        txn_indicator = "C"
                    };
                    dataentries.Add(entry3);
                    dataentries.Add(entry4);
                }

                
                Dataentry[] postingEntries = dataentries.ToArray();
                
                postingRequest.DataEntries = postingEntries;

                var postTransaction = apiImpl.MultiJrnlTransfer(postingRequest);

                string reqJson = JsonSerializer.Serialize(postingRequest);

                // Save payment details to the payment table
                PaymentDetails payment = new PaymentDetails()
                {
                    Amount = principalAmount,
                    Interest = fees,
                    Currency = "NGN",
                    Requestjson = reqJson,
                    Invoiceno = invoiceNo,
                    Msgid = postingRequest.msg_id,
                    Paymentdate = null,
                    Paymentreference = postTransaction == null ? "" : postTransaction.institution_reference,
                    Responsecode = postTransaction == null ? "" : postTransaction.response_code,
                    Responsemsg = postTransaction == null ? "" : postTransaction.response_message,
                    Paymenttype = PaymentType.DISBURSEMENT.ToString()

                };
                var paymentSaved = _dbcalls.SavePaymentDetails(payment);

                return postTransaction;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        private MultiJrnlTransferRes PostRecourseFactoringLoanTransaction(string corporateAccount, string corporateAcctBranchCode, string vendorAccount, string vendorAcctBranchCode, string invoiceNo, decimal principalAmount, decimal fees, string narration, string currency)
        {
            try
            {
                var randNo = GenerateReference();
                MultiJrnlTransferReq postingRequest = new MultiJrnlTransferReq()
                {
                    tran_narration = $"{invoiceNo}/{narration}",
                    msg_id = $"SCP{randNo}",
                    user_loginid = postingUsername
                };

                List<Dataentry> dataentries = new List<Dataentry>();

                // Debit Access pool account the full loan amount
                Dataentry entry1 = new Dataentry()
                {
                    gl_branchcode = postingGLBranch,
                    gl_ccycode = currency,
                    tran_amount = principalAmount.ToString(),
                    tran_remark = principaReverseFactoringNarration,
                    tran_code = disbursementTrnCode,
                    txn_accountno = postingGL,
                    txn_indicator = "D"
                };

                // Credit Corporate account the full loan amount
                Dataentry entry2 = new Dataentry()
                {
                    gl_branchcode = corporateAcctBranchCode,
                    gl_ccycode = currency,
                    tran_amount = principalAmount.ToString(),
                    tran_remark = principaReverseFactoringNarration,
                    tran_code = disbursementTrnCode,
                    txn_accountno = corporateAccount.Trim(),
                    txn_indicator = "C"
                };

                // Debit Corporate account the full loan amount
                Dataentry entry3 = new Dataentry()
                {
                    gl_branchcode = corporateAcctBranchCode,
                    gl_ccycode = currency,
                    tran_amount = principalAmount.ToString(),
                    tran_remark = principaReverseFactoringNarration,
                    tran_code = disbursementTrnCode,
                    txn_accountno = corporateAccount.Trim(),
                    txn_indicator = "D"
                };

                // Credit Vendor account the full loan amount
                Dataentry entry4 = new Dataentry()
                {
                    gl_branchcode = vendorAcctBranchCode,
                    gl_ccycode = currency,
                    tran_amount = principalAmount.ToString(),
                    tran_remark = principaReverseFactoringNarration,
                    tran_code = disbursementTrnCode,
                    txn_accountno = vendorAccount.Trim(),
                    txn_indicator = "C"
                };
                dataentries.Add(entry1);
                dataentries.Add(entry2);
                dataentries.Add(entry3);
                dataentries.Add(entry4);

                if (fees > 0)
                {
                    // Debit Corporate account fees
                    Dataentry entry5 = new Dataentry()
                    {
                        gl_branchcode = corporateAcctBranchCode,
                        gl_ccycode = currency,
                        tran_amount = fees.ToString(),
                        tran_remark = rffeeNarration,//"Supply Chain Interest",
                        tran_code = disbursementTrnCode,
                        txn_accountno = corporateAccount.Trim(),
                        txn_indicator = "D"
                    };

                    // Credit Access Bank Fees GL with interest amount
                    Dataentry entry6 = new Dataentry()
                    {
                        gl_branchcode = feesGLBranch,
                        gl_ccycode = currency,
                        tran_amount = fees.ToString(),
                        tran_remark = rffeeNarration,
                        tran_code = disbursementTrnCode,
                        txn_accountno = feesGL,
                        txn_indicator = "C"
                    };

                    dataentries.Add(entry5);
                    dataentries.Add(entry6);
                }
                
                Dataentry[] postingEntries = dataentries.ToArray();                

                postingRequest.DataEntries = postingEntries;

                var postTransaction = apiImpl.MultiJrnlTransfer(postingRequest);

                string reqJson = JsonSerializer.Serialize(postingRequest);

                // Save payment details to the payment table
                PaymentDetails payment = new PaymentDetails()
                {
                    Amount = principalAmount,
                    Interest = fees,
                    Currency = "NGN",
                    Requestjson = reqJson,
                    Invoiceno = invoiceNo,
                    Msgid = postingRequest.msg_id,
                    Paymentdate = null,
                    Paymentreference = postTransaction == null ? "" : postTransaction.institution_reference,
                    Responsecode = postTransaction == null ? "" : postTransaction.response_code,
                    Responsemsg = postTransaction == null ? "" : postTransaction.response_message,
                    Paymenttype = PaymentType.DISBURSEMENT.ToString()

                };

                var paymentSaved = _dbcalls.SavePaymentDetails(payment);

                return postTransaction;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public decimal ComputeInterest(decimal invoiceAmount, decimal interestRate, int duration)
        {
            try
            {
                //Get calculate interest using the corporate interest rate
                decimal interest = (invoiceAmount * interestRate * duration) / (100 * 365);
                decimal interest2dp = Math.Round(interest, 2);
                return interest2dp;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return -1;
            }
        }

        public decimal ComputeFees(decimal amount, decimal feesRate)
        {
            try
            {
                // compute fees using the corporate fees rate
                decimal fees = decimal.Divide(feesRate, 100) * amount;
                decimal fees2dp = Math.Round(fees, 2);
                return fees2dp;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return -1;
            }
        }

        public string SaveSingleRecourseFactoring(RecourseFactorinViewModel model)
        {
            try
            {
                //Get corporateDetails
                var corporateDetails = _dbcalls.GetApprovedCorporates().Where(x => x.ID == model.RecourseFDetails.corporateid).FirstOrDefault();
                if (corporateDetails == null)
                {
                    return "Unable to fetch corporate details";
                }
                int invoiceId = int.Parse(model.RecourseFDetails.invoicenumber);
                var invoiceDetails = _dbcalls.GetInvoiceById(invoiceId);
                if (invoiceDetails == null)
                {
                    return "Unable to fetch invoice details";
                }

                //Get contract details
                decimal interest = ComputeInterest(model.RecourseFDetails.totalamount, corporateDetails.INTERESTRATE, model.RecourseFDetails.maturityperiod);
                decimal fees = ComputeFees(model.RecourseFDetails.totalamount, corporateDetails.FEESRATE);

                string corporateAcctNo = model.CorporateLoanDetails.accountnumber.Trim();
                // Validate Corporate Account 
                GetCustAcctDetReq corpAcctReq = new GetCustAcctDetReq()
                {
                    account_no = corporateAcctNo
                };
                GetCustAcctDetRes corporateAccountDetails = apiImpl.GetCustAcctDet(corpAcctReq);
                if (corporateAccountDetails == null || corporateAccountDetails.ResponseCode != "00" || corporateAccountDetails.getcustomeracctsdetailsresp == null)
                {
                    return "Unable to validate account to debit at maturity";
                }
                string corpAcctBranchCode = corporateAccountDetails.getcustomeracctsdetailsresp.FirstOrDefault().branchCode;

                string vendorAcctNo = model.RecourseFDetails.vendoraccountno.Trim();
                // Validate Vendor's Account
                GetCustAcctDetReq vendorAcctReq = new GetCustAcctDetReq()
                {
                    account_no = vendorAcctNo
                };
                GetCustAcctDetRes vendorAccountDetails = apiImpl.GetCustAcctDet(vendorAcctReq);
                if (vendorAccountDetails == null || vendorAccountDetails.ResponseCode != "00" || vendorAccountDetails.getcustomeracctsdetailsresp == null)
                {
                    return "Unable to validate vendor's account";
                }
                string vendorAcctBranchCode = vendorAccountDetails.getcustomeracctsdetailsresp.FirstOrDefault().branchCode;

                //Save corporate loan details
                model.CorporateLoanDetails.corporateid = corporateDetails.ID;
                model.CorporateLoanDetails.corporatename = corporateDetails.CORPORATENAME;
                model.CorporateLoanDetails.contractid = invoiceDetails.contractid;
                model.CorporateLoanDetails.interest = interest;
                model.CorporateLoanDetails.availablelimit = corporateDetails.AVAILABLELINEOFCREDIT;
                model.CorporateLoanDetails.totalamount = model.RecourseFDetails.totalamount;
                model.CorporateLoanDetails.maturityperiod = model.RecourseFDetails.maturityperiod;
                model.CorporateLoanDetails.accountname = corporateAccountDetails.getcustomeracctsdetailsresp.FirstOrDefault().accountName;
                model.RecourseFDetails.FundsDisbursed = 0;
                model.CorporateLoanDetails.fees = fees;

                //model.CorporateLoanDetails.loanid = ""; // generate loanid
                int corporateLoanId = _dbcalls.InsertCorporateLoan(model.CorporateLoanDetails);
                if (corporateLoanId == 0) //unable to save corporate loan details
                {
                    return "Unable to save details. Please try again";
                }

                model.RecourseFDetails.invoiceid = invoiceDetails.id;
                model.RecourseFDetails.description = invoiceDetails.projectname;
                //post Multi Journal Entry - debit access pool account for full amount : credit corporate
                //post Multi Journal Entry - debit corporate for full amount : credit vendor
                //post Multi Journal Entry - debit corporate account for interest : credit access pool account
                //string narration = "Supply Chain Recourse Factoring";
                string narration = principaReverseFactoringNarration; //"Reverse Factoring Facility Principal  disbursement";
                var postTransRes = PostRecourseFactoringLoanTransaction(corporateAcctNo, corpAcctBranchCode, vendorAcctNo, vendorAcctBranchCode, model.RecourseFDetails.invoicenumber, model.RecourseFDetails.totalamount, fees, narration, "NGN");
                if (postTransRes == null || postTransRes.response_code != "00")//failed
                {
                    string postingMsg = postTransRes == null ? "" : postTransRes.response_message;
                    logger.Info($"Reverse Factoring failed to disburse :: invoice No : {invoiceDetails.invoicenumber} :: responseMsg : {postTransRes.response_message} :: responseCode : {postTransRes.response_code}");
                    // TODO :: Save in payment table

                    model.RecourseFDetails.loanstatus = LoanStatus.FAILEDDISBURSEMENT.ToString();
                    model.RecourseFDetails.FundsDisbursed = 0;

                    // Use corporateLoanId to save recorse factoring requests
                    model.RecourseFDetails.loanid = corporateLoanId;
                    model.RecourseFDetails.invoicenumber = invoiceDetails.invoicenumber;
                   
                    model.RecourseFDetails.contractid = invoiceDetails.contractid;
                    model.RecourseFDetails.vendoraccountname = vendorAccountDetails.getcustomeracctsdetailsresp.FirstOrDefault().accountName;
                    var recourseSaved = _dbcalls.InsertRecourseFactoring(model.RecourseFDetails);
                    return $"Unable to disburse funds. Error Message :: {postingMsg}";
                }
                else
                {
                    //update corporate loan to show funds have been disbursed
                    _dbcalls.UpdateCorporateLoanDisbursement(corporateLoanId);

                    //Update corporate details to reflect depleted corporate's available line of Credit
                    decimal newAvailableLine = corporateDetails.AVAILABLELINEOFCREDIT - model.RecourseFDetails.totalamount;
                    _dbcalls.UpdateCorporateAvailableLimit(corporateDetails.ID, newAvailableLine);

                    //model.CorporateLoanDetails.fundsdisbursed = 1;
                    model.RecourseFDetails.FundsDisbursed = 1;
                    model.RecourseFDetails.loanstatus = LoanStatus.DISBURSED.ToString();
                    model.RecourseFDetails.fcubsexternalref = postTransRes.institution_reference;
                    // Use corporateLoanId to save recorse factoring requests
                    model.RecourseFDetails.loanid = corporateLoanId;
                    model.RecourseFDetails.invoicenumber = invoiceDetails.invoicenumber;
                    model.RecourseFDetails.contractid = invoiceDetails.contractid;
                    model.RecourseFDetails.vendoraccountname = vendorAccountDetails.getcustomeracctsdetailsresp.FirstOrDefault().accountName;
                    var recourseSaved = _dbcalls.InsertRecourseFactoring(model.RecourseFDetails);
                }



                return "";
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return "Unable to process Reverse Factoring Request";
            }
        }

        public void ProcessInvoiceDiscountingRepayment()
        {
            try
            {
                // get all pending invoice for repayment
                var pendingRepaymentInvoices = _dbcalls.GetInvoicesWithPendingRepayment();

                // Build transaction blocks
                foreach (var invoice in pendingRepaymentInvoices)
                {
                    Dataentry[] postingEntries;
                    string narration = repaymentIDFNarration; //"IDF Liquidation";
                    var randNo = GenerateReference();
                    MultiJrnlTransferReq postingRequest = new MultiJrnlTransferReq()
                    {
                        tran_narration = $"{invoice.invoicenumber}/{narration}",
                        msg_id = $"SCP{randNo}",
                        user_loginid = _config["APISettings:PostingUserLoginId"]
                    };

                    var discountingTransactions = BuildDiscountingTransactions(invoice);
                    if (discountingTransactions != null && discountingTransactions[0] != null && discountingTransactions[1] != null && discountingTransactions[2] != null && discountingTransactions[3] != null)
                    {
                        postingEntries = new Dataentry[6];
                        postingEntries[2] = discountingTransactions[0];
                        postingEntries[3] = discountingTransactions[1];
                        postingEntries[4] = discountingTransactions[2];
                        postingEntries[5] = discountingTransactions[3];
                    }
                    else
                    {
                        postingEntries = new Dataentry[2];
                    }

                    var mainTransactions = BuildMainInvoiceRepaymentEntries(invoice);
                    if (mainTransactions?[0] != null && mainTransactions[1] != null)
                    {
                        postingEntries[0] = mainTransactions[0];
                        postingEntries[1] = mainTransactions[1];

                    }

                    if (postingEntries?[0] != null && postingEntries[1] != null)
                    {
                        // post transactions
                        postingRequest.DataEntries = postingEntries;
                        var postingRes = apiImpl.MultiJrnlTransfer(postingRequest);

                        bool repaymentStatus = false;
                        bool updated = false;
                        if (postingRes != null && postingRes.response_code == "00")
                        {
                            repaymentStatus = true;

                            // Update invoice table with status
                            updated = _dbcalls.UpdateInvoiceRepaymentStatus(invoice.id, repaymentStatus);
                            bool updatedLoan = _dbcalls.UpdateInvoiceLoanRepayment(invoice.id, repaymentStatus);
                        }

                        logger.Info($"Repayment processed. invoice Number :: {invoice.invoicenumber} :: Repayment Status :: {repaymentStatus} :: update status :: {updated}");

                        // Save payment details to the payment table
                        string requestJson = JsonSerializer.Serialize(postingRequest);
                        PaymentDetails payment = new PaymentDetails()
                        {
                            Amount = invoice.totalincludingvat,
                            Interest = 0,
                            Currency = "NGN",
                            Requestjson = requestJson,
                            Invoiceno = invoice.invoicenumber,
                            Msgid = postingRequest.msg_id,
                            Paymentdate = null,
                            Paymentreference = postingRes == null ? "" : postingRes.institution_reference,
                            Responsecode = postingRes == null ? "" : postingRes.response_code,
                            Responsemsg = postingRes == null ? "" : postingRes.response_message,
                            Paymenttype = PaymentType.REPAYMENT.ToString()

                        };
                        var paymentSaved = _dbcalls.SavePaymentDetails(payment);
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

        }
        public Dataentry[] BuildDiscountingTransactions(ContractInvoice invoice)
        {
            Dataentry[] postingEntries = new Dataentry[4];
            try
            {
                // confirm if discounting was requested
                var invoiceLoanDetails = _dbcalls.GetInvoiceLoanByInvoiceId(invoice.id);
                if (invoiceLoanDetails != null && invoiceLoanDetails.FundsDisbursed == 1 && invoiceLoanDetails.LoanRepaid == 0)
                {
                    if (invoice.accountnumber.Trim() == invoiceLoanDetails.vendoraccountno)
                    {
                        // revalidate account
                        string vendorLoanAcctBrn = "";
                        GetCustAcctDetReq vendorLoanAcctReq = new GetCustAcctDetReq()
                        {
                            account_no = invoiceLoanDetails.vendoraccountno
                        };
                        GetCustAcctDetRes vendorLoanAccountDetails = apiImpl.GetCustAcctDet(vendorLoanAcctReq);
                        if (vendorLoanAccountDetails != null && vendorLoanAccountDetails.ResponseCode == "00" && vendorLoanAccountDetails.getcustomeracctsdetailsresp != null)
                        {
                            vendorLoanAcctBrn = vendorLoanAccountDetails.getcustomeracctsdetailsresp.FirstOrDefault().branchCode;
                        }

                        // Debit Vendor account the full loan amount
                        Dataentry entry1 = new Dataentry()
                        {
                            gl_branchcode = vendorLoanAcctBrn,
                            gl_ccycode = "NGN",
                            tran_amount = invoiceLoanDetails.requestedamount.ToString(),
                            tran_remark = "Supply Chain Loan Repayment",
                            tran_code = postingTrnCode,
                            txn_accountno = invoiceLoanDetails.vendoraccountno.Trim(),
                            txn_indicator = "D"
                        };

                        // Credit Access pool account the full loan amount
                        Dataentry entry2 = new Dataentry()
                        {
                            gl_branchcode = postingGLBranch,
                            gl_ccycode = "NGN",
                            tran_amount = invoiceLoanDetails.requestedamount.ToString(),
                            tran_remark = "Supply Chain Loan Repayment",
                            tran_code = postingTrnCode,
                            txn_accountno = postingGL,
                            txn_indicator = "C"
                        };

                        // Debit Vendor account the interest
                        Dataentry entry3 = new Dataentry()
                        {
                            gl_branchcode = vendorLoanAcctBrn,
                            gl_ccycode = "NGN",
                            tran_amount = invoiceLoanDetails.interest.ToString(),
                            tran_remark = "Supply Chain Loan Interest",
                            tran_code = postingTrnCode,
                            txn_accountno = invoiceLoanDetails.vendoraccountno.Trim(),
                            txn_indicator = "D"
                        };

                        // Credit Access feeGL with the interest
                        Dataentry entry4 = new Dataentry()
                        {
                            gl_branchcode = interestGLBranch,
                            gl_ccycode = "NGN",
                            tran_amount = invoiceLoanDetails.interest.ToString(),
                            tran_remark = "Supply Chain Loan Interest",
                            tran_code = postingTrnCode,
                            txn_accountno = interestGL,
                            txn_indicator = "C"
                        };

                        postingEntries[0] = entry1;
                        postingEntries[1] = entry2;
                        postingEntries[2] = entry3;
                        postingEntries[3] = entry4;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return postingEntries;
        }
        public Dataentry[] BuildMainInvoiceRepaymentEntries(ContractInvoice invoice)
        {
            Dataentry[] postingEntries = new Dataentry[2];
            try
            {
                // get corporate account no from invoice id
                string corporateAcctNo = _dbcalls.GetCorporateAccountByInvoiceId(invoice.id); // fetch from db 

                // Validate Vendor's Account
                GetCustAcctDetReq vendorAcctReq = new GetCustAcctDetReq()
                {
                    account_no = invoice.accountnumber
                };
                GetCustAcctDetRes vendorAccountDetails = apiImpl.GetCustAcctDet(vendorAcctReq);
                if (vendorAccountDetails == null || vendorAccountDetails.ResponseCode != "00" || vendorAccountDetails.getcustomeracctsdetailsresp == null)
                {
                    logger.Info($"The customer detail service is returning NULL for Vendor account Number {vendorAcctReq.account_no}");
                    return null;
                }
                string vendorAcctBrn = vendorAccountDetails.getcustomeracctsdetailsresp.FirstOrDefault().branchCode;

                // validate corporate's account
                GetCustAcctDetReq corporateAcctReq = new GetCustAcctDetReq()
                {
                    account_no = corporateAcctNo
                };
                GetCustAcctDetRes corporateAccountDetails = apiImpl.GetCustAcctDet(corporateAcctReq);
                if (corporateAccountDetails == null || corporateAccountDetails.ResponseCode != "00" || corporateAccountDetails.getcustomeracctsdetailsresp == null)
                {
                    logger.Info($"The customer detail service is returning NULL for Corporate account Number {corporateAcctReq.account_no}");
                    return null;
                }
                string corporateAcctBrn = corporateAccountDetails.getcustomeracctsdetailsresp.FirstOrDefault().branchCode;

                // Debit corporate's account the full invoice amount
                Dataentry entry1 = new Dataentry()
                {
                    gl_branchcode = corporateAcctBrn,
                    gl_ccycode = "NGN",
                    tran_amount = invoice.totalincludingvat.ToString(),
                    tran_remark = "Supply Chain Vendor Payment",
                    tran_code = _config["APISettings:PostingTransactionCode"],
                    txn_accountno = corporateAcctNo,
                    txn_indicator = "D"
                };

                // Credit Vendor account the full invoice amount
                Dataentry entry2 = new Dataentry()
                {
                    gl_branchcode = vendorAcctBrn,
                    gl_ccycode = "NGN",
                    tran_amount = invoice.totalincludingvat.ToString(),
                    tran_remark = "Supply Chain Vendor Payment",
                    tran_code = _config["APISettings:PostingTransactionCode"],
                    txn_accountno = invoice.accountnumber.Trim(),
                    txn_indicator = "C"
                };

                postingEntries[0] = entry1;
                postingEntries[1] = entry2;

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            return postingEntries;
        }

        public void ProcessReverseFactoringRepayment()
        {
            try
            {
                // get all pending corporate loan details for repayment
                var pendingRepaymentLoan = _dbcalls.GetCorporateLoanWithPendingRepayment();

                // Build transaction legs
                foreach (var loan in pendingRepaymentLoan)
                {
                    // Get all reverse factoring details mapped to the corporate for the loan id
                    // var reverseFactoring = _dbcalls.GetReverseFactoringWithPendingRepayment(loan.id);

                    string narration = supplyChainRepaymentNarration;//"Supply Chain Repayment";
                    var randNo = GenerateReference();
                    MultiJrnlTransferReq postingRequest = new MultiJrnlTransferReq()
                    {
                        tran_narration = $"{loan.corporatename}/{narration}",
                        msg_id = $"SCP{randNo}",
                        user_loginid = _config["APISettings:PostingUserLoginId"]
                    };
                    //int arrayLength = reverseFactoring == null ? 2 : (reverseFactoring.Count() * 4) + 2;
                    //Dataentry[] transactions = new Dataentry[arrayLength];

                    Dataentry[] transactions = BuildReverseFactorinTransactions(loan.accountnumber, loan.totalamount, loan.interest);

                    if (transactions != null && transactions[0] != null && transactions[1] != null && transactions[2] != null && transactions[3] != null)
                    {
                        // post transactions
                        postingRequest.DataEntries = transactions;
                        var postingRes = apiImpl.MultiJrnlTransfer(postingRequest);

                        //Confirm repayment was successful
                        if (postingRes != null && postingRes.response_code == "00")
                        {
                            //Get corporateDetails
                            var corporateDetails = _dbcalls.GetApprovedCorporates().Where(x => x.ID == loan.corporateid).FirstOrDefault();

                            //Update corporate details to reflect reimbursement of corporate's available line of Credit
                            decimal newAvailableLine = corporateDetails.AVAILABLELINEOFCREDIT + loan.totalamount;
                            _dbcalls.UpdateCorporateAvailableLimit(corporateDetails.ID, newAvailableLine);

                            // Update corporate loan table and reverse factoring table
                            _dbcalls.UpdateCorporateLoanRepaymentStatus(loan.id, true);
                            _dbcalls.UpdateRecourseFactoringRepaymentStatus(loan.id, true, LoanStatus.REPAYED.ToString());
                        }

                        // Save payment details to the payment table
                        string requestJson = JsonSerializer.Serialize(postingRequest);
                        PaymentDetails payment = new PaymentDetails()
                        {
                            Amount = loan.totalamount,
                            Interest = loan.interest,
                            Currency = "NGN",
                            Requestjson = requestJson,
                            Invoiceno = "",
                            Msgid = postingRequest.msg_id,
                            Paymentdate = null,
                            Paymentreference = postingRes == null ? "" : postingRes.institution_reference,
                            Responsecode = postingRes == null ? "" : postingRes.response_code,
                            Responsemsg = postingRes == null ? "" : postingRes.response_message,
                            Paymenttype = PaymentType.REPAYMENT.ToString()

                        };
                        var paymentSaved = _dbcalls.SavePaymentDetails(payment);
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

        }
        public Dataentry[] BuildReverseFactorinTransactions(string corporateAcctNo, decimal amount, decimal interest)
        {

            try
            {
                Dataentry[] postingEntries = new Dataentry[4];

                // revalidate account
                string corporateAcctBrn = "";
                GetCustAcctDetReq corporateAcctReq = new GetCustAcctDetReq()
                {
                    account_no = corporateAcctNo
                };
                GetCustAcctDetRes corporateAccountDetails = apiImpl.GetCustAcctDet(corporateAcctReq);
                if (corporateAccountDetails != null && corporateAccountDetails.ResponseCode == "00" && corporateAccountDetails.getcustomeracctsdetailsresp != null)
                {
                    corporateAcctBrn = corporateAccountDetails.getcustomeracctsdetailsresp.FirstOrDefault().branchCode;
                }

                // Debit corporate's account the total loan amount
                Dataentry entry1 = new Dataentry()
                {
                    gl_branchcode = corporateAcctBrn,
                    gl_ccycode = "NGN",
                    tran_amount = amount.ToString(),
                    tran_remark = "Supply Chain Loan Repayment",
                    tran_code = postingTrnCode,
                    txn_accountno = corporateAcctNo.Trim(),
                    txn_indicator = "D"
                };

                // credit Access pool account the total loan amount
                Dataentry entry2 = new Dataentry()
                {
                    gl_branchcode = postingGLBranch,
                    gl_ccycode = "NGN",
                    tran_amount = amount.ToString(),
                    tran_remark = "Supply Chain Loan Repayment",
                    tran_code = postingTrnCode,
                    txn_accountno = postingGL,
                    txn_indicator = "C"
                };

                // Debit corporate's account the interest
                Dataentry entry3 = new Dataentry()
                {
                    gl_branchcode = corporateAcctBrn,
                    gl_ccycode = "NGN",
                    tran_amount = interest.ToString(),
                    tran_remark = "Supply Chain Loan Interest",
                    tran_code = postingTrnCode,
                    txn_accountno = corporateAcctNo.Trim(),
                    txn_indicator = "D"
                };

                // credit Access pool account the interest
                Dataentry entry4 = new Dataentry()
                {
                    gl_branchcode = interestGLBranch,
                    gl_ccycode = "NGN",
                    tran_amount = interest.ToString(),
                    tran_remark = "Supply Chain Loan Repayment",
                    tran_code = postingTrnCode,
                    txn_accountno = interestGL,
                    txn_indicator = "C"
                };

                postingEntries[0] = entry1;
                postingEntries[1] = entry2;
                postingEntries[2] = entry3;
                postingEntries[3] = entry4;
                
                return postingEntries;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }

        }
        public bool AuthorizeInvoice(ContractInvoice model, string authStatus)
        {
            try
            {
                string auditMsg = "";
                AuthorizeInvoice auth = new AuthorizeInvoice();
                auth.AuthEmail = model.AUTHORIZEREMAIL;
                auth.AuthName = model.AUTHORIZERNAME;
                auth.AuthStatus = authStatus;
                auth.AuthComment = model.AUTHORIZERCOMMENT;
                auth.Idt = model.id;
                auth.RepaymentDays = model.days;

                var authorized = _dbcalls.AuthorizeInvoice(auth);
                if (authorized)
                {
                    string authStat = "";
                    if (authStatus == InvoiceAuthorizationStatus.COMPLETED.ToString())
                    {
                        auditMsg = "Invoice successfully approved";
                        authStat = "Approved";
                        
                        // TODO: **** move 
                        //// Disburse funds and debit fees if discounting was requested
                        //var disbursed = ProcessInvoiceDiscounting(model.id);

                        //Update invoice loan details
                        var loanUpdated = _dbcalls.UpdateInvoiceLoanStatus(model.id, LoanStatus.APPROVED.ToString());
                       
                        //send email to all investors
                       // List<string> investors = new List<string>(); 
                       // TODO: Validate Investor's preference with vendor category;
                        IEnumerable<Investor> investors = _dbcalls.GetAllValidInvestors();

                        foreach (Investor investor in investors)
                        {
                            SendMailReq investorsMailReq = new SendMailReq()
                            {
                                Content = $"<p>Good day,</p><p>There is a loan request open to bid on Supply Chain platform.  <p> Login <a href={supplyChainUrl}>here</a> to the portal to view details. </p><p> Regards, Supply Chain Admin</p>",
                                CopyAddress = "",
                                From = "no-reply@supplychain.com",
                                Subject = "New Supply Chain Loan",
                                Recipient = investor.EMAIL,
                                attachment = "",
                                DisplayAsHtml = true,
                                DisplayName = "Supply Chain"
                            };
                            var invMailSent = SendMail(investorsMailReq);
                        }
                        if (loanUpdated)
                        {
                            auditMsg = "Invoice successfully approved, awaiting bid by investors";
                        }
                    }
                    else
                    {
                        //Update invoice loan details
                        var loanUpdated = _dbcalls.UpdateInvoiceLoanStatus(model.id, LoanStatus.REJECTED.ToString());
                        auditMsg = "Invoice successfully rejected";
                        authStat = "Rejected";
                    }

                    //send email to vendor
                    SendMailReq mailReq = new SendMailReq()
                    {
                        Content = $"<p>Good day {model.vendorname},</p><p>Your Invoice request on Supply Chain platform has been {authStat} by {model.AUTHORIZERNAME}.  <p> Login <a href={supplyChainUrl}>here</a> to the portal to view details. </p><p> Regards, Supply Chain Admin</p>",
                        CopyAddress = "",
                        From = "no-reply@supplychain.com",
                        Subject = "Supply Chain Portal Authorization",
                        Recipient = model.vendoremail,
                        attachment = "",
                        DisplayAsHtml = true,
                        DisplayName = "Supply Chain"
                    };
                    var mailSent = SendMail(mailReq);                   
                    
                }

                AuditDetails audit = new AuditDetails()
                {
                    USERNAME = model.AUTHORIZERNAME,
                    ACTIVITIES = auditMsg,
                    DATECREATED = DateTime.UtcNow
                };
                _dbcalls.InsertAudit(audit);
                return authorized;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool ChangePassword(PasswordChangeModel model)
        {
            try
            {
                if (model.NewPassword != model.ConfirmPassword)
                {
                    return false;
                }

                string hashedPassword = GetHashedPassword(model.NewPassword);
                bool updated = _dbcalls.UpdateUserPassword(model.UserId, hashedPassword);
                return updated;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public ReverseFactoringContractInvoice GetReverseFactoringInvoiceById(int invoiceId)
        {
            try
            {
                ReverseFactoringContractInvoice rfContractInv = new ReverseFactoringContractInvoice();
                ContractInvoice invoiceDet = _dbcalls.GetInvoiceById(invoiceId);
                if (invoiceDet != null)
                {
                    // Get contract details
                    ContractDetails contractDet = _dbcalls.GetContractById(invoiceDet.contractid);
                   
                    if (contractDet != null)
                    {
                        rfContractInv.ContractNumber = contractDet.CONTRACTNUMBER;
                        rfContractInv.ContractName = contractDet.CONTRACTNAME;
                        rfContractInv.ContractAmount = contractDet.ContractAmount;
                        rfContractInv.PaymentTenor = contractDet.PAYMENTTENOR;
                    }

                    //if(invoiceDet.DATEAUTHORIZED != null)
                    //{
                    //    var dt = DateTime.Now - invoiceDet.DATEAUTHORIZED;
                    //    rfContractInv.PaymentTenor = Convert.ToInt32(dt.Value.TotalDays);
                    //}
                    
                    GetCustAcctDetReq vendorAcctReq = new GetCustAcctDetReq()
                    {
                        account_no = invoiceDet.accountnumber
                    };

                    GetCustAcctDetRes vendorAccountDetails = apiImpl.GetCustAcctDet(vendorAcctReq);
                    if (vendorAccountDetails != null && vendorAccountDetails.ResponseCode == "00" && vendorAccountDetails.getcustomeracctsdetailsresp != null)
                    {
                        invoiceDet.accountname = vendorAccountDetails.getcustomeracctsdetailsresp.FirstOrDefault().accountName;
                    }
                    else
                    {
                        invoiceDet.accountnumber = "";
                        invoiceDet.accountname = "";
                    }

                    rfContractInv.ContractInvoice = invoiceDet;
                    return rfContractInv;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public Getcustomeracctsdetailsresp GetAccountDetByAccountNo(string accountNo)
        {
            Getcustomeracctsdetailsresp acctDet = new Getcustomeracctsdetailsresp();
            try
            {
                GetCustAcctDetReq acctReq = new GetCustAcctDetReq()
                {
                    account_no = accountNo
                };
                GetCustAcctDetRes accountDetails = apiImpl.GetCustAcctDet(acctReq);
                if (accountDetails != null && accountDetails.ResponseCode == "00" && accountDetails.getcustomeracctsdetailsresp != null)
                {
                    acctDet = accountDetails.getcustomeracctsdetailsresp.FirstOrDefault();
                }

                return acctDet;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public string FetchAccountNameByAccountNo(string accountNo)
        {
            try
            {
                //validate user's account number is access bank account
                GetCustAcctDetReq req = new GetCustAcctDetReq()
                {
                    account_no = accountNo
                };
                var accountDet = apiImpl.GetCustAcctDet(req);
                if (accountDet != null && accountDet.ResponseCode == "00" && accountDet.getcustomeracctsdetailsresp != null)
                {
                    string accountName = accountDet.getcustomeracctsdetailsresp.FirstOrDefault().accountName;
                    return accountName;
                }
                else
                { return ""; }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return "";
            }
        }

        public bool IsCorporateEnabled(int corporateId)
        {
            try
            {
                var corporateDet = _dbcalls.GetApprovedCorporates().Where(x => x.ID == corporateId).FirstOrDefault();
                if (corporateDet != null && corporateDet.STATUS == '1')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool IsVendorEnabled(string vendorId)
        {
            try
            {
                VendorDetails vendorDetails = _dbcalls.GetApprovedVendors().Where(x => x.UNIQUEVENDORID == vendorId).FirstOrDefault();
                return vendorDetails != null && vendorDetails.STATUS == "1";
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public UserPendingApproveModel GetUserViewModel(string userEmail, string userClass, int corporateId, int roleId,int corporateid)
        {
            UserPendingApproveModel userViewModel = new UserPendingApproveModel();
           
            try
            {

                var approvedUsers = _dbcalls.GetAllUsers(corporateid, userClass);
                var pendingUsers = _dbcalls.GetPendingUsers(userEmail, userClass, roleId, corporateid);

                // For corporate user, only display users that are vendors and mapped to the logged in corporate
                if (userClass == UserClass.CORPORATE.ToString() || userClass == UserClass.VENDORCORPORATE.ToString())
                {
                    userViewModel.userapproved = approvedUsers.Where(x => x.USERCLASS == UserClass.VENDOR.ToString() || x.USERCLASS==UserClass.CORPORATE.ToString()  && x.CORPORATECORPID == corporateId).ToList();
                    userViewModel.userpending = pendingUsers.Where(x => x.USERCLASS == UserClass.VENDOR.ToString() || x.USERCLASS == UserClass.CORPORATE.ToString() && x.CORPORATECORPID == corporateId).ToList();
                }
                else // AccessRep user
                {
                    userViewModel.userapproved = approvedUsers;
                    userViewModel.userpending = pendingUsers;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return userViewModel;
        }

        public InvoiceVendorViewModel GetVendorInvoiceDetailsByEmail(string email)
        {
            InvoiceVendorViewModel invoiceViewModel = new InvoiceVendorViewModel();
            try
            {
                IEnumerable<InvoiceList> invoiceList = _dbcalls.GetInvoiceListByVendorEmail(email);
                IEnumerable<InvoiceLoan> invoiceDiscounting = _dbcalls.GetAllInvoiceLoan().Where(x => x.requestoremail == email);

                invoiceViewModel.InvoiceDetails = invoiceList;
                invoiceViewModel.InvoiceDiscounting = invoiceDiscounting;
                invoiceViewModel.InvoiceDiscountingGL = _config["AccountingEntries:AccessBankPoolAccount"];

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return invoiceViewModel;
        }

        public bool CreateUpdateVendor(UpdateVendor vendor, bool isSingleCorporate)
        {
            try
            {
                var createUpdateId = _dbcalls.UpdateInsertVendor(vendor);

                if (createUpdateId > 0)
                {
                    // If there is a single user corporate, authorize vendor
                    if (isSingleCorporate)
                    {
                        AuthorizeVendor authorizeVendor = new AuthorizeVendor();
                        authorizeVendor.Idt = createUpdateId;
                        authorizeVendor.AuthName = vendor.CREATEDBYNAME;
                        authorizeVendor.AuthEmail = vendor.CREATEDBYEMAIL;
                        authorizeVendor.AuthComment = "";
                        authorizeVendor.AuthStatus = 1;
                        
                        var authorized = _dbcalls.AuthorizeVendor(authorizeVendor);
                        return authorized;
                    }
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool AuthourizeContract(int responseId, string authStatus, string authorizerEmail, string AuthorizerName)
        {
            AuthorizeContractResponse authDet = new AuthorizeContractResponse()
            {
                AuthEmail = authorizerEmail,
                AuthName = AuthorizerName,
                Idt = responseId,
                AuthStatus = authStatus
            };
            var authorized = _dbcalls.AuthorizeContractResponse(authDet);
            if (authorized)
            {

                var contractresponse = _dbcalls.GetContractResponseByID(responseId);
                

                SendMailReq mailReq = new SendMailReq()
                {
                    Content = $"<p>Good day {contractresponse.VENDORNAME},</p><p>A contract you bid for has been approved</p> </p>. <p>Please log in <a href={supplyChainUrl}>here</a> to view</p> <p></p> <p> Regards, Supply Chain Platform Admin</p>",
                    CopyAddress = "",
                    From = "no-reply@accessbankplc.com",
                    Subject = "Supply Chain Contract Approved",
                    Recipient = contractresponse.VENDOREMAIL,
                    attachment = "",
                    DisplayAsHtml = true,
                    DisplayName = "Access Bank"

                };
                var mailSent = SendMail(mailReq);

                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = AuthorizerName,
                    ACTIVITIES = $"Contract Bid Successfully Authorized. Bid ID: {responseId} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbcalls.InsertAudit(detail);
               
            }
            else
            {
                AuditDetails detail = new AuditDetails()
                {
                    USERNAME = AuthorizerName,
                    ACTIVITIES = $"Unable to authorize contract bid. Bid ID: {responseId} ",
                    DATECREATED = DateTime.UtcNow

                };
                _dbcalls.InsertAudit(detail);
               
            }

            return authorized;
        }

        public IEnumerable<BidViewModel> GetLoanBidListByVendor(string vendorCode)
        {
            try
            {
                return _dbcalls.GetLoanBidListByVendor(vendorCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Enumerable.Empty<BidViewModel>();
            }
        } 
        
        public IEnumerable<BidViewModel> GetAllAvailableLoanBidList(int investorId)
        {
            try
            {
                return _dbcalls.GetAllAvailableLoanBidList(investorId);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Enumerable.Empty<BidViewModel>();
            }
        }

        public IEnumerable<BidViewModel> GetLoanBidHistory(int investorId)
        {
            try
            {
                return _dbcalls.GetLoanBidHistory(investorId);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Enumerable.Empty<BidViewModel>();
            }
        }

        public IEnumerable<BidModel> GetBidsByLoanId(int loanIdt)
        {
            try
            {
                return _dbcalls.GetBidByLoanId(loanIdt);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Enumerable.Empty<BidModel>();
            }
        }

        public bool PlaceBid(InsertBid bidDetails)
        {
            try
            {
                bool bidPlaced = _dbcalls.PlaceBid(bidDetails);

                if(bidPlaced)
                {
                    // Update Loan status to Bid Ongoing, once a bid has been submitted
                    _dbcalls.UpdateLoanStatusAfterSubmittingBid(bidDetails.LOANID);
                }
                

                return bidPlaced;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool AcceptBid(int bidIdt, int loanIdt, int invoiceId)
        {
            try
            {
                bool disbursed = false;
                bool bidAccepted = _dbcalls.AcceptBid(bidIdt, loanIdt);

                if (bidAccepted)
                {
                    // Process Payment
                    // Disburse funds and debit fees
                    // TODO: Process Invoice discounting from Investor's account
                    //disbursed = ProcessInvoiceDiscounting(invoiceId);
                }
                

                return bidAccepted && disbursed;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool CreateUpdateInvestor(UpdateInvestor investor)
        {
            try
            {
                var createUpdateId = _dbcalls.UpdateInsertInvestor(investor);

                if (createUpdateId > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
    }
}
