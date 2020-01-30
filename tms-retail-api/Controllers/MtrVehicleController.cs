using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TmsPlusRetailAPI.DataLayer;
using static TmsPlusRetailAPI.Models.MtrVehicleDetails;

namespace TmsPlusRetailAPI.Controllers
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

    }
}
