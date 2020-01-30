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
using static ProductSetupApi.Models.MtrVehicleDetailMdl;

namespace ProductSetupApi.DataLayers
{
    public class RenewalDal
    {

        //Get Certificate and Policy with effective date and expiry date
        public List<MtrInsPolicyMdl> GetCertStrByDate(MtrInsPolicyMdl _MtrInsPolicyMdl1)
        {
            try
            {

                //For Renewable
                if (_MtrInsPolicyMdl1.RenewalType == 0)
                {

                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    string _sqlString = "SELECT ip.IsRenewal,ip.ParentTxnSysID,ip.CertInsureCode,ip.DocNo , ip.DocString,mvd.ParticipantName,mvd.ParticipantValue ,mvd.TxnSysID, mvd.InsuranceTypeCode ,ip.TxnSysDate,ip.EffectiveDate,ip.ExpiryDate FROM InsPolicy ip  INNER JOIN MtrVehicleDetails mvd ON mvd.ParentTxnSysID = ip.ParentTxnSysID WHERE mvd.InsuranceTypeCode IN(1,2) AND ip.DocType IN(5,7) AND ip.IsActive = 1 AND ip.IsRenewal = 0 AND FORMAT(ip.EffectiveDate, 'd', 'en-US' ) = (SELECT SUBSTRING( '" + (_MtrInsPolicyMdl1.EffectiveDate) + "' , 0,10)) AND FORMAT(ip.ExpiryDate, 'd', 'en-US' ) = (SELECT SUBSTRING( '" + (_MtrInsPolicyMdl1.ExpiryDate) + "' , 0,10)) AND ip.ExpiryDate > '" + DateTime.Now.ToString() + "'";
                    //+ " WHERE  FORMAT(TxnSysDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + 
                    // "AND FORMAT(EffectiveDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + "AND FORMAT(ExpiryDate, 'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(), 'yyyy-MM-dd'))";
                    SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                    DataTable _tblSqla = new DataTable();
                    List<MtrInsPolicyMdl> _MtrInsPolicyMdlList = new List<MtrInsPolicyMdl>();
                    MtrInsPolicyMdl _MtrInsPolicyMdl;

                    _adpSql.Fill(_tblSqla);

                    if (_tblSqla.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla.Rows.Count; i++)
                        {
                            _MtrInsPolicyMdl = new MtrInsPolicyMdl();

                           
                            _MtrInsPolicyMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                            _MtrInsPolicyMdl.CertString = _tblSqla.Rows[i]["DocString"].ToString();
                            _MtrInsPolicyMdl.CertNo = Convert.ToInt32(_tblSqla.Rows[i]["DocNo"]);
                            _MtrInsPolicyMdl.EffectiveDate = Convert.ToDateTime(_tblSqla.Rows[i]["EffectiveDate"]);
                            _MtrInsPolicyMdl.ExpiryDate = Convert.ToDateTime(_tblSqla.Rows[i]["ExpiryDate"]);
                            _MtrInsPolicyMdl.ParticipantName = _tblSqla.Rows[i]["ParticipantName"].ToString();
                            _MtrInsPolicyMdl.InsuranceTypeCode = Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]);
                            _MtrInsPolicyMdl.IsRenewal = Convert.ToBoolean(_tblSqla.Rows[i]["IsRenewal"]);

                           _MtrInsPolicyMdl.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]));

                           _MtrInsPolicyMdl.IsValidTxn = true;

