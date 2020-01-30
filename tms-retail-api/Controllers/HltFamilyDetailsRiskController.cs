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
    [RoutePrefix("HltFamilyDetails")]
    public class HltFamilyDetailsRiskController : ApiController
    {

        [HttpGet]
        [Route("AddHltFamilyDetails")]
        public HltFamilyDetailsRisk AddTrvlFamilyRisk(string _Json)
        {
            HltFamilyDetailsRisk _HltFamilyDetailsRisk = JsonConvert.DeserializeObject<HltFamilyDetailsRisk>(_Json);
            HltRisk _HltRisk = JsonConvert.DeserializeObject<HltRisk>(_Json);
            HltPortalDal _HltPortalDal = new HltPortalDal();


            HltFamilyDetailsRisk hltFamilyDetailsRisk = _HltPortalDal.AddHltFamilyDetails(_HltRisk, _HltFamilyDetailsRisk);
            return hltFamilyDetailsRisk;
        }

    }
}
