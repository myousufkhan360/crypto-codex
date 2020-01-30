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
    [RoutePrefix("MtrVClass")]

    public class MtrVClassController : ApiController
    {
        [HttpGet]
        [Route("GetMtrVClass")]
        public List<MtrVClassMdl> GetMtrVClass()
        {
            
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<MtrVClassMdl> _MtrVClassMdlList = new List<MtrVClassMdl>();

            _MtrVClassMdlList = _VehicleDetailDal.GetVClass();
            return _MtrVClassMdlList;
        }

    }
}
