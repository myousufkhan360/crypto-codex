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
    [RoutePrefix("MtrVMake")]
    public class MtrVMakeController : ApiController
    {

        [HttpGet]
        [Route("GetMtrVMake")]
        public List<MtrVMakeMdl> GetMtrVMake()
        {
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<MtrVMakeMdl> _MtrVMakeMdlList = new List<MtrVMakeMdl>();

            _MtrVMakeMdlList = _VehicleDetailDal.GetVMake();
            return _MtrVMakeMdlList;
        }


    }
}
