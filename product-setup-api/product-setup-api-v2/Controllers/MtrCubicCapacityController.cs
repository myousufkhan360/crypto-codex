using ProductSetupApi.DataLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ProductSetupApi.Models.MtrVehicleDetailMdl;

namespace ProductSetupApi.Controllers
{
    [RoutePrefix("MtrVCC")]
    public class MtrCubicCapacityController : ApiController
    {
        [HttpGet]
        [Route("GetMtrVCC")]
        public List<MtrVCubicCapacityMdl> GetMtrVCC()
        {
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<MtrVCubicCapacityMdl> _MtrVCubicCapacityMdlList = new List<MtrVCubicCapacityMdl>();

            _MtrVCubicCapacityMdlList = _VehicleDetailDal.GetCC();
            return _MtrVCubicCapacityMdlList;
        }
    }
}
