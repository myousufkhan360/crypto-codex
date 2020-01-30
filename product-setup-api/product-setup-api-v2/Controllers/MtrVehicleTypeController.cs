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
    [RoutePrefix("MtrVehicleType")]
    public class MtrVehicleTypeController : ApiController
    {

        [HttpGet]
        [Route("GetMtrVehicleType")]
        public List<MtrVehicleTypeMdl> GetMtrVehicleType()
        {
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<MtrVehicleTypeMdl> _MtrVehicleTypeMdlList = new List<MtrVehicleTypeMdl>();

            _MtrVehicleTypeMdlList = _VehicleDetailDal.GetVehicleType();
            return _MtrVehicleTypeMdlList;
        }

    }
}
