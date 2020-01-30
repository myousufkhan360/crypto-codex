using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ddlAPI.Models
{
    public class TravelCoversSetup
    {
        public int TravelPlanCode { get; set; }
        public string TravelPlanName { get; set; }
        public int TravelCoverCode { get; set; }
        public string TravelCoverName { get; set; }
        public string TravelCoverLimitText { get; set; }
    }

    public class TravelContributionSetup
    {
        public int TravelContributionStpCode { get; set; }
        public int TravelCategoryCode { get; set; }
        public string TravelCategoryName { get; set; }
        public int TravelPlanCode { get; set; }
        public string TravelPlanName { get; set; }
        public int TravelTanureCode { get; set; }
        public string TravelTanureText { get; set; }
        public int TravelCoverageTypeCode { get; set; }
        public string TravelCoverageTypeName { get; set; }
        public decimal TravelContribution { get; set; }
    }
}