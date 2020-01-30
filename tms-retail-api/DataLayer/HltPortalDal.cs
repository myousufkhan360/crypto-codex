using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using static TmsPlusRetailAPI.Models.GlobalModels;
using static TmsPlusRetailAPI.Models.HltPortalMdl;

namespace TmsPlusRetailAPI.DataLayer
{
    public class HltPortalDal
    {

        //Insert InTo Policy, Client, HltRisk, PurchaseProtection And Contribution For Health
        public Policy AddPolicyHlt(Policy _Policy, Client _Client, HltRisk _HltRisk)
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
                _sbSql.AppendLine("ExpDate,");
                _sbSql.AppendLine("ClassCode)");
               // _sbSql.AppendLine("ProductCode)");

                _sbSql.AppendLine("output INSERTED. SysID VALUES ( ");
                // _sbSql.AppendLine("@SysID,");
                _sbSql.AppendLine("@SysDate,");
                _sbSql.AppendLine("@PolicyNo,");
                _sbSql.AppendLine("('4'),");
                _sbSql.AppendLine("@IssueDate,");
                _sbSql.AppendLine("@EffDate,");
                _sbSql.AppendLine("@ExpDate,");
                _sbSql.AppendLine("('08'))");
                //_sbSql.AppendLine("@ProductCode)");


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
               // _cmdSql.Parameters.AddWithValue("@ProductCode", _Policy.ProductCode);


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

                //_sbSql2.AppendLine("Email,");
               // _sbSql2.AppendLine("Address,");
               // _sbSql2.AppendLine("CityCode,");
                _sbSql2.AppendLine("EmpID,");
                _sbSql2.AppendLine("HltID,");
                _sbSql2.AppendLine("PlanID)");



                _sbSql2.AppendLine("output INSERTED. SysID VALUES ( ");
                //_sbSql2.AppendLine("@SysID,");
                _sbSql2.AppendLine("@SysDate,");
                _sbSql2.AppendLine("@ParentSysID,");
                _sbSql2.AppendLine("@NameOfInsured,");
                _sbSql2.AppendLine("@DOB,");
                _sbSql2.AppendLine("@NIC,");
                _sbSql2.AppendLine("@GenderCode,");
                _sbSql2.AppendLine("@MobileNo,");
               // _sbSql2.AppendLine("@Email,");
               // _sbSql2.AppendLine("@Address,");
               // _sbSql2.AppendLine("@CityCode,");
                _sbSql2.AppendLine("@EmpID,");
                _sbSql2.AppendLine("@HltID,");
                _sbSql2.AppendLine("@PlanID)");





                _cmdSql2 = new SqlCommand(_sbSql2.ToString(), _conSql2);

      

                // _cmdSql.Parameters.AddWithValue("@SysID", _ClientMdlList[i].SysID);
                _cmdSql2.Parameters.AddWithValue("@SysDate", DateTime.Now);
                _cmdSql2.Parameters.AddWithValue("@ParentSysID", _TxnSysId);


                //To Be Entered
                _cmdSql2.Parameters.AddWithValue("@NameOfInsured", _Client.NameOfInsured);
                _cmdSql2.Parameters.AddWithValue("@DOB", Convert.ToDateTime(_Client.DOB));
                _cmdSql2.Parameters.AddWithValue("@NIC", _Client.NIC);
                _cmdSql2.Parameters.AddWithValue("@GenderCode", _Client.GenderCode);
                _cmdSql2.Parameters.AddWithValue("@MobileNo", _Client.MobileNo);
                // _cmdSql2.Parameters.AddWithValue("@Email", _Client.Email);
                // _cmdSql2.Parameters.AddWithValue("@Address", _Client.Address);
                // _cmdSql2.Parameters.AddWithValue("@CityCode", _Client.CityCode);
                _cmdSql2.Parameters.AddWithValue("@EmpID", _Client.EmpID);
                _cmdSql2.Parameters.AddWithValue("@HltID", _Client.HltID);
                _cmdSql2.Parameters.AddWithValue("@PlanID", _Client.PlanID);


