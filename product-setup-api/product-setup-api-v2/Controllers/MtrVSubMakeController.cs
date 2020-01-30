using Newtonsoft.Json;
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
    [RoutePrefix("MtrVSubMake")]
    public class MtrVSubMakeController : ApiController
    {

        [HttpGet]
        [Route("GetMtrVSubMake")]
        public List<MtrVSubMakeMdl> GetMtrVSubMake(string _Json)
        {
            MtrVMakeMdl _MtrVMakeMdl = JsonConvert.DeserializeObject<MtrVMakeMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<MtrVSubMakeMdl> _MtrVSubMakeMdlList = new List<MtrVSubMakeMdl>();

            _MtrVSubMakeMdlList = _VehicleDetailDal.GetVSubMake(_MtrVMakeMdl);
            return _MtrVSubMakeMdlList;
        }

    }
}
