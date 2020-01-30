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

        [HttpGet]
        [Route("AddMtrVColor")]
        public VColorMdl AddMtrVColor(string _Json)
        {
            VColorMdl _VColorMdl = JsonConvert.DeserializeObject<VColorMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            VColorMdl VColorMdlList = _VehicleDetailDal.AddVehicleColor(_VColorMdl);
            return VColorMdlList;
        }

        [HttpGet]
        [Route("UpdateMtrVColor")]
        public VColorMdl UpdateMtrVColor(string _Json)

        {
            VColorMdl _VColorMdl = JsonConvert.DeserializeObject<VColorMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            VColorMdl VColorMdl = _VehicleDetailDal.UpdateMasterProductSetup(_VColorMdl);
            return VColorMdl;
        }

    }
}