                int _TxnSysId2;
                _conSql2.Open();
                _TxnSysId2 = (Int32)_cmdSql2.ExecuteScalar();
                _conSql2.Close();

                _Client.SysID = _TxnSysId2;


                //Get Base Rate For Hospitalization by Limit1 and Limit2
                decimal HosBaseRate = GetHosBaseRate(_HltRisk.HosL1, _HltRisk.HosL2);

                decimal MatBaseRate;
                //Get Base Rate For Hospitalization by Limit1 and Limit2
                if (_HltRisk.IsMat == Convert.ToBoolean(1))
                {
                   MatBaseRate = GetMatBaseRate(_HltRisk.MatL1, _HltRisk.MatL2);
           
                }

                else
                {
                     MatBaseRate = 0;
                    _HltRisk.MatL1 = 0;
                    _HltRisk.MatL2 = 0;
                }

                //OPD Rate
                decimal OPDRate;

                if (_HltRisk.IsOPD == Convert.ToBoolean(1))
                {
                    OPDRate = _HltRisk.OPDSumCovered * (_HltRisk.OPDRate / 100);
                }

                else
                {
                    OPDRate = 0;
                    _HltRisk.OPDSumCovered = 0;
                    _HltRisk.OPDRate = 0;

                }
                //Calculate Total
                decimal Total = HosBaseRate + MatBaseRate + OPDRate;

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

                _cmdSql3.Parameters.AddWithValue("@SumCovered", Total);

                decimal Gross, Net, FED = 0, FIF = 1, Stamp = 50;

                Net = (Total);
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

                

                //Insert Into HltRisk
                SqlConnection _conSql4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql4 = new StringBuilder();
                SqlCommand _cmdSql4;

                _sbSql4.AppendLine("INSERT INTO HltRisk(");
                //_sbSql.AppendLine("SysID,");
                _sbSql4.AppendLine("SysDate,");
                _sbSql4.AppendLine("ParentSysID,");
                _sbSql4.AppendLine("PlanCode,");
                _sbSql4.AppendLine("HostBaseRate,");
                _sbSql4.AppendLine("MatBaseRate,");
                _sbSql4.AppendLine("OPDSumCovered,");
                _sbSql4.AppendLine("OPDRate,");
                _sbSql4.AppendLine("HosDisc,");
                _sbSql4.AppendLine("IsMat,");
                _sbSql4.AppendLine("IsOPD,");
                _sbSql4.AppendLine("MatDisc)");





                _sbSql4.AppendLine("output INSERTED. SysID VALUES ( ");
                // _sbSql4.AppendLine("@SysID,");
                _sbSql4.AppendLine("@SysDate,");
                _sbSql4.AppendLine("@ParentSysID,");
                _sbSql4.AppendLine("@PlanCode,");
                _sbSql4.AppendLine("@HostBaseRate,");
                _sbSql4.AppendLine("@MatBaseRate,");
                _sbSql4.AppendLine("@OPDSumCovered,");
                _sbSql4.AppendLine("@OPDRate,");
                _sbSql4.AppendLine("(0),");
                _sbSql4.AppendLine("@IsMat,");
                _sbSql4.AppendLine("@IsOPD,");
                _sbSql4.AppendLine("(0))");





                _cmdSql4 = new SqlCommand(_sbSql4.ToString(), _conSql4);




                _cmdSql4.Parameters.AddWithValue("@SysDate", DateTime.Now);
                _cmdSql4.Parameters.AddWithValue("@ParentSysID", _TxnSysId);

                _cmdSql4.Parameters.AddWithValue("@PlanCode", _HltRisk.PlanCode);
                _cmdSql4.Parameters.AddWithValue("@HostBaseRate", HosBaseRate);
                _cmdSql4.Parameters.AddWithValue("@MatBaseRate", MatBaseRate);
                _cmdSql4.Parameters.AddWithValue("@OPDSumCovered", _HltRisk.OPDSumCovered);
                _cmdSql4.Parameters.AddWithValue("@OPDRate", _HltRisk.OPDRate);

