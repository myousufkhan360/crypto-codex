using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ddlAPI.Models;
using ddlAPI.DataLayers;
using Newtonsoft.Json;

namespace ddlAPI.Controllers
{
    [RoutePrefix("ddlTravel")]    
    public class ddlTravelController : ApiController
    {
        [HttpGet]
        [Route("GetTravelCategoryList")]
        // GET: api/ddlTravel
        public List<ddlTravelCategory> GetTravelCategoryList()
        {
            ddlTravelDataLayer _ddlTravelDataLayer = new ddlTravelDataLayer();
            List<ddlTravelCategory> _ddlTravelCategoryList = new List<ddlTravelCategory>();

            _ddlTravelCategoryList = _ddlTravelDataLayer.GetTravelCategoryList();
            return _ddlTravelCategoryList;
        }

        [HttpGet]
        [Route("getTravelPlansByCategory")]        
        public List<ddlTravelPlan> getTravelPlansByCategory(int _TravelCategoryCode)
        {
            ddlTravelDataLayer _ddlTravelDataLayer = new ddlTravelDataLayer();
            List<ddlTravelPlan> _ddlTravelPlanList = new List<ddlTravelPlan>();

            _ddlTravelPlanList = _ddlTravelDataLayer.getTravelPlansByCategory(_TravelCategoryCode);
            return _ddlTravelPlanList;
        }

        [HttpGet]
        [Route("GetTravelCoverageTypeList")]
        //for getting all Travel Coverage Type (DDL)
        public List<ddlTravelCoverageType> GetTravelCoverageTypeList()
        {
            ddlTravelDataLayer _ddlTravelDataLayer = new ddlTravelDataLayer();
            List<ddlTravelCoverageType> _ddlTravelCoverageTypeList = new List<ddlTravelCoverageType>();

            _ddlTravelCoverageTypeList = _ddlTravelDataLayer.GetTravelCoverageTypeList();
            return _ddlTravelCoverageTypeList;
        }

        [HttpGet]
        [Route("getTravelTenureList")]
        //for getting all Travel Tenures (DDL)
        public List<ddlTravelTenure> getTravelTenuresList(int _TravelCategoryCode, int _TravelPlanCode, int _TravelCoverageTypeCode)

        {
            ddlTravelDataLayer _ddlTravelDataLayer = new ddlTravelDataLayer();
            List<ddlTravelTenure> _ddlTravelTenureList = new List<ddlTravelTenure>();

            _ddlTravelTenureList = _ddlTravelDataLayer.getTravelTenureList(_TravelCategoryCode, _TravelPlanCode, _TravelCoverageTypeCode);
            return _ddlTravelTenureList;
        }

        [HttpGet]
        [Route("getTravelDestinationList")]
        //for getting Travel Destination
        public List<ddlTravelDestination> getTravelDestinationList(int _TravelCategoryCode)
        {
            ddlTravelDataLayer _ddlTravelDataLayer = new ddlTravelDataLayer();
            List<ddlTravelDestination> _ddlTravelDestinationList = new List<ddlTravelDestination>();

            _ddlTravelDestinationList = _ddlTravelDataLayer.getTravelDestinationList(_TravelCategoryCode);
            return _ddlTravelDestinationList;
        }

        [HttpGet]
        [Route("GetRelationList")]
        public List<ddlRelation> GetRelationList()
        {
            ddlTravelDataLayer _ddlTravelDataLayer = new ddlTravelDataLayer();
            List<ddlRelation> _ddlRelationList = new List<ddlRelation>();

            _ddlRelationList = _ddlTravelDataLayer.GetRelationList();
            return _ddlRelationList;
        }

        [HttpGet]
        [Route("GetPaymentMethodList")]
        public List<ddlPaymentMethod> GetPaymentMethodList()
        {
            ddlTravelDataLayer _ddlTravelDataLayer = new ddlTravelDataLayer();
            List<ddlPaymentMethod> _ddlPaymentMethodList = new List<ddlPaymentMethod>();

            _ddlPaymentMethodList = _ddlTravelDataLayer.GetPaymentMethodList();
            return _ddlPaymentMethodList;
        }

        [HttpGet]
        [Route("GetContribution")]
        //for getting all Travel Tenures (DDL)
        public TravelContribution GetContribution(int _TravelCategoryCode, int _TravelPlanCode, int _TravelCoverageTypeCode, int _TravelTenureCode)

        {
            ddlTravelDataLayer _ddlTravelDataLayer = new ddlTravelDataLayer();
            TravelContribution _TravelContribution = new TravelContribution();

            _TravelContribution = _ddlTravelDataLayer.GetContribution(_TravelCategoryCode, _TravelPlanCode, _TravelCoverageTypeCode, _TravelTenureCode);
            return _TravelContribution;
        }


        [HttpGet]
        [Route("CreateTravelPolicy")]
        //for getting all Travel Policy (DDL)
        public SubmitStatus CreateTravelPolicy(string _Json, string _familyJson)
        {
            TravelPolicy _TravelPolicy = JsonConvert.DeserializeObject<TravelPolicy>(_Json);
            //_TravelPolicy.TxnSysID = _TravelPolicy.TxnSysID;
            //_TravelPolicy.TxnSysDate = _TravelPolicy.TxnSysDate;
            _TravelPolicy.CategoryCode = _TravelPolicy.CategoryCode;
            _TravelPolicy.PlanCode = _TravelPolicy.PlanCode;
            _TravelPolicy.InsuredName = _TravelPolicy.InsuredName;
            _TravelPolicy.DOB = _TravelPolicy.DOB;
            _TravelPolicy.Email = _TravelPolicy.Email;
            _TravelPolicy.MobileNumber = _TravelPolicy.MobileNumber;
            _TravelPolicy.DestinationCode = _TravelPolicy.DestinationCode;
            _TravelPolicy.TravelWithCode = _TravelPolicy.TravelWithCode;
            _TravelPolicy.TravellingDate = _TravelPolicy.TravellingDate;
            _TravelPolicy.TenureCode = _TravelPolicy.TenureCode;
            _TravelPolicy.ContributionCode = _TravelPolicy.ContributionCode;
            _TravelPolicy.PaymentModeCode = _TravelPolicy.PaymentModeCode;


            ddlTravelDataLayer _ddlTravelDataLayer = new ddlTravelDataLayer();

            List<TravelFamilyDetails> _TravelFamilyDetails = JsonConvert.DeserializeObject<List<TravelFamilyDetails>>(_familyJson);

            SubmitStatus _submitStatus =  _ddlTravelDataLayer.CreateTravelPolicy(_TravelPolicy,_TravelFamilyDetails);
            return _submitStatus;

        }


    }
}
