using Newtonsoft.Json;
using ProductSetupApi.DataLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ProductSetupApi.Models.InsPolicyMdl;

namespace ProductSetupApi.Controllers
{
    [RoutePrefix("InsMtrWarranties")]
    public class InsMtrWarrantiesController : ApiController
    {

        [HttpGet]
        [Route("GetMtrWarranties")]
        public List<MtrInsWarrantiesMdl> GetInsRider(string _Json)
        {
            MtrInsWarrantiesMdl _MtrInsWarrantiesMdl = JsonConvert.DeserializeObject<MtrInsWarrantiesMdl>(_Json);
            InsPolicyDal _InsPolicyDal = new InsPolicyDal();



            List<MtrInsWarrantiesMdl> _MtrInsWarrantiesMdlList = new List<MtrInsWarrantiesMdl>();

            _MtrInsWarrantiesMdlList = _InsPolicyDal.GetInsWarranties(_MtrInsWarrantiesMdl);
            return _MtrInsWarrantiesMdlList;
        }


        [HttpGet]
        [Route("AddInsMtrWarranties")]
        public MtrInsWarrantiesMdl AddInsTracker(string _Json)
        {
            MtrInsWarrantiesMdl _MtrInsWarrantiesMdl = JsonConvert.DeserializeObject<MtrInsWarrantiesMdl>(_Json);
            InsPolicyDal _InsPolicyDal = new InsPolicyDal();

            MtrInsWarrantiesMdl mtrInsWarrantiesMdl = _InsPolicyDal.AddInsWarranties(_MtrInsWarrantiesMdl);
            return mtrInsWarrantiesMdl;
        }

        [HttpGet]
        [Route("UpdateInsMtrWarranties")]
        public MtrInsWarrantiesMdl UpdateMasterCodes(string _Json)
        {
            MtrInsWarrantiesMdl _MtrInsWarrantiesMdl = JsonConvert.DeserializeObject<MtrInsWarrantiesMdl>(_Json);
            InsPolicyDal _InsPolicyDal = new InsPolicyDal();

            MtrInsWarrantiesMdl mtrInsWarrantiesMdl = _InsPolicyDal.UpdateInsWarranties(_MtrInsWarrantiesMdl);
            return mtrInsWarrantiesMdl;
        }


    }
}
