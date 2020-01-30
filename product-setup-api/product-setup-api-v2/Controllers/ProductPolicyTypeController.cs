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
    [RoutePrefix("ProductPolicyType")]
    public class ProductPolicyTypeController : ApiController
    {
        [HttpGet]
        [Route("GetProductPolicyType")]
        public List<ProductPolicyTypeMdl> GetPolicyClass()
        {
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();
            List<ProductPolicyTypeMdl> _ProductPolicyTypeMdlList = new List<ProductPolicyTypeMdl>();

            _ProductPolicyTypeMdlList = _ProductSetupDal.GetPolicyType();
            return _ProductPolicyTypeMdlList;
        }


        [HttpGet]
        [Route("GetMtrCertInsuranceCode")]
        public ProductPolicyTypeMdl GetMasterProductSetupByCode(string _Json)
        {
            ProductPolicyTypeMdl _ProductPolicyTypeMdl = JsonConvert.DeserializeObject<ProductPolicyTypeMdl>(_Json);
            OpenPolicyDal _OpenPolicyDal = new OpenPolicyDal();

            ProductPolicyTypeMdl ProductPolicyTypeMdlList = _OpenPolicyDal.GetCertInsureCode(_ProductPolicyTypeMdl);
            return ProductPolicyTypeMdlList;
        }
    }
}
