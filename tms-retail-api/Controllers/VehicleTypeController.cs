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
    [RoutePrefix("MtrVehicleType")]
    public class VehicleTypeController : ApiController
    {

        [HttpGet]
        [Route("GetMtrVehicleType")]
        public List<MtrVehicleTypeMdl> GetMtrVehicleType()
        {
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<MtrVehicleTypeMdl> _MtrVehicleTypeMdlList = new List<MtrVehicleTypeMdl>();

            _MtrVehicleTypeMdlList = _VehicleDetailDal.GetVehicleType();
            return _MtrVehicleTypeMdlList;

        }


    }
}
