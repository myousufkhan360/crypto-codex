using ProductSetupApi.DataLayers;
using ProductSetupApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ProductSetupApi.Models.MtrEndorsementMdl;

namespace ProductSetupApi.Controllers
{
    [RoutePrefix("EndtType")]
    public class EndtTypeController : ApiController
    {

        [HttpGet]
        [Route("GetEndtType")]
        public List<EndtTypeMdl> GetMtrTxnType()
        {
            EndorsementDal _EndorsementDal = new EndorsementDal();
            List<EndtTypeMdl> _EndtTypeList = new List<EndtTypeMdl>();

            _EndtTypeList = _EndorsementDal.GetEndtTypeMdl();
            return _EndtTypeList;
        }


    }
}
