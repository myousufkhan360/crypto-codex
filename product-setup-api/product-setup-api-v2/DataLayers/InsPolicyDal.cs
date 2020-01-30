using ProductSetupApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static ProductSetupApi.Models.InsPolicyMdl;
using static ProductSetupApi.Models.OpenPolicyMdl;
using ProductSetupApi.DataLayers;
using System.Text;

namespace ProductSetupApi.DataLayers
{
    public class InsPolicyDal
    {


        //------------------- CRUD Starts From Here --------------------//


        //for getting all InsPolicy
        public List<MtrInsPolicyMdl> GetMtrInsPolicy()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM InsPolicy";
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
                        _MtrInsPolicyMdl.BrchCode = _tblSqla.Rows[i]["BrchCode"].ToString();
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
                        _MtrInsPolicyMdl.PostDate = Convert.ToDateTime(_tblSqla.Rows[i]["PostDate"]);
                        _MtrInsPolicyMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["OpolTxnSysID"]);
                        _MtrInsPolicyMdl.RenewSysID = Convert.ToInt32(_tblSqla.Rows[i]["RenewSysID"]);
                        _MtrInsPolicyMdl.PolSysID = Convert.ToInt32(_tblSqla.Rows[i]["PolSysID"]);
                        _MtrInsPolicyMdl.IsRenewal = Convert.ToBoolean(_tblSqla.Rows[i]["IsRenewal"]);
                        _MtrInsPolicyMdl.CommisionRate = Convert.ToDecimal(_tblSqla.Rows[i]["CommisionRate"]);

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

