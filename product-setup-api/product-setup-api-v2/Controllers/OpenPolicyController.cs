using Newtonsoft.Json;
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

    [RoutePrefix("MtrOpenPolicy")]
    public class OpenPolicyController : ApiController
    {

        [HttpGet]
        [Route("GetOpenPolicy")]
        public List<MtrOpenPolicyMdl> GetOpenPolicy()
        {
            OpenPolicyDal _OpenPolicyDal = new OpenPolicyDal();
            List<MtrOpenPolicyMdl> _MtrOpenPolicyMdlList = new List<MtrOpenPolicyMdl>();

            _MtrOpenPolicyMdlList = _OpenPolicyDal.GetMtrOpenPolicy();
            return _MtrOpenPolicyMdlList;
        }


        [HttpGet]
        [Route("AddOpenPolicy")]
        public MtrOpenPolicyMdl AddMtrOpenPolicy(string _Json)
        {
            MtrOpenPolicyMdl _MtrOpenPolicyMdl = JsonConvert.DeserializeObject<MtrOpenPolicyMdl>(_Json);
            OpenPolicyDal _OpenPolicyDal = new OpenPolicyDal();

            MtrOpenPolicyMdl MtrOpenPolicyMdlList = _OpenPolicyDal.AddMtrOpenPolicy(_MtrOpenPolicyMdl);
            return MtrOpenPolicyMdlList;
        }

        [HttpGet]
        [Route("UpdateOpenPolicy")]
        public MtrOpenPolicyMdl UpdateMasterCodes(string _Json)

        {
            MtrOpenPolicyMdl _MtrOpenPolicyMdl = JsonConvert.DeserializeObject<MtrOpenPolicyMdl>(_Json);
            OpenPolicyDal _OpenPolicyDal = new OpenPolicyDal();

            MtrOpenPolicyMdl mtrOpenPolicyMdl = _OpenPolicyDal.UpdateMtrOpenPolicy(_MtrOpenPolicyMdl);
            return mtrOpenPolicyMdl;
        }

        [HttpGet]
        [Route("PostOpenPolicy")]
        public MtrOpenPolicyMdl PostOpenPolicy(string _Json)
        {
            MtrOpenPolicyMdl _MtrOpenPolicyMdl = new MtrOpenPolicyMdl();
            try
            {
               _MtrOpenPolicyMdl = JsonConvert.DeserializeObject<MtrOpenPolicyMdl>(_Json);
            }
            catch(Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy Controller");
            }
           
            OpenPolicyDal _OpenPolicyDal = new OpenPolicyDal();

            MtrOpenPolicyMdl mtrOpenPolicyMdl = _OpenPolicyDal.PostMtrOpenPolicy(_MtrOpenPolicyMdl);
            return mtrOpenPolicyMdl;
        }

        [HttpGet]
        [Route("GetOPolicyByClient")]
        public List<MtrOpenPolicyMdl> GetOPolicyByClient(string _Json)
        {
            ProductClientMdl _ProductClientMdl = JsonConvert.DeserializeObject<ProductClientMdl>(_Json);
            InsPolicyDal _InsPolicyDal = new InsPolicyDal();

            List<MtrOpenPolicyMdl> mtrOpenPolicyMdl = _InsPolicyDal.GetOpolicytByClient(_ProductClientMdl);
            return mtrOpenPolicyMdl;
        }

        [HttpGet]
        [Route("GetOPolicyByTxnID")]
        public MtrOpenPolicyMdl GetOPolicyByTxnID(string _Json)
        {
            MtrOpenPolicyMdl _MtrOpenPolicyMdl = JsonConvert.DeserializeObject<MtrOpenPolicyMdl>(_Json);
            InsPolicyDal _InsPolicyDal = new InsPolicyDal();

            MtrOpenPolicyMdl mtrOpenPolicyMdl = _InsPolicyDal.GetOpolicytByTxnID(_MtrOpenPolicyMdl);
            return mtrOpenPolicyMdl;
        }

        [HttpGet]
        [Route("GetOPolicyByClientForPol")]
        public MtrOpenPolicyMdl GetOPolicyByClientForPol(string _Json)
        {
            ProductClientMdl _ProductClientMdl = JsonConvert.DeserializeObject<ProductClientMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();

            MtrOpenPolicyMdl mtrOpenPolicyMdl = _PolicyDal.GetOpolicytByClientForPol(_ProductClientMdl);
            return mtrOpenPolicyMdl;
        }

    }
}
