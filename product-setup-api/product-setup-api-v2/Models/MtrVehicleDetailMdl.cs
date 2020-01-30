using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSetupApi.Models
{
    public class MtrVehicleDetailMdl
    {
        //Vehicle Details
        public class VehicleDetailMdl
        {
            //For Vehicle Details
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int SerialNo { get; set; }
            public int VehicleCode { get; set; }
            public int VehicleModel { get; set; }
            public decimal UpdatedValue { get; set; }
            public decimal PreviousValue {get; set;}
            public decimal? Mileage { get; set; }
            public decimal ParticipantValue { get; set; }
            public int ColorCode {get; set;}
            public string ParticipantName { get; set; }
            public string ParticipantAddress { get; set; }
            public string RegistrationNumber { get; set; }
            public string CityCode { get; set; }
            public string EngineNumber { get; set; }
            public int AreaCode { get; set; }
            public string ChasisNumber { get; set; }
            public string Remarks { get; set; }
            public  DateTime? PODate { get; set; }
            public string PONumber { get; set; }
            public string CNICNumber { get; set; }
            public string Tenure { get; set; }

            
            public DateTime? BirthDate { get; set; }
            public string Gender { get; set; }
            public string VehicleType { get; set; }
            public int VEODCode {get; set;}
            public string CertTypeCode { get; set; }
            public decimal Rate { get; set; }
            public decimal Contribution { get; set; }
            public int InsuranceTypeCode { get; set; }
            public int ParentTxnSysID { get; set; }
            public int OpolTxnSysID { get; set; }
            public string MobileNumber { get; set; }
            public string ResNumber { get; set; }
            public string OfficeNumber { get; set; }
            public string EmailAddress { get; set; }
            public decimal Deductible { get; set; }
            public DateTime ContractMatDate { get; set; }
            public decimal total { get; set; }
            public Boolean IsActive { get; set; }
            public Boolean IsCanceled { get; set; }
            public decimal CommisionRate { get; set; }

            //Vehicle Model
            public int ModelNumber { get; set; }

            //For Names
            public string VehicleName { get; set; }
            public string VehicleModelName { get; set; }
            public string ColorName { get; set; }
            public string CityName { get; set; }
            public string AreaName { get; set; }
            public string GenderName { get; set; }
            public string VehicleTypeName { get; set; }
            public string VEODName { get; set; }
            public string CertTypeName { get; set; }
            public string InsuranceTypeName { get; set; }

            //Get Expiry date from InsPolicy
            public DateTime ExpiryDate { get; set; }

            //For Errors
            public bool IsValidTxn { get; set; }
            public List<TxnError> TxnErrors { get; set; }
            //For Active
            public bool IsActiveTxn { get; set; }

            //For Ins Policy (Header) 
            public int InsPolicyID { get; set; }
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
            public string Remarks1 { get; set; }
            public string BrchCoverNoteNo { get; set; }
            public string LeaderPolicyNo { get; set; }
            public string LeaderEndNo { get; set; }
            public string IsFiler { get; set; }
            public string CalcType { get; set; }
            public string IsAuto { get; set; }
            public DateTime EffectiveDate { get; set; }
            public DateTime ExpiryDate1 { get; set; }
            public int SerialNo1 { get; set; }
            public string UWYear { get; set; }
            public string CreatedBy { get; set; } 
            public int OpolTxnSysID1 { get; set; }
            public int RenewSysID { get; set; }
            public int PolSysID { get; set; }
            public Boolean IsRenewal { get; set; }
            public decimal CommisionRate1 { get; set; }
            public string BrchCode { get; set; }



            //For Ins Contribution
            public int ConTxnID { get; set; }
            public decimal SumCovered { get; set; }
            public decimal Rate2 { get; set; }
            public decimal NetContribution { get; set; }
            public decimal GrossContribution { get; set; }
            public decimal FIF { get; set; }
            public decimal FED { get; set; }
            public decimal Stamp { get; set; }
            public decimal BasicContribution { get; set; }
            public decimal PEV { get; set; }
            public decimal BeforePEV { get; set; }
            public decimal TerrorContribution { get; set; }
            public int RiskTxnID { get; set; }
            public decimal PerDayContribution { get; set; }
            public int Tenure2 { get; set; }
            public int BranchCode { get; set; }
            public int OpolTxnSysID2 { get; set; }

            
            //Getting Rating Factor
            public string RatingFactor { get; set; }

            public decimal Difference { get; set; }

            //For Posting
            public string PostedBy { get; set; }
            public DateTime PostDate { get; set; }
            public bool IsPosted { get; set; }

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

            public string RatingFactorShText { get; set; }

            //For Expiry
            public bool IsExpired { get; set; }

            public string PolicyString { get; set; }

        }

        //VEOD 
        public class MtrVEODMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int VEODCode { get; set; }
            public string VEODName { get; set; }

        }

        //Vehicle Type
        public class MtrVehicleTypeMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public string VehicleTypeCode { get; set; }
            public string VehicleTypeName { get; set; }

        }

        //Colors
        public class VColorMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int COLOR_CODE { get; set; }
            public string COLOR_NAME { get; set; }
            public string COLOR_SHORT_NAME { get; set; }

            //For Errors
            public bool IsValidTxn { get; set; }
            public List<TxnError> TxnErrors { get; set; }
            //For Active
            public bool IsActiveTxn { get; set; }

        }

        //Vehicles
        public class MtrVehicleMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int VEHICLE_CODE { get; set; }
            public int MAKE_CODE { get; set; }
            public string VEHICLE_NAME { get; set; }
            public string VEHICLE_SHORT_NAME { get; set; }
            public int MARKET_VALUE { get; set; }
            public DateTime VALUE_DATE { get; set; }
            public int SEATING_CAPACITY { get; set; }
            public int BODY_TYPE_CODE { get; set; }
            public int CUBIC_HORSE_CODE { get; set; }
            public int VEHICLE_CLASSIFICATION_CODE { get; set; }
            public int SUB_MAKE_CODE { get; set; }


           

            //To get Concatinated String
            public string VEHICLE_TEXT { get; set; }

            //For Errors
            public bool IsValidTxn { get; set; }
            public List<TxnError> TxnErrors { get; set; }
            //For Active
            public bool IsActiveTxn { get; set; }


        }

        //Gender
        public class GendersMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public string GenderCode { get; set; }
            public string GenderName { get; set; }

        }

        //City
        public class MtrCityMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int CITY_CODE { get; set; }
            public string CITY_NAME { get; set; }
            public int STATE_CODE { get; set; }
            public int CRESTA_CODE { get; set; }
            public string CRESTA_NAME { get; set; }
            public string ENT_BY { get; set; }
            public DateTime ENT_DATE { get; set; }
            public string Active { get; set; }

            //For Errors
            public bool IsValidTxn { get; set; }
            public List<TxnError> TxnErrors { get; set; }
            //For Active
            public bool IsActiveTxn { get; set; }

        }

        //District
        public class MtrDistrictMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int DISTRICT_CODE { get; set; }
            public string DISTRICT_NAME { get; set; }
            public int CITY_CODE { get; set; }
            public string ENT_BY { get; set; }
            public DateTime ENT_DATE { get; set; }

        }

        //Ins Certificate
        public class MtrInsCertMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int CERTIFICATE_CODE { get; set; }
            public string DRIVER { get; set; }
            public string USAGE_LIMITATION { get; set; }
            public string CERTIFICATE_TYPE { get; set; }

            //For MtrCertificateInsurance
            public string CertInsureCode { get; set; }
            public string CertInsureName { get; set; }
            public string PolicyTypeCode { get; set; }


        }

        //Contribution
        public class MtrVContributionMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public decimal SumCovered { get; set; }
            public decimal Rate { get; set; }
            public decimal NetContribution { get; set; }
            public decimal GrossContribution { get; set; }
            public decimal FIF { get; set; }
            public decimal FED { get; set; }
            public decimal Stamp { get; set; }
            public decimal BasicContribution { get; set; }
            public decimal PEV { get; set; }
            public decimal BeforePEV { get; set; }
            public decimal TerrorContribution { get; set; }
            public int RiskTxnID { get; set; }
            public decimal PerDayContribution { get; set; }
            public int Tenure { get; set; }
            public int BranchCode { get; set; }
            public int OpolTxnSysID { get; set; }

            public decimal Difference { get; set; }

            //For Errors
            public bool IsValidTxn { get; set; }
            public List<TxnError> TxnErrors { get; set; }

            //To Get Updated Contribution
            public int TxnSysIDU { get; set; }
            public DateTime TxnSysDateU { get; set; }
            public int UserCodeU { get; set; }
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
            public int RiskTxnIDU { get; set; }
            public decimal PerDayContributionU { get; set; }
            public int TenureU { get; set; }
            public int BranchCodeU { get; set; }
            public int OpolTxnSysIDU { get; set; }

        }

        //Calcualte
        public class Calc
        {
            public decimal rate { get; set; }
            public decimal value { get; set; }
            public decimal total { get; set; }
        }

        //Co Insurance
        public class InsCoInsurance
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int SumCovered { get; set; }
            public decimal Rate { get; set; }
            public decimal NetContribution { get; set; }
            public decimal GrossContribution { get; set; }
            public decimal FIF { get; set; }
            public decimal FED { get; set; }
            public decimal Stamp { get; set; }
            public decimal BasicContribution { get; set; }
            public decimal PEV { get; set; }
            public decimal BeforePEV { get; set; }
            public decimal TerrorContribution { get; set; }
            public int RiskTxnID { get; set; }
            public int CoInsuranceCode { get; set; }
            public decimal CoInsuranceShare { get; set; }
            public decimal PerDayContribution { get; set; }
            public int OpolTxnSysID { get; set; }
            public int Tenure { get; set; }

            //To get string
            public string PartTakerName { get; set; }

            //For Errors
            public bool IsValidTxn { get; set; }
            public List<TxnError> TxnErrors { get; set; }
            //For Active
            public bool IsActiveTxn { get; set; }

        }

        //Prattaker
        public class InsPartTakerMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int PARTTAKER_CODE { get; set; }
            public string CATEGORY_PARTTAKER_CODE { get; set; }
            public string ABBREVIATION { get; set; }
            public string ADDRESS { get; set; }
            public string CONTACT_PERSON { get; set; }
            public int PHONE_NO { get; set; }
            public DateTime START_DATE { get; set; }
            public int FAX_NO { get; set; }
            public string REG_NO { get; set; }
            public string NTN_NO { get; set; }
            public string EMAIL_ADDRESS { get; set; }
            public string ACTIVE { get; set; }
            public string PARTTAKER_NAME { get; set; }
            public string NIC { get; set; }
            public string TAX_DED { get; set; }
            public int DISTRICT_CODE { get; set; }
            public string PARTTAKER_TYPE { get; set; }
            public string ENT_BY { get; set; }
            public DateTime ENT_DATE { get; set; }

        }

        //Co Insurance Element
        public class CoInsElementMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int ElemetID { get; set; }
            public string ElementName { get; set; }
            public int ElementCode { get; set; }

        }

        //Extras

        public class MtrVMakeMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int MAKE_CODE { get; set; }
            public string ENT_BY { get; set; }
            public string MAKE_NAME { get; set; }
            public string MAKE_SHORT_NAME { get; set; }
            public string MAKE_TYPE { get; set; }

        }

        public class MtrVSubMakeMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int MAKE_CODE { get; set; }
            public int SUB_MAKE_CODE { get; set; }
            public string SUB_MAKE_NAME { get; set; }
            public string SUB_MAKE_SHORT_NAME { get; set; }
            public string REMARKS { get; set; }
            public string ENT_BY { get; set; }
            public DateTime ENT_DATE { get; set; }

        }

        public class MtrVClassMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int VCLASS_CODE { get; set; }
            public string VCLASS_NAME { get; set; }
            public string VCLASS_SHORT_NAME { get; set; }
            public int RATE { get; set; }

        }

        public class MtrVCubicCapacityMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int CUBIC_HORSE_CODE { get; set; }
            public string CUBIC_HORSE_TITLE { get; set; }
            public int BASIC_PREMIUM { get; set; }
            public string TYPE { get; set; }
            public string CUBIC_HORSE_SHORT_NAME { get; set; }
            public string ENT_BY { get; set; }
            public DateTime ENT_DATE { get; set; }


            //For Getting Strings
            public string CUBIC_STRING { get; set; }

        }

        public class MtrVBodyTypeMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int BODY_TYPE_CODE { get; set; }
            public string BODY_NAME { get; set; }
            public string SHORT_NAME { get; set; }
            public string ENT_BY { get; set; }

           
        }

    }
}