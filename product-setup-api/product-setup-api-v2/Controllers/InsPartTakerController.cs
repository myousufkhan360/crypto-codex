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
    [RoutePrefix("InsParttaker")]
    public class InsPartTakerController : ApiController
    {

        [HttpGet]
        [Route("GetInsParttaker")]
        public List<InsPartTakerMdl> GetInsPartTakerMdl()
        {
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<InsPartTakerMdl> _InsPartTakerMdlList = new List<InsPartTakerMdl>();

            _InsPartTakerMdlList = _VehicleDetailDal.GetPartTaker();
            return _InsPartTakerMdlList;
        }



    }
}
