using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using TmsPlusRetailAPI.Models;

namespace TmsPlusRetailAPI.DataLayer
{
    public class PurchaseProtectionDal
    {
        public PurchaseProtectionModel AddPurchaseProtection(PurchaseProtectionModel _purchaseProtection)

        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();
                SqlCommand _cmdSql;



                //Insert In Policy
                _sbSql.AppendLine("INSERT INTO Policy(");
                //_sbSql.AppendLine("SysID,");
                _sbSql.AppendLine("SysDate,");
                _sbSql.AppendLine("PolicyNo,");
                _sbSql.AppendLine("DocType,");
                _sbSql.AppendLine("IssueDate,");
                _sbSql.AppendLine("EffDate,");
                _sbSql.AppendLine("ExpDate,");
                _sbSql.AppendLine("ClassCode,");
                _sbSql.AppendLine("ProductCode)");

                _sbSql.AppendLine("output INSERTED. SysID VALUES ( ");
                // _sbSql.AppendLine("@SysID,");
                _sbSql.AppendLine("@SysDate,");
                _sbSql.AppendLine("@PolicyNo,");
                _sbSql.AppendLine("('7'),");
                _sbSql.AppendLine("@IssueDate,");
                _sbSql.AppendLine("@EffDate,");
                _sbSql.AppendLine("@ExpDate,");
                _sbSql.AppendLine("('02'),");
                _sbSql.AppendLine("@ProductCode)");


                _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                string PolicyNo = GetNewPolicyNo();
                string ProductCode = "5";



                _cmdSql.Parameters.AddWithValue("@SysDate", DateTime.Now);
                _cmdSql.Parameters.AddWithValue("@PolicyNo", PolicyNo.ToString());
                _cmdSql.Parameters.AddWithValue("@IssueDate", DateTime.Now);
                // _cmdSql.Parameters.AddWithValue("@ProductCode", ProductCode.ToString());

                //To Be Entered
                _cmdSql.Parameters.AddWithValue("@EffDate", DateTime.Now);
                _cmdSql.Parameters.AddWithValue("@ExpDate", DateTime.Now.AddDays(365));
                _cmdSql.Parameters.AddWithValue("@ProductCode", ProductCode);


                int _TxnSysId;
                _conSql.Open();
                _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                _conSql.Close();

               // _TxnSysId = _purchaseProtection.SysID ;


                //Insert In To Client

                SqlConnection _conSql2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql2 = new StringBuilder();
                SqlCommand _cmdSql2;

                _sbSql2.AppendLine("INSERT INTO Client(");
                // _sbSql2.AppendLine("SysID,");
                _sbSql2.AppendLine("SysDate,");
                _sbSql2.AppendLine("ParentSysID,");
                _sbSql2.AppendLine("NameOfInsured,");
                _sbSql2.AppendLine("DOB,");
                _sbSql2.AppendLine("NIC,");
                _sbSql2.AppendLine("GenderCode,");
                _sbSql2.AppendLine("MobileNo,");
                _sbSql2.AppendLine("Email,");
                _sbSql2.AppendLine("Address,");
                _sbSql2.AppendLine("CityCode)");


                _sbSql2.AppendLine("output INSERTED. SysID VALUES ( ");
                //_sbSql2.AppendLine("@SysID,");
                _sbSql2.AppendLine("@SysDate,");
                _sbSql2.AppendLine("@ParentSysID,");
                _sbSql2.AppendLine("@NameOfInsured,");
                _sbSql2.AppendLine("@DOB,");
                _sbSql2.AppendLine("@NIC,");
                _sbSql2.AppendLine("@GenderCode,");
                _sbSql2.AppendLine("@MobileNo,");
                _sbSql2.AppendLine("@Email,");
                _sbSql2.AppendLine("@Address,");
                _sbSql2.AppendLine("@CityCode)");




                _cmdSql2 = new SqlCommand(_sbSql2.ToString(), _conSql2);



                // _cmdSql.Parameters.AddWithValue("@SysID", _ClientMdlList[i].SysID);
                _cmdSql2.Parameters.AddWithValue("@SysDate", DateTime.Now);

