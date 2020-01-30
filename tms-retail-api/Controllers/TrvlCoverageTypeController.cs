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
    [RoutePrefix("ddlTrvlCoverageType")]
    public class TrvlCoverageTypeController : ApiController
    {

        [HttpGet]
        [Route("GetTravelCoverageTypeList")]
        //for getting all Travel Coverage Type (DDL)
        public List<ddlTravelCoverageType> GetTravelCoverageTypeList()
        {
            TrvlPortalDal _TrvlPortalDal = new TrvlPortalDal();
            List<ddlTravelCoverageType> _ddlTravelCoverageTypeList = new List<ddlTravelCoverageType>();

            _ddlTravelCoverageTypeList = _TrvlPortalDal.GetTravelCoverageTypeList();
            return _ddlTravelCoverageTypeList;
        }


    }
}
