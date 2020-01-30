using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TmsPlusRetailAPI.DataLayer;
using static TmsPlusRetailAPI.Models.MtrVehicleDetails;

namespace TmsPlusRetailAPI.Controllers
{
    [RoutePrefix("MtrCity")]
    public class MtrCityController : ApiController
    {

        [HttpGet]
        [Route("GetMtrCity")]
        public List<MtrCityMdl> GetMtrCity()
        {
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<MtrCityMdl> _MtrCityMdlList = new List<MtrCityMdl>();

            _MtrCityMdlList = _VehicleDetailDal.GetCity();
            return _MtrCityMdlList;
        }


    }
}
