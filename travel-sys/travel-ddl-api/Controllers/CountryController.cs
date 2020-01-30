using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleAPI.Controllers
{
    [RoutePrefix("Country")]
    public class CountryController : ApiController
    {
        [HttpGet]
        [Route("GetCountryList")]
        // GET: api/Country
        public List<CountryModel> GetCountryList()
        {
            CountryModel _CountryModel;
            List<CountryModel> _CountryModelList = new List<CountryModel>();

            _CountryModel = new CountryModel();
            _CountryModel.CountryCode = 101;
            _CountryModel.CountryName = "Pakistan";
            _CountryModelList.Add(_CountryModel);

            _CountryModel = new CountryModel();
            _CountryModel.CountryCode = 102;
            _CountryModel.CountryName = "India";
            _CountryModelList.Add(_CountryModel);

            return _CountryModelList;

        }

        [HttpGet]
        [Route("GetCityList")]
        public List<CityModel> GetCityList(int _CountryCode)
        {
            CityModel _CityModel;
            List<CityModel> _CityModelList = new List<CityModel>();

            if (_CountryCode == 101)
            {
                _CityModel = new CityModel();
                _CityModel.CityCode = 101001;
                _CityModel.CityName = "Karachi";
                _CityModel.CountryCode = 101;
                _CityModelList.Add(_CityModel);

                _CityModel = new CityModel();
                _CityModel.CityCode = 101002;
                _CityModel.CityName = "Lahore";
                _CityModel.CountryCode = 101;
                _CityModelList.Add(_CityModel);

                _CityModel = new CityModel();
                _CityModel.CityCode = 101003;
                _CityModel.CityName = "Islamabad";
                _CityModel.CountryCode = 101;
                _CityModelList.Add(_CityModel);
            }
            else if (_CountryCode == 102)
            {
                _CityModel = new CityModel();
                _CityModel.CityCode = 102001;
                _CityModel.CityName = "Delhi";
                _CityModel.CountryCode = 102;
                _CityModelList.Add(_CityModel);

                _CityModel = new CityModel();
                _CityModel.CityCode = 102002;
                _CityModel.CityName = "Mumbai";
                _CityModel.CountryCode = 102;
                _CityModelList.Add(_CityModel);

                _CityModel = new CityModel();
                _CityModel.CityCode = 102003;
                _CityModel.CityName = "Chennai";
                _CityModel.CountryCode = 102;
                _CityModelList.Add(_CityModel);
            }

            return _CityModelList;

        }

        // GET: api/Country/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Country
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Country/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Country/5
        public void Delete(int id)
        {
        }
    }
}