                //To Be Entered
                _cmdSql2.Parameters.AddWithValue("@ParentSysID", _TxnSysId);
                _cmdSql2.Parameters.AddWithValue("@NameOfInsured", _purchaseProtection.NameOfInsured ?? DBNull.Value.ToString());
                _cmdSql2.Parameters.AddWithValue("@DOB", Convert.ToDateTime(_purchaseProtection.DOB));
                _cmdSql2.Parameters.AddWithValue("@NIC", _purchaseProtection.NIC ?? DBNull.Value.ToString());
                _cmdSql2.Parameters.AddWithValue("@GenderCode", _purchaseProtection.GenderCode ?? DBNull.Value.ToString());
                _cmdSql2.Parameters.AddWithValue("@MobileNo", _purchaseProtection.MobileNo ?? DBNull.Value.ToString());
                _cmdSql2.Parameters.AddWithValue("@Email", _purchaseProtection.Email ?? DBNull.Value.ToString());
                _cmdSql2.Parameters.AddWithValue("@Address", _purchaseProtection.Address ?? DBNull.Value.ToString());
                _cmdSql2.Parameters.AddWithValue("@CityCode", _purchaseProtection.CityCode ?? DBNull.Value.ToString());

                int _TxnSysId2;
                _conSql2.Open();
                _TxnSysId2 = (Int32)_cmdSql2.ExecuteScalar();
                _conSql2.Close();

                _purchaseProtection.SysID = _TxnSysId2;


                //Insert In To Contribution

                SqlConnection _conSql3 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql3 = new StringBuilder();
                SqlCommand _cmdSql3;


                _sbSql3.AppendLine("INSERT INTO Contribution(");
                //_sbSql3.AppendLine("SysID,");
                _sbSql3.AppendLine("SysDate,");
                _sbSql3.AppendLine("ParentSysID,");
                _sbSql3.AppendLine("SumCovered,");
                _sbSql3.AppendLine("Gross,");
                _sbSql3.AppendLine("FED,");
                _sbSql3.AppendLine("FIF,");
                _sbSql3.AppendLine("SD,");
                _sbSql3.AppendLine("Net)");



                _sbSql3.AppendLine("output INSERTED. SysID VALUES ( ");
                // _sbSql3.AppendLine("@SysID,");
                _sbSql3.AppendLine("@SysDate,");
                _sbSql3.AppendLine("@ParentSysID,");
                _sbSql3.AppendLine("@PurchasedValue,");
                _sbSql3.AppendLine("@Gross,");
                _sbSql3.AppendLine("@FED,");
                _sbSql3.AppendLine("@FIF,");
                _sbSql3.AppendLine("@SD,");
                _sbSql3.AppendLine("@Net)");




                _cmdSql3 = new SqlCommand(_sbSql3.ToString(), _conSql3);




                // _cmdSql2.Parameters.AddWithValue("@SysID", _ContributionMdlList[i].SysID);

                _cmdSql3.Parameters.AddWithValue("@SysDate", DateTime.Now);
                _cmdSql3.Parameters.AddWithValue("@ParentSysID", _TxnSysId);
                _cmdSql3.Parameters.AddWithValue("@PurchasedValue", _purchaseProtection.PurchasedValue);

                decimal Gross, Net, FED = 13, FIF = 1, Stamp = 50;

                //hard coded rate
                _purchaseProtection.ContributionRate = Convert.ToDecimal(3.5);


                Net = (_purchaseProtection.PurchasedValue * (_purchaseProtection.ContributionRate / 100));
                Gross = (Net - Stamp) / (((FED + FIF) / 100) + 1);


                _cmdSql3.Parameters.AddWithValue("@Gross", Gross);
                _cmdSql3.Parameters.AddWithValue("@FED", FED);
                _cmdSql3.Parameters.AddWithValue("@FIF", FIF);
                _cmdSql3.Parameters.AddWithValue("@SD", Stamp);
                _cmdSql3.Parameters.AddWithValue("@Net", Net);


