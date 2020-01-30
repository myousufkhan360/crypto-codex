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
    [RoutePrefix("MtrVBodyType")]
    public class MtrVBodyTypeController : ApiController
    {

        [HttpGet]
        [Route("GetMtrVBodyType")]
        public List<MtrVBodyTypeMdl> GetMtrVBodyType()
        {
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<MtrVBodyTypeMdl> _MtrVBodyTypeMdlList = new List<MtrVBodyTypeMdl>();

            _MtrVBodyTypeMdlList = _VehicleDetailDal.GetVBodyType();
            return _MtrVBodyTypeMdlList;
        }


    }
}
