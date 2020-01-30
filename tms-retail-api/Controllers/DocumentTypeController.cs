using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TmsPlusRetailAPI.DataLayer;
using static TmsPlusRetailAPI.Models.GlobalModels;

namespace TmsPlusRetailAPI.Controllers
{
    [RoutePrefix("DocumentType")]
    public class DocumentTypeController : ApiController
    {
        [HttpGet]
        [Route("GetDocumentType")]
        public List<DocumentTypeMdl> GetDocumentType()
        {
            GlobalDataLayer _GlobalDataLayer = new GlobalDataLayer();
            List<DocumentTypeMdl> _MtrDocumentTypeMdlList = new List<DocumentTypeMdl>();

            _MtrDocumentTypeMdlList = _GlobalDataLayer.GetDocumentType();
            return _MtrDocumentTypeMdlList;
        }
    }
}