                if (_HltRisk.IsMat == Convert.ToBoolean(1))
                {
                    _cmdSql4.Parameters.AddWithValue("@IsMat", true);
                }
                else
                {
                    _cmdSql4.Parameters.AddWithValue("@IsMat", false);
                }

                if (_HltRisk.IsOPD == Convert.ToBoolean(1))
                {
                    _cmdSql4.Parameters.AddWithValue("@IsOPD", true);
                }
                else
                {
                    _cmdSql4.Parameters.AddWithValue("@IsOPD", false);
                }

                int _TxnSysId4;
                _conSql4.Open();
                _TxnSysId4 = (Int32)_cmdSql4.ExecuteScalar();
                _conSql4.Close();

                _HltRisk.SysID = _TxnSysId4;


                
                _Policy.ClassCode = "08";
                _Policy.DocType = "4";
                _Policy.ClassName = GlobalDataLayer.GetPolicyClassNameByCode("08");
                _Policy.DocName = GlobalDataLayer.GetDocTypeNameByDocTypeCode("4");
                _Policy.PolicyNo = PolicyNo;
              //  _Policy.ProductName = GlobalDataLayer.GetProductNameByCode(_Policy.ProductCode);


                Client _Client1 = new Client();

                _Client1.NameOfInsured = _Client.NameOfInsured;
                _Client1.DOB = _Client.DOB;
                _Client1.NIC = _Client.NIC;
                _Client1.GenderCode = _Client.GenderCode;
                _Client1.MobileNo = _Client.MobileNo;
               // _Client1.Email = _Client.Email;
                //_Client1.Address = _Client.Address;
               // _Client1.CityCode = _Client.CityCode;
                _Client1.GenderName = GlobalDataLayer.GetGenderNameByCode(_Client.GenderCode);
                // _Client1.CityName = GlobalDataLayer.GetCityNameByCode(_Client.CityCode);
                _Client1.HltID = _Client.HltID;
                _Client1.EmpID = _Client.EmpID;
                _Client1.PlanID = _Client.PlanID;
                _Client1.PlanName = GetPlanNameByCode(_Client.PlanID);

                 Contribution _Contribution1 = new Contribution();

                _Contribution1.SumCovered = Total;
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
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Health Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        //Insert InTO Hlt Family Details Risk
        public HltFamilyDetailsRisk AddHltFamilyDetails(HltRisk _HltRisk, HltFamilyDetailsRisk _HltFamilyDetailsRisk)
        {
            try
            {

               
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("INSERT INTO HltFamilyDetailsRisk(");
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
                    _sbSql.AppendLine("@FamilyName,");
                    _sbSql.AppendLine("@DOB,");
                    _sbSql.AppendLine("@FamilyRelationCode)");



                _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    _cmdSql.Parameters.AddWithValue("@SysDate", DateTime.Now);


                    //To Be Entered
                    _cmdSql.Parameters.AddWithValue("@RiskSysID", _HltRisk.SysID);
                    _cmdSql.Parameters.AddWithValue("@FamilyName", _HltFamilyDetailsRisk.FamilyName);
                    _cmdSql.Parameters.AddWithValue("@DOB", _HltFamilyDetailsRisk.DOB);
                    _cmdSql.Parameters.AddWithValue("@FamilyRelationCode", _HltFamilyDetailsRisk.FamilyRelationCode);



                int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();

                _HltFamilyDetailsRisk.FamilyRelationName = GlobalDataLayer.GetRelationNameByCode(_HltFamilyDetailsRisk.FamilyRelationCode);
                _HltFamilyDetailsRisk.SysID = _TxnSysId;

                    return _HltFamilyDetailsRisk;

               



            }

            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Health Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }


        //Get Base Rate For Hospitalization by Limit1 and Limit2      
        public decimal GetHosBaseRate(int L1,int L2)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                HltRisk _HltRisk;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM HltBaseRate Where LIMIT1 = @LIMIT1 AND LIMIT2 = @LIMIT2 AND TYPE = 'H' ", conn);

