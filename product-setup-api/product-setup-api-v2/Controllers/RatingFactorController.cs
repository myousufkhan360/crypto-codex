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
    [RoutePrefix("RatingFactor")]
    public class RatingFactorController : ApiController
    {

        [HttpGet]
        [Route("GetRatingFactor")]
        public List<RatingFactorMdl> GetPolicyClass()
        {
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();
            List<RatingFactorMdl> _RatingFactorMdlList = new List<RatingFactorMdl>();

            _RatingFactorMdlList = _ProductSetupDal.GetRatingFactor();
            return _RatingFactorMdlList;
        }

    }
}
