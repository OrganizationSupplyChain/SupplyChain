using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class UpdateCorporateBulk
    {

        public int ID { get; set; }
        public byte[] corporatebulk { get; set; }
        public int STATUS { get; set; }
        public string CREATEDBYNAME { get; set; }
        public string CREATEDBYEMAIL { get; set; }
        public DateTime DATECREATED { get; set; }
        public string UPDATETYPE { get; set; }
        public string AUTHORIZERCOMMENT { get; set; }
        public string AUTHORIZEREMAIL { get; set; }
        public string AUTHORIZERNAME { get; set; }
    }
}
