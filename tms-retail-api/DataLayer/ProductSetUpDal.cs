using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using static TmsPlusRetailAPI.Models.ProductSetupMdl;

namespace TmsPlusRetailAPI.DataLayer
{
    public class ProductSetUpDal
    {

        //for adding new Product SetUp For Motors
        public ProductSetUp AddProductSetUpMtr(ProductSetUp _ProductSetUp)
        {
            try
            {

               
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("INSERT INTO ProductSetUp(");
                   // _sbSql.AppendLine("SysID,");
                    _sbSql.AppendLine("SysDate,");
                    _sbSql.AppendLine("ProductCode,");
                    _sbSql.AppendLine("ProductName,");
                    _sbSql.AppendLine("Tenure,");
                    _sbSql.AppendLine("Rate,");
                    _sbSql.AppendLine("PolicyTypeCode,");
                    _sbSql.AppendLine("ClassCode,");
                    _sbSql.AppendLine("FixedContribution)");

                    _sbSql.AppendLine("output INSERTED. SysID VALUES ( ");
                    //_sbSql.AppendLine("@SysID,");
                    _sbSql.AppendLine("@SysDate,");
                    _sbSql.AppendLine("@ProductCode,");
                    _sbSql.AppendLine("@ProductName,");
                    _sbSql.AppendLine("@Tenure,");
                    _sbSql.AppendLine("@Rate,");
                    _sbSql.AppendLine("@PolicyTypeCode,");
                    _sbSql.AppendLine("('02'),");
                    _sbSql.AppendLine("@FixedContribution)");


                _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);


               // _cmdSql.Parameters.AddWithValue("@SysID", _ProductSetUpMdlList[i].SysID);
                _cmdSql.Parameters.AddWithValue("@SysDate", DateTime.Now);
                _cmdSql.Parameters.AddWithValue("@Tenure", 365);
                string ProductCode = GetProductCode(_ProductSetUp);
                _cmdSql.Parameters.AddWithValue("@ProductCode", ProductCode.ToString());

                //To Be Entered
                _cmdSql.Parameters.AddWithValue("@ProductName", _ProductSetUp.ProductName);
                _cmdSql.Parameters.AddWithValue("@Rate", _ProductSetUp.Rate);
                _cmdSql.Parameters.AddWithValue("@FixedContribution", _ProductSetUp.FixedContribution);
                _cmdSql.Parameters.AddWithValue("@PolicyTypeCode", _ProductSetUp.PolicyTypeCode);

                //Get String
                _ProductSetUp.PolicyTypeName = GetPolicyTypeNameByCode(_ProductSetUp.PolicyTypeCode);


                int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();

                _ProductSetUp.SysID = _TxnSysId;
                return _ProductSetUp;

            }
            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //for adding new Product SetUp For Travel
        public ProductSetUp AddProductSetUpTrvl(ProductSetUp _ProductSetUp)
        {
            try
            {


                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();
                SqlCommand _cmdSql;

                _sbSql.AppendLine("INSERT INTO ProductSetUp(");
                // _sbSql.AppendLine("SysID,");
                _sbSql.AppendLine("SysDate,");
                _sbSql.AppendLine("ProductCode,");
                _sbSql.AppendLine("ProductName,");
                _sbSql.AppendLine("Tenure,");
                _sbSql.AppendLine("Rate,");
                _sbSql.AppendLine("PolicyTypeCode,");
                _sbSql.AppendLine("ClassCode,");
                _sbSql.AppendLine("FixedContribution)");

                _sbSql.AppendLine("output INSERTED. SysID VALUES ( ");
                //_sbSql.AppendLine("@SysID,");
                _sbSql.AppendLine("@SysDate,");
                _sbSql.AppendLine("@ProductCode,");
                _sbSql.AppendLine("@ProductName,");
                _sbSql.AppendLine("@Tenure,");
                _sbSql.AppendLine("@Rate,");
                _sbSql.AppendLine("@PolicyTypeCode,");
                _sbSql.AppendLine("('03'),");
                _sbSql.AppendLine("@FixedContribution)");


                _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);


                // _cmdSql.Parameters.AddWithValue("@SysID", _ProductSetUpMdlList[i].SysID);
                _cmdSql.Parameters.AddWithValue("@SysDate", DateTime.Now);
                string ProductCode = GetProductCode(_ProductSetUp);
                _cmdSql.Parameters.AddWithValue("@ProductCode", ProductCode.ToString());

                int i=0;
                string[] TenureNum = Regex.Split(_ProductSetUp.Tenure, @"\D+");

                foreach (string value in TenureNum)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                         i = int.Parse(value);
                    }
                }



                //To Be Entered
                _cmdSql.Parameters.AddWithValue("@ProductName", _ProductSetUp.ProductName);
                _cmdSql.Parameters.AddWithValue("@Rate", _ProductSetUp.Rate);
                _cmdSql.Parameters.AddWithValue("@FixedContribution", _ProductSetUp.FixedContribution);
                _cmdSql.Parameters.AddWithValue("@Tenure", i);
                _cmdSql.Parameters.AddWithValue("@PolicyTypeCode", _ProductSetUp.PolicyTypeCode);

                //Get String
                _ProductSetUp.PolicyTypeName = GetPolicyTypeNameByCode(_ProductSetUp.PolicyTypeCode);

                int _TxnSysId;
                _conSql.Open();
                _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                _conSql.Close();

                _ProductSetUp.SysID = _TxnSysId;
                return _ProductSetUp;






            }
            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //Get Product For Motors
        public List<ProductSetUp> GetProductSetUpMtr()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM ProductSetUp WHERE ClassCode = 2";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductSetUp> _ProductSetUpList = new List<ProductSetUp>();
                ProductSetUp _ProductSetUp;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _ProductSetUp = new ProductSetUp();
                    

                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ProductSetUp = new ProductSetUp();
                        _ProductSetUp.ProductCode = _tbl.Rows[i]["ProductCode"].ToString();
                        _ProductSetUp.ProductName = _tbl.Rows[i]["ProductName"].ToString();

                        _ProductSetUpList.Add(_ProductSetUp);
                    }

                    return _ProductSetUpList;
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //Get Product For Travel
        public List<ProductSetUp> GetProductSetUpTrvl()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM ProductSetUp WHERE ClassCode = 3";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductSetUp> _ProductSetUpList = new List<ProductSetUp>();
                ProductSetUp _ProductSetUp;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _ProductSetUp = new ProductSetUp();


                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ProductSetUp = new ProductSetUp();
                        _ProductSetUp.ProductCode = _tbl.Rows[i]["ProductCode"].ToString();
                        _ProductSetUp.ProductName = _tbl.Rows[i]["ProductName"].ToString();

                        _ProductSetUpList.Add(_ProductSetUp);
                    }

                    return _ProductSetUpList;
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }


        //For Increment of Product Code For Product SetUp
        public static string GetProductCode(ProductSetUp _ProductSetUp)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(ProductCode) LastProductCode FROM ProductSetUp ";

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

        //Getting Policy Type Name By Code (100 or 101)
        public static string GetPolicyTypeNameByCode(int _PolicyTypeCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                ProductSetUp _ProductSetUp;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM PolicyTypeProductSetup Where PolicyTypeCode = @PolicyTypeCode", conn);

                    command.Parameters.Add(new SqlParameter("@PolicyTypeCode", _PolicyTypeCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _ProductSetUp = new ProductSetUp();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _ProductSetUp.PolicyTypeName = _tblSqla.Rows[i]["PolicyTypeName"].ToString();

                    }
                    return _ProductSetUp.PolicyTypeName;

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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }


    }
}