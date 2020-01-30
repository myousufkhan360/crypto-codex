using Newtonsoft.Json;
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
    [RoutePrefix("ProductConditions")]
    public class ProductConditionsController : ApiController
    {

        [HttpGet]
        [Route("GetProductConditions")]
        public List<ProductConditionsMdl> GetMasterCodes()
        {
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();
            List<ProductConditionsMdl> _ProductConditionsMdlList = new List<ProductConditionsMdl>();

            _ProductConditionsMdlList = _ProductSetupDal.GetConditions();
            return _ProductConditionsMdlList;
        }

        

    }
}
