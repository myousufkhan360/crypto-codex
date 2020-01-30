using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSetupApi.Models
{
    public class UserMDL
    {
        public string UserID { get; set; }
        public string UserPassword { get; set; }
        public int UserSysID { get; set; }
        public DateTime UserSysDate { get; set; }
    }


    public class UserToken
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public bool IsValid { get; set; }
        public string Token { get; set; }
        public string UserID { get; set; }
    }

}