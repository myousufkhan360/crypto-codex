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
    [RoutePrefix("ddlTrvlRelation")]
    public class TrvlRelationsController : ApiController
    {

        [HttpGet]
        [Route("GetRelationList")]
        public List<ddlRelation> GetRelationList()
        {
            TrvlPortalDal _TrvlPortalDal = new TrvlPortalDal();
            List<ddlRelation> _ddlRelationList = new List<ddlRelation>();

            _ddlRelationList = _TrvlPortalDal.GetRelationList();
            return _ddlRelationList;
        }

    }
}
