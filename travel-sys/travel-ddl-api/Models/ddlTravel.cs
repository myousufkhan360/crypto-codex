using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ddlAPI.Models
{
   
    public class ddlTravelCategory
    {
        public int TravelCategoryCode { get; set; }
        public string TravelCategoryName { get; set; }
    }

    public class ddlTravelCovers
    {
        public int TravelCoverCode { get; set; }
        public string TravelCoverName { get; set; }
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

    public class TravelContribution
    {
        public int Contribution { get; set; }
    }

    public class TravelBooking
    {
        public int TravelCategoryCode { get; set; }
        public int TravelPlanCode { get; set; }
        public int TravelDestinationCode { get; set; }
        public int TravelCoverageTypeCode { get; set; }
        public int TravelTenureCode { get; set; }
        public int Contribution { get; set; }
    }

    public class TravelPolicy 

    {

	    public int? TxnSysID { get; set; }
	    public DateTime? TxnSysDate { get; set; }
	    public int CategoryCode { get; set; }
	    public int PlanCode { get; set; }
	    public string InsuredName { get; set; }
	    public DateTime	DOB { get; set; }
	    public string Email { get; set; }
	    public string MobileNumber { get; set; }
	    public int DestinationCode { get; set; }
	    public int TravelWithCode { get; set; }
	    public DateTime TravellingDate { get; set; }
	    public int TenureCode { get; set; }
        public int ContributionCode { get; set; }
	    public int PaymentModeCode { get; set; }

    }

    public class TravelFamilyDetails

    {
        public int TxnSysID { get; set; }
        public DateTime TxnSysDate { get; set; }
        public int PolicyTxnSysID { get; set; }
        public string FamilyName { get; set; }
        public DateTime FamilyDob { get; set; }
        public int FamilyRelationCode { get; set; }
        public string FamilyRelationName { get; set; }
    }
    
}