                    command.Parameters.Add(new SqlParameter("@LIMIT1", L1));
                    command.Parameters.Add(new SqlParameter("@LIMIT2", L2));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _HltRisk = new HltRisk();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _HltRisk.HostBaseRate = Convert.ToDecimal(_tblSqla.Rows[i]["BASE_RATE"]);

                    }
                    return _HltRisk.HostBaseRate;

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

        //Get Base Rate For Maturnity by Limit1 and Limit2      
        public decimal GetMatBaseRate(int L1, int L2)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                HltRisk _HltRisk;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM HltBaseRate Where LIMIT1 = @LIMIT1 AND LIMIT2 = @LIMIT2 AND TYPE = 'M' ", conn);

                    command.Parameters.Add(new SqlParameter("@LIMIT1", L1));
                    command.Parameters.Add(new SqlParameter("@LIMIT2", L2));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _HltRisk = new HltRisk();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _HltRisk.MatBaseRate = Convert.ToDecimal(_tblSqla.Rows[i]["BASE_RATE"]);

                    }
                    return _HltRisk.MatBaseRate;

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

        //Get Plan Name By Code
        public static string GetPlanNameByCode(int _PlanCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                DataTable _tblSqla = new DataTable();
                Client _Client;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM HltGroup Where GroupCode = @GroupCode", conn);

                    command.Parameters.Add(new SqlParameter("@GroupCode", _PlanCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _Client = new Client();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _Client.PlanName = _tblSqla.Rows[i]["GroupName"].ToString();

                    }
                    return _Client.PlanName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Health Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        //For Drop Down

        //for getting all Health Groups
        public List<HltGroup> GetHltGroup()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM HltGroup";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<HltGroup> _HltGroupList = new List<HltGroup>();
                HltGroup _HltGroup;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _HltGroup = new HltGroup();

                        _HltGroup.SysID = Convert.ToInt32(_tblSqla.Rows[i]["SysID"]);
                        _HltGroup.SysDate = Convert.ToDateTime(_tblSqla.Rows[i]["SysDate"]);
                        _HltGroup.GroupCode = Convert.ToInt32(_tblSqla.Rows[i]["GroupCode"]);
                        _HltGroup.GroupName = _tblSqla.Rows[i]["GroupName"].ToString();




                        _HltGroupList.Add(_HltGroup);
                    }

                    return _HltGroupList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Health Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        //For Getting all Hospitalization Limit1
        public List<HealthBaseRate> GetHealthBaseRateL1H()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM HltBaseRate WHERE TYPE='H'";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<HealthBaseRate> _HealthBaseRateList = new List<HealthBaseRate>();
                HealthBaseRate _HealthBaseRate;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _HealthBaseRate = new HealthBaseRate();

                       // _HealthBaseRate.SysID = Convert.ToInt32(_tblSqla.Rows[i]["SysID"]);
                       // _HealthBaseRate.SysDate = Convert.ToDateTime(_tblSqla.Rows[i]["SysDate"]);
                       // _HealthBaseRate.BASE_RATE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["BASE_RATE_CODE"]);
                        _HealthBaseRate.LIMIT1 = Convert.ToInt32(_tblSqla.Rows[i]["LIMIT1"]);
                      //  _HealthBaseRate.LIMIT2 = Convert.ToInt32(_tblSqla.Rows[i]["LIMIT2"]);
                        _HealthBaseRate.BASE_RATE = Convert.ToInt32(_tblSqla.Rows[i]["BASE_RATE"]);
                        _HealthBaseRate.TYPE = _tblSqla.Rows[i]["TYPE"].ToString();





                        _HealthBaseRateList.Add(_HealthBaseRate);
                    }

                    return _HealthBaseRateList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Health Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        //For Getting Hospitalization Limit2 According to Limit1
        public List<HealthBaseRate> GetHealthBaseRateL2H(HealthBaseRate _HealthBaseRate1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM HltBaseRate WHERE TYPE='H' AND LIMIT1 = "+_HealthBaseRate1.LIMIT1;
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<HealthBaseRate> _HealthBaseRateList = new List<HealthBaseRate>();
                HealthBaseRate _HealthBaseRate;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _HealthBaseRate = new HealthBaseRate();

                        //_HealthBaseRate.SysID = Convert.ToInt32(_tblSqla.Rows[i]["SysID"]);
                       // _HealthBaseRate.SysDate = Convert.ToDateTime(_tblSqla.Rows[i]["SysDate"]);
                       // _HealthBaseRate.BASE_RATE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["BASE_RATE_CODE"]);
                       // _HealthBaseRate.LIMIT1 = Convert.ToInt32(_tblSqla.Rows[i]["LIMIT1"]);
                        _HealthBaseRate.LIMIT2 = Convert.ToInt32(_tblSqla.Rows[i]["LIMIT2"]);
                        _HealthBaseRate.BASE_RATE = Convert.ToInt32(_tblSqla.Rows[i]["BASE_RATE"]);
                        _HealthBaseRate.TYPE = _tblSqla.Rows[i]["TYPE"].ToString();





                        _HealthBaseRateList.Add(_HealthBaseRate);
                    }

                    return _HealthBaseRateList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Health Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }


        //For Getting all Maturnity Limit1
        public List<HealthBaseRate> GetHealthBaseRateL1M()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM HltBaseRate WHERE TYPE='M'";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<HealthBaseRate> _HealthBaseRateList = new List<HealthBaseRate>();
                HealthBaseRate _HealthBaseRate;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _HealthBaseRate = new HealthBaseRate();

                        // _HealthBaseRate.SysID = Convert.ToInt32(_tblSqla.Rows[i]["SysID"]);
                        // _HealthBaseRate.SysDate = Convert.ToDateTime(_tblSqla.Rows[i]["SysDate"]);
                        // _HealthBaseRate.BASE_RATE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["BASE_RATE_CODE"]);
                        _HealthBaseRate.LIMIT1 = Convert.ToInt32(_tblSqla.Rows[i]["LIMIT1"]);
                        //  _HealthBaseRate.LIMIT2 = Convert.ToInt32(_tblSqla.Rows[i]["LIMIT2"]);
                        _HealthBaseRate.BASE_RATE = Convert.ToInt32(_tblSqla.Rows[i]["BASE_RATE"]);
                        _HealthBaseRate.TYPE = _tblSqla.Rows[i]["TYPE"].ToString();





                        _HealthBaseRateList.Add(_HealthBaseRate);
                    }

                    return _HealthBaseRateList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Health Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        //For Getting Hospitalization Limit2 According to Limit1
        public List<HealthBaseRate> GetHealthBaseRateL2M(HealthBaseRate _HealthBaseRate1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM HltBaseRate WHERE TYPE='M' AND LIMIT1 = " + _HealthBaseRate1.LIMIT1;
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<HealthBaseRate> _HealthBaseRateList = new List<HealthBaseRate>();
                HealthBaseRate _HealthBaseRate;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _HealthBaseRate = new HealthBaseRate();

                        //_HealthBaseRate.SysID = Convert.ToInt32(_tblSqla.Rows[i]["SysID"]);
                        // _HealthBaseRate.SysDate = Convert.ToDateTime(_tblSqla.Rows[i]["SysDate"]);
                        // _HealthBaseRate.BASE_RATE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["BASE_RATE_CODE"]);
                        // _HealthBaseRate.LIMIT1 = Convert.ToInt32(_tblSqla.Rows[i]["LIMIT1"]);
                        _HealthBaseRate.LIMIT2 = Convert.ToInt32(_tblSqla.Rows[i]["LIMIT2"]);
                        _HealthBaseRate.BASE_RATE = Convert.ToInt32(_tblSqla.Rows[i]["BASE_RATE"]);
                        _HealthBaseRate.TYPE = _tblSqla.Rows[i]["TYPE"].ToString();





                        _HealthBaseRateList.Add(_HealthBaseRate);
                    }

                    return _HealthBaseRateList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Health Portal DataLayer", System.Reflection.MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        //For Drop Down

    }
}