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
    [RoutePrefix("ProductTrackerSetup")]
    public class ProductTrackerSetupController : ApiController
    {
        [HttpGet]
        [Route("GetProductTrackerSetupMdl")]
        public List<ProductTrackerSetupMdl> GetTrackerSetup(string _Json)
        {
            ProductTrackerSetupMdl _ProductTrackerSetupMdl = JsonConvert.DeserializeObject<ProductTrackerSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();



            List<ProductTrackerSetupMdl> _ProductTrackerSetupMdlList = new List<ProductTrackerSetupMdl>();

            _ProductTrackerSetupMdlList = _ProductSetupDal.GetProductTrackerSetup(_ProductTrackerSetupMdl);
            return _ProductTrackerSetupMdlList;
        }


        [HttpGet]
        [Route("AddProductTrackerSetupMdl")]
        public ProductTrackerSetupMdl AddProductTrackerSetupMdl(string _Json)
        {
            ProductTrackerSetupMdl _ProductTrackerSetupMdl = JsonConvert.DeserializeObject<ProductTrackerSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();

            ProductTrackerSetupMdl productTrackerSetupMdl = _ProductSetupDal.AddProductTrackerSetup(_ProductTrackerSetupMdl);
            return productTrackerSetupMdl;
        }

        [HttpGet]
        [Route("UpdateProductTrackerSetupMdl")]
        public ProductTrackerSetupMdl UpdateMasterCodes(string _Json)
        {
            ProductTrackerSetupMdl _ProductTrackerSetupMdl = JsonConvert.DeserializeObject<ProductTrackerSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();

            ProductTrackerSetupMdl productTrackerSetupMdl = _ProductSetupDal.UpdateProductTrackerSetup(_ProductTrackerSetupMdl);
            return productTrackerSetupMdl;
        }


        [HttpGet]
        [Route("GetTrackerSetup")]
        public List<ProductTrackerSetupMdl> GetConditionByClient(string _Json)
        {
            ProductClientMdl _ProductClientMdl = JsonConvert.DeserializeObject<ProductClientMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();



            List<ProductTrackerSetupMdl> _ProductTrackerSetupMdl = new List<ProductTrackerSetupMdl>();

            _ProductTrackerSetupMdl = _VehicleDetailDal.GetTrackerByClient(_ProductClientMdl);
            return _ProductTrackerSetupMdl;
        }


        [HttpGet]
        [Route("GetTrackerByPCode")]
        public List<ProductTrackerSetupMdl> GetTrackerByPCode(string _Json)
        {
            MasterProductSetupMdl _MasterProductSetupMdl = JsonConvert.DeserializeObject<MasterProductSetupMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();



            List<ProductTrackerSetupMdl> _ProductTrackerSetupMdl = new List<ProductTrackerSetupMdl>();

            _ProductTrackerSetupMdl = _PolicyDal.GetTrackerByPCode(_MasterProductSetupMdl);
            return _ProductTrackerSetupMdl;
        }

        [HttpGet]
        [Route("GetTrackerAmount")]
        public ProductTrackerSetupMdl GetTrackerAmount(string _Json)
        {
            ProductTrackerSetupMdl _ProductTrackerSetupMdl = JsonConvert.DeserializeObject<ProductTrackerSetupMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();



            ProductTrackerSetupMdl productTrackerSetupMdl = new ProductTrackerSetupMdl();

            productTrackerSetupMdl = _PolicyDal.GetTrackerAmount(_ProductTrackerSetupMdl);
            return productTrackerSetupMdl;
        }

    }
}
