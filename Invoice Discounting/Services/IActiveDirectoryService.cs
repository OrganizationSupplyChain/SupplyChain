using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

namespace Invoice_Discounting.Services
{
	public interface IActiveDirectoryService
	{
		UserPrincipal Login(string username, string password);
		UserPrincipal GetUser(string sUserName, string tempUserName, string tempPassword);
		List<string> GetUsersInGroup(string groupName);
		List<string> GetUsersInGroup(string groupName, string username, string password);
	}
}