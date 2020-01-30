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
    [RoutePrefix("ProductConditionsSetUp")]
    public class ProductConditionsSetUpController : ApiController
    {
        [HttpGet]
        [Route("GetProductConditionsSetUp")]
        public List<ProductConditionsSetupMdl> GetMasterCodes(string _Json)
        {
            ProductConditionsSetupMdl _ProductConditionsSetupMdl = JsonConvert.DeserializeObject<ProductConditionsSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();


            
            List<ProductConditionsSetupMdl> _ProductConditionsSetUpMdlList = new List<ProductConditionsSetupMdl>();

            _ProductConditionsSetUpMdlList = _ProductSetupDal.GetProductCondonditionsSetUp(_ProductConditionsSetupMdl);
            return _ProductConditionsSetUpMdlList;
        }


        [HttpGet]
        [Route("AddProductConditionsSetUp")]
        public ProductConditionsSetupMdl AddProductConditionsSetUpMdl(string _Json)
        {
            ProductConditionsSetupMdl _ProductConditionsSetupMdl = JsonConvert.DeserializeObject<ProductConditionsSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();

            ProductConditionsSetupMdl productConditionsSetUpMdl = _ProductSetupDal.AddProductConditionsSetUp(_ProductConditionsSetupMdl);
            return productConditionsSetUpMdl;
        }

        [HttpGet]
        [Route("UpdateProductConditionsSetUp")]
        public ProductConditionsSetupMdl UpdateMasterCodes(string _Json)
        {
            ProductConditionsSetupMdl _ProductConditionsSetUpMdl = JsonConvert.DeserializeObject<ProductConditionsSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();

            ProductConditionsSetupMdl productConditionsSetUpMdl = _ProductSetupDal.UpdateProductConditionsSetUp(_ProductConditionsSetUpMdl);
            return _ProductConditionsSetUpMdl;
        }

        [HttpGet]
        [Route("IsDuplicateProductConditionsSetUp")]
        public bool IsDuplicateMasterCode(string _Json)
        {
            ProductConditionsSetupMdl _ProductConditionsSetUpMdl = JsonConvert.DeserializeObject<ProductConditionsSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();


            bool _duplicationCheck = _ProductSetupDal.IsDuplicateProductConditionsSetUp(_ProductConditionsSetUpMdl);
            return _duplicationCheck;
        }


        [HttpGet]
        [Route("GetConditionByClient")]
        public List<ProductConditionsSetupMdl> GetConditionByClient(string _Json)
        {
            ProductClientMdl _ProductClientMdl = JsonConvert.DeserializeObject<ProductClientMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();



            List<ProductConditionsSetupMdl> _ProductConditionsSetUpMdl = new List<ProductConditionsSetupMdl>();

            _ProductConditionsSetUpMdl = _VehicleDetailDal.GetConditionByClient(_ProductClientMdl);
            return _ProductConditionsSetUpMdl;
        }

        [HttpGet]
        [Route("GetConditionsByPCode")]
        public List<ProductConditionsSetupMdl> GetConditionsByPCode(string _Json)
        {
            MasterProductSetupMdl _MasterProductSetupMdl = JsonConvert.DeserializeObject<MasterProductSetupMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();



            List<ProductConditionsSetupMdl> _ProductConditionsSetupMdl = new List<ProductConditionsSetupMdl>();

            _ProductConditionsSetupMdl = _PolicyDal.GetConditionsByPCode(_MasterProductSetupMdl);
            return _ProductConditionsSetupMdl;
        }

    }
}
