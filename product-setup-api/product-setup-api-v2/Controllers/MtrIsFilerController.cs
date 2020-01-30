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
    [RoutePrefix("IsFiler")]
    public class MtrIsFilerController : ApiController
    {
        [HttpGet]
        [Route("GetIsFiler")]
        public List<MtrIsFilerMdl> GetIsFiler()
        {
            OpenPolicyDal _OpenPolicyDal = new OpenPolicyDal();
            List<MtrIsFilerMdl> _MtrIsFilerMdlList = new List<MtrIsFilerMdl>();

            _MtrIsFilerMdlList = _OpenPolicyDal.GetIsFiler();
            return _MtrIsFilerMdlList;
        }
    }
}
