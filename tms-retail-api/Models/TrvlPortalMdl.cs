using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TmsPlusRetailAPI.Models
{
    public class TrvlPortalMdl
    {
        //Travel Risk
        public class TrvlRisk
        {
            public int SysID { get; set; }
            public DateTime SysDate { get; set; }
            public int ParentSysID { get; set; }
            public int CategoryCode { get; set; }
            public int PlanCode { get; set; }
            public int CoveregeCode { get; set; }
            public int TenureCode { get; set; }
            public int DestinationCode { get; set; }
            public string BenificiaryName { get; set; }
            public int BenificiaryRelationCode { get; set; }
            public int ModeOfPaymentCode { get; set; }

            //Get Name Strings
            public int ModeOfPaymentName { get; set; }

            //Get Rate From ProductSetUp
            public int Rate { get; set; }

           

        }

        //Travel Family Details Risk
        public class TrvlFamilyDetailsRisk
        {
            public int SysID { get; set; }
            public DateTime SysDate { get; set; }
            public int RiskSysID { get; set; }
            public string FamilyName { get; set; }
            public DateTime DOB { get; set; }
            public int FamilyRelationCode { get; set; }

            //Get String By Code
            public string FamilyRelationName { get; set; }

            //Message If Family Not Selected
            public string Message { get; set; }

        }


        //For Drop Downs

        public class ddlTravelCategory
        {
            public int TravelCategoryCode { get; set; }
            public string TravelCategoryName { get; set; }
        }

        public class ddlTravelPlan
        {
            public int TravelPlanCode { get; set; }
            public string TravelPlanName { get; set; }
            public int TravelCategoryCode { get; set; }
        }

        public class ddlTravelCoverageType
        {
            public int TravelCoverageTypeCode { get; set; }
            public string TravelCoverageTypeName { get; set; }
        }

        public class ddlTravelTenure
        {
            public int TravelTenureCode { get; set; }
            public string TravelTenureText { get; set; }
        }

        public class TravelContribution
        {
            public int Contribution { get; set; }
        }

        public class ddlTravelDestination
        {
            public int TravelDestinationCode { get; set; }
            public string TravelDestinationName { get; set; }
        }

        public class ddlRelation
        {
            public int RelationCode { get; set; }
            public string RelationName { get; set; }
        }

        public class ddlPaymentMethod
        {
            public int PaymentMethodCode { get; set; }
            public string PaymentMethodName { get; set; }
        }


    }
}