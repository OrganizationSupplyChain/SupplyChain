using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;


namespace Invoice_Discounting.Services
{
	public class ActiveDirectoryService: IActiveDirectoryService
	{
		private readonly IConfiguration _config;
		private readonly string _domain;
		private UserPrincipal UserPrincipal { get; set; }
		private static DirectoryEntry DirEntry { get; set; }
		NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		public ActiveDirectoryService( IConfiguration config)
		{
			_config = config;
			_domain = _config["ADSettings:ldapip"]; 
		}

		public UserPrincipal Login(string username, string password)
		{
			try
			{
				var ldap = _config["ADSettings:ldapip"];
				DirEntry = new DirectoryEntry(_domain, username, password);
				PrincipalContext oPrincipalContext = GetPrincipalContext(username, password);
				UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, username);
				return userPrincipal;
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				if (ex.Message.Contains("operational"))
				{
					logger.Info("The active directory server is not Operational at the moment");
					return null;
				}
				logger.Info("Login Failure");
				return null;
			}
		}

		public  PrincipalContext GetPrincipalContext(string username, string password)
		{

			PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, _config["ADSettings:ldapip"], _config["ADSettings:domain_user"] + @"\" + username, password);
			return oPrincipalContext;
		}

        public UserPrincipal GetUser(string sUserName, string tempUserName, string tempPassword)
        {          

            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, _config["ADSettings:domain_user"]))
            {
                var user = UserPrincipal.FindByIdentity(context, sUserName);
                return user;                
            }
        }

        public List<string> GetUsersInGroup(string groupName)
		{
			using (var context = new PrincipalContext(ContextType.Domain, _config["ADSettings:ldapip"], _config["ADSettings:domain_user"] + @"\" + _config["ADSettings:adusername"], _config["ADSettings:adpassword"]))
			{
				using (var group = GroupPrincipal.FindByIdentity(context, groupName))
				{

					if (group == null)
					{
						//throw new RiaException("ActiveDirectoryService", "Group does not exist in active directory", "ADS01");
					}
					var users = @group.GetMembers(true);
					var exemptedEmails = _config["AppSettings:exempt"]
						.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
					var list = (from UserPrincipal user in users where !exemptedEmails.Contains(user.EmailAddress) select user.EmailAddress).ToList();
					return list;
				}
			}
		}

		public List<string> GetUsersInGroup(string groupName,string username,string password)
		{
			using (var context = new PrincipalContext(ContextType.Domain, _config["ADSettings:ldapip"], _config["ADSettings:domain_user"] + @"\" + username,password))
			{
				using (var group = GroupPrincipal.FindByIdentity(context, groupName))
				{

					if (group == null)
					{
						//throw new RiaException("ActiveDirectoryService", "Group does not exist in active directory", "ADS01");
					}
					var users = @group.GetMembers(true);
					var exemptedEmails = _config["AppSettings:exempt"]
						.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
					List<string> list = (from UserPrincipal user in users where !exemptedEmails.Contains(user.EmailAddress) select user.EmailAddress).ToList();
					return list;
				}
			}
		}
    }
}
