using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TmsPlusRetailAPI.Models
{
    public class GlobalModels
    {

        //For Duplication
        public class DuplicationCheck
        {
            public bool IsDuplicate { get; set; }
        }

        //For Error
        public class TxnError
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public string ErrorCode { get; set; }
            public string Error { get; set; }

        }

        //For General Header
        public class Policy
        {
            public int SysID { get; set; }
            public DateTime SysDate { get; set; }
            public string PolicyNo { get; set; }
            public string DocType { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime EffDate { get; set; }
            public DateTime ExpDate { get; set; }
            public string ClassCode { get; set; }
            public string ProductCode { get; set; }

            public Client client { get; set; }
            public Contribution contribution { get; set; }
          //  public PurchaseProtection purchaseProtection { get; set; }

            //To Get Names
            public string ClassName { get; set;}
            public string DocName { get; set; }
            public string ProductName { get; set; }

        }

        //For All Clients
        public class Client
        {
            public int ParentSysID { get; set; }
            public int SysID { get; set; }
            public string NameOfInsured { get; set; }
            public string PolicyNo { get; set; }
            public DateTime DOB { get; set; }
            public string NIC { get; set; }
            public string GenderCode { get; set; }
            public string MobileNo { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string CityCode { get; set; }

            //Get String
            public string GenderName { get; set; }
            public string CityName { get; set; }

            //For Health
            public string EmpID { get; set; }
            public string HltID { get; set; }
            public int PlanID { get; set; }

            //To Get Health String
            public string PlanName { get; set; }

        }

        //For Contribution Calculation
        public class Contribution
        {
            public int ParentSysID { get; set; }
            public int SysID { get; set; }
            public decimal SumCovered { get; set; }
            public decimal Gross { get; set; }
            public decimal FED { get; set; }
            public decimal FIF { get; set; }
            public decimal SD { get; set; }
            public decimal Net { get; set; }

            //For Travel
            public int ModeOfPayment { get; set; }
            public string PaymentNo { get; set; }
            public string PaymentName { get; set; }

            //Get Name Strings
            public string ModeOfPaymentName { get; set; }

        }

        //For Document Type
        public class DocumentTypeMdl
        {

            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public string DocTypeCode { get; set; }
            public string DocTypeName { get; set; }
        }

        //For Genders
        public class GendersMdl
        {
            public int TxnSysID { get; set; }
            public DateTime TxnSysDate { get; set; }
            public int UserCode { get; set; }
            public string GenderCode { get; set; }
            public string GenderName { get; set; }

        }

        //For Purchase Protection
        public class PurchaseProtection 
        {
            public int SysID { get; set; }
            public DateTime SysDate { get; set; }
            public int ParentSysID { get; set; }
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
}