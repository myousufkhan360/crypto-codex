using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using static TmsPlusRetailAPI.Models.GlobalModels;
using static TmsPlusRetailAPI.Models.TrvlPortalMdl;

namespace TmsPlusRetailAPI.DataLayer
{
    public class TrvlPortalDal
    {

        //Insert InTo Policy, Client, TrvlRisk and Contribution For Travel
        public Policy AddPolicyTrvl(Policy _Policy, Client _Client,Contribution _Contribution, TrvlRisk _TrvlRisk)
        {
            try
            {

                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();
                SqlCommand _cmdSql;



                //Insert In Main
                _sbSql.AppendLine("INSERT INTO Policy(");
                //_sbSql.AppendLine("SysID,");
                _sbSql.AppendLine("SysDate,");
                _sbSql.AppendLine("PolicyNo,");
                _sbSql.AppendLine("DocType,");
                _sbSql.AppendLine("IssueDate,");
                _sbSql.AppendLine("EffDate,");
               // _sbSql.AppendLine("ExpDate,");
                _sbSql.AppendLine("ClassCode,");
                _sbSql.AppendLine("ProductCode)");

                _sbSql.AppendLine("output INSERTED. SysID VALUES ( ");
                // _sbSql.AppendLine("@SysID,");
                _sbSql.AppendLine("@SysDate,");
                _sbSql.AppendLine("@PolicyNo,");
                _sbSql.AppendLine("('4'),");
                _sbSql.AppendLine("@IssueDate,");
                _sbSql.AppendLine("@EffDate,");
               // _sbSql.AppendLine("@ExpDate,");
                _sbSql.AppendLine("('03'),");
                _sbSql.AppendLine("@ProductCode)");


                _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                string PolicyNo = GlobalDataLayer.GetPolicyNo(_Policy);
                string ProductCode = GlobalDataLayer.GetProductCode(_Policy);



                _cmdSql.Parameters.AddWithValue("@SysDate", DateTime.Now);
                _cmdSql.Parameters.AddWithValue("@PolicyNo", PolicyNo.ToString() ?? DBNull.Value.ToString());
                _cmdSql.Parameters.AddWithValue("@IssueDate", DateTime.Now);
               // _cmdSql.Parameters.AddWithValue("@ProductCode", ProductCode.ToString());

                //To Be Entered
                _cmdSql.Parameters.AddWithValue("@EffDate", _Policy.EffDate);
               // _cmdSql.Parameters.AddWithValue("@ExpDate", _Policy.ExpDate);
                _cmdSql.Parameters.AddWithValue("@ProductCode", _Policy.ProductCode ?? DBNull.Value.ToString());


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
               // _sbSql2.AppendLine("NIC,");
               // _sbSql2.AppendLine("GenderCode,");
                _sbSql2.AppendLine("MobileNo,");
                _sbSql2.AppendLine("Email)");
                //_sbSql2.AppendLine("Address,");
               // _sbSql2.AppendLine("CityCode)");


                _sbSql2.AppendLine("output INSERTED. SysID VALUES ( ");
                //_sbSql2.AppendLine("@SysID,");
                _sbSql2.AppendLine("@SysDate,");
                _sbSql2.AppendLine("@ParentSysID,");
                _sbSql2.AppendLine("@NameOfInsured,");
                _sbSql2.AppendLine("@DOB,");
               // _sbSql2.AppendLine("@NIC,");
               // _sbSql2.AppendLine("@GenderCode,");
                _sbSql2.AppendLine("@MobileNo,");
                _sbSql2.AppendLine("@Email)");
              //  _sbSql2.AppendLine("@Address,");
               // _sbSql2.AppendLine("@CityCode)");




                _cmdSql2 = new SqlCommand(_sbSql2.ToString(), _conSql2);



                // _cmdSql.Parameters.AddWithValue("@SysID", _ClientMdlList[i].SysID);
                _cmdSql2.Parameters.AddWithValue("@SysDate", DateTime.Now);
                _cmdSql2.Parameters.AddWithValue("@ParentSysID", _TxnSysId);
                

                //To Be Entered
                _cmdSql2.Parameters.AddWithValue("@NameOfInsured", _Client.NameOfInsured ?? DBNull.Value.ToString());
                _cmdSql2.Parameters.AddWithValue("@DOB", Convert.ToDateTime(_Client.DOB));
               // _cmdSql2.Parameters.AddWithValue("@NIC", _Client.NIC);
               // _cmdSql2.Parameters.AddWithValue("@GenderCode", _Client.GenderCode);
                _cmdSql2.Parameters.AddWithValue("@MobileNo", _Client.MobileNo ?? DBNull.Value.ToString());
                _cmdSql2.Parameters.AddWithValue("@Email", _Client.Email ?? DBNull.Value.ToString());
              //  _cmdSql2.Parameters.AddWithValue("@Address", _Client.Address);
              //  _cmdSql2.Parameters.AddWithValue("@CityCode", _Client.CityCode);

                int _TxnSysId2;
                _conSql2.Open();
                _TxnSysId2 = (Int32)_cmdSql2.ExecuteScalar();
                _conSql2.Close();

                _Client.SysID = _TxnSysId2;


                //Insert In To Contribution

                SqlConnection _conSql3 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql3 = new StringBuilder();
                SqlCommand _cmdSql3;
                int Contribution = GetContributionForIns(_TrvlRisk.CategoryCode, _TrvlRisk.PlanCode, _TrvlRisk.CoveregeCode, _TrvlRisk.TenureCode);

                _sbSql3.AppendLine("INSERT INTO Contribution(");
                //_sbSql3.AppendLine("SysID,");
                _sbSql3.AppendLine("SysDate,");
                _sbSql3.AppendLine("ParentSysID,");
                _sbSql3.AppendLine("SumCovered,");
                 _sbSql3.AppendLine("Gross,");
                _sbSql3.AppendLine("FED,");
                 _sbSql3.AppendLine("FIF,");
                _sbSql3.AppendLine("SD,");
                _sbSql3.AppendLine("Net,");
                _sbSql3.AppendLine("ModeOfPayment,");
                _sbSql3.AppendLine("PaymentNo,");
                _sbSql3.AppendLine("PaymentName)");



                _sbSql3.AppendLine("output INSERTED.SysID VALUES ( ");
                    //_sbSql3.AppendLine("@SysID,");
                _sbSql3.AppendLine("@SysDate,");
                _sbSql3.AppendLine("@ParentSysID,");
                _sbSql3.AppendLine("@SumCovered,");
                _sbSql3.AppendLine("@Gross,");
                _sbSql3.AppendLine("@FED,");
                _sbSql3.AppendLine("@FIF,");
               _sbSql3.AppendLine("@SD,");
                _sbSql3.AppendLine("@Net,");
                _sbSql3.AppendLine("@ModeOfPayment,");
                _sbSql3.AppendLine("@PaymentNo,");
                _sbSql3.AppendLine("@PaymentName)");

                decimal Gross, Net, FED = 13, FIF = 1, Stamp = 50;

                //Get Rate By Product Code
                int Rate = GetRateByProductCode(_Policy.ProductCode);

                Net = (Contribution * (Rate / 100));
                Gross = (Net - Stamp) / (((FED + FIF) / 100) + 1);



                _cmdSql3 = new SqlCommand(_sbSql3.ToString(), _conSql3);


                

                // _cmdSql2.Parameters.AddWithValue("@SysID", _ContributionMdlList[i].SysID);

                _cmdSql3.Parameters.AddWithValue("@SysDate", DateTime.Now);
                _cmdSql3.Parameters.AddWithValue("@ParentSysID", _TxnSysId);


                _cmdSql3.Parameters.AddWithValue("@SumCovered", Contribution);
                _cmdSql3.Parameters.AddWithValue("@Gross", Gross);
                _cmdSql3.Parameters.AddWithValue("@FED", FED);
                _cmdSql3.Parameters.AddWithValue("@FIF", FIF);
                _cmdSql3.Parameters.AddWithValue("@SD", Stamp);
                _cmdSql3.Parameters.AddWithValue("@Net", Net);
                _cmdSql3.Parameters.AddWithValue("@ModeOfPayment", _TrvlRisk.ModeOfPaymentCode);
                _cmdSql3.Parameters.AddWithValue("@PaymentNo", _Contribution.PaymentNo ?? DBNull.Value.ToString());
                _cmdSql3.Parameters.AddWithValue("@PaymentName", _Contribution.PaymentName ?? DBNull.Value.ToString());


                int _TxnSysId3;
                _conSql3.Open();
                _TxnSysId3 = (Int32)_cmdSql3.ExecuteScalar();
                _conSql3.Close();



                //Insert Into TrvlRisk
                SqlConnection _conSql4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql4 = new StringBuilder();
                SqlCommand _cmdSql4;

                _sbSql4.AppendLine("INSERT INTO TrvlRisk(");
               // _sbSql.AppendLine("SysID,");
                _sbSql4.AppendLine("SysDate,");
                _sbSql4.AppendLine("ParentSysID,");
                _sbSql4.AppendLine("CategoryCode,");
                _sbSql4.AppendLine("PlanCode,");
                _sbSql4.AppendLine("CoveregeCode,");
                _sbSql4.AppendLine("TenureCode,");
                _sbSql4.AppendLine("DestinationCode,");
                _sbSql4.AppendLine("BenificiaryName,");
                _sbSql4.AppendLine("BenificiaryRelationCode,");
                _sbSql4.AppendLine("ModeOfPaymentCode)");



                _sbSql4.AppendLine("output INSERTED. SysID VALUES ( ");
                //// _sbSql44.AppendLine("@SysID,");
                _sbSql4.AppendLine("@SysDate,");
                _sbSql4.AppendLine("@ParentSysID,");
                _sbSql4.AppendLine("@CategoryCode,");
                _sbSql4.AppendLine("@PlanCode,");
                _sbSql4.AppendLine("@CoveregeCode,");
                _sbSql4.AppendLine("@TenureCode,");
                _sbSql4.AppendLine("@DestinationCode,");
                _sbSql4.AppendLine("@BenificiaryName,");
                _sbSql4.AppendLine("@BenificiaryRelationCode,");
                _sbSql4.AppendLine("@ModeOfPaymentCode)");






                _cmdSql4 = new SqlCommand(_sbSql4.ToString(), _conSql4);




                _cmdSql4.Parameters.AddWithValue("@SysDate", DateTime.Now);
                _cmdSql4.Parameters.AddWithValue("@ParentSysID", _TxnSysId);

                _cmdSql4.Parameters.AddWithValue("@CategoryCode", _TrvlRisk.CategoryCode);
                _cmdSql4.Parameters.AddWithValue("@PlanCode", _TrvlRisk.PlanCode);
                _cmdSql4.Parameters.AddWithValue("@CoveregeCode", _TrvlRisk.CoveregeCode);
                _cmdSql4.Parameters.AddWithValue("@TenureCode", _TrvlRisk.TenureCode);
                _cmdSql4.Parameters.AddWithValue("@DestinationCode", _TrvlRisk.DestinationCode);
                _cmdSql4.Parameters.AddWithValue("@BenificiaryName", _TrvlRisk.BenificiaryName ?? DBNull.Value.ToString());
                _cmdSql4.Parameters.AddWithValue("@BenificiaryRelationCode", _TrvlRisk.BenificiaryRelationCode);
                _cmdSql4.Parameters.AddWithValue("@ModeOfPaymentCode", _TrvlRisk.ModeOfPaymentCode);



                int _TxnSysId4;
                _conSql4.Open();
                _TxnSysId4 = (Int32)_cmdSql4.ExecuteScalar();
                _conSql4.Close();

                _TrvlRisk.SysID = _TxnSysId4;

               
                _Policy.ClassCode = "03";
                _Policy.DocType = "4";
                _Policy.ClassName = GlobalDataLayer.GetPolicyClassNameByCode("03");
                _Policy.DocName = GlobalDataLayer.GetDocTypeNameByDocTypeCode("4");
                _Policy.PolicyNo = PolicyNo;
                _Policy.ProductName = GlobalDataLayer.GetProductNameByCode(_Policy.ProductCode);

                Client _Client1 = new Client();

                _Client1.NameOfInsured = _Client.NameOfInsured;
                _Client1.DOB = _Client.DOB;
               // _Client1.NIC = _Client.NIC;
               // _Client1.GenderCode = _Client.GenderCode;
                _Client1.MobileNo = _Client.MobileNo;
                _Client1.Email = _Client.Email;
                // _Client1.Address = _Client.Address;
                // _Client1.CityCode = _Client.CityCode;
                // _Client1.GenderName = GlobalDataLayer.GetGenderNameByCode(_Client.GenderCode);
                //  _Client1.CityName = GlobalDataLayer.GetCityNameByCode(_Client.CityCode);
                _Client.SysID = _TxnSysId2;

                Contribution _Contribution1 = new Contribution();

                _Contribution1.SumCovered = Contribution;
                _Contribution1.Gross = Gross;
                _Contribution1.FED = FED;
                _Contribution1.FIF = FIF;
                _Contribution1.SD = Stamp;
                _Contribution1.Net = Net;
                _Contribution1.PaymentName = _Contribution.PaymentName;
                _Contribution1.PaymentNo = _Contribution.PaymentNo;
                _Contribution1.ModeOfPayment = _Contribution.ModeOfPayment;
                _Contribution1.ModeOfPaymentName = GetPaymentModeNameByCode(_Contribution.ModeOfPayment);
                _Contribution.SysID = _TxnSysId3;


                

                _Policy.client = _Client1;
                _Policy.contribution = _Contribution1;
             
                _Policy.SysID = _TxnSysId;

                return _Policy;

            }
            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);


                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Travel Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }


        //Insert InTo TrvlFamilyDetailsRisk 
        public TrvlFamilyDetailsRisk AddTrvlFamilyDetails(TrvlRisk _TrvlRisk,TrvlFamilyDetailsRisk _TrvlFamilyDetailsRisk)
        {
            try
            {

                //If Travel With Family Selected
                if (_TrvlRisk.CoveregeCode == 2)
                {
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("INSERT INTO TrvlFamilyDetailsRisk(");
                    //_sbSql.AppendLine("SysID,");
                    _sbSql.AppendLine("SysDate,");
                    _sbSql.AppendLine("RiskSysID,");
                    _sbSql.AppendLine("FamilyName,");
                    _sbSql.AppendLine("DOB,");
                    _sbSql.AppendLine("FamilyRelationCode)");

                    _sbSql.AppendLine("output INSERTED. SysID VALUES ( ");
                    // _sbSql.AppendLine("@SysID,");
                    _sbSql.AppendLine("@SysDate,");
                    _sbSql.AppendLine("@RiskSysID,");
                    //_sbSql.AppendLine("(SELECT MAX(SysID) LastSysID FROM TrvlRisk),");
                    _sbSql.AppendLine("@FamilyName,");
                    _sbSql.AppendLine("@DOB,");
                    _sbSql.AppendLine("@FamilyRelationCode)");


                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    _cmdSql.Parameters.AddWithValue("@SysDate", DateTime.Now);


                    //To Be Entered
                    _cmdSql.Parameters.AddWithValue("@RiskSysID", _TrvlRisk.SysID);
                    _cmdSql.Parameters.AddWithValue("@FamilyName", _TrvlFamilyDetailsRisk.FamilyName);
                    _cmdSql.Parameters.AddWithValue("@DOB", _TrvlFamilyDetailsRisk.DOB);
                    _cmdSql.Parameters.AddWithValue("@FamilyRelationCode", _TrvlFamilyDetailsRisk.FamilyRelationCode);


                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();

                    _TrvlFamilyDetailsRisk.FamilyRelationName = GlobalDataLayer.GetRelationNameByCode(_TrvlFamilyDetailsRisk.FamilyRelationCode);
                    _TrvlFamilyDetailsRisk.SysID = _TxnSysId;

                    return _TrvlFamilyDetailsRisk;

                }

                else
                {
                    _TrvlFamilyDetailsRisk.Message = "Sorry you have not Selected Travel with Option as Family";
                    return _TrvlFamilyDetailsRisk;
                }




            }

            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Travel Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }


