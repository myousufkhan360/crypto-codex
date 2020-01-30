using ProductSetupApi.DataLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ProductSetupApi.Models.OpenPolicyMdl;

namespace ProductSetupApi.Controllers
{
    [RoutePrefix("IsAuto")]
    public class MtrIsAutoController : ApiController
    {
        [HttpGet]
        [Route("GetIsAuto")]
        public List<MtrIsAutoMdl> GetIsAuto()
        {
            OpenPolicyDal _OpenPolicyDal = new OpenPolicyDal();
            List<MtrIsAutoMdl> _MtrIsAutoMdlList = new List<MtrIsAutoMdl>();

            _MtrIsAutoMdlList = _OpenPolicyDal.GetIsAuto();
            return _MtrIsAutoMdlList;
        }
    }
}
