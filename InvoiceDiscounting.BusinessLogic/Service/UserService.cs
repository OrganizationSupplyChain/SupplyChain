using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Dapper;
using InvoiceDiscounting.BusinessLogic.Model;
using InvoiceDiscounting.BusinessLogic.Repository;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;

namespace InvoiceDiscounting.BusinessLogic.Service
{
    public class UserService : BaseRepository,IUserService
    {
        public UserService():base(MethodBase.GetCurrentMethod()?.Name)
        {
            
        }
        
        bool IUserService.EnableUser()
        {
            bool resp = false;
            try
            {

                using var conn = NewConnect();
                conn.Open();
                var sql = "SELECT * FROM DISCOUNTING_USERS where Failuretries='3' and LockStatus='1'";
                //get all locked Users
                //Fetch All the Locked Users with Failure Retry=3 and LockedStatus=1
                List<Users> user = conn.Query<Users>(sql, commandType: CommandType.Text).ToList();
                //convert the list to datable for Bulk Unlock to be possible

                UnlockUser(user);

                return true;
            }
            catch (Exception ex)
            {
                Log(LogType.Error,ex,"Error Occur While trying to Enable User");
            }

            return resp;
        }

        private void UnlockUser(List<Users> Users)
        {
            try
            {
                //Declare a new list
                //loop through the previous list and check users with 
                //lockedtime greater than 5minute
                var defaulttime = int.Parse(ConfigurationManager.AppSettings["maxtimeinsec"]); 
                List<Users> usertobeunlock = new List<Users>();

                foreach (var user in Users)
                {
                    var duration = DateTime.Now.Subtract((DateTime)user.LASTLOCKTIME);

                    var durationsec = duration.TotalSeconds;

                    if (durationsec >= defaulttime)
                    {
                        usertobeunlock.Add(user);
                    }
                }
                
                var json = JsonConvert.SerializeObject(usertobeunlock);
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

                string[] USERNAMES = new string[dt.Rows.Count];
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    USERNAMES[i] = Convert.ToString(dt.Rows[i]["USERNAME"]);
                   
                }
                //change the array to comma separated sequence
                var username = $"('{string.Join("','", USERNAMES)}')";

                if (username != "('')")
                {
                    using var conn = NewConnect();
                    using (conn)
                    {
                        conn.Open();
                        OracleCommand cmd = conn.CreateCommand();
                        cmd.CommandText = ($"UPDATE DISCOUNTING_USERS SET Failuretries='0',LockStatus=0 where username in {username}");
                        cmd.ExecuteNonQuery();
                    }
                }
               
                
            }
            catch (Exception ex)
            {
               // logger.Debug($"Error during bulk insert{ex.Message}");

            }
        }
    }
}