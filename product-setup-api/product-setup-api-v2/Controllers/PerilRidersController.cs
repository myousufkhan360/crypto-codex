using ProductSetupApi.DataLayers;
using ProductSetupApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductSetupApi.Controllers
{
    [RoutePrefix("PerilRiders")]
    public class PerilRidersController : ApiController
    {

        [HttpGet]
        [Route("GetPerilRiders")]
        public List<PerilRidersMdl> GetPerilRiders()
        {
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();
            List<PerilRidersMdl> _PerilRidersMdlList = new List<PerilRidersMdl>();

            _PerilRidersMdlList = _ProductSetupDal.GetPerilRiders();
            return _PerilRidersMdlList;
        }

    }
}
