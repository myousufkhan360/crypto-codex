using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TmsPlusRetailAPI.Models
{
    public class HltPortalMdl
    {

        //Health Risk
        public class HltRisk
        {
            public int SysID { get; set; }
            public DateTime SysDate { get; set; }
            public int ParentSysID { get; set; }
            public int PlanCode { get; set; }
            public decimal HostBaseRate { get; set; }
            public decimal MatBaseRate { get; set; }
            public decimal OPDSumCovered { get; set; }
            public decimal OPDRate { get; set; }
            public decimal HosDisc { get; set; }
            public decimal MatDisc { get; set; }

            public Boolean IsMat { get; set; }
            public Boolean IsOPD { get; set; }


            //For Limit
            public int HosL1 { get; set; }
            public int HosL2 { get; set; }

            public int MatL1 { get; set; }
            public int MatL2 { get; set; }
        }

        //For Family Details
        public class HltFamilyDetailsRisk
        {
            public int SysID { get; set; }
            public DateTime SysDate { get; set; }
            public int RiskSysID { get; set; }
            public string FamilyName { get; set; }
            public DateTime DOB { get; set; }
            public int FamilyRelationCode { get; set; }

            //Get String by Code
            public string FamilyRelationName { get; set; }

        }

        //For Drop Downs

        //For Health Groups
        public class HltGroup
        {
            public int SysID { get; set; }
            public DateTime SysDate { get; set; }
            public int GroupCode { get; set; }
            public string GroupName { get; set; }

        }

        //For Health Base Rate
        public class HealthBaseRate
        {
            public int SysID { get; set; }
            public DateTime SysDate { get; set; }
            public int BASE_RATE_CODE { get; set; }
            public int LIMIT1 { get; set; }
            public int LIMIT2 { get; set; }
            public int BASE_RATE { get; set; }
            public string TYPE { get; set; }

        }

        //For Drop Downs


    }
}