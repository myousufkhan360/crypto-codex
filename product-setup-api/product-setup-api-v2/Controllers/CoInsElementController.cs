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
    [RoutePrefix("CoInsElement")]
    public class CoInsElementController : ApiController
    {

        [HttpGet]
        [Route("GetCoInsElement")]
        public List<CoInsElementMdl> GetCoInsElement()
        {
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<CoInsElementMdl> _CoInsElementMdlList = new List<CoInsElementMdl>();

            _CoInsElementMdlList = _VehicleDetailDal.GetCoInsElement();
            return _CoInsElementMdlList;
        }

    }
}
