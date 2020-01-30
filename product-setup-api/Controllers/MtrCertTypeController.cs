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
    [RoutePrefix("CertType")]
    public class MtrCertTypeController : ApiController
    {

        [HttpGet]
        [Route("GetCertType")]
        public List<MtrInsCertMdl> GetMtrCertType()
        {
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<MtrInsCertMdl> _MtrInsCertMdlList = new List<MtrInsCertMdl>();

            _MtrInsCertMdlList = _VehicleDetailDal.GetCert();
            return _MtrInsCertMdlList;
        }

    }
}
