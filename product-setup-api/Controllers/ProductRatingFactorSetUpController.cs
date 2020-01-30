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
    [RoutePrefix("ProductRatingFactorSetUp")]
    public class ProductRatingFactorSetUpController : ApiController
    {
        [HttpGet]
        [Route("GetProductRatingFactorSetUp")]
        public List<ProductRatingFactorSetUpMdl> GetProductRatingFactorSetUpMdl(string _Json)
        {
            
                ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl = JsonConvert.DeserializeObject<ProductRatingFactorSetUpMdl>(_Json);
                ProductSetupDal _ProductSetupDal = new ProductSetupDal();
                List<ProductRatingFactorSetUpMdl> _ProductRatingFactorSetUpMdlList = new List<ProductRatingFactorSetUpMdl>();

                _ProductRatingFactorSetUpMdlList = _ProductSetupDal.GetProductRatingFactorSetUp(_ProductRatingFactorSetUpMdl);
                return _ProductRatingFactorSetUpMdlList;
            
        }

        [HttpGet]
        [Route("AddProductRatingFactorSetUp")]
        public ProductRatingFactorSetUpMdl AddProductRatingFactorSetUpMdl(string _Json)
        {
            ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl = JsonConvert.DeserializeObject<ProductRatingFactorSetUpMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();

            ProductRatingFactorSetUpMdl ProductRatingFactorSetUpMdlList = _ProductSetupDal.AddProductRatingFactorSetUp(_ProductRatingFactorSetUpMdl);
            return ProductRatingFactorSetUpMdlList;
        }

        [HttpGet]
        [Route("UpdateProductRatingFactorSetUp")]
        public ProductRatingFactorSetUpMdl UpdateMasterCodes(string _Json)
        {
            ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl = JsonConvert.DeserializeObject<ProductRatingFactorSetUpMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();

            ProductRatingFactorSetUpMdl productRatingFactorSetUpMdl = _ProductSetupDal.UpdateProductRatingFactorSetUp(_ProductRatingFactorSetUpMdl);
            return productRatingFactorSetUpMdl;
        }

        [HttpGet]
        [Route("IsDuplicateProductRatingFactorSetUp")]
        public bool IsDuplicateMasterCode(string _Json)
        {
            ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl = JsonConvert.DeserializeObject<ProductRatingFactorSetUpMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();

            bool _duplicationCheck = _ProductSetupDal.IsDuplicateProductRatingFactorSetUp(_ProductRatingFactorSetUpMdl);
            return _duplicationCheck;
        }


        [HttpGet]
        [Route("GetRatingFactorByOpol")]
        public ProductRatingFactorSetUpMdl GetRating(string _Json)
        {
            MtrOpenPolicyMdl _MtrOpenPolicyMdl = JsonConvert.DeserializeObject<MtrOpenPolicyMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            ProductRatingFactorSetUpMdl productRatingFactorSetUpMdl = _VehicleDetailDal.GetRatingFactor(_MtrOpenPolicyMdl);
            return productRatingFactorSetUpMdl;
        }

        [HttpGet]
        [Route("GetRatingFactorByPCode")]
        public List<ProductRatingFactorSetUpMdl> GetRiderByPCode(string _Json)
        {
            MasterProductSetupMdl _MasterProductSetupMdl = JsonConvert.DeserializeObject<MasterProductSetupMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();



            List<ProductRatingFactorSetUpMdl> _ProductRatingFactorSetUpMdl = new List<ProductRatingFactorSetUpMdl>();

            _ProductRatingFactorSetUpMdl = _PolicyDal.GetRatingFactorByPCode(_MasterProductSetupMdl);
            return _ProductRatingFactorSetUpMdl;
        }

        [HttpGet]
        [Route("GetRatingFactorRate")]
        public ProductRatingFactorSetUpMdl GetRiderAmount(string _Json)
        {
            ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl = JsonConvert.DeserializeObject<ProductRatingFactorSetUpMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();



            ProductRatingFactorSetUpMdl productRatingFactorSetUpMdl = new ProductRatingFactorSetUpMdl();

            productRatingFactorSetUpMdl = _PolicyDal.GetRatingFactorRate(_ProductRatingFactorSetUpMdl);
            return productRatingFactorSetUpMdl;
        }

    }
}
