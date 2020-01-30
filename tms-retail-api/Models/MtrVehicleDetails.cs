using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using TmsPlusRetailAPI.DataLayer;
using static TmsPlusRetailAPI.Models.GlobalModels;

namespace TmsPlusRetailAPI.Models
{
    public class MtrVehicleDetails
    {

        //For Mtr Risk
        public class MtrRisk
        {
            public int SysID { get; set; }
            public DateTime SysDate { get; set; }
            public int ParentSysID { get; set; }
            public decimal SumCovered { get; set; }
            public decimal Rate { get; set; }
            public string VehicleCode { get; set; }
            public string Model { get; set; }
            public string EngineNo { get; set; }
            public string ChasisNo { get; set; }
            public string RegNo { get; set; }
            public int ColorCode { get; set; }
            public decimal CommisionRate { get; set; }

        }


        //For Drop Downs

        public class MtrVEODMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int VEODCode { get; set; }
            public string VEODName { get; set; }

        }

        public class MtrVehicleTypeMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public string VehicleTypeCode { get; set; }
            public string VehicleTypeName { get; set; }

        }

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

        public class MtrInsCertMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public int CERTIFICATE_CODE { get; set; }
            public string DRIVER { get; set; }
            public string USAGE_LIMITATION { get; set; }
            public string CERTIFICATE_TYPE { get; set; }

        }

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


    }
}