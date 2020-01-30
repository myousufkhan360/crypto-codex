using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TmsPlusRetailAPI.Models
{
    public class PurchaseProtectionModel
    {
        public int SysID { get; set; }
        public DateTime SysDate { get; set; }
        public string PolicyNo { get; set; }

        public string NameOfInsured { get; set; }
        public DateTime DOB { get; set; }
        public string NIC { get; set; }
        public string GenderCode { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CityCode { get; set; }

        public decimal PurchaseValue { get; set; }
        public decimal Net { get; set; }

        public string ProductID { get; set; }
        public string InvoiceNo { get; set; }
        public string OrderNo { get; set; }
        public string OrderTracker { get; set; }
        public string DeliveryStatus { get; set; }
        public string CashOnDelivery { get; set; }
        public string PaymentGateway { get; set; }
        public decimal PurchasedValue { get; set; }
        public decimal ContributionRate { get; set; }



    }
}