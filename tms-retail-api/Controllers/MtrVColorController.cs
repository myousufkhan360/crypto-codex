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
    [RoutePrefix("MtrVColor")]
    public class MtrVColorController : ApiController
    {

        [HttpGet]
        [Route("GetMtrVColor")]
        public List<VColorMdl> GetMtrVColor()
        {
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<VColorMdl> _VColorMdlList = new List<VColorMdl>();

            _VColorMdlList = _VehicleDetailDal.GetVehicleColor();
            return _VColorMdlList;
        }

    }
}
