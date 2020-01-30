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
    [RoutePrefix("Warranties")]
    public class WarrantiesController : ApiController
    {
        [HttpGet]
        [Route("GetWarranties")]
        public List<WarrantiesMdl> GetPolicyClass()
        {
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();
            List<WarrantiesMdl> _WarrantiesMdlList = new List<WarrantiesMdl>();

            _WarrantiesMdlList = _ProductSetupDal.GetWarranties();
            return _WarrantiesMdlList;
        }
    }
}
