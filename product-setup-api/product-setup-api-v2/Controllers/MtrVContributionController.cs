using Newtonsoft.Json;
using ProductSetupApi.DataLayers;
using ProductSetupApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ProductSetupApi.Models.MtrEndorsementMdl;
using static ProductSetupApi.Models.MtrVehicleDetailMdl;

namespace ProductSetupApi.Controllers
{
    [RoutePrefix("MtrVContribution")]

    public class MtrVContributionController : ApiController
    {

        [HttpGet]
        [Route("GetMtrVContribution")]
        public List<MtrVContributionMdl> AddMtrVContribution(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            List<MtrVContributionMdl> MtrVContributionMdl = _VehicleDetailDal.CalcContribution(_VehicleDetailMdl);
            return MtrVContributionMdl;
        }

        [HttpGet]
        [Route("GetMtrVContributionForPol")]
        public List<MtrVContributionMdl> AddMtrVContributionForPol(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            List<MtrVContributionMdl> MtrVContributionMdl = _VehicleDetailDal.CalcContributionForPol(_VehicleDetailMdl);
            return MtrVContributionMdl;
        }

        [HttpGet]
        [Route("GetAllMtrVContribution")]
        public List<MtrVContributionMdl> GetMtrVContribution(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            List<MtrVContributionMdl> MtrVContributionMdl = _VehicleDetailDal.GetContributionByTxnSysID(_VehicleDetailMdl);
            return MtrVContributionMdl;
        }

        [HttpGet]
        [Route("GetMtrVDForEndt")]
        public VehicleDetailMdl GetMtrVDForEndt(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);
            EndtReasonMdl _EndtReasonMdl = JsonConvert.DeserializeObject<EndtReasonMdl>(_Json);
            

            EndorsementDal _EndorsementDal = new EndorsementDal();

            VehicleDetailMdl MtrVContributionMdlList = _EndorsementDal.GetEndorsement(_VehicleDetailMdl, _EndtReasonMdl);
            return MtrVContributionMdlList;
        }

        [HttpGet]
        [Route("UpdateMtrVContribution")]
        public List<MtrVContributionMdl> UpdateMtrVContribution(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

           List<MtrVContributionMdl> MtrVContributionMdl = _VehicleDetailDal.UpdateCalcContribution(_VehicleDetailMdl);
            return MtrVContributionMdl;
        }
    }
}
