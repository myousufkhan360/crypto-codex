using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TmsPlusRetailAPI.Models
{
    public class ProductSetupMdl
    {

        public class ProductSetUp
        {
            public int SysID { get; set; }
            public DateTime SysDate { get; set; }
            public string ProductCode { get; set; }
            public string ProductName { get; set; }
            public string Tenure { get; set; }
            public string Rate { get; set; }
            public string FixedContribution { get; set; }
            public int PolicyTypeCode { get; set; }

            //Get String Names
            public string PolicyTypeName { get; set; }

        }

    }
}