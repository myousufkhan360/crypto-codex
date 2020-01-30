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
    [RoutePrefix("MtrVEOD")]
    public class MtrVEODController : ApiController
    {

        [HttpGet]
        [Route("GetMtrVEOD")]
        public List<MtrVEODMdl> GetMtrVEOD()
        {
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<MtrVEODMdl> _MtrVEODMdlList = new List<MtrVEODMdl>();

            _MtrVEODMdlList = _VehicleDetailDal.GetVEOD();
            return _MtrVEODMdlList;
        }

    }
}