                int _TxnSysId3;
                _conSql3.Open();
                _TxnSysId3 = (Int32)_cmdSql3.ExecuteScalar();
                _conSql3.Close();

                //Insert Into Purcahse Protection

                SqlConnection _conSql4 =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql4 = new StringBuilder();
                SqlCommand _cmdSql4;

                _sbSql4.AppendLine("INSERT INTO PurchaseProtection(");
                _sbSql4.AppendLine("SysDate,");
                _sbSql4.AppendLine("ParentSysID,");
                _sbSql4.AppendLine("ProductID,");
                _sbSql4.AppendLine("InvoiceNo,");
                _sbSql4.AppendLine("OrderNo,");
                _sbSql4.AppendLine("OrderTracker,");
                _sbSql4.AppendLine("DeliveryStatus,");
                _sbSql4.AppendLine("CashOnDelivery,");
                _sbSql4.AppendLine("PaymentGateway,");
                _sbSql4.AppendLine("PurchasedValue,");
                _sbSql4.AppendLine("ContributionRate)");

                _sbSql4.AppendLine("output INSERTED. SysID VALUES ( ");
                _sbSql4.AppendLine("@SysDate,");
                _sbSql4.AppendLine("@ParentSysID,");
                _sbSql4.AppendLine("@ProductID,");
                _sbSql4.AppendLine("@InvoiceNo,");
                _sbSql4.AppendLine("@OrderNo,");
                _sbSql4.AppendLine("@OrderTracker,");
                _sbSql4.AppendLine("@DeliveryStatus,");
                _sbSql4.AppendLine("@CashOnDelivery,");
                _sbSql4.AppendLine("@PaymentGateway,");
                _sbSql4.AppendLine("@PurchasedValue,");
                _sbSql4.AppendLine("@ContributionRate)");


                _cmdSql4 = new SqlCommand(_sbSql4.ToString(), _conSql4);

                _cmdSql4.Parameters.AddWithValue("@SysDate", DateTime.Now);
                _cmdSql4.Parameters.AddWithValue("@ParentSysID", _TxnSysId);

                _cmdSql4.Parameters.AddWithValue("@ProductID", Convert.ToInt32(_purchaseProtection.ProductID));
                _cmdSql4.Parameters.AddWithValue("@InvoiceNo", _purchaseProtection.InvoiceNo);
                _cmdSql4.Parameters.AddWithValue("@OrderNo", _purchaseProtection.OrderNo);
                _cmdSql4.Parameters.AddWithValue("@OrderTracker", _purchaseProtection.OrderTracker);
                _cmdSql4.Parameters.AddWithValue("@DeliveryStatus", _purchaseProtection.DeliveryStatus);
                _cmdSql4.Parameters.AddWithValue("@CashOnDelivery", _purchaseProtection.CashOnDelivery);
                _cmdSql4.Parameters.AddWithValue("@PaymentGateway", _purchaseProtection.PaymentGateway);
                _cmdSql4.Parameters.AddWithValue("@PurchasedValue", _purchaseProtection.PurchasedValue);
                _cmdSql4.Parameters.AddWithValue("@ContributionRate", _purchaseProtection.ContributionRate);


                int _TxnSysId4;
                _conSql4.Open();
                _TxnSysId4 = (Int32)_cmdSql4.ExecuteScalar();
                _conSql4.Close();
                _purchaseProtection.SysID = _TxnSysId4;

                return _purchaseProtection;



            }
            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);


                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Purchase Protection DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }



        }

        //For Increment of Policy Number For Main
        public static string GetNewPolicyNo()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(PolicyNo) LastPolicyNo FROM Policy ";

                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                string _result;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows[0][0] == null || _tbl.Rows[0][0] == DBNull.Value)
                {
                    _result = "1";
                }
                else
                {
                    string _tmpNumber = (Convert.ToInt32(_tbl.Rows[0][0]) + 1).ToString();
                    _result = _tmpNumber;
                }

                return _result;
            }
            catch (Exception ex)
            {
                return "0";
            }

        }
    }
}