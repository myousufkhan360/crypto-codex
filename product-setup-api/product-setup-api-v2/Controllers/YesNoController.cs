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
    [RoutePrefix("YesNo")]
    public class YesNoController : ApiController
    {

        [HttpGet]
        [Route("GetYesNo")]
        public List<YesNoMdl> GetYesNo()
        {
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();
            List<YesNoMdl> _YesNoMdlList = new List<YesNoMdl>();

            _YesNoMdlList = _ProductSetupDal.GetYesNo();
            return _YesNoMdlList;
        }

    }
}
