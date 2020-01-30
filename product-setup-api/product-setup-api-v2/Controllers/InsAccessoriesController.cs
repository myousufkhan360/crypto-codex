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

    [RoutePrefix("InsAccessories")]
    public class InsAccessoriesController : ApiController
    {

        [HttpGet]
        [Route("GetInsAccessories")]
        public List<InsAccessoriesMdl> GetDocumentType()
        {
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();
            List<InsAccessoriesMdl> _InsAccessoriesMdlList = new List<InsAccessoriesMdl>();

            _InsAccessoriesMdlList = _ProductSetupDal.GetAcessories();
            return _InsAccessoriesMdlList;
        }

    }
}
