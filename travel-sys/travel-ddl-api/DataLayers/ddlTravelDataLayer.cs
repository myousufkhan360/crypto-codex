using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ddlAPI.Models;
using System.Configuration;
using System.Data;
using System.Text;

namespace ddlAPI.DataLayers
{
    public class ddlTravelDataLayer
    {
        //for getting all Travel Categories (DDL)
        public List<ddlTravelCategory> GetTravelCategoryList()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM TravelCategories";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ddlTravelCategory> _ddlTravelCategoryList = new List<ddlTravelCategory>();
                ddlTravelCategory _ddlTravelCategory;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _ddlTravelCategory = new ddlTravelCategory();
                    _ddlTravelCategory.TravelCategoryCode = -1;
                    _ddlTravelCategory.TravelCategoryName = "--Select--";
                    _ddlTravelCategoryList.Add(_ddlTravelCategory);

                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ddlTravelCategory = new ddlTravelCategory();
                        _ddlTravelCategory.TravelCategoryCode = Convert.ToInt32(_tbl.Rows[i]["TravelCategoryCode"]);
                        _ddlTravelCategory.TravelCategoryName = _tbl.Rows[i]["TravelCategoryName"].ToString();
                        _ddlTravelCategoryList.Add(_ddlTravelCategory);
                    }

                    return _ddlTravelCategoryList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //for getting all Travel Plans (DDL)
        public List<ddlTravelPlan> getTravelPlansByCategory(int _TravelCategoryCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM TravelPlans WHERE TravelCategoryCode =" + _TravelCategoryCode;
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ddlTravelPlan> _ddlTravelPlansList = new List<ddlTravelPlan>();
                ddlTravelPlan _ddlTravelPlan;

                _adpSql.Fill(_tbl);

                _ddlTravelPlan = new ddlTravelPlan();
                _ddlTravelPlan.TravelPlanCode = -1;
                _ddlTravelPlan.TravelCategoryCode = -1;
                _ddlTravelPlan.TravelPlanName = "--Select--";
                _ddlTravelPlansList.Add(_ddlTravelPlan);


                for (int i = 0; i < _tbl.Rows.Count; i++)
                {
                    _ddlTravelPlan = new ddlTravelPlan();
                    _ddlTravelPlan.TravelPlanCode = Convert.ToInt32(_tbl.Rows[i]["TravelPlanCode"]);
                    _ddlTravelPlan.TravelCategoryCode = Convert.ToInt32(_tbl.Rows[i]["TravelCategoryCode"]);
                    _ddlTravelPlan.TravelPlanName = _tbl.Rows[i]["TravelPlanName"].ToString();
                    _ddlTravelPlansList.Add(_ddlTravelPlan);
                }

                return _ddlTravelPlansList;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //for getting all Travel Coverage Type (DDL)
        public List<ddlTravelCoverageType> GetTravelCoverageTypeList()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM TravelCoverageType";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ddlTravelCoverageType> _ddlTravelCoverageTypeList = new List<ddlTravelCoverageType>();
                ddlTravelCoverageType _ddlTravelCoverageType;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _ddlTravelCoverageType = new ddlTravelCoverageType();
                    _ddlTravelCoverageType.TravelCoverageTypeCode = -1;
                    _ddlTravelCoverageType.TravelCoverageTypeName = "--Select--";
                    _ddlTravelCoverageTypeList.Add(_ddlTravelCoverageType);

                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ddlTravelCoverageType = new ddlTravelCoverageType();
                        _ddlTravelCoverageType.TravelCoverageTypeCode = Convert.ToInt32(_tbl.Rows[i]["TravelCoverageTypeCode"]);
                        _ddlTravelCoverageType.TravelCoverageTypeName = _tbl.Rows[i]["TravelCoverageTypeName"].ToString();
                        _ddlTravelCoverageTypeList.Add(_ddlTravelCoverageType);
                    }

