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
    [RoutePrefix("ProductClient")]
    public class ProductClientController : ApiController
    {

        [HttpGet]
        [Route("GetProductClient")]
        public List<ProductClientMdl> GetMasterCodes()
        {
           
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();
            List<ProductClientMdl> _ProductClientMdlList = new List<ProductClientMdl>();

            _ProductClientMdlList = _ProductSetupDal.GetClient();
            return _ProductClientMdlList;
        }

        [HttpGet]
        [Route("GetProductClientForPol")]
        public List<ProductClientMdl> GetClientForPol()
        {

            ProductSetupDal _ProductSetupDal = new ProductSetupDal();
            List<ProductClientMdl> _ProductClientMdlList = new List<ProductClientMdl>();

            _ProductClientMdlList = _ProductSetupDal.GetClientForPol();
            return _ProductClientMdlList;
        }


        [HttpGet]
        [Route("GetProductClientByCode")]
        public List<ProductClientMdl> GetClientByCode(string _Json)
        {
            ProductClientMdl _ProductClientMdl = JsonConvert.DeserializeObject<ProductClientMdl>(_Json);
            OpenPolicyDal _OpenPolicyDal = new OpenPolicyDal();
            List<ProductClientMdl> _ProductClientMdlList = new List<ProductClientMdl>();

            _ProductClientMdlList = _OpenPolicyDal.GetClientByCode(_ProductClientMdl);
            return _ProductClientMdlList;
        }

    }
}
