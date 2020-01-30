using Newtonsoft.Json;
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

    [RoutePrefix("EndtReason")]
    public class EndtReasonController : ApiController
    {
        [HttpGet]
        [Route("GetEndtReason")]
        public List<EndtReasonMdl> GetEndtReason(string _Json)
        {
            EndtTypeMdl _EndtTypeMdl = JsonConvert.DeserializeObject<EndtTypeMdl>(_Json);
            EndorsementDal _EndorsementDal = new EndorsementDal();

            List<EndtReasonMdl> EndtReasonMdlList = _EndorsementDal.GetEndtReasonMdl(_EndtTypeMdl);
            return EndtReasonMdlList;
        }


        [HttpGet]
        [Route("GetEndtReasonForNonF")]
        public List<EndtReasonMdl> GetEndtReasonForNonF()
        {
          
            EndorsementDal _EndorsementDal = new EndorsementDal();

            List<EndtReasonMdl> EndtReasonMdlList = _EndorsementDal.GetNonFEndtReasonMdl();
            return EndtReasonMdlList;
        }


    }
}
