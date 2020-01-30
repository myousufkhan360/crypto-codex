using ddlAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ddlAPI.DataLayers;
using ddlAPI.Models;

namespace ddlAPI.Controllers
{
    [RoutePrefix("gridTravel")]
    public class gridTravelController : ApiController
    {
        [HttpGet]
        [Route("getTravelCoversSetupByPlan")]
        public List<TravelCoversSetup> getTravelCoversSetupByPlan(int _TravelPlanCode)
        {
            gridTravelDataLayer _gridTravelDataLayer = new gridTravelDataLayer();
            List<TravelCoversSetup> _TravelCoversSetup = new List<TravelCoversSetup>();

            _TravelCoversSetup = _gridTravelDataLayer.getTravelCoversSetupByPlan(_TravelPlanCode);
            return _TravelCoversSetup;
        }

        [HttpGet]
        [Route("getTravelContributionSetup")]
        public List<TravelContributionSetup> getTravelContributionSetup(int _TravelCategoryCode, int _TravelPlanCode)
        {
            gridTravelDataLayer _gridTravelDataLayer = new gridTravelDataLayer();
            List<TravelContributionSetup> _TravelContributionSetup = new List<TravelContributionSetup>();

            _TravelContributionSetup = _gridTravelDataLayer.getTravelContributionSetup(_TravelCategoryCode, _TravelPlanCode);
            return _TravelContributionSetup;
        }


    }
}
