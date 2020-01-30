using Newtonsoft.Json;
using ProductSetupApi.DataLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ProductSetupApi.Models.MtrVehicleDetailMdl;

namespace ProductSetupApi.Controllers
{
    [RoutePrefix("CalcContribution")]
    public class CalcController : ApiController
    {

        [HttpGet]
        [Route("Calc")]
        public Calc AddMtrVColor(string _Json)
        {
            Calc _Calc = JsonConvert.DeserializeObject<Calc>(_Json);
            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            Calc Calc = _VehicleDetailDal.GetCalc(_Calc);
            return Calc;
        }

    }
}
