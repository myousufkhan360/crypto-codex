using Newtonsoft.Json;
using ProductSetupApi.DataLayers;
using ProductSetupApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductSetupApi.Controllers
{
    [RoutePrefix("Users")]
    public class UsersController : ApiController
    {

        [HttpGet]
        [Route("ValidateUserCredentials")]
        //Validate user credentials
        public UserToken ValidateUserCredentials(string _UserInfo)
        {
            UserMDL _userMdl = JsonConvert.DeserializeObject<UserMDL>(_UserInfo);
            UsersDAL _UsersDAL = new UsersDAL();
            UserToken _userToken = _UsersDAL.ValidateUserCredentials(_userMdl);

            return _userToken;
        }


        [HttpGet]
        [Route("ValidateUserToken")]
        //Validate user credentials
        public UserToken ValidateUserToken(string _UserInfo)
        {
            UserToken _userToken = JsonConvert.DeserializeObject<UserToken>(_UserInfo);
            UsersDAL _UsersDAL = new UsersDAL();

            _userToken = _UsersDAL.ValidateUserToken(_userToken);

            return _userToken;
        }

        [HttpGet]
        [Route("TokenExpiry")]
        //Validate user credentials
        public UserToken TokenExpiry(string _UserInfo)
        {
            UserToken _userToken = JsonConvert.DeserializeObject<UserToken>(_UserInfo);
            UsersDAL _UsersDAL = new UsersDAL();

            _userToken = _UsersDAL.TokenExpiry(_userToken);

            return _userToken;
        }

    }
}
