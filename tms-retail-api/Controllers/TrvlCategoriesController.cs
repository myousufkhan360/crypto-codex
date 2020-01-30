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
    [RoutePrefix("ddlTrvlCategory")]
    public class TrvlCategoriesController : ApiController
    {

        [HttpGet]
        [Route("GetTravelCategoryList")]
        // GET: api/ddlTravel
        public List<ddlTravelCategory> GetTravelCategoryList()
        {
            TrvlPortalDal _TrvlPortalDal = new TrvlPortalDal();
            List<ddlTravelCategory> _ddlTravelCategoryList = new List<ddlTravelCategory>();

            _ddlTravelCategoryList = _TrvlPortalDal.GetTravelCategoryList();
            return _ddlTravelCategoryList;
        }


    }
}
