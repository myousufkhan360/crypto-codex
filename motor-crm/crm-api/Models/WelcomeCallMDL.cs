using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmApi.Models
{
    public class WelcomeCallMDL
    {
        public int TxnSysID { get; set; }
        public string PolicyNo { get; set; }
        public DateTime PolicyIssueDate { get; set; }
        public string ClientName { get; set; }
        public string ContactNumber { get; set; }
        public string RegistrationNo { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleSubMake { get; set; }
        public int VehicleModel { get; set; }
        public string VehicleColor { get; set; }
        public decimal VehicleValue { get; set; }
        public bool IsPending { get; set; }
    }
}