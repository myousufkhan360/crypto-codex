using Newtonsoft.Json;
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
    [RoutePrefix("MasterProductSetUp")]
    public class MasterProductSetupController : ApiController
    {
        [HttpGet]
        [Route("GetMasterProductSetUp")]
        public List<MasterProductSetupMdl> GetMasterCodes()
        {
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();
            List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();

            _MasterProductSetupMdlList = _ProductSetupDal.GetMasterProductSetUp();
            return _MasterProductSetupMdlList;
        }


        [HttpGet]
        [Route("AddMasterProductSetUp")]
        public MasterProductSetupMdl AddProductConditionsSetUpMdl(string _Json)
        {
            MasterProductSetupMdl _MasterProductSetupMdl = JsonConvert.DeserializeObject<MasterProductSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();

            MasterProductSetupMdl MasterProductSetupMdlList = _ProductSetupDal.AddMasterProductSetUp(_MasterProductSetupMdl);
            return MasterProductSetupMdlList;
        }

        [HttpGet]
        [Route("UpdateMasterProductSetUp")]
        public MasterProductSetupMdl UpdateMasterCodes(string _Json)
        {
            MasterProductSetupMdl _MasterProductSetupMdl = JsonConvert.DeserializeObject<MasterProductSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();

            MasterProductSetupMdl masterProductSetupMdl = _ProductSetupDal.UpdateMasterProductSetup(_MasterProductSetupMdl);
            return masterProductSetupMdl;
        }


        [HttpGet]
        [Route("GetMasterProductSetUpByCode")]
        public MasterProductSetupMdl GetMasterProductSetupByCode(string _Json)
        {
            MasterProductSetupMdl _MasterProductSetupMdl = JsonConvert.DeserializeObject<MasterProductSetupMdl>(_Json);
            OpenPolicyDal _OpenPolicyDal = new OpenPolicyDal();

            MasterProductSetupMdl masterProductSetupMdlList = _OpenPolicyDal.GetMasterProductSetUpByProductCode(_MasterProductSetupMdl);
            return masterProductSetupMdlList;
        }


        [HttpGet]
        [Route("GetMasterProductSetUpByCodeForPol")]
        public MasterProductSetupMdl GetMasterProductSetupByCodeForPol(string _Json)
        {
            MasterProductSetupMdl _MasterProductSetupMdl = JsonConvert.DeserializeObject<MasterProductSetupMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();

            MasterProductSetupMdl masterProductSetupMdlList = _PolicyDal.GetMasterProductSetUpByProductCodeForPol(_MasterProductSetupMdl);
            return masterProductSetupMdlList;
        }


        [HttpGet]
        [Route("IsDuplicateMasterCode")]
        public bool IsDuplicateMasterCode(string _Json)
        {
            MasterProductSetupMdl _MasterProductSetupMdl = JsonConvert.DeserializeObject<MasterProductSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();

            bool  _duplicationCheck = _ProductSetupDal.IsDuplicateMasterProductSetup(_MasterProductSetupMdl);
            return _duplicationCheck;
        }

        [HttpGet]
        [Route("GetAllProductCodeOfMasterProductSetUp")]
        public List<MasterProductSetupMdl> GetAllProductCodeOfMasterProductSetup()
        {
           
            OpenPolicyDal _OpenPolicyDal = new OpenPolicyDal();

            List<MasterProductSetupMdl> masterProductSetupMdlList = _OpenPolicyDal.GetProductCodeOfMasterProductSetUp();
            return masterProductSetupMdlList;
        }

        [HttpGet]
        [Route("ProductCodeByClientForPol")]
        public List<MasterProductSetupMdl> ProductCodeByClientForPol(string _Json)
        {
            MasterProductSetupMdl _MasterProductSetupMdl = JsonConvert.DeserializeObject<MasterProductSetupMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();

            List<MasterProductSetupMdl> masterProductSetupMdlList = _PolicyDal.ProductCodeByClient(_MasterProductSetupMdl);
            return masterProductSetupMdlList;
        }


        [HttpGet]
        [Route("GetMasterProductSetUpByPCode")]
        public MasterProductSetupMdl GetConditionsByPCode(string _Json)
        {
            MasterProductSetupMdl _MasterProductSetupMdl = JsonConvert.DeserializeObject<MasterProductSetupMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();



            MasterProductSetupMdl masterProductSetupMdl = new MasterProductSetupMdl();

            masterProductSetupMdl = _PolicyDal.GetMasterProductByProductCode(_MasterProductSetupMdl);
            return masterProductSetupMdl;
        }

        [HttpGet]
        [Route("ProductCodeByClientNo")]
        public List<MasterProductSetupMdl> ProductCodeByClientNoForPol()
        {
            PolicyDal _PolicyDal = new PolicyDal();

            List<MasterProductSetupMdl> masterProductSetupMdlList = _PolicyDal.ProductCodeWithNoClient();
            return masterProductSetupMdlList;
        }


    }
}
