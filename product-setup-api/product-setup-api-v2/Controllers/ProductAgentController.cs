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
    [RoutePrefix("ProductAgent")]
    public class ProductAgentController : ApiController
    {

        [HttpGet]
        [Route("GetProductAgent")]
        public List<ProductAgentMdl> GetMasterCodes()
        {
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();
            List<ProductAgentMdl> _ProductAgentMdlList = new List<ProductAgentMdl>();

            _ProductAgentMdlList = _ProductSetupDal.GetAgent();
            return _ProductAgentMdlList;
        }

        [HttpGet]
        [Route("GetProductAgentForPol")]
        public List<ProductAgentMdl> GetAgentForPol()
        {
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();
            List<ProductAgentMdl> _ProductAgentMdlList = new List<ProductAgentMdl>();

            _ProductAgentMdlList = _ProductSetupDal.GetAgentForPol();
            return _ProductAgentMdlList;
        }

    }
}
