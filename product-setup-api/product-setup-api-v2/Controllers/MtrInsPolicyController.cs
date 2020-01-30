using Newtonsoft.Json;
using ProductSetupApi.DataLayers;
using ProductSetupApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ProductSetupApi.Models.InsPolicyMdl;
using static ProductSetupApi.Models.MtrVehicleDetailMdl;
using static ProductSetupApi.Models.OpenPolicyMdl;

namespace ProductSetupApi.Controllers
{
    [RoutePrefix("MtrInsPolicy")]
    public class MtrInsPolicyController : ApiController
    {
        [HttpGet]
        [Route("GetInsPolicy")]
        public List<MtrInsPolicyMdl> GetMasterCodes()
        {
            InsPolicyDal _InsPolicyDal = new InsPolicyDal();
            List<MtrInsPolicyMdl> _MtrInsPolicyMdlList = new List<MtrInsPolicyMdl>();

            _MtrInsPolicyMdlList = _InsPolicyDal.GetMtrInsPolicy();
            return _MtrInsPolicyMdlList;
        }


        [HttpGet]
        [Route("AddInsPolicy")]
        public MtrInsPolicyMdl AddProductConditionsSetUpMdl(string _Json)
        {
            MtrInsPolicyMdl _MtrInsPolicyMdl = JsonConvert.DeserializeObject<MtrInsPolicyMdl>(_Json);
            MtrOpenPolicyMdl _MtrOpenPolicyMdl = JsonConvert.DeserializeObject<MtrOpenPolicyMdl>(_Json);

            InsPolicyDal _InsPolicyDal = new InsPolicyDal();

            MtrInsPolicyMdl MtrInsPolicyMdlList = _InsPolicyDal.AddMtrInsPolicy(_MtrInsPolicyMdl, _MtrOpenPolicyMdl);
            return MtrInsPolicyMdlList;
        }

        [HttpGet]
        [Route("AddInsPolicyForPol")]
        public MtrInsPolicyMdl AddInsPol(string _Json)
        {
            MtrInsPolicyMdl _MtrInsPolicyMdl = JsonConvert.DeserializeObject<MtrInsPolicyMdl>(_Json);
          //  MtrOpenPolicyMdl _MtrOpenPolicyMdl = JsonConvert.DeserializeObject<MtrOpenPolicyMdl>(_Json);
            MasterProductSetupMdl _MasterProductSetupMdl = JsonConvert.DeserializeObject<MasterProductSetupMdl>(_Json);

            InsPolicyDal _InsPolicyDal = new InsPolicyDal();

            MtrInsPolicyMdl MtrInsPolicyMdlList = _InsPolicyDal.AddMtrInsPolicyForPol1(_MtrInsPolicyMdl, _MasterProductSetupMdl);
            return MtrInsPolicyMdlList;
        }

        [HttpGet]
        [Route("AddInsPolicyForPol1")]
        public MtrInsPolicyMdl AddInsPol1(string _Json)
        {
            MtrInsPolicyMdl _MtrInsPolicyMdl = JsonConvert.DeserializeObject<MtrInsPolicyMdl>(_Json);
            MasterProductSetupMdl _MasterProductSetupMdl = JsonConvert.DeserializeObject<MasterProductSetupMdl>(_Json);

           // MtrOpenPolicyMdl _MtrOpenPolicyMdl = JsonConvert.DeserializeObject<MtrOpenPolicyMdl>(_Json);

            InsPolicyDal _InsPolicyDal = new InsPolicyDal();

            MtrInsPolicyMdl MtrInsPolicyMdlList = _InsPolicyDal.AddMtrInsPolicyForPol1(_MtrInsPolicyMdl, _MasterProductSetupMdl);
            return MtrInsPolicyMdlList;
        }

        [HttpGet]
        [Route("AddInsPolicyForEnd")]
        public MtrInsPolicyMdl AddInsPolForEnd(string _Json)
        {
            MtrInsPolicyMdl _MtrInsPolicyMdl = JsonConvert.DeserializeObject<MtrInsPolicyMdl>(_Json);
            MtrOpenPolicyMdl _MtrOpenPolicyMdl = JsonConvert.DeserializeObject<MtrOpenPolicyMdl>(_Json);

            InsPolicyDal _InsPolicyDal = new InsPolicyDal();

            MtrInsPolicyMdl MtrInsPolicyMdlList = _InsPolicyDal.AddMtrInsPolicyForEnd(_MtrInsPolicyMdl, _MtrOpenPolicyMdl);
            return MtrInsPolicyMdlList;
        }


        [HttpGet]
        [Route("GetInsByDate")]
        public List<MtrInsPolicyMdl> GetInsByDate(string _Json)
        {
            MtrInsPolicyMdl _MtrInsPolicyMdl = JsonConvert.DeserializeObject<MtrInsPolicyMdl>(_Json);

            RenewalDal _RenewalDal = new RenewalDal();
            List<MtrInsPolicyMdl> _MtrInsPolicyMdlList = new List<MtrInsPolicyMdl>();

            _MtrInsPolicyMdlList = _RenewalDal.GetCertStrByDate(_MtrInsPolicyMdl);
            return _MtrInsPolicyMdlList;
        }


        [HttpGet]
        [Route("AddInsPolicyForRenw")]
        public MtrInsPolicyMdl AddInsPolForRenw(string _Json)
        {
            MtrInsPolicyMdl _MtrInsPolicyMdl = JsonConvert.DeserializeObject<MtrInsPolicyMdl>(_Json);
            // MtrOpenPolicyMdl _MtrOpenPolicyMdl = JsonConvert.DeserializeObject<MtrOpenPolicyMdl>(_Json);

            RenewalDal _RenewalDal = new RenewalDal();

            MtrInsPolicyMdl MtrInsPolicyMdlList = _RenewalDal.ToPassRenewal(_MtrInsPolicyMdl);
            return MtrInsPolicyMdlList;
        }


        [HttpGet]
        [Route("AddInsPolicyForDedut")]
        public List<MtrVContributionMdl> AddInsPolForDedut(string _Json)
        {
            MtrInsPolicyMdl _MtrInsPolicyMdl = JsonConvert.DeserializeObject<MtrInsPolicyMdl>(_Json);
            // MtrOpenPolicyMdl _MtrOpenPolicyMdl = JsonConvert.DeserializeObject<MtrOpenPolicyMdl>(_Json);

            RenewalDal _RenewalDal = new RenewalDal();

            List<MtrVContributionMdl> MtrVContributionMdlList = _RenewalDal.ToDeductForRenewal(_MtrInsPolicyMdl);
            return MtrVContributionMdlList;
        }

        [HttpGet]
        [Route("AddInsPolicyForConv")]
        public MtrInsPolicyMdl AddInsPolForConv(string _Json)
        {
            MtrInsPolicyMdl _MtrInsPolicyMdl = JsonConvert.DeserializeObject<MtrInsPolicyMdl>(_Json);
            // MtrOpenPolicyMdl _MtrOpenPolicyMdl = JsonConvert.DeserializeObject<MtrOpenPolicyMdl>(_Json);

            RenewalDal _RenewalDal = new RenewalDal();

            MtrInsPolicyMdl MtrInsPolicyMdlList = _RenewalDal.ToConvertToPolicy(_MtrInsPolicyMdl);
            return MtrInsPolicyMdlList;
        }

    }
}
