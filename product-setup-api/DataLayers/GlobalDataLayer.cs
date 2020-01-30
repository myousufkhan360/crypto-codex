using ProductSetupApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using static ProductSetupApi.Models.InsPolicyMdl;
using static ProductSetupApi.Models.MtrVehicleDetailMdl;
using static ProductSetupApi.Models.OpenPolicyMdl;

namespace ProductSetupApi.DataLayers
{
    public class GlobalDataLayer
    {

        public static int GetUserCodeById(int _userId)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT UserCode FROM [User] WHERE UserId='" + _userId + "'";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                int _result = 0;
                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _result = Convert.ToInt32(_tbl.Rows[0][0]);
                }
                else
                {
                    return -1;
                }

                return _result;
            }
            catch (Exception ex)
            {

                return -1;
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
                MtrOpenPolicyMdl _MtrOpenPolicyMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrDocumentType Where DocTypeCode = @DocTypeCode", conn);

                    command.Parameters.Add(new SqlParameter("@DocTypeCode", _DocTypeCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _MtrOpenPolicyMdl = new MtrOpenPolicyMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _MtrOpenPolicyMdl.DocTypeName = _tblSqla.Rows[i]["DocTypeName"].ToString();

                    }
                    return _MtrOpenPolicyMdl.DocTypeName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Getting IsFiler Name By Code (3 or 4)
        public static string GetIsFilerNameByIsFilerCode(string _IsFilerCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                MtrOpenPolicyMdl _MtrOpenPolicyMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrIsFiler Where IsFilerCode = @IsFilerCode", conn);

                    command.Parameters.Add(new SqlParameter("@IsFilerCode", _IsFilerCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _MtrOpenPolicyMdl = new MtrOpenPolicyMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _MtrOpenPolicyMdl.IsFilerName = _tblSqla.Rows[i]["IsFilerName"].ToString();

                    }
                    return _MtrOpenPolicyMdl.IsFilerName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Getting Calc Name By Code (5 or 6)
        public static string GetCalcNameByCalcCode(string _CalcCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                MtrOpenPolicyMdl _MtrOpenPolicyMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrCalcType Where CalcCode = @CalcCode", conn);

                    command.Parameters.Add(new SqlParameter("@CalcCode", _CalcCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _MtrOpenPolicyMdl = new MtrOpenPolicyMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _MtrOpenPolicyMdl.CalcName = _tblSqla.Rows[i]["CalcName"].ToString();

                    }
                    return _MtrOpenPolicyMdl.CalcName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Getting IsAuto Name By Code (7 or 8)
        public static string GetIsAutoNameByIsAutoCode(string _IsAutoCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                MtrOpenPolicyMdl _MtrOpenPolicyMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrIsAuto Where IsAutoCode = @IsAutoCode", conn);

                    command.Parameters.Add(new SqlParameter("@IsAutoCode", _IsAutoCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _MtrOpenPolicyMdl = new MtrOpenPolicyMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _MtrOpenPolicyMdl.IsAutoName = _tblSqla.Rows[i]["IsAutoName"].ToString();

                    }
                    return _MtrOpenPolicyMdl.IsAutoName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Getting Certificate Insurance Code by Policy Type Code
        public static ProductPolicyTypeMdl GetCertInsureCode(ProductPolicyTypeMdl _ProductPolicyTypeMdl1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT * FROM MtrCertificateInsurance";
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<ProductPolicyTypeMdl> _ProductPolicyTypeMdlList = new List<ProductPolicyTypeMdl>();
                ProductPolicyTypeMdl _ProductPolicyTypeMdl = new ProductPolicyTypeMdl();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM PolicyTypeProductSetup WHERE PolicyTypeCode = @PolicyTypeCode", conn);

                    command.Parameters.Add(new SqlParameter("@PolicyTypeCode", _ProductPolicyTypeMdl1.PolicyTypeCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


                // _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductPolicyTypeMdl = new ProductPolicyTypeMdl();

                        _ProductPolicyTypeMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _ProductPolicyTypeMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _ProductPolicyTypeMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();
                        _ProductPolicyTypeMdl.PolicyTypeName = _tblSqla.Rows[i]["PolicyTypeName"].ToString();
                        _ProductPolicyTypeMdl.CertInsureCode = _tblSqla.Rows[i]["CertInsureCode"].ToString();
                        _ProductPolicyTypeMdl.PolicyClassCode = _tblSqla.Rows[i]["PolicyClassCode"].ToString();
                        _ProductPolicyTypeMdl.PolicyClassName = GetPolicyClassNameByCode(_tblSqla.Rows[i]["PolicyClassCode"].ToString());
                        _ProductPolicyTypeMdl.CertInsureName = GetCertInsNameByCertInsCode(_tblSqla.Rows[i]["CertInsureCode"].ToString());

                        _ProductPolicyTypeMdlList.Add(_ProductPolicyTypeMdl);


                    }

                    return _ProductPolicyTypeMdl;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Getting Policy Class Name By Code
        public static string GetPolicyClassNameByCode(string _PolicyClassCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                ProductPolicyTypeMdl _ProductPolicyTypeMdl;

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
                    _ProductPolicyTypeMdl = new ProductPolicyTypeMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _ProductPolicyTypeMdl.PolicyClassName = _tblSqla.Rows[i]["PolicyClassName"].ToString();

                    }
                    return _ProductPolicyTypeMdl.PolicyClassName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Getting Product Name By Code
        public static string GetProductNameByProductCode(string _ProductCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                MtrOpenPolicyMdl _MtrOpenPolicyMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MasterProductSetup Where ProductCode = @ProductCode", conn);

                    command.Parameters.Add(new SqlParameter("@ProductCode", _ProductCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _MtrOpenPolicyMdl = new MtrOpenPolicyMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _MtrOpenPolicyMdl.ProductName = _tblSqla.Rows[i]["ProductName"].ToString();

                    }
                    return _MtrOpenPolicyMdl.ProductName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Getting Policy Type Name By Code (100 or 101)
        public static string GetPolicyTypeNameByPolicyTypeCode(string _PolicyTypeCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                MtrOpenPolicyMdl _MtrOpenPolicyMdl;

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
                    _MtrOpenPolicyMdl = new MtrOpenPolicyMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _MtrOpenPolicyMdl.PolicyTypeName = _tblSqla.Rows[i]["PolicyTypeName"].ToString();

                    }
                    return _MtrOpenPolicyMdl.PolicyTypeName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Getting Client Name By Code (25 or 26)
        public static string GetClientNameByClientCode(string _ClientCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                MtrOpenPolicyMdl _MtrOpenPolicyMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM ClientProductSetup Where ClientCode = @ClientCode", conn);

                    command.Parameters.Add(new SqlParameter("@ClientCode", _ClientCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _MtrOpenPolicyMdl = new MtrOpenPolicyMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _MtrOpenPolicyMdl.ClientName = _tblSqla.Rows[i]["ClientName"].ToString();

                    }
                    return _MtrOpenPolicyMdl.ClientName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Getting Agent Name By Code (20 or 21)
        public static string GetAgentNameByAgentCode(string _AgentCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                MtrOpenPolicyMdl _MtrOpenPolicyMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM AgentProductSetup Where AgentCode = @AgentCode", conn);

                    command.Parameters.Add(new SqlParameter("@AgentCode", _AgentCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _MtrOpenPolicyMdl = new MtrOpenPolicyMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _MtrOpenPolicyMdl.AgentName = _tblSqla.Rows[i]["AgentName"].ToString();

                    }
                    return _MtrOpenPolicyMdl.AgentName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Getting Certificate Insurance Name By Code
        public static string GetCertInsNameByCertInsCode(string _CertInsureCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                MtrOpenPolicyMdl _MtrOpenPolicyMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrCertificateInsurance Where CertInsureCode = @CertInsureCode", conn);

                    command.Parameters.Add(new SqlParameter("@CertInsureCode", _CertInsureCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _MtrOpenPolicyMdl = new MtrOpenPolicyMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _MtrOpenPolicyMdl.CertInsureName = _tblSqla.Rows[i]["CertInsureName"].ToString();

                    }
                    return _MtrOpenPolicyMdl.CertInsureName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //for getting all Document Type(1 or 2)
        public static List<MtrDocumentTypeMdl> GetDocumentType()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrDocumentType";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrDocumentTypeMdl> _MtrDocumentTypeMdlList = new List<MtrDocumentTypeMdl>();
                MtrDocumentTypeMdl _MtrDocumentTypeMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrDocumentTypeMdl = new MtrDocumentTypeMdl();

                        _MtrDocumentTypeMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrDocumentTypeMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrDocumentTypeMdl.DocTypeCode = _tblSqla.Rows[i]["DocTypeCode"].ToString();
                        _MtrDocumentTypeMdl.DocTypeName = _tblSqla.Rows[i]["DocTypeName"].ToString();



                        _MtrDocumentTypeMdlList.Add(_MtrDocumentTypeMdl);


                    }

                    return _MtrDocumentTypeMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //for getting all Is Auto (7 or 8)
        public static List<MtrIsAutoMdl> GetIsAuto()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrIsAuto";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrIsAutoMdl> _MtrIsAutoMdlList = new List<MtrIsAutoMdl>();
                MtrIsAutoMdl _MtrIsAutoMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrIsAutoMdl = new MtrIsAutoMdl();

                        _MtrIsAutoMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrIsAutoMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrIsAutoMdl.IsAutoCode = _tblSqla.Rows[i]["IsAutoCode"].ToString();
                        _MtrIsAutoMdl.IsAutoName = _tblSqla.Rows[i]["IsAutoName"].ToString();


                        _MtrIsAutoMdlList.Add(_MtrIsAutoMdl);


                    }

                    return _MtrIsAutoMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }


        //for getting all Calculation Types (5 or 6)
        public static List<MtrCalcTypeMdl> GetCalcType()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrCalcType";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrCalcTypeMdl> _MtrCalcTypeMdlList = new List<MtrCalcTypeMdl>();
                MtrCalcTypeMdl _MtrCalcTypeMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrCalcTypeMdl = new MtrCalcTypeMdl();

                        _MtrCalcTypeMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrCalcTypeMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrCalcTypeMdl.CalcCode = _tblSqla.Rows[i]["CalcCode"].ToString();
                        _MtrCalcTypeMdl.CalcName = _tblSqla.Rows[i]["CalcName"].ToString();


                        _MtrCalcTypeMdlList.Add(_MtrCalcTypeMdl);


                    }

                    return _MtrCalcTypeMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //for getting all IsFiler(3 or 4)
        public static List<MtrIsFilerMdl> GetIsFiler()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrIsFiler";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrIsFilerMdl> _MtrIsFilerMdlList = new List<MtrIsFilerMdl>();
                MtrIsFilerMdl _MtrIsFilerMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrIsFilerMdl = new MtrIsFilerMdl();

                        _MtrIsFilerMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrIsFilerMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrIsFilerMdl.IsFilerCode = _tblSqla.Rows[i]["IsFilerCode"].ToString();
                        _MtrIsFilerMdl.IsFilerName = _tblSqla.Rows[i]["IsFilerName"].ToString();



                        _MtrIsFilerMdlList.Add(_MtrIsFilerMdl);


                    }

                    return _MtrIsFilerMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }


        //for getting all Product Clients by Client Code (25 or 26)
        public static List<ProductClientMdl> GetClientByCode(ProductClientMdl _ProductClientMdl1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT * FROM ClientProductSetup WHERE ClientCode=" ;
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductClientMdl> _ProductClientMdlList = new List<ProductClientMdl>();
                ProductClientMdl _ProductClientMdl;


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM ClientProductSetup WHERE ClientCode = @ClientCode", conn);

                    command.Parameters.Add(new SqlParameter("@ClientCode", _ProductClientMdl1.ClientCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tbl);
                }


                // _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ProductClientMdl = new ProductClientMdl();
                        _ProductClientMdl.ClientCode = _tbl.Rows[i]["ClientCode"].ToString();
                        _ProductClientMdl.ClientName = _tbl.Rows[i]["ClientName"].ToString();
                        _ProductClientMdl.NtnNo = _tbl.Rows[i]["NtnNo"].ToString();
                        _ProductClientMdl.NicNo = _tbl.Rows[i]["NicNo"].ToString();
                        _ProductClientMdl.Address = _tbl.Rows[i]["Address"].ToString();
                        _ProductClientMdlList.Add(_ProductClientMdl);
                    }

                    return _ProductClientMdlList;
                }
                else
                {

                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Get Values from Product Setup On selection of Product Code
        public static MasterProductSetupMdl GetMasterProductSetUpByProductCode(MasterProductSetupMdl _MasterProductSetupMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM MasterProductSetup Where ProductCode = @ProductCode", conn);

                    command.Parameters.Add(new SqlParameter("@ProductCode", _MasterProductSetupMdl.ProductCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MasterProductSetupMdl = new MasterProductSetupMdl();

                        _MasterProductSetupMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MasterProductSetupMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        //_MasterProductSetupMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MasterProductSetupMdl.ProductCode = Convert.ToInt32(_tblSqla.Rows[i]["ProductCode"]);
                        _MasterProductSetupMdl.ProductName = _tblSqla.Rows[i]["ProductName"].ToString();
                        _MasterProductSetupMdl.IsClientBased = _tblSqla.Rows[i]["IsClientBased"].ToString();
                        _MasterProductSetupMdl.Client = _tblSqla.Rows[i]["Client"].ToString();
                        _MasterProductSetupMdl.Agent = _tblSqla.Rows[i]["Agent"].ToString();
                        _MasterProductSetupMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();

                        // _MasterProductSetupMdl.WarrantyCode = _tblSqla.Rows[i]["WarrantyCode"].ToString();
                        //  _MasterProductSetupMdl.ConditionCode = _tblSqla.Rows[i]["ConditionCode"].ToString();

                        _MasterProductSetupMdl.PolicyTypeName = GetPolicyTypeNameByPolicyTypeCode(_tblSqla.Rows[i]["PolicyTypeCode"].ToString());
                        _MasterProductSetupMdl.ClientName = GetClientNameByClientCode(_tblSqla.Rows[i]["Client"].ToString());
                        _MasterProductSetupMdl.AgentName = GetAgentNameByAgentCode(_tblSqla.Rows[i]["Agent"].ToString());

                        _MasterProductSetupMdlList.Add(_MasterProductSetupMdl);
                    }

                    return _MasterProductSetupMdl;
                }
                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //For Creation of Policy String
        public static string GetPolicyString(string _BranchCode, string _PolicyNo, int _SerialNo, string _PolicyTypeCode, string _ProductCode, string _PolicyMonth, string _PolicyYear)
        {
            string PolicyString = _BranchCode + "-1-" + _ProductCode + "-2-" + _PolicyTypeCode + "-" + _PolicyNo + "-" + _PolicyMonth + "-" + _PolicyYear;
            return PolicyString;
        }

        //For Increment of Serial Numbers
        public static int GetSerialNo(MtrOpenPolicyMdl _MtrOpenPolicyMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(SerialNo) LastSerialNo FROM MtrOpenPolicy";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                int _result;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows[0][0] == null)
                {
                    _result = 1;
                }
                else
                {
                    int _tmpNumber = Convert.ToInt32(_tbl.Rows[0][0]) + 1;
                    _result = _tmpNumber;
                }

                return _result;
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return 0;
            }

        }

        //Get new Policy No
        public static string GettingNewPolicyNo(MtrOpenPolicyMdl _MtrOpenPolicyMdl)
        {
            try
            {
                SqlConnection _conSql =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(PolicyNo) LastPolicyNo FROM MtrOpenPolicy";

                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                int _result = 0;
                _adpSql.Fill(_tbl);

                _result = _tbl.Rows[0][0].Equals(System.DBNull.Value) ? 1 : Convert.ToInt32(_tbl.Rows[0][0]) + 1;

                return _result.ToString();
            }
            catch (Exception ex)
            {

                int n = -1;
                return n.ToString();
            }
        }

        //Getting VEOD Name By Code
        public static string GetVEODNameByCode(int _VEODCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                VehicleDetailMdl _VehicleDetailMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrVEOD Where VEODCode = @VEODCode", conn);

                    command.Parameters.Add(new SqlParameter("@VEODCode", _VEODCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.VEODName = _tblSqla.Rows[i]["VEODName"].ToString();

                    }
                    return _VehicleDetailMdl.VEODName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Getting Vehicle Type Names by Codes
        public static string GetVehicleTypeNameByCode(string _VehicleTypeCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                VehicleDetailMdl _VehicleDetailMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrVehicleType Where VehicleTypeCode = @VehicleTypeCode", conn);

                    command.Parameters.Add(new SqlParameter("@VehicleTypeCode", _VehicleTypeCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.VehicleTypeName = _tblSqla.Rows[i]["VehicleTypeName"].ToString();

                    }
                    return _VehicleDetailMdl.VehicleTypeName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Getting Vehical Name By Code
        public static string GetVehicleNameByCode(int _VEHICLE_CODE)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                VehicleDetailMdl _VehicleDetailMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrVehicle Where VEHICLE_CODE = @VEHICLE_CODE", conn);

                    command.Parameters.Add(new SqlParameter("@VEHICLE_CODE", _VEHICLE_CODE));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.VehicleName = _tblSqla.Rows[i]["VEHICLE_NAME"].ToString();

                    }
                    return _VehicleDetailMdl.VehicleName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
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
                VehicleDetailMdl _VehicleDetailMdl;

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
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.GenderName = _tblSqla.Rows[i]["GenderName"].ToString();

                    }
                    return _VehicleDetailMdl.GenderName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Get District/Area Name by Code
        public static string GetAreaNameByCode(int _DISTRICT_CODE)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                VehicleDetailMdl _VehicleDetailMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrDistrict Where DISTRICT_CODE = @DISTRICT_CODE", conn);

                    command.Parameters.Add(new SqlParameter("@DISTRICT_CODE", _DISTRICT_CODE));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.AreaName = _tblSqla.Rows[i]["DISTRICT_NAME"].ToString();

                    }
                    return _VehicleDetailMdl.AreaName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Get Cert Type Name by Code
        public static string GetCertTypeByCode(string _CERTIFICATE_CODE)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                VehicleDetailMdl _VehicleDetailMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrInsCert Where CERTIFICATE_CODE = @CERTIFICATE_CODE", conn);

                    command.Parameters.Add(new SqlParameter("@CERTIFICATE_CODE", _CERTIFICATE_CODE));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.CertTypeName = _tblSqla.Rows[i]["CERTIFICATE_TYPE"].ToString();

                    }
                    return _VehicleDetailMdl.CertTypeName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //To Calculate Net Value
        public static decimal calculate(VehicleDetailMdl _VehicleDetailMdl)
        {

            decimal rate = _VehicleDetailMdl.Rate;
            decimal SumCovered = _VehicleDetailMdl.PreviousValue;

            decimal net = SumCovered * (rate / 100);
            decimal stamp = 50;

            decimal total1 = net - stamp;
            decimal gross = total1 / Convert.ToDecimal(1.14);

            decimal fif = gross * Convert.ToDecimal(0.01);
            decimal fed = gross * Convert.ToDecimal(0.13);

            decimal total = gross + fif + fed + stamp;

            return total;



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
                VehicleDetailMdl _VehicleDetailMdl;

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
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.CityName = _tblSqla.Rows[i]["CITY_NAME"].ToString();

                    }
                    return _VehicleDetailMdl.CityName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Getting Motor Vehicle Colors Name By Code
        public static string GetVehicleColorNameByCode(int _COLOR_CODE)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                VehicleDetailMdl _VehicleDetailMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrVColors Where COLOR_CODE = @COLOR_CODE", conn);

                    command.Parameters.Add(new SqlParameter("@COLOR_CODE", _COLOR_CODE));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.ColorName = _tblSqla.Rows[i]["COLOR_SHORT_NAME"].ToString();

                    }
                    return _VehicleDetailMdl.ColorName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Getting Insurance Type Name By Code
        public static string GetInsuranceTypeNameByCode(int _INSURANCE_TYPE_CODE)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                MtrOpenPolicyMdl _MtrOpenPolicyMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM InsuranceType Where INSURANCE_TYPE_CODE = @INSURANCE_TYPE_CODE", conn);

                    command.Parameters.Add(new SqlParameter("@INSURANCE_TYPE_CODE", _INSURANCE_TYPE_CODE));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _MtrOpenPolicyMdl = new MtrOpenPolicyMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _MtrOpenPolicyMdl.InsuranceTypeName = _tblSqla.Rows[i]["INSURANCE_TYPE_TITLE"].ToString();

                    }
                    return _MtrOpenPolicyMdl.InsuranceTypeName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //for getting short text of Rating Factor by using code of Rating Factor (10 or 11)
        public static string GetRaitingFactorByCode(string _RatingFactorCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM RatingProductSetup WHERE RatingFactorCode='" + _RatingFactorCode + "'";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _ProductRatingFactorSetUpMdl = new ProductRatingFactorSetUpMdl();
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {

                        _ProductRatingFactorSetUpMdl.RatingFactorShText = _tbl.Rows[i]["RatingFactorName"].ToString();

                    }
                    return _ProductRatingFactorSetUpMdl.RatingFactorShText;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //for getting short text according to code of condition (1200 or 1221)
        public static string GetConditionByCode(string _ConditionCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM ConditionsProductSetup WHERE ConditionCode='" + _ConditionCode + "'";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                ProductConditionsMdl _ProductConditionsMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _ProductConditionsMdl = new ProductConditionsMdl();
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {

                        _ProductConditionsMdl.ConditionShText = _tbl.Rows[i]["ConditionShText"].ToString();

                    }
                    return _ProductConditionsMdl.ConditionShText;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //for getting Warranty Text From Warranty Code (200 or 201) 
        public static string GetWarrantyTextByCode(string _WarrantyCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM WarrantiesProductSetup WHERE WarrantyCode ='" + _WarrantyCode + "'";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                ProductWarrantiesSetupMdl _ProductWarrantiesSetupMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _ProductWarrantiesSetupMdl = new ProductWarrantiesSetupMdl();
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {

                        _ProductWarrantiesSetupMdl.WarrantyShText = _tbl.Rows[i]["WarrantyShText"].ToString();

                    }
                    return _ProductWarrantiesSetupMdl.WarrantyShText;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //for getting Warranty Text From Warranty Code (200 or 201) 
        public static int GetMaxParentTxnSysID()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(ParentTxnSysID) LastParentID FROM InsPolicy";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                VehicleDetailMdl _VehicleDetailMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.ParentTxnSysID = Convert.ToInt32(_tbl.Rows[i]["LastParentID"]);

                    }
                    return _VehicleDetailMdl.ParentTxnSysID;

                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        //Getting Tracker Name By Code
        public static string GetTrackerSetUpNameByCode(int _TrackerCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                ProductTrackerSetupMdl _ProductTrackerSetupMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM InsAccessories  Where ACCESSORY_CODE = @ACCESSORY_CODE", conn);

                    command.Parameters.Add(new SqlParameter("@ACCESSORY_CODE", _TrackerCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _ProductTrackerSetupMdl = new ProductTrackerSetupMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _ProductTrackerSetupMdl.TrackerName = _tblSqla.Rows[i]["ACCESSORY_SHORT_NAME"].ToString();

                    }
                    return _ProductTrackerSetupMdl.TrackerName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Getting Rider Name By Code
        public static string GetRiderSetUpNameByCode(int _RiderCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                ProductRiderSetupMdl _ProductRiderSetupMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM PerilRiders  Where RECORD_ID = @RECORD_ID", conn);

                    command.Parameters.Add(new SqlParameter("@RECORD_ID", _RiderCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _ProductRiderSetupMdl = new ProductRiderSetupMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _ProductRiderSetupMdl.RiderName = _tblSqla.Rows[i]["RIDER_NAME"].ToString();

                    }
                    return _ProductRiderSetupMdl.RiderName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Get Certificate Insurance Code By Policy Type
        public static string GetCertInsByPolicyType(string _PolicyTypeCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM PolicyTypeProductSetup WHERE PolicyTypeCode='" + _PolicyTypeCode + "'";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                MasterProductSetupMdl _MasterProductSetupMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _MasterProductSetupMdl = new MasterProductSetupMdl();
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {

                        _MasterProductSetupMdl.CertInsureCode = _tbl.Rows[i]["CertInsureCode"].ToString();

                    }
                    return _MasterProductSetupMdl.CertInsureCode;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Global DataLayer");
                return null;
            }
        }

        //Get new Cert No
        public static string GettingNewCertNo(MtrInsPolicyMdl _MtrInsPolicyMdl)
        {
            try
            {
                SqlConnection _conSql =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(DocNo) LastCertNo FROM InsPolicy";

                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                int _result = 0;
                _adpSql.Fill(_tbl);

                _result = _tbl.Rows[0][0].Equals(System.DBNull.Value) ? 1 : Convert.ToInt32(_tbl.Rows[0][0]) + 1;

                return _result.ToString();
            }
            catch (Exception ex)
            {

                int n = -1;
                return n.ToString();
            }
        }

        //To create an Error Log
        public static string CreateLog(List<TxnError> _TxnError, string Mdl)
        {
            string _fileName = "c:\\ErrorsLogs\\ErrorsLog_" + DateTime.Now.ToString("yy-MM-dd") + ".log";

            if (File.Exists(_fileName))
            {
                using (StreamWriter _StreamWriter = File.AppendText(_fileName))
                {
                   
                   _StreamWriter.WriteLine("==================================================");
                   _StreamWriter.WriteLine("Takaful Pakistan Limited");
                   _StreamWriter.WriteLine("Takaful Management System - Product Setup Log");
                   _StreamWriter.WriteLine("Error From : " + Mdl);
                   _StreamWriter.WriteLine("==================================================");
                   _StreamWriter.WriteLine("");
                   _StreamWriter.WriteLine("");

                   _StreamWriter.WriteLine(
                        "========================ERROR LOG==========================");

                    for (int i = 0; i < _TxnError.Count; i++)
                    {
                       _StreamWriter.WriteLine(_TxnError[i].TxnSysDate.ToString() ?? DBNull.Value.ToString());
                       _StreamWriter.WriteLine(_TxnError[i].ErrorCode ?? DBNull.Value.ToString());
                       _StreamWriter.WriteLine(_TxnError[i].Error ?? DBNull.Value.ToString());

                    }

                   _StreamWriter.WriteLine(
                        "===========================================================");
                    return _fileName;
                }
            }

            else
            {
            StringBuilder _sb = new StringBuilder();
            List<TxnError> _txnError = new List<TxnError>();

            _sb.AppendLine("==================================================");
            _sb.AppendLine("Takaful Pakistan Limited");
            _sb.AppendLine("Takaful Management System - Product Setup Log");
            _sb.AppendLine("Error from " + Mdl);
            _sb.AppendLine("==================================================");
            _sb.AppendLine("");
            // _sb.AppendLine("Errors From Product Setup System");
            _sb.AppendLine("");

            _sb.AppendLine(
                "========================ERROR LOG==========================");

            for (int i = 0; i < _TxnError.Count; i++)
            {
                _sb.AppendLine(_TxnError[i].TxnSysDate.ToString() ?? DBNull.Value.ToString());
                _sb.AppendLine(_TxnError[i].ErrorCode ?? DBNull.Value.ToString());
                _sb.AppendLine(_TxnError[i].Error ?? DBNull.Value.ToString());
            }

            _sb.AppendLine(
                "===========================================================");


                if (!Directory.Exists("c:\\ErrorsLogs\\"))
                {

                    Directory.CreateDirectory("c:\\ErrorsLogs\\");

                }

                File.WriteAllText(_fileName, _sb.ToString());

                return _fileName;
            }
        }

        //To create an Error Log For Exception
        public static string CreateExceptionLog(string Exp, string Mdl)
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
                _sb.AppendLine("Takaful Management System - Product Setup Log");
                _sb.AppendLine("Error From : " + Mdl);
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