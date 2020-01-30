using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TmsPlusRetailAPI.DataLayer;
using static TmsPlusRetailAPI.Models.ProductSetupMdl;

namespace TmsPlusRetailAPI.Controllers
{

    [RoutePrefix("ProductSetUp")]
    public class ProductSetUpController : ApiController
    {

        [HttpGet]
        [Route("GetMtrProductSetUp")]
        public List<ProductSetUp> GetMtrProductSetUp()
        {
            ProductSetUpDal _ProductSetUpDal = new ProductSetUpDal();
            List<ProductSetUp> _ProductSetUpList = new List<ProductSetUp>();

            _ProductSetUpList = _ProductSetUpDal.GetProductSetUpMtr();
            return _ProductSetUpList;
        }

        [HttpGet]
        [Route("GetTrvlProductSetUp")]
        public List<ProductSetUp> GetTrvlProductSetUp()
        {
            ProductSetUpDal _ProductSetUpDal = new ProductSetUpDal();
            List<ProductSetUp> _ProductSetUpList = new List<ProductSetUp>();

            _ProductSetUpList = _ProductSetUpDal.GetProductSetUpTrvl();
            return _ProductSetUpList;
        }


        [HttpGet]
        [Route("AddMtrProductSetUp")]
        public ProductSetUp AddMtrProductSetUp(string _Json)
        {
            ProductSetUp _ProductSetUp = JsonConvert.DeserializeObject<ProductSetUp>(_Json);
            ProductSetUpDal _ProductSetUpDal = new ProductSetUpDal();

            ProductSetUp ProductSetUpList = _ProductSetUpDal.AddProductSetUpMtr(_ProductSetUp);
            return ProductSetUpList;
        }

        [HttpGet]
        [Route("AddTrvlProductSetUp")]
        public ProductSetUp AddTrvlProductSetUp(string _Json)
        {
            ProductSetUp _ProductSetUp = JsonConvert.DeserializeObject<ProductSetUp>(_Json);
            ProductSetUpDal _ProductSetUpDal = new ProductSetUpDal();

            ProductSetUp ProductSetUpList = _ProductSetUpDal.AddProductSetUpTrvl(_ProductSetUp);
            return ProductSetUpList;
        }


    }
}
