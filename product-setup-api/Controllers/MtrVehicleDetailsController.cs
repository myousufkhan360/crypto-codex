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
using static ProductSetupApi.Models.MtrEndorsementMdl;
using static ProductSetupApi.Models.MtrVehicleDetailMdl;
using static ProductSetupApi.Models.OpenPolicyMdl;

namespace ProductSetupApi.Controllers
{
    [RoutePrefix("MtrVehicleDetails")]
    public class MtrVehicleDetailsController : ApiController
    {
   
            [HttpGet]
            [Route("GetMtrVehicleDetails")]
            public List<VehicleDetailMdl> GetVehicleDetailMdl(string _Json)
            {
            MtrOpenPolicyMdl _MtrOpenPolicyMdl = JsonConvert.DeserializeObject<MtrOpenPolicyMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<VehicleDetailMdl> _VehicleDetailMdlList = new List<VehicleDetailMdl>();

            _VehicleDetailMdlList = _VehicleDetailDal.GetVehicleDetail(_MtrOpenPolicyMdl);
            return _VehicleDetailMdlList;
            }

        [HttpGet]
        [Route("GetMtrVehicleDetailsForPol")]
        public List<VehicleDetailMdl> GetVehicleDetailMdlForPol(string _Json)
        {
            MtrInsPolicyMdl _MtrInsPolicyMdl = JsonConvert.DeserializeObject<MtrInsPolicyMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            List<VehicleDetailMdl> _VehicleDetailMdlList = new List<VehicleDetailMdl>();

            _VehicleDetailMdlList = _VehicleDetailDal.GetVehicleDetailForPol(_MtrInsPolicyMdl);
            return _VehicleDetailMdlList;
        }


        [HttpGet]
            [Route("AddMtrVehicleDetails")]
            public VehicleDetailMdl AddVehicleDetailMdl(string _Json)
            {

            VehicleDetailMdl _VehicleDetailMdl = new VehicleDetailMdl();
            try
            {
                _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);
            }

            catch(Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Json Error From Vehicle Details Controller");
            }
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            VehicleDetailMdl VehicleDetailMdlList = _VehicleDetailDal.AddVehicleDetail(_VehicleDetailMdl);
                return VehicleDetailMdlList;
            }

        [HttpGet]
        [Route("AddMtrVehicleDetailsForPol")]
        public VehicleDetailMdl AddVehicleDetailMdlForPol(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            VehicleDetailMdl VehicleDetailMdlList = _VehicleDetailDal.AddVehicleDetailForPol(_VehicleDetailMdl);
            return VehicleDetailMdlList;
        }

        [HttpGet]
        [Route("UpdateMtrVehicleDetails")]
        public VehicleDetailMdl UpdateVehicleDetailMdl(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            VehicleDetailMdl VehicleDetailMdlList = _VehicleDetailDal.UpdateVehicleDetail(_VehicleDetailMdl);
            return VehicleDetailMdlList;
        }

        [HttpGet]
        [Route("GetMtrVDByInfo")]
        public List<VehicleDetailMdl> GetMtrVDByInfo(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);
            MtrInsPolicyMdl _MtrInsPolicyMdl = JsonConvert.DeserializeObject<MtrInsPolicyMdl>(_Json);
            MtrSeByCertMdl _MtrSeByCertMdl = JsonConvert.DeserializeObject<MtrSeByCertMdl>(_Json);
            EndorsementDal _EndorsementDal = new EndorsementDal();

           List<VehicleDetailMdl> VehicleDetailMdlList = _EndorsementDal.GetVehicleDetail1(_VehicleDetailMdl, _MtrInsPolicyMdl, _MtrSeByCertMdl);
            return VehicleDetailMdlList;
        }

        [HttpGet]
        [Route("GetMtrVDByInfoForPol")]
        public List<VehicleDetailMdl> GetMtrVDByInfoForPol(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);
            MtrInsPolicyMdl _MtrInsPolicyMdl = JsonConvert.DeserializeObject<MtrInsPolicyMdl>(_Json);
            MtrSeByCertMdl _MtrSeByCertMdl = JsonConvert.DeserializeObject<MtrSeByCertMdl>(_Json);
            PolicyDal _PolicyDal = new PolicyDal();

            List<VehicleDetailMdl> VehicleDetailMdlList = _PolicyDal.GetVehicleDetailForPol(_VehicleDetailMdl, _MtrInsPolicyMdl, _MtrSeByCertMdl);
            return VehicleDetailMdlList;
        }

        [HttpGet]
        [Route("GetMtrVDByInfoForOPol")]
        public List<VehicleDetailMdl> GetMtrVDByInfoForOpol(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);
            MtrInsPolicyMdl _MtrInsPolicyMdl = JsonConvert.DeserializeObject<MtrInsPolicyMdl>(_Json);
            MtrSeByCertMdl _MtrSeByCertMdl = JsonConvert.DeserializeObject<MtrSeByCertMdl>(_Json);
            EndorsementDal _EndorsementDal = new EndorsementDal();

            List<VehicleDetailMdl> VehicleDetailMdlList = _EndorsementDal.GetVehicleDetailForOpol(_VehicleDetailMdl, _MtrInsPolicyMdl, _MtrSeByCertMdl);
            return VehicleDetailMdlList;
        }

       



        [HttpGet]
        [Route("GetMtrVDExp")]
        public VehicleDetailMdl GetMtrVDExp(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);
            
            EndorsementDal _EndorsementDal = new EndorsementDal();

            VehicleDetailMdl VehicleDetailMdl = _EndorsementDal.GetVehicleDetailsExp(_VehicleDetailMdl);
            return VehicleDetailMdl;
        }

        [HttpGet]
        [Route("CancelMtrVehicleDetails")]
        public VehicleDetailMdl CancelVehicleDetailMdl(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            VehicleDetailMdl VehicleDetailMdlList = _VehicleDetailDal.CancelVehicleDetail(_VehicleDetailMdl);
            return VehicleDetailMdlList;
        }

        [HttpGet]
        [Route("ForNonFEndorsement")]
        public VehicleDetailMdl ForNonFEndorsement(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);
            EndtReasonMdl _EndtReasonMdl = JsonConvert.DeserializeObject<EndtReasonMdl>(_Json);
            EndorsementDal _EndorsementDal = new EndorsementDal();

            VehicleDetailMdl VehicleDetailMdl = _EndorsementDal.GetNonFEndorsement(_VehicleDetailMdl, _EndtReasonMdl);
            return VehicleDetailMdl;
        }

        



    }
}
