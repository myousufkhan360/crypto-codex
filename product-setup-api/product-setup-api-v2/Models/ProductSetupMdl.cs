using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSetupApi.Models
{
    //Client
    public class ProductClientMdl
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string NtnNo { get; set; }
        public string NicNo { get; set; }
        public string Address { get; set; }


    }

    //Agent
    public class ProductAgentMdl
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string NtnNo { get; set; }
        public string NicNo { get; set; }

    }

    //Conditions
    public class ProductConditionsMdl
    {

        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public string ConditionCode { get; set; }
        public string ConditionType { get; set; }
        public string ConditionShText { get; set; }
        public string ConditionText { get; set; }
        public string PolicyTypeCode { get; set; }
    }

    //Policy Class
    public class ProductPolicyClassMdl
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public string PolicyClassCode { get; set; }
        public string PolicyClassName { get; set; }

    }

    //Policy Type
    public class ProductPolicyTypeMdl
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public string PolicyTypeCode { get; set; }
        public string PolicyClassCode { get; set; }
        public string PolicyClassName { get; set; }
        public string PolicyTypeName { get; set; }
        public string CertInsureCode { get; set; }
        public string CertInsureName { get; set; }

    }

    //Rating Factor
    public class RatingFactorMdl
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public string RatingFactorCode { get; set; }
        public string RatingFactorName { get; set; }

    }

    //Warranties
    public class WarrantiesMdl
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public string WarrantyCode { get; set; }
        public string WarrantyShText { get; set; }
        public string WarrantyText { get; set; }
        public string PolicyTypeCode { get; set; }

    }

    //Yes No
    public class YesNoMdl
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public string YesNoText { get; set; }
        public string TrueFalse { get; set; }

    }

    //Ins Accessories
    public class InsAccessoriesMdl
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public int ACCESSORY_CODE { get; set; }
        public string ACCESSORY_NAME { get; set; }
        public string ACCESSORY_SHORT_NAME { get; set; }
        public int RATE { get; set; }
        public string REMARKS { get; set; }
        public int ACCESSORY_CATEGORY_CODE { get; set; }
        public int MAKE_CODE { get; set; }
        public int MODEL { get; set; }
        public string ENT_BY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public int AMOUNT { get; set; }
        public int TAX_AMOUNT { get; set; }
        public int PARTTAKER_CODE { get; set; }
    }

    //Peril Rider
    public class PerilRidersMdl
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public int RECORD_ID { get; set; }
        public string RIDER_NAME { get; set; }
        public int BASIC_PREMIUM { get; set; }
        public int ADDITIONAL_PREMIUM { get; set; }
        public int BENEFIT_COVERED { get; set; }
        public int PARENT_RIDER_CODE { get; set; }

    }

    //Product Rating Factor
    public class ProductRatingFactorSetUpMdl
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public int PrdStpTxnSysId { get; set; }
        public string RatingFactor { get; set; }
        public string IsEditable { get; set; }
        public decimal Rate { get; set; }
        public bool IsValidTxn { get; set; }
        public List<TxnError> TxnErrors { get; set; }
        public string RatingFactorShText { get; set; }

        public int ProductCode { get; set; }

    }

    //Product Warranties
    public class ProductWarrantiesSetupMdl
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public int PrdStpTxnSysId { get; set; }
        public string Warranty { get; set; }
        public bool IsValidTxn { get; set; }
        public List<TxnError> TxnErrors { get; set; }
        public string WarrantyShText { get; set; }
    }

    //Product Conditions
    public class ProductConditionsSetupMdl
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public int PrdStpTxnSysId { get; set; }
        public string Condition { get; set; }
        public string ConditionShText { get; set; }
        public bool IsValidTxn { get; set; }
        public List<TxnError> TxnErrors { get; set; }

    }

    //Product Tracker
   public class ProductTrackerSetupMdl
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public int TrackerCode { get; set; }
        public string TrackerName { get; set; }
        public int TrackerRate { get; set; }
        public int PrdStpTxnSysId { get; set; }

        public int ProductCode { get; set; }

        //For Errors
        public bool IsValidTxn { get; set; }
        public List<TxnError> TxnErrors { get; set; }

    }

    //Product Rider
    public class ProductRiderSetupMdl
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public int RiderCode { get; set; }
        public string RiderName { get; set; }
        public int RiderRate { get; set; }
        public int PrdStpTxnSysId { get; set; }

        public int ProductCode { get; set; }

        //For Errors
        public bool IsValidTxn { get; set; }
        public List<TxnError> TxnErrors { get; set; }

    }

    //Master Product SetUp
    public class MasterProductSetupMdl
    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int UserCode { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string IsClientBased { get; set; }
        public string Client { get; set; }
        public string Agent { get; set; }
        public decimal AgentCommPct { get; set; }
        public string PolicyTypeCode { get; set; }

        //For Certificate Type
        public string CertInsureCode { get; set; }


        //------For getting Values for Policy that is to get all values by product code----//

        //For Ratting Factor
        public string RatingFactor { get; set; }
        public string IsEditable { get; set; }
        public decimal Rate { get; set; }
        public string RatingFactorShText { get; set; }

        //For Condition
        public string Condition { get; set; }
        public string ConditionShText { get; set; }

        //For Warranty
        public string Warranty { get; set; }
        public string WarrantyShText { get; set; }

        //For Tracker
        public int TrackerCode { get; set; }
        public string TrackerName { get; set; }
        public int TrackerRate { get; set; }

        //------For getting Values for Policy that is to get all values by product code----//

        //For Geting Strings from Code
        public string PolicyTypeName { get; set; }
        public string ClientName { get; set; }
        public string AgentName { get; set; }
        public string CertInsureName { get; set; }

        //For Errors
        public bool IsValidTxn { get; set; }
        public List<TxnError> TxnErrors { get; set; }
        //For Active
        public bool IsActiveTxn { get; set; }
    }


}