                    return _ddlTravelCoverageTypeList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //for getting all Travel Tenures (DDL)
        public List<ddlTravelTenure> getTravelTenureList(int _TravelCategoryCode, int _TravelPlanCode, int _TravelCoverageTypeCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM vuTravelContributionSetup WHERE TravelCategoryCode =" + _TravelCategoryCode + " AND TravelPlanCode = " + _TravelPlanCode + " AND TravelCoverageTypeCode =  " + _TravelCoverageTypeCode;
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ddlTravelTenure> _ddlTravelTenuresList = new List<ddlTravelTenure>();
                ddlTravelTenure _ddlTravelTenure;

                _adpSql.Fill(_tbl);

                _ddlTravelTenure = new ddlTravelTenure();
                _ddlTravelTenure.TravelTenureCode = -1;
                _ddlTravelTenure.TravelTenureText = "--Select--";
                _ddlTravelTenuresList.Add(_ddlTravelTenure);


                for (int i = 0; i < _tbl.Rows.Count; i++)
                {
                    _ddlTravelTenure = new ddlTravelTenure();
                    _ddlTravelTenure.TravelTenureCode = Convert.ToInt32(_tbl.Rows[i]["TravelTenureCode"]);
                    _ddlTravelTenure.TravelTenureText = _tbl.Rows[i]["TravelTenureText"].ToString();
                    _ddlTravelTenuresList.Add(_ddlTravelTenure);
                }

                return _ddlTravelTenuresList;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //for getting all Travel Destination (DDL)
        public List<ddlTravelDestination> getTravelDestinationList(int _TravelCategoryCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "";

                if (_TravelCategoryCode == 1 || _TravelCategoryCode == 2)
                {
                    _sqlString = "SELECT  CountryCode TravelDestinationCode,CountryName TravelDestinationName FROM Country";
                }
                else if (_TravelCategoryCode == 3)
                {
                    _sqlString = "SELECT  CityCode TravelDestinationCode,CityName TravelDestinationName  FROM City";
                }
                else if (_TravelCategoryCode == 4)
                {
                    _sqlString = "SELECT  CountryCode TravelDestinationCode,CountryName TravelDestinationName FROM Country WHERE CountryCode=152";
                }

                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ddlTravelDestination> _ddlTravelDestinationList = new List<ddlTravelDestination>();
                ddlTravelDestination _ddlTravelDestination;

                _adpSql.Fill(_tbl);

                _ddlTravelDestination = new ddlTravelDestination();
                _ddlTravelDestination.TravelDestinationCode = -1;
                _ddlTravelDestination.TravelDestinationName = "--Select--";
                _ddlTravelDestinationList.Add(_ddlTravelDestination);


                for (int i = 0; i < _tbl.Rows.Count; i++)
                {
                    _ddlTravelDestination = new ddlTravelDestination();
                    _ddlTravelDestination.TravelDestinationCode = Convert.ToInt32(_tbl.Rows[i]["TravelDestinationCode"]);
                    _ddlTravelDestination.TravelDestinationName = _tbl.Rows[i]["TravelDestinationName"].ToString();
                    _ddlTravelDestinationList.Add(_ddlTravelDestination);
                }

                return _ddlTravelDestinationList;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //for getting all Relations (DDL)
        public List<ddlRelation> GetRelationList()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM Relations";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ddlRelation> _ddlRelationList = new List<ddlRelation>();
                ddlRelation _ddlRelation;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _ddlRelation = new ddlRelation();
                    _ddlRelation.RelationCode = -1;
                    _ddlRelation.RelationName = "--Select--";
                    _ddlRelationList.Add(_ddlRelation);

                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ddlRelation = new ddlRelation();
                        _ddlRelation.RelationCode = Convert.ToInt32(_tbl.Rows[i]["RelationCode"]);
                        _ddlRelation.RelationName = _tbl.Rows[i]["RelationName"].ToString();
                        _ddlRelationList.Add(_ddlRelation);
                    }

                    return _ddlRelationList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //for getting all PaymentMethod (DDL)
        public List<ddlPaymentMethod> GetPaymentMethodList()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM PaymentMethods";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ddlPaymentMethod> _ddlPaymentMethodList = new List<ddlPaymentMethod>();
                ddlPaymentMethod _ddlPaymentMethod;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _ddlPaymentMethod = new ddlPaymentMethod();
                    _ddlPaymentMethod.PaymentMethodCode = -1;
                    _ddlPaymentMethod.PaymentMethodName = "--Select--";
                    _ddlPaymentMethodList.Add(_ddlPaymentMethod);

                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ddlPaymentMethod = new ddlPaymentMethod();
                        _ddlPaymentMethod.PaymentMethodCode = Convert.ToInt32(_tbl.Rows[i]["PaymentMethodCode"]);
                        _ddlPaymentMethod.PaymentMethodName = _tbl.Rows[i]["PaymentMethodName"].ToString();
                        _ddlPaymentMethodList.Add(_ddlPaymentMethod);
                    }

