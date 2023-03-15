using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class VendorBatchDetailsPending
    {
        [DataType(DataType.Text)]
        public int ID { get; set; }
        public byte[] vendorbulk { get; set; }
        [DataType(DataType.Text)]
        public string DATECREATED { get; set; }
        [DataType(DataType.Text)]
        public int AUTHORIZATIONSTATUS { get; set; }
        public DateTime DATEAUTHORIZED { get; set; }
        [DataType(DataType.Text)]
        public string CREATEDBYNAME { get; set; }
        [DataType(DataType.Text)]
        public string AUTHORIZERNAME { get; set; }
        [DataType(DataType.Text)]
        public string AUTHORIZEREMAIL { get; set; }
        [DataType(DataType.Text)]
        public string AUTHORIZERCOMMENT { get; set; }
    }
}
