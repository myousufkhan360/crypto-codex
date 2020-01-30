using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using CrmApi.DataAccessLayer;
using CrmApi.Models;

namespace CrmApi.Controllers
{
    [RoutePrefix("WelcomeCall")]
    public class WelcomeCallController : ApiController
    {
        [HttpGet]
        [Route("GetPendingList")]
        // GET: api/WelcomeCall
        public List<WelcomeCallMDL> GetPendingList()
        {
            try
            {
                WelcomeCallDAL _WelcomeCallDAL = new WelcomeCallDAL();
                return _WelcomeCallDAL.GetPendingList();
                
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
