using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TmsPlusRetailAPI.DataLayer;
using static TmsPlusRetailAPI.Models.TrvlPortalMdl;

namespace TmsPlusRetailAPI.Controllers
{
    [RoutePrefix("TrvlFamilyDetails")]
    public class TrvlFamilyDetailsRiskController : ApiController
    {

        [HttpGet]
        [Route("AddTrvlFamilyDetails")]
        public TrvlFamilyDetailsRisk AddTrvlFamilyRisk(string _Json)
        {
            TrvlFamilyDetailsRisk _TrvlFamilyDetailsRisk = JsonConvert.DeserializeObject<TrvlFamilyDetailsRisk>(_Json);
            TrvlRisk _TrvlRisk = JsonConvert.DeserializeObject<TrvlRisk>(_Json);
            TrvlPortalDal _TrvlPortalDal = new TrvlPortalDal();


            TrvlFamilyDetailsRisk trvlFamilyDetailsRisk = _TrvlPortalDal.AddTrvlFamilyDetails(_TrvlRisk,_TrvlFamilyDetailsRisk);
            return trvlFamilyDetailsRisk;
        }

    }
}