                        string OpenPolicyDoc = "7";
                        _MtrInsPolicyMdl.DocType = OpenPolicyDoc;
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
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //for Inserting into InsPolicy for OpenPolicy
        public MtrInsPolicyMdl AddMtrInsPolicy(MtrInsPolicyMdl _MtrInsPolicyMdl, MtrOpenPolicyMdl _MtrOpenPolicyMdl)
        {
            try

            {

                _MtrInsPolicyMdl.SerialNo = _MtrInsPolicyMdl.SerialNo == 0 ? _MtrInsPolicyMdl.SerialNo++ : _MtrInsPolicyMdl.SerialNo++;



                      SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;
                    int _SerialNumber = GetSerialNo(_MtrInsPolicyMdl);


                MtrOpenPolicyMdl OpenPolicyMdl = GetOpolicytByTxnID(_MtrOpenPolicyMdl);

                _sbSql.AppendLine("INSERT INTO InsPolicy(");
               // _sbSql.AppendLine("TxnSysID,");
                _sbSql.AppendLine("TxnSysDate,");
                _sbSql.AppendLine("DocMonth,");
                _sbSql.AppendLine("DocString,");
                _sbSql.AppendLine("DocYear,");
                _sbSql.AppendLine("DocNo,");
                _sbSql.AppendLine("DocType,");
                _sbSql.AppendLine("GenerateAgainst,");
                _sbSql.AppendLine("ProductCode,");
                _sbSql.AppendLine("PolicyTypeCode,");
                _sbSql.AppendLine("ClientCode,");
                _sbSql.AppendLine("AgencyCode,");
                _sbSql.AppendLine("CertInsureCode,");
                _sbSql.AppendLine("Remarks,");
                _sbSql.AppendLine("BrchCoverNoteNo,");
                _sbSql.AppendLine("BrchCode,");
                _sbSql.AppendLine("LeaderPolicyNo,");
                _sbSql.AppendLine("LeaderEndNo,");
                _sbSql.AppendLine("IsFiler,");
                _sbSql.AppendLine("CalcType,");
                _sbSql.AppendLine("IsAuto,");
                _sbSql.AppendLine("EffectiveDate,");
                _sbSql.AppendLine("ExpiryDate,");
                _sbSql.AppendLine("SerialNo,");
                _sbSql.AppendLine("UWYear,");
                _sbSql.AppendLine("CreatedBy,");
                _sbSql.AppendLine("CommisionRate,");
                //_sbSql.AppendLine("SerialNo,");
                 _sbSql.AppendLine("IsPosted,");
                // _sbSql.AppendLine("PostDate,");
                _sbSql.AppendLine("EndoSerial,");
                _sbSql.AppendLine("OpolTxnSysID)");
               // _sbSql.AppendLine("RenewSysID,");
              //  _sbSql.AppendLine("PolSysID,");
              //  _sbSql.AppendLine("IsRenewal)");



                _sbSql.AppendLine("output INSERTED. ParentTxnSysID VALUES ( ");
               // _sbSql.AppendLine("@TxnSysID,");
                _sbSql.AppendLine("@TxnSysDate,");
                _sbSql.AppendLine("@DocMonth,");
                _sbSql.AppendLine("@DocString,");
                _sbSql.AppendLine("@DocYear,");
                _sbSql.AppendLine("@DocNo,");
                _sbSql.AppendLine("@DocType,");
                _sbSql.AppendLine("@GenerateAgainst,");
                _sbSql.AppendLine("@ProductCode,");
                _sbSql.AppendLine("@PolicyTypeCode,");
                _sbSql.AppendLine("@ClientCode,");
                _sbSql.AppendLine("@AgencyCode,");
                _sbSql.AppendLine("@CertInsureCode,");
                _sbSql.AppendLine("@Remarks,");
                _sbSql.AppendLine("@BrchCoverNoteNo,");
                _sbSql.AppendLine("@BrchCode,");
                _sbSql.AppendLine("@LeaderPolicyNo,");
                _sbSql.AppendLine("@LeaderEndNo,");
                _sbSql.AppendLine("@IsFiler,");
                _sbSql.AppendLine("@CalcType,");
                _sbSql.AppendLine("@IsAuto,");
                _sbSql.AppendLine("@EffectiveDate,");
                _sbSql.AppendLine("@ExpiryDate,");
                _sbSql.AppendLine("@SerialNo,");
                _sbSql.AppendLine("@UWYear,");
                _sbSql.AppendLine("@CreatedBy,");
                _sbSql.AppendLine("@CommisionRate,");
                //_sbSql.AppendLine("@SerialNo,");
                 _sbSql.AppendLine("@IsPosted,");
                 // _sbSql.AppendLine("@PostDate,");
                _sbSql.AppendLine("@EndoSerial,");
                _sbSql.AppendLine("@OpolTxnSysID)");
              //  _sbSql.AppendLine("@RenewSysID,");
              //  _sbSql.AppendLine("@PolSysID,");
              //  _sbSql.AppendLine("@IsRenewal,");


                _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);
                   // DateTime da = DateTime.Now;
                  //  da.ToString("MM-dd-yyyy h:mm tt");
                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", SqlDbType.DateTime).Value =  DateTime.Now;
                    

                    _cmdSql.Parameters.AddWithValue("@DocMonth", OpenPolicyMdl.PolicyMonth);

                       


                    _cmdSql.Parameters.AddWithValue("@DocYear", OpenPolicyMdl.PolicyYear);

                    _cmdSql.Parameters.AddWithValue("@DocNo", GettingNewCertNo(_MtrInsPolicyMdl));

                    string OpenPolicyDoc = "7";

                     _cmdSql.Parameters.AddWithValue("@DocType", OpenPolicyDoc);

                string CertString = GetCertString(
                     OpenPolicyMdl.BrchCode,
                     OpenPolicyMdl.InsuranceTypeCode.ToString(),
                     OpenPolicyDoc,
                     Convert.ToInt32(OpenPolicyMdl.PolicyTypeCode),
                     _SerialNumber,
                    DateTime.Now.Month.ToString(),
                        DateTime.Now.Year.ToString());

                _cmdSql.Parameters.AddWithValue("@DocString", CertString);

                _cmdSql.Parameters.AddWithValue("@GenerateAgainst", OpenPolicyMdl.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@ProductCode", OpenPolicyMdl.ProductCode);
                    _cmdSql.Parameters.AddWithValue("@PolicyTypeCode", OpenPolicyMdl.PolicyTypeCode);
                    _cmdSql.Parameters.AddWithValue("@ClientCode", _MtrInsPolicyMdl.ClientCode);
                    _cmdSql.Parameters.AddWithValue("@AgencyCode", OpenPolicyMdl.AgencyCode);
                    _cmdSql.Parameters.AddWithValue("@CertInsureCode", OpenPolicyMdl.CertInsureCode);
                    _cmdSql.Parameters.AddWithValue("@Remarks", OpenPolicyMdl.Remarks);
                    _cmdSql.Parameters.AddWithValue("@BrchCoverNoteNo", OpenPolicyMdl.BrchCoverNoteNo);
                _cmdSql.Parameters.AddWithValue("@BrchCode", OpenPolicyMdl.BrchCode);
                _cmdSql.Parameters.AddWithValue("@LeaderPolicyNo", OpenPolicyMdl.LeaderPolicyNo);
                    _cmdSql.Parameters.AddWithValue("@LeaderEndNo", OpenPolicyMdl.LeaderEndNo);
                    _cmdSql.Parameters.AddWithValue("@IsFiler", OpenPolicyMdl.IsFiler);
                    _cmdSql.Parameters.AddWithValue("@CalcType", OpenPolicyMdl.CalcType);
                    _cmdSql.Parameters.AddWithValue("@IsAuto", OpenPolicyMdl.IsAuto);
                _cmdSql.Parameters.AddWithValue("@EffectiveDate", Convert.ToDateTime(_MtrInsPolicyMdl.EffectiveDate.ToString()));
                _cmdSql.Parameters.AddWithValue("@ExpiryDate", Convert.ToDateTime(_MtrInsPolicyMdl.ExpiryDate.ToString()));
                _cmdSql.Parameters.AddWithValue("@SerialNo", _SerialNumber);
                    _cmdSql.Parameters.AddWithValue("@UWYear", OpenPolicyMdl.UWYear);
                _cmdSql.Parameters.AddWithValue("@CommisionRate", OpenPolicyMdl.CommisionRate);

                _cmdSql.Parameters.AddWithValue("@CreatedBy", _MtrInsPolicyMdl.CreatedBy);
                
                //Endorsement Serial
                _cmdSql.Parameters.AddWithValue("@EndoSerial", Convert.ToInt32(0));

                _cmdSql.Parameters.AddWithValue("@IsPosted", OpenPolicyMdl.IsPosted);
                    // _cmdSql.Parameters.AddWithValue("@PostDate", OpenPolicyMdl.PostDate);
                     _cmdSql.Parameters.AddWithValue("@OpolTxnSysID", OpenPolicyMdl.TxnSysID);
                

                _MtrInsPolicyMdl.CertString = CertString;
                _MtrInsPolicyMdl.SerialNo = _SerialNumber;
               // _MtrInsPolicyMdl.TxnSysDate = DateTime.Now;


                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();
                    _MtrOpenPolicyMdl.IsValidTxn = true;

                     _MtrInsPolicyMdl.ParentTxnSysID = _TxnSysId;

                    _MtrInsPolicyMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(OpenPolicyMdl.ProductCode.ToString());
                    _MtrInsPolicyMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(OpenPolicyMdl.PolicyTypeCode.ToString());
                    _MtrInsPolicyMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_MtrInsPolicyMdl.ClientCode.ToString());
                    _MtrInsPolicyMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(OpenPolicyMdl.AgencyCode.ToString());
                    _MtrInsPolicyMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(OpenPolicyMdl.CertInsureCode.ToString());

                string OpenPolicyDoc1 = "7";
                _MtrInsPolicyMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(OpenPolicyDoc1);
                _MtrInsPolicyMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(OpenPolicyMdl.IsFiler.ToString());
                _MtrInsPolicyMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(OpenPolicyMdl.CalcType.ToString());
                _MtrInsPolicyMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(OpenPolicyMdl.IsAuto.ToString());

                _MtrInsPolicyMdl.IsValidTxn = true;
                _MtrInsPolicyMdl.DocType = OpenPolicyDoc1;

                    return _MtrInsPolicyMdl;
                
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        ////for Inserting into InsPolicy for Policy
        //public MtrInsPolicyMdl AddMtrInsPolicyForPol(MtrInsPolicyMdl _MtrInsPolicyMdl, MtrOpenPolicyMdl _MtrOpenPolicyMdl)
        //{
        //    try

        //    {
        //        _MtrInsPolicyMdl.SerialNo = _MtrInsPolicyMdl.SerialNo == 0 ? _MtrInsPolicyMdl.SerialNo++ : _MtrInsPolicyMdl.SerialNo++;

        //        SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
        //        StringBuilder _sbSql = new StringBuilder();
        //        SqlCommand _cmdSql;
        //        int _SerialNumber = GetSerialNo(_MtrInsPolicyMdl);


        //        MtrOpenPolicyMdl OpenPolicyMdl = GetOpolicytByProductCode(_MtrOpenPolicyMdl);

        //        _sbSql.AppendLine("INSERT INTO InsPolicy(");
        //        // _sbSql.AppendLine("ParentTxnSysID,");
        //        _sbSql.AppendLine("TxnSysDate,");
        //        _sbSql.AppendLine("DocMonth,");
        //        _sbSql.AppendLine("DocString,");
        //        _sbSql.AppendLine("DocYear,");
        //        _sbSql.AppendLine("DocNo,");
        //        _sbSql.AppendLine("DocType,");
        //        _sbSql.AppendLine("GenerateAgainst,");
        //        _sbSql.AppendLine("ProductCode,");
        //        _sbSql.AppendLine("PolicyTypeCode,");
        //        _sbSql.AppendLine("ClientCode,");
        //        _sbSql.AppendLine("AgencyCode,");
        //        _sbSql.AppendLine("CertInsureCode,");
        //        _sbSql.AppendLine("Remarks,");
        //        _sbSql.AppendLine("BrchCoverNoteNo,");
        //        _sbSql.AppendLine("LeaderPolicyNo,");
        //        _sbSql.AppendLine("LeaderEndNo,");
        //        _sbSql.AppendLine("IsFiler,");
        //        _sbSql.AppendLine("CalcType,");
        //        _sbSql.AppendLine("IsAuto,");
        //        _sbSql.AppendLine("EffectiveDate,");
        //        _sbSql.AppendLine("ExpiryDate,");
        //        _sbSql.AppendLine("SerialNo,");
        //        _sbSql.AppendLine("UWYear,");
        //        _sbSql.AppendLine("CreatedBy,");
        //        _sbSql.AppendLine("CommisionRate,");
        //        //_sbSql.AppendLine("SerialNo,");
        //        _sbSql.AppendLine("IsPosted,");
        //        _sbSql.AppendLine("PostDate,");
        //        _sbSql.AppendLine("OpolTxnSysID)");
        //        // _sbSql.AppendLine("RenewSysID,");
        //        //  _sbSql.AppendLine("PolSysID,");
        //        //  _sbSql.AppendLine("IsRenewal)");



        //        _sbSql.AppendLine("output INSERTED. ParentTxnSysID VALUES ( ");
        //        // _sbSql.AppendLine("@ParentTxnSysID,");
        //        _sbSql.AppendLine("@TxnSysDate,");
        //        _sbSql.AppendLine("@DocMonth,");
        //        _sbSql.AppendLine("@DocString,");
        //        _sbSql.AppendLine("@DocYear,");
        //        _sbSql.AppendLine("@DocNo,");
        //        _sbSql.AppendLine("@DocType,");
        //        _sbSql.AppendLine("@GenerateAgainst,");
        //        _sbSql.AppendLine("@ProductCode,");
        //        _sbSql.AppendLine("@PolicyTypeCode,");
        //        _sbSql.AppendLine("@ClientCode,");
        //        _sbSql.AppendLine("@AgencyCode,");
        //        _sbSql.AppendLine("@CertInsureCode,");
        //        _sbSql.AppendLine("@Remarks,");
        //        _sbSql.AppendLine("@BrchCoverNoteNo,");
        //        _sbSql.AppendLine("@LeaderPolicyNo,");
        //        _sbSql.AppendLine("@LeaderEndNo,");
        //        _sbSql.AppendLine("@IsFiler,");
        //        _sbSql.AppendLine("@CalcType,");
        //        _sbSql.AppendLine("@IsAuto,");
        //        _sbSql.AppendLine("@EffectiveDate,");
        //        _sbSql.AppendLine("@ExpiryDate,");
        //        _sbSql.AppendLine("@SerialNo,");
        //        _sbSql.AppendLine("@UWYear,");
        //        _sbSql.AppendLine("@CreatedBy,");
        //        _sbSql.AppendLine("@CommisionRate,");
        //        //_sbSql.AppendLine("@SerialNo,");
        //        _sbSql.AppendLine("@IsPosted,");
        //        _sbSql.AppendLine("@PostDate,");
        //        _sbSql.AppendLine("@OpolTxnSysID)");
        //        //  _sbSql.AppendLine("@RenewSysID,");
        //        //  _sbSql.AppendLine("@PolSysID,");
        //        //  _sbSql.AppendLine("@IsRenewal,");


        //        _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);
        //        // DateTime da = DateTime.Now;
        //        //  da.ToString("MM-dd-yyyy h:mm tt");
        //        _cmdSql.Parameters.AddWithValue("@TxnSysDate", SqlDbType.DateTime).Value = DateTime.Now;

               
        //         _cmdSql.Parameters.AddWithValue("@DocMonth", OpenPolicyMdl.PolicyMonth);

        //        _cmdSql.Parameters.AddWithValue("@DocYear", OpenPolicyMdl.PolicyYear);

        //       _cmdSql.Parameters.AddWithValue("@DocNo", GettingNewCertNo(_MtrInsPolicyMdl));

        //        string OpenPolicyDoc = "4";

        //        _cmdSql.Parameters.AddWithValue("@DocType", OpenPolicyDoc);

        //        string CertString = GetCertString(
        //             OpenPolicyMdl.BrchCoverNoteNo,
        //             OpenPolicyMdl.InsuranceTypeCode.ToString(),
        //             OpenPolicyDoc,
        //             Convert.ToInt32(OpenPolicyMdl.PolicyTypeCode),
        //             _SerialNumber,
        //            DateTime.Now.Month.ToString(),
        //                DateTime.Now.Year.ToString());

        //        _cmdSql.Parameters.AddWithValue("@DocString", CertString);



        //        _cmdSql.Parameters.AddWithValue("@GenerateAgainst", OpenPolicyMdl.GenerateAgainst);


        //        _cmdSql.Parameters.AddWithValue("@ProductCode", OpenPolicyMdl.ProductCode);
        //        _cmdSql.Parameters.AddWithValue("@PolicyTypeCode", OpenPolicyMdl.PolicyTypeCode);
        //        _cmdSql.Parameters.AddWithValue("@ClientCode", _MtrInsPolicyMdl.ClientCode);
        //        _cmdSql.Parameters.AddWithValue("@AgencyCode", OpenPolicyMdl.AgencyCode);
        //        _cmdSql.Parameters.AddWithValue("@CertInsureCode", OpenPolicyMdl.CertInsureCode);
        //        _cmdSql.Parameters.AddWithValue("@Remarks", OpenPolicyMdl.Remarks);
        //        _cmdSql.Parameters.AddWithValue("@BrchCoverNoteNo", OpenPolicyMdl.BrchCoverNoteNo);
        //        _cmdSql.Parameters.AddWithValue("@LeaderPolicyNo", OpenPolicyMdl.LeaderPolicyNo);
        //        _cmdSql.Parameters.AddWithValue("@LeaderEndNo", OpenPolicyMdl.LeaderEndNo);
        //        _cmdSql.Parameters.AddWithValue("@IsFiler", OpenPolicyMdl.IsFiler);
        //        _cmdSql.Parameters.AddWithValue("@CalcType", OpenPolicyMdl.CalcType);
        //        _cmdSql.Parameters.AddWithValue("@IsAuto", OpenPolicyMdl.IsAuto);
        //        _cmdSql.Parameters.AddWithValue("@EffectiveDate", Convert.ToDateTime(_MtrInsPolicyMdl.EffectiveDate.ToString()));
        //        _cmdSql.Parameters.AddWithValue("@ExpiryDate", Convert.ToDateTime(_MtrInsPolicyMdl.ExpiryDate.ToString()));
        //        _cmdSql.Parameters.AddWithValue("@SerialNo", _SerialNumber);
        //        _cmdSql.Parameters.AddWithValue("@UWYear", OpenPolicyMdl.UWYear);

        //        //Change inCommission rate for policy
        //        _cmdSql.Parameters.AddWithValue("@CommisionRate", _MtrInsPolicyMdl.CommisionRate);

        //        _cmdSql.Parameters.AddWithValue("@CreatedBy", _MtrInsPolicyMdl.CreatedBy);

        //        //_cmdSql.Parameters.AddWithValue("@SerialNo", OpenPolicyMdl.SerialNo);
        //        _cmdSql.Parameters.AddWithValue("@IsPosted", OpenPolicyMdl.IsPosted);
        //        _cmdSql.Parameters.AddWithValue("@PostDate", OpenPolicyMdl.PostDate);
        //        _cmdSql.Parameters.AddWithValue("@OpolTxnSysID", -1);


        //        _MtrInsPolicyMdl.CertString = CertString;
        //        _MtrInsPolicyMdl.SerialNo = _SerialNumber;
        //        // _MtrInsPolicyMdl.TxnSysDate = DateTime.Now;


        //        int _TxnSysId;
        //        _conSql.Open();
        //        _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
        //        _conSql.Close();
        //        _MtrOpenPolicyMdl.IsValidTxn = true;

        //        _MtrInsPolicyMdl.ParentTxnSysID = _TxnSysId;

        //        _MtrInsPolicyMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(OpenPolicyMdl.ProductCode.ToString());
        //        _MtrInsPolicyMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(OpenPolicyMdl.PolicyTypeCode.ToString());
        //        _MtrInsPolicyMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_MtrInsPolicyMdl.ClientCode.ToString());
        //        _MtrInsPolicyMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(OpenPolicyMdl.AgencyCode.ToString());
        //        _MtrInsPolicyMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(OpenPolicyMdl.CertInsureCode.ToString());

        //        string OpenPolicyDoc1 = "4";
        //        _MtrInsPolicyMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(OpenPolicyDoc1);
        //        _MtrInsPolicyMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(OpenPolicyMdl.IsFiler.ToString());
        //        _MtrInsPolicyMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(OpenPolicyMdl.CalcType.ToString());
        //        _MtrInsPolicyMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(OpenPolicyMdl.IsAuto.ToString());

        //        _MtrInsPolicyMdl.IsValidTxn = true;
        //        _MtrInsPolicyMdl.DocType = OpenPolicyDoc1;

        //        _MtrInsPolicyMdl.ParentTxnSysID = _TxnSysId;

        //        return _MtrInsPolicyMdl;

        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        //for Inserting into InsPolicy for Policy
        public MtrInsPolicyMdl AddMtrInsPolicyForPol1(MtrInsPolicyMdl _MtrInsPolicyMdl, MasterProductSetupMdl _MasterProductSetupMdl1)
        {
            try

            {
                _MtrInsPolicyMdl.SerialNo = _MtrInsPolicyMdl.SerialNo == 0 ? _MtrInsPolicyMdl.SerialNo++ : _MtrInsPolicyMdl.SerialNo++;

                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();
                SqlCommand _cmdSql;
                int _SerialNumber = GetSerialNo(_MtrInsPolicyMdl);

                MasterProductSetupMdl _MasterProductSetupMdl = GetMasterProductByProductCode(_MasterProductSetupMdl1);



                _sbSql.AppendLine("INSERT INTO InsPolicy(");
                // _sbSql.AppendLine("ParentTxnSysID,");
                _sbSql.AppendLine("TxnSysDate,");
                _sbSql.AppendLine("DocMonth,");
                _sbSql.AppendLine("DocString,");
                _sbSql.AppendLine("DocYear,");
                _sbSql.AppendLine("DocNo,");
                _sbSql.AppendLine("DocType,");
                _sbSql.AppendLine("GenerateAgainst,");
                _sbSql.AppendLine("ProductCode,");
                _sbSql.AppendLine("PolicyTypeCode,");
                _sbSql.AppendLine("ClientCode,");
                _sbSql.AppendLine("AgencyCode,");
                _sbSql.AppendLine("CertInsureCode,");
              //  _sbSql.AppendLine("Remarks,");
              //  _sbSql.AppendLine("BrchCoverNoteNo,");
              //  _sbSql.AppendLine("LeaderPolicyNo,");
              //  _sbSql.AppendLine("LeaderEndNo,");
              //  _sbSql.AppendLine("IsFiler,");
              //  _sbSql.AppendLine("CalcType,");
               // _sbSql.AppendLine("IsAuto,");
                _sbSql.AppendLine("EffectiveDate,");
                _sbSql.AppendLine("ExpiryDate,");
                _sbSql.AppendLine("SerialNo,");
                _sbSql.AppendLine("UWYear,");
                _sbSql.AppendLine("CreatedBy,");
                _sbSql.AppendLine("CommisionRate,");
                //_sbSql.AppendLine("SerialNo,");
                //  _sbSql.AppendLine("IsPosted,");
                // _sbSql.AppendLine("PostDate,");
                _sbSql.AppendLine("EndoSerial,");
                _sbSql.AppendLine("OpolTxnSysID)");
                // _sbSql.AppendLine("RenewSysID,");
                //  _sbSql.AppendLine("PolSysID,");
                //  _sbSql.AppendLine("IsRenewal)");



                _sbSql.AppendLine("output INSERTED. ParentTxnSysID VALUES ( ");
                // _sbSql.AppendLine("@ParentTxnSysID,");
                _sbSql.AppendLine("@TxnSysDate,");
                _sbSql.AppendLine("@DocMonth,");
                _sbSql.AppendLine("@DocString,");
                _sbSql.AppendLine("@DocYear,");
                _sbSql.AppendLine("@DocNo,");
                _sbSql.AppendLine("@DocType,");
                _sbSql.AppendLine("@GenerateAgainst,");
                _sbSql.AppendLine("@ProductCode,");
                _sbSql.AppendLine("@PolicyTypeCode,");
                _sbSql.AppendLine("@ClientCode,");
                _sbSql.AppendLine("@AgencyCode,");
                _sbSql.AppendLine("@CertInsureCode,");
               // _sbSql.AppendLine("@Remarks,");
               // _sbSql.AppendLine("@BrchCoverNoteNo,");
               // _sbSql.AppendLine("@LeaderPolicyNo,");
               // _sbSql.AppendLine("@LeaderEndNo,");
               // _sbSql.AppendLine("@IsFiler,");
               // _sbSql.AppendLine("@CalcType,");
               // _sbSql.AppendLine("@IsAuto,");
                _sbSql.AppendLine("@EffectiveDate,");
                _sbSql.AppendLine("@ExpiryDate,");
                _sbSql.AppendLine("@SerialNo,");
                _sbSql.AppendLine("@UWYear,");
                _sbSql.AppendLine("@CreatedBy,");
                _sbSql.AppendLine("@CommisionRate,");
                //_sbSql.AppendLine("@SerialNo,");
                // _sbSql.AppendLine("@IsPosted,");
                // _sbSql.AppendLine("@PostDate,");
                _sbSql.AppendLine("@EndoSerial,");
                _sbSql.AppendLine("@OpolTxnSysID)");
                //  _sbSql.AppendLine("@RenewSysID,");
                //  _sbSql.AppendLine("@PolSysID,");
                //  _sbSql.AppendLine("@IsRenewal,");


                _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);
                _cmdSql.Parameters.AddWithValue("@TxnSysDate", SqlDbType.DateTime).Value = DateTime.Now;
                _cmdSql.Parameters.AddWithValue("@DocMonth", DateTime.Now.Month);
                _cmdSql.Parameters.AddWithValue("@DocYear", DateTime.Now.Year);
                _cmdSql.Parameters.AddWithValue("@DocNo", GettingNewCertNo(_MtrInsPolicyMdl));
                string OpenPolicyDoc = "4";
                _cmdSql.Parameters.AddWithValue("@DocType", OpenPolicyDoc);

                string CertString = GetCertString(
                    "101",
                    GlobalDataLayer.GetCertInsByPolicyType(_MasterProductSetupMdl.PolicyTypeCode),
                    OpenPolicyDoc,
                   Convert.ToInt32(_MasterProductSetupMdl.PolicyTypeCode),
                    _SerialNumber,
                  DateTime.Now.Month.ToString(),
                       DateTime.Now.Year.ToString());

                 _cmdSql.Parameters.AddWithValue("@DocString", CertString);

               // _cmdSql.Parameters.AddWithValue("@DocString", -1);

                _cmdSql.Parameters.AddWithValue("@GenerateAgainst", _MasterProductSetupMdl.TxnSysID);

                //_cmdSql.Parameters.AddWithValue("@GenerateAgainst", OpenPolicyMdl.GenerateAgainst);


                _cmdSql.Parameters.AddWithValue("@ProductCode", _MasterProductSetupMdl1.ProductCode);
                _cmdSql.Parameters.AddWithValue("@PolicyTypeCode", _MasterProductSetupMdl.PolicyTypeCode);
                _cmdSql.Parameters.AddWithValue("@ClientCode", _MtrInsPolicyMdl.ClientCode);
                _cmdSql.Parameters.AddWithValue("@AgencyCode", _MtrInsPolicyMdl.AgencyCode);

                string CerInsuranceCode = GetCertInsByPolicyType(_MasterProductSetupMdl.PolicyTypeCode);
                _cmdSql.Parameters.AddWithValue("@CertInsureCode", CerInsuranceCode);

               
                _cmdSql.Parameters.AddWithValue("@EffectiveDate", Convert.ToDateTime(_MtrInsPolicyMdl.EffectiveDate.ToString()));
                _cmdSql.Parameters.AddWithValue("@ExpiryDate", Convert.ToDateTime(_MtrInsPolicyMdl.ExpiryDate.ToString()));
                _cmdSql.Parameters.AddWithValue("@SerialNo", _SerialNumber);
                _cmdSql.Parameters.AddWithValue("@UWYear", DateTime.Now.Year);

                //Change inCommission rate for policy
                _cmdSql.Parameters.AddWithValue("@CommisionRate", _MtrInsPolicyMdl.CommisionRate);

                _cmdSql.Parameters.AddWithValue("@CreatedBy", _MtrInsPolicyMdl.CreatedBy);

                
                _cmdSql.Parameters.AddWithValue("@OpolTxnSysID", -1);

                //Endorsement Serial
                _cmdSql.Parameters.AddWithValue("@EndoSerial", Convert.ToInt32(0));

                _MtrInsPolicyMdl.SerialNo = _SerialNumber;
               


                int _TxnSysId;
                _conSql.Open();
                _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                _conSql.Close();
               

                _MtrInsPolicyMdl.ParentTxnSysID = _TxnSysId;
                _MtrInsPolicyMdl.IsValidTxn = true;

                _MtrInsPolicyMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(_MasterProductSetupMdl1.ProductCode.ToString());
                _MtrInsPolicyMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_MasterProductSetupMdl.PolicyTypeCode.ToString());
                _MtrInsPolicyMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_MtrInsPolicyMdl.ClientCode.ToString());
                _MtrInsPolicyMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_MtrInsPolicyMdl.AgencyCode.ToString());
                _MtrInsPolicyMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(CerInsuranceCode.ToString());

                string OpenPolicyDoc1 = "4";
                _MtrInsPolicyMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(OpenPolicyDoc1);
               // _MtrInsPolicyMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(OpenPolicyMdl.IsFiler.ToString());
               // _MtrInsPolicyMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(OpenPolicyMdl.CalcType.ToString());
              //  _MtrInsPolicyMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(OpenPolicyMdl.IsAuto.ToString());

                _MtrInsPolicyMdl.IsValidTxn = true;
                _MtrInsPolicyMdl.DocType = OpenPolicyDoc1;

                _MtrInsPolicyMdl.ParentTxnSysID = _TxnSysId;

                return _MtrInsPolicyMdl;

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }


        //for Inserting into InsPolicy for Endorsement
        public MtrInsPolicyMdl AddMtrInsPolicyForEnd(MtrInsPolicyMdl _MtrInsPolicyMdl, MtrOpenPolicyMdl _MtrOpenPolicyMdl)
        {
            try

            {

                _MtrInsPolicyMdl.SerialNo = _MtrInsPolicyMdl.SerialNo == 0 ? _MtrInsPolicyMdl.SerialNo++ : _MtrInsPolicyMdl.SerialNo++;



                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();
                SqlCommand _cmdSql;
                int _SerialNumber = GetSerialNo(_MtrInsPolicyMdl);


                MtrOpenPolicyMdl OpenPolicyMdl = GetOpolicytByProductCode(_MtrOpenPolicyMdl);

                _sbSql.AppendLine("INSERT INTO InsPolicy(");
                // _sbSql.AppendLine("ParentTxnSysID,");
                _sbSql.AppendLine("TxnSysDate,");
                _sbSql.AppendLine("DocMonth,");
                _sbSql.AppendLine("DocString,");
                _sbSql.AppendLine("DocYear,");
                _sbSql.AppendLine("DocNo,");
                _sbSql.AppendLine("DocType,");
                _sbSql.AppendLine("GenerateAgainst,");
                _sbSql.AppendLine("ProductCode,");
                _sbSql.AppendLine("PolicyTypeCode,");
                _sbSql.AppendLine("ClientCode,");
                _sbSql.AppendLine("AgencyCode,");
                _sbSql.AppendLine("CertInsureCode,");
                _sbSql.AppendLine("Remarks,");
                _sbSql.AppendLine("BrchCoverNoteNo,");
                _sbSql.AppendLine("BrchCode,");
                _sbSql.AppendLine("LeaderPolicyNo,");
                _sbSql.AppendLine("LeaderEndNo,");
                _sbSql.AppendLine("IsFiler,");
                _sbSql.AppendLine("CalcType,");
                _sbSql.AppendLine("IsAuto,");
                _sbSql.AppendLine("EffectiveDate,");
                _sbSql.AppendLine("ExpiryDate,");
                _sbSql.AppendLine("SerialNo,");
                _sbSql.AppendLine("UWYear,");
                _sbSql.AppendLine("CreatedBy,");
                _sbSql.AppendLine("CommisionRate,");
                //_sbSql.AppendLine("SerialNo,");
                _sbSql.AppendLine("IsPosted,");
                _sbSql.AppendLine("PostDate,");
                _sbSql.AppendLine("OpolTxnSysID)");
                // _sbSql.AppendLine("RenewSysID,");
                //  _sbSql.AppendLine("PolSysID,");
                //  _sbSql.AppendLine("IsRenewal)");



                _sbSql.AppendLine("output INSERTED. ParentTxnSysID VALUES ( ");
                // _sbSql.AppendLine("@ParentTxnSysID,");
                _sbSql.AppendLine("@TxnSysDate,");
                _sbSql.AppendLine("@DocMonth,");
                _sbSql.AppendLine("@DocString,");
                _sbSql.AppendLine("@DocYear,");
                _sbSql.AppendLine("@DocNo,");
                _sbSql.AppendLine("@DocType,");
                _sbSql.AppendLine("@GenerateAgainst,");
                _sbSql.AppendLine("@ProductCode,");
                _sbSql.AppendLine("@PolicyTypeCode,");
                _sbSql.AppendLine("@ClientCode,");
                _sbSql.AppendLine("@AgencyCode,");
                _sbSql.AppendLine("@CertInsureCode,");
                _sbSql.AppendLine("@Remarks,");
                _sbSql.AppendLine("@BrchCoverNoteNo,");
                _sbSql.AppendLine("@BrchCode,");
                _sbSql.AppendLine("@LeaderPolicyNo,");
                _sbSql.AppendLine("@LeaderEndNo,");
                _sbSql.AppendLine("@IsFiler,");
                _sbSql.AppendLine("@CalcType,");
                _sbSql.AppendLine("@IsAuto,");
                _sbSql.AppendLine("@EffectiveDate,");
                _sbSql.AppendLine("@ExpiryDate,");
                _sbSql.AppendLine("@SerialNo,");
                _sbSql.AppendLine("@UWYear,");
                _sbSql.AppendLine("@CreatedBy,");
                _sbSql.AppendLine("@CommisionRate,");
                //_sbSql.AppendLine("@SerialNo,");
                _sbSql.AppendLine("@IsPosted,");
                _sbSql.AppendLine("@PostDate,");
                _sbSql.AppendLine("@OpolTxnSysID)");
                //  _sbSql.AppendLine("@RenewSysID,");
                //  _sbSql.AppendLine("@PolSysID,");
                //  _sbSql.AppendLine("@IsRenewal,");


                _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);
                // DateTime da = DateTime.Now;
                //  da.ToString("MM-dd-yyyy h:mm tt");
                _cmdSql.Parameters.AddWithValue("@TxnSysDate", SqlDbType.DateTime).Value = DateTime.Now;


                _cmdSql.Parameters.AddWithValue("@DocMonth", OpenPolicyMdl.PolicyMonth);




                _cmdSql.Parameters.AddWithValue("@DocYear", OpenPolicyMdl.PolicyYear);

                _cmdSql.Parameters.AddWithValue("@DocNo", GettingNewCertNo(_MtrInsPolicyMdl));

                string OpenPolicyDoc = "5";

                _cmdSql.Parameters.AddWithValue("@DocType", OpenPolicyDoc);

                string CertString = GetCertString(
                     OpenPolicyMdl.BrchCode,
                     OpenPolicyMdl.InsuranceTypeCode.ToString(),
                     OpenPolicyDoc,
                     Convert.ToInt32(OpenPolicyMdl.PolicyTypeCode),
                     _SerialNumber,
                    DateTime.Now.Month.ToString(),
                        DateTime.Now.Year.ToString());

                _cmdSql.Parameters.AddWithValue("@DocString", CertString);

                _cmdSql.Parameters.AddWithValue("@GenerateAgainst", OpenPolicyMdl.GenerateAgainst);
                _cmdSql.Parameters.AddWithValue("@ProductCode", OpenPolicyMdl.ProductCode);
                _cmdSql.Parameters.AddWithValue("@PolicyTypeCode", OpenPolicyMdl.PolicyTypeCode);
                _cmdSql.Parameters.AddWithValue("@ClientCode", _MtrInsPolicyMdl.ClientCode);
                _cmdSql.Parameters.AddWithValue("@AgencyCode", OpenPolicyMdl.AgencyCode);
                _cmdSql.Parameters.AddWithValue("@CertInsureCode", OpenPolicyMdl.CertInsureCode);
                _cmdSql.Parameters.AddWithValue("@Remarks", OpenPolicyMdl.Remarks);
                _cmdSql.Parameters.AddWithValue("@BrchCoverNoteNo", OpenPolicyMdl.BrchCoverNoteNo);
                _cmdSql.Parameters.AddWithValue("@BrchCode", OpenPolicyMdl.BrchCode);
                _cmdSql.Parameters.AddWithValue("@LeaderPolicyNo", OpenPolicyMdl.LeaderPolicyNo);
                _cmdSql.Parameters.AddWithValue("@LeaderEndNo", OpenPolicyMdl.LeaderEndNo);
                _cmdSql.Parameters.AddWithValue("@IsFiler", OpenPolicyMdl.IsFiler);
                _cmdSql.Parameters.AddWithValue("@CalcType", OpenPolicyMdl.CalcType);
                _cmdSql.Parameters.AddWithValue("@IsAuto", OpenPolicyMdl.IsAuto);
                _cmdSql.Parameters.AddWithValue("@EffectiveDate", Convert.ToDateTime(_MtrInsPolicyMdl.EffectiveDate.ToString()));
                _cmdSql.Parameters.AddWithValue("@ExpiryDate", Convert.ToDateTime(_MtrInsPolicyMdl.ExpiryDate.ToString()));
                _cmdSql.Parameters.AddWithValue("@SerialNo", _SerialNumber);
                _cmdSql.Parameters.AddWithValue("@UWYear", OpenPolicyMdl.UWYear);

                //Change inCommission rate for policy
                _cmdSql.Parameters.AddWithValue("@CommisionRate", _MtrInsPolicyMdl.CommisionRate);

                _cmdSql.Parameters.AddWithValue("@CreatedBy", _MtrInsPolicyMdl.CreatedBy);

                //_cmdSql.Parameters.AddWithValue("@SerialNo", OpenPolicyMdl.SerialNo);
                _cmdSql.Parameters.AddWithValue("@IsPosted", OpenPolicyMdl.IsPosted);
                _cmdSql.Parameters.AddWithValue("@PostDate", OpenPolicyMdl.PostDate);
                _cmdSql.Parameters.AddWithValue("@OpolTxnSysID", -1);


                _MtrInsPolicyMdl.CertString = CertString;
                _MtrInsPolicyMdl.SerialNo = _SerialNumber;
                // _MtrInsPolicyMdl.TxnSysDate = DateTime.Now;


                int _TxnSysId;
                _conSql.Open();
                _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                _conSql.Close();
                _MtrOpenPolicyMdl.IsValidTxn = true;

                _MtrInsPolicyMdl.ParentTxnSysID = _TxnSysId;

                _MtrInsPolicyMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(OpenPolicyMdl.ProductCode.ToString());
                _MtrInsPolicyMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(OpenPolicyMdl.PolicyTypeCode.ToString());
                _MtrInsPolicyMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_MtrInsPolicyMdl.ClientCode.ToString());
                _MtrInsPolicyMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(OpenPolicyMdl.AgencyCode.ToString());
                _MtrInsPolicyMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(OpenPolicyMdl.CertInsureCode.ToString());

                string OpenPolicyDoc1 = "5";
                _MtrInsPolicyMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(OpenPolicyDoc1);
                _MtrInsPolicyMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(OpenPolicyMdl.IsFiler.ToString());
                _MtrInsPolicyMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(OpenPolicyMdl.CalcType.ToString());
                _MtrInsPolicyMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(OpenPolicyMdl.IsAuto.ToString());

                _MtrInsPolicyMdl.IsValidTxn = true;
                _MtrInsPolicyMdl.DocType = OpenPolicyDoc1;

                return _MtrInsPolicyMdl;

            }
            catch (Exception e)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(e.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //------------------- CRUD Ends From Here --------------------//


        //Get All Open Policy Attributes by Product Code
        public MtrOpenPolicyMdl GetOpolicytByProductCode(MtrOpenPolicyMdl _MtrOpenPolicyMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT * FROM ClientProductSetup WHERE ClientCode=" ;
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrOpenPolicyMdl> _MtrOpenPolicyMdlList = new List<MtrOpenPolicyMdl>();



                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM MtrOpenPolicy WHERE ProductCode = @ProductCode", conn);

                    command.Parameters.Add(new SqlParameter("@ProductCode", _MtrOpenPolicyMdl.ProductCode));

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
                        _MtrOpenPolicyMdl.InsuranceTypeCode = Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]);
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
                        _MtrOpenPolicyMdl.BrchCode = _tblSqla.Rows[i]["BrchCode"].ToString();
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }


        //for getting all Open Policy by Client Code 
        public List<MtrOpenPolicyMdl>  GetOpolicytByClient(ProductClientMdl _ProductClientMdl1)
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
                        _MtrOpenPolicyMdl.ProductCode =Convert.ToInt32( _tblSqla.Rows[i]["ProductCode"]);
                        _MtrOpenPolicyMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();
                        _MtrOpenPolicyMdl.ClientCode = _tblSqla.Rows[i]["ClientCode"].ToString();
                        _MtrOpenPolicyMdl.AgencyCode = _tblSqla.Rows[i]["AgencyCode"].ToString();
                        _MtrOpenPolicyMdl.CertInsureCode = _tblSqla.Rows[i]["CertInsureCode"].ToString();
                        _MtrOpenPolicyMdl.Remarks = _tblSqla.Rows[i]["Remarks"].ToString();
                        _MtrOpenPolicyMdl.BrchCoverNoteNo = _tblSqla.Rows[i]["BrchCoverNoteNo"].ToString();
                        _MtrOpenPolicyMdl.BrchCode = _tblSqla.Rows[i]["BrchCode"].ToString();
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //Get All Open Policy Attributes by Open Policy TxnSysID
        public MtrOpenPolicyMdl GetOpolicytByTxnID(MtrOpenPolicyMdl _MtrOpenPolicyMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT * FROM ClientProductSetup WHERE ClientCode=" ;
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrOpenPolicyMdl> _MtrOpenPolicyMdlList = new List<MtrOpenPolicyMdl>();
               


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM MtrOpenPolicy WHERE TxnSysID = @TxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@TxnSysID", _MtrOpenPolicyMdl.TxnSysID));

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
                        _MtrOpenPolicyMdl.InsuranceTypeCode = Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]);
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
                        _MtrOpenPolicyMdl.BrchCode = _tblSqla.Rows[i]["BrchCode"].ToString();
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

                        _MtrOpenPolicyMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_tblSqla.Rows[i]["AgencyCode"].ToString());
                        _MtrOpenPolicyMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_tblSqla.Rows[i]["ClientCode"].ToString());
                        _MtrOpenPolicyMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(_tblSqla.Rows[i]["ProductCode"].ToString());
                        _MtrOpenPolicyMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_tblSqla.Rows[i]["PolicyTypeCode"].ToString());
                        _MtrOpenPolicyMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_tblSqla.Rows[i]["CertInsureCode"].ToString());

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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }


        //Get new Cert No
        private string GettingNewCertNo(MtrInsPolicyMdl _MtrInsPolicyMdl)
        {
            try
            {
                SqlConnection _conSql =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(DocNo) LastCertNo FROM InsPolicy";

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

        //For Increment of Serial Numbers
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


        //For Creation of Cert String
        public string GetCertString(string _BranchCode, string InsuranceType, string _DocType, int _PolicyTypeCode, int _SerialNumber, string _PolicyMonth, string _PolicyYear)
        {
            string PolicyString = _BranchCode + "-" + InsuranceType +"-2-" + _DocType + "-000" + _PolicyTypeCode + "-00"+_SerialNumber + "-"+ _PolicyMonth+"-"+ _PolicyYear;
            return PolicyString;
        }

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
                        _MasterProductSetupMdl.IsClientBased = _tblSqla.Rows[i]["IsClientBased"].ToString();
                        _MasterProductSetupMdl.Client = _tblSqla.Rows[i]["Client"].ToString();
                        _MasterProductSetupMdl.Agent = _tblSqla.Rows[i]["Agent"].ToString();
                        _MasterProductSetupMdl.AgentCommPct = Convert.ToDecimal(_tblSqla.Rows[i]["AgentCommPct"]);
                        _MasterProductSetupMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();

                        _MasterProductSetupMdl.CertInsureCode = GetCertInsByPolicyType(_tblSqla.Rows[i]["PolicyTypeCode"].ToString());


                        _MasterProductSetupMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_tblSqla.Rows[i]["Client"].ToString());
                        _MasterProductSetupMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_tblSqla.Rows[i]["Agent"].ToString());
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //---------------- For Tracker , Rider , Conditons And Warranties ------------------- //

        //For Getting all Ins Tracker 
        public List<MtrInsTrackerMdl> GetInsTracker(MtrInsTrackerMdl _MtrInsTrackerMdl1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //  string _sqlString = "SELECT * FROM ProductWarrantiesProductSetup";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrInsTrackerMdl> _MtrInsTrackerMdlList = new List<MtrInsTrackerMdl>();
                MtrInsTrackerMdl _MtrInsTrackerMdl;


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM InsMtrTracker WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsTrackerMdl1.ParentTxnSysID));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


                //  _adpSql.Fill(_tbl);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrInsTrackerMdl = new MtrInsTrackerMdl();

                        _MtrInsTrackerMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrInsTrackerMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrInsTrackerMdl.TrackerCode = Convert.ToInt32(_tblSqla.Rows[i]["TrackerCode"]);
                        _MtrInsTrackerMdl.TrackerName = _tblSqla.Rows[i]["TrackerName"].ToString();
                        _MtrInsTrackerMdl.TrackerRate = Convert.ToInt32(_tblSqla.Rows[i]["TrackerRate"]);
                        _MtrInsTrackerMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["ParentTxnSysID"]);



                        _MtrInsTrackerMdl.IsValidTxn = true;

                        _MtrInsTrackerMdlList.Add(_MtrInsTrackerMdl);
                    }

                    return _MtrInsTrackerMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //for adding new Ins Tracker 
        public MtrInsTrackerMdl AddInsTracker(MtrInsTrackerMdl _MtrInsTrackerMdl)
        {
            try
            {
                if (IsDuplicateInsTracker(_MtrInsTrackerMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _MtrInsTrackerMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1001";
                    _txnError.Error = "Duplicate Transaction";
                    _txnError.TxnSysDate = DateTime.Now;
                    _txnErrors.Add(_txnError);



                    //To Return model

                    _MtrInsTrackerMdl.TxnErrors = _txnErrors;
                    return _MtrInsTrackerMdl;
                }

                else
                {
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("INSERT INTO InsMtrTracker(");
                    // _sbSql.AppendLine("TxnSysID,");
                    // _sbSql.AppendLine("TxnSysDate,");

                    _sbSql.AppendLine("UserCode,");
                    _sbSql.AppendLine("TrackerCode,");
                    _sbSql.AppendLine("TrackerName,");
                    _sbSql.AppendLine("TrackerRate,");
                    _sbSql.AppendLine("ParentTxnSysID)");


                    _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                    // _sbSql.AppendLine("@TxnSysID,");
                    // _sbSql.AppendLine("@TxnSysDate,");
                    _sbSql.AppendLine("@UserCode,");
                    _sbSql.AppendLine("@TrackerCode,");
                    _sbSql.AppendLine("@TrackerName,");
                    _sbSql.AppendLine("@TrackerRate,");
                    _sbSql.AppendLine("@ParentTxnSysID)");


                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);
                    int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsTrackerMdl.UserCode);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@TrackerCode", _MtrInsTrackerMdl.TrackerCode);
                    _cmdSql.Parameters.AddWithValue("@TrackerName", GlobalDataLayer.GetTrackerSetUpNameByCode(_MtrInsTrackerMdl.TrackerCode));
                    _cmdSql.Parameters.AddWithValue("@TrackerRate", _MtrInsTrackerMdl.TrackerRate);
                    _cmdSql.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsTrackerMdl.ParentTxnSysID);


                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();




                    _MtrInsTrackerMdl.TxnSysID = _TxnSysId;
                    _MtrInsTrackerMdl.IsValidTxn = true;
                    return _MtrInsTrackerMdl;

                }


            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //for updating existing Ins Tracker
        public MtrInsTrackerMdl UpdateInsTracker(MtrInsTrackerMdl _MtrInsTrackerMdl)
        {
            try
            {

                _MtrInsTrackerMdl.ParentTxnSysID = _MtrInsTrackerMdl.ParentTxnSysID == 0 ? _MtrInsTrackerMdl.ParentTxnSysID = -1 : _MtrInsTrackerMdl.ParentTxnSysID;

                //if (IsDuplicateInsTracker(_MtrInsTrackerMdl) == false)
                //{

                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("Update  InsMtrTracker SET");
                    _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
                    _sbSql.AppendLine("UserCode= @UserCode,");
                    _sbSql.AppendLine("ParentTxnSysID=@ParentTxnSysID,");
                    _sbSql.AppendLine("TrackerCode=@TrackerCode,");
                    _sbSql.AppendLine("TrackerName=@TrackerName,");
                    _sbSql.AppendLine("TrackerRate=@TrackerRate");

                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsTrackerMdl.UserCode);


                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _MtrInsTrackerMdl.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsTrackerMdl.ParentTxnSysID);
                    _cmdSql.Parameters.AddWithValue("@TrackerCode", _MtrInsTrackerMdl.TrackerCode);
                    _cmdSql.Parameters.AddWithValue("@TrackerName", GlobalDataLayer.GetTrackerSetUpNameByCode(_MtrInsTrackerMdl.TrackerCode));
                    _cmdSql.Parameters.AddWithValue("@TrackerRate", _MtrInsTrackerMdl.TrackerRate);



                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    _MtrInsTrackerMdl.IsValidTxn = true;
                    return _MtrInsTrackerMdl;
                //}

                //else
                //{
                //    List<TxnError> _txnErrors = new List<TxnError>();
                //    TxnError _txnError = new TxnError();
                //    _MtrInsTrackerMdl.IsValidTxn = false;
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

                //    _MtrInsTrackerMdl.TxnErrors = _txnErrors;


                //    return _MtrInsTrackerMdl;

                //}
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //for checking duplicate Product Tracker Setup
        public bool IsDuplicateInsTracker(MtrInsTrackerMdl _MtrInsTrackerMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  InsMtrTracker  WHERE UPPER(TrackerName)='" + _MtrInsTrackerMdl.TrackerName.ToString().ToUpper() + "' AND ParentTxnSysID=" + _MtrInsTrackerMdl.ParentTxnSysID + " AND TxnSysID <>" + _MtrInsTrackerMdl.TxnSysID;


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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return true;
            }
        }

        //For Getting all Ins Rider 
        public List<MtrInsRiderMdl> GetInsRider(MtrInsRiderMdl _MtrInsRiderMdl1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //  string _sqlString = "SELECT * FROM ProductWarrantiesProductSetup";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrInsRiderMdl> _MtrInsRiderMdlList = new List<MtrInsRiderMdl>();
                MtrInsRiderMdl _MtrInsRiderMdl;


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM InsMtrRider WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsRiderMdl1.ParentTxnSysID));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


                //  _adpSql.Fill(_tbl);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrInsRiderMdl = new MtrInsRiderMdl();

                        _MtrInsRiderMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrInsRiderMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrInsRiderMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrInsRiderMdl.RiderCode = Convert.ToInt32(_tblSqla.Rows[i]["RiderCode"]);
                        _MtrInsRiderMdl.RiderName = GlobalDataLayer.GetRiderSetUpNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["RiderCode"])) ;
                        _MtrInsRiderMdl.RiderRate = Convert.ToInt32(_tblSqla.Rows[i]["RiderRate"]);
                        _MtrInsRiderMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["ParentTxnSysID"]);




                        _MtrInsRiderMdl.IsValidTxn = true;

                        _MtrInsRiderMdlList.Add(_MtrInsRiderMdl);
                    }

                    return _MtrInsRiderMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //for adding new Ins Rider
        public MtrInsRiderMdl AddInsRider(MtrInsRiderMdl _MtrInsRiderMdl)
        {
            try
            {
                //if (IsDuplicateInsRider(_MtrInsRiderMdl) == true)
                //{
                //    List<TxnError> _txnErrors = new List<TxnError>();
                //    TxnError _txnError = new TxnError();
                //    _MtrInsRiderMdl.IsValidTxn = false;
                //    _txnError.ErrorCode = "1001";
                //    _txnError.Error = "Duplicate Transaction";
                //    _txnError.TxnSysDate = DateTime.Now;
                //    _txnErrors.Add(_txnError);



                //    //To Return model

                //    _MtrInsRiderMdl.TxnErrors = _txnErrors;
                //    return _MtrInsRiderMdl;
                //}

                //else
                //{
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("INSERT INTO InsMtrRider(");
                    //_sbSql.AppendLine("TxnSysID,");
                    //_sbSql.AppendLine("TxnSysDate,");
                    _sbSql.AppendLine("UserCode,");
                    _sbSql.AppendLine("RiderCode,");
                    _sbSql.AppendLine("RiderName,");
                    _sbSql.AppendLine("RiderRate,");
                    _sbSql.AppendLine("ParentTxnSysID)");



                    _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                    // _sbSql.AppendLine("@TxnSysID,");
                    //  _sbSql.AppendLine("@TxnSysDate,");
                    _sbSql.AppendLine("@UserCode,");
                    _sbSql.AppendLine("@RiderCode,");
                    _sbSql.AppendLine("@RiderName,");
                    _sbSql.AppendLine("@RiderRate,");
                    _sbSql.AppendLine("@ParentTxnSysID)");


                

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);
                    int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsRiderMdl.UserCode);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@RiderCode", _MtrInsRiderMdl.RiderCode);
                    _cmdSql.Parameters.AddWithValue("@RiderName", GlobalDataLayer.GetRiderSetUpNameByCode(_MtrInsRiderMdl.RiderCode));
                    _cmdSql.Parameters.AddWithValue("@RiderRate", _MtrInsRiderMdl.RiderRate);
                    _cmdSql.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsRiderMdl.ParentTxnSysID);


                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();




                    _MtrInsRiderMdl.TxnSysID = _TxnSysId;
                    _MtrInsRiderMdl.IsValidTxn = true;
                    return _MtrInsRiderMdl;

              //  }


            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //for updating existing Product Rider Setup
        public MtrInsRiderMdl UpdateInsRider(MtrInsRiderMdl _MtrInsRiderMdl)
        {
            try
            {

                _MtrInsRiderMdl.ParentTxnSysID = _MtrInsRiderMdl.ParentTxnSysID == 0 ? _MtrInsRiderMdl.ParentTxnSysID = -1 : _MtrInsRiderMdl.ParentTxnSysID;

                //if (IsDuplicateInsRider(_MtrInsRiderMdl) == false)
                //{

                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("Update  InsMtrRider SET");
                    _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
                    _sbSql.AppendLine("UserCode= @UserCode,");
                    _sbSql.AppendLine("ParentTxnSysID=@ParentTxnSysID,");
                    _sbSql.AppendLine("RiderCode=@RiderCode,");
                    _sbSql.AppendLine("RiderName=@RiderName,");
                    _sbSql.AppendLine("RiderRate=@RiderRate");

                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsRiderMdl.UserCode);


                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _MtrInsRiderMdl.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsRiderMdl.ParentTxnSysID);
                    _cmdSql.Parameters.AddWithValue("@RiderCode", _MtrInsRiderMdl.RiderCode);
                    _cmdSql.Parameters.AddWithValue("@RiderName", GlobalDataLayer.GetRiderSetUpNameByCode(_MtrInsRiderMdl.RiderCode));
                    _cmdSql.Parameters.AddWithValue("@RiderRate", _MtrInsRiderMdl.RiderRate);



                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    _MtrInsRiderMdl.IsValidTxn = true;
                    return _MtrInsRiderMdl;
                //}

                //else
                //{
                //    List<TxnError> _txnErrors = new List<TxnError>();
                //    TxnError _txnError = new TxnError();
                //    _MtrInsRiderMdl.IsValidTxn = false;
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

                //    _MtrInsRiderMdl.TxnErrors = _txnErrors;


                //    return _MtrInsRiderMdl;

                //}
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //for checking duplicate Ins Rider 
        public bool IsDuplicateInsRider(MtrInsRiderMdl _MtrInsRiderMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  InsMtrRider  WHERE UPPER(RiderName)='" + _MtrInsRiderMdl.RiderName.ToString().ToUpper() + "' AND ParentTxnSysID=" + _MtrInsRiderMdl.ParentTxnSysID + " AND TxnSysID <>" + _MtrInsRiderMdl.TxnSysID;


                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                

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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return true;
            }
        }

        //For Getting all Ins Conditions 
        public List<MtrInsConditionsMdl> GetInsConditions(MtrInsConditionsMdl _MtrInsConditionsMdl1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //  string _sqlString = "SELECT * FROM ProductWarrantiesProductSetup";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrInsConditionsMdl> _MtrInsConditionsMdlList = new List<MtrInsConditionsMdl>();
                MtrInsConditionsMdl _MtrInsConditionsMdl;


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM InsMtrConditions WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsConditionsMdl1.ParentTxnSysID));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


                //  _adpSql.Fill(_tbl);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrInsConditionsMdl = new MtrInsConditionsMdl();

                        _MtrInsConditionsMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrInsConditionsMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrInsConditionsMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrInsConditionsMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["ParentTxnSysID"]);
                        _MtrInsConditionsMdl.Condition = _tblSqla.Rows[i]["Condition"].ToString();

                        _MtrInsConditionsMdl.ConditionShText = GlobalDataLayer.GetConditionByCode(_tblSqla.Rows[i]["Condition"].ToString());



                       _MtrInsConditionsMdl.IsValidTxn = true;

                        _MtrInsConditionsMdlList.Add(_MtrInsConditionsMdl);
                    }

                    return _MtrInsConditionsMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //for adding new Ins Conditions
        public MtrInsConditionsMdl AddInsConditions(MtrInsConditionsMdl _MtrInsConditionsMdl)
        {
            try
            {

                if (IsDuplicateInsConditions(_MtrInsConditionsMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _MtrInsConditionsMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1001";
                    _txnError.Error = "Duplicate Transaction";
                    _txnError.TxnSysDate = DateTime.Now;
                    _txnErrors.Add(_txnError);


                    //To Return Model
                    _MtrInsConditionsMdl.TxnErrors = _txnErrors;
                    return _MtrInsConditionsMdl;
                }

                else
                {

                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("INSERT INTO InsMtrConditions(");
                    _sbSql.AppendLine("ParentTxnSysID,");
                    _sbSql.AppendLine("Condition)");

                    _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                    _sbSql.AppendLine("@ParentTxnSysID,");
                    _sbSql.AppendLine("@Condition)");


                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);
                    int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsConditionsMdl.UserCode);

                    _cmdSql.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsConditionsMdl.ParentTxnSysID);
                    _cmdSql.Parameters.AddWithValue("@Condition", _MtrInsConditionsMdl.Condition);

                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();

                    _MtrInsConditionsMdl.TxnSysID = _TxnSysId;
                    _MtrInsConditionsMdl.ConditionShText = GlobalDataLayer.GetConditionByCode(_MtrInsConditionsMdl.Condition);
                    _MtrInsConditionsMdl.IsValidTxn = true;
                    return _MtrInsConditionsMdl;

                }



            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //for updating existing  Ins Conditions
        public MtrInsConditionsMdl UpdateInsConditions(MtrInsConditionsMdl _MtrInsConditionsMdl)
        {
            try
            {

                _MtrInsConditionsMdl.ParentTxnSysID = _MtrInsConditionsMdl.ParentTxnSysID == 0 ? _MtrInsConditionsMdl.ParentTxnSysID = -1 : _MtrInsConditionsMdl.ParentTxnSysID;

                //if (IsDuplicateInsConditions(_MtrInsConditionsMdl) == false)
                //{
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("Update InsMtrConditions SET");
                    _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
                    _sbSql.AppendLine("UserCode=@UserCode,");
                    _sbSql.AppendLine("ParentTxnSysID=@ParentTxnSysID,");
                    _sbSql.AppendLine("Condition =@Condition ");
                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsConditionsMdl.UserCode);

                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _MtrInsConditionsMdl.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsConditionsMdl.ParentTxnSysID);
                    _cmdSql.Parameters.AddWithValue("@Condition", _MtrInsConditionsMdl.Condition);

                    _MtrInsConditionsMdl.ConditionShText = GlobalDataLayer.GetConditionByCode(_MtrInsConditionsMdl.Condition);
                    _MtrInsConditionsMdl.IsValidTxn = true;

                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    return _MtrInsConditionsMdl;
                //}

                //else
                //{
                //    List<TxnError> _txnErrors = new List<TxnError>();
                //    TxnError _txnError = new TxnError();
                //    _MtrInsConditionsMdl.IsValidTxn = false;
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
                //    _MtrInsConditionsMdl.TxnErrors = _txnErrors;

                //    return _MtrInsConditionsMdl;
                //}
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //for checking duplicate in Product Conditions SetUp
        public bool IsDuplicateInsConditions(MtrInsConditionsMdl _MtrInsConditionsMdl)

        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();

                string _sqlString = "SELECT * FROM  InsMtrConditions  WHERE UPPER(Condition)='" + _MtrInsConditionsMdl.Condition.ToString().ToUpper() + "' AND ParentTxnSysID=" + _MtrInsConditionsMdl.ParentTxnSysID + " AND TxnSysID <>" + _MtrInsConditionsMdl.TxnSysID;
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
               // List<ProductConditionsSetupMdl> _ProductConditionsSetupMdlList = new List<ProductConditionsSetupMdl>();
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return true;
            }
        }


        //For Getting all Ins Warranties 
        public List<MtrInsWarrantiesMdl> GetInsWarranties(MtrInsWarrantiesMdl _MtrInsWarrantiesMdl1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //  string _sqlString = "SELECT * FROM ProductWarrantiesProductSetup";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrInsWarrantiesMdl> _MtrInsWarrantiesMdlList = new List<MtrInsWarrantiesMdl>();
                MtrInsWarrantiesMdl _MtrInsWarrantiesMdl;


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM InsMtrWarranties WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@ParentTxnSysID", _MtrInsWarrantiesMdl1.ParentTxnSysID));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


                //  _adpSql.Fill(_tbl);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrInsWarrantiesMdl = new MtrInsWarrantiesMdl();

                        _MtrInsWarrantiesMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrInsWarrantiesMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrInsWarrantiesMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrInsWarrantiesMdl.Warranty = _tblSqla.Rows[i]["Warranty"].ToString();
                        _MtrInsWarrantiesMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["ParentTxnSysID"]);

                        _MtrInsWarrantiesMdl.WarrantyShText = GlobalDataLayer.GetWarrantyTextByCode(_tblSqla.Rows[i]["Warranty"].ToString());




                        _MtrInsWarrantiesMdl.IsValidTxn = true;

                        _MtrInsWarrantiesMdlList.Add(_MtrInsWarrantiesMdl);
                    }

                    return _MtrInsWarrantiesMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //for adding new Ins Warranties
        public MtrInsWarrantiesMdl AddInsWarranties(MtrInsWarrantiesMdl _MtrInsWarrantiesMdl)
        {
            try
            {
                if (IsDuplicateInsWarranties(_MtrInsWarrantiesMdl) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _MtrInsWarrantiesMdl.IsValidTxn = false;
                    _txnError.ErrorCode = "1001";
                    _txnError.Error = "Duplicate Transaction";
                    _txnError.TxnSysDate = DateTime.Now;
                    _txnErrors.Add(_txnError);


                    //To Return model

                    _MtrInsWarrantiesMdl.TxnErrors = _txnErrors;
                    return _MtrInsWarrantiesMdl;
                }

                else
                {
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("INSERT INTO InsMtrWarranties(");
                    _sbSql.AppendLine("ParentTxnSysID,");
                    _sbSql.AppendLine("Warranty)");
                    _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                    _sbSql.AppendLine("@ParentTxnSysID,");
                    _sbSql.AppendLine("@Warranty)");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);
                    int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsWarrantiesMdl.UserCode);

                    _cmdSql.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsWarrantiesMdl.ParentTxnSysID);
                    _cmdSql.Parameters.AddWithValue("@Warranty", _MtrInsWarrantiesMdl.Warranty);

                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();


                    _MtrInsWarrantiesMdl.WarrantyShText = GlobalDataLayer.GetWarrantyTextByCode(_MtrInsWarrantiesMdl.Warranty.ToString());

                    _MtrInsWarrantiesMdl.TxnSysID = _TxnSysId;
                    _MtrInsWarrantiesMdl.IsValidTxn = true;
                    return _MtrInsWarrantiesMdl;

                }


            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //for updating existing Ins Warranties
        public MtrInsWarrantiesMdl UpdateInsWarranties(MtrInsWarrantiesMdl _MtrInsWarrantiesMdl)
        {
            try
            {

                _MtrInsWarrantiesMdl.ParentTxnSysID = _MtrInsWarrantiesMdl.ParentTxnSysID == 0 ? _MtrInsWarrantiesMdl.ParentTxnSysID = -1 : _MtrInsWarrantiesMdl.ParentTxnSysID;

                //if (IsDuplicateInsWarranties(_MtrInsWarrantiesMdl) == false)
                //{

                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("Update  InsMtrWarranties SET");
                    _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
                    _sbSql.AppendLine("UserCode= @UserCode,");
                    _sbSql.AppendLine("ParentTxnSysID=@ParentTxnSysID,");
                    _sbSql.AppendLine("Warranty=@Warranty");
                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsWarrantiesMdl.UserCode);


                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _MtrInsWarrantiesMdl.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsWarrantiesMdl.ParentTxnSysID);
                    _cmdSql.Parameters.AddWithValue("@Warranty", _MtrInsWarrantiesMdl.Warranty);



                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    _MtrInsWarrantiesMdl.IsValidTxn = true;
                    _MtrInsWarrantiesMdl.WarrantyShText = GlobalDataLayer.GetWarrantyTextByCode(_MtrInsWarrantiesMdl.Warranty);
                    return _MtrInsWarrantiesMdl;
                //}

                //else
                //{
                //    List<TxnError> _txnErrors = new List<TxnError>();
                //    TxnError _txnError = new TxnError();
                //    _MtrInsWarrantiesMdl.IsValidTxn = false;
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

                //    _MtrInsWarrantiesMdl.TxnErrors = _txnErrors;


                //    return _MtrInsWarrantiesMdl;

                //}
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return null;
            }
        }

        //for checking duplicate  Product Warranties Setup
        public bool IsDuplicateInsWarranties(MtrInsWarrantiesMdl _MtrInsWarrantiesMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT * FROM  InsMtrWarranties  WHERE UPPER(Warranty)='" + _MtrInsWarrantiesMdl.Warranty.ToString().ToUpper() + "' AND ParentTxnSysID=" + _MtrInsWarrantiesMdl.ParentTxnSysID + " AND TxnSysID <>" + _MtrInsWarrantiesMdl.TxnSysID;


                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<ProductWarrantiesSetupMdl> _ProductWarrantiesSetupMdlList = new List<ProductWarrantiesSetupMdl>();
              //  ProductWarrantiesSetupMdl _ProductWarrantiesSetupMdl;
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "InsPolicy DataLayer");
                return true;
            }
        }


        //---------------- For Tracker , Rider , Conditons And Warranties ------------------- //


    }
}