                    return _ddlPaymentMethodList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //for getting contribution
        public TravelContribution GetContribution(int _TravelCategoryCode, int _TravelPlanCode, int _TravelCoverageTypeCode, int _TravelTenureCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT TravelContribution FROM vuTravelContributionSetup WHERE TravelCategoryCode =" + _TravelCategoryCode + " AND TravelPlanCode = " + _TravelPlanCode + " AND TravelCoverageTypeCode =  " + _TravelCoverageTypeCode + " AND TravelTenureCode= " + _TravelTenureCode;
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                TravelContribution _TravelContribution = new TravelContribution();

                _adpSql.Fill(_tbl);


                for (int i = 0; i < _tbl.Rows.Count; i++)
                {
                    _TravelContribution.Contribution = Convert.ToInt32(_tbl.Rows[i]["TravelContribution"]);
                }

                return _TravelContribution;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Creating new policy
        public SubmitStatus CreateTravelPolicy(TravelPolicy _TravelPolicy, List<TravelFamilyDetails> _TravelFamilyDetailsList)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sb = new StringBuilder();
                string _PolicyNumber = GetNewPolicyNumber();

                _sb.AppendLine("INSERT INTO TravelPolicy");
                _sb.AppendLine(" (PolicyNumber,CategoryCode,");
                _sb.AppendLine(" PlanCode,InsuredName,DOB,");
                _sb.AppendLine(" Email,MobileNumber,DestinationCode,");
                _sb.AppendLine(" TravelWithCode,TravellingDate,TenureCode,");
                _sb.AppendLine(" ContributionCode,PaymentModeCode)");
                _sb.AppendLine("output INSERTED.TxnSysID VALUES ( ");
                //_sb.AppendLine(" VALUES(");
                _sb.AppendLine(" @PolicyNumber,@CategoryCode,");
                _sb.AppendLine(" @PlanCode,@InsuredName,@DOB,");
                _sb.AppendLine(" @Email,@MobileNumber,@DestinationCode,");
                _sb.AppendLine(" @TravelWithCode,@TravellingDate,@TenureCode,");
                _sb.AppendLine(" @ContributionCode,@PaymentModeCode)");

                SqlCommand _cmdSql = new SqlCommand(_sb.ToString(), _conSql);
                //_cmdSql.Parameters.AddWithValue("@TxnSysID", _TravelPolicy.TxnSysID);
                _cmdSql.Parameters.AddWithValue("@PolicyNumber", _PolicyNumber);
                _cmdSql.Parameters.AddWithValue("@CategoryCode", _TravelPolicy.CategoryCode);
                _cmdSql.Parameters.AddWithValue("@PlanCode", _TravelPolicy.PlanCode);
                _cmdSql.Parameters.AddWithValue("@InsuredName", _TravelPolicy.InsuredName);
                _cmdSql.Parameters.AddWithValue("@DOB", _TravelPolicy.DOB);
                _cmdSql.Parameters.AddWithValue("@Email", _TravelPolicy.Email);
                _cmdSql.Parameters.AddWithValue("@MobileNumber", _TravelPolicy.MobileNumber);
                _cmdSql.Parameters.AddWithValue("@DestinationCode", _TravelPolicy.DestinationCode);
                _cmdSql.Parameters.AddWithValue("@TravelWithCode", _TravelPolicy.TravelWithCode);
                _cmdSql.Parameters.AddWithValue("@TravellingDate", _TravelPolicy.TravellingDate);
                _cmdSql.Parameters.AddWithValue("@TenureCode", _TravelPolicy.TenureCode);
                _cmdSql.Parameters.AddWithValue("@ContributionCode", _TravelPolicy.ContributionCode);
                _cmdSql.Parameters.AddWithValue("@PaymentModeCode", _TravelPolicy.PaymentModeCode);


                int _newTxnSysId;

                _conSql.Open();
                _newTxnSysId = (Int32)_cmdSql.ExecuteScalar();
                _conSql.Close();

                if (_TravelFamilyDetailsList != null)
                {
                    CreateTravelFamilyDetails(_TravelFamilyDetailsList, _newTxnSysId);
                }

                SubmitStatus _submitStatus = new SubmitStatus();
                _submitStatus.Ref = _PolicyNumber;
                _submitStatus.IsValid = true;
                _submitStatus.StatusCode = 0;
                _submitStatus.StatusDescription = "Policy created sucessfully.";

                return _submitStatus;

            }
            catch (Exception ex)
            {
                SubmitStatus _submitStatus = new SubmitStatus();
                _submitStatus.Ref = "-1";
                _submitStatus.IsValid = false;
                _submitStatus.StatusCode = 101;
                _submitStatus.StatusDescription = ex.Message;

                return _submitStatus;
            }
        }

        //for inserting family details
        public void CreateTravelFamilyDetails(List<TravelFamilyDetails> _TravelFamilyDetailsList, int _PolicyTxnSysID)
        {
            try
            {
                for (int i = 0; i < _TravelFamilyDetailsList.Count; i++)
                {
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sb = new StringBuilder();

                    

                    _sb.AppendLine("INSERT INTO TravelFamilyDetails");
                    _sb.AppendLine(" (PolicyTxnSysID,");
                    _sb.AppendLine(" FamilyName,FamilyDob,");
                    _sb.AppendLine(" FamilyRelationCode)");
                    _sb.AppendLine(" VALUES(");
                    _sb.AppendLine(" @PolicyTxnSysID,");
                    _sb.AppendLine(" @FamilyName,@FamilyDob,");
                    _sb.AppendLine(" @FamilyRelationCode)");

                    int _FamilyRelationCode = GetFamilyRelationCode(_TravelFamilyDetailsList[i].FamilyRelationName);

                    SqlCommand _cmdSql = new SqlCommand(_sb.ToString(), _conSql);
                    _cmdSql.Parameters.AddWithValue("@PolicyTxnSysID", _PolicyTxnSysID);
                    _cmdSql.Parameters.AddWithValue("@FamilyName", _TravelFamilyDetailsList[i].FamilyName);
                    _cmdSql.Parameters.AddWithValue("@FamilyDob", _TravelFamilyDetailsList[i].FamilyDob);
                    _cmdSql.Parameters.AddWithValue("@FamilyRelationCode", _FamilyRelationCode);


                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();
                }

            }
            catch (Exception ex)
            {

            }
        }

        //for getting new policy number
        private string GetNewPolicyNumber()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(PolicyNumber) LastPolicyNumber FROM TravelPolicy";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                string _result;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows[0][0] ==null)
                {
                    _result = "10001";
                }
                else
                {
                    int _tmpNumber = Convert.ToInt32(_tbl.Rows[0][0])+1;
                    _result = _tmpNumber.ToString();
                }

                return _result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //for getting relation code by relation name
        private int GetFamilyRelationCode(string _FamilyRelationCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM Relations r WHERE r.RelationName = '" + _FamilyRelationCode + "'";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                int _result;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _result = Convert.ToInt32(_tbl.Rows[0]["RelationCode"]);
                }
                else
                {

                    _result = 0;
                }

                return _result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


    }
}