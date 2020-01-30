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
    [RoutePrefix("InsMtrTracker")]
    public class InsMtrTrackerController : ApiController
    {

        [HttpGet]
        [Route("GetInsMtrTracker")]
        public List<MtrInsTrackerMdl> GetTrackerSetup(string _Json)
        {
            MtrInsTrackerMdl _MtrInsTrackerMdl = JsonConvert.DeserializeObject<MtrInsTrackerMdl>(_Json);
            InsPolicyDal _InsPolicyDal = new InsPolicyDal();



            List<MtrInsTrackerMdl> _MtrInsTrackerMdlList = new List<MtrInsTrackerMdl>();

            _MtrInsTrackerMdlList = _InsPolicyDal.GetInsTracker(_MtrInsTrackerMdl);
            return _MtrInsTrackerMdlList;
        }


        [HttpGet]
        [Route("AddInsTracker")]
        public MtrInsTrackerMdl AddInsTracker(string _Json)
        {
            MtrInsTrackerMdl _MtrInsTrackerMdl = JsonConvert.DeserializeObject<MtrInsTrackerMdl>(_Json);
            InsPolicyDal _InsPolicyDal = new InsPolicyDal();

            MtrInsTrackerMdl mtrInsTrackerMdl = _InsPolicyDal.AddInsTracker(_MtrInsTrackerMdl);
            return mtrInsTrackerMdl;
        }

        [HttpGet]
        [Route("UpdateInsTracker")]
        public MtrInsTrackerMdl UpdateMasterCodes(string _Json)
        {
            MtrInsTrackerMdl _MtrInsTrackerMdl = JsonConvert.DeserializeObject<MtrInsTrackerMdl>(_Json);
            InsPolicyDal _InsPolicyDal = new InsPolicyDal();

            MtrInsTrackerMdl mtrInsTrackerMdl = _InsPolicyDal.UpdateInsTracker(_MtrInsTrackerMdl);
            return mtrInsTrackerMdl;
        }


    }
}
