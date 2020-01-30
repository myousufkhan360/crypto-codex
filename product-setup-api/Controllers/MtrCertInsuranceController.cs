using Newtonsoft.Json;
using ProductSetupApi.DataLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ProductSetupApi.Models.OpenPolicyMdl;

namespace ProductSetupApi.Controllers
{
    [RoutePrefix("MtrCertInsurance")]
    public class MtrCertInsuranceController : ApiController
    {
        //[HttpGet]
        //[Route("GetMtrCertInsuranceCode")]
        //public MtrCertificateInsuranceMdl GetMasterProductSetupByCode(string _Json)
        //{
        //    MtrCertificateInsuranceMdl _MtrCertificateInsuranceMdl = JsonConvert.DeserializeObject<MtrCertificateInsuranceMdl>(_Json);
        //    OpenPolicyDal _OpenPolicyDal = new OpenPolicyDal();

        //    MtrCertificateInsuranceMdl mtrCertificateInsuranceMdlList = _OpenPolicyDal.GetCertInsureCode(_MtrCertificateInsuranceMdl);
        //    return mtrCertificateInsuranceMdlList;
        //}

        [HttpGet]
        [Route("GetAllMtrCertInsuranceCode")]
        public List<MtrCertificateInsuranceMdl> GetAllMtrCertInsuranceCode()
        {

            OpenPolicyDal _OpenPolicyDal = new OpenPolicyDal();

            List<MtrCertificateInsuranceMdl> mtrCertificateInsuranceMdlList = _OpenPolicyDal.GetAllCertInsureCode();
            return mtrCertificateInsuranceMdlList;
        }
    }
}
