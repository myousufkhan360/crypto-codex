using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data.SQLite;
using System.Data;

namespace MotorCRMDispatcher
{
    class WelcomeCallDAL
    {
        //Data refilling for welcome calls
        public void RefillMotorWelcomeCalls()
        {
            try
            {
                OracleConnection _conOra = new OracleConnection(Globals._oraConStr);
                StringBuilder _sbOra = new StringBuilder();
                _sbOra.AppendLine("SELECT * from vuCrmMotorWelcomeCall");
                OracleDataAdapter _adpOra = new  OracleDataAdapter(_sbOra.ToString(), _conOra);
                DataTable _tblOra = new DataTable();
                _adpOra.Fill(_tblOra);

                List<WelcomeCallMDL> _WelcomeCallMDLList = new List<WelcomeCallMDL>();
                WelcomeCallMDL _WelcomeCallMDL;

                for (int i = 0; i < _tblOra.Rows.Count; i++)
                {
                    _WelcomeCallMDL = new WelcomeCallMDL();
                    _WelcomeCallMDL.PolicyNo = _tblOra.Rows[i]["PolicyNo"].ToString();
                    _WelcomeCallMDL.PolicyIssueDate = Convert.ToDateTime(_tblOra.Rows[i]["PolicyIssueDate"]);
                    _WelcomeCallMDL.ClientName = _tblOra.Rows[i]["ClientName"].ToString();
                    _WelcomeCallMDL.ContactNumber = _tblOra.Rows[i]["ContactNumber"].ToString();
                    _WelcomeCallMDL.RegistrationNo = _tblOra.Rows[i]["RegistrationNo"].ToString();
                    _WelcomeCallMDL.EngineNo = _tblOra.Rows[i]["EngineNo"].ToString();
                    _WelcomeCallMDL.ChassisNo = _tblOra.Rows[i]["ChassisNo"].ToString();
                    _WelcomeCallMDL.VehicleMake = _tblOra.Rows[i]["VehicleMake"].ToString();
                    _WelcomeCallMDL.VehicleSubMake = _tblOra.Rows[i]["VehicleSubMake"].ToString();
                    _WelcomeCallMDL.VehicleModel = Convert.ToInt32(_tblOra.Rows[i]["VehicleModel"]);
                    _WelcomeCallMDL.VehicleColor = _tblOra.Rows[i]["VehicleColor"].ToString();
                    _WelcomeCallMDL.VehicleValue = Convert.ToDecimal(_tblOra.Rows[i]["VehicleValue"]);
                    _WelcomeCallMDLList.Add(_WelcomeCallMDL);
                }


                SQLiteConnection _conSql = new SQLiteConnection(Globals._sqlConStr);
                SQLiteCommand _cmdSql;
                StringBuilder _sbSql = new StringBuilder();

                _sbSql.AppendLine("INSERT INTO MotorWelcomeCalls");
                _sbSql.AppendLine("(PolicyNo,");
                _sbSql.AppendLine("PolicyIssueDate,");
                _sbSql.AppendLine("ClientName,");
                _sbSql.AppendLine("ContactNumber,");
                _sbSql.AppendLine("RegistrationNo,");
                _sbSql.AppendLine("EngineNo,");
                _sbSql.AppendLine("ChassisNo,");
                _sbSql.AppendLine("VehicleMake,");
                _sbSql.AppendLine("VehicleSubMake,");
                _sbSql.AppendLine("VehicleModel,");
                _sbSql.AppendLine("VehicleColor,");
                _sbSql.AppendLine("VehicleValue)");
                _sbSql.AppendLine(" VALUES(");
                _sbSql.AppendLine("@PolicyNo,");
                _sbSql.AppendLine("@PolicyIssueDate,");
                _sbSql.AppendLine("@ClientName,");
                _sbSql.AppendLine("@ContactNumber,");
                _sbSql.AppendLine("@RegistrationNo,");
                _sbSql.AppendLine("@EngineNo,");
                _sbSql.AppendLine("@ChassisNo,");
                _sbSql.AppendLine("@VehicleMake,");
                _sbSql.AppendLine("@VehicleSubMake,");
                _sbSql.AppendLine("@VehicleModel,");
                _sbSql.AppendLine("@VehicleColor,");
                _sbSql.AppendLine("@VehicleValue)");



                for (int i=0; i<_WelcomeCallMDLList.Count;i++)
                {
                    if(IsDuplicatePolicy(_WelcomeCallMDLList[i].PolicyNo) ==false)
                    {
                        _cmdSql = new SQLiteCommand(_sbSql.ToString(), _conSql);
                        _cmdSql.Parameters.AddWithValue("@PolicyNo", _WelcomeCallMDLList[i].PolicyNo);
                        _cmdSql.Parameters.AddWithValue("@PolicyIssueDate", _WelcomeCallMDLList[i].PolicyIssueDate);
                        _cmdSql.Parameters.AddWithValue("@ClientName", _WelcomeCallMDLList[i].ClientName);
                        _cmdSql.Parameters.AddWithValue("@ContactNumber", _WelcomeCallMDLList[i].ContactNumber);
                        _cmdSql.Parameters.AddWithValue("@RegistrationNo", _WelcomeCallMDLList[i].RegistrationNo);
                        _cmdSql.Parameters.AddWithValue("@EngineNo", _WelcomeCallMDLList[i].EngineNo);
                        _cmdSql.Parameters.AddWithValue("@ChassisNo", _WelcomeCallMDLList[i].ChassisNo);
                        _cmdSql.Parameters.AddWithValue("@VehicleMake", _WelcomeCallMDLList[i].VehicleMake);
                        _cmdSql.Parameters.AddWithValue("@VehicleSubMake", _WelcomeCallMDLList[i].VehicleSubMake);
                        _cmdSql.Parameters.AddWithValue("@VehicleModel", _WelcomeCallMDLList[i].VehicleModel);
                        _cmdSql.Parameters.AddWithValue("@VehicleColor", _WelcomeCallMDLList[i].VehicleColor);
                        _cmdSql.Parameters.AddWithValue("@VehicleValue", _WelcomeCallMDLList[i].VehicleValue);

                        _conSql.Open();
                        _cmdSql.ExecuteNonQuery();
                        _conSql.Close();

                    }
                }


            }
            catch(Exception ex)
            {

            }
        }

        //Duplicate check for policy number
        public bool IsDuplicatePolicy(string _PolicyNumber)
        {
            try
            {
                SQLiteConnection _conSql = new SQLiteConnection(Globals._sqlConStr);
                
                StringBuilder _sbSql = new StringBuilder();
                _sbSql.AppendLine("SELECT COUNT(*) FROM MotorWelcomeCalls WHERE PolicyNo='" + _PolicyNumber + "'");
                SQLiteDataAdapter _adpSql = new SQLiteDataAdapter(_sbSql.ToString(), _conSql);
                DataTable _tblSql = new DataTable();

                _adpSql.Fill(_tblSql);
                if(_tblSql.Rows[0][0].ToString() == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
