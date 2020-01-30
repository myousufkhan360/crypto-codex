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
    [RoutePrefix("ProductWarrantiesSetup")]
    public class ProductWarrantiesSetupController : ApiController
    {

        [HttpGet]
        [Route("GetProductWarrantiesSetup")]
        public List<ProductWarrantiesSetupMdl> GetProductWarrantiesSetup(string _Json)
        {
            ProductWarrantiesSetupMdl _ProductWarrantiesSetupMdl = JsonConvert.DeserializeObject<ProductWarrantiesSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();
            List<ProductWarrantiesSetupMdl> _ProductWarrantiesSetupMdlList = new List<ProductWarrantiesSetupMdl> ();

            _ProductWarrantiesSetupMdlList = _ProductSetupDal.GetProductWarrantiesSetup(_ProductWarrantiesSetupMdl);
            return _ProductWarrantiesSetupMdlList;
        }

        [HttpGet]
        [Route("AddProductWarrantiesSetup")]
        public ProductWarrantiesSetupMdl AddProductWarrantiesSetup(string _Json)
        {
            ProductWarrantiesSetupMdl _ProductWarrantiesSetupMdl = JsonConvert.DeserializeObject<ProductWarrantiesSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();

            ProductWarrantiesSetupMdl ProductWarrantiesSetupMdlList = _ProductSetupDal.AddProductWarrantiesSetup(_ProductWarrantiesSetupMdl);
            return ProductWarrantiesSetupMdlList;
        }

        [HttpGet]
        [Route("UpdateProductWarrantiesSetup")]
        public ProductWarrantiesSetupMdl UpdateProductWarrantiesSetup(string _Json)
        {
            ProductWarrantiesSetupMdl _ProductWarrantiesSetupMdl = JsonConvert.DeserializeObject<ProductWarrantiesSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();

            ProductWarrantiesSetupMdl productWarrantiesSetupMdl = _ProductSetupDal.UpdateProductWarrantiesSetup(_ProductWarrantiesSetupMdl);
            return productWarrantiesSetupMdl;
        }

        [HttpGet]
        [Route("IsDuplicateProductWarrantiesSetup")]
        public bool IsDuplicateMasterCode(string _Json)
        {
            ProductWarrantiesSetupMdl _ProductWarrantiesSetupMdl = JsonConvert.DeserializeObject<ProductWarrantiesSetupMdl>(_Json);
            ProductSetupDal _ProductSetupDal = new ProductSetupDal();


            bool _duplicationCheck = _ProductSetupDal.IsDuplicateProductWarrantiesSetup(_ProductWarrantiesSetupMdl);
            return _duplicationCheck;
        }

        [HttpGet]
        [Route("GetWarrantyByClient")]
        public List<ProductWarrantiesSetupMdl> GetWarrantyByClient(string _Json)
        {
            ProductClientMdl _ProductClientMdl = JsonConvert.DeserializeObject<ProductClientMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();



            List<ProductWarrantiesSetupMdl> _ProductWarrantiesSetupMdl = new List<ProductWarrantiesSetupMdl>();

            _ProductWarrantiesSetupMdl = _VehicleDetailDal.GetWarrantyByClient(_ProductClientMdl);
            return _ProductWarrantiesSetupMdl;
        }

        [HttpGet]
        [Route("GetWarrantiesByPCode")]
        public List<ProductWarrantiesSetupMdl> GetConditionsByPCode(string _Json)
        {
            MasterProductSetupMdl _MasterProductSetupMdl = JsonConvert.DeserializeObject<MasterProductSetupMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();



            List<ProductWarrantiesSetupMdl> _ProductWarrantiesSetupMdl = new List<ProductWarrantiesSetupMdl>();

            _ProductWarrantiesSetupMdl = _PolicyDal.GetWarantiesByPCode(_MasterProductSetupMdl);
            return _ProductWarrantiesSetupMdl;
        }

    }
}
