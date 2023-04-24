using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Invoice_Discounting.Models
{
    public class UpdateCategoryList
    {
        public int ID { get; set; }
        public string STATUS { get; set; }
        public string CATEGORYNAME { get; set; }
        public string CREATEDBYNAME { get; set; }
        public  DateTime DATECREATED { get; set; }
        public string CREATEDBYEMAIL { get; set; }
        public string UPDATETYPE { get; set; }
    }
}
