using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TmsPlusRetailAPI.DataLayer;
using static TmsPlusRetailAPI.Models.TrvlPortalMdl;

namespace TmsPlusRetailAPI.Controllers
{
    [RoutePrefix("ddlTrvlPayMethod")]
    public class TrvlPaymentMethodController : ApiController
    {

        [HttpGet]
        [Route("GetPaymentMethodList")]
        public List<ddlPaymentMethod> GetPaymentMethodList()
        {
            TrvlPortalDal _TrvlPortalDal = new TrvlPortalDal();
            List<ddlPaymentMethod> _ddlPaymentMethodList = new List<ddlPaymentMethod>();

            _ddlPaymentMethodList = _TrvlPortalDal.GetPaymentMethodList();
            return _ddlPaymentMethodList;
        }

    }
}
