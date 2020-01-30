using ProductSetupApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace ProductSetupApi.DataLayers
{
    public class ProductSetupDal
    {
        //for getting all Product Clients
        public List<ProductClientMdl> GetClient()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT TxnSysID,ClientCode,ClientName FROM ClientProductSetup";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductClientMdl> _ProductClientMdlList = new List<ProductClientMdl>();
                ProductClientMdl _ProductClientMdl;


                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ProductClientMdl = new ProductClientMdl();

                        _ProductClientMdl.TxnSysID = Convert.ToInt32(_tbl.Rows[i]["TxnSysID"].ToString());
                        _ProductClientMdl.ClientCode = _tbl.Rows[i]["ClientCode"].ToString();
                        _ProductClientMdl.ClientName = _tbl.Rows[i]["ClientName"].ToString();
                       // _ProductClientMdl.NtnNo = _tbl.Rows[i]["NtnNo"].ToString();
                       // _ProductClientMdl.NicNo = _tbl.Rows[i]["NicNo"].ToString();
                      //  _ProductClientMdl.Address = _tbl.Rows[i]["Address"].ToString();
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }


        //for getting all Product Agents
        public List<ProductAgentMdl> GetAgent()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM AgentProductSetup";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductAgentMdl> _ProductAgentMdlList = new List<ProductAgentMdl>();
                ProductAgentMdl _ProductAgentMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ProductAgentMdl = new ProductAgentMdl();
                        _ProductAgentMdl.AgentCode = _tbl.Rows[i]["AgentCode"].ToString();
                        _ProductAgentMdl.AgentName = _tbl.Rows[i]["AgentName"].ToString();
                        _ProductAgentMdl.NtnNo = _tbl.Rows[i]["NtnNo"].ToString();
                        _ProductAgentMdl.NicNo = _tbl.Rows[i]["NicNo"].ToString();
                        _ProductAgentMdlList.Add(_ProductAgentMdl);
                    }

                    return _ProductAgentMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }


        //for getting all Product Clients For Policy
        public List<ProductClientMdl> GetClientForPol()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM ClientProductSetup";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductClientMdl> _ProductClientMdlList = new List<ProductClientMdl>();
                ProductClientMdl _ProductClientMdl;


                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ProductClientMdl = new ProductClientMdl();

                        _ProductClientMdl.TxnSysID = Convert.ToInt32(_tbl.Rows[i]["TxnSysID"].ToString());
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //for getting all Product Agents For Policy
        public List<ProductAgentMdl> GetAgentForPol()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM AgentProductSetup";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductAgentMdl> _ProductAgentMdlList = new List<ProductAgentMdl>();
                ProductAgentMdl _ProductAgentMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ProductAgentMdl = new ProductAgentMdl();
                        _ProductAgentMdl.AgentCode = _tbl.Rows[i]["AgentCode"].ToString();
                        _ProductAgentMdl.AgentName = _tbl.Rows[i]["AgentName"].ToString();
                        _ProductAgentMdl.NtnNo = _tbl.Rows[i]["NtnNo"].ToString();
                        _ProductAgentMdl.NicNo = _tbl.Rows[i]["NicNo"].ToString();
                        _ProductAgentMdlList.Add(_ProductAgentMdl);
                    }

                    return _ProductAgentMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //for getting all Product Conditions
        public List<ProductConditionsMdl> GetConditions()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM ConditionsProductSetup";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductConditionsMdl> _ProductConditionsMdlList = new List<ProductConditionsMdl>();
                ProductConditionsMdl _ProductConditionsMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ProductConditionsMdl = new ProductConditionsMdl();
                        _ProductConditionsMdl.ConditionCode = _tbl.Rows[i]["ConditionCode"].ToString();
                        _ProductConditionsMdl.ConditionType = _tbl.Rows[i]["ConditionType"].ToString();
                        _ProductConditionsMdl.ConditionShText = _tbl.Rows[i]["ConditionShText"].ToString();
                      //  _ProductConditionsMdl.ConditionText = _tbl.Rows[i]["ConditionText"].ToString();
                        _ProductConditionsMdl.PolicyTypeCode = _tbl.Rows[i]["PolicyTypeCode"].ToString();

                        _ProductConditionsMdlList.Add(_ProductConditionsMdl);
                    }

                    return _ProductConditionsMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

       
        //for getting all Product Policy Class
        public List<ProductPolicyClassMdl> GetPolicyClass()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM PolicyClassProductSetup";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductPolicyClassMdl> _ProductPolicyClassMdlList = new List<ProductPolicyClassMdl>();
                ProductPolicyClassMdl _ProductPolicyClassMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ProductPolicyClassMdl = new ProductPolicyClassMdl();
                        _ProductPolicyClassMdl.PolicyClassCode = _tbl.Rows[i]["PolicyClassCode"].ToString();
                        _ProductPolicyClassMdl.PolicyClassName = _tbl.Rows[i]["PolicyClassName"].ToString();
                        

                        _ProductPolicyClassMdlList.Add(_ProductPolicyClassMdl);
                    }

                    return _ProductPolicyClassMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }


        //for getting all Product Policy type
        public List<ProductPolicyTypeMdl> GetPolicyType()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM PolicyTypeProductSetup WHERE PolicyClassCode = '02'";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductPolicyTypeMdl> _ProductPolicyTypeMdlList = new List<ProductPolicyTypeMdl>();
                ProductPolicyTypeMdl _ProductPolicyTypeMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ProductPolicyTypeMdl = new ProductPolicyTypeMdl();
                        _ProductPolicyTypeMdl.PolicyClassCode = _tbl.Rows[i]["PolicyClassCode"].ToString();
                        _ProductPolicyTypeMdl.PolicyTypeCode = _tbl.Rows[i]["PolicyTypeCode"].ToString();
                        _ProductPolicyTypeMdl.PolicyTypeName = _tbl.Rows[i]["PolicyTypeName"].ToString();


                        _ProductPolicyTypeMdlList.Add(_ProductPolicyTypeMdl);
                    }

                    return _ProductPolicyTypeMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }


        //for getting all Product Rating Factor
        public List<RatingFactorMdl> GetRatingFactor()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM RatingProductSetup";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<RatingFactorMdl> _RatingFactorMdlList = new List<RatingFactorMdl>();
                RatingFactorMdl _RatingFactorMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _RatingFactorMdl = new RatingFactorMdl();
                        _RatingFactorMdl.RatingFactorCode = _tbl.Rows[i]["RatingFactorCode"].ToString();
                        _RatingFactorMdl.RatingFactorName = _tbl.Rows[i]["RatingFactorName"].ToString();
                        


                        _RatingFactorMdlList.Add(_RatingFactorMdl);
                    }

                    return _RatingFactorMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }


        //for getting all Product Warranties
        public List<WarrantiesMdl> GetWarranties()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM WarrantiesProductSetup";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<WarrantiesMdl> _WarrantiesMdlList = new List<WarrantiesMdl>();
                WarrantiesMdl _WarrantiesMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _WarrantiesMdl = new WarrantiesMdl();
                        _WarrantiesMdl.WarrantyCode = _tbl.Rows[i]["WarrantyCode"].ToString();
                        _WarrantiesMdl.WarrantyShText = _tbl.Rows[i]["WarrantyShText"].ToString();
                        _WarrantiesMdl.WarrantyText = _tbl.Rows[i]["WarrantyText"].ToString();
                        _WarrantiesMdl.PolicyTypeCode = _tbl.Rows[i]["PolicyTypeCode"].ToString();



                        _WarrantiesMdlList.Add(_WarrantiesMdl);
                    }

                    return _WarrantiesMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }


        //for getting all Product Yes and No
        public List<YesNoMdl> GetYesNo()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM YesNoProductSetup";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<YesNoMdl> _YesNoMdlList = new List<YesNoMdl>();
                YesNoMdl _YesNoMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _YesNoMdl = new YesNoMdl();
                        _YesNoMdl.YesNoText = _tbl.Rows[i]["YesNoText"].ToString();
                        _YesNoMdl.TxnSysID = Convert.ToInt32(_tbl.Rows[i]["TxnSysID"]);
                        _YesNoMdl.TrueFalse = _tbl.Rows[i]["TrueFalse"].ToString();                      



                        _YesNoMdlList.Add(_YesNoMdl);
                    }

                    return _YesNoMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //For getting all Accessories
        public List<InsAccessoriesMdl> GetAcessories()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM InsAccessories WHERE ACCESSORY_CATEGORY_CODE = 3 ";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<InsAccessoriesMdl> _InsAccessoriesMdlList = new List<InsAccessoriesMdl>();
                InsAccessoriesMdl _InsAccessoriesMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _InsAccessoriesMdl = new InsAccessoriesMdl();

                       // _InsAccessoriesMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _InsAccessoriesMdl.ACCESSORY_CODE = Convert.ToInt32(_tblSqla.Rows[i]["ACCESSORY_CODE"]);
                        _InsAccessoriesMdl.ACCESSORY_NAME = _tblSqla.Rows[i]["ACCESSORY_NAME"].ToString();
                        _InsAccessoriesMdl.ACCESSORY_SHORT_NAME = _tblSqla.Rows[i]["ACCESSORY_SHORT_NAME"].ToString();
                      //  _InsAccessoriesMdl.RATE = Convert.ToInt32(_tblSqla.Rows[i]["RATE"]);
                      //  _InsAccessoriesMdl.REMARKS = _tblSqla.Rows[i]["REMARKS"].ToString();
                        _InsAccessoriesMdl.ACCESSORY_CATEGORY_CODE = Convert.ToInt32(_tblSqla.Rows[i]["ACCESSORY_CATEGORY_CODE"]);
                        _InsAccessoriesMdl.MAKE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["MAKE_CODE"]);
                        _InsAccessoriesMdl.MODEL = Convert.ToInt32(_tblSqla.Rows[i]["MODEL"]);
                      //  _InsAccessoriesMdl.ENT_BY = _tblSqla.Rows[i]["ENT_BY"].ToString();
                       // _InsAccessoriesMdl.ENT_DATE = Convert.ToDateTime(_tblSqla.Rows[i]["ENT_DATE"]);
                       _InsAccessoriesMdl.AMOUNT = Convert.ToInt32(_tblSqla.Rows[i]["AMOUNT"]);
                        _InsAccessoriesMdl.TAX_AMOUNT = Convert.ToInt32(_tblSqla.Rows[i]["TAX_AMOUNT"]);
                      //  _InsAccessoriesMdl.PARTTAKER_CODE = Convert.ToInt32(_tblSqla.Rows[i]["PARTTAKER_CODE"]);




                        _InsAccessoriesMdlList.Add(_InsAccessoriesMdl);
                    }

                    return _InsAccessoriesMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //For Getting all Riders
        public List<PerilRidersMdl> GetPerilRiders()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM PerilRiders";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<PerilRidersMdl> _PerilRidersMdlList = new List<PerilRidersMdl>();
                PerilRidersMdl _PerilRidersMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _PerilRidersMdl = new PerilRidersMdl();

                        _PerilRidersMdl.RECORD_ID = Convert.ToInt32(_tblSqla.Rows[i]["RECORD_ID"]);
                        _PerilRidersMdl.RIDER_NAME = _tblSqla.Rows[i]["RIDER_NAME"].ToString();
                        _PerilRidersMdl.BASIC_PREMIUM = Convert.ToInt32(_tblSqla.Rows[i]["BASIC_PREMIUM"]);
                        _PerilRidersMdl.ADDITIONAL_PREMIUM = Convert.ToInt32(_tblSqla.Rows[i]["ADDITIONAL_PREMIUM"]);
                        _PerilRidersMdl.BENEFIT_COVERED = Convert.ToInt32(_tblSqla.Rows[i]["BENEFIT_COVERED"]);
                        _PerilRidersMdl.PARENT_RIDER_CODE = Convert.ToInt32(_tblSqla.Rows[i]["PARENT_RIDER_CODE"]);






                        _PerilRidersMdlList.Add(_PerilRidersMdl);
                    }

                    return _PerilRidersMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }


        // ----------------------------------------------- CRUD Operation Starts from Here ------------------------------------------------------------------- //


        //for getting all Product Conditions SetUp
        public List<ProductConditionsSetupMdl> GetProductCondonditionsSetUp(ProductConditionsSetupMdl _ProductConditionsSetupMdl1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());


              //  string _sqlString = "SELECT * FROM ProductConditionsProductSetup";
               // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductConditionsSetupMdl> _ProductConditionsSetupMdlList = new List<ProductConditionsSetupMdl>();
                ProductConditionsSetupMdl _ProductConditionsSetupMdl;

              

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM ProductConditionsProductSetup WHERE PrdStpTxnSysId = @PrdStpTxnSysId", conn);

                    command.Parameters.Add(new SqlParameter("@PrdStpTxnSysId", _ProductConditionsSetupMdl1.PrdStpTxnSysId));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);
                  

                    _adpSql.Fill(_tbl);
                }

               // _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ProductConditionsSetupMdl = new ProductConditionsSetupMdl();
                        _ProductConditionsSetupMdl.TxnSysID = Convert.ToInt32(_tbl.Rows[i]["TxnSysID"]);
                        _ProductConditionsSetupMdl.PrdStpTxnSysId = Convert.ToInt32( _tbl.Rows[i]["PrdStpTxnSysId"]);
                        _ProductConditionsSetupMdl.Condition = _tbl.Rows[i]["Condition"].ToString();
                        _ProductConditionsSetupMdl.ConditionShText = GetConditionByCode(_tbl.Rows[i]["Condition"].ToString());
                        _ProductConditionsSetupMdl.IsValidTxn = true;
                        _ProductConditionsSetupMdlList.Add(_ProductConditionsSetupMdl);
                    }

                    return _ProductConditionsSetupMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }


        //for adding new Product Conditions SetUp
        public ProductConditionsSetupMdl AddProductConditionsSetUp(ProductConditionsSetupMdl _ProductConditionsSetupMdl)
        {
            try
            {

                if (IsDuplicateProductConditionsSetUp(_ProductConditionsSetupMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _ProductConditionsSetupMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1001";
                    _txnError.Error = "Duplicate Transaction";
                    _txnError.TxnSysDate = DateTime.Now;
                    _txnErrors.Add(_txnError);

                    //For creating Log file
                   // string _logFileName = GlobalDataLayer.CreateLog(_txnErrors, "Product Conditions SetUp");
                   // Process.Start("notepad.exe", _logFileName);

                    ////For Email Sending
                    //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    //client.EnableSsl = true;
                    //client.Timeout = 100000;
                    //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //client.UseDefaultCredentials = false;
                    //client.Credentials = new NetworkCredential("yousuftakaful@gmail.com", "takaful123");
                    //MailMessage msg = new MailMessage();
                    //msg.To.Add("huma_abdi@hotmail.com");
                    //msg.From = new MailAddress("yousuftakaful@gmail.com");
                    //msg.Subject = "Error Log of Product Setup---" + DateTime.Now.ToString();
                    //msg.Body = String.Concat(_txnErrors.Select(o => "\n ================== PRODUCT SETUP ERROR LOG ================== \n" + "\n Error Date = " + o.TxnSysDate + "\n Error Code = " + o.ErrorCode + "\n Error = " + o.Error ));

                    //client.Send(msg);
                    //Debug.WriteLine("Email Sent Sucessfully");


                    //To Return Model
                    _ProductConditionsSetupMdl.TxnErrors = _txnErrors;
                    return _ProductConditionsSetupMdl;
                }

                else
                {

                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("INSERT INTO ProductConditionsProductSetup(");
                    _sbSql.AppendLine("PrdStpTxnSysId,");
                    _sbSql.AppendLine("Condition)");
                    _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                    _sbSql.AppendLine("@PrdStpTxnSysId,");
                    _sbSql.AppendLine("@Condition)");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);
                    int _userCode = GlobalDataLayer.GetUserCodeById(_ProductConditionsSetupMdl.UserCode);

                    _cmdSql.Parameters.AddWithValue("@PrdStpTxnSysId", _ProductConditionsSetupMdl.PrdStpTxnSysId);
                    _cmdSql.Parameters.AddWithValue("@Condition", _ProductConditionsSetupMdl.Condition);

                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();

                    _ProductConditionsSetupMdl.TxnSysID = _TxnSysId;
                    _ProductConditionsSetupMdl.ConditionShText = GetConditionByCode(_ProductConditionsSetupMdl.Condition);
                    _ProductConditionsSetupMdl.IsValidTxn = true;
                    return _ProductConditionsSetupMdl;

                }

              

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog( ex.Message,"Product SetUp DataLayer");
                return null;
            }
        }

        //for updating existing  Product Conditions SetUp
        public ProductConditionsSetupMdl UpdateProductConditionsSetUp(ProductConditionsSetupMdl _ProductConditionsSetupMdl)
        {
            try
            {

                _ProductConditionsSetupMdl.PrdStpTxnSysId = _ProductConditionsSetupMdl.PrdStpTxnSysId == 0 ? _ProductConditionsSetupMdl.PrdStpTxnSysId = -1 : _ProductConditionsSetupMdl.PrdStpTxnSysId;

                if (IsDuplicateProductConditionsSetUp(_ProductConditionsSetupMdl) == false)
                {
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("Update ProductConditionsProductSetup SET");
                    _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
                    _sbSql.AppendLine("UserCode=@UserCode,");
                    _sbSql.AppendLine("PrdStpTxnSysId=@PrdStpTxnSysId,");
                    _sbSql.AppendLine("Condition =@Condition ");
                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_ProductConditionsSetupMdl.UserCode);

                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _ProductConditionsSetupMdl.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql.Parameters.AddWithValue("@PrdStpTxnSysId", _ProductConditionsSetupMdl.PrdStpTxnSysId);
                    _cmdSql.Parameters.AddWithValue("@Condition", _ProductConditionsSetupMdl.Condition);

                    _ProductConditionsSetupMdl.ConditionShText = GetConditionByCode(_ProductConditionsSetupMdl.Condition);
                    _ProductConditionsSetupMdl.IsValidTxn = true;

                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    return _ProductConditionsSetupMdl;
                }

                else
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _ProductConditionsSetupMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1002";
                    _txnError.Error = "Active Transaction";
                    _txnError.TxnSysDate = DateTime.Now;


                    List<TxnError> _txnErrors2 = new List<TxnError>();
                    TxnError _txnError2 = new TxnError();

                    _txnError2.ErrorCode = "1001";
                    _txnError2.Error = "Duplicate  Transaction";
                    _txnError2.TxnSysDate = DateTime.Now;

                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError2);

                    ////For creating Log file
                    //string _logFileName = CreateLog(_txnErrors, "Master Product SetUp");
                    //Process.Start("notepad.exe", _logFileName);

                    ////For Email Sending
                    //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    //client.EnableSsl = true;
                    //client.Timeout = 100000;
                    //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //client.UseDefaultCredentials = false;
                    //client.Credentials = new NetworkCredential("yousuftakaful@gmail.com", "takaful123");
                    //MailMessage msg = new MailMessage();
                    //msg.To.Add("huma_abdi@hotmail.com");
                    //msg.From = new MailAddress("yousuftakaful@gmail.com");
                    //msg.Subject = "Error Log of Product Setup---" + DateTime.Now.ToString();
                    //msg.Body = String.Concat(_txnErrors.Select(o => "\n ================== PRODUCT SETUP ERROR LOG ================== \n" + "\n Error Date = " + o.TxnSysDate + "\n Error Code = " + o.ErrorCode + "\n Error = " + o.Error));

                    //client.Send(msg);
                    //Debug.WriteLine("Email Sent Sucessfully");

                    //To Return model
                    _ProductConditionsSetupMdl.TxnErrors = _txnErrors;

                    return _ProductConditionsSetupMdl;
                }
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }


        //for checking duplicate in Product Conditions SetUp
        public bool IsDuplicateProductConditionsSetUp(ProductConditionsSetupMdl _productConditionsSetupMdl)

        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();

                string _sqlString = "SELECT * FROM  ProductConditionsProductSetup  WHERE UPPER(Condition)='" + _productConditionsSetupMdl.Condition.ToString().ToUpper() + "' AND PrdStpTxnSysId="+ _productConditionsSetupMdl.PrdStpTxnSysId +" AND TxnSysID <>" + _productConditionsSetupMdl.TxnSysID;
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductConditionsSetupMdl> _ProductConditionsSetupMdlList = new List<ProductConditionsSetupMdl>();                
                DuplicationCheck _duplicationCheck = new DuplicationCheck();

                

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
               
                {
                    return true;
                }
                else
                {
                    return false;
                }

               

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return false;
            }
        }


        //for getting all Master Product SetUp
        public List<MasterProductSetupMdl> GetMasterProductSetUp()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT mps.*,ynps.YesNoText,ynps.TrueFalse FROM MasterProductSetup mps INNER JOIN YesNoProductSetup ynps ON mps.IsClientBased = ynps.YesNoText";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                MasterProductSetupMdl _MasterProductSetupMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _MasterProductSetupMdl = new MasterProductSetupMdl();
                        _MasterProductSetupMdl.TxnSysID = Convert.ToInt32(_tbl.Rows[i]["TxnSysID"]);
                        _MasterProductSetupMdl.ProductCode = Convert.ToInt32(_tbl.Rows[i]["ProductCode"].ToString());
                        _MasterProductSetupMdl.ProductName = _tbl.Rows[i]["ProductName"].ToString();
                        _MasterProductSetupMdl.Client = _tbl.Rows[i]["Client"].ToString();
                        _MasterProductSetupMdl.Agent = _tbl.Rows[i]["Agent"].ToString();
                        _MasterProductSetupMdl.AgentCommPct = Convert.ToDecimal(_tbl.Rows[i]["AgentCommPct"]);
                        _MasterProductSetupMdl.IsClientBased = _tbl.Rows[i]["YesNoText"].ToString();
                        _MasterProductSetupMdl.PolicyTypeCode = _tbl.Rows[i]["PolicyTypeCode"].ToString();

                        _MasterProductSetupMdl.PolicyTypeName = GetPolicyTypeNameByPolicyTypeCode(_tbl.Rows[i]["PolicyTypeCode"].ToString());
                        _MasterProductSetupMdl.ClientName = GetClientNameByClientCode(_tbl.Rows[i]["Client"].ToString());
                        _MasterProductSetupMdl.AgentName = GetAgentNameByAgentCode(_tbl.Rows[i]["Agent"].ToString());


                        _MasterProductSetupMdl.IsValidTxn = true;

                        _MasterProductSetupMdlList.Add(_MasterProductSetupMdl);
                    }

                    return _MasterProductSetupMdlList;
                }
                else
                {
                    
                    return null;
                   
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }


        //for adding new Master Product SetUp
        public MasterProductSetupMdl AddMasterProductSetUp(MasterProductSetupMdl _MasterProductSetupMdl)
        {
            try
            {
                
                _MasterProductSetupMdl.ProductCode = _MasterProductSetupMdl.ProductCode== 0 ? _MasterProductSetupMdl.ProductCode = -1 : _MasterProductSetupMdl.ProductCode;

                if (IsDuplicateMasterProductSetup(_MasterProductSetupMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _MasterProductSetupMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1001";
                    _txnError.Error = "Duplicate Transaction";
                    _txnError.TxnSysDate = DateTime.Now;

                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError);

                    //To Return model
                    _MasterProductSetupMdl.TxnErrors = _txnErrors;
                    return _MasterProductSetupMdl;

                    /*
                    //For creating Log file
                    string _logFileName = CreateLog(_txnErrors, "Master Product SetUp");
                    Process.Start("notepad.exe", _logFileName);


                    //For Email Sending
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Timeout = 100000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("yousuftakaful@gmail.com", "takaful123");
                    MailMessage msg = new MailMessage();
                    msg.To.Add("m.yousuf@takaful.com.pk");
                    msg.From = new MailAddress("yousuftakaful@gmail.com");
                    msg.Subject = "Error Log of Product Setup---" + DateTime.Now.ToString();

                    string body = String.Concat(_txnErrors.Select(o => "\n ================== PRODUCT SETUP ERROR LOG ================== \n" + "\n Error Date = " + o.TxnSysDate + "\n Error Code = " + o.ErrorCode + "\n Error = " + o.Error));

                    msg.Body = body + "\n Master Product Code = "+_MasterProductSetupMdl.ProductCode+"\n Master Product Name = "+_MasterProductSetupMdl.ProductName+ "\n Client = "+_MasterProductSetupMdl.Client+ "\n Agent = "+ _MasterProductSetupMdl.Agent; 

                    client.Send(msg);
                    Debug.WriteLine("Email Sent Sucessfully");
                    */
                   
                }

                else
                {
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    int _ProductCode = GettingNewProductCode(_MasterProductSetupMdl);


                    _sbSql.AppendLine("INSERT INTO MasterProductSetup(");
                    _sbSql.AppendLine("ProductCode,");
                    _sbSql.AppendLine("ProductName,");
                    _sbSql.AppendLine("IsClientBased,");
                    _sbSql.AppendLine("Client,");
                    _sbSql.AppendLine("Agent,");
                    _sbSql.AppendLine("AgentCommPct,");
                    _sbSql.AppendLine("PolicyTypeCode)");
                    _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                    _sbSql.AppendLine("@ProductCode,");
                    _sbSql.AppendLine("@ProductName,");
                    _sbSql.AppendLine("@IsClientBased,");
                    _sbSql.AppendLine("@Client,");
                    _sbSql.AppendLine("@Agent,");
                    _sbSql.AppendLine("@AgentCommPct,");
                    _sbSql.AppendLine("@PolicyTypeCode)");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);
                    int _userCode = GlobalDataLayer.GetUserCodeById(_MasterProductSetupMdl.UserCode);

                    _cmdSql.Parameters.AddWithValue("@ProductCode", _ProductCode);
                    _cmdSql.Parameters.AddWithValue("@ProductName", _MasterProductSetupMdl.ProductName);
                    _cmdSql.Parameters.AddWithValue("@IsClientBased", _MasterProductSetupMdl.IsClientBased);
                    _cmdSql.Parameters.AddWithValue("@Client", _MasterProductSetupMdl.Client);
                    _cmdSql.Parameters.AddWithValue("@Agent", _MasterProductSetupMdl.Agent);
                    _cmdSql.Parameters.AddWithValue("@AgentCommPct", _MasterProductSetupMdl.AgentCommPct);
                    _cmdSql.Parameters.AddWithValue("@PolicyTypeCode", _MasterProductSetupMdl.PolicyTypeCode);
                    




                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();
                    _MasterProductSetupMdl.IsValidTxn = true;

                    _MasterProductSetupMdl.TxnSysID = _TxnSysId;

                    _MasterProductSetupMdl.ProductCode = _ProductCode;


                    _MasterProductSetupMdl.PolicyTypeName = GetPolicyTypeNameByPolicyTypeCode(_MasterProductSetupMdl.PolicyTypeCode.ToString());
                    _MasterProductSetupMdl.ClientName = GetClientNameByClientCode(_MasterProductSetupMdl.Client.ToString());
                    _MasterProductSetupMdl.AgentName = GetAgentNameByAgentCode(_MasterProductSetupMdl.Agent.ToString());

                    return _MasterProductSetupMdl;

                }


            }
            catch (Exception ex)
            {
               
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
                
            }
        }

        //for updating existing Master  Product SetUp
        public MasterProductSetupMdl UpdateMasterProductSetup(MasterProductSetupMdl _MasterProductSetupMdl)
        {
            try
            {

                _MasterProductSetupMdl.ProductCode = _MasterProductSetupMdl.ProductCode == 0 ? _MasterProductSetupMdl.ProductCode = -1 : _MasterProductSetupMdl.ProductCode;

                if (IsDuplicateMasterProductSetup(_MasterProductSetupMdl) == false)
                {


                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("Update  MasterProductSetup SET");
                    _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
                    _sbSql.AppendLine("UserCode= @UserCode,");
                    _sbSql.AppendLine("ProductCode=@ProductCode,");
                    _sbSql.AppendLine("ProductName=@ProductName,");
                    _sbSql.AppendLine("IsClientBased=@IsClientBased,");
                    _sbSql.AppendLine("Client =@Client, ");
                    _sbSql.AppendLine("Agent =@Agent, ");
                    _sbSql.AppendLine("AgentCommPct =@AgentCommPct, ");
                    _sbSql.AppendLine("PolicyTypeCode =@PolicyTypeCode ");
                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_MasterProductSetupMdl.UserCode);


                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _MasterProductSetupMdl.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@ProductCode", _MasterProductSetupMdl.ProductCode);
                    _cmdSql.Parameters.AddWithValue("@ProductName", _MasterProductSetupMdl.ProductName);
                    _cmdSql.Parameters.AddWithValue("@IsClientBased", _MasterProductSetupMdl.IsClientBased);
                    _cmdSql.Parameters.AddWithValue("@Client", _MasterProductSetupMdl.Client);
                    _cmdSql.Parameters.AddWithValue("@Agent", _MasterProductSetupMdl.Agent);
                    _cmdSql.Parameters.AddWithValue("@AgentCommPct", _MasterProductSetupMdl.AgentCommPct);
                    _cmdSql.Parameters.AddWithValue("@PolicyTypeCode", _MasterProductSetupMdl.PolicyTypeCode);


                    _MasterProductSetupMdl.PolicyTypeName = GetPolicyTypeNameByPolicyTypeCode(_MasterProductSetupMdl.PolicyTypeCode.ToString());
                    _MasterProductSetupMdl.ClientName = GetClientNameByClientCode(_MasterProductSetupMdl.Client.ToString());
                    _MasterProductSetupMdl.AgentName = GetAgentNameByAgentCode(_MasterProductSetupMdl.Agent.ToString());



                    _MasterProductSetupMdl.IsValidTxn = true;

                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    return _MasterProductSetupMdl;

                }

                else
                {

                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _MasterProductSetupMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1002";
                    _txnError.Error = "Active Transaction";
                    _txnError.TxnSysDate = DateTime.Now;
                   

                    List<TxnError> _txnErrors2 = new List<TxnError>();
                    TxnError _txnError2 = new TxnError();
                  
                    _txnError2.ErrorCode = "1001";
                    _txnError2.Error = "Duplicate  Transaction";
                    _txnError2.TxnSysDate = DateTime.Now;

                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError2);

                    //For creating Log file
                    string _logFileName = GlobalDataLayer.CreateLog(_txnErrors, "Master Product SetUp");
                    Process.Start("notepad.exe", _logFileName);

                    ////For Email Sending
                    //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    //client.EnableSsl = true;
                    //client.Timeout = 100000;
                    //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //client.UseDefaultCredentials = false;
                    //client.Credentials = new NetworkCredential("yousuftakaful@gmail.com", "takaful123");
                    //MailMessage msg = new MailMessage();
                    //msg.To.Add("huma_abdi@hotmail.com");
                    //msg.From = new MailAddress("yousuftakaful@gmail.com");
                    //msg.Subject = "Error Log of Product Setup---" + DateTime.Now.ToString();
                    //string body = String.Concat(_txnErrors.Select(o => "\n ================== PRODUCT SETUP ERROR LOG ================== \n" + "\n Error Date = " + o.TxnSysDate + "\n Error Code = " + o.ErrorCode + "\n Error = " + o.Error));

                    //msg.Body = body + "\n Master Product Code = " + _MasterProductSetupMdl.ProductCode + "\n Master Product Name = " + _MasterProductSetupMdl.ProductName + "\n Client = " + _MasterProductSetupMdl.Client + "\n Agent = " + _MasterProductSetupMdl.Agent;

                    //client.Send(msg);
                    //Debug.WriteLine("Email Sent Sucessfully");

                    //To Return model
                    _MasterProductSetupMdl.TxnErrors = _txnErrors;
                   // _MasterProductSetupMdl.TxnErrors = _txnErrors2;
                    return _MasterProductSetupMdl;
                }
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }


        //for checking duplicate master Product Setup
        public bool IsDuplicateMasterProductSetup(MasterProductSetupMdl _masterProductSetupMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  MasterProductSetup  WHERE UPPER(ProductName)='" + _masterProductSetupMdl.ProductName.ToString().ToUpper()+ "' AND ProductCode <>" + _masterProductSetupMdl.ProductCode;
               // _sbSql.AppendLine("SELECT * FROM MasterCodes WHERE UPPER(ProductName)='");
               // _sbSql.AppendLine("ProductName= @ProductName");
               // _adpSql.Parameters.AddWithValue("@ProductCode", _MasterProductSetupMdl.ProductCode);



                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                MasterProductSetupMdl _MasterProductSetupMdl;
                DuplicationCheck _duplicationCheck = new DuplicationCheck();

               // SqlCommand cmd = new SqlCommand(_sqlString,_conSql);
               // int count = (int)cmd.ExecuteScalar();

                _adpSql.Fill(_tbl);

               if (_tbl.Rows.Count > 0)
             // if(count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return true;
            }
        }


        //for getting all  Product RatingFactor SetUp
        public List<ProductRatingFactorSetUpMdl> GetProductRatingFactorSetUp(ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
               // string _sqlString = "SELECT * FROM ProductRatingFactorsProductSetup";
               // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductRatingFactorSetUpMdl> _ProductRatingFactorSetUpMdlList = new List<ProductRatingFactorSetUpMdl>();
                ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl;


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM ProductRatingFactorsProductSetup WHERE PrdStpTxnSysID = @PrdStpTxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@PrdStpTxnSysID", _ProductRatingFactorSetUpMdl1.PrdStpTxnSysId));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tbl);
                }


               

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ProductRatingFactorSetUpMdl = new ProductRatingFactorSetUpMdl();
                        _ProductRatingFactorSetUpMdl.TxnSysID = Convert.ToInt32(_tbl.Rows[i]["TxnSysID"]);
                        _ProductRatingFactorSetUpMdl.PrdStpTxnSysId = Convert.ToInt32( _tbl.Rows[i]["PrdStpTxnSysId"]);
                        _ProductRatingFactorSetUpMdl.RatingFactor = _tbl.Rows[i]["RatingFactor"].ToString();
                        _ProductRatingFactorSetUpMdl.IsEditable = _tbl.Rows[i]["IsEditable"].ToString();
                        _ProductRatingFactorSetUpMdl.Rate = Convert.ToDecimal(_tbl.Rows[i]["Rate"]);
                        _ProductRatingFactorSetUpMdl.RatingFactorShText = GetRaitingFactorByCode(_tbl.Rows[i]["RatingFactor"].ToString());
                        _ProductRatingFactorSetUpMdl.IsValidTxn = true;


                        _ProductRatingFactorSetUpMdlList.Add(_ProductRatingFactorSetUpMdl);
                    }

                    return _ProductRatingFactorSetUpMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }


        //for adding new Product RatingFactor SetUp
        public ProductRatingFactorSetUpMdl AddProductRatingFactorSetUp(ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl)
        {
            try
            {

                if (IsDuplicateProductRatingFactorSetUp(_ProductRatingFactorSetUpMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _ProductRatingFactorSetUpMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1001";
                    _txnError.Error = "Duplicate Transaction";
                    _txnError.TxnSysDate = DateTime.Now;
                    _ProductRatingFactorSetUpMdl.RatingFactorShText = GetRaitingFactorByCode(_ProductRatingFactorSetUpMdl.RatingFactor);
                    _txnErrors.Add(_txnError);

                    //For creating Log file
                    //string _logFileName = CreateLog(_txnErrors, "Product RatingFactor SetUp");
                    //Process.Start("notepad.exe", _logFileName);

                    ////For Email Sending
                    //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    //client.EnableSsl = true;
                    //client.Timeout = 100000;
                    //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //client.UseDefaultCredentials = false;
                    //client.Credentials = new NetworkCredential("yousuftakaful@gmail.com", "takaful123");
                    //MailMessage msg = new MailMessage();
                    //msg.To.Add("huma_abdi@hotmail.com");
                    //msg.From = new MailAddress("yousuftakaful@gmail.com");
                    //msg.Subject = "Error Log of Product Setup---" + DateTime.Now.ToString();

                    //string body = String.Concat(_txnErrors.Select(o => "\n ================== PRODUCT SETUP ERROR LOG ================== \n" + "\n Error Date = " + o.TxnSysDate + "\n Error Code = " + o.ErrorCode + "\n Error = " + o.Error));
                    //msg.Body = body + "\n Product System Id = "+_ProductRatingFactorSetUpMdl.PrdStpTxnSysId+ "\n Rating Factor = "+_ProductRatingFactorSetUpMdl.RatingFactor+ "\n Rate = "+_ProductRatingFactorSetUpMdl.Rate;

                    //client.Send(msg);
                    //Debug.WriteLine("Email Sent Sucessfully");

                    //To Return model

                    _ProductRatingFactorSetUpMdl.TxnErrors = _txnErrors;
                    return _ProductRatingFactorSetUpMdl;
                }

                else
                {
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("INSERT INTO ProductRatingFactorsProductSetup(");
                    _sbSql.AppendLine("UserCode,");
                    _sbSql.AppendLine("PrdStpTxnSysId,");
                    _sbSql.AppendLine("RatingFactor,");
                    _sbSql.AppendLine("IsEditable,");
                    _sbSql.AppendLine("Rate)");
                    _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                    _sbSql.AppendLine("@UserCode,");
                    _sbSql.AppendLine("@PrdStpTxnSysId,");
                    _sbSql.AppendLine("@RatingFactor,");
                    _sbSql.AppendLine("@IsEditable,");
                    _sbSql.AppendLine("@Rate)");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);
                    int _userCode = GlobalDataLayer.GetUserCodeById(_ProductRatingFactorSetUpMdl.UserCode);

                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@PrdStpTxnSysId", _ProductRatingFactorSetUpMdl.PrdStpTxnSysId);
                    _cmdSql.Parameters.AddWithValue("@RatingFactor", _ProductRatingFactorSetUpMdl.RatingFactor);
                    _cmdSql.Parameters.AddWithValue("@IsEditable", _ProductRatingFactorSetUpMdl.IsEditable);
                    _cmdSql.Parameters.AddWithValue("@Rate", _ProductRatingFactorSetUpMdl.Rate);

                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();

                    _ProductRatingFactorSetUpMdl.RatingFactorShText = GetRaitingFactorByCode(_ProductRatingFactorSetUpMdl.RatingFactor);

                    _ProductRatingFactorSetUpMdl.IsValidTxn = true;

                    _ProductRatingFactorSetUpMdl.TxnSysID = _TxnSysId;

                    return _ProductRatingFactorSetUpMdl;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //for updating existing Product RatingFactor SetUp
        public ProductRatingFactorSetUpMdl UpdateProductRatingFactorSetUp(ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl)
        {
            try
            {

                if (IsDuplicateProductRatingFactorSetUp(_ProductRatingFactorSetUpMdl) == false)
                {

                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("Update  ProductRatingFactorsProductSetup SET");
                    _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
                    _sbSql.AppendLine("UserCode= @UserCode,");
                    _sbSql.AppendLine("PrdStpTxnSysId=@PrdStpTxnSysId,");
                    _sbSql.AppendLine("RatingFactor=@RatingFactor,");
                    _sbSql.AppendLine("IsEditable =@IsEditable, ");
                    _sbSql.AppendLine("Rate =@Rate ");
                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_ProductRatingFactorSetUpMdl.UserCode);


                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _ProductRatingFactorSetUpMdl.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@PrdStpTxnSysId", _ProductRatingFactorSetUpMdl.PrdStpTxnSysId);
                    _cmdSql.Parameters.AddWithValue("@RatingFactor", _ProductRatingFactorSetUpMdl.RatingFactor);
                    _cmdSql.Parameters.AddWithValue("@IsEditable", _ProductRatingFactorSetUpMdl.IsEditable);
                    _cmdSql.Parameters.AddWithValue("@Rate", _ProductRatingFactorSetUpMdl.Rate);

                    _ProductRatingFactorSetUpMdl.RatingFactorShText = GetRaitingFactorByCode(_ProductRatingFactorSetUpMdl.RatingFactor);

                    _ProductRatingFactorSetUpMdl.IsValidTxn = true;

                    _ProductRatingFactorSetUpMdl.RatingFactorShText = GetRaitingFactorByCode(_ProductRatingFactorSetUpMdl.RatingFactor);
                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    return _ProductRatingFactorSetUpMdl;

                }

                else
                {

                        List<TxnError> _txnErrors = new List<TxnError>();
                        TxnError _txnError = new TxnError();
                        _ProductRatingFactorSetUpMdl.IsValidTxn = false;
                        _txnError.ErrorCode = "1002";
                        _txnError.Error = "Active Transaction";
                        _txnError.TxnSysDate = DateTime.Now;


                        List<TxnError> _txnErrors2 = new List<TxnError>();
                        TxnError _txnError2 = new TxnError();

                        _txnError2.ErrorCode = "1001";
                        _txnError2.Error = "Duplicate  Transaction";
                        _txnError2.TxnSysDate = DateTime.Now;

                        _txnErrors.Add(_txnError);
                        _txnErrors.Add(_txnError2);

                        ////For creating Log file
                        //string _logFileName = CreateLog(_txnErrors, "Master Product SetUp");
                        //Process.Start("notepad.exe", _logFileName);


                        ////For Email Sending
                        //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        //client.EnableSsl = true;
                        //client.Timeout = 100000;
                        //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        //client.UseDefaultCredentials = false;
                        //client.Credentials = new NetworkCredential("yousuftakaful@gmail.com", "takaful123");
                        //MailMessage msg = new MailMessage();
                        //msg.To.Add("huma_abdi@hotmail.com");
                        //msg.From = new MailAddress("yousuftakaful@gmail.com");
                        //msg.Subject = "Error Log of Product Setup---" + DateTime.Now.ToString();
                        //string body = String.Concat(_txnErrors.Select(o => "\n ================== PRODUCT SETUP ERROR LOG ================== \n" + "\n Error Date = " + o.TxnSysDate + "\n Error Code = " + o.ErrorCode + "\n Error = " + o.Error));
                        //msg.Body = body + "\n Product System Id = " + _ProductRatingFactorSetUpMdl.PrdStpTxnSysId + "\n Rating Factor = " + _ProductRatingFactorSetUpMdl.RatingFactor + "\n Rate = " + _ProductRatingFactorSetUpMdl.Rate;
                        //client.Send(msg);
                        //Debug.WriteLine("Email Sent Sucessfully");

                        //To Return model

                        _ProductRatingFactorSetUpMdl.TxnErrors = _txnErrors;

                        return _ProductRatingFactorSetUpMdl;
                    }
                 }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //for checking duplicate Product RatingFactor SetUp
        public bool IsDuplicateProductRatingFactorSetUp(ProductRatingFactorSetUpMdl _productRatingFactorSetUpMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  ProductRatingFactorsProductSetup  WHERE UPPER(RatingFactor)='" + _productRatingFactorSetUpMdl.RatingFactor.ToString().ToUpper() + "' AND PrdStpTxnSysId = " + _productRatingFactorSetUpMdl.PrdStpTxnSysId + "AND Rate=" + _productRatingFactorSetUpMdl.Rate+ "  AND TxnSysID <>" + _productRatingFactorSetUpMdl.TxnSysID;
              
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductRatingFactorSetUpMdl> _ProductRatingFactorSetUpMdlList = new List<ProductRatingFactorSetUpMdl>();
                ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl;
                DuplicationCheck _duplicationCheck = new DuplicationCheck();

               

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

               

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return true;
            }
        }


        //for getting all  Product Warranties Setup
        public List<ProductWarrantiesSetupMdl> GetProductWarrantiesSetup(ProductWarrantiesSetupMdl _ProductWarrantiesSetupMdl1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
              //  string _sqlString = "SELECT * FROM ProductWarrantiesProductSetup";
               // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductWarrantiesSetupMdl> _ProductWarrantiesSetupMdlList = new List<ProductWarrantiesSetupMdl>();
                ProductWarrantiesSetupMdl _ProductWarrantiesSetupMdl;


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM ProductWarrantiesProductSetup WHERE PrdStpTxnSysId = @PrdStpTxnSysId", conn);

                    command.Parameters.Add(new SqlParameter("@PrdStpTxnSysId", _ProductWarrantiesSetupMdl1.PrdStpTxnSysId));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tbl);
                }


              //  _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {
                        _ProductWarrantiesSetupMdl = new ProductWarrantiesSetupMdl();
                        _ProductWarrantiesSetupMdl.TxnSysID = Convert.ToInt32(_tbl.Rows[i]["TxnSysID"]);
                        _ProductWarrantiesSetupMdl.PrdStpTxnSysId = Convert.ToInt32(_tbl.Rows[i]["PrdStpTxnSysId"]);
                        _ProductWarrantiesSetupMdl.Warranty = _tbl.Rows[i]["Warranty"].ToString();
                        _ProductWarrantiesSetupMdl.WarrantyShText = GetWarrantyTextByCode(_tbl.Rows[i]["Warranty"].ToString());
                        _ProductWarrantiesSetupMdl.IsValidTxn = true;

                        _ProductWarrantiesSetupMdlList.Add(_ProductWarrantiesSetupMdl);
                    }

                    return _ProductWarrantiesSetupMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }


        //for adding new Product Warranties Setup
        public ProductWarrantiesSetupMdl AddProductWarrantiesSetup(ProductWarrantiesSetupMdl _ProductWarrantiesSetupMdl)
        {
            try
            {
                if (IsDuplicateProductWarrantiesSetup(_ProductWarrantiesSetupMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _ProductWarrantiesSetupMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1001";
                    _txnError.Error = "Duplicate Transaction";
                    _txnError.TxnSysDate = DateTime.Now;
                    _txnErrors.Add(_txnError);

                    ////For creating Log file
                    //string _logFileName = CreateLog(_txnErrors, "Product Warranties Setup");
                    //Process.Start("notepad.exe", _logFileName);

                    ////For Email Sending
                    //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    //client.EnableSsl = true;
                    //client.Timeout = 100000;
                    //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //client.UseDefaultCredentials = false;
                    //client.Credentials = new NetworkCredential("yousuftakaful@gmail.com", "takaful123");
                    //MailMessage msg = new MailMessage();
                    //msg.To.Add("huma_abdi@hotmail.com");
                    //msg.From = new MailAddress("yousuftakaful@gmail.com");
                    //msg.Subject = "Error Log of Product Setup---" + DateTime.Now.ToString();

                    //string body = String.Concat(_txnErrors.Select(o => "\n ================== PRODUCT SETUP ERROR LOG ================== \n" + "\n Error Date = " + o.TxnSysDate + "\n Error Code = " + o.ErrorCode + "\n Error = " + o.Error));
                    //msg.Body = body + "Product Id = "+ _ProductWarrantiesSetupMdl.PrdStpTxnSysId+ "\n Warranty = "+_ProductWarrantiesSetupMdl.Warranty;
                    //client.Send(msg);
                    //Debug.WriteLine("Email Sent Sucessfully");

                    //To Return model

                    _ProductWarrantiesSetupMdl.TxnErrors = _txnErrors;
                    return _ProductWarrantiesSetupMdl;
                }

                else
                {
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("INSERT INTO ProductWarrantiesProductSetup(");
                    _sbSql.AppendLine("PrdStpTxnSysId,");
                    _sbSql.AppendLine("Warranty)");
                    _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                    _sbSql.AppendLine("@PrdStpTxnSysId,");
                    _sbSql.AppendLine("@Warranty)");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);
                    int _userCode = GlobalDataLayer.GetUserCodeById(_ProductWarrantiesSetupMdl.UserCode);

                    _cmdSql.Parameters.AddWithValue("@PrdStpTxnSysId", _ProductWarrantiesSetupMdl.PrdStpTxnSysId);
                    _cmdSql.Parameters.AddWithValue("@Warranty", _ProductWarrantiesSetupMdl.Warranty);

                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();


                    _ProductWarrantiesSetupMdl.WarrantyShText = GetWarrantyTextByCode(_ProductWarrantiesSetupMdl.Warranty.ToString());

                    _ProductWarrantiesSetupMdl.TxnSysID = _TxnSysId;
                    _ProductWarrantiesSetupMdl.IsValidTxn = true;
                    return _ProductWarrantiesSetupMdl;

                }


            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //for updating existing Product Warranties Setup
        public ProductWarrantiesSetupMdl UpdateProductWarrantiesSetup(ProductWarrantiesSetupMdl _ProductWarrantiesSetupMdl)
        {
            try
            {

                _ProductWarrantiesSetupMdl.PrdStpTxnSysId = _ProductWarrantiesSetupMdl.PrdStpTxnSysId == 0 ? _ProductWarrantiesSetupMdl.PrdStpTxnSysId = -1 : _ProductWarrantiesSetupMdl.PrdStpTxnSysId;

                if (IsDuplicateProductWarrantiesSetup(_ProductWarrantiesSetupMdl) == false)
                {

                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("Update  ProductWarrantiesProductSetup SET");
                    _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
                    _sbSql.AppendLine("UserCode= @UserCode,");
                    _sbSql.AppendLine("PrdStpTxnSysId=@PrdStpTxnSysId,");
                    _sbSql.AppendLine("Warranty=@Warranty");
                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_ProductWarrantiesSetupMdl.UserCode);


                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _ProductWarrantiesSetupMdl.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@PrdStpTxnSysId", _ProductWarrantiesSetupMdl.PrdStpTxnSysId);
                    _cmdSql.Parameters.AddWithValue("@Warranty", _ProductWarrantiesSetupMdl.Warranty);

                    

                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    _ProductWarrantiesSetupMdl.IsValidTxn = true;
                    return _ProductWarrantiesSetupMdl;
                }

                else
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _ProductWarrantiesSetupMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1002";
                    _txnError.Error = "Active Transaction";
                    _txnError.TxnSysDate = DateTime.Now;


                    List<TxnError> _txnErrors2 = new List<TxnError>();
                    TxnError _txnError2 = new TxnError();

                    _txnError2.ErrorCode = "1001";
                    _txnError2.Error = "Duplicate  Transaction";
                    _txnError2.TxnSysDate = DateTime.Now;

                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError2);

                    ////For creating Log file
                    //string _logFileName = CreateLog(_txnErrors, "Master Product SetUp");
                    //Process.Start("notepad.exe", _logFileName);

                    ////For Email Sending
                    //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    //client.EnableSsl = true;
                    //client.Timeout = 100000;
                    //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //client.UseDefaultCredentials = false;
                    //client.Credentials = new NetworkCredential("yousuftakaful@gmail.com", "takaful123");
                    //MailMessage msg = new MailMessage();
                    //msg.To.Add("huma_abdi@hotmail.com");
                    //msg.From = new MailAddress("yousuftakaful@gmail.com");
                    //msg.Subject = "Error Log of Product Setup---" + DateTime.Now.ToString();
                    //msg.Body = String.Concat(_txnErrors.Select(o => "\n ================== PRODUCT SETUP ERROR LOG ================== \n" + "\n Error Date = " + o.TxnSysDate + "\n Error Code = " + o.ErrorCode + "\n Error = " + o.Error));

                    //client.Send(msg);
                    //Debug.WriteLine("Email Sent Sucessfully");

                    //To Return model

                    _ProductWarrantiesSetupMdl.TxnErrors = _txnErrors;


                    return _ProductWarrantiesSetupMdl;

                }
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //for checking duplicate  Product Warranties Setup
        public bool IsDuplicateProductWarrantiesSetup(ProductWarrantiesSetupMdl _productWarrantiesSetupMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  ProductWarrantiesProductSetup  WHERE UPPER(Warranty)='" + _productWarrantiesSetupMdl.Warranty.ToString().ToUpper() + "' AND PrdStpTxnSysId="+ _productWarrantiesSetupMdl.PrdStpTxnSysId +" AND TxnSysID <>" + _productWarrantiesSetupMdl.TxnSysID;


                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductWarrantiesSetupMdl> _ProductWarrantiesSetupMdlList = new List<ProductWarrantiesSetupMdl>();
                ProductWarrantiesSetupMdl _ProductWarrantiesSetupMdl;
                DuplicationCheck _duplicationCheck = new DuplicationCheck();



                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

               

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return true;
            }
        }


        //For Getting all Product Tracker Setup
        public List<ProductTrackerSetupMdl> GetProductTrackerSetup(ProductTrackerSetupMdl _ProductTrackerSetupMdl1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //  string _sqlString = "SELECT * FROM ProductWarrantiesProductSetup";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<ProductTrackerSetupMdl> _ProductTrackerSetupMdlList = new List<ProductTrackerSetupMdl>();
                ProductTrackerSetupMdl _ProductTrackerSetupMdl;


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM ProductTrackerSetup WHERE PrdStpTxnSysId = @PrdStpTxnSysId", conn);

                    command.Parameters.Add(new SqlParameter("@PrdStpTxnSysId", _ProductTrackerSetupMdl1.PrdStpTxnSysId));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


                //  _adpSql.Fill(_tbl);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductTrackerSetupMdl = new ProductTrackerSetupMdl();

                        _ProductTrackerSetupMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _ProductTrackerSetupMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _ProductTrackerSetupMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _ProductTrackerSetupMdl.TrackerCode = Convert.ToInt32(_tblSqla.Rows[i]["TrackerCode"]);
                        _ProductTrackerSetupMdl.TrackerName =  _tblSqla.Rows[i]["TrackerName"].ToString();
                        _ProductTrackerSetupMdl.TrackerRate = Convert.ToInt32(_tblSqla.Rows[i]["TrackerRate"]);
                        _ProductTrackerSetupMdl.PrdStpTxnSysId = Convert.ToInt32(_tblSqla.Rows[i]["PrdStpTxnSysId"]);



                        _ProductTrackerSetupMdl.IsValidTxn = true;

                        _ProductTrackerSetupMdlList.Add(_ProductTrackerSetupMdl);
                    }

                    return _ProductTrackerSetupMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //for adding new Product Tracker Setup
        public ProductTrackerSetupMdl AddProductTrackerSetup(ProductTrackerSetupMdl _ProductTrackerSetupMdl)
        {
            try
            {
                if (IsDuplicateProductTrackerSetup(_ProductTrackerSetupMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _ProductTrackerSetupMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1001";
                    _txnError.Error = "Duplicate Transaction";
                    _txnError.TxnSysDate = DateTime.Now;
                    _txnErrors.Add(_txnError);



                    //To Return model

                    _ProductTrackerSetupMdl.TxnErrors = _txnErrors;
                    return _ProductTrackerSetupMdl;
                }

                else
                {
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("INSERT INTO ProductTrackerSetup(");
                   // _sbSql.AppendLine("TxnSysID,");
                   // _sbSql.AppendLine("TxnSysDate,");
                   _sbSql.AppendLine("UserCode,");
                    _sbSql.AppendLine("TrackerCode,");
                    _sbSql.AppendLine("TrackerName,");
                    _sbSql.AppendLine("TrackerRate,");
                    _sbSql.AppendLine("PrdStpTxnSysId)");

                    _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                   // _sbSql.AppendLine("@TxnSysID,");
                   // _sbSql.AppendLine("@TxnSysDate,");
                    _sbSql.AppendLine("@UserCode,");
                    _sbSql.AppendLine("@TrackerCode,");
                    _sbSql.AppendLine("@TrackerName,");
                    _sbSql.AppendLine("@TrackerRate,");
                    _sbSql.AppendLine("@PrdStpTxnSysId)");


                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);
                    int _userCode = GlobalDataLayer.GetUserCodeById(_ProductTrackerSetupMdl.UserCode);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@TrackerCode", _ProductTrackerSetupMdl.TrackerCode);

                    string TrackerName = GlobalDataLayer.GetTrackerSetUpNameByCode(_ProductTrackerSetupMdl.TrackerCode);

                    _cmdSql.Parameters.AddWithValue("@TrackerName", TrackerName);
                    _cmdSql.Parameters.AddWithValue("@TrackerRate", _ProductTrackerSetupMdl.TrackerRate);
                    _cmdSql.Parameters.AddWithValue("@PrdStpTxnSysId", _ProductTrackerSetupMdl.PrdStpTxnSysId);


                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();




                    _ProductTrackerSetupMdl.TxnSysID = _TxnSysId;
                    _ProductTrackerSetupMdl.IsValidTxn = true;
                    _ProductTrackerSetupMdl.TrackerName = TrackerName;
                    return _ProductTrackerSetupMdl;

                }


            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //for updating existing Product Tracker SetupMdl
        public ProductTrackerSetupMdl UpdateProductTrackerSetup(ProductTrackerSetupMdl _ProductTrackerSetupMdl)
        {
            try
            {

                _ProductTrackerSetupMdl.PrdStpTxnSysId = _ProductTrackerSetupMdl.PrdStpTxnSysId == 0 ? _ProductTrackerSetupMdl.PrdStpTxnSysId = -1 : _ProductTrackerSetupMdl.PrdStpTxnSysId;

                if (IsDuplicateProductTrackerSetup(_ProductTrackerSetupMdl) == false)
                {

                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("Update  ProductTrackerSetup SET");
                    _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
                    _sbSql.AppendLine("UserCode= @UserCode,");
                    _sbSql.AppendLine("PrdStpTxnSysId=@PrdStpTxnSysId,");
                    _sbSql.AppendLine("TrackerCode=@TrackerCode,");
                    _sbSql.AppendLine("TrackerName=@TrackerName,");
                    _sbSql.AppendLine("TrackerRate=@TrackerRate");

                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_ProductTrackerSetupMdl.UserCode);


                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _ProductTrackerSetupMdl.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@PrdStpTxnSysId", _ProductTrackerSetupMdl.PrdStpTxnSysId);
                    _cmdSql.Parameters.AddWithValue("@TrackerCode", _ProductTrackerSetupMdl.TrackerCode);

                    string TrackerName = GlobalDataLayer.GetTrackerSetUpNameByCode(_ProductTrackerSetupMdl.TrackerCode);

                    _cmdSql.Parameters.AddWithValue("@TrackerName",TrackerName);
                    _cmdSql.Parameters.AddWithValue("@TrackerRate", _ProductTrackerSetupMdl.TrackerRate);



                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    _ProductTrackerSetupMdl.IsValidTxn = true;
                    _ProductTrackerSetupMdl.TrackerName = TrackerName;
                    return _ProductTrackerSetupMdl;
                }

                else
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _ProductTrackerSetupMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1002";
                    _txnError.Error = "Active Transaction";
                    _txnError.TxnSysDate = DateTime.Now;


                    List<TxnError> _txnErrors2 = new List<TxnError>();
                    TxnError _txnError2 = new TxnError();

                    _txnError2.ErrorCode = "1001";
                    _txnError2.Error = "Duplicate  Transaction";
                    _txnError2.TxnSysDate = DateTime.Now;

                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError2);

                  

                    //To Return model

                    _ProductTrackerSetupMdl.TxnErrors = _txnErrors;


                    return _ProductTrackerSetupMdl;

                }
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //for checking duplicate Product Tracker Setup
        public bool IsDuplicateProductTrackerSetup(ProductTrackerSetupMdl _ProductTrackerSetupMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  ProductTrackerSetup  WHERE UPPER(TrackerName)='" + GlobalDataLayer.GetTrackerSetUpNameByCode(_ProductTrackerSetupMdl.TrackerCode).ToString().ToUpper() + "' AND PrdStpTxnSysId=" + _ProductTrackerSetupMdl.PrdStpTxnSysId + " AND TxnSysID <>" + _ProductTrackerSetupMdl.TxnSysID;


                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductWarrantiesSetupMdl> _ProductWarrantiesSetupMdlList = new List<ProductWarrantiesSetupMdl>();
                
                DuplicationCheck _duplicationCheck = new DuplicationCheck();



                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }



            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return true;
            }
        }

        //For Getting all Product Rider Setup
        public List<ProductRiderSetupMdl> GetProductRiderSetup(ProductRiderSetupMdl _ProductRiderSetupMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //  string _sqlString = "SELECT * FROM ProductWarrantiesProductSetup";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<ProductRiderSetupMdl> _ProductRiderSetupMdlList = new List<ProductRiderSetupMdl>();
               // ProductRiderSetupMdl _ProductRiderSetupMdl;


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM ProductRiderSetup WHERE PrdStpTxnSysId = @PrdStpTxnSysId", conn);

                    command.Parameters.Add(new SqlParameter("@PrdStpTxnSysId", _ProductRiderSetupMdl.PrdStpTxnSysId));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


                //  _adpSql.Fill(_tbl);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductRiderSetupMdl = new ProductRiderSetupMdl();

                        _ProductRiderSetupMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _ProductRiderSetupMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _ProductRiderSetupMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _ProductRiderSetupMdl.RiderCode = Convert.ToInt32(_tblSqla.Rows[i]["RiderCode"]);
                        _ProductRiderSetupMdl.RiderName = _tblSqla.Rows[i]["RiderName"].ToString();
                        _ProductRiderSetupMdl.RiderRate = Convert.ToInt32(_tblSqla.Rows[i]["RiderRate"]);
                        _ProductRiderSetupMdl.PrdStpTxnSysId = Convert.ToInt32(_tblSqla.Rows[i]["PrdStpTxnSysId"]);



                        _ProductRiderSetupMdl.IsValidTxn = true;

                        _ProductRiderSetupMdlList.Add(_ProductRiderSetupMdl);
                    }

                    return _ProductRiderSetupMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //for adding new Product Rider Setup
        public ProductRiderSetupMdl AddProductRiderSetup(ProductRiderSetupMdl _ProductRiderSetupMdl)
        {
            try
            {
                if (IsDuplicateProductRiderSetup(_ProductRiderSetupMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _ProductRiderSetupMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1001";
                    _txnError.Error = "Duplicate Transaction";
                    _txnError.TxnSysDate = DateTime.Now;
                    _txnErrors.Add(_txnError);



                    //To Return model

                    _ProductRiderSetupMdl.TxnErrors = _txnErrors;
                    return _ProductRiderSetupMdl;
                }

                else
                {
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("INSERT INTO ProductRiderSetup(");
                    //_sbSql.AppendLine("TxnSysID,");
                    //_sbSql.AppendLine("TxnSysDate,");
                    _sbSql.AppendLine("UserCode,");
                    _sbSql.AppendLine("RiderCode,");
                    _sbSql.AppendLine("RiderName,");
                    _sbSql.AppendLine("RiderRate,");
                    _sbSql.AppendLine("PrdStpTxnSysId)");


                    _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                   // _sbSql.AppendLine("@TxnSysID,");
                  //  _sbSql.AppendLine("@TxnSysDate,");
                    _sbSql.AppendLine("@UserCode,");
                    _sbSql.AppendLine("@RiderCode,");
                    _sbSql.AppendLine("@RiderName,");
                    _sbSql.AppendLine("@RiderRate,");
                    _sbSql.AppendLine("@PrdStpTxnSysId)");



                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);
                    int _userCode = GlobalDataLayer.GetUserCodeById(_ProductRiderSetupMdl.UserCode);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@RiderCode", _ProductRiderSetupMdl.RiderCode);

                    string RiderName = GlobalDataLayer.GetRiderSetUpNameByCode(_ProductRiderSetupMdl.RiderCode);
                    _cmdSql.Parameters.AddWithValue("@RiderName", RiderName);
                    _cmdSql.Parameters.AddWithValue("@RiderRate", _ProductRiderSetupMdl.RiderRate);
                    _cmdSql.Parameters.AddWithValue("@PrdStpTxnSysId", _ProductRiderSetupMdl.PrdStpTxnSysId);


                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();




                    _ProductRiderSetupMdl.TxnSysID = _TxnSysId;
                    _ProductRiderSetupMdl.IsValidTxn = true;
                    _ProductRiderSetupMdl.RiderName = RiderName;
                    return _ProductRiderSetupMdl;

                }


            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //for updating existing Product Rider Setup
        public ProductRiderSetupMdl UpdateProductRiderSetup(ProductRiderSetupMdl _ProductRiderSetupMdl)
        {
            try
            {

                _ProductRiderSetupMdl.PrdStpTxnSysId = _ProductRiderSetupMdl.PrdStpTxnSysId == 0 ? _ProductRiderSetupMdl.PrdStpTxnSysId = -1 : _ProductRiderSetupMdl.PrdStpTxnSysId;

                if (IsDuplicateProductRiderSetup(_ProductRiderSetupMdl) == false)
                {

                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("Update  ProductRiderSetup SET");
                    _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
                    _sbSql.AppendLine("UserCode= @UserCode,");
                    _sbSql.AppendLine("PrdStpTxnSysId=@PrdStpTxnSysId,");
                    _sbSql.AppendLine("RiderCode=@RiderCode,");
                    _sbSql.AppendLine("RiderName=@RiderName,");
                    _sbSql.AppendLine("RiderRate=@RiderRate");

                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_ProductRiderSetupMdl.UserCode);


                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _ProductRiderSetupMdl.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@PrdStpTxnSysId", _ProductRiderSetupMdl.PrdStpTxnSysId);
                    _cmdSql.Parameters.AddWithValue("@RiderCode", _ProductRiderSetupMdl.RiderCode);

                    string RiderName = GlobalDataLayer.GetRiderSetUpNameByCode(_ProductRiderSetupMdl.RiderCode);

                    _cmdSql.Parameters.AddWithValue("@RiderName", RiderName);
                    _cmdSql.Parameters.AddWithValue("@RiderRate", _ProductRiderSetupMdl.RiderRate);



                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    _ProductRiderSetupMdl.IsValidTxn = true;
                    return _ProductRiderSetupMdl;
                }

                else
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _ProductRiderSetupMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1002";
                    _txnError.Error = "Active Transaction";
                    _txnError.TxnSysDate = DateTime.Now;


                    List<TxnError> _txnErrors2 = new List<TxnError>();
                    TxnError _txnError2 = new TxnError();

                    _txnError2.ErrorCode = "1001";
                    _txnError2.Error = "Duplicate  Transaction";
                    _txnError2.TxnSysDate = DateTime.Now;

                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError2);



                    //To Return model

                    _ProductRiderSetupMdl.TxnErrors = _txnErrors;


                    return _ProductRiderSetupMdl;

                }
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //for checking duplicate Product Rider SetupMdl
        public bool IsDuplicateProductRiderSetup(ProductRiderSetupMdl _ProductRiderSetupMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  ProductRiderSetup  WHERE UPPER(RiderName)='" + GlobalDataLayer.GetRiderSetUpNameByCode(_ProductRiderSetupMdl.RiderCode).ToString().ToUpper() + "' AND PrdStpTxnSysId=" + _ProductRiderSetupMdl.PrdStpTxnSysId + " AND TxnSysID <>" + _ProductRiderSetupMdl.TxnSysID;


                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductWarrantiesSetupMdl> _ProductWarrantiesSetupMdlList = new List<ProductWarrantiesSetupMdl>();

                DuplicationCheck _duplicationCheck = new DuplicationCheck();



                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }



            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return true;
            }
        }


        // -----------------------------------------------CRUD Operation Ends from Here------------------------------------------------------------------- //

        //incerementing product code
        public string ProductCode()
        {

            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(ProductCode) LastProductCode FROM MasterProductSetup";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                string _result;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows[0][0] == null)
                {
                    _result = "1";
                }
                else
                {
                    int _tmpNumber = Convert.ToInt32(_tbl.Rows[0][0]) + 1;
                    _result = _tmpNumber.ToString();
                }

                return _result;
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        
    }

        //Get new Product code
        private int GettingNewProductCode(MasterProductSetupMdl _MasterProductSetupMdl)
        {
            try
            {
                SqlConnection _conSql =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(ProductCode) LastProductCode FROM MasterProductSetup";
                                 
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                int _result = 0;
                _adpSql.Fill(_tbl);

                //_result = _tbl.Rows[0][0].Equals(System.DBNull.Value) ? 1 : Convert.ToInt32(_tbl.Rows[0][0]) + 1;

                //return _result.ToString();


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

                int n = -1;
                return n;
            }
        }

        //for getting short text according to code of condition (1200 or 1221)
        public string GetConditionByCode(string _ConditionCode)
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //for getting short text of Rating Factor by using code of Rating Factor (10 or 11)
        public string GetRaitingFactorByCode(string _RatingFactorCode)
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //for getting Warranty Text From Warranty Code (200 or 201) 
        public string GetWarrantyTextByCode(string _WarrantyCode)
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //Getting Policy Type Name By Code(100 or 101)
        public string GetPolicyTypeNameByPolicyTypeCode(string _PolicyTypeCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                MasterProductSetupMdl _MasterProductSetupMdl;

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
                    _MasterProductSetupMdl = new MasterProductSetupMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _MasterProductSetupMdl.PolicyTypeName = _tblSqla.Rows[i]["PolicyTypeName"].ToString();

                    }
                    return _MasterProductSetupMdl.PolicyTypeName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //Getting Client Name By Code (25 or 26)
        public string GetClientNameByClientCode(string _ClientCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                MasterProductSetupMdl _MasterProductSetupMdl;

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
                    _MasterProductSetupMdl = new MasterProductSetupMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _MasterProductSetupMdl.ClientName = _tblSqla.Rows[i]["ClientName"].ToString();

                    }
                    return _MasterProductSetupMdl.ClientName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }

        //Getting Agent Name By Code(20 or 21)
        public string GetAgentNameByAgentCode(string _AgentCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                MasterProductSetupMdl _MasterProductSetupMdl;

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
                    _MasterProductSetupMdl = new MasterProductSetupMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _MasterProductSetupMdl.AgentName = _tblSqla.Rows[i]["AgentName"].ToString();

                    }
                    return _MasterProductSetupMdl.AgentName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Product SetUp DataLayer");
                return null;
            }
        }


    }
}