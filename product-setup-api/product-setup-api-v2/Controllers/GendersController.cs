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
    [RoutePrefix("Genders")]
    public class GendersController : ApiController
    {

        [HttpGet]
        [Route("GetGenders")]
        public List<GendersMdl> GetGenders()
        {
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<GendersMdl> _GendersMdlList = new List<GendersMdl>();

            _GendersMdlList = _VehicleDetailDal.GetGenders();
            return _GendersMdlList;
        }


    }
}
