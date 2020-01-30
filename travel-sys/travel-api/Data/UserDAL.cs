using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using TakafulSetup.Api.Models;
using System.Configuration;
using System.Data;
using Newtonsoft.Json;

namespace TakafulSetup.Api.Data
{
    public class UserDAL
    {
        public bool ValidateUserCredentials(UserMDL _UserMDL)
        {
            try
            {                
                SqlConnection _conDB = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlStr = "SELECT * FROM [User] WHERE UserID='" + _UserMDL.UserID + "'";
                SqlDataAdapter _adpDB = new SqlDataAdapter(_sqlStr, _conDB);
                DataTable _tblDB = new DataTable();

                _adpDB.Fill(_tblDB);

                if(_tblDB.Rows.Count == 0)
                {
                    return false;
                }
                else if(_UserMDL.UserID == _tblDB.Rows[0]["UserID"].ToString() && _UserMDL.UserPassword == _tblDB.Rows[0]["UserPassword"].ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch(Exception ex)
            {
                return false;
            }
        }
    }
}