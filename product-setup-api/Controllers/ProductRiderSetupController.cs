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
    [RoutePrefix("ProductRiderSetup")]
    public class ProductRiderSetupController : ApiController
    {

        [HttpGet]
        [Route("GetProductRiderSetup")]
        public List<ProductRiderSetupMdl> GetTrackerSetup(string _Json)
        {
            ProductRiderSetupMdl _ProductRiderSetupMdl = JsonConvert.DeserializeObject<ProductRiderSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();



            List<ProductRiderSetupMdl> _ProductRiderSetupMdlList = new List<ProductRiderSetupMdl>();

            _ProductRiderSetupMdlList = _ProductSetupDal.GetProductRiderSetup(_ProductRiderSetupMdl);
            return _ProductRiderSetupMdlList;
        }


        [HttpGet]
        [Route("AddProductRiderSetup")]
        public ProductRiderSetupMdl AddProductTrackerSetupMdl(string _Json)
        {
            ProductRiderSetupMdl _ProductRiderSetupMdl = JsonConvert.DeserializeObject<ProductRiderSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();

            ProductRiderSetupMdl productRiderSetupMdl = _ProductSetupDal.AddProductRiderSetup(_ProductRiderSetupMdl);
            return productRiderSetupMdl;
        }

        [HttpGet]
        [Route("UpdateProductRiderSetup")]
        public ProductRiderSetupMdl UpdateMasterCodes(string _Json)
        {
            ProductRiderSetupMdl _ProductRiderSetupMdl = JsonConvert.DeserializeObject<ProductRiderSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();

            ProductRiderSetupMdl productRiderSetupMdl = _ProductSetupDal.UpdateProductRiderSetup(_ProductRiderSetupMdl);
            return productRiderSetupMdl;
        }

        [HttpGet]
        [Route("GetProductRiderByClient")]
        public List<ProductRiderSetupMdl> GetProductRiderByClient(string _Json)
        {
            ProductClientMdl _ProductClientMdl = JsonConvert.DeserializeObject<ProductClientMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();



            List<ProductRiderSetupMdl> _ProductRiderSetupMdl = new List<ProductRiderSetupMdl>();

            _ProductRiderSetupMdl = _VehicleDetailDal.GetRidersByClient(_ProductClientMdl);
            return _ProductRiderSetupMdl;
        }

        [HttpGet]
        [Route("GetRiderByPCode")]
        public List<ProductRiderSetupMdl> GetRiderByPCode(string _Json)
        {
            MasterProductSetupMdl _MasterProductSetupMdl = JsonConvert.DeserializeObject<MasterProductSetupMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();



            List<ProductRiderSetupMdl> _ProductRiderSetupMdl = new List<ProductRiderSetupMdl>();

            _ProductRiderSetupMdl = _PolicyDal.GetRiderByPCode(_MasterProductSetupMdl);
            return _ProductRiderSetupMdl;
        }


        [HttpGet]
        [Route("GetRiderAmount")]
        public ProductRiderSetupMdl GetRiderAmount(string _Json)
        {
            ProductRiderSetupMdl _ProductRiderSetupMdl = JsonConvert.DeserializeObject<ProductRiderSetupMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();



            ProductRiderSetupMdl productRiderSetupMdl = new ProductRiderSetupMdl();

            productRiderSetupMdl = _PolicyDal.GetRiderAmount(_ProductRiderSetupMdl);
            return productRiderSetupMdl;
        }

    }
}
