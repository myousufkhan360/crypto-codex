using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using static TmsPlusRetailAPI.Models.GlobalModels;
using static TmsPlusRetailAPI.Models.MtrVehicleDetails;

namespace TmsPlusRetailAPI.DataLayer
{
    public class VehicleDetailDal
    {

        //Insert InTo Policy, Client, MtrRisk and Contribution For Motors
        public Policy AddPolicyMtr(Policy _Policy, Client _Client, MtrRisk _MtrRisk)
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

                string PolicyNo = GlobalDataLayer.GetPolicyNo(_Policy);
                string ProductCode = GlobalDataLayer.GetProductCode(_Policy);



                _cmdSql.Parameters.AddWithValue("@SysDate", DateTime.Now);
                _cmdSql.Parameters.AddWithValue("@PolicyNo", PolicyNo.ToString());
                _cmdSql.Parameters.AddWithValue("@IssueDate", DateTime.Now);
               // _cmdSql.Parameters.AddWithValue("@ProductCode", ProductCode.ToString());

                //To Be Entered
                _cmdSql.Parameters.AddWithValue("@EffDate", _Policy.EffDate);
                _cmdSql.Parameters.AddWithValue("@ExpDate", _Policy.ExpDate);
                _cmdSql.Parameters.AddWithValue("@ProductCode",_Policy.ProductCode);


                int _TxnSysId;
                _conSql.Open();
                _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                _conSql.Close();

                _Policy.SysID = _TxnSysId;


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
                _cmdSql2.Parameters.AddWithValue("@ParentSysID", _TxnSysId);


                //To Be Entered
                _cmdSql2.Parameters.AddWithValue("@NameOfInsured", _Client.NameOfInsured ?? DBNull.Value.ToString());
                _cmdSql2.Parameters.AddWithValue("@DOB", Convert.ToDateTime(_Client.DOB));
                _cmdSql2.Parameters.AddWithValue("@NIC", _Client.NIC ?? DBNull.Value.ToString());
                _cmdSql2.Parameters.AddWithValue("@GenderCode", _Client.GenderCode ?? DBNull.Value.ToString());
                _cmdSql2.Parameters.AddWithValue("@MobileNo", _Client.MobileNo ?? DBNull.Value.ToString());
                _cmdSql2.Parameters.AddWithValue("@Email", _Client.Email ?? DBNull.Value.ToString());
                _cmdSql2.Parameters.AddWithValue("@Address", _Client.Address ?? DBNull.Value.ToString());
                _cmdSql2.Parameters.AddWithValue("@CityCode", _Client.CityCode ?? DBNull.Value.ToString());

                int _TxnSysId2;
                _conSql2.Open();
                _TxnSysId2 = (Int32)_cmdSql2.ExecuteScalar();
                _conSql2.Close();

                _Client.SysID = _TxnSysId2;


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
                _sbSql3.AppendLine("@SumCovered,");
                _sbSql3.AppendLine("@Gross,");
                _sbSql3.AppendLine("@FED,");
                _sbSql3.AppendLine("@FIF,");
                _sbSql3.AppendLine("@SD,");
                _sbSql3.AppendLine("@Net)");




                _cmdSql3 = new SqlCommand(_sbSql3.ToString(), _conSql3);




                // _cmdSql2.Parameters.AddWithValue("@SysID", _ContributionMdlList[i].SysID);

                _cmdSql3.Parameters.AddWithValue("@SysDate", DateTime.Now);
                _cmdSql3.Parameters.AddWithValue("@ParentSysID", _TxnSysId);

                _cmdSql3.Parameters.AddWithValue("@SumCovered", _MtrRisk.SumCovered);

                decimal Gross, Net, FED = 13, FIF = 1, Stamp = 50;

                Net = (_MtrRisk.SumCovered * (_MtrRisk.Rate / 100));
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


                //Insert Into MtrRisk
                SqlConnection _conSql4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql4 = new StringBuilder();
                SqlCommand _cmdSql4;