                            _MtrInsPolicyMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["ParentTxnSysID"]);
                            _MtrInsPolicyMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                            _MtrInsPolicyMdl.ParticipantValue = Convert.ToDecimal(_tblSqla.Rows[i]["ParticipantValue"]);
                  

                            _MtrInsPolicyMdl.IsValidTxn = true;

                            _MtrInsPolicyMdlList.Add(_MtrInsPolicyMdl);


                        }

                        return _MtrInsPolicyMdlList;
                    }

                    else
                    {
                        return null;
                    }

                }

                //For Already Renewed
                else 
                if (_MtrInsPolicyMdl1.RenewalType == 1)
                {

                    SqlConnection _conSql1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    string _sqlString1 = "SELECT ip.ParentTxnSysID,ip.CertInsureCode,ip.DocNo , ip.DocString,mvd.ParticipantName,mvd.InsuranceTypeCode, mvd.ParticipantValue, mvd.TxnSysID, ip.TxnSysDate,ip.EffectiveDate,ip.ExpiryDate FROM InsPolicy ip  INNER JOIN MtrVehicleDetails mvd ON mvd.ParentTxnSysID = ip.ParentTxnSysID WHERE mvd.InsuranceTypeCode IN(1,2) AND ip.DocType IN(8) AND ip.IsActive = 1 AND ip.IsRenewal = 1 AND FORMAT(ip.EffectiveDate, 'd', 'en-US' ) = (SELECT SUBSTRING( '" + (_MtrInsPolicyMdl1.EffectiveDate) + "' , 0,10)) AND FORMAT(ip.ExpiryDate, 'd', 'en-US' ) = (SELECT SUBSTRING( '" + (_MtrInsPolicyMdl1.ExpiryDate) + "' , 0,10)) AND ip.ExpiryDate > '" + DateTime.Now.ToString() + "'";
                    //+ " WHERE  FORMAT(TxnSysDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + 
                    // "AND FORMAT(EffectiveDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + "AND FORMAT(ExpiryDate, 'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(), 'yyyy-MM-dd'))";
                    SqlDataAdapter _adpSql1 = new SqlDataAdapter(_sqlString1, _conSql1);
                    DataTable _tblSqla1 = new DataTable();
                    List<MtrInsPolicyMdl> _MtrInsPolicyMdlList1 = new List<MtrInsPolicyMdl>();
                    MtrInsPolicyMdl _MtrInsPolicyMdl2;

                    _adpSql1.Fill(_tblSqla1);

                    if (_tblSqla1.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla1.Rows.Count; i++)
                        {
                            _MtrInsPolicyMdl2 = new MtrInsPolicyMdl();

                            _MtrInsPolicyMdl2.TxnSysDate = Convert.ToDateTime(_tblSqla1.Rows[i]["TxnSysDate"]);
                            _MtrInsPolicyMdl2.CertString = _tblSqla1.Rows[i]["DocString"].ToString();
                            _MtrInsPolicyMdl2.CertNo = Convert.ToInt32(_tblSqla1.Rows[i]["DocNo"]);
                            _MtrInsPolicyMdl2.EffectiveDate = Convert.ToDateTime(_tblSqla1.Rows[i]["EffectiveDate"]);
                            _MtrInsPolicyMdl2.ExpiryDate = Convert.ToDateTime(_tblSqla1.Rows[i]["ExpiryDate"]);
                            _MtrInsPolicyMdl2.ParticipantName = _tblSqla1.Rows[i]["ParticipantName"].ToString();
                            _MtrInsPolicyMdl2.InsuranceTypeCode = Convert.ToInt32(_tblSqla1.Rows[i]["InsuranceTypeCode"]);

                            _MtrInsPolicyMdl2.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla1.Rows[i]["InsuranceTypeCode"]));

                            _MtrInsPolicyMdl2.IsValidTxn = true;

                            _MtrInsPolicyMdl2.ParentTxnSysID = Convert.ToInt32(_tblSqla1.Rows[i]["ParentTxnSysID"]);
                            _MtrInsPolicyMdl2.TxnSysID = Convert.ToInt32(_tblSqla1.Rows[i]["TxnSysID"]);
                            _MtrInsPolicyMdl2.ParticipantValue = Convert.ToDecimal(_tblSqla1.Rows[i]["ParticipantValue"]);


                            _MtrInsPolicyMdlList1.Add(_MtrInsPolicyMdl2);


                        }


                        return _MtrInsPolicyMdlList1;
                    }

                    else
                    {
                        return null;
                    }

                }

                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Renewal DataLayer");
                return null;
            }
        }

     //--------- Important --------------//

        //To make Renewal
        public MtrInsPolicyMdl ToPassRenewal(MtrInsPolicyMdl _MtrInsPolicyMdl1)
        {
            try
            {
                //Get Values from Ins Policy
                DataTable _tblSqla = new DataTable();
                List<MtrInsPolicyMdl> _MtrInsPolicyMdlList = new List<MtrInsPolicyMdl>();
                MtrInsPolicyMdl _MtrInsPolicyMdl = new MtrInsPolicyMdl();

                int InsuranceType = 0;

                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM InsPolicy WHERE  ParentTxnSysID= @ParentTxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrInsPolicyMdl = new MtrInsPolicyMdl();

                        _MtrInsPolicyMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["ParentTxnSysID"]);
                        _MtrInsPolicyMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrInsPolicyMdl.CertMonth = _tblSqla.Rows[i]["DocMonth"].ToString();
                        _MtrInsPolicyMdl.CertString = _tblSqla.Rows[i]["DocString"].ToString();
                        _MtrInsPolicyMdl.CertYear = _tblSqla.Rows[i]["DocYear"].ToString();
                        _MtrInsPolicyMdl.CertNo = Convert.ToInt32(_tblSqla.Rows[i]["DocNo"]);
                        _MtrInsPolicyMdl.DocType = _tblSqla.Rows[i]["DocType"].ToString();
                        _MtrInsPolicyMdl.GenerateAgainst = _tblSqla.Rows[i]["GenerateAgainst"].ToString();
                        _MtrInsPolicyMdl.ProductCode = Convert.ToInt32(_tblSqla.Rows[i]["ProductCode"]);
                        _MtrInsPolicyMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();
                        _MtrInsPolicyMdl.ClientCode = _tblSqla.Rows[i]["ClientCode"].ToString();
                        _MtrInsPolicyMdl.AgencyCode = _tblSqla.Rows[i]["AgencyCode"].ToString();
                        _MtrInsPolicyMdl.CertInsureCode = _tblSqla.Rows[i]["CertInsureCode"].ToString();
                        _MtrInsPolicyMdl.Remarks = _tblSqla.Rows[i]["Remarks"].ToString();
                        _MtrInsPolicyMdl.BrchCoverNoteNo = _tblSqla.Rows[i]["BrchCoverNoteNo"].ToString();
                        _MtrInsPolicyMdl.LeaderPolicyNo = _tblSqla.Rows[i]["LeaderPolicyNo"].ToString();
                        _MtrInsPolicyMdl.LeaderEndNo = _tblSqla.Rows[i]["LeaderEndNo"].ToString();
                        _MtrInsPolicyMdl.IsFiler = _tblSqla.Rows[i]["IsFiler"].ToString();
                        _MtrInsPolicyMdl.CalcType = _tblSqla.Rows[i]["CalcType"].ToString();
                        _MtrInsPolicyMdl.IsAuto = _tblSqla.Rows[i]["IsAuto"].ToString();
                        _MtrInsPolicyMdl.EffectiveDate = Convert.ToDateTime(_tblSqla.Rows[i]["EffectiveDate"]);
                        _MtrInsPolicyMdl.ExpiryDate = Convert.ToDateTime(_tblSqla.Rows[i]["ExpiryDate"]);
                        _MtrInsPolicyMdl.SerialNo = Convert.ToInt32(_tblSqla.Rows[i]["SerialNo"]);
                        _MtrInsPolicyMdl.UWYear = _tblSqla.Rows[i]["UWYear"].ToString();
                        _MtrInsPolicyMdl.CreatedBy = _tblSqla.Rows[i]["CreatedBy"].ToString();
                        _MtrInsPolicyMdl.PostedBy = _tblSqla.Rows[i]["PostedBy"].ToString();
                        _MtrInsPolicyMdl.IsPosted = Convert.ToBoolean(_tblSqla.Rows[i]["IsPosted"]);
                        //_MtrInsPolicyMdl.PostDate = Convert.ToDateTime(_tblSqla.Rows[i]["PostDate"]);
                        _MtrInsPolicyMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["OpolTxnSysID"]);
                        _MtrInsPolicyMdl.RenewSysID = Convert.ToInt32(_tblSqla.Rows[i]["RenewSysID"]);
                      _MtrInsPolicyMdl.PolSysID = Convert.ToInt32(_tblSqla.Rows[i]["PolSysID"]);
                        _MtrInsPolicyMdl.IsRenewal = Convert.ToBoolean(_tblSqla.Rows[i]["IsRenewal"]);
                        _MtrInsPolicyMdl.CommisionRate = Convert.ToDecimal(_tblSqla.Rows[i]["CommisionRate"]);
                        _MtrInsPolicyMdl.IsActive = Convert.ToBoolean(_tblSqla.Rows[i]["IsActive"]);

                        _MtrInsPolicyMdl.IsValidTxn = true;


                        _MtrInsPolicyMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(_tblSqla.Rows[i]["ProductCode"].ToString());
                        _MtrInsPolicyMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_tblSqla.Rows[i]["PolicyTypeCode"].ToString());
                        _MtrInsPolicyMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_tblSqla.Rows[i]["ClientCode"].ToString());
                        _MtrInsPolicyMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_tblSqla.Rows[i]["AgencyCode"].ToString());
                        _MtrInsPolicyMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_tblSqla.Rows[i]["CertInsureCode"].ToString());

                        _MtrInsPolicyMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(_tblSqla.Rows[i]["DocType"].ToString());
                        _MtrInsPolicyMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_tblSqla.Rows[i]["IsFiler"].ToString());
                        _MtrInsPolicyMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_tblSqla.Rows[i]["CalcType"].ToString());
                        _MtrInsPolicyMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_tblSqla.Rows[i]["IsAuto"].ToString());


                        _MtrInsPolicyMdl.IsValidTxn = true;

                        _MtrInsPolicyMdlList.Add(_MtrInsPolicyMdl);


                    }

                    ////Update Is Active to False in Ins Policy
                    //SqlConnection _conSqlA = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    //StringBuilder _sbSqlA = new StringBuilder();
                    //SqlCommand _cmdSqlA;
                    //_sbSqlA.AppendLine("Update  InsPolicy  SET");
                    //_sbSqlA.AppendLine("IsActive=@IsActive");
                    //_sbSqlA.AppendLine("WHERE ParentTxnSysID=@ParentTxnSysID ");
                    //_cmdSqlA = new SqlCommand(_sbSqlA.ToString(), _conSqlA);
                    //_cmdSqlA.Parameters.AddWithValue("@IsActive", false);
                    //_cmdSqlA.Parameters.AddWithValue("@ParentTxnSysID",_MtrInsPolicyMdl1.ParentTxnSysID);
                    //_conSqlA.Open();
                    //_cmdSqlA.ExecuteNonQuery();
                    //_conSqlA.Close();

                    //To Insert in to InsPolicy for Renewal
                    SqlConnection _conSql2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql2 = new StringBuilder();
                    SqlCommand _cmdSql2;
                    MtrInsPolicyMdl _MtrInsPolicyMdl2 = new MtrInsPolicyMdl();
                    int _SerialNumber = GetSerialNo(_MtrInsPolicyMdl2);


                    _sbSql2.AppendLine("INSERT INTO InsPolicy(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql2.AppendLine("TxnSysDate,");
                    _sbSql2.AppendLine("DocMonth,");
                    _sbSql2.AppendLine("DocString,");
                    _sbSql2.AppendLine("DocYear,");
                    _sbSql2.AppendLine("DocNo,");
                    _sbSql2.AppendLine("DocType,");
                    _sbSql2.AppendLine("GenerateAgainst,");
                    _sbSql2.AppendLine("ProductCode,");
                    _sbSql2.AppendLine("PolicyTypeCode,");
                    _sbSql2.AppendLine("ClientCode,");
                    _sbSql2.AppendLine("AgencyCode,");
                    _sbSql2.AppendLine("CertInsureCode,");
                    _sbSql2.AppendLine("Remarks,");
                    _sbSql2.AppendLine("BrchCoverNoteNo,");
                    _sbSql2.AppendLine("LeaderPolicyNo,");
                    _sbSql2.AppendLine("LeaderEndNo,");
                    _sbSql2.AppendLine("IsFiler,");
                    _sbSql2.AppendLine("CalcType,");
                    _sbSql2.AppendLine("IsAuto,");
                    _sbSql2.AppendLine("EffectiveDate,");
                    _sbSql2.AppendLine("ExpiryDate,");
                    _sbSql2.AppendLine("SerialNo,");
                    _sbSql2.AppendLine("UWYear,");
                    _sbSql2.AppendLine("CreatedBy,");
                    _sbSql2.AppendLine("CommisionRate,");

                    _sbSql2.AppendLine("IsPosted,");
                    // _sbSql2.AppendLine("PostDate,");
                    _sbSql2.AppendLine("IsRenewal,");
                    _sbSql2.AppendLine("RenewSysID,");

                    _sbSql2.AppendLine("OpolTxnSysID)");




                    _sbSql2.AppendLine("output INSERTED. ParentTxnSysID VALUES ( ");

                    _sbSql2.AppendLine("@TxnSysDate,");
                    _sbSql2.AppendLine("@DocMonth,");
                    _sbSql2.AppendLine("@DocString,");
                    _sbSql2.AppendLine("@DocYear,");
                    _sbSql2.AppendLine("@DocNo,");
                    _sbSql2.AppendLine("@DocType,");
                    _sbSql2.AppendLine("@GenerateAgainst,");
                    _sbSql2.AppendLine("@ProductCode,");
                    _sbSql2.AppendLine("@PolicyTypeCode,");
                    _sbSql2.AppendLine("@ClientCode,");
                    _sbSql2.AppendLine("@AgencyCode,");
                    _sbSql2.AppendLine("@CertInsureCode,");
                    _sbSql2.AppendLine("@Remarks,");
                    _sbSql2.AppendLine("@BrchCoverNoteNo,");
                    _sbSql2.AppendLine("@LeaderPolicyNo,");
                    _sbSql2.AppendLine("@LeaderEndNo,");
                    _sbSql2.AppendLine("@IsFiler,");
                    _sbSql2.AppendLine("@CalcType,");
                    _sbSql2.AppendLine("@IsAuto,");
                    _sbSql2.AppendLine("@EffectiveDate,");
                    _sbSql2.AppendLine("(DATEADD(DAY, 365, @ExpiryDate)),");
                    _sbSql2.AppendLine("@SerialNo,");
                    _sbSql2.AppendLine("@UWYear,");
                    _sbSql2.AppendLine("@CreatedBy,");
                    _sbSql2.AppendLine("@CommisionRate,");
                    _sbSql2.AppendLine("@IsPosted,");
                    // _sbSql2.AppendLine("@PostDate,");
                    _sbSql2.AppendLine("@IsRenewal,");
                    _sbSql2.AppendLine("@RenewSysID,");
                    _sbSql2.AppendLine("@OpolTxnSysID)");



                    _cmdSql2 = new SqlCommand(_sbSql2.ToString(), _conSql2);
                    // DateTime da = DateTime.Now;
                    //  da.ToString("MM-dd-yyyy h:mm tt");
                    _cmdSql2.Parameters.AddWithValue("@TxnSysDate", SqlDbType.DateTime).Value = DateTime.Now;


                    _cmdSql2.Parameters.AddWithValue("@DocMonth", _MtrInsPolicyMdl.CertMonth);
                    _cmdSql2.Parameters.AddWithValue("@RenewSysID", _MtrInsPolicyMdl.ParentTxnSysID);

                    _cmdSql2.Parameters.AddWithValue("@DocYear", _MtrInsPolicyMdl.CertYear);

                    _cmdSql2.Parameters.AddWithValue("@DocNo", _MtrInsPolicyMdl.CertNo);

                    string OpenPolicyDoc = "8";

                    _cmdSql2.Parameters.AddWithValue("@DocType", OpenPolicyDoc);


                    string CertString = GetCertString(
                        _MtrInsPolicyMdl.BrchCoverNoteNo,
                        _MtrInsPolicyMdl.CertInsureCode.ToString(),
                        OpenPolicyDoc,
                        Convert.ToInt32(_MtrInsPolicyMdl.PolicyTypeCode),
                        _SerialNumber,
                       DateTime.Now.Month.ToString(),
                           DateTime.Now.Year.ToString());




                    _cmdSql2.Parameters.AddWithValue("@DocString", CertString);

                    _cmdSql2.Parameters.AddWithValue("@GenerateAgainst", _MtrInsPolicyMdl.ParentTxnSysID);
                    _cmdSql2.Parameters.AddWithValue("@ProductCode", _MtrInsPolicyMdl.ProductCode);
                    _cmdSql2.Parameters.AddWithValue("@PolicyTypeCode", _MtrInsPolicyMdl.PolicyTypeCode);
                    _cmdSql2.Parameters.AddWithValue("@ClientCode", _MtrInsPolicyMdl.ClientCode);
                    _cmdSql2.Parameters.AddWithValue("@AgencyCode", _MtrInsPolicyMdl.AgencyCode);
                    _cmdSql2.Parameters.AddWithValue("@CertInsureCode", _MtrInsPolicyMdl.CertInsureCode);

                    //Remarks for Addition
                    _cmdSql2.Parameters.AddWithValue("@Remarks", _MtrInsPolicyMdl.Remarks ?? DBNull.Value.ToString());

                    _cmdSql2.Parameters.AddWithValue("@BrchCoverNoteNo", _MtrInsPolicyMdl.BrchCoverNoteNo);
                    _cmdSql2.Parameters.AddWithValue("@LeaderPolicyNo", _MtrInsPolicyMdl.LeaderPolicyNo);
                    _cmdSql2.Parameters.AddWithValue("@LeaderEndNo", _MtrInsPolicyMdl.LeaderEndNo);
                    _cmdSql2.Parameters.AddWithValue("@IsFiler", _MtrInsPolicyMdl.IsFiler);
                    _cmdSql2.Parameters.AddWithValue("@CalcType", _MtrInsPolicyMdl.CalcType);
                    _cmdSql2.Parameters.AddWithValue("@IsAuto", _MtrInsPolicyMdl.IsAuto);
                    _cmdSql2.Parameters.AddWithValue("@EffectiveDate", Convert.ToDateTime(_MtrInsPolicyMdl.EffectiveDate.ToString()));
                    _cmdSql2.Parameters.AddWithValue("@ExpiryDate", Convert.ToDateTime(_MtrInsPolicyMdl.ExpiryDate.ToString()));
                    _cmdSql2.Parameters.AddWithValue("@SerialNo", _SerialNumber);
                    _cmdSql2.Parameters.AddWithValue("@UWYear", _MtrInsPolicyMdl.UWYear);
                    _cmdSql2.Parameters.AddWithValue("@CommisionRate", _MtrInsPolicyMdl.CommisionRate);

                    _cmdSql2.Parameters.AddWithValue("@CreatedBy", _MtrInsPolicyMdl.CreatedBy);

                    _cmdSql2.Parameters.AddWithValue("@IsPosted", _MtrInsPolicyMdl.IsPosted);
                    // _cmdSql2.Parameters.AddWithValue("@PostDate", _MtrInsPolicyMdl.PostDate);
                    _cmdSql2.Parameters.AddWithValue("@OpolTxnSysID", _MtrInsPolicyMdl.OpolTxnSysID);
                    _cmdSql2.Parameters.AddWithValue("@IsRenewal", Convert.ToBoolean(true));

                    _MtrInsPolicyMdl.CertString = _MtrInsPolicyMdl.CertString;
                    _MtrInsPolicyMdl.SerialNo = _SerialNumber;
                    // _MtrInsPolicyMdl.TxnSysDate = DateTime.Now;


                    int _TxnSysId;
                    _conSql2.Open();
                    _TxnSysId = (Int32)_cmdSql2.ExecuteScalar();
                    _conSql2.Close();
                    _MtrInsPolicyMdl2.IsValidTxn = true;

                    _MtrInsPolicyMdl2.ParentTxnSysID = _TxnSysId;

                    _MtrInsPolicyMdl2.ProductName = GlobalDataLayer.GetProductNameByProductCode(_MtrInsPolicyMdl.ProductCode.ToString());
                    _MtrInsPolicyMdl2.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_MtrInsPolicyMdl.PolicyTypeCode.ToString());
                    _MtrInsPolicyMdl2.ClientName = GlobalDataLayer.GetClientNameByClientCode(_MtrInsPolicyMdl.ClientCode.ToString());
                    _MtrInsPolicyMdl2.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_MtrInsPolicyMdl.AgencyCode.ToString());
                    _MtrInsPolicyMdl2.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_MtrInsPolicyMdl.CertInsureCode.ToString());

                    string OpenPolicyDoc1 = "8";
                    _MtrInsPolicyMdl2.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(OpenPolicyDoc1);
                    _MtrInsPolicyMdl2.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_MtrInsPolicyMdl.IsFiler.ToString());
                    _MtrInsPolicyMdl2.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_MtrInsPolicyMdl.CalcType.ToString());
                    _MtrInsPolicyMdl2.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_MtrInsPolicyMdl.IsAuto.ToString());

                    _MtrInsPolicyMdl2.IsValidTxn = true;
                    _MtrInsPolicyMdl2.DocType = OpenPolicyDoc1;

                    //----------------For Ins Tracker-----------------//

                    //Get Values From InsTracker
                    SqlConnection _conSql3 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());

                    DataTable _tblSqla3 = new DataTable();
                    List<MtrInsTrackerMdl> _MtrInsTrackerMdlList1 = new List<MtrInsTrackerMdl>();
                    MtrInsTrackerMdl _MtrInsTrackerMdl1 = new MtrInsTrackerMdl();


                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM InsMtrTracker WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                        command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                        SqlDataAdapter _adpSql3 = new SqlDataAdapter(command);


                        _adpSql3.Fill(_tblSqla3);
                    }

                    if (_tblSqla3.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla3.Rows.Count; i++)
                        {
                            _MtrInsTrackerMdl1 = new MtrInsTrackerMdl();

                            _MtrInsTrackerMdl1.TxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["TxnSysID"]);
                            _MtrInsTrackerMdl1.UserCode = Convert.ToInt32(_tblSqla3.Rows[i]["UserCode"]);
                            _MtrInsTrackerMdl1.TrackerCode = Convert.ToInt32(_tblSqla3.Rows[i]["TrackerCode"]);
                            _MtrInsTrackerMdl1.TrackerName = _tblSqla3.Rows[i]["TrackerName"].ToString();
                            _MtrInsTrackerMdl1.TrackerRate = Convert.ToInt32(_tblSqla3.Rows[i]["TrackerRate"]);
                            _MtrInsTrackerMdl1.ParentTxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["ParentTxnSysID"]);



                            _MtrInsTrackerMdl1.IsValidTxn = true;

                            _MtrInsTrackerMdlList1.Add(_MtrInsTrackerMdl1);
                        }

                        //Insert In to InsTracker For Renewal
                        SqlConnection _conSql7 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql7 = new StringBuilder();
                        SqlCommand _cmdSql7;


                        MtrInsTrackerMdl[] TrackerArray = _MtrInsTrackerMdlList1.ToArray();

                        for (int j = 0; j < TrackerArray.Length; j++)
                        {
                            _sbSql7 = new StringBuilder();

                            _sbSql7.AppendLine("INSERT INTO InsMtrTracker(");

                            _sbSql7.AppendLine("UserCode,");
                            _sbSql7.AppendLine("TrackerCode,");
                            _sbSql7.AppendLine("TrackerName,");
                            _sbSql7.AppendLine("TrackerRate,");
                            _sbSql7.AppendLine("ParentTxnSysID)");


                            _sbSql7.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                            _sbSql7.AppendLine("@UserCode,");
                            _sbSql7.AppendLine("@TrackerCode,");
                            _sbSql7.AppendLine("@TrackerName,");
                            _sbSql7.AppendLine("@TrackerRate,");
                            _sbSql7.AppendLine("(SELECT MAX(ip.ParentTxnSysID) FROM InsPolicy ip))");


                            _cmdSql7 = new SqlCommand(_sbSql7.ToString(), _conSql7);
                            int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsTrackerMdl1.UserCode);
                            _cmdSql7.Parameters.AddWithValue("@UserCode", _userCode);
                            _cmdSql7.Parameters.AddWithValue("@TrackerCode", TrackerArray[j].TrackerCode);
                            _cmdSql7.Parameters.AddWithValue("@TrackerName", TrackerArray[j].TrackerName);
                            _cmdSql7.Parameters.AddWithValue("@TrackerRate", TrackerArray[j].TrackerRate);
                          //  _cmdSql7.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsTrackerMdl1.ParentTxnSysID);


                            int _TxnSysId1;
                            _conSql7.Open();
                            _TxnSysId1 = (Int32)_cmdSql7.ExecuteScalar();
                            _conSql7.Close();
                        }

                    }
                    else
                    {

                    }

                    //----------------For Ins Tracker-----------------//

                    //----------------For Ins Rider-----------------//

                    //Get Values From InsRider
                    SqlConnection _conSql4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    DataTable _tblSqla4 = new DataTable();
                    List<MtrInsRiderMdl> _MtrInsRiderMdlList1 = new List<MtrInsRiderMdl>();
                    MtrInsRiderMdl _MtrInsRiderMdl1 = new MtrInsRiderMdl();


                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM InsMtrRider WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                        command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                        SqlDataAdapter _adpSql4 = new SqlDataAdapter(command);


                        _adpSql4.Fill(_tblSqla4);
                    }


                    if (_tblSqla4.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla4.Rows.Count; i++)
                        {
                            _MtrInsRiderMdl1 = new MtrInsRiderMdl();

                            _MtrInsRiderMdl1.TxnSysID = Convert.ToInt32(_tblSqla4.Rows[i]["TxnSysID"]);
                            _MtrInsRiderMdl1.TxnSysDate = Convert.ToDateTime(_tblSqla4.Rows[i]["TxnSysDate"]);
                            _MtrInsRiderMdl1.UserCode = Convert.ToInt32(_tblSqla4.Rows[i]["UserCode"]);
                            _MtrInsRiderMdl1.RiderCode = Convert.ToInt32(_tblSqla4.Rows[i]["RiderCode"]);
                            _MtrInsRiderMdl1.RiderName = _tblSqla4.Rows[i]["RiderName"].ToString();
                            _MtrInsRiderMdl1.RiderRate = Convert.ToInt32(_tblSqla4.Rows[i]["RiderRate"]);
                            _MtrInsRiderMdl1.ParentTxnSysID = Convert.ToInt32(_tblSqla4.Rows[i]["ParentTxnSysID"]);




                            _MtrInsRiderMdl1.IsValidTxn = true;

                            _MtrInsRiderMdlList1.Add(_MtrInsRiderMdl1);
                        }


                        //Insert In To Ins Rider
                        SqlConnection _conSql8 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql8 = new StringBuilder();
                        SqlCommand _cmdSql8;


                        MtrInsRiderMdl[] RiderArray = _MtrInsRiderMdlList1.ToArray();

                        for (int j = 0; j < RiderArray.Length; j++)
                        {
                            _sbSql8 = new StringBuilder();

                            _sbSql8.AppendLine("INSERT INTO InsMtrRider(");
                            //_sbSql.AppendLine("TxnSysID,");
                            //_sbSql.AppendLine("TxnSysDate,");
                            _sbSql8.AppendLine("UserCode,");
                            _sbSql8.AppendLine("RiderCode,");
                            _sbSql8.AppendLine("RiderName,");
                            _sbSql8.AppendLine("RiderRate,");
                            _sbSql8.AppendLine("ParentTxnSysID)");



                            _sbSql8.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                            // _sbSql.AppendLine("@TxnSysID,");
                            //  _sbSql.AppendLine("@TxnSysDate,");
                            _sbSql8.AppendLine("@UserCode,");
                            _sbSql8.AppendLine("@RiderCode,");
                            _sbSql8.AppendLine("@RiderName,");
                            _sbSql8.AppendLine("@RiderRate,");
                            _sbSql8.AppendLine("(SELECT MAX(ip.ParentTxnSysID) FROM InsPolicy ip))");




                            _cmdSql8 = new SqlCommand(_sbSql8.ToString(), _conSql8);
                            int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsRiderMdl1.UserCode);
                            _cmdSql8.Parameters.AddWithValue("@UserCode", _userCode);
                            _cmdSql8.Parameters.AddWithValue("@RiderCode", RiderArray[j].RiderCode);
                            _cmdSql8.Parameters.AddWithValue("@RiderName", RiderArray[j].RiderName);
                            _cmdSql8.Parameters.AddWithValue("@RiderRate", RiderArray[j].RiderRate);
                           // _cmdSql8.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsRiderMdl1.ParentTxnSysID);


                            int _TxnSysId2;
                            _conSql8.Open();
                            _TxnSysId2 = (Int32)_cmdSql8.ExecuteScalar();
                            _conSql8.Close();

                        }

                    }
                    else
                    {

                    }

                    //----------------For Ins Rider-----------------//

                    //----------------For Ins Conditions-----------------//

                    //Get Values From Ins Conditions
                    SqlConnection _conSql5 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    DataTable _tblSqla5 = new DataTable();
                    List<MtrInsConditionsMdl> _MtrInsConditionsMdlList1 = new List<MtrInsConditionsMdl>();
                    MtrInsConditionsMdl _MtrInsConditionsMdl1;


                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM InsMtrConditions WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                        command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                        SqlDataAdapter _adpSql5 = new SqlDataAdapter(command);


                        _adpSql5.Fill(_tblSqla5);
                    }


                    if (_tblSqla5.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla5.Rows.Count; i++)
                        {
                            _MtrInsConditionsMdl1 = new MtrInsConditionsMdl();

                            _MtrInsConditionsMdl1.TxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["TxnSysID"]);
                            _MtrInsConditionsMdl1.TxnSysDate = Convert.ToDateTime(_tblSqla5.Rows[i]["TxnSysDate"]);
                            _MtrInsConditionsMdl1.UserCode = Convert.ToInt32(_tblSqla5.Rows[i]["UserCode"]);
                            _MtrInsConditionsMdl1.ParentTxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["ParentTxnSysID"]);
                            _MtrInsConditionsMdl1.Condition = _tblSqla5.Rows[i]["Condition"].ToString();

                            _MtrInsConditionsMdl1.ConditionShText = GlobalDataLayer.GetConditionByCode(_tblSqla5.Rows[i]["Condition"].ToString());



                            _MtrInsConditionsMdl1.IsValidTxn = true;

                            _MtrInsConditionsMdlList1.Add(_MtrInsConditionsMdl1);
                        }

                        //Insert Into Ins Conditions
                        SqlConnection _conSql9 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql9 = new StringBuilder();
                        SqlCommand _cmdSql9;


                        MtrInsConditionsMdl[] ConditionsArray = _MtrInsConditionsMdlList1.ToArray();

                        for (int j = 0; j < ConditionsArray.Length; j++)
                        {
                            _sbSql9 = new StringBuilder();

                            _sbSql9.AppendLine("INSERT INTO InsMtrConditions(");
                            _sbSql9.AppendLine("ParentTxnSysID,");
                            _sbSql9.AppendLine("Condition)");

                            _sbSql9.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                            _sbSql9.AppendLine("(SELECT MAX(ip.ParentTxnSysID) FROM InsPolicy ip),");
                            _sbSql9.AppendLine("@Condition)");

                            _cmdSql9 = new SqlCommand(_sbSql9.ToString(), _conSql9);

                            //_cmdSql9.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsRiderMdl1.ParentTxnSysID);
                            _cmdSql9.Parameters.AddWithValue("@Condition", ConditionsArray[j].Condition.ToString());

                            int _TxnSysId3;
                            _conSql9.Open();
                            _TxnSysId3 = (Int32)_cmdSql9.ExecuteScalar();
                            _conSql9.Close();
                        }

                    }
                    else
                    {

                    }

                    //----------------For Ins Conditions-----------------//

                    //----------------For Ins Warranties-----------------//

                    //Get Values From InsWarranties
                    SqlConnection _conSql6 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    DataTable _tblSqla6 = new DataTable();
                    List<MtrInsWarrantiesMdl> _MtrInsWarrantiesMdlList1 = new List<MtrInsWarrantiesMdl>();
                    MtrInsWarrantiesMdl _MtrInsWarrantiesMdl1;


                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM InsMtrWarranties WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                        command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                        SqlDataAdapter _adpSql6 = new SqlDataAdapter(command);


                        _adpSql6.Fill(_tblSqla6);
                    }


                    //  _adpSql.Fill(_tbl);

                    if (_tblSqla6.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla6.Rows.Count; i++)
                        {
                            _MtrInsWarrantiesMdl1 = new MtrInsWarrantiesMdl();

                            _MtrInsWarrantiesMdl1.TxnSysID = Convert.ToInt32(_tblSqla6.Rows[i]["TxnSysID"]);
                            _MtrInsWarrantiesMdl1.TxnSysDate = Convert.ToDateTime(_tblSqla6.Rows[i]["TxnSysDate"]);
                            _MtrInsWarrantiesMdl1.UserCode = Convert.ToInt32(_tblSqla6.Rows[i]["UserCode"]);
                            _MtrInsWarrantiesMdl1.Warranty = _tblSqla6.Rows[i]["Warranty"].ToString();
                            _MtrInsWarrantiesMdl1.ParentTxnSysID = Convert.ToInt32(_tblSqla6.Rows[i]["ParentTxnSysID"]);

                            _MtrInsWarrantiesMdl1.WarrantyShText = GlobalDataLayer.GetWarrantyTextByCode(_tblSqla6.Rows[i]["Warranty"].ToString());




                            _MtrInsWarrantiesMdl1.IsValidTxn = true;

                            _MtrInsWarrantiesMdlList1.Add(_MtrInsWarrantiesMdl1);
                        }

                        //Insert In To InsWarranties
                        SqlConnection _conSql10 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql10 = new StringBuilder();
                        SqlCommand _cmdSql10;



                      //  _cmdSql10 = new SqlCommand(_sbSql10.ToString(), _conSql10);

                        MtrInsWarrantiesMdl[] WarrantyArray = _MtrInsWarrantiesMdlList1.ToArray();

                        for (int j = 0; j < WarrantyArray.Length; j++)
                        {
                            _sbSql10 = new StringBuilder();

                            _sbSql10.AppendLine("INSERT INTO InsMtrWarranties(");
                            _sbSql10.AppendLine("ParentTxnSysID,");
                            _sbSql10.AppendLine("Warranty)");

                            _sbSql10.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                            _sbSql10.AppendLine("(SELECT MAX(ip.ParentTxnSysID) FROM InsPolicy ip),");
                            _sbSql10.AppendLine("@Warranty)");

                            _cmdSql10 = new SqlCommand(_sbSql10.ToString(), _conSql10);

                          //  _cmdSql10.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsRiderMdl1.ParentTxnSysID);
                            _cmdSql10.Parameters.AddWithValue("@Warranty", WarrantyArray[j].Warranty.ToString());

                            int _TxnSysId4;
                            _conSql10.Open();
                            _TxnSysId4 = (Int32)_cmdSql10.ExecuteScalar();
                            _conSql10.Close();
                        }

                    }
                    else
                    {

                    }

                    //----------------For Ins Warranties-----------------//

                    //----------------For Vehicle Details-----------------//

                    //Get Values From Vehicle Details
                    SqlConnection _conSql11 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    string _sqlString11 = "SELECT * FROM MtrVehicleDetails mvd WHERE mvd.ParentTxnSysID =  " + _MtrInsPolicyMdl1.ParentTxnSysID;

                    SqlDataAdapter _adpSql11 = new SqlDataAdapter(_sqlString11, _conSql11);
                    DataTable _tblSqla11 = new DataTable();
                    List<VehicleDetailMdl> _VehicleDetailMdlList1 = new List<VehicleDetailMdl>();
                    VehicleDetailMdl _VehicleDetailMdl1 = new VehicleDetailMdl();

                    _adpSql11.Fill(_tblSqla11);

                    if (_tblSqla11.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla11.Rows.Count; i++)
                        {

                            _VehicleDetailMdl1 = new VehicleDetailMdl();

                            _VehicleDetailMdl1.TxnSysID = Convert.ToInt32(_tblSqla11.Rows[i]["TxnSysID"]);
                            _VehicleDetailMdl1.TxnSysDate = Convert.ToDateTime(_tblSqla11.Rows[i]["TxnSysDate"]);
                            _VehicleDetailMdl1.UserCode = Convert.ToInt32(_tblSqla11.Rows[i]["UserCode"]);
                            _VehicleDetailMdl1.SerialNo = Convert.ToInt32(_tblSqla11.Rows[i]["SerialNo"].ToString());
                            _VehicleDetailMdl1.VehicleCode = Convert.ToInt32(_tblSqla11.Rows[i]["VehicleCode"].ToString());
                            _VehicleDetailMdl1.VehicleModel = Convert.ToInt32(_tblSqla11.Rows[i]["VehicleModel"].ToString());
                            _VehicleDetailMdl1.UpdatedValue = Convert.ToDecimal(_tblSqla11.Rows[i]["UpdatedValue"]);
                            _VehicleDetailMdl1.PreviousValue = Convert.ToDecimal(_tblSqla11.Rows[i]["PreviousValue"]);
                            _VehicleDetailMdl1.Mileage = Convert.ToInt32(_tblSqla11.Rows[i]["Mileage"].ToString());
                            _VehicleDetailMdl1.ParticipantValue = Convert.ToDecimal(_tblSqla11.Rows[i]["ParticipantValue"]);
                            _VehicleDetailMdl1.ColorCode = Convert.ToInt32(_tblSqla11.Rows[i]["ColorCode"].ToString());
                            _VehicleDetailMdl1.ParticipantName = _tblSqla11.Rows[i]["ParticipantName"].ToString();
                            _VehicleDetailMdl1.ParticipantAddress = _tblSqla11.Rows[i]["ParticipantAddress"].ToString();

                            _VehicleDetailMdl1.RegistrationNumber = _tblSqla11.Rows[i]["RegistrationNumber"].ToString();
                            _VehicleDetailMdl1.CityCode = _tblSqla11.Rows[i]["CityCode"].ToString();
                            _VehicleDetailMdl1.EngineNumber = _tblSqla11.Rows[i]["EngineNumber"].ToString();
                            _VehicleDetailMdl1.AreaCode = Convert.ToInt32(_tblSqla11.Rows[i]["AreaCode"].ToString());
                            _VehicleDetailMdl1.ChasisNumber = _tblSqla11.Rows[i]["ChasisNumber"].ToString();
                            _VehicleDetailMdl1.Remarks = _tblSqla11.Rows[i]["Remarks"].ToString();
                            _VehicleDetailMdl1.PODate = Convert.ToDateTime(_tblSqla11.Rows[i]["PODate"]);
                            _VehicleDetailMdl1.PONumber = (_tblSqla11.Rows[i]["PONumber"].ToString() ?? DBNull.Value.ToString());
                            _VehicleDetailMdl1.CNICNumber = _tblSqla11.Rows[i]["CNICNumber"].ToString();
                            _VehicleDetailMdl1.Tenure = _tblSqla11.Rows[i]["Tenure"].ToString();
                            _VehicleDetailMdl1.BirthDate = Convert.ToDateTime(_tblSqla11.Rows[i]["BirthDate"]);
                            _VehicleDetailMdl1.Gender = _tblSqla11.Rows[i]["Gender"].ToString();
                            _VehicleDetailMdl1.VehicleType = _tblSqla11.Rows[i]["VehicleType"].ToString();
                            _VehicleDetailMdl1.VEODCode = Convert.ToInt32(_tblSqla11.Rows[i]["VEODCode"]);
                            _VehicleDetailMdl1.CertTypeCode = _tblSqla11.Rows[i]["CertTypeCode"].ToString();
                            _VehicleDetailMdl1.Rate = Convert.ToInt32(_tblSqla11.Rows[i]["Rate"]);
                            _VehicleDetailMdl1.Contribution = Convert.ToInt32(_tblSqla11.Rows[i]["Contribution"]);
                            _VehicleDetailMdl1.ParentTxnSysID = Convert.ToInt32(_tblSqla11.Rows[i]["ParentTxnSysID"]);
                            _VehicleDetailMdl1.OpolTxnSysID = Convert.ToInt32(_tblSqla11.Rows[i]["OpolTxnSysID"]);

                            _VehicleDetailMdl1.VEODName = GlobalDataLayer.GetVEODNameByCode(Convert.ToInt32(_tblSqla11.Rows[i]["VEODCode"]));
                            _VehicleDetailMdl1.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_tblSqla11.Rows[i]["VehicleType"].ToString() ?? DBNull.Value.ToString());

                            _VehicleDetailMdl1.RatingFactor = _tblSqla11.Rows[i]["RatingFactor"].ToString();
                            _VehicleDetailMdl1.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_tblSqla11.Rows[i]["RatingFactor"].ToString());

                            _VehicleDetailMdl1.InsuranceTypeCode = Convert.ToInt32(_tblSqla11.Rows[i]["InsuranceTypeCode"]);
                            _VehicleDetailMdl1.IsActive = Convert.ToBoolean(_tblSqla11.Rows[i]["IsActive"]);
                            _VehicleDetailMdl1.IsCanceled = Convert.ToBoolean(_tblSqla11.Rows[i]["IsCanceled"]);
                            _VehicleDetailMdl1.CommisionRate = Convert.ToDecimal(_tblSqla11.Rows[i]["CommisionRate"]);
                            _VehicleDetailMdl1.MobileNumber = _tblSqla11.Rows[i]["MobileNumber"].ToString() ?? DBNull.Value.ToString();
                            _VehicleDetailMdl1.ResNumber = _tblSqla11.Rows[i]["ResNumber"].ToString() ?? DBNull.Value.ToString();
                            _VehicleDetailMdl1.OfficeNumber = _tblSqla11.Rows[i]["OfficeNumber"].ToString() ?? DBNull.Value.ToString();

                            _VehicleDetailMdl1.EmailAddress = _tblSqla11.Rows[i]["EmailAddress"].ToString();
                            _VehicleDetailMdl1.Deductible = Convert.ToDecimal(_tblSqla11.Rows[i]["Deductible"]);

                            _VehicleDetailMdl1.ContractMatDate = Convert.ToDateTime(_tblSqla11.Rows[i]["ContractMatDate"]);


                            _VehicleDetailMdl1.GenderName = GlobalDataLayer.GetGenderNameByCode(_tblSqla11.Rows[i]["Gender"].ToString());
                            _VehicleDetailMdl1.CityName = GlobalDataLayer.GetCityNameByCode(_tblSqla11.Rows[i]["CityCode"].ToString());
                            _VehicleDetailMdl1.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(Convert.ToInt32(_tblSqla11.Rows[i]["ColorCode"].ToString()));
                            _VehicleDetailMdl1.VehicleName = GlobalDataLayer.GetVehicleNameByCode(Convert.ToInt32(_tblSqla11.Rows[i]["VehicleCode"].ToString()));
                            _VehicleDetailMdl1.AreaName = GlobalDataLayer.GetAreaNameByCode(Convert.ToInt32(_tblSqla11.Rows[i]["AreaCode"].ToString()));
                            _VehicleDetailMdl1.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_tblSqla11.Rows[i]["CertTypeCode"].ToString());
                            _VehicleDetailMdl1.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla11.Rows[i]["InsuranceTypeCode"]));

                            _VehicleDetailMdl1.total = GlobalDataLayer.calculate(_VehicleDetailMdl1);


                            _VehicleDetailMdlList1.Add(_VehicleDetailMdl1);


                        }


                        //Update Is Active to False in Mtr Vehicle Details for Renewal
                        SqlConnection _conSqlB = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSqlB = new StringBuilder();
                        SqlCommand _cmdSqlB;

                        _sbSqlB.AppendLine("Update  MtrVehicleDetails  SET");
                        _sbSqlB.AppendLine("IsActive=@IsActive");
                        _sbSqlB.AppendLine("WHERE ParentTxnSysID=@ParentTxnSysID ");
                        _cmdSqlB = new SqlCommand(_sbSqlB.ToString(), _conSqlB);
                        _cmdSqlB.Parameters.AddWithValue("@IsActive", false);
                        _cmdSqlB.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID);
                        _conSqlB.Open();
                        _cmdSqlB.ExecuteNonQuery();
                        _conSqlB.Close();

                        //Insert Values To Vehicle Details For Renewal
                        SqlConnection _conSql12 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql12 = new StringBuilder();
                        SqlCommand _cmdSql12;
                        int _SerialNumber1 = GetSerialNo1(_VehicleDetailMdl1);


                        _sbSql12.AppendLine("INSERT INTO MtrVehicleDetails(");
                        // _sbSql.AppendLine("TxnSysID,");
                        _sbSql12.AppendLine("TxnSysDate,");
                        _sbSql12.AppendLine("UserCode,");
                        _sbSql12.AppendLine("SerialNo,");
                        _sbSql12.AppendLine("VehicleCode,");
                        _sbSql12.AppendLine("VehicleModel,");
                        _sbSql12.AppendLine("UpdatedValue,");
                        _sbSql12.AppendLine("PreviousValue,");
                        _sbSql12.AppendLine("Mileage,");
                        _sbSql12.AppendLine("ParticipantValue,");
                        _sbSql12.AppendLine("ColorCode,");
                        _sbSql12.AppendLine("ParticipantName,");
                        _sbSql12.AppendLine("ParticipantAddress,");
                        // _sbSql.AppendLine("ModelNumber,");
                        _sbSql12.AppendLine("RegistrationNumber,");
                        _sbSql12.AppendLine("CityCode,");
                        _sbSql12.AppendLine("EngineNumber,");
                        _sbSql12.AppendLine("AreaCode,");
                        _sbSql12.AppendLine("ChasisNumber,");
                        _sbSql12.AppendLine("Remarks,");
                        _sbSql12.AppendLine("PODate,");
                        _sbSql12.AppendLine("PONumber,");
                        _sbSql12.AppendLine("CNICNumber,");
                        _sbSql12.AppendLine("Tenure,");
                        _sbSql12.AppendLine("BirthDate,");
                        _sbSql12.AppendLine("Gender,");
                        _sbSql12.AppendLine("VehicleType,");
                        _sbSql12.AppendLine("VEODCode,");
                        _sbSql12.AppendLine("CertTypeCode,");
                        _sbSql12.AppendLine("Rate,");
                        _sbSql12.AppendLine("ParentTxnSysID,");
                        _sbSql12.AppendLine("OpolTxnSysID,");
                        _sbSql12.AppendLine("InsuranceTypeCode,");
                        _sbSql12.AppendLine("CommisionRate,");
                        _sbSql12.AppendLine("MobileNumber,");
                        _sbSql12.AppendLine("ResNumber,");
                        _sbSql12.AppendLine("OfficeNumber,");
                        _sbSql12.AppendLine("EmailAddress,");
                        _sbSql12.AppendLine("Deductible,");
                        _sbSql12.AppendLine("ContractMatDate,");
                        _sbSql12.AppendLine("RatingFactor,");
                        _sbSql12.AppendLine("Contribution)");


                        _sbSql12.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                        // _sbSql12.AppendLine("@TxnSysID,");
                        _sbSql12.AppendLine("@TxnSysDate,");
                        _sbSql12.AppendLine("@UserCode,");
                        _sbSql12.AppendLine("@SerialNo,");
                        _sbSql12.AppendLine("@VehicleCode,");
                        _sbSql12.AppendLine("@VehicleModel,");
                        _sbSql12.AppendLine("@UpdatedValue,");
                        _sbSql12.AppendLine("@PreviousValue,");
                        _sbSql12.AppendLine("@Mileage,");
                        _sbSql12.AppendLine("@ParticipantValue,");
                        _sbSql12.AppendLine("@ColorCode,");
                        _sbSql12.AppendLine("@ParticipantName,");
                        _sbSql12.AppendLine("@ParticipantAddress,");
                        // _sbSql12.AppendLine("@ModelNumber,");
                        _sbSql12.AppendLine("@RegistrationNumber,");
                        _sbSql12.AppendLine("@CityCode,");
                        _sbSql12.AppendLine("@EngineNumber,");
                        _sbSql12.AppendLine("@AreaCode,");
                        _sbSql12.AppendLine("@ChasisNumber,");
                        _sbSql12.AppendLine("@Remarks,");
                        _sbSql12.AppendLine("@PODate,");
                        _sbSql12.AppendLine("@PONumber,");
                        _sbSql12.AppendLine("@CNICNumber,");
                        _sbSql12.AppendLine("@Tenure,");
                        _sbSql12.AppendLine("@BirthDate,");
                        _sbSql12.AppendLine("@Gender,");
                        _sbSql12.AppendLine("@VehicleType,");
                        _sbSql12.AppendLine("@VEODCode,");
                        _sbSql12.AppendLine("@CertTypeCode,");
                        _sbSql12.AppendLine("@Rate,");
                        _sbSql12.AppendLine("(SELECT MAX(ip.ParentTxnSysID) FROM InsPolicy ip),");
                        _sbSql12.AppendLine("@OpolTxnSysID,");
                        _sbSql12.AppendLine("@InsuranceTypeCode,");
                        _sbSql12.AppendLine("@CommisionRate,");
                        _sbSql12.AppendLine("@MobileNumber,");
                        _sbSql12.AppendLine("@ResNumber,");
                        _sbSql12.AppendLine("@OfficeNumber,");
                        _sbSql12.AppendLine("@EmailAddress,");
                        _sbSql12.AppendLine("@Deductible,");
                        _sbSql12.AppendLine("@ContractMatDate,");
                        _sbSql12.AppendLine("@RatingFactor,");
                        _sbSql12.AppendLine("@Contribution)");


                        _cmdSql12 = new SqlCommand(_sbSql12.ToString(), _conSql12);




                        DateTime da = DateTime.Now;
                        da.ToString("MM-dd-yyyy h:mm tt");

                        _cmdSql12.Parameters.AddWithValue("@TxnSysDate", Convert.ToDateTime(da));
                        int _userCode = GlobalDataLayer.GetUserCodeById(_VehicleDetailMdl1.UserCode);
                        _cmdSql12.Parameters.AddWithValue("@UserCode", _userCode);

                        _cmdSql12.Parameters.AddWithValue("@SerialNo", _SerialNumber1);

                        //_cmdSql12.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID);
                        _cmdSql12.Parameters.AddWithValue("@OpolTxnSysID", _VehicleDetailMdl1.OpolTxnSysID);

                        _cmdSql12.Parameters.AddWithValue("@VehicleCode", _VehicleDetailMdl1.VehicleCode);
                        _cmdSql12.Parameters.AddWithValue("@VehicleModel", _VehicleDetailMdl1.VehicleModel);
                        _cmdSql12.Parameters.AddWithValue("@UpdatedValue", _VehicleDetailMdl1.UpdatedValue);
                        _cmdSql12.Parameters.AddWithValue("@PreviousValue", _VehicleDetailMdl1.PreviousValue);
                        _cmdSql12.Parameters.AddWithValue("@Mileage", _VehicleDetailMdl1.Mileage);
                        _cmdSql12.Parameters.AddWithValue("@ParticipantValue", _VehicleDetailMdl1.ParticipantValue);
                        _cmdSql12.Parameters.AddWithValue("@ColorCode", _VehicleDetailMdl1.ColorCode);
                        _cmdSql12.Parameters.AddWithValue("@ParticipantName", _VehicleDetailMdl1.ParticipantName);
                        _cmdSql12.Parameters.AddWithValue("@ParticipantAddress", _VehicleDetailMdl1.ParticipantAddress);
                        // _cmdSql12.Parameters.AddWithValue("@ModelNumber", _VehicleDetailMdl.ModelNumber);
                        _cmdSql12.Parameters.AddWithValue("@RegistrationNumber", _VehicleDetailMdl1.RegistrationNumber);
                        _cmdSql12.Parameters.AddWithValue("@CityCode", _VehicleDetailMdl1.CityCode);
                        _cmdSql12.Parameters.AddWithValue("@EngineNumber", _VehicleDetailMdl1.EngineNumber);
                        _cmdSql12.Parameters.AddWithValue("@AreaCode", _VehicleDetailMdl1.AreaCode);
                        _cmdSql12.Parameters.AddWithValue("@ChasisNumber", _VehicleDetailMdl1.ChasisNumber);
                        _cmdSql12.Parameters.AddWithValue("@Remarks", _VehicleDetailMdl1.Remarks ?? DBNull.Value.ToString());
                        _cmdSql12.Parameters.AddWithValue("@PODate", _VehicleDetailMdl1.PODate);
                        _cmdSql12.Parameters.AddWithValue("@PONumber", _VehicleDetailMdl1.PONumber ?? DBNull.Value.ToString());
                        _cmdSql12.Parameters.AddWithValue("@CNICNumber", _VehicleDetailMdl1.CNICNumber);
                        _cmdSql12.Parameters.AddWithValue("@Tenure", _VehicleDetailMdl1.Tenure);
                        _cmdSql12.Parameters.AddWithValue("@BirthDate", _VehicleDetailMdl1.BirthDate);
                        _cmdSql12.Parameters.AddWithValue("@Gender", _VehicleDetailMdl1.Gender);
                        _cmdSql12.Parameters.AddWithValue("@VehicleType", _VehicleDetailMdl1.VehicleType);
                        _cmdSql12.Parameters.AddWithValue("@VEODCode", _VehicleDetailMdl1.VEODCode);
                        _cmdSql12.Parameters.AddWithValue("@CertTypeCode", _VehicleDetailMdl1.CertTypeCode);
                        _cmdSql12.Parameters.AddWithValue("@Rate", _VehicleDetailMdl1.Rate);
                        _cmdSql12.Parameters.AddWithValue("@InsuranceTypeCode", _VehicleDetailMdl1.InsuranceTypeCode);
                         InsuranceType = _VehicleDetailMdl1.InsuranceTypeCode;
                        _cmdSql12.Parameters.AddWithValue("@Contribution", _VehicleDetailMdl1.Contribution);
                        _cmdSql12.Parameters.AddWithValue("@CommisionRate", _VehicleDetailMdl1.CommisionRate);
                        _cmdSql12.Parameters.AddWithValue("@MobileNumber", _VehicleDetailMdl1.MobileNumber ?? DBNull.Value.ToString());
                        _cmdSql12.Parameters.AddWithValue("@ResNumber", _VehicleDetailMdl1.ResNumber ?? DBNull.Value.ToString());
                        _cmdSql12.Parameters.AddWithValue("@OfficeNumber", _VehicleDetailMdl1.OfficeNumber ?? DBNull.Value.ToString());

                        _cmdSql12.Parameters.AddWithValue("@EmailAddress", _VehicleDetailMdl1.EmailAddress ?? DBNull.Value.ToString());
                        _cmdSql12.Parameters.AddWithValue("@Deductible", _VehicleDetailMdl1.Deductible);
                        _cmdSql12.Parameters.AddWithValue("@ContractMatDate", _VehicleDetailMdl1.ContractMatDate);

                        _cmdSql12.Parameters.AddWithValue("@RatingFactor", _VehicleDetailMdl1.RatingFactor);

                        _VehicleDetailMdl1.SerialNo = _SerialNumber1;

                        _VehicleDetailMdl1.TxnSysDate = DateTime.Now;

                        _VehicleDetailMdl1.VEODName = GlobalDataLayer.GetVEODNameByCode(_VehicleDetailMdl1.VEODCode);
                        _VehicleDetailMdl1.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_VehicleDetailMdl1.VehicleType);
                        _VehicleDetailMdl1.GenderName = GlobalDataLayer.GetGenderNameByCode(_VehicleDetailMdl1.Gender);
                        _VehicleDetailMdl1.CityName = GlobalDataLayer.GetCityNameByCode(_VehicleDetailMdl1.CityCode);
                        _VehicleDetailMdl1.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(_VehicleDetailMdl1.ColorCode);
                        _VehicleDetailMdl1.VehicleName = GlobalDataLayer.GetVehicleNameByCode(_VehicleDetailMdl1.VehicleCode);
                        _VehicleDetailMdl1.AreaName = GlobalDataLayer.GetAreaNameByCode(_VehicleDetailMdl1.AreaCode);
                        _VehicleDetailMdl1.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_VehicleDetailMdl1.CertTypeCode);
                        _VehicleDetailMdl1.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(_VehicleDetailMdl1.InsuranceTypeCode);

                        _VehicleDetailMdl1.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_VehicleDetailMdl1.RatingFactor);

                        _VehicleDetailMdl1.total = GlobalDataLayer.calculate(_VehicleDetailMdl1);


                        int _TxnSysId5;
                        _conSql12.Open();
                        _TxnSysId5 = (Int32)_cmdSql12.ExecuteScalar();
                        _conSql12.Close();

                    }


                    else
                    {

                    }
                    //----------------For Vehicle Details-----------------//


                    // --------------- For Co-Insurance --------------------- //

                    //For CoInsurance of Leader
                    if (InsuranceType == 2)
                    {

                        SqlConnection _conSqlA1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        string _sqlStringA1 = "SELECT *  FROM InsCoInsuance Where RiskTxnID =" + _VehicleDetailMdl1.TxnSysID;
                        SqlDataAdapter _adpSqlA1 = new SqlDataAdapter(_sqlStringA1, _conSqlA1);
                        DataTable _tblSqlaA1 = new DataTable();
                        InsCoInsurance _InsCoInsuranceA1 = new InsCoInsurance();
                        List<InsCoInsurance> _InsCoInsuranceListA1 = new List<InsCoInsurance>();

                        _adpSqlA1.Fill(_tblSqlaA1);

                        if (_tblSqlaA1.Rows.Count > 0)
                        {

                            for (int i = 0; i < _tblSqlaA1.Rows.Count; i++)
                            {

                                _InsCoInsuranceA1 = new InsCoInsurance();

                                _InsCoInsuranceA1.FIF = Convert.ToDecimal(_tblSqlaA1.Rows[i]["FIF"]);
                                _InsCoInsuranceA1.FED = Convert.ToDecimal(_tblSqlaA1.Rows[i]["FED"]);
                                _InsCoInsuranceA1.CoInsuranceCode = Convert.ToInt32(_tblSqlaA1.Rows[i]["CoInsuranceCode"]);
                                _InsCoInsuranceA1.CoInsuranceShare = Convert.ToDecimal(_tblSqlaA1.Rows[i]["CoInsuranceShare"]);
                                _InsCoInsuranceA1.PEV = Decimal.Round(Convert.ToDecimal(_tblSqlaA1.Rows[i]["PEV"]), MidpointRounding.ToEven);
                                _InsCoInsuranceA1.BeforePEV = Decimal.Round(Convert.ToDecimal(_tblSqlaA1.Rows[i]["BeforePEV"]), MidpointRounding.ToEven);
                                _InsCoInsuranceA1.Stamp = Convert.ToDecimal(_tblSqlaA1.Rows[i]["Stamp"]);
                                _InsCoInsuranceA1.OpolTxnSysID = Convert.ToInt32(_tblSqlaA1.Rows[i]["OpolTxnSysID"]);
                                _InsCoInsuranceA1.Rate = Convert.ToDecimal(_tblSqlaA1.Rows[i]["Rate"]);
                                _InsCoInsuranceA1.BasicContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["BasicContribution"]);
                                _InsCoInsuranceA1.TerrorContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["TerrorContribution"]);
                                _InsCoInsuranceA1.NetContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["NetContribution"]);
                                _InsCoInsuranceA1.GrossContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["GrossContribution"]);
                                _InsCoInsuranceA1.PerDayContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["PerDayContribution"]);
                                _InsCoInsuranceA1.SumCovered = Convert.ToInt32(_tblSqlaA1.Rows[i]["SumCovered"]);

                                _InsCoInsuranceListA1.Add(_InsCoInsuranceA1);
                            }

                            //Insert InTo CoInsurance for Renewal
                            SqlConnection _conSqlA2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                            StringBuilder _sbSqlA2 = new StringBuilder();
                            SqlCommand _cmdSqlA2;
                            InsCoInsurance[] ConInsList = _InsCoInsuranceListA1.ToArray();


                            for (int i = 0; i < ConInsList.Length; i++)
                            {
                                _sbSqlA2 = new StringBuilder();

                                _sbSqlA2.AppendLine("INSERT INTO InsCoInsuance(");
                                //_sbSql.AppendLine("TxnSysID,");
                                _sbSqlA2.AppendLine("TxnSysDate,");
                                _sbSqlA2.AppendLine("UserCode,");
                                _sbSqlA2.AppendLine("SumCovered,");
                                _sbSqlA2.AppendLine("Rate,");
                                _sbSqlA2.AppendLine("NetContribution,");
                                _sbSqlA2.AppendLine("GrossContribution,");
                                _sbSqlA2.AppendLine("FIF,");
                                _sbSqlA2.AppendLine("FED,");
                                _sbSqlA2.AppendLine("Stamp,");
                                _sbSqlA2.AppendLine("BasicContribution,");
                                _sbSqlA2.AppendLine("PEV,");
                                _sbSqlA2.AppendLine("BeforePEV,");
                                _sbSqlA2.AppendLine("TerrorContribution,");
                                _sbSqlA2.AppendLine("RiskTxnID,");
                                _sbSqlA2.AppendLine("OpolTxnSysID,");
                                _sbSqlA2.AppendLine("PerDayContribution,");

                                _sbSqlA2.AppendLine("CoInsuranceCode,");
                                _sbSqlA2.AppendLine("CoInsuranceShare)");


                                _sbSqlA2.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                                //_sbSqlA2.AppendLine("@TxnSysID,");
                                _sbSqlA2.AppendLine("@TxnSysDate,");
                                _sbSqlA2.AppendLine("@UserCode,");
                                _sbSqlA2.AppendLine("@SumCovered,");
                                _sbSqlA2.AppendLine("@Rate,");
                                _sbSqlA2.AppendLine("@NetContribution,");
                                _sbSqlA2.AppendLine("@GrossContribution,");
                                _sbSqlA2.AppendLine("@FIF,");
                                _sbSqlA2.AppendLine("@FED,");
                                _sbSqlA2.AppendLine("@Stamp,");
                                _sbSqlA2.AppendLine("@BasicContribution,");
                                _sbSqlA2.AppendLine("@PEV,");
                                _sbSqlA2.AppendLine("@BeforePEV,");
                                _sbSqlA2.AppendLine("@TerrorContribution,");
                                _sbSqlA2.AppendLine("(SELECT MAX(mvd.TxnSysID) FROM MtrVehicleDetails mvd),");
                                _sbSqlA2.AppendLine("@OpolTxnSysID,");
                                _sbSqlA2.AppendLine("@PerDayContribution,");
                                _sbSqlA2.AppendLine("@CoInsuranceCode,");
                                _sbSqlA2.AppendLine("@CoInsuranceShare)");


                                _cmdSqlA2 = new SqlCommand(_sbSqlA2.ToString(), _conSqlA2);

                                _cmdSqlA2.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                                _cmdSqlA2.Parameters.AddWithValue("@SumCovered", ConInsList[i].SumCovered);

                                int _userCodeA2 = GlobalDataLayer.GetUserCodeById(ConInsList[i].UserCode);

                                _cmdSqlA2.Parameters.AddWithValue("@UserCode", _userCodeA2);


                                _cmdSqlA2.Parameters.AddWithValue("@Rate", ConInsList[i].Rate);
                                _cmdSqlA2.Parameters.AddWithValue("@NetContribution", ConInsList[i].NetContribution);
                                _cmdSqlA2.Parameters.AddWithValue("@GrossContribution", ConInsList[i].GrossContribution);
                                _cmdSqlA2.Parameters.AddWithValue("@FIF", ConInsList[i].FIF);
                                _cmdSqlA2.Parameters.AddWithValue("@FED", ConInsList[i].FED);
                                _cmdSqlA2.Parameters.AddWithValue("@Stamp", ConInsList[i].Stamp);
                                _cmdSqlA2.Parameters.AddWithValue("@BasicContribution", ConInsList[i].BasicContribution);
                                _cmdSqlA2.Parameters.AddWithValue("@PEV", ConInsList[i].PEV);
                                _cmdSqlA2.Parameters.AddWithValue("@BeforePEV", ConInsList[i].BeforePEV);
                                _cmdSqlA2.Parameters.AddWithValue("@TerrorContribution", ConInsList[i].TerrorContribution);
                                // _cmdSqlA2.Parameters.AddWithValue("@RiskTxnID", ConInsList[i].RiskTxnID);
                                _cmdSqlA2.Parameters.AddWithValue("@OpolTxnSysID", ConInsList[i].OpolTxnSysID);
                                _cmdSqlA2.Parameters.AddWithValue("@PerDayContribution", ConInsList[i].PerDayContribution);
                                _cmdSqlA2.Parameters.AddWithValue("@CoInsuranceCode", ConInsList[i].CoInsuranceCode);
                                _cmdSqlA2.Parameters.AddWithValue("@CoInsuranceShare", ConInsList[i].CoInsuranceShare);


                                int _TxnSysId1;
                                _conSqlA2.Open();
                                _TxnSysId1 = (Int32)_cmdSqlA2.ExecuteScalar();
                                _conSqlA2.Close();
                            }


                        }


                        else
                        {



                        }

                    }
                    // --------------- For Co-Insurance --------------------- //




                    //----------------For Mtr Contribution-----------------//

                    //Get Values From Mtr Contribution
                    SqlConnection _conSql13 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    DataTable _tblSqla13 = new DataTable();
                    MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();
                    List<MtrVContributionMdl> _MtrVContributionMdlList1 = new List<MtrVContributionMdl>();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM InsContribution ic INNER JOIN MtrVehicleDetails mvd ON mvd.TxnSysID = ic.RiskTxnID WHERE mvd.ParentTxnSysID = @ParentTxnSysID ", conn);

                        command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                        SqlDataAdapter _adpSql13 = new SqlDataAdapter(command);


                        _adpSql13.Fill(_tblSqla13);
                    }

                    //  _adpSql.Fill(_tblSqla);

                    if (_tblSqla13.Rows.Count > 0)
                    {
                        _MtrVContributionMdl1 = new MtrVContributionMdl();
                        for (int i = 0; i < _tblSqla13.Rows.Count; i++)
                        {
                            _MtrVContributionMdl1 = new MtrVContributionMdl();

                            _MtrVContributionMdl1.TxnSysID = Convert.ToInt32(_tblSqla13.Rows[i]["TxnSysID"]);
                            _MtrVContributionMdl1.TxnSysDate = Convert.ToDateTime(_tblSqla13.Rows[i]["TxnSysDate"]);
                            _MtrVContributionMdl1.UserCode = Convert.ToInt32(_tblSqla13.Rows[i]["UserCode"]);
                            _MtrVContributionMdl1.SumCovered = Convert.ToInt32(_tblSqla13.Rows[i]["SumCovered"]);
                            _MtrVContributionMdl1.Rate = Convert.ToDecimal(_tblSqla13.Rows[i]["Rate"]);
                            _MtrVContributionMdl1.NetContribution = Convert.ToDecimal(_tblSqla13.Rows[i]["NetContribution"]);
                            _MtrVContributionMdl1.GrossContribution = Convert.ToDecimal(_tblSqla13.Rows[i]["GrossContribution"]);
                            _MtrVContributionMdl1.FIF = Convert.ToDecimal(_tblSqla13.Rows[i]["FIF"]);
                            _MtrVContributionMdl1.FED = Convert.ToDecimal(_tblSqla13.Rows[i]["FED"]);
                            _MtrVContributionMdl1.Stamp = Convert.ToDecimal(_tblSqla13.Rows[i]["Stamp"]);
                            _MtrVContributionMdl1.BasicContribution = Convert.ToDecimal(_tblSqla13.Rows[i]["BasicContribution"]);
                            _MtrVContributionMdl1.PEV = Convert.ToDecimal(_tblSqla13.Rows[i]["PEV"]);
                            _MtrVContributionMdl1.BeforePEV = Convert.ToDecimal(_tblSqla13.Rows[i]["BeforePEV"]);
                            _MtrVContributionMdl1.TerrorContribution = Convert.ToDecimal(_tblSqla13.Rows[i]["TerrorContribution"]);
                            _MtrVContributionMdl1.RiskTxnID = Convert.ToInt32(_tblSqla13.Rows[i]["RiskTxnID"]);
                            _MtrVContributionMdl1.PerDayContribution = Convert.ToInt32(_tblSqla13.Rows[i]["PerDayContribution"]);
                            _MtrVContributionMdl1.OpolTxnSysID = Convert.ToInt32(_tblSqla13.Rows[i]["OpolTxnSysID"]);

                            _MtrVContributionMdlList1.Add(_MtrVContributionMdl1);
                        }


                        //Insert In To Mtr Ins Contribution 
                        SqlConnection _conSql14 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql14 = new StringBuilder();
                        SqlCommand _cmdSql14;

                        _sbSql14.AppendLine("INSERT INTO InsContribution(");
                        // _sbSql.AppendLine("TxnSysID,");
                        _sbSql14.AppendLine("TxnSysDate,");
                        _sbSql14.AppendLine("UserCode,");
                        _sbSql14.AppendLine("SumCovered,");
                        _sbSql14.AppendLine("Rate,");
                        _sbSql14.AppendLine("NetContribution,");
                        _sbSql14.AppendLine("GrossContribution,");
                        _sbSql14.AppendLine("FIF,");
                        _sbSql14.AppendLine("FED,");
                        _sbSql14.AppendLine("Stamp,");
                        _sbSql14.AppendLine("BasicContribution,");
                        _sbSql14.AppendLine("PEV,");
                        _sbSql14.AppendLine("BeforePEV,");
                        _sbSql14.AppendLine("TerrorContribution,");
                        _sbSql14.AppendLine("RiskTxnID,");
                        _sbSql14.AppendLine("OpolTxnSysID,");
                        _sbSql14.AppendLine("PerDayContribution)");

                        _sbSql14.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                        //_sbSql.AppendLine("@TxnSysID,");
                        _sbSql14.AppendLine("@TxnSysDate,");
                        _sbSql14.AppendLine("@UserCode,");
                        _sbSql14.AppendLine("@SumCovered,");
                        _sbSql14.AppendLine("@Rate,");
                        _sbSql14.AppendLine("@NetContribution,");
                        _sbSql14.AppendLine("@GrossContribution,");
                        _sbSql14.AppendLine("@FIF,");
                        _sbSql14.AppendLine("@FED,");
                        _sbSql14.AppendLine("@Stamp,");
                        _sbSql14.AppendLine("@BasicContribution,");
                        _sbSql14.AppendLine("@PEV,");
                        _sbSql14.AppendLine("@BeforePEV,");
                        _sbSql14.AppendLine("@TerrorContribution,");
                        _sbSql14.AppendLine("(SELECT MAX(mvd.TxnSysID) FROM MtrVehicleDetails mvd),");
                        _sbSql14.AppendLine("@OpolTxnSysID,");
                        _sbSql14.AppendLine("@PerDayContribution)");

                        _cmdSql14 = new SqlCommand(_sbSql14.ToString(), _conSql14);

                        _cmdSql14.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                        _cmdSql14.Parameters.AddWithValue("@SumCovered", _MtrVContributionMdl1.SumCovered);

                        int _userCode2 = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl1.UserCode);

                        _cmdSql14.Parameters.AddWithValue("@UserCode", _userCode2);

                        _cmdSql14.Parameters.AddWithValue("@Rate", _MtrVContributionMdl1.Rate);
                        _cmdSql14.Parameters.AddWithValue("@NetContribution", _MtrVContributionMdl1.NetContribution);
                        _cmdSql14.Parameters.AddWithValue("@GrossContribution", _MtrVContributionMdl1.GrossContribution);
                        _cmdSql14.Parameters.AddWithValue("@FIF", _MtrVContributionMdl1.FIF);
                        _cmdSql14.Parameters.AddWithValue("@FED", _MtrVContributionMdl1.FED);
                        _cmdSql14.Parameters.AddWithValue("@Stamp", _MtrVContributionMdl1.Stamp);
                        _cmdSql14.Parameters.AddWithValue("@BasicContribution", _MtrVContributionMdl1.BasicContribution);
                        _cmdSql14.Parameters.AddWithValue("@PEV", _MtrVContributionMdl1.PEV);
                        _cmdSql14.Parameters.AddWithValue("@BeforePEV", _MtrVContributionMdl1.BeforePEV);
                        _cmdSql14.Parameters.AddWithValue("@TerrorContribution", _MtrVContributionMdl1.TerrorContribution);
                        _cmdSql14.Parameters.AddWithValue("@PerDayContribution", _MtrVContributionMdl1.PerDayContribution);

                        _cmdSql14.Parameters.AddWithValue("@OpolTxnSysID", _MtrVContributionMdl1.OpolTxnSysID);

                        int _TxnSysId4;
                        _conSql14.Open();
                        _TxnSysId4 = (Int32)_cmdSql14.ExecuteScalar();
                        _conSql14.Close();

                        _MtrVContributionMdl1.TxnSysID = _TxnSysId4;
                        _MtrVContributionMdl1.IsValidTxn = true;
                    }


                    else
                    {

                    }

                    //----------------For Mtr Contribution-----------------//

                    return _MtrInsPolicyMdl2;

                }
                else
                {
                    return null;
                }

                


            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Renewal DataLayer");
                return null;
            }
        }

        //To make Renewal and Perform Deduction
        public List<MtrVContributionMdl> ToDeductForRenewal(MtrInsPolicyMdl _MtrInsPolicyMdl1)
        {
            try
            {
                //Get Values from Ins Policy
                DataTable _tblSqla = new DataTable();
                List<MtrInsPolicyMdl> _MtrInsPolicyMdlList = new List<MtrInsPolicyMdl>();
                MtrInsPolicyMdl _MtrInsPolicyMdl = new MtrInsPolicyMdl();

                int InsuranceType = 0;
                decimal SumCovered = 0,Contribution = 0,Rate = 0;
                decimal NetContribution = 0 , GrossContribution = 0, BeforePEV = 0, PEV = 0, PerDay = 0;
                int terror = 0, tenure = 0;


                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    string str = "SELECT * FROM InsPolicy WHERE  ParentTxnSysID = @ParentTxnSysID";

                    SqlCommand command =
                        new SqlCommand(str, conn);

                    command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrInsPolicyMdl = new MtrInsPolicyMdl();

                        _MtrInsPolicyMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["ParentTxnSysID"]);
                        _MtrInsPolicyMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrInsPolicyMdl.CertMonth = _tblSqla.Rows[i]["DocMonth"].ToString();
                        _MtrInsPolicyMdl.CertString = _tblSqla.Rows[i]["DocString"].ToString();
                        _MtrInsPolicyMdl.CertYear = _tblSqla.Rows[i]["DocYear"].ToString();
                        _MtrInsPolicyMdl.CertNo = Convert.ToInt32(_tblSqla.Rows[i]["DocNo"]);
                        _MtrInsPolicyMdl.DocType = _tblSqla.Rows[i]["DocType"].ToString();
                        _MtrInsPolicyMdl.GenerateAgainst = _tblSqla.Rows[i]["GenerateAgainst"].ToString();
                        _MtrInsPolicyMdl.ProductCode = Convert.ToInt32(_tblSqla.Rows[i]["ProductCode"]);
                        _MtrInsPolicyMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();
                        _MtrInsPolicyMdl.ClientCode = _tblSqla.Rows[i]["ClientCode"].ToString();
                        _MtrInsPolicyMdl.AgencyCode = _tblSqla.Rows[i]["AgencyCode"].ToString();
                        _MtrInsPolicyMdl.CertInsureCode = _tblSqla.Rows[i]["CertInsureCode"].ToString();
                        _MtrInsPolicyMdl.Remarks = _tblSqla.Rows[i]["Remarks"].ToString();
                        _MtrInsPolicyMdl.BrchCoverNoteNo = _tblSqla.Rows[i]["BrchCoverNoteNo"].ToString();
                        _MtrInsPolicyMdl.LeaderPolicyNo = _tblSqla.Rows[i]["LeaderPolicyNo"].ToString();
                        _MtrInsPolicyMdl.LeaderEndNo = _tblSqla.Rows[i]["LeaderEndNo"].ToString();
                        _MtrInsPolicyMdl.IsFiler = _tblSqla.Rows[i]["IsFiler"].ToString();
                        _MtrInsPolicyMdl.CalcType = _tblSqla.Rows[i]["CalcType"].ToString();
                        _MtrInsPolicyMdl.IsAuto = _tblSqla.Rows[i]["IsAuto"].ToString();
                        _MtrInsPolicyMdl.EffectiveDate = Convert.ToDateTime(_tblSqla.Rows[i]["EffectiveDate"]);
                        _MtrInsPolicyMdl.ExpiryDate = Convert.ToDateTime(_tblSqla.Rows[i]["ExpiryDate"]);
                        _MtrInsPolicyMdl.SerialNo = Convert.ToInt32(_tblSqla.Rows[i]["SerialNo"]);
                        _MtrInsPolicyMdl.UWYear = _tblSqla.Rows[i]["UWYear"].ToString();
                        _MtrInsPolicyMdl.CreatedBy = _tblSqla.Rows[i]["CreatedBy"].ToString();
                        _MtrInsPolicyMdl.PostedBy = _tblSqla.Rows[i]["PostedBy"].ToString();
                        _MtrInsPolicyMdl.IsPosted = Convert.ToBoolean(_tblSqla.Rows[i]["IsPosted"]);
                        //_MtrInsPolicyMdl.PostDate = Convert.ToDateTime(_tblSqla.Rows[i]["PostDate"]);
                        _MtrInsPolicyMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["OpolTxnSysID"]);
                        _MtrInsPolicyMdl.RenewSysID = Convert.ToInt32(_tblSqla.Rows[i]["RenewSysID"]);
                        _MtrInsPolicyMdl.PolSysID = Convert.ToInt32(_tblSqla.Rows[i]["PolSysID"]);
                        _MtrInsPolicyMdl.IsRenewal = Convert.ToBoolean(_tblSqla.Rows[i]["IsRenewal"]);
                        _MtrInsPolicyMdl.CommisionRate = Convert.ToDecimal(_tblSqla.Rows[i]["CommisionRate"]);
                        _MtrInsPolicyMdl.IsActive = Convert.ToBoolean(_tblSqla.Rows[i]["IsActive"]);

                        _MtrInsPolicyMdl.IsValidTxn = true;

                        _MtrInsPolicyMdlList.Add(_MtrInsPolicyMdl);


                    }

                    

                    //To Insert in to InsPolicy for Renewal
                    SqlConnection _conSql2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql2 = new StringBuilder();
                    SqlCommand _cmdSql2;
                    MtrInsPolicyMdl _MtrInsPolicyMdl2 = new MtrInsPolicyMdl();
                    int _SerialNumber = GetSerialNo(_MtrInsPolicyMdl);


                    _sbSql2.AppendLine("INSERT INTO InsPolicy(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql2.AppendLine("TxnSysDate,");
                    _sbSql2.AppendLine("DocMonth,");
                    _sbSql2.AppendLine("DocString,");
                    _sbSql2.AppendLine("DocYear,");
                    _sbSql2.AppendLine("DocNo,");
                    _sbSql2.AppendLine("DocType,");
                    _sbSql2.AppendLine("GenerateAgainst,");
                    _sbSql2.AppendLine("ProductCode,");
                    _sbSql2.AppendLine("PolicyTypeCode,");
                    _sbSql2.AppendLine("ClientCode,");
                    _sbSql2.AppendLine("AgencyCode,");
                    _sbSql2.AppendLine("CertInsureCode,");
                    _sbSql2.AppendLine("Remarks,");
                    _sbSql2.AppendLine("BrchCoverNoteNo,");
                    _sbSql2.AppendLine("LeaderPolicyNo,");
                    _sbSql2.AppendLine("LeaderEndNo,");
                    _sbSql2.AppendLine("IsFiler,");
                    _sbSql2.AppendLine("CalcType,");
                    _sbSql2.AppendLine("IsAuto,");
                    _sbSql2.AppendLine("EffectiveDate,");
                    _sbSql2.AppendLine("ExpiryDate,");
                    _sbSql2.AppendLine("SerialNo,");
                    _sbSql2.AppendLine("UWYear,");
                    _sbSql2.AppendLine("CreatedBy,");
                    _sbSql2.AppendLine("CommisionRate,");

                    _sbSql2.AppendLine("IsPosted,");
                    // _sbSql2.AppendLine("PostDate,");
                    _sbSql2.AppendLine("IsRenewal,");
                    _sbSql2.AppendLine("RenewSysID,");

                    _sbSql2.AppendLine("OpolTxnSysID)");




                    _sbSql2.AppendLine("output INSERTED. ParentTxnSysID VALUES ( ");

                    _sbSql2.AppendLine("@TxnSysDate,");
                    _sbSql2.AppendLine("@DocMonth,");
                    _sbSql2.AppendLine("@DocString,");
                    _sbSql2.AppendLine("@DocYear,");
                    _sbSql2.AppendLine("@DocNo,");
                    _sbSql2.AppendLine("@DocType,");
                    _sbSql2.AppendLine("@GenerateAgainst,");
                    _sbSql2.AppendLine("@ProductCode,");
                    _sbSql2.AppendLine("@PolicyTypeCode,");
                    _sbSql2.AppendLine("@ClientCode,");
                    _sbSql2.AppendLine("@AgencyCode,");
                    _sbSql2.AppendLine("@CertInsureCode,");
                    _sbSql2.AppendLine("@Remarks,");
                    _sbSql2.AppendLine("@BrchCoverNoteNo,");
                    _sbSql2.AppendLine("@LeaderPolicyNo,");
                    _sbSql2.AppendLine("@LeaderEndNo,");
                    _sbSql2.AppendLine("@IsFiler,");
                    _sbSql2.AppendLine("@CalcType,");
                    _sbSql2.AppendLine("@IsAuto,");
                    _sbSql2.AppendLine("@EffectiveDate,");
                    _sbSql2.AppendLine("(DATEADD(DAY, 365, @ExpiryDate)),");
                    _sbSql2.AppendLine("@SerialNo,");
                    _sbSql2.AppendLine("@UWYear,");
                    _sbSql2.AppendLine("@CreatedBy,");
                    _sbSql2.AppendLine("@CommisionRate,");
                    _sbSql2.AppendLine("@IsPosted,");
                    // _sbSql2.AppendLine("@PostDate,");
                    _sbSql2.AppendLine("@IsRenewal,");
                    _sbSql2.AppendLine("@RenewSysID,");
                    _sbSql2.AppendLine("@OpolTxnSysID)");



                    _cmdSql2 = new SqlCommand(_sbSql2.ToString(), _conSql2);
                    // DateTime da = DateTime.Now;
                    //  da.ToString("MM-dd-yyyy h:mm tt");
                    _cmdSql2.Parameters.AddWithValue("@TxnSysDate", SqlDbType.DateTime).Value = DateTime.Now;


                    _cmdSql2.Parameters.AddWithValue("@DocMonth", _MtrInsPolicyMdl.CertMonth);
                    _cmdSql2.Parameters.AddWithValue("@RenewSysID", _MtrInsPolicyMdl.ParentTxnSysID);

                    _cmdSql2.Parameters.AddWithValue("@DocYear", _MtrInsPolicyMdl.CertYear);

                    _cmdSql2.Parameters.AddWithValue("@DocNo", _MtrInsPolicyMdl.CertNo);

                    string OpenPolicyDoc = "8";

                    _cmdSql2.Parameters.AddWithValue("@DocType", OpenPolicyDoc);


                    string CertString = GetCertString(
                        "101".ToString(),
                        _MtrInsPolicyMdl.CertInsureCode.ToString(),
                        OpenPolicyDoc,
                        Convert.ToInt32(_MtrInsPolicyMdl.PolicyTypeCode),
                        _SerialNumber,
                       DateTime.Now.Month.ToString(),
                           DateTime.Now.Year.ToString());


                    _cmdSql2.Parameters.AddWithValue("@DocString", CertString);

                    _cmdSql2.Parameters.AddWithValue("@GenerateAgainst", _MtrInsPolicyMdl.ParentTxnSysID);
                    _cmdSql2.Parameters.AddWithValue("@ProductCode", _MtrInsPolicyMdl.ProductCode);
                    _cmdSql2.Parameters.AddWithValue("@PolicyTypeCode", _MtrInsPolicyMdl.PolicyTypeCode);
                    _cmdSql2.Parameters.AddWithValue("@ClientCode", _MtrInsPolicyMdl.ClientCode);
                    _cmdSql2.Parameters.AddWithValue("@AgencyCode", _MtrInsPolicyMdl.AgencyCode);
                    _cmdSql2.Parameters.AddWithValue("@CertInsureCode", _MtrInsPolicyMdl.CertInsureCode);

                    //Remarks for Addition
                    _cmdSql2.Parameters.AddWithValue("@Remarks", _MtrInsPolicyMdl.Remarks ?? DBNull.Value.ToString());

                    _cmdSql2.Parameters.AddWithValue("@BrchCoverNoteNo", _MtrInsPolicyMdl.BrchCoverNoteNo ?? DBNull.Value.ToString());
                    _cmdSql2.Parameters.AddWithValue("@LeaderPolicyNo", _MtrInsPolicyMdl.LeaderPolicyNo ?? DBNull.Value.ToString());
                    _cmdSql2.Parameters.AddWithValue("@LeaderEndNo", _MtrInsPolicyMdl.LeaderEndNo ?? DBNull.Value.ToString());
                    _cmdSql2.Parameters.AddWithValue("@IsFiler", _MtrInsPolicyMdl.IsFiler ?? DBNull.Value.ToString());
                    _cmdSql2.Parameters.AddWithValue("@CalcType", _MtrInsPolicyMdl.CalcType ?? DBNull.Value.ToString());
                    _cmdSql2.Parameters.AddWithValue("@IsAuto", _MtrInsPolicyMdl.IsAuto ?? DBNull.Value.ToString());
                    _cmdSql2.Parameters.AddWithValue("@EffectiveDate", Convert.ToDateTime(_MtrInsPolicyMdl.EffectiveDate.ToString()));
                    _cmdSql2.Parameters.AddWithValue("@ExpiryDate", Convert.ToDateTime(_MtrInsPolicyMdl.ExpiryDate.ToString()));
                    _cmdSql2.Parameters.AddWithValue("@SerialNo", _SerialNumber);
                    _cmdSql2.Parameters.AddWithValue("@UWYear", _MtrInsPolicyMdl.UWYear);
                    _cmdSql2.Parameters.AddWithValue("@CommisionRate", _MtrInsPolicyMdl.CommisionRate);

                    _cmdSql2.Parameters.AddWithValue("@CreatedBy", _MtrInsPolicyMdl.CreatedBy);

                    _cmdSql2.Parameters.AddWithValue("@IsPosted", _MtrInsPolicyMdl.IsPosted);
                    // _cmdSql2.Parameters.AddWithValue("@PostDate", _MtrInsPolicyMdl.PostDate);
                    _cmdSql2.Parameters.AddWithValue("@OpolTxnSysID", _MtrInsPolicyMdl.OpolTxnSysID);
                    _cmdSql2.Parameters.AddWithValue("@IsRenewal", Convert.ToBoolean(true));

                    _MtrInsPolicyMdl.CertString = CertString;
                    _MtrInsPolicyMdl.SerialNo = _SerialNumber;
                    // _MtrInsPolicyMdl.TxnSysDate = DateTime.Now;


                    int _TxnSysId;
                    _conSql2.Open();
                    _TxnSysId = (Int32)_cmdSql2.ExecuteScalar();
                    _conSql2.Close();
                    _MtrInsPolicyMdl2.IsValidTxn = true;

                    _MtrInsPolicyMdl2.ParentTxnSysID = _TxnSysId;
                    string OpenPolicyDoc1 = "8"; 
                    _MtrInsPolicyMdl2.IsValidTxn = true;
                    _MtrInsPolicyMdl2.DocType = OpenPolicyDoc1;

                    //----------------For Ins Tracker-----------------//

                    //Get Values From InsTracker
                    SqlConnection _conSql3 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());

                    DataTable _tblSqla3 = new DataTable();
                    List<MtrInsTrackerMdl> _MtrInsTrackerMdlList1 = new List<MtrInsTrackerMdl>();
                    MtrInsTrackerMdl _MtrInsTrackerMdl1 = new MtrInsTrackerMdl();


                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        string str = "SELECT * FROM InsMtrTracker WHERE ParentTxnSysID = @ParentTxnSysID";

                        SqlCommand command =
                            new SqlCommand(str, conn);

                        command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                        SqlDataAdapter _adpSql3 = new SqlDataAdapter(command);


                        _adpSql3.Fill(_tblSqla3);
                    }

                    if (_tblSqla3.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla3.Rows.Count; i++)
                        {
                            _MtrInsTrackerMdl1 = new MtrInsTrackerMdl();

                           // _MtrInsTrackerMdl1.TxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["TxnSysID"]);
                            _MtrInsTrackerMdl1.UserCode = Convert.ToInt32(_tblSqla3.Rows[i]["UserCode"]);
                            _MtrInsTrackerMdl1.TrackerCode = Convert.ToInt32(_tblSqla3.Rows[i]["TrackerCode"]);
                            _MtrInsTrackerMdl1.TrackerName = _tblSqla3.Rows[i]["TrackerName"].ToString();
                            _MtrInsTrackerMdl1.TrackerRate = Convert.ToInt32(_tblSqla3.Rows[i]["TrackerRate"]);
                          //  _MtrInsTrackerMdl1.ParentTxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["ParentTxnSysID"]);



                            _MtrInsTrackerMdl1.IsValidTxn = true;

                            _MtrInsTrackerMdlList1.Add(_MtrInsTrackerMdl1);
                        }

                        //Insert In to InsTracker For Renewal
                        SqlConnection _conSql7 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql7 = new StringBuilder();
                        SqlCommand _cmdSql7;


                        MtrInsTrackerMdl[] TrackerArray = _MtrInsTrackerMdlList1.ToArray();

                        for (int j = 0; j < TrackerArray.Length; j++)
                        {
                            _sbSql7 = new StringBuilder();

                            _sbSql7.AppendLine("INSERT INTO InsMtrTracker(");

                            _sbSql7.AppendLine("UserCode,");
                            _sbSql7.AppendLine("TrackerCode,");
                            _sbSql7.AppendLine("TrackerName,");
                            _sbSql7.AppendLine("TrackerRate,");
                            _sbSql7.AppendLine("ParentTxnSysID)");


                            _sbSql7.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                            _sbSql7.AppendLine("@UserCode,");
                            _sbSql7.AppendLine("@TrackerCode,");
                            _sbSql7.AppendLine("@TrackerName,");
                            _sbSql7.AppendLine("@TrackerRate,");
                            _sbSql7.AppendLine("(SELECT MAX(ip.ParentTxnSysID) FROM InsPolicy ip))");


                            _cmdSql7 = new SqlCommand(_sbSql7.ToString(), _conSql7);
                            int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsTrackerMdl1.UserCode);
                            _cmdSql7.Parameters.AddWithValue("@UserCode", _userCode);
                            _cmdSql7.Parameters.AddWithValue("@TrackerCode", TrackerArray[j].TrackerCode);
                            _cmdSql7.Parameters.AddWithValue("@TrackerName", TrackerArray[j].TrackerName);
                            _cmdSql7.Parameters.AddWithValue("@TrackerRate", TrackerArray[j].TrackerRate);
                            //_cmdSql7.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsTrackerMdl1.ParentTxnSysID);


                            int _TxnSysId1;
                            _conSql7.Open();
                            _TxnSysId1 = (Int32)_cmdSql7.ExecuteScalar();
                            _conSql7.Close();
                        }

                    }
                    else
                    {

                    }

                    //----------------For Ins Tracker-----------------//

                    //----------------For Ins Rider-----------------//

                    //Get Values From InsRider
                    SqlConnection _conSql4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    DataTable _tblSqla4 = new DataTable();
                    List<MtrInsRiderMdl> _MtrInsRiderMdlList1 = new List<MtrInsRiderMdl>();
                    MtrInsRiderMdl _MtrInsRiderMdl1 = new MtrInsRiderMdl();


                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        string str ="SELECT * FROM InsMtrRider WHERE ParentTxnSysID = @ParentTxnSysID";

                        SqlCommand command =
                            new SqlCommand(str, conn);

                        command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                        SqlDataAdapter _adpSql4 = new SqlDataAdapter(command);


                        _adpSql4.Fill(_tblSqla4);
                    }


                    if (_tblSqla4.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla4.Rows.Count; i++)
                        {
                            _MtrInsRiderMdl1 = new MtrInsRiderMdl();

                           // _MtrInsRiderMdl1.TxnSysID = Convert.ToInt32(_tblSqla4.Rows[i]["TxnSysID"]);
                           // _MtrInsRiderMdl1.TxnSysDate = Convert.ToDateTime(_tblSqla4.Rows[i]["TxnSysDate"]);
                            _MtrInsRiderMdl1.UserCode = Convert.ToInt32(_tblSqla4.Rows[i]["UserCode"]);
                            _MtrInsRiderMdl1.RiderCode = Convert.ToInt32(_tblSqla4.Rows[i]["RiderCode"]);
                            _MtrInsRiderMdl1.RiderName = _tblSqla4.Rows[i]["RiderName"].ToString();
                            _MtrInsRiderMdl1.RiderRate = Convert.ToInt32(_tblSqla4.Rows[i]["RiderRate"]);
                          //  _MtrInsRiderMdl1.ParentTxnSysID = Convert.ToInt32(_tblSqla4.Rows[i]["ParentTxnSysID"]);




                            _MtrInsRiderMdl1.IsValidTxn = true;

                            _MtrInsRiderMdlList1.Add(_MtrInsRiderMdl1);
                        }


                        //Insert In To Ins Rider
                        SqlConnection _conSql8 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql8 = new StringBuilder();
                        SqlCommand _cmdSql8;


                        MtrInsRiderMdl[] RiderArray = _MtrInsRiderMdlList1.ToArray();

                        for (int j = 0; j < RiderArray.Length; j++)
                        {
                            _sbSql8 = new StringBuilder();

                            _sbSql8.AppendLine("INSERT INTO InsMtrRider(");
                            //_sbSql.AppendLine("TxnSysID,");
                            //_sbSql.AppendLine("TxnSysDate,");
                            _sbSql8.AppendLine("UserCode,");
                            _sbSql8.AppendLine("RiderCode,");
                            _sbSql8.AppendLine("RiderName,");
                            _sbSql8.AppendLine("RiderRate,");
                            _sbSql8.AppendLine("ParentTxnSysID)");



                            _sbSql8.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                            // _sbSql.AppendLine("@TxnSysID,");
                            //  _sbSql.AppendLine("@TxnSysDate,");
                            _sbSql8.AppendLine("@UserCode,");
                            _sbSql8.AppendLine("@RiderCode,");
                            _sbSql8.AppendLine("@RiderName,");
                            _sbSql8.AppendLine("@RiderRate,");
                            _sbSql8.AppendLine("(SELECT MAX(ip.ParentTxnSysID) FROM InsPolicy ip))");




                            _cmdSql8 = new SqlCommand(_sbSql8.ToString(), _conSql8);
                            int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsRiderMdl1.UserCode);
                            _cmdSql8.Parameters.AddWithValue("@UserCode", _userCode);
                            _cmdSql8.Parameters.AddWithValue("@RiderCode", RiderArray[j].RiderCode);
                            _cmdSql8.Parameters.AddWithValue("@RiderName", RiderArray[j].RiderName);
                            _cmdSql8.Parameters.AddWithValue("@RiderRate", RiderArray[j].RiderRate);
                            //_cmdSql8.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsRiderMdl1.ParentTxnSysID);


                            int _TxnSysId2;
                            _conSql8.Open();
                            _TxnSysId2 = (Int32)_cmdSql8.ExecuteScalar();
                            _conSql8.Close();

                        }

                    }
                    else
                    {

                    }

                    //----------------For Ins Rider-----------------//

                    //----------------For Ins Conditions-----------------//

                    //Get Values From Ins Conditions
                    SqlConnection _conSql5 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    DataTable _tblSqla5 = new DataTable();
                    List<MtrInsConditionsMdl> _MtrInsConditionsMdlList1 = new List<MtrInsConditionsMdl>();
                    MtrInsConditionsMdl _MtrInsConditionsMdl1;


                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        string str = "SELECT * FROM InsMtrConditions WHERE ParentTxnSysID = @ParentTxnSysID";

                        SqlCommand command =
                            new SqlCommand(str, conn);

                        command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                        SqlDataAdapter _adpSql5 = new SqlDataAdapter(command);


                        _adpSql5.Fill(_tblSqla5);
                    }


                    if (_tblSqla5.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla5.Rows.Count; i++)
                        {
                            _MtrInsConditionsMdl1 = new MtrInsConditionsMdl();

                          //  _MtrInsConditionsMdl1.TxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["TxnSysID"]);
                          //  _MtrInsConditionsMdl1.TxnSysDate = Convert.ToDateTime(_tblSqla5.Rows[i]["TxnSysDate"]);
                            _MtrInsConditionsMdl1.UserCode = Convert.ToInt32(_tblSqla5.Rows[i]["UserCode"]);
                          //  _MtrInsConditionsMdl1.ParentTxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["ParentTxnSysID"]);
                            _MtrInsConditionsMdl1.Condition = _tblSqla5.Rows[i]["Condition"].ToString();

                            _MtrInsConditionsMdl1.ConditionShText = GlobalDataLayer.GetConditionByCode(_tblSqla5.Rows[i]["Condition"].ToString());



                            _MtrInsConditionsMdl1.IsValidTxn = true;

                            _MtrInsConditionsMdlList1.Add(_MtrInsConditionsMdl1);
                        }

                        //Insert Into Ins Conditions
                        SqlConnection _conSql9 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql9 = new StringBuilder();
                        SqlCommand _cmdSql9;


                        MtrInsConditionsMdl[] ConditionsArray = _MtrInsConditionsMdlList1.ToArray();

                        for (int j = 0; j < ConditionsArray.Length; j++)
                        {
                            _sbSql9 = new StringBuilder();

                            _sbSql9.AppendLine("INSERT INTO InsMtrConditions(");
                            _sbSql9.AppendLine("ParentTxnSysID,");
                            _sbSql9.AppendLine("Condition)");

                            _sbSql9.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                            _sbSql9.AppendLine("(SELECT MAX(ip.ParentTxnSysID) FROM InsPolicy ip),");
                            _sbSql9.AppendLine("@Condition)");

                            _cmdSql9 = new SqlCommand(_sbSql9.ToString(), _conSql9);

                            //_cmdSql9.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsRiderMdl1.ParentTxnSysID);
                            _cmdSql9.Parameters.AddWithValue("@Condition", ConditionsArray[j].Condition.ToString());

                            int _TxnSysId3;
                            _conSql9.Open();
                            _TxnSysId3 = (Int32)_cmdSql9.ExecuteScalar();
                            _conSql9.Close();
                        }

                    }
                    else
                    {

                    }

                    //----------------For Ins Conditions-----------------//

                    //----------------For Ins Warranties-----------------//

                    //Get Values From InsWarranties
                    SqlConnection _conSql6 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    DataTable _tblSqla6 = new DataTable();
                    List<MtrInsWarrantiesMdl> _MtrInsWarrantiesMdlList1 = new List<MtrInsWarrantiesMdl>();
                    MtrInsWarrantiesMdl _MtrInsWarrantiesMdl1;


                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        string str = "SELECT * FROM InsMtrWarranties WHERE ParentTxnSysID = @ParentTxnSysID";

                        SqlCommand command =
                            new SqlCommand(str, conn);

                        command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                        SqlDataAdapter _adpSql6 = new SqlDataAdapter(command);


                        _adpSql6.Fill(_tblSqla6);
                    }


                    //  _adpSql.Fill(_tbl);

                    if (_tblSqla6.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla6.Rows.Count; i++)
                        {
                            _MtrInsWarrantiesMdl1 = new MtrInsWarrantiesMdl();

                          //  _MtrInsWarrantiesMdl1.TxnSysID = Convert.ToInt32(_tblSqla6.Rows[i]["TxnSysID"]);
                           // _MtrInsWarrantiesMdl1.TxnSysDate = Convert.ToDateTime(_tblSqla6.Rows[i]["TxnSysDate"]);
                            _MtrInsWarrantiesMdl1.UserCode = Convert.ToInt32(_tblSqla6.Rows[i]["UserCode"]);
                            _MtrInsWarrantiesMdl1.Warranty = _tblSqla6.Rows[i]["Warranty"].ToString();
                           // _MtrInsWarrantiesMdl1.ParentTxnSysID = Convert.ToInt32(_tblSqla6.Rows[i]["ParentTxnSysID"]);

                            _MtrInsWarrantiesMdl1.WarrantyShText = GlobalDataLayer.GetWarrantyTextByCode(_tblSqla6.Rows[i]["Warranty"].ToString());




                            _MtrInsWarrantiesMdl1.IsValidTxn = true;

                            _MtrInsWarrantiesMdlList1.Add(_MtrInsWarrantiesMdl1);
                        }

                        //Insert In To InsWarranties
                        SqlConnection _conSql10 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql10 = new StringBuilder();
                        SqlCommand _cmdSql10;



                        _cmdSql10 = new SqlCommand(_sbSql10.ToString(), _conSql10);

                        MtrInsWarrantiesMdl[] WarrantyArray = _MtrInsWarrantiesMdlList1.ToArray();

                        for (int j = 0; j < WarrantyArray.Length; j++)
                        {
                            _sbSql10 = new StringBuilder();

                            _sbSql10.AppendLine("INSERT INTO InsMtrWarranties(");
                            _sbSql10.AppendLine("ParentTxnSysID,");
                            _sbSql10.AppendLine("Warranty)");

                            _sbSql10.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                            _sbSql10.AppendLine("(SELECT MAX(ip.ParentTxnSysID) FROM InsPolicy ip),");
                            _sbSql10.AppendLine("@Warranty)");

                            _cmdSql10 = new SqlCommand(_sbSql10.ToString(), _conSql10);

                           // _cmdSql10.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsRiderMdl1.ParentTxnSysID);
                            _cmdSql10.Parameters.AddWithValue("@Warranty", WarrantyArray[j].Warranty.ToString());

                            int _TxnSysId4;
                            _conSql10.Open();
                            _TxnSysId4 = (Int32)_cmdSql10.ExecuteScalar();
                            _conSql10.Close();
                        }

                    }
                    else
                    {

                    }

                    //----------------For Ins Warranties-----------------//

                    //----------------For Vehicle Details-----------------//

                    //Get Values From Vehicle Details
                    SqlConnection _conSql11 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    string _sqlString11 = "SELECT * FROM MtrVehicleDetails mvd INNER JOIN InsPolicy ip ON mvd.ParentTxnSysID = ip.ParentTxnSysID WHERE ip.IsActive <> 0 AND mvd.ParentTxnSysID =  " + _MtrInsPolicyMdl1.ParentTxnSysID;

                    SqlDataAdapter _adpSql11 = new SqlDataAdapter(_sqlString11, _conSql11);
                    DataTable _tblSqla11 = new DataTable();
                    List<VehicleDetailMdl> _VehicleDetailMdlList1 = new List<VehicleDetailMdl>();
                    VehicleDetailMdl _VehicleDetailMdl1 = new VehicleDetailMdl();

                    _adpSql11.Fill(_tblSqla11);

                    if (_tblSqla11.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla11.Rows.Count; i++)
                        {

                            _VehicleDetailMdl1 = new VehicleDetailMdl();

                            _VehicleDetailMdl1.TxnSysID = Convert.ToInt32(_tblSqla11.Rows[i]["TxnSysID"]);
                            _VehicleDetailMdl1.TxnSysDate = Convert.ToDateTime(_tblSqla11.Rows[i]["TxnSysDate"]);
                            _VehicleDetailMdl1.UserCode = Convert.ToInt32(_tblSqla11.Rows[i]["UserCode"]);
                            _VehicleDetailMdl1.SerialNo = Convert.ToInt32(_tblSqla11.Rows[i]["SerialNo"].ToString());
                            _VehicleDetailMdl1.VehicleCode = Convert.ToInt32(_tblSqla11.Rows[i]["VehicleCode"].ToString());
                            _VehicleDetailMdl1.VehicleModel = Convert.ToInt32(_tblSqla11.Rows[i]["VehicleModel"].ToString());
                            _VehicleDetailMdl1.UpdatedValue = Convert.ToDecimal(_tblSqla11.Rows[i]["UpdatedValue"]);
                            _VehicleDetailMdl1.PreviousValue = Convert.ToDecimal(_tblSqla11.Rows[i]["PreviousValue"]);
                            _VehicleDetailMdl1.Mileage = Convert.ToInt32(_tblSqla11.Rows[i]["Mileage"].ToString());
                            _VehicleDetailMdl1.ParticipantValue = Convert.ToDecimal(_tblSqla11.Rows[i]["ParticipantValue"]);
                            SumCovered = Convert.ToDecimal(_tblSqla11.Rows[i]["ParticipantValue"]);
                            _VehicleDetailMdl1.ColorCode = Convert.ToInt32(_tblSqla11.Rows[i]["ColorCode"].ToString());
                            _VehicleDetailMdl1.ParticipantName = _tblSqla11.Rows[i]["ParticipantName"].ToString();
                            _VehicleDetailMdl1.ParticipantAddress = _tblSqla11.Rows[i]["ParticipantAddress"].ToString();

                            _VehicleDetailMdl1.RegistrationNumber = _tblSqla11.Rows[i]["RegistrationNumber"].ToString();
                            _VehicleDetailMdl1.CityCode = _tblSqla11.Rows[i]["CityCode"].ToString();
                            _VehicleDetailMdl1.EngineNumber = _tblSqla11.Rows[i]["EngineNumber"].ToString();
                            _VehicleDetailMdl1.AreaCode = Convert.ToInt32(_tblSqla11.Rows[i]["AreaCode"].ToString());
                            _VehicleDetailMdl1.ChasisNumber = _tblSqla11.Rows[i]["ChasisNumber"].ToString();
                            _VehicleDetailMdl1.Remarks = _tblSqla11.Rows[i]["Remarks"].ToString();
                            _VehicleDetailMdl1.PODate = Convert.ToDateTime(_tblSqla11.Rows[i]["PODate"]);
                            _VehicleDetailMdl1.PONumber = (_tblSqla11.Rows[i]["PONumber"].ToString() ?? DBNull.Value.ToString());
                            _VehicleDetailMdl1.CNICNumber = _tblSqla11.Rows[i]["CNICNumber"].ToString();
                            _VehicleDetailMdl1.Tenure = _tblSqla11.Rows[i]["Tenure"].ToString();
                            _VehicleDetailMdl1.BirthDate = Convert.ToDateTime(_tblSqla11.Rows[i]["BirthDate"]);
                            _VehicleDetailMdl1.Gender = _tblSqla11.Rows[i]["Gender"].ToString();
                            _VehicleDetailMdl1.VehicleType = _tblSqla11.Rows[i]["VehicleType"].ToString();
                            _VehicleDetailMdl1.VEODCode = Convert.ToInt32(_tblSqla11.Rows[i]["VEODCode"]);
                            _VehicleDetailMdl1.CertTypeCode = _tblSqla11.Rows[i]["CertTypeCode"].ToString();
                            _VehicleDetailMdl1.Rate = Convert.ToInt32(_tblSqla11.Rows[i]["Rate"]);
                            Rate = Convert.ToInt32(_tblSqla11.Rows[i]["Rate"]);
                            _VehicleDetailMdl1.Contribution = Convert.ToInt32(_tblSqla11.Rows[i]["Contribution"]);
                            _VehicleDetailMdl1.ParentTxnSysID = Convert.ToInt32(_tblSqla11.Rows[i]["ParentTxnSysID"]);
                            _VehicleDetailMdl1.OpolTxnSysID = Convert.ToInt32(_tblSqla11.Rows[i]["OpolTxnSysID"]);

                            _VehicleDetailMdl1.VEODName = GlobalDataLayer.GetVEODNameByCode(Convert.ToInt32(_tblSqla11.Rows[i]["VEODCode"]));
                            _VehicleDetailMdl1.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_tblSqla11.Rows[i]["VehicleType"].ToString() ?? DBNull.Value.ToString());

                            _VehicleDetailMdl1.RatingFactor = _tblSqla11.Rows[i]["RatingFactor"].ToString();
                            _VehicleDetailMdl1.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_tblSqla11.Rows[i]["RatingFactor"].ToString());

                            _VehicleDetailMdl1.InsuranceTypeCode = Convert.ToInt32(_tblSqla11.Rows[i]["InsuranceTypeCode"]);
                            _VehicleDetailMdl1.IsActive = Convert.ToBoolean(_tblSqla11.Rows[i]["IsActive"]);
                            _VehicleDetailMdl1.IsCanceled = Convert.ToBoolean(_tblSqla11.Rows[i]["IsCanceled"]);
                            _VehicleDetailMdl1.CommisionRate = Convert.ToDecimal(_tblSqla11.Rows[i]["CommisionRate"]);
                            _VehicleDetailMdl1.MobileNumber = _tblSqla11.Rows[i]["MobileNumber"].ToString() ?? DBNull.Value.ToString();
                            _VehicleDetailMdl1.ResNumber = _tblSqla11.Rows[i]["ResNumber"].ToString() ?? DBNull.Value.ToString();
                            _VehicleDetailMdl1.OfficeNumber = _tblSqla11.Rows[i]["OfficeNumber"].ToString() ?? DBNull.Value.ToString();

                            _VehicleDetailMdl1.EmailAddress = _tblSqla11.Rows[i]["EmailAddress"].ToString();
                            _VehicleDetailMdl1.Deductible = Convert.ToDecimal(_tblSqla11.Rows[i]["Deductible"]);

                            _VehicleDetailMdl1.ContractMatDate = Convert.ToDateTime(_tblSqla11.Rows[i]["ContractMatDate"]);
                            _VehicleDetailMdl1.total = GlobalDataLayer.calculate(_VehicleDetailMdl1);


                            _VehicleDetailMdlList1.Add(_VehicleDetailMdl1);


                        }


                        //Insert Values To Vehicle Details For Renewal
                        SqlConnection _conSql12 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql12 = new StringBuilder();
                        SqlCommand _cmdSql12;
                        int _SerialNumber1 = GetSerialNo1(_VehicleDetailMdl1);

                        _sbSql12.AppendLine("INSERT INTO MtrVehicleDetails(");
                        // _sbSql.AppendLine("TxnSysID,");
                        _sbSql12.AppendLine("TxnSysDate,");
                        _sbSql12.AppendLine("UserCode,");
                        _sbSql12.AppendLine("SerialNo,");
                        _sbSql12.AppendLine("VehicleCode,");
                        _sbSql12.AppendLine("VehicleModel,");
                        _sbSql12.AppendLine("UpdatedValue,");
                        _sbSql12.AppendLine("PreviousValue,");
                        _sbSql12.AppendLine("Mileage,");
                        _sbSql12.AppendLine("ParticipantValue,");
                        _sbSql12.AppendLine("ColorCode,");
                        _sbSql12.AppendLine("ParticipantName,");
                        _sbSql12.AppendLine("ParticipantAddress,");
                        // _sbSql.AppendLine("ModelNumber,");
                        _sbSql12.AppendLine("RegistrationNumber,");
                        _sbSql12.AppendLine("CityCode,");
                        _sbSql12.AppendLine("EngineNumber,");
                        _sbSql12.AppendLine("AreaCode,");
                        _sbSql12.AppendLine("ChasisNumber,");
                        _sbSql12.AppendLine("Remarks,");
                        _sbSql12.AppendLine("PODate,");
                        _sbSql12.AppendLine("PONumber,");
                        _sbSql12.AppendLine("CNICNumber,");
                        _sbSql12.AppendLine("Tenure,");
                        _sbSql12.AppendLine("BirthDate,");
                        _sbSql12.AppendLine("Gender,");
                        _sbSql12.AppendLine("VehicleType,");
                        _sbSql12.AppendLine("VEODCode,");
                        _sbSql12.AppendLine("CertTypeCode,");
                        _sbSql12.AppendLine("Rate,");
                        _sbSql12.AppendLine("ParentTxnSysID,");
                        _sbSql12.AppendLine("OpolTxnSysID,");
                        _sbSql12.AppendLine("InsuranceTypeCode,");
                        _sbSql12.AppendLine("CommisionRate,");
                        _sbSql12.AppendLine("MobileNumber,");
                        _sbSql12.AppendLine("ResNumber,");
                        _sbSql12.AppendLine("OfficeNumber,");
                        _sbSql12.AppendLine("EmailAddress,");
                        _sbSql12.AppendLine("Deductible,");
                        _sbSql12.AppendLine("ContractMatDate,");
                        _sbSql12.AppendLine("RatingFactor,");
                        _sbSql12.AppendLine("Contribution)");


                        _sbSql12.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                        // _sbSql12.AppendLine("@TxnSysID,");
                        _sbSql12.AppendLine("@TxnSysDate,");
                        _sbSql12.AppendLine("@UserCode,");
                        _sbSql12.AppendLine("@SerialNo,");
                        _sbSql12.AppendLine("@VehicleCode,");
                        _sbSql12.AppendLine("@VehicleModel,");
                        _sbSql12.AppendLine("@UpdatedValue,");
                        _sbSql12.AppendLine("@PreviousValue,");
                        _sbSql12.AppendLine("@Mileage,");
                        _sbSql12.AppendLine("@ParticipantValue,");
                        _sbSql12.AppendLine("@ColorCode,");
                        _sbSql12.AppendLine("@ParticipantName,");
                        _sbSql12.AppendLine("@ParticipantAddress,");
                        // _sbSql12.AppendLine("@ModelNumber,");
                        _sbSql12.AppendLine("@RegistrationNumber,");
                        _sbSql12.AppendLine("@CityCode,");
                        _sbSql12.AppendLine("@EngineNumber,");
                        _sbSql12.AppendLine("@AreaCode,");
                        _sbSql12.AppendLine("@ChasisNumber,");
                        _sbSql12.AppendLine("@Remarks,");
                        _sbSql12.AppendLine("@PODate,");
                        _sbSql12.AppendLine("@PONumber,");
                        _sbSql12.AppendLine("@CNICNumber,");
                        _sbSql12.AppendLine("@Tenure,");
                        _sbSql12.AppendLine("@BirthDate,");
                        _sbSql12.AppendLine("@Gender,");
                        _sbSql12.AppendLine("@VehicleType,");
                        _sbSql12.AppendLine("@VEODCode,");
                        _sbSql12.AppendLine("@CertTypeCode,");
                        _sbSql12.AppendLine("@Rate,");
                        _sbSql12.AppendLine("(SELECT MAX(ip.ParentTxnSysID) FROM InsPolicy ip),");
                        _sbSql12.AppendLine("@OpolTxnSysID,");
                        _sbSql12.AppendLine("@InsuranceTypeCode,");
                        _sbSql12.AppendLine("@CommisionRate,");
                        _sbSql12.AppendLine("@MobileNumber,");
                        _sbSql12.AppendLine("@ResNumber,");
                        _sbSql12.AppendLine("@OfficeNumber,");
                        _sbSql12.AppendLine("@EmailAddress,");
                        _sbSql12.AppendLine("@Deductible,");
                        _sbSql12.AppendLine("@ContractMatDate,");
                        _sbSql12.AppendLine("@RatingFactor,");
                        _sbSql12.AppendLine("@Contribution)");


                        _cmdSql12 = new SqlCommand(_sbSql12.ToString(), _conSql12);

                        decimal ParticipantV = 0;
                        ParticipantV = SumCovered - (SumCovered * (_MtrInsPolicyMdl1.Deduct / 100));

                        Contribution = ParticipantV * (Rate / 100);

                        DateTime da = DateTime.Now;
                        da.ToString("MM-dd-yyyy h:mm tt");

                        _cmdSql12.Parameters.AddWithValue("@TxnSysDate", Convert.ToDateTime(da));
                        int _userCode = GlobalDataLayer.GetUserCodeById(_VehicleDetailMdl1.UserCode);
                        _cmdSql12.Parameters.AddWithValue("@UserCode", _userCode);

                        _cmdSql12.Parameters.AddWithValue("@SerialNo", _SerialNumber1);

                       // _cmdSql12.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID);
                        _cmdSql12.Parameters.AddWithValue("@OpolTxnSysID", _VehicleDetailMdl1.OpolTxnSysID);

                        _cmdSql12.Parameters.AddWithValue("@VehicleCode", _VehicleDetailMdl1.VehicleCode);
                        _cmdSql12.Parameters.AddWithValue("@VehicleModel", _VehicleDetailMdl1.VehicleModel);
                        _cmdSql12.Parameters.AddWithValue("@UpdatedValue", _VehicleDetailMdl1.UpdatedValue);
                        _cmdSql12.Parameters.AddWithValue("@PreviousValue", _VehicleDetailMdl1.PreviousValue);
                        _cmdSql12.Parameters.AddWithValue("@Mileage", _VehicleDetailMdl1.Mileage);
                        _cmdSql12.Parameters.AddWithValue("@ParticipantValue", ParticipantV);
                        _cmdSql12.Parameters.AddWithValue("@ColorCode", _VehicleDetailMdl1.ColorCode);
                        _cmdSql12.Parameters.AddWithValue("@ParticipantName", _VehicleDetailMdl1.ParticipantName);
                        _cmdSql12.Parameters.AddWithValue("@ParticipantAddress", _VehicleDetailMdl1.ParticipantAddress);
                        // _cmdSql12.Parameters.AddWithValue("@ModelNumber", _VehicleDetailMdl.ModelNumber);
                        _cmdSql12.Parameters.AddWithValue("@RegistrationNumber", _VehicleDetailMdl1.RegistrationNumber);
                        _cmdSql12.Parameters.AddWithValue("@CityCode", _VehicleDetailMdl1.CityCode);
                        _cmdSql12.Parameters.AddWithValue("@EngineNumber", _VehicleDetailMdl1.EngineNumber);
                        _cmdSql12.Parameters.AddWithValue("@AreaCode", _VehicleDetailMdl1.AreaCode);
                        _cmdSql12.Parameters.AddWithValue("@ChasisNumber", _VehicleDetailMdl1.ChasisNumber);
                        _cmdSql12.Parameters.AddWithValue("@Remarks", _VehicleDetailMdl1.Remarks ?? DBNull.Value.ToString());
                        _cmdSql12.Parameters.AddWithValue("@PODate", _VehicleDetailMdl1.PODate);
                        _cmdSql12.Parameters.AddWithValue("@PONumber", _VehicleDetailMdl1.PONumber ?? DBNull.Value.ToString());
                        _cmdSql12.Parameters.AddWithValue("@CNICNumber", _VehicleDetailMdl1.CNICNumber);
                        _cmdSql12.Parameters.AddWithValue("@Tenure", _VehicleDetailMdl1.Tenure);
                        _cmdSql12.Parameters.AddWithValue("@BirthDate", _VehicleDetailMdl1.BirthDate);
                        _cmdSql12.Parameters.AddWithValue("@Gender", _VehicleDetailMdl1.Gender);
                        _cmdSql12.Parameters.AddWithValue("@VehicleType", _VehicleDetailMdl1.VehicleType);
                        _cmdSql12.Parameters.AddWithValue("@VEODCode", _VehicleDetailMdl1.VEODCode);
                        _cmdSql12.Parameters.AddWithValue("@CertTypeCode", _VehicleDetailMdl1.CertTypeCode);
                        _cmdSql12.Parameters.AddWithValue("@Rate", _VehicleDetailMdl1.Rate);
                        _cmdSql12.Parameters.AddWithValue("@InsuranceTypeCode", _VehicleDetailMdl1.InsuranceTypeCode);
                        InsuranceType = _VehicleDetailMdl1.InsuranceTypeCode;
                        _cmdSql12.Parameters.AddWithValue("@Contribution", Contribution);
                        _cmdSql12.Parameters.AddWithValue("@CommisionRate", _VehicleDetailMdl1.CommisionRate);
                        _cmdSql12.Parameters.AddWithValue("@MobileNumber", _VehicleDetailMdl1.MobileNumber ?? DBNull.Value.ToString());
                        _cmdSql12.Parameters.AddWithValue("@ResNumber", _VehicleDetailMdl1.ResNumber ?? DBNull.Value.ToString());
                        _cmdSql12.Parameters.AddWithValue("@OfficeNumber", _VehicleDetailMdl1.OfficeNumber ?? DBNull.Value.ToString());

                        _cmdSql12.Parameters.AddWithValue("@EmailAddress", _VehicleDetailMdl1.EmailAddress ?? DBNull.Value.ToString());
                        _cmdSql12.Parameters.AddWithValue("@Deductible", _VehicleDetailMdl1.Deductible);
                        _cmdSql12.Parameters.AddWithValue("@ContractMatDate", _VehicleDetailMdl1.ContractMatDate);

                        _cmdSql12.Parameters.AddWithValue("@RatingFactor", _VehicleDetailMdl1.RatingFactor);

                        _VehicleDetailMdl1.SerialNo = _SerialNumber1;

                        _VehicleDetailMdl1.TxnSysDate = DateTime.Now;
                        _VehicleDetailMdl1.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_VehicleDetailMdl1.RatingFactor);

                        _VehicleDetailMdl1.total = GlobalDataLayer.calculate(_VehicleDetailMdl1);


                        int _TxnSysId5;
                        _conSql12.Open();
                        _TxnSysId5 = (Int32)_cmdSql12.ExecuteScalar();
                        _conSql12.Close();

                    }


                    else
                    {

                    }
                    //----------------For Vehicle Details-----------------//



                    //----------------For Mtr Contribution-----------------//

                    //Get Values From Mtr Contribution
                    SqlConnection _conSql13 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    DataTable _tblSqla13 = new DataTable();
                    MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();
                    List<MtrVContributionMdl> _MtrVContributionMdlList1 = new List<MtrVContributionMdl>();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        string str = "SELECT * FROM InsContribution ic INNER JOIN MtrVehicleDetails mvd ON mvd.TxnSysID = ic.RiskTxnID WHERE mvd.ParentTxnSysID = @ParentTxnSysID ";

                        SqlCommand command =
                            new SqlCommand(str, conn);

                        command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                        SqlDataAdapter _adpSql13 = new SqlDataAdapter(command);


                        _adpSql13.Fill(_tblSqla13);
                    }

                    //  _adpSql.Fill(_tblSqla);

                    if (_tblSqla13.Rows.Count > 0)
                    {
                        _MtrVContributionMdl1 = new MtrVContributionMdl();
                        for (int i = 0; i < _tblSqla13.Rows.Count; i++)
                        {
                            _MtrVContributionMdl1 = new MtrVContributionMdl();

                            _MtrVContributionMdl1.TxnSysID = Convert.ToInt32(_tblSqla13.Rows[i]["TxnSysID"]);
                            _MtrVContributionMdl1.TxnSysDate = Convert.ToDateTime(_tblSqla13.Rows[i]["TxnSysDate"]);
                            _MtrVContributionMdl1.UserCode = Convert.ToInt32(_tblSqla13.Rows[i]["UserCode"]);
                            _MtrVContributionMdl1.SumCovered = Convert.ToInt32(_tblSqla13.Rows[i]["SumCovered"]);
                            _MtrVContributionMdl1.Rate = Convert.ToDecimal(_tblSqla13.Rows[i]["Rate"]);
                            _MtrVContributionMdl1.NetContribution = Convert.ToDecimal(_tblSqla13.Rows[i]["NetContribution"]);
                            _MtrVContributionMdl1.GrossContribution = Convert.ToDecimal(_tblSqla13.Rows[i]["GrossContribution"]);
                            _MtrVContributionMdl1.FIF = Convert.ToDecimal(_tblSqla13.Rows[i]["FIF"]);
                            _MtrVContributionMdl1.FED = Convert.ToDecimal(_tblSqla13.Rows[i]["FED"]);
                            _MtrVContributionMdl1.Stamp = Convert.ToDecimal(_tblSqla13.Rows[i]["Stamp"]);
                            _MtrVContributionMdl1.BasicContribution = Convert.ToDecimal(_tblSqla13.Rows[i]["BasicContribution"]);
                            _MtrVContributionMdl1.PEV = Convert.ToDecimal(_tblSqla13.Rows[i]["PEV"]);
                            _MtrVContributionMdl1.BeforePEV = Convert.ToDecimal(_tblSqla13.Rows[i]["BeforePEV"]);
                            _MtrVContributionMdl1.TerrorContribution = Convert.ToDecimal(_tblSqla13.Rows[i]["TerrorContribution"]);
                            _MtrVContributionMdl1.RiskTxnID = Convert.ToInt32(_tblSqla13.Rows[i]["RiskTxnID"]);
                            _MtrVContributionMdl1.PerDayContribution = Convert.ToInt32(_tblSqla13.Rows[i]["PerDayContribution"]);
                            _MtrVContributionMdl1.OpolTxnSysID = Convert.ToInt32(_tblSqla13.Rows[i]["OpolTxnSysID"]);

                            _MtrVContributionMdlList1.Add(_MtrVContributionMdl1);
                        }


                        //Insert In To Mtr Ins Contribution 
                        SqlConnection _conSql14 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql14 = new StringBuilder();
                        SqlCommand _cmdSql14;

                       

                        NetContribution = SumCovered * _MtrVContributionMdl1.Rate;
                        GrossContribution = (NetContribution - _MtrVContributionMdl1.Stamp) / (((_MtrVContributionMdl1.FIF + _MtrVContributionMdl1.FED) / 100) + 1);
                        


                        //To get Tenure
                        DataTable _tbl = new DataTable();
                        MtrVContributionMdl _MtrVContributionMdlA = new MtrVContributionMdl();

                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                        {
                            SqlCommand command =
                                new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = @ParentTxnSysID", conn);

                            command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                            SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                            _adpSql.Fill(_tbl);
                        }

                        // _adpSql.Fill(_tbl);

                        if (_tbl.Rows.Count > 0)
                        {
                            for (int i = 0; i < _tbl.Rows.Count; i++)
                            {
                                _MtrVContributionMdlA = new MtrVContributionMdl();
                                _MtrVContributionMdlA.Tenure = Convert.ToInt32(_tbl.Rows[i]["tenure"]);
                                tenure = Convert.ToInt32(_tbl.Rows[i]["tenure"]);
                            }


                        }
                        else
                        {
                            _MtrVContributionMdlA.Tenure = 365;
                            tenure = 365;
                        }

                        //Get Terrorism Contribution
                        if (SumCovered > 10000000)
                        {
                            terror = 1000;
                        }

                        else
                        {
                            terror = 400;
                        }

                        BeforePEV = GrossContribution - terror;
                        PEV = BeforePEV - _MtrVContributionMdl1.BasicContribution;
                        PerDay = GrossContribution / tenure;



                        _sbSql14.AppendLine("INSERT INTO InsContribution(");
                        // _sbSql.AppendLine("TxnSysID,");
                        _sbSql14.AppendLine("TxnSysDate,");
                        _sbSql14.AppendLine("UserCode,");
                        _sbSql14.AppendLine("SumCovered,");
                        _sbSql14.AppendLine("Rate,");
                        _sbSql14.AppendLine("NetContribution,");
                        _sbSql14.AppendLine("GrossContribution,");
                        _sbSql14.AppendLine("FIF,");
                        _sbSql14.AppendLine("FED,");
                        _sbSql14.AppendLine("Stamp,");
                        _sbSql14.AppendLine("BasicContribution,");
                        _sbSql14.AppendLine("PEV,");
                        _sbSql14.AppendLine("BeforePEV,");
                        _sbSql14.AppendLine("TerrorContribution,");
                        _sbSql14.AppendLine("RiskTxnID,");
                        _sbSql14.AppendLine("OpolTxnSysID,");
                        _sbSql14.AppendLine("PerDayContribution)");

                        _sbSql14.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                        //_sbSql.AppendLine("@TxnSysID,");
                        _sbSql14.AppendLine("@TxnSysDate,");
                        _sbSql14.AppendLine("@UserCode,");
                        _sbSql14.AppendLine("@SumCovered,");
                        _sbSql14.AppendLine("@Rate,");
                        _sbSql14.AppendLine("@NetContribution,");
                        _sbSql14.AppendLine("@GrossContribution,");
                        _sbSql14.AppendLine("@FIF,");
                        _sbSql14.AppendLine("@FED,");
                        _sbSql14.AppendLine("@Stamp,");
                        _sbSql14.AppendLine("@BasicContribution,");
                        _sbSql14.AppendLine("@PEV,");
                        _sbSql14.AppendLine("@BeforePEV,");
                        _sbSql14.AppendLine("@TerrorContribution,");
                        _sbSql14.AppendLine("(SELECT MAX(mvd.TxnSysID) FROM MtrVehicleDetails mvd),");
                        _sbSql14.AppendLine("@OpolTxnSysID,");
                        _sbSql14.AppendLine("@PerDayContribution)");

                        _cmdSql14 = new SqlCommand(_sbSql14.ToString(), _conSql14);

                        _cmdSql14.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                        _cmdSql14.Parameters.AddWithValue("@SumCovered", SumCovered);

                        int _userCode2 = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl1.UserCode);

                        _cmdSql14.Parameters.AddWithValue("@UserCode", _userCode2);

                        _cmdSql14.Parameters.AddWithValue("@Rate", _MtrVContributionMdl1.Rate);
                        _cmdSql14.Parameters.AddWithValue("@NetContribution", NetContribution);
                        _cmdSql14.Parameters.AddWithValue("@GrossContribution", GrossContribution);
                        _cmdSql14.Parameters.AddWithValue("@FIF", _MtrVContributionMdl1.FIF);
                        _cmdSql14.Parameters.AddWithValue("@FED", _MtrVContributionMdl1.FED);
                        _cmdSql14.Parameters.AddWithValue("@Stamp", _MtrVContributionMdl1.Stamp);
                        _cmdSql14.Parameters.AddWithValue("@BasicContribution", _MtrVContributionMdl1.BasicContribution);
                        _cmdSql14.Parameters.AddWithValue("@PEV", PEV);
                        _cmdSql14.Parameters.AddWithValue("@BeforePEV", BeforePEV);
                        _cmdSql14.Parameters.AddWithValue("@TerrorContribution", terror);
                        _cmdSql14.Parameters.AddWithValue("@PerDayContribution", PerDay);

                        _cmdSql14.Parameters.AddWithValue("@OpolTxnSysID", _MtrVContributionMdl1.OpolTxnSysID);

                        int _TxnSysId4;
                        _conSql14.Open();
                        _TxnSysId4 = (Int32)_cmdSql14.ExecuteScalar();
                        _conSql14.Close();

                        _MtrVContributionMdl1.TxnSysID = _TxnSysId4;
                        _MtrVContributionMdl1.IsValidTxn = true;
                    }


                    else
                    {

                    }

                    //----------------For Mtr Contribution-----------------//



                    // --------------- For Co-Insurance --------------------- //

                    //For CoInsurance of Leader
                    if (InsuranceType == 2)
                    {

                        SqlConnection _conSqlA1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        string _sqlStringA1 = "SELECT *  FROM InsCoInsuance Where RiskTxnID =" + _VehicleDetailMdl1.TxnSysID;
                        SqlDataAdapter _adpSqlA1 = new SqlDataAdapter(_sqlStringA1, _conSqlA1);
                        DataTable _tblSqlaA1 = new DataTable();
                        InsCoInsurance _InsCoInsuranceA1 = new InsCoInsurance();
                        List<InsCoInsurance> _InsCoInsuranceListA1 = new List<InsCoInsurance>();

                        _adpSqlA1.Fill(_tblSqlaA1);

                        if (_tblSqlaA1.Rows.Count > 0)
                        {

                            for (int i = 0; i < _tblSqlaA1.Rows.Count; i++)
                            {

                                _InsCoInsuranceA1 = new InsCoInsurance();

                                _InsCoInsuranceA1.FIF = Convert.ToDecimal(_tblSqlaA1.Rows[i]["FIF"]);
                                _InsCoInsuranceA1.FED = Convert.ToDecimal(_tblSqlaA1.Rows[i]["FED"]);
                                _InsCoInsuranceA1.CoInsuranceCode = Convert.ToInt32(_tblSqlaA1.Rows[i]["CoInsuranceCode"]);
                                _InsCoInsuranceA1.CoInsuranceShare = Convert.ToDecimal(_tblSqlaA1.Rows[i]["CoInsuranceShare"]);
                                _InsCoInsuranceA1.PEV = Decimal.Round(Convert.ToDecimal(_tblSqlaA1.Rows[i]["PEV"]), MidpointRounding.ToEven);
                                _InsCoInsuranceA1.BeforePEV = Decimal.Round(Convert.ToDecimal(_tblSqlaA1.Rows[i]["BeforePEV"]), MidpointRounding.ToEven);
                                _InsCoInsuranceA1.Stamp = Convert.ToDecimal(_tblSqlaA1.Rows[i]["Stamp"]);
                                _InsCoInsuranceA1.OpolTxnSysID = Convert.ToInt32(_tblSqlaA1.Rows[i]["OpolTxnSysID"]);
                                _InsCoInsuranceA1.Rate = Convert.ToDecimal(_tblSqlaA1.Rows[i]["Rate"]);
                                _InsCoInsuranceA1.BasicContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["BasicContribution"]);
                                _InsCoInsuranceA1.TerrorContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["TerrorContribution"]);
                                _InsCoInsuranceA1.NetContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["NetContribution"]);
                                _InsCoInsuranceA1.GrossContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["GrossContribution"]);
                                _InsCoInsuranceA1.PerDayContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["PerDayContribution"]);
                                _InsCoInsuranceA1.SumCovered = Convert.ToInt32(_tblSqlaA1.Rows[i]["SumCovered"]);

                                _InsCoInsuranceListA1.Add(_InsCoInsuranceA1);
                            }

                            //Insert InTo CoInsurance for Renewal
                            SqlConnection _conSqlA2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                            StringBuilder _sbSqlA2 = new StringBuilder();
                            SqlCommand _cmdSqlA2;
                            InsCoInsurance[] ConInsList = _InsCoInsuranceListA1.ToArray();


                            for (int i = 0; i < ConInsList.Length; i++)
                            {
                                _sbSqlA2 = new StringBuilder();

                                _sbSqlA2.AppendLine("INSERT INTO InsCoInsuance(");
                                //_sbSql.AppendLine("TxnSysID,");
                                _sbSqlA2.AppendLine("TxnSysDate,");
                                _sbSqlA2.AppendLine("UserCode,");
                                _sbSqlA2.AppendLine("SumCovered,");
                                _sbSqlA2.AppendLine("Rate,");
                                _sbSqlA2.AppendLine("NetContribution,");
                                _sbSqlA2.AppendLine("GrossContribution,");
                                _sbSqlA2.AppendLine("FIF,");
                                _sbSqlA2.AppendLine("FED,");
                                _sbSqlA2.AppendLine("Stamp,");
                                _sbSqlA2.AppendLine("BasicContribution,");
                                _sbSqlA2.AppendLine("PEV,");
                                _sbSqlA2.AppendLine("BeforePEV,");
                                _sbSqlA2.AppendLine("TerrorContribution,");
                                _sbSqlA2.AppendLine("RiskTxnID,");
                                _sbSqlA2.AppendLine("OpolTxnSysID,");
                                _sbSqlA2.AppendLine("PerDayContribution,");

                                _sbSqlA2.AppendLine("CoInsuranceCode,");
                                _sbSqlA2.AppendLine("CoInsuranceShare)");


                                decimal CoGross = 0, CoNet = 0, PEVCo = 0, BeforePEVCo = 0, PerDayContributionCo = 0;

                                CoGross = GrossContribution * ConInsList[i].CoInsuranceShare;
                                CoNet = NetContribution * ConInsList[i].CoInsuranceShare;
                                PEVCo = PEV * ConInsList[i].CoInsuranceShare;
                                BeforePEVCo = BeforePEV * ConInsList[i].CoInsuranceShare;
                                PerDayContributionCo = PerDay * ConInsList[i].CoInsuranceShare;


                                BeforePEV = CoGross - ConInsList[i].TerrorContribution;


                                _sbSqlA2.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                                //_sbSqlA2.AppendLine("@TxnSysID,");
                                _sbSqlA2.AppendLine("@TxnSysDate,");
                                _sbSqlA2.AppendLine("@UserCode,");
                                _sbSqlA2.AppendLine("@SumCovered,");
                                _sbSqlA2.AppendLine("@Rate,");
                                _sbSqlA2.AppendLine("@NetContribution,");
                                _sbSqlA2.AppendLine("@GrossContribution,");
                                _sbSqlA2.AppendLine("@FIF,");
                                _sbSqlA2.AppendLine("@FED,");
                                _sbSqlA2.AppendLine("@Stamp,");
                                _sbSqlA2.AppendLine("@BasicContribution,");
                                _sbSqlA2.AppendLine("@PEV,");
                                _sbSqlA2.AppendLine("@BeforePEV,");
                                _sbSqlA2.AppendLine("@TerrorContribution,");
                                _sbSqlA2.AppendLine("(SELECT MAX(mvd.TxnSysID) FROM MtrVehicleDetails mvd),");
                                _sbSqlA2.AppendLine("@OpolTxnSysID,");
                                _sbSqlA2.AppendLine("@PerDayContribution,");
                                _sbSqlA2.AppendLine("@CoInsuranceCode,");
                                _sbSqlA2.AppendLine("@CoInsuranceShare)");


                                _cmdSqlA2 = new SqlCommand(_sbSqlA2.ToString(), _conSqlA2);

                                _cmdSqlA2.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                                _cmdSqlA2.Parameters.AddWithValue("@SumCovered", ConInsList[i].SumCovered);

                                int _userCodeA2 = GlobalDataLayer.GetUserCodeById(ConInsList[i].UserCode);

                                _cmdSqlA2.Parameters.AddWithValue("@UserCode", _userCodeA2);


                                _cmdSqlA2.Parameters.AddWithValue("@Rate", ConInsList[i].Rate);
                                _cmdSqlA2.Parameters.AddWithValue("@NetContribution", CoGross);
                                _cmdSqlA2.Parameters.AddWithValue("@GrossContribution", CoNet);
                                _cmdSqlA2.Parameters.AddWithValue("@FIF", ConInsList[i].FIF);
                                _cmdSqlA2.Parameters.AddWithValue("@FED", ConInsList[i].FED);
                                _cmdSqlA2.Parameters.AddWithValue("@Stamp", ConInsList[i].Stamp);
                                _cmdSqlA2.Parameters.AddWithValue("@BasicContribution", ConInsList[i].BasicContribution);
                                _cmdSqlA2.Parameters.AddWithValue("@PEV", ConInsList[i].PEV);
                                _cmdSqlA2.Parameters.AddWithValue("@BeforePEV", ConInsList[i].BeforePEV);
                                _cmdSqlA2.Parameters.AddWithValue("@TerrorContribution", ConInsList[i].TerrorContribution);
                                // _cmdSqlA2.Parameters.AddWithValue("@RiskTxnID", ConInsList[i].RiskTxnID);
                                _cmdSqlA2.Parameters.AddWithValue("@OpolTxnSysID", ConInsList[i].OpolTxnSysID);
                                _cmdSqlA2.Parameters.AddWithValue("@PerDayContribution", PerDayContributionCo);
                                _cmdSqlA2.Parameters.AddWithValue("@CoInsuranceCode", ConInsList[i].CoInsuranceCode);
                                _cmdSqlA2.Parameters.AddWithValue("@CoInsuranceShare", ConInsList[i].CoInsuranceShare);


                                int _TxnSysId1;
                                _conSqlA2.Open();
                                _TxnSysId1 = (Int32)_cmdSqlA2.ExecuteScalar();
                                _conSqlA2.Close();
                            }


                        }


                        else
                        {



                        }

                    }
                    // --------------- For Co-Insurance --------------------- //



                    //Get Values From Contribution GROSS --> NET
                    SqlConnection _conSqlR = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    DataTable _tblSqlaR = new DataTable();
                   MtrVContributionMdl _MtrVContributionMdlR;
                    List<MtrVContributionMdl> _MtrVContributionMdlListR = new List<MtrVContributionMdl>();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        string str = "SELECT * FROM InsContribution ic WHERE ic.RiskTxnID = (SELECT MAX(mvd.TxnSysID) FROM MtrVehicleDetails mvd)";

                        SqlCommand command =
                            new SqlCommand(str, conn);



                        SqlDataAdapter _adpSqlR = new SqlDataAdapter(command);


                        _adpSqlR.Fill(_tblSqlaR);
                    }


                    if (_tblSqlaR.Rows.Count > 0)
                    {

                        _MtrVContributionMdlR = new MtrVContributionMdl();

                        for (int i = 0; i < _tblSqlaR.Rows.Count; i++)
                        {

                            //_MtrVContributionMdlR.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                            _MtrVContributionMdlR.TxnSysDate = Convert.ToDateTime(_tblSqlaR.Rows[i]["TxnSysDate"]);
                            _MtrVContributionMdlR.UserCode = Convert.ToInt32(_tblSqlaR.Rows[i]["UserCode"]);
                            _MtrVContributionMdlR.SumCovered = Convert.ToInt32(_tblSqlaR.Rows[i]["SumCovered"]);
                            _MtrVContributionMdlR.Rate = Convert.ToDecimal(_tblSqlaR.Rows[i]["Rate"]);
                            _MtrVContributionMdlR.NetContribution = Convert.ToDecimal(_tblSqlaR.Rows[i]["NetContribution"]);
                            _MtrVContributionMdlR.GrossContribution = Convert.ToDecimal(_tblSqlaR.Rows[i]["GrossContribution"]);
                            _MtrVContributionMdlR.FIF = Convert.ToDecimal(_tblSqlaR.Rows[i]["FIF"]);
                            _MtrVContributionMdlR.FED = Convert.ToDecimal(_tblSqlaR.Rows[i]["FED"]);
                            _MtrVContributionMdlR.Stamp = Convert.ToDecimal(_tblSqlaR.Rows[i]["Stamp"]);
                            _MtrVContributionMdlR.BasicContribution = Convert.ToDecimal(_tblSqlaR.Rows[i]["BasicContribution"]);
                            _MtrVContributionMdlR.PEV = Convert.ToDecimal(_tblSqlaR.Rows[i]["PEV"]);
                            _MtrVContributionMdlR.BeforePEV = Convert.ToDecimal(_tblSqlaR.Rows[i]["BeforePEV"]);
                            _MtrVContributionMdlR.TerrorContribution = Convert.ToDecimal(_tblSqlaR.Rows[i]["TerrorContribution"]);
                            _MtrVContributionMdlR.RiskTxnID = Convert.ToInt32(_tblSqlaR.Rows[i]["RiskTxnID"]);
                            _MtrVContributionMdlR.PerDayContribution = Convert.ToInt32(_tblSqlaR.Rows[i]["PerDayContribution"]);
                            _MtrVContributionMdlR.OpolTxnSysID = Convert.ToInt32(_tblSqlaR.Rows[i]["OpolTxnSysID"]);


                            _MtrVContributionMdlR.GrossContribution = Decimal.Round(Convert.ToDecimal(_tblSqlaR.Rows[i]["GrossContribution"]), MidpointRounding.ToEven);
                            _MtrVContributionMdlR.PEV = Decimal.Round(Convert.ToDecimal(_tblSqlaR.Rows[i]["PEV"]), MidpointRounding.ToEven);
                            _MtrVContributionMdlR.NetContribution = Decimal.Round(Convert.ToDecimal(_tblSqlaR.Rows[i]["NetContribution"]), MidpointRounding.ToEven);
                            _MtrVContributionMdlR.BeforePEV = Decimal.Round(Convert.ToDecimal(_tblSqlaR.Rows[i]["BeforePEV"]), MidpointRounding.ToEven);



                            _MtrVContributionMdlListR.Add(_MtrVContributionMdlR);
                        }

                        return _MtrVContributionMdlListR;

                    }


                    else
                    {

                        return null;

                    }


                }
                else
                {
                    return null;
                }

                


            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Renewal DataLayer");
                return null;
            }
        }

        //For Convert To Policy
        public MtrInsPolicyMdl ToConvertToPolicy(MtrInsPolicyMdl _MtrInsPolicyMdl1)
        {
            try
            {
                //Get Values from Ins Policy
                DataTable _tblSqla = new DataTable();
                List<MtrInsPolicyMdl> _MtrInsPolicyMdlList = new List<MtrInsPolicyMdl>();
                MtrInsPolicyMdl _MtrInsPolicyMdl = new MtrInsPolicyMdl();

                int InsuranceType = 0;

                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM InsPolicy WHERE  ParentTxnSysID= @ParentTxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrInsPolicyMdl = new MtrInsPolicyMdl();

                        _MtrInsPolicyMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["ParentTxnSysID"]);
                        _MtrInsPolicyMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrInsPolicyMdl.CertMonth = _tblSqla.Rows[i]["DocMonth"].ToString();
                        _MtrInsPolicyMdl.CertString = _tblSqla.Rows[i]["DocString"].ToString();
                        _MtrInsPolicyMdl.CertYear = _tblSqla.Rows[i]["DocYear"].ToString();
                        _MtrInsPolicyMdl.CertNo = Convert.ToInt32(_tblSqla.Rows[i]["DocNo"]);
                        _MtrInsPolicyMdl.DocType = _tblSqla.Rows[i]["DocType"].ToString();
                        _MtrInsPolicyMdl.GenerateAgainst = _tblSqla.Rows[i]["GenerateAgainst"].ToString();
                        _MtrInsPolicyMdl.ProductCode = Convert.ToInt32(_tblSqla.Rows[i]["ProductCode"]);
                        _MtrInsPolicyMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();
                        _MtrInsPolicyMdl.ClientCode = _tblSqla.Rows[i]["ClientCode"].ToString();
                        _MtrInsPolicyMdl.AgencyCode = _tblSqla.Rows[i]["AgencyCode"].ToString();
                        _MtrInsPolicyMdl.CertInsureCode = _tblSqla.Rows[i]["CertInsureCode"].ToString();
                        _MtrInsPolicyMdl.Remarks = _tblSqla.Rows[i]["Remarks"].ToString();
                        _MtrInsPolicyMdl.BrchCoverNoteNo = _tblSqla.Rows[i]["BrchCoverNoteNo"].ToString();
                        _MtrInsPolicyMdl.LeaderPolicyNo = _tblSqla.Rows[i]["LeaderPolicyNo"].ToString();
                        _MtrInsPolicyMdl.LeaderEndNo = _tblSqla.Rows[i]["LeaderEndNo"].ToString();
                        _MtrInsPolicyMdl.IsFiler = _tblSqla.Rows[i]["IsFiler"].ToString();
                        _MtrInsPolicyMdl.CalcType = _tblSqla.Rows[i]["CalcType"].ToString();
                        _MtrInsPolicyMdl.IsAuto = _tblSqla.Rows[i]["IsAuto"].ToString();
                        _MtrInsPolicyMdl.EffectiveDate = Convert.ToDateTime(_tblSqla.Rows[i]["EffectiveDate"]);
                        _MtrInsPolicyMdl.ExpiryDate = Convert.ToDateTime(_tblSqla.Rows[i]["ExpiryDate"]);
                        _MtrInsPolicyMdl.SerialNo = Convert.ToInt32(_tblSqla.Rows[i]["SerialNo"]);
                        _MtrInsPolicyMdl.UWYear = _tblSqla.Rows[i]["UWYear"].ToString();
                        _MtrInsPolicyMdl.CreatedBy = _tblSqla.Rows[i]["CreatedBy"].ToString();
                        _MtrInsPolicyMdl.PostedBy = _tblSqla.Rows[i]["PostedBy"].ToString();
                        _MtrInsPolicyMdl.IsPosted = Convert.ToBoolean(_tblSqla.Rows[i]["IsPosted"]);
                        //_MtrInsPolicyMdl.PostDate = Convert.ToDateTime(_tblSqla.Rows[i]["PostDate"]);
                        _MtrInsPolicyMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["OpolTxnSysID"]);
                        _MtrInsPolicyMdl.RenewSysID = Convert.ToInt32(_tblSqla.Rows[i]["RenewSysID"]);
                        _MtrInsPolicyMdl.PolSysID = Convert.ToInt32(_tblSqla.Rows[i]["PolSysID"]);
                        _MtrInsPolicyMdl.IsRenewal = Convert.ToBoolean(_tblSqla.Rows[i]["IsRenewal"]);
                        _MtrInsPolicyMdl.CommisionRate = Convert.ToDecimal(_tblSqla.Rows[i]["CommisionRate"]);
                        _MtrInsPolicyMdl.IsActive = Convert.ToBoolean(_tblSqla.Rows[i]["IsActive"]);

                        _MtrInsPolicyMdl.IsValidTxn = true;


                        _MtrInsPolicyMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(_tblSqla.Rows[i]["ProductCode"].ToString());
                        _MtrInsPolicyMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_tblSqla.Rows[i]["PolicyTypeCode"].ToString());
                        _MtrInsPolicyMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_tblSqla.Rows[i]["ClientCode"].ToString());
                        _MtrInsPolicyMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_tblSqla.Rows[i]["AgencyCode"].ToString());
                        _MtrInsPolicyMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_tblSqla.Rows[i]["CertInsureCode"].ToString());

                        _MtrInsPolicyMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(_tblSqla.Rows[i]["DocType"].ToString());
                        _MtrInsPolicyMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_tblSqla.Rows[i]["IsFiler"].ToString());
                        _MtrInsPolicyMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_tblSqla.Rows[i]["CalcType"].ToString());
                        _MtrInsPolicyMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_tblSqla.Rows[i]["IsAuto"].ToString());


                        _MtrInsPolicyMdl.IsValidTxn = true;

                        _MtrInsPolicyMdlList.Add(_MtrInsPolicyMdl);


                    }

                    ////Update Is Active to False in Ins Policy
                    //SqlConnection _conSqlA = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    //StringBuilder _sbSqlA = new StringBuilder();
                    //SqlCommand _cmdSqlA;
                    //_sbSqlA.AppendLine("Update  InsPolicy  SET");
                    //_sbSqlA.AppendLine("IsActive=@IsActive");
                    //_sbSqlA.AppendLine("WHERE ParentTxnSysID=@ParentTxnSysID ");
                    //_cmdSqlA = new SqlCommand(_sbSqlA.ToString(), _conSqlA);
                    //_cmdSqlA.Parameters.AddWithValue("@IsActive", false);
                    //_cmdSqlA.Parameters.AddWithValue("@ParentTxnSysID",_MtrInsPolicyMdl1.ParentTxnSysID);
                    //_conSqlA.Open();
                    //_cmdSqlA.ExecuteNonQuery();
                    //_conSqlA.Close();

                    //To Insert in to InsPolicy for Renewal
                    SqlConnection _conSql2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql2 = new StringBuilder();
                    SqlCommand _cmdSql2;
                    MtrInsPolicyMdl _MtrInsPolicyMdl2 = new MtrInsPolicyMdl();
                    int _SerialNumber = GetSerialNo(_MtrInsPolicyMdl2);


                    _sbSql2.AppendLine("INSERT INTO InsPolicy(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql2.AppendLine("TxnSysDate,");
                    _sbSql2.AppendLine("DocMonth,");
                    _sbSql2.AppendLine("DocString,");
                    _sbSql2.AppendLine("DocYear,");
                    _sbSql2.AppendLine("DocNo,");
                    _sbSql2.AppendLine("DocType,");
                    _sbSql2.AppendLine("GenerateAgainst,");
                    _sbSql2.AppendLine("ProductCode,");
                    _sbSql2.AppendLine("PolicyTypeCode,");
                    _sbSql2.AppendLine("ClientCode,");
                    _sbSql2.AppendLine("AgencyCode,");
                    _sbSql2.AppendLine("CertInsureCode,");
                    _sbSql2.AppendLine("Remarks,");
                    _sbSql2.AppendLine("BrchCoverNoteNo,");
                    _sbSql2.AppendLine("LeaderPolicyNo,");
                    _sbSql2.AppendLine("LeaderEndNo,");
                    _sbSql2.AppendLine("IsFiler,");
                    _sbSql2.AppendLine("CalcType,");
                    _sbSql2.AppendLine("IsAuto,");
                    _sbSql2.AppendLine("EffectiveDate,");
                    _sbSql2.AppendLine("ExpiryDate,");
                    _sbSql2.AppendLine("SerialNo,");
                    _sbSql2.AppendLine("UWYear,");
                    _sbSql2.AppendLine("CreatedBy,");
                    _sbSql2.AppendLine("CommisionRate,");

                    _sbSql2.AppendLine("IsPosted,");
                    // _sbSql2.AppendLine("PostDate,");
                    _sbSql2.AppendLine("IsRenewal,");
                    _sbSql2.AppendLine("RenewSysID,");

                    _sbSql2.AppendLine("OpolTxnSysID)");




                    _sbSql2.AppendLine("output INSERTED. ParentTxnSysID VALUES ( ");

                    _sbSql2.AppendLine("@TxnSysDate,");
                    _sbSql2.AppendLine("@DocMonth,");
                    _sbSql2.AppendLine("@DocString,");
                    _sbSql2.AppendLine("@DocYear,");
                    _sbSql2.AppendLine("@DocNo,");
                    _sbSql2.AppendLine("@DocType,");
                    _sbSql2.AppendLine("@GenerateAgainst,");
                    _sbSql2.AppendLine("@ProductCode,");
                    _sbSql2.AppendLine("@PolicyTypeCode,");
                    _sbSql2.AppendLine("@ClientCode,");
                    _sbSql2.AppendLine("@AgencyCode,");
                    _sbSql2.AppendLine("@CertInsureCode,");
                    _sbSql2.AppendLine("@Remarks,");
                    _sbSql2.AppendLine("@BrchCoverNoteNo,");
                    _sbSql2.AppendLine("@LeaderPolicyNo,");
                    _sbSql2.AppendLine("@LeaderEndNo,");
                    _sbSql2.AppendLine("@IsFiler,");
                    _sbSql2.AppendLine("@CalcType,");
                    _sbSql2.AppendLine("@IsAuto,");
                    _sbSql2.AppendLine("@EffectiveDate,");
                    _sbSql2.AppendLine("@ExpiryDate,");
                    _sbSql2.AppendLine("@SerialNo,");
                    _sbSql2.AppendLine("@UWYear,");
                    _sbSql2.AppendLine("@CreatedBy,");
                    _sbSql2.AppendLine("@CommisionRate,");
                    _sbSql2.AppendLine("@IsPosted,");
                    // _sbSql2.AppendLine("@PostDate,");
                    _sbSql2.AppendLine("@IsRenewal,");
                    _sbSql2.AppendLine("@RenewSysID,");
                    _sbSql2.AppendLine("@OpolTxnSysID)");



                    _cmdSql2 = new SqlCommand(_sbSql2.ToString(), _conSql2);
                    // DateTime da = DateTime.Now;
                    //  da.ToString("MM-dd-yyyy h:mm tt");
                    _cmdSql2.Parameters.AddWithValue("@TxnSysDate", SqlDbType.DateTime).Value = DateTime.Now;


                    _cmdSql2.Parameters.AddWithValue("@DocMonth", DateTime.Now.Month.ToString());
                    _cmdSql2.Parameters.AddWithValue("@RenewSysID", _MtrInsPolicyMdl.ParentTxnSysID);

                    _cmdSql2.Parameters.AddWithValue("@DocYear", (Convert.ToInt32(_MtrInsPolicyMdl.CertYear) + 1));

                    _cmdSql2.Parameters.AddWithValue("@DocNo", GlobalDataLayer.GettingNewCertNo(_MtrInsPolicyMdl));

                    string OpenPolicyDoc = "8";

                    _cmdSql2.Parameters.AddWithValue("@DocType", OpenPolicyDoc);


                    string CertString = GetCertString(
                        _MtrInsPolicyMdl.BrchCoverNoteNo,
                        _MtrInsPolicyMdl.CertInsureCode.ToString(),
                        OpenPolicyDoc,
                        Convert.ToInt32(_MtrInsPolicyMdl.PolicyTypeCode),
                        _SerialNumber,
                       DateTime.Now.Month.ToString(),
                           (_MtrInsPolicyMdl.CertYear + 1));




                    _cmdSql2.Parameters.AddWithValue("@DocString", CertString);

                    _cmdSql2.Parameters.AddWithValue("@GenerateAgainst", _MtrInsPolicyMdl.ParentTxnSysID);
                    _cmdSql2.Parameters.AddWithValue("@ProductCode", _MtrInsPolicyMdl.ProductCode);
                    _cmdSql2.Parameters.AddWithValue("@PolicyTypeCode", _MtrInsPolicyMdl.PolicyTypeCode);
                    _cmdSql2.Parameters.AddWithValue("@ClientCode", _MtrInsPolicyMdl.ClientCode);
                    _cmdSql2.Parameters.AddWithValue("@AgencyCode", _MtrInsPolicyMdl.AgencyCode);
                    _cmdSql2.Parameters.AddWithValue("@CertInsureCode", _MtrInsPolicyMdl.CertInsureCode);

                    //Remarks for Addition
                    _cmdSql2.Parameters.AddWithValue("@Remarks", _MtrInsPolicyMdl1.Remarks ?? DBNull.Value.ToString());

                    _cmdSql2.Parameters.AddWithValue("@BrchCoverNoteNo", _MtrInsPolicyMdl.BrchCoverNoteNo);
                    _cmdSql2.Parameters.AddWithValue("@LeaderPolicyNo", _MtrInsPolicyMdl.LeaderPolicyNo);
                    _cmdSql2.Parameters.AddWithValue("@LeaderEndNo", _MtrInsPolicyMdl.LeaderEndNo);
                    _cmdSql2.Parameters.AddWithValue("@IsFiler", _MtrInsPolicyMdl.IsFiler);
                    _cmdSql2.Parameters.AddWithValue("@CalcType", _MtrInsPolicyMdl.CalcType);
                    _cmdSql2.Parameters.AddWithValue("@IsAuto", _MtrInsPolicyMdl.IsAuto);
                    _cmdSql2.Parameters.AddWithValue("@EffectiveDate", Convert.ToDateTime(_MtrInsPolicyMdl.EffectiveDate.ToString()).AddYears(1));
                    _cmdSql2.Parameters.AddWithValue("@ExpiryDate", Convert.ToDateTime(_MtrInsPolicyMdl.ExpiryDate.ToString()).AddYears(1));
                    _cmdSql2.Parameters.AddWithValue("@SerialNo", _SerialNumber);
                    _cmdSql2.Parameters.AddWithValue("@UWYear", Convert.ToInt32(_MtrInsPolicyMdl.UWYear)+1);
                    _cmdSql2.Parameters.AddWithValue("@CommisionRate", _MtrInsPolicyMdl.CommisionRate);

                    _cmdSql2.Parameters.AddWithValue("@CreatedBy", _MtrInsPolicyMdl.CreatedBy);

                    _cmdSql2.Parameters.AddWithValue("@IsPosted", _MtrInsPolicyMdl.IsPosted);
                    // _cmdSql2.Parameters.AddWithValue("@PostDate", _MtrInsPolicyMdl.PostDate);
                    _cmdSql2.Parameters.AddWithValue("@OpolTxnSysID", _MtrInsPolicyMdl.OpolTxnSysID);
                    _cmdSql2.Parameters.AddWithValue("@IsRenewal", Convert.ToBoolean(true));

                    _MtrInsPolicyMdl.CertString = _MtrInsPolicyMdl.CertString;
                    _MtrInsPolicyMdl.SerialNo = _SerialNumber;
                    // _MtrInsPolicyMdl.TxnSysDate = DateTime.Now;


                    int _TxnSysId;
                    _conSql2.Open();
                    _TxnSysId = (Int32)_cmdSql2.ExecuteScalar();
                    _conSql2.Close();
                    _MtrInsPolicyMdl2.IsValidTxn = true;

                    _MtrInsPolicyMdl2.ParentTxnSysID = _TxnSysId;

                    _MtrInsPolicyMdl2.ProductName = GlobalDataLayer.GetProductNameByProductCode(_MtrInsPolicyMdl.ProductCode.ToString());
                    _MtrInsPolicyMdl2.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_MtrInsPolicyMdl.PolicyTypeCode.ToString());
                    _MtrInsPolicyMdl2.ClientName = GlobalDataLayer.GetClientNameByClientCode(_MtrInsPolicyMdl.ClientCode.ToString());
                    _MtrInsPolicyMdl2.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_MtrInsPolicyMdl.AgencyCode.ToString());
                    _MtrInsPolicyMdl2.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_MtrInsPolicyMdl.CertInsureCode.ToString());

                    string OpenPolicyDoc1 = "8";
                    _MtrInsPolicyMdl2.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(OpenPolicyDoc1);
                    _MtrInsPolicyMdl2.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_MtrInsPolicyMdl.IsFiler.ToString());
                    _MtrInsPolicyMdl2.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_MtrInsPolicyMdl.CalcType.ToString());
                    _MtrInsPolicyMdl2.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_MtrInsPolicyMdl.IsAuto.ToString());

                    _MtrInsPolicyMdl2.IsValidTxn = true;
                    _MtrInsPolicyMdl2.DocType = OpenPolicyDoc1;

                    //----------------For Ins Tracker-----------------//

                    //Get Values From InsTracker
                    SqlConnection _conSql3 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());

                    DataTable _tblSqla3 = new DataTable();
                    List<MtrInsTrackerMdl> _MtrInsTrackerMdlList1 = new List<MtrInsTrackerMdl>();
                    MtrInsTrackerMdl _MtrInsTrackerMdl1 = new MtrInsTrackerMdl();


                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM InsMtrTracker WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                        command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                        SqlDataAdapter _adpSql3 = new SqlDataAdapter(command);


                        _adpSql3.Fill(_tblSqla3);
                    }

                    if (_tblSqla3.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla3.Rows.Count; i++)
                        {
                            _MtrInsTrackerMdl1 = new MtrInsTrackerMdl();

                            _MtrInsTrackerMdl1.TxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["TxnSysID"]);
                            _MtrInsTrackerMdl1.UserCode = Convert.ToInt32(_tblSqla3.Rows[i]["UserCode"]);
                            _MtrInsTrackerMdl1.TrackerCode = Convert.ToInt32(_tblSqla3.Rows[i]["TrackerCode"]);
                            _MtrInsTrackerMdl1.TrackerName = _tblSqla3.Rows[i]["TrackerName"].ToString();
                            _MtrInsTrackerMdl1.TrackerRate = Convert.ToInt32(_tblSqla3.Rows[i]["TrackerRate"]);
                            _MtrInsTrackerMdl1.ParentTxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["ParentTxnSysID"]);



                            _MtrInsTrackerMdl1.IsValidTxn = true;

                            _MtrInsTrackerMdlList1.Add(_MtrInsTrackerMdl1);
                        }

                        //Insert In to InsTracker For Renewal
                        SqlConnection _conSql7 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql7 = new StringBuilder();
                        SqlCommand _cmdSql7;


                        MtrInsTrackerMdl[] TrackerArray = _MtrInsTrackerMdlList1.ToArray();

                        for (int j = 0; j < TrackerArray.Length; j++)
                        {
                            _sbSql7 = new StringBuilder();

                            _sbSql7.AppendLine("INSERT INTO InsMtrTracker(");

                            _sbSql7.AppendLine("UserCode,");
                            _sbSql7.AppendLine("TrackerCode,");
                            _sbSql7.AppendLine("TrackerName,");
                            _sbSql7.AppendLine("TrackerRate,");
                            _sbSql7.AppendLine("ParentTxnSysID)");


                            _sbSql7.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                            _sbSql7.AppendLine("@UserCode,");
                            _sbSql7.AppendLine("@TrackerCode,");
                            _sbSql7.AppendLine("@TrackerName,");
                            _sbSql7.AppendLine("@TrackerRate,");
                            _sbSql7.AppendLine("(SELECT MAX(ip.ParentTxnSysID) FROM InsPolicy ip))");


                            _cmdSql7 = new SqlCommand(_sbSql7.ToString(), _conSql7);
                            int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsTrackerMdl1.UserCode);
                            _cmdSql7.Parameters.AddWithValue("@UserCode", _userCode);
                            _cmdSql7.Parameters.AddWithValue("@TrackerCode", TrackerArray[j].TrackerCode);
                            _cmdSql7.Parameters.AddWithValue("@TrackerName", TrackerArray[j].TrackerName);
                            _cmdSql7.Parameters.AddWithValue("@TrackerRate", TrackerArray[j].TrackerRate);
                           // _cmdSql7.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsTrackerMdl1.ParentTxnSysID);


                            int _TxnSysId1;
                            _conSql7.Open();
                            _TxnSysId1 = (Int32)_cmdSql7.ExecuteScalar();
                            _conSql7.Close();
                        }

                    }
                    else
                    {

                    }

                    //----------------For Ins Tracker-----------------//

                    //----------------For Ins Rider-----------------//

                    //Get Values From InsRider
                    SqlConnection _conSql4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    DataTable _tblSqla4 = new DataTable();
                    List<MtrInsRiderMdl> _MtrInsRiderMdlList1 = new List<MtrInsRiderMdl>();
                    MtrInsRiderMdl _MtrInsRiderMdl1 = new MtrInsRiderMdl();


                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM InsMtrRider WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                        command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                        SqlDataAdapter _adpSql4 = new SqlDataAdapter(command);


                        _adpSql4.Fill(_tblSqla4);
                    }


                    if (_tblSqla4.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla4.Rows.Count; i++)
                        {
                            _MtrInsRiderMdl1 = new MtrInsRiderMdl();

                            _MtrInsRiderMdl1.TxnSysID = Convert.ToInt32(_tblSqla4.Rows[i]["TxnSysID"]);
                            _MtrInsRiderMdl1.TxnSysDate = Convert.ToDateTime(_tblSqla4.Rows[i]["TxnSysDate"]);
                            _MtrInsRiderMdl1.UserCode = Convert.ToInt32(_tblSqla4.Rows[i]["UserCode"]);
                            _MtrInsRiderMdl1.RiderCode = Convert.ToInt32(_tblSqla4.Rows[i]["RiderCode"]);
                            _MtrInsRiderMdl1.RiderName = _tblSqla4.Rows[i]["RiderName"].ToString();
                            _MtrInsRiderMdl1.RiderRate = Convert.ToInt32(_tblSqla4.Rows[i]["RiderRate"]);
                            _MtrInsRiderMdl1.ParentTxnSysID = Convert.ToInt32(_tblSqla4.Rows[i]["ParentTxnSysID"]);




                            _MtrInsRiderMdl1.IsValidTxn = true;

                            _MtrInsRiderMdlList1.Add(_MtrInsRiderMdl1);
                        }


                        //Insert In To Ins Rider
                        SqlConnection _conSql8 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql8 = new StringBuilder();
                        SqlCommand _cmdSql8;


                        MtrInsRiderMdl[] RiderArray = _MtrInsRiderMdlList1.ToArray();

                        for (int j = 0; j < RiderArray.Length; j++)
                        {
                            _sbSql8 = new StringBuilder();

                            _sbSql8.AppendLine("INSERT INTO InsMtrRider(");
                            //_sbSql.AppendLine("TxnSysID,");
                            //_sbSql.AppendLine("TxnSysDate,");
                            _sbSql8.AppendLine("UserCode,");
                            _sbSql8.AppendLine("RiderCode,");
                            _sbSql8.AppendLine("RiderName,");
                            _sbSql8.AppendLine("RiderRate,");
                            _sbSql8.AppendLine("(SELECT MAX(ip.ParentTxnSysID) FROM InsPolicy ip))");



                            _sbSql8.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                            // _sbSql.AppendLine("@TxnSysID,");
                            //  _sbSql.AppendLine("@TxnSysDate,");
                            _sbSql8.AppendLine("@UserCode,");
                            _sbSql8.AppendLine("@RiderCode,");
                            _sbSql8.AppendLine("@RiderName,");
                            _sbSql8.AppendLine("@RiderRate,");
                           // _sbSql8.AppendLine("@ParentTxnSysID)");




                            _cmdSql8 = new SqlCommand(_sbSql8.ToString(), _conSql8);
                            int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsRiderMdl1.UserCode);
                            _cmdSql8.Parameters.AddWithValue("@UserCode", _userCode);
                            _cmdSql8.Parameters.AddWithValue("@RiderCode", RiderArray[j].RiderCode);
                            _cmdSql8.Parameters.AddWithValue("@RiderName", RiderArray[j].RiderName);
                            _cmdSql8.Parameters.AddWithValue("@RiderRate", RiderArray[j].RiderRate);
                            _cmdSql8.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsRiderMdl1.ParentTxnSysID);


                            int _TxnSysId2;
                            _conSql8.Open();
                            _TxnSysId2 = (Int32)_cmdSql8.ExecuteScalar();
                            _conSql8.Close();

                        }

                    }
                    else
                    {

                    }

                    //----------------For Ins Rider-----------------//

                    //----------------For Ins Conditions-----------------//

                    //Get Values From Ins Conditions
                    SqlConnection _conSql5 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    DataTable _tblSqla5 = new DataTable();
                    List<MtrInsConditionsMdl> _MtrInsConditionsMdlList1 = new List<MtrInsConditionsMdl>();
                    MtrInsConditionsMdl _MtrInsConditionsMdl1;


                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM InsMtrConditions WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                        command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                        SqlDataAdapter _adpSql5 = new SqlDataAdapter(command);


                        _adpSql5.Fill(_tblSqla5);
                    }


                    if (_tblSqla5.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla5.Rows.Count; i++)
                        {
                            _MtrInsConditionsMdl1 = new MtrInsConditionsMdl();

                            _MtrInsConditionsMdl1.TxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["TxnSysID"]);
                            _MtrInsConditionsMdl1.TxnSysDate = Convert.ToDateTime(_tblSqla5.Rows[i]["TxnSysDate"]);
                            _MtrInsConditionsMdl1.UserCode = Convert.ToInt32(_tblSqla5.Rows[i]["UserCode"]);
                            _MtrInsConditionsMdl1.ParentTxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["ParentTxnSysID"]);
                            _MtrInsConditionsMdl1.Condition = _tblSqla5.Rows[i]["Condition"].ToString();

                            _MtrInsConditionsMdl1.ConditionShText = GlobalDataLayer.GetConditionByCode(_tblSqla5.Rows[i]["Condition"].ToString());



                            _MtrInsConditionsMdl1.IsValidTxn = true;

                            _MtrInsConditionsMdlList1.Add(_MtrInsConditionsMdl1);
                        }

                        //Insert Into Ins Conditions
                        SqlConnection _conSql9 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql9 = new StringBuilder();
                        SqlCommand _cmdSql9;


                        MtrInsConditionsMdl[] ConditionsArray = _MtrInsConditionsMdlList1.ToArray();

                        for (int j = 0; j < ConditionsArray.Length; j++)
                        {
                            _sbSql9 = new StringBuilder();

                            _sbSql9.AppendLine("INSERT INTO InsMtrConditions(");
                            _sbSql9.AppendLine("ParentTxnSysID,");
                            _sbSql9.AppendLine("Condition)");

                            _sbSql9.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                            _sbSql9.AppendLine("(SELECT MAX(ip.ParentTxnSysID) FROM InsPolicy ip),");
                            _sbSql9.AppendLine("@Condition)");

                            _cmdSql9 = new SqlCommand(_sbSql9.ToString(), _conSql9);

                            //_cmdSql9.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsRiderMdl1.ParentTxnSysID);
                            _cmdSql9.Parameters.AddWithValue("@Condition", ConditionsArray[j].Condition.ToString());

                            int _TxnSysId3;
                            _conSql9.Open();
                            _TxnSysId3 = (Int32)_cmdSql9.ExecuteScalar();
                            _conSql9.Close();
                        }

                    }
                    else
                    {

                    }

                    //----------------For Ins Conditions-----------------//

                    //----------------For Ins Warranties-----------------//

                    //Get Values From InsWarranties
                    SqlConnection _conSql6 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    DataTable _tblSqla6 = new DataTable();
                    List<MtrInsWarrantiesMdl> _MtrInsWarrantiesMdlList1 = new List<MtrInsWarrantiesMdl>();
                    MtrInsWarrantiesMdl _MtrInsWarrantiesMdl1;


                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM InsMtrWarranties WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                        command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                        SqlDataAdapter _adpSql6 = new SqlDataAdapter(command);


                        _adpSql6.Fill(_tblSqla6);
                    }


                    //  _adpSql.Fill(_tbl);

                    if (_tblSqla6.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla6.Rows.Count; i++)
                        {
                            _MtrInsWarrantiesMdl1 = new MtrInsWarrantiesMdl();

                            _MtrInsWarrantiesMdl1.TxnSysID = Convert.ToInt32(_tblSqla6.Rows[i]["TxnSysID"]);
                            _MtrInsWarrantiesMdl1.TxnSysDate = Convert.ToDateTime(_tblSqla6.Rows[i]["TxnSysDate"]);
                            _MtrInsWarrantiesMdl1.UserCode = Convert.ToInt32(_tblSqla6.Rows[i]["UserCode"]);
                            _MtrInsWarrantiesMdl1.Warranty = _tblSqla6.Rows[i]["Warranty"].ToString();
                            _MtrInsWarrantiesMdl1.ParentTxnSysID = Convert.ToInt32(_tblSqla6.Rows[i]["ParentTxnSysID"]);

                            _MtrInsWarrantiesMdl1.WarrantyShText = GlobalDataLayer.GetWarrantyTextByCode(_tblSqla6.Rows[i]["Warranty"].ToString());




                            _MtrInsWarrantiesMdl1.IsValidTxn = true;

                            _MtrInsWarrantiesMdlList1.Add(_MtrInsWarrantiesMdl1);
                        }

                        //Insert In To InsWarranties
                        SqlConnection _conSql10 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql10 = new StringBuilder();
                        SqlCommand _cmdSql10;



                        _cmdSql10 = new SqlCommand(_sbSql10.ToString(), _conSql10);

                        MtrInsWarrantiesMdl[] WarrantyArray = _MtrInsWarrantiesMdlList1.ToArray();

                        for (int j = 0; j < WarrantyArray.Length; j++)
                        {
                            _sbSql10 = new StringBuilder();

                            _sbSql10.AppendLine("INSERT INTO InsMtrWarranties(");
                            _sbSql10.AppendLine("ParentTxnSysID,");
                            _sbSql10.AppendLine("Warranty)");

                            _sbSql10.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                            _sbSql10.AppendLine("(SELECT MAX(ip.ParentTxnSysID) FROM InsPolicy ip),");
                            _sbSql10.AppendLine("@Warranty)");

                            _cmdSql10 = new SqlCommand(_sbSql10.ToString(), _conSql10);

                            //_cmdSql10.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsRiderMdl1.ParentTxnSysID);
                            _cmdSql10.Parameters.AddWithValue("@Warranty", WarrantyArray[j].Warranty.ToString());

                            int _TxnSysId4;
                            _conSql10.Open();
                            _TxnSysId4 = (Int32)_cmdSql10.ExecuteScalar();
                            _conSql10.Close();
                        }

                    }
                    else
                    {

                    }

                    //----------------For Ins Warranties-----------------//

                    //----------------For Vehicle Details-----------------//

                    //Get Values From Vehicle Details
                    SqlConnection _conSql11 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    string _sqlString11 = "SELECT * FROM MtrVehicleDetails mvd WHERE mvd.ParentTxnSysID =  " + _MtrInsPolicyMdl1.ParentTxnSysID;

                    SqlDataAdapter _adpSql11 = new SqlDataAdapter(_sqlString11, _conSql11);
                    DataTable _tblSqla11 = new DataTable();
                    List<VehicleDetailMdl> _VehicleDetailMdlList1 = new List<VehicleDetailMdl>();
                    VehicleDetailMdl _VehicleDetailMdl1 = new VehicleDetailMdl();

                    _adpSql11.Fill(_tblSqla11);

                    if (_tblSqla11.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla11.Rows.Count; i++)
                        {

                            _VehicleDetailMdl1 = new VehicleDetailMdl();

                            _VehicleDetailMdl1.TxnSysID = Convert.ToInt32(_tblSqla11.Rows[i]["TxnSysID"]);
                            _VehicleDetailMdl1.TxnSysDate = Convert.ToDateTime(_tblSqla11.Rows[i]["TxnSysDate"]);
                            _VehicleDetailMdl1.UserCode = Convert.ToInt32(_tblSqla11.Rows[i]["UserCode"]);
                            _VehicleDetailMdl1.SerialNo = Convert.ToInt32(_tblSqla11.Rows[i]["SerialNo"].ToString());
                            _VehicleDetailMdl1.VehicleCode = Convert.ToInt32(_tblSqla11.Rows[i]["VehicleCode"].ToString());
                            _VehicleDetailMdl1.VehicleModel = Convert.ToInt32(_tblSqla11.Rows[i]["VehicleModel"].ToString());
                            _VehicleDetailMdl1.UpdatedValue = Convert.ToDecimal(_tblSqla11.Rows[i]["UpdatedValue"]);
                            _VehicleDetailMdl1.PreviousValue = Convert.ToDecimal(_tblSqla11.Rows[i]["PreviousValue"]);
                            _VehicleDetailMdl1.Mileage = Convert.ToInt32(_tblSqla11.Rows[i]["Mileage"].ToString());
                            _VehicleDetailMdl1.ParticipantValue = Convert.ToDecimal(_tblSqla11.Rows[i]["ParticipantValue"]);
                            _VehicleDetailMdl1.ColorCode = Convert.ToInt32(_tblSqla11.Rows[i]["ColorCode"].ToString());
                            _VehicleDetailMdl1.ParticipantName = _tblSqla11.Rows[i]["ParticipantName"].ToString();
                            _VehicleDetailMdl1.ParticipantAddress = _tblSqla11.Rows[i]["ParticipantAddress"].ToString();

                            _VehicleDetailMdl1.RegistrationNumber = _tblSqla11.Rows[i]["RegistrationNumber"].ToString();
                            _VehicleDetailMdl1.CityCode = _tblSqla11.Rows[i]["CityCode"].ToString();
                            _VehicleDetailMdl1.EngineNumber = _tblSqla11.Rows[i]["EngineNumber"].ToString();
                            _VehicleDetailMdl1.AreaCode = Convert.ToInt32(_tblSqla11.Rows[i]["AreaCode"].ToString());
                            _VehicleDetailMdl1.ChasisNumber = _tblSqla11.Rows[i]["ChasisNumber"].ToString();
                            _VehicleDetailMdl1.Remarks = _tblSqla11.Rows[i]["Remarks"].ToString();
                            _VehicleDetailMdl1.PODate = Convert.ToDateTime(_tblSqla11.Rows[i]["PODate"]);
                            _VehicleDetailMdl1.PONumber = (_tblSqla11.Rows[i]["PONumber"].ToString() ?? DBNull.Value.ToString());
                            _VehicleDetailMdl1.CNICNumber = _tblSqla11.Rows[i]["CNICNumber"].ToString();
                            _VehicleDetailMdl1.Tenure = _tblSqla11.Rows[i]["Tenure"].ToString();
                            _VehicleDetailMdl1.BirthDate = Convert.ToDateTime(_tblSqla11.Rows[i]["BirthDate"]);
                            _VehicleDetailMdl1.Gender = _tblSqla11.Rows[i]["Gender"].ToString();
                            _VehicleDetailMdl1.VehicleType = _tblSqla11.Rows[i]["VehicleType"].ToString();
                            _VehicleDetailMdl1.VEODCode = Convert.ToInt32(_tblSqla11.Rows[i]["VEODCode"]);
                            _VehicleDetailMdl1.CertTypeCode = _tblSqla11.Rows[i]["CertTypeCode"].ToString();
                            _VehicleDetailMdl1.Rate = Convert.ToInt32(_tblSqla11.Rows[i]["Rate"]);
                            _VehicleDetailMdl1.Contribution = Convert.ToInt32(_tblSqla11.Rows[i]["Contribution"]);
                            _VehicleDetailMdl1.ParentTxnSysID = Convert.ToInt32(_tblSqla11.Rows[i]["ParentTxnSysID"]);
                            _VehicleDetailMdl1.OpolTxnSysID = Convert.ToInt32(_tblSqla11.Rows[i]["OpolTxnSysID"]);

                            _VehicleDetailMdl1.VEODName = GlobalDataLayer.GetVEODNameByCode(Convert.ToInt32(_tblSqla11.Rows[i]["VEODCode"]));
                            _VehicleDetailMdl1.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_tblSqla11.Rows[i]["VehicleType"].ToString() ?? DBNull.Value.ToString());

                            _VehicleDetailMdl1.RatingFactor = _tblSqla11.Rows[i]["RatingFactor"].ToString();
                            _VehicleDetailMdl1.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_tblSqla11.Rows[i]["RatingFactor"].ToString());

                            _VehicleDetailMdl1.InsuranceTypeCode = Convert.ToInt32(_tblSqla11.Rows[i]["InsuranceTypeCode"]);
                            _VehicleDetailMdl1.IsActive = Convert.ToBoolean(_tblSqla11.Rows[i]["IsActive"]);
                            _VehicleDetailMdl1.IsCanceled = Convert.ToBoolean(_tblSqla11.Rows[i]["IsCanceled"]);
                            _VehicleDetailMdl1.CommisionRate = Convert.ToDecimal(_tblSqla11.Rows[i]["CommisionRate"]);
                            _VehicleDetailMdl1.MobileNumber = _tblSqla11.Rows[i]["MobileNumber"].ToString() ?? DBNull.Value.ToString();
                            _VehicleDetailMdl1.ResNumber = _tblSqla11.Rows[i]["ResNumber"].ToString() ?? DBNull.Value.ToString();
                            _VehicleDetailMdl1.OfficeNumber = _tblSqla11.Rows[i]["OfficeNumber"].ToString() ?? DBNull.Value.ToString();

                            _VehicleDetailMdl1.EmailAddress = _tblSqla11.Rows[i]["EmailAddress"].ToString();
                            _VehicleDetailMdl1.Deductible = Convert.ToDecimal(_tblSqla11.Rows[i]["Deductible"]);

                            _VehicleDetailMdl1.ContractMatDate = Convert.ToDateTime(_tblSqla11.Rows[i]["ContractMatDate"]);


                            _VehicleDetailMdl1.GenderName = GlobalDataLayer.GetGenderNameByCode(_tblSqla11.Rows[i]["Gender"].ToString());
                            _VehicleDetailMdl1.CityName = GlobalDataLayer.GetCityNameByCode(_tblSqla11.Rows[i]["CityCode"].ToString());
                            _VehicleDetailMdl1.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(Convert.ToInt32(_tblSqla11.Rows[i]["ColorCode"].ToString()));
                            _VehicleDetailMdl1.VehicleName = GlobalDataLayer.GetVehicleNameByCode(Convert.ToInt32(_tblSqla11.Rows[i]["VehicleCode"].ToString()));
                            _VehicleDetailMdl1.AreaName = GlobalDataLayer.GetAreaNameByCode(Convert.ToInt32(_tblSqla11.Rows[i]["AreaCode"].ToString()));
                            _VehicleDetailMdl1.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_tblSqla11.Rows[i]["CertTypeCode"].ToString());
                            _VehicleDetailMdl1.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla11.Rows[i]["InsuranceTypeCode"]));

                            _VehicleDetailMdl1.total = GlobalDataLayer.calculate(_VehicleDetailMdl1);


                            _VehicleDetailMdlList1.Add(_VehicleDetailMdl1);


                        }


                        //Update Is Active to False in Mtr Vehicle Details for Renewal
                        SqlConnection _conSqlB = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSqlB = new StringBuilder();
                        SqlCommand _cmdSqlB;

                        _sbSqlB.AppendLine("Update  MtrVehicleDetails  SET");
                        _sbSqlB.AppendLine("IsActive=@IsActive");
                        _sbSqlB.AppendLine("WHERE ParentTxnSysID=@ParentTxnSysID ");
                        _cmdSqlB = new SqlCommand(_sbSqlB.ToString(), _conSqlB);
                        _cmdSqlB.Parameters.AddWithValue("@IsActive", false);
                        _cmdSqlB.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID);
                        _conSqlB.Open();
                        _cmdSqlB.ExecuteNonQuery();
                        _conSqlB.Close();

                        //Insert Values To Vehicle Details For Renewal
                        SqlConnection _conSql12 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql12 = new StringBuilder();
                        SqlCommand _cmdSql12;
                        int _SerialNumber1 = GetSerialNo1(_VehicleDetailMdl1);


                        _sbSql12.AppendLine("INSERT INTO MtrVehicleDetails(");
                        // _sbSql.AppendLine("TxnSysID,");
                        _sbSql12.AppendLine("TxnSysDate,");
                        _sbSql12.AppendLine("UserCode,");
                        _sbSql12.AppendLine("SerialNo,");
                        _sbSql12.AppendLine("VehicleCode,");
                        _sbSql12.AppendLine("VehicleModel,");
                        _sbSql12.AppendLine("UpdatedValue,");
                        _sbSql12.AppendLine("PreviousValue,");
                        _sbSql12.AppendLine("Mileage,");
                        _sbSql12.AppendLine("ParticipantValue,");
                        _sbSql12.AppendLine("ColorCode,");
                        _sbSql12.AppendLine("ParticipantName,");
                        _sbSql12.AppendLine("ParticipantAddress,");
                        // _sbSql.AppendLine("ModelNumber,");
                        _sbSql12.AppendLine("RegistrationNumber,");
                        _sbSql12.AppendLine("CityCode,");
                        _sbSql12.AppendLine("EngineNumber,");
                        _sbSql12.AppendLine("AreaCode,");
                        _sbSql12.AppendLine("ChasisNumber,");
                        _sbSql12.AppendLine("Remarks,");
                        _sbSql12.AppendLine("PODate,");
                        _sbSql12.AppendLine("PONumber,");
                        _sbSql12.AppendLine("CNICNumber,");
                        _sbSql12.AppendLine("Tenure,");
                        _sbSql12.AppendLine("BirthDate,");
                        _sbSql12.AppendLine("Gender,");
                        _sbSql12.AppendLine("VehicleType,");
                        _sbSql12.AppendLine("VEODCode,");
                        _sbSql12.AppendLine("CertTypeCode,");
                        _sbSql12.AppendLine("Rate,");
                        _sbSql12.AppendLine("ParentTxnSysID,");
                        _sbSql12.AppendLine("OpolTxnSysID,");
                        _sbSql12.AppendLine("InsuranceTypeCode,");
                        _sbSql12.AppendLine("CommisionRate,");
                        _sbSql12.AppendLine("MobileNumber,");
                        _sbSql12.AppendLine("ResNumber,");
                        _sbSql12.AppendLine("OfficeNumber,");
                        _sbSql12.AppendLine("EmailAddress,");
                        _sbSql12.AppendLine("Deductible,");
                        _sbSql12.AppendLine("ContractMatDate,");
                        _sbSql12.AppendLine("RatingFactor,");
                        _sbSql12.AppendLine("Contribution)");


                        _sbSql12.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                        // _sbSql12.AppendLine("@TxnSysID,");
                        _sbSql12.AppendLine("@TxnSysDate,");
                        _sbSql12.AppendLine("@UserCode,");
                        _sbSql12.AppendLine("@SerialNo,");
                        _sbSql12.AppendLine("@VehicleCode,");
                        _sbSql12.AppendLine("@VehicleModel,");
                        _sbSql12.AppendLine("@UpdatedValue,");
                        _sbSql12.AppendLine("@PreviousValue,");
                        _sbSql12.AppendLine("@Mileage,");
                        _sbSql12.AppendLine("@ParticipantValue,");
                        _sbSql12.AppendLine("@ColorCode,");
                        _sbSql12.AppendLine("@ParticipantName,");
                        _sbSql12.AppendLine("@ParticipantAddress,");
                        // _sbSql12.AppendLine("@ModelNumber,");
                        _sbSql12.AppendLine("@RegistrationNumber,");
                        _sbSql12.AppendLine("@CityCode,");
                        _sbSql12.AppendLine("@EngineNumber,");
                        _sbSql12.AppendLine("@AreaCode,");
                        _sbSql12.AppendLine("@ChasisNumber,");
                        _sbSql12.AppendLine("@Remarks,");
                        _sbSql12.AppendLine("@PODate,");
                        _sbSql12.AppendLine("@PONumber,");
                        _sbSql12.AppendLine("@CNICNumber,");
                        _sbSql12.AppendLine("@Tenure,");
                        _sbSql12.AppendLine("@BirthDate,");
                        _sbSql12.AppendLine("@Gender,");
                        _sbSql12.AppendLine("@VehicleType,");
                        _sbSql12.AppendLine("@VEODCode,");
                        _sbSql12.AppendLine("@CertTypeCode,");
                        _sbSql12.AppendLine("@Rate,");
                        _sbSql12.AppendLine("(SELECT MAX(ip.ParentTxnSysID) FROM InsPolicy ip),");
                        _sbSql12.AppendLine("@OpolTxnSysID,");
                        _sbSql12.AppendLine("@InsuranceTypeCode,");
                        _sbSql12.AppendLine("@CommisionRate,");
                        _sbSql12.AppendLine("@MobileNumber,");
                        _sbSql12.AppendLine("@ResNumber,");
                        _sbSql12.AppendLine("@OfficeNumber,");
                        _sbSql12.AppendLine("@EmailAddress,");
                        _sbSql12.AppendLine("@Deductible,");
                        _sbSql12.AppendLine("@ContractMatDate,");
                        _sbSql12.AppendLine("@RatingFactor,");
                        _sbSql12.AppendLine("@Contribution)");


                        _cmdSql12 = new SqlCommand(_sbSql12.ToString(), _conSql12);




                        DateTime da = DateTime.Now;
                        da.ToString("MM-dd-yyyy h:mm tt");

                        _cmdSql12.Parameters.AddWithValue("@TxnSysDate", Convert.ToDateTime(da));
                        int _userCode = GlobalDataLayer.GetUserCodeById(_VehicleDetailMdl1.UserCode);
                        _cmdSql12.Parameters.AddWithValue("@UserCode", _userCode);

                        _cmdSql12.Parameters.AddWithValue("@SerialNo", _SerialNumber1);

                       // _cmdSql12.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID);
                        _cmdSql12.Parameters.AddWithValue("@OpolTxnSysID", _VehicleDetailMdl1.OpolTxnSysID);

                        _cmdSql12.Parameters.AddWithValue("@VehicleCode", _VehicleDetailMdl1.VehicleCode);
                        _cmdSql12.Parameters.AddWithValue("@VehicleModel", _VehicleDetailMdl1.VehicleModel);
                        _cmdSql12.Parameters.AddWithValue("@UpdatedValue", _VehicleDetailMdl1.UpdatedValue);
                        _cmdSql12.Parameters.AddWithValue("@PreviousValue", _VehicleDetailMdl1.PreviousValue);
                        _cmdSql12.Parameters.AddWithValue("@Mileage", _VehicleDetailMdl1.Mileage);
                        _cmdSql12.Parameters.AddWithValue("@ParticipantValue", _VehicleDetailMdl1.ParticipantValue);
                        _cmdSql12.Parameters.AddWithValue("@ColorCode", _VehicleDetailMdl1.ColorCode);
                        _cmdSql12.Parameters.AddWithValue("@ParticipantName", _VehicleDetailMdl1.ParticipantName);
                        _cmdSql12.Parameters.AddWithValue("@ParticipantAddress", _VehicleDetailMdl1.ParticipantAddress);
                        // _cmdSql12.Parameters.AddWithValue("@ModelNumber", _VehicleDetailMdl.ModelNumber);
                        _cmdSql12.Parameters.AddWithValue("@RegistrationNumber", _VehicleDetailMdl1.RegistrationNumber);
                        _cmdSql12.Parameters.AddWithValue("@CityCode", _VehicleDetailMdl1.CityCode);
                        _cmdSql12.Parameters.AddWithValue("@EngineNumber", _VehicleDetailMdl1.EngineNumber);
                        _cmdSql12.Parameters.AddWithValue("@AreaCode", _VehicleDetailMdl1.AreaCode);
                        _cmdSql12.Parameters.AddWithValue("@ChasisNumber", _VehicleDetailMdl1.ChasisNumber);
                        _cmdSql12.Parameters.AddWithValue("@Remarks", _VehicleDetailMdl1.Remarks ?? DBNull.Value.ToString());
                        _cmdSql12.Parameters.AddWithValue("@PODate", _VehicleDetailMdl1.PODate);
                        _cmdSql12.Parameters.AddWithValue("@PONumber", _VehicleDetailMdl1.PONumber ?? DBNull.Value.ToString());
                        _cmdSql12.Parameters.AddWithValue("@CNICNumber", _VehicleDetailMdl1.CNICNumber);
                        _cmdSql12.Parameters.AddWithValue("@Tenure", _VehicleDetailMdl1.Tenure);
                        _cmdSql12.Parameters.AddWithValue("@BirthDate", _VehicleDetailMdl1.BirthDate);
                        _cmdSql12.Parameters.AddWithValue("@Gender", _VehicleDetailMdl1.Gender);
                        _cmdSql12.Parameters.AddWithValue("@VehicleType", _VehicleDetailMdl1.VehicleType);
                        _cmdSql12.Parameters.AddWithValue("@VEODCode", _VehicleDetailMdl1.VEODCode);
                        _cmdSql12.Parameters.AddWithValue("@CertTypeCode", _VehicleDetailMdl1.CertTypeCode);
                        _cmdSql12.Parameters.AddWithValue("@Rate", _VehicleDetailMdl1.Rate);
                        _cmdSql12.Parameters.AddWithValue("@InsuranceTypeCode", _VehicleDetailMdl1.InsuranceTypeCode);
                        InsuranceType = _VehicleDetailMdl1.InsuranceTypeCode;
                        _cmdSql12.Parameters.AddWithValue("@Contribution", _VehicleDetailMdl1.Contribution);
                        _cmdSql12.Parameters.AddWithValue("@CommisionRate", _VehicleDetailMdl1.CommisionRate);
                        _cmdSql12.Parameters.AddWithValue("@MobileNumber", _VehicleDetailMdl1.MobileNumber ?? DBNull.Value.ToString());
                        _cmdSql12.Parameters.AddWithValue("@ResNumber", _VehicleDetailMdl1.ResNumber ?? DBNull.Value.ToString());
                        _cmdSql12.Parameters.AddWithValue("@OfficeNumber", _VehicleDetailMdl1.OfficeNumber ?? DBNull.Value.ToString());

                        _cmdSql12.Parameters.AddWithValue("@EmailAddress", _VehicleDetailMdl1.EmailAddress ?? DBNull.Value.ToString());
                        _cmdSql12.Parameters.AddWithValue("@Deductible", _VehicleDetailMdl1.Deductible);
                        _cmdSql12.Parameters.AddWithValue("@ContractMatDate", _VehicleDetailMdl1.ContractMatDate);

                        _cmdSql12.Parameters.AddWithValue("@RatingFactor", _VehicleDetailMdl1.RatingFactor);

                        _VehicleDetailMdl1.SerialNo = _SerialNumber1;

                        _VehicleDetailMdl1.TxnSysDate = DateTime.Now;

                        _VehicleDetailMdl1.VEODName = GlobalDataLayer.GetVEODNameByCode(_VehicleDetailMdl1.VEODCode);
                        _VehicleDetailMdl1.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_VehicleDetailMdl1.VehicleType);
                        _VehicleDetailMdl1.GenderName = GlobalDataLayer.GetGenderNameByCode(_VehicleDetailMdl1.Gender);
                        _VehicleDetailMdl1.CityName = GlobalDataLayer.GetCityNameByCode(_VehicleDetailMdl1.CityCode);
                        _VehicleDetailMdl1.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(_VehicleDetailMdl1.ColorCode);
                        _VehicleDetailMdl1.VehicleName = GlobalDataLayer.GetVehicleNameByCode(_VehicleDetailMdl1.VehicleCode);
                        _VehicleDetailMdl1.AreaName = GlobalDataLayer.GetAreaNameByCode(_VehicleDetailMdl1.AreaCode);
                        _VehicleDetailMdl1.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_VehicleDetailMdl1.CertTypeCode);
                        _VehicleDetailMdl1.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(_VehicleDetailMdl1.InsuranceTypeCode);

                        _VehicleDetailMdl1.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_VehicleDetailMdl1.RatingFactor);

                        _VehicleDetailMdl1.total = GlobalDataLayer.calculate(_VehicleDetailMdl1);


                        int _TxnSysId5;
                        _conSql12.Open();
                        _TxnSysId5 = (Int32)_cmdSql12.ExecuteScalar();
                        _conSql12.Close();

                    }


                    else
                    {

                    }
                    //----------------For Vehicle Details-----------------//


                    // --------------- For Co-Insurance --------------------- //

                    //For CoInsurance of Leader
                    if (InsuranceType == 2)
                    {

                        SqlConnection _conSqlA1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        string _sqlStringA1 = "SELECT *  FROM InsCoInsuance Where RiskTxnID =" + _VehicleDetailMdl1.TxnSysID;
                        SqlDataAdapter _adpSqlA1 = new SqlDataAdapter(_sqlStringA1, _conSqlA1);
                        DataTable _tblSqlaA1 = new DataTable();
                        InsCoInsurance _InsCoInsuranceA1 = new InsCoInsurance();
                        List<InsCoInsurance> _InsCoInsuranceListA1 = new List<InsCoInsurance>();

                        _adpSqlA1.Fill(_tblSqlaA1);

                        if (_tblSqlaA1.Rows.Count > 0)
                        {

                            for (int i = 0; i < _tblSqlaA1.Rows.Count; i++)
                            {

                                _InsCoInsuranceA1 = new InsCoInsurance();

                                _InsCoInsuranceA1.FIF = Convert.ToDecimal(_tblSqlaA1.Rows[i]["FIF"]);
                                _InsCoInsuranceA1.FED = Convert.ToDecimal(_tblSqlaA1.Rows[i]["FED"]);
                                _InsCoInsuranceA1.CoInsuranceCode = Convert.ToInt32(_tblSqlaA1.Rows[i]["CoInsuranceCode"]);
                                _InsCoInsuranceA1.CoInsuranceShare = Convert.ToDecimal(_tblSqlaA1.Rows[i]["CoInsuranceShare"]);
                                _InsCoInsuranceA1.PEV = Decimal.Round(Convert.ToDecimal(_tblSqlaA1.Rows[i]["PEV"]), MidpointRounding.ToEven);
                                _InsCoInsuranceA1.BeforePEV = Decimal.Round(Convert.ToDecimal(_tblSqlaA1.Rows[i]["BeforePEV"]), MidpointRounding.ToEven);
                                _InsCoInsuranceA1.Stamp = Convert.ToDecimal(_tblSqlaA1.Rows[i]["Stamp"]);
                                _InsCoInsuranceA1.OpolTxnSysID = Convert.ToInt32(_tblSqlaA1.Rows[i]["OpolTxnSysID"]);
                                _InsCoInsuranceA1.Rate = Convert.ToDecimal(_tblSqlaA1.Rows[i]["Rate"]);
                                _InsCoInsuranceA1.BasicContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["BasicContribution"]);
                                _InsCoInsuranceA1.TerrorContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["TerrorContribution"]);
                                _InsCoInsuranceA1.NetContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["NetContribution"]);
                                _InsCoInsuranceA1.GrossContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["GrossContribution"]);
                                _InsCoInsuranceA1.PerDayContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["PerDayContribution"]);
                                _InsCoInsuranceA1.SumCovered = Convert.ToInt32(_tblSqlaA1.Rows[i]["SumCovered"]);

                                _InsCoInsuranceListA1.Add(_InsCoInsuranceA1);
                            }

                            //Insert InTo CoInsurance for Renewal
                            SqlConnection _conSqlA2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                            StringBuilder _sbSqlA2 = new StringBuilder();
                            SqlCommand _cmdSqlA2;
                            InsCoInsurance[] ConInsList = _InsCoInsuranceListA1.ToArray();


                            for (int i = 0; i < ConInsList.Length; i++)
                            {
                                _sbSqlA2 = new StringBuilder();

                                _sbSqlA2.AppendLine("INSERT INTO InsCoInsuance(");
                                //_sbSql.AppendLine("TxnSysID,");
                                _sbSqlA2.AppendLine("TxnSysDate,");
                                _sbSqlA2.AppendLine("UserCode,");
                                _sbSqlA2.AppendLine("SumCovered,");
                                _sbSqlA2.AppendLine("Rate,");
                                _sbSqlA2.AppendLine("NetContribution,");
                                _sbSqlA2.AppendLine("GrossContribution,");
                                _sbSqlA2.AppendLine("FIF,");
                                _sbSqlA2.AppendLine("FED,");
                                _sbSqlA2.AppendLine("Stamp,");
                                _sbSqlA2.AppendLine("BasicContribution,");
                                _sbSqlA2.AppendLine("PEV,");
                                _sbSqlA2.AppendLine("BeforePEV,");
                                _sbSqlA2.AppendLine("TerrorContribution,");
                                _sbSqlA2.AppendLine("RiskTxnID,");
                                _sbSqlA2.AppendLine("OpolTxnSysID,");
                                _sbSqlA2.AppendLine("PerDayContribution,");

                                _sbSqlA2.AppendLine("CoInsuranceCode,");
                                _sbSqlA2.AppendLine("CoInsuranceShare)");


                                _sbSqlA2.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                                //_sbSqlA2.AppendLine("@TxnSysID,");
                                _sbSqlA2.AppendLine("@TxnSysDate,");
                                _sbSqlA2.AppendLine("@UserCode,");
                                _sbSqlA2.AppendLine("@SumCovered,");
                                _sbSqlA2.AppendLine("@Rate,");
                                _sbSqlA2.AppendLine("@NetContribution,");
                                _sbSqlA2.AppendLine("@GrossContribution,");
                                _sbSqlA2.AppendLine("@FIF,");
                                _sbSqlA2.AppendLine("@FED,");
                                _sbSqlA2.AppendLine("@Stamp,");
                                _sbSqlA2.AppendLine("@BasicContribution,");
                                _sbSqlA2.AppendLine("@PEV,");
                                _sbSqlA2.AppendLine("@BeforePEV,");
                                _sbSqlA2.AppendLine("@TerrorContribution,");
                                _sbSqlA2.AppendLine("(SELECT MAX(mvd.TxnSysID) FROM MtrVehicleDetails mvd),");
                                _sbSqlA2.AppendLine("@OpolTxnSysID,");
                                _sbSqlA2.AppendLine("@PerDayContribution,");
                                _sbSqlA2.AppendLine("@CoInsuranceCode,");
                                _sbSqlA2.AppendLine("@CoInsuranceShare)");


                                _cmdSqlA2 = new SqlCommand(_sbSqlA2.ToString(), _conSqlA2);

                                _cmdSqlA2.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                                _cmdSqlA2.Parameters.AddWithValue("@SumCovered", ConInsList[i].SumCovered);

                                int _userCodeA2 = GlobalDataLayer.GetUserCodeById(ConInsList[i].UserCode);

                                _cmdSqlA2.Parameters.AddWithValue("@UserCode", _userCodeA2);


                                _cmdSqlA2.Parameters.AddWithValue("@Rate", ConInsList[i].Rate);
                                _cmdSqlA2.Parameters.AddWithValue("@NetContribution", ConInsList[i].NetContribution);
                                _cmdSqlA2.Parameters.AddWithValue("@GrossContribution", ConInsList[i].GrossContribution);
                                _cmdSqlA2.Parameters.AddWithValue("@FIF", ConInsList[i].FIF);
                                _cmdSqlA2.Parameters.AddWithValue("@FED", ConInsList[i].FED);
                                _cmdSqlA2.Parameters.AddWithValue("@Stamp", ConInsList[i].Stamp);
                                _cmdSqlA2.Parameters.AddWithValue("@BasicContribution", ConInsList[i].BasicContribution);
                                _cmdSqlA2.Parameters.AddWithValue("@PEV", ConInsList[i].PEV);
                                _cmdSqlA2.Parameters.AddWithValue("@BeforePEV", ConInsList[i].BeforePEV);
                                _cmdSqlA2.Parameters.AddWithValue("@TerrorContribution", ConInsList[i].TerrorContribution);
                                // _cmdSqlA2.Parameters.AddWithValue("@RiskTxnID", ConInsList[i].RiskTxnID);
                                _cmdSqlA2.Parameters.AddWithValue("@OpolTxnSysID", ConInsList[i].OpolTxnSysID);
                                _cmdSqlA2.Parameters.AddWithValue("@PerDayContribution", ConInsList[i].PerDayContribution);
                                _cmdSqlA2.Parameters.AddWithValue("@CoInsuranceCode", ConInsList[i].CoInsuranceCode);
                                _cmdSqlA2.Parameters.AddWithValue("@CoInsuranceShare", ConInsList[i].CoInsuranceShare);


                                int _TxnSysId1;
                                _conSqlA2.Open();
                                _TxnSysId1 = (Int32)_cmdSqlA2.ExecuteScalar();
                                _conSqlA2.Close();
                            }


                        }


                        else
                        {



                        }

                    }
                    // --------------- For Co-Insurance --------------------- //




                    //----------------For Mtr Contribution-----------------//

                    //Get Values From Mtr Contribution
                    SqlConnection _conSql13 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    DataTable _tblSqla13 = new DataTable();
                    MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();
                    List<MtrVContributionMdl> _MtrVContributionMdlList1 = new List<MtrVContributionMdl>();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM InsContribution ic INNER JOIN MtrVehicleDetails mvd ON mvd.TxnSysID = ic.RiskTxnID WHERE mvd.ParentTxnSysID = @ParentTxnSysID ", conn);

                        command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsPolicyMdl1.ParentTxnSysID));

                        SqlDataAdapter _adpSql13 = new SqlDataAdapter(command);


                        _adpSql13.Fill(_tblSqla13);
                    }

                    //  _adpSql.Fill(_tblSqla);

                    if (_tblSqla13.Rows.Count > 0)
                    {
                        _MtrVContributionMdl1 = new MtrVContributionMdl();
                        for (int i = 0; i < _tblSqla13.Rows.Count; i++)
                        {
                            _MtrVContributionMdl1 = new MtrVContributionMdl();

                            _MtrVContributionMdl1.TxnSysID = Convert.ToInt32(_tblSqla13.Rows[i]["TxnSysID"]);
                            _MtrVContributionMdl1.TxnSysDate = Convert.ToDateTime(_tblSqla13.Rows[i]["TxnSysDate"]);
                            _MtrVContributionMdl1.UserCode = Convert.ToInt32(_tblSqla13.Rows[i]["UserCode"]);
                            _MtrVContributionMdl1.SumCovered = Convert.ToInt32(_tblSqla13.Rows[i]["SumCovered"]);
                            _MtrVContributionMdl1.Rate = Convert.ToDecimal(_tblSqla13.Rows[i]["Rate"]);
                            _MtrVContributionMdl1.NetContribution = Convert.ToDecimal(_tblSqla13.Rows[i]["NetContribution"]);
                            _MtrVContributionMdl1.GrossContribution = Convert.ToDecimal(_tblSqla13.Rows[i]["GrossContribution"]);
                            _MtrVContributionMdl1.FIF = Convert.ToDecimal(_tblSqla13.Rows[i]["FIF"]);
                            _MtrVContributionMdl1.FED = Convert.ToDecimal(_tblSqla13.Rows[i]["FED"]);
                            _MtrVContributionMdl1.Stamp = Convert.ToDecimal(_tblSqla13.Rows[i]["Stamp"]);
                            _MtrVContributionMdl1.BasicContribution = Convert.ToDecimal(_tblSqla13.Rows[i]["BasicContribution"]);
                            _MtrVContributionMdl1.PEV = Convert.ToDecimal(_tblSqla13.Rows[i]["PEV"]);
                            _MtrVContributionMdl1.BeforePEV = Convert.ToDecimal(_tblSqla13.Rows[i]["BeforePEV"]);
                            _MtrVContributionMdl1.TerrorContribution = Convert.ToDecimal(_tblSqla13.Rows[i]["TerrorContribution"]);
                            _MtrVContributionMdl1.RiskTxnID = Convert.ToInt32(_tblSqla13.Rows[i]["RiskTxnID"]);
                            _MtrVContributionMdl1.PerDayContribution = Convert.ToInt32(_tblSqla13.Rows[i]["PerDayContribution"]);
                            _MtrVContributionMdl1.OpolTxnSysID = Convert.ToInt32(_tblSqla13.Rows[i]["OpolTxnSysID"]);

                            _MtrVContributionMdlList1.Add(_MtrVContributionMdl1);
                        }


                        //Insert In To Mtr Ins Contribution 
                        SqlConnection _conSql14 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        StringBuilder _sbSql14 = new StringBuilder();
                        SqlCommand _cmdSql14;

                        _sbSql14.AppendLine("INSERT INTO InsContribution(");
                        // _sbSql.AppendLine("TxnSysID,");
                        _sbSql14.AppendLine("TxnSysDate,");
                        _sbSql14.AppendLine("UserCode,");
                        _sbSql14.AppendLine("SumCovered,");
                        _sbSql14.AppendLine("Rate,");
                        _sbSql14.AppendLine("NetContribution,");
                        _sbSql14.AppendLine("GrossContribution,");
                        _sbSql14.AppendLine("FIF,");
                        _sbSql14.AppendLine("FED,");
                        _sbSql14.AppendLine("Stamp,");
                        _sbSql14.AppendLine("BasicContribution,");
                        _sbSql14.AppendLine("PEV,");
                        _sbSql14.AppendLine("BeforePEV,");
                        _sbSql14.AppendLine("TerrorContribution,");
                        _sbSql14.AppendLine("RiskTxnID,");
                        _sbSql14.AppendLine("OpolTxnSysID,");
                        _sbSql14.AppendLine("PerDayContribution)");

                        _sbSql14.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                        //_sbSql.AppendLine("@TxnSysID,");
                        _sbSql14.AppendLine("@TxnSysDate,");
                        _sbSql14.AppendLine("@UserCode,");
                        _sbSql14.AppendLine("@SumCovered,");
                        _sbSql14.AppendLine("@Rate,");
                        _sbSql14.AppendLine("@NetContribution,");
                        _sbSql14.AppendLine("@GrossContribution,");
                        _sbSql14.AppendLine("@FIF,");
                        _sbSql14.AppendLine("@FED,");
                        _sbSql14.AppendLine("@Stamp,");
                        _sbSql14.AppendLine("@BasicContribution,");
                        _sbSql14.AppendLine("@PEV,");
                        _sbSql14.AppendLine("@BeforePEV,");
                        _sbSql14.AppendLine("@TerrorContribution,");
                        _sbSql14.AppendLine("(SELECT MAX(mvd.TxnSysID) FROM MtrVehicleDetails mvd),");
                        _sbSql14.AppendLine("@OpolTxnSysID,");
                        _sbSql14.AppendLine("@PerDayContribution)");

                        _cmdSql14 = new SqlCommand(_sbSql14.ToString(), _conSql14);

                        _cmdSql14.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                        _cmdSql14.Parameters.AddWithValue("@SumCovered", _MtrVContributionMdl1.SumCovered);

                        int _userCode2 = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl1.UserCode);

                        _cmdSql14.Parameters.AddWithValue("@UserCode", _userCode2);

                        _cmdSql14.Parameters.AddWithValue("@Rate", _MtrVContributionMdl1.Rate);
                        _cmdSql14.Parameters.AddWithValue("@NetContribution", _MtrVContributionMdl1.NetContribution);
                        _cmdSql14.Parameters.AddWithValue("@GrossContribution", _MtrVContributionMdl1.GrossContribution);
                        _cmdSql14.Parameters.AddWithValue("@FIF", _MtrVContributionMdl1.FIF);
                        _cmdSql14.Parameters.AddWithValue("@FED", _MtrVContributionMdl1.FED);
                        _cmdSql14.Parameters.AddWithValue("@Stamp", _MtrVContributionMdl1.Stamp);
                        _cmdSql14.Parameters.AddWithValue("@BasicContribution", _MtrVContributionMdl1.BasicContribution);
                        _cmdSql14.Parameters.AddWithValue("@PEV", _MtrVContributionMdl1.PEV);
                        _cmdSql14.Parameters.AddWithValue("@BeforePEV", _MtrVContributionMdl1.BeforePEV);
                        _cmdSql14.Parameters.AddWithValue("@TerrorContribution", _MtrVContributionMdl1.TerrorContribution);
                        _cmdSql14.Parameters.AddWithValue("@PerDayContribution", _MtrVContributionMdl1.PerDayContribution);

                        _cmdSql14.Parameters.AddWithValue("@OpolTxnSysID", _MtrVContributionMdl1.OpolTxnSysID);

                        int _TxnSysId4;
                        _conSql14.Open();
                        _TxnSysId4 = (Int32)_cmdSql14.ExecuteScalar();
                        _conSql14.Close();

                        _MtrVContributionMdl1.TxnSysID = _TxnSysId4;
                        _MtrVContributionMdl1.IsValidTxn = true;
                    }


                    else
                    {

                    }

                    //----------------For Mtr Contribution-----------------//

                    return _MtrInsPolicyMdl2;

                }
                else
                {
                    return null;
                }




            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Renewal DataLayer");
                return null;
            }
        }

        //--------- Important --------------//

        //For Increment of Serial Numbers for InsPolicy
        public static int GetSerialNo(MtrInsPolicyMdl _MtrInsPolicyMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(SerialNo) LastSerialNo FROM InsPolicy";
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

        //For Increment of Serial Numbers
        public int GetSerialNo1(VehicleDetailMdl _VehicleDetailMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(mvd.SerialNo) LastSerialNo FROM MtrVehicleDetails mvd ";
                //"WHERE mvd.ParentTxnSysID = (SELECT MAX(ParentTxnSysID) FROM InsPolicy)";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                int _result;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows[0][0] == null || _tbl.Rows[0][0] == DBNull.Value)
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

        //For Creation of Cert String
        public string GetCertString(string _BranchCode, string InsuranceType, string _DocType, int _PolicyTypeCode, int _SerialNumber, string _PolicyMonth, string _PolicyYear)
        {
            string PolicyString = _BranchCode + "-" + InsuranceType + "-2-" + _DocType + "-000" + _PolicyTypeCode + "-00" + _SerialNumber + "-" + _PolicyMonth + "-" + _PolicyYear;
            return PolicyString;
        }

    }
}