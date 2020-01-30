using ProductSetupApi.DataLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ProductSetupApi.Models.MtrEndorsementMdl;

namespace ProductSetupApi.Controllers
{
    [RoutePrefix("MtrSearchBy")]
    public class MtrSeByCertController : ApiController
    {
        [HttpGet]
        [Route("GetMtrSearchBy")]
        public List<MtrSeByCertMdl> GetVehicleDetailMdl()
        {
            EndorsementDal _EndorsementDal = new EndorsementDal();
            List<MtrSeByCertMdl> _MtrSeByCertMdlList = new List<MtrSeByCertMdl>();

            _MtrSeByCertMdlList = _EndorsementDal.GetMtrSeByCert();
            return _MtrSeByCertMdlList;
        }
    }
}
