using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceDiscounting.BusinessLogic.Model
{
    public class Users
    {
        public int ID { get; set; }
            public string USERNAME { get; set; }
            public string EMAIL { get; set; }
            public string FIRSTNAME { get; set; }
            public string LASTNAME { get; set; }
            public int ROLEID { get; set; }
            public string ROLENAME { get; set; }
            public string USERTYPE { get; set; }
            public string USERCLASS { get; set; }
            public int CORPORATEID { get; set; }
            public int STATUS { get; set; }
            public int FAILURETRIES { get; set; }
            public char LOCKSTATUS { get; set; }
            public DateTime LASTLOCKTIME { get; set; }
            public string HASHEDPASSWORD { get; set; }
            public char ISPASSWORDNEWLYCREATED { get; set; }
            public string INPUTTEREMAIL { get; set; }
            public string INPUTTERNAME { get; set; }
            public string AUTHORIZEREMAIL { get; set; }
            public string AUTHORIZERNAME { get; set; }
            public DateTime CREATEDDATE { get; set; }
            public DateTime? LASTLOGINDATE { get; set; }
            public DateTime? LASTUPDATETIME { get; set; }
            public DateTime? DATEAUTHORIZED { get; set; }
        }
	
}
