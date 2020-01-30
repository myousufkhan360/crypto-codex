using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ddlAPI.Models
{
    public class SubmitStatus
    {
        public string Ref { get; set; }
        public bool IsValid { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
    }
}