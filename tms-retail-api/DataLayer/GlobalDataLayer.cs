using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using static TmsPlusRetailAPI.Models.GlobalModels;
using static TmsPlusRetailAPI.Models.MtrVehicleDetails;
using static TmsPlusRetailAPI.Models.ProductSetupMdl;
using static TmsPlusRetailAPI.Models.TrvlPortalMdl;

namespace TmsPlusRetailAPI.DataLayer
{
    public class GlobalDataLayer
    {


        //For Increment of Policy Number For Main
        public static string GetPolicyNo(Policy _Policy)
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

        //For Increment of Product Code For Main
        public static string GetProductCode(Policy _Policy)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(ProductCode) LastProductCode FROM Policy ";

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

        //Getting Policy Class Name By Code
        public static string GetPolicyClassNameByCode(string _PolicyClassCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
               
                DataTable _tblSqla = new DataTable();
                Policy _Policy = new Policy();


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM PolicyClassProductSetup Where PolicyClassCode = @PolicyClassCode", conn);

                    command.Parameters.Add(new SqlParameter("@PolicyClassCode", _PolicyClassCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _Policy = new Policy();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _Policy.ClassName = _tblSqla.Rows[i]["PolicyClassName"].ToString();

                    }
                    return _Policy.ClassName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //Getting Doc Type Name By Code (1 or 2)
        public static string GetDocTypeNameByDocTypeCode(string _DocTypeCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                Policy _Policy;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM DocumentType Where DocTypeCode = @DocTypeCode", conn);

                    command.Parameters.Add(new SqlParameter("@DocTypeCode", _DocTypeCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _Policy = new Policy();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _Policy.DocName = _tblSqla.Rows[i]["DocTypeName"].ToString();

                    }
                    return _Policy.DocName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }


        //Getting Gender Name By Code
        public static string GetGenderNameByCode(string _GenderCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                Client _Client;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM Genders Where GenderCode = @GenderCode", conn);

                    command.Parameters.Add(new SqlParameter("@GenderCode", _GenderCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _Client = new Client();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _Client.GenderName = _tblSqla.Rows[i]["GenderName"].ToString();

                    }
                    return _Client.GenderName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);


                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //Getting City Name By Code
        public static string GetCityNameByCode(string _CityCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                Client _Client;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrCity Where CITY_CODE = @CityCode", conn);

                    command.Parameters.Add(new SqlParameter("@CityCode", _CityCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _Client = new Client();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _Client.CityName = _tblSqla.Rows[i]["CITY_NAME"].ToString();

                    }
                    return _Client.CityName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //Getting Product Name By Code
        public static string GetProductNameByCode(string _ProductCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());                
                DataTable _tblSqla = new DataTable();
                ProductSetUp _ProductSetUp;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM ProductSetUp Where ProductCode = @ProductCode", conn);

                    command.Parameters.Add(new SqlParameter("@ProductCode", _ProductCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _ProductSetUp = new ProductSetUp();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _ProductSetUp.ProductName = _tblSqla.Rows[i]["ProductName"].ToString();

                    }
                    return _ProductSetUp.ProductName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);


                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //for getting all Document Type(1 or 2)
        public List<DocumentTypeMdl> GetDocumentType()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM DocumentType";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<DocumentTypeMdl> _DocumentTypeMdlList = new List<DocumentTypeMdl>();
                DocumentTypeMdl _DocumentTypeMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _DocumentTypeMdl = new DocumentTypeMdl();

                        _DocumentTypeMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _DocumentTypeMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _DocumentTypeMdl.DocTypeCode = _tblSqla.Rows[i]["DocTypeCode"].ToString();
                        _DocumentTypeMdl.DocTypeName = _tblSqla.Rows[i]["DocTypeName"].ToString();



                        _DocumentTypeMdlList.Add(_DocumentTypeMdl);


                    }

                    return _DocumentTypeMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //To get All Genders
        public List<GendersMdl> GetGenders()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM Genders";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<GendersMdl> _GendersMdlList = new List<GendersMdl>();
                GendersMdl _GendersMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _GendersMdl = new GendersMdl();

                        _GendersMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _GendersMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _GendersMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _GendersMdl.GenderCode = _tblSqla.Rows[i]["GenderCode"].ToString();
                        _GendersMdl.GenderName = _tblSqla.Rows[i]["GenderName"].ToString();



                        _GendersMdlList.Add(_GendersMdl);


                    }

                    return _GendersMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //Get Relation Name By Code
        public static string GetRelationNameByCode(int _RelationCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                DataTable _tblSqla = new DataTable();
                TrvlFamilyDetailsRisk _TrvlFamilyDetailsRisk;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM Relations Where RelationCode = @RelationCode", conn);

                    command.Parameters.Add(new SqlParameter("@RelationCode", _RelationCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _TrvlFamilyDetailsRisk = new TrvlFamilyDetailsRisk();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _TrvlFamilyDetailsRisk.FamilyRelationName = _tblSqla.Rows[i]["RelationName"].ToString();

                    }
                    return _TrvlFamilyDetailsRisk.FamilyRelationName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        public PurchaseProtection AddPurchaseProtection(PurchaseProtection _purchaseProtection)
        {
            try
            {
                SqlConnection _conSql =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();
                SqlCommand _cmdSql;

                _sbSql.AppendLine("INSERT INTO PurchaseProtection (");
                _sbSql.AppendLine("@ProductID,");
                _sbSql.AppendLine("@InvoiceNo,");
                _sbSql.AppendLine("@OrderNo,");
                _sbSql.AppendLine("@OrderTracker,");
                _sbSql.AppendLine("@DeliveryStatus,");
                _sbSql.AppendLine("@CashOnDelivery,");
                _sbSql.AppendLine("@PaymentGateway)");

                _sbSql.AppendLine("output INSERTED. SysID VALUES ( ");
                _sbSql.AppendLine("@ProductID,");
                _sbSql.AppendLine("@InvoiceNo,");
                _sbSql.AppendLine("@OrderNo,");
                _sbSql.AppendLine("@OrderTracker,");
                _sbSql.AppendLine("@DeliveryStatus,");
                _sbSql.AppendLine("@CashOnDelivery,");
                _sbSql.AppendLine("@PaymentGateway)");


                _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                _cmdSql.Parameters.AddWithValue("@ProductID", Convert.ToInt32(_purchaseProtection.ProductID));
                _cmdSql.Parameters.AddWithValue("@InvoiceNo", _purchaseProtection.InvoiceNo);
                _cmdSql.Parameters.AddWithValue("@OrderNo", _purchaseProtection.OrderNo);
                _cmdSql.Parameters.AddWithValue("@OrderTracker", _purchaseProtection.OrderTracker);
                _cmdSql.Parameters.AddWithValue("@DeliveryStatus", _purchaseProtection.DeliveryStatus);
                _cmdSql.Parameters.AddWithValue("@CashOnDelivery", _purchaseProtection.CashOnDelivery);
                _cmdSql.Parameters.AddWithValue("@PaymentGateway", _purchaseProtection.PaymentGateway);


                int _TxnSysId;
                _conSql.Open();
                _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                _conSql.Close();
                _purchaseProtection.SysID = _TxnSysId;

                return _purchaseProtection;



            }
            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }

        }

        //To create an Error Log For Exception
        public static string CreateExceptionLog(string Exp, string Mdl,string method,string line)
        {
            string _fileName = "c:\\ErrorsLogs\\ErrorsLog_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";

            if (File.Exists(_fileName))
            {
                using (StreamWriter _StreamWriter = File.AppendText(_fileName))
                {
                    _StreamWriter.WriteLine("");
                    _StreamWriter.WriteLine("");
                    _StreamWriter.WriteLine("==================================================");
                    _StreamWriter.WriteLine("Takaful Pakistan Limited");
                    _StreamWriter.WriteLine("Takaful Management System - Product Setup Log");
                    _StreamWriter.WriteLine("Error Accured at : " + DateTime.Now);
                    _StreamWriter.WriteLine("Error From : " + Mdl);
                    _StreamWriter.WriteLine("Error from Method : " + method);
                    _StreamWriter.WriteLine("Error Accured at Line Number : " + line);
                    _StreamWriter.WriteLine("Exception has Accured:" + Exp);
                    _StreamWriter.WriteLine("==================================================");
                    //   _StreamWriter.WriteLine("");
                    //  _StreamWriter.WriteLine("");

                    // _StreamWriter.WriteLine(
                    //    "========================ERROR LOG==========================");
                    // _StreamWriter.WriteLine("Exception has Accured:"+Exp);


                    // _StreamWriter.WriteLine(
                    //       "===========================================================");
                    return _fileName;
                }
            }

            else
            {
                StringBuilder _sb = new StringBuilder();
                List<TxnError> _txnError = new List<TxnError>();


                _sb.AppendLine("==================================================");
                _sb.AppendLine("Takaful Pakistan Limited");
                _sb.AppendLine("Takaful Retail API");
                _sb.AppendLine("Error From : " + Mdl);
                _sb.AppendLine("Error from Method : " + method);
                _sb.AppendLine("Error Accured at Line Number : " + line);
                _sb.AppendLine("Error Accured at : " + DateTime.Now);
                _sb.AppendLine("Exception has Accured:" + Exp);
                _sb.AppendLine("==================================================");
                //   _sb.AppendLine("");
                // _sb.AppendLine("Errors From Product Setup System");
                //  _sb.AppendLine("");

                // _sb.AppendLine(
                //   "========================ERROR LOG==========================");

                // _sb.AppendLine("Exception has Accured:" + Exp);


                //  _sb.AppendLine(
                //    "===========================================================");


                if (!Directory.Exists("c:\\ErrorsLogs\\"))
                {

                    Directory.CreateDirectory("c:\\ErrorsLogs\\");

                }

                File.WriteAllText(_fileName, _sb.ToString());

                return _fileName;
            }
        }


    }
}