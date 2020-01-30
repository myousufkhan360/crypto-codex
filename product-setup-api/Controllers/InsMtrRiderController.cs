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
    [RoutePrefix("InsMtrRider")]
    public class InsMtrRiderController : ApiController
    {

        [HttpGet]
        [Route("GetInsMtrRider")]
        public List<MtrInsRiderMdl> GetTrackerSetup(string _Json)
        {
            MtrInsRiderMdl _MtrInsRiderMdl = JsonConvert.DeserializeObject<MtrInsRiderMdl>(_Json);
            InsPolicyDal _InsPolicyDal = new InsPolicyDal();



            List<MtrInsRiderMdl> _MtrInsRiderMdlList = new List<MtrInsRiderMdl>();

            _MtrInsRiderMdlList = _InsPolicyDal.GetInsRider(_MtrInsRiderMdl);
            return _MtrInsRiderMdlList;
        }


        [HttpGet]
        [Route("AddInsRider")]
        public MtrInsRiderMdl AddInsTracker(string _Json)
        {
            MtrInsRiderMdl _MtrInsRiderMdl = JsonConvert.DeserializeObject<MtrInsRiderMdl>(_Json);
            InsPolicyDal _InsPolicyDal = new InsPolicyDal();

            MtrInsRiderMdl mtrInsRiderMdl = _InsPolicyDal.AddInsRider(_MtrInsRiderMdl);
            return mtrInsRiderMdl;
        }

        [HttpGet]
        [Route("UpdateInsRider")]
        public MtrInsRiderMdl UpdateMasterCodes(string _Json)
        {
            MtrInsRiderMdl _MtrInsRiderMdl = JsonConvert.DeserializeObject<MtrInsRiderMdl>(_Json);
            InsPolicyDal _InsPolicyDal = new InsPolicyDal();

            MtrInsRiderMdl mtrInsRiderMdl = _InsPolicyDal.UpdateInsRider(_MtrInsRiderMdl);
            return mtrInsRiderMdl;
        }


    }
}
