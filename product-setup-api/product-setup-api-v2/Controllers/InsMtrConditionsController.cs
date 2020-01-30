using Newtonsoft.Json;
using ProductSetupApi.DataLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ProductSetupApi.Models.InsPolicyMdl;

namespace ProductSetupApi.Controllers
{
    [RoutePrefix("InsMtrConditions")]
    public class InsMtrConditionsController : ApiController
    {
        [HttpGet]
        [Route("GetInsConditions")]
        public List<MtrInsConditionsMdl> GetInsRider(string _Json)
        {
            MtrInsConditionsMdl _MtrInsConditionsMdl = JsonConvert.DeserializeObject<MtrInsConditionsMdl>(_Json);
            InsPolicyDal _InsPolicyDal = new InsPolicyDal();



            List<MtrInsConditionsMdl> _MtrInsConditionsMdlList = new List<MtrInsConditionsMdl>();

            _MtrInsConditionsMdlList = _InsPolicyDal.GetInsConditions(_MtrInsConditionsMdl);
            return _MtrInsConditionsMdlList;
        }


        [HttpGet]
        [Route("AddInsConditions")]
        public MtrInsConditionsMdl AddInsTracker(string _Json)
        {
            MtrInsConditionsMdl _MtrInsConditionsMdl = JsonConvert.DeserializeObject<MtrInsConditionsMdl>(_Json);
            InsPolicyDal _InsPolicyDal = new InsPolicyDal();

            MtrInsConditionsMdl mtrInsConditionsMdl = _InsPolicyDal.AddInsConditions(_MtrInsConditionsMdl);
            return mtrInsConditionsMdl;
        }

        [HttpGet]
        [Route("UpdateInsConditions")]
        public MtrInsConditionsMdl UpdateMasterCodes(string _Json)
        {
            MtrInsConditionsMdl _MtrInsConditionsMdl = JsonConvert.DeserializeObject<MtrInsConditionsMdl>(_Json);
            InsPolicyDal _InsPolicyDal = new InsPolicyDal();

            MtrInsConditionsMdl mtrInsConditionsMdl = _InsPolicyDal.UpdateInsConditions(_MtrInsConditionsMdl);
            return mtrInsConditionsMdl;
        }



    }
}
