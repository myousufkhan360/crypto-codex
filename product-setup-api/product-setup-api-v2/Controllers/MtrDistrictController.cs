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
    [RoutePrefix("MtrArea")]
    public class MtrDistrictController : ApiController
    {
        [HttpGet]
        [Route("GetMtrArea")]
        public List<MtrDistrictMdl> AddProductConditionsSetUpMdl(string _Json)
        {
            MtrCityMdl _MtrCityMdl = JsonConvert.DeserializeObject<MtrCityMdl>(_Json);


            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            List<MtrDistrictMdl> MtrDistrictMdlList = _VehicleDetailDal.GetArea(_MtrCityMdl);
            return MtrDistrictMdlList;
        }
    }
}
