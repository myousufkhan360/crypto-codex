using ProductSetupApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using static ProductSetupApi.Models.OpenPolicyMdl;

namespace ProductSetupApi.DataLayers
{


    public class OpenPolicyDal
    {
        //-------------------- CRUD Starts From Here ------------------------//
       
        //for getting all Open Policy
        public List<MtrOpenPolicyMdl> GetMtrOpenPolicy()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrOpenPolicy WHERE DocType = 6";
                    //+ " WHERE  FORMAT(TxnSysDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + 
                   // "AND FORMAT(EffectiveDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + "AND FORMAT(ExpiryDate, 'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(), 'yyyy-MM-dd'))";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrOpenPolicyMdl> _MtrOpenPolicyMdlList = new List<MtrOpenPolicyMdl>();
                MtrOpenPolicyMdl _MtrOpenPolicyMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrOpenPolicyMdl = new MtrOpenPolicyMdl();

                        _MtrOpenPolicyMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrOpenPolicyMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]).Date;
                        _MtrOpenPolicyMdl.PolicyMonth = _tblSqla.Rows[i]["PolicyMonth"].ToString();
                        _MtrOpenPolicyMdl.InsuranceTypeCode = Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]);


                        _MtrOpenPolicyMdl.PolicyString = GetPolicyString(
                         _tblSqla.Rows[i]["BrchCoverNoteNo"].ToString(),
                           Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]),
                           _tblSqla.Rows[i]["DocType"].ToString(),
                           _tblSqla.Rows[i]["PolicyTypeCode"].ToString(),
                            _tblSqla.Rows[i]["PolicyNo"].ToString(),
                            Convert.ToInt32(_tblSqla.Rows[i]["SerialNo"]),
                             Convert.ToInt32(_tblSqla.Rows[i]["ProductCode"]),
                        _tblSqla.Rows[i]["PolicyMonth"].ToString(),
                            _tblSqla.Rows[i]["PolicyYear"].ToString());


                        _MtrOpenPolicyMdl.PolicyYear = _tblSqla.Rows[i]["PolicyYear"].ToString();
                        _MtrOpenPolicyMdl.PolicyNo = _tblSqla.Rows[i]["PolicyNo"].ToString();
                        _MtrOpenPolicyMdl.DocType = _tblSqla.Rows[i]["DocType"].ToString();
                        _MtrOpenPolicyMdl.GenerateAgainst = _tblSqla.Rows[i]["GenerateAgainst"].ToString();
                        _MtrOpenPolicyMdl.ProductCode = Convert.ToInt32(_tblSqla.Rows[i]["ProductCode"]);
                        _MtrOpenPolicyMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();
                        _MtrOpenPolicyMdl.ClientCode = _tblSqla.Rows[i]["ClientCode"].ToString();
                        _MtrOpenPolicyMdl.AgencyCode = _tblSqla.Rows[i]["AgencyCode"].ToString();
                        _MtrOpenPolicyMdl.CertInsureCode = _tblSqla.Rows[i]["CertInsureCode"].ToString();

                       // _MtrOpenPolicyMdl.ClientName = _tblSqla.Rows[i]["ClientName"].ToString();
                       // _MtrOpenPolicyMdl.ClientAddress = _tblSqla.Rows[i]["ClientAddress"].ToString();
                       // _MtrOpenPolicyMdl.ConditionCode = _tblSqla.Rows[i]["ConditionCode"].ToString();
                       // _MtrOpenPolicyMdl.WarrantyCode = _tblSqla.Rows[i]["WarrantyCode"].ToString();

                        _MtrOpenPolicyMdl.Remarks = _tblSqla.Rows[i]["Remarks"].ToString();
                        _MtrOpenPolicyMdl.BrchCoverNoteNo = _tblSqla.Rows[i]["BrchCoverNoteNo"].ToString();
                        _MtrOpenPolicyMdl.LeaderPolicyNo = _tblSqla.Rows[i]["LeaderPolicyNo"].ToString();
                        _MtrOpenPolicyMdl.LeaderEndNo = _tblSqla.Rows[i]["LeaderEndNo"].ToString();
                        _MtrOpenPolicyMdl.IsFiler = _tblSqla.Rows[i]["IsFiler"].ToString();
                        _MtrOpenPolicyMdl.CalcType = _tblSqla.Rows[i]["CalcType"].ToString();
                        _MtrOpenPolicyMdl.IsAuto = _tblSqla.Rows[i]["IsAuto"].ToString();
                        _MtrOpenPolicyMdl.SerialNo = Convert.ToInt32(_tblSqla.Rows[i]["SerialNo"].ToString());
                        _MtrOpenPolicyMdl.UWYear = _tblSqla.Rows[i]["UWYear"].ToString();
                        _MtrOpenPolicyMdl.CreatedBy = _tblSqla.Rows[i]["CreatedBy"].ToString();
                        _MtrOpenPolicyMdl.PostedBy = _tblSqla.Rows[i]["PostedBy"].ToString();
                        _MtrOpenPolicyMdl.IsPosted = Boolean.Parse(_tblSqla.Rows[i]["IsPosted"].ToString());
                      //  _MtrOpenPolicyMdl.PostDate = Convert.ToDateTime(_tblSqla.Rows[i]["PostDate"]);


                        _MtrOpenPolicyMdl.EffectiveDate = Convert.ToDateTime(_tblSqla.Rows[i]["EffectiveDate"]).Date;
                        _MtrOpenPolicyMdl.ExpiryDate = Convert.ToDateTime(_tblSqla.Rows[i]["ExpiryDate"].ToString()).Date;
                        _MtrOpenPolicyMdl.CommisionRate = Convert.ToDecimal(_tblSqla.Rows[i]["CommisionRate"]);


                        _MtrOpenPolicyMdl.IsValidTxn = true;


                        _MtrOpenPolicyMdl.ProductName = GetProductNameByProductCode(_tblSqla.Rows[i]["ProductCode"].ToString());
                        _MtrOpenPolicyMdl.PolicyTypeName = GetPolicyTypeNameByPolicyTypeCode(_tblSqla.Rows[i]["PolicyTypeCode"].ToString());
                        _MtrOpenPolicyMdl.ClientName = GetClientNameByClientCode(_tblSqla.Rows[i]["ClientCode"].ToString());
                        _MtrOpenPolicyMdl.AgentName = GetAgentNameByAgentCode(_tblSqla.Rows[i]["AgencyCode"].ToString());
                        _MtrOpenPolicyMdl.CertInsureName = GetCertInsNameByCertInsCode(_tblSqla.Rows[i]["CertInsureCode"].ToString());

                        _MtrOpenPolicyMdl.DocTypeName = GetDocTypeNameByDocTypeCode(_tblSqla.Rows[i]["DocType"].ToString());
                        _MtrOpenPolicyMdl.IsFilerName = GetIsFilerNameByIsFilerCode(_tblSqla.Rows[i]["IsFiler"].ToString());
                        _MtrOpenPolicyMdl.CalcName = GetCalcNameByCalcCode(_tblSqla.Rows[i]["CalcType"].ToString());
                        _MtrOpenPolicyMdl.IsAutoName = GetIsAutoNameByIsAutoCode(_tblSqla.Rows[i]["IsAuto"].ToString());
                        _MtrOpenPolicyMdl.InsuranceTypeName = GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]));

                        

                        string OpenPolicyDoc = "6";
                        _MtrOpenPolicyMdl.DocType = OpenPolicyDoc;

                        _MtrOpenPolicyMdlList.Add(_MtrOpenPolicyMdl);


                    }

                    return _MtrOpenPolicyMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //for adding new Open Policy
        public MtrOpenPolicyMdl AddMtrOpenPolicy(MtrOpenPolicyMdl _MtrOpenPolicyMdl)
        {
            try

            {

                _MtrOpenPolicyMdl.SerialNo = _MtrOpenPolicyMdl.SerialNo == 0 ? _MtrOpenPolicyMdl.SerialNo ++ : _MtrOpenPolicyMdl.SerialNo ++;

                if (IsDuplicateMtrOpenPolicy(_MtrOpenPolicyMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _MtrOpenPolicyMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1001";
                    _txnError.Error = "Duplicate Transaction";
                    _txnError.TxnSysDate = DateTime.Now;

                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError);

                    //To Return model
                    _MtrOpenPolicyMdl.TxnErrors = _txnErrors;


                    //_MtrOpenPolicyMdl.ProductName = GetProductNameByProductCode(_MtrOpenPolicyMdl.ProductCode.ToString());
                    //_MtrOpenPolicyMdl.PolicyTypeName = GetPolicyTypeNameByPolicyTypeCode(_MtrOpenPolicyMdl.PolicyTypeCode.ToString());
                    //_MtrOpenPolicyMdl.ClientName = GetClientNameByClientCode(_MtrOpenPolicyMdl.ClientCode.ToString());
                    //_MtrOpenPolicyMdl.AgentName = GetAgentNameByAgentCode(_MtrOpenPolicyMdl.AgencyCode.ToString());
                    //_MtrOpenPolicyMdl.CertInsureName = GetCertInsNameByCertInsCode(_MtrOpenPolicyMdl.CertInsureCode.ToString());

                    //_MtrOpenPolicyMdl.DocTypeName = GetDocTypeNameByDocTypeCode(_MtrOpenPolicyMdl.DocType.ToString());
                    //_MtrOpenPolicyMdl.IsFilerName = GetIsFilerNameByIsFilerCode(_MtrOpenPolicyMdl.IsFiler.ToString());
                    //_MtrOpenPolicyMdl.CalcName = GetCalcNameByCalcCode(_MtrOpenPolicyMdl.CalcType.ToString());
                    //_MtrOpenPolicyMdl.IsAutoName = GetIsAutoNameByIsAutoCode(_MtrOpenPolicyMdl.IsAuto.ToString());

                    //string PolicyString = GetPolicyString(_MtrOpenPolicyMdl.PolicyNo.ToString(), _MtrOpenPolicyMdl.PolicyMonth.ToString(), _MtrOpenPolicyMdl.PolicyYear.ToString());
                    //_MtrOpenPolicyMdl.PolicyString = PolicyString;

                    _MtrOpenPolicyMdl.TxnSysDate = DateTime.Now;

                    return _MtrOpenPolicyMdl;

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
                    int _SerialNumber = GetSerialNo(_MtrOpenPolicyMdl);


                    _sbSql.AppendLine("INSERT INTO MtrOpenPolicy(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql.AppendLine("TxnSysDate,");
                    _sbSql.AppendLine("InsuranceTypeCode,");
                    _sbSql.AppendLine("PolicyMonth,");
                    _sbSql.AppendLine("PolicyString,");
                    _sbSql.AppendLine("PolicyYear,");
                    _sbSql.AppendLine("PolicyNo,");
                    _sbSql.AppendLine("DocType,");
                    _sbSql.AppendLine("GenerateAgainst,");
                    _sbSql.AppendLine("ProductCode,");
                    _sbSql.AppendLine("PolicyTypeCode,");
                    _sbSql.AppendLine("ClientCode,");
                    _sbSql.AppendLine("AgencyCode,");
                    _sbSql.AppendLine("CertInsureCode,");
                   // _sbSql.AppendLine("ClientName,");
                   // _sbSql.AppendLine("ClientAddress,");
                   // _sbSql.AppendLine("ConditionCode,");
                   // _sbSql.AppendLine("WarrantyCode,");
                    _sbSql.AppendLine("Remarks,");
                    _sbSql.AppendLine("BrchCoverNoteNo,");
                    _sbSql.AppendLine("LeaderPolicyNo,");
                    _sbSql.AppendLine("LeaderEndNo,");
                    _sbSql.AppendLine("IsFiler,");
                    _sbSql.AppendLine("CalcType,");
                    _sbSql.AppendLine("IsAuto,");
                    _sbSql.AppendLine("EffectiveDate,");
                    _sbSql.AppendLine("ExpiryDate,");
                    _sbSql.AppendLine("SerialNo,");
                    _sbSql.AppendLine("UWYear,");
                    _sbSql.AppendLine("CommisionRate,");
                    _sbSql.AppendLine("CreatedBy)");


                    _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                    // _sbSql.AppendLine("@TxnSysID,");
                    _sbSql.AppendLine("@TxnSysDate,");
                    _sbSql.AppendLine("@InsuranceTypeCode,");
                    _sbSql.AppendLine("@PolicyMonth,");
                    _sbSql.AppendLine("@PolicyString,");
                    _sbSql.AppendLine("@PolicyYear,");
                    _sbSql.AppendLine("@PolicyNo,");
                    _sbSql.AppendLine("@DocType,");
                    _sbSql.AppendLine("@GenerateAgainst,");
                    _sbSql.AppendLine("@ProductCode,");
                    _sbSql.AppendLine("@PolicyTypeCode,");
                    _sbSql.AppendLine("@ClientCode,");
                    _sbSql.AppendLine("@AgencyCode,");
                    _sbSql.AppendLine("@CertInsureCode,");
                 //   _sbSql.AppendLine("@ClientName,");
                 //   _sbSql.AppendLine("@ClientAddress,");
                  //  _sbSql.AppendLine("@ConditionCode,");
                  //  _sbSql.AppendLine("@WarrantyCode,");
                    _sbSql.AppendLine("@Remarks,");
                    _sbSql.AppendLine("@BrchCoverNoteNo,");
                    _sbSql.AppendLine("@LeaderPolicyNo,");
                    _sbSql.AppendLine("@LeaderEndNo,");
                    _sbSql.AppendLine("@IsFiler,");
                    _sbSql.AppendLine("@CalcType,");
                    _sbSql.AppendLine("@IsAuto,");
                    _sbSql.AppendLine("@EffectiveDate,");
                    _sbSql.AppendLine("@ExpiryDate,");
                    _sbSql.AppendLine("@SerialNo,");
                    _sbSql.AppendLine("@UWYear,");
                    _sbSql.AppendLine("@CommisionRate,");
                    _sbSql.AppendLine("@CreatedBy)");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);


                   

                    DateTime da = DateTime.Now;
                    da.ToString("MM-dd-yyyy h:mm tt");


                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", Convert.ToDateTime(da));
                    //da.ToString("MM-dd-yyyyTHH:mm:ss"));
                    _cmdSql.Parameters.AddWithValue("@PolicyMonth", DateTime.Now.Month.ToString());


                    string OpenPolicyDoc1 = "06";

                    string PolicyString = GetPolicyString(
                         _MtrOpenPolicyMdl.BrchCoverNoteNo, _MtrOpenPolicyMdl.InsuranceTypeCode, OpenPolicyDoc1,
                         _MtrOpenPolicyMdl.PolicyTypeCode,
                         _MtrOpenPolicyMdl.PolicyNo,
                         _SerialNumber,
                          _MtrOpenPolicyMdl.ProductCode,
                        DateTime.Now.Month.ToString(),
                            DateTime.Now.Year.ToString());


                   
                    _cmdSql.Parameters.AddWithValue("@PolicyString", PolicyString);

                    _cmdSql.Parameters.AddWithValue("@PolicyYear", DateTime.Now.Year.ToString());


                    //_cmdSql.Parameters.AddWithValue("@PolicyYear", _MtrOpenPolicyMdl.PolicyYear);



                  //  _cmdSql.Parameters.AddWithValue("@PolicyNo", _MtrOpenPolicyMdl.PolicyNo);
                    _cmdSql.Parameters.AddWithValue("@PolicyNo", GettingNewPolicyNo(_MtrOpenPolicyMdl));

                    string OpenPolicyDoc = "6";

                    _cmdSql.Parameters.AddWithValue("@DocType", OpenPolicyDoc);
                    _cmdSql.Parameters.AddWithValue("@GenerateAgainst", GettingNewPolicyNo(_MtrOpenPolicyMdl));
                    _cmdSql.Parameters.AddWithValue("@ProductCode", _MtrOpenPolicyMdl.ProductCode);
                    _cmdSql.Parameters.AddWithValue("@PolicyTypeCode", _MtrOpenPolicyMdl.PolicyTypeCode);
                    _cmdSql.Parameters.AddWithValue("@ClientCode", _MtrOpenPolicyMdl.ClientCode);
                    _cmdSql.Parameters.AddWithValue("@AgencyCode", _MtrOpenPolicyMdl.AgencyCode);
                    _cmdSql.Parameters.AddWithValue("@CertInsureCode", _MtrOpenPolicyMdl.CertInsureCode);
                   // _cmdSql.Parameters.AddWithValue("@ClientName", _MtrOpenPolicyMdl.ClientName);
                 //   _cmdSql.Parameters.AddWithValue("@ClientAddress", _MtrOpenPolicyMdl.ClientAddress);
                  //  _cmdSql.Parameters.AddWithValue("@ConditionCode", _MtrOpenPolicyMdl.ConditionCode);
                  //  _cmdSql.Parameters.AddWithValue("@WarrantyCode", _MtrOpenPolicyMdl.WarrantyCode);
                    _cmdSql.Parameters.AddWithValue("@Remarks", _MtrOpenPolicyMdl.Remarks ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@BrchCoverNoteNo", _MtrOpenPolicyMdl.BrchCoverNoteNo);
                    _cmdSql.Parameters.AddWithValue("@LeaderPolicyNo", _MtrOpenPolicyMdl.LeaderPolicyNo ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@LeaderEndNo", _MtrOpenPolicyMdl.LeaderEndNo ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@IsFiler", _MtrOpenPolicyMdl.IsFiler);
                    _cmdSql.Parameters.AddWithValue("@CalcType", _MtrOpenPolicyMdl.CalcType);
                    _cmdSql.Parameters.AddWithValue("@IsAuto", _MtrOpenPolicyMdl.IsAuto);
                    _cmdSql.Parameters.AddWithValue("@EffectiveDate", Convert.ToDateTime(_MtrOpenPolicyMdl.EffectiveDate.ToString()));
                    _cmdSql.Parameters.AddWithValue("@ExpiryDate", Convert.ToDateTime(_MtrOpenPolicyMdl.ExpiryDate.ToString()));
                    _cmdSql.Parameters.AddWithValue("@SerialNo", _SerialNumber);
                    _cmdSql.Parameters.AddWithValue("@InsuranceTypeCode", _MtrOpenPolicyMdl.InsuranceTypeCode);


                    _cmdSql.Parameters.AddWithValue("@UWYear", DateTime.Now.Year.ToString());
                    // _cmdSql.Parameters.AddWithValue("@UWYear", _MtrOpenPolicyMdl.UWYear);


                    _cmdSql.Parameters.AddWithValue("@CommisionRate", _MtrOpenPolicyMdl.CommisionRate);

                    _cmdSql.Parameters.AddWithValue("@CreatedBy", _MtrOpenPolicyMdl.CreatedBy);


                    

                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();
                    _MtrOpenPolicyMdl.IsValidTxn = true;

                    _MtrOpenPolicyMdl.PolicyString = PolicyString;
                    _MtrOpenPolicyMdl.SerialNo = _SerialNumber;
                    _MtrOpenPolicyMdl.TxnSysDate = DateTime.Now;
                    _MtrOpenPolicyMdl.PolicyNo = GettingNewPolicyNo(_MtrOpenPolicyMdl);

                    _MtrOpenPolicyMdl.TxnSysID = _TxnSysId;

                    _MtrOpenPolicyMdl.ProductName = GetProductNameByProductCode(_MtrOpenPolicyMdl.ProductCode.ToString());
                    _MtrOpenPolicyMdl.PolicyTypeName = GetPolicyTypeNameByPolicyTypeCode(_MtrOpenPolicyMdl.PolicyTypeCode.ToString());
                    _MtrOpenPolicyMdl.ClientName = GetClientNameByClientCode(_MtrOpenPolicyMdl.ClientCode.ToString());
                    _MtrOpenPolicyMdl.AgentName = GetAgentNameByAgentCode(_MtrOpenPolicyMdl.AgencyCode.ToString());
                    _MtrOpenPolicyMdl.CertInsureName = GetCertInsNameByCertInsCode(_MtrOpenPolicyMdl.CertInsureCode.ToString());

                    _MtrOpenPolicyMdl.DocTypeName = GetDocTypeNameByDocTypeCode(OpenPolicyDoc);
                    _MtrOpenPolicyMdl.IsFilerName = GetIsFilerNameByIsFilerCode(_MtrOpenPolicyMdl.IsFiler.ToString());
                    _MtrOpenPolicyMdl.CalcName = GetCalcNameByCalcCode(_MtrOpenPolicyMdl.CalcType.ToString());
                    _MtrOpenPolicyMdl.IsAutoName = GetIsAutoNameByIsAutoCode(_MtrOpenPolicyMdl.IsAuto.ToString());
                    _MtrOpenPolicyMdl.InsuranceTypeName = GetInsuranceTypeNameByCode(_MtrOpenPolicyMdl.InsuranceTypeCode);

                    _MtrOpenPolicyMdl.PolicyNo = GettingNewPolicyNo(_MtrOpenPolicyMdl);
                    _MtrOpenPolicyMdl.GenerateAgainst = GettingNewPolicyNo(_MtrOpenPolicyMdl);


                    _MtrOpenPolicyMdl.DocType = OpenPolicyDoc1;

                    return _MtrOpenPolicyMdl;
                }
            }
            catch (Exception ex)
            {

                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }

        }

        //for updating existing Open Policy
        public MtrOpenPolicyMdl UpdateMtrOpenPolicy(MtrOpenPolicyMdl _MtrOpenPolicyMdl)
       {
            try
            {

                _MtrOpenPolicyMdl.SerialNo = _MtrOpenPolicyMdl.SerialNo == 0 ? _MtrOpenPolicyMdl.SerialNo += 1 : _MtrOpenPolicyMdl.SerialNo;

                // if (IsDuplicateMtrOpenPolicy(_MtrOpenPolicyMdl) == false && IsExpiredMtrOpenPolicy(_MtrOpenPolicyMdl) == false  )
                if (IsExpiredMtrOpenPolicy(_MtrOpenPolicyMdl) == false)
                {


                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;


                    _sbSql.AppendLine("Update  MtrOpenPolicy SET");
                    _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
                    _sbSql.AppendLine("PolicyMonth= @PolicyMonth,");
                    _sbSql.AppendLine("PolicyString= @PolicyString,");
                    _sbSql.AppendLine("InsuranceTypeCode= @InsuranceTypeCode,");
                    _sbSql.AppendLine("PolicyYear= @PolicyYear,");
                   // _sbSql.AppendLine("PolicyNo= @PolicyNo,");
                    _sbSql.AppendLine("DocType= @DocType,");
                   _sbSql.AppendLine("GenerateAgainst= @GenerateAgainst,");
                    _sbSql.AppendLine("ProductCode= @ProductCode,");
                    _sbSql.AppendLine("PolicyTypeCode= @PolicyTypeCode,");
                    _sbSql.AppendLine("ClientCode= @ClientCode,");
                    _sbSql.AppendLine("AgencyCode= @AgencyCode,");
                    _sbSql.AppendLine("CertInsureCode= @CertInsureCode,");
                  
                    _sbSql.AppendLine("Remarks= @Remarks,");
                    _sbSql.AppendLine("BrchCoverNoteNo= @BrchCoverNoteNo,");

                    _sbSql.AppendLine("LeaderPolicyNo= @LeaderPolicyNo,");
                    _sbSql.AppendLine("LeaderEndNo= @LeaderEndNo,");
                    _sbSql.AppendLine("IsFiler= @IsFiler,");
                    _sbSql.AppendLine("CalcType= @CalcType,");
                    _sbSql.AppendLine("IsAuto= @IsAuto,");

                    _sbSql.AppendLine("EffectiveDate = @EffectiveDate,");
                    _sbSql.AppendLine("ExpiryDate = @ExpiryDate,");
                   // _sbSql.AppendLine("SerialNo= @SerialNo,");
                    _sbSql.AppendLine("UWYear= @UWYear,");
                    // _sbSql.AppendLine("CreatedBy= @CreatedBy");
                    _sbSql.AppendLine("CommisionRate= @CommisionRate");
                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                   


                    _cmdSql.Parameters.AddWithValue("@TxnSysID", _MtrOpenPolicyMdl.TxnSysID);


                    DateTime da = DateTime.Now;
                    da.ToString("MM-dd-yyyy h:mm tt");
                    string OpenPolicyDoc = "06";

                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);

                    int _SerialNumber = GetSerialNo(_MtrOpenPolicyMdl);

                    _cmdSql.Parameters.AddWithValue("@PolicyMonth", DateTime.Now.Month.ToString());

                    string PolicyString = GetPolicyString(
                         _MtrOpenPolicyMdl.BrchCoverNoteNo, _MtrOpenPolicyMdl.InsuranceTypeCode, OpenPolicyDoc,
                         _MtrOpenPolicyMdl.PolicyTypeCode,
                          _MtrOpenPolicyMdl.PolicyNo,
                         _MtrOpenPolicyMdl.SerialNo,
                          _MtrOpenPolicyMdl.ProductCode,
                        DateTime.Now.Month.ToString(),
                            DateTime.Now.Year.ToString());

                    _cmdSql.Parameters.AddWithValue("@PolicyString", PolicyString);

                    _cmdSql.Parameters.AddWithValue("@PolicyYear", DateTime.Now.Year.ToString());

                    //  _cmdSql.Parameters.AddWithValue("@PolicyNo", GettingNewPolicyNo(_MtrOpenPolicyMdl));

                    

                    _cmdSql.Parameters.AddWithValue("@DocType", OpenPolicyDoc);

                    string str = "abc";
                    _cmdSql.Parameters.AddWithValue("@GenerateAgainst", GettingNewPolicyNo(_MtrOpenPolicyMdl));

                    _cmdSql.Parameters.AddWithValue("@ProductCode", _MtrOpenPolicyMdl.ProductCode);
                    _cmdSql.Parameters.AddWithValue("@PolicyTypeCode", _MtrOpenPolicyMdl.PolicyTypeCode);
                    _cmdSql.Parameters.AddWithValue("@ClientCode", _MtrOpenPolicyMdl.ClientCode);
                    _cmdSql.Parameters.AddWithValue("@AgencyCode", _MtrOpenPolicyMdl.AgencyCode);
                    _cmdSql.Parameters.AddWithValue("@CertInsureCode", _MtrOpenPolicyMdl.CertInsureCode);
                    

                   
                    _cmdSql.Parameters.AddWithValue("@Remarks", _MtrOpenPolicyMdl.Remarks ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@BrchCoverNoteNo", _MtrOpenPolicyMdl.BrchCoverNoteNo);
                    _cmdSql.Parameters.AddWithValue("@LeaderPolicyNo", _MtrOpenPolicyMdl.LeaderPolicyNo ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@LeaderEndNo", _MtrOpenPolicyMdl.LeaderEndNo ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@IsFiler", _MtrOpenPolicyMdl.IsFiler);
                    _cmdSql.Parameters.AddWithValue("@CalcType", _MtrOpenPolicyMdl.CalcType);
                    _cmdSql.Parameters.AddWithValue("@IsAuto", _MtrOpenPolicyMdl.IsAuto);

                    _cmdSql.Parameters.AddWithValue("@EffectiveDate", Convert.ToDateTime(_MtrOpenPolicyMdl.EffectiveDate.ToString()));
                    _cmdSql.Parameters.AddWithValue("@ExpiryDate", Convert.ToDateTime(_MtrOpenPolicyMdl.ExpiryDate.ToString()));

                    // _cmdSql.Parameters.AddWithValue("@SerialNo", _MtrOpenPolicyMdl.SerialNo);
                    _cmdSql.Parameters.AddWithValue("@UWYear", DateTime.Now.Year.ToString());
                    _cmdSql.Parameters.AddWithValue("@InsuranceTypeCode",_MtrOpenPolicyMdl.InsuranceTypeCode);

                    _cmdSql.Parameters.AddWithValue("@CommisionRate", _MtrOpenPolicyMdl.CommisionRate);


                    _MtrOpenPolicyMdl.IsValidTxn = true;


                    _MtrOpenPolicyMdl.ProductName = GetProductNameByProductCode(_MtrOpenPolicyMdl.ProductCode.ToString());
                    _MtrOpenPolicyMdl.PolicyTypeName = GetPolicyTypeNameByPolicyTypeCode(_MtrOpenPolicyMdl.PolicyTypeCode.ToString());
                    _MtrOpenPolicyMdl.ClientName = GetClientNameByClientCode(_MtrOpenPolicyMdl.ClientCode.ToString());
                    _MtrOpenPolicyMdl.AgentName = GetAgentNameByAgentCode(_MtrOpenPolicyMdl.AgencyCode.ToString());
                    _MtrOpenPolicyMdl.CertInsureName = GetCertInsNameByCertInsCode(_MtrOpenPolicyMdl.CertInsureCode.ToString());

                     _MtrOpenPolicyMdl.DocTypeName = GetDocTypeNameByDocTypeCode(OpenPolicyDoc);
                    _MtrOpenPolicyMdl.IsFilerName = GetIsFilerNameByIsFilerCode(_MtrOpenPolicyMdl.IsFiler.ToString());
                    _MtrOpenPolicyMdl.CalcName = GetCalcNameByCalcCode(_MtrOpenPolicyMdl.CalcType.ToString());
                    _MtrOpenPolicyMdl.IsAutoName = GetIsAutoNameByIsAutoCode(_MtrOpenPolicyMdl.IsAuto.ToString());
                    _MtrOpenPolicyMdl.InsuranceTypeName = GetInsuranceTypeNameByCode(_MtrOpenPolicyMdl.InsuranceTypeCode);
                    _MtrOpenPolicyMdl.TxnSysDate = DateTime.Now;
                    _MtrOpenPolicyMdl.PolicyMonth = DateTime.Now.Month.ToString();
                    _MtrOpenPolicyMdl.UWYear = DateTime.Now.Year.ToString();
                    _MtrOpenPolicyMdl.DocType = OpenPolicyDoc;



                    _MtrOpenPolicyMdl.PolicyString = PolicyString;

                    string OpenPolicyDoc1 = "6";
                    _MtrOpenPolicyMdl.DocType = OpenPolicyDoc1;

                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    return _MtrOpenPolicyMdl;

                }

                //else if(IsDuplicateMtrOpenPolicy(_MtrOpenPolicyMdl) == true)
                //{

                //    List<TxnError> _txnErrors = new List<TxnError>();
                //    TxnError _txnError = new TxnError();
                //    _MtrOpenPolicyMdl.IsValidTxn = false;
                //    _txnError.ErrorCode = "1002";
                //    _txnError.Error = "Active Transaction";
                //    _txnError.TxnSysDate = DateTime.Now;


                //    List<TxnError> _txnErrors2 = new List<TxnError>();
                //    TxnError _txnError2 = new TxnError();

                //    _txnError2.ErrorCode = "1001";
                //    _txnError2.Error = "Duplicate  Transaction";
                //    _txnError2.TxnSysDate = DateTime.Now;

                //    _txnErrors.Add(_txnError);
                //    _txnErrors.Add(_txnError2);

                //    //For creating Log file
                //    // string _logFileName = CreateLog(_txnErrors, "Master Product SetUp");
                //    //  Process.Start("notepad.exe", _logFileName);

                //    ////For Email Sending
                //    //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                //    //client.EnableSsl = true;
                //    //client.Timeout = 100000;
                //    //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //    //client.UseDefaultCredentials = false;
                //    //client.Credentials = new NetworkCredential("yousuftakaful@gmail.com", "takaful123");
                //    //MailMessage msg = new MailMessage();
                //    //msg.To.Add("huma_abdi@hotmail.com");
                //    //msg.From = new MailAddress("yousuftakaful@gmail.com");
                //    //msg.Subject = "Error Log of Product Setup---" + DateTime.Now.ToString();
                //    //string body = String.Concat(_txnErrors.Select(o => "\n ================== PRODUCT SETUP ERROR LOG ================== \n" + "\n Error Date = " + o.TxnSysDate + "\n Error Code = " + o.ErrorCode + "\n Error = " + o.Error));

                //    //msg.Body = body + "\n Master Product Code = " + _MasterProductSetupMdl.ProductCode + "\n Master Product Name = " + _MasterProductSetupMdl.ProductName + "\n Client = " + _MasterProductSetupMdl.Client + "\n Agent = " + _MasterProductSetupMdl.Agent;

                //    //client.Send(msg);
                //    //Debug.WriteLine("Email Sent Sucessfully");

                //    //To Return model
                //    _MtrOpenPolicyMdl.TxnErrors = _txnErrors;

                    

                //    _MtrOpenPolicyMdl.TxnSysDate = DateTime.Now;


                  
                //    return _MtrOpenPolicyMdl;
                //}

                else if (IsExpiredMtrOpenPolicy(_MtrOpenPolicyMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _MtrOpenPolicyMdl.IsValidTxn = false;
                    //_MtrOpenPolicyMdl.IsExpired = true;
                    _txnError.ErrorCode = "1004";
                    _txnError.Error = "Policy Has been Expired";
                    _txnError.TxnSysDate = DateTime.Now;


                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError);

                    //For creating Log file
                    // string _logFileName = CreateLog(_txnErrors, "Master Product SetUp");
                    //  Process.Start("notepad.exe", _logFileName);

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
                    _MtrOpenPolicyMdl.TxnErrors = _txnErrors;

                   
                    _MtrOpenPolicyMdl.TxnSysDate = DateTime.Now;

                    return _MtrOpenPolicyMdl;
                }

                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }


        //for checking duplicate Open Policy
        public bool IsDuplicateMtrOpenPolicy(MtrOpenPolicyMdl _MtrOpenPolicyMdl)

       {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  MtrOpenPolicy  WHERE   PolicyYear = '" + DateTime.Now.Year.ToString()
                    + "' AND PolicyTypeCode= '" + _MtrOpenPolicyMdl.PolicyTypeCode.ToString() + "' AND ClientCode = '" + _MtrOpenPolicyMdl.ClientCode.ToString() + "'AND ProductCode = '" + _MtrOpenPolicyMdl.ProductCode.ToString()+"'";


                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<MtrOpenPolicyMdl> _MtrOpenPolicyMdlList = new List<MtrOpenPolicyMdl>();
            
                DuplicationCheck _duplicationCheck = new DuplicationCheck();

          

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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return true;
            }
        }

        //For Posting the Policy
        public MtrOpenPolicyMdl PostMtrOpenPolicy(MtrOpenPolicyMdl _MtrOpenPolicyMdl)
        {
            try

            {

                if ((IsPostedMtrOpenPolicy(_MtrOpenPolicyMdl) == false) && (IsExpiredMtrOpenPolicy(_MtrOpenPolicyMdl) == false) && (IsPostedTMtrOpenPolicy(_MtrOpenPolicyMdl) == false))

                {

                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;
                   



                    _sbSql.AppendLine("Update  MtrOpenPolicy SET");
                   
                    _sbSql.AppendLine("PostedBy= @PostedBy,");

                    _sbSql.AppendLine("IsPosted= @IsPosted,");

                    _sbSql.AppendLine("PostDate= @PostDate");

                    _sbSql.AppendLine("WHERE TxnSysID = @TxnSysID ");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                  

                    _cmdSql.Parameters.AddWithValue("@TxnSysID", _MtrOpenPolicyMdl.TxnSysID);


                 


                   

                    _MtrOpenPolicyMdl.IsPosted = true;
                   

                    _cmdSql.Parameters.AddWithValue("@PostedBy", _MtrOpenPolicyMdl.PostedBy);
                    _cmdSql.Parameters.AddWithValue("@PostDate", DateTime.Now);

                    int t = 1;

                    _cmdSql.Parameters.AddWithValue("@IsPosted", true);


                    _MtrOpenPolicyMdl.IsValidTxn = true;


                   

                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    return _MtrOpenPolicyMdl;

                }

                else if(IsPostedMtrOpenPolicy(_MtrOpenPolicyMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _MtrOpenPolicyMdl.IsValidTxn = false;
                
                    _txnError.ErrorCode = "1003";
                    _txnError.Error = "Policy is Created by and Posted by same person";
                    _txnError.TxnSysDate = DateTime.Now;


                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError);

                    //For creating Log file
                    // string _logFileName = CreateLog(_txnErrors, "Master Product SetUp");
                    //  Process.Start("notepad.exe", _logFileName);

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
                    _MtrOpenPolicyMdl.TxnErrors = _txnErrors;
                    return _MtrOpenPolicyMdl;
                }

                else if (IsExpiredMtrOpenPolicy(_MtrOpenPolicyMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _MtrOpenPolicyMdl.IsValidTxn = false;
                    //_MtrOpenPolicyMdl.IsExpired = true;
                    _txnError.ErrorCode = "1004";
                    _txnError.Error = "Policy Has been Expired";
                    _txnError.TxnSysDate = DateTime.Now;


                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError);

                    //For creating Log file
                    // string _logFileName = CreateLog(_txnErrors, "Master Product SetUp");
                    //  Process.Start("notepad.exe", _logFileName);

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
                    _MtrOpenPolicyMdl.TxnErrors = _txnErrors;

                    return _MtrOpenPolicyMdl;
                }

                else if (IsPostedTMtrOpenPolicy(_MtrOpenPolicyMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _MtrOpenPolicyMdl.IsValidTxn = false;

                    _txnError.ErrorCode = "1005";
                    _txnError.Error = "Policy is Already Posted";
                    _txnError.TxnSysDate = DateTime.Now;


                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError);

                    //For creating Log file
                    // string _logFileName = CreateLog(_txnErrors, "Master Product SetUp");
                    //  Process.Start("notepad.exe", _logFileName);

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
                    _MtrOpenPolicyMdl.TxnErrors = _txnErrors;
                    return _MtrOpenPolicyMdl;
                }

                else
                {
                    return null;
                }




            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }

        }

        //for checking that policy created by and posted by are same for validation of Open Policy posting
        public bool IsPostedMtrOpenPolicy(MtrOpenPolicyMdl _MtrOpenPolicyMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  MtrOpenPolicy  WHERE   TxnSysID = '" + _MtrOpenPolicyMdl.TxnSysID
                    + "' AND CreatedBy = '" + _MtrOpenPolicyMdl.PostedBy.ToString()+"'";

                    
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<MtrOpenPolicyMdl> _MtrOpenPolicyMdlList = new List<MtrOpenPolicyMdl>();
                //  MtrOpenPolicyMdl _MtrOpenPolicyMdl;
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return true;
            }
        }

        //for checking that policy is already Posted for validation of Open Policy posting
        public bool IsPostedTMtrOpenPolicy(MtrOpenPolicyMdl _MtrOpenPolicyMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  MtrOpenPolicy  WHERE   TxnSysID = '" + _MtrOpenPolicyMdl.TxnSysID
                    + "' AND IsPosted = 1";


                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<MtrOpenPolicyMdl> _MtrOpenPolicyMdlList = new List<MtrOpenPolicyMdl>();
                //  MtrOpenPolicyMdl _MtrOpenPolicyMdl;
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return true;
            }
        }

        //for checking that policy is expired for validation of Open Policy posting
        public bool IsExpiredMtrOpenPolicy(MtrOpenPolicyMdl _MtrOpenPolicyMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  MtrOpenPolicy  WHERE   TxnSysID = '" + _MtrOpenPolicyMdl.TxnSysID
                    + "' AND ExpiryDate <= '" + DateTime.Now +"'";



                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<MtrOpenPolicyMdl> _MtrOpenPolicyMdlList = new List<MtrOpenPolicyMdl>();
                //  MtrOpenPolicyMdl _MtrOpenPolicyMdl;
                DuplicationCheck _duplicationCheck = new DuplicationCheck();

                // SqlCommand cmd = new SqlCommand(_sqlString,_conSql);
                // int count = (int)cmd.ExecuteScalar();

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                // if(count > 0)
                {
                    _MtrOpenPolicyMdl.IsExpired = true;
                    return true;
                   
                }
                else
                {
                    _MtrOpenPolicyMdl.IsExpired = false;
                    return false;
                    
                }


            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return true;
            }
        }

        //Get new Policy No
        private string GettingNewPolicyNo(MtrOpenPolicyMdl _MtrOpenPolicyMdl)
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

        //-------------------- CRUD Ends From Here ------------------------//

        //for getting all Document Type(1 or 2)
        public List<MtrDocumentTypeMdl> GetDocumentType()
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //for getting all Is Auto (7 or 8)
        public List<MtrIsAutoMdl> GetIsAuto()
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //for getting all Calculation Types (5 or 6)
        public List<MtrCalcTypeMdl> GetCalcType()
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //for getting all IsFiler(3 or 4)
        public List<MtrIsFilerMdl> GetIsFiler()
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //for getting all Product Clients by Client Code (25 or 26)
        public List<ProductClientMdl> GetClientByCode(ProductClientMdl _ProductClientMdl1)
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //Get Values from Product Setup On selection of Product Code
        public MasterProductSetupMdl GetMasterProductSetUpByProductCode(MasterProductSetupMdl _MasterProductSetupMdl)
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
                        _MasterProductSetupMdl.AgentCommPct = Convert.ToDecimal(_tblSqla.Rows[i]["AgentCommPct"]); 
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //For Creation of Policy String
        public string GetPolicyString(string _BranchCode, int _InsuranceTypeCode, string _DocType, string _PolicyTypeCode, string _PolicyNo, int _SerialNo, int _ProductCode, string _PolicyMonth, string _PolicyYear)
      //  public string GetPolicyString(string _BranchCode,string _PolicyNo ,int _SerialNo,string _PolicyTypeCode,string _ProductCode, string _PolicyMonth,string _PolicyYear)
        {
            string PolicyString = _BranchCode + "-" + _InsuranceTypeCode + "-2-" + _DocType + "-000" + _PolicyTypeCode +"-" + _PolicyNo + "-0" + _SerialNo + "-" + _PolicyMonth + "-" + _PolicyYear;
            return PolicyString;
        }

        //For Increment of Serial Numbers
        public int GetSerialNo(MtrOpenPolicyMdl _MtrOpenPolicyMdl)
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
                return 0;
            }

        }

        //for getting product code from master product Setup 
        public List<MasterProductSetupMdl> GetProductCodeOfMasterProductSetUp()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT ProductCode,ProductName,PolicyTypeCode FROM MasterProductSetup WHERE IsClientBased = 'Yes'";
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
              
                        _MasterProductSetupMdl.ProductCode = Convert.ToInt32(_tbl.Rows[i]["ProductCode"]);
                        _MasterProductSetupMdl.ProductName = _tbl.Rows[i]["ProductName"].ToString();
                        _MasterProductSetupMdl.PolicyTypeCode = _tbl.Rows[i]["PolicyTypeCode"].ToString();



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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //getting all Certificate Insurance Code 
        public List<MtrCertificateInsuranceMdl> GetAllCertInsureCode()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrCertificateInsurance";
                  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrCertificateInsuranceMdl> _MtrCertificateInsuranceMdlList = new List<MtrCertificateInsuranceMdl>();
                MtrCertificateInsuranceMdl _MtrCertificateInsuranceMdl ;

               

                 _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrCertificateInsuranceMdl = new MtrCertificateInsuranceMdl();

                        _MtrCertificateInsuranceMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrCertificateInsuranceMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrCertificateInsuranceMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();
                        _MtrCertificateInsuranceMdl.CertInsureCode = _tblSqla.Rows[i]["CertInsureCode"].ToString();
                        _MtrCertificateInsuranceMdl.CertInsureName = _tblSqla.Rows[i]["CertInsureName"].ToString();

                        _MtrCertificateInsuranceMdlList.Add(_MtrCertificateInsuranceMdl);


                    }

                    return  _MtrCertificateInsuranceMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }
        
        //Getting Product Name By Code
        public string GetProductNameByProductCode(string _ProductCode)
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //Getting Policy Type Name By Code (100 or 101)
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //Getting Agent Name By Code (20 or 21)
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //Getting Certificate Insurance Name By Code
        public string GetCertInsNameByCertInsCode(string _CertInsureCode)
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //Getting Doc Type Name By Code (1 or 2)
        public string GetDocTypeNameByDocTypeCode(string _DocTypeCode)
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //Getting IsFiler Name By Code (3 or 4)
        public string GetIsFilerNameByIsFilerCode(string _IsFilerCode)
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //Getting Calc Name By Code (5 or 6)
        public string GetCalcNameByCalcCode(string _CalcCode)
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //Getting IsAuto Name By Code (7 or 8)
        public string GetIsAutoNameByIsAutoCode(string _IsAutoCode)
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //Getting Certificate Insurance Code by Policy Type Code
        public ProductPolicyTypeMdl GetCertInsureCode(ProductPolicyTypeMdl _ProductPolicyTypeMdl1)
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //Getting Policy Class Name By Code
        public string GetPolicyClassNameByCode(string _PolicyClassCode)
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //Getting Insurance Type Name By Code
        public string GetInsuranceTypeNameByCode(int _INSURANCE_TYPE_CODE)
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

        //Get All Insurance Type
        public List<InsuranceTypeMdl> GetInsType()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM InsuranceType";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<InsuranceTypeMdl> _InsuranceTypeMdlList = new List<InsuranceTypeMdl>();
                InsuranceTypeMdl _InsuranceTypeMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _InsuranceTypeMdl = new InsuranceTypeMdl();

                        _InsuranceTypeMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _InsuranceTypeMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _InsuranceTypeMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _InsuranceTypeMdl.INSURANCE_TYPE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["INSURANCE_TYPE_CODE"]);
                        _InsuranceTypeMdl.INSURANCE_TYPE_TITLE = _tblSqla.Rows[i]["INSURANCE_TYPE_TITLE"].ToString();



                        _InsuranceTypeMdlList.Add(_InsuranceTypeMdl);


                    }

                    return _InsuranceTypeMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Open Policy DataLayer");
                return null;
            }
        }

    }
}