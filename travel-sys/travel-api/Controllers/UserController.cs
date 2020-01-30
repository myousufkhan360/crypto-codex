using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TakafulSetup.Api.Data;
using TakafulSetup.Api.Models;

namespace TakafulSetup.Api.Controllers
{
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("ValidateUserCredential")]
        // GET: api/User
        public bool ValidateUserCredential(string _UserString)
        {
            bool _result;
            UserDAL _UserDAL = new UserDAL();

            //Conversion of string into JSON object
            UserMDL _UserMDL = JsonConvert.DeserializeObject<UserMDL>(_UserString);

            _result = _UserDAL.ValidateUserCredentials(_UserMDL);
            

            return _result;
        }

        [HttpGet]
        [Route("TestService")]
        // GET: api/User
        public string TestService()
        {
            
            return "Service is working fine";
        }


    }
}
