using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TmsPlusRetailAPI.DataLayer;
using static TmsPlusRetailAPI.Models.HltPortalMdl;

namespace TmsPlusRetailAPI.Controllers
{
    [RoutePrefix("HltBaseRate")]
    public class HltBaseRateController : ApiController
    {

        [HttpGet]
        [Route("GetBaseL1Hos")]
        public List<HealthBaseRate> GetBaseL1Hos()
        {

            HltPortalDal _HltPortalDal = new HltPortalDal();
            List<HealthBaseRate> _HealthBaseRateList = _HltPortalDal.GetHealthBaseRateL1H();
            return _HealthBaseRateList;
        }


        [HttpGet]
        [Route("GetBaseL2ByL1Hos")]
        public List<HealthBaseRate> GetBaseL2Hos(string _Json)
        {
            HealthBaseRate _HealthBaseRate = JsonConvert.DeserializeObject<HealthBaseRate>(_Json);
            HltPortalDal _HltPortalDal = new HltPortalDal();

            List<HealthBaseRate> _HealthBaseRateList = _HltPortalDal.GetHealthBaseRateL2H(_HealthBaseRate);
            return _HealthBaseRateList;
        }

        [HttpGet]
        [Route("GetBaseL1Mat")]
        public List<HealthBaseRate> GetBaseL1Mat()
        {

            HltPortalDal _HltPortalDal = new HltPortalDal();
            List<HealthBaseRate> _HealthBaseRateList = _HltPortalDal.GetHealthBaseRateL1M();
            return _HealthBaseRateList;
        }


        [HttpGet]
        [Route("GetBaseL2ByL1Mat")]
        public List<HealthBaseRate> GetBaseL2Mat(string _Json)
        {
            HealthBaseRate _HealthBaseRate = JsonConvert.DeserializeObject<HealthBaseRate>(_Json);
            HltPortalDal _HltPortalDal = new HltPortalDal();

            List<HealthBaseRate> _HealthBaseRateList = _HltPortalDal.GetHealthBaseRateL2M(_HealthBaseRate);
            return _HealthBaseRateList;
        }


    }
}
