using ProductSetupApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ProductSetupApi.DataLayers
{
    public class UsersDAL
    {
        //Validate user credentials
        public UserToken ValidateUserCredentials(UserMDL _UserMDL)
        {
            try
            {
                SqlConnection _conDB = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlStr = "SELECT * FROM [User] WHERE UserID='" + _UserMDL.UserID + "'";
                SqlDataAdapter _adpDB = new SqlDataAdapter(_sqlStr, _conDB);
                DataTable _tblDB = new DataTable();

                _adpDB.Fill(_tblDB);

                UserToken _userToken = new UserToken();

                if (_tblDB.Rows.Count == 0)
                {

                    _userToken.IsValid = false;
                    _userToken.Token = null;
                    return _userToken;
                }
                else if (_UserMDL.UserID == _tblDB.Rows[0]["UserID"].ToString() && _UserMDL.UserPassword == _tblDB.Rows[0]["UserPassword"].ToString())
                {

                    _userToken.IsValid = true;
                    _userToken.Token = Guid.NewGuid().ToString();
                    _userToken.UserID = _UserMDL.UserID;
                    InsertToken(_userToken);
                    return _userToken;
                }
                else
                {
                    _userToken.IsValid = false;
                    _userToken.Token = null;
                    return _userToken;
                }
            }

            catch (Exception ex)
            {
                UserToken _userToken = new UserToken();
                _userToken.IsValid = false;
                _userToken.Token = null;
                return _userToken;
            }
        }

        //for inserting token with user id
        private void InsertToken(UserToken _userToken)
        {
            try
            {
                SqlConnection _conDB = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sb = new StringBuilder();

                _sb.AppendLine("INSERT INTO UserToken(");
                _sb.AppendLine("UserID,Token)");
                _sb.AppendLine("VALUES(");
                _sb.AppendLine("@UserID,@Token)");
                SqlCommand _cmdSql = new SqlCommand(_sb.ToString(), _conDB);

                _cmdSql.Parameters.AddWithValue("@UserID", _userToken.UserID);
                _cmdSql.Parameters.AddWithValue("@Token", _userToken.Token);

                _conDB.Open();
                _cmdSql.ExecuteNonQuery();
                _conDB.Close();
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "User DataLayer");
            }
        }

        //for validating the token
        public UserToken ValidateUserToken(UserToken _userToken)
        {
            try
            {
                SqlConnection _conDB =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlStr = "SELECT * FROM [UserToken] WHERE UserID='" + _userToken.UserID + "' AND Token='" +
                                 _userToken.Token + "' AND IsValidToken=1 AND FORMAT(TxnSysDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))";
                SqlDataAdapter _adpDB = new SqlDataAdapter(_sqlStr, _conDB);
                DataTable _tblDB = new DataTable();
                _adpDB.Fill(_tblDB);
                UserToken _userToken1 = new UserToken();

                if (_tblDB.Rows.Count == 0)
                {
                    _userToken1.IsValid = false;
                    return _userToken1;
                }
                else
                {
                    _userToken1.IsValid = true;
                    return _userToken1;
                }
            }
            catch (Exception e)
            {
                UserToken _userToken1 = new UserToken();
                _userToken1.IsValid = false;
                return _userToken1;
            }
        }

        //for inserting token with user id
        public UserToken TokenExpiry(UserToken _userToken)
        {
            try
            {
                SqlConnection _conDB = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sb = new StringBuilder();

                _sb.AppendLine("Update UserToken");
                _sb.AppendLine("Set IsValidToken=0");
                _sb.AppendLine("WHERE Token=@Token");
                SqlCommand _cmdSql = new SqlCommand(_sb.ToString(), _conDB);

                _cmdSql.Parameters.AddWithValue("@Token", _userToken.Token);

                _conDB.Open();
                _cmdSql.ExecuteNonQuery();
                _conDB.Close();

                return _userToken;
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "User DataLayer");
                return null;
            }
        }

    }
}