using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TmsPlusRetailAPI.DataLayer;
using static TmsPlusRetailAPI.Models.TrvlPortalMdl;

namespace TmsPlusRetailAPI.Controllers
{
    [RoutePrefix("ddlTrvlContribution")]
    public class TrvlContributionController : ApiController
    {

        [HttpGet]
        [Route("GetContribution")]
        //for getting all Travel Tenures (DDL)
        public TravelContribution GetContribution(string _Json)
        {

            ddlTravelCategory _ddlTravelCategory = JsonConvert.DeserializeObject<ddlTravelCategory>(_Json);
            ddlTravelPlan _ddlTravelPlan = JsonConvert.DeserializeObject<ddlTravelPlan>(_Json);
            ddlTravelCoverageType _ddlTravelCoverageType = JsonConvert.DeserializeObject<ddlTravelCoverageType>(_Json);
            ddlTravelTenure _ddlTravelTenure = JsonConvert.DeserializeObject<ddlTravelTenure>(_Json);

            TrvlPortalDal _TrvlPortalDal = new TrvlPortalDal();
            TravelContribution _TravelContribution = new TravelContribution();

            _TravelContribution = _TrvlPortalDal.GetContribution(_ddlTravelCategory.TravelCategoryCode, _ddlTravelPlan.TravelPlanCode, _ddlTravelCoverageType.TravelCoverageTypeCode, _ddlTravelTenure.TravelTenureCode);
            return _TravelContribution;
        }

    }
}
