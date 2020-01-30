using Newtonsoft.Json;
using ProductSetupApi.DataLayers;
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
    [RoutePrefix("Calculation")]
    public class CalculateController : ApiController
    {

        [HttpGet]
        [Route("GetCalcForEndor")]
        public List<Calculate> GetGetCalcForEndor(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);
            EndtReasonMdl _EndtReasonMdl = JsonConvert.DeserializeObject<EndtReasonMdl>(_Json);


            EndorsementDal _EndorsementDal = new EndorsementDal();

            List<Calculate> CalculateList = _EndorsementDal.CalculateNew(_VehicleDetailMdl, _EndtReasonMdl);
            return CalculateList;
        }
    }

}

