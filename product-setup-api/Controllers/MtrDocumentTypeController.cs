using ProductSetupApi.DataLayers;
using ProductSetupApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ProductSetupApi.Models.OpenPolicyMdl;

namespace ProductSetupApi.Controllers
{
    [RoutePrefix("DocumentType")]
    public class MtrDocumentTypeController : ApiController
    {
        [HttpGet]
        [Route("GetDocumentType")]
        public List<MtrDocumentTypeMdl> GetDocumentType()
        {
            OpenPolicyDal _ProductSetupDal = new OpenPolicyDal();
            List<MtrDocumentTypeMdl> _MtrDocumentTypeMdlList = new List<MtrDocumentTypeMdl>();

            _MtrDocumentTypeMdlList = _ProductSetupDal.GetMtrDocumentType();
            return _MtrDocumentTypeMdlList;
        }
    }
}
