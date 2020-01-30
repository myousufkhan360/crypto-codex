using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSetupApi.Models
{

    public class DuplicationCheck
    {
        public bool IsDuplicate { get; set; }
    }

    public class TxnError
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public string ErrorCode { get; set; }
        public string Error { get; set; }

    }



}