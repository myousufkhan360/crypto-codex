using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakafulSetup.Api.Models
{
    public class UserMDL
    {
        public string UserID { get; set; }
        public string UserPassword { get; set; }
        public int UserSysID { get; set; }
        public DateTime UserSysDate { get; set; }
    }
}