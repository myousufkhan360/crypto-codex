using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TmsPlusRetailAPI.DataLayer;
using static TmsPlusRetailAPI.Models.GlobalModels;

namespace TmsPlusRetailAPI.Controllers
{
    [RoutePrefix("Genders")]
    public class GendersController : ApiController
    {

        [HttpGet]
        [Route("GetGenders")]
        public List<GendersMdl> GetGenders()
        {
            GlobalDataLayer _GlobalDataLayer = new GlobalDataLayer();
            List<GendersMdl> _GendersMdlList = new List<GendersMdl>();

            _GendersMdlList = _GlobalDataLayer.GetGenders();
            return _GendersMdlList;
        }
    }
}
