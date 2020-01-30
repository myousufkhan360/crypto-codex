using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSetupApi.Models
{
    public class MtrPolicy
    {

        //Mtr Policy
        public class MtrPolicyMdl
        {

            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public string PolicyMonth { get; set; }
            public string PolicyString { get; set; }
            public string PolicyYear { get; set; }
            public string PolicyNo { get; set; }
            public string DocType { get; set; }
            public string GenerateAgainst { get; set; }
            public int ProductCode { get; set; }
            public string PolicyTypeCode { get; set; }
            public string ClientCode { get; set; }
            public string AgencyCode { get; set; }
            public string CertInsureCode { get; set; }
            //  public string ClientName { get; set; }
            public string ClientAddress { get; set; }
            public string ConditionCode { get; set; }
            public string WarrantyCode { get; set; }
            public string Remarks { get; set; }
            public string BrchCoverNoteNo { get; set; }
            public string LeaderPolicyNo { get; set; }
            public string LeaderEndNo { get; set; }
            public string IsFiler { get; set; }
            public string CalcType { get; set; }
            public string IsAuto { get; set; }
            public DateTime EffectiveDate { get; set; }
            public DateTime ExpiryDate { get; set; }
            public int SerialNo { get; set; }
            public string UWYear { get; set; }
            public string CreatedBy { get; set; }
            public int InsuranceTypeCode { get; set; }
            public decimal CommisionRate { get; set; }
          

            //For Posting
            public string PostedBy { get; set; }
            public DateTime PostDate { get; set; }
            public bool IsPosted { get; set; }


            //For Errors
            public bool IsValidTxn { get; set; }
            public List<TxnError> TxnErrors { get; set; }
            //For Active
            public bool IsActiveTxn { get; set; }

            //For Geting Strings from Code
            public string ProductName { get; set; }
            public string PolicyTypeName { get; set; }
            public string ClientName { get; set; }
            public string AgentName { get; set; }
            public string CertInsureName { get; set; }
            public string DocTypeName { get; set; }
            public string IsAutoName { get; set; }
            public string CalcName { get; set; }
            public string IsFilerName { get; set; }
            public string InsuranceTypeName { get; set; }

            //For Expiry
            public bool IsExpired { get; set; }

        }



    }
}