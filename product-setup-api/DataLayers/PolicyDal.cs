using ProductSetupApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using static ProductSetupApi.Models.InsPolicyMdl;
using static ProductSetupApi.Models.MtrEndorsementMdl;
using static ProductSetupApi.Models.MtrPolicy;
using static ProductSetupApi.Models.MtrVehicleDetailMdl;
using static ProductSetupApi.Models.OpenPolicyMdl;

namespace ProductSetupApi.DataLayers
{
    public class PolicyDal
    {

        //for getting all Policy
        public List<MtrPolicyMdl> GetMtrOpenPolicy()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrOpenPolicy WHERE DocType = 4";
                //+ " WHERE  FORMAT(TxnSysDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + 
                // "AND FORMAT(EffectiveDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + "AND FORMAT(ExpiryDate, 'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(), 'yyyy-MM-dd'))";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrPolicyMdl> _MtrPolicyMdlList = new List<MtrPolicyMdl>();
                MtrPolicyMdl _MtrPolicyMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrPolicyMdl = new MtrPolicyMdl();

                        _MtrPolicyMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrPolicyMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]).Date;
                        _MtrPolicyMdl.PolicyMonth = _tblSqla.Rows[i]["PolicyMonth"].ToString();
                        _MtrPolicyMdl.InsuranceTypeCode = Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]);


                        _MtrPolicyMdl.PolicyString = GetPolicyString(
                         _tblSqla.Rows[i]["BrchCoverNoteNo"].ToString(),
                           Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]),
                           _tblSqla.Rows[i]["DocType"].ToString(),
                           _tblSqla.Rows[i]["PolicyTypeCode"].ToString(),
                            _tblSqla.Rows[i]["PolicyNo"].ToString(),
                            Convert.ToInt32(_tblSqla.Rows[i]["SerialNo"]),
                             Convert.ToInt32(_tblSqla.Rows[i]["ProductCode"]),
                        _tblSqla.Rows[i]["PolicyMonth"].ToString(),
                            _tblSqla.Rows[i]["PolicyYear"].ToString());


                        _MtrPolicyMdl.PolicyYear = _tblSqla.Rows[i]["PolicyYear"].ToString();
                        _MtrPolicyMdl.PolicyNo = _tblSqla.Rows[i]["PolicyNo"].ToString();
                        _MtrPolicyMdl.DocType = _tblSqla.Rows[i]["DocType"].ToString();
                        _MtrPolicyMdl.GenerateAgainst = _tblSqla.Rows[i]["GenerateAgainst"].ToString();
                        _MtrPolicyMdl.ProductCode = Convert.ToInt32(_tblSqla.Rows[i]["ProductCode"]);
                        _MtrPolicyMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();
                        _MtrPolicyMdl.ClientCode = _tblSqla.Rows[i]["ClientCode"].ToString();
                        _MtrPolicyMdl.AgencyCode = _tblSqla.Rows[i]["AgencyCode"].ToString();
                        _MtrPolicyMdl.CertInsureCode = _tblSqla.Rows[i]["CertInsureCode"].ToString();

                        // _MtrOpenPolicyMdl.ClientName = _tblSqla.Rows[i]["ClientName"].ToString();
                        // _MtrOpenPolicyMdl.ClientAddress = _tblSqla.Rows[i]["ClientAddress"].ToString();
                        // _MtrOpenPolicyMdl.ConditionCode = _tblSqla.Rows[i]["ConditionCode"].ToString();
                        // _MtrOpenPolicyMdl.WarrantyCode = _tblSqla.Rows[i]["WarrantyCode"].ToString();

                        _MtrPolicyMdl.Remarks = _tblSqla.Rows[i]["Remarks"].ToString();
                        _MtrPolicyMdl.BrchCoverNoteNo = _tblSqla.Rows[i]["BrchCoverNoteNo"].ToString();
                        _MtrPolicyMdl.LeaderPolicyNo = _tblSqla.Rows[i]["LeaderPolicyNo"].ToString();
                        _MtrPolicyMdl.LeaderEndNo = _tblSqla.Rows[i]["LeaderEndNo"].ToString();
                        _MtrPolicyMdl.IsFiler = _tblSqla.Rows[i]["IsFiler"].ToString();
                        _MtrPolicyMdl.CalcType = _tblSqla.Rows[i]["CalcType"].ToString();
                        _MtrPolicyMdl.IsAuto = _tblSqla.Rows[i]["IsAuto"].ToString();
                        _MtrPolicyMdl.SerialNo = Convert.ToInt32(_tblSqla.Rows[i]["SerialNo"].ToString());
                        _MtrPolicyMdl.UWYear = _tblSqla.Rows[i]["UWYear"].ToString();
                        _MtrPolicyMdl.CreatedBy = _tblSqla.Rows[i]["CreatedBy"].ToString();
                        _MtrPolicyMdl.PostedBy = _tblSqla.Rows[i]["PostedBy"].ToString();
                        _MtrPolicyMdl.IsPosted = Boolean.Parse(_tblSqla.Rows[i]["IsPosted"].ToString());
                        _MtrPolicyMdl.PostDate = Convert.ToDateTime(_tblSqla.Rows[i]["PostDate"]);


                        _MtrPolicyMdl.EffectiveDate = Convert.ToDateTime(_tblSqla.Rows[i]["EffectiveDate"]).Date;
                        _MtrPolicyMdl.ExpiryDate = Convert.ToDateTime(_tblSqla.Rows[i]["ExpiryDate"].ToString()).Date;
                        _MtrPolicyMdl.CommisionRate = Convert.ToDecimal(_tblSqla.Rows[i]["CommisionRate"]);


                        _MtrPolicyMdl.IsValidTxn = true;


                        _MtrPolicyMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(_tblSqla.Rows[i]["ProductCode"].ToString());
                        _MtrPolicyMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_tblSqla.Rows[i]["PolicyTypeCode"].ToString());
                        _MtrPolicyMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_tblSqla.Rows[i]["ClientCode"].ToString());
                        _MtrPolicyMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_tblSqla.Rows[i]["AgencyCode"].ToString());
                        _MtrPolicyMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_tblSqla.Rows[i]["CertInsureCode"].ToString());

                        _MtrPolicyMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(_tblSqla.Rows[i]["DocType"].ToString());
                        _MtrPolicyMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_tblSqla.Rows[i]["IsFiler"].ToString());
                        _MtrPolicyMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_tblSqla.Rows[i]["CalcType"].ToString());
                        _MtrPolicyMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_tblSqla.Rows[i]["IsAuto"].ToString());
                        _MtrPolicyMdl.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]));



                        string OpenPolicyDoc = "4";
                        _MtrPolicyMdl.DocType = OpenPolicyDoc;

                        _MtrPolicyMdlList.Add(_MtrPolicyMdl);


                    }

                    return _MtrPolicyMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }

        //for adding new Policy
        public MtrPolicyMdl AddMtrPolicy(MtrPolicyMdl _MtrPolicyMdl)
        {
            try

            {

                _MtrPolicyMdl.SerialNo = _MtrPolicyMdl.SerialNo == 0 ? _MtrPolicyMdl.SerialNo++ : _MtrPolicyMdl.SerialNo++;

                if (IsDuplicateMtrPolicy(_MtrPolicyMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _MtrPolicyMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1001";
                    _txnError.Error = "Duplicate Transaction";
                    _txnError.TxnSysDate = DateTime.Now;

                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError);

                    //To Return model
                    _MtrPolicyMdl.TxnErrors = _txnErrors;


                    _MtrPolicyMdl.TxnSysDate = DateTime.Now;

                    return _MtrPolicyMdl;

                }

                else
                {


                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;
                    int _SerialNumber = GetSerialNo(_MtrPolicyMdl);


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


                    string OpenPolicyDoc1 = "04";

                    string PolicyString = GetPolicyString(
                         _MtrPolicyMdl.BrchCoverNoteNo, _MtrPolicyMdl.InsuranceTypeCode, OpenPolicyDoc1,
                         _MtrPolicyMdl.PolicyTypeCode,
                         _MtrPolicyMdl.PolicyNo,
                         _SerialNumber,
                          _MtrPolicyMdl.ProductCode,
                        DateTime.Now.Month.ToString(),
                            DateTime.Now.Year.ToString());



                    _cmdSql.Parameters.AddWithValue("@PolicyString", PolicyString);

                    _cmdSql.Parameters.AddWithValue("@PolicyYear", DateTime.Now.Year.ToString());


                    //_cmdSql.Parameters.AddWithValue("@PolicyYear", _MtrOpenPolicyMdl.PolicyYear);



                    //  _cmdSql.Parameters.AddWithValue("@PolicyNo", _MtrOpenPolicyMdl.PolicyNo);
                    _cmdSql.Parameters.AddWithValue("@PolicyNo", GettingNewPolicyNo(_MtrPolicyMdl));

                    string OpenPolicyDoc = "4";

                    _cmdSql.Parameters.AddWithValue("@DocType", OpenPolicyDoc);
                    _cmdSql.Parameters.AddWithValue("@GenerateAgainst", GettingNewPolicyNo(_MtrPolicyMdl));
                    _cmdSql.Parameters.AddWithValue("@ProductCode", _MtrPolicyMdl.ProductCode);
                    _cmdSql.Parameters.AddWithValue("@PolicyTypeCode", _MtrPolicyMdl.PolicyTypeCode);
                    _cmdSql.Parameters.AddWithValue("@ClientCode", _MtrPolicyMdl.ClientCode);
                    _cmdSql.Parameters.AddWithValue("@AgencyCode", _MtrPolicyMdl.AgencyCode);
                    _cmdSql.Parameters.AddWithValue("@CertInsureCode", _MtrPolicyMdl.CertInsureCode);
                    // _cmdSql.Parameters.AddWithValue("@ClientName", _MtrOpenPolicyMdl.ClientName);
                    //   _cmdSql.Parameters.AddWithValue("@ClientAddress", _MtrOpenPolicyMdl.ClientAddress);
                    //  _cmdSql.Parameters.AddWithValue("@ConditionCode", _MtrOpenPolicyMdl.ConditionCode);
                    //  _cmdSql.Parameters.AddWithValue("@WarrantyCode", _MtrOpenPolicyMdl.WarrantyCode);
                    _cmdSql.Parameters.AddWithValue("@Remarks", _MtrPolicyMdl.Remarks ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@BrchCoverNoteNo", _MtrPolicyMdl.BrchCoverNoteNo);
                    _cmdSql.Parameters.AddWithValue("@LeaderPolicyNo", _MtrPolicyMdl.LeaderPolicyNo ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@LeaderEndNo", _MtrPolicyMdl.LeaderEndNo ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@IsFiler", _MtrPolicyMdl.IsFiler);
                    _cmdSql.Parameters.AddWithValue("@CalcType", _MtrPolicyMdl.CalcType);
                    _cmdSql.Parameters.AddWithValue("@IsAuto", _MtrPolicyMdl.IsAuto);
                    _cmdSql.Parameters.AddWithValue("@EffectiveDate", Convert.ToDateTime(_MtrPolicyMdl.EffectiveDate.ToString()));
                    _cmdSql.Parameters.AddWithValue("@ExpiryDate", Convert.ToDateTime(_MtrPolicyMdl.ExpiryDate.ToString()));
                    _cmdSql.Parameters.AddWithValue("@SerialNo", _SerialNumber);
                    _cmdSql.Parameters.AddWithValue("@InsuranceTypeCode", _MtrPolicyMdl.InsuranceTypeCode);


                    _cmdSql.Parameters.AddWithValue("@UWYear", DateTime.Now.Year.ToString());
                    // _cmdSql.Parameters.AddWithValue("@UWYear", _MtrOpenPolicyMdl.UWYear);


                    _cmdSql.Parameters.AddWithValue("@CommisionRate", _MtrPolicyMdl.CommisionRate);

                    _cmdSql.Parameters.AddWithValue("@CreatedBy", _MtrPolicyMdl.CreatedBy);


                    _MtrPolicyMdl.PolicyString = PolicyString;
                    _MtrPolicyMdl.SerialNo = _SerialNumber;
                    _MtrPolicyMdl.TxnSysDate = DateTime.Now;


                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();
                    _MtrPolicyMdl.IsValidTxn = true;

                    _MtrPolicyMdl.TxnSysID = _TxnSysId;

                    _MtrPolicyMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(_MtrPolicyMdl.ProductCode.ToString());
                    _MtrPolicyMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_MtrPolicyMdl.PolicyTypeCode.ToString());
                    _MtrPolicyMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_MtrPolicyMdl.ClientCode.ToString());
                    _MtrPolicyMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_MtrPolicyMdl.AgencyCode.ToString());
                    _MtrPolicyMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_MtrPolicyMdl.CertInsureCode.ToString());

                    _MtrPolicyMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(OpenPolicyDoc);
                    _MtrPolicyMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_MtrPolicyMdl.IsFiler.ToString());
                    _MtrPolicyMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_MtrPolicyMdl.CalcType.ToString());
                    _MtrPolicyMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_MtrPolicyMdl.IsAuto.ToString());
                    _MtrPolicyMdl.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(_MtrPolicyMdl.InsuranceTypeCode);


                    _MtrPolicyMdl.DocType = OpenPolicyDoc1;

                    return _MtrPolicyMdl;
                }
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }

        }


        //for updating existing Policy
        public MtrPolicyMdl UpdateMtrPolicy(MtrPolicyMdl _MtrPolicyMdl)
        {
            try
            {

                _MtrPolicyMdl.SerialNo = _MtrPolicyMdl.SerialNo == 0 ? _MtrPolicyMdl.SerialNo += 1 : _MtrPolicyMdl.SerialNo;

               // if (IsDuplicateMtrPolicy(_MtrPolicyMdl) == false && IsExpiredMtrPolicy(_MtrPolicyMdl) == false)
                if (IsExpiredMtrPolicy(_MtrPolicyMdl) == false)
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




                    _cmdSql.Parameters.AddWithValue("@TxnSysID", _MtrPolicyMdl.TxnSysID);


                    DateTime da = DateTime.Now;
                    da.ToString("MM-dd-yyyy h:mm tt");
                    string OpenPolicyDoc = "04";

                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);

                    int _SerialNumber = GetSerialNo(_MtrPolicyMdl);

                    _cmdSql.Parameters.AddWithValue("@PolicyMonth", DateTime.Now.Month.ToString());

                    string PolicyString = GetPolicyString(
                         _MtrPolicyMdl.BrchCoverNoteNo, _MtrPolicyMdl.InsuranceTypeCode, OpenPolicyDoc,
                         _MtrPolicyMdl.PolicyTypeCode,
                          _MtrPolicyMdl.PolicyNo,
                         _MtrPolicyMdl.SerialNo,
                          _MtrPolicyMdl.ProductCode,
                        DateTime.Now.Month.ToString(),
                            DateTime.Now.Year.ToString());

                    _cmdSql.Parameters.AddWithValue("@PolicyString", PolicyString);

                    _cmdSql.Parameters.AddWithValue("@PolicyYear", DateTime.Now.Year.ToString());

                    //  _cmdSql.Parameters.AddWithValue("@PolicyNo", GettingNewPolicyNo(_MtrOpenPolicyMdl));



                    _cmdSql.Parameters.AddWithValue("@DocType", OpenPolicyDoc);

                    string str = "abc";
                    _cmdSql.Parameters.AddWithValue("@GenerateAgainst", GettingNewPolicyNo(_MtrPolicyMdl));

                    _cmdSql.Parameters.AddWithValue("@ProductCode", _MtrPolicyMdl.ProductCode);
                    _cmdSql.Parameters.AddWithValue("@PolicyTypeCode", _MtrPolicyMdl.PolicyTypeCode);
                    _cmdSql.Parameters.AddWithValue("@ClientCode", _MtrPolicyMdl.ClientCode);
                    _cmdSql.Parameters.AddWithValue("@AgencyCode", _MtrPolicyMdl.AgencyCode);
                    _cmdSql.Parameters.AddWithValue("@CertInsureCode", _MtrPolicyMdl.CertInsureCode);



                    _cmdSql.Parameters.AddWithValue("@Remarks", _MtrPolicyMdl.Remarks ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@BrchCoverNoteNo", _MtrPolicyMdl.BrchCoverNoteNo);
                    _cmdSql.Parameters.AddWithValue("@LeaderPolicyNo", _MtrPolicyMdl.LeaderPolicyNo ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@LeaderEndNo", _MtrPolicyMdl.LeaderEndNo ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@IsFiler", _MtrPolicyMdl.IsFiler);
                    _cmdSql.Parameters.AddWithValue("@CalcType", _MtrPolicyMdl.CalcType);
                    _cmdSql.Parameters.AddWithValue("@IsAuto", _MtrPolicyMdl.IsAuto);

                    _cmdSql.Parameters.AddWithValue("@EffectiveDate", Convert.ToDateTime(_MtrPolicyMdl.EffectiveDate.ToString()));
                    _cmdSql.Parameters.AddWithValue("@ExpiryDate", Convert.ToDateTime(_MtrPolicyMdl.ExpiryDate.ToString()));

                    // _cmdSql.Parameters.AddWithValue("@SerialNo", _MtrOpenPolicyMdl.SerialNo);
                    _cmdSql.Parameters.AddWithValue("@UWYear", DateTime.Now.Year.ToString());
                    _cmdSql.Parameters.AddWithValue("@InsuranceTypeCode", _MtrPolicyMdl.InsuranceTypeCode);

                    _cmdSql.Parameters.AddWithValue("@CommisionRate", _MtrPolicyMdl.CommisionRate);


                    _MtrPolicyMdl.IsValidTxn = true;


                    _MtrPolicyMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(_MtrPolicyMdl.ProductCode.ToString());
                    _MtrPolicyMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_MtrPolicyMdl.PolicyTypeCode.ToString());
                    _MtrPolicyMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_MtrPolicyMdl.ClientCode.ToString());
                    _MtrPolicyMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_MtrPolicyMdl.AgencyCode.ToString());
                    _MtrPolicyMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_MtrPolicyMdl.CertInsureCode.ToString());

                    _MtrPolicyMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(OpenPolicyDoc);
                    _MtrPolicyMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_MtrPolicyMdl.IsFiler.ToString());
                    _MtrPolicyMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_MtrPolicyMdl.CalcType.ToString());
                    _MtrPolicyMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_MtrPolicyMdl.IsAuto.ToString());
                    _MtrPolicyMdl.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(_MtrPolicyMdl.InsuranceTypeCode);
                    _MtrPolicyMdl.TxnSysDate = DateTime.Now;


                    _MtrPolicyMdl.PolicyString = PolicyString;

                    string OpenPolicyDoc1 = "4";
                    _MtrPolicyMdl.DocType = OpenPolicyDoc1;

                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    return _MtrPolicyMdl;

                }

                //else if (IsDuplicateMtrPolicy(_MtrPolicyMdl) == true)
                //{

                //    List<TxnError> _txnErrors = new List<TxnError>();
                //    TxnError _txnError = new TxnError();
                //    _MtrPolicyMdl.IsValidTxn = false;
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


                //    //To Return model
                //    _MtrPolicyMdl.TxnErrors = _txnErrors;



                //    _MtrPolicyMdl.TxnSysDate = DateTime.Now;



                //    return _MtrPolicyMdl;
                //}

                else if (IsExpiredMtrPolicy(_MtrPolicyMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _MtrPolicyMdl.IsValidTxn = false;
                    //_MtrOpenPolicyMdl.IsExpired = true;
                    _txnError.ErrorCode = "1004";
                    _txnError.Error = "Policy Has been Expired";
                    _txnError.TxnSysDate = DateTime.Now;


                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError);

              
                    //To Return model
                    _MtrPolicyMdl.TxnErrors = _txnErrors;


                    _MtrPolicyMdl.TxnSysDate = DateTime.Now;

                    return _MtrPolicyMdl;
                }

                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }

        //for checking duplicate Policy
        public bool IsDuplicateMtrPolicy(MtrPolicyMdl _MtrPolicyMdl)

        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  MtrOpenPolicy  WHERE   PolicyYear = '" + DateTime.Now.Year.ToString()
                    + "' AND PolicyTypeCode= '" + _MtrPolicyMdl.PolicyTypeCode.ToString() + "' AND ClientCode = '" + _MtrPolicyMdl.ClientCode.ToString() + "'AND ProductCode = " + _MtrPolicyMdl.ProductCode;


                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<MtrPolicyMdl> _MtrPolicyMdlList = new List<MtrPolicyMdl>();

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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return true;
            }
        }

        //For Posting the Policy
        public MtrPolicyMdl PostMtrPolicy(MtrPolicyMdl _MtrPolicyMdl)
        {
            try

            {

                if ((IsPostedMtrPolicy(_MtrPolicyMdl) == false) && (IsExpiredMtrPolicy(_MtrPolicyMdl) == false) && (IsPostedTMtrPolicy(_MtrPolicyMdl) == false))

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



                    _cmdSql.Parameters.AddWithValue("@TxnSysID", _MtrPolicyMdl.TxnSysID);







                    _MtrPolicyMdl.IsPosted = true;


                    _cmdSql.Parameters.AddWithValue("@PostedBy", _MtrPolicyMdl.PostedBy);
                    _cmdSql.Parameters.AddWithValue("@PostDate", DateTime.Now);

                    int t = 1;

                    _cmdSql.Parameters.AddWithValue("@IsPosted", true);


                    _MtrPolicyMdl.IsValidTxn = true;




                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    return _MtrPolicyMdl;

                }

                else if (IsPostedMtrPolicy(_MtrPolicyMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _MtrPolicyMdl.IsValidTxn = false;

                    _txnError.ErrorCode = "1003";
                    _txnError.Error = "Policy is Created by and Posted by same person";
                    _txnError.TxnSysDate = DateTime.Now;


                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError);

                  

                    //To Return model
                    _MtrPolicyMdl.TxnErrors = _txnErrors;
                    return _MtrPolicyMdl;
                }

                else if (IsExpiredMtrPolicy(_MtrPolicyMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _MtrPolicyMdl.IsValidTxn = false;
                    //_MtrOpenPolicyMdl.IsExpired = true;
                    _txnError.ErrorCode = "1004";
                    _txnError.Error = "Policy Has been Expired";
                    _txnError.TxnSysDate = DateTime.Now;


                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError);

                    
                    //To Return model
                    _MtrPolicyMdl.TxnErrors = _txnErrors;

                    return _MtrPolicyMdl;
                }

                else if (IsPostedMtrPolicy(_MtrPolicyMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _MtrPolicyMdl.IsValidTxn = false;

                    _txnError.ErrorCode = "1005";
                    _txnError.Error = "Policy is Already Posted";
                    _txnError.TxnSysDate = DateTime.Now;


                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError);

                    

                    //To Return model
                    _MtrPolicyMdl.TxnErrors = _txnErrors;
                    return _MtrPolicyMdl;
                }

                else
                {
                    return null;
                }




            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }

        }

        //for checking that policy created by and posted by are same for validation of Open Policy posting
        public bool IsPostedMtrPolicy(MtrPolicyMdl _MtrPolicyMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  MtrOpenPolicy  WHERE   TxnSysID = '" + _MtrPolicyMdl.TxnSysID
                    + "' AND CreatedBy = '" + _MtrPolicyMdl.PostedBy.ToString() + "'";


                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<MtrPolicyMdl> _MtrPolicyMdlList = new List<MtrPolicyMdl>();
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return true;
            }
        }

        //for checking that policy is already Posted for validation of Open Policy posting
        public bool IsPostedTMtrPolicy(MtrPolicyMdl _MtrPolicyMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  MtrOpenPolicy  WHERE   TxnSysID = '" + _MtrPolicyMdl.TxnSysID
                    + "' AND IsPosted = 1";


                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
               // List<MtrOpenPolicyMdl> _MtrOpenPolicyMdlList = new List<MtrOpenPolicyMdl>();
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return true;
            }
        }

        //for checking that policy is expired for validation of Open Policy posting
        public bool IsExpiredMtrPolicy(MtrPolicyMdl _MtrPolicyMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  MtrOpenPolicy  WHERE   TxnSysID = '" + _MtrPolicyMdl.TxnSysID
                    + "' AND ExpiryDate <= '" + DateTime.Now + "'";



                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<MtrPolicyMdl> _MtrPolicyMdlList = new List<MtrPolicyMdl>();
                //  MtrOpenPolicyMdl _MtrOpenPolicyMdl;
                DuplicationCheck _duplicationCheck = new DuplicationCheck();

                // SqlCommand cmd = new SqlCommand(_sqlString,_conSql);
                // int count = (int)cmd.ExecuteScalar();

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                // if(count > 0)
                {
                    _MtrPolicyMdl.IsExpired = true;
                    return true;

                }
                else
                {
                    _MtrPolicyMdl.IsExpired = false;
                    return false;

                }


            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return true;
            }
        }

        //Get new Policy No
        private string GettingNewPolicyNo(MtrPolicyMdl _MtrPolicyMdl)
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


        //For Creation of Policy String
        public string GetPolicyString(string _BranchCode, int _InsuranceTypeCode, string _DocType, string _PolicyTypeCode, string _PolicyNo, int _SerialNo, int _ProductCode, string _PolicyMonth, string _PolicyYear)
      
        {
            string PolicyString = _BranchCode + "-" + _InsuranceTypeCode + "-2-" + _DocType + "-000" + _PolicyTypeCode + "-" + _PolicyNo + "-0" + _SerialNo + "-" + _PolicyMonth + "-" + _PolicyYear;
            return PolicyString;
        }

        //For Increment of Serial Numbers
        public int GetSerialNo(MtrPolicyMdl _MtrPolicyMdl)
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


        //Get Values from Product Setup On selection of Product Code
        public MasterProductSetupMdl GetMasterProductSetUpByProductCodeForPol(MasterProductSetupMdl _MasterProductSetupMdl)
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
                        new SqlCommand("SELECT mps.TxnSysID, pcps.PrdStpTxnSysId, prfps.RatingFactor, prfps.Rate,prfps.IsEditable,mps.ProductCode,mps.ProductName,mps.IsClientBased,mps.Client,mps.Agent, mps.AgentCommPct,mps.PolicyTypeCode,pcps.Condition,pwps.Warranty,Pts.TrackerName,pts.TrackerCode,pts.TrackerRate, mps.AgentCommPct FROM MasterProductSetup mps INNER JOIN ProductRatingFactorsProductSetup prfps ON mps.TxnSysID = prfps.PrdStpTxnSysId INNER JOIN ProductConditionsProductSetup pcps ON  mps.TxnSysID = pcps.PrdStpTxnSysId INNER JOIN ProductWarrantiesProductSetup pwps ON mps.TxnSysID = pwps.PrdStpTxnSysId INNER JOIN ProductTrackerSetup pts ON mps.TxnSysID = pts.PrdStpTxnSysId  WHERE mps.ProductCode = @ProductCode", conn);

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
                       // _MasterProductSetupMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        //_MasterProductSetupMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MasterProductSetupMdl.ProductCode = Convert.ToInt32(_tblSqla.Rows[i]["ProductCode"]);
                        _MasterProductSetupMdl.ProductName = _tblSqla.Rows[i]["ProductName"].ToString();
                        _MasterProductSetupMdl.IsClientBased = _tblSqla.Rows[i]["IsClientBased"].ToString();
                        _MasterProductSetupMdl.Client = _tblSqla.Rows[i]["Client"].ToString();
                        _MasterProductSetupMdl.Agent = _tblSqla.Rows[i]["Agent"].ToString();
                        _MasterProductSetupMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();
                        _MasterProductSetupMdl.AgentCommPct = Convert.ToDecimal(_tblSqla.Rows[i]["AgentCommPct"].ToString());


                        //For Rating
                        _MasterProductSetupMdl.RatingFactor = _tblSqla.Rows[i]["RatingFactor"].ToString();
                        _MasterProductSetupMdl.Rate = Convert.ToDecimal(_tblSqla.Rows[i]["Rate"]);
                        _MasterProductSetupMdl.IsEditable = _tblSqla.Rows[i]["IsEditable"].ToString();
                        _MasterProductSetupMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_tblSqla.Rows[i]["RatingFactor"].ToString());

                        //For Condition
                        _MasterProductSetupMdl.Condition = _tblSqla.Rows[i]["Condition"].ToString();
                        _MasterProductSetupMdl.ConditionShText = GlobalDataLayer.GetConditionByCode(_tblSqla.Rows[i]["Condition"].ToString());

                        //For Warranty
                        _MasterProductSetupMdl.Warranty = _tblSqla.Rows[i]["Warranty"].ToString();
                        _MasterProductSetupMdl.WarrantyShText = GlobalDataLayer.GetWarrantyTextByCode(_tblSqla.Rows[i]["Warranty"].ToString());

                        //For Tracker
                        _MasterProductSetupMdl.TrackerCode = Convert.ToInt32(_tblSqla.Rows[i]["TrackerCode"]);
                        _MasterProductSetupMdl.TrackerName = _tblSqla.Rows[i]["TrackerName"].ToString();
                        _MasterProductSetupMdl.TrackerRate = Convert.ToInt32(_tblSqla.Rows[i]["TrackerRate"]);

                        //Get Name By Code
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }

        //Get Products By Client Code
        public List<MasterProductSetupMdl> ProductCodeByClient(MasterProductSetupMdl _MasterProductSetupMdl1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //string _sqlString = "SELECT * FROM MtrDistrict ";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();

                MasterProductSetupMdl _MasterProductSetupMdl = new MasterProductSetupMdl();
                List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT mps.ProductCode,mps.ProductName FROM MasterProductSetup mps WHERE mps.IsClientBased = 'No' AND mps.Client = @Client", conn);

                    command.Parameters.Add(new SqlParameter("@Client", _MasterProductSetupMdl1.Client));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                // _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MasterProductSetupMdl = new MasterProductSetupMdl();

                        _MasterProductSetupMdl.ProductCode = Convert.ToInt32(_tblSqla.Rows[i]["ProductCode"].ToString());
                        _MasterProductSetupMdl.ProductName = _tblSqla.Rows[i]["ProductName"].ToString();
                        

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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }

        }


        //for getting all Open Policy by Client Code  For Policy
        public MtrOpenPolicyMdl GetOpolicytByClientForPol(ProductClientMdl _ProductClientMdl1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT * FROM ClientProductSetup WHERE ClientCode=" ;
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrOpenPolicyMdl> _MtrOpenPolicyMdlList = new List<MtrOpenPolicyMdl>();
                MtrOpenPolicyMdl _MtrOpenPolicyMdl = new MtrOpenPolicyMdl();


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM MtrOpenPolicy WHERE ClientCode = @ClientCode", conn);

                    command.Parameters.Add(new SqlParameter("@ClientCode", _ProductClientMdl1.ClientCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


                // _adpSql.Fill(_tbl);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrOpenPolicyMdl = new MtrOpenPolicyMdl();

                        _MtrOpenPolicyMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrOpenPolicyMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrOpenPolicyMdl.PolicyMonth = _tblSqla.Rows[i]["PolicyMonth"].ToString();
                        _MtrOpenPolicyMdl.PolicyString = _tblSqla.Rows[i]["PolicyString"].ToString();
                        _MtrOpenPolicyMdl.PolicyYear = _tblSqla.Rows[i]["PolicyYear"].ToString();
                        _MtrOpenPolicyMdl.PolicyNo = _tblSqla.Rows[i]["PolicyNo"].ToString();
                        _MtrOpenPolicyMdl.DocType = _tblSqla.Rows[i]["DocType"].ToString();
                        _MtrOpenPolicyMdl.GenerateAgainst = _tblSqla.Rows[i]["GenerateAgainst"].ToString();
                        _MtrOpenPolicyMdl.ProductCode = Convert.ToInt32(_tblSqla.Rows[i]["ProductCode"]);
                        _MtrOpenPolicyMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();
                        _MtrOpenPolicyMdl.ClientCode = _tblSqla.Rows[i]["ClientCode"].ToString();
                        _MtrOpenPolicyMdl.AgencyCode = _tblSqla.Rows[i]["AgencyCode"].ToString();
                        _MtrOpenPolicyMdl.CertInsureCode = _tblSqla.Rows[i]["CertInsureCode"].ToString();
                        _MtrOpenPolicyMdl.Remarks = _tblSqla.Rows[i]["Remarks"].ToString();
                        _MtrOpenPolicyMdl.BrchCoverNoteNo = _tblSqla.Rows[i]["BrchCoverNoteNo"].ToString();
                        _MtrOpenPolicyMdl.LeaderPolicyNo = _tblSqla.Rows[i]["LeaderPolicyNo"].ToString();
                        _MtrOpenPolicyMdl.LeaderEndNo = _tblSqla.Rows[i]["LeaderEndNo"].ToString();
                        _MtrOpenPolicyMdl.IsFiler = _tblSqla.Rows[i]["IsFiler"].ToString();
                        _MtrOpenPolicyMdl.CalcType = _tblSqla.Rows[i]["CalcType"].ToString();
                        _MtrOpenPolicyMdl.IsAuto = _tblSqla.Rows[i]["IsAuto"].ToString();
                        _MtrOpenPolicyMdl.EffectiveDate = Convert.ToDateTime(_tblSqla.Rows[i]["EffectiveDate"]);
                        _MtrOpenPolicyMdl.ExpiryDate = Convert.ToDateTime(_tblSqla.Rows[i]["ExpiryDate"]);
                        _MtrOpenPolicyMdl.SerialNo = Convert.ToInt32(_tblSqla.Rows[i]["SerialNo"]);
                        _MtrOpenPolicyMdl.UWYear = _tblSqla.Rows[i]["UWYear"].ToString();
                        _MtrOpenPolicyMdl.CreatedBy = _tblSqla.Rows[i]["CreatedBy"].ToString();
                        _MtrOpenPolicyMdl.PostedBy = _tblSqla.Rows[i]["PostedBy"].ToString();
                        _MtrOpenPolicyMdl.IsPosted = Convert.ToBoolean(_tblSqla.Rows[i]["IsPosted"]);
                        _MtrOpenPolicyMdl.PostDate = Convert.ToDateTime(_tblSqla.Rows[i]["PostDate"]);
                        _MtrOpenPolicyMdl.CommisionRate = Convert.ToDecimal(_tblSqla.Rows[i]["CommisionRate"]);

                        _MtrOpenPolicyMdlList.Add(_MtrOpenPolicyMdl);
                    }

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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }

        //Get All Products with Client Based No
        public List<MasterProductSetupMdl> ProductCodeWithNoClient()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT mps.ProductCode,mps.ProductName FROM MasterProductSetup mps WHERE mps.IsClientBased = 'No' ";
                 SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();

                MasterProductSetupMdl _MasterProductSetupMdl = new MasterProductSetupMdl();
                List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MasterProductSetupMdl = new MasterProductSetupMdl();

                        _MasterProductSetupMdl.ProductCode = Convert.ToInt32(_tblSqla.Rows[i]["ProductCode"].ToString());
                        _MasterProductSetupMdl.ProductName = _tblSqla.Rows[i]["ProductName"].ToString();


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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }

        }



        //--------------For Ins Policy--------------//


        //for getting all Open Policy by Client Code 
        public List<MtrPolicyMdl> GetOpolicytByClient(ProductClientMdl _ProductClientMdl1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT * FROM ClientProductSetup WHERE ClientCode=" ;
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrPolicyMdl> _MtrPolicyMdlList = new List<MtrPolicyMdl>();
                MtrPolicyMdl _MtrPolicyMdl = new MtrPolicyMdl();


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM MtrOpenPolicy WHERE ClientCode = @ClientCode ", conn);

                    command.Parameters.Add(new SqlParameter("@ClientCode", _ProductClientMdl1.ClientCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


                // _adpSql.Fill(_tbl);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrPolicyMdl = new MtrPolicyMdl();

                        _MtrPolicyMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrPolicyMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrPolicyMdl.PolicyMonth = _tblSqla.Rows[i]["PolicyMonth"].ToString();
                        _MtrPolicyMdl.PolicyString = _tblSqla.Rows[i]["PolicyString"].ToString();
                        _MtrPolicyMdl.PolicyYear = _tblSqla.Rows[i]["PolicyYear"].ToString();
                        _MtrPolicyMdl.PolicyNo = _tblSqla.Rows[i]["PolicyNo"].ToString();
                        _MtrPolicyMdl.DocType = _tblSqla.Rows[i]["DocType"].ToString();
                        _MtrPolicyMdl.GenerateAgainst = _tblSqla.Rows[i]["GenerateAgainst"].ToString();
                        _MtrPolicyMdl.ProductCode = Convert.ToInt32(_tblSqla.Rows[i]["ProductCode"]);
                        _MtrPolicyMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();
                        _MtrPolicyMdl.ClientCode = _tblSqla.Rows[i]["ClientCode"].ToString();
                        _MtrPolicyMdl.AgencyCode = _tblSqla.Rows[i]["AgencyCode"].ToString();
                        _MtrPolicyMdl.CertInsureCode = _tblSqla.Rows[i]["CertInsureCode"].ToString();
                        _MtrPolicyMdl.Remarks = _tblSqla.Rows[i]["Remarks"].ToString();
                        _MtrPolicyMdl.BrchCoverNoteNo = _tblSqla.Rows[i]["BrchCoverNoteNo"].ToString();
                        _MtrPolicyMdl.LeaderPolicyNo = _tblSqla.Rows[i]["LeaderPolicyNo"].ToString();
                        _MtrPolicyMdl.LeaderEndNo = _tblSqla.Rows[i]["LeaderEndNo"].ToString();
                        _MtrPolicyMdl.IsFiler = _tblSqla.Rows[i]["IsFiler"].ToString();
                        _MtrPolicyMdl.CalcType = _tblSqla.Rows[i]["CalcType"].ToString();
                        _MtrPolicyMdl.IsAuto = _tblSqla.Rows[i]["IsAuto"].ToString();
                        _MtrPolicyMdl.EffectiveDate = Convert.ToDateTime(_tblSqla.Rows[i]["EffectiveDate"]);
                        _MtrPolicyMdl.ExpiryDate = Convert.ToDateTime(_tblSqla.Rows[i]["ExpiryDate"]);
                        _MtrPolicyMdl.SerialNo = Convert.ToInt32(_tblSqla.Rows[i]["SerialNo"]);
                        _MtrPolicyMdl.UWYear = _tblSqla.Rows[i]["UWYear"].ToString();
                        _MtrPolicyMdl.CreatedBy = _tblSqla.Rows[i]["CreatedBy"].ToString();
                        _MtrPolicyMdl.PostedBy = _tblSqla.Rows[i]["PostedBy"].ToString();
                        _MtrPolicyMdl.IsPosted = Convert.ToBoolean(_tblSqla.Rows[i]["IsPosted"]);
                        _MtrPolicyMdl.PostDate = Convert.ToDateTime(_tblSqla.Rows[i]["PostDate"]);


                        _MtrPolicyMdlList.Add(_MtrPolicyMdl);
                    }

                    return _MtrPolicyMdlList;
                }
                else
                {

                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }


        //--------------For Ins Policy--------------//

        //------------- Get Values On Selection of Product Code ------------- //

        //Get Values from Product Setup On selection of Product Code
        public MasterProductSetupMdl GetMasterProductByProductCode(MasterProductSetupMdl _MasterProductSetupMdl)
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
                        new SqlCommand("SELECT * FROM MasterProductSetup mps WHERE mps.ProductCode = @ProductCode", conn);

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
                        _MasterProductSetupMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MasterProductSetupMdl.ProductCode = Convert.ToInt32(_tblSqla.Rows[i]["ProductCode"]);
                        _MasterProductSetupMdl.ProductName = _tblSqla.Rows[i]["ProductName"].ToString();

                        if (_tblSqla.Rows[i]["IsClientBased"].ToString() == "No")
                        {
                            _MasterProductSetupMdl.IsClientBased = _tblSqla.Rows[i]["IsClientBased"].ToString();
                            _MasterProductSetupMdl.Client = "N/A";
                            _MasterProductSetupMdl.Agent = "N/A";
                            _MasterProductSetupMdl.AgentCommPct = 0;



                            _MasterProductSetupMdl.ClientName = "N/A";
                            _MasterProductSetupMdl.AgentName = "N/A";

                        }

                        else
                        {
                            _MasterProductSetupMdl.IsClientBased = _tblSqla.Rows[i]["IsClientBased"].ToString();
                            _MasterProductSetupMdl.Client = _tblSqla.Rows[i]["Client"].ToString();
                            _MasterProductSetupMdl.Agent = _tblSqla.Rows[i]["Agent"].ToString();

                            _MasterProductSetupMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_tblSqla.Rows[i]["Client"].ToString());
                            _MasterProductSetupMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_tblSqla.Rows[i]["Agent"].ToString());
                        }
                            _MasterProductSetupMdl.AgentCommPct = Convert.ToDecimal(_tblSqla.Rows[i]["AgentCommPct"]);
                            _MasterProductSetupMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();
                            _MasterProductSetupMdl.CertInsureCode = GetCertInsByPolicyType(_tblSqla.Rows[i]["PolicyTypeCode"].ToString());

                           
                            _MasterProductSetupMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_MasterProductSetupMdl.CertInsureCode);
                            _MasterProductSetupMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_tblSqla.Rows[i]["PolicyTypeCode"].ToString());
                        
                        _MasterProductSetupMdl.IsValidTxn = true;

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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }

        //Get Trackers On selection of Product Code
        public List<ProductTrackerSetupMdl> GetTrackerByPCode(MasterProductSetupMdl _MasterProductSetupMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<ProductTrackerSetupMdl> _ProductTrackerSetupMdlList = new List<ProductTrackerSetupMdl>();
                ProductTrackerSetupMdl _ProductTrackerSetupMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM MasterProductSetup mps INNER JOIN ProductTrackerSetup pts ON mps.TxnSysID = pts.PrdStpTxnSysId WHERE mps.ProductCode = @ProductCode", conn);

                    command.Parameters.Add(new SqlParameter("@ProductCode", _MasterProductSetupMdl.ProductCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductTrackerSetupMdl = new ProductTrackerSetupMdl();

                        //For Tracker
                        _ProductTrackerSetupMdl.TrackerCode = Convert.ToInt32(_tblSqla.Rows[i]["TrackerCode"]);
                        _ProductTrackerSetupMdl.TrackerName = _tblSqla.Rows[i]["TrackerName"].ToString();
                        _ProductTrackerSetupMdl.TrackerRate = Convert.ToInt32(_tblSqla.Rows[i]["TrackerRate"]);

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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }

        //Get Rider On selection of Product Code
        public List<ProductRiderSetupMdl> GetRiderByPCode(MasterProductSetupMdl _MasterProductSetupMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<ProductRiderSetupMdl> _ProductRiderSetupMdlList = new List<ProductRiderSetupMdl>();
                ProductRiderSetupMdl _ProductRiderSetupMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM MasterProductSetup mps INNER JOIN ProductRiderSetup pts ON mps.TxnSysID = pts.PrdStpTxnSysId WHERE mps.ProductCode = @ProductCode", conn);

                    command.Parameters.Add(new SqlParameter("@ProductCode", _MasterProductSetupMdl.ProductCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductRiderSetupMdl = new ProductRiderSetupMdl();

                        //For Rider
                        _ProductRiderSetupMdl.RiderCode = Convert.ToInt32(_tblSqla.Rows[i]["RiderCode"]);
                        _ProductRiderSetupMdl.RiderName = _tblSqla.Rows[i]["RiderName"].ToString();
                        _ProductRiderSetupMdl.RiderRate = Convert.ToInt32(_tblSqla.Rows[i]["RiderRate"]);


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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }

        //Get Rating Factor On selection of Product Code
        public List<ProductRatingFactorSetUpMdl> GetRatingFactorByPCode(MasterProductSetupMdl _MasterProductSetupMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<ProductRatingFactorSetUpMdl> _ProductRatingFactorSetUpMdlList = new List<ProductRatingFactorSetUpMdl>();
                ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM MasterProductSetup mps INNER JOIN ProductRatingFactorsProductSetup pts ON mps.TxnSysID = pts.PrdStpTxnSysId WHERE mps.ProductCode = @ProductCode", conn);

                    command.Parameters.Add(new SqlParameter("@ProductCode", _MasterProductSetupMdl.ProductCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductRatingFactorSetUpMdl = new ProductRatingFactorSetUpMdl();

                        //For Rating Factor
                        _ProductRatingFactorSetUpMdl.RatingFactor = _tblSqla.Rows[i]["RatingFactor"].ToString();
                        _ProductRatingFactorSetUpMdl.Rate = Convert.ToInt32(_tblSqla.Rows[i]["Rate"]);
                        _ProductRatingFactorSetUpMdl.IsEditable = _tblSqla.Rows[i]["IsEditable"].ToString();

                        _ProductRatingFactorSetUpMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_tblSqla.Rows[i]["RatingFactor"].ToString());

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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }

        //Get Warranties On selection of Product Code
        public List<ProductWarrantiesSetupMdl> GetWarantiesByPCode(MasterProductSetupMdl _MasterProductSetupMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<ProductWarrantiesSetupMdl> _ProductWarrantiesSetupMdlList = new List<ProductWarrantiesSetupMdl>();
                ProductWarrantiesSetupMdl _ProductWarrantiesSetupMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM MasterProductSetup mps INNER JOIN ProductWarrantiesProductSetup pts ON mps.TxnSysID = pts.PrdStpTxnSysId WHERE mps.ProductCode = @ProductCode", conn);

                    command.Parameters.Add(new SqlParameter("@ProductCode", _MasterProductSetupMdl.ProductCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductWarrantiesSetupMdl = new ProductWarrantiesSetupMdl();

                        //For Warranties
                        _ProductWarrantiesSetupMdl.Warranty = _tblSqla.Rows[i]["Warranty"].ToString();
                        _ProductWarrantiesSetupMdl.WarrantyShText = GlobalDataLayer.GetWarrantyTextByCode(_tblSqla.Rows[i]["Warranty"].ToString());
                       


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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }

        //Get Conditions On selection of Product Code
        public List<ProductConditionsSetupMdl> GetConditionsByPCode(MasterProductSetupMdl _MasterProductSetupMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<ProductConditionsSetupMdl> _ProductConditionsSetupMdlList = new List<ProductConditionsSetupMdl>();
                ProductConditionsSetupMdl _ProductConditionsSetupMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM MasterProductSetup mps INNER JOIN ProductConditionsProductSetup pts ON mps.TxnSysID = pts.PrdStpTxnSysId WHERE mps.ProductCode = @ProductCode", conn);

                    command.Parameters.Add(new SqlParameter("@ProductCode", _MasterProductSetupMdl.ProductCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductConditionsSetupMdl = new ProductConditionsSetupMdl();

                        //For Conditions
                        _ProductConditionsSetupMdl.Condition = _tblSqla.Rows[i]["Condition"].ToString();
                        _ProductConditionsSetupMdl.ConditionShText = GlobalDataLayer.GetConditionByCode(_tblSqla.Rows[i]["Condition"].ToString());



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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }


        //Get Certificate Insurance Code By Policy Type
        public string GetCertInsByPolicyType(string _PolicyTypeCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM PolicyTypeProductSetup WHERE PolicyTypeCode='" + _PolicyTypeCode + "'";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                MasterProductSetupMdl _MasterProductSetupMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _MasterProductSetupMdl = new MasterProductSetupMdl();
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {

                        _MasterProductSetupMdl.CertInsureCode = _tbl.Rows[i]["CertInsureCode"].ToString();

                    }
                    return _MasterProductSetupMdl.CertInsureCode;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }

        //Get Tracker Amount by Product Code and Tracker Code
        public ProductTrackerSetupMdl GetTrackerAmount(ProductTrackerSetupMdl _ProductTrackerSetupMdl1)
        {
            try
            {

                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //  string _sqlString = "SELECT * FROM ProductWarrantiesProductSetup";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
               // List<ProductTrackerSetupMdl> _ProductTrackerSetupMdlList = new List<ProductTrackerSetupMdl>();
                ProductTrackerSetupMdl _ProductTrackerSetupMdl = new ProductTrackerSetupMdl();


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand(" SELECT * FROM MasterProductSetup mps INNER JOIN ProductTrackerSetup  pts ON mps.TxnSysID = pts.PrdStpTxnSysId WHERE mps.ProductCode = "+_ProductTrackerSetupMdl1.ProductCode+" AND pts.TrackerCode = @TrackerCode", conn);

                    command.Parameters.Add(new SqlParameter("@TrackerCode", _ProductTrackerSetupMdl1.TrackerCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


                //  _adpSql.Fill(_tbl);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductTrackerSetupMdl = new ProductTrackerSetupMdl();

                     
                        _ProductTrackerSetupMdl.TrackerRate = Convert.ToInt32(_tblSqla.Rows[i]["TrackerRate"]);
                        _ProductTrackerSetupMdl.PrdStpTxnSysId = Convert.ToInt32(_tblSqla.Rows[i]["PrdStpTxnSysId"]);


                        _ProductTrackerSetupMdl.IsValidTxn = true;

                        
                    }

                    return _ProductTrackerSetupMdl;
                }
                else
                {
                    return null;
                }



            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }

        //Get Rider Amount by Product Code and Rider Code
        public ProductRiderSetupMdl GetRiderAmount(ProductRiderSetupMdl _ProductRiderSetupMdl1)
        {
            try
            {

                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //  string _sqlString = "SELECT * FROM ProductWarrantiesProductSetup";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<ProductTrackerSetupMdl> _ProductTrackerSetupMdlList = new List<ProductTrackerSetupMdl>();
                ProductRiderSetupMdl _ProductRiderSetupMdl = new ProductRiderSetupMdl();


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM MasterProductSetup mps INNER JOIN ProductRiderSetup  pts ON mps.TxnSysID = pts.PrdStpTxnSysId WHERE mps.ProductCode = " + _ProductRiderSetupMdl1.ProductCode + " AND pts.RiderCode = @RiderCode", conn);

                    command.Parameters.Add(new SqlParameter("@RiderCode", _ProductRiderSetupMdl1.RiderCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


                //  _adpSql.Fill(_tbl);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductRiderSetupMdl = new ProductRiderSetupMdl();


                        _ProductRiderSetupMdl.RiderRate = Convert.ToInt32(_tblSqla.Rows[i]["RiderRate"]);
                        _ProductRiderSetupMdl.PrdStpTxnSysId = Convert.ToInt32(_tblSqla.Rows[i]["PrdStpTxnSysId"]);


                        _ProductRiderSetupMdl.IsValidTxn = true;


                    }

                    return _ProductRiderSetupMdl;
                }
                else
                {
                    return null;
                }



            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }

        //Get Rating Factor Rate by Product Code and Rating Factor Code
        public ProductRatingFactorSetUpMdl GetRatingFactorRate(ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl1)
        {
            try
            {

                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //  string _sqlString = "SELECT * FROM ProductWarrantiesProductSetup";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<ProductTrackerSetupMdl> _ProductTrackerSetupMdlList = new List<ProductTrackerSetupMdl>();
                ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl = new ProductRatingFactorSetUpMdl();


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM MasterProductSetup mps INNER JOIN ProductRatingFactorsProductSetup  pts ON mps.TxnSysID = pts.PrdStpTxnSysId WHERE mps.ProductCode = " + _ProductRatingFactorSetUpMdl1.ProductCode + " AND pts.RatingFactor  = @RatingFactor ", conn);

                    command.Parameters.Add(new SqlParameter("@RatingFactor ", _ProductRatingFactorSetUpMdl1.RatingFactor));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


                //  _adpSql.Fill(_tbl);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductRatingFactorSetUpMdl = new ProductRatingFactorSetUpMdl();


                        _ProductRatingFactorSetUpMdl.RatingFactor = _tblSqla.Rows[i]["RatingFactor"].ToString();
                        _ProductRatingFactorSetUpMdl.Rate = Convert.ToDecimal(_tblSqla.Rows[i]["Rate"]);
                        _ProductRatingFactorSetUpMdl.PrdStpTxnSysId = Convert.ToInt32(_tblSqla.Rows[i]["PrdStpTxnSysId"]);


                        _ProductRatingFactorSetUpMdl.IsValidTxn = true;


                    }

                    return _ProductRatingFactorSetUpMdl;
                }
                else
                {
                    return null;
                }



            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }

        //------------- Get Values On Selection of Product Code ------------- //


        //Get Vehicle Certificate by Chasis Number, Participant Name , Registration Number , Engine Number , Policy Number
        public List<VehicleDetailMdl> GetVehicleDetailForPol(VehicleDetailMdl _VehicleDetailMdl1, MtrInsPolicyMdl _MtrInsPolicyMdl, MtrSeByCertMdl _MtrSeByCertMdl)
        {

            try
            {
                // SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                DataTable _tblSqla = new DataTable();
                List<VehicleDetailMdl> _VehicleDetailMdlList = new List<VehicleDetailMdl>();
                VehicleDetailMdl _VehicleDetailMdl = new VehicleDetailMdl();


                //Search by chasis number
                if (_MtrSeByCertMdl.SeByCertCode == 1)
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE mvd.OpolTxnSysID = -1 AND ip.IsActive <> 0 AND  ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND mvd.ChasisNumber = @ChasisNumber", conn);

                        command.Parameters.Add(new SqlParameter("@ChasisNumber", _VehicleDetailMdl1.ChasisNumber ?? DBNull.Value.ToString()));

                        SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                        _adpSql.Fill(_tblSqla);
                    }

                }

                //Search by registration number
                else if (_MtrSeByCertMdl.SeByCertCode == 2)
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE mvd.OpolTxnSysID = -1 AND ip.IsActive <> 0 AND ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND mvd.RegistrationNumber = @RegistrationNumber", conn);


                        command.Parameters.Add(new SqlParameter("@RegistrationNumber", _VehicleDetailMdl1.RegistrationNumber ?? DBNull.Value.ToString()));



                        SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                        _adpSql.Fill(_tblSqla);
                    }

                }

                //Search by Model Number
                else if (_MtrSeByCertMdl.SeByCertCode == 3)
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE mvd.OpolTxnSysID = -1 AND ip.IsActive <> 0 AND ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND mvd.VehicleModel = @ModelNumber ", conn);


                        command.Parameters.Add(new SqlParameter("@ModelNumber", _VehicleDetailMdl1.ModelNumber));


                        SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                        _adpSql.Fill(_tblSqla);
                    }
                }

                //Search By participant Name 
                else if (_MtrSeByCertMdl.SeByCertCode == 4)
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE  mvd.OpolTxnSysID = -1 AND ip.IsActive <> 0 AND ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND UPPER(mvd.ParticipantName)  like '%'+UPPER('" + _VehicleDetailMdl1.ParticipantName + "')+'%'", conn);


                        // command.Parameters.Add(new SqlParameter("@ParticipantName", _VehicleDetailMdl1.ParticipantName));


                        SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                        _adpSql.Fill(_tblSqla);
                    }
                }

                //Search by policy Number
                else
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {

                        string str = "SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE mvd.OpolTxnSysID = -1 AND ip.IsActive <> 0 AND ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND ip.DocString LIKE '%" + _MtrInsPolicyMdl.ParentTxnSysID + "%'";

                        //  SqlCommand command =
                        //    new SqlCommand("SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE  ip.DocType IN (7,4,5) AND ip.IsActive <> 0 AND ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND ip.DocString LIKE '%@ParentTxnSysID%' ", conn);

                        SqlCommand command =
                          new SqlCommand(str, conn);


                        // command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl.ParentTxnSysID));


                        SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                        _adpSql.Fill(_tblSqla);
                    }
                }


                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl = new VehicleDetailMdl();

                        _VehicleDetailMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _VehicleDetailMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _VehicleDetailMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _VehicleDetailMdl.SerialNo = Convert.ToInt32(_tblSqla.Rows[i]["SerialNo"].ToString());
                        _VehicleDetailMdl.VehicleCode = Convert.ToInt32(_tblSqla.Rows[i]["VehicleCode"].ToString());
                        _VehicleDetailMdl.VehicleModel = Convert.ToInt32(_tblSqla.Rows[i]["VehicleModel"].ToString());
                        _VehicleDetailMdl.UpdatedValue = Convert.ToDecimal(_tblSqla.Rows[i]["UpdatedValue"]);
                        _VehicleDetailMdl.PreviousValue = Convert.ToDecimal(_tblSqla.Rows[i]["PreviousValue"]);
                        _VehicleDetailMdl.Mileage = Convert.ToInt32(_tblSqla.Rows[i]["Mileage"].ToString());
                        _VehicleDetailMdl.ParticipantValue = Convert.ToDecimal(_tblSqla.Rows[i]["ParticipantValue"]);
                        _VehicleDetailMdl.ColorCode = Convert.ToInt32(_tblSqla.Rows[i]["ColorCode"]);
                        _VehicleDetailMdl.ParticipantName = _tblSqla.Rows[i]["ParticipantName"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.ParticipantAddress = _tblSqla.Rows[i]["ParticipantAddress"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.RegistrationNumber = _tblSqla.Rows[i]["RegistrationNumber"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.CityCode = _tblSqla.Rows[i]["CityCode"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.EngineNumber = _tblSqla.Rows[i]["EngineNumber"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.AreaCode = Convert.ToInt32(_tblSqla.Rows[i]["AreaCode"]);
                        _VehicleDetailMdl.ChasisNumber = _tblSqla.Rows[i]["ChasisNumber"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.Remarks = _tblSqla.Rows[i]["Remarks"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.PODate = Convert.ToDateTime(_tblSqla.Rows[i]["PODate"]);
                        _VehicleDetailMdl.PONumber = (_tblSqla.Rows[i]["PONumber"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.CNICNumber = _tblSqla.Rows[i]["CNICNumber"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.Tenure = _tblSqla.Rows[i]["Tenure"].ToString() ?? DBNull.Value.ToString();

                        _VehicleDetailMdl.Gender = _tblSqla.Rows[i]["Gender"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.VehicleType = _tblSqla.Rows[i]["VehicleType"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.VEODCode = Convert.ToInt32(_tblSqla.Rows[i]["VEODCode"]);
                        _VehicleDetailMdl.CertTypeCode = _tblSqla.Rows[i]["CertTypeCode"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.Rate = Convert.ToDecimal(_tblSqla.Rows[i]["Rate"]);
                        _VehicleDetailMdl.Contribution = Convert.ToInt32(_tblSqla.Rows[i]["Contribution"]);
                        _VehicleDetailMdl.BirthDate = Convert.ToDateTime(_tblSqla.Rows[i]["BirthDate"]);

                        _VehicleDetailMdl.RatingFactor = _tblSqla.Rows[i]["RatingFactor"].ToString();
                        _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_tblSqla.Rows[i]["RatingFactor"].ToString());


                        _VehicleDetailMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["ParentTxnSysID"]);
                        _VehicleDetailMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["OpolTxnSysID"]);

                        _VehicleDetailMdl.InsuranceTypeCode = Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]);
                        _VehicleDetailMdl.IsActive = Convert.ToBoolean(_tblSqla.Rows[i]["IsActive"]);
                        _VehicleDetailMdl.IsCanceled = Convert.ToBoolean(_tblSqla.Rows[i]["IsCanceled"]);
                        _VehicleDetailMdl.CommisionRate = Convert.ToDecimal(_tblSqla.Rows[i]["CommisionRate"]);
                        _VehicleDetailMdl.MobileNumber = _tblSqla.Rows[i]["MobileNumber"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.ResNumber = _tblSqla.Rows[i]["ResNumber"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.OfficeNumber = _tblSqla.Rows[i]["OfficeNumber"].ToString() ?? DBNull.Value.ToString();

                        _VehicleDetailMdl.EmailAddress = _tblSqla.Rows[i]["EmailAddress"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.Deductible = Convert.ToDecimal(_tblSqla.Rows[i]["Deductible"]);

                        _VehicleDetailMdl.ContractMatDate = Convert.ToDateTime(_tblSqla.Rows[i]["ContractMatDate"]);

                        _VehicleDetailMdl.VEODName = GlobalDataLayer.GetVEODNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["VEODCode"])) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_tblSqla.Rows[i]["VehicleType"].ToString()) ?? DBNull.Value.ToString();

                        _VehicleDetailMdl.GenderName = GlobalDataLayer.GetGenderNameByCode(_tblSqla.Rows[i]["Gender"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.CityName = GlobalDataLayer.GetCityNameByCode(_tblSqla.Rows[i]["CityCode"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["ColorCode"].ToString()));
                        _VehicleDetailMdl.VehicleName = GlobalDataLayer.GetVehicleNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["VehicleCode"].ToString())) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.AreaName = GlobalDataLayer.GetAreaNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["AreaCode"].ToString())) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_tblSqla.Rows[i]["CertTypeCode"].ToString()) ?? DBNull.Value.ToString();

                        // _VehicleDetailMdl.total = GlobalDataLayer.calculate(_VehicleDetailMdl);

                        //For Ins Policy (Header)
                        _VehicleDetailMdl.ExpiryDate = Convert.ToDateTime(_tblSqla.Rows[i]["ExpiryDate"]);
                        _VehicleDetailMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["ParentTxnSysID"]);
                        _VehicleDetailMdl.CertMonth = _tblSqla.Rows[i]["DocMonth"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.CertString = _tblSqla.Rows[i]["DocString"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.CertYear = _tblSqla.Rows[i]["DocYear"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.CertNo = Convert.ToInt32(_tblSqla.Rows[i]["DocNo"]);
                        _VehicleDetailMdl.DocType = _tblSqla.Rows[i]["DocType"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.GenerateAgainst = _tblSqla.Rows[i]["GenerateAgainst"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.ProductCode = Convert.ToInt32(_tblSqla.Rows[i]["ProductCode"]);
                        _VehicleDetailMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.ClientCode = _tblSqla.Rows[i]["ClientCode"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.AgencyCode = _tblSqla.Rows[i]["AgencyCode"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.CertInsureCode = _tblSqla.Rows[i]["CertInsureCode"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.Remarks1 = _tblSqla.Rows[i]["Remarks"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.BrchCoverNoteNo = _tblSqla.Rows[i]["BrchCoverNoteNo"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.LeaderPolicyNo = _tblSqla.Rows[i]["LeaderPolicyNo"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.LeaderEndNo = _tblSqla.Rows[i]["LeaderEndNo"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.IsFiler = _tblSqla.Rows[i]["IsFiler"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.CalcType = _tblSqla.Rows[i]["CalcType"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.IsAuto = _tblSqla.Rows[i]["IsAuto"].ToString() ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.EffectiveDate = Convert.ToDateTime(_tblSqla.Rows[i]["EffectiveDate"]);
                        _VehicleDetailMdl.ExpiryDate = Convert.ToDateTime(_tblSqla.Rows[i]["ExpiryDate"]);
                        _VehicleDetailMdl.SerialNo = Convert.ToInt32(_tblSqla.Rows[i]["SerialNo"]);
                        _VehicleDetailMdl.UWYear = _tblSqla.Rows[i]["UWYear"].ToString();
                        _VehicleDetailMdl.CreatedBy = _tblSqla.Rows[i]["CreatedBy"].ToString();
                        //_VehicleDetailMdl.PostedBy = _tblSqla.Rows[i]["PostedBy"].ToString();
                        _VehicleDetailMdl.IsPosted = Convert.ToBoolean(_tblSqla.Rows[i]["IsPosted"]);
                        // _VehicleDetailMdl.PostDate = Convert.ToDateTime(_tblSqla.Rows[i]["PostDate"]);
                        _VehicleDetailMdl.OpolTxnSysID1 = Convert.ToInt32(_tblSqla.Rows[i]["OpolTxnSysID"]);
                        _VehicleDetailMdl.RenewSysID = Convert.ToInt32(_tblSqla.Rows[i]["RenewSysID"]);
                        _VehicleDetailMdl.PolSysID = Convert.ToInt32(_tblSqla.Rows[i]["PolSysID"]);
                        _VehicleDetailMdl.IsRenewal = Convert.ToBoolean(_tblSqla.Rows[i]["IsRenewal"]);
                        _VehicleDetailMdl.CommisionRate1 = Convert.ToDecimal(_tblSqla.Rows[i]["CommisionRate"]);

                        _VehicleDetailMdl.IsValidTxn = true;

                        _VehicleDetailMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(_tblSqla.Rows[i]["ProductCode"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_tblSqla.Rows[i]["PolicyTypeCode"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_tblSqla.Rows[i]["ClientCode"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_tblSqla.Rows[i]["AgencyCode"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_tblSqla.Rows[i]["CertInsureCode"].ToString()) ?? DBNull.Value.ToString();

                        _VehicleDetailMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(_tblSqla.Rows[i]["DocType"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_tblSqla.Rows[i]["IsFiler"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_tblSqla.Rows[i]["CalcType"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_tblSqla.Rows[i]["IsAuto"].ToString()) ?? DBNull.Value.ToString();


                        //For Contribution

                        _VehicleDetailMdl.SumCovered = Convert.ToInt32(_tblSqla.Rows[i]["SumCovered"]);
                        _VehicleDetailMdl.Rate2 = Convert.ToDecimal(_tblSqla.Rows[i]["Rate1"]);
                        _VehicleDetailMdl.NetContribution = Decimal.Round(Convert.ToDecimal(_tblSqla.Rows[i]["NetContribution"]), MidpointRounding.ToEven);
                        _VehicleDetailMdl.GrossContribution = Decimal.Round(Convert.ToDecimal(_tblSqla.Rows[i]["GrossContribution"]), MidpointRounding.ToEven);
                        _VehicleDetailMdl.FIF = Convert.ToDecimal(_tblSqla.Rows[i]["FIF"]);
                        _VehicleDetailMdl.FED = Convert.ToDecimal(_tblSqla.Rows[i]["FED"]);
                        _VehicleDetailMdl.Stamp = Convert.ToDecimal(_tblSqla.Rows[i]["Stamp"]);
                        _VehicleDetailMdl.BasicContribution = Convert.ToDecimal(_tblSqla.Rows[i]["BasicContribution"]);
                        _VehicleDetailMdl.PEV = Convert.ToDecimal(_tblSqla.Rows[i]["PEV"]);
                        _VehicleDetailMdl.BeforePEV = Convert.ToDecimal(_tblSqla.Rows[i]["BeforePEV"]);
                        _VehicleDetailMdl.TerrorContribution = Convert.ToDecimal(_tblSqla.Rows[i]["TerrorContribution"]);
                        _VehicleDetailMdl.RiskTxnID = Convert.ToInt32(_tblSqla.Rows[i]["RiskTxnID"]);
                        _VehicleDetailMdl.PerDayContribution = Convert.ToInt32(_tblSqla.Rows[i]["PerDayContribution"]);
                        _VehicleDetailMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["OpolTxnSysID"]);




                        _VehicleDetailMdl.IsValidTxn = true;


                        _VehicleDetailMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(_tblSqla.Rows[i]["ProductCode"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_tblSqla.Rows[i]["PolicyTypeCode"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_tblSqla.Rows[i]["ClientCode"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_tblSqla.Rows[i]["AgencyCode"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_tblSqla.Rows[i]["CertInsureCode"].ToString()) ?? DBNull.Value.ToString();

                        _VehicleDetailMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(_tblSqla.Rows[i]["DocType"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_tblSqla.Rows[i]["IsFiler"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_tblSqla.Rows[i]["CalcType"].ToString()) ?? DBNull.Value.ToString();
                        _VehicleDetailMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_tblSqla.Rows[i]["IsAuto"].ToString()) ?? DBNull.Value.ToString();


                        //DateTime? _birthDate;
                        //if (_tblSqla.Rows[i]["BirthDate"].Equals(null))
                        //{
                        //    _birthDate = null;

                        //}
                        //else
                        //{
                        //    _birthDate = Convert.ToDateTime(_tblSqla.Rows[i]["BirthDate"]);
                        //}

                        // _VehicleDetailMdl.BirthDate = _birthDate;

                        _VehicleDetailMdlList.Add(_VehicleDetailMdl);


                    }

                    return _VehicleDetailMdlList;

                }

                else
                {
                    return null;
                }

            }




            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Policy DataLayer");
                return null;
            }
        }




    }
}