                _sbSql4.AppendLine("INSERT INTO MtrRisk(");
                //_sbSql.AppendLine("SysID,");
                _sbSql4.AppendLine("SysDate,");
                _sbSql4.AppendLine("ParentSysID,");
                _sbSql4.AppendLine("SumCovered,");
                _sbSql4.AppendLine("Rate,");
                _sbSql4.AppendLine("VehicleCode,");
                _sbSql4.AppendLine("Model,");
                _sbSql4.AppendLine("EngineNo,");
                _sbSql4.AppendLine("ChasisNo,");
                _sbSql4.AppendLine("RegNo,");     
                _sbSql4.AppendLine("ColorCode,");
                _sbSql4.AppendLine("@CommisionRate)");

                _sbSql4.AppendLine("output INSERTED. SysID VALUES ( ");
                // _sbSql4.AppendLine("@SysID,");
                _sbSql4.AppendLine("@SysDate,");
                _sbSql4.AppendLine("@ParentSysID,");
                _sbSql4.AppendLine("@SumCovered,");
                _sbSql4.AppendLine("@Rate,");
                _sbSql4.AppendLine("@VehicleCode,");
                _sbSql4.AppendLine("@Model,");
                _sbSql4.AppendLine("@EngineNo,");
                _sbSql4.AppendLine("@ChasisNo,");
                _sbSql4.AppendLine("@RegNo,");
                _sbSql4.AppendLine("@ColorCode,");
                _sbSql4.AppendLine("(0))");





                _cmdSql4 = new SqlCommand(_sbSql4.ToString(), _conSql4);



             
                _cmdSql4.Parameters.AddWithValue("@SysDate", DateTime.Now);
                _cmdSql4.Parameters.AddWithValue("@ParentSysID", _TxnSysId);

                _cmdSql4.Parameters.AddWithValue("@SumCovered", _MtrRisk.SumCovered);
                _cmdSql4.Parameters.AddWithValue("@Rate", _MtrRisk.Rate);
                _cmdSql4.Parameters.AddWithValue("@VehicleCode", _MtrRisk.VehicleCode ?? DBNull.Value.ToString());
                _cmdSql4.Parameters.AddWithValue("@Model", _MtrRisk.Model ?? DBNull.Value.ToString());
                _cmdSql4.Parameters.AddWithValue("@EngineNo", _MtrRisk.EngineNo ?? DBNull.Value.ToString());
                _cmdSql4.Parameters.AddWithValue("@ChasisNo", _MtrRisk.ChasisNo ?? DBNull.Value.ToString());
                _cmdSql4.Parameters.AddWithValue("@RegNo", _MtrRisk.RegNo ?? DBNull.Value.ToString());
                _cmdSql4.Parameters.AddWithValue("@ColorCode", _MtrRisk.ColorCode);
               


                int _TxnSysId4;
                _conSql4.Open();
                _TxnSysId4 = (Int32)_cmdSql4.ExecuteScalar();
                _conSql4.Close();

                _MtrRisk.SysID = _TxnSysId4;


                _Policy.ClassCode = "02";
                _Policy.DocType = "7";
                _Policy.ClassName = GlobalDataLayer.GetPolicyClassNameByCode("02");
                _Policy.DocName = GlobalDataLayer.GetDocTypeNameByDocTypeCode("7");
                _Policy.PolicyNo = PolicyNo;
                _Policy.ProductName = GlobalDataLayer.GetProductNameByCode(_Policy.ProductCode);


                Client _Client1 = new Client();

                _Client1.NameOfInsured = _Client.NameOfInsured;
                _Client1.PolicyNo = PolicyNo;
                _Client1.DOB= _Client.DOB;
                _Client1.NIC = _Client.NIC;
                _Client1.GenderCode = _Client.GenderCode;
                _Client1.MobileNo = _Client.MobileNo;
                _Client1.Email = _Client.Email;
                _Client1.Address = _Client.Address;
                _Client1.CityCode = _Client.CityCode;
                _Client1.GenderName = GlobalDataLayer.GetGenderNameByCode(_Client.GenderCode);
                _Client1.CityName = GlobalDataLayer.GetCityNameByCode(_Client.CityCode);
                

                Contribution _Contribution1 = new Contribution();

