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
    [RoutePrefix("InsCoInsurance")]
    public class InsCoInsuranceController : ApiController
    {

        [HttpGet]
        [Route("GetInsCoInsurance")]
        public InsCoInsurance AddMtrVContribution(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);

            InsCoInsurance _InsCoInsurance = JsonConvert.DeserializeObject<InsCoInsurance>(_Json);

            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            InsCoInsurance InsCoInsuranceList = _VehicleDetailDal.CalcCoContribution(_VehicleDetailMdl, _InsCoInsurance);
            return InsCoInsuranceList;
        }


        [HttpGet]
        [Route("UpdateInsCoInsurance")]
        public InsCoInsurance UpdateMtrVColor(string _Json)

        {
            InsCoInsurance _InsCoInsurance = JsonConvert.DeserializeObject<InsCoInsurance>(_Json);

            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            InsCoInsurance _InsCoInsuranceList = _VehicleDetailDal.UpdateCalcCoContribution(_InsCoInsurance);
            return _InsCoInsuranceList;
        }


        [HttpGet]
        [Route("UpdateInsCoInsuranceByElement")]
        public InsCoInsurance UpdateInsCoInsuranceByElement(string _Json)

        {
            InsCoInsurance _InsCoInsurance = JsonConvert.DeserializeObject<InsCoInsurance>(_Json);
            CoInsElementMdl _CoInsElementMdl = JsonConvert.DeserializeObject<CoInsElementMdl>(_Json);

            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();
            

            InsCoInsurance _InsCoInsuranceList = _VehicleDetailDal.UpdateCalcCoContributionByElement(_InsCoInsurance, _CoInsElementMdl);
            return _InsCoInsuranceList;
        }


        [HttpGet]
        [Route("GetAllInsCoInsurance")]
        public List<InsCoInsurance> GetAllMtrVContribution(string _Json)
        {
            VehicleDetailMdl _VehicleDetailMdl = JsonConvert.DeserializeObject<VehicleDetailMdl>(_Json);

           

            VehicleDetailDal _VehicleDetailDal = new VehicleDetailDal();

            List<InsCoInsurance> InsCoInsuranceList = _VehicleDetailDal.GetAllCoContribution(_VehicleDetailMdl);
            return InsCoInsuranceList;
        }
    }
}
