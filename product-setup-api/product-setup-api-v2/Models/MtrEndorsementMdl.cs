using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSetupApi.Models
{

    public class MtrEndorsementMdl
    {

        public class InsEndorsementMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public string EndMonth { get; set; }
            public string EndString { get; set; }
            public string EndYear { get; set; }
            public string EndNo { get; set; }
            public string DocType { get; set; }
            public string GenerateAgainst { get; set; }
            public string ProductCode { get; set; }
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
            public string PostedBy { get; set; }
            public Boolean IsPosted { get; set; }
            public DateTime PostDate { get; set; }
            public int OpolTxnSysID { get; set; }
            public int RenewSysID { get; set; }
            public int PolSysID { get; set; }
            public Boolean IsRenewal { get; set; }

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

        }

        //Search By
        public class MtrSeByCertMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int SeByCertCode { get; set; }
            public string SeByCertName { get; set; }

        }

        //Endorsement Type
        public class EndtTypeMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int EndtTypeCode { get; set; }
            public string EndtTypeName { get; set; }


        }

        //Endorsement Reason
        public class EndtReasonMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int EndtReasonCode { get; set; }
            public string EndtReasonName { get; set; }
            public int EndtTypeCode { get; set; }

        }

        //To Calculate
        public class Calculate
        {

            public List<PreviousContribution> PreviousContribution { get; set; }

            //Previous
            public string PreviousMsg { get; set; }
            public decimal SumCoveredP { get; set; }
            public decimal RateP { get; set; }
            public decimal NetContributionP { get; set; }
            public decimal GrossContributionP { get; set; }
            public decimal FIFP { get; set; }
            public decimal FEDP { get; set; }
            public decimal StampP { get; set; }
            public decimal BasicContributionP { get; set; }
            public decimal PEVP { get; set; }
            public decimal BeforePEVP { get; set; }
            public decimal TerrorContributionP { get; set; }
            public decimal PerDayContributionP { get; set; }
            public int TenureP { get; set; }


            //Updated
            public string UpdatedMsg { get; set; }
            public decimal SumCoveredU { get; set; }
            public decimal RateU { get; set; }
            public decimal NetContributionU { get; set; }
            public decimal GrossContributionU { get; set; }
            public decimal FIFU { get; set; }
            public decimal FEDU { get; set; }
            public decimal StampU { get; set; }
            public decimal BasicContributionU { get; set; }
            public decimal PEVU { get; set; }
            public decimal BeforePEVU { get; set; }
            public decimal TerrorContributionU { get; set; }       
            public decimal PerDayContributionU { get; set; }
            public int TenureU { get; set; }
            public decimal differenceU { get; set; }

            //Variance
            public string VarianceMsg { get; set; }
            public decimal SumCoveredV { get; set; }
            public decimal RateV { get; set; }
            public decimal NetContributionV { get; set; }
            public decimal GrossContributionV { get; set; }
            public decimal FIFV { get; set; }
            public decimal FEDV { get; set; }
            public decimal StampV { get; set; }
            public decimal BasicContributionV { get; set; }
            public decimal PEVV { get; set; }
            public decimal BeforePEVV { get; set; }
            public decimal TerrorContributionV { get; set; }
            public decimal PerDayContributionV { get; set; }
            public int TenureV { get; set; }
            public decimal differenceV { get; set; }

        }

        //For Geting Previous Contribution
        public class PreviousContribution
        {
            //Previous
            public decimal SumCoveredP { get; set; }
            public decimal RateP { get; set; }
            public decimal NetContributionP { get; set; }
            public decimal GrossContributionP { get; set; }
            public decimal FIFP { get; set; }
            public decimal FEDP { get; set; }
            public decimal StampP { get; set; }
            public decimal BasicContributionP { get; set; }
            public decimal PEVP { get; set; }
            public decimal BeforePEVP { get; set; }
            public decimal TerrorContributionP { get; set; }
            public decimal PerDayContributionP { get; set; }
            public int TenureP { get; set; }
        }
    }
}