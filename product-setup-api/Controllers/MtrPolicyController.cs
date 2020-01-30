using Newtonsoft.Json;
using ProductSetupApi.DataLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ProductSetupApi.Models.MtrPolicy;

namespace ProductSetupApi.Controllers
{

    [RoutePrefix("MtrPolicy")]
    public class MtrPolicyController : ApiController
    {



        [HttpGet]
        [Route("GetPolicy")]
        public List<MtrPolicyMdl> GetOpenPolicy()
        {
            PolicyDal _PolicyDal = new PolicyDal();
            List<MtrPolicyMdl> _MtrPolicyMdlList = new List<MtrPolicyMdl>();

            _MtrPolicyMdlList = _PolicyDal.GetMtrOpenPolicy();
            return _MtrPolicyMdlList;
        }

        [HttpGet]
        [Route("AddPolicy")]
        public MtrPolicyMdl AddMtrOpenPolicy(string _Json)
        {
            MtrPolicyMdl _MtrPolicyMdl = new MtrPolicyMdl();
            try
            {
               _MtrPolicyMdl = JsonConvert.DeserializeObject<MtrPolicyMdl>(_Json);
            }

            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Json Error From Vehicle Details Controller");
            }

           // MtrPolicyMdl _MtrPolicyMdl = JsonConvert.DeserializeObject<MtrPolicyMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();

            MtrPolicyMdl MtrPolicyMdlList = _PolicyDal.AddMtrPolicy(_MtrPolicyMdl);
            return MtrPolicyMdlList;
        }

        [HttpGet]
        [Route("UpdatePolicy")]
        public MtrPolicyMdl UpdateMasterCodes(string _Json)

        {
            MtrPolicyMdl _MtrPolicyMdl = JsonConvert.DeserializeObject<MtrPolicyMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();

            MtrPolicyMdl mtrPolicyMdl = _PolicyDal.UpdateMtrPolicy(_MtrPolicyMdl);
            return mtrPolicyMdl;
        }


        [HttpGet]
        [Route("PostPolicy")]
        public MtrPolicyMdl PostOpenPolicy(string _Json)
        {
            MtrPolicyMdl _MtrPolicyMdl = JsonConvert.DeserializeObject<MtrPolicyMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();

            MtrPolicyMdl mtrPolicyMdl = _PolicyDal.PostMtrPolicy(_MtrPolicyMdl);
            return mtrPolicyMdl;
        }




    }
}
