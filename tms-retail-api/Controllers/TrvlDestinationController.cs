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
    [RoutePrefix("ddlTrvlDestination")]
    public class TrvlDestinationController : ApiController
    {
        [HttpGet]
        [Route("getTravelDestinationList")]
        //for getting Travel Destination
        public List<ddlTravelDestination> getTravelDestinationList(string _Json)
        {
            ddlTravelCategory _ddlTravelCategory = JsonConvert.DeserializeObject<ddlTravelCategory>(_Json);
            TrvlPortalDal _TrvlPortalDal = new TrvlPortalDal();
            List<ddlTravelDestination> _ddlTravelDestinationList = new List<ddlTravelDestination>();

            _ddlTravelDestinationList = _TrvlPortalDal.getTravelDestinationList(_ddlTravelCategory.TravelCategoryCode);
            return _ddlTravelDestinationList;
        }


    }
}
