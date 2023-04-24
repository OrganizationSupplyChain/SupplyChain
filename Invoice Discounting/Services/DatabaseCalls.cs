using Invoice_Discounting.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using Invoice_Discounting.Models.Response;
using Invoice_Discounting.Utility;
using Newtonsoft.Json;
using Invoice_Discounting.ViewModel;
using static Invoice_Discounting.Utility.Enums;

namespace Invoice_Discounting.Services
{
    public class DatabaseCalls : IDatabaseCalls
    {
        private readonly IConfiguration _config;
        private readonly string connString;
        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private IDatabaseCalls _databaseCallsImplementation;

        public DatabaseCalls(IConfiguration config)
        {
            _config = config;
            connString = _config["ConnectionStrings:InvoiceDiscountingConnStr"];
        }

        public IEnumerable<Users> GetAllUsers()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT * FROM DISCOUNTING_USERS order by createddate desc";
                using (conn)
                {
                    conn.Open();
                    List<Users> users = conn.Query<Users>(sql, commandType: CommandType.Text).ToList();

                    return users;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public Users GetUserByUsername(string username)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = $"SELECT * FROM DISCOUNTING_USERS WHERE STATUS = 1 AND TRIM(UPPER(USERNAME)) = '{username.Trim().ToUpper()}'";
                using (conn)
                {
                    conn.Open();
                    Users users = conn.Query<Users>(sql, commandType: CommandType.Text).FirstOrDefault();

                    return users;
                }
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
                OracleConnection conn = new OracleConnection(connString);
                string sql = $"SELECT * FROM DISCOUNTING_USERS WHERE STATUS = 1 AND ID = {userId}";
                using (conn)
                {
                    conn.Open();
                    Users users = conn.Query<Users>(sql, commandType: CommandType.Text).FirstOrDefault();

                    return users;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public IEnumerable<Users> GetAllUsers(int roleId, string userClass)
        {
            try
            {

                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { roleID = roleId, UserClass = userClass };
                string sql = "SELECT * FROM DISCOUNTING_USERS WHERE ROLEID= :roleID and USERCLASS= :UserClass";
                if (userClass == UserClass.ACCESSREP.ToString()) // For AccessRep also select VendorCorporate Users
                {
                    sql = "SELECT * FROM DISCOUNTING_USERS WHERE ROLEID= :roleID AND USERCLASS= :UserClass OR USERCLASS = 'VENDORCORPORATE'";
                }
                using (conn)
                {
                    conn.Open();
                    List<Users> users = conn.Query<Users>(sql, parameter, commandType: CommandType.Text).ToList();

                    return users;
                }
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
                OracleConnection conn = new OracleConnection(connString);
                username = string.IsNullOrEmpty(username) ? "" : username.ToUpper(); 
                string sql = $"UPDATE DISCOUNTING_USERS SET LASTLOGINDATE = SYSDATE WHERE UPPER(USERNAME)= :uname";
                var parameter = new { uname = username };
                using (conn)
                {
                    conn.Open();
                    int ret = conn.Execute(sql, param: parameter, commandType: CommandType.Text);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public IEnumerable<Roles> GetRoles(int roleName)
        {
            switch (roleName)
            {
                case 30:
                    try
                    {
                        OracleConnection conn = new OracleConnection(connString);
                        string sql = "SELECT * FROM DISCOUNTING_ROLE where rolename in ('RelationshipManager','AccessAdminRep','VendorAndCorporate') order by createddate desc";
                        using (conn)
                        {
                            conn.Open();
                            List<Roles> roles = conn.Query<Roles>(sql, commandType: CommandType.Text).ToList();

                            return roles;
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                        return null;
                    }

                    break;
                case 29:
                    try
                    {
                        OracleConnection conn = new OracleConnection(connString);
                        string sql = "SELECT * FROM DISCOUNTING_ROLE where rolename in ('RelationshipManager','Corporate') order by createddate desc";
                        using (conn)
                        {
                            conn.Open();
                            List<Roles> roles = conn.Query<Roles>(sql, commandType: CommandType.Text).ToList();

                            return roles;
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                        return null;
                    }


                    break;

                case 31:
                    try
                    {
                        OracleConnection conn = new OracleConnection(connString);
                        string sql = "SELECT * FROM DISCOUNTING_ROLE where rolename in ('Vendor') order by createddate desc";
                        using (conn)
                        {
                            conn.Open();
                            List<Roles> roles = conn.Query<Roles>(sql, commandType: CommandType.Text).ToList();

                            return roles;
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                        return null;
                    }

                    break;
                default:
                    try
                    {
                        OracleConnection conn = new OracleConnection(connString);
                        string sql = "SELECT * FROM DISCOUNTING_ROLE where rolename ='Vendor' order by createddate desc";
                        using (conn)
                        {
                            conn.Open();
                            List<Roles> roles = conn.Query<Roles>(sql, commandType: CommandType.Text).ToList();

                            return roles;
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                        return null;
                    }

                    break;
            }
        }

        public IEnumerable<Roles> GetRoles()
        {

            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT * FROM DISCOUNTING_ROLE order by createddate desc";
                using (conn)
                {
                    conn.Open();
                    List<Roles> roles = conn.Query<Roles>(sql, commandType: CommandType.Text).ToList();

                    return roles;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }

        }


        //public IEnumerable<CorporateDetails> GetCorporates()
        //{
        //    try
        //    {
        //        OracleConnection conn = new OracleConnection(connString);
        //        string sql = "SELECT * FROM DISCOUNTING_Corporate";
        //        using (conn)
        //        {
        //            conn.Open();
        //            List<Roles> roles = conn.Query<Roles>(sql, commandType: CommandType.Text).ToList();

        //            return roles;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex);
        //        return null;
        //    }
        //}
        public IEnumerable<Modules> GetModules()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT * FROM DISCOUNTING_MODULES order by ID desc";
                using (conn)
                {
                    conn.Open();
                    List<Modules> modules = conn.Query<Modules>(sql, commandType: CommandType.Text).ToList();

                    return modules;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public int UpdateInsertUser(UpdateUser userDetails)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                DynamicParameters userParams = new DynamicParameters();
                userParams.Add("USERID", userDetails.USERID);
                userParams.Add("USERNAME", userDetails.USERNAME);
                userParams.Add("EMAIL", userDetails.EMAIL);
                userParams.Add("FIRSTNAME", userDetails.FIRSTNAME);
                userParams.Add("LASTNAME", userDetails.LASTNAME);
                userParams.Add("ROLEID", userDetails.ROLEID);
                userParams.Add("ROLENAME", userDetails.ROLENAME);
                userParams.Add("USERTYPE", userDetails.USERTYPE);
                userParams.Add("USERCLASS", userDetails.USERCLASS);
                userParams.Add("CORPORATECORPID", userDetails.CORPORATECORPID);
                userParams.Add("VENDORCORPID", userDetails.VENDORCORPID);
                userParams.Add("STATUS", userDetails.STATUS);
                userParams.Add("HASHEDPASSWORD", userDetails.HASHEDPASSWORD);
                userParams.Add("INPUTTEREMAIL", userDetails.INPUTTEREMAIL);
                userParams.Add("INPUTTERNAME", userDetails.INPUTTERNAME);
                userParams.Add("UPDATETYPE", userDetails.UPDATETYPE);
                userParams.Add("VENDORID", userDetails.VENDORID);
                userParams.Add("idt", DbType.Int32, direction: ParameterDirection.Output);
                using (conn)
                {
                    conn.Open();
                    var savedOrUpdatedId = conn.Query<int>("PR_DISCOUNTING_USERS_PENDING", param: userParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    int userId = userParams.Get<int>("idt");
                    return userId;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return 0;
            }
        }
        public bool AuthorizeUser(AuthorizeUser user)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                using (conn)
                {
                    conn.Open();
                    int executed = conn.Execute("PR_DISCOUNTING_AUTHORIZE_USER", param: user, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public IEnumerable<CorporateDetails> GetApprovedCorporates()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT * FROM DISCOUNTING_CORPORATEDETAILS order by createddate desc";
                using (conn)
                {
                    conn.Open();
                    List<CorporateDetails> corporates = conn.Query<CorporateDetails>(sql, commandType: CommandType.Text).ToList();

                    return corporates;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<CorporateDetails> GetApprovedCorporatesbyCorporateID(int corporateid)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = $"SELECT * FROM DISCOUNTING_CORPORATEDETAILS WHERE ID={corporateid}  order by createddate desc";
                using (conn)
                {
                    conn.Open();
                    List<CorporateDetails> corporates = conn.Query<CorporateDetails>(sql, commandType: CommandType.Text).ToList();

                    return corporates;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<VendorDetails> GetApprovedVendorsbyCorporateID(int corporateid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VendorContractBidsDetails> GetContractbidsbyVendorEmail(string vendoremail)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = $"SELECT A.VENDORNAME,A.RESPONSESTATUS, C.CORPORATENAME, C.UNIQUECORPORATEID, B.CONTRACTNUMBER , B.CONTRACTNAME FROM DISCOUNTING_CONTRACT_RESPONSE A LEFT OUTER JOIN DISCOUNTING_CONTRACT B ON B.ID = A.CONTRACTID LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS C ON C.ID = B.CORPORATEID  WHERE A.VENDOREMAIL  in ({vendoremail})";
                using (conn)
                {
                    conn.Open();
                    List<VendorContractBidsDetails> vendorbidslist = conn.Query<VendorContractBidsDetails>(sql, commandType: CommandType.Text).ToList();

                    return vendorbidslist;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }


        public decimal GetSumOfInvoice()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT ROUND(Sum(a.TotalIncludingvat + b.totalamount),2)TOTAL FROM DISCOUNTING_INVOICE a Join DISCOUNTING_INVOICE_LOAN b ON a.ID = b.InvoiceID"; ;

                using (conn)
                {
                    conn.Open();
                    var sum = conn.Query<decimal>(sql, commandType: CommandType.Text).FirstOrDefault();

                    return sum;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return 0;
            }
        }

        public decimal GetSumOfRecourseFactoring()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT ROUND(Sum(TotalAmount + Interest),2)Total from DISCOUNTING_CORPORATE_LOAN where fundsdisbursed ='1'";
                using (conn)
                {
                    conn.Open();
                    var sum = conn.Query<decimal>(sql, commandType: CommandType.Text).FirstOrDefault();

                    return sum;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return 0;
            }
        }

        //public IEnumerable<VendorDetails> GetApprovedVendor()
        //{
        //    try
        //    {
        //        OracleConnection conn = new OracleConnection(connString);
        //        string sql = "SELECT * FROM DISCOUNTING_Vendor order by ID desc";
        //        using (conn)
        //        {
        //            conn.Open();
        //            List<VendorDetails> vendors = conn.Query<VendorDetails>(sql, commandType: CommandType.Text).ToList();

        //            return vendors;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex);
        //        return null;
        //    }
        //}

        public IEnumerable<AuditDetails> GetAuditDetails()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT * FROM DISCOUNTING_AUDIT order by datecreated desc";
                using (conn)
                {
                    conn.Open();
                    List<AuditDetails> audit = conn.Query<AuditDetails>(sql, commandType: CommandType.Text).ToList();

                    return audit;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<CorporateDetailsPending> GetPendingCorporates(string currentuseremail)
        {

            try
            {
                var parameter = new { currentEmail = currentuseremail };
                OracleConnection conn = new OracleConnection(connString);
                string sql = $"SELECT * FROM DISCOUNTING_CORPDET_PENDING WHERE AUTHORIZATIONSTATUS=0 AND (CREATEDBYEMAIL != :currentEmail OR CREATEDBYEMAIL IS NULL) order by createddate desc";
                using (conn)
                {
                    conn.Open();
                    List<CorporateDetailsPending> corporates = conn.Query<CorporateDetailsPending>(sql, parameter, commandType: CommandType.Text).ToList();

                    return corporates;


                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }

            //try
            //{
            //    OracleConnection conn = new OracleConnection(connString);
            //    string sql = $"SELECT * FROM DISCOUNTING_CORPDET_PENDING WHERE AUTHORIZATIONSTATUS=0 AND CREATEDBYEMAIL != '{currentuseremail}' order by createddate desc";
            //    using (conn)
            //    {
            //        conn.Open();
            //        List<CorporateDetailsPending> corporates = conn.Query<CorporateDetailsPending>(sql, commandType: CommandType.Text).ToList();

            //        return corporates;


            //    }
            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex);
            //    return null;
            //}
        }

        public List<BankList> GetAllBanksNew()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);

                string sql = "SELECT * FROM DISCOUNTING_BANKS";
                using (conn)
                {
                    conn.Open();
                    var banks = conn.Query<BankList>(sql, commandType: CommandType.Text).ToList();

                    return banks;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public List<CategoryList> GetCategoryLists()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT * FROM DISCOUNTING_CATEGORYLIST WHERE STATUS='A' order by datecreated desc";
                using (conn)
                {
                    conn.Open();
                    List<CategoryList> categorylist = conn.Query<CategoryList>(sql, commandType: CommandType.Text).ToList();

                    return categorylist;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public bool UpdateInsertCategoryList(UpdateCategoryList categoryList)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                using (conn)
                {
                    conn.Open();
                    var savedOrUpdated = conn.Execute("PR_DISCOUNTING_CATEGORYLIST", param: categoryList, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool UpdateInsertCorporate(UpdateCorporate corporateDetails)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                using (conn)
                {
                    conn.Open();
                    var savedOrUpdated = conn.Execute("PR_DISCOUNTING_CORP_PENDING", param: corporateDetails, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool InsertVendorBulk(UpdateVendorBulk vendorBulk)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                using (conn)
                {
                    conn.Open();
                    var savedOrUpdated = conn.Execute("PR_DISCOUNTING_BULK_PENDING", param: vendorBulk, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool InsertCorporateBulk(UpdateCorporateBulk corporateBulk)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                using (conn)
                {
                    conn.Open();
                    var savedOrUpdated = conn.Execute("PR_DISCOUNT_BULKCORP_PENDING", param: corporateBulk, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool InsertAudit(AuditDetails audit)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                using (conn)
                {
                    conn.Open();
                    var savedOrUpdated = conn.Execute("PR_DISCOUNTING_AUDIT", param: audit, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool AuthorizeCorporate(AuthorizeCorporate corporate)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                using (conn)
                {
                    conn.Open();
                    int executed = conn.Execute("PR_DISCOUNTING_AUTHORIZE_CORP", param: corporate, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool UpdateLogonStatus(int userId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = userId };
                using (conn)
                {
                    conn.Open();
                    int executed = conn.Execute("PR_DISCOUNTING_UPDUSERLOGON", param: parameter, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool UpdateLogonStatusbyUsername(string username)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = username };
                using (conn)
                {
                    conn.Open();
                    int executed = conn.Execute("PR_DISCOUNTING_UPDUSERBYNAME", param: parameter, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool UpdateFailureTries(int userId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = userId };
                using (conn)
                {
                    conn.Open();
                    int executed = conn.Execute("PR_DISCOUNTING_UPDFAILURETRIES", param: parameter, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public bool UpdateLoginFailureCount(int id)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = id };
                string sql = "UPDATE DISCOUNTING_USERS SET FailureTries=FailureTries+1 WHERE ID = :idt";
                using (conn)
                {
                    conn.Open();
                    var updated = conn.Execute(sql, param: parameter, commandType: CommandType.Text);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public bool LockUserProfile(int id)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = id, lockStat = "1" };
                string sql = "UPDATE DISCOUNTING_USERS SET LockStatus = :lockStat, LASTLOCKTIME = SYSDATE WHERE ID = :idt";
                using (conn)
                {
                    conn.Open();
                    var updated = conn.Execute(sql, param: parameter, commandType: CommandType.Text);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public bool InsertUpdateRole(RoleUpdate role)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);

                using (conn)
                {
                    conn.Open();
                    var updated = conn.Execute("PR_DISCOUNTING_ROLE", param: role, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public Users GetUserDetailsVM(int id)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { userid = id };

                string sql = "SELECT A.*,vendor.NAME VENDORNAME,corp.CORPORATENAME CORPORATEUSERSCORP,corpVendor.CORPORATENAME VENDORUSERSCORP \n " +
                            "FROM DISCOUNTING_USERS A " +
                            "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS corp ON A.CORPORATECORPID = corp.ID \n" +
                            "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS corpVendor ON A.VENDORCORPID = corpVendor.ID \n" +
                            "LEFT OUTER JOIN DISCOUNTING_VENDOR vendor ON A.VENDORID = vendor.UNIQUEVENDORID \n" +
                            "WHERE A.ID = :userid ";
                using (conn)
                {
                    conn.Open();
                    Users users = conn.Query<Users>(sql, param: parameter, commandType: CommandType.Text).FirstOrDefault();

                    return users;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<UsersPending> GetPendingUsers(string currentuseremail, string userclass, int roleId,int corporateId)
        {
            try
            {
                string sql = string.Empty;
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { uemail = currentuseremail, uclass = userclass, roleid = roleId,coporateid= corporateId };

                if (userclass == "ACCESSREP")
                {
                    sql = "SELECT A.ID,A.USERNAME,A.FIRSTNAME,A.LASTNAME,A.EMAIL,A.ROLEID,A.USERTYPE,A.USERCLASS,A.CORPORATECORPID,A.VENDORCORPID,A.STATUS,A.VENDORID, \n" +
                          "A.FAILURETRIES,A.LOCKSTATUS,A.LASTLOCKTIME,A.HASHEDPASSWORD,A.ISPASSWORDNEWLYCREATED,A.INPUTTEREMAIL,A.CREATEDDATE,A.LASTLOGINDATE,\n" +
                          "A.INPUTTERNAME,A.AUTHORIZEREMAIL,A.AUTHORIZERNAME,A.LASTUPDATETIME,AUTHORIZATIONSTATUS,A.AUTHORIZERCOMMENT,A.DATEAUTHORIZED,\n" +
                          "A.USERID,A.UPDATETYPE,A.ROLENAME,vendor.NAME VENDORNAME,corp.CORPORATENAME CORPORATEUSERSCORP,corpVendor.CORPORATENAME VENDORUSERSCORP \n " +
                          "FROM DISCOUNTING_USERS_PENDING A " +
                          "LEFT OUTER JOIN DISCOUNTING_USERS B ON A.INPUTTEREMAIL = B.EMAIL \n" +
                          "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS corp ON A.CORPORATECORPID = corp.ID \n" +
                          "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS corpVendor ON A.VENDORCORPID = corpVendor.ID \n" +
                          "LEFT OUTER JOIN DISCOUNTING_VENDOR vendor ON A.VENDORID = vendor.UNIQUEVENDORID \n" +
                          "WHERE A.AUTHORIZATIONSTATUS = 0 AND B.USERCLASS = :uclass  AND A.INPUTTEREMAIL != :uemail \n" +
                          "AND B.ROLEID = :roleid  order by A.createddate desc";
                }
                else if(userclass == "CORPORATE")
                {
                    sql = "SELECT A.ID,A.USERNAME,A.FIRSTNAME,A.LASTNAME,A.EMAIL,A.ROLEID,A.USERTYPE,A.USERCLASS,A.CORPORATECORPID,A.VENDORCORPID,A.STATUS,A.VENDORID, \n" +
                          "A.FAILURETRIES,A.LOCKSTATUS,A.LASTLOCKTIME,A.HASHEDPASSWORD,A.ISPASSWORDNEWLYCREATED,A.INPUTTEREMAIL,A.CREATEDDATE,A.LASTLOGINDATE,\n" +
                          "A.INPUTTERNAME,A.AUTHORIZEREMAIL,A.AUTHORIZERNAME,A.LASTUPDATETIME,AUTHORIZATIONSTATUS,A.AUTHORIZERCOMMENT,A.DATEAUTHORIZED,\n" +
                          "A.USERID,A.UPDATETYPE,A.ROLENAME,vendor.NAME VENDORNAME,corp.CORPORATENAME CORPORATEUSERSCORP,corpVendor.CORPORATENAME VENDORUSERSCORP \n " +
                          "FROM DISCOUNTING_USERS_PENDING A " +
                          "LEFT OUTER JOIN DISCOUNTING_USERS B ON A.INPUTTEREMAIL = B.EMAIL \n" +
                          "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS corp ON A.CORPORATECORPID = corp.ID \n" +
                          "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS corpVendor ON A.VENDORCORPID = corpVendor.ID \n" +
                          "LEFT OUTER JOIN DISCOUNTING_VENDOR vendor ON A.VENDORID = vendor.UNIQUEVENDORID \n" +
                          "WHERE A.AUTHORIZATIONSTATUS = 0 AND B.USERCLASS = :uclass  AND A.INPUTTEREMAIL != :uemail \n" +
                          "AND B.ROLEID in ('32','31') AND A.VENDORCORPID=:coporateid  order by A.createddate desc";
                }
                else
                {
                    sql = "SELECT A.ID,A.USERNAME,A.FIRSTNAME,A.LASTNAME,A.EMAIL,A.ROLEID,A.USERTYPE,A.USERCLASS,A.CORPORATECORPID,A.VENDORCORPID,A.STATUS,A.VENDORID, \n" +
                          "A.FAILURETRIES,A.LOCKSTATUS,A.LASTLOCKTIME,A.HASHEDPASSWORD,A.ISPASSWORDNEWLYCREATED,A.INPUTTEREMAIL,A.CREATEDDATE,A.LASTLOGINDATE,\n" +
                          "A.INPUTTERNAME,A.AUTHORIZEREMAIL,A.AUTHORIZERNAME,A.LASTUPDATETIME,AUTHORIZATIONSTATUS,A.AUTHORIZERCOMMENT,A.DATEAUTHORIZED,\n" +
                          "A.USERID,A.UPDATETYPE,A.ROLENAME,vendor.NAME VENDORNAME,corp.CORPORATENAME CORPORATEUSERSCORP,corpVendor.CORPORATENAME VENDORUSERSCORP \n " +
                          "FROM DISCOUNTING_USERS_PENDING A " +
                          "LEFT OUTER JOIN DISCOUNTING_USERS B ON A.INPUTTEREMAIL = B.EMAIL \n" +
                          "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS corp ON A.CORPORATECORPID = corp.ID \n" +
                          "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS corpVendor ON A.VENDORCORPID = corpVendor.ID \n" +
                          "LEFT OUTER JOIN DISCOUNTING_VENDOR vendor ON A.VENDORID = vendor.UNIQUEVENDORID \n" +
                          "WHERE A.AUTHORIZATIONSTATUS = 0 AND B.USERCLASS = :uclass  AND A.INPUTTEREMAIL != :uemail \n" +
                          "AND B.ROLEID = :roleid AND A.CORPORATECORPID=:coporateid  order by A.createddate desc";
                }

                using (conn)
                {
                    conn.Open();
                    List<UsersPending> users = conn.Query<UsersPending>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return users;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<UsersPending> GetPendingUsers()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                //var parameter = new { uemail = currentuseremail, uclass = userclass, roleid = roleId };

                string sql = "SELECT * FROM DISCOUNTING_USERS_pending order by createddate desc";
                using (conn)
                {
                    conn.Open();
                    List<UsersPending> users = conn.Query<UsersPending>(sql, commandType: CommandType.Text).ToList();

                    return users;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public Users GetLoginUser(string username, string password)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { uname = username, passwrd = password };
                string sql = "SELECT * FROM DISCOUNTING_USERS WHERE username = :uname AND hashedpassword = :passwrd order by createddate desc";
                using (conn)
                {
                    conn.Open();
                    var userDet = conn.Query<Users>(sql, param: parameter, commandType: CommandType.Text).FirstOrDefault();

                    return userDet;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public bool AuthorizeVendor(AuthorizeVendor vendor)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                using (conn)
                {
                    conn.Open();
                    int executed = conn.Execute("PR_DISCOUNTING_AUTH_Vendor", param: vendor, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        //public List<VendorDetails> GetPendingVendorDetails(int idx)
        //{
        //    try
        //    {
        //        OracleConnection conn = new OracleConnection(connString);
        //        var parameter = new { idt = idx };
        //        string sql = "SELECT * FROM DISCOUNTING_VENDORBULK_PENDING WHERE ID = :idt";
        //        using (conn)
        //        {
        //            conn.Open();
        //            var response = conn.Query<ContractResponse>(sql, param: parameter, commandType: CommandType.Text).FirstOrDefault();

        //            return response;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex);
        //        return null;
        //    }
        //}

        public string InsertBulkCorporate(List<CorporateDetails> corporatedetails, AuthorizeBulkCorporate authCoporate)
        {
            if (authCoporate.AuthStatus == 1)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(corporatedetails);
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

                    string[] ids = new string[dt.Rows.Count];
                    string[] COPORATENAMES = new string[dt.Rows.Count];
                    string[] EMAILS = new string[dt.Rows.Count];
                    string[] PHONENOS = new string[dt.Rows.Count];
                    string[] ACCOUNTNOS = new string[dt.Rows.Count];
                    DateTime[] DATECREATED = new DateTime[dt.Rows.Count];
                    string[] CREATEDBYNAMES = new string[dt.Rows.Count];
                    string[] CREATEDBYEMAILS = new string[dt.Rows.Count];
                    char[] STATUSES = new char[dt.Rows.Count];
                    string[] AUTHORIZERNAMES = new string[dt.Rows.Count];
                    DateTime[] DATEAUTHORIZED = new DateTime[dt.Rows.Count];
                    string[] AUTHORIZATIONSTATUS = new string[dt.Rows.Count];
                    string[] INTERESTRATE = new string[dt.Rows.Count];
                    string[] AVAILABLELINEOFCREDIT = new string[dt.Rows.Count];
                    string approvedate = DateTime.Now.ToString("yyyy-MM-dd");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        COPORATENAMES[i] = Convert.ToString(dt.Rows[i]["CORPORATENAME"]);
                        EMAILS[i] = Convert.ToString(dt.Rows[i]["PRINCIPALEMAIL"]);
                        PHONENOS[i] = Convert.ToString(dt.Rows[i]["PRINCIPALPHONENO"]);
                        ACCOUNTNOS[i] = Convert.ToString(dt.Rows[i]["PRINCIPALACCOUNTNO"]);
                        DATECREATED[i] = DateTime.Parse(approvedate, CultureInfo.InvariantCulture);//Convert.ToDateTime(dt.Rows[i]["DATECREATED"]);
                        CREATEDBYNAMES[i] = Convert.ToString(dt.Rows[i]["CREATEDBYNAME"]);
                        CREATEDBYEMAILS[i] = Convert.ToString(dt.Rows[i]["CREATEDBYEMAIL"]);
                        INTERESTRATE[i] = Convert.ToString(dt.Rows[i]["INTERESTRATE"]);
                        AVAILABLELINEOFCREDIT[i] = Convert.ToString(dt.Rows[i]["AVAILABLELINEOFCREDIT"]);
                        STATUSES[i] = '1';//Convert.ToString(dt.Rows[i]["STATUS"]);
                        AUTHORIZERNAMES[i] = authCoporate.AuthName;//Convert.ToString(dt.Rows[i]["AUTHORIZERNAME"]);
                        DATEAUTHORIZED[i] = DateTime.Parse(approvedate, CultureInfo.InvariantCulture);//Convert.ToDateTime(dt.Rows[i]["DATEAUTHORIZED"]);
                                                                                                      //AUTHORIZATIONSTATUS[i] = Convert.ToString(dt.Rows[i]["AUTHORIZATIONSTATUS"]);
                    }

                    OracleParameter coporatename = new OracleParameter();
                    coporatename.OracleDbType = OracleDbType.NVarchar2;
                    coporatename.Value = COPORATENAMES;


                    OracleParameter phoneno = new OracleParameter();
                    phoneno.OracleDbType = OracleDbType.NVarchar2;
                    phoneno.Value = PHONENOS;

                    OracleParameter email = new OracleParameter();
                    email.OracleDbType = OracleDbType.NVarchar2;
                    email.Value = EMAILS;

                    OracleParameter accountno = new OracleParameter();
                    accountno.OracleDbType = OracleDbType.NVarchar2;
                    accountno.Value = ACCOUNTNOS;


                    OracleParameter datecreated = new OracleParameter();
                    datecreated.OracleDbType = OracleDbType.Date;
                    datecreated.Value = DATECREATED;

                    OracleParameter createdbyname = new OracleParameter();
                    createdbyname.OracleDbType = OracleDbType.NVarchar2;
                    createdbyname.Value = CREATEDBYNAMES;

                    OracleParameter createdbyemail = new OracleParameter();
                    createdbyemail.OracleDbType = OracleDbType.NVarchar2;
                    createdbyemail.Value = CREATEDBYEMAILS;

                    OracleParameter status = new OracleParameter();
                    status.OracleDbType = OracleDbType.Char;
                    status.Value = STATUSES;

                    OracleParameter authorizename = new OracleParameter();
                    authorizename.OracleDbType = OracleDbType.NVarchar2;
                    authorizename.Value = AUTHORIZERNAMES;

                    OracleParameter dateauthorized = new OracleParameter();
                    dateauthorized.OracleDbType = OracleDbType.Date;
                    dateauthorized.Value = DATEAUTHORIZED;

                    OracleParameter interestrate = new OracleParameter();
                    createdbyemail.OracleDbType = OracleDbType.Decimal;
                    createdbyemail.Value = INTERESTRATE;

                    OracleParameter availablelineofcredit = new OracleParameter();
                    createdbyemail.OracleDbType = OracleDbType.Decimal;
                    createdbyemail.Value = AVAILABLELINEOFCREDIT;

                    OracleConnection conn = new OracleConnection(connString);
                    using (conn)
                    {
                        conn.Open();
                        //Create Command and set properties
                        OracleCommand cmd = conn.CreateCommand();

                        cmd.CommandText = "INSERT INTO DISCOUNTING_CORPORATEDETAILS (CORPORATENAME,PRINCIPALPHONENO,PRINCIPALEMAIL,PRINCIPALACCOUNTNO,CREATEDDATE,CREATEDBYNAME,CREATEDBYEMAIL,STATUS,AUTHORIZERNAME,DATEAUTHORIZED,INTERESTRATE,AVAILABLELINEOFCREDIT)  VALUES (:1, :2, :3, :4, :5, :6, :7, :8, :9, :10, :11, :12)";
                        cmd.ArrayBindCount = ids.Length;
                        cmd.Parameters.Add(coporatename);
                        cmd.Parameters.Add(phoneno);
                        cmd.Parameters.Add(email);
                        cmd.Parameters.Add(accountno);
                        cmd.Parameters.Add(datecreated);
                        cmd.Parameters.Add(createdbyname);
                        cmd.Parameters.Add(createdbyemail);
                        cmd.Parameters.Add(status);
                        cmd.Parameters.Add(authorizename);
                        cmd.Parameters.Add(dateauthorized);
                        cmd.Parameters.Add(interestrate);
                        cmd.Parameters.Add(availablelineofcredit);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    logger.Debug($"Error during bulk insert{ex.Message}");
                }
            }
            else
            {
                //The Authorizer Disapproved the bulk excel
                try
                {
                    OracleConnection conn = new OracleConnection(connString);
                    var parameter = new { bulkid = authCoporate.Idt };
                    string sql = "UPDATE DISCOUNTING_CORPBULK_PENDING SET AUTH_STATUS = '1' WHERE ID = :bulkid";
                    using (conn)
                    {
                        conn.Open();
                        conn.Execute(sql, param: parameter, commandType: CommandType.Text);

                        return "okD";
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    return "okD";
                }

            }

            //After Successful insertion///
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { bulkid = authCoporate.Idt };
                string sql = "UPDATE DISCOUNTING_CORPBULK_PENDING SET AUTH_STATUS = '1' WHERE ID = :bulkid";
                using (conn)
                {
                    conn.Open();
                    conn.Execute(sql, param: parameter, commandType: CommandType.Text);


                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);

            }

            return "OK";
        }

        public string InsertBulkVendor(List<VendorDetails> vendordetails, AuthorizeBulkVendor authVendor)
        {
            if (authVendor.AuthStatus == 1)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(vendordetails);
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

                    string[] ids = new string[dt.Rows.Count];
                    string[] CATEGORYS = new string[dt.Rows.Count];
                    string[] NAMES = new string[dt.Rows.Count];
                    string[] PHONENOS = new string[dt.Rows.Count];
                    string[] EMAILS = new string[dt.Rows.Count];
                    string[] ACCOUNTNOS = new string[dt.Rows.Count];
                    string[] ADDRESSES = new string[dt.Rows.Count];
                    string[] BANKS = new string[dt.Rows.Count];
                    string[] TIN_RCS = new string[dt.Rows.Count];
                    string[] SERVICENATURES = new string[dt.Rows.Count];
                    DateTime[] DATECREATED = new DateTime[dt.Rows.Count];
                    string[] CREATEDBYNAMES = new string[dt.Rows.Count];
                    string[] CREATEDBYEMAILS = new string[dt.Rows.Count];
                    string[] STATUSES = new string[dt.Rows.Count];
                    string[] AUTHORIZERNAMES = new string[dt.Rows.Count];
                    DateTime[] DATEAUTHORIZED = new DateTime[dt.Rows.Count];
                    string[] AUTHORIZATIONSTATUS = new string[dt.Rows.Count];
                    string approvedate = DateTime.Now.ToString("yyyy-MM-dd");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CATEGORYS[i] = Convert.ToString(dt.Rows[i]["CATEGORY"]);
                        NAMES[i] = Convert.ToString(dt.Rows[i]["NAME"]);
                        PHONENOS[i] = Convert.ToString(dt.Rows[i]["PHONENO"]);
                        EMAILS[i] = Convert.ToString(dt.Rows[i]["EMAIL"]);
                        ACCOUNTNOS[i] = Convert.ToString(dt.Rows[i]["ACCOUNTNO"]);
                        ADDRESSES[i] = Convert.ToString(dt.Rows[i]["ADDRESS"]);
                        BANKS[i] = Convert.ToString(dt.Rows[i]["BANK"]);
                        TIN_RCS[i] = Convert.ToString(dt.Rows[i]["TIN_RC"]);
                        SERVICENATURES[i] = Convert.ToString(dt.Rows[i]["SERVICENATURE"]);
                        DATECREATED[i] = DateTime.Parse(approvedate, CultureInfo.InvariantCulture);//Convert.ToDateTime(dt.Rows[i]["DATECREATED"]);
                        CREATEDBYNAMES[i] = Convert.ToString(dt.Rows[i]["CREATEDBYNAME"]);
                        CREATEDBYEMAILS[i] = Convert.ToString(dt.Rows[i]["CREATEDBYEMAIL"]);
                        // STATUSES[i] = Convert.ToString(dt.Rows[i]["STATUS"]);
                        AUTHORIZERNAMES[i] = authVendor.AuthName;//Convert.ToString(dt.Rows[i]["AUTHORIZERNAME"]);
                        DATEAUTHORIZED[i] = DateTime.Parse(approvedate, CultureInfo.InvariantCulture);//Convert.ToDateTime(dt.Rows[i]["DATEAUTHORIZED"]);
                                                                                                      //AUTHORIZATIONSTATUS[i] = Convert.ToString(dt.Rows[i]["AUTHORIZATIONSTATUS"]);
                    }

                    OracleParameter category = new OracleParameter();
                    category.OracleDbType = OracleDbType.NVarchar2;
                    category.Value = CATEGORYS;

                    OracleParameter name = new OracleParameter();
                    name.OracleDbType = OracleDbType.NVarchar2;
                    name.Value = NAMES;

                    OracleParameter phoneno = new OracleParameter();
                    phoneno.OracleDbType = OracleDbType.NVarchar2;
                    phoneno.Value = PHONENOS;

                    OracleParameter email = new OracleParameter();
                    email.OracleDbType = OracleDbType.NVarchar2;
                    email.Value = EMAILS;

                    OracleParameter accountno = new OracleParameter();
                    accountno.OracleDbType = OracleDbType.NVarchar2;
                    accountno.Value = ACCOUNTNOS;

                    OracleParameter address = new OracleParameter();
                    address.OracleDbType = OracleDbType.NVarchar2;
                    address.Value = ADDRESSES;

                    OracleParameter bank = new OracleParameter();
                    bank.OracleDbType = OracleDbType.NVarchar2;
                    bank.Value = BANKS;

                    OracleParameter tin_rc = new OracleParameter();
                    tin_rc.OracleDbType = OracleDbType.NVarchar2;
                    tin_rc.Value = TIN_RCS;

                    OracleParameter servicenature = new OracleParameter();
                    servicenature.OracleDbType = OracleDbType.NVarchar2;
                    servicenature.Value = SERVICENATURES;

                    OracleParameter datecreated = new OracleParameter();
                    datecreated.OracleDbType = OracleDbType.Date;
                    datecreated.Value = DATECREATED;

                    OracleParameter createdbyname = new OracleParameter();
                    createdbyname.OracleDbType = OracleDbType.NVarchar2;
                    createdbyname.Value = CREATEDBYNAMES;

                    OracleParameter createdbyemail = new OracleParameter();
                    createdbyemail.OracleDbType = OracleDbType.NVarchar2;
                    createdbyemail.Value = CREATEDBYEMAILS;

                    //OracleParameter status = new OracleParameter();
                    //category.OracleDbType = OracleDbType.NVarchar2;
                    //category.Value = STATUSES;

                    OracleParameter authorizename = new OracleParameter();
                    authorizename.OracleDbType = OracleDbType.NVarchar2;
                    authorizename.Value = AUTHORIZERNAMES;

                    OracleParameter dateauthorized = new OracleParameter();
                    dateauthorized.OracleDbType = OracleDbType.Date;
                    dateauthorized.Value = DATEAUTHORIZED;

                    //OracleParameter authorizedstatus = new OracleParameter();
                    //category.OracleDbType = OracleDbType.NVarchar2;
                    //category.Value = AUTHORIZATIONSTATUS;

                    OracleConnection conn = new OracleConnection(connString);
                    using (conn)
                    {
                        conn.Open();
                        //Create Command and set properties
                        OracleCommand cmd = conn.CreateCommand();

                        cmd.CommandText = "INSERT INTO DISCOUNTING_VENDOR (CATEGORY,NAME,PHONENO,EMAIL,ACCOUNTNO,ADDRESS,BANK,TIN_RC,SERVICENATURE,DATECREATED,CREATEDBYNAME,CREATEDBYEMAIL,AUTHORIZERNAME,DATEAUTHORIZED)  VALUES (:1, :2, :3, :4, :5, :6, :7, :8, :9, :10, :11, :12, :13, :14)";
                        cmd.ArrayBindCount = ids.Length;
                        cmd.Parameters.Add(category);
                        cmd.Parameters.Add(name);
                        cmd.Parameters.Add(phoneno);
                        cmd.Parameters.Add(email);
                        cmd.Parameters.Add(accountno);
                        cmd.Parameters.Add(address);
                        cmd.Parameters.Add(bank);
                        cmd.Parameters.Add(tin_rc);
                        cmd.Parameters.Add(servicenature);
                        cmd.Parameters.Add(datecreated);
                        cmd.Parameters.Add(createdbyname);
                        cmd.Parameters.Add(createdbyemail);
                        //cmd.Parameters.Add(status);
                        cmd.Parameters.Add(authorizename);
                        cmd.Parameters.Add(dateauthorized);
                        //cmd.Parameters.Add(authorizedstatus);
                        cmd.ExecuteNonQuery();
                    }



                }
                catch (Exception ex)
                {
                    logger.Debug($"Error during bulk insert{ex.Message}");

                }
            }
            else
            {
                //The Authorizer Disapproved the bulk excel
                try
                {
                    OracleConnection conn = new OracleConnection(connString);
                    var parameter = new { bulkid = authVendor.Idt };
                    string sql = "UPDATE DISCOUNTING_VENDORBULK_PENDING SET AUTH_STATUS = '1' WHERE ID = :bulkid";
                    using (conn)
                    {
                        conn.Open();
                        conn.Execute(sql, param: parameter, commandType: CommandType.Text);

                        return "okD";
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    return "okD";
                }

            }

            //After Successful insertion///
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { bulkid = authVendor.Idt };
                string sql = "UPDATE DISCOUNTING_VENDORBULK_PENDING SET AUTH_STATUS = '1' WHERE ID = :bulkid";
                using (conn)
                {
                    conn.Open();
                    conn.Execute(sql, param: parameter, commandType: CommandType.Text);


                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);

            }

            return "OK";
        }

        public bool AuthorizeBulkVendor(AuthorizeBulkVendor vendor)
        {
            var details = GetPendingBatchVendor(vendor.Idt);
            byte[] dataAsBytes = details.vendorbulk;
            Object resp = new ByteConverter().ByteArrayToObject(dataAsBytes);

            List<VendorDetails> bulkVendor = (List<VendorDetails>)resp;

            InsertBulkVendor(bulkVendor, vendor);

            return true;


        }

        public bool AuthorizeBulkCorporate(AuthorizeBulkCorporate corporate)
        {
            var details = GetPendingBatchCorporate(corporate.Idt);
            byte[] dataAsBytes = details.corporatebulk;
            Object resp = new ByteConverter().ByteArrayToObject(dataAsBytes);

            List<CorporateDetails> bulkcoporate = (List<CorporateDetails>)resp;

            InsertBulkCorporate(bulkcoporate, corporate);

            return true;
        }

        public int UpdateInsertVendor(UpdateVendor vendorDetails)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                DynamicParameters vendorParams = new DynamicParameters();
                vendorParams.Add("CATEGORY", vendorDetails.CATEGORY);
                vendorParams.Add("UNIQUEVENDORID", vendorDetails.UNIQUEVENDORID);
                vendorParams.Add("ACCOUNTNO", vendorDetails.ACCOUNTNO);
                vendorParams.Add("NAME", vendorDetails.NAME);
                vendorParams.Add("PHONENO", vendorDetails.PHONENO);
                vendorParams.Add("EMAIL", vendorDetails.EMAIL);
                vendorParams.Add("ADDRESS", vendorDetails.ADDRESS);
                vendorParams.Add("BANK", vendorDetails.BANK);
                vendorParams.Add("TIN_RC", vendorDetails.TIN_RC);
                vendorParams.Add("SERVICENATURE", vendorDetails.SERVICENATURE);
                vendorParams.Add("DATECREATED", vendorDetails.DATECREATED);
                vendorParams.Add("STATUS", vendorDetails.STATUS);
                vendorParams.Add("CREATEDBYNAME", vendorDetails.CREATEDBYNAME);
                vendorParams.Add("CREATEDBYEMAIL", vendorDetails.CREATEDBYEMAIL);
                vendorParams.Add("UPDATETYPE", vendorDetails.UPDATETYPE);
                vendorParams.Add("AUTHORIZERCOMMENT", vendorDetails.AUTHORIZERCOMMENT);
                vendorParams.Add("AUTHORIZEREMAIL", vendorDetails.AUTHORIZEREMAIL);
                vendorParams.Add("AUTHORIZERNAME", vendorDetails.AUTHORIZERNAME);
                vendorParams.Add("CORPORATEID", vendorDetails.CORPORATEID);
                vendorParams.Add("idt", DbType.Int32, direction: ParameterDirection.Output);
                using (conn)
                {
                    conn.Open();
                    var savedOrUpdatedId = conn.Execute("PR_DISCOUNTING_VENDOR_PENDING", param: vendorParams, commandType: CommandType.StoredProcedure);

                    int vendorId = vendorParams.Get<int>("idt");
                    return vendorId;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return 0;
            }
        }

        public List<string> GetVendorEmailByContractId(int corporateID)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { corporateid = corporateID };
                string sql = "SELECT EMAIL FROM DISCOUNTING_VENDOR WHERE CORPORATEID = :corporateid order by datecreated desc";
                using (conn)
                {
                    conn.Open();
                    List<string> vendors = conn.Query<string>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return vendors;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public string GetCorporateNameByCorporateID(int GetCorporateNameByCorporateID)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql =
                    $"SELECT dc.corporateName FROM DISCOUNTING_CORPORATEDETAILS dc INNER JOIN DISCOUNTING_VENDOR DV ON dc.id = dv.corporateID WHERE dv.corporateid = {GetCorporateNameByCorporateID}";
                using (conn)
                {
                    conn.Open();
                    var corporateName = conn.Query<string>(sql, commandType: CommandType.Text).FirstOrDefault();

                    return corporateName;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public IEnumerable<string> GetDefinedUDFbyCorporateID(int corporateID)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = $"SELECT UDFLABEL FROM DISCOUNTING_UDF WHERE CONTRACTID={corporateID}";
                using (conn)
                {
                    conn.Open();
                    var existingUDFdetails = conn.Query<string>(sql, commandType: CommandType.Text).ToList();

                    return existingUDFdetails;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<VendorDetails> GetApprovedVendors()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT * FROM DISCOUNTING_VENDOR order by datecreated desc";
                using (conn)
                {
                    conn.Open();
                    List<VendorDetails> vendors = conn.Query<VendorDetails>(sql, commandType: CommandType.Text).ToList();

                    return vendors;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<VendorDetails> GetApprovedVendorsbyCorporateId(int? corporateId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = $"SELECT * FROM DISCOUNTING_VENDOR WHERE CORPORATEID={corporateId}";
                using (conn)
                {
                    conn.Open();
                    List<VendorDetails> vendors = conn.Query<VendorDetails>(sql, commandType: CommandType.Text).ToList();

                    return vendors;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<vendoruser> GetApprovedVendorusers()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT a.EMAIL AS LogInUserEmail,b.UNIQUEVENDORID, b.EMAIL AS VendorEMail FROM DISCOUNTING_USERS  a LEFT OUTER JOIN DISCOUNTING_VENDOR b ON a.VENDORID = b.UNIQUEVENDORID";
                using (conn)
                {
                    conn.Open();
                    List<vendoruser> vendors = conn.Query<vendoruser>(sql, commandType: CommandType.Text).ToList();

                    return vendors;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }


        public IEnumerable<VendorDetails> GetApprovedVendors(string vendoremail)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { vendEmail = vendoremail };
                string sql = $"SELECT * FROM DISCOUNTING_VENDOR where email= :vendEmail order by datecreated desc";
                using (conn)
                {
                    conn.Open();
                    List<VendorDetails> vendors = conn.Query<VendorDetails>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return vendors;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public VendorDetails GetVendorByEmail(string currentuseremail)
        {

            try
            {

                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { currentEmail = currentuseremail };
                string sql = $"select * from DISCOUNTING_VENDOR where EMAIL= :currentEmail order by datecreated desc";
                using (conn)
                {
                    conn.Open();
                    var vendor = conn.Query<VendorDetails>(sql, parameter, commandType: CommandType.Text).FirstOrDefault();

                    return vendor;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<VendorDetailsPending> GetPendingVendors(string currentuseremail, int corporateId)
        {

            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { currentEmail = currentuseremail, corpid = corporateId };
                string sql = $"SELECT * FROM DISCOUNTING_VENDOR_PENDING WHERE AUTHORIZATIONSTATUS=0 and CREATEDBYEMAIL !=:currentEmail AND CORPORATEID = :corpid order by datecreated desc";
                using (conn)
                {
                    conn.Open();
                    List<VendorDetailsPending> vendors = conn.Query<VendorDetailsPending>(sql, parameter, commandType: CommandType.Text).ToList();

                    return vendors;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }


        public List<notification> GetAllpendingInvoices(string vendoremail)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { vendEmail = vendoremail };
                string sql = "SELECT VendorName FROM DISCOUNTING_INVOICE where Invoicestatus='PENDING' AND vendoremail= :vendEmail";
                using (conn)
                {
                    conn.Open();
                    List<notification> vendoList = conn.Query<notification>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return vendoList;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public List<notification> GetAllpendingInvoicesByCorporate(int corporateId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { corpId = corporateId };
                string sql = "SELECT VendorName FROM DISCOUNTING_INVOICE where Invoicestatus='PENDING' AND CORPORATEID = :corpId";
                using (conn)
                {
                    conn.Open();
                    List<notification> vendoList = conn.Query<notification>(sql, commandType: CommandType.Text).ToList();

                    return vendoList;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public List<notification> GetAllpendingInvoices()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT VendorName FROM DISCOUNTING_INVOICE where Invoicestatus='PENDING'";
                using (conn)
                {
                    conn.Open();
                    List<notification> vendoList = conn.Query<notification>(sql, commandType: CommandType.Text).ToList();

                    return vendoList;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public List<notification> GetAllpendingInvoicesbyvendorcode(string vendorcode)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = $"SELECT VendorName FROM DISCOUNTING_INVOICE where Invoicestatus='PENDING' and VendorCode='{vendorcode}'";
                using (conn)
                {
                    conn.Open();
                    List<notification> vendoList = conn.Query<notification>(sql, commandType: CommandType.Text).ToList();

                    return vendoList;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<VendorBatchDetailsPending> GetPendingBulkVendors()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "Select * from DISCOUNTING_VENDORBULK_PENDING where auth_status='0' order by datecreated desc";
                using (conn)
                {
                    conn.Open();
                    List<VendorBatchDetailsPending> vendors = conn.Query<VendorBatchDetailsPending>(sql, commandType: CommandType.Text).ToList();

                    return vendors;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<CorporateBatchDetailsPending> GetPendingBulkCorporate()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "Select * from DISCOUNTING_CORPBULK_PENDING where auth_status='0' order by datecreated desc";
                using (conn)
                {
                    conn.Open();
                    List<CorporateBatchDetailsPending> vendors = conn.Query<CorporateBatchDetailsPending>(sql, commandType: CommandType.Text).ToList();

                    return vendors;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public VendorBatchDetailsPending GetPendingBatchVendor(int id)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = id };
                string sql = $"select * from DISCOUNTING_VENDORBULK_PENDING where AUTH_STATUS = 0 and ID= :idt order by datecreated desc";

                using (conn)
                {
                    conn.Open();
                    var batchvendor = conn.Query<VendorBatchDetailsPending>(sql, param: parameter, commandType: CommandType.Text).FirstOrDefault();
                    return batchvendor;
                }
            }
            catch (Exception ex)
            {
                logger.Debug(ex.Message);
                return null;
            }
        }

        public CorporateBatchDetailsPending GetPendingBatchCorporate(int id)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = id };
                string sql = $"select * from DISCOUNTING_CORPBULK_PENDING where AUTH_STATUS = 0 and ID= :idt order by datecreated desc";

                using (conn)
                {
                    conn.Open();
                    var batchcorporate = conn.Query<CorporateBatchDetailsPending>(sql, param: parameter, commandType: CommandType.Text).FirstOrDefault();
                    return batchcorporate;
                }
            }
            catch (Exception ex)
            {
                logger.Debug(ex.Message);
                return null;
            }
        }

        public IEnumerable<ContractDetails> GetAllContracts()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT * FROM DISCOUNTING_CONTRACT order by createddate desc";
                using (conn)
                {
                    conn.Open();
                    List<ContractDetails> contracts = conn.Query<ContractDetails>(sql, commandType: CommandType.Text).ToList();

                    return contracts;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public ContractDetails GetContractById(int contractId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { contractid = contractId };
                string sql = "SELECT * FROM DISCOUNTING_CONTRACT WHERE ID = :contractid";

                using (conn)
                {
                    conn.Open();
                    ContractDetails contract = conn.Query<ContractDetails>(sql, param:parameter, commandType: CommandType.Text).FirstOrDefault();

                    return contract;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<ContractDetails> GetAllContractsbyVendoremail(string currentuseremail)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { vemail = currentuseremail };
                string sql = "SELECT* FROM DISCOUNTING_CONTRACT WHERE INSTR(VENDOREMAIL, :vemail) > 0 order by createddate desc";

                using (conn)
                {
                    conn.Open();
                    List<ContractDetails> contracts = conn.Query<ContractDetails>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return contracts;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public int UpdateInsertContract(UpdateContract contractDetails, string updateType)
        {
            int contractId = 0;
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                DynamicParameters contractParams = new DynamicParameters();
                contractParams.Add("ContractNumber", contractDetails.ContractNumber);
                contractParams.Add("PONumber", contractDetails.PONumber);
                contractParams.Add("ContractName", contractDetails.ContractName);
                contractParams.Add("ContractAmount", contractDetails.ContractAmount);
                contractParams.Add("QualitySpecification", contractDetails.QualitySpecification);
                contractParams.Add("Description", contractDetails.Description);
                contractParams.Add("PaymentTenor", contractDetails.PaymentTenor);
                contractParams.Add("TimelineDays", contractDetails.TimelineDays);
                contractParams.Add("VendorName", contractDetails.VendorName);
                contractParams.Add("VendorCategory", contractDetails.VendorCategory);
                contractParams.Add("VendorEmail", contractDetails.VendorEmail);
                contractParams.Add("OtherInformation", contractDetails.OtherInformation);
                contractParams.Add("RequiredDocuments", contractDetails.RequiredDocuments);
                contractParams.Add("CreatedByName", contractDetails.CreatedByName);
                contractParams.Add("CreatedByEmail", contractDetails.CreatedByEmail);
                contractParams.Add("LastModifiedBy", contractDetails.LastModifiedBy);
                contractParams.Add("CorporateId", contractDetails.CorporateId);
                contractParams.Add("UpdateType", updateType);
                contractParams.Add("Id", contractDetails.Id);
                contractParams.Add("idt", DbType.Int32, direction: ParameterDirection.Output);


                using (conn)
                {
                    conn.Open();
                    var savedOrUpdatedId = conn.Execute("PR_DISCOUNTING_CONTRACT", param: contractParams, commandType: CommandType.StoredProcedure);

                    contractId = updateType == Enums.UpdateTypes.NEW.ToString() ? contractParams.Get<int>("idt") : contractDetails.Id;
                    return contractId;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return 0;
            }
        }
        public List<UDFDetails> GetUdfByContractId(int contractId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { contrId = contractId };
                string sql = "SELECT * FROM DISCOUNTING_UDF WHERE CONTRACTID = :contrId order by createddate desc";
                using (conn)
                {
                    conn.Open();
                    List<UDFDetails> udfDetails = conn.Query<UDFDetails>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return udfDetails;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public bool DeleteUdfById(int udfId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { udfsid = udfId };
                string sql = "UPDATE DISCOUNTING_UDF SET ISDELETED = 1 WHERE ID = :udfsId";
                using (conn)
                {
                    conn.Open();
                    conn.Execute(sql, param: parameter, commandType: CommandType.Text);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public bool InsertContractUDF(UdfInsert udfDetails)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                // var parameter = new { udfdetails = udfDetails };
                var param = new DynamicParameters();
                param.Add("@UdfLabel", udfDetails.UdfLabel, DbType.String, ParameterDirection.Input);
                param.Add("@UdfType", udfDetails.UdfType, DbType.String, ParameterDirection.Input);
                param.Add("@CreatorName", udfDetails.CreatorName, DbType.String, ParameterDirection.Input);
                param.Add("@CreatorEmail", udfDetails.CreatorEmail, DbType.String, ParameterDirection.Input);
                param.Add("@ContractId", udfDetails.ContractId, DbType.Int32, ParameterDirection.Input);
                using (conn)
                {
                    conn.Open();
                    //var saved = conn.Execute("PR_DISCOUNTING_INSERT_UDF", param: parameter, commandType: CommandType.StoredProcedure);
                    var saved = conn.Execute("PR_DISCOUNTING_INSERT_UDF", param: param, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
            //try
            //{
            //    OracleConnection conn = new OracleConnection(connString);
            //    using (conn)
            //    {
            //        conn.Open();
            //        var saved = conn.Execute("PR_DISCOUNTING_INSERT_UDF", param: udfDetails, commandType: CommandType.StoredProcedure);

            //        return true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex);
            //    return false;
            //}
        }



        public IEnumerable<ContractResponse> GetAllContractResponse(string vendoremail)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { vendEmail = vendoremail };
                string sql = $"select* from discounting_contract_response where vendoremail = :vendEmail";

                using (conn)
                {
                    conn.Open();
                    List<ContractResponse> contractresponse = conn.Query<ContractResponse>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return contractresponse;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }


        public IEnumerable<ContractResponse> GetAllContractResponse()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT * FROM DISCOUNTING_CONTRACT_RESPONSE order by datecreated desc";
                using (conn)
                {
                    conn.Open();
                    List<ContractResponse> contractresponse = conn.Query<ContractResponse>(sql, commandType: CommandType.Text).ToList();

                    return contractresponse;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }


        public IEnumerable<ContractResponse> GetContractResponseByContractID(int contractId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { contrid = contractId };
                string sql = "SELECT * FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = :contrid AND RESPONSESTATUS <> 'Declined' order by datecreated desc";
                using (conn)
                {
                    conn.Open();
                    var response = conn.Query<ContractResponse>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<ContractDetails> GetContractResponseByCorporateID(int corporateId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { corporateid = corporateId };
                //string sql = "SELECT * FROM DISCOUNTING_CORPORATEDETAILS";
                string sql = "SELECT * from DISCOUNTING_CONTRACT where CorporateID = :corporateid  order by createddate desc";
                using (conn)
                {
                    conn.Open();
                    var response = conn.Query<ContractDetails>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public ContractResponse GetContractResponseByID(int responseId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = responseId };
                string sql = "SELECT * FROM DISCOUNTING_CONTRACT_RESPONSE WHERE ID = :idt order by datecreated desc";
                using (conn)
                {
                    conn.Open();
                    var response = conn.Query<ContractResponse>(sql, param: parameter, commandType: CommandType.Text).FirstOrDefault();

                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public IEnumerable<ContractUDFResponse> GetContractUDFResponseByResponseID(int responsetId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { respid = responsetId };
                string sql = "SELECT * FROM DISCOUNTING_CONTRACT_UDF_RESP WHERE CONTRACTRESPONSEID = :respid order by createddate desc";
                using (conn)
                {
                    conn.Open();
                    var response = conn.Query<ContractUDFResponse>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public ContractUDFResponse GetContractUDFResponseByID(int id)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = id };
                string sql = "SELECT * FROM DISCOUNTING_CONTRACT_UDF_RESP WHERE ID = :idt order by createddate desc";
                using (conn)
                {
                    conn.Open();
                    var response = conn.Query<ContractUDFResponse>(sql, param: parameter, commandType: CommandType.Text).FirstOrDefault();

                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public long InsertContractResponse(InsertContractResponse contractRespDetails)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = new OracleConnection(connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_DISCOUNTING_INSERT_CONTRESP";

                cmd.Parameters.Add("CONTRACTID", OracleDbType.Int64, contractRespDetails.CONTRACTID, ParameterDirection.Input);
                cmd.Parameters.Add("SUPPORTINGDOCUMENT1", OracleDbType.Blob, contractRespDetails.SUPPORTINGDOCUMENT1, ParameterDirection.Input);
                cmd.Parameters.Add("SUPPORTINGDOCUMENT2", OracleDbType.Blob, contractRespDetails.SUPPORTINGDOCUMENT2, ParameterDirection.Input);
                cmd.Parameters.Add("SUPPORTINGDOC1FILENAME", OracleDbType.Varchar2, contractRespDetails.SUPPORTINGDOC1FILENAME, ParameterDirection.Input);
                cmd.Parameters.Add("SUPPORTINGDOC2FILENAME", OracleDbType.Varchar2, contractRespDetails.SUPPORTINGDOC2FILENAME, ParameterDirection.Input);
                cmd.Parameters.Add("VENDORCOMMENT", OracleDbType.Varchar2, contractRespDetails.VENDORCOMMENT, ParameterDirection.Input);
                cmd.Parameters.Add("VENDORNAME", OracleDbType.Varchar2, contractRespDetails.VENDORNAME, ParameterDirection.Input);
                cmd.Parameters.Add("VENDOREMAIL", OracleDbType.Varchar2, contractRespDetails.VENDOREMAIL, ParameterDirection.Input);
                cmd.Parameters.Add("contractstatus", OracleDbType.Varchar2, contractRespDetails.CONTRACTSTATUS, ParameterDirection.Input);
                cmd.Parameters.Add("ContractAmount", OracleDbType.Varchar2, contractRespDetails.CONTRACTAMOUNT, ParameterDirection.Input);
                cmd.Parameters.Add("IDT", OracleDbType.Int64, ParameterDirection.Output);
                using (cmd)
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    var idt = cmd.Parameters["IDT"].Value;
                    long id = Convert.ToInt64(idt.ToString());
                    cmd.Connection.Close();
                    return id;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return 0;
            }
        }
        public bool InsertUDFResponse(InsertContractUDFResponse udfRespDetails)
        {
            try
            {

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = new OracleConnection(connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_DISCOUNTING_INSERT_UDF_RESP";

                cmd.Parameters.Add("CONTRACTID", OracleDbType.Int64, udfRespDetails.CONTRACTID, ParameterDirection.Input);
                cmd.Parameters.Add("CONTRACTRESPONSEID", OracleDbType.Int64, udfRespDetails.CONTRACTRESPONSEID, ParameterDirection.Input);
                cmd.Parameters.Add("TEXTVALUE", OracleDbType.Varchar2, udfRespDetails.TEXTVALUE, ParameterDirection.Input);
                cmd.Parameters.Add("UPLOADVALUE", OracleDbType.Blob, udfRespDetails.UPLOADVALUE, ParameterDirection.Input);
                cmd.Parameters.Add("UPLOADFILENAME", OracleDbType.Varchar2, udfRespDetails.UPLOADFILENAME, ParameterDirection.Input);
                cmd.Parameters.Add("RESPONSETYPE", OracleDbType.Varchar2, udfRespDetails.RESPONSETYPE, ParameterDirection.Input);
                cmd.Parameters.Add("UDFLABEL", OracleDbType.Varchar2, udfRespDetails.UDFLABEL, ParameterDirection.Input);

                using (cmd)
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool AuthorizeContractResponse(AuthorizeContractResponse authDetails)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                using (conn)
                {
                    conn.Open();
                    var authorized = conn.Execute("PR_DISCOUNTING_AUTH_CONTRRESP", param: authDetails, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public List<ContractDetails> GetAwardedContractByVendor(string vendorEmail)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { vemail = vendorEmail };
                string sql = "SELECT B.* FROM DISCOUNTING_CONTRACT_RESPONSE A" +
                             "LEFT OUTER JOIN DISCOUNTING_CONTRACT B ON A.CONTRACTID = B.ID" +
                             "WHERE A.RESPONSESTATUS = 'Awarded' AND A.VENDOREMAIL = :vemail";

                using (conn)
                {
                    conn.Open();
                    var response = conn.Query<ContractDetails>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;

            }
        }

        public IEnumerable<VendorContractListModel> GetVendorContractList(string vendorEmail)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { vendorMail = vendorEmail };
                string sql = $"SELECT \n" +
                                "    A.*,\n" +
                                "    B.CORPORATENAME,\n" +
                                "    CASE " +
                                "      WHEN EXISTS (SELECT vendoremail FROM DISCOUNTING_INVOICE WHERE CONTRACTID = A.ID AND VENDOREMAIL = :vendorMail) THEN 'Completed' \n" +
                                "      WHEN EXISTS (SELECT vendoremail FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = A.ID AND VENDOREMAIL = :vendorMail AND RESPONSESTATUS = 'Awarded') THEN 'Awarded' \n" +
                                "      WHEN EXISTS (SELECT * FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = A.ID AND RESPONSESTATUS = 'Awarded') THEN 'Rejected' \n" +
                                "      WHEN EXISTS (SELECT vendoremail FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = A.ID AND VENDOREMAIL = :vendorMail AND RESPONSESTATUS = 'Rejected') THEN 'Rejected' \n" +
                                "      WHEN EXISTS (SELECT vendoremail FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = A.ID AND VENDOREMAIL = :vendorMail AND RESPONSESTATUS = 'Ongoing') THEN 'Pending' \n" +
                                "      WHEN EXISTS (SELECT vendoremail FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = A.ID AND VENDOREMAIL = :vendorMail AND RESPONSESTATUS = 'Declined') THEN 'Declined' \n" +
                                "      ELSE 'New'" +
                                "    END AS CONTRACTSTATUS, \n" +
                                "    (SELECT ID FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = A.ID AND VENDOREMAIL = :vendorMail) AS RESPONSEID, \n" +
                                "    '' AS AWARDVENDORNAME \n" +
                                "FROM DISCOUNTING_CONTRACT A \n" +
                                "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS B ON A.CORPORATEID = B.ID \n" +
                                "WHERE INSTR(A.VENDOREMAIL,:vendorMail) > 0 \n" +
                                "ORDER BY A.createddate DESC \n";

                using (conn)
                {
                    conn.Open();
                    var contractList = conn.Query<VendorContractListModel>(sql, param: parameter, commandType: CommandType.Text).ToList();
                    return contractList;
                }
            }
            catch (Exception ex)
            {
                logger.Debug(ex.Message);
                return null;
            }
        }

        public IEnumerable<VendorContractListModel> GetAllCorporateContractList(int corporateId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { corpId = corporateId };
                string sql = $"SELECT \n" +
                             "    A.*,\n" +
                             "    B.CORPORATENAME,\n" +
                             "    CASE " +
                             "      WHEN EXISTS (SELECT * FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = A.ID AND RESPONSESTATUS = 'Awarded') THEN 'Awarded' \n" +
                             "      ELSE 'In Progress'" +
                             "    END AS CONTRACTSTATUS, \n" +
                             "    (SELECT ID FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = A.ID AND ROWNUM = 1) AS RESPONSEID, \n" +
                             "    (SELECT VENDORNAME FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = A.ID) AS AWARDVENDORNAME \n" +
                             "FROM DISCOUNTING_CONTRACT A \n" +
                             "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS B ON A.CORPORATEID = B.ID \n" +
                             "WHERE A.CORPORATEID = :corpId \n";

                using (conn)
                {
                    conn.Open();
                    var contractList = conn.Query<VendorContractListModel>(sql, commandType: CommandType.Text).ToList();
                    return contractList;
                }
            }
            catch (Exception ex)
            {
                logger.Debug(ex.Message);
                return null;
            }
        }
        public IEnumerable<VendorContractListModel> GetAllCorporateContractList()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                //var parameter = new { corpId = corporateId };
                string sql = $"SELECT \n" +
                             "    A.*,\n" +
                             "    B.CORPORATENAME,\n" +
                             "    CASE " +
                             "      WHEN EXISTS (SELECT * FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = A.ID AND RESPONSESTATUS = 'Awarded') THEN 'Awarded' \n" +
                             "      ELSE 'In Progress'" +
                             "    END AS CONTRACTSTATUS, \n" +
                             "    (SELECT ID FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = A.ID AND ROWNUM = 1) AS RESPONSEID, \n" +
                             "    (SELECT VENDORNAME FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = A.ID AND ROWNUM=1) AS AWARDVENDORNAME \n" +
                             "FROM DISCOUNTING_CONTRACT A \n" +
                             "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS B ON A.CORPORATEID = B.ID \n";
                //  "WHERE A.CORPORATEID = :corpId \n";

                using (conn)
                {
                    conn.Open();
                    var contractList = conn.Query<VendorContractListModel>(sql, commandType: CommandType.Text).ToList();
                    return contractList;
                }
            }
            catch (Exception ex)
            {
                logger.Debug(ex.Message);
                return null;
            }
        }
        public IEnumerable<VendorContractListModel> GetCorporateContractList(int corporateId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { corpId = corporateId };
                string sql = $"SELECT \n" +
                                "    A.*,\n" +
                                "    B.CORPORATENAME,\n" +
                                "    CASE " +
                                "      WHEN EXISTS (SELECT * FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = A.ID AND RESPONSESTATUS = 'Awarded') THEN 'Awarded' \n" +
                                "      ELSE 'In Progress'" +
                                "    END AS CONTRACTSTATUS, \n" +
                                "    (SELECT ID FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = A.ID AND VENDORNAME IS NOT NULL AND ROWNUM = 1) AS RESPONSEID, \n" +
                                "    (SELECT VENDORNAME FROM DISCOUNTING_CONTRACT_RESPONSE WHERE CONTRACTID = A.ID AND ROWNUM=1) AS AWARDVENDORNAME \n" +
                                "FROM DISCOUNTING_CONTRACT A \n" +
                                "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS B ON A.CORPORATEID = B.ID \n" +
                                "WHERE A.CORPORATEID = :corpId \n" +
                                "ORDER BY A.CREATEDDATE DESC \n";

                using (conn)
                {
                    conn.Open();
                    var contractList = conn.Query<VendorContractListModel>(sql, param: parameter, commandType: CommandType.Text).ToList();
                    return contractList;
                }
            }
            catch (Exception ex)
            {
                logger.Debug(ex.Message);
                return null;
            }
        }
        //public int InsertInvoiceDetails(ContractInvoice invoiceDetails)
        //{
        //    try
        //    {
        //        OracleConnection conn = new OracleConnection(connString);


        //        DynamicParameters invoiceParams = new DynamicParameters();

        //        invoiceParams.Add("id", DbType.Int32, direction: ParameterDirection.Output);
        //        invoiceParams.Add("contractid", invoiceDetails.contractid);
        //        invoiceParams.Add("invoicenumber", invoiceDetails.invoicenumber, DbType.String);
        //        invoiceParams.Add("invoicedate", invoiceDetails.invoicedate);
        //        invoiceParams.Add("vatregistrationno", invoiceDetails.vatregistrationno, DbType.String);
        //        invoiceParams.Add("vendorcode", invoiceDetails.vendorcode, DbType.String);
        //        invoiceParams.Add("tin", invoiceDetails.tin, DbType.String);
        //        invoiceParams.Add("contractnumber", invoiceDetails.contractnumber, DbType.String);
        //        invoiceParams.Add("ponumber", invoiceDetails.ponumber, DbType.String);
        //        invoiceParams.Add("projectname", invoiceDetails.projectname, DbType.String);
        //        invoiceParams.Add("vendorname", invoiceDetails.vendorname, DbType.String);
        //        invoiceParams.Add("vendoremail", invoiceDetails.vendoremail, DbType.String);
        //        invoiceParams.Add("vendoraddress", invoiceDetails.vendoraddress, DbType.String);
        //        invoiceParams.Add("vendorphoneno", invoiceDetails.vendorphoneno, DbType.String);
        //        invoiceParams.Add("description", invoiceDetails.description, DbType.String);
        //        invoiceParams.Add("days", invoiceDetails.days);
        //        invoiceParams.Add("unitprice", invoiceDetails.unitprice, DbType.String);
        //        invoiceParams.Add("totalexcludingvat", invoiceDetails.totalexcludingvat, DbType.String);
        //        invoiceParams.Add("totalincludingvat", invoiceDetails.totalincludingvat, DbType.String);
        //        invoiceParams.Add("totalamountinwords", invoiceDetails.totalamountinwords, DbType.String);
        //        invoiceParams.Add("accountnumber", invoiceDetails.accountnumber, DbType.String);
        //        invoiceParams.Add("accountname", invoiceDetails.accountname, DbType.String);
        //        invoiceParams.Add("bankname", invoiceDetails.bankname, DbType.String);
        //        invoiceParams.Add("vatrate", invoiceDetails.vatrate);
        //        invoiceParams.Add("requestdiscounting", invoiceDetails.requestdiscounting);
        //        invoiceParams.Add("isautorepayment", invoiceDetails.ISAUTOREPAYMENT);
        //        invoiceParams.Add("supportingdocument1", invoiceDetails.SUPPORTINGDOCUMENT1);
        //        invoiceParams.Add("supportingdocument2", invoiceDetails.SUPPORTINGDOCUMENT2);
        //        invoiceParams.Add("supportingdoc1filename", invoiceDetails.SUPPORTINGDOC1FILENAME);
        //        invoiceParams.Add("supportingdoc2filename", invoiceDetails.SUPPORTINGDOC2FILENAME);
        //        invoiceParams.Add("corporateid", invoiceDetails.CORPORATEID);
        //        // invoiceParams.Add("id", DbType.Int32, direction: ParameterDirection.Output);
        //        // invoiceParams.Add("contractid", invoiceDetails.contractid);
        //        //invoiceParams.Add("invoicenumber", invoiceDetails.invoicenumber);
        //        //invoiceParams.Add("invoicedate", invoiceDetails.invoicedate);
        //        //invoiceParams.Add("vatregistrationno", invoiceDetails.vatregistrationno);
        //        //invoiceParams.Add("vendorcode", invoiceDetails.vendorcode);
        //        //invoiceParams.Add("tin", invoiceDetails.tin);
        //        //invoiceParams.Add("contractnumber", invoiceDetails.contractnumber);
        //        //invoiceParams.Add("ponumber", invoiceDetails.ponumber);
        //        //invoiceParams.Add("projectname", invoiceDetails.projectname);
        //        //invoiceParams.Add("vendorname", invoiceDetails.vendorname);
        //        //invoiceParams.Add("vendoremail", invoiceDetails.vendoremail);
        //        //invoiceParams.Add("vendoraddress", invoiceDetails.vendoraddress);
        //        //invoiceParams.Add("vendorphoneno", invoiceDetails.vendorphoneno);
        //        //invoiceParams.Add("description", invoiceDetails.description);
        //        //invoiceParams.Add("days", invoiceDetails.days);
        //        //invoiceParams.Add("unitprice", invoiceDetails.unitprice);
        //        //invoiceParams.Add("totalexcludingvat", invoiceDetails.totalexcludingvat);
        //        //invoiceParams.Add("totalincludingvat", invoiceDetails.totalincludingvat);
        //        //invoiceParams.Add("totalamountinwords", invoiceDetails.totalamountinwords);
        //        //invoiceParams.Add("accountnumber", invoiceDetails.accountnumber);
        //        //invoiceParams.Add("accountname", invoiceDetails.accountname);
        //        //invoiceParams.Add("bankname", invoiceDetails.bankname);
        //        //invoiceParams.Add("vatrate", invoiceDetails.vatrate);
        //        //invoiceParams.Add("requestdiscounting", invoiceDetails.requestdiscounting);
        //        //invoiceParams.Add("isautorepayment", invoiceDetails.ISAUTOREPAYMENT);
        //        //invoiceParams.Add("supportingdocument1", invoiceDetails.SUPPORTINGDOCUMENT1);
        //        //invoiceParams.Add("supportingdocument2", invoiceDetails.SUPPORTINGDOCUMENT2);
        //        //invoiceParams.Add("supportingdoc1filename", invoiceDetails.SUPPORTINGDOC1FILENAME);
        //        //invoiceParams.Add("supportingdoc2filename", invoiceDetails.SUPPORTINGDOC2FILENAME);
        //        //invoiceParams.Add("corporateid", invoiceDetails.CORPORATEID);

        //        //invoiceParams.Add("contractid", invoiceDetails.contractid);
        //        //invoiceParams.Add("invoicenumber", $"'{invoiceDetails.invoicenumber}'");
        //        //invoiceParams.Add("invoicedate", invoiceDetails.invoicedate);
        //        //invoiceParams.Add("vatregistrationno", $"'{invoiceDetails.vatregistrationno}'");
        //        //invoiceParams.Add("vendorcode", $"'{invoiceDetails.vendorcode}'");
        //        //invoiceParams.Add("tin", $"'{invoiceDetails.tin}'");
        //        //invoiceParams.Add("contractnumber", $"'{invoiceDetails.contractnumber}'");
        //        //invoiceParams.Add("ponumber", $"'{invoiceDetails.ponumber}'");
        //        //invoiceParams.Add("projectname", $"'{invoiceDetails.projectname}'");
        //        //invoiceParams.Add("vendorname", $"'{invoiceDetails.vendorname}'");
        //        //invoiceParams.Add("vendoremail", $"'{invoiceDetails.vendoremail}'");
        //        //invoiceParams.Add("vendoraddress", $"'{invoiceDetails.vendoraddress}'");
        //        //invoiceParams.Add("vendorphoneno", $"'{invoiceDetails.vendorphoneno}'");
        //        //invoiceParams.Add("description", $"'{invoiceDetails.description}'");
        //        //invoiceParams.Add("days", invoiceDetails.days);
        //        //invoiceParams.Add("unitprice", $"'{invoiceDetails.unitprice}'");
        //        //invoiceParams.Add("totalexcludingvat", $"'{invoiceDetails.totalexcludingvat}'");
        //        //invoiceParams.Add("totalincludingvat", $"'{invoiceDetails.totalincludingvat}'");
        //        //invoiceParams.Add("totalamountinwords", $"'{invoiceDetails.totalamountinwords}'");
        //        //invoiceParams.Add("accountnumber", $"'{invoiceDetails.accountnumber}'");
        //        //invoiceParams.Add("accountname", $"'{invoiceDetails.accountname}'");
        //        //invoiceParams.Add("bankname", $"'{invoiceDetails.bankname}'");
        //        //invoiceParams.Add("vatrate", $"'{invoiceDetails.vatrate}'");
        //        //invoiceParams.Add("requestdiscounting", invoiceDetails.requestdiscounting);
        //        //invoiceParams.Add("isautorepayment", invoiceDetails.ISAUTOREPAYMENT);
        //        //invoiceParams.Add("supportingdocument1", invoiceDetails.SUPPORTINGDOCUMENT1);
        //        //invoiceParams.Add("supportingdocument2", invoiceDetails.SUPPORTINGDOCUMENT2);
        //        //invoiceParams.Add("supportingdoc1filename", invoiceDetails.SUPPORTINGDOC1FILENAME);
        //        //invoiceParams.Add("supportingdoc2filename", invoiceDetails.SUPPORTINGDOC2FILENAME);
        //        //invoiceParams.Add("corporateid", invoiceDetails.CORPORATEID);
        //        //invoiceParams.Add("id", DbType.Int32, direction: ParameterDirection.Output);

        //        using (conn)
        //        {
        //            conn.Open();
        //           // var result = conn.Execute("PR_DISCOUNTING_INVOICE", param: invoiceParams, commandType: CommandType.StoredProcedure);
        //            //var result = conn.Execute("SUPPLYCHAIN.PR_DISCOUNTING_INVOICE", param: invoiceParams, commandType: CommandType.StoredProcedure);
        //            var result = conn.Execute("SUPPLYCHAIN.PR_INVOICE_DISCOUNTING", param: invoiceParams, commandType: CommandType.StoredProcedure);
        //            var invoiceId = invoiceParams.Get<int>("id");
        //            return invoiceId;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex);
        //        return 0;
        //    }
        //}



        public int InsertInvoiceDetails(ContractInvoice invoiceDetails)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);



                using (conn)
                {
                    conn.Open();


                    const string insertUserSql = @"
                                            INSERT INTO DISCOUNTING_INVOICE(contractid, invoicenumber, invoicedate, vatregistrationno,vendorcode, tin, contractnumber, ponumber, projectname, vendorname, vendoremail, 
                                            vendoraddress, vendorphoneno, description, days, unitprice, totalexcludingvat,totalincludingvat, totalamountinwords, accountnumber, accountname, bankname,invoicestatus,vatrate,requestdiscounting,
                                            isautorepayment,paymentsettled,supportingdocument1,supportingdocument2,supportingdoc1filename,supportingdoc2filename,corporateid)
                                             VALUES 
                                            (:contractid, :invoicenumber, :invoicedate, :vatregistrationno,:vendorcode, :tin, :contractnumber, :ponumber, :projectname, :vendorname, :vendoremail,:vendoraddress, :vendorphoneno,
                                             :description, :days, :unitprice, :totalexcludingvat,:totalincludingvat, :totalamountinwords, :accountnumber, :accountname, :bankname,:invoicestatus,:vatrate,:requestdiscounting,
                                             :isautorepayment,:paymentsettled,:supportingdocument1,:supportingdocument2,:supportingdoc1filename,:supportingdoc2filename,:corporateid)";

                    var newUserId = conn.QueryFirstOrDefault<int>(
                                                              insertUserSql,
                                                              new
                                                              {
                                                                  contractid = invoiceDetails.contractid,
                                                                  invoicenumber = invoiceDetails.invoicenumber,
                                                                  invoicedate = DateTime.Now,
                                                                  vatregistrationno = invoiceDetails.vatregistrationno,
                                                                  vendorcode = invoiceDetails.vendorcode,
                                                                  tin = invoiceDetails.tin,
                                                                  contractnumber = invoiceDetails.contractnumber,
                                                                  ponumber = invoiceDetails.ponumber,
                                                                  projectname = invoiceDetails.projectname,
                                                                  vendorname = invoiceDetails.vendorname,
                                                                  vendoremail = invoiceDetails.vendoremail,
                                                                  vendoraddress = invoiceDetails.vendoraddress,
                                                                  vendorphoneno = invoiceDetails.vendorphoneno,
                                                                  description = invoiceDetails.description,
                                                                  days = invoiceDetails.days,
                                                                  unitprice = invoiceDetails.unitprice,
                                                                  totalexcludingvat = invoiceDetails.totalexcludingvat,
                                                                  totalincludingvat = invoiceDetails.totalincludingvat,
                                                                  totalamountinwords = invoiceDetails.totalamountinwords,
                                                                  accountnumber = invoiceDetails.accountnumber,
                                                                  accountname = invoiceDetails.accountname,
                                                                  bankname = invoiceDetails.bankname,
                                                                  invoicestatus = "PENDING",
                                                                  vatrate = invoiceDetails.vatrate,
                                                                  requestdiscounting = invoiceDetails.requestdiscounting,
                                                                  isautorepayment = invoiceDetails.ISAUTOREPAYMENT,
                                                                  paymentsettled = "0",
                                                                  supportingdocument1 = invoiceDetails.SUPPORTINGDOCUMENT1,
                                                                  supportingdocument2 = invoiceDetails.SUPPORTINGDOCUMENT2,
                                                                  supportingdoc1filename = invoiceDetails.SUPPORTINGDOC1FILENAME,
                                                                  supportingdoc2filename = invoiceDetails.SUPPORTINGDOC2FILENAME,
                                                                  corporateid = invoiceDetails.CORPORATEID
                                                              }
                                                              );

                    var query2 = @"select max(id) from DISCOUNTING_INVOICE";
                    var lastinsertedID = conn.ExecuteScalar<int>(query2);


                    return lastinsertedID;


                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return 0;
            }
        }



        //public int InsertInvoiceDetails(ContractInvoice invoiceDetails)
        //{
        //    try
        //    {
        //        OracleConnection conn = new OracleConnection(connString);



        //        using (conn)
        //        {
        //            DynamicParameters invoiceParams = new DynamicParameters();

        //            invoiceParams.Add("id", DbType.Int32, direction: ParameterDirection.Output);
        //            invoiceParams.Add("contractid", invoiceDetails.contractid);
        //            invoiceParams.Add("invoicenumber", invoiceDetails.invoicenumber, DbType.String);
        //            invoiceParams.Add("invoicedate", invoiceDetails.invoicedate);
        //            invoiceParams.Add("vatregistrationno", invoiceDetails.vatregistrationno, DbType.String);
        //            invoiceParams.Add("vendorcode", invoiceDetails.vendorcode, DbType.String);
        //            invoiceParams.Add("tin", invoiceDetails.tin, DbType.String);
        //            invoiceParams.Add("contractnumber", invoiceDetails.contractnumber, DbType.String);
        //            invoiceParams.Add("ponumber", invoiceDetails.ponumber, DbType.String);
        //            invoiceParams.Add("projectname", invoiceDetails.projectname, DbType.String);
        //            invoiceParams.Add("vendorname", invoiceDetails.vendorname, DbType.String);
        //            invoiceParams.Add("vendoremail", invoiceDetails.vendoremail, DbType.String);
        //            invoiceParams.Add("vendoraddress", invoiceDetails.vendoraddress, DbType.String);
        //            invoiceParams.Add("vendorphoneno", invoiceDetails.vendorphoneno, DbType.String);
        //            invoiceParams.Add("description", invoiceDetails.description, DbType.String);
        //            invoiceParams.Add("days", invoiceDetails.days);
        //            invoiceParams.Add("unitprice", invoiceDetails.unitprice, DbType.String);
        //            invoiceParams.Add("totalexcludingvat", invoiceDetails.totalexcludingvat, DbType.String);
        //            invoiceParams.Add("totalincludingvat", invoiceDetails.totalincludingvat, DbType.String);
        //            invoiceParams.Add("totalamountinwords", invoiceDetails.totalamountinwords, DbType.String);
        //            invoiceParams.Add("accountnumber", invoiceDetails.accountnumber, DbType.String);
        //            invoiceParams.Add("accountname", invoiceDetails.accountname, DbType.String);
        //            invoiceParams.Add("bankname", invoiceDetails.bankname, DbType.String);
        //            invoiceParams.Add("vatrate", invoiceDetails.vatrate);
        //            invoiceParams.Add("requestdiscounting", invoiceDetails.requestdiscounting);
        //            invoiceParams.Add("isautorepayment", invoiceDetails.ISAUTOREPAYMENT);
        //            invoiceParams.Add("supportingdocument1", invoiceDetails.SUPPORTINGDOCUMENT1);
        //            invoiceParams.Add("supportingdocument2", invoiceDetails.SUPPORTINGDOCUMENT2);
        //            invoiceParams.Add("supportingdoc1filename", invoiceDetails.SUPPORTINGDOC1FILENAME);
        //            invoiceParams.Add("supportingdoc2filename", invoiceDetails.SUPPORTINGDOC2FILENAME);
        //            invoiceParams.Add("corporateid", invoiceDetails.CORPORATEID);



        //            const string insertUserSql = @"
        //                                    INSERT INTO DISCOUNTING_INVOICE(contractid, invoicenumber, invoicedate, vatregistrationno,vendorcode, tin, contractnumber, ponumber, projectname, vendorname, vendoremail, 
        //                                    vendoraddress, vendorphoneno, description, days, unitprice, totalexcludingvat,totalincludingvat, totalamountinwords, accountnumber, accountname, bankname,invoicestatus,vatrate,requestdiscounting,
        //                                    isautorepayment,paymentsettled,supportingdocument1,supportingdocument2,supportingdoc1filename,supportingdoc2filename,corporateid)
        //                                     VALUES 
        //                                    (:contractid, :invoicenumber, :invoicedate, :vatregistrationno,:vendorcode, :tin, :contractnumber, :ponumber, :projectname, :vendorname, :vendoremail,:vendoraddress, :vendorphoneno,
        //                                     :description, :days, :unitprice, :totalexcludingvat,:totalincludingvat, :totalamountinwords, :accountnumber, :accountname, :bankname,:invoicestatus,:vatrate,:requestdiscounting,
        //                                     :isautorepayment,:paymentsettled,:supportingdocument1,:supportingdocument2,:supportingdoc1filename,:supportingdoc2filename,:corporateid)
        //                                     RETURNING ID INTO id";


        //            var result = conn.Execute("SUPPLYCHAIN.PR_INVOICE_DISCOUNTING", param: invoiceParams, commandType: CommandType.StoredProcedure);
        //            var invoiceId = invoiceParams.Get<int>("id");
        //            return invoiceId;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex);
        //        return 0;
        //    }
        //}



        public bool InsertInvoiceLoanDetails(InvoiceLoan loanDetails)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                using (conn)
                {
                    conn.Open();
                    var inserted = conn.Execute("PR_DISCOUNTING_INVOICE_LOAN", param: loanDetails, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool InsertInvoiceItemDetails(InvoiceItem invoiceItem)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                using (conn)
                {
                    conn.Open();
                    var inserted = conn.Execute("PR_DISCOUNTING_INVOICE_ITEM", param: invoiceItem, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public IEnumerable<InvoiceList> GetInvoiceListByCorporate(int corporateId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { corpId = corporateId };
                //string sql = "SELECT A.id invoiceid, A.contractid, A.invoicenumber, A.invoicedate, A.contractnumber, A.vendorname, A.vendoremail, \n" +
                //             "A.projectname, A.totalincludingvat, A.invoicestatus, A.expectedrepaymentdate, C.CorporateName FROM DISCOUNTING_INVOICE A \n" +
                //             "LEFT OUTER JOIN DISCOUNTING_CONTRACT B ON A.CONTRACTID = B.ID \n" +
                //             "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS C ON B.CORPORATEID = C.ID \n" +
                //             "WHERE B.CORPORATEID = :corpId \n" +
                //             "ORDER BY invoicedate DESC";

                string sql = "SELECT A.id invoiceid, A.contractid, A.invoicenumber, A.invoicedate, A.contractnumber, A.vendorname, A.vendoremail, \n" +
                            "A.projectname, A.totalincludingvat, A.invoicestatus, A.expectedrepaymentdate, C.CorporateName FROM DISCOUNTING_INVOICE A \n" +
                            "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS C ON C.ID = A.CORPORATEID \n" +
                            "WHERE A.CORPORATEID = :corpId \n" +
                            "ORDER BY invoicedate DESC";

                using (conn)
                {
                    conn.Open();
                    var response = conn.Query<InvoiceList>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public ContractInvoice GetInvoiceById(int id)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = id };
                string sql = "SELECT * FROM DISCOUNTING_INVOICE WHERE ID = :idt order by ID desc";

                using (conn)
                {
                    conn.Open();
                    var response = conn.Query<ContractInvoice>(sql, param: parameter, commandType: CommandType.Text).FirstOrDefault();

                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<InvoiceList> GetInvoiceList(string currentuseremail)
        {
            try
            {
                var parameter = new { vemail = currentuseremail };
                OracleConnection conn = new OracleConnection(connString);

                string sql = "SELECT A.id invoiceid, A.contractid, A.invoicenumber, A.invoicedate, A.contractnumber, A.vendorname, A.vendoremail ,A.projectname, A.totalincludingvat, A.invoicestatus, C.CorporateName FROM DISCOUNTING_INVOICE A LEFT OUTER JOIN DISCOUNTING_CONTRACT B ON A.CONTRACTID = B.ID  \r\nLEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS C ON B.CORPORATEID = C.ID WHERE A.vendoremail= :vemail ";


                using (conn)
                {
                    conn.Open();
                    var response = conn.Query<InvoiceList>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<InvoiceList> GetInvoiceList()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);

                string sql = "SELECT A.id invoiceid, A.contractid, A.invoicenumber, A.invoicedate, A.contractnumber, A.vendorname, A.vendoremail ,A.projectname, A.totalincludingvat, A.invoicestatus, C.CorporateName FROM DISCOUNTING_INVOICE A LEFT OUTER JOIN DISCOUNTING_CONTRACT B ON A.CONTRACTID = B.ID  \r\nLEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS C ON B.CORPORATEID = C.ID ";
                //string sql = "SELECT A.id invoiceid, A.contractid, A.invoicenumber, A.invoicedate, A.contractnumber, A.vendorname, A.vendoremail, \n" +
                //             "A.projectname, A.totalincludingvat, A.invoicestatus, C.CorporateName FROM DISCOUNTING_INVOICE A \n" +
                //             "LEFT OUTER JOIN DISCOUNTING_CONTRACT B ON A.CONTRACTID = B.ID \n" +
                //             "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS C ON B.CORPORATEID = C.ID \n" +
                //             "WHERE B.CORPORATEID = :corpId";

                using (conn)
                {
                    conn.Open();
                    var response = conn.Query<InvoiceList>(sql, commandType: CommandType.Text).ToList();

                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<InvoiceList> GetInvoiceListByVendorEmail(string vendorEmail)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { vemail = vendorEmail };
                string sql = "SELECT A.id invoiceid, A.contractid, A.invoicenumber, A.invoicedate, A.contractnumber, A.vendorname, A.vendoremail, \n" +
                             "A.projectname, A.totalincludingvat, A.invoicestatus, A.expectedrepaymentdate, C.CorporateName FROM DISCOUNTING_INVOICE A \n" +
                             "LEFT OUTER JOIN DISCOUNTING_CONTRACT B ON A.CONTRACTID = B.ID \n" +
                             "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS C ON B.CORPORATEID = C.ID \n" +
                             "WHERE A.VENDOREMAIL = :vemail \n" +
                             "ORDER BY A.invoicedate DESC";

                using (conn)
                {
                    conn.Open();
                    var response = conn.Query<InvoiceList>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<InvoiceList> GetAllInvoiceList()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT A.id invoiceid, A.contractid, A.invoicenumber, A.invoicedate, A.contractnumber, A.vendorname, A.vendoremail, \n" +
                             "A.projectname, A.totalincludingvat, A.invoicestatus, A.expectedrepaymentdate, C.CorporateName FROM DISCOUNTING_INVOICE A \n" +
                             "LEFT OUTER JOIN DISCOUNTING_CONTRACT B ON A.CONTRACTID = B.ID \n" +
                             "LEFT OUTER JOIN DISCOUNTING_CORPORATEDETAILS C ON B.CORPORATEID = C.ID \n" +
                             "ORDER BY A.INVOICEDATE DESC";

                using (conn)
                {
                    conn.Open();
                    var response = conn.Query<InvoiceList>(sql, commandType: CommandType.Text).ToList();

                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public bool AuthorizeInvoice(AuthorizeInvoice invoice)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                using (conn)
                {
                    conn.Open();
                    int executed = conn.Execute("PR_DISCOUNTING_AUTHORIZE_INV", param: invoice, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public IEnumerable<VendorBreakdown> GetVendorBreakdownByCorporate(int CorporateID)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { corpid = CorporateID };
                string sql = "SELECT  (a.firstname || ' ' || a.lastname) VendorName, a.email VendorEmail, \n" +
                            "(SELECT COUNT(*) FROM discounting_contract_response WHERE vendoremail = a.email AND responsestatus <> 'Declined') ContractResponseCount, \n" +
                            "(SELECT COUNT(*) FROM discounting_invoice WHERE vendoremail = a.email) InvoiceCount, \n" +
                            "(SELECT COUNT(*) FROM discounting_invoice WHERE vendoremail = a.email AND requestdiscounting = '1') InvoiceDiscountingCount \n" +
                            "FROM discounting_users a \n" +
                            " WHERE CORPORATEID = :corpid AND USERCLASS = 'VENDOR'";

                using (conn)
                {
                    conn.Open();
                    var response = conn.Query<VendorBreakdown>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public IEnumerable<ContractInvoice> GetAllInvoices()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT * FROM DISCOUNTING_INVOICE order by ID desc";

                using (conn)
                {
                    conn.Open();
                    var response = conn.Query<ContractInvoice>(sql, commandType: CommandType.Text).ToList();

                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public List<InvoiceItem> GetInvoiceItemsByInvoiceId(int invoiceId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { invId = invoiceId };
                string sql = "SELECT * FROM DISCOUNTING_INVOICE_ITEM WHERE INVOICEID = :invId order by ID desc";

                using (conn)
                {
                    conn.Open();
                    var response = conn.Query<InvoiceItem>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public InvoiceLoan GetInvoiceLoanByInvoiceId(int invoiceId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { invId = invoiceId };
                string sql = "Select * from DISCOUNTING_INVOICE_LOAN where invoiceid = :invId order by ID desc";
                using (conn)
                {
                    conn.Open();
                    InvoiceLoan loanDetails = conn.Query<InvoiceLoan>(sql, param: parameter, commandType: CommandType.Text).FirstOrDefault();

                    return loanDetails;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public int InsertCorporateLoan(CorporateLoan loanDetails)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                DynamicParameters loanParams = new DynamicParameters();
                loanParams.Add("contractid", loanDetails.contractid);
                loanParams.Add("corporateid", loanDetails.corporateid);
                loanParams.Add("corporatename", loanDetails.corporatename);
                loanParams.Add("loanid", loanDetails.loanid);
                loanParams.Add("availablelimit", loanDetails.availablelimit);
                loanParams.Add("interest", loanDetails.interest);
                loanParams.Add("totalamount", loanDetails.totalamount);
                loanParams.Add("maturityperiod", loanDetails.maturityperiod);
                loanParams.Add("accountnumber", loanDetails.accountnumber);
                loanParams.Add("fundsdisbursed", loanDetails.fundsdisbursed);
                loanParams.Add("accountname", loanDetails.accountname);
                loanParams.Add("fees", loanDetails.fees);
                loanParams.Add("id", DbType.Int32, direction: ParameterDirection.Output);

                using (conn)
                {
                    conn.Open();
                    var result = conn.Execute("PR_DISCOUNTING_CORPORATE_LOAN", param: loanParams, commandType: CommandType.StoredProcedure);
                    var loanId = loanParams.Get<int>("id");
                    return loanId;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return 0;
            }
        }
        public bool UpdateCorporateLoanDisbursement(int loanId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = loanId };

                string sql = $"UPDATE discounting_corporate_loan \n" +
                            "SET fundsdisbursed = 1, \n" +
                            "disbursementdate = SYSDATE \n" +
                            "WHERE ID = :idt ";

                using (conn)
                {
                    conn.Open();
                    conn.Execute(sql, param: parameter, commandType: CommandType.Text);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public IEnumerable<CorporateLoan> GetCorporateLoanByCorporateId(int corporateId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { corpId = corporateId };
                string sql = "SELECT * FROM discounting_corporate_loan WHERE corporateid = :corpId order by ID desc";
                using (conn)
                {
                    conn.Open();
                    var loanDetails = conn.Query<CorporateLoan>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return loanDetails;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public bool InsertRecourseFactoring(RecourseFactoring loanDetails)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);

                using (conn)
                {
                    conn.Open();
                    var result = conn.Execute("PR_DISCOUNTING_RECOURSE_FACTOR", param: loanDetails, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public IEnumerable<RecourseFactoring> GetRecourseFactoringByCorporateId(int corporateId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { corpId = corporateId };
                string sql = "SELECT * FROM discounting_recourse_factoring WHERE corporateid = :corpId order by ID desc";
                using (conn)
                {
                    conn.Open();
                    var loanDetails = conn.Query<RecourseFactoring>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return loanDetails;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public IEnumerable<ContractInvoice> GetInvoicesWithNoLoan(int corporateId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { corpId = corporateId };
                string sql = $"SELECT A.* FROM discounting_invoice A \n" +
                            "LEFT OUTER JOIN discounting_contract B \n" +
                            "ON A.CONTRACTID = B.ID \n" +
                            "WHERE A.ID NOT IN(SELECT INVOICEID FROM discounting_invoice_loan) \n" +
                            "AND A.ID NOT IN(SELECT INVOICEID FROM discounting_recourse_factoring) \n" +
                            "AND A.INVOICESTATUS = 'COMPLETED' \n" +
                            "AND TRUNC(A.DATEAUTHORIZED + DAYS) >= SYSDATE \n" +
                            "AND B.CORPORATEID = :corpId";
                using (conn)
                {
                    conn.Open();
                    var invoices = conn.Query<ContractInvoice>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return invoices;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public bool UpdateInvoiceLoanStatus(int invoiceId, string loanStatus)
        {
            try
            {
                string sql = "";
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { invId = invoiceId, loanStat = loanStatus };

                sql = $@"UPDATE DISCOUNTING_INVOICE_LOAN 
                        SET loanstatus = :loanStat
                        WHERE invoiceid = :invId";

                using (conn)
                {
                    conn.Open();
                    conn.Execute(sql, param: parameter, commandType: CommandType.Text);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool UpdateInvoiceLoanDisbursement(int invoiceId, bool isDisbursed, int repaymentDays)
        {
            try
            {
                string sql = "";
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { invId = invoiceId, repayDays = repaymentDays };

                if (isDisbursed)
                {
                    sql = $@"UPDATE DISCOUNTING_INVOICE_LOAN SET fundsdisbursed = '1',
                            expectedrepaymentdate = SYSDATE + :repayDays, 
                            disbursementdate = SYSDATE,
                            loanstatus = '{LoanStatus.DISBURSED.ToString()}'
                            WHERE invoiceid = :invId";
                }
                else
                {
                    sql = $@"UPDATE DISCOUNTING_INVOICE_LOAN SET fundsdisbursed = '0',
                            expectedrepaymentdate = SYSDATE + :repayDays,
                            loanstatus = '{LoanStatus.FAILEDDISBURSEMENT.ToString()}'
                            WHERE invoiceid = :invId";
                }
                using (conn)
                {
                    conn.Open();
                    conn.Execute(sql, param: parameter, commandType: CommandType.Text);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool UpdateInvoiceLoanRepayment(int invoiceId, bool isRepayed)
        {
            try
            {
                string sql = "";
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { invId = invoiceId };

                if (isRepayed)
                {
                    sql = $@"UPDATE DISCOUNTING_INVOICE_LOAN SET LOANREPAID = '1',
                            repaymentdate = SYSDATE, 
                            loanstatus = '{LoanStatus.REPAYED.ToString()}'
                            WHERE invoiceid = :invId";
                }
                else
                {
                    sql = $@"UPDATE DISCOUNTING_INVOICE_LOAN SET LOANREPAID = '0',
                            loanstatus = '{LoanStatus.FAILEDREPAYMENT.ToString()}'
                            WHERE invoiceid = :invId";
                }

                using (conn)
                {
                    conn.Open();
                    conn.Execute(sql, param: parameter, commandType: CommandType.Text);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public IEnumerable<ContractInvoice> GetInvoicesWithPendingRepayment()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = "SELECT di.ID,di.CONTRACTID,di.INVOICENUMBER,\n" +
                             "di.INVOICEDATE, di.VATREGISTRATIONNO,di.VENDORCODE, \n" +
                             "di.TIN,di.CONTRACTNUMBER,di.PONUMBER,di.PROJECTNAME,\n" +
                             "di.VENDORNAME,di.VENDOREMAIL,di.VENDORADDRESS,di.VENDORPHONENO,\n" +
                             "di.DESCRIPTION,di.DAYS,di.UNITPRICE,di.TOTALEXCLUDINGVAT,di.TOTALINCLUDINGVAT,\n" +
                             "di.TOTALAMOUNTINWORDS,di.ACCOUNTNUMBER,di.ACCOUNTNAME,di.BANKNAME,\n" +
                             "di.INVOICESTATUS,di.VATRATE,di.AUTHORIZERNAME, di.AUTHORIZERCOMMENT, di.DATEAUTHORIZED,\n" +
                             "di.REQUESTDISCOUNTING,di.ISAUTOREPAYMENT,di.EXPECTEDREPAYMENTDATE, di.PAYMENTSETTLED,\n" +
                             "di.REPAYMENTDATE FROM DISCOUNTING_INVOICE di Left JOIN DISCOUNTING_PAYMENT dp\n" +
                             "ON di.INVOICENUMBER = dp.INVOICENO \n" +
                             "WHERE di.invoicestatus = 'COMPLETED' \n" +
                             "AND di.paymentsettled = 0 \n" +
                             "AND dp.PAYMENTREFERENCE IS NOT NULL \n" +
                             "AND TRUNC(di.dateauthorized +days) <= TRUNC(SYSDATE)  order by di.ID";
                //string sql = $"SELECT * FROM DISCOUNTING_INVOICE \n" +
                //            "WHERE invoicestatus = 'COMPLETED' \n" +
                //            "AND paymentsettled = 0 \n" +
                //            "AND TRUNC(dateauthorized + days) <= TRUNC(SYSDATE)  order by ID";

                using (conn)
                {
                    conn.Open();
                    var invoices = conn.Query<ContractInvoice>(sql, commandType: CommandType.Text).ToList();

                    return invoices;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<CorporateLoan> GetCorporateLoanWithPendingRepayment()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                string sql = $"SELECT * FROM discounting_corporate_loan \n" +
                            "WHERE fundsdisbursed = '1' \n" +
                            "AND loanrepaid = 0 \n" +
                            "AND TRUNC(EXPECTEDREPAYMENTDATE) <= TRUNC(SYSDATE) order by ID ";

                using (conn)
                {
                    conn.Open();
                    var loadDetails = conn.Query<CorporateLoan>(sql, commandType: CommandType.Text).ToList();

                    return loadDetails;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public IEnumerable<RecourseFactoring> GetReverseFactoringWithPendingRepayment(int loanId)
        {
            try
            {

                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { loadidt = loanId };
                string sql = $"SELECT A.* , B.* FROM discounting_recourse_factoring A \n" +
                            "LEFT OUTER JOIN discounting_corporate_loan B \n" +
                            "ON A.LOANID = B.ID \n" +
                            "WHERE A.LOANSTATUS = 'DISBURSED' \n" +
                            "AND A.LOANID = :loadidt \n" +
                            "AND TRUNC(B.EXPECTEDREPAYMENTDATE) >= TRUNC(SYSDATE) ";

                using (conn)
                {
                    conn.Open();
                    var reverseFactoring = conn.Query<RecourseFactoring>(sql, param: parameter, commandType: CommandType.Text).ToList();

                    return reverseFactoring;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public string GetCorporateAccountByInvoiceId(int invoiceId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = invoiceId };

                string sql = $"SELECT c.principalaccountno FROM discounting_invoice a \n" +
                            "LEFT OUTER JOIN discounting_contract b ON a.contractid = b.id \n" +
                            "LEFT OUTER JOIN discounting_corporatedetails c ON b.corporateid = c.id \n" +
                            "WHERE a.id = :idt ";

                using (conn)
                {
                    conn.Open();
                    var corporateAcctNo = conn.Query<string>(sql, param: parameter, commandType: CommandType.Text).FirstOrDefault();

                    return corporateAcctNo;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public InvoiceDiscountingVM GetAccessRepInvoiceDiscByInvoiceId(int invoiceId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = invoiceId };

                string sql = $"SELECT a.id, a.requestedamount, a.interest, a.totalamount, \n" +
                            "a.requestorname, a.requestoremail, a.daterequested, a.fundsdisbursed, a.disbursementdate, \n" +
                            "a.expectedrepaymentdate, a.loanrepaid, a.repaymentdate, a.vendoraccountno, \n" +
                            "a.invoicenumber, a.vendoraccountname,c.corporatename, c.interestrate, b.paymenttenor, null AS GL \n" +
                            "FROM discounting_invoice_loan a \n" +
                            "LEFT OUTER JOIN discounting_contract b ON a.contractid = b.id \n" +
                            "LEFT OUTER JOIN discounting_corporatedetails c ON b.corporateid = c.id \n" +
                            "WHERE a.invoiceid = :idt ";

                using (conn)
                {
                    conn.Open();
                    var invoiceDiscDetails = conn.Query<InvoiceDiscountingVM>(sql, param: parameter, commandType: CommandType.Text).FirstOrDefault();

                    return invoiceDiscDetails;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public ReverseFactoringVM GetAccessRepReverseFactByInvoiceId(int invoiceId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = invoiceId };

                string sql = $"SELECT a.id, a.contractid, a.invoiceid, a.totalamount, a.maturityperiod, \n" +
                            " a.vendorname, a.vendoremail, a.corporateid, a.corporatename, a.loanid, \n" +
                            "a.daterequested, a.fundsdisbursed, a.disbursementdate, a.expectedrepaymentdate,  \n" +
                            "a.loanrepaid, a.repaymentdate, a.loanstatus, a.invoicenumber, a.vendoraccountno,  \n" +
                            "a.description, a.fcubsexternalref, \n" +
                            "b.accountnumber AS corporateacctno, b.accountname AS corporateacctname, null AS GL \n" +
                            "FROM discounting_recourse_factoring a \n" +
                            "LEFT OUTER JOIN discounting_corporate_loan b ON a.loanid = b.id \n" +
                            "WHERE a.invoiceid = :idt ";

                using (conn)
                {
                    conn.Open();
                    var reverseFactDetails = conn.Query<ReverseFactoringVM>(sql, param: parameter, commandType: CommandType.Text).FirstOrDefault();

                    return reverseFactDetails;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<InvoiceLoan> GetAllInvoiceLoan()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);

                string sql = "SELECT a.id, a.contractid, a.invoiceid, a.eligibleamount, \n" +
                             "a.requestedamount, a.interest, a.totalamount, a.discountingtype, \n" +
                             "b.vendorname requestorname, b.vendoremail requestoremail, a.acceptterms, \n" +
                             "a.daterequested, a.fundsdisbursed, a.disbursementdate, \n" +
                             "a.expectedrepaymentdate, a.loanrepaid, a.repaymentdate, \n" +
                             "a.vendoraccountno, a.invoicenumber, a.loanstatus, \n" +
                             "a.vendoraccountname \n" +
                             "FROM DISCOUNTING_INVOICE_LOAN a \n" +
                             "LEFT OUTER JOIN DISCOUNTING_INVOICE b \n" +
                             "ON a.invoiceid = b.id \n" +
                             "ORDER BY daterequested DESC";
                using (conn)
                {
                    conn.Open();
                    var loanDetails = conn.Query<InvoiceLoan>(sql, commandType: CommandType.Text).ToList();

                    return loanDetails;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public IEnumerable<RecourseFactoring> GetAllRecourseFactoring()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);

                string sql = "SELECT * FROM discounting_recourse_factoring order by ID desc";
                using (conn)
                {
                    conn.Open();
                    var loanDetails = conn.Query<RecourseFactoring>(sql, commandType: CommandType.Text).ToList();

                    return loanDetails;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public bool UpdateUserPassword(int userId, string hashedPwrd)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = userId, hashedPwd = hashedPwrd };

                string sql = $"UPDATE discounting_users \n" +
                            "SET hashedpassword = :hashedPwd, \n" +
                            "ispasswordnewlycreated = 0, \n" +
                            "lastupdatetime = SYSDATE \n" +
                            "WHERE ID = :idt ";

                using (conn)
                {
                    conn.Open();
                    conn.Execute(sql, param: parameter, commandType: CommandType.Text);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool UpdateCorporateAvailableLimit(int corporateId, decimal newLineOfCredit)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { idt = corporateId, newLineOfCredit = newLineOfCredit };

                string sql = "UPDATE discounting_corporatedetails \n" +
                            "SET availablelineofcredit = :newLineOfCredit \n" +
                            "WHERE ID = :idt ";

                using (conn)
                {
                    conn.Open();
                    conn.Execute(sql, param: parameter, commandType: CommandType.Text);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public IEnumerable<string> GetAllBanks()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);

                string sql = "SELECT BANKNAME FROM DISCOUNTING_BANKS";
                using (conn)
                {
                    conn.Open();
                    var banks = conn.Query<string>(sql, commandType: CommandType.Text).ToList();

                    return banks;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        public bool UpdateInvoiceDetails(ContractInvoice invoiceDetails)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                DynamicParameters invoiceParams = new DynamicParameters();
                invoiceParams.Add("contractid", invoiceDetails.contractid);
                invoiceParams.Add("invoicenumber", invoiceDetails.invoicenumber);
                invoiceParams.Add("invoicedate", invoiceDetails.invoicedate);
                invoiceParams.Add("vatregistrationno", invoiceDetails.vatregistrationno);
                invoiceParams.Add("vendorcode", invoiceDetails.vendorcode);
                invoiceParams.Add("tin", invoiceDetails.tin);
                invoiceParams.Add("contractnumber", invoiceDetails.contractnumber);
                invoiceParams.Add("ponumber", invoiceDetails.ponumber);
                invoiceParams.Add("projectname", invoiceDetails.projectname);
                invoiceParams.Add("vendorname", invoiceDetails.vendorname);
                invoiceParams.Add("vendoremail", invoiceDetails.vendoremail);
                invoiceParams.Add("vendoraddress", invoiceDetails.vendoraddress);
                invoiceParams.Add("vendorphoneno", invoiceDetails.vendorphoneno);
                invoiceParams.Add("description", invoiceDetails.description);
                invoiceParams.Add("days", invoiceDetails.days);
                invoiceParams.Add("unitprice", invoiceDetails.unitprice);
                invoiceParams.Add("totalexcludingvat", invoiceDetails.totalexcludingvat);
                invoiceParams.Add("totalincludingvat", invoiceDetails.totalincludingvat);
                invoiceParams.Add("totalamountinwords", invoiceDetails.totalamountinwords);
                invoiceParams.Add("accountnumber", invoiceDetails.accountnumber);
                invoiceParams.Add("accountname", invoiceDetails.accountname);
                invoiceParams.Add("bankname", invoiceDetails.bankname);
                invoiceParams.Add("vatrate", invoiceDetails.vatrate);
                invoiceParams.Add("requestdiscounting", invoiceDetails.requestdiscounting);
                invoiceParams.Add("isautorepayment", invoiceDetails.ISAUTOREPAYMENT);
                invoiceParams.Add("id", invoiceDetails.id);

                using (conn)
                {
                    conn.Open();
                    var result = conn.Execute("PR_DISCOUNTING_INVOICE_UPDATE", param: invoiceParams, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool ArchiveInvoiceDetails(int invoiceId)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { invoiceid = invoiceId };
                using (conn)
                {
                    conn.Open();
                    var inserted = conn.Execute("PR_DISCOUNTING_INVOICE_ARCHIVE", param: parameter, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool UpdateVendorStatus(int vendorId, bool status)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                char statusChar = status == true ? '1' : '0';
                var parameter = new { idt = vendorId, stat = statusChar };

                string sql = "UPDATE discounting_vendor \n" +
                            "SET status = :stat \n" +
                            "WHERE ID = :idt ";

                using (conn)
                {
                    conn.Open();
                    conn.Execute(sql, param: parameter, commandType: CommandType.Text);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool UpdateCorporateStatus(int corporateId, bool status)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                char statusChar = status == true ? '1' : '0';
                var parameter = new { idt = corporateId, stat = statusChar };

                string sql = "UPDATE discounting_corporatedetails \n" +
                            "SET status = :stat \n" +
                            "WHERE ID = :idt ";

                using (conn)
                {
                    conn.Open();
                    conn.Execute(sql, param: parameter, commandType: CommandType.Text);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public bool SavePaymentDetails(PaymentDetails payment)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                using (conn)
                {
                    conn.Open();
                    var saved = conn.Execute("PR_DISCOUNTING_PAYMENT", param: payment, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool UpdateInvoiceRepaymentStatus(int invoiceId, bool status)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                char statusChar = status == true ? '1' : '0';
                var parameter = new { idt = invoiceId, stat = statusChar };

                string sql = "UPDATE discounting_invoice \n" +
                            "SET PAYMENTSETTLED = :stat, \n" +
                            "REPAYMENTDATE = SYSDATE \n" +
                            "WHERE ID = :idt ";

                using (conn)
                {
                    conn.Open();
                    conn.Execute(sql, param: parameter, commandType: CommandType.Text);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public bool UpdateCorporateLoanRepaymentStatus(int loanId, bool status)
        {
            try
            {

                OracleConnection conn = new OracleConnection(connString);
                char statusChar = status == true ? '1' : '0';
                var parameter = new { idt = loanId };
                string sql = "";
                //string sql = "UPDATE discounting_corporate_loan \n" +
                //            "SET LOANREPAID = :stat, \n" +
                //            "REPAYMENTDATE = SYSDATE \n" +
                //            "WHERE ID = :idt ";

                if (status)
                {
                    sql = $@"UPDATE DISCOUNTING_CORPORATE_LOAN 
                            SET LOANREPAID = '1',
                                REPAYMENTDATE = SYSDATE
                            WHERE ID = :idt ";
                }
                else
                {
                    sql = $@"UPDATE DISCOUNTING_CORPORATE_LOAN 
                            SET LOANREPAID = '0'
                            WHERE ID = :idt ";
                }

                using (conn)
                {
                    conn.Open();
                    conn.Execute(sql, param: parameter, commandType: CommandType.Text);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        public bool UpdateRecourseFactoringRepaymentStatus(int loanId, bool loanRepaid, string loanStatus)
        {
            try
            {

                OracleConnection conn = new OracleConnection(connString);
                char lrepaid = loanRepaid == true ? '1' : '0';
                var parameter = new { idt = loanId, repaid = lrepaid, loanStat = loanStatus };
                string sql = "";
                //string sql = "UPDATE discounting_recourse_factoring \n" +
                //            "SET LOANREPAID = :repaid, \n" +
                //            "REPAYMENTDATE = SYSDATE, \n" +
                //            "loanstatus = :loanStat \n" +
                //            "WHERE loanid = :idt ";
                if (loanRepaid)
                {
                    sql = $@"UPDATE discounting_recourse_factoring SET LOANREPAID = '1',
                            REPAYMENTDATE = SYSDATE, 
                            loanstatus = '{LoanStatus.REPAYED.ToString()}'
                            WHERE loanid = :idt ";
                }
                else
                {
                    sql = $@"UPDATE discounting_recourse_factoring 
                            SET LOANREPAID = '0',
                                loanstatus = '{LoanStatus.FAILEDREPAYMENT.ToString()}'
                            WHERE ID = :idt ";
                }

                using (conn)
                {
                    conn.Open();
                    conn.Execute(sql, param: parameter, commandType: CommandType.Text);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool IsSingleCorporate(int corporateId)
        {
            try
            {
                if (corporateId == 0)
                {
                    return false;
                }

                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { corpid = corporateId };

                string sql = "SELECT COUNT(*) FROM discounting_users WHERE USERCLASS = 'CORPORATE' AND CORPORATECORPID = :corpid";
                using (conn)
                {
                    conn.Open();
                    var corporateUserCount = conn.Query<int>(sql, parameter, commandType: CommandType.Text).FirstOrDefault();

                    if (corporateUserCount > 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        
        public IEnumerable<BidViewModel> GetLoanBidListByVendor(string vendorCode)
        {
            try
            {                
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { vendorid = vendorCode };

                // diaplay loans that has been approved by the corporate and the loans that bids has been submitted but none has been accepted
                string sql = @"SELECT dil.*, di.VENDORNAME, di.PROJECTNAME, di.TOTALEXCLUDINGVAT, di.VENDORCODE 
                                FROM DISCOUNTING_INVOICE_LOAN dil 
                                LEFT OUTER JOIN DISCOUNTING_INVOICE di ON di.ID = dil.INVOICEID 
                                WHERE di.INVOICESTATUS = 'COMPLETED'
	                                AND dil.LOANSTATUS IN ('APPROVED', 'BID ONGOING')
	                                AND di.VENDORCODE = :vendorid";
                using (conn)
                {
                    conn.Open();
                    var invoiceLoans = conn.Query<BidViewModel>(sql, parameter, commandType: CommandType.Text).ToList();

                    return invoiceLoans;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<BidViewModel> GetAllAvailableLoanBidList()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);

                // diaplay loans that has been approved by the corporate and the loans that bids has been submitted but none has been accepted
                string sql = @"SELECT dil.*, di.VENDORNAME, di.PROJECTNAME, di.TOTALEXCLUDINGVAT, di.VENDORCODE 
                                FROM DISCOUNTING_INVOICE_LOAN dil 
                                LEFT OUTER JOIN DISCOUNTING_INVOICE di ON di.ID = dil.INVOICEID 
                                WHERE di.INVOICESTATUS = 'COMPLETED'
	                                AND dil.LOANSTATUS  IN ('APPROVED', 'BID ONGOING')"; 
                using (conn)
                {
                    conn.Open();
                    var invoiceLoans = conn.Query<BidViewModel>(sql, commandType: CommandType.Text).ToList();

                    return invoiceLoans;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public IEnumerable<BidModel> GetBidByLoanId(int loanIdt)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { loanid = loanIdt };

                string sql = @"SELECT * FROM DISCOUNTING_BID
                               WHERE LOANID = :loanid";
                using (conn)
                {
                    conn.Open();
                    var bids = conn.Query<BidModel>(sql, commandType: CommandType.Text).ToList();

                    return bids;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
        
        public bool PlaceBid(InsertBid bidDetails)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                using (conn)
                {
                    conn.Open();
                    var saved = conn.Execute("PR_DISCOUNTING_INSERT_BID", param: bidDetails, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool AcceptBid(int bidIdt, int loanIdt)
        {
            try
            {
                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { bidid = bidIdt, loanid = loanIdt };

                using (conn)
                {
                    conn.Open();
                    var saved = conn.Execute("PR_DISCOUNTING_ACCEPT_BID", param: parameter, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }

        public bool UpdateLoanStatusAfterSubmittingBid(int loanId)
        {
            try
            {

                OracleConnection conn = new OracleConnection(connString);
                var parameter = new { lid = loanId };
                
                string sql = $@"UPDATE DISCOUNTING_INVOICE_LOAN 
	                        SET LOANSTATUS = 'BID ONGOING'
	                        WHERE ID = :lid;";

                using (conn)
                {
                    conn.Open();
                    conn.Execute(sql, param: parameter, commandType: CommandType.Text);

                    return true;
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