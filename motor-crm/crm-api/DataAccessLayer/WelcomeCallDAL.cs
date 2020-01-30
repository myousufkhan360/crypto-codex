using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using CrmApi.Models;
using System.Text;
using System.Data;
using System.Configuration;

namespace CrmApi.DataAccessLayer
{
    public class WelcomeCallDAL
    {
        public List<WelcomeCallMDL> GetPendingList()
        {
            try
            {
                SQLiteConnection _conSql = new SQLiteConnection(ConfigurationManager.ConnectionStrings["sqliteConStr"].ToString());

                StringBuilder _sbSql = new StringBuilder();
                _sbSql.AppendLine("SELECT * FROM MotorWelcomeCalls WHERE IsPending=true");
                SQLiteDataAdapter _adpSql = new SQLiteDataAdapter(_sbSql.ToString(), _conSql);
                DataTable _tblSql = new DataTable();
                List<WelcomeCallMDL> _WelcomeCallMDLList = new List<WelcomeCallMDL>();
                WelcomeCallMDL _WelcomeCallMDL;

                for(int i=0;i<_WelcomeCallMDLList.Count;i++)
                {
                    _WelcomeCallMDL = new WelcomeCallMDL();
                    _WelcomeCallMDL.TxnSysID = Convert.ToInt32(_tblSql.Rows[i]["TxnSysID"]);
                    _WelcomeCallMDL.PolicyNo = _tblSql.Rows[i]["PolicyNo"].ToString();
                    _WelcomeCallMDL.PolicyIssueDate = Convert.ToDateTime(_tblSql.Rows[i]["PolicyIssueDate"]);
                    _WelcomeCallMDL.ClientName = _tblSql.Rows[i]["ClientName"].ToString();
                    _WelcomeCallMDL.ContactNumber = _tblSql.Rows[i]["ContactNumber"].ToString();
                    _WelcomeCallMDL.RegistrationNo = _tblSql.Rows[i]["RegistrationNo"].ToString();
                    _WelcomeCallMDL.EngineNo = _tblSql.Rows[i]["EngineNo"].ToString();
                    _WelcomeCallMDL.ChassisNo = _tblSql.Rows[i]["ChassisNo"].ToString();
                    _WelcomeCallMDL.VehicleMake = _tblSql.Rows[i]["VehicleMake"].ToString();
                    _WelcomeCallMDL.VehicleSubMake = _tblSql.Rows[i]["VehicleSubMake"].ToString();
                    _WelcomeCallMDL.VehicleModel = Convert.ToInt32(_tblSql.Rows[i]["VehicleModel"]);
                    _WelcomeCallMDL.VehicleColor = _tblSql.Rows[i]["VehicleColor"].ToString();
                    _WelcomeCallMDL.VehicleValue = Convert.ToDecimal(_tblSql.Rows[i]["VehicleValue"]);
                    _WelcomeCallMDL.IsPending = Convert.ToBoolean(_tblSql.Rows[i]["IsPending"]);

                    _WelcomeCallMDLList.Add(_WelcomeCallMDL);
                }


                return _WelcomeCallMDLList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}