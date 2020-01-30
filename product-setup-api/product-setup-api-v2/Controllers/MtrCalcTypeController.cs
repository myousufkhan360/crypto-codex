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
    [RoutePrefix("CalcType")]
    public class MtrCalcTypeController : ApiController
    {

        [HttpGet]
        [Route("GetCalcType")]
        public List<MtrCalcTypeMdl> GetCalcType()
        {
            OpenPolicyDal _OpenPolicyDal = new OpenPolicyDal();
            List<MtrCalcTypeMdl> _MtrCalcTypeMdlList = new List<MtrCalcTypeMdl>();

            _MtrCalcTypeMdlList = _OpenPolicyDal.GetCalcType();
            return _MtrCalcTypeMdlList;
        }

    }
}
