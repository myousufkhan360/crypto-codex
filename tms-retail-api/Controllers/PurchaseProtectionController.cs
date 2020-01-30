using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TmsPlusRetailAPI.DataLayer;
using static TmsPlusRetailAPI.Models.GlobalModels;

namespace TmsPlusRetailAPI.Controllers
{
    [RoutePrefix("PurchaseProtection")]
    public class PurchaseProtectionController : ApiController
    {
        [HttpGet]
        [Route("AddProductProtection")]
        public PurchaseProtection AddPurchaseProtection(string _Json)
        {
            PurchaseProtection _PurchaseProtection = JsonConvert.DeserializeObject<PurchaseProtection>(_Json);
            GlobalDataLayer _GlobalDataLayer = new GlobalDataLayer();

            PurchaseProtection PurchaseProtectionList = _GlobalDataLayer.AddPurchaseProtection(_PurchaseProtection);
            return PurchaseProtectionList;
        }

    }
}
