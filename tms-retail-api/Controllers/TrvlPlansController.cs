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
    [RoutePrefix("ddlTrvlPlans")]
    public class TrvlPlansController : ApiController
    {

        [HttpGet]
        [Route("getTravelPlansByCategory")]
        public List<ddlTravelPlan> getTravelPlansByCategory(string _Json)
        {
            ddlTravelCategory _ddlTravelCategory = JsonConvert.DeserializeObject<ddlTravelCategory>(_Json);
            TrvlPortalDal _TrvlPortalDal = new TrvlPortalDal();
            List<ddlTravelPlan> _ddlTravelPlanList = new List<ddlTravelPlan>();

            _ddlTravelPlanList = _TrvlPortalDal.getTravelPlansByCategory(_ddlTravelCategory.TravelCategoryCode);
            return _ddlTravelPlanList;
        }


    }
}
