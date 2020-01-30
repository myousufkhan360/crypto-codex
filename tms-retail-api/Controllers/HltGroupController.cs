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
    [RoutePrefix("HltGroup")]
    public class HltGroupController : ApiController
    {

        [HttpGet]
        [Route("GetHltGroup")]
        public List<HltGroup> AddMtrVColor()
        {
            
            HltPortalDal _HltPortalDal = new HltPortalDal();

            List<HltGroup> _HltGroupList = _HltPortalDal.GetHltGroup();
            return _HltGroupList;


        }


    }
}
