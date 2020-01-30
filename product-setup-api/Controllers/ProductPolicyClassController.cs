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
    [RoutePrefix("ProductPolicyClass")]
    public class ProductPolicyClassController : ApiController
    {
        [HttpGet]
        [Route("GetProductPolicyClass")]
        public List<ProductPolicyClassMdl> GetPolicyClass()
        {
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();
            List<ProductPolicyClassMdl> _ProductPolicyClassMdlList = new List<ProductPolicyClassMdl>();

            _ProductPolicyClassMdlList = _ProductSetupDal.GetPolicyClass();
            return _ProductPolicyClassMdlList;
        }
    }
}
