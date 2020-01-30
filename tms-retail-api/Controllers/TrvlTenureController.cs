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
    [RoutePrefix("ddlTrvlTenure")]
    public class TrvlTenureController : ApiController
    {

        [HttpGet]
        [Route("getTravelTenureList")]
        //for getting all Travel Tenures (DDL)
        public List<ddlTravelTenure> getTravelTenuresList()
            //(string _Json)
        {

            //ddlTravelCategory _ddlTravelCategory = JsonConvert.DeserializeObject<ddlTravelCategory>(_Json);
            //ddlTravelPlan _ddlTravelPlan = JsonConvert.DeserializeObject<ddlTravelPlan>(_Json);
            //ddlTravelCoverageType _ddlTravelCoverageType = JsonConvert.DeserializeObject<ddlTravelCoverageType>(_Json);

            TrvlPortalDal _TrvlPortalDal = new TrvlPortalDal();
            List<ddlTravelTenure> _ddlTravelTenureList = new List<ddlTravelTenure>();

            _ddlTravelTenureList = _TrvlPortalDal.getTravelTenureList();
                //(_ddlTravelCategory.TravelCategoryCode, _ddlTravelPlan.TravelPlanCode, _ddlTravelCoverageType.TravelCoverageTypeCode);
            return _ddlTravelTenureList;
        }

    }
}