        //for getting contribution for insert
        public int GetContributionForIns(int _TravelCategoryCode, int _TravelPlanCode, int _TravelCoverageTypeCode, int _TravelTenureCode)
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

                return _TravelContribution.Contribution;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Getting Payment Mode Name By Code
        public string GetPaymentModeNameByCode(int _PaymentModeCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                DataTable _tblSqla = new DataTable();
                Contribution _Contribution;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM PaymentMethods Where PaymentMethodCode = @PaymentMethodCode", conn);

                    command.Parameters.Add(new SqlParameter("@PaymentMethodCode", _PaymentModeCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _Contribution = new Contribution();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _Contribution.ModeOfPaymentName = _tblSqla.Rows[i]["PaymentMethodName"].ToString();

                    }
                    return _Contribution.ModeOfPaymentName;

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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Travel Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //Getting Rate From Product Code
        public int GetRateByProductCode(string _ProductCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                DataTable _tblSqla = new DataTable();
                TrvlRisk _TrvlRisk;

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
                    _TrvlRisk = new TrvlRisk();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _TrvlRisk.Rate = Convert.ToInt32(_tblSqla.Rows[i]["Rate"]);

                    }
                    return _TrvlRisk.Rate;

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

       

        //For Drop Downs

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
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Travel Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
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
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Travel Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
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
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Travel Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //for getting all Travel Tenures (DDL)
        public List<ddlTravelTenure> getTravelTenureList()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT * FROM vuTravelContributionSetup WHERE TravelCategoryCode =" + _TravelCategoryCode + " AND TravelPlanCode = " + _TravelPlanCode + " AND TravelCoverageTypeCode =  " + _TravelCoverageTypeCode;
                string _sqlString = "SELECT * FROM TravelTenure";
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
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Travel Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
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
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Travel Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
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
                    _sqlString = "SELECT  CountryCode TravelDestinationCode,CountryName TravelDestinationName FROM TrvlCountry";
                }
                else if (_TravelCategoryCode == 3)
                {
                    _sqlString = "SELECT  CityCode TravelDestinationCode,CityName TravelDestinationName  FROM TrvlCity";
                }
                else if (_TravelCategoryCode == 4)
                {
                    _sqlString = "SELECT  CountryCode TravelDestinationCode,CountryName TravelDestinationName FROM TrvlCountry WHERE CountryCode=152";
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
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Travel Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
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
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Travel Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
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
                string lineNumber = ex.StackTrace;
                int startIndex = lineNumber.IndexOf("line");
                string domain = lineNumber.Substring(startIndex);

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Travel Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name,domain);
                return null;
            }
        }

        //For Drop Downs

    }
}