using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TmsPlusRetailAPI.DataLayer;
using TmsPlusRetailAPI.Models;
using static TmsPlusRetailAPI.Models.GlobalModels;
using static TmsPlusRetailAPI.Models.HltPortalMdl;
using static TmsPlusRetailAPI.Models.MtrVehicleDetails;
using static TmsPlusRetailAPI.Models.TrvlPortalMdl;

namespace TmsPlusRetailAPI.Controllers
{
    [RoutePrefix("Policy")]
    public class PolicyController : ApiController
    {

        [HttpGet]
        [Route("AddPolicyMtr")]
        public Policy AddMtrPolicy(string _Json)
        {
            Policy _Policy = JsonConvert.DeserializeObject<Policy>(_Json);
            Client _Client = JsonConvert.DeserializeObject<Client>(_Json);
            MtrRisk _MtrRisk = JsonConvert.DeserializeObject<MtrRisk>(_Json);
           // PurchaseProtection _purchaseProtection = JsonConvert.DeserializeObject<PurchaseProtection>(_Json);

            VehicleDetailDal _MtrVehicleDetailsDal = new VehicleDetailDal();

            Policy policy = _MtrVehicleDetailsDal.AddPolicyMtr(_Policy,_Client,_MtrRisk);
            return policy;
        }


        [HttpGet]
        [Route("AddPolicyTrvl")]
        public Policy AddtrvlPolicy(string _Json)
        {
            Policy _Policy = JsonConvert.DeserializeObject<Policy>(_Json);
            Client _Client = JsonConvert.DeserializeObject<Client>(_Json);
            Contribution _Contribution = JsonConvert.DeserializeObject<Contribution>(_Json);
            TrvlRisk _TrvlRisk = JsonConvert.DeserializeObject<TrvlRisk>(_Json);
           // PurchaseProtection _purchaseProtection = JsonConvert.DeserializeObject<PurchaseProtection>(_Json);

            TrvlPortalDal _TrvlPortalDal = new TrvlPortalDal();

            Policy policy = _TrvlPortalDal.AddPolicyTrvl(_Policy, _Client, _Contribution, _TrvlRisk);
            return policy;
        }

        [HttpGet]
        [Route("AddPolicyHlt")]
        public Policy AddHltPolicy(string _Json)
        {
            Policy _Policy = JsonConvert.DeserializeObject<Policy>(_Json);
            Client _Client = JsonConvert.DeserializeObject<Client>(_Json);
            Contribution _Contribution = JsonConvert.DeserializeObject<Contribution>(_Json);
            HltRisk _HltRisk = JsonConvert.DeserializeObject<HltRisk>(_Json);
          //  PurchaseProtection _purchaseProtection = JsonConvert.DeserializeObject<PurchaseProtection>(_Json);

            HltPortalDal _HltPortalDal = new HltPortalDal();

            Policy policy = _HltPortalDal.AddPolicyHlt(_Policy, _Client, _HltRisk);
            return policy;
        }

        [HttpGet]
        [Route("AddPurchProtectPolicy")]
        // public PurchaseProtectionModel AddPurchProtectPolicy([FromBody] PurchaseProtectionModel purchaseProtectionModel)
        public PurchaseProtectionModel AddPurchProtectPolicy(string _Json)
        {
            PurchaseProtectionModel purchaseProtectionModel = JsonConvert.DeserializeObject<PurchaseProtectionModel>(_Json);
 
            PurchaseProtectionDal purchaseProtectionDal = new PurchaseProtectionDal();

            PurchaseProtectionModel purchaseProtectionModel1 = purchaseProtectionDal.AddPurchaseProtection(purchaseProtectionModel);
            return purchaseProtectionModel1;
        }
    }
}
