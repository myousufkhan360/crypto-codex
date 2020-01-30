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
    [RoutePrefix("TakafulType")]
    public class InsuranceTypeController : ApiController
    {

        [HttpGet]
        [Route("GetTakafulType")]
        public List<InsuranceTypeMdl> GetTakafulType()
        {
            OpenPolicyDal _OpenPolicyDal = new OpenPolicyDal();
            List<InsuranceTypeMdl> _InsuranceTypeMdlList = new List<InsuranceTypeMdl>();

            _InsuranceTypeMdlList = _OpenPolicyDal.GetInsType();
            return _InsuranceTypeMdlList;
        }

    }
}
