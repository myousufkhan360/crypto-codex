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
    [RoutePrefix("CertType")]
    public class CertTypeController : ApiController
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
