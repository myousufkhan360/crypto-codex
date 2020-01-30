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
    [RoutePrefix("MtrVehicle")]
    public class MtrVehicleController : ApiController
    {

        [HttpGet]
        [Route("GetMtrVehicle")]
        public List<MtrVehicleMdl> GetMtrVehicle()
        {
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<MtrVehicleMdl> _MtrVehicleMdlList = new List<MtrVehicleMdl>();

            _MtrVehicleMdlList = _VehicleDetailDal.GetMtrVehicle();
            return _MtrVehicleMdlList;
        }

        [HttpGet]
        [Route("AddMtrVehicle")]
        public MtrVehicleMdl AddMtrVehicle(string _Json)
        {
            MtrVehicleMdl _MtrVehicleMdl = JsonConvert.DeserializeObject<MtrVehicleMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            MtrVehicleMdl MtrVehicleMdlList = _VehicleDetailDal.AddVehicle(_MtrVehicleMdl);
            return MtrVehicleMdlList;
        }


    }
}