                _Contribution1.SumCovered = _MtrRisk.SumCovered;
                _Contribution1.Gross = Gross;
                _Contribution1.FED = FED;
                _Contribution1.FIF = FIF;
                _Contribution1.SD = Stamp;
                _Contribution1.Net = Net;




                _Policy.client = _Client1;
                _Policy.contribution = _Contribution1;

               _Policy.SysID = _TxnSysId;

                return _Policy;

            }


            catch (Exception ex)
            {
                //System.Reflection.MethodBase.GetCurrentMethod();
                // string str = System.Reflection.MethodBase.GetCurrentMethod().Name;

                
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);
               

                //int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //For Drop Downs

        //For Getting all VEOD Codes and Names
        public List<MtrVEODMdl> GetVEOD()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrVEOD";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrVEODMdl> _MtrVEODMdlList = new List<MtrVEODMdl>();
                MtrVEODMdl _MtrVEODMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrVEODMdl = new MtrVEODMdl();

                        //_MtrVEODMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        //_MtrVEODMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        //_MtrVEODMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrVEODMdl.VEODCode = Convert.ToInt32(_tblSqla.Rows[i]["VEODCode"]);
                        _MtrVEODMdl.VEODName = _tblSqla.Rows[i]["VEODName"].ToString();


                        _MtrVEODMdlList.Add(_MtrVEODMdl);


                    }

                    return _MtrVEODMdlList;
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //For Getting all Vehicle Type Codes and Names
        public List<MtrVehicleTypeMdl> GetVehicleType()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrVehicleType";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrVehicleTypeMdl> _MtrVehicleTypeMdlList = new List<MtrVehicleTypeMdl>();
                MtrVehicleTypeMdl _MtrVehicleTypeMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrVehicleTypeMdl = new MtrVehicleTypeMdl();

                        //_MtrVehicleTypeMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        //_MtrVehicleTypeMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        //_MtrVehicleTypeMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrVehicleTypeMdl.VehicleTypeCode = _tblSqla.Rows[i]["VehicleTypeCode"].ToString();
                        _MtrVehicleTypeMdl.VehicleTypeName = _tblSqla.Rows[i]["VehicleTypeName"].ToString();



                        _MtrVehicleTypeMdlList.Add(_MtrVehicleTypeMdl);


                    }

                    return _MtrVehicleTypeMdlList;
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //for getting all Vehicle Colors
        public List<VColorMdl> GetVehicleColor()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrVColors";
                //+ " WHERE  FORMAT(TxnSysDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + 
                // "AND FORMAT(EffectiveDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + "AND FORMAT(ExpiryDate, 'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(), 'yyyy-MM-dd'))";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<VColorMdl> _VColorMdlList = new List<VColorMdl>();
                VColorMdl _VColorMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _VColorMdl = new VColorMdl();

                        //_VColorMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        //_VColorMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        //_VColorMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _VColorMdl.COLOR_CODE = Convert.ToInt32(_tblSqla.Rows[i]["COLOR_CODE"]);
                        _VColorMdl.COLOR_NAME = _tblSqla.Rows[i]["COLOR_NAME"].ToString();
                        _VColorMdl.COLOR_SHORT_NAME = _tblSqla.Rows[i]["COLOR_SHORT_NAME"].ToString();


                        _VColorMdlList.Add(_VColorMdl);


                    }

                    return _VColorMdlList;
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //Get All Vehicles Concatinated
        public List<MtrVehicleMdl> GetMtrVehicle()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString =
                "SELECT MM.MAKE_NAME + ' | ' + MV.VEHICLE_NAME  +' | ' + mbt.BODY_NAME +' | '+(CASE WHEN  icc.TYPE = 'H' THEN 'Horse Power' WHEN icc.TYPE = 'C' THEN 'Cubic Capacity' ELSE '' END) + ' | ' + icc.CUBIC_HORSE_TITLE VEHICLE_TEXT, mv.VEHICLE_CODE FROM TmsPlusDB.dbo.MtrVehicle mv INNER JOIN TmsPlusDB.dbo.MtrVMake mm ON mv.MAKE_CODE = mm.MAKE_CODE INNER JOIN TmsPlusDB.dbo.MtrVBodyType mbt ON mv.BODY_TYPE_CODE = mbt.BODY_TYPE_CODE INNER JOIN TmsPlusDB.dbo.MtrVCubicCapacity icc ON mv.CUBIC_HORSE_CODE = icc.CUBIC_HORSE_CODE";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrVehicleMdl> _MtrVehicleMdlList = new List<MtrVehicleMdl>();
                MtrVehicleMdl _MtrVehicleMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrVehicleMdl = new MtrVehicleMdl();

                        // _MtrVehicleMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        //_MtrVehicleMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrVehicleMdl.VEHICLE_TEXT = _tblSqla.Rows[i]["VEHICLE_TEXT"].ToString();
                        _MtrVehicleMdl.VEHICLE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["VEHICLE_CODE"]);


                        _MtrVehicleMdlList.Add(_MtrVehicleMdl);


                    }

                    return _MtrVehicleMdlList;
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
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

                        //_GendersMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        //_GendersMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        //_GendersMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //Get all Cities
        public List<MtrCityMdl> GetCity()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrCity";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrCityMdl> _MtrCityMdlList = new List<MtrCityMdl>();
                MtrCityMdl _MtrCityMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrCityMdl = new MtrCityMdl();

                        //_MtrCityMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        //_MtrCityMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        //_MtrCityMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrCityMdl.CITY_CODE = Convert.ToInt32(_tblSqla.Rows[i]["CITY_CODE"]);
                        _MtrCityMdl.CITY_NAME = _tblSqla.Rows[i]["CITY_NAME"].ToString();
                        



                        _MtrCityMdlList.Add(_MtrCityMdl);


                    }

                    return _MtrCityMdlList;
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //Getting All District/Area By City Code
        public List<MtrDistrictMdl> GetArea(MtrCityMdl _MtrCityMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //string _sqlString = "SELECT * FROM MtrDistrict ";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrDistrictMdl> _MtrDistrictMdlList = new List<MtrDistrictMdl>();
                MtrDistrictMdl _MtrDistrictMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrDistrict Where CITY_CODE = @CITY_CODE", conn);

                    command.Parameters.Add(new SqlParameter("@CITY_CODE", _MtrCityMdl.CITY_CODE));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                // _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrDistrictMdl = new MtrDistrictMdl();

                        // _MtrDistrictMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        //_MtrDistrictMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        // _MtrDistrictMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrDistrictMdl.DISTRICT_CODE = Convert.ToInt32(_tblSqla.Rows[i]["DISTRICT_CODE"]);
                        _MtrDistrictMdl.DISTRICT_NAME = _tblSqla.Rows[i]["DISTRICT_NAME"].ToString();
                        _MtrDistrictMdl.CITY_CODE = Convert.ToInt32(_tblSqla.Rows[i]["CITY_CODE"]);
                        // _MtrDistrictMdl.ENT_BY = _tblSqla.Rows[i]["ENT_BY"].ToString();
                        // _MtrDistrictMdl.ENT_DATE = Convert.ToDateTime(_tblSqla.Rows[i]["ENT_DATE"]);





                        _MtrDistrictMdlList.Add(_MtrDistrictMdl);


                    }

                    return _MtrDistrictMdlList;
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //Get all Certificate Types
        public List<MtrInsCertMdl> GetCert()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrInsCert";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrInsCertMdl> _MtrInsCertMdlList = new List<MtrInsCertMdl>();
                MtrInsCertMdl _MtrInsCertMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrInsCertMdl = new MtrInsCertMdl();

                        //_MtrInsCertMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        //_MtrInsCertMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        //_MtrInsCertMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrInsCertMdl.CERTIFICATE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["CERTIFICATE_CODE"]);
                        _MtrInsCertMdl.DRIVER = _tblSqla.Rows[i]["DRIVER"].ToString();
                        _MtrInsCertMdl.USAGE_LIMITATION = _tblSqla.Rows[i]["USAGE_LIMITATION"].ToString();
                        _MtrInsCertMdl.CERTIFICATE_TYPE = _tblSqla.Rows[i]["CERTIFICATE_TYPE"].ToString();



                        _MtrInsCertMdlList.Add(_MtrInsCertMdl);


                    }

                    return _MtrInsCertMdlList;
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //For Drop Downs






    }
}