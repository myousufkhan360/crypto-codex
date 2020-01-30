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

        [HttpGet]
        [Route("AddMtrCity")]
        public MtrCityMdl AddMtrVColor(string _Json)
        {
            MtrCityMdl _MtrCityMdl = JsonConvert.DeserializeObject<MtrCityMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            MtrCityMdl MtrCityMdlList = _VehicleDetailDal.AddCity(_MtrCityMdl);
            return MtrCityMdlList;
        }

        [HttpGet]
        [Route("UpdateMtrVColor")]
        public MtrCityMdl UpdateMtrVColor(string _Json)

        {
            MtrCityMdl _MtrCityMdl = JsonConvert.DeserializeObject<MtrCityMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            MtrCityMdl MtrCityMdl = _VehicleDetailDal.UpdateCity(_MtrCityMdl);
            return MtrCityMdl;
        }
    }
}
