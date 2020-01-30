using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSetupApi.Models
{
    public class InsPolicyMdl
    {

        //Ins Policy
        public class MtrInsPolicyMdl
        {

            public int ParentTxnSysID { get; set; }
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public string CertMonth { get; set; }
            public string CertString { get; set; }
            public string CertYear { get; set; }
            public int CertNo { get; set; }
            public string DocType { get; set; }
            public string GenerateAgainst { get; set; }
            public int ProductCode { get; set; }
            public string PolicyTypeCode { get; set; }
            public string ClientCode { get; set; }
            public string AgencyCode { get; set; }
            public string CertInsureCode { get; set; }
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
           // public string PostedBy { get; set; }
           // public Boolean IsPosted { get; set; }
           // public DateTime PostDate { get; set; }
            public int OpolTxnSysID { get; set; }
            public int RenewSysID { get; set; }
            public int PolSysID { get; set; }
            public Boolean IsRenewal { get; set; }
            public decimal CommisionRate { get; set; }
            public string BrchCode { get; set; }

            public bool IsActive { get; set; }

            public int RenewalType { get; set; }
            public int EndoSerial { get; set; }

            //For Deduction of renewal
            public decimal Deduct { get; set; }
            public decimal ParticipantValue { get; set; }

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

            //For Expiry
            public bool IsExpired { get; set; }

            //For Vehicle Details For Renewal
            public string ParticipantName { get; set; }
            public int InsuranceTypeCode { get; set; }
            public string InsuranceTypeName { get; set; }
        }

        //Ins Tracker
        public class MtrInsTrackerMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int TrackerCode { get; set; }
            public string TrackerName { get; set; }
            public int TrackerRate { get; set; }
            public int ParentTxnSysID { get; set; }

            //For Errors
            public bool IsValidTxn { get; set; }
            public List<TxnError> TxnErrors { get; set; }
            //For Active
            public bool IsActiveTxn { get; set; }

        }

        //InsRider
        public class MtrInsRiderMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int RiderCode { get; set; }
            public string RiderName { get; set; }
            public int RiderRate { get; set; }
            public int ParentTxnSysID { get; set; }

            //For Errors
            public bool IsValidTxn { get; set; }
            public List<TxnError> TxnErrors { get; set; }
            //For Active
            public bool IsActiveTxn { get; set; }

        }

        //Ins Conditions
        public class MtrInsConditionsMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int ParentTxnSysID { get; set; }
            public string Condition { get; set; }

            //For Errors
            public bool IsValidTxn { get; set; }
            public List<TxnError> TxnErrors { get; set; }
            //For Active
            public bool IsActiveTxn { get; set; }

            public string ConditionShText { get; set; }
        }

        //Ins Warranties
        public class MtrInsWarrantiesMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int ParentTxnSysID { get; set; }
            public string Warranty { get; set; }

            //For Errors
            public bool IsValidTxn { get; set; }
            public List<TxnError> TxnErrors { get; set; }
            //For Active
            public bool IsActiveTxn { get; set; }

            public string WarrantyShText { get; set; }

        }
    }
}