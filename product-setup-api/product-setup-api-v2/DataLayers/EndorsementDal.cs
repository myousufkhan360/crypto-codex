using ProductSetupApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static ProductSetupApi.Models.InsPolicyMdl;
using static ProductSetupApi.Models.MtrEndorsementMdl;
using static ProductSetupApi.Models.MtrVehicleDetailMdl;


namespace ProductSetupApi.DataLayers
{
    public class EndorsementDal
    {

        //Checking that the Vehicle Certificate is Expired
        public Boolean Expiry(VehicleDetailMdl _VehicleDetailMdl)
            {
                try
                {
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();


                    string _sqlString = "SELECT *, ip.ExpiryDate FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND TxnSysID = "+_VehicleDetailMdl.TxnSysID;


                    SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                    DataTable _tbl = new DataTable();
                    List<VehicleDetailMdl> _MtrOpenPolicyMdlList = new List<VehicleDetailMdl>();

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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsemnet DataLayer");
                return true;
                }



            }

        //Checking that the Vehicle Certificate is Canceled or Deleted
        public Boolean ISCanceled(VehicleDetailMdl _VehicleDetailMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();


                string _sqlString = "SELECT mvd.IsCanceled FROM MtrVehicleDetails mvd WHERE mvd.TxnSysID =  " + _VehicleDetailMdl.TxnSysID;


                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<VehicleDetailMdl> _MtrOpenPolicyMdlList = new List<VehicleDetailMdl>();

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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return true;
            }



        }

        //Get All Ins Endorsement (Endorsement Header)
        public List<InsEndorsementMdl> GetMtrEndorsementMdl()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM InsEndorsement";
                //+ " WHERE  FORMAT(TxnSysDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + 
                // "AND FORMAT(EffectiveDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + "AND FORMAT(ExpiryDate, 'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(), 'yyyy-MM-dd'))";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<InsEndorsementMdl> _MtrEndorsementMdlList = new List<InsEndorsementMdl>();
                InsEndorsementMdl _MtrEndorsementMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrEndorsementMdl = new InsEndorsementMdl();

                        _MtrEndorsementMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrEndorsementMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrEndorsementMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrEndorsementMdl.EndMonth = _tblSqla.Rows[i]["EndMonth"].ToString();
                        _MtrEndorsementMdl.EndString = _tblSqla.Rows[i]["EndString"].ToString();
                        _MtrEndorsementMdl.EndYear = _tblSqla.Rows[i]["EndYear"].ToString();
                        _MtrEndorsementMdl.EndNo = _tblSqla.Rows[i]["EndNo"].ToString();
                        _MtrEndorsementMdl.DocType = _tblSqla.Rows[i]["DocType"].ToString();
                        _MtrEndorsementMdl.GenerateAgainst = _tblSqla.Rows[i]["GenerateAgainst"].ToString();
                        _MtrEndorsementMdl.ProductCode = _tblSqla.Rows[i]["ProductCode"].ToString();
                        _MtrEndorsementMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();
                        _MtrEndorsementMdl.ClientCode = _tblSqla.Rows[i]["ClientCode"].ToString();
                        _MtrEndorsementMdl.AgencyCode = _tblSqla.Rows[i]["AgencyCode"].ToString();
                        _MtrEndorsementMdl.CertInsureCode = _tblSqla.Rows[i]["CertInsureCode"].ToString();
                        _MtrEndorsementMdl.Remarks = _tblSqla.Rows[i]["Remarks"].ToString();
                        _MtrEndorsementMdl.BrchCoverNoteNo = _tblSqla.Rows[i]["BrchCoverNoteNo"].ToString();
                       
                        _MtrEndorsementMdl.LeaderPolicyNo = _tblSqla.Rows[i]["LeaderPolicyNo"].ToString();
                        _MtrEndorsementMdl.LeaderEndNo = _tblSqla.Rows[i]["LeaderEndNo"].ToString();
                        _MtrEndorsementMdl.IsFiler = _tblSqla.Rows[i]["IsFiler"].ToString();
                        _MtrEndorsementMdl.CalcType = _tblSqla.Rows[i]["CalcType"].ToString();
                        _MtrEndorsementMdl.IsAuto = _tblSqla.Rows[i]["IsAuto"].ToString();
                        _MtrEndorsementMdl.EffectiveDate = Convert.ToDateTime(_tblSqla.Rows[i]["EffectiveDate"]);
                        _MtrEndorsementMdl.ExpiryDate = Convert.ToDateTime(_tblSqla.Rows[i]["ExpiryDate"]);
                        _MtrEndorsementMdl.SerialNo = Convert.ToInt32(_tblSqla.Rows[i]["SerialNo"]);
                        _MtrEndorsementMdl.UWYear = _tblSqla.Rows[i]["UWYear"].ToString();
                        _MtrEndorsementMdl.CreatedBy = _tblSqla.Rows[i]["CreatedBy"].ToString();
                        _MtrEndorsementMdl.PostedBy = _tblSqla.Rows[i]["PostedBy"].ToString();
                        _MtrEndorsementMdl.IsPosted = Convert.ToBoolean(_tblSqla.Rows[i]["IsPosted"]);
                        _MtrEndorsementMdl.PostDate = Convert.ToDateTime(_tblSqla.Rows[i]["PostDate"]);
                        _MtrEndorsementMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["OpolTxnSysID"]);
                        _MtrEndorsementMdl.RenewSysID = Convert.ToInt32(_tblSqla.Rows[i]["RenewSysID"]);
                        _MtrEndorsementMdl.PolSysID = Convert.ToInt32(_tblSqla.Rows[i]["PolSysID"]);
                        _MtrEndorsementMdl.IsRenewal = Convert.ToBoolean(_tblSqla.Rows[i]["IsRenewal"]);


                        _MtrEndorsementMdl.IsValidTxn = true;


                        _MtrEndorsementMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(_tblSqla.Rows[i]["ProductCode"].ToString());
                        _MtrEndorsementMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_tblSqla.Rows[i]["PolicyTypeCode"].ToString());
                        _MtrEndorsementMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_tblSqla.Rows[i]["ClientCode"].ToString());
                        _MtrEndorsementMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_tblSqla.Rows[i]["AgencyCode"].ToString());
                        _MtrEndorsementMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_tblSqla.Rows[i]["CertInsureCode"].ToString());

                        _MtrEndorsementMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(_tblSqla.Rows[i]["DocType"].ToString());
                        _MtrEndorsementMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_tblSqla.Rows[i]["IsFiler"].ToString());
                        _MtrEndorsementMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_tblSqla.Rows[i]["CalcType"].ToString());
                        _MtrEndorsementMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_tblSqla.Rows[i]["IsAuto"].ToString());

                        string EndorDoc = "5";
                        _MtrEndorsementMdl.DocType = EndorDoc;
                        _MtrEndorsementMdl.IsValidTxn = true;

                        _MtrEndorsementMdlList.Add(_MtrEndorsementMdl);


                    }

                    return _MtrEndorsementMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return null;
            }
        }

        //Increment Serial Number
        public static int GetSerialNo(MtrEndorsementMdl _MtrEndorsementMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(SerialNo) LastSerialNo FROM InsEndorsement";
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
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return 0;
            }

        }

        //Get All Search By
        public List<MtrSeByCertMdl> GetMtrSeByCert()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrSeByCert";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrSeByCertMdl> _MtrSeByCertMdlList = new List<MtrSeByCertMdl>();
                MtrSeByCertMdl _MtrSeByCertMdl;


                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrSeByCertMdl = new MtrSeByCertMdl();

                        _MtrSeByCertMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrSeByCertMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrSeByCertMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrSeByCertMdl.SeByCertCode = Convert.ToInt32(_tblSqla.Rows[i]["SeByCertCode"]);
                        _MtrSeByCertMdl.SeByCertName = _tblSqla.Rows[i]["SeByCertName"].ToString();


                        _MtrSeByCertMdlList.Add(_MtrSeByCertMdl);
                    }

                    return _MtrSeByCertMdlList;
                }
                else
                {

                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return null;
            }
        }

        //Get Vehicle Certificate by Chasis Number, Participant Name , Registration Number , Engine Number , Policy Number
        public List<VehicleDetailMdl> GetVehicleDetail1(VehicleDetailMdl _VehicleDetailMdl1, MtrInsPolicyMdl _MtrInsPolicyMdl, MtrSeByCertMdl _MtrSeByCertMdl)
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
                            new SqlCommand("SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE ip.DocType IN (7,4,5) AND ip.IsActive <> 0 AND  ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND mvd.ChasisNumber = @ChasisNumber", conn);

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
                            new SqlCommand("SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE ip.DocType IN (7,4,5) AND ip.IsActive <> 0 AND ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND mvd.RegistrationNumber = @RegistrationNumber", conn);


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
                            new SqlCommand("SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE ip.DocType IN (7,4,5) AND ip.IsActive <> 0 AND ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND mvd.VehicleModel = @ModelNumber ", conn);


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
                            new SqlCommand("SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE  ip.DocType IN (7,4,5) AND ip.IsActive <> 0 AND ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND UPPER(mvd.ParticipantName)  like '%'+UPPER('" + _VehicleDetailMdl1.ParticipantName + "')+'%'", conn);


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

                        string str = "SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE  ip.DocType IN(7,4,5) AND ip.IsActive <> 0 AND ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND ip.DocString LIKE '%" + _MtrInsPolicyMdl.ParentTxnSysID + "%'";

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
                            _VehicleDetailMdl.Mileage = Convert.ToInt32(_tblSqla.Rows[i]["Mileage"].ToString()) ;
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
                            _VehicleDetailMdl.BrchCode = _tblSqla.Rows[i]["BrchCode"].ToString() ?? DBNull.Value.ToString();
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


                        //Get Rating Factor by Rate and Product Code
                        _VehicleDetailMdl.RatingFactor = _tblSqla.Rows[i]["RatingFactor"].ToString();
                        _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_tblSqla.Rows[i]["RatingFactor"].ToString());


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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return null;
            }
        }


        //Get Vehicle Certificate by Chasis Number, Participant Name , Registration Number , Engine Number , Policy Number For OpenPolicy
        public List<VehicleDetailMdl> GetVehicleDetailForOpol(VehicleDetailMdl _VehicleDetailMdl1, MtrInsPolicyMdl _MtrInsPolicyMdl, MtrSeByCertMdl _MtrSeByCertMdl)
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
                            new SqlCommand("SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE mvd.OpolTxnSysID <> -1 AND ip.DocType IN (7,4,5) AND ip.IsActive <> 0 AND  ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND mvd.ChasisNumber = @ChasisNumber", conn);

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
                            new SqlCommand("SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE mvd.OpolTxnSysID <> -1 AND ip.DocType IN (7,4,5) AND ip.IsActive <> 0 AND ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND mvd.RegistrationNumber = @RegistrationNumber", conn);


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
                            new SqlCommand("SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE mvd.OpolTxnSysID <> -1 AND ip.DocType IN (7,4,5) AND ip.IsActive <> 0 AND ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND mvd.VehicleModel = @ModelNumber ", conn);


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
                        string str = "SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE mvd.OpolTxnSysID <> -1 AND  ip.DocType IN (7,4,5) AND ip.IsActive <> 0 AND ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND UPPER(mvd.ParticipantName)  like '%'+UPPER('" + _VehicleDetailMdl1.ParticipantName + "')+'%'";

                        SqlCommand command =
                            new SqlCommand(str, conn);


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

                        string str = "SELECT mvd.*, ip.ExpiryDate,ip.*,ic.* FROM MtrVehicleDetails mvd  INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN InsContribution ic ON mvd.TxnSysID = ic.RiskTxnID WHERE mvd.OpolTxnSysID <> -1 AND ip.DocType IN(7,4,5) AND ip.IsActive <> 0 AND ip.ExpiryDate > '" + DateTime.Now.ToString() + "' AND ip.DocString LIKE '%" + _MtrInsPolicyMdl.ParentTxnSysID + "%'";

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
                        _VehicleDetailMdl.BrchCode = _tblSqla.Rows[i]["BrchCode"].ToString() ?? DBNull.Value.ToString();
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


                        //Get Rating Factor by Rate and Product Code
                        _VehicleDetailMdl.RatingFactor = _tblSqla.Rows[i]["RatingFactor"].ToString();
                        _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_tblSqla.Rows[i]["RatingFactor"].ToString());


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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return null;
            }
        }


        //Get Vehicle Detail to check for expiry
        public VehicleDetailMdl GetVehicleDetailsExp(VehicleDetailMdl _VehicleDetailMdl1)
        {
            if (Expiry(_VehicleDetailMdl1) == true && ISCanceled(_VehicleDetailMdl1) == true)
            {
                List<TxnError> _txnErrors = new List<TxnError>();
                TxnError _txnError = new TxnError();
                _VehicleDetailMdl1.IsValidTxn = false;
                _txnError.ErrorCode = "1004";
                _txnError.Error = "Certificate has been Expired or Cancelled";
                _txnError.TxnSysDate = DateTime.Now;

                _txnErrors.Add(_txnError);
                _txnErrors.Add(_txnError);

                //    //To Return model
                _VehicleDetailMdl1.TxnErrors = _txnErrors;


                //    //_MtrOpenPolicyMdl.ProductName = GetProductNameByProductCode(_MtrOpenPolicyMdl.ProductCode.ToString());
                //    //_MtrOpenPolicyMdl.PolicyTypeName = GetPolicyTypeNameByPolicyTypeCode(_MtrOpenPolicyMdl.PolicyTypeCode.ToString());
                //    //_MtrOpenPolicyMdl.ClientName = GetClientNameByClientCode(_MtrOpenPolicyMdl.ClientCode.ToString());
                //    //_MtrOpenPolicyMdl.AgentName = GetAgentNameByAgentCode(_MtrOpenPolicyMdl.AgencyCode.ToString());
                //    //_MtrOpenPolicyMdl.CertInsureName = GetCertInsNameByCertInsCode(_MtrOpenPolicyMdl.CertInsureCode.ToString());

                //    //_MtrOpenPolicyMdl.DocTypeName = GetDocTypeNameByDocTypeCode(_MtrOpenPolicyMdl.DocType.ToString());
                //    //_MtrOpenPolicyMdl.IsFilerName = GetIsFilerNameByIsFilerCode(_MtrOpenPolicyMdl.IsFiler.ToString());
                //    //_MtrOpenPolicyMdl.CalcName = GetCalcNameByCalcCode(_MtrOpenPolicyMdl.CalcType.ToString());
                //    //_MtrOpenPolicyMdl.IsAutoName = GetIsAutoNameByIsAutoCode(_MtrOpenPolicyMdl.IsAuto.ToString());

                //    //string PolicyString = GetPolicyString(_MtrOpenPolicyMdl.PolicyNo.ToString(), _MtrOpenPolicyMdl.PolicyMonth.ToString(), _MtrOpenPolicyMdl.PolicyYear.ToString());
                //    //_MtrOpenPolicyMdl.PolicyString = PolicyString;

                _VehicleDetailMdl1.TxnSysDate = DateTime.Now;

                return _VehicleDetailMdl1;
            }
            else
            {

                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrVehicleDetails Where TxnSysID= " + _VehicleDetailMdl1.TxnSysID;
                //+ " WHERE  FORMAT(TxnSysDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + 
                // "AND FORMAT(EffectiveDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + "AND FORMAT(ExpiryDate, 'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(), 'yyyy-MM-dd'))";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<VehicleDetailMdl> _VehicleDetailMdlList = new List<VehicleDetailMdl>();
                VehicleDetailMdl _VehicleDetailMdl = new VehicleDetailMdl();

                _adpSql.Fill(_tblSqla);

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
                        _VehicleDetailMdl.ColorCode = Convert.ToInt32(_tblSqla.Rows[i]["ColorCode"].ToString());
                        _VehicleDetailMdl.ParticipantName = _tblSqla.Rows[i]["ParticipantName"].ToString();
                        _VehicleDetailMdl.ParticipantAddress = _tblSqla.Rows[i]["ParticipantAddress"].ToString();
                        //_VehicleDetailMdl.ModelNumber = Convert.ToInt32(_tblSqla.Rows[i]["ModelNumber"]);
                        _VehicleDetailMdl.RegistrationNumber = _tblSqla.Rows[i]["RegistrationNumber"].ToString();
                        _VehicleDetailMdl.CityCode = _tblSqla.Rows[i]["CityCode"].ToString();
                        _VehicleDetailMdl.EngineNumber = _tblSqla.Rows[i]["EngineNumber"].ToString();
                        _VehicleDetailMdl.AreaCode = Convert.ToInt32(_tblSqla.Rows[i]["AreaCode"].ToString());
                        _VehicleDetailMdl.ChasisNumber = _tblSqla.Rows[i]["ChasisNumber"].ToString();
                        _VehicleDetailMdl.Remarks = _tblSqla.Rows[i]["Remarks"].ToString();
                        _VehicleDetailMdl.PODate = Convert.ToDateTime(_tblSqla.Rows[i]["PODate"]);
                        _VehicleDetailMdl.PONumber = (_tblSqla.Rows[i]["PONumber"].ToString());
                        _VehicleDetailMdl.CNICNumber = _tblSqla.Rows[i]["CNICNumber"].ToString();
                        _VehicleDetailMdl.Tenure = _tblSqla.Rows[i]["Tenure"].ToString();
                        _VehicleDetailMdl.BirthDate = Convert.ToDateTime(_tblSqla.Rows[i]["BirthDate"]);
                        _VehicleDetailMdl.Gender = _tblSqla.Rows[i]["Gender"].ToString();
                        _VehicleDetailMdl.VehicleType = _tblSqla.Rows[i]["VehicleType"].ToString();
                        _VehicleDetailMdl.VEODCode = Convert.ToInt32(_tblSqla.Rows[i]["VEODCode"]);
                        _VehicleDetailMdl.CertTypeCode = _tblSqla.Rows[i]["CertTypeCode"].ToString();
                        _VehicleDetailMdl.Rate = Convert.ToInt32(_tblSqla.Rows[i]["Rate"]);
                        _VehicleDetailMdl.Contribution = Convert.ToInt32(_tblSqla.Rows[i]["Contribution"]);

                        _VehicleDetailMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["ParentTxnSysID"]);
                        _VehicleDetailMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["OpolTxnSysID"]);

                       

                        _VehicleDetailMdl.InsuranceTypeCode = Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]);
                        _VehicleDetailMdl.IsActive = Convert.ToBoolean(_tblSqla.Rows[i]["IsActive"]);
                        _VehicleDetailMdl.IsCanceled = Convert.ToBoolean(_tblSqla.Rows[i]["IsCanceled"]);
                        _VehicleDetailMdl.CommisionRate = Convert.ToDecimal(_tblSqla.Rows[i]["CommisionRate"]);
                        _VehicleDetailMdl.MobileNumber = _tblSqla.Rows[i]["MobileNumber"].ToString();
                        _VehicleDetailMdl.ResNumber = _tblSqla.Rows[i]["ResNumber"].ToString();
                        _VehicleDetailMdl.OfficeNumber = _tblSqla.Rows[i]["OfficeNumber"].ToString();

                        _VehicleDetailMdl.EmailAddress = _tblSqla.Rows[i]["EmailAddress"].ToString();
                        _VehicleDetailMdl.Deductible = Convert.ToDecimal(_tblSqla.Rows[i]["Deductible"]);

                        _VehicleDetailMdl.ContractMatDate = Convert.ToDateTime(_tblSqla.Rows[i]["ContractMatDate"]);

                        _VehicleDetailMdl.VEODName = GlobalDataLayer.GetVEODNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["VEODCode"]));
                        _VehicleDetailMdl.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_tblSqla.Rows[i]["VehicleType"].ToString());

                       // _VehicleDetailMdl.InsuranceTypeCode = Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]);



                        _VehicleDetailMdl.GenderName = GlobalDataLayer.GetGenderNameByCode(_tblSqla.Rows[i]["Gender"].ToString());
                        _VehicleDetailMdl.CityName = GlobalDataLayer.GetCityNameByCode(_tblSqla.Rows[i]["CityCode"].ToString());
                        _VehicleDetailMdl.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["ColorCode"].ToString()));
                        _VehicleDetailMdl.VehicleName = GlobalDataLayer.GetVehicleNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["VehicleCode"].ToString()));
                        _VehicleDetailMdl.AreaName = GlobalDataLayer.GetAreaNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["AreaCode"].ToString()));
                        _VehicleDetailMdl.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_tblSqla.Rows[i]["CertTypeCode"].ToString());
                        //_VehicleDetailMdl.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]));



                        _VehicleDetailMdl.total = GlobalDataLayer.calculate(_VehicleDetailMdl);


                        _VehicleDetailMdlList.Add(_VehicleDetailMdl);


                    }


                    return _VehicleDetailMdl;
                }

                else
                {
                    return null;
                }
            }
        }


        //--------- Important --------------//


        //---------------- Financial Endorsement ---------------------//

        //To claculate only the values to be entered after endorsement
        public List<Calculate> CalculateNew(VehicleDetailMdl _VehicleDetailMdl1, EndtReasonMdl _EndtReasonMdl1)
        {
            decimal newSumCovered = _VehicleDetailMdl1.ParticipantValue;

            decimal stamp = 0;
            int days = 0;
            decimal FEDU = 0;

            SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
            //Get all IDs For insertion in database
            string _sqlString = "SELECT mvd.TxnSysID,mvd.ParentTxnSysID InsPolicyID,ic.TxnSysID ConTxnID FROM MtrVehicleDetails mvd INNER JOIN InsPolicy ip ON mvd.ParentTxnSysID = ip.ParentTxnSysID INNER JOIN InsContribution ic ON ic.RiskTxnID = mvd.TxnSysID WHERE mvd.TxnSysID =" + _VehicleDetailMdl1.TxnSysID;
            DataTable _tblSqla = new DataTable();
            List<VehicleDetailMdl> _VehicleDetailMdlList = new List<VehicleDetailMdl>();
            VehicleDetailMdl _VehicleDetailMdl = new VehicleDetailMdl();
            VehicleDetailMdl _VehicleDetailMdl0 = new VehicleDetailMdl();
            SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
            MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
            MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

            List<Calculate> _CalculateList = new List<Calculate>();
            Calculate _Calculate = new Calculate();

            int VehicleTxnID = 0, InsPolicyTxnID = 0, ConTxnID = 0;
            decimal diff = 0;

            _adpSql.Fill(_tblSqla);

            if (_tblSqla.Rows.Count > 0)
            {
                for (int i = 0; i < _tblSqla.Rows.Count; i++)
                {
                    _VehicleDetailMdl0 = new VehicleDetailMdl();

                    _VehicleDetailMdl0.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                    VehicleTxnID = _VehicleDetailMdl0.TxnSysID;
                    _VehicleDetailMdl0.InsPolicyID = Convert.ToInt32(_tblSqla.Rows[i]["InsPolicyID"]);
                    InsPolicyTxnID = _VehicleDetailMdl0.InsPolicyID;
                    _VehicleDetailMdl0.ConTxnID = Convert.ToInt32(_tblSqla.Rows[i]["ConTxnID"]);
                    ConTxnID = _VehicleDetailMdl0.ConTxnID;
                }


            }
            else
            {

             

            }

           
            //Get Values From MtrVehicle Detail by TxnID
            SqlConnection _conSql3 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
            string _sqlString3 = "SELECT * FROM MtrVehicleDetails mvd WHERE mvd.TxnSysID =  " + _VehicleDetailMdl1.TxnSysID;

            SqlDataAdapter _adpSql3 = new SqlDataAdapter(_sqlString3, _conSql3);
            DataTable _tblSqla3 = new DataTable();


            _adpSql3.Fill(_tblSqla3);

            if (_tblSqla3.Rows.Count > 0)
            {
                for (int i = 0; i < _tblSqla3.Rows.Count; i++)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();                   
                    //_VehicleDetailMdl.UpdatedValue = Convert.ToDecimal(_tblSqla3.Rows[i]["UpdatedValue"]);
                    //_VehicleDetailMdl.PreviousValue = Convert.ToDecimal(_tblSqla3.Rows[i]["PreviousValue"]);                   
                   _VehicleDetailMdl.ParticipantValue = Convert.ToDecimal(_tblSqla3.Rows[i]["ParticipantValue"]);                  
                   _VehicleDetailMdl.Tenure = _tblSqla3.Rows[i]["Tenure"].ToString();                  
                   _VehicleDetailMdl.Rate = Convert.ToDecimal(_tblSqla3.Rows[i]["Rate"]);
                  // _VehicleDetailMdl.Contribution = Convert.ToInt32(_tblSqla3.Rows[i]["Contribution"]);                                    
                   _VehicleDetailMdl.CommisionRate = Convert.ToDecimal(_tblSqla3.Rows[i]["CommisionRate"]);;
                    //_VehicleDetailMdlList.Add(_VehicleDetailMdl);


                }
            }

            //Get values From InsContribution
            SqlConnection _conSql5 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
            DataTable _tblSqla5 = new DataTable();
            // MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
            List<MtrVContributionMdl> _MtrVContributionMdlList = new List<MtrVContributionMdl>();

            //string _sqlString5 = "SELECT *  FROM InsContribution Where  TxnSysID  =  " + ConTxnID;

            //SqlDataAdapter _adpSql5 = new SqlDataAdapter(_sqlString3, _conSql3);
            //DataTable _tblSqla5 = new DataTable();


            //_adpSql5.Fill(_tblSqla5);


            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
            {
                SqlCommand command =
                    new SqlCommand("SELECT *  FROM InsContribution Where  TxnSysID = @TxnSysID", conn);

                command.Parameters.Add(new SqlParameter("@TxnSysID", ConTxnID));

                SqlDataAdapter _adpSql5 = new SqlDataAdapter(command);


                _adpSql5.Fill(_tblSqla5);
            }



            if (_tblSqla5.Rows.Count > 0)
            {
                _MtrVContributionMdl = new MtrVContributionMdl();
                for (int i = 0; i < _tblSqla5.Rows.Count; i++)
                {

                   
                    _MtrVContributionMdl.SumCovered = Convert.ToInt32(_tblSqla5.Rows[i]["SumCovered"]);
                    _MtrVContributionMdl.Rate = Convert.ToDecimal(_tblSqla5.Rows[i]["Rate"]);
                    _MtrVContributionMdl.NetContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["NetContribution"]);
                    _MtrVContributionMdl.GrossContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["GrossContribution"]);
                    _MtrVContributionMdl.FIF = Convert.ToDecimal(_tblSqla5.Rows[i]["FIF"]);
                    _MtrVContributionMdl.FED = Convert.ToDecimal(_tblSqla5.Rows[i]["FED"]);
                    _MtrVContributionMdl.Stamp = Convert.ToDecimal(_tblSqla5.Rows[i]["Stamp"]);
                    stamp = _MtrVContributionMdl.Stamp;
                    _MtrVContributionMdl.BasicContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["BasicContribution"]);
                    _MtrVContributionMdl.PEV = Convert.ToDecimal(_tblSqla5.Rows[i]["PEV"]);
                    _MtrVContributionMdl.BeforePEV = Convert.ToDecimal(_tblSqla5.Rows[i]["BeforePEV"]);
                    _MtrVContributionMdl.TerrorContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["TerrorContribution"]);        
                    _MtrVContributionMdl.PerDayContribution = Convert.ToInt32(_tblSqla5.Rows[i]["PerDayContribution"]);
                   


                }


            }


            else
            {

                

            }

            //To increase Rate
            decimal _Rate;
            if (_EndtReasonMdl1.EndtReasonCode == 1)
            {
                _Rate = _VehicleDetailMdl1.Rate;


                decimal _SumCovered = _VehicleDetailMdl.ParticipantValue;
                decimal _RateV = _VehicleDetailMdl1.Rate;




                decimal NetContribution = (_SumCovered * (_RateV / 100));
                decimal GrossContribution = (NetContribution - _MtrVContributionMdl.Stamp) / (((_MtrVContributionMdl.FED + _MtrVContributionMdl.FIF) / 100) + 1);



                decimal BeforePEV = (GrossContribution - _MtrVContributionMdl.TerrorContribution);
                decimal PEV = (BeforePEV - _MtrVContributionMdl.BasicContribution);


                //To get Tenure
                DataTable _tbl8 = new DataTable();
                //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = " + InsPolicyTxnID, conn);



                    SqlDataAdapter _adpSql8 = new SqlDataAdapter(command);


                    _adpSql8.Fill(_tbl8);
                }

                // _adpSql.Fill(_tbl);

                if (_tbl8.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl8.Rows.Count; i++)
                    {
                        _MtrVContributionMdl1 = new MtrVContributionMdl();
                        _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl8.Rows[i]["tenure"]);

                    }


                }
                else
                {
                    _MtrVContributionMdl1.Tenure = 365;
                }


                decimal PerDayContribution = GrossContribution / _MtrVContributionMdl1.Tenure;
                //Difference of added value and previous value
                diff = NetContribution - _SumCovered;


                //Previous

                _Calculate.BasicContributionP = Decimal.Round(_MtrVContributionMdl.BasicContribution,  MidpointRounding.ToEven);
                //  _Calculate.BasicContributionP = _MtrVContributionMdl.BasicContribution;
                _Calculate.BeforePEVP = Decimal.Round(_MtrVContributionMdl.BeforePEV,  MidpointRounding.ToEven);
                //_Calculate.BeforePEVP = _MtrVContributionMdl.BeforePEV;               
                _Calculate.FEDP = _MtrVContributionMdl.FED;
                _Calculate.FIFP = _MtrVContributionMdl.FIF;
                _Calculate.GrossContributionP = Decimal.Round(_MtrVContributionMdl.GrossContribution,  MidpointRounding.ToEven);
               // _Calculate.GrossContributionP = _MtrVContributionMdl.GrossContribution;
               // _Calculate.NetContributionP = _MtrVContributionMdl.NetContribution;
                _Calculate.NetContributionP = Decimal.Round(_MtrVContributionMdl.NetContribution,  MidpointRounding.ToEven);
                _Calculate.PerDayContributionP = _MtrVContributionMdl.PerDayContribution;
                _Calculate.PEVP = _MtrVContributionMdl.PEV;
                _Calculate.RateP = _VehicleDetailMdl.Rate;
                _Calculate.StampP = _MtrVContributionMdl.Stamp;

                _Calculate.SumCoveredP = Decimal.Round(_MtrVContributionMdl.SumCovered,  MidpointRounding.ToEven);
               // _Calculate.SumCoveredP = _MtrVContributionMdl.SumCovered;
                _Calculate.TenureP = _MtrVContributionMdl.Tenure;
                _Calculate.TerrorContributionP = _MtrVContributionMdl.TerrorContribution;
                _Calculate.PreviousMsg = "Previous Contribution";


                //Updated
                _Calculate.BasicContributionU = _MtrVContributionMdl.BasicContribution;
                _Calculate.BeforePEVU = Decimal.Round(BeforePEV,  MidpointRounding.ToEven);
                //_Calculate.BeforePEVU = BeforePEV;
                _Calculate.differenceU = diff;
                _Calculate.FEDU = _MtrVContributionMdl.FED;
                _Calculate.FIFU = _MtrVContributionMdl.FIF;
                _Calculate.GrossContributionU = Decimal.Round(GrossContribution,  MidpointRounding.ToEven);
                //_Calculate.GrossContributionU = GrossContribution;
                //_Calculate.NetContributionU = NetContribution;
                _Calculate.NetContributionU = Decimal.Round(NetContribution,  MidpointRounding.ToEven);
                _Calculate.PerDayContributionU = PerDayContribution;
                _Calculate.PEVU = PEV;
                _Calculate.RateU = _RateV;
                _Calculate.StampU = _MtrVContributionMdl.Stamp;
                _Calculate.SumCoveredU = Decimal.Round(_SumCovered,  MidpointRounding.ToEven);
               // _Calculate.SumCoveredU = _SumCovered;
                _Calculate.TenureU = _MtrVContributionMdl1.Tenure;
                _Calculate.TerrorContributionU = _MtrVContributionMdl.TerrorContribution;
                _Calculate.UpdatedMsg = "Updated Contribution";

                //Variance
                decimal _SumCovered1 = diff;
                decimal _RateV1 = _VehicleDetailMdl1.Rate;
                decimal NetContribution1 = (_SumCovered1 * (_RateV1 / 100));
                decimal GrossContribution1 = (NetContribution1 - _MtrVContributionMdl.Stamp) / ((_MtrVContributionMdl.FED + _MtrVContributionMdl.FIF / 100) + 1);
                decimal BeforePEV1 = (GrossContribution1 - _MtrVContributionMdl.TerrorContribution);
                decimal PEV1 = (BeforePEV1 - _MtrVContributionMdl.BasicContribution);


                //To get Tenure
                DataTable _tbl10 = new DataTable();
                //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = " + InsPolicyTxnID, conn);



                    SqlDataAdapter _adpSql10 = new SqlDataAdapter(command);


                    _adpSql10.Fill(_tbl10);
                }

                // _adpSql.Fill(_tbl);

                if (_tbl10.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl10.Rows.Count; i++)
                    {
                        _MtrVContributionMdl1 = new MtrVContributionMdl();
                        _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl10.Rows[i]["tenure"]);

                    }


                }
                else
                {
                    _MtrVContributionMdl1.Tenure = 1;
                }


                decimal PerDayContribution1 = GrossContribution1 / _MtrVContributionMdl1.Tenure;


                _Calculate.BasicContributionV = _MtrVContributionMdl.BasicContribution;
                _Calculate.BeforePEVV = Decimal.Round((_Calculate.BeforePEVU - _Calculate.BeforePEVP),  MidpointRounding.ToEven);
               // _Calculate.BeforePEVV = _Calculate.BeforePEVU - _Calculate.BeforePEVP;
                _Calculate.differenceV = diff;
                _Calculate.FEDV = _MtrVContributionMdl.FED;
                _Calculate.FIFV = _MtrVContributionMdl.FIF;
                _Calculate.GrossContributionV = Decimal.Round((_Calculate.GrossContributionU - _Calculate.GrossContributionP),  MidpointRounding.ToEven);
                // _Calculate.GrossContributionV = _Calculate.GrossContributionU - _Calculate.GrossContributionP;
                _Calculate.NetContributionV = Decimal.Round((_Calculate.NetContributionU - _Calculate.NetContributionP),  MidpointRounding.ToEven);
                //_Calculate.NetContributionV = _Calculate.NetContributionU - _Calculate.NetContributionP;
                _Calculate.PerDayContributionV = PerDayContribution1;
                _Calculate.PEVV = PEV1;
                _Calculate.RateV = _RateV;
                _Calculate.StampV = _MtrVContributionMdl.Stamp;
                _Calculate.SumCoveredV = Decimal.Round((_Calculate.SumCoveredU - _Calculate.SumCoveredP),  MidpointRounding.ToEven);
               // _Calculate.SumCoveredV = _Calculate.SumCoveredU - _Calculate.SumCoveredP;
                _Calculate.TenureV = _MtrVContributionMdl1.Tenure;
                _Calculate.TerrorContributionV = _MtrVContributionMdl.TerrorContribution;
                _Calculate.VarianceMsg = "Variance Contribution";


                _CalculateList.Add(_Calculate);

                return _CalculateList;


            }

            //To increase Sum Covered
            if (_EndtReasonMdl1.EndtReasonCode == 2)
            {
                _Rate = _MtrVContributionMdl.Rate;

                decimal _SumCovered = _VehicleDetailMdl1.ParticipantValue;
                decimal _RateV = _VehicleDetailMdl.Rate;



                decimal NetContribution = 0;
               NetContribution = (_VehicleDetailMdl1.ParticipantValue * (_Rate / 100));
                decimal GrossContribution = 0;
                GrossContribution = (NetContribution - _MtrVContributionMdl.Stamp) / (((_MtrVContributionMdl.FED + _MtrVContributionMdl.FIF) / 100) + 1);



                decimal BeforePEV = (GrossContribution - _MtrVContributionMdl.TerrorContribution);
                decimal PEV = (BeforePEV - _MtrVContributionMdl.BasicContribution);


                //To get Tenure
                DataTable _tbl8 = new DataTable();
                //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = " + InsPolicyTxnID, conn);



                    SqlDataAdapter _adpSql8 = new SqlDataAdapter(command);


                    _adpSql8.Fill(_tbl8);
                }

                // _adpSql.Fill(_tbl);

                if (_tbl8.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl8.Rows.Count; i++)
                    {
                        _MtrVContributionMdl1 = new MtrVContributionMdl();
                        _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl8.Rows[i]["tenure"]);

                    }


                }
                else
                {
                    _MtrVContributionMdl1.Tenure = 365;
                }


                decimal PerDayContribution = GrossContribution / _MtrVContributionMdl1.Tenure;

                //Difference of added value and previous value
                diff = _VehicleDetailMdl1.ParticipantValue - _MtrVContributionMdl.SumCovered;

                //Previous
                _Calculate.BasicContributionP = _MtrVContributionMdl.BasicContribution;
                // _Calculate.BeforePEVP = _MtrVContributionMdl.BeforePEV;
                _Calculate.BeforePEVP = Decimal.Round(_MtrVContributionMdl.BeforePEV,  MidpointRounding.ToEven);
                _Calculate.FEDP = _MtrVContributionMdl.FED;
                _Calculate.FIFP = _MtrVContributionMdl.FIF;
                _Calculate.GrossContributionP = Decimal.Round(_MtrVContributionMdl.GrossContribution,  MidpointRounding.ToEven);
                // _Calculate.GrossContributionP = _MtrVContributionMdl.GrossContribution;
                //  _Calculate.NetContributionP = _MtrVContributionMdl.NetContribution;
                _Calculate.NetContributionP = Decimal.Round(_MtrVContributionMdl.NetContribution,  MidpointRounding.ToEven);
                _Calculate.PerDayContributionP = _MtrVContributionMdl.PerDayContribution;
                _Calculate.PEVP = _MtrVContributionMdl.PEV;
                _Calculate.RateP = _VehicleDetailMdl.Rate;
                _Calculate.StampP = _MtrVContributionMdl.Stamp;
                _Calculate.SumCoveredP = Decimal.Round(_MtrVContributionMdl.SumCovered,  MidpointRounding.ToEven);
               // _Calculate.SumCoveredP = _MtrVContributionMdl.SumCovered;
                _Calculate.TenureP = _MtrVContributionMdl.Tenure;
                _Calculate.TerrorContributionP = _MtrVContributionMdl.TerrorContribution;
                _Calculate.PreviousMsg = "Previous Contribution";


                //Updated
                _Calculate.BasicContributionU = _MtrVContributionMdl.BasicContribution;
                //_Calculate.BeforePEVU = BeforePEV;
                _Calculate.BeforePEVU = Decimal.Round(BeforePEV,  MidpointRounding.ToEven);
                _Calculate.differenceU = diff;
                _Calculate.FEDU = _MtrVContributionMdl.FED;
                _Calculate.FIFU = _MtrVContributionMdl.FIF;
                // _Calculate.GrossContributionU = GrossContribution;
                _Calculate.GrossContributionU = Decimal.Round(GrossContribution,  MidpointRounding.ToEven);
                // _Calculate.NetContributionU = NetContribution;
                _Calculate.NetContributionU = Decimal.Round(NetContribution,  MidpointRounding.ToEven);
                _Calculate.PerDayContributionU = PerDayContribution;
                _Calculate.PEVU = PEV;
                _Calculate.RateU = _RateV;
                _Calculate.StampU = _MtrVContributionMdl.Stamp;
                //_Calculate.SumCoveredU = _SumCovered;
                _Calculate.SumCoveredU = Decimal.Round(_SumCovered,  MidpointRounding.ToEven);
                _Calculate.TenureU = _MtrVContributionMdl1.Tenure;
                _Calculate.TerrorContributionU = _MtrVContributionMdl.TerrorContribution;
                _Calculate.UpdatedMsg = "Updated Contribution";

                //Variance
                decimal _SumCovered1 = diff;
                decimal _RateV1 = _VehicleDetailMdl.Rate;
                decimal NetContribution1 = (_SumCovered1 * (_RateV1 / 100));
                decimal GrossContribution1 = (NetContribution1 - _MtrVContributionMdl.Stamp) / ((_MtrVContributionMdl.FED + _MtrVContributionMdl.FIF / 100) + 1);
                decimal BeforePEV1 = (GrossContribution1 - _MtrVContributionMdl.TerrorContribution);
                decimal PEV1 = (BeforePEV1 - _MtrVContributionMdl.BasicContribution);


                //To get Tenure
                DataTable _tbl10 = new DataTable();
                //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = " + InsPolicyTxnID, conn);



                    SqlDataAdapter _adpSql10 = new SqlDataAdapter(command);


                    _adpSql10.Fill(_tbl10);
                }

                // _adpSql.Fill(_tbl);

                if (_tbl10.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl10.Rows.Count; i++)
                    {
                        _MtrVContributionMdl1 = new MtrVContributionMdl();
                        _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl10.Rows[i]["tenure"]);

                    }


                }
                else
                {
                    _MtrVContributionMdl1.Tenure = 1;
                }


                decimal PerDayContribution1 = GrossContribution1 / _MtrVContributionMdl1.Tenure;


                _Calculate.BasicContributionV = _MtrVContributionMdl.BasicContribution;
                _Calculate.BeforePEVV = Decimal.Round((_Calculate.BeforePEVU - _Calculate.BeforePEVP),  MidpointRounding.ToEven);
                //_Calculate.BeforePEVV = _Calculate.BeforePEVU - _Calculate.BeforePEVP;
                _Calculate.differenceV = diff;
                _Calculate.FEDV = _MtrVContributionMdl.FED;
                _Calculate.FIFV = _MtrVContributionMdl.FIF;
                _Calculate.GrossContributionV = Decimal.Round((_Calculate.GrossContributionU - _Calculate.GrossContributionP),  MidpointRounding.ToEven);
                //_Calculate.GrossContributionV = _Calculate.GrossContributionU - _Calculate.GrossContributionP;
                _Calculate.NetContributionV = Decimal.Round((_Calculate.NetContributionU - _Calculate.NetContributionP),  MidpointRounding.ToEven);
                //_Calculate.NetContributionV = _Calculate.NetContributionU - _Calculate.NetContributionP;
                _Calculate.PerDayContributionV = PerDayContribution1;
                _Calculate.PEVV = _Calculate.PEVU - _Calculate.PEVP;
                _Calculate.RateV = _RateV;
                _Calculate.StampV = _MtrVContributionMdl.Stamp;
                _Calculate.SumCoveredV = _Calculate.SumCoveredU - _Calculate.SumCoveredP;
                _Calculate.TenureV = _MtrVContributionMdl1.Tenure;
                _Calculate.TerrorContributionV = _MtrVContributionMdl.TerrorContribution;
                _Calculate.VarianceMsg = "Variance Contribution";


                _CalculateList.Add(_Calculate);

                return _CalculateList;




            }

            //To Decrease Rate
            if (_EndtReasonMdl1.EndtReasonCode == 3)
            {
                _Rate = _VehicleDetailMdl1.Rate;

                //Convert FED To Zero if 180 days Passed
                DataTable _tblFED = new DataTable();
                //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,'" + DateTime.Now + "') diff  FROM InsPolicy ip INNER JOIN MtrVehicleDetails mvd ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE mvd.TxnSysID = " + _VehicleDetailMdl1.TxnSysID, conn);



                    SqlDataAdapter _adpSql8 = new SqlDataAdapter(command);


                    _adpSql8.Fill(_tblFED);
                }

                // _adpSql.Fill(_tbl);

                if (_tblFED.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblFED.Rows.Count; i++)
                    {

                        days = Convert.ToInt32(_tblFED.Rows[i]["diff"]);

                    }


                }
                else
                {
                    days = 0;
                }

                if (days == 180)
                {
                    FEDU = 0;
                }

                else
                {
                    FEDU = _MtrVContributionMdl.FED;
                }



                decimal _SumCovered = _VehicleDetailMdl.ParticipantValue;
                decimal _RateV = _VehicleDetailMdl1.Rate;




                decimal NetContribution = (_SumCovered * (_RateV / 100));
                decimal GrossContribution = (NetContribution - _MtrVContributionMdl.Stamp) / (((FEDU + _MtrVContributionMdl.FIF) / 100) + 1);



                decimal BeforePEV = (GrossContribution - _MtrVContributionMdl.TerrorContribution);
                decimal PEV = (BeforePEV - _MtrVContributionMdl.BasicContribution);


                //To get Tenure
                DataTable _tbl8 = new DataTable();
                //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = " + InsPolicyTxnID, conn);



                    SqlDataAdapter _adpSql8 = new SqlDataAdapter(command);


                    _adpSql8.Fill(_tbl8);
                }

                // _adpSql.Fill(_tbl);

                if (_tbl8.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl8.Rows.Count; i++)
                    {
                        _MtrVContributionMdl1 = new MtrVContributionMdl();
                        _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl8.Rows[i]["tenure"]);

                    }


                }
                else
                {
                    _MtrVContributionMdl1.Tenure = 365;
                }


                decimal PerDayContribution = GrossContribution / _MtrVContributionMdl1.Tenure;
                //Difference of added value and previous value
                diff = _MtrVContributionMdl.SumCovered - NetContribution;


                //Previous
                _Calculate.BasicContributionP = Decimal.Round(_MtrVContributionMdl.BasicContribution,  MidpointRounding.ToEven);
                //  _Calculate.BasicContributionP = _MtrVContributionMdl.BasicContribution;
                _Calculate.BeforePEVP = Decimal.Round(_MtrVContributionMdl.BeforePEV,  MidpointRounding.ToEven);
                //_Calculate.BeforePEVP = _MtrVContributionMdl.BeforePEV;    
                _Calculate.FEDP = _MtrVContributionMdl.FED;
                _Calculate.FIFP = _MtrVContributionMdl.FIF;
                _Calculate.GrossContributionP = Decimal.Round(_MtrVContributionMdl.GrossContribution,  MidpointRounding.ToEven);
                // _Calculate.GrossContributionP = _MtrVContributionMdl.GrossContribution;
                // _Calculate.NetContributionP = _MtrVContributionMdl.NetContribution;
                _Calculate.NetContributionP = Decimal.Round(_MtrVContributionMdl.NetContribution,  MidpointRounding.ToEven);
                _Calculate.PerDayContributionP = _MtrVContributionMdl.PerDayContribution;
                _Calculate.PEVP = _MtrVContributionMdl.PEV;
                _Calculate.RateP = _VehicleDetailMdl.Rate;
                _Calculate.StampP = _MtrVContributionMdl.Stamp;

                _Calculate.SumCoveredP = Decimal.Round(_MtrVContributionMdl.SumCovered,  MidpointRounding.ToEven);
                // _Calculate.SumCoveredP = _MtrVContributionMdl.SumCovered;
                _Calculate.TenureP = _MtrVContributionMdl.Tenure;
                _Calculate.TerrorContributionP = _MtrVContributionMdl.TerrorContribution;
                _Calculate.PreviousMsg = "Previous Contribution";


                //Updated
                _Calculate.BasicContributionU = _MtrVContributionMdl.BasicContribution;
                _Calculate.BeforePEVU = Decimal.Round(BeforePEV,  MidpointRounding.ToEven);
                //_Calculate.BeforePEVU = BeforePEV;
                _Calculate.differenceU = diff;
                _Calculate.FEDU = FEDU;
                _Calculate.FIFU = _MtrVContributionMdl.FIF;
                _Calculate.GrossContributionU = Decimal.Round(GrossContribution,  MidpointRounding.ToEven);
                //_Calculate.GrossContributionU = GrossContribution;
                //_Calculate.NetContributionU = NetContribution;
                _Calculate.NetContributionU = Decimal.Round(NetContribution,  MidpointRounding.ToEven);
                _Calculate.PerDayContributionU = PerDayContribution;
                _Calculate.PEVU = PEV;
                _Calculate.RateU = _RateV;
                _Calculate.StampU = _MtrVContributionMdl.Stamp;
                _Calculate.SumCoveredU = Decimal.Round(_SumCovered,  MidpointRounding.ToEven);
                // _Calculate.SumCoveredU = _SumCovered;
                _Calculate.TenureU = _MtrVContributionMdl1.Tenure;
                _Calculate.TerrorContributionU = _MtrVContributionMdl.TerrorContribution;
                _Calculate.UpdatedMsg = "Updated Contribution";

                //Variance
                decimal _SumCovered1 = diff;
                decimal _RateV1 = _VehicleDetailMdl1.Rate;
                decimal NetContribution1 = _MtrVContributionMdl.NetContribution - NetContribution;
                decimal GrossContribution1 = _MtrVContributionMdl.GrossContribution - GrossContribution;
                decimal BeforePEV1 = (GrossContribution1 - _MtrVContributionMdl.TerrorContribution);
                decimal PEV1 = (BeforePEV1 - _MtrVContributionMdl.BasicContribution);


                //To get Tenure
                DataTable _tbl10 = new DataTable();
                //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = " + InsPolicyTxnID, conn);



                    SqlDataAdapter _adpSql10 = new SqlDataAdapter(command);


                    _adpSql10.Fill(_tbl10);
                }

                // _adpSql.Fill(_tbl);

                if (_tbl10.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl10.Rows.Count; i++)
                    {
                        _MtrVContributionMdl1 = new MtrVContributionMdl();
                        _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl10.Rows[i]["tenure"]);

                    }


                }
                else
                {
                    _MtrVContributionMdl1.Tenure = 1;
                }


                decimal PerDayContribution1 = GrossContribution1 / _MtrVContributionMdl1.Tenure;


                _Calculate.BasicContributionV = _MtrVContributionMdl.BasicContribution;
                _Calculate.BeforePEVV = Decimal.Round((_Calculate.BeforePEVP - _Calculate.BeforePEVU),  MidpointRounding.ToEven);
                // _Calculate.BeforePEVV = _Calculate.BeforePEVU - _Calculate.BeforePEVP;
                _Calculate.differenceV = diff;
                _Calculate.FEDV = FEDU;
                _Calculate.FIFV = _MtrVContributionMdl.FIF;
                _Calculate.GrossContributionV = Decimal.Round((_Calculate.GrossContributionP - _Calculate.GrossContributionU),  MidpointRounding.ToEven);
                // _Calculate.GrossContributionV = _Calculate.GrossContributionU - _Calculate.GrossContributionP;
                _Calculate.NetContributionV = Decimal.Round((_Calculate.NetContributionP - _Calculate.NetContributionU),  MidpointRounding.ToEven);
                //_Calculate.NetContributionV = _Calculate.NetContributionU - _Calculate.NetContributionP;
                _Calculate.PerDayContributionV = PerDayContribution1;
                _Calculate.PEVV = PEV1;
                _Calculate.RateV = _RateV;
                _Calculate.StampV = _MtrVContributionMdl.Stamp;
                _Calculate.SumCoveredV = Decimal.Round((_Calculate.SumCoveredP - _Calculate.SumCoveredU),  MidpointRounding.ToEven);
                // _Calculate.SumCoveredV = _Calculate.SumCoveredU - _Calculate.SumCoveredP;
                _Calculate.TenureV = _MtrVContributionMdl1.Tenure;
                _Calculate.TerrorContributionV = _MtrVContributionMdl.TerrorContribution;
                _Calculate.VarianceMsg = "Variance Contribution";


                _CalculateList.Add(_Calculate);

                return _CalculateList;


            }

            //To Decrease Sum Covered
            if (_EndtReasonMdl1.EndtReasonCode == 4)
            {
                _Rate = _MtrVContributionMdl.Rate;

                //Convert FED To Zero if 180 days Passed
                DataTable _tblFED = new DataTable();
                //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,'" + DateTime.Now + "') diff  FROM InsPolicy ip INNER JOIN MtrVehicleDetails mvd ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE mvd.TxnSysID = " + _VehicleDetailMdl1.TxnSysID, conn);



                    SqlDataAdapter _adpSql8 = new SqlDataAdapter(command);


                    _adpSql8.Fill(_tblFED);
                }

                // _adpSql.Fill(_tbl);

                if (_tblFED.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblFED.Rows.Count; i++)
                    {

                        days = Convert.ToInt32(_tblFED.Rows[i]["diff"]);

                    }


                }
                else
                {
                    days = 0;
                }

                if (days == 180)
                {
                    FEDU = 0;
                }

                else
                {
                    FEDU = _MtrVContributionMdl.FED;
                }


                decimal _SumCovered = _VehicleDetailMdl1.ParticipantValue;
                decimal _RateV = _VehicleDetailMdl.Rate;



                decimal NetContribution = 0;
                NetContribution = (_VehicleDetailMdl1.ParticipantValue * (_Rate / 100));
                decimal GrossContribution = 0;
                GrossContribution = (NetContribution - _MtrVContributionMdl.Stamp) / (((FEDU + _MtrVContributionMdl.FIF) / 100) + 1);



                decimal BeforePEV = (GrossContribution - _MtrVContributionMdl.TerrorContribution);
                decimal PEV = (BeforePEV - _MtrVContributionMdl.BasicContribution);


                //To get Tenure
                DataTable _tbl8 = new DataTable();
                //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = " + InsPolicyTxnID, conn);



                    SqlDataAdapter _adpSql8 = new SqlDataAdapter(command);


                    _adpSql8.Fill(_tbl8);
                }

                // _adpSql.Fill(_tbl);

                if (_tbl8.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl8.Rows.Count; i++)
                    {
                        _MtrVContributionMdl1 = new MtrVContributionMdl();
                        _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl8.Rows[i]["tenure"]);

                    }


                }
                else
                {
                    _MtrVContributionMdl1.Tenure = 365;
                }


                decimal PerDayContribution = GrossContribution / _MtrVContributionMdl1.Tenure;

                //Difference of added value and previous value
                diff =  _MtrVContributionMdl.SumCovered - _VehicleDetailMdl1.ParticipantValue;

                //Previous
                _Calculate.BasicContributionP = _MtrVContributionMdl.BasicContribution;
                // _Calculate.BeforePEVP = _MtrVContributionMdl.BeforePEV;
                _Calculate.BeforePEVP = Decimal.Round(_MtrVContributionMdl.BeforePEV,  MidpointRounding.ToEven);
                _Calculate.FEDP = _MtrVContributionMdl.FED;
                _Calculate.FIFP = _MtrVContributionMdl.FIF;
                _Calculate.GrossContributionP = Decimal.Round(_MtrVContributionMdl.GrossContribution,  MidpointRounding.ToEven);
                // _Calculate.GrossContributionP = _MtrVContributionMdl.GrossContribution;
                //  _Calculate.NetContributionP = _MtrVContributionMdl.NetContribution;
                _Calculate.NetContributionP = Decimal.Round(_MtrVContributionMdl.NetContribution,  MidpointRounding.ToEven);
                _Calculate.PerDayContributionP = _MtrVContributionMdl.PerDayContribution;
                _Calculate.PEVP = _MtrVContributionMdl.PEV;
                _Calculate.RateP = _VehicleDetailMdl.Rate;
                _Calculate.StampP = _MtrVContributionMdl.Stamp;
                _Calculate.SumCoveredP = Decimal.Round(_MtrVContributionMdl.SumCovered,  MidpointRounding.ToEven);
                // _Calculate.SumCoveredP = _MtrVContributionMdl.SumCovered;
                _Calculate.TenureP = _MtrVContributionMdl.Tenure;
                _Calculate.TerrorContributionP = _MtrVContributionMdl.TerrorContribution;
                _Calculate.PreviousMsg = "Previous Contribution";


                //Updated
                _Calculate.BasicContributionU = _MtrVContributionMdl.BasicContribution;
                //_Calculate.BeforePEVU = BeforePEV;
                _Calculate.BeforePEVU = Decimal.Round(BeforePEV,  MidpointRounding.ToEven);
                _Calculate.differenceU = diff;
                _Calculate.FEDU = FEDU;
                _Calculate.FIFU = _MtrVContributionMdl.FIF;
                // _Calculate.GrossContributionU = GrossContribution;
                _Calculate.GrossContributionU = Decimal.Round(GrossContribution,  MidpointRounding.ToEven);
                // _Calculate.NetContributionU = NetContribution;
                _Calculate.NetContributionU = Decimal.Round(NetContribution,MidpointRounding.ToEven);
                _Calculate.PerDayContributionU = PerDayContribution;
                _Calculate.PEVU = PEV;
                _Calculate.RateU = _RateV;
                _Calculate.StampU = _MtrVContributionMdl.Stamp;
                //_Calculate.SumCoveredU = _SumCovered;
                _Calculate.SumCoveredU = Decimal.Round(_SumCovered,  MidpointRounding.ToEven);
                _Calculate.TenureU = _MtrVContributionMdl1.Tenure;
                _Calculate.TerrorContributionU = _MtrVContributionMdl.TerrorContribution;
                _Calculate.UpdatedMsg = "Updated Contribution";

                //Variance
                decimal _SumCovered1 = diff;
                decimal _RateV1 = _VehicleDetailMdl.Rate;
                decimal NetContribution1 = _MtrVContributionMdl.NetContribution - NetContribution;
                decimal GrossContribution1 = _MtrVContributionMdl.GrossContribution - GrossContribution;
                decimal BeforePEV1 = (GrossContribution1 - _MtrVContributionMdl.TerrorContribution);
                decimal PEV1 = (BeforePEV1 - _MtrVContributionMdl.BasicContribution);


                //To get Tenure
                DataTable _tbl10 = new DataTable();
                //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = " + InsPolicyTxnID, conn);



                    SqlDataAdapter _adpSql10 = new SqlDataAdapter(command);


                    _adpSql10.Fill(_tbl10);
                }

                // _adpSql.Fill(_tbl);

                if (_tbl10.Rows.Count > 0)
                {
                    for (int i = 0; i < _tbl10.Rows.Count; i++)
                    {
                        _MtrVContributionMdl1 = new MtrVContributionMdl();
                        _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl10.Rows[i]["tenure"]);

                    }


                }
                else
                {
                    _MtrVContributionMdl1.Tenure = 1;
                }


                decimal PerDayContribution1 = GrossContribution1 / _MtrVContributionMdl1.Tenure;


                _Calculate.BasicContributionV = _MtrVContributionMdl.BasicContribution;
                _Calculate.BeforePEVV = Decimal.Round((_Calculate.BeforePEVP - _Calculate.BeforePEVU),  MidpointRounding.ToEven);
                //_Calculate.BeforePEVV = _Calculate.BeforePEVU - _Calculate.BeforePEVP;
                _Calculate.differenceV = diff;
                _Calculate.FEDV = FEDU;
                _Calculate.FIFV = _MtrVContributionMdl.FIF;
                _Calculate.GrossContributionV = Decimal.Round((_Calculate.GrossContributionP - _Calculate.GrossContributionU),  MidpointRounding.ToEven);
                //_Calculate.GrossContributionV = _Calculate.GrossContributionU - _Calculate.GrossContributionP;
                _Calculate.NetContributionV = Decimal.Round((_Calculate.NetContributionP - _Calculate.NetContributionU),  MidpointRounding.ToEven);
                //_Calculate.NetContributionV = _Calculate.NetContributionU - _Calculate.NetContributionP;
                _Calculate.PerDayContributionV = PerDayContribution1;
                _Calculate.PEVV = _Calculate.PEVU - _Calculate.PEVP;
                _Calculate.RateV = _RateV;
                _Calculate.StampV = _MtrVContributionMdl.Stamp;
                _Calculate.SumCoveredV = Decimal.Round((_Calculate.SumCoveredP - _Calculate.SumCoveredU), MidpointRounding.ToEven);
                //_Calculate.SumCoveredV = _Calculate.SumCoveredP - _Calculate.SumCoveredU;
                _Calculate.TenureV = _MtrVContributionMdl1.Tenure;
                _Calculate.TerrorContributionV = _MtrVContributionMdl.TerrorContribution;
                _Calculate.VarianceMsg = "Variance Contribution";


                _CalculateList.Add(_Calculate);

                return _CalculateList;




            }

            else
            {
                return null;
            }



            }


        //To create Endorsement (Insertion in 7 tables)
        public VehicleDetailMdl GetEndorsement(VehicleDetailMdl _VehicleDetailMdl1, EndtReasonMdl _EndtReasonMdl1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //Get all IDs For insertion in database
                string _sqlString = "SELECT mvd.Rate,mvd.TxnSysID,mvd.ParentTxnSysID InsPolicyID,ic.TxnSysID ConTxnID FROM MtrVehicleDetails mvd INNER JOIN InsPolicy ip ON mvd.ParentTxnSysID = ip.ParentTxnSysID INNER JOIN InsContribution ic ON ic.RiskTxnID = mvd.TxnSysID WHERE mvd.TxnSysID =" + _VehicleDetailMdl1.TxnSysID;
                DataTable _tblSqla = new DataTable();
                List<VehicleDetailMdl> _VehicleDetailMdlList = new List<VehicleDetailMdl>();
                VehicleDetailMdl _VehicleDetailMdl = new VehicleDetailMdl();
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
                MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                int VehicleTxnID=0, InsPolicyTxnID=0, ConTxnID=0,days=0,stamp =0;
                decimal diff = 0,FEDU = 0;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _VehicleDetailMdl = new VehicleDetailMdl();

                        _VehicleDetailMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        VehicleTxnID = _VehicleDetailMdl.TxnSysID;
                        _VehicleDetailMdl.InsPolicyID = Convert.ToInt32(_tblSqla.Rows[i]["InsPolicyID"]);
                        InsPolicyTxnID = _VehicleDetailMdl.InsPolicyID;
                        _VehicleDetailMdl.ConTxnID = Convert.ToInt32(_tblSqla.Rows[i]["ConTxnID"]);
                        ConTxnID = _VehicleDetailMdl.ConTxnID;
                        _VehicleDetailMdl.Rate = Convert.ToDecimal(_tblSqla.Rows[i]["Rate"]);
                    }

                    
                }
                else
                {

                   
                }

                //Get InsPolicy By ID and insert into InsPolicy For Endorsement
                SqlConnection _conSql1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString1 = "SELECT * FROM InsPolicy WHERE ParentTxnSysID= "+ InsPolicyTxnID;
              
                SqlDataAdapter _adpSql1 = new SqlDataAdapter(_sqlString1, _conSql1);
                DataTable _tblSqla1 = new DataTable();
                List<MtrInsPolicyMdl> _MtrInsPolicyMdlList = new List<MtrInsPolicyMdl>();
                MtrInsPolicyMdl _MtrInsPolicyMdl = new MtrInsPolicyMdl();
                string gen = ""; 

                _adpSql1.Fill(_tblSqla1);

                if (_tblSqla1.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla1.Rows.Count; i++)
                    {
                        _MtrInsPolicyMdl = new MtrInsPolicyMdl();

                       _MtrInsPolicyMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla1.Rows[i]["ParentTxnSysID"]);
                        _MtrInsPolicyMdl.TxnSysDate = Convert.ToDateTime(_tblSqla1.Rows[i]["TxnSysDate"]);
                        _MtrInsPolicyMdl.CertMonth = _tblSqla1.Rows[i]["DocMonth"].ToString();
                        _MtrInsPolicyMdl.CertString = _tblSqla1.Rows[i]["DocString"].ToString();
                        _MtrInsPolicyMdl.CertYear = _tblSqla1.Rows[i]["DocYear"].ToString();
                        _MtrInsPolicyMdl.CertNo = Convert.ToInt32(_tblSqla1.Rows[i]["DocNo"]);
                        _MtrInsPolicyMdl.DocType = _tblSqla1.Rows[i]["DocType"].ToString();
                        _MtrInsPolicyMdl.GenerateAgainst = _tblSqla1.Rows[i]["GenerateAgainst"].ToString();
                        gen = _tblSqla1.Rows[i]["GenerateAgainst"].ToString();
                        _MtrInsPolicyMdl.ProductCode = Convert.ToInt32(_tblSqla1.Rows[i]["ProductCode"]);
                        _MtrInsPolicyMdl.PolicyTypeCode = _tblSqla1.Rows[i]["PolicyTypeCode"].ToString();
                        _MtrInsPolicyMdl.ClientCode = _tblSqla1.Rows[i]["ClientCode"].ToString();
                        _MtrInsPolicyMdl.AgencyCode = _tblSqla1.Rows[i]["AgencyCode"].ToString();
                        _MtrInsPolicyMdl.CertInsureCode = _tblSqla1.Rows[i]["CertInsureCode"].ToString();
                        _MtrInsPolicyMdl.Remarks = _tblSqla1.Rows[i]["Remarks"].ToString();
                        _MtrInsPolicyMdl.BrchCoverNoteNo = _tblSqla1.Rows[i]["BrchCoverNoteNo"].ToString();
                        _MtrInsPolicyMdl.BrchCode = _tblSqla1.Rows[i]["BrchCode"].ToString();
                        _MtrInsPolicyMdl.LeaderPolicyNo = _tblSqla1.Rows[i]["LeaderPolicyNo"].ToString();
                        _MtrInsPolicyMdl.LeaderEndNo = _tblSqla1.Rows[i]["LeaderEndNo"].ToString();
                        _MtrInsPolicyMdl.IsFiler = _tblSqla1.Rows[i]["IsFiler"].ToString();
                        _MtrInsPolicyMdl.CalcType = _tblSqla1.Rows[i]["CalcType"].ToString();
                        _MtrInsPolicyMdl.IsAuto = _tblSqla1.Rows[i]["IsAuto"].ToString();
                        _MtrInsPolicyMdl.EffectiveDate = Convert.ToDateTime(_tblSqla1.Rows[i]["EffectiveDate"]);
                        _MtrInsPolicyMdl.ExpiryDate = Convert.ToDateTime(_tblSqla1.Rows[i]["ExpiryDate"]);
                        _MtrInsPolicyMdl.SerialNo = Convert.ToInt32(_tblSqla1.Rows[i]["SerialNo"]);
                        _MtrInsPolicyMdl.UWYear = _tblSqla1.Rows[i]["UWYear"].ToString();
                        _MtrInsPolicyMdl.CreatedBy = _tblSqla1.Rows[i]["CreatedBy"].ToString();
                        _MtrInsPolicyMdl.PostedBy = _tblSqla1.Rows[i]["PostedBy"].ToString();
                        _MtrInsPolicyMdl.IsPosted = Convert.ToBoolean(_tblSqla1.Rows[i]["IsPosted"]);
                        //_MtrInsPolicyMdl.PostDate = Convert.ToDateTime(_tblSqla1.Rows[i]["PostDate"]);
                        _MtrInsPolicyMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla1.Rows[i]["OpolTxnSysID"]);
                        _MtrInsPolicyMdl.RenewSysID = Convert.ToInt32(_tblSqla1.Rows[i]["RenewSysID"]);
                        _MtrInsPolicyMdl.PolSysID = Convert.ToInt32(_tblSqla1.Rows[i]["PolSysID"]);
                        _MtrInsPolicyMdl.IsRenewal = Convert.ToBoolean(_tblSqla1.Rows[i]["IsRenewal"]);
                        _MtrInsPolicyMdl.CommisionRate = Convert.ToDecimal(_tblSqla1.Rows[i]["CommisionRate"]);
                        _MtrInsPolicyMdl.EndoSerial = Convert.ToInt32(_tblSqla1.Rows[i]["EndoSerial"]);

                        _MtrInsPolicyMdl.IsValidTxn = true;


                        _MtrInsPolicyMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(_tblSqla1.Rows[i]["ProductCode"].ToString());
                        _MtrInsPolicyMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_tblSqla1.Rows[i]["PolicyTypeCode"].ToString());
                        _MtrInsPolicyMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_tblSqla1.Rows[i]["ClientCode"].ToString());
                        _MtrInsPolicyMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_tblSqla1.Rows[i]["AgencyCode"].ToString());
                        _MtrInsPolicyMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_tblSqla1.Rows[i]["CertInsureCode"].ToString());

                        _MtrInsPolicyMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(_tblSqla1.Rows[i]["DocType"].ToString());
                        _MtrInsPolicyMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_tblSqla1.Rows[i]["IsFiler"].ToString());
                        _MtrInsPolicyMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_tblSqla1.Rows[i]["CalcType"].ToString());
                        _MtrInsPolicyMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_tblSqla1.Rows[i]["IsAuto"].ToString());

                      
                       
                        _MtrInsPolicyMdl.IsValidTxn = true;

                    }

                   
                }
                else
                {
                   
                }

                //Increment Endorsement Serial Number
                int _EndoSerial = GetEndoSerial(_MtrInsPolicyMdl.EndoSerial);

                //Update IsActive of particular InsPolicy To pass Endorsement
                SqlConnection _conSql11 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql11 = new StringBuilder();
                SqlCommand _cmdSql11;

                _sbSql11.AppendLine("Update  InsPolicy  SET"); 
                _sbSql11.AppendLine("IsActive = 0"); 
                _sbSql11.AppendLine("WHERE  GenerateAgainst = @GenerateAgainst1");
                _sbSql11.AppendLine("OR  GenerateAgainst = @GenerateAgainst2");
                _cmdSql11 = new SqlCommand(_sbSql11.ToString(), _conSql11);
               // _cmdSql11.Parameters.AddWithValue("@IsActive", Convert.ToBoolean(0));
                _cmdSql11.Parameters.AddWithValue("@GenerateAgainst1", _MtrInsPolicyMdl.GenerateAgainst);
                _cmdSql11.Parameters.AddWithValue("@GenerateAgainst2", InsPolicyTxnID);
                _conSql11.Open();
                _cmdSql11.ExecuteNonQuery();
                _conSql11.Close();

                //Update IsActive of particular Vehicle Details To pass Endorsement
                SqlConnection _conSql12 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql12 = new StringBuilder();
                SqlCommand _cmdSql12;

                _sbSql12.AppendLine("Update  MtrVehicleDetails  SET");
                _sbSql12.AppendLine("IsActive=@IsActive");
                _sbSql12.AppendLine("WHERE TxnSysId=@TxnSysId ");
                _cmdSql12 = new SqlCommand(_sbSql12.ToString(), _conSql12);
                _cmdSql12.Parameters.AddWithValue("@IsActive", false);
                _cmdSql12.Parameters.AddWithValue("@TxnSysId", VehicleTxnID);
                _conSql12.Open();
                _cmdSql12.ExecuteNonQuery();
                _conSql12.Close();

                //Insert Into Ins Policy
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
                _sbSql2.AppendLine("BrchCode,");
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
                _sbSql2.AppendLine("EndoSerial,");
                _sbSql2.AppendLine("IsPosted,");
                // _sbSql2.AppendLine("PostDate,");
                _sbSql2.AppendLine("EndoType,");
                _sbSql2.AppendLine("EndoReason,");
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
                _sbSql2.AppendLine("@BrchCode,");
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
                _sbSql2.AppendLine("@EndoSerial,");
                _sbSql2.AppendLine("@IsPosted,");
                // _sbSql2.AppendLine("@PostDate,");
                _sbSql2.AppendLine("@EndoType,");
                _sbSql2.AppendLine("@EndoReason,");
                _sbSql2.AppendLine("@OpolTxnSysID)");
                


                _cmdSql2 = new SqlCommand(_sbSql2.ToString(), _conSql2);
                // DateTime da = DateTime.Now;
                //  da.ToString("MM-dd-yyyy h:mm tt");
                _cmdSql2.Parameters.AddWithValue("@TxnSysDate", SqlDbType.DateTime).Value = DateTime.Now;


                _cmdSql2.Parameters.AddWithValue("@DocMonth", _MtrInsPolicyMdl.CertMonth);


                _cmdSql2.Parameters.AddWithValue("@DocYear", _MtrInsPolicyMdl.CertYear);

                _cmdSql2.Parameters.AddWithValue("@DocNo", _MtrInsPolicyMdl.CertNo);

                string OpenPolicyDoc = "5";

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

                _cmdSql2.Parameters.AddWithValue("@GenerateAgainst", InsPolicyTxnID);
                _cmdSql2.Parameters.AddWithValue("@ProductCode", _MtrInsPolicyMdl.ProductCode);
                _cmdSql2.Parameters.AddWithValue("@PolicyTypeCode", _MtrInsPolicyMdl.PolicyTypeCode);
                _cmdSql2.Parameters.AddWithValue("@ClientCode", _MtrInsPolicyMdl.ClientCode);
                _cmdSql2.Parameters.AddWithValue("@AgencyCode", _MtrInsPolicyMdl.AgencyCode);
                _cmdSql2.Parameters.AddWithValue("@CertInsureCode", _MtrInsPolicyMdl.CertInsureCode);

                //Remarks for Addition
                _cmdSql2.Parameters.AddWithValue("@Remarks", _VehicleDetailMdl1.Remarks ?? DBNull.Value.ToString());

                _cmdSql2.Parameters.AddWithValue("@BrchCoverNoteNo", _MtrInsPolicyMdl.BrchCoverNoteNo);
                _cmdSql2.Parameters.AddWithValue("@BrchCode", _MtrInsPolicyMdl.BrchCode);
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
              //  _cmdSql2.Parameters.AddWithValue("@PostDate", _MtrInsPolicyMdl.PostDate);
                _cmdSql2.Parameters.AddWithValue("@OpolTxnSysID", _MtrInsPolicyMdl.OpolTxnSysID);
                _cmdSql2.Parameters.AddWithValue("@EndoSerial", _EndoSerial);


                _MtrInsPolicyMdl.CertString = _MtrInsPolicyMdl.CertString;
                _MtrInsPolicyMdl.SerialNo = _SerialNumber;
                // _MtrInsPolicyMdl.TxnSysDate = DateTime.Now;

                if (_EndtReasonMdl1.EndtReasonCode == 1 || _EndtReasonMdl1.EndtReasonCode == 2)
                {
                    _cmdSql2.Parameters.AddWithValue("@EndoType", Convert.ToInt32(1));
                    _cmdSql2.Parameters.AddWithValue("@EndoReason", Convert.ToInt32(_EndtReasonMdl1.EndtReasonCode));
                }

                else
                if (_EndtReasonMdl1.EndtReasonCode == 3 || _EndtReasonMdl1.EndtReasonCode == 4)
                {
                    _cmdSql2.Parameters.AddWithValue("@EndoType", Convert.ToInt32(2));
                    _cmdSql2.Parameters.AddWithValue("@EndoReason", Convert.ToInt32(_EndtReasonMdl1.EndtReasonCode));
                }

                int _TxnSysId;
                _conSql2.Open();
                _TxnSysId = (Int32)_cmdSql2.ExecuteScalar();
                _conSql2.Close();
                _MtrInsPolicyMdl.IsValidTxn = true;

                _MtrInsPolicyMdl.ParentTxnSysID = _TxnSysId;

                _MtrInsPolicyMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(_MtrInsPolicyMdl.ProductCode.ToString());
                _MtrInsPolicyMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_MtrInsPolicyMdl.PolicyTypeCode.ToString());
                _MtrInsPolicyMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_MtrInsPolicyMdl.ClientCode.ToString());
                _MtrInsPolicyMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_MtrInsPolicyMdl.AgencyCode.ToString());
                _MtrInsPolicyMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_MtrInsPolicyMdl.CertInsureCode.ToString());

                string OpenPolicyDoc1 = "5";
                _MtrInsPolicyMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(OpenPolicyDoc1);
                _MtrInsPolicyMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_MtrInsPolicyMdl.IsFiler.ToString());
                _MtrInsPolicyMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_MtrInsPolicyMdl.CalcType.ToString());
                _MtrInsPolicyMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_MtrInsPolicyMdl.IsAuto.ToString());

                _MtrInsPolicyMdl.IsValidTxn = true;
                _MtrInsPolicyMdl.DocType = OpenPolicyDoc1;

                //----------------For Ins Tracker-----------------//

                //Get Values From InsTracker
                SqlConnection _conSqlA = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());

                DataTable _tblSqlaA = new DataTable();
                List<MtrInsTrackerMdl> _MtrInsTrackerMdlListA = new List<MtrInsTrackerMdl>();
                MtrInsTrackerMdl _MtrInsTrackerMdlA = new MtrInsTrackerMdl();


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM InsMtrTracker WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@ParentTxnSysID", InsPolicyTxnID));

                    SqlDataAdapter _adpSqlA = new SqlDataAdapter(command);


                    _adpSqlA.Fill(_tblSqlaA);
                }

                if (_tblSqlaA.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqlaA.Rows.Count; i++)
                    {
                        _MtrInsTrackerMdlA = new MtrInsTrackerMdl();

                        _MtrInsTrackerMdlA.TxnSysID = Convert.ToInt32(_tblSqlaA.Rows[i]["TxnSysID"]);
                        _MtrInsTrackerMdlA.UserCode = Convert.ToInt32(_tblSqlaA.Rows[i]["UserCode"]);
                        _MtrInsTrackerMdlA.TrackerCode = Convert.ToInt32(_tblSqlaA.Rows[i]["TrackerCode"]);
                        _MtrInsTrackerMdlA.TrackerName = _tblSqlaA.Rows[i]["TrackerName"].ToString();
                        _MtrInsTrackerMdlA.TrackerRate = Convert.ToInt32(_tblSqlaA.Rows[i]["TrackerRate"]);
                        _MtrInsTrackerMdlA.ParentTxnSysID = Convert.ToInt32(_tblSqlaA.Rows[i]["ParentTxnSysID"]);



                        _MtrInsTrackerMdlA.IsValidTxn = true;

                        _MtrInsTrackerMdlListA.Add(_MtrInsTrackerMdlA);
                    }

                    //Insert In to InsTracker For Renewal
                    SqlConnection _conSqlB = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSqlB = new StringBuilder();
                    SqlCommand _cmdSqlB;


                    MtrInsTrackerMdl[] TrackerArray = _MtrInsTrackerMdlListA.ToArray();

                    for (int j = 0; j < TrackerArray.Length; j++)
                    {
                        _sbSqlB = new StringBuilder();

                        _sbSqlB.AppendLine("INSERT INTO InsMtrTracker(");

                        _sbSqlB.AppendLine("UserCode,");
                        _sbSqlB.AppendLine("TrackerCode,");
                        _sbSqlB.AppendLine("TrackerName,");
                        _sbSqlB.AppendLine("TrackerRate,");
                        _sbSqlB.AppendLine("ParentTxnSysID)");


                        _sbSqlB.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                        _sbSqlB.AppendLine("@UserCode,");
                        _sbSqlB.AppendLine("@TrackerCode,");
                        _sbSqlB.AppendLine("@TrackerName,");
                        _sbSqlB.AppendLine("@TrackerRate,");
                        _sbSqlB.AppendLine("@ParentTxnSysID)");


                        _cmdSqlB = new SqlCommand(_sbSqlB.ToString(), _conSqlB);
                        int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsTrackerMdlA.UserCode);
                        _cmdSqlB.Parameters.AddWithValue("@UserCode", _userCode);
                        _cmdSqlB.Parameters.AddWithValue("@ParentTxnSysID", _TxnSysId);
                        _cmdSqlB.Parameters.AddWithValue("@TrackerCode", TrackerArray[j].TrackerCode);
                        _cmdSqlB.Parameters.AddWithValue("@TrackerName", TrackerArray[j].TrackerName);
                        _cmdSqlB.Parameters.AddWithValue("@TrackerRate", TrackerArray[j].TrackerRate);
                        //  _cmdSql7.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsTrackerMdl1.ParentTxnSysID);


                        int _TxnSysId1;
                        _conSqlB.Open();
                        _TxnSysId1 = (Int32)_cmdSqlB.ExecuteScalar();
                        _conSqlB.Close();
                    }

                }
                else
                {

                }

                //----------------For Ins Tracker-----------------//

                //----------------For Ins Rider-----------------//

                //Get Values From InsRider
                SqlConnection _conSqlC = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                DataTable _tblSqlaC = new DataTable();
                List<MtrInsRiderMdl> _MtrInsRiderMdlListC = new List<MtrInsRiderMdl>();
                MtrInsRiderMdl _MtrInsRiderMdlC = new MtrInsRiderMdl();


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM InsMtrRider WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@ParentTxnSysID", InsPolicyTxnID));

                    SqlDataAdapter _adpSqlC = new SqlDataAdapter(command);


                    _adpSqlC.Fill(_tblSqlaC);
                }


                if (_tblSqlaC.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqlaC.Rows.Count; i++)
                    {
                        _MtrInsRiderMdlC = new MtrInsRiderMdl();

                        _MtrInsRiderMdlC.TxnSysID = Convert.ToInt32(_tblSqlaC.Rows[i]["TxnSysID"]);
                        _MtrInsRiderMdlC.TxnSysDate = Convert.ToDateTime(_tblSqlaC.Rows[i]["TxnSysDate"]);
                        _MtrInsRiderMdlC.UserCode = Convert.ToInt32(_tblSqlaC.Rows[i]["UserCode"]);
                        _MtrInsRiderMdlC.RiderCode = Convert.ToInt32(_tblSqlaC.Rows[i]["RiderCode"]);
                        _MtrInsRiderMdlC.RiderName = _tblSqlaC.Rows[i]["RiderName"].ToString();
                        _MtrInsRiderMdlC.RiderRate = Convert.ToInt32(_tblSqlaC.Rows[i]["RiderRate"]);
                        _MtrInsRiderMdlC.ParentTxnSysID = Convert.ToInt32(_tblSqlaC.Rows[i]["ParentTxnSysID"]);




                        _MtrInsRiderMdlC.IsValidTxn = true;

                        _MtrInsRiderMdlListC.Add(_MtrInsRiderMdlC);
                    }


                    //Insert In To Ins Rider
                    SqlConnection _conSqlD = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSqlD = new StringBuilder();
                    SqlCommand _cmdSqlD;


                    MtrInsRiderMdl[] RiderArray = _MtrInsRiderMdlListC.ToArray();

                    for (int j = 0; j < RiderArray.Length; j++)
                    {
                        _sbSqlD = new StringBuilder();

                        _sbSqlD.AppendLine("INSERT INTO InsMtrRider(");
                        //_sbSql.AppendLine("TxnSysID,");
                        //_sbSql.AppendLine("TxnSysDate,");
                        _sbSqlD.AppendLine("UserCode,");
                        _sbSqlD.AppendLine("RiderCode,");
                        _sbSqlD.AppendLine("RiderName,");
                        _sbSqlD.AppendLine("RiderRate,");
                        _sbSqlD.AppendLine("ParentTxnSysID)");



                        _sbSqlD.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                        // _sbSql.AppendLine("@TxnSysID,");
                        //  _sbSql.AppendLine("@TxnSysDate,");
                        _sbSqlD.AppendLine("@UserCode,");
                        _sbSqlD.AppendLine("@RiderCode,");
                        _sbSqlD.AppendLine("@RiderName,");
                        _sbSqlD.AppendLine("@RiderRate,");
                        _sbSqlD.AppendLine("@ParentTxnSysID)");




                        _cmdSqlD = new SqlCommand(_sbSqlD.ToString(), _conSqlD);
                        int _userCode = GlobalDataLayer.GetUserCodeById(_MtrInsRiderMdlC.UserCode);
                        _cmdSqlD.Parameters.AddWithValue("@UserCode", _userCode);
                        _cmdSqlD.Parameters.AddWithValue("@RiderCode", RiderArray[j].RiderCode);
                        _cmdSqlD.Parameters.AddWithValue("@RiderName", RiderArray[j].RiderName);
                        _cmdSqlD.Parameters.AddWithValue("@RiderRate", RiderArray[j].RiderRate);
                        _cmdSqlD.Parameters.AddWithValue("@ParentTxnSysID", _TxnSysId);


                        int _TxnSysId2;
                        _conSqlD.Open();
                        _TxnSysId2 = (Int32)_cmdSqlD.ExecuteScalar();
                        _conSqlD.Close();

                    }

                }
                else
                {

                }

                //----------------For Ins Rider-----------------//

                //----------------For Ins Conditions-----------------//

                //Get Values From Ins Conditions
                SqlConnection _conSqlE = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                DataTable _tblSqlaE = new DataTable();
                List<MtrInsConditionsMdl> _MtrInsConditionsMdlListE = new List<MtrInsConditionsMdl>();
                MtrInsConditionsMdl _MtrInsConditionsMdlE;


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM InsMtrConditions WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@ParentTxnSysID", InsPolicyTxnID));

                    SqlDataAdapter _adpSqlE = new SqlDataAdapter(command);


                    _adpSqlE.Fill(_tblSqlaE);
                }


                if (_tblSqlaE.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqlaE.Rows.Count; i++)
                    {
                        _MtrInsConditionsMdlE = new MtrInsConditionsMdl();

                        _MtrInsConditionsMdlE.TxnSysID = Convert.ToInt32(_tblSqlaE.Rows[i]["TxnSysID"]);
                        _MtrInsConditionsMdlE.TxnSysDate = Convert.ToDateTime(_tblSqlaE.Rows[i]["TxnSysDate"]);
                        _MtrInsConditionsMdlE.UserCode = Convert.ToInt32(_tblSqlaE.Rows[i]["UserCode"]);
                        _MtrInsConditionsMdlE.ParentTxnSysID = Convert.ToInt32(_tblSqlaE.Rows[i]["ParentTxnSysID"]);
                        _MtrInsConditionsMdlE.Condition = _tblSqlaE.Rows[i]["Condition"].ToString();

                        _MtrInsConditionsMdlE.ConditionShText = GlobalDataLayer.GetConditionByCode(_tblSqlaE.Rows[i]["Condition"].ToString());



                        _MtrInsConditionsMdlE.IsValidTxn = true;

                        _MtrInsConditionsMdlListE.Add(_MtrInsConditionsMdlE);
                    }

                    //Insert Into Ins Conditions
                    SqlConnection _conSqlF = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSqlF = new StringBuilder();
                    SqlCommand _cmdSqlF;


                    MtrInsConditionsMdl[] ConditionsArray = _MtrInsConditionsMdlListE.ToArray();

                    for (int j = 0; j < ConditionsArray.Length; j++)
                    {
                        _sbSqlF = new StringBuilder();

                        _sbSqlF.AppendLine("INSERT INTO InsMtrConditions(");
                        _sbSqlF.AppendLine("ParentTxnSysID,");
                        _sbSqlF.AppendLine("Condition)");

                        _sbSqlF.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                        _sbSqlF.AppendLine("@ParentTxnSysID,");
                        _sbSqlF.AppendLine("@Condition)");

                        _cmdSqlF = new SqlCommand(_sbSqlF.ToString(), _conSqlF);

                        //_cmdSql9.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsRiderMdl1.ParentTxnSysID);
                        _cmdSqlF.Parameters.AddWithValue("@Condition", ConditionsArray[j].Condition.ToString());
                        _cmdSqlF.Parameters.AddWithValue("@ParentTxnSysID", _TxnSysId);

                        int _TxnSysId3;
                        _conSqlF.Open();
                        _TxnSysId3 = (Int32)_cmdSqlF.ExecuteScalar();
                        _conSqlF.Close();
                    }

                }
                else
                {

                }

                //----------------For Ins Conditions-----------------//

                //----------------For Ins Warranties-----------------//

                //Get Values From InsWarranties
                SqlConnection _conSqlG = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                DataTable _tblSqlaG = new DataTable();
                List<MtrInsWarrantiesMdl> _MtrInsWarrantiesMdlListG = new List<MtrInsWarrantiesMdl>();
                MtrInsWarrantiesMdl _MtrInsWarrantiesMdlG;


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM InsMtrWarranties WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@ParentTxnSysID", InsPolicyTxnID));

                    SqlDataAdapter _adpSqlG = new SqlDataAdapter(command);


                    _adpSqlG.Fill(_tblSqlaG);
                }


                //  _adpSql.Fill(_tbl);

                if (_tblSqlaG.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqlaG.Rows.Count; i++)
                    {
                        _MtrInsWarrantiesMdlG = new MtrInsWarrantiesMdl();

                        _MtrInsWarrantiesMdlG.TxnSysID = Convert.ToInt32(_tblSqlaG.Rows[i]["TxnSysID"]);
                        _MtrInsWarrantiesMdlG.TxnSysDate = Convert.ToDateTime(_tblSqlaG.Rows[i]["TxnSysDate"]);
                        _MtrInsWarrantiesMdlG.UserCode = Convert.ToInt32(_tblSqlaG.Rows[i]["UserCode"]);
                        _MtrInsWarrantiesMdlG.Warranty = _tblSqlaG.Rows[i]["Warranty"].ToString();
                        _MtrInsWarrantiesMdlG.ParentTxnSysID = Convert.ToInt32(_tblSqlaG.Rows[i]["ParentTxnSysID"]);

                        _MtrInsWarrantiesMdlG.WarrantyShText = GlobalDataLayer.GetWarrantyTextByCode(_tblSqlaG.Rows[i]["Warranty"].ToString());




                        _MtrInsWarrantiesMdlG.IsValidTxn = true;

                        _MtrInsWarrantiesMdlListG.Add(_MtrInsWarrantiesMdlG);
                    }

                    //Insert In To InsWarranties
                    SqlConnection _conSqlH = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSqlH = new StringBuilder();
                    SqlCommand _cmdSqlH;


                    MtrInsWarrantiesMdl[] WarrantyArray = _MtrInsWarrantiesMdlListG.ToArray();

                    for (int j = 0; j < WarrantyArray.Length; j++)
                    {
                        _sbSqlH = new StringBuilder();

                        _sbSqlH.AppendLine("INSERT INTO InsMtrWarranties(");
                        _sbSqlH.AppendLine("ParentTxnSysID,");
                        _sbSqlH.AppendLine("Warranty)");

                       

                        _sbSqlH.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                        _sbSqlH.AppendLine("@ParentTxnSysID,");
                        _sbSqlH.AppendLine("@Warranty)");

                        _cmdSqlH = new SqlCommand(_sbSqlH.ToString(), _conSqlH);

                        //  _cmdSql10.Parameters.AddWithValue("@ParentTxnSysID", _MtrInsRiderMdl1.ParentTxnSysID);
                        _cmdSqlH.Parameters.AddWithValue("@Warranty", WarrantyArray[j].Warranty.ToString());
                        _cmdSqlH.Parameters.AddWithValue("@ParentTxnSysID", _TxnSysId);

                        int _TxnSysId4;
                        _conSqlH.Open();
                        _TxnSysId4 = (Int32)_cmdSqlH.ExecuteScalar();
                        _conSqlH.Close();
                    }

                }
                else
                {

                }

                //----------------For Ins Warranties-----------------//


                //To increase Rate
                decimal _Rate;
                if (_EndtReasonMdl1.EndtReasonCode == 1)
                {
                    _Rate = _VehicleDetailMdl1.Rate;

                    //Get Values From MtrVehicle Detail by TxnID
                    SqlConnection _conSql3 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    string _sqlString3 = "SELECT * FROM MtrVehicleDetails mvd WHERE mvd.TxnSysID =  " + _VehicleDetailMdl1.TxnSysID;

                    SqlDataAdapter _adpSql3 = new SqlDataAdapter(_sqlString3, _conSql3);
                    DataTable _tblSqla3 = new DataTable();


                    _adpSql3.Fill(_tblSqla3);

                    if (_tblSqla3.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla3.Rows.Count; i++)
                        {
                            _VehicleDetailMdl = new VehicleDetailMdl();

                            _VehicleDetailMdl.TxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["TxnSysID"]);
                            _VehicleDetailMdl.TxnSysDate = Convert.ToDateTime(_tblSqla3.Rows[i]["TxnSysDate"]);
                            _VehicleDetailMdl.UserCode = Convert.ToInt32(_tblSqla3.Rows[i]["UserCode"]);
                            _VehicleDetailMdl.SerialNo = Convert.ToInt32(_tblSqla3.Rows[i]["SerialNo"].ToString());
                            _VehicleDetailMdl.VehicleCode = Convert.ToInt32(_tblSqla3.Rows[i]["VehicleCode"].ToString());
                            _VehicleDetailMdl.VehicleModel = Convert.ToInt32(_tblSqla3.Rows[i]["VehicleModel"].ToString());
                            _VehicleDetailMdl.UpdatedValue = Convert.ToDecimal(_tblSqla3.Rows[i]["UpdatedValue"]);
                            _VehicleDetailMdl.PreviousValue = Convert.ToDecimal(_tblSqla3.Rows[i]["PreviousValue"]);
                            _VehicleDetailMdl.Mileage = Convert.ToInt32(_tblSqla3.Rows[i]["Mileage"].ToString());
                            _VehicleDetailMdl.ParticipantValue = Convert.ToDecimal(_tblSqla3.Rows[i]["ParticipantValue"]);
                            _VehicleDetailMdl.ColorCode = Convert.ToInt32(_tblSqla3.Rows[i]["ColorCode"].ToString());
                            _VehicleDetailMdl.ParticipantName = _tblSqla3.Rows[i]["ParticipantName"].ToString();
                            _VehicleDetailMdl.ParticipantAddress = _tblSqla3.Rows[i]["ParticipantAddress"].ToString();
                            // _VehicleDetailMdl.ModelNumber = Convert.ToInt32(_tblSqla.Rows[i]["ModelNumber"]);
                            _VehicleDetailMdl.RegistrationNumber = _tblSqla3.Rows[i]["RegistrationNumber"].ToString();
                            _VehicleDetailMdl.CityCode = _tblSqla3.Rows[i]["CityCode"].ToString();
                            _VehicleDetailMdl.EngineNumber = _tblSqla3.Rows[i]["EngineNumber"].ToString();
                            _VehicleDetailMdl.AreaCode = Convert.ToInt32(_tblSqla3.Rows[i]["AreaCode"].ToString());
                            _VehicleDetailMdl.ChasisNumber = _tblSqla3.Rows[i]["ChasisNumber"].ToString();
                            _VehicleDetailMdl.Remarks = _tblSqla3.Rows[i]["Remarks"].ToString();
                            _VehicleDetailMdl.PODate = Convert.ToDateTime(_tblSqla3.Rows[i]["PODate"]);
                            _VehicleDetailMdl.PONumber = (_tblSqla3.Rows[i]["PONumber"].ToString());
                            _VehicleDetailMdl.CNICNumber = _tblSqla3.Rows[i]["CNICNumber"].ToString();
                            _VehicleDetailMdl.Tenure = _tblSqla3.Rows[i]["Tenure"].ToString();
                            _VehicleDetailMdl.BirthDate = Convert.ToDateTime(_tblSqla3.Rows[i]["BirthDate"]);
                            _VehicleDetailMdl.Gender = _tblSqla3.Rows[i]["Gender"].ToString();
                            _VehicleDetailMdl.VehicleType = _tblSqla3.Rows[i]["VehicleType"].ToString();
                            _VehicleDetailMdl.VEODCode = Convert.ToInt32(_tblSqla3.Rows[i]["VEODCode"]);
                            _VehicleDetailMdl.CertTypeCode = _tblSqla3.Rows[i]["CertTypeCode"].ToString();
                            _VehicleDetailMdl.Rate = Convert.ToDecimal(_tblSqla3.Rows[i]["Rate"]);
                            _VehicleDetailMdl.Contribution = Convert.ToInt32(_tblSqla3.Rows[i]["Contribution"]);
                            _VehicleDetailMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["ParentTxnSysID"]);
                            _VehicleDetailMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["OpolTxnSysID"]);

                            _VehicleDetailMdl.RatingFactor = _tblSqla3.Rows[i]["RatingFactor"].ToString();
                            _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_tblSqla3.Rows[i]["RatingFactor"].ToString());

                           _VehicleDetailMdl.VEODName = GlobalDataLayer.GetVEODNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["VEODCode"]));
                            _VehicleDetailMdl.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_tblSqla3.Rows[i]["VehicleType"].ToString());

                            _VehicleDetailMdl.InsuranceTypeCode = Convert.ToInt32(_tblSqla3.Rows[i]["InsuranceTypeCode"]);
                            _VehicleDetailMdl.IsActive = Convert.ToBoolean(_tblSqla3.Rows[i]["IsActive"]);
                            _VehicleDetailMdl.IsCanceled = Convert.ToBoolean(_tblSqla3.Rows[i]["IsCanceled"]);
                            _VehicleDetailMdl.CommisionRate = Convert.ToDecimal(_tblSqla3.Rows[i]["CommisionRate"]);
                            _VehicleDetailMdl.MobileNumber = _tblSqla3.Rows[i]["MobileNumber"].ToString();
                            _VehicleDetailMdl.ResNumber = _tblSqla3.Rows[i]["ResNumber"].ToString();
                            _VehicleDetailMdl.OfficeNumber = _tblSqla3.Rows[i]["OfficeNumber"].ToString();

                            _VehicleDetailMdl.EmailAddress = _tblSqla3.Rows[i]["EmailAddress"].ToString();
                            _VehicleDetailMdl.Deductible = Convert.ToDecimal(_tblSqla3.Rows[i]["Deductible"]);

                            _VehicleDetailMdl.ContractMatDate = Convert.ToDateTime(_tblSqla3.Rows[i]["ContractMatDate"]);


                            _VehicleDetailMdl.GenderName = GlobalDataLayer.GetGenderNameByCode(_tblSqla3.Rows[i]["Gender"].ToString());
                            _VehicleDetailMdl.CityName = GlobalDataLayer.GetCityNameByCode(_tblSqla3.Rows[i]["CityCode"].ToString());
                            _VehicleDetailMdl.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["ColorCode"].ToString()));
                            _VehicleDetailMdl.VehicleName = GlobalDataLayer.GetVehicleNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["VehicleCode"].ToString()));
                            _VehicleDetailMdl.AreaName = GlobalDataLayer.GetAreaNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["AreaCode"].ToString()));
                            _VehicleDetailMdl.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_tblSqla3.Rows[i]["CertTypeCode"].ToString());
                            _VehicleDetailMdl.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["InsuranceTypeCode"]));

                            _VehicleDetailMdl.total = GlobalDataLayer.calculate(_VehicleDetailMdl);


                            _VehicleDetailMdlList.Add(_VehicleDetailMdl);


                        }
                    }

                    else
                    {

                    }


                    //Insert Into Vehicle Details
                    SqlConnection _conSql4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql4 = new StringBuilder();
                    SqlCommand _cmdSql4;
                    int _SerialNumber1 = GetSerialNo1(_VehicleDetailMdl);


                    _sbSql4.AppendLine("INSERT INTO MtrVehicleDetails(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql4.AppendLine("TxnSysDate,");
                    _sbSql4.AppendLine("UserCode,");
                    _sbSql4.AppendLine("SerialNo,");
                    _sbSql4.AppendLine("VehicleCode,");
                    _sbSql4.AppendLine("VehicleModel,");
                    _sbSql4.AppendLine("UpdatedValue,");
                    _sbSql4.AppendLine("PreviousValue,");
                    _sbSql4.AppendLine("Mileage,");
                    _sbSql4.AppendLine("ParticipantValue,");
                    _sbSql4.AppendLine("ColorCode,");
                    _sbSql4.AppendLine("ParticipantName,");
                    _sbSql4.AppendLine("ParticipantAddress,");
                    // _sbSql.AppendLine("ModelNumber,");
                    _sbSql4.AppendLine("RegistrationNumber,");
                    _sbSql4.AppendLine("CityCode,");
                    _sbSql4.AppendLine("EngineNumber,");
                    _sbSql4.AppendLine("AreaCode,");
                    _sbSql4.AppendLine("ChasisNumber,");
                    _sbSql4.AppendLine("Remarks,");
                    _sbSql4.AppendLine("PODate,");
                    _sbSql4.AppendLine("PONumber,");
                    _sbSql4.AppendLine("CNICNumber,");
                    _sbSql4.AppendLine("Tenure,");
                    _sbSql4.AppendLine("BirthDate,");
                    _sbSql4.AppendLine("Gender,");
                    _sbSql4.AppendLine("VehicleType,");
                    _sbSql4.AppendLine("VEODCode,");
                    _sbSql4.AppendLine("CertTypeCode,");
                    _sbSql4.AppendLine("Rate,");
                    _sbSql4.AppendLine("ParentTxnSysID,");
                    _sbSql4.AppendLine("OpolTxnSysID,");
                    _sbSql4.AppendLine("InsuranceTypeCode,");
                    _sbSql4.AppendLine("CommisionRate,");
                    _sbSql4.AppendLine("MobileNumber,");
                    _sbSql4.AppendLine("ResNumber,");
                    _sbSql4.AppendLine("OfficeNumber,");
                    _sbSql4.AppendLine("EmailAddress,");
                    _sbSql4.AppendLine("Deductible,");
                    _sbSql4.AppendLine("ContractMatDate,");
                    _sbSql4.AppendLine("RatingFactor,");
                    _sbSql4.AppendLine("Contribution)");


                    _sbSql4.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                    // _sbSql.AppendLine("@TxnSysID,");
                    _sbSql4.AppendLine("@TxnSysDate,");
                    _sbSql4.AppendLine("@UserCode,");
                    _sbSql4.AppendLine("@SerialNo,");
                    _sbSql4.AppendLine("@VehicleCode,");
                    _sbSql4.AppendLine("@VehicleModel,");
                    _sbSql4.AppendLine("@UpdatedValue,");
                    _sbSql4.AppendLine("@PreviousValue,");
                    _sbSql4.AppendLine("@Mileage,");
                    _sbSql4.AppendLine("@ParticipantValue,");
                    _sbSql4.AppendLine("@ColorCode,");
                    _sbSql4.AppendLine("@ParticipantName,");
                    _sbSql4.AppendLine("@ParticipantAddress,");
                    // _sbSql.AppendLine("@ModelNumber,");
                    _sbSql4.AppendLine("@RegistrationNumber,");
                    _sbSql4.AppendLine("@CityCode,");
                    _sbSql4.AppendLine("@EngineNumber,");
                    _sbSql4.AppendLine("@AreaCode,");
                    _sbSql4.AppendLine("@ChasisNumber,");
                    _sbSql4.AppendLine("@Remarks,");
                   _sbSql4.AppendLine("@PODate,");
                    _sbSql4.AppendLine("@PONumber,");
                    _sbSql4.AppendLine("@CNICNumber,");
                    _sbSql4.AppendLine("@Tenure,");
                    _sbSql4.AppendLine("@BirthDate,");
                    _sbSql4.AppendLine("@Gender,");
                    _sbSql4.AppendLine("@VehicleType,");
                    _sbSql4.AppendLine("@VEODCode,");
                    _sbSql4.AppendLine("@CertTypeCode,");
                    _sbSql4.AppendLine("@Rate,");
                    _sbSql4.AppendLine("@ParentTxnSysID,");
                    _sbSql4.AppendLine("(SELECT ip.OpolTxnSysID FROM InsPolicy ip WHERE ip.ParentTxnSysID = @ParentTxnSysID),");
                    _sbSql4.AppendLine("@InsuranceTypeCode,");
                    _sbSql4.AppendLine("@CommisionRate,");
                    _sbSql4.AppendLine("@MobileNumber,");
                    _sbSql4.AppendLine("@ResNumber,");
                    _sbSql4.AppendLine("@OfficeNumber,");
                    _sbSql4.AppendLine("@EmailAddress,");
                    _sbSql4.AppendLine("@Deductible,");
                    _sbSql4.AppendLine("@ContractMatDate,");
                    _sbSql4.AppendLine("@RatingFactor,");
                    _sbSql4.AppendLine("@Contribution)");


                    _cmdSql4 = new SqlCommand(_sbSql4.ToString(), _conSql4);




                    DateTime da = DateTime.Now;
                    da.ToString("MM-dd-yyyy h:mm tt");

                    _cmdSql4.Parameters.AddWithValue("@TxnSysDate", Convert.ToDateTime(da));
                    int _userCode = GlobalDataLayer.GetUserCodeById(_VehicleDetailMdl.UserCode);
                    _cmdSql4.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql4.Parameters.AddWithValue("@ParentTxnSysID", _TxnSysId);

                    _cmdSql4.Parameters.AddWithValue("@SerialNo", _SerialNumber1);
                    _cmdSql4.Parameters.AddWithValue("@VehicleCode", _VehicleDetailMdl.VehicleCode);
                    _cmdSql4.Parameters.AddWithValue("@VehicleModel", _VehicleDetailMdl.VehicleModel);
                    _cmdSql4.Parameters.AddWithValue("@UpdatedValue", _VehicleDetailMdl.UpdatedValue);
                    _cmdSql4.Parameters.AddWithValue("@PreviousValue", _VehicleDetailMdl.PreviousValue);
                    _cmdSql4.Parameters.AddWithValue("@Mileage", _VehicleDetailMdl.Mileage);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantValue", _VehicleDetailMdl.ParticipantValue);
                    _cmdSql4.Parameters.AddWithValue("@ColorCode", _VehicleDetailMdl.ColorCode);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantName", _VehicleDetailMdl.ParticipantName);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantAddress", _VehicleDetailMdl.ParticipantAddress);
                    // _cmdSql.Parameters.AddWithValue("@ModelNumber", _VehicleDetailMdl.ModelNumber);
                    _cmdSql4.Parameters.AddWithValue("@RegistrationNumber", _VehicleDetailMdl.RegistrationNumber);
                    _cmdSql4.Parameters.AddWithValue("@CityCode", _VehicleDetailMdl.CityCode);
                    _cmdSql4.Parameters.AddWithValue("@EngineNumber", _VehicleDetailMdl.EngineNumber);
                    _cmdSql4.Parameters.AddWithValue("@AreaCode", _VehicleDetailMdl.AreaCode);
                    _cmdSql4.Parameters.AddWithValue("@ChasisNumber", _VehicleDetailMdl.ChasisNumber);

                    //Add Remarks for addition
                    _cmdSql4.Parameters.AddWithValue("@Remarks", _VehicleDetailMdl1.Remarks ?? DBNull.Value.ToString());

                   _cmdSql4.Parameters.AddWithValue("@PODate", _VehicleDetailMdl.PODate);
                    _cmdSql4.Parameters.AddWithValue("@PONumber", _VehicleDetailMdl.PONumber);
                    _cmdSql4.Parameters.AddWithValue("@CNICNumber", _VehicleDetailMdl.CNICNumber);
                    _cmdSql4.Parameters.AddWithValue("@Tenure", _VehicleDetailMdl.Tenure);
                    _cmdSql4.Parameters.AddWithValue("@BirthDate", _VehicleDetailMdl.BirthDate);
                    _cmdSql4.Parameters.AddWithValue("@Gender", _VehicleDetailMdl.Gender);
                    _cmdSql4.Parameters.AddWithValue("@VehicleType", _VehicleDetailMdl.VehicleType);
                    _cmdSql4.Parameters.AddWithValue("@VEODCode", _VehicleDetailMdl.VEODCode);
                    _cmdSql4.Parameters.AddWithValue("@CertTypeCode", _VehicleDetailMdl.CertTypeCode);
                    _cmdSql4.Parameters.AddWithValue("@Rate", _VehicleDetailMdl1.Rate);
                    _cmdSql4.Parameters.AddWithValue("@InsuranceTypeCode", _VehicleDetailMdl.InsuranceTypeCode);
                    _cmdSql4.Parameters.AddWithValue("@Contribution", _VehicleDetailMdl.Contribution);
                    _cmdSql4.Parameters.AddWithValue("@CommisionRate", _VehicleDetailMdl.CommisionRate);
                    _cmdSql4.Parameters.AddWithValue("@MobileNumber", _VehicleDetailMdl.MobileNumber);
                    _cmdSql4.Parameters.AddWithValue("@ResNumber", _VehicleDetailMdl.ResNumber);
                    _cmdSql4.Parameters.AddWithValue("@OfficeNumber", _VehicleDetailMdl.OfficeNumber);

                    _cmdSql4.Parameters.AddWithValue("@EmailAddress", _VehicleDetailMdl.EmailAddress);
                    _cmdSql4.Parameters.AddWithValue("@Deductible", _VehicleDetailMdl.Deductible);
                    _cmdSql4.Parameters.AddWithValue("@ContractMatDate", _VehicleDetailMdl.ContractMatDate);

                    _cmdSql4.Parameters.AddWithValue("@RatingFactor", _VehicleDetailMdl.RatingFactor);
                    _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_VehicleDetailMdl.RatingFactor);

                   _VehicleDetailMdl.SerialNo = _SerialNumber;

                    _VehicleDetailMdl.TxnSysDate = DateTime.Now;

                    //_VehicleDetailMdl.VEODName = GlobalDataLayer.GetVEODNameByCode(_VehicleDetailMdl.VEODCode);
                    //_VehicleDetailMdl.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_VehicleDetailMdl.VehicleType);
                    //_VehicleDetailMdl.GenderName = GlobalDataLayer.GetGenderNameByCode(_VehicleDetailMdl.Gender);
                    //_VehicleDetailMdl.CityName = GlobalDataLayer.GetCityNameByCode(_VehicleDetailMdl.CityCode);
                    //_VehicleDetailMdl.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(_VehicleDetailMdl.ColorCode);
                    //_VehicleDetailMdl.VehicleName = GlobalDataLayer.GetVehicleNameByCode(_VehicleDetailMdl.VehicleCode);
                    //_VehicleDetailMdl.AreaName = GlobalDataLayer.GetAreaNameByCode(_VehicleDetailMdl.AreaCode);
                    //_VehicleDetailMdl.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_VehicleDetailMdl.CertTypeCode);
                    //_VehicleDetailMdl.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(_VehicleDetailMdl.InsuranceTypeCode);


                    //_VehicleDetailMdl.total = GlobalDataLayer.calculate(_VehicleDetailMdl);

                    int _TxnSysId2;
                    _conSql4.Open();
                    _TxnSysId2 = (Int32)_cmdSql4.ExecuteScalar();
                    _conSql4.Close();
                    _VehicleDetailMdl.IsValidTxn = true;
                    _VehicleDetailMdl.TxnSysID = _TxnSysId2;

                    //For Second Endorsemnt Get Values of Contribution from UpdateContribution
                    if (_MtrInsPolicyMdl.EndoSerial > 0)
                    {
                        //Get values From Ins Update Contribution
                        SqlConnection _conSql5A = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        DataTable _tblSqla5A = new DataTable();
                        // MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
                        List<MtrVContributionMdl> _MtrVContributionMdlListA = new List<MtrVContributionMdl>();

                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                        {
                            SqlCommand command =
                                new SqlCommand("SELECT * FROM InsUpdateContribution iuc INNER JOIN InsContribution ic ON ic.RiskTxnID = iuc.RiskTxnID WHERE ic.TxnSysID = @TxnSysID", conn);

                            command.Parameters.Add(new SqlParameter("@TxnSysID", ConTxnID));

                            SqlDataAdapter _adpSql5A = new SqlDataAdapter(command);


                            _adpSql5A.Fill(_tblSqla5A);
                        }



                        if (_tblSqla5A.Rows.Count > 0)
                        {
                            _MtrVContributionMdl = new MtrVContributionMdl();
                            for (int i = 0; i < _tblSqla5A.Rows.Count; i++)
                            {

                                _MtrVContributionMdl.TxnSysID = Convert.ToInt32(_tblSqla5A.Rows[i]["TxnSysID"]);
                                _MtrVContributionMdl.TxnSysDate = Convert.ToDateTime(_tblSqla5A.Rows[i]["TxnSysDate"]);
                                _MtrVContributionMdl.UserCode = Convert.ToInt32(_tblSqla5A.Rows[i]["UserCode"]);
                                _MtrVContributionMdl.SumCovered = Convert.ToInt32(_tblSqla5A.Rows[i]["SumCovered"]);
                                _MtrVContributionMdl.Rate = Convert.ToDecimal(_tblSqla5A.Rows[i]["Rate"]);
                                _MtrVContributionMdl.NetContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["NetContribution"]);
                                _MtrVContributionMdl.GrossContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["GrossContribution"]);
                                _MtrVContributionMdl.FIF = Convert.ToDecimal(_tblSqla5A.Rows[i]["FIF"]);
                                _MtrVContributionMdl.FED = Convert.ToDecimal(_tblSqla5A.Rows[i]["FED"]);
                                _MtrVContributionMdl.Stamp = Convert.ToDecimal(_tblSqla5A.Rows[i]["Stamp"]);
                                _MtrVContributionMdl.BasicContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["BasicContribution"]);
                                _MtrVContributionMdl.PEV = Convert.ToDecimal(_tblSqla5A.Rows[i]["PEV"]);
                                _MtrVContributionMdl.BeforePEV = Convert.ToDecimal(_tblSqla5A.Rows[i]["BeforePEV"]);
                                _MtrVContributionMdl.TerrorContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["TerrorContribution"]);
                                _MtrVContributionMdl.RiskTxnID = Convert.ToInt32(_tblSqla5A.Rows[i]["RiskTxnID"]);
                                _MtrVContributionMdl.PerDayContribution = Convert.ToInt32(_tblSqla5A.Rows[i]["PerDayContribution"]);
                                _MtrVContributionMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla5A.Rows[i]["OpolTxnSysID"]);

                            }


                        }


                        else
                        {

                        }
                    }

                    else
                    {
                        //Get values From InsContribution
                        SqlConnection _conSql5 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        DataTable _tblSqla5 = new DataTable();
                        // MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
                        List<MtrVContributionMdl> _MtrVContributionMdlList = new List<MtrVContributionMdl>();

                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                        {
                            SqlCommand command =
                                new SqlCommand("SELECT *  FROM InsContribution Where  TxnSysID = @TxnSysID", conn);

                            command.Parameters.Add(new SqlParameter("@TxnSysID", ConTxnID));

                            SqlDataAdapter _adpSql5 = new SqlDataAdapter(command);


                            _adpSql5.Fill(_tblSqla5);
                        }



                        if (_tblSqla5.Rows.Count > 0)
                        {
                            _MtrVContributionMdl = new MtrVContributionMdl();
                            for (int i = 0; i < _tblSqla5.Rows.Count; i++)
                            {

                                _MtrVContributionMdl.TxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["TxnSysID"]);
                                _MtrVContributionMdl.TxnSysDate = Convert.ToDateTime(_tblSqla5.Rows[i]["TxnSysDate"]);
                                _MtrVContributionMdl.UserCode = Convert.ToInt32(_tblSqla5.Rows[i]["UserCode"]);
                                _MtrVContributionMdl.SumCovered = Convert.ToInt32(_tblSqla5.Rows[i]["SumCovered"]);
                                _MtrVContributionMdl.Rate = Convert.ToDecimal(_tblSqla5.Rows[i]["Rate"]);
                                _MtrVContributionMdl.NetContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["NetContribution"]);
                                _MtrVContributionMdl.GrossContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["GrossContribution"]);
                                _MtrVContributionMdl.FIF = Convert.ToDecimal(_tblSqla5.Rows[i]["FIF"]);
                                _MtrVContributionMdl.FED = Convert.ToDecimal(_tblSqla5.Rows[i]["FED"]);
                                _MtrVContributionMdl.Stamp = Convert.ToDecimal(_tblSqla5.Rows[i]["Stamp"]);
                                _MtrVContributionMdl.BasicContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["BasicContribution"]);
                                _MtrVContributionMdl.PEV = Convert.ToDecimal(_tblSqla5.Rows[i]["PEV"]);
                                _MtrVContributionMdl.BeforePEV = Convert.ToDecimal(_tblSqla5.Rows[i]["BeforePEV"]);
                                _MtrVContributionMdl.TerrorContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["TerrorContribution"]);
                                _MtrVContributionMdl.RiskTxnID = Convert.ToInt32(_tblSqla5.Rows[i]["RiskTxnID"]);
                                _MtrVContributionMdl.PerDayContribution = Convert.ToInt32(_tblSqla5.Rows[i]["PerDayContribution"]);
                                _MtrVContributionMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["OpolTxnSysID"]);

                            }


                        }


                        else
                        {

                        }
                    }


                    //Insert values in to InsUpdateContribution
                    SqlConnection _conSql6 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql6 = new StringBuilder();
                    SqlCommand _cmdSql6;

                    _sbSql6.AppendLine("INSERT INTO InsUpdateContribution(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql6.AppendLine("TxnSysDate,");
                    _sbSql6.AppendLine("UserCode,");
                    _sbSql6.AppendLine("SumCovered,");
                    _sbSql6.AppendLine("Rate,");
                    _sbSql6.AppendLine("NetContribution,");
                    _sbSql6.AppendLine("GrossContribution,");
                    _sbSql6.AppendLine("FIF,");
                    _sbSql6.AppendLine("FED,");
                    _sbSql6.AppendLine("Stamp,");
                    _sbSql6.AppendLine("BasicContribution,");
                    _sbSql6.AppendLine("PEV,");
                    _sbSql6.AppendLine("BeforePEV,");
                    _sbSql6.AppendLine("TerrorContribution,");
                    _sbSql6.AppendLine("RiskTxnID,");
                    _sbSql6.AppendLine("OpolTxnSysID,");
                    _sbSql6.AppendLine("PerDayContribution)");

                    _sbSql6.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                    //_sbSql.AppendLine("@TxnSysID,");
                    _sbSql6.AppendLine("@TxnSysDate,");
                    _sbSql6.AppendLine("@UserCode,");
                    _sbSql6.AppendLine("@SumCovered,");
                    _sbSql6.AppendLine("@Rate,");
                    _sbSql6.AppendLine("@NetContribution,");
                    _sbSql6.AppendLine("@GrossContribution,");
                    _sbSql6.AppendLine("@FIF,");
                    _sbSql6.AppendLine("@FED,");
                    _sbSql6.AppendLine("@Stamp,");
                    _sbSql6.AppendLine("@BasicContribution,");
                    _sbSql6.AppendLine("@PEV,");
                    _sbSql6.AppendLine("@BeforePEV,");
                    _sbSql6.AppendLine("@TerrorContribution,");
                    _sbSql6.AppendLine("@RiskTxnID,");
                    _sbSql6.AppendLine("@OpolTxnSysID,");
                    _sbSql6.AppendLine("@PerDayContribution)");

                    _cmdSql6 = new SqlCommand(_sbSql6.ToString(), _conSql6);

                    _cmdSql6.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql6.Parameters.AddWithValue("@RiskTxnID", _TxnSysId2);

                    decimal _SumCovered = _VehicleDetailMdl.ParticipantValue;
                    decimal _RateV = _VehicleDetailMdl1.Rate;


                   

                    decimal NetContribution = (_SumCovered * (_RateV / 100));
                    decimal GrossContribution = (NetContribution - stamp) / (((_MtrVContributionMdl.FED + _MtrVContributionMdl.FIF) / 100) + 1);

                  

                    decimal BeforePEV = (GrossContribution - _MtrVContributionMdl.TerrorContribution);
                    decimal PEV = (BeforePEV - _MtrVContributionMdl.BasicContribution);


                    //To get Tenure
                    DataTable _tbl8 = new DataTable();
                  //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = "+InsPolicyTxnID, conn);

                        

                        SqlDataAdapter _adpSql8 = new SqlDataAdapter(command);


                        _adpSql8.Fill(_tbl8);
                    }

                    // _adpSql.Fill(_tbl);

                    if (_tbl8.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tbl8.Rows.Count; i++)
                        {
                            _MtrVContributionMdl1 = new MtrVContributionMdl();
                            _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl8.Rows[i]["tenure"]);

                        }


                    }
                    else
                    {
                        _MtrVContributionMdl1.Tenure = 1;
                    }


                    decimal PerDayContribution = GrossContribution / _MtrVContributionMdl1.Tenure;


                    _cmdSql6.Parameters.AddWithValue("@SumCovered", _SumCovered);

                    int _userCode1 = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl.UserCode);

                    _cmdSql6.Parameters.AddWithValue("@UserCode", _userCode);

                    _cmdSql6.Parameters.AddWithValue("@Rate", _RateV);
                    _cmdSql6.Parameters.AddWithValue("@NetContribution", NetContribution);
                    _cmdSql6.Parameters.AddWithValue("@GrossContribution", GrossContribution);
                    _cmdSql6.Parameters.AddWithValue("@FIF", _MtrVContributionMdl.FIF);
                    _cmdSql6.Parameters.AddWithValue("@FED", _MtrVContributionMdl.FED);
                    _cmdSql6.Parameters.AddWithValue("@Stamp", stamp);
                    _cmdSql6.Parameters.AddWithValue("@BasicContribution", _MtrVContributionMdl.BasicContribution);
                    _cmdSql6.Parameters.AddWithValue("@PEV", PEV);
                    _cmdSql6.Parameters.AddWithValue("@BeforePEV", BeforePEV);
                    _cmdSql6.Parameters.AddWithValue("@TerrorContribution", _MtrVContributionMdl.TerrorContribution);
                    _cmdSql6.Parameters.AddWithValue("@PerDayContribution", PerDayContribution);
                   
                    _cmdSql6.Parameters.AddWithValue("@OpolTxnSysID", _MtrVContributionMdl.OpolTxnSysID);

                    //Difference of added value and previous value
                    diff = NetContribution - _MtrVContributionMdl.NetContribution;


                    int _TxnSysId3;
                    _conSql6.Open();
                    _TxnSysId3 = (Int32)_cmdSql6.ExecuteScalar();
                    _conSql6.Close();

                    _MtrVContributionMdl1.TxnSysID = _TxnSysId3;
                    //  _ProductConditionsSetupMdl.ConditionShText = GetConditionByCode(_ProductConditionsSetupMdl.Condition);
                    _MtrVContributionMdl1.IsValidTxn = true;


                    //To update Contribution of Vehicle Certificate
                    SqlConnection _conSql7 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql7 = new StringBuilder();
                    SqlCommand _cmdSql7;

                    _sbSql7.AppendLine("Update  MtrVehicleDetails SET");
                    _sbSql7.AppendLine("Contribution= @Contribution");
                    _sbSql7.AppendLine("WHERE TxnSysId= "+_TxnSysId2);

                    _cmdSql7 = new SqlCommand(_sbSql7.ToString(), _conSql7);

                    
                    _cmdSql7.Parameters.AddWithValue("@Contribution", NetContribution);

                    _conSql7.Open();
                    _cmdSql7.ExecuteNonQuery();
                    _conSql7.Close();

                    //Insert values in to InsContribution
                    SqlConnection _conSql10 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql10 = new StringBuilder();
                    SqlCommand _cmdSql10;

                    _sbSql10.AppendLine("INSERT INTO InsContribution(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql10.AppendLine("TxnSysDate,");
                    _sbSql10.AppendLine("UserCode,");
                    _sbSql10.AppendLine("SumCovered,");
                    _sbSql10.AppendLine("Rate,");
                    _sbSql10.AppendLine("NetContribution,");
                    _sbSql10.AppendLine("GrossContribution,");
                    _sbSql10.AppendLine("FIF,");
                    _sbSql10.AppendLine("FED,");
                    _sbSql10.AppendLine("Stamp,");
                    _sbSql10.AppendLine("BasicContribution,");
                    _sbSql10.AppendLine("PEV,");
                    _sbSql10.AppendLine("BeforePEV,");
                    _sbSql10.AppendLine("TerrorContribution,");
                    _sbSql10.AppendLine("RiskTxnID,");
                    _sbSql10.AppendLine("OpolTxnSysID,");
                    _sbSql10.AppendLine("PerDayContribution)");

                    _sbSql10.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                    //_sbSql.AppendLine("@TxnSysID,");
                    _sbSql10.AppendLine("@TxnSysDate,");
                    _sbSql10.AppendLine("@UserCode,");
                    _sbSql10.AppendLine("@SumCovered,");
                    _sbSql10.AppendLine("@Rate,");
                    _sbSql10.AppendLine("@NetContribution,");
                    _sbSql10.AppendLine("@GrossContribution,");
                    _sbSql10.AppendLine("@FIF,");
                    _sbSql10.AppendLine("@FED,");
                    _sbSql10.AppendLine("@Stamp,");
                    _sbSql10.AppendLine("@BasicContribution,");
                    _sbSql10.AppendLine("@PEV,");
                    _sbSql10.AppendLine("@BeforePEV,");
                    _sbSql10.AppendLine("@TerrorContribution,");
                    _sbSql10.AppendLine("@RiskTxnID,");
                    _sbSql10.AppendLine("@OpolTxnSysID,");
                    _sbSql10.AppendLine("@PerDayContribution)");

                    _cmdSql10 = new SqlCommand(_sbSql10.ToString(), _conSql10);

                    _cmdSql10.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql10.Parameters.AddWithValue("@RiskTxnID", _TxnSysId2);

                    decimal _SumCovered1 = diff;
                    decimal _RateV1 = _VehicleDetailMdl1.Rate;




                    decimal NetContribution1 = NetContribution -  _MtrVContributionMdl.NetContribution;
                    decimal GrossContribution1 = GrossContribution - _MtrVContributionMdl.GrossContribution;



                    decimal BeforePEV1 = ( _MtrVContributionMdl.TerrorContribution - GrossContribution1);
                    decimal PEV1 = (BeforePEV1 - _MtrVContributionMdl.BasicContribution);


                    //To get Tenure
                    DataTable _tbl10 = new DataTable();
                    //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = " + InsPolicyTxnID, conn);



                        SqlDataAdapter _adpSql10 = new SqlDataAdapter(command);


                        _adpSql10.Fill(_tbl10);
                    }

                    // _adpSql.Fill(_tbl);

                    if (_tbl10.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tbl10.Rows.Count; i++)
                        {
                            _MtrVContributionMdl1 = new MtrVContributionMdl();
                            _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl10.Rows[i]["tenure"]);

                        }


                    }
                    else
                    {
                        _MtrVContributionMdl1.Tenure = 1;
                    }


                    decimal PerDayContribution1 = GrossContribution1 / _MtrVContributionMdl1.Tenure;


                    _cmdSql10.Parameters.AddWithValue("@SumCovered", _SumCovered - _MtrVContributionMdl.SumCovered);

                    int _userCode2 = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl.UserCode);

                    _cmdSql10.Parameters.AddWithValue("@UserCode", _userCode);

                    _cmdSql10.Parameters.AddWithValue("@Rate", _RateV1);
                    _cmdSql10.Parameters.AddWithValue("@NetContribution", NetContribution - _MtrVContributionMdl.NetContribution );
                    _cmdSql10.Parameters.AddWithValue("@GrossContribution", GrossContribution - _MtrVContributionMdl.GrossContribution );
                    _cmdSql10.Parameters.AddWithValue("@FIF", _MtrVContributionMdl.FIF);
                    _cmdSql10.Parameters.AddWithValue("@FED", _MtrVContributionMdl.FED);
                    _cmdSql10.Parameters.AddWithValue("@Stamp", stamp);
                    _cmdSql10.Parameters.AddWithValue("@BasicContribution", _MtrVContributionMdl.BasicContribution);
                    _cmdSql10.Parameters.AddWithValue("@PEV", PEV1);
                    _cmdSql10.Parameters.AddWithValue("@BeforePEV", BeforePEV - _MtrVContributionMdl.BeforePEV );
                    _cmdSql10.Parameters.AddWithValue("@TerrorContribution", _MtrVContributionMdl.TerrorContribution);
                    _cmdSql10.Parameters.AddWithValue("@PerDayContribution", PerDayContribution1);

                    _cmdSql10.Parameters.AddWithValue("@OpolTxnSysID", _MtrVContributionMdl.OpolTxnSysID);

                    int _TxnSysId4;
                    _conSql10.Open();
                    _TxnSysId4 = (Int32)_cmdSql10.ExecuteScalar();
                    _conSql10.Close();

                    _MtrVContributionMdl1.TxnSysID = _TxnSysId4;
                   
                    _MtrVContributionMdl1.IsValidTxn = true;


                    if (_VehicleDetailMdl.InsuranceTypeCode == 2 || _VehicleDetailMdl.InsuranceTypeCode == 3)
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
                                _InsCoInsuranceA1.PEV = Decimal.Round(Convert.ToDecimal(_tblSqlaA1.Rows[i]["PEV"]),  MidpointRounding.ToEven);
                                _InsCoInsuranceA1.BeforePEV = Decimal.Round(Convert.ToDecimal(_tblSqlaA1.Rows[i]["BeforePEV"]),  MidpointRounding.ToEven);
                                _InsCoInsuranceA1.Stamp = Convert.ToDecimal(_tblSqlaA1.Rows[i]["Stamp"]);
                                _InsCoInsuranceA1.OpolTxnSysID = Convert.ToInt32(_tblSqlaA1.Rows[i]["OpolTxnSysID"]);
                                _InsCoInsuranceA1.Rate = Convert.ToDecimal(_tblSqlaA1.Rows[i]["Rate"]);
                                _InsCoInsuranceA1.BasicContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["BasicContribution"]);
                                _InsCoInsuranceA1.TerrorContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["TerrorContribution "]);


                                _InsCoInsuranceListA1.Add(_InsCoInsuranceA1);
                            }

                            //Insert InTo CoInsurance for Endorsement
                            SqlConnection _conSqlA2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                            StringBuilder _sbSqlA2 = new StringBuilder();
                            SqlCommand _cmdSqlA2;
                            InsCoInsurance[] ConInsList = _InsCoInsuranceListA1.ToArray();


                            for(int i = 0; i< ConInsList.Length; i++)
                            {
                                _sbSqlA2 = new StringBuilder();

                                decimal SumCovered = 0;
                                SumCovered = _SumCovered - _MtrVContributionMdl.SumCovered;
                                decimal NetC = 0;
                                NetC = NetContribution - _MtrVContributionMdl.NetContribution;
                                decimal GrossC = 0;
                                GrossC = GrossContribution - _MtrVContributionMdl.GrossContribution;


                                //To get Tenure
                                DataTable _tbl = new DataTable();
                                InsCoInsurance _InsCoInsuranceTe = new InsCoInsurance();

                                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                                {
                                    SqlCommand command =
                                        new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip INNER JOIN MtrVehicleDetails mvd ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE mvd.TxnSysID = @TxnSysID", conn);

                                    command.Parameters.Add(new SqlParameter("@TxnSysID", _VehicleDetailMdl1.TxnSysID));

                                    SqlDataAdapter _adpSqlTe = new SqlDataAdapter(command);


                                    _adpSqlTe.Fill(_tbl);
                                }

                                // _adpSql.Fill(_tbl);

                                if (_tbl.Rows.Count > 0)
                                {
                                    for (int j = 0; j < _tbl.Rows.Count; j++)
                                    {
                                        _InsCoInsuranceTe = new InsCoInsurance();
                                        _InsCoInsuranceTe.Tenure = Convert.ToInt32(_tbl.Rows[j]["tenure"]);

                                    }


                                }
                                else
                                {
                                    _InsCoInsuranceTe.Tenure = 1;
                                }


                                int SumCo = 0;
                                 SumCo = Convert.ToInt32(SumCovered * (ConInsList[i].CoInsuranceShare / 100));
                                decimal NetCo = 0;
                                  NetCo = NetC * (ConInsList[i].CoInsuranceShare / 100);
                                decimal GrossCo = 0;
                                GrossCo = GrossC * (ConInsList[i].CoInsuranceShare / 100);
                                decimal PerDayCo = 0;
                                PerDayCo = GrossCo / _InsCoInsuranceTe.Tenure;


                               


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
                                _sbSqlA2.AppendLine("@RiskTxnID,");
                                _sbSqlA2.AppendLine("@OpolTxnSysID,");
                                _sbSqlA2.AppendLine("@PerDayContribution,");
                                _sbSqlA2.AppendLine("@CoInsuranceCode,");
                                _sbSqlA2.AppendLine("@CoInsuranceShare)");


                                _cmdSqlA2 = new SqlCommand(_sbSqlA2.ToString(), _conSqlA2);

                                _cmdSqlA2.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                                _cmdSqlA2.Parameters.AddWithValue("@RiskTxnID", _TxnSysId2);
                                _cmdSqlA2.Parameters.AddWithValue("@SumCovered", SumCo);

                                int _userCodeA2 = GlobalDataLayer.GetUserCodeById(ConInsList[i].UserCode);

                                _cmdSqlA2.Parameters.AddWithValue("@UserCode", _userCodeA2);


                                _cmdSqlA2.Parameters.AddWithValue("@Rate", ConInsList[i].Rate);
                                _cmdSqlA2.Parameters.AddWithValue("@NetContribution", NetCo);
                                _cmdSqlA2.Parameters.AddWithValue("@GrossContribution", GrossCo);
                                _cmdSqlA2.Parameters.AddWithValue("@FIF", ConInsList[i].FIF);
                                _cmdSqlA2.Parameters.AddWithValue("@FED", ConInsList[i].FED);
                                _cmdSqlA2.Parameters.AddWithValue("@Stamp", stamp);
                                _cmdSqlA2.Parameters.AddWithValue("@BasicContribution", ConInsList[i].BasicContribution);
                                _cmdSqlA2.Parameters.AddWithValue("@PEV", ConInsList[i].PEV);
                                _cmdSqlA2.Parameters.AddWithValue("@BeforePEV", ConInsList[i].BeforePEV);
                                _cmdSqlA2.Parameters.AddWithValue("@TerrorContribution", ConInsList[i].TerrorContribution);
                               // _cmdSqlA2.Parameters.AddWithValue("@RiskTxnID", ConInsList[i].RiskTxnID);
                                _cmdSqlA2.Parameters.AddWithValue("@OpolTxnSysID", ConInsList[i].OpolTxnSysID);
                                _cmdSqlA2.Parameters.AddWithValue("@PerDayContribution", PerDayCo);
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

                }


                //To increase Sum Covered
                if (_EndtReasonMdl1.EndtReasonCode == 2)
                {
                    _Rate = _VehicleDetailMdl.Rate;

                    //Get Values From MtrVehicle Detail by TxnID
                    SqlConnection _conSql3 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    string _sqlString3 = "SELECT * FROM MtrVehicleDetails mvd WHERE mvd.TxnSysID =  " + _VehicleDetailMdl1.TxnSysID;

                    SqlDataAdapter _adpSql3 = new SqlDataAdapter(_sqlString3, _conSql3);
                    DataTable _tblSqla3 = new DataTable();


                    _adpSql3.Fill(_tblSqla3);

                    if (_tblSqla3.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla3.Rows.Count; i++)
                        {
                            _VehicleDetailMdl = new VehicleDetailMdl();

                            _VehicleDetailMdl.TxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["TxnSysID"]);
                            _VehicleDetailMdl.TxnSysDate = Convert.ToDateTime(_tblSqla3.Rows[i]["TxnSysDate"]);
                            _VehicleDetailMdl.UserCode = Convert.ToInt32(_tblSqla3.Rows[i]["UserCode"]);
                            _VehicleDetailMdl.SerialNo = Convert.ToInt32(_tblSqla3.Rows[i]["SerialNo"].ToString());
                            _VehicleDetailMdl.VehicleCode = Convert.ToInt32(_tblSqla3.Rows[i]["VehicleCode"].ToString());
                            _VehicleDetailMdl.VehicleModel = Convert.ToInt32(_tblSqla3.Rows[i]["VehicleModel"].ToString());
                            _VehicleDetailMdl.UpdatedValue = Convert.ToDecimal(_tblSqla3.Rows[i]["UpdatedValue"]);
                            _VehicleDetailMdl.PreviousValue = Convert.ToDecimal(_tblSqla3.Rows[i]["PreviousValue"]);
                            _VehicleDetailMdl.Mileage = Convert.ToInt32(_tblSqla3.Rows[i]["Mileage"].ToString());
                            _VehicleDetailMdl.ParticipantValue = Convert.ToDecimal(_tblSqla3.Rows[i]["ParticipantValue"]);
                            _VehicleDetailMdl.ColorCode = Convert.ToInt32(_tblSqla3.Rows[i]["ColorCode"].ToString());
                            _VehicleDetailMdl.ParticipantName = _tblSqla3.Rows[i]["ParticipantName"].ToString();
                            _VehicleDetailMdl.ParticipantAddress = _tblSqla3.Rows[i]["ParticipantAddress"].ToString();
                            // _VehicleDetailMdl.ModelNumber = Convert.ToInt32(_tblSqla.Rows[i]["ModelNumber"]);
                            _VehicleDetailMdl.RegistrationNumber = _tblSqla3.Rows[i]["RegistrationNumber"].ToString();
                            _VehicleDetailMdl.CityCode = _tblSqla3.Rows[i]["CityCode"].ToString();
                            _VehicleDetailMdl.EngineNumber = _tblSqla3.Rows[i]["EngineNumber"].ToString();
                            _VehicleDetailMdl.AreaCode = Convert.ToInt32(_tblSqla3.Rows[i]["AreaCode"].ToString());
                            _VehicleDetailMdl.ChasisNumber = _tblSqla3.Rows[i]["ChasisNumber"].ToString();
                            _VehicleDetailMdl.Remarks = _tblSqla3.Rows[i]["Remarks"].ToString();
                            _VehicleDetailMdl.PODate = Convert.ToDateTime(_tblSqla3.Rows[i]["PODate"]);
                            _VehicleDetailMdl.PONumber =(_tblSqla3.Rows[i]["PONumber"].ToString());
                            _VehicleDetailMdl.CNICNumber = _tblSqla3.Rows[i]["CNICNumber"].ToString();
                            _VehicleDetailMdl.Tenure = _tblSqla3.Rows[i]["Tenure"].ToString();
                            _VehicleDetailMdl.BirthDate = Convert.ToDateTime(_tblSqla3.Rows[i]["BirthDate"]);
                            _VehicleDetailMdl.Gender = _tblSqla3.Rows[i]["Gender"].ToString();
                            _VehicleDetailMdl.VehicleType = _tblSqla3.Rows[i]["VehicleType"].ToString();
                            _VehicleDetailMdl.VEODCode = Convert.ToInt32(_tblSqla3.Rows[i]["VEODCode"]);
                            _VehicleDetailMdl.CertTypeCode = _tblSqla3.Rows[i]["CertTypeCode"].ToString();
                            _VehicleDetailMdl.Rate = Convert.ToDecimal(_tblSqla3.Rows[i]["Rate"]);
                            _VehicleDetailMdl.Contribution = Convert.ToInt32(_tblSqla3.Rows[i]["Contribution"]);
                            _VehicleDetailMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["ParentTxnSysID"]);
                            _VehicleDetailMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["OpolTxnSysID"]);

                            _VehicleDetailMdl.VEODName = GlobalDataLayer.GetVEODNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["VEODCode"]));
                            _VehicleDetailMdl.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_tblSqla3.Rows[i]["VehicleType"].ToString());

                            _VehicleDetailMdl.InsuranceTypeCode = Convert.ToInt32(_tblSqla3.Rows[i]["InsuranceTypeCode"]);
                            _VehicleDetailMdl.IsActive = Convert.ToBoolean(_tblSqla3.Rows[i]["IsActive"]);
                            _VehicleDetailMdl.IsCanceled = Convert.ToBoolean(_tblSqla3.Rows[i]["IsCanceled"]);
                            _VehicleDetailMdl.CommisionRate = Convert.ToDecimal(_tblSqla3.Rows[i]["CommisionRate"]);
                            _VehicleDetailMdl.MobileNumber = _tblSqla3.Rows[i]["MobileNumber"].ToString();
                            _VehicleDetailMdl.ResNumber = _tblSqla3.Rows[i]["ResNumber"].ToString();
                            _VehicleDetailMdl.OfficeNumber = _tblSqla3.Rows[i]["OfficeNumber"].ToString();

                            _VehicleDetailMdl.EmailAddress = _tblSqla3.Rows[i]["EmailAddress"].ToString();
                            _VehicleDetailMdl.Deductible = Convert.ToDecimal(_tblSqla3.Rows[i]["Deductible"]);

                            _VehicleDetailMdl.ContractMatDate = Convert.ToDateTime(_tblSqla3.Rows[i]["ContractMatDate"]);

                            _VehicleDetailMdl.RatingFactor = _tblSqla3.Rows[i]["RatingFactor"].ToString();
                            _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_tblSqla3.Rows[i]["RatingFactor"].ToString());

                            _VehicleDetailMdl.GenderName = GlobalDataLayer.GetGenderNameByCode(_tblSqla3.Rows[i]["Gender"].ToString());
                            _VehicleDetailMdl.CityName = GlobalDataLayer.GetCityNameByCode(_tblSqla3.Rows[i]["CityCode"].ToString());
                            _VehicleDetailMdl.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["ColorCode"].ToString()));
                            _VehicleDetailMdl.VehicleName = GlobalDataLayer.GetVehicleNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["VehicleCode"].ToString()));
                            _VehicleDetailMdl.AreaName = GlobalDataLayer.GetAreaNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["AreaCode"].ToString()));
                            _VehicleDetailMdl.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_tblSqla3.Rows[i]["CertTypeCode"].ToString());
                            _VehicleDetailMdl.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["InsuranceTypeCode"]));

                            _VehicleDetailMdl.total = GlobalDataLayer.calculate(_VehicleDetailMdl);


                            _VehicleDetailMdlList.Add(_VehicleDetailMdl);


                        }
                    }


                    //Insert Into Vehicle Details
                    SqlConnection _conSql4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql4 = new StringBuilder();
                    SqlCommand _cmdSql4;
                    int _SerialNumber1 = GetSerialNo1(_VehicleDetailMdl);


                    _sbSql4.AppendLine("INSERT INTO MtrVehicleDetails(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql4.AppendLine("TxnSysDate,");
                    _sbSql4.AppendLine("UserCode,");
                    _sbSql4.AppendLine("SerialNo,");
                    _sbSql4.AppendLine("VehicleCode,");
                    _sbSql4.AppendLine("VehicleModel,");
                    _sbSql4.AppendLine("UpdatedValue,");
                    _sbSql4.AppendLine("PreviousValue,");
                    _sbSql4.AppendLine("Mileage,");
                    _sbSql4.AppendLine("ParticipantValue,");
                    _sbSql4.AppendLine("ColorCode,");
                    _sbSql4.AppendLine("ParticipantName,");
                    _sbSql4.AppendLine("ParticipantAddress,");
                    // _sbSql.AppendLine("ModelNumber,");
                    _sbSql4.AppendLine("RegistrationNumber,");
                    _sbSql4.AppendLine("CityCode,");
                    _sbSql4.AppendLine("EngineNumber,");
                    _sbSql4.AppendLine("AreaCode,");
                    _sbSql4.AppendLine("ChasisNumber,");
                    _sbSql4.AppendLine("Remarks,");
                    _sbSql4.AppendLine("PODate,");
                    _sbSql4.AppendLine("PONumber,");
                    _sbSql4.AppendLine("CNICNumber,");
                    _sbSql4.AppendLine("Tenure,");
                    _sbSql4.AppendLine("BirthDate,");
                    _sbSql4.AppendLine("Gender,");
                    _sbSql4.AppendLine("VehicleType,");
                    _sbSql4.AppendLine("VEODCode,");
                    _sbSql4.AppendLine("CertTypeCode,");
                    _sbSql4.AppendLine("Rate,");
                    _sbSql4.AppendLine("ParentTxnSysID,");
                    _sbSql4.AppendLine("OpolTxnSysID,");
                    _sbSql4.AppendLine("InsuranceTypeCode,");
                    _sbSql4.AppendLine("CommisionRate,");
                    _sbSql4.AppendLine("MobileNumber,");
                    _sbSql4.AppendLine("ResNumber,");
                    _sbSql4.AppendLine("OfficeNumber,");
                    _sbSql4.AppendLine("EmailAddress,");
                    _sbSql4.AppendLine("Deductible,");
                    _sbSql4.AppendLine("ContractMatDate,");
                    _sbSql4.AppendLine("RatingFactor,");
                    _sbSql4.AppendLine("Contribution)");


                    _sbSql4.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                    // _sbSql.AppendLine("@TxnSysID,");
                    _sbSql4.AppendLine("@TxnSysDate,");
                    _sbSql4.AppendLine("@UserCode,");
                    _sbSql4.AppendLine("@SerialNo,");
                    _sbSql4.AppendLine("@VehicleCode,");
                    _sbSql4.AppendLine("@VehicleModel,");
                    _sbSql4.AppendLine("@UpdatedValue,");
                    _sbSql4.AppendLine("@PreviousValue,");
                    _sbSql4.AppendLine("@Mileage,");
                    _sbSql4.AppendLine("@ParticipantValue,");
                    _sbSql4.AppendLine("@ColorCode,");
                    _sbSql4.AppendLine("@ParticipantName,");
                    _sbSql4.AppendLine("@ParticipantAddress,");
                    // _sbSql.AppendLine("@ModelNumber,");
                    _sbSql4.AppendLine("@RegistrationNumber,");
                    _sbSql4.AppendLine("@CityCode,");
                    _sbSql4.AppendLine("@EngineNumber,");
                    _sbSql4.AppendLine("@AreaCode,");
                    _sbSql4.AppendLine("@ChasisNumber,");
                    _sbSql4.AppendLine("@Remarks,");
                    _sbSql4.AppendLine("@PODate,");
                    _sbSql4.AppendLine("@PONumber,");
                    _sbSql4.AppendLine("@CNICNumber,");
                    _sbSql4.AppendLine("@Tenure,");
                    _sbSql4.AppendLine("@BirthDate,");
                    _sbSql4.AppendLine("@Gender,");
                    _sbSql4.AppendLine("@VehicleType,");
                    _sbSql4.AppendLine("@VEODCode,");
                    _sbSql4.AppendLine("@CertTypeCode,");
                    _sbSql4.AppendLine("@Rate,");
                    _sbSql4.AppendLine("@ParentTxnSysID,");
                    _sbSql4.AppendLine("(SELECT ip.OpolTxnSysID FROM InsPolicy ip WHERE ip.ParentTxnSysID = @ParentTxnSysID),");
                    _sbSql4.AppendLine("@InsuranceTypeCode,");
                    _sbSql4.AppendLine("@CommisionRate,");
                    _sbSql4.AppendLine("@MobileNumber,");
                    _sbSql4.AppendLine("@ResNumber,");
                    _sbSql4.AppendLine("@OfficeNumber,");
                    _sbSql4.AppendLine("@EmailAddress,");
                    _sbSql4.AppendLine("@Deductible,");
                    _sbSql4.AppendLine("@ContractMatDate,");
                    _sbSql4.AppendLine("@RatingFactor,");
                    _sbSql4.AppendLine("@Contribution)");


                    _cmdSql4 = new SqlCommand(_sbSql4.ToString(), _conSql4);




                    DateTime da = DateTime.Now;
                    da.ToString("MM-dd-yyyy h:mm tt");

                    _cmdSql4.Parameters.AddWithValue("@TxnSysDate", Convert.ToDateTime(da));
                    int _userCode = GlobalDataLayer.GetUserCodeById(_VehicleDetailMdl.UserCode);
                    _cmdSql4.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql4.Parameters.AddWithValue("@ParentTxnSysID", _TxnSysId);

                    _cmdSql4.Parameters.AddWithValue("@RatingFactor", _VehicleDetailMdl.RatingFactor);
                    _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_VehicleDetailMdl.RatingFactor);


                    _cmdSql4.Parameters.AddWithValue("@SerialNo", _SerialNumber1);
                    _cmdSql4.Parameters.AddWithValue("@VehicleCode", _VehicleDetailMdl.VehicleCode);
                    _cmdSql4.Parameters.AddWithValue("@VehicleModel", _VehicleDetailMdl.VehicleModel);
                    _cmdSql4.Parameters.AddWithValue("@UpdatedValue", _VehicleDetailMdl.UpdatedValue);
                    _cmdSql4.Parameters.AddWithValue("@PreviousValue", _VehicleDetailMdl.PreviousValue);
                    _cmdSql4.Parameters.AddWithValue("@Mileage", _VehicleDetailMdl.Mileage);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantValue", _VehicleDetailMdl1.ParticipantValue);
                    _cmdSql4.Parameters.AddWithValue("@ColorCode", _VehicleDetailMdl.ColorCode);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantName", _VehicleDetailMdl.ParticipantName);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantAddress", _VehicleDetailMdl.ParticipantAddress);
                    // _cmdSql.Parameters.AddWithValue("@ModelNumber", _VehicleDetailMdl.ModelNumber);
                    _cmdSql4.Parameters.AddWithValue("@RegistrationNumber", _VehicleDetailMdl.RegistrationNumber);
                    _cmdSql4.Parameters.AddWithValue("@CityCode", _VehicleDetailMdl.CityCode);
                    _cmdSql4.Parameters.AddWithValue("@EngineNumber", _VehicleDetailMdl.EngineNumber);
                    _cmdSql4.Parameters.AddWithValue("@AreaCode", _VehicleDetailMdl.AreaCode);
                    _cmdSql4.Parameters.AddWithValue("@ChasisNumber", _VehicleDetailMdl.ChasisNumber);

                    //Add Remarks for addition
                    _cmdSql4.Parameters.AddWithValue("@Remarks", _VehicleDetailMdl1.Remarks ?? DBNull.Value.ToString());

                    _cmdSql4.Parameters.AddWithValue("@PODate", _VehicleDetailMdl.PODate);
                    _cmdSql4.Parameters.AddWithValue("@PONumber", _VehicleDetailMdl.PONumber);
                    _cmdSql4.Parameters.AddWithValue("@CNICNumber", _VehicleDetailMdl.CNICNumber);
                    _cmdSql4.Parameters.AddWithValue("@Tenure", _VehicleDetailMdl.Tenure);
                    _cmdSql4.Parameters.AddWithValue("@BirthDate", _VehicleDetailMdl.BirthDate);
                    _cmdSql4.Parameters.AddWithValue("@Gender", _VehicleDetailMdl.Gender);
                    _cmdSql4.Parameters.AddWithValue("@VehicleType", _VehicleDetailMdl.VehicleType);
                    _cmdSql4.Parameters.AddWithValue("@VEODCode", _VehicleDetailMdl.VEODCode);
                    _cmdSql4.Parameters.AddWithValue("@CertTypeCode", _VehicleDetailMdl.CertTypeCode);
                    _cmdSql4.Parameters.AddWithValue("@Rate", _VehicleDetailMdl.Rate);
                    _cmdSql4.Parameters.AddWithValue("@InsuranceTypeCode", _VehicleDetailMdl.InsuranceTypeCode);
                    _cmdSql4.Parameters.AddWithValue("@Contribution", _VehicleDetailMdl.Contribution);
                    _cmdSql4.Parameters.AddWithValue("@CommisionRate", _VehicleDetailMdl.CommisionRate);
                    _cmdSql4.Parameters.AddWithValue("@MobileNumber", _VehicleDetailMdl.MobileNumber);
                    _cmdSql4.Parameters.AddWithValue("@ResNumber", _VehicleDetailMdl.ResNumber);
                    _cmdSql4.Parameters.AddWithValue("@OfficeNumber", _VehicleDetailMdl.OfficeNumber);

                    _cmdSql4.Parameters.AddWithValue("@EmailAddress", _VehicleDetailMdl.EmailAddress);
                    _cmdSql4.Parameters.AddWithValue("@Deductible", _VehicleDetailMdl.Deductible);
                    _cmdSql4.Parameters.AddWithValue("@ContractMatDate", _VehicleDetailMdl.ContractMatDate);



                    _VehicleDetailMdl.SerialNo = _SerialNumber;

                    _VehicleDetailMdl.TxnSysDate = DateTime.Now;

                    _VehicleDetailMdl.VEODName = GlobalDataLayer.GetVEODNameByCode(_VehicleDetailMdl.VEODCode);
                    _VehicleDetailMdl.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_VehicleDetailMdl.VehicleType);
                    _VehicleDetailMdl.GenderName = GlobalDataLayer.GetGenderNameByCode(_VehicleDetailMdl.Gender);
                    _VehicleDetailMdl.CityName = GlobalDataLayer.GetCityNameByCode(_VehicleDetailMdl.CityCode);
                    _VehicleDetailMdl.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(_VehicleDetailMdl.ColorCode);
                    _VehicleDetailMdl.VehicleName = GlobalDataLayer.GetVehicleNameByCode(_VehicleDetailMdl.VehicleCode);
                    _VehicleDetailMdl.AreaName = GlobalDataLayer.GetAreaNameByCode(_VehicleDetailMdl.AreaCode);
                    _VehicleDetailMdl.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_VehicleDetailMdl.CertTypeCode);
                    _VehicleDetailMdl.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(_VehicleDetailMdl.InsuranceTypeCode);


                    _VehicleDetailMdl.total = GlobalDataLayer.calculate(_VehicleDetailMdl);

                    int _TxnSysId2;
                    _conSql4.Open();
                    _TxnSysId2 = (Int32)_cmdSql4.ExecuteScalar();
                    _conSql4.Close();
                    _VehicleDetailMdl.IsValidTxn = true;


                    //For Second Endorsemnt Get Values of Contribution from UpdateContribution
                    if (_MtrInsPolicyMdl.EndoSerial > 0)
                    {
                        //Get values From Ins Update Contribution
                        SqlConnection _conSql5A = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        DataTable _tblSqla5A = new DataTable();
                        // MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
                        List<MtrVContributionMdl> _MtrVContributionMdlListA = new List<MtrVContributionMdl>();

                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                        {
                            SqlCommand command =
                                new SqlCommand("SELECT * FROM InsUpdateContribution iuc INNER JOIN InsContribution ic ON ic.RiskTxnID = iuc.RiskTxnID WHERE ic.TxnSysID = @TxnSysID", conn);

                            command.Parameters.Add(new SqlParameter("@TxnSysID", ConTxnID));

                            SqlDataAdapter _adpSql5A = new SqlDataAdapter(command);


                            _adpSql5A.Fill(_tblSqla5A);
                        }



                        if (_tblSqla5A.Rows.Count > 0)
                        {
                            _MtrVContributionMdl = new MtrVContributionMdl();
                            for (int i = 0; i < _tblSqla5A.Rows.Count; i++)
                            {

                                _MtrVContributionMdl.TxnSysID = Convert.ToInt32(_tblSqla5A.Rows[i]["TxnSysID"]);
                                _MtrVContributionMdl.TxnSysDate = Convert.ToDateTime(_tblSqla5A.Rows[i]["TxnSysDate"]);
                                _MtrVContributionMdl.UserCode = Convert.ToInt32(_tblSqla5A.Rows[i]["UserCode"]);
                                _MtrVContributionMdl.SumCovered = Convert.ToInt32(_tblSqla5A.Rows[i]["SumCovered"]);
                                _MtrVContributionMdl.Rate = Convert.ToDecimal(_tblSqla5A.Rows[i]["Rate"]);
                                _MtrVContributionMdl.NetContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["NetContribution"]);
                                _MtrVContributionMdl.GrossContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["GrossContribution"]);
                                _MtrVContributionMdl.FIF = Convert.ToDecimal(_tblSqla5A.Rows[i]["FIF"]);
                                _MtrVContributionMdl.FED = Convert.ToDecimal(_tblSqla5A.Rows[i]["FED"]);
                                _MtrVContributionMdl.Stamp = Convert.ToDecimal(_tblSqla5A.Rows[i]["Stamp"]);
                                _MtrVContributionMdl.BasicContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["BasicContribution"]);
                                _MtrVContributionMdl.PEV = Convert.ToDecimal(_tblSqla5A.Rows[i]["PEV"]);
                                _MtrVContributionMdl.BeforePEV = Convert.ToDecimal(_tblSqla5A.Rows[i]["BeforePEV"]);
                                _MtrVContributionMdl.TerrorContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["TerrorContribution"]);
                                _MtrVContributionMdl.RiskTxnID = Convert.ToInt32(_tblSqla5A.Rows[i]["RiskTxnID"]);
                                _MtrVContributionMdl.PerDayContribution = Convert.ToInt32(_tblSqla5A.Rows[i]["PerDayContribution"]);
                                _MtrVContributionMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla5A.Rows[i]["OpolTxnSysID"]);

                            }


                        }


                        else
                        {

                        }
                    }

                    else
                    {
                        //Get values From InsContribution
                        SqlConnection _conSql5 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        DataTable _tblSqla5 = new DataTable();
                        // MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
                        List<MtrVContributionMdl> _MtrVContributionMdlList = new List<MtrVContributionMdl>();

                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                        {
                            SqlCommand command =
                                new SqlCommand("SELECT *  FROM InsContribution Where  TxnSysID = @TxnSysID", conn);

                            command.Parameters.Add(new SqlParameter("@TxnSysID", ConTxnID));

                            SqlDataAdapter _adpSql5 = new SqlDataAdapter(command);


                            _adpSql5.Fill(_tblSqla5);
                        }



                        if (_tblSqla5.Rows.Count > 0)
                        {
                            _MtrVContributionMdl = new MtrVContributionMdl();
                            for (int i = 0; i < _tblSqla5.Rows.Count; i++)
                            {

                                _MtrVContributionMdl.TxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["TxnSysID"]);
                                _MtrVContributionMdl.TxnSysDate = Convert.ToDateTime(_tblSqla5.Rows[i]["TxnSysDate"]);
                                _MtrVContributionMdl.UserCode = Convert.ToInt32(_tblSqla5.Rows[i]["UserCode"]);
                                _MtrVContributionMdl.SumCovered = Convert.ToInt32(_tblSqla5.Rows[i]["SumCovered"]);
                                _MtrVContributionMdl.Rate = Convert.ToDecimal(_tblSqla5.Rows[i]["Rate"]);
                                _MtrVContributionMdl.NetContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["NetContribution"]);
                                _MtrVContributionMdl.GrossContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["GrossContribution"]);
                                _MtrVContributionMdl.FIF = Convert.ToDecimal(_tblSqla5.Rows[i]["FIF"]);
                                _MtrVContributionMdl.FED = Convert.ToDecimal(_tblSqla5.Rows[i]["FED"]);
                                _MtrVContributionMdl.Stamp = Convert.ToDecimal(_tblSqla5.Rows[i]["Stamp"]);
                                _MtrVContributionMdl.BasicContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["BasicContribution"]);
                                _MtrVContributionMdl.PEV = Convert.ToDecimal(_tblSqla5.Rows[i]["PEV"]);
                                _MtrVContributionMdl.BeforePEV = Convert.ToDecimal(_tblSqla5.Rows[i]["BeforePEV"]);
                                _MtrVContributionMdl.TerrorContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["TerrorContribution"]);
                                _MtrVContributionMdl.RiskTxnID = Convert.ToInt32(_tblSqla5.Rows[i]["RiskTxnID"]);
                                _MtrVContributionMdl.PerDayContribution = Convert.ToInt32(_tblSqla5.Rows[i]["PerDayContribution"]);
                                _MtrVContributionMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["OpolTxnSysID"]);

                            }


                        }


                        else
                        {

                        }
                    }


                    //Insert values in to InsUpdateContribution
                    SqlConnection _conSql6 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql6 = new StringBuilder();
                    SqlCommand _cmdSql6;

                    _sbSql6.AppendLine("INSERT INTO InsUpdateContribution(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql6.AppendLine("TxnSysDate,");
                    _sbSql6.AppendLine("UserCode,");
                    _sbSql6.AppendLine("SumCovered,");
                    _sbSql6.AppendLine("Rate,");
                    _sbSql6.AppendLine("NetContribution,");
                    _sbSql6.AppendLine("GrossContribution,");
                    _sbSql6.AppendLine("FIF,");
                    _sbSql6.AppendLine("FED,");
                    _sbSql6.AppendLine("Stamp,");
                    _sbSql6.AppendLine("BasicContribution,");
                    _sbSql6.AppendLine("PEV,");
                    _sbSql6.AppendLine("BeforePEV,");
                    _sbSql6.AppendLine("TerrorContribution,");
                    _sbSql6.AppendLine("RiskTxnID,");
                    _sbSql6.AppendLine("OpolTxnSysID,");
                    _sbSql6.AppendLine("PerDayContribution)");

                    _sbSql6.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                    //_sbSql.AppendLine("@TxnSysID,");
                    _sbSql6.AppendLine("@TxnSysDate,");
                    _sbSql6.AppendLine("@UserCode,");
                    _sbSql6.AppendLine("@SumCovered,");
                    _sbSql6.AppendLine("@Rate,");
                    _sbSql6.AppendLine("@NetContribution,");
                    _sbSql6.AppendLine("@GrossContribution,");
                    _sbSql6.AppendLine("@FIF,");
                    _sbSql6.AppendLine("@FED,");
                    _sbSql6.AppendLine("@Stamp,");
                    _sbSql6.AppendLine("@BasicContribution,");
                    _sbSql6.AppendLine("@PEV,");
                    _sbSql6.AppendLine("@BeforePEV,");
                    _sbSql6.AppendLine("@TerrorContribution,");
                    _sbSql6.AppendLine("@RiskTxnID,");
                    _sbSql6.AppendLine("@OpolTxnSysID,");
                    _sbSql6.AppendLine("@PerDayContribution)");

                    _cmdSql6 = new SqlCommand(_sbSql6.ToString(), _conSql6);

                    _cmdSql6.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql6.Parameters.AddWithValue("@RiskTxnID", _TxnSysId2);

                    decimal _SumCovered = _VehicleDetailMdl1.ParticipantValue;
                    decimal _RateV = _MtrVContributionMdl.Rate;




                    decimal NetContribution = (_SumCovered * (_RateV / 100));
                    decimal GrossContribution = (NetContribution - stamp) / (((_MtrVContributionMdl.FED + _MtrVContributionMdl.FIF) / 100) + 1);



                    decimal BeforePEV = (GrossContribution - _MtrVContributionMdl.TerrorContribution);
                    decimal PEV = (BeforePEV - _MtrVContributionMdl.BasicContribution);


                    //To get Tenure
                    DataTable _tbl8 = new DataTable();
                    //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = " + InsPolicyTxnID, conn);



                        SqlDataAdapter _adpSql8 = new SqlDataAdapter(command);


                        _adpSql8.Fill(_tbl8);
                    }

                    // _adpSql.Fill(_tbl);

                    if (_tbl8.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tbl8.Rows.Count; i++)
                        {
                            _MtrVContributionMdl1 = new MtrVContributionMdl();
                            _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl8.Rows[i]["tenure"]);

                        }


                    }
                    else
                    {
                        _MtrVContributionMdl1.Tenure = 1;
                    }


                    decimal PerDayContribution = GrossContribution / _MtrVContributionMdl1.Tenure;


                    _cmdSql6.Parameters.AddWithValue("@SumCovered", _SumCovered);

                    int _userCode1 = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl.UserCode);

                    _cmdSql6.Parameters.AddWithValue("@UserCode", _userCode);

                    _cmdSql6.Parameters.AddWithValue("@Rate", _RateV);
                    _cmdSql6.Parameters.AddWithValue("@NetContribution", NetContribution);
                    _cmdSql6.Parameters.AddWithValue("@GrossContribution", GrossContribution);
                    _cmdSql6.Parameters.AddWithValue("@FIF", _MtrVContributionMdl.FIF);
                    _cmdSql6.Parameters.AddWithValue("@FED", _MtrVContributionMdl.FED);
                    _cmdSql6.Parameters.AddWithValue("@Stamp", stamp);
                    _cmdSql6.Parameters.AddWithValue("@BasicContribution", _MtrVContributionMdl.BasicContribution);
                    _cmdSql6.Parameters.AddWithValue("@PEV", PEV);
                    _cmdSql6.Parameters.AddWithValue("@BeforePEV", BeforePEV);
                    _cmdSql6.Parameters.AddWithValue("@TerrorContribution", _MtrVContributionMdl.TerrorContribution);
                    _cmdSql6.Parameters.AddWithValue("@PerDayContribution", PerDayContribution);

                    _cmdSql6.Parameters.AddWithValue("@OpolTxnSysID", _MtrVContributionMdl.OpolTxnSysID);

                    //Difference of added value and previous value
                    diff = NetContribution - _MtrVContributionMdl.NetContribution;


                    int _TxnSysId3;
                    _conSql6.Open();
                    _TxnSysId3 = (Int32)_cmdSql6.ExecuteScalar();
                    _conSql6.Close();

                    _MtrVContributionMdl1.TxnSysID = _TxnSysId3;
                    //  _ProductConditionsSetupMdl.ConditionShText = GetConditionByCode(_ProductConditionsSetupMdl.Condition);
                    _MtrVContributionMdl1.IsValidTxn = true;


                    //To update Contribution of Vehicle Certificate
                    SqlConnection _conSql7 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql7 = new StringBuilder();
                    SqlCommand _cmdSql7;

                    _sbSql7.AppendLine("Update  MtrVehicleDetails SET");
                    _sbSql7.AppendLine("Contribution= @Contribution");
                    _sbSql7.AppendLine("WHERE TxnSysId= "+_TxnSysId2);

                    _cmdSql7 = new SqlCommand(_sbSql7.ToString(), _conSql7);


                    _cmdSql7.Parameters.AddWithValue("@Contribution", NetContribution);

                    _conSql7.Open();
                    _cmdSql7.ExecuteNonQuery();
                    _conSql7.Close();

                    //Insert values in to InsContribution
                    SqlConnection _conSql10 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql10 = new StringBuilder();
                    SqlCommand _cmdSql10;

                    _sbSql10.AppendLine("INSERT INTO InsContribution(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql10.AppendLine("TxnSysDate,");
                    _sbSql10.AppendLine("UserCode,");
                    _sbSql10.AppendLine("SumCovered,");
                    _sbSql10.AppendLine("Rate,");
                    _sbSql10.AppendLine("NetContribution,");
                    _sbSql10.AppendLine("GrossContribution,");
                    _sbSql10.AppendLine("FIF,");
                    _sbSql10.AppendLine("FED,");
                    _sbSql10.AppendLine("Stamp,");
                    _sbSql10.AppendLine("BasicContribution,");
                    _sbSql10.AppendLine("PEV,");
                    _sbSql10.AppendLine("BeforePEV,");
                    _sbSql10.AppendLine("TerrorContribution,");
                    _sbSql10.AppendLine("RiskTxnID,");
                    _sbSql10.AppendLine("OpolTxnSysID,");
                    _sbSql10.AppendLine("PerDayContribution)");

                    _sbSql10.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                    //_sbSql.AppendLine("@TxnSysID,");
                    _sbSql10.AppendLine("@TxnSysDate,");
                    _sbSql10.AppendLine("@UserCode,");
                    _sbSql10.AppendLine("@SumCovered,");
                    _sbSql10.AppendLine("@Rate,");
                    _sbSql10.AppendLine("@NetContribution,");
                    _sbSql10.AppendLine("@GrossContribution,");
                    _sbSql10.AppendLine("@FIF,");
                    _sbSql10.AppendLine("@FED,");
                    _sbSql10.AppendLine("@Stamp,");
                    _sbSql10.AppendLine("@BasicContribution,");
                    _sbSql10.AppendLine("@PEV,");
                    _sbSql10.AppendLine("@BeforePEV,");
                    _sbSql10.AppendLine("@TerrorContribution,");
                    _sbSql10.AppendLine("@RiskTxnID,");
                    _sbSql10.AppendLine("@OpolTxnSysID,");
                    _sbSql10.AppendLine("@PerDayContribution)");

                    _cmdSql10 = new SqlCommand(_sbSql10.ToString(), _conSql10);

                    _cmdSql10.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql10.Parameters.AddWithValue("@RiskTxnID", _TxnSysId2);

                    decimal _SumCovered1 = diff;
                    decimal _RateV1 = _VehicleDetailMdl.Rate;




                    decimal NetContribution1 = NetContribution - _MtrVContributionMdl.NetContribution;
                    decimal GrossContribution1 = GrossContribution - _MtrVContributionMdl.GrossContribution;



                    decimal BeforePEV1 = (GrossContribution1 - _MtrVContributionMdl.TerrorContribution);
                    decimal PEV1 = (BeforePEV1 - _MtrVContributionMdl.BasicContribution);


                    //To get Tenure
                    DataTable _tbl10 = new DataTable();
                    //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = " + InsPolicyTxnID, conn);



                        SqlDataAdapter _adpSql10 = new SqlDataAdapter(command);


                        _adpSql10.Fill(_tbl10);
                    }

                    // _adpSql.Fill(_tbl);

                    if (_tbl10.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tbl10.Rows.Count; i++)
                        {
                            _MtrVContributionMdl1 = new MtrVContributionMdl();
                            _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl10.Rows[i]["tenure"]);

                        }


                    }
                    else
                    {
                        _MtrVContributionMdl1.Tenure = 1;
                    }


                    decimal PerDayContribution1 = GrossContribution1 / _MtrVContributionMdl1.Tenure;


                    _cmdSql10.Parameters.AddWithValue("@SumCovered", _SumCovered - _MtrVContributionMdl.SumCovered );

                    int _userCode2 = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl.UserCode);

                    _cmdSql10.Parameters.AddWithValue("@UserCode", _userCode);

                    _cmdSql10.Parameters.AddWithValue("@Rate", _RateV1);
                    _cmdSql10.Parameters.AddWithValue("@NetContribution", NetContribution- _MtrVContributionMdl.NetContribution );
                    _cmdSql10.Parameters.AddWithValue("@GrossContribution", GrossContribution - _MtrVContributionMdl.GrossContribution );
                    _cmdSql10.Parameters.AddWithValue("@FIF", _MtrVContributionMdl.FIF);
                    _cmdSql10.Parameters.AddWithValue("@FED", _MtrVContributionMdl.FED);
                    _cmdSql10.Parameters.AddWithValue("@Stamp", stamp);
                    _cmdSql10.Parameters.AddWithValue("@BasicContribution", _MtrVContributionMdl.BasicContribution);
                    _cmdSql10.Parameters.AddWithValue("@PEV", PEV1);
                    _cmdSql10.Parameters.AddWithValue("@BeforePEV", BeforePEV - _MtrVContributionMdl.BeforePEV );
                    _cmdSql10.Parameters.AddWithValue("@TerrorContribution", _MtrVContributionMdl.TerrorContribution);
                    _cmdSql10.Parameters.AddWithValue("@PerDayContribution", PerDayContribution1);

                    _cmdSql10.Parameters.AddWithValue("@OpolTxnSysID", _MtrVContributionMdl.OpolTxnSysID);

                    int _TxnSysId4;
                    _conSql10.Open();
                    _TxnSysId4 = (Int32)_cmdSql10.ExecuteScalar();
                    _conSql10.Close();

                    _MtrVContributionMdl1.TxnSysID = _TxnSysId4;

                    _MtrVContributionMdl1.IsValidTxn = true;

                    //For CoInsurance 
                    if (_VehicleDetailMdl.InsuranceTypeCode == 2 || _VehicleDetailMdl.InsuranceTypeCode == 3)
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
                                

                               _InsCoInsuranceListA1.Add(_InsCoInsuranceA1);
                            }

                            //Insert InTo CoInsurance for Endorsement
                            SqlConnection _conSqlA2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                            StringBuilder _sbSqlA2 = new StringBuilder();
                            SqlCommand _cmdSqlA2;
                            InsCoInsurance[] ConInsList = _InsCoInsuranceListA1.ToArray();


                            for (int i = 0; i < ConInsList.Length; i++)
                            {
                                _sbSqlA2 = new StringBuilder();

                                decimal SumCovered = 0;
                                SumCovered = _SumCovered - _MtrVContributionMdl.SumCovered;
                                decimal NetC = 0;
                                NetC = NetContribution - _MtrVContributionMdl.NetContribution;
                                decimal GrossC = 0;
                                GrossC = GrossContribution - _MtrVContributionMdl.GrossContribution;


                                //To get Tenure
                                DataTable _tbl = new DataTable();
                                InsCoInsurance _InsCoInsuranceTe = new InsCoInsurance();

                                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                                {
                                    SqlCommand command =
                                        new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip INNER JOIN MtrVehicleDetails mvd ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE mvd.TxnSysID = @TxnSysID", conn);

                                    command.Parameters.Add(new SqlParameter("@TxnSysID", _VehicleDetailMdl1.TxnSysID));

                                    SqlDataAdapter _adpSqlTe = new SqlDataAdapter(command);


                                    _adpSqlTe.Fill(_tbl);
                                }

                                // _adpSql.Fill(_tbl);

                                if (_tbl.Rows.Count > 0)
                                {
                                    for (int j = 0; j < _tbl.Rows.Count; j++)
                                    {
                                        _InsCoInsuranceTe = new InsCoInsurance();
                                        _InsCoInsuranceTe.Tenure = Convert.ToInt32(_tbl.Rows[j]["tenure"]);

                                    }


                                }
                                else
                                {
                                    _InsCoInsuranceTe.Tenure = 1;
                                }

                                int SumCo = 0;
                                SumCo = Convert.ToInt32(SumCovered * (ConInsList[i].CoInsuranceShare / 100));
                                decimal NetCo = 0;
                                NetCo = NetC * (ConInsList[i].CoInsuranceShare / 100);
                                decimal GrossCo = 0;
                                GrossCo = GrossC * (ConInsList[i].CoInsuranceShare / 100);
                                decimal PerDayCo = 0;
                                PerDayCo = GrossCo / _InsCoInsuranceTe.Tenure;





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
                                _sbSqlA2.AppendLine("@RiskTxnID,");
                                _sbSqlA2.AppendLine("@OpolTxnSysID,");
                                _sbSqlA2.AppendLine("@PerDayContribution,");
                                _sbSqlA2.AppendLine("@CoInsuranceCode,");
                                _sbSqlA2.AppendLine("@CoInsuranceShare)");


                                _cmdSqlA2 = new SqlCommand(_sbSqlA2.ToString(), _conSqlA2);

                                _cmdSqlA2.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                                _cmdSqlA2.Parameters.AddWithValue("@RiskTxnID", _TxnSysId2);
                                _cmdSqlA2.Parameters.AddWithValue("@SumCovered", SumCo);

                                int _userCodeA2 = GlobalDataLayer.GetUserCodeById(ConInsList[i].UserCode);

                                _cmdSqlA2.Parameters.AddWithValue("@UserCode", _userCodeA2);


                                _cmdSqlA2.Parameters.AddWithValue("@Rate", ConInsList[i].Rate);
                                _cmdSqlA2.Parameters.AddWithValue("@NetContribution", NetCo);
                                _cmdSqlA2.Parameters.AddWithValue("@GrossContribution", GrossCo);
                                _cmdSqlA2.Parameters.AddWithValue("@FIF", ConInsList[i].FIF);
                                _cmdSqlA2.Parameters.AddWithValue("@FED", ConInsList[i].FED);
                                _cmdSqlA2.Parameters.AddWithValue("@Stamp", stamp);
                                _cmdSqlA2.Parameters.AddWithValue("@BasicContribution", ConInsList[i].BasicContribution);
                                _cmdSqlA2.Parameters.AddWithValue("@PEV", ConInsList[i].PEV);
                                _cmdSqlA2.Parameters.AddWithValue("@BeforePEV", ConInsList[i].BeforePEV);
                                _cmdSqlA2.Parameters.AddWithValue("@TerrorContribution", ConInsList[i].TerrorContribution);
                                // _cmdSqlA2.Parameters.AddWithValue("@RiskTxnID", ConInsList[i].RiskTxnID);
                                _cmdSqlA2.Parameters.AddWithValue("@OpolTxnSysID", ConInsList[i].OpolTxnSysID);
                                _cmdSqlA2.Parameters.AddWithValue("@PerDayContribution", PerDayCo);
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



                }

                //To Decrease Rate
                if (_EndtReasonMdl1.EndtReasonCode == 3)
                {
                    _Rate = _VehicleDetailMdl1.Rate;

                    //Convert FED To Zero if 180 days Passed
                    DataTable _tblFED = new DataTable();
                    //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,'" + DateTime.Now + "') diff  FROM InsPolicy ip INNER JOIN MtrVehicleDetails mvd ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE mvd.TxnSysID = " + _VehicleDetailMdl1.TxnSysID, conn);



                        SqlDataAdapter _adpSql8 = new SqlDataAdapter(command);


                        _adpSql8.Fill(_tblFED);
                    }

                    // _adpSql.Fill(_tbl);

                    if (_tblFED.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblFED.Rows.Count; i++)
                        {

                            days = Convert.ToInt32(_tblFED.Rows[i]["diff"]);

                        }


                    }
                    else
                    {
                        days = 0;
                    }

                    if (days == 180)
                    {
                        FEDU = 0;
                    }

                    else
                    {
                        FEDU = _MtrVContributionMdl.FED;
                    }

                    //Get Values From MtrVehicle Detail by TxnID
                    SqlConnection _conSql3 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    string _sqlString3 = "SELECT * FROM MtrVehicleDetails mvd WHERE mvd.TxnSysID =  " + _VehicleDetailMdl1.TxnSysID;

                    SqlDataAdapter _adpSql3 = new SqlDataAdapter(_sqlString3, _conSql3);
                    DataTable _tblSqla3 = new DataTable();


                    _adpSql3.Fill(_tblSqla3);

                    if (_tblSqla3.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla3.Rows.Count; i++)
                        {
                            _VehicleDetailMdl = new VehicleDetailMdl();

                            _VehicleDetailMdl.TxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["TxnSysID"]);
                            _VehicleDetailMdl.TxnSysDate = Convert.ToDateTime(_tblSqla3.Rows[i]["TxnSysDate"]);
                            _VehicleDetailMdl.UserCode = Convert.ToInt32(_tblSqla3.Rows[i]["UserCode"]);
                            _VehicleDetailMdl.SerialNo = Convert.ToInt32(_tblSqla3.Rows[i]["SerialNo"].ToString());
                            _VehicleDetailMdl.VehicleCode = Convert.ToInt32(_tblSqla3.Rows[i]["VehicleCode"].ToString());
                            _VehicleDetailMdl.VehicleModel = Convert.ToInt32(_tblSqla3.Rows[i]["VehicleModel"].ToString());
                            _VehicleDetailMdl.UpdatedValue = Convert.ToDecimal(_tblSqla3.Rows[i]["UpdatedValue"]);
                            _VehicleDetailMdl.PreviousValue = Convert.ToDecimal(_tblSqla3.Rows[i]["PreviousValue"]);
                            _VehicleDetailMdl.Mileage = Convert.ToInt32(_tblSqla3.Rows[i]["Mileage"].ToString());
                            _VehicleDetailMdl.ParticipantValue = Convert.ToDecimal(_tblSqla3.Rows[i]["ParticipantValue"]);
                            _VehicleDetailMdl.ColorCode = Convert.ToInt32(_tblSqla3.Rows[i]["ColorCode"].ToString());
                            _VehicleDetailMdl.ParticipantName = _tblSqla3.Rows[i]["ParticipantName"].ToString();
                            _VehicleDetailMdl.ParticipantAddress = _tblSqla3.Rows[i]["ParticipantAddress"].ToString();
                            // _VehicleDetailMdl.ModelNumber = Convert.ToInt32(_tblSqla.Rows[i]["ModelNumber"]);
                            _VehicleDetailMdl.RegistrationNumber = _tblSqla3.Rows[i]["RegistrationNumber"].ToString();
                            _VehicleDetailMdl.CityCode = _tblSqla3.Rows[i]["CityCode"].ToString();
                            _VehicleDetailMdl.EngineNumber = _tblSqla3.Rows[i]["EngineNumber"].ToString();
                            _VehicleDetailMdl.AreaCode = Convert.ToInt32(_tblSqla3.Rows[i]["AreaCode"].ToString());
                            _VehicleDetailMdl.ChasisNumber = _tblSqla3.Rows[i]["ChasisNumber"].ToString();
                            _VehicleDetailMdl.Remarks = _tblSqla3.Rows[i]["Remarks"].ToString();
                            _VehicleDetailMdl.PODate = Convert.ToDateTime(_tblSqla3.Rows[i]["PODate"]);
                            _VehicleDetailMdl.PONumber = (_tblSqla3.Rows[i]["PONumber"].ToString());
                            _VehicleDetailMdl.CNICNumber = _tblSqla3.Rows[i]["CNICNumber"].ToString();
                            _VehicleDetailMdl.Tenure = _tblSqla3.Rows[i]["Tenure"].ToString();
                            _VehicleDetailMdl.BirthDate = Convert.ToDateTime(_tblSqla3.Rows[i]["BirthDate"]);
                            _VehicleDetailMdl.Gender = _tblSqla3.Rows[i]["Gender"].ToString();
                            _VehicleDetailMdl.VehicleType = _tblSqla3.Rows[i]["VehicleType"].ToString();
                            _VehicleDetailMdl.VEODCode = Convert.ToInt32(_tblSqla3.Rows[i]["VEODCode"]);
                            _VehicleDetailMdl.CertTypeCode = _tblSqla3.Rows[i]["CertTypeCode"].ToString();
                            _VehicleDetailMdl.Rate = Convert.ToDecimal(_tblSqla3.Rows[i]["Rate"]);
                            _VehicleDetailMdl.Contribution = Convert.ToInt32(_tblSqla3.Rows[i]["Contribution"]);
                            _VehicleDetailMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["ParentTxnSysID"]);
                            _VehicleDetailMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["OpolTxnSysID"]);

                            _VehicleDetailMdl.VEODName = GlobalDataLayer.GetVEODNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["VEODCode"]));
                            _VehicleDetailMdl.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_tblSqla3.Rows[i]["VehicleType"].ToString());

                            _VehicleDetailMdl.InsuranceTypeCode = Convert.ToInt32(_tblSqla3.Rows[i]["InsuranceTypeCode"]);
                            _VehicleDetailMdl.IsActive = Convert.ToBoolean(_tblSqla3.Rows[i]["IsActive"]);
                            _VehicleDetailMdl.IsCanceled = Convert.ToBoolean(_tblSqla3.Rows[i]["IsCanceled"]);
                            _VehicleDetailMdl.CommisionRate = Convert.ToDecimal(_tblSqla3.Rows[i]["CommisionRate"]);
                            _VehicleDetailMdl.MobileNumber = _tblSqla3.Rows[i]["MobileNumber"].ToString();
                            _VehicleDetailMdl.ResNumber = _tblSqla3.Rows[i]["ResNumber"].ToString();
                            _VehicleDetailMdl.OfficeNumber = _tblSqla3.Rows[i]["OfficeNumber"].ToString();

                            _VehicleDetailMdl.EmailAddress = _tblSqla3.Rows[i]["EmailAddress"].ToString();
                            _VehicleDetailMdl.Deductible = Convert.ToDecimal(_tblSqla3.Rows[i]["Deductible"]);

                            _VehicleDetailMdl.ContractMatDate = Convert.ToDateTime(_tblSqla3.Rows[i]["ContractMatDate"]);

                            _VehicleDetailMdl.RatingFactor = _tblSqla3.Rows[i]["RatingFactor"].ToString();
                            _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_tblSqla3.Rows[i]["RatingFactor"].ToString());

                            _VehicleDetailMdl.GenderName = GlobalDataLayer.GetGenderNameByCode(_tblSqla3.Rows[i]["Gender"].ToString());
                            _VehicleDetailMdl.CityName = GlobalDataLayer.GetCityNameByCode(_tblSqla3.Rows[i]["CityCode"].ToString());
                            _VehicleDetailMdl.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["ColorCode"].ToString()));
                            _VehicleDetailMdl.VehicleName = GlobalDataLayer.GetVehicleNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["VehicleCode"].ToString()));
                            _VehicleDetailMdl.AreaName = GlobalDataLayer.GetAreaNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["AreaCode"].ToString()));
                            _VehicleDetailMdl.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_tblSqla3.Rows[i]["CertTypeCode"].ToString());
                            _VehicleDetailMdl.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["InsuranceTypeCode"]));

                            _VehicleDetailMdl.total = GlobalDataLayer.calculate(_VehicleDetailMdl);


                            _VehicleDetailMdlList.Add(_VehicleDetailMdl);


                        }
                    }

                    else
                    {

                    }


                    //Insert Into Vehicle Details
                    SqlConnection _conSql4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql4 = new StringBuilder();
                    SqlCommand _cmdSql4;
                    int _SerialNumber1 = GetSerialNo1(_VehicleDetailMdl);


                    _sbSql4.AppendLine("INSERT INTO MtrVehicleDetails(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql4.AppendLine("TxnSysDate,");
                    _sbSql4.AppendLine("UserCode,");
                    _sbSql4.AppendLine("SerialNo,");
                    _sbSql4.AppendLine("VehicleCode,");
                    _sbSql4.AppendLine("VehicleModel,");
                    _sbSql4.AppendLine("UpdatedValue,");
                    _sbSql4.AppendLine("PreviousValue,");
                    _sbSql4.AppendLine("Mileage,");
                    _sbSql4.AppendLine("ParticipantValue,");
                    _sbSql4.AppendLine("ColorCode,");
                    _sbSql4.AppendLine("ParticipantName,");
                    _sbSql4.AppendLine("ParticipantAddress,");
                    // _sbSql.AppendLine("ModelNumber,");
                    _sbSql4.AppendLine("RegistrationNumber,");
                    _sbSql4.AppendLine("CityCode,");
                    _sbSql4.AppendLine("EngineNumber,");
                    _sbSql4.AppendLine("AreaCode,");
                    _sbSql4.AppendLine("ChasisNumber,");
                    _sbSql4.AppendLine("Remarks,");
                    _sbSql4.AppendLine("PODate,");
                    _sbSql4.AppendLine("PONumber,");
                    _sbSql4.AppendLine("CNICNumber,");
                    _sbSql4.AppendLine("Tenure,");
                    _sbSql4.AppendLine("BirthDate,");
                    _sbSql4.AppendLine("Gender,");
                    _sbSql4.AppendLine("VehicleType,");
                    _sbSql4.AppendLine("VEODCode,");
                    _sbSql4.AppendLine("CertTypeCode,");
                    _sbSql4.AppendLine("Rate,");
                    _sbSql4.AppendLine("ParentTxnSysID,");
                    _sbSql4.AppendLine("OpolTxnSysID,");
                    _sbSql4.AppendLine("InsuranceTypeCode,");
                    _sbSql4.AppendLine("CommisionRate,");
                    _sbSql4.AppendLine("MobileNumber,");
                    _sbSql4.AppendLine("ResNumber,");
                    _sbSql4.AppendLine("OfficeNumber,");
                    _sbSql4.AppendLine("EmailAddress,");
                    _sbSql4.AppendLine("Deductible,");
                    _sbSql4.AppendLine("ContractMatDate,");
                    _sbSql4.AppendLine("RatingFactor,");
                    _sbSql4.AppendLine("Contribution)");


                    _sbSql4.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                    // _sbSql.AppendLine("@TxnSysID,");
                    _sbSql4.AppendLine("@TxnSysDate,");
                    _sbSql4.AppendLine("@UserCode,");
                    _sbSql4.AppendLine("@SerialNo,");
                    _sbSql4.AppendLine("@VehicleCode,");
                    _sbSql4.AppendLine("@VehicleModel,");
                    _sbSql4.AppendLine("@UpdatedValue,");
                    _sbSql4.AppendLine("@PreviousValue,");
                    _sbSql4.AppendLine("@Mileage,");
                    _sbSql4.AppendLine("@ParticipantValue,");
                    _sbSql4.AppendLine("@ColorCode,");
                    _sbSql4.AppendLine("@ParticipantName,");
                    _sbSql4.AppendLine("@ParticipantAddress,");
                    // _sbSql.AppendLine("@ModelNumber,");
                    _sbSql4.AppendLine("@RegistrationNumber,");
                    _sbSql4.AppendLine("@CityCode,");
                    _sbSql4.AppendLine("@EngineNumber,");
                    _sbSql4.AppendLine("@AreaCode,");
                    _sbSql4.AppendLine("@ChasisNumber,");
                    _sbSql4.AppendLine("@Remarks,");
                    _sbSql4.AppendLine("@PODate,");
                    _sbSql4.AppendLine("@PONumber,");
                    _sbSql4.AppendLine("@CNICNumber,");
                    _sbSql4.AppendLine("@Tenure,");
                    _sbSql4.AppendLine("@BirthDate,");
                    _sbSql4.AppendLine("@Gender,");
                    _sbSql4.AppendLine("@VehicleType,");
                    _sbSql4.AppendLine("@VEODCode,");
                    _sbSql4.AppendLine("@CertTypeCode,");
                    _sbSql4.AppendLine("@Rate,");
                    _sbSql4.AppendLine("@ParentTxnSysID,");
                    _sbSql4.AppendLine("(SELECT ip.OpolTxnSysID FROM InsPolicy ip WHERE ip.ParentTxnSysID = @ParentTxnSysID),");
                    _sbSql4.AppendLine("@InsuranceTypeCode,");
                    _sbSql4.AppendLine("@CommisionRate,");
                    _sbSql4.AppendLine("@MobileNumber,");
                    _sbSql4.AppendLine("@ResNumber,");
                    _sbSql4.AppendLine("@OfficeNumber,");
                    _sbSql4.AppendLine("@EmailAddress,");
                    _sbSql4.AppendLine("@Deductible,");
                    _sbSql4.AppendLine("@ContractMatDate,");
                    _sbSql4.AppendLine("@RatingFactor,");
                    _sbSql4.AppendLine("@Contribution)");


                    _cmdSql4 = new SqlCommand(_sbSql4.ToString(), _conSql4);




                    DateTime da = DateTime.Now;
                    da.ToString("MM-dd-yyyy h:mm tt");

                    _cmdSql4.Parameters.AddWithValue("@TxnSysDate", Convert.ToDateTime(da));
                    _cmdSql4.Parameters.AddWithValue("@ParentTxnSysID", _TxnSysId);
                    int _userCode = GlobalDataLayer.GetUserCodeById(_VehicleDetailMdl.UserCode);
                    _cmdSql4.Parameters.AddWithValue("@UserCode", _userCode);

                    _cmdSql4.Parameters.AddWithValue("@RatingFactor", _VehicleDetailMdl.RatingFactor);
                    _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_VehicleDetailMdl.RatingFactor);

                    _cmdSql4.Parameters.AddWithValue("@SerialNo", _SerialNumber1);
                    _cmdSql4.Parameters.AddWithValue("@VehicleCode", _VehicleDetailMdl.VehicleCode);
                    _cmdSql4.Parameters.AddWithValue("@VehicleModel", _VehicleDetailMdl.VehicleModel);
                    _cmdSql4.Parameters.AddWithValue("@UpdatedValue", _VehicleDetailMdl.UpdatedValue);
                    _cmdSql4.Parameters.AddWithValue("@PreviousValue", _VehicleDetailMdl.PreviousValue);
                    _cmdSql4.Parameters.AddWithValue("@Mileage", _VehicleDetailMdl.Mileage);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantValue", _VehicleDetailMdl.ParticipantValue);
                    _cmdSql4.Parameters.AddWithValue("@ColorCode", _VehicleDetailMdl.ColorCode);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantName", _VehicleDetailMdl.ParticipantName);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantAddress", _VehicleDetailMdl.ParticipantAddress);
                    // _cmdSql.Parameters.AddWithValue("@ModelNumber", _VehicleDetailMdl.ModelNumber);
                    _cmdSql4.Parameters.AddWithValue("@RegistrationNumber", _VehicleDetailMdl.RegistrationNumber);
                    _cmdSql4.Parameters.AddWithValue("@CityCode", _VehicleDetailMdl.CityCode);
                    _cmdSql4.Parameters.AddWithValue("@EngineNumber", _VehicleDetailMdl.EngineNumber);
                    _cmdSql4.Parameters.AddWithValue("@AreaCode", _VehicleDetailMdl.AreaCode);
                    _cmdSql4.Parameters.AddWithValue("@ChasisNumber", _VehicleDetailMdl.ChasisNumber);

                    //Add Remarks for addition
                    _cmdSql4.Parameters.AddWithValue("@Remarks", _VehicleDetailMdl1.Remarks ?? DBNull.Value.ToString());

                   _cmdSql4.Parameters.AddWithValue("@PODate", _VehicleDetailMdl.PODate);
                    _cmdSql4.Parameters.AddWithValue("@PONumber", _VehicleDetailMdl.PONumber);
                    _cmdSql4.Parameters.AddWithValue("@CNICNumber", _VehicleDetailMdl.CNICNumber);
                    _cmdSql4.Parameters.AddWithValue("@Tenure", _VehicleDetailMdl.Tenure);
                    _cmdSql4.Parameters.AddWithValue("@BirthDate", _VehicleDetailMdl.BirthDate);
                    _cmdSql4.Parameters.AddWithValue("@Gender", _VehicleDetailMdl.Gender);
                    _cmdSql4.Parameters.AddWithValue("@VehicleType", _VehicleDetailMdl.VehicleType);
                    _cmdSql4.Parameters.AddWithValue("@VEODCode", _VehicleDetailMdl.VEODCode);
                    _cmdSql4.Parameters.AddWithValue("@CertTypeCode", _VehicleDetailMdl.CertTypeCode);
                    _cmdSql4.Parameters.AddWithValue("@Rate", _VehicleDetailMdl1.Rate);
                    _cmdSql4.Parameters.AddWithValue("@InsuranceTypeCode", _VehicleDetailMdl.InsuranceTypeCode);
                    _cmdSql4.Parameters.AddWithValue("@Contribution", _VehicleDetailMdl.Contribution);
                    _cmdSql4.Parameters.AddWithValue("@CommisionRate", _VehicleDetailMdl.CommisionRate);
                    _cmdSql4.Parameters.AddWithValue("@MobileNumber", _VehicleDetailMdl.MobileNumber);
                    _cmdSql4.Parameters.AddWithValue("@ResNumber", _VehicleDetailMdl.ResNumber);
                    _cmdSql4.Parameters.AddWithValue("@OfficeNumber", _VehicleDetailMdl.OfficeNumber);

                    _cmdSql4.Parameters.AddWithValue("@EmailAddress", _VehicleDetailMdl.EmailAddress);
                    _cmdSql4.Parameters.AddWithValue("@Deductible", _VehicleDetailMdl.Deductible);
                    _cmdSql4.Parameters.AddWithValue("@ContractMatDate", _VehicleDetailMdl.ContractMatDate);



                    _VehicleDetailMdl.SerialNo = _SerialNumber;

                    _VehicleDetailMdl.TxnSysDate = DateTime.Now;

                    _VehicleDetailMdl.VEODName = GlobalDataLayer.GetVEODNameByCode(_VehicleDetailMdl.VEODCode);
                    _VehicleDetailMdl.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_VehicleDetailMdl.VehicleType);
                    _VehicleDetailMdl.GenderName = GlobalDataLayer.GetGenderNameByCode(_VehicleDetailMdl.Gender);
                    _VehicleDetailMdl.CityName = GlobalDataLayer.GetCityNameByCode(_VehicleDetailMdl.CityCode);
                    _VehicleDetailMdl.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(_VehicleDetailMdl.ColorCode);
                    _VehicleDetailMdl.VehicleName = GlobalDataLayer.GetVehicleNameByCode(_VehicleDetailMdl.VehicleCode);
                    _VehicleDetailMdl.AreaName = GlobalDataLayer.GetAreaNameByCode(_VehicleDetailMdl.AreaCode);
                    _VehicleDetailMdl.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_VehicleDetailMdl.CertTypeCode);
                    _VehicleDetailMdl.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(_VehicleDetailMdl.InsuranceTypeCode);


                    _VehicleDetailMdl.total = GlobalDataLayer.calculate(_VehicleDetailMdl);

                    int _TxnSysId2;
                    _conSql4.Open();
                    _TxnSysId2 = (Int32)_cmdSql4.ExecuteScalar();
                    _conSql4.Close();
                    _VehicleDetailMdl.IsValidTxn = true;


                    //For Second Endorsemnt Get Values of Contribution from UpdateContribution
                    if (_MtrInsPolicyMdl.EndoSerial > 0)
                    {
                        //Get values From Ins Update Contribution
                        SqlConnection _conSql5A = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        DataTable _tblSqla5A = new DataTable();
                        // MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
                        List<MtrVContributionMdl> _MtrVContributionMdlListA = new List<MtrVContributionMdl>();

                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                        {
                            SqlCommand command =
                                new SqlCommand("SELECT * FROM InsUpdateContribution iuc INNER JOIN InsContribution ic ON ic.RiskTxnID = iuc.RiskTxnID WHERE ic.TxnSysID = @TxnSysID", conn);

                            command.Parameters.Add(new SqlParameter("@TxnSysID", ConTxnID));

                            SqlDataAdapter _adpSql5A = new SqlDataAdapter(command);


                            _adpSql5A.Fill(_tblSqla5A);
                        }



                        if (_tblSqla5A.Rows.Count > 0)
                        {
                            _MtrVContributionMdl = new MtrVContributionMdl();
                            for (int i = 0; i < _tblSqla5A.Rows.Count; i++)
                            {

                                _MtrVContributionMdl.TxnSysID = Convert.ToInt32(_tblSqla5A.Rows[i]["TxnSysID"]);
                                _MtrVContributionMdl.TxnSysDate = Convert.ToDateTime(_tblSqla5A.Rows[i]["TxnSysDate"]);
                                _MtrVContributionMdl.UserCode = Convert.ToInt32(_tblSqla5A.Rows[i]["UserCode"]);
                                _MtrVContributionMdl.SumCovered = Convert.ToInt32(_tblSqla5A.Rows[i]["SumCovered"]);
                                _MtrVContributionMdl.Rate = Convert.ToDecimal(_tblSqla5A.Rows[i]["Rate"]);
                                _MtrVContributionMdl.NetContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["NetContribution"]);
                                _MtrVContributionMdl.GrossContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["GrossContribution"]);
                                _MtrVContributionMdl.FIF = Convert.ToDecimal(_tblSqla5A.Rows[i]["FIF"]);
                                _MtrVContributionMdl.FED = Convert.ToDecimal(_tblSqla5A.Rows[i]["FED"]);
                                _MtrVContributionMdl.Stamp = Convert.ToDecimal(_tblSqla5A.Rows[i]["Stamp"]);
                                _MtrVContributionMdl.BasicContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["BasicContribution"]);
                                _MtrVContributionMdl.PEV = Convert.ToDecimal(_tblSqla5A.Rows[i]["PEV"]);
                                _MtrVContributionMdl.BeforePEV = Convert.ToDecimal(_tblSqla5A.Rows[i]["BeforePEV"]);
                                _MtrVContributionMdl.TerrorContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["TerrorContribution"]);
                                _MtrVContributionMdl.RiskTxnID = Convert.ToInt32(_tblSqla5A.Rows[i]["RiskTxnID"]);
                                _MtrVContributionMdl.PerDayContribution = Convert.ToInt32(_tblSqla5A.Rows[i]["PerDayContribution"]);
                                _MtrVContributionMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla5A.Rows[i]["OpolTxnSysID"]);

                            }


                        }


                        else
                        {

                        }
                    }

                    else
                    {
                        //Get values From InsContribution
                        SqlConnection _conSql5 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        DataTable _tblSqla5 = new DataTable();
                        // MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
                        List<MtrVContributionMdl> _MtrVContributionMdlList = new List<MtrVContributionMdl>();

                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                        {
                            SqlCommand command =
                                new SqlCommand("SELECT *  FROM InsContribution Where  TxnSysID = @TxnSysID", conn);

                            command.Parameters.Add(new SqlParameter("@TxnSysID", ConTxnID));

                            SqlDataAdapter _adpSql5 = new SqlDataAdapter(command);


                            _adpSql5.Fill(_tblSqla5);
                        }



                        if (_tblSqla5.Rows.Count > 0)
                        {
                            _MtrVContributionMdl = new MtrVContributionMdl();
                            for (int i = 0; i < _tblSqla5.Rows.Count; i++)
                            {

                                _MtrVContributionMdl.TxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["TxnSysID"]);
                                _MtrVContributionMdl.TxnSysDate = Convert.ToDateTime(_tblSqla5.Rows[i]["TxnSysDate"]);
                                _MtrVContributionMdl.UserCode = Convert.ToInt32(_tblSqla5.Rows[i]["UserCode"]);
                                _MtrVContributionMdl.SumCovered = Convert.ToInt32(_tblSqla5.Rows[i]["SumCovered"]);
                                _MtrVContributionMdl.Rate = Convert.ToDecimal(_tblSqla5.Rows[i]["Rate"]);
                                _MtrVContributionMdl.NetContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["NetContribution"]);
                                _MtrVContributionMdl.GrossContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["GrossContribution"]);
                                _MtrVContributionMdl.FIF = Convert.ToDecimal(_tblSqla5.Rows[i]["FIF"]);
                                _MtrVContributionMdl.FED = Convert.ToDecimal(_tblSqla5.Rows[i]["FED"]);
                                _MtrVContributionMdl.Stamp = Convert.ToDecimal(_tblSqla5.Rows[i]["Stamp"]);
                                _MtrVContributionMdl.BasicContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["BasicContribution"]);
                                _MtrVContributionMdl.PEV = Convert.ToDecimal(_tblSqla5.Rows[i]["PEV"]);
                                _MtrVContributionMdl.BeforePEV = Convert.ToDecimal(_tblSqla5.Rows[i]["BeforePEV"]);
                                _MtrVContributionMdl.TerrorContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["TerrorContribution"]);
                                _MtrVContributionMdl.RiskTxnID = Convert.ToInt32(_tblSqla5.Rows[i]["RiskTxnID"]);
                                _MtrVContributionMdl.PerDayContribution = Convert.ToInt32(_tblSqla5.Rows[i]["PerDayContribution"]);
                                _MtrVContributionMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["OpolTxnSysID"]);

                            }


                        }


                        else
                        {

                        }
                    }


                    //Insert values in to InsUpdateContribution
                    SqlConnection _conSql6 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql6 = new StringBuilder();
                    SqlCommand _cmdSql6;

                    _sbSql6.AppendLine("INSERT INTO InsUpdateContribution(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql6.AppendLine("TxnSysDate,");
                    _sbSql6.AppendLine("UserCode,");
                    _sbSql6.AppendLine("SumCovered,");
                    _sbSql6.AppendLine("Rate,");
                    _sbSql6.AppendLine("NetContribution,");
                    _sbSql6.AppendLine("GrossContribution,");
                    _sbSql6.AppendLine("FIF,");
                    _sbSql6.AppendLine("FED,");
                    _sbSql6.AppendLine("Stamp,");
                    _sbSql6.AppendLine("BasicContribution,");
                    _sbSql6.AppendLine("PEV,");
                    _sbSql6.AppendLine("BeforePEV,");
                    _sbSql6.AppendLine("TerrorContribution,");
                    _sbSql6.AppendLine("RiskTxnID,");
                    _sbSql6.AppendLine("OpolTxnSysID,");
                    _sbSql6.AppendLine("PerDayContribution)");

                    _sbSql6.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                    //_sbSql.AppendLine("@TxnSysID,");
                    _sbSql6.AppendLine("@TxnSysDate,");
                    _sbSql6.AppendLine("@UserCode,");
                    _sbSql6.AppendLine("@SumCovered,");
                    _sbSql6.AppendLine("@Rate,");
                    _sbSql6.AppendLine("@NetContribution,");
                    _sbSql6.AppendLine("@GrossContribution,");
                    _sbSql6.AppendLine("@FIF,");
                    _sbSql6.AppendLine("@FED,");
                    _sbSql6.AppendLine("@Stamp,");
                    _sbSql6.AppendLine("@BasicContribution,");
                    _sbSql6.AppendLine("@PEV,");
                    _sbSql6.AppendLine("@BeforePEV,");
                    _sbSql6.AppendLine("@TerrorContribution,");
                    _sbSql6.AppendLine("@RiskTxnID,");
                    _sbSql6.AppendLine("@OpolTxnSysID,");
                    _sbSql6.AppendLine("@PerDayContribution)");

                    _cmdSql6 = new SqlCommand(_sbSql6.ToString(), _conSql6);

                    _cmdSql6.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql6.Parameters.AddWithValue("@RiskTxnID", _TxnSysId2);

                    decimal _SumCovered = _VehicleDetailMdl.ParticipantValue;
                    decimal _RateV = _VehicleDetailMdl1.Rate;




                    decimal NetContribution = (_SumCovered * (_RateV / 100));
                    decimal GrossContribution = (NetContribution - stamp) / (((FEDU + _MtrVContributionMdl.FIF) / 100) + 1);



                    decimal BeforePEV = (GrossContribution - _MtrVContributionMdl.TerrorContribution);
                    decimal PEV = (BeforePEV - _MtrVContributionMdl.BasicContribution);


                    //To get Tenure
                    DataTable _tbl8 = new DataTable();
                    //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = " + InsPolicyTxnID, conn);



                        SqlDataAdapter _adpSql8 = new SqlDataAdapter(command);


                        _adpSql8.Fill(_tbl8);
                    }

                    // _adpSql.Fill(_tbl);

                    if (_tbl8.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tbl8.Rows.Count; i++)
                        {
                            _MtrVContributionMdl1 = new MtrVContributionMdl();
                            _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl8.Rows[i]["tenure"]);

                        }


                    }
                    else
                    {
                        _MtrVContributionMdl1.Tenure = 1;
                    }


                    decimal PerDayContribution = GrossContribution / _MtrVContributionMdl1.Tenure;


                    _cmdSql6.Parameters.AddWithValue("@SumCovered", _SumCovered);

                    int _userCode1 = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl.UserCode);

                    _cmdSql6.Parameters.AddWithValue("@UserCode", _userCode);

                    _cmdSql6.Parameters.AddWithValue("@Rate", _RateV);
                    _cmdSql6.Parameters.AddWithValue("@NetContribution", NetContribution);
                    _cmdSql6.Parameters.AddWithValue("@GrossContribution", GrossContribution);
                    _cmdSql6.Parameters.AddWithValue("@FIF", _MtrVContributionMdl.FIF);
                    _cmdSql6.Parameters.AddWithValue("@FED", FEDU);
                    _cmdSql6.Parameters.AddWithValue("@Stamp", stamp);
                    _cmdSql6.Parameters.AddWithValue("@BasicContribution", _MtrVContributionMdl.BasicContribution);
                    _cmdSql6.Parameters.AddWithValue("@PEV", PEV);
                    _cmdSql6.Parameters.AddWithValue("@BeforePEV", BeforePEV);
                    _cmdSql6.Parameters.AddWithValue("@TerrorContribution", _MtrVContributionMdl.TerrorContribution);
                    _cmdSql6.Parameters.AddWithValue("@PerDayContribution", PerDayContribution);

                    _cmdSql6.Parameters.AddWithValue("@OpolTxnSysID", _MtrVContributionMdl.OpolTxnSysID);

                    //Difference of added value and previous value
                    diff = NetContribution - _MtrVContributionMdl.NetContribution;


                    int _TxnSysId3;
                    _conSql6.Open();
                    _TxnSysId3 = (Int32)_cmdSql6.ExecuteScalar();
                    _conSql6.Close();

                    _MtrVContributionMdl1.TxnSysID = _TxnSysId3;
                    //  _ProductConditionsSetupMdl.ConditionShText = GetConditionByCode(_ProductConditionsSetupMdl.Condition);
                    _MtrVContributionMdl1.IsValidTxn = true;


                    //To update Contribution of Vehicle Certificate
                    SqlConnection _conSql7 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql7 = new StringBuilder();
                    SqlCommand _cmdSql7;

                    _sbSql7.AppendLine("Update  MtrVehicleDetails SET");
                    _sbSql7.AppendLine("Contribution= @Contribution");
                    _sbSql7.AppendLine("WHERE TxnSysId= "+_TxnSysId2);

                    _cmdSql7 = new SqlCommand(_sbSql7.ToString(), _conSql7);


                    _cmdSql7.Parameters.AddWithValue("@Contribution", NetContribution);

                    _conSql7.Open();
                    _cmdSql7.ExecuteNonQuery();
                    _conSql7.Close();

                    //Insert values in to InsContribution
                    SqlConnection _conSql10 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql10 = new StringBuilder();
                    SqlCommand _cmdSql10;

                    _sbSql10.AppendLine("INSERT INTO InsContribution(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql10.AppendLine("TxnSysDate,");
                    _sbSql10.AppendLine("UserCode,");
                    _sbSql10.AppendLine("SumCovered,");
                    _sbSql10.AppendLine("Rate,");
                    _sbSql10.AppendLine("NetContribution,");
                    _sbSql10.AppendLine("GrossContribution,");
                    _sbSql10.AppendLine("FIF,");
                    _sbSql10.AppendLine("FED,");
                    _sbSql10.AppendLine("Stamp,");
                    _sbSql10.AppendLine("BasicContribution,");
                    _sbSql10.AppendLine("PEV,");
                    _sbSql10.AppendLine("BeforePEV,");
                    _sbSql10.AppendLine("TerrorContribution,");
                    _sbSql10.AppendLine("RiskTxnID,");
                    _sbSql10.AppendLine("OpolTxnSysID,");
                    _sbSql10.AppendLine("PerDayContribution)");

                    _sbSql10.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                    //_sbSql.AppendLine("@TxnSysID,");
                    _sbSql10.AppendLine("@TxnSysDate,");
                    _sbSql10.AppendLine("@UserCode,");
                    _sbSql10.AppendLine("@SumCovered,");
                    _sbSql10.AppendLine("@Rate,");
                    _sbSql10.AppendLine("@NetContribution,");
                    _sbSql10.AppendLine("@GrossContribution,");
                    _sbSql10.AppendLine("@FIF,");
                    _sbSql10.AppendLine("@FED,");
                    _sbSql10.AppendLine("@Stamp,");
                    _sbSql10.AppendLine("@BasicContribution,");
                    _sbSql10.AppendLine("@PEV,");
                    _sbSql10.AppendLine("@BeforePEV,");
                    _sbSql10.AppendLine("@TerrorContribution,");
                    _sbSql10.AppendLine("@RiskTxnID,");
                    _sbSql10.AppendLine("@OpolTxnSysID,");
                    _sbSql10.AppendLine("@PerDayContribution)");

                    _cmdSql10 = new SqlCommand(_sbSql10.ToString(), _conSql10);

                    _cmdSql10.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql10.Parameters.AddWithValue("@RiskTxnID", _TxnSysId2);

                    decimal _SumCovered1 = diff;
                    decimal _RateV1 = _VehicleDetailMdl1.Rate;




                    decimal NetContribution1 = _MtrVContributionMdl.NetContribution - NetContribution;
                    decimal GrossContribution1 = _MtrVContributionMdl.GrossContribution - GrossContribution;



                    decimal BeforePEV1 = (GrossContribution1 - _MtrVContributionMdl.TerrorContribution);
                    decimal PEV1 = (BeforePEV1 - _MtrVContributionMdl.BasicContribution);


                    //To get Tenure
                    DataTable _tbl10 = new DataTable();
                    //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = " + InsPolicyTxnID, conn);



                        SqlDataAdapter _adpSql10 = new SqlDataAdapter(command);


                        _adpSql10.Fill(_tbl10);
                    }

                    // _adpSql.Fill(_tbl);

                    if (_tbl10.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tbl10.Rows.Count; i++)
                        {
                            _MtrVContributionMdl1 = new MtrVContributionMdl();
                            _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl10.Rows[i]["tenure"]);

                        }


                    }
                    else
                    {
                        _MtrVContributionMdl1.Tenure = 1;
                    }


                    decimal PerDayContribution1 = GrossContribution1 / _MtrVContributionMdl1.Tenure;


                    _cmdSql10.Parameters.AddWithValue("@SumCovered", _MtrVContributionMdl.SumCovered - _SumCovered);

                    int _userCode2 = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl.UserCode);

                    _cmdSql10.Parameters.AddWithValue("@UserCode", _userCode);

                    _cmdSql10.Parameters.AddWithValue("@Rate", _RateV1);
                    _cmdSql10.Parameters.AddWithValue("@NetContribution", _MtrVContributionMdl.NetContribution - NetContribution);
                    _cmdSql10.Parameters.AddWithValue("@GrossContribution", _MtrVContributionMdl.GrossContribution - GrossContribution );
                    _cmdSql10.Parameters.AddWithValue("@FIF", _MtrVContributionMdl.FIF);
                    _cmdSql10.Parameters.AddWithValue("@FED", FEDU);
                    _cmdSql10.Parameters.AddWithValue("@Stamp", stamp);
                    _cmdSql10.Parameters.AddWithValue("@BasicContribution", _MtrVContributionMdl.BasicContribution);
                    _cmdSql10.Parameters.AddWithValue("@PEV", PEV1);
                    _cmdSql10.Parameters.AddWithValue("@BeforePEV", BeforePEV1);
                    _cmdSql10.Parameters.AddWithValue("@TerrorContribution", _MtrVContributionMdl.TerrorContribution);
                    _cmdSql10.Parameters.AddWithValue("@PerDayContribution", PerDayContribution1);

                    _cmdSql10.Parameters.AddWithValue("@OpolTxnSysID", _MtrVContributionMdl.OpolTxnSysID);

                    int _TxnSysId4;
                    _conSql10.Open();
                    _TxnSysId4 = (Int32)_cmdSql10.ExecuteScalar();
                    _conSql10.Close();

                    _MtrVContributionMdl1.TxnSysID = _TxnSysId4;

                    _MtrVContributionMdl1.IsValidTxn = true;


                    //For CoInsurance 
                    if (_VehicleDetailMdl.InsuranceTypeCode == 2 || _VehicleDetailMdl.InsuranceTypeCode == 3)
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
                                _InsCoInsuranceA1.TerrorContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["TerrorContribution "]);


                                _InsCoInsuranceListA1.Add(_InsCoInsuranceA1);
                            }

                            //Insert InTo CoInsurance for Endorsement
                            SqlConnection _conSqlA2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                            StringBuilder _sbSqlA2 = new StringBuilder();
                            SqlCommand _cmdSqlA2;
                            InsCoInsurance[] ConInsList = _InsCoInsuranceListA1.ToArray();


                            for (int i = 0; i < ConInsList.Length; i++)
                            {
                                _sbSqlA2 = new StringBuilder();

                                decimal SumCovered = 0;
                                SumCovered =  _MtrVContributionMdl.SumCovered - _SumCovered;
                                decimal NetC = 0;
                                NetC =  _MtrVContributionMdl.NetContribution - NetContribution;
                                decimal GrossC = 0;
                                GrossC =  _MtrVContributionMdl.GrossContribution - GrossContribution;


                                //To get Tenure
                                DataTable _tbl = new DataTable();
                                InsCoInsurance _InsCoInsuranceTe = new InsCoInsurance();

                                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                                {
                                    SqlCommand command =
                                        new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip INNER JOIN MtrVehicleDetails mvd ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE mvd.TxnSysID = @TxnSysID", conn);

                                    command.Parameters.Add(new SqlParameter("@TxnSysID", _VehicleDetailMdl1.TxnSysID));

                                    SqlDataAdapter _adpSqlTe = new SqlDataAdapter(command);


                                    _adpSqlTe.Fill(_tbl);
                                }

                                // _adpSql.Fill(_tbl);

                                if (_tbl.Rows.Count > 0)
                                {
                                    for (int j = 0; j < _tbl.Rows.Count; j++)
                                    {
                                        _InsCoInsuranceTe = new InsCoInsurance();
                                        _InsCoInsuranceTe.Tenure = Convert.ToInt32(_tbl.Rows[j]["tenure"]);

                                    }


                                }
                                else
                                {
                                    _InsCoInsuranceTe.Tenure = 1;
                                }

                                int SumCo = 0;
                                SumCo = Convert.ToInt32(SumCovered * (ConInsList[i].CoInsuranceShare / 100));
                                decimal NetCo = 0;
                                NetCo = NetC * (ConInsList[i].CoInsuranceShare / 100);
                                decimal GrossCo = 0;
                                GrossCo = GrossC * (ConInsList[i].CoInsuranceShare / 100);
                                decimal PerDayCo = 0;
                                PerDayCo = GrossCo / _InsCoInsuranceTe.Tenure;





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
                                _sbSqlA2.AppendLine("@RiskTxnID,");
                                _sbSqlA2.AppendLine("@OpolTxnSysID,");
                                _sbSqlA2.AppendLine("@PerDayContribution,");
                                _sbSqlA2.AppendLine("@CoInsuranceCode,");
                                _sbSqlA2.AppendLine("@CoInsuranceShare)");


                                _cmdSqlA2 = new SqlCommand(_sbSqlA2.ToString(), _conSqlA2);

                                _cmdSqlA2.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                                _cmdSqlA2.Parameters.AddWithValue("@RiskTxnID", _TxnSysId2);
                                _cmdSqlA2.Parameters.AddWithValue("@SumCovered", SumCo);

                                int _userCodeA2 = GlobalDataLayer.GetUserCodeById(ConInsList[i].UserCode);

                                _cmdSqlA2.Parameters.AddWithValue("@UserCode", _userCodeA2);


                                _cmdSqlA2.Parameters.AddWithValue("@Rate", ConInsList[i].Rate);
                                _cmdSqlA2.Parameters.AddWithValue("@NetContribution", NetCo);
                                _cmdSqlA2.Parameters.AddWithValue("@GrossContribution", GrossCo);
                                _cmdSqlA2.Parameters.AddWithValue("@FIF", ConInsList[i].FIF);
                                _cmdSqlA2.Parameters.AddWithValue("@FED", FEDU);
                                _cmdSqlA2.Parameters.AddWithValue("@Stamp", ConInsList[i].Stamp);
                                _cmdSqlA2.Parameters.AddWithValue("@BasicContribution", ConInsList[i].BasicContribution);
                                _cmdSqlA2.Parameters.AddWithValue("@PEV", ConInsList[i].PEV);
                                _cmdSqlA2.Parameters.AddWithValue("@BeforePEV", ConInsList[i].BeforePEV);
                                _cmdSqlA2.Parameters.AddWithValue("@TerrorContribution", ConInsList[i].TerrorContribution);
                                // _cmdSqlA2.Parameters.AddWithValue("@RiskTxnID", ConInsList[i].RiskTxnID);
                                _cmdSqlA2.Parameters.AddWithValue("@OpolTxnSysID", ConInsList[i].OpolTxnSysID);
                                _cmdSqlA2.Parameters.AddWithValue("@PerDayContribution", PerDayCo);
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



                }

                //To Decrease Sum Covered
                if (_EndtReasonMdl1.EndtReasonCode == 4)
                {
                    _Rate = _MtrVContributionMdl.Rate;

                    //Convert FED To Zero if 180 days Passed
                    DataTable _tblFED = new DataTable();
                    //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,'" + DateTime.Now + "') diff  FROM InsPolicy ip INNER JOIN MtrVehicleDetails mvd ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE mvd.TxnSysID = " + _VehicleDetailMdl1.TxnSysID, conn);



                        SqlDataAdapter _adpSql8 = new SqlDataAdapter(command);


                        _adpSql8.Fill(_tblFED);
                    }

                    // _adpSql.Fill(_tbl);

                    if (_tblFED.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblFED.Rows.Count; i++)
                        {

                            days = Convert.ToInt32(_tblFED.Rows[i]["diff"]);

                        }


                    }
                    else
                    {
                        days = 0;
                    }

                    if (days == 180)
                    {
                        FEDU = 0;
                    }

                    else
                    {
                        FEDU = _MtrVContributionMdl.FED;
                    }



                    //Get Values From MtrVehicle Detail by TxnID
                    SqlConnection _conSql3 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    string _sqlString3 = "SELECT * FROM MtrVehicleDetails mvd WHERE mvd.TxnSysID =  " + _VehicleDetailMdl1.TxnSysID;

                    SqlDataAdapter _adpSql3 = new SqlDataAdapter(_sqlString3, _conSql3);
                    DataTable _tblSqla3 = new DataTable();


                    _adpSql3.Fill(_tblSqla3);

                    if (_tblSqla3.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla3.Rows.Count; i++)
                        {
                            _VehicleDetailMdl = new VehicleDetailMdl();

                            _VehicleDetailMdl.TxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["TxnSysID"]);
                            _VehicleDetailMdl.TxnSysDate = Convert.ToDateTime(_tblSqla3.Rows[i]["TxnSysDate"]);
                            _VehicleDetailMdl.UserCode = Convert.ToInt32(_tblSqla3.Rows[i]["UserCode"]);
                            _VehicleDetailMdl.SerialNo = Convert.ToInt32(_tblSqla3.Rows[i]["SerialNo"].ToString());
                            _VehicleDetailMdl.VehicleCode = Convert.ToInt32(_tblSqla3.Rows[i]["VehicleCode"].ToString());
                            _VehicleDetailMdl.VehicleModel = Convert.ToInt32(_tblSqla3.Rows[i]["VehicleModel"].ToString());
                            _VehicleDetailMdl.UpdatedValue = Convert.ToDecimal(_tblSqla3.Rows[i]["UpdatedValue"]);
                            _VehicleDetailMdl.PreviousValue = Convert.ToDecimal(_tblSqla3.Rows[i]["PreviousValue"]);
                            _VehicleDetailMdl.Mileage = Convert.ToInt32(_tblSqla3.Rows[i]["Mileage"].ToString());
                            _VehicleDetailMdl.ParticipantValue = Convert.ToDecimal(_tblSqla3.Rows[i]["ParticipantValue"]);
                            _VehicleDetailMdl.ColorCode = Convert.ToInt32(_tblSqla3.Rows[i]["ColorCode"].ToString());
                            _VehicleDetailMdl.ParticipantName = _tblSqla3.Rows[i]["ParticipantName"].ToString();
                            _VehicleDetailMdl.ParticipantAddress = _tblSqla3.Rows[i]["ParticipantAddress"].ToString();
                            // _VehicleDetailMdl.ModelNumber = Convert.ToInt32(_tblSqla.Rows[i]["ModelNumber"]);
                            _VehicleDetailMdl.RegistrationNumber = _tblSqla3.Rows[i]["RegistrationNumber"].ToString();
                            _VehicleDetailMdl.CityCode = _tblSqla3.Rows[i]["CityCode"].ToString();
                            _VehicleDetailMdl.EngineNumber = _tblSqla3.Rows[i]["EngineNumber"].ToString();
                            _VehicleDetailMdl.AreaCode = Convert.ToInt32(_tblSqla3.Rows[i]["AreaCode"].ToString());
                            _VehicleDetailMdl.ChasisNumber = _tblSqla3.Rows[i]["ChasisNumber"].ToString();
                            _VehicleDetailMdl.Remarks = _tblSqla3.Rows[i]["Remarks"].ToString();
                            _VehicleDetailMdl.PODate = Convert.ToDateTime(_tblSqla3.Rows[i]["PODate"]);
                            _VehicleDetailMdl.PONumber = (_tblSqla3.Rows[i]["PONumber"].ToString());
                            _VehicleDetailMdl.CNICNumber = _tblSqla3.Rows[i]["CNICNumber"].ToString();
                            _VehicleDetailMdl.Tenure = _tblSqla3.Rows[i]["Tenure"].ToString();
                            _VehicleDetailMdl.BirthDate = Convert.ToDateTime(_tblSqla3.Rows[i]["BirthDate"]);
                            _VehicleDetailMdl.Gender = _tblSqla3.Rows[i]["Gender"].ToString();
                            _VehicleDetailMdl.VehicleType = _tblSqla3.Rows[i]["VehicleType"].ToString();
                            _VehicleDetailMdl.VEODCode = Convert.ToInt32(_tblSqla3.Rows[i]["VEODCode"]);
                            _VehicleDetailMdl.CertTypeCode = _tblSqla3.Rows[i]["CertTypeCode"].ToString();
                            _VehicleDetailMdl.Rate = Convert.ToDecimal(_tblSqla3.Rows[i]["Rate"]);
                            _VehicleDetailMdl.Contribution = Convert.ToInt32(_tblSqla3.Rows[i]["Contribution"]);
                            _VehicleDetailMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["ParentTxnSysID"]);
                            _VehicleDetailMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["OpolTxnSysID"]);

                            _VehicleDetailMdl.VEODName = GlobalDataLayer.GetVEODNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["VEODCode"]));
                            _VehicleDetailMdl.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_tblSqla3.Rows[i]["VehicleType"].ToString());

                            _VehicleDetailMdl.InsuranceTypeCode = Convert.ToInt32(_tblSqla3.Rows[i]["InsuranceTypeCode"]);
                            _VehicleDetailMdl.IsActive = Convert.ToBoolean(_tblSqla3.Rows[i]["IsActive"]);
                            _VehicleDetailMdl.IsCanceled = Convert.ToBoolean(_tblSqla3.Rows[i]["IsCanceled"]);
                            _VehicleDetailMdl.CommisionRate = Convert.ToDecimal(_tblSqla3.Rows[i]["CommisionRate"]);
                            _VehicleDetailMdl.MobileNumber = _tblSqla3.Rows[i]["MobileNumber"].ToString();
                            _VehicleDetailMdl.ResNumber = _tblSqla3.Rows[i]["ResNumber"].ToString();
                            _VehicleDetailMdl.OfficeNumber = _tblSqla3.Rows[i]["OfficeNumber"].ToString();

                            _VehicleDetailMdl.EmailAddress = _tblSqla3.Rows[i]["EmailAddress"].ToString();
                            _VehicleDetailMdl.Deductible = Convert.ToDecimal(_tblSqla3.Rows[i]["Deductible"]);

                            _VehicleDetailMdl.ContractMatDate = Convert.ToDateTime(_tblSqla3.Rows[i]["ContractMatDate"]);

                            _VehicleDetailMdl.RatingFactor = _tblSqla3.Rows[i]["RatingFactor"].ToString();
                            _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_tblSqla3.Rows[i]["RatingFactor"].ToString());

                            _VehicleDetailMdl.GenderName = GlobalDataLayer.GetGenderNameByCode(_tblSqla3.Rows[i]["Gender"].ToString());
                            _VehicleDetailMdl.CityName = GlobalDataLayer.GetCityNameByCode(_tblSqla3.Rows[i]["CityCode"].ToString());
                            _VehicleDetailMdl.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["ColorCode"].ToString()));
                            _VehicleDetailMdl.VehicleName = GlobalDataLayer.GetVehicleNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["VehicleCode"].ToString()));
                            _VehicleDetailMdl.AreaName = GlobalDataLayer.GetAreaNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["AreaCode"].ToString()));
                            _VehicleDetailMdl.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_tblSqla3.Rows[i]["CertTypeCode"].ToString());
                            _VehicleDetailMdl.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["InsuranceTypeCode"]));

                            _VehicleDetailMdl.total = GlobalDataLayer.calculate(_VehicleDetailMdl);


                            _VehicleDetailMdlList.Add(_VehicleDetailMdl);


                        }
                    }


                    //Insert Into Vehicle Details
                    SqlConnection _conSql4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql4 = new StringBuilder();
                    SqlCommand _cmdSql4;
                    int _SerialNumber1 = GetSerialNo1(_VehicleDetailMdl);


                    _sbSql4.AppendLine("INSERT INTO MtrVehicleDetails(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql4.AppendLine("TxnSysDate,");
                    _sbSql4.AppendLine("UserCode,");
                    _sbSql4.AppendLine("SerialNo,");
                    _sbSql4.AppendLine("VehicleCode,");
                    _sbSql4.AppendLine("VehicleModel,");
                    _sbSql4.AppendLine("UpdatedValue,");
                    _sbSql4.AppendLine("PreviousValue,");
                    _sbSql4.AppendLine("Mileage,");
                    _sbSql4.AppendLine("ParticipantValue,");
                    _sbSql4.AppendLine("ColorCode,");
                    _sbSql4.AppendLine("ParticipantName,");
                    _sbSql4.AppendLine("ParticipantAddress,");
                    // _sbSql.AppendLine("ModelNumber,");
                    _sbSql4.AppendLine("RegistrationNumber,");
                    _sbSql4.AppendLine("CityCode,");
                    _sbSql4.AppendLine("EngineNumber,");
                    _sbSql4.AppendLine("AreaCode,");
                    _sbSql4.AppendLine("ChasisNumber,");
                    _sbSql4.AppendLine("Remarks,");
                    _sbSql4.AppendLine("PODate,");
                    _sbSql4.AppendLine("PONumber,");
                    _sbSql4.AppendLine("CNICNumber,");
                    _sbSql4.AppendLine("Tenure,");
                    _sbSql4.AppendLine("BirthDate,");
                    _sbSql4.AppendLine("Gender,");
                    _sbSql4.AppendLine("VehicleType,");
                    _sbSql4.AppendLine("VEODCode,");
                    _sbSql4.AppendLine("CertTypeCode,");
                    _sbSql4.AppendLine("Rate,");
                    _sbSql4.AppendLine("ParentTxnSysID,");
                    _sbSql4.AppendLine("OpolTxnSysID,");
                    _sbSql4.AppendLine("InsuranceTypeCode,");
                    _sbSql4.AppendLine("CommisionRate,");
                    _sbSql4.AppendLine("MobileNumber,");
                    _sbSql4.AppendLine("ResNumber,");
                    _sbSql4.AppendLine("OfficeNumber,");
                    _sbSql4.AppendLine("EmailAddress,");
                    _sbSql4.AppendLine("Deductible,");
                    _sbSql4.AppendLine("ContractMatDate,");
                    _sbSql4.AppendLine("RatingFactor,");
                    _sbSql4.AppendLine("Contribution)");


                    _sbSql4.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                    // _sbSql.AppendLine("@TxnSysID,");
                    _sbSql4.AppendLine("@TxnSysDate,");
                    _sbSql4.AppendLine("@UserCode,");
                    _sbSql4.AppendLine("@SerialNo,");
                    _sbSql4.AppendLine("@VehicleCode,");
                    _sbSql4.AppendLine("@VehicleModel,");
                    _sbSql4.AppendLine("@UpdatedValue,");
                    _sbSql4.AppendLine("@PreviousValue,");
                    _sbSql4.AppendLine("@Mileage,");
                    _sbSql4.AppendLine("@ParticipantValue,");
                    _sbSql4.AppendLine("@ColorCode,");
                    _sbSql4.AppendLine("@ParticipantName,");
                    _sbSql4.AppendLine("@ParticipantAddress,");
                    // _sbSql.AppendLine("@ModelNumber,");
                    _sbSql4.AppendLine("@RegistrationNumber,");
                    _sbSql4.AppendLine("@CityCode,");
                    _sbSql4.AppendLine("@EngineNumber,");
                    _sbSql4.AppendLine("@AreaCode,");
                    _sbSql4.AppendLine("@ChasisNumber,");
                    _sbSql4.AppendLine("@Remarks,");
                    _sbSql4.AppendLine("@PODate,");
                    _sbSql4.AppendLine("@PONumber,");
                    _sbSql4.AppendLine("@CNICNumber,");
                    _sbSql4.AppendLine("@Tenure,");
                    _sbSql4.AppendLine("@BirthDate,");
                    _sbSql4.AppendLine("@Gender,");
                    _sbSql4.AppendLine("@VehicleType,");
                    _sbSql4.AppendLine("@VEODCode,");
                    _sbSql4.AppendLine("@CertTypeCode,");
                    _sbSql4.AppendLine("@Rate,");
                    _sbSql4.AppendLine("@ParentTxnSysID,");
                    _sbSql4.AppendLine("(SELECT ip.OpolTxnSysID FROM InsPolicy ip WHERE ip.ParentTxnSysID = @ParentTxnSysID),");
                    _sbSql4.AppendLine("@InsuranceTypeCode,");
                    _sbSql4.AppendLine("@CommisionRate,");
                    _sbSql4.AppendLine("@MobileNumber,");
                    _sbSql4.AppendLine("@ResNumber,");
                    _sbSql4.AppendLine("@OfficeNumber,");
                    _sbSql4.AppendLine("@EmailAddress,");
                    _sbSql4.AppendLine("@Deductible,");
                    _sbSql4.AppendLine("@ContractMatDate,");
                    _sbSql4.AppendLine("@RatingFactor,");
                    _sbSql4.AppendLine("@Contribution)");


                    _cmdSql4 = new SqlCommand(_sbSql4.ToString(), _conSql4);




                    DateTime da = DateTime.Now;
                    da.ToString("MM-dd-yyyy h:mm tt");

                    _cmdSql4.Parameters.AddWithValue("@TxnSysDate", Convert.ToDateTime(da));
                    _cmdSql4.Parameters.AddWithValue("@ParentTxnSysID", _TxnSysId);
                    int _userCode = GlobalDataLayer.GetUserCodeById(_VehicleDetailMdl.UserCode);
                    _cmdSql4.Parameters.AddWithValue("@UserCode", _userCode);

                    _cmdSql4.Parameters.AddWithValue("@RatingFactor", _VehicleDetailMdl.RatingFactor);
                    _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_VehicleDetailMdl.RatingFactor);

                    _cmdSql4.Parameters.AddWithValue("@SerialNo", _SerialNumber1);
                    _cmdSql4.Parameters.AddWithValue("@VehicleCode", _VehicleDetailMdl.VehicleCode);
                    _cmdSql4.Parameters.AddWithValue("@VehicleModel", _VehicleDetailMdl.VehicleModel);
                    _cmdSql4.Parameters.AddWithValue("@UpdatedValue", _VehicleDetailMdl.UpdatedValue);
                    _cmdSql4.Parameters.AddWithValue("@PreviousValue", _VehicleDetailMdl.PreviousValue);
                    _cmdSql4.Parameters.AddWithValue("@Mileage", _VehicleDetailMdl.Mileage);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantValue", _VehicleDetailMdl1.ParticipantValue);
                    _cmdSql4.Parameters.AddWithValue("@ColorCode", _VehicleDetailMdl.ColorCode);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantName", _VehicleDetailMdl.ParticipantName);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantAddress", _VehicleDetailMdl.ParticipantAddress);
                    // _cmdSql.Parameters.AddWithValue("@ModelNumber", _VehicleDetailMdl.ModelNumber);
                    _cmdSql4.Parameters.AddWithValue("@RegistrationNumber", _VehicleDetailMdl.RegistrationNumber);
                    _cmdSql4.Parameters.AddWithValue("@CityCode", _VehicleDetailMdl.CityCode);
                    _cmdSql4.Parameters.AddWithValue("@EngineNumber", _VehicleDetailMdl.EngineNumber);
                    _cmdSql4.Parameters.AddWithValue("@AreaCode", _VehicleDetailMdl.AreaCode);
                    _cmdSql4.Parameters.AddWithValue("@ChasisNumber", _VehicleDetailMdl.ChasisNumber);

                    //Add Remarks for addition
                    _cmdSql4.Parameters.AddWithValue("@Remarks", _VehicleDetailMdl1.Remarks ?? DBNull.Value.ToString());

                    _cmdSql4.Parameters.AddWithValue("@PODate", _VehicleDetailMdl.PODate);
                    _cmdSql4.Parameters.AddWithValue("@PONumber", _VehicleDetailMdl.PONumber);
                    _cmdSql4.Parameters.AddWithValue("@CNICNumber", _VehicleDetailMdl.CNICNumber);
                    _cmdSql4.Parameters.AddWithValue("@Tenure", _VehicleDetailMdl.Tenure);
                    _cmdSql4.Parameters.AddWithValue("@BirthDate", _VehicleDetailMdl.BirthDate);
                    _cmdSql4.Parameters.AddWithValue("@Gender", _VehicleDetailMdl.Gender);
                    _cmdSql4.Parameters.AddWithValue("@VehicleType", _VehicleDetailMdl.VehicleType);
                    _cmdSql4.Parameters.AddWithValue("@VEODCode", _VehicleDetailMdl.VEODCode);
                    _cmdSql4.Parameters.AddWithValue("@CertTypeCode", _VehicleDetailMdl.CertTypeCode);
                    _cmdSql4.Parameters.AddWithValue("@Rate", _VehicleDetailMdl.Rate);
                    _cmdSql4.Parameters.AddWithValue("@InsuranceTypeCode", _VehicleDetailMdl.InsuranceTypeCode);
                    _cmdSql4.Parameters.AddWithValue("@Contribution", _VehicleDetailMdl.Contribution);
                    _cmdSql4.Parameters.AddWithValue("@CommisionRate", _VehicleDetailMdl.CommisionRate);
                    _cmdSql4.Parameters.AddWithValue("@MobileNumber", _VehicleDetailMdl.MobileNumber);
                    _cmdSql4.Parameters.AddWithValue("@ResNumber", _VehicleDetailMdl.ResNumber);
                    _cmdSql4.Parameters.AddWithValue("@OfficeNumber", _VehicleDetailMdl.OfficeNumber);

                    _cmdSql4.Parameters.AddWithValue("@EmailAddress", _VehicleDetailMdl.EmailAddress);
                    _cmdSql4.Parameters.AddWithValue("@Deductible", _VehicleDetailMdl.Deductible);
                    _cmdSql4.Parameters.AddWithValue("@ContractMatDate", _VehicleDetailMdl.ContractMatDate);



                    _VehicleDetailMdl.SerialNo = _SerialNumber;

                    _VehicleDetailMdl.TxnSysDate = DateTime.Now;

                    _VehicleDetailMdl.VEODName = GlobalDataLayer.GetVEODNameByCode(_VehicleDetailMdl.VEODCode);
                    _VehicleDetailMdl.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_VehicleDetailMdl.VehicleType);
                    _VehicleDetailMdl.GenderName = GlobalDataLayer.GetGenderNameByCode(_VehicleDetailMdl.Gender);
                    _VehicleDetailMdl.CityName = GlobalDataLayer.GetCityNameByCode(_VehicleDetailMdl.CityCode);
                    _VehicleDetailMdl.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(_VehicleDetailMdl.ColorCode);
                    _VehicleDetailMdl.VehicleName = GlobalDataLayer.GetVehicleNameByCode(_VehicleDetailMdl.VehicleCode);
                    _VehicleDetailMdl.AreaName = GlobalDataLayer.GetAreaNameByCode(_VehicleDetailMdl.AreaCode);
                    _VehicleDetailMdl.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_VehicleDetailMdl.CertTypeCode);
                    _VehicleDetailMdl.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(_VehicleDetailMdl.InsuranceTypeCode);


                    _VehicleDetailMdl.total = GlobalDataLayer.calculate(_VehicleDetailMdl);

                    int _TxnSysId2;
                    _conSql4.Open();
                    _TxnSysId2 = (Int32)_cmdSql4.ExecuteScalar();
                    _conSql4.Close();
                    _VehicleDetailMdl.IsValidTxn = true;


                    //For Second Endorsemnt Get Values of Contribution from UpdateContribution
                    if (_MtrInsPolicyMdl.EndoSerial > 0)
                    {
                        //Get values From Ins Update Contribution
                        SqlConnection _conSql5A = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        DataTable _tblSqla5A = new DataTable();
                        // MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
                        List<MtrVContributionMdl> _MtrVContributionMdlListA = new List<MtrVContributionMdl>();

                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                        {
                            SqlCommand command =
                                new SqlCommand("SELECT * FROM InsUpdateContribution iuc INNER JOIN InsContribution ic ON ic.RiskTxnID = iuc.RiskTxnID WHERE ic.TxnSysID = @TxnSysID", conn);

                            command.Parameters.Add(new SqlParameter("@TxnSysID", ConTxnID));

                            SqlDataAdapter _adpSql5A = new SqlDataAdapter(command);


                            _adpSql5A.Fill(_tblSqla5A);
                        }



                        if (_tblSqla5A.Rows.Count > 0)
                        {
                            _MtrVContributionMdl = new MtrVContributionMdl();
                            for (int i = 0; i < _tblSqla5A.Rows.Count; i++)
                            {

                                _MtrVContributionMdl.TxnSysID = Convert.ToInt32(_tblSqla5A.Rows[i]["TxnSysID"]);
                                _MtrVContributionMdl.TxnSysDate = Convert.ToDateTime(_tblSqla5A.Rows[i]["TxnSysDate"]);
                                _MtrVContributionMdl.UserCode = Convert.ToInt32(_tblSqla5A.Rows[i]["UserCode"]);
                                _MtrVContributionMdl.SumCovered = Convert.ToInt32(_tblSqla5A.Rows[i]["SumCovered"]);
                                _MtrVContributionMdl.Rate = Convert.ToDecimal(_tblSqla5A.Rows[i]["Rate"]);
                                _MtrVContributionMdl.NetContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["NetContribution"]);
                                _MtrVContributionMdl.GrossContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["GrossContribution"]);
                                _MtrVContributionMdl.FIF = Convert.ToDecimal(_tblSqla5A.Rows[i]["FIF"]);
                                _MtrVContributionMdl.FED = Convert.ToDecimal(_tblSqla5A.Rows[i]["FED"]);
                                _MtrVContributionMdl.Stamp = Convert.ToDecimal(_tblSqla5A.Rows[i]["Stamp"]);
                                _MtrVContributionMdl.BasicContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["BasicContribution"]);
                                _MtrVContributionMdl.PEV = Convert.ToDecimal(_tblSqla5A.Rows[i]["PEV"]);
                                _MtrVContributionMdl.BeforePEV = Convert.ToDecimal(_tblSqla5A.Rows[i]["BeforePEV"]);
                                _MtrVContributionMdl.TerrorContribution = Convert.ToDecimal(_tblSqla5A.Rows[i]["TerrorContribution"]);
                                _MtrVContributionMdl.RiskTxnID = Convert.ToInt32(_tblSqla5A.Rows[i]["RiskTxnID"]);
                                _MtrVContributionMdl.PerDayContribution = Convert.ToInt32(_tblSqla5A.Rows[i]["PerDayContribution"]);
                                _MtrVContributionMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla5A.Rows[i]["OpolTxnSysID"]);

                            }


                        }


                        else
                        {

                        }
                    }

                    else
                    {
                        //Get values From InsContribution
                        SqlConnection _conSql5 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                        DataTable _tblSqla5 = new DataTable();
                        // MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
                        List<MtrVContributionMdl> _MtrVContributionMdlList = new List<MtrVContributionMdl>();

                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                        {
                            SqlCommand command =
                                new SqlCommand("SELECT *  FROM InsContribution Where  TxnSysID = @TxnSysID", conn);

                            command.Parameters.Add(new SqlParameter("@TxnSysID", ConTxnID));

                            SqlDataAdapter _adpSql5 = new SqlDataAdapter(command);


                            _adpSql5.Fill(_tblSqla5);
                        }



                        if (_tblSqla5.Rows.Count > 0)
                        {
                            _MtrVContributionMdl = new MtrVContributionMdl();
                            for (int i = 0; i < _tblSqla5.Rows.Count; i++)
                            {

                                _MtrVContributionMdl.TxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["TxnSysID"]);
                                _MtrVContributionMdl.TxnSysDate = Convert.ToDateTime(_tblSqla5.Rows[i]["TxnSysDate"]);
                                _MtrVContributionMdl.UserCode = Convert.ToInt32(_tblSqla5.Rows[i]["UserCode"]);
                                _MtrVContributionMdl.SumCovered = Convert.ToInt32(_tblSqla5.Rows[i]["SumCovered"]);
                                _MtrVContributionMdl.Rate = Convert.ToDecimal(_tblSqla5.Rows[i]["Rate"]);
                                _MtrVContributionMdl.NetContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["NetContribution"]);
                                _MtrVContributionMdl.GrossContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["GrossContribution"]);
                                _MtrVContributionMdl.FIF = Convert.ToDecimal(_tblSqla5.Rows[i]["FIF"]);
                                _MtrVContributionMdl.FED = Convert.ToDecimal(_tblSqla5.Rows[i]["FED"]);
                                _MtrVContributionMdl.Stamp = Convert.ToDecimal(_tblSqla5.Rows[i]["Stamp"]);
                                _MtrVContributionMdl.BasicContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["BasicContribution"]);
                                _MtrVContributionMdl.PEV = Convert.ToDecimal(_tblSqla5.Rows[i]["PEV"]);
                                _MtrVContributionMdl.BeforePEV = Convert.ToDecimal(_tblSqla5.Rows[i]["BeforePEV"]);
                                _MtrVContributionMdl.TerrorContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["TerrorContribution"]);
                                _MtrVContributionMdl.RiskTxnID = Convert.ToInt32(_tblSqla5.Rows[i]["RiskTxnID"]);
                                _MtrVContributionMdl.PerDayContribution = Convert.ToInt32(_tblSqla5.Rows[i]["PerDayContribution"]);
                                _MtrVContributionMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["OpolTxnSysID"]);

                            }


                        }


                        else
                        {

                        }
                    }

                    //Insert values in to InsUpdateContribution
                    SqlConnection _conSql6 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql6 = new StringBuilder();
                    SqlCommand _cmdSql6;

                    _sbSql6.AppendLine("INSERT INTO InsUpdateContribution(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql6.AppendLine("TxnSysDate,");
                    _sbSql6.AppendLine("UserCode,");
                    _sbSql6.AppendLine("SumCovered,");
                    _sbSql6.AppendLine("Rate,");
                    _sbSql6.AppendLine("NetContribution,");
                    _sbSql6.AppendLine("GrossContribution,");
                    _sbSql6.AppendLine("FIF,");
                    _sbSql6.AppendLine("FED,");
                    _sbSql6.AppendLine("Stamp,");
                    _sbSql6.AppendLine("BasicContribution,");
                    _sbSql6.AppendLine("PEV,");
                    _sbSql6.AppendLine("BeforePEV,");
                    _sbSql6.AppendLine("TerrorContribution,");
                    _sbSql6.AppendLine("RiskTxnID,");
                    _sbSql6.AppendLine("OpolTxnSysID,");
                    _sbSql6.AppendLine("PerDayContribution)");

                    _sbSql6.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                    //_sbSql.AppendLine("@TxnSysID,");
                    _sbSql6.AppendLine("@TxnSysDate,");
                    _sbSql6.AppendLine("@UserCode,");
                    _sbSql6.AppendLine("@SumCovered,");
                    _sbSql6.AppendLine("@Rate,");
                    _sbSql6.AppendLine("@NetContribution,");
                    _sbSql6.AppendLine("@GrossContribution,");
                    _sbSql6.AppendLine("@FIF,");
                    _sbSql6.AppendLine("@FED,");
                    _sbSql6.AppendLine("@Stamp,");
                    _sbSql6.AppendLine("@BasicContribution,");
                    _sbSql6.AppendLine("@PEV,");
                    _sbSql6.AppendLine("@BeforePEV,");
                    _sbSql6.AppendLine("@TerrorContribution,");
                    _sbSql6.AppendLine("@RiskTxnID,");
                    _sbSql6.AppendLine("@OpolTxnSysID,");
                    _sbSql6.AppendLine("@PerDayContribution)");

                    _cmdSql6 = new SqlCommand(_sbSql6.ToString(), _conSql6);

                    _cmdSql6.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql6.Parameters.AddWithValue("@RiskTxnID", _TxnSysId2);

                    decimal _SumCovered = _VehicleDetailMdl1.ParticipantValue;
                    decimal _RateV = _VehicleDetailMdl.Rate;




                    decimal NetContribution = (_SumCovered * (_RateV / 100));
                    decimal GrossContribution = (NetContribution - stamp) / (((FEDU + _MtrVContributionMdl.FIF) / 100) + 1);



                    decimal BeforePEV = (GrossContribution - _MtrVContributionMdl.TerrorContribution);
                    decimal PEV = (BeforePEV - _MtrVContributionMdl.BasicContribution);


                    //To get Tenure
                    DataTable _tbl8 = new DataTable();
                    //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = " + InsPolicyTxnID, conn);



                        SqlDataAdapter _adpSql8 = new SqlDataAdapter(command);


                        _adpSql8.Fill(_tbl8);
                    }

                    // _adpSql.Fill(_tbl);

                    if (_tbl8.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tbl8.Rows.Count; i++)
                        {
                            _MtrVContributionMdl1 = new MtrVContributionMdl();
                            _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl8.Rows[i]["tenure"]);

                        }


                    }
                    else
                    {
                        _MtrVContributionMdl1.Tenure = 1;
                    }


                    decimal PerDayContribution = GrossContribution / _MtrVContributionMdl1.Tenure;


                    _cmdSql6.Parameters.AddWithValue("@SumCovered", _SumCovered);

                    int _userCode1 = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl.UserCode);

                    _cmdSql6.Parameters.AddWithValue("@UserCode", _userCode);

                    _cmdSql6.Parameters.AddWithValue("@Rate", _RateV);
                    _cmdSql6.Parameters.AddWithValue("@NetContribution", NetContribution);
                    _cmdSql6.Parameters.AddWithValue("@GrossContribution", GrossContribution);
                    _cmdSql6.Parameters.AddWithValue("@FIF", _MtrVContributionMdl.FIF);
                    _cmdSql6.Parameters.AddWithValue("@FED", FEDU);
                    _cmdSql6.Parameters.AddWithValue("@Stamp", stamp);
                    _cmdSql6.Parameters.AddWithValue("@BasicContribution", _MtrVContributionMdl.BasicContribution);
                    _cmdSql6.Parameters.AddWithValue("@PEV", PEV);
                    _cmdSql6.Parameters.AddWithValue("@BeforePEV", BeforePEV);
                    _cmdSql6.Parameters.AddWithValue("@TerrorContribution", _MtrVContributionMdl.TerrorContribution);
                    _cmdSql6.Parameters.AddWithValue("@PerDayContribution", PerDayContribution);

                    _cmdSql6.Parameters.AddWithValue("@OpolTxnSysID", _MtrVContributionMdl.OpolTxnSysID);

                    //Difference of added value and previous value
                    diff = NetContribution - _MtrVContributionMdl.NetContribution;


                    int _TxnSysId3;
                    _conSql6.Open();
                    _TxnSysId3 = (Int32)_cmdSql6.ExecuteScalar();
                    _conSql6.Close();

                    _MtrVContributionMdl1.TxnSysID = _TxnSysId3;
                    //  _ProductConditionsSetupMdl.ConditionShText = GetConditionByCode(_ProductConditionsSetupMdl.Condition);
                    _MtrVContributionMdl1.IsValidTxn = true;


                    //To update Contribution of Vehicle Certificate
                    SqlConnection _conSql7 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql7 = new StringBuilder();
                    SqlCommand _cmdSql7;

                    _sbSql7.AppendLine("Update  MtrVehicleDetails SET");
                    _sbSql7.AppendLine("Contribution= @Contribution");
                    _sbSql7.AppendLine("WHERE TxnSysId= "+_TxnSysId2);

                    _cmdSql7 = new SqlCommand(_sbSql7.ToString(), _conSql7);


                    _cmdSql7.Parameters.AddWithValue("@Contribution", NetContribution);

                    _conSql7.Open();
                    _cmdSql7.ExecuteNonQuery();
                    _conSql7.Close();

                    //Insert values in to InsContribution
                    SqlConnection _conSql10 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql10 = new StringBuilder();
                    SqlCommand _cmdSql10;

                    _sbSql10.AppendLine("INSERT INTO InsContribution(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql10.AppendLine("TxnSysDate,");
                    _sbSql10.AppendLine("UserCode,");
                    _sbSql10.AppendLine("SumCovered,");
                    _sbSql10.AppendLine("Rate,");
                    _sbSql10.AppendLine("NetContribution,");
                    _sbSql10.AppendLine("GrossContribution,");
                    _sbSql10.AppendLine("FIF,");
                    _sbSql10.AppendLine("FED,");
                    _sbSql10.AppendLine("Stamp,");
                    _sbSql10.AppendLine("BasicContribution,");
                    _sbSql10.AppendLine("PEV,");
                    _sbSql10.AppendLine("BeforePEV,");
                    _sbSql10.AppendLine("TerrorContribution,");
                    _sbSql10.AppendLine("RiskTxnID,");
                    _sbSql10.AppendLine("OpolTxnSysID,");
                    _sbSql10.AppendLine("PerDayContribution)");

                    _sbSql10.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                    //_sbSql.AppendLine("@TxnSysID,");
                    _sbSql10.AppendLine("@TxnSysDate,");
                    _sbSql10.AppendLine("@UserCode,");
                    _sbSql10.AppendLine("@SumCovered,");
                    _sbSql10.AppendLine("@Rate,");
                    _sbSql10.AppendLine("@NetContribution,");
                    _sbSql10.AppendLine("@GrossContribution,");
                    _sbSql10.AppendLine("@FIF,");
                    _sbSql10.AppendLine("@FED,");
                    _sbSql10.AppendLine("@Stamp,");
                    _sbSql10.AppendLine("@BasicContribution,");
                    _sbSql10.AppendLine("@PEV,");
                    _sbSql10.AppendLine("@BeforePEV,");
                    _sbSql10.AppendLine("@TerrorContribution,");
                    _sbSql10.AppendLine("@RiskTxnID,");
                    _sbSql10.AppendLine("@OpolTxnSysID,");
                    _sbSql10.AppendLine("@PerDayContribution)");

                    _cmdSql10 = new SqlCommand(_sbSql10.ToString(), _conSql10);

                    _cmdSql10.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql10.Parameters.AddWithValue("@RiskTxnID", _TxnSysId2);

                    decimal _SumCovered1 = diff;
                    decimal _RateV1 = _VehicleDetailMdl.Rate;




                    decimal NetContribution1 = _MtrVContributionMdl.NetContribution - NetContribution ;
                    decimal GrossContribution1 = _MtrVContributionMdl.GrossContribution - GrossContribution;



                    decimal BeforePEV1 = (GrossContribution1 - _MtrVContributionMdl.TerrorContribution);
                    decimal PEV1 = (BeforePEV1 - _MtrVContributionMdl.BasicContribution);


                    //To get Tenure
                    DataTable _tbl10 = new DataTable();
                    //  MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip WHERE ip.ParentTxnSysID = " + InsPolicyTxnID, conn);



                        SqlDataAdapter _adpSql10 = new SqlDataAdapter(command);


                        _adpSql10.Fill(_tbl10);
                    }

                    // _adpSql.Fill(_tbl);

                    if (_tbl10.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tbl10.Rows.Count; i++)
                        {
                            _MtrVContributionMdl1 = new MtrVContributionMdl();
                            _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl10.Rows[i]["tenure"]);

                        }


                    }
                    else
                    {
                        _MtrVContributionMdl1.Tenure = 1;
                    }


                    decimal PerDayContribution1 = GrossContribution1 / _MtrVContributionMdl1.Tenure;


                    _cmdSql10.Parameters.AddWithValue("@SumCovered", _MtrVContributionMdl.SumCovered - _SumCovered);

                    int _userCode2 = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl.UserCode);

                    _cmdSql10.Parameters.AddWithValue("@UserCode", _userCode);

                    _cmdSql10.Parameters.AddWithValue("@Rate", _RateV1);
                    _cmdSql10.Parameters.AddWithValue("@NetContribution", _MtrVContributionMdl.NetContribution - NetContribution);
                    _cmdSql10.Parameters.AddWithValue("@GrossContribution",  _MtrVContributionMdl.GrossContribution - NetContribution);
                    _cmdSql10.Parameters.AddWithValue("@FIF", _MtrVContributionMdl.FIF);
                    _cmdSql10.Parameters.AddWithValue("@FED", FEDU);
                    _cmdSql10.Parameters.AddWithValue("@Stamp", stamp);
                    _cmdSql10.Parameters.AddWithValue("@BasicContribution", _MtrVContributionMdl.BasicContribution);
                    _cmdSql10.Parameters.AddWithValue("@PEV", PEV1);
                    _cmdSql10.Parameters.AddWithValue("@BeforePEV", _MtrVContributionMdl.BeforePEV - BeforePEV);
                    _cmdSql10.Parameters.AddWithValue("@TerrorContribution", _MtrVContributionMdl.TerrorContribution);
                    _cmdSql10.Parameters.AddWithValue("@PerDayContribution", PerDayContribution1);

                    _cmdSql10.Parameters.AddWithValue("@OpolTxnSysID", _MtrVContributionMdl.OpolTxnSysID);

                    int _TxnSysId4;
                    _conSql10.Open();
                    _TxnSysId4 = (Int32)_cmdSql10.ExecuteScalar();
                    _conSql10.Close();

                    _MtrVContributionMdl1.TxnSysID = _TxnSysId4;

                    _MtrVContributionMdl1.IsValidTxn = true;


                    //For CoInsurance 
                    if (_VehicleDetailMdl.InsuranceTypeCode == 2 || _VehicleDetailMdl.InsuranceTypeCode == 3)
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
                                _InsCoInsuranceA1.TerrorContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["TerrorContribution "]);


                                _InsCoInsuranceListA1.Add(_InsCoInsuranceA1);
                            }

                            //Insert InTo CoInsurance for Endorsement
                            SqlConnection _conSqlA2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                            StringBuilder _sbSqlA2 = new StringBuilder();
                            SqlCommand _cmdSqlA2;
                            InsCoInsurance[] ConInsList = _InsCoInsuranceListA1.ToArray();


                            for (int i = 0; i < ConInsList.Length; i++)
                            {
                                _sbSqlA2 = new StringBuilder();

                                decimal SumCovered = 0;
                                SumCovered = _MtrVContributionMdl.SumCovered - _SumCovered;
                                decimal NetC = 0;
                                NetC = _MtrVContributionMdl.NetContribution - NetContribution;
                                decimal GrossC = 0;
                                GrossC = _MtrVContributionMdl.GrossContribution - GrossContribution;


                                //To get Tenure
                                DataTable _tbl = new DataTable();
                                InsCoInsurance _InsCoInsuranceTe = new InsCoInsurance();

                                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                                {
                                    SqlCommand command =
                                        new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip INNER JOIN MtrVehicleDetails mvd ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE mvd.TxnSysID = @TxnSysID", conn);

                                    command.Parameters.Add(new SqlParameter("@TxnSysID", _VehicleDetailMdl1.TxnSysID));

                                    SqlDataAdapter _adpSqlTe = new SqlDataAdapter(command);


                                    _adpSqlTe.Fill(_tbl);
                                }

                                // _adpSql.Fill(_tbl);

                                if (_tbl.Rows.Count > 0)
                                {
                                    for (int j = 0; j < _tbl.Rows.Count; j++)
                                    {
                                        _InsCoInsuranceTe = new InsCoInsurance();
                                        _InsCoInsuranceTe.Tenure = Convert.ToInt32(_tbl.Rows[j]["tenure"]);

                                    }


                                }
                                else
                                {
                                    _InsCoInsuranceTe.Tenure = 1;
                                }

                                int SumCo = 0;
                                SumCo = Convert.ToInt32(SumCovered * (ConInsList[i].CoInsuranceShare / 100));
                                decimal NetCo = 0;
                                NetCo = NetC * (ConInsList[i].CoInsuranceShare / 100);
                                decimal GrossCo = 0;
                                GrossCo = GrossC * (ConInsList[i].CoInsuranceShare / 100);
                                decimal PerDayCo = 0;
                                PerDayCo = GrossCo / _InsCoInsuranceTe.Tenure;





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
                                _sbSqlA2.AppendLine("@RiskTxnID,");
                                _sbSqlA2.AppendLine("@OpolTxnSysID,");
                                _sbSqlA2.AppendLine("@PerDayContribution,");
                                _sbSqlA2.AppendLine("@CoInsuranceCode,");
                                _sbSqlA2.AppendLine("@CoInsuranceShare)");


                                _cmdSqlA2 = new SqlCommand(_sbSqlA2.ToString(), _conSqlA2);

                                _cmdSqlA2.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                                _cmdSqlA2.Parameters.AddWithValue("@RiskTxnID", _TxnSysId2);
                                _cmdSqlA2.Parameters.AddWithValue("@SumCovered", SumCo);

                                int _userCodeA2 = GlobalDataLayer.GetUserCodeById(ConInsList[i].UserCode);

                                _cmdSqlA2.Parameters.AddWithValue("@UserCode", _userCodeA2);


                                _cmdSqlA2.Parameters.AddWithValue("@Rate", ConInsList[i].Rate);
                                _cmdSqlA2.Parameters.AddWithValue("@NetContribution", NetCo);
                                _cmdSqlA2.Parameters.AddWithValue("@GrossContribution", GrossCo);
                                _cmdSqlA2.Parameters.AddWithValue("@FIF", ConInsList[i].FIF);
                                _cmdSqlA2.Parameters.AddWithValue("@FED", FEDU);
                                _cmdSqlA2.Parameters.AddWithValue("@Stamp", ConInsList[i].Stamp);
                                _cmdSqlA2.Parameters.AddWithValue("@BasicContribution", ConInsList[i].BasicContribution);
                                _cmdSqlA2.Parameters.AddWithValue("@PEV", ConInsList[i].PEV);
                                _cmdSqlA2.Parameters.AddWithValue("@BeforePEV", ConInsList[i].BeforePEV);
                                _cmdSqlA2.Parameters.AddWithValue("@TerrorContribution", ConInsList[i].TerrorContribution);
                                // _cmdSqlA2.Parameters.AddWithValue("@RiskTxnID", ConInsList[i].RiskTxnID);
                                _cmdSqlA2.Parameters.AddWithValue("@OpolTxnSysID", ConInsList[i].OpolTxnSysID);
                                _cmdSqlA2.Parameters.AddWithValue("@PerDayContribution", PerDayCo);
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

                }


                SqlConnection _conSql9 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                DataTable _tblSqla9 = new DataTable();
                VehicleDetailMdl _VehicleDetailMdl2;
                List<VehicleDetailMdl> _VehicleDetailMdlList2 = new List<VehicleDetailMdl>();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    string str = "SELECT TOP 1 mvd.TxnSysID, mvd.TxnSysDate, mvd.UserCode, mvd.SerialNo, " +
                        "mvd.VehicleCode, mvd.VehicleModel,  mvd.UpdatedValue, mvd.PreviousValue, mvd.Mileage, mvd.ParticipantValue, " +
                        "mvd.ColorCode, mvd.ParticipantName, mvd.ParticipantAddress, mvd.RegistrationNumber, mvd.CityCode, " +
                        "mvd.EngineNumber, mvd.AreaCode, mvd.ChasisNumber, mvd.Remarks, mvd.PODate, mvd.PONumber, mvd.CNICNumber, " +
                        "mvd.Tenure, mvd.BirthDate, mvd.Gender, mvd.VehicleType, mvd.VEODCode, mvd.CertTypeCode, mvd.Rate, " +
                        "mvd.Contribution, mvd.InsuranceTypeCode, mvd.CommisionRate, mvd.IsActive, mvd.IsCanceled, mvd.OpolTxnSysID, " +
                        "mvd.MobileNumber, mvd.ResNumber, mvd.OfficeNumber, mvd.EmailAddress, mvd.Deductible, mvd.ContractMatDate, " +
                        "mvd.ParentTxnSysID, mvd.ContractMatDate, " +
                        "ip.ParentTxnSysID InsPolicyID, ip.DocMonth, ip.DocString, ip.DocYear, ip.DocNo, ip.DocType, ip.GenerateAgainst," +
                        "ip.ProductCode, ip.PolicyTypeCode, ip.ClientCode, ip.AgencyCode, ip.CertInsureCode, ip.Remarks Remarks1, ip.BrchCoverNoteNo,ip.BrchCode, " +
                        "ip.LeaderPolicyNo, ip.LeaderEndNo, ip.IsFiler, ip.CalcType, ip.IsAuto, ip.EffectiveDate, ip.ExpiryDate, ip.SerialNo SerialNo1, " +
                        "ip.UWYear, ip.CreatedBy, ip.PostedBy, ip.IsPosted, ip.PostDate, ip.OpolTxnSysID OpolTxnSysID1, ip.RenewSysID, ip.PolSysID, " +
                        "ip.IsRenewal, ip.CommisionRate CommisionRate1, ic.TxnSysID ConTxnID, ic.SumCovered, ic.Rate Rate2, ic.NetContribution," +
                        " ic.GrossContribution, ic.FIF, ic.FED, ic.Stamp, ic.BasicContribution, ic.PEV, ic.BeforePEV, ic.TerrorContribution, ic.RiskTxnID, " +
                        "ic.PerDayContribution, ic.OpolTxnSysID OpolTxnSysID2, ic.IsActive, " +
                        "ip.DocString, ip.PolicyTypeCode ," +
                        "pp.RatingFactor FROM MtrVehicleDetails mvd " +
                        "INNER JOIN InsPolicy ip ON mvd.ParentTxnSysID = ip.ParentTxnSysID " +
                        "INNER JOIN InsContribution ic ON ic.RiskTxnID = mvd.TxnSysID " +
                        //"INNER JOIN MtrOpenPolicy mop ON mop.TxnSysID = mvd.OpolTxnSysID " +
                        "INNER JOIN MasterProductSetup mp ON mp.ProductCode = ip.ProductCode " +
                        "INNER JOIN ProductRatingFactorsProductSetup pp ON pp.PrdStpTxnSysId = mp.TxnSysID " +
                        "WHERE ip.IsActive <> 0 AND mvd.TxnSysID = (SELECT MAX(TxnSysID) FROM MtrVehicleDetails)";
                    SqlCommand command =
                        new SqlCommand(str, conn);



                    SqlDataAdapter _adpSql9 = new SqlDataAdapter(command);


                    _adpSql9.Fill(_tblSqla9);
                }


                if (_tblSqla9.Rows.Count > 0)
                {
                    _VehicleDetailMdl2 = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla9.Rows.Count; i++)
                    {

                        //Getting Vehicle Details
                        _VehicleDetailMdl2.TxnSysID = Convert.ToInt32(_tblSqla9.Rows[i]["TxnSysID"]);
                        _VehicleDetailMdl2.TxnSysDate = Convert.ToDateTime(_tblSqla9.Rows[i]["TxnSysDate"]);
                        _VehicleDetailMdl2.UserCode = Convert.ToInt32(_tblSqla9.Rows[i]["UserCode"]);
                        _VehicleDetailMdl2.SerialNo = Convert.ToInt32(_tblSqla9.Rows[i]["SerialNo"].ToString());
                        _VehicleDetailMdl2.VehicleCode = Convert.ToInt32(_tblSqla9.Rows[i]["VehicleCode"].ToString());
                        _VehicleDetailMdl2.VehicleModel = Convert.ToInt32(_tblSqla9.Rows[i]["VehicleModel"].ToString());
                        _VehicleDetailMdl2.UpdatedValue = Convert.ToDecimal(_tblSqla9.Rows[i]["UpdatedValue"]);
                        _VehicleDetailMdl2.PreviousValue = Convert.ToDecimal(_tblSqla9.Rows[i]["PreviousValue"]);
                        _VehicleDetailMdl2.Mileage = Convert.ToInt32(_tblSqla9.Rows[i]["Mileage"].ToString());
                        _VehicleDetailMdl2.ParticipantValue = Convert.ToDecimal(_tblSqla9.Rows[i]["ParticipantValue"]);
                        _VehicleDetailMdl2.ColorCode = Convert.ToInt32(_tblSqla9.Rows[i]["ColorCode"].ToString());
                        _VehicleDetailMdl2.ParticipantName = _tblSqla9.Rows[i]["ParticipantName"].ToString();
                        _VehicleDetailMdl2.ParticipantAddress = _tblSqla9.Rows[i]["ParticipantAddress"].ToString();
                        _VehicleDetailMdl2.ContractMatDate = Convert.ToDateTime(_tblSqla9.Rows[i]["ContractMatDate"]) ;

                        _VehicleDetailMdl2.RegistrationNumber = _tblSqla9.Rows[i]["RegistrationNumber"].ToString();
                        _VehicleDetailMdl2.CityCode = _tblSqla9.Rows[i]["CityCode"].ToString();
                        _VehicleDetailMdl2.EngineNumber = _tblSqla9.Rows[i]["EngineNumber"].ToString();
                        _VehicleDetailMdl2.AreaCode = Convert.ToInt32(_tblSqla9.Rows[i]["AreaCode"].ToString());
                        _VehicleDetailMdl2.ChasisNumber = _tblSqla9.Rows[i]["ChasisNumber"].ToString();
                        _VehicleDetailMdl2.Remarks = _tblSqla9.Rows[i]["Remarks"].ToString();
                       // _VehicleDetailMdl2.PODate = Convert.ToDateTime(_tblSqla9.Rows[i]["PODate"]);
                        _VehicleDetailMdl2.PONumber = (_tblSqla9.Rows[i]["PONumber"].ToString());
                        _VehicleDetailMdl2.CNICNumber = _tblSqla9.Rows[i]["CNICNumber"].ToString();
                        _VehicleDetailMdl2.Tenure = _tblSqla9.Rows[i]["Tenure"].ToString();
                        _VehicleDetailMdl2.BirthDate = Convert.ToDateTime(_tblSqla9.Rows[i]["BirthDate"]);
                        _VehicleDetailMdl2.Gender = _tblSqla9.Rows[i]["Gender"].ToString();
                        _VehicleDetailMdl2.VehicleType = _tblSqla9.Rows[i]["VehicleType"].ToString();
                        _VehicleDetailMdl2.VEODCode = Convert.ToInt32(_tblSqla9.Rows[i]["VEODCode"]);
                        _VehicleDetailMdl2.CertTypeCode = _tblSqla9.Rows[i]["CertTypeCode"].ToString();
                        _VehicleDetailMdl2.Rate = Convert.ToInt32(_tblSqla9.Rows[i]["Rate"]);
                        _VehicleDetailMdl2.Contribution = Convert.ToInt32(_tblSqla9.Rows[i]["Contribution"]);
                        _VehicleDetailMdl2.ParentTxnSysID = Convert.ToInt32(_tblSqla9.Rows[i]["ParentTxnSysID"]);
                        _VehicleDetailMdl2.OpolTxnSysID = Convert.ToInt32(_tblSqla9.Rows[i]["OpolTxnSysID"]);

                        _VehicleDetailMdl2.VEODName = GlobalDataLayer.GetVEODNameByCode(Convert.ToInt32(_tblSqla9.Rows[i]["VEODCode"]));
                        _VehicleDetailMdl2.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_tblSqla9.Rows[i]["VehicleType"].ToString());

                        _VehicleDetailMdl2.InsuranceTypeCode = Convert.ToInt32(_tblSqla9.Rows[i]["InsuranceTypeCode"]);
                        _VehicleDetailMdl2.IsActive = Convert.ToBoolean(_tblSqla9.Rows[i]["IsActive"]);
                        _VehicleDetailMdl2.IsCanceled = Convert.ToBoolean(_tblSqla9.Rows[i]["IsCanceled"]);
                        _VehicleDetailMdl2.CommisionRate = Convert.ToDecimal(_tblSqla9.Rows[i]["CommisionRate"]);
                        _VehicleDetailMdl2.MobileNumber = _tblSqla9.Rows[i]["MobileNumber"].ToString();
                        _VehicleDetailMdl2.ResNumber = _tblSqla9.Rows[i]["ResNumber"].ToString();
                        _VehicleDetailMdl2.OfficeNumber = _tblSqla9.Rows[i]["OfficeNumber"].ToString();

                        _VehicleDetailMdl2.EmailAddress = _tblSqla9.Rows[i]["EmailAddress"].ToString();
                        _VehicleDetailMdl2.Deductible = Convert.ToDecimal(_tblSqla9.Rows[i]["Deductible"]);

                        _VehicleDetailMdl2.ContractMatDate = Convert.ToDateTime(_tblSqla9.Rows[i]["ContractMatDate"]);


                        _VehicleDetailMdl2.GenderName = GlobalDataLayer.GetGenderNameByCode(_tblSqla9.Rows[i]["Gender"].ToString());
                        _VehicleDetailMdl2.CityName = GlobalDataLayer.GetCityNameByCode(_tblSqla9.Rows[i]["CityCode"].ToString());
                        _VehicleDetailMdl2.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(Convert.ToInt32(_tblSqla9.Rows[i]["ColorCode"].ToString()));
                        _VehicleDetailMdl2.VehicleName = GlobalDataLayer.GetVehicleNameByCode(Convert.ToInt32(_tblSqla9.Rows[i]["VehicleCode"].ToString()));
                        _VehicleDetailMdl2.AreaName = GlobalDataLayer.GetAreaNameByCode(Convert.ToInt32(_tblSqla9.Rows[i]["AreaCode"].ToString()));
                        _VehicleDetailMdl2.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_tblSqla9.Rows[i]["CertTypeCode"].ToString());
                        _VehicleDetailMdl2.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla9.Rows[i]["InsuranceTypeCode"]));

                        _VehicleDetailMdl2.total = GlobalDataLayer.calculate(_VehicleDetailMdl);

                        //For InsPolicy
                        _VehicleDetailMdl2.InsPolicyID = Convert.ToInt32(_tblSqla9.Rows[i]["InsPolicyID"]);
                        _VehicleDetailMdl2.CertMonth = _tblSqla9.Rows[i]["DocMonth"].ToString();
                        _VehicleDetailMdl2.CertString = _tblSqla9.Rows[i]["DocString"].ToString();
                        _VehicleDetailMdl2.CertYear = _tblSqla9.Rows[i]["DocYear"].ToString();
                        _VehicleDetailMdl2.CertNo = Convert.ToInt32(_tblSqla9.Rows[i]["DocNo"]);
                        _VehicleDetailMdl2.DocType = _tblSqla9.Rows[i]["DocType"].ToString();
                        _VehicleDetailMdl2.GenerateAgainst = _tblSqla9.Rows[i]["GenerateAgainst"].ToString();
                        _VehicleDetailMdl2.ProductCode = Convert.ToInt32(_tblSqla9.Rows[i]["ProductCode"]);
                        _VehicleDetailMdl2.PolicyTypeCode = _tblSqla9.Rows[i]["PolicyTypeCode"].ToString();
                        _VehicleDetailMdl2.ClientCode = _tblSqla9.Rows[i]["ClientCode"].ToString();
                        _VehicleDetailMdl2.AgencyCode = _tblSqla9.Rows[i]["AgencyCode"].ToString();
                        _VehicleDetailMdl2.CertInsureCode = _tblSqla9.Rows[i]["CertInsureCode"].ToString();
                        _VehicleDetailMdl2.Remarks1 = _tblSqla9.Rows[i]["Remarks1"].ToString();
                        _VehicleDetailMdl2.BrchCoverNoteNo = _tblSqla9.Rows[i]["BrchCoverNoteNo"].ToString();
                        _VehicleDetailMdl2.BrchCode = _tblSqla9.Rows[i]["BrchCode"].ToString();
                        _VehicleDetailMdl2.LeaderPolicyNo = _tblSqla9.Rows[i]["LeaderPolicyNo"].ToString();
                        _VehicleDetailMdl2.LeaderEndNo = _tblSqla9.Rows[i]["LeaderEndNo"].ToString();
                        _VehicleDetailMdl2.IsFiler = _tblSqla9.Rows[i]["IsFiler"].ToString();
                        _VehicleDetailMdl2.CalcType = _tblSqla9.Rows[i]["CalcType"].ToString();
                        _VehicleDetailMdl2.IsAuto = _tblSqla9.Rows[i]["IsAuto"].ToString();
                        _VehicleDetailMdl2.EffectiveDate = Convert.ToDateTime(_tblSqla9.Rows[i]["EffectiveDate"]);
                        _VehicleDetailMdl2.ExpiryDate = Convert.ToDateTime(_tblSqla9.Rows[i]["ExpiryDate"]);
                        _VehicleDetailMdl2.SerialNo1 = Convert.ToInt32(_tblSqla9.Rows[i]["SerialNo1"]);
                        _VehicleDetailMdl2.UWYear = _tblSqla9.Rows[i]["UWYear"].ToString();
                        _VehicleDetailMdl2.CreatedBy = _tblSqla9.Rows[i]["CreatedBy"].ToString();
                        _VehicleDetailMdl2.PostedBy = _tblSqla9.Rows[i]["PostedBy"].ToString();
                        _VehicleDetailMdl2.IsPosted = Convert.ToBoolean(_tblSqla9.Rows[i]["IsPosted"]);
                       // _VehicleDetailMdl2.PostDate = Convert.ToDateTime(_tblSqla9.Rows[i]["PostDate"]);
                        _VehicleDetailMdl2.OpolTxnSysID1 = Convert.ToInt32(_tblSqla9.Rows[i]["OpolTxnSysID1"]);
                       // _VehicleDetailMdl2.RenewSysID = Convert.ToInt32(_tblSqla9.Rows[i]["RenewSysID"]);
                        _VehicleDetailMdl2.PolSysID = Convert.ToInt32(_tblSqla9.Rows[i]["PolSysID"]);
                        _VehicleDetailMdl2.IsRenewal = Convert.ToBoolean(_tblSqla9.Rows[i]["IsRenewal"]);
                        _VehicleDetailMdl2.CommisionRate1 = Convert.ToDecimal(_tblSqla9.Rows[i]["CommisionRate1"]);

                        _VehicleDetailMdl2.RatingFactor = _tblSqla9.Rows[i]["RatingFactor"].ToString();
                        _VehicleDetailMdl2.RatingFactorShText = GetRaitingFactorByCode(_tblSqla9.Rows[i]["RatingFactor"].ToString());

                        _VehicleDetailMdl2.IsValidTxn = true;


                        _VehicleDetailMdl2.ProductName = GlobalDataLayer.GetProductNameByProductCode(_tblSqla9.Rows[i]["ProductCode"].ToString());
                        _VehicleDetailMdl2.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_tblSqla9.Rows[i]["PolicyTypeCode"].ToString());
                        _VehicleDetailMdl2.ClientName = GlobalDataLayer.GetClientNameByClientCode(_tblSqla9.Rows[i]["ClientCode"].ToString());
                        _VehicleDetailMdl2.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_tblSqla9.Rows[i]["AgencyCode"].ToString());
                        _VehicleDetailMdl2.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_tblSqla9.Rows[i]["CertInsureCode"].ToString());

                        _VehicleDetailMdl2.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(_tblSqla9.Rows[i]["DocType"].ToString());
                        _VehicleDetailMdl2.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_tblSqla9.Rows[i]["IsFiler"].ToString());
                        _VehicleDetailMdl2.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_tblSqla9.Rows[i]["CalcType"].ToString());
                        _VehicleDetailMdl2.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_tblSqla9.Rows[i]["IsAuto"].ToString());


                        //For Contribution
                        _VehicleDetailMdl2.ConTxnID = Convert.ToInt32(_tblSqla9.Rows[i]["ConTxnID"]);

                        _VehicleDetailMdl2.SumCovered = Convert.ToInt32(_tblSqla9.Rows[i]["SumCovered"]);
                        _VehicleDetailMdl2.Rate2 = Convert.ToDecimal(_tblSqla9.Rows[i]["Rate2"]);
                        _VehicleDetailMdl2.NetContribution = Convert.ToDecimal(_tblSqla9.Rows[i]["NetContribution"]);
                        _VehicleDetailMdl2.GrossContribution = Convert.ToDecimal(_tblSqla9.Rows[i]["GrossContribution"]);
                        _VehicleDetailMdl2.FIF = Convert.ToDecimal(_tblSqla9.Rows[i]["FIF"]);
                        _VehicleDetailMdl2.FED = Convert.ToDecimal(_tblSqla9.Rows[i]["FED"]);
                        _VehicleDetailMdl2.Stamp = Convert.ToDecimal(_tblSqla9.Rows[i]["Stamp"]);
                        _VehicleDetailMdl2.BasicContribution = Convert.ToDecimal(_tblSqla9.Rows[i]["BasicContribution"]);
                        _VehicleDetailMdl2.PEV = Convert.ToDecimal(_tblSqla9.Rows[i]["PEV"]);
                        _VehicleDetailMdl2.BeforePEV = Convert.ToDecimal(_tblSqla9.Rows[i]["BeforePEV"]);
                        _VehicleDetailMdl2.TerrorContribution = Convert.ToDecimal(_tblSqla9.Rows[i]["TerrorContribution"]);
                        _VehicleDetailMdl2.RiskTxnID = Convert.ToInt32(_tblSqla9.Rows[i]["RiskTxnID"]);
                        _VehicleDetailMdl2.PerDayContribution = Convert.ToInt32(_tblSqla9.Rows[i]["PerDayContribution"]);
                        _VehicleDetailMdl2.OpolTxnSysID2 = Convert.ToInt32(_tblSqla9.Rows[i]["OpolTxnSysID2"]);



                        _VehicleDetailMdl2.GrossContribution = Decimal.Round(Convert.ToDecimal(_tblSqla9.Rows[i]["GrossContribution"]),  MidpointRounding.ToEven);
                        _VehicleDetailMdl2.PEV = Decimal.Round(Convert.ToDecimal(_tblSqla9.Rows[i]["PEV"]),  MidpointRounding.ToEven);
                       // _VehicleDetailMdl2.SumCovered = Decimal.Round(_MtrVContributionMdl.SumCovered,  MidpointRounding.ToEven);
                        _VehicleDetailMdl2.NetContribution = Decimal.Round(Convert.ToDecimal(_tblSqla9.Rows[i]["NetContribution"]),  MidpointRounding.ToEven);
                        _VehicleDetailMdl2.BeforePEV = Decimal.Round(Convert.ToDecimal(_tblSqla9.Rows[i]["BeforePEV"]),  MidpointRounding.ToEven);


                        _VehicleDetailMdl2.PolicyString = _tblSqla9.Rows[i]["DocString"].ToString();

                        //Difference of added value and previous value
                        decimal diff1 = _VehicleDetailMdl2.NetContribution - Convert.ToDecimal(_tblSqla9.Rows[i]["NetContribution"]); ;
                        _VehicleDetailMdl2.Difference = diff1;

                        _VehicleDetailMdlList2.Add(_VehicleDetailMdl2);

                    }
                    return _VehicleDetailMdl2;

                }


                else
                {

                    return null;

                }

                //MtrVContributionMdl _MtrVContributionMdl2;
                //List<MtrVContributionMdl> _MtrVContributionMdlList2 = new List<MtrVContributionMdl>();

                //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                //{
                //    SqlCommand command =
                //        new SqlCommand("SELECT *  FROM InsContribution ic INNER JOIN InsUpdateContribution iuc ON ic.RiskTxnID = iuc.RiskTxnID Where ic.TxnSysID = (SELECT MAX(ic.TxnSysID) FROM InsContribution ic) AND iuc.TxnSysID = (SELECT MAX(ic.TxnSysID) FROM InsUpdateContribution ic)", conn);



                //    SqlDataAdapter _adpSql9 = new SqlDataAdapter(command);


                //    _adpSql9.Fill(_tblSqla9);
                //}



                //if (_tblSqla.Rows.Count > 0)
                //{
                //    _MtrVContributionMdl2 = new MtrVContributionMdl();
                //    for (int i = 0; i < _tblSqla9.Rows.Count; i++)
                //    {

                //        _MtrVContributionMdl2.TxnSysID = Convert.ToInt32(_tblSqla9.Rows[i]["TxnSysID"]);
                //        _MtrVContributionMdl2.TxnSysDate = Convert.ToDateTime(_tblSqla9.Rows[i]["TxnSysDate"]);
                //        _MtrVContributionMdl2.UserCode = Convert.ToInt32(_tblSqla9.Rows[i]["UserCode"]);
                //        _MtrVContributionMdl2.SumCovered = Convert.ToInt32(_tblSqla9.Rows[i]["SumCovered"]);
                //        _MtrVContributionMdl2.Rate = Convert.ToDecimal(_tblSqla9.Rows[i]["Rate"]);
                //        _MtrVContributionMdl2.NetContribution = Convert.ToDecimal(_tblSqla9.Rows[i]["NetContribution"]);
                //        _MtrVContributionMdl2.GrossContribution = Convert.ToDecimal(_tblSqla9.Rows[i]["GrossContribution"]);
                //        _MtrVContributionMdl2.FIF = Convert.ToDecimal(_tblSqla9.Rows[i]["FIF"]);
                //        _MtrVContributionMdl2.FED = Convert.ToDecimal(_tblSqla9.Rows[i]["FED"]);
                //        _MtrVContributionMdl2.Stamp = Convert.ToDecimal(_tblSqla9.Rows[i]["Stamp"]);
                //        _MtrVContributionMdl2.BasicContribution = Convert.ToDecimal(_tblSqla9.Rows[i]["BasicContribution"]);
                //        _MtrVContributionMdl2.PEV = Convert.ToDecimal(_tblSqla9.Rows[i]["PEV"]);
                //        _MtrVContributionMdl2.BeforePEV = Convert.ToDecimal(_tblSqla9.Rows[i]["BeforePEV"]);
                //        _MtrVContributionMdl2.TerrorContribution = Convert.ToDecimal(_tblSqla9.Rows[i]["TerrorContribution"]);
                //        _MtrVContributionMdl2.RiskTxnID = Convert.ToInt32(_tblSqla9.Rows[i]["RiskTxnID"]);
                //        _MtrVContributionMdl2.PerDayContribution = Convert.ToInt32(_tblSqla9.Rows[i]["PerDayContribution"]);
                //        _MtrVContributionMdl2.OpolTxnSysID = Convert.ToInt32(_tblSqla9.Rows[i]["OpolTxnSysID"]);


                //        _MtrVContributionMdl2.TxnSysIDU = Convert.ToInt32(_tblSqla9.Rows[i]["TxnSysID1"]);
                //        _MtrVContributionMdl2.TxnSysDateU = Convert.ToDateTime(_tblSqla9.Rows[i]["TxnSysDate1"]);
                //        _MtrVContributionMdl2.UserCodeU = Convert.ToInt32(_tblSqla9.Rows[i]["UserCode1"]);
                //        _MtrVContributionMdl2.SumCoveredU = Convert.ToInt32(_tblSqla9.Rows[i]["SumCovered1"]);
                //        _MtrVContributionMdl2.RateU = Convert.ToDecimal(_tblSqla9.Rows[i]["Rate1"]);
                //        _MtrVContributionMdl2.NetContributionU = Convert.ToDecimal(_tblSqla9.Rows[i]["NetContribution1"]);
                //        _MtrVContributionMdl2.GrossContributionU = Convert.ToDecimal(_tblSqla9.Rows[i]["GrossContribution1"]);
                //        _MtrVContributionMdl2.FIFU = Convert.ToDecimal(_tblSqla9.Rows[i]["FIF1"]);
                //        _MtrVContributionMdl2.FEDU = Convert.ToDecimal(_tblSqla9.Rows[i]["FED1"]);
                //        _MtrVContributionMdl2.StampU = Convert.ToDecimal(_tblSqla9.Rows[i]["Stamp1"]);
                //        _MtrVContributionMdl2.BasicContributionU = Convert.ToDecimal(_tblSqla9.Rows[i]["BasicContribution1"]);
                //        _MtrVContributionMdl2.PEVU = Convert.ToDecimal(_tblSqla9.Rows[i]["PEV1"]);
                //        _MtrVContributionMdl2.BeforePEVU = Convert.ToDecimal(_tblSqla9.Rows[i]["BeforePEV1"]);
                //        _MtrVContributionMdl2.TerrorContributionU = Convert.ToDecimal(_tblSqla9.Rows[i]["TerrorContribution1"]);
                //        _MtrVContributionMdl2.RiskTxnIDU = Convert.ToInt32(_tblSqla9.Rows[i]["RiskTxnID1"]);
                //        _MtrVContributionMdl2.PerDayContributionU = Convert.ToInt32(_tblSqla9.Rows[i]["PerDayContribution1"]);
                //        _MtrVContributionMdl2.OpolTxnSysIDU = Convert.ToInt32(_tblSqla9.Rows[i]["OpolTxnSysID1"]);

                //        //Difference of added value and previous value
                //        // decimal diff = _MtrVContributionMdl.NetContribution - Convert.ToDecimal(_tblSqla9.Rows[i]["NetContribution"]); ;
                //        _MtrVContributionMdl2.Difference = diff;

                //        _MtrVContributionMdl2.IsValidTxn = true;

                //        _MtrVContributionMdlList2.Add(_MtrVContributionMdl2);
                //    }
                //    return _MtrVContributionMdlList2;

                //}


                //else
                //{

                //    return null;

                //}




            }




            catch (Exception ex)

            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return null;
            }
        }


        //---------------- Financial Endorsement ---------------------//



        //---------------- Non Financial Endorsement ---------------------//

        //To Pass Non Financial Endosement (Insertion in 7 tables)
        public VehicleDetailMdl GetNonFEndorsement(VehicleDetailMdl _VehicleDetailMdl1, EndtReasonMdl _EndtReasonMdl1)
        {

            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //Get all IDs For insertion in database
                string _sqlString = "SELECT mvd.Rate,mvd.TxnSysID,mvd.ParentTxnSysID InsPolicyID,ic.TxnSysID ConTxnID FROM MtrVehicleDetails mvd INNER JOIN InsPolicy ip ON mvd.ParentTxnSysID = ip.ParentTxnSysID INNER JOIN InsContribution ic ON ic.RiskTxnID = mvd.TxnSysID WHERE mvd.TxnSysID =" + _VehicleDetailMdl1.TxnSysID;
                DataTable _tblSqla = new DataTable();
                List<VehicleDetailMdl> _VehicleDetailMdlList = new List<VehicleDetailMdl>();
                VehicleDetailMdl _VehicleDetailMdl = new VehicleDetailMdl();
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
                MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();

                int VehicleTxnID = 0, InsPolicyTxnID = 0, ConTxnID = 0;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _VehicleDetailMdl = new VehicleDetailMdl();

                        _VehicleDetailMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        VehicleTxnID = _VehicleDetailMdl.TxnSysID;
                        _VehicleDetailMdl.InsPolicyID = Convert.ToInt32(_tblSqla.Rows[i]["InsPolicyID"]);
                        InsPolicyTxnID = _VehicleDetailMdl.InsPolicyID;
                        _VehicleDetailMdl.ConTxnID = Convert.ToInt32(_tblSqla.Rows[i]["ConTxnID"]);
                        ConTxnID = _VehicleDetailMdl.ConTxnID;
                        _VehicleDetailMdl.Rate = Convert.ToDecimal(_tblSqla.Rows[i]["Rate"]);
                    }


                }
                else
                {

                }

                //Get InsPolicy By ID and insert into InsPolicy For Endorsement
                SqlConnection _conSql1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString1 = "SELECT * FROM InsPolicy WHERE ParentTxnSysID= " + InsPolicyTxnID;

                SqlDataAdapter _adpSql1 = new SqlDataAdapter(_sqlString1, _conSql1);
                DataTable _tblSqla1 = new DataTable();
                List<MtrInsPolicyMdl> _MtrInsPolicyMdlList = new List<MtrInsPolicyMdl>();
                MtrInsPolicyMdl _MtrInsPolicyMdl = new MtrInsPolicyMdl();

                _adpSql1.Fill(_tblSqla1);

                if (_tblSqla1.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla1.Rows.Count; i++)
                    {
                        _MtrInsPolicyMdl = new MtrInsPolicyMdl();

                        _MtrInsPolicyMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla1.Rows[i]["ParentTxnSysID"]);
                        _MtrInsPolicyMdl.TxnSysDate = Convert.ToDateTime(_tblSqla1.Rows[i]["TxnSysDate"]);
                        _MtrInsPolicyMdl.CertMonth = _tblSqla1.Rows[i]["DocMonth"].ToString();
                        _MtrInsPolicyMdl.CertString = _tblSqla1.Rows[i]["DocString"].ToString();
                        _MtrInsPolicyMdl.CertYear = _tblSqla1.Rows[i]["DocYear"].ToString();
                        _MtrInsPolicyMdl.CertNo = Convert.ToInt32(_tblSqla1.Rows[i]["DocNo"]);
                        _MtrInsPolicyMdl.DocType = _tblSqla1.Rows[i]["DocType"].ToString();
                        _MtrInsPolicyMdl.GenerateAgainst = _tblSqla1.Rows[i]["GenerateAgainst"].ToString();
                        _MtrInsPolicyMdl.ProductCode = Convert.ToInt32(_tblSqla1.Rows[i]["ProductCode"]);
                        _MtrInsPolicyMdl.PolicyTypeCode = _tblSqla1.Rows[i]["PolicyTypeCode"].ToString();
                        _MtrInsPolicyMdl.ClientCode = _tblSqla1.Rows[i]["ClientCode"].ToString();
                        _MtrInsPolicyMdl.AgencyCode = _tblSqla1.Rows[i]["AgencyCode"].ToString();
                        _MtrInsPolicyMdl.CertInsureCode = _tblSqla1.Rows[i]["CertInsureCode"].ToString();
                        _MtrInsPolicyMdl.Remarks = _tblSqla1.Rows[i]["Remarks"].ToString();
                        _MtrInsPolicyMdl.BrchCoverNoteNo = _tblSqla1.Rows[i]["BrchCoverNoteNo"].ToString();
                        _MtrInsPolicyMdl.BrchCode = _tblSqla1.Rows[i]["BrchCode"].ToString();
                        _MtrInsPolicyMdl.LeaderPolicyNo = _tblSqla1.Rows[i]["LeaderPolicyNo"].ToString();
                        _MtrInsPolicyMdl.LeaderEndNo = _tblSqla1.Rows[i]["LeaderEndNo"].ToString();
                        _MtrInsPolicyMdl.IsFiler = _tblSqla1.Rows[i]["IsFiler"].ToString();
                        _MtrInsPolicyMdl.CalcType = _tblSqla1.Rows[i]["CalcType"].ToString();
                        _MtrInsPolicyMdl.IsAuto = _tblSqla1.Rows[i]["IsAuto"].ToString();
                        _MtrInsPolicyMdl.EffectiveDate = Convert.ToDateTime(_tblSqla1.Rows[i]["EffectiveDate"]);
                        _MtrInsPolicyMdl.ExpiryDate = Convert.ToDateTime(_tblSqla1.Rows[i]["ExpiryDate"]);
                        _MtrInsPolicyMdl.SerialNo = Convert.ToInt32(_tblSqla1.Rows[i]["SerialNo"]);
                        _MtrInsPolicyMdl.UWYear = _tblSqla1.Rows[i]["UWYear"].ToString();
                        _MtrInsPolicyMdl.CreatedBy = _tblSqla1.Rows[i]["CreatedBy"].ToString();
                        _MtrInsPolicyMdl.PostedBy = _tblSqla1.Rows[i]["PostedBy"].ToString();
                        _MtrInsPolicyMdl.IsPosted = Convert.ToBoolean(_tblSqla1.Rows[i]["IsPosted"]);
                        //_MtrInsPolicyMdl.PostDate = Convert.ToDateTime(_tblSqla1.Rows[i]["PostDate"]);
                        _MtrInsPolicyMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla1.Rows[i]["OpolTxnSysID"]);
                        _MtrInsPolicyMdl.RenewSysID = Convert.ToInt32(_tblSqla1.Rows[i]["RenewSysID"]);
                        _MtrInsPolicyMdl.PolSysID = Convert.ToInt32(_tblSqla1.Rows[i]["PolSysID"]);
                        _MtrInsPolicyMdl.IsRenewal = Convert.ToBoolean(_tblSqla1.Rows[i]["IsRenewal"]);
                        _MtrInsPolicyMdl.CommisionRate = Convert.ToDecimal(_tblSqla1.Rows[i]["CommisionRate"]);
                        _MtrInsPolicyMdl.EndoSerial = Convert.ToInt32(_tblSqla1.Rows[i]["EndoSerial"]);

                        _MtrInsPolicyMdl.IsValidTxn = true;


                        _MtrInsPolicyMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(_tblSqla1.Rows[i]["ProductCode"].ToString());
                        _MtrInsPolicyMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_tblSqla1.Rows[i]["PolicyTypeCode"].ToString());
                        _MtrInsPolicyMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_tblSqla1.Rows[i]["ClientCode"].ToString());
                        _MtrInsPolicyMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_tblSqla1.Rows[i]["AgencyCode"].ToString());
                        _MtrInsPolicyMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_tblSqla1.Rows[i]["CertInsureCode"].ToString());

                        _MtrInsPolicyMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(_tblSqla1.Rows[i]["DocType"].ToString());
                        _MtrInsPolicyMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_tblSqla1.Rows[i]["IsFiler"].ToString());
                        _MtrInsPolicyMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_tblSqla1.Rows[i]["CalcType"].ToString());
                        _MtrInsPolicyMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_tblSqla1.Rows[i]["IsAuto"].ToString());



                        _MtrInsPolicyMdl.IsValidTxn = true;

                    }


                }
                else
                {

                }

                //Increment Endorsement Serial Number
                int _EndoSerial = GetEndoSerial(_MtrInsPolicyMdl.EndoSerial);

                //Update IsActive of particular InsPolicy To pass Endorsement
                SqlConnection _conSql11 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql11 = new StringBuilder();
                SqlCommand _cmdSql11;

                _sbSql11.AppendLine("Update  InsPolicy  SET");
                _sbSql11.AppendLine("IsActive=@IsActive");
                _sbSql11.AppendLine("WHERE  GenerateAgainst = @GenerateAgainst1");
                _sbSql11.AppendLine("OR  GenerateAgainst = @GenerateAgainst2");
                _cmdSql11 = new SqlCommand(_sbSql11.ToString(), _conSql11);
                _cmdSql11.Parameters.AddWithValue("@IsActive", false);
                _cmdSql11.Parameters.AddWithValue("@GenerateAgainst1", _MtrInsPolicyMdl.GenerateAgainst);
                _cmdSql11.Parameters.AddWithValue("@GenerateAgainst2", InsPolicyTxnID);
                _conSql11.Open();
                _cmdSql11.ExecuteNonQuery();
                _conSql11.Close();

                //Update IsActive of particular Vehicle Details To pass Endorsement
                SqlConnection _conSql12 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql12 = new StringBuilder();
                SqlCommand _cmdSql12;

                _sbSql12.AppendLine("Update  MtrVehicleDetails  SET");
                _sbSql12.AppendLine("IsActive=@IsActive");
                _sbSql12.AppendLine("WHERE TxnSysId=@TxnSysId ");
                _cmdSql12 = new SqlCommand(_sbSql12.ToString(), _conSql12);
                _cmdSql12.Parameters.AddWithValue("@IsActive", false);
                _cmdSql12.Parameters.AddWithValue("@TxnSysId", VehicleTxnID);
                _conSql12.Open();
                _cmdSql12.ExecuteNonQuery();
                _conSql12.Close();

                //Insert Into Ins Policy
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
                _sbSql2.AppendLine("BrchCode,");
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
                _sbSql2.AppendLine("EndoSerial,");
                _sbSql2.AppendLine("IsPosted,");
                // _sbSql2.AppendLine("PostDate,");
                _sbSql2.AppendLine("EndoType,");
                _sbSql2.AppendLine("EndoReason,");
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
                _sbSql2.AppendLine("@BrchCode,");
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
                _sbSql2.AppendLine("@EndoSerial,");
                _sbSql2.AppendLine("@IsPosted,");
                // _sbSql2.AppendLine("@PostDate,");
                _sbSql2.AppendLine("@EndoType,");
                _sbSql2.AppendLine("@EndoReason,");
                _sbSql2.AppendLine("@OpolTxnSysID)");



                _cmdSql2 = new SqlCommand(_sbSql2.ToString(), _conSql2);
                // DateTime da = DateTime.Now;
                //  da.ToString("MM-dd-yyyy h:mm tt");
                _cmdSql2.Parameters.AddWithValue("@TxnSysDate", SqlDbType.DateTime).Value = DateTime.Now;


                _cmdSql2.Parameters.AddWithValue("@DocMonth", _MtrInsPolicyMdl.CertMonth);


                _cmdSql2.Parameters.AddWithValue("@DocYear", _MtrInsPolicyMdl.CertYear);

                _cmdSql2.Parameters.AddWithValue("@DocNo", _MtrInsPolicyMdl.CertNo);

                string OpenPolicyDoc = "5";

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

                _cmdSql2.Parameters.AddWithValue("@GenerateAgainst", InsPolicyTxnID);
                _cmdSql2.Parameters.AddWithValue("@ProductCode", _MtrInsPolicyMdl.ProductCode);
                _cmdSql2.Parameters.AddWithValue("@PolicyTypeCode", _MtrInsPolicyMdl.PolicyTypeCode);
                _cmdSql2.Parameters.AddWithValue("@ClientCode", _MtrInsPolicyMdl.ClientCode);
                _cmdSql2.Parameters.AddWithValue("@AgencyCode", _MtrInsPolicyMdl.AgencyCode);
                _cmdSql2.Parameters.AddWithValue("@CertInsureCode", _MtrInsPolicyMdl.CertInsureCode);

                //Remarks for Addition
                _cmdSql2.Parameters.AddWithValue("@Remarks", _VehicleDetailMdl1.Remarks ?? DBNull.Value.ToString());

                _cmdSql2.Parameters.AddWithValue("@BrchCoverNoteNo", _MtrInsPolicyMdl.BrchCoverNoteNo);
                _cmdSql2.Parameters.AddWithValue("@BrchCode", _MtrInsPolicyMdl.BrchCode);
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
                //  _cmdSql2.Parameters.AddWithValue("@PostDate", _MtrInsPolicyMdl.PostDate);
                _cmdSql2.Parameters.AddWithValue("@OpolTxnSysID", _MtrInsPolicyMdl.OpolTxnSysID);
                _cmdSql2.Parameters.AddWithValue("@EndoSerial", _EndoSerial);

                _cmdSql2.Parameters.AddWithValue("@EndoType", Convert.ToInt32(3));

                if(_EndtReasonMdl1.EndtReasonCode == 5)
                {
                    _cmdSql2.Parameters.AddWithValue("@EndoReason", Convert.ToInt32(5));
                }
                else
                if (_EndtReasonMdl1.EndtReasonCode == 6)
                {
                    _cmdSql2.Parameters.AddWithValue("@EndoReason", Convert.ToInt32(6));
                }



                _MtrInsPolicyMdl.CertString = _MtrInsPolicyMdl.CertString;
                _MtrInsPolicyMdl.SerialNo = _SerialNumber;
                // _MtrInsPolicyMdl.TxnSysDate = DateTime.Now;


                int _TxnSysId;
                _conSql2.Open();
                _TxnSysId = (Int32)_cmdSql2.ExecuteScalar();
                _conSql2.Close();
                _MtrInsPolicyMdl.IsValidTxn = true;

                _MtrInsPolicyMdl.ParentTxnSysID = _TxnSysId;

                _MtrInsPolicyMdl.ProductName = GlobalDataLayer.GetProductNameByProductCode(_MtrInsPolicyMdl.ProductCode.ToString());
                _MtrInsPolicyMdl.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_MtrInsPolicyMdl.PolicyTypeCode.ToString());
                _MtrInsPolicyMdl.ClientName = GlobalDataLayer.GetClientNameByClientCode(_MtrInsPolicyMdl.ClientCode.ToString());
                _MtrInsPolicyMdl.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_MtrInsPolicyMdl.AgencyCode.ToString());
                _MtrInsPolicyMdl.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_MtrInsPolicyMdl.CertInsureCode.ToString());

                string OpenPolicyDoc1 = "5";
                _MtrInsPolicyMdl.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(OpenPolicyDoc1);
                _MtrInsPolicyMdl.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_MtrInsPolicyMdl.IsFiler.ToString());
                _MtrInsPolicyMdl.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_MtrInsPolicyMdl.CalcType.ToString());
                _MtrInsPolicyMdl.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_MtrInsPolicyMdl.IsAuto.ToString());

                _MtrInsPolicyMdl.IsValidTxn = true;
                _MtrInsPolicyMdl.DocType = OpenPolicyDoc1;


                //----------------For Ins Tracker-----------------//

                //Get Values From InsTracker
                SqlConnection _conSqlA = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());

                DataTable _tblSqlaA = new DataTable();
                List<MtrInsTrackerMdl> _MtrInsTrackerMdlListA = new List<MtrInsTrackerMdl>();
                MtrInsTrackerMdl _MtrInsTrackerMdlA = new MtrInsTrackerMdl();


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM InsMtrTracker WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@ParentTxnSysID", InsPolicyTxnID));

                    SqlDataAdapter _adpSqlA = new SqlDataAdapter(command);


                    _adpSqlA.Fill(_tblSqlaA);
                }

                if (_tblSqlaA.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqlaA.Rows.Count; i++)
                    {
                        _MtrInsTrackerMdlA = new MtrInsTrackerMdl();

                        _MtrInsTrackerMdlA.TxnSysID = Convert.ToInt32(_tblSqlaA.Rows[i]["TxnSysID"]);
                        _MtrInsTrackerMdlA.UserCode = Convert.ToInt32(_tblSqlaA.Rows[i]["UserCode"]);
                        _MtrInsTrackerMdlA.TrackerCode = Convert.ToInt32(_tblSqlaA.Rows[i]["TrackerCode"]);
                        _MtrInsTrackerMdlA.TrackerName = _tblSqlaA.Rows[i]["TrackerName"].ToString();
                        _MtrInsTrackerMdlA.TrackerRate = Convert.ToInt32(_tblSqlaA.Rows[i]["TrackerRate"]);
                        _MtrInsTrackerMdlA.ParentTxnSysID = Convert.ToInt32(_tblSqlaA.Rows[i]["ParentTxnSysID"]);



                        _MtrInsTrackerMdlA.IsValidTxn = true;

                        _MtrInsTrackerMdlListA.Add(_MtrInsTrackerMdlA);
                    }

                    //Insert In to InsTracker For Renewal
                    SqlConnection _conSqlB = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSqlB = new StringBuilder();
                    SqlCommand _cmdSqlB;


                    MtrInsTrackerMdl[] TrackerArray = _MtrInsTrackerMdlListA.ToArray();

                    for (int j = 0; j < TrackerArray.Length; j++)
                    {
                        _sbSqlB = new StringBuilder();

                        _sbSqlB.AppendLine("INSERT INTO InsMtrTracker(");

                        _sbSqlB.AppendLine("UserCode,");
                        _sbSqlB.AppendLine("TrackerCode,");
                        _sbSqlB.AppendLine("TrackerName,");
                        _sbSqlB.AppendLine("TrackerRate,");
                        _sbSqlB.AppendLine("ParentTxnSysID)");


                        _sbSqlB.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                        _sbSqlB.AppendLine("@UserCode,");
                        _sbSqlB.AppendLine("@TrackerCode,");
                        _sbSqlB.AppendLine("@TrackerName,");
                        _sbSqlB.AppendLine("@TrackerRate,");
                        _sbSqlB.AppendLine("@ParentTxnSysID)");


                        _cmdSqlB = new SqlCommand(_sbSqlB.ToString(), _conSqlB);
                        int _userCodeA = GlobalDataLayer.GetUserCodeById(_MtrInsTrackerMdlA.UserCode);
                        _cmdSqlB.Parameters.AddWithValue("@UserCode", _userCodeA);
                        _cmdSqlB.Parameters.AddWithValue("@TrackerCode", TrackerArray[j].TrackerCode);
                        _cmdSqlB.Parameters.AddWithValue("@TrackerName", TrackerArray[j].TrackerName);
                        _cmdSqlB.Parameters.AddWithValue("@TrackerRate", TrackerArray[j].TrackerRate);
                        _cmdSqlB.Parameters.AddWithValue("@ParentTxnSysID", _TxnSysId);


                        int _TxnSysId1;
                        _conSqlB.Open();
                        _TxnSysId1 = (Int32)_cmdSqlB.ExecuteScalar();
                        _conSqlB.Close();
                    }

                }
                else
                {

                }

                //----------------For Ins Tracker-----------------//

                //----------------For Ins Rider-----------------//

                //Get Values From InsRider
                SqlConnection _conSqlC = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                DataTable _tblSqlaC = new DataTable();
                List<MtrInsRiderMdl> _MtrInsRiderMdlListC = new List<MtrInsRiderMdl>();
                MtrInsRiderMdl _MtrInsRiderMdlC = new MtrInsRiderMdl();


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM InsMtrRider WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@ParentTxnSysID", InsPolicyTxnID));

                    SqlDataAdapter _adpSqlC = new SqlDataAdapter(command);


                    _adpSqlC.Fill(_tblSqlaC);
                }


                if (_tblSqlaC.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqlaC.Rows.Count; i++)
                    {
                        _MtrInsRiderMdlC = new MtrInsRiderMdl();

                        _MtrInsRiderMdlC.TxnSysID = Convert.ToInt32(_tblSqlaC.Rows[i]["TxnSysID"]);
                        _MtrInsRiderMdlC.TxnSysDate = Convert.ToDateTime(_tblSqlaC.Rows[i]["TxnSysDate"]);
                        _MtrInsRiderMdlC.UserCode = Convert.ToInt32(_tblSqlaC.Rows[i]["UserCode"]);
                        _MtrInsRiderMdlC.RiderCode = Convert.ToInt32(_tblSqlaC.Rows[i]["RiderCode"]);
                        _MtrInsRiderMdlC.RiderName = _tblSqlaC.Rows[i]["RiderName"].ToString();
                        _MtrInsRiderMdlC.RiderRate = Convert.ToInt32(_tblSqlaC.Rows[i]["RiderRate"]);
                        _MtrInsRiderMdlC.ParentTxnSysID = Convert.ToInt32(_tblSqlaC.Rows[i]["ParentTxnSysID"]);




                        _MtrInsRiderMdlC.IsValidTxn = true;

                        _MtrInsRiderMdlListC.Add(_MtrInsRiderMdlC);
                    }


                    //Insert In To Ins Rider
                    SqlConnection _conSqlD = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSqlD = new StringBuilder();
                    SqlCommand _cmdSqlD;


                    MtrInsRiderMdl[] RiderArray = _MtrInsRiderMdlListC.ToArray();

                    for (int j = 0; j < RiderArray.Length; j++)
                    {
                        _sbSqlD = new StringBuilder();

                        _sbSqlD.AppendLine("INSERT INTO InsMtrRider(");
                        //_sbSql.AppendLine("TxnSysID,");
                        //_sbSql.AppendLine("TxnSysDate,");
                        _sbSqlD.AppendLine("UserCode,");
                        _sbSqlD.AppendLine("RiderCode,");
                        _sbSqlD.AppendLine("RiderName,");
                        _sbSqlD.AppendLine("RiderRate,");
                        _sbSqlD.AppendLine("ParentTxnSysID)");



                        _sbSqlD.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                        // _sbSql.AppendLine("@TxnSysID,");
                        //  _sbSql.AppendLine("@TxnSysDate,");
                        _sbSqlD.AppendLine("@UserCode,");
                        _sbSqlD.AppendLine("@RiderCode,");
                        _sbSqlD.AppendLine("@RiderName,");
                        _sbSqlD.AppendLine("@RiderRate,");
                        _sbSqlD.AppendLine("@ParentTxnSysID)");




                        _cmdSqlD = new SqlCommand(_sbSqlD.ToString(), _conSqlD);
                        int _userCodeB = GlobalDataLayer.GetUserCodeById(_MtrInsRiderMdlC.UserCode);
                        _cmdSqlD.Parameters.AddWithValue("@UserCode", _userCodeB);
                        _cmdSqlD.Parameters.AddWithValue("@RiderCode", RiderArray[j].RiderCode);
                        _cmdSqlD.Parameters.AddWithValue("@RiderName", RiderArray[j].RiderName);
                        _cmdSqlD.Parameters.AddWithValue("@RiderRate", RiderArray[j].RiderRate);
                        _cmdSqlD.Parameters.AddWithValue("@ParentTxnSysID", _TxnSysId);


                        int _TxnSysIdB;
                        _conSqlD.Open();
                        _TxnSysIdB = (Int32)_cmdSqlD.ExecuteScalar();
                        _conSqlD.Close();

                    }

                }
                else
                {

                }

                //----------------For Ins Rider-----------------//

                //----------------For Ins Conditions-----------------//

                //Get Values From Ins Conditions
                SqlConnection _conSqlE = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                DataTable _tblSqlaE = new DataTable();
                List<MtrInsConditionsMdl> _MtrInsConditionsMdlListE = new List<MtrInsConditionsMdl>();
                MtrInsConditionsMdl _MtrInsConditionsMdlE;


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM InsMtrConditions WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@ParentTxnSysID", InsPolicyTxnID));

                    SqlDataAdapter _adpSqlE = new SqlDataAdapter(command);


                    _adpSqlE.Fill(_tblSqlaE);
                }


                if (_tblSqlaE.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqlaE.Rows.Count; i++)
                    {
                        _MtrInsConditionsMdlE = new MtrInsConditionsMdl();

                        _MtrInsConditionsMdlE.TxnSysID = Convert.ToInt32(_tblSqlaE.Rows[i]["TxnSysID"]);
                        _MtrInsConditionsMdlE.TxnSysDate = Convert.ToDateTime(_tblSqlaE.Rows[i]["TxnSysDate"]);
                        _MtrInsConditionsMdlE.UserCode = Convert.ToInt32(_tblSqlaE.Rows[i]["UserCode"]);
                        _MtrInsConditionsMdlE.ParentTxnSysID = Convert.ToInt32(_tblSqlaE.Rows[i]["ParentTxnSysID"]);
                        _MtrInsConditionsMdlE.Condition = _tblSqlaE.Rows[i]["Condition"].ToString();

                        _MtrInsConditionsMdlE.ConditionShText = GlobalDataLayer.GetConditionByCode(_tblSqlaE.Rows[i]["Condition"].ToString());



                        _MtrInsConditionsMdlE.IsValidTxn = true;

                        _MtrInsConditionsMdlListE.Add(_MtrInsConditionsMdlE);
                    }

                    //Insert Into Ins Conditions
                    SqlConnection _conSqlF = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSqlF = new StringBuilder();
                    SqlCommand _cmdSqlF;


                    MtrInsConditionsMdl[] ConditionsArray = _MtrInsConditionsMdlListE.ToArray();

                    for (int j = 0; j < ConditionsArray.Length; j++)
                    {
                        _sbSqlF = new StringBuilder();

                        _sbSqlF.AppendLine("INSERT INTO InsMtrConditions(");
                        _sbSqlF.AppendLine("ParentTxnSysID,");
                        _sbSqlF.AppendLine("Condition)");

                        _sbSqlF.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                        _sbSqlF.AppendLine("@ParentTxnSysID,");
                        _sbSqlF.AppendLine("@Condition)");

                        _cmdSqlF = new SqlCommand(_sbSqlF.ToString(), _conSqlF);

                        _cmdSqlF.Parameters.AddWithValue("@ParentTxnSysID", _TxnSysId);
                        _cmdSqlF.Parameters.AddWithValue("@Condition", ConditionsArray[j].Condition.ToString());

                        int _TxnSysIdC;
                        _conSqlF.Open();
                        _TxnSysIdC = (Int32)_cmdSqlF.ExecuteScalar();
                        _conSqlF.Close();
                    }

                }
                else
                {

                }

                //----------------For Ins Conditions-----------------//

                //----------------For Ins Warranties-----------------//

                //Get Values From InsWarranties
                SqlConnection _conSqlG = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                DataTable _tblSqlaG = new DataTable();
                List<MtrInsWarrantiesMdl> _MtrInsWarrantiesMdlListG = new List<MtrInsWarrantiesMdl>();
                MtrInsWarrantiesMdl _MtrInsWarrantiesMdlG;


                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM InsMtrWarranties WHERE ParentTxnSysID = @ParentTxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@ParentTxnSysID", InsPolicyTxnID));

                    SqlDataAdapter _adpSqlG = new SqlDataAdapter(command);


                    _adpSqlG.Fill(_tblSqlaG);
                }


                //  _adpSql.Fill(_tbl);

                if (_tblSqlaG.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqlaG.Rows.Count; i++)
                    {
                        _MtrInsWarrantiesMdlG = new MtrInsWarrantiesMdl();

                        _MtrInsWarrantiesMdlG.TxnSysID = Convert.ToInt32(_tblSqlaG.Rows[i]["TxnSysID"]);
                        _MtrInsWarrantiesMdlG.TxnSysDate = Convert.ToDateTime(_tblSqlaG.Rows[i]["TxnSysDate"]);
                        _MtrInsWarrantiesMdlG.UserCode = Convert.ToInt32(_tblSqlaG.Rows[i]["UserCode"]);
                        _MtrInsWarrantiesMdlG.Warranty = _tblSqlaG.Rows[i]["Warranty"].ToString();
                        _MtrInsWarrantiesMdlG.ParentTxnSysID = Convert.ToInt32(_tblSqlaG.Rows[i]["ParentTxnSysID"]);

                        _MtrInsWarrantiesMdlG.WarrantyShText = GlobalDataLayer.GetWarrantyTextByCode(_tblSqlaG.Rows[i]["Warranty"].ToString());




                        _MtrInsWarrantiesMdlG.IsValidTxn = true;

                        _MtrInsWarrantiesMdlListG.Add(_MtrInsWarrantiesMdlG);
                    }

                    //Insert In To InsWarranties
                    SqlConnection _conSqlH = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSqlH = new StringBuilder();
                    SqlCommand _cmdSqlH;


                    MtrInsWarrantiesMdl[] WarrantyArray = _MtrInsWarrantiesMdlListG.ToArray();

                    for (int j = 0; j < WarrantyArray.Length; j++)
                    {
                        _sbSqlH = new StringBuilder();

                        _sbSqlH.AppendLine("INSERT INTO InsMtrWarranties(");
                        _sbSqlH.AppendLine("ParentTxnSysID,");
                        _sbSqlH.AppendLine("Warranty)");



                        _sbSqlH.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                        _sbSqlH.AppendLine("@ParentTxnSysID,");
                        _sbSqlH.AppendLine("@Warranty)");

                        _cmdSqlH = new SqlCommand(_sbSqlH.ToString(), _conSqlH);

                         _cmdSqlH.Parameters.AddWithValue("@ParentTxnSysID", _TxnSysId);
                        _cmdSqlH.Parameters.AddWithValue("@Warranty", WarrantyArray[j].Warranty.ToString());

                        int _TxnSysIdD;
                        _conSqlH.Open();
                        _TxnSysIdD = (Int32)_cmdSqlH.ExecuteScalar();
                        _conSqlH.Close();
                    }

                }
                else
                {

                }

                //----------------For Ins Warranties-----------------//


                //Get Values From MtrVehicle Detail by TxnID
                SqlConnection _conSql3 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString3 = "SELECT * FROM MtrVehicleDetails mvd WHERE mvd.TxnSysID =  " + _VehicleDetailMdl1.TxnSysID;

                SqlDataAdapter _adpSql3 = new SqlDataAdapter(_sqlString3, _conSql3);
                DataTable _tblSqla3 = new DataTable();


                _adpSql3.Fill(_tblSqla3);

                if (_tblSqla3.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla3.Rows.Count; i++)
                    {
                        _VehicleDetailMdl = new VehicleDetailMdl();

                        _VehicleDetailMdl.TxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["TxnSysID"]);
                        _VehicleDetailMdl.TxnSysDate = Convert.ToDateTime(_tblSqla3.Rows[i]["TxnSysDate"]);
                        _VehicleDetailMdl.UserCode = Convert.ToInt32(_tblSqla3.Rows[i]["UserCode"]);
                        _VehicleDetailMdl.SerialNo = Convert.ToInt32(_tblSqla3.Rows[i]["SerialNo"].ToString());
                        _VehicleDetailMdl.VehicleCode = Convert.ToInt32(_tblSqla3.Rows[i]["VehicleCode"].ToString());
                        _VehicleDetailMdl.VehicleModel = Convert.ToInt32(_tblSqla3.Rows[i]["VehicleModel"].ToString());
                        _VehicleDetailMdl.UpdatedValue = Convert.ToDecimal(_tblSqla3.Rows[i]["UpdatedValue"]);
                        _VehicleDetailMdl.PreviousValue = Convert.ToDecimal(_tblSqla3.Rows[i]["PreviousValue"]);
                        _VehicleDetailMdl.Mileage = Convert.ToInt32(_tblSqla3.Rows[i]["Mileage"].ToString());
                        _VehicleDetailMdl.ParticipantValue = Convert.ToDecimal(_tblSqla3.Rows[i]["ParticipantValue"]);
                        _VehicleDetailMdl.ColorCode = Convert.ToInt32(_tblSqla3.Rows[i]["ColorCode"].ToString());
                        _VehicleDetailMdl.ParticipantName = _tblSqla3.Rows[i]["ParticipantName"].ToString();
                        _VehicleDetailMdl.ParticipantAddress = _tblSqla3.Rows[i]["ParticipantAddress"].ToString();
                        // _VehicleDetailMdl.ModelNumber = Convert.ToInt32(_tblSqla.Rows[i]["ModelNumber"]);
                        _VehicleDetailMdl.RegistrationNumber = _tblSqla3.Rows[i]["RegistrationNumber"].ToString();
                        _VehicleDetailMdl.CityCode = _tblSqla3.Rows[i]["CityCode"].ToString();
                        _VehicleDetailMdl.EngineNumber = _tblSqla3.Rows[i]["EngineNumber"].ToString();
                        _VehicleDetailMdl.AreaCode = Convert.ToInt32(_tblSqla3.Rows[i]["AreaCode"].ToString());
                        _VehicleDetailMdl.ChasisNumber = _tblSqla3.Rows[i]["ChasisNumber"].ToString();
                        _VehicleDetailMdl.Remarks = _tblSqla3.Rows[i]["Remarks"].ToString();
                        _VehicleDetailMdl.PODate = Convert.ToDateTime(_tblSqla3.Rows[i]["PODate"]);
                        _VehicleDetailMdl.PONumber = (_tblSqla3.Rows[i]["PONumber"].ToString());
                        _VehicleDetailMdl.CNICNumber = _tblSqla3.Rows[i]["CNICNumber"].ToString();
                        _VehicleDetailMdl.Tenure = _tblSqla3.Rows[i]["Tenure"].ToString();
                        _VehicleDetailMdl.BirthDate = Convert.ToDateTime(_tblSqla3.Rows[i]["BirthDate"]);
                        _VehicleDetailMdl.Gender = _tblSqla3.Rows[i]["Gender"].ToString();
                        _VehicleDetailMdl.VehicleType = _tblSqla3.Rows[i]["VehicleType"].ToString();
                        _VehicleDetailMdl.VEODCode = Convert.ToInt32(_tblSqla3.Rows[i]["VEODCode"]);
                        _VehicleDetailMdl.CertTypeCode = _tblSqla3.Rows[i]["CertTypeCode"].ToString();
                        _VehicleDetailMdl.Rate = Convert.ToDecimal(_tblSqla3.Rows[i]["Rate"]);
                        _VehicleDetailMdl.Contribution = Convert.ToInt32(_tblSqla3.Rows[i]["Contribution"]);
                        _VehicleDetailMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["ParentTxnSysID"]);
                        _VehicleDetailMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla3.Rows[i]["OpolTxnSysID"]);

                        _VehicleDetailMdl.RatingFactor = _tblSqla3.Rows[i]["RatingFactor"].ToString();
                        _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_tblSqla3.Rows[i]["RatingFactor"].ToString());

                        _VehicleDetailMdl.VEODName = GlobalDataLayer.GetVEODNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["VEODCode"]));
                        _VehicleDetailMdl.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_tblSqla3.Rows[i]["VehicleType"].ToString());

                        _VehicleDetailMdl.InsuranceTypeCode = Convert.ToInt32(_tblSqla3.Rows[i]["InsuranceTypeCode"]);
                        _VehicleDetailMdl.IsActive = Convert.ToBoolean(_tblSqla3.Rows[i]["IsActive"]);
                        _VehicleDetailMdl.IsCanceled = Convert.ToBoolean(_tblSqla3.Rows[i]["IsCanceled"]);
                        _VehicleDetailMdl.CommisionRate = Convert.ToDecimal(_tblSqla3.Rows[i]["CommisionRate"]);
                        _VehicleDetailMdl.MobileNumber = _tblSqla3.Rows[i]["MobileNumber"].ToString();
                        _VehicleDetailMdl.ResNumber = _tblSqla3.Rows[i]["ResNumber"].ToString();
                        _VehicleDetailMdl.OfficeNumber = _tblSqla3.Rows[i]["OfficeNumber"].ToString();

                        _VehicleDetailMdl.EmailAddress = _tblSqla3.Rows[i]["EmailAddress"].ToString();
                        _VehicleDetailMdl.Deductible = Convert.ToDecimal(_tblSqla3.Rows[i]["Deductible"]);

                        _VehicleDetailMdl.ContractMatDate = Convert.ToDateTime(_tblSqla3.Rows[i]["ContractMatDate"]);


                        _VehicleDetailMdl.GenderName = GlobalDataLayer.GetGenderNameByCode(_tblSqla3.Rows[i]["Gender"].ToString());
                        _VehicleDetailMdl.CityName = GlobalDataLayer.GetCityNameByCode(_tblSqla3.Rows[i]["CityCode"].ToString());
                        _VehicleDetailMdl.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["ColorCode"].ToString()));
                        _VehicleDetailMdl.VehicleName = GlobalDataLayer.GetVehicleNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["VehicleCode"].ToString()));
                        _VehicleDetailMdl.AreaName = GlobalDataLayer.GetAreaNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["AreaCode"].ToString()));
                        _VehicleDetailMdl.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_tblSqla3.Rows[i]["CertTypeCode"].ToString());
                        _VehicleDetailMdl.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla3.Rows[i]["InsuranceTypeCode"]));

                        _VehicleDetailMdl.total = GlobalDataLayer.calculate(_VehicleDetailMdl);


                        _VehicleDetailMdlList.Add(_VehicleDetailMdl);


                    }
                }

                else
                {

                }

                SqlConnection _conSql4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql4 = new StringBuilder();
                SqlCommand _cmdSql4 = new SqlCommand();
                int _SerialNumber1 = GetSerialNo1(_VehicleDetailMdl);

                if (_EndtReasonMdl1.EndtReasonCode == 5)
                {
                    //Insert Into Vehicle Details
                    //SqlConnection _conSql4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    //StringBuilder _sbSql4 = new StringBuilder();
                    //SqlCommand _cmdSql4;
                    //int _SerialNumber1 = GetSerialNo1(_VehicleDetailMdl);


                    _sbSql4.AppendLine("INSERT INTO MtrVehicleDetails(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql4.AppendLine("TxnSysDate,");
                    _sbSql4.AppendLine("UserCode,");
                    _sbSql4.AppendLine("SerialNo,");
                    _sbSql4.AppendLine("VehicleCode,");
                    _sbSql4.AppendLine("VehicleModel,");
                    _sbSql4.AppendLine("UpdatedValue,");
                    _sbSql4.AppendLine("PreviousValue,");
                    _sbSql4.AppendLine("Mileage,");
                    _sbSql4.AppendLine("ParticipantValue,");
                    _sbSql4.AppendLine("ColorCode,");
                    _sbSql4.AppendLine("ParticipantName,");
                    _sbSql4.AppendLine("ParticipantAddress,");
                    // _sbSql.AppendLine("ModelNumber,");
                    _sbSql4.AppendLine("RegistrationNumber,");
                    _sbSql4.AppendLine("CityCode,");
                    _sbSql4.AppendLine("EngineNumber,");
                    _sbSql4.AppendLine("AreaCode,");
                    _sbSql4.AppendLine("ChasisNumber,");
                    _sbSql4.AppendLine("Remarks,");
                    _sbSql4.AppendLine("PODate,");
                    _sbSql4.AppendLine("PONumber,");
                    _sbSql4.AppendLine("CNICNumber,");
                    _sbSql4.AppendLine("Tenure,");
                    _sbSql4.AppendLine("BirthDate,");
                    _sbSql4.AppendLine("Gender,");
                    _sbSql4.AppendLine("VehicleType,");
                    _sbSql4.AppendLine("VEODCode,");
                    _sbSql4.AppendLine("CertTypeCode,");
                    _sbSql4.AppendLine("Rate,");
                    _sbSql4.AppendLine("ParentTxnSysID,");
                    _sbSql4.AppendLine("OpolTxnSysID,");
                    _sbSql4.AppendLine("InsuranceTypeCode,");
                    _sbSql4.AppendLine("CommisionRate,");
                    _sbSql4.AppendLine("MobileNumber,");
                    _sbSql4.AppendLine("ResNumber,");
                    _sbSql4.AppendLine("OfficeNumber,");
                    _sbSql4.AppendLine("EmailAddress,");
                    _sbSql4.AppendLine("Deductible,");
                    _sbSql4.AppendLine("ContractMatDate,");
                    _sbSql4.AppendLine("RatingFactor,");
                    _sbSql4.AppendLine("Contribution)");


                    _sbSql4.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                    // _sbSql.AppendLine("@TxnSysID,");
                    _sbSql4.AppendLine("@TxnSysDate,");
                    _sbSql4.AppendLine("@UserCode,");
                    _sbSql4.AppendLine("@SerialNo,");
                    _sbSql4.AppendLine("@VehicleCode,");
                    _sbSql4.AppendLine("@VehicleModel,");
                    _sbSql4.AppendLine("@UpdatedValue,");
                    _sbSql4.AppendLine("@PreviousValue,");
                    _sbSql4.AppendLine("@Mileage,");
                    _sbSql4.AppendLine("@ParticipantValue,");
                    _sbSql4.AppendLine("@ColorCode,");
                    _sbSql4.AppendLine("@ParticipantName,");
                    _sbSql4.AppendLine("@ParticipantAddress,");
                    // _sbSql.AppendLine("@ModelNumber,");
                    _sbSql4.AppendLine("@RegistrationNumber,");
                    _sbSql4.AppendLine("@CityCode,");
                    _sbSql4.AppendLine("@EngineNumber,");
                    _sbSql4.AppendLine("@AreaCode,");
                    _sbSql4.AppendLine("@ChasisNumber,");
                    _sbSql4.AppendLine("@Remarks,");
                    _sbSql4.AppendLine("@PODate,");
                    _sbSql4.AppendLine("@PONumber,");
                    _sbSql4.AppendLine("@CNICNumber,");
                    _sbSql4.AppendLine("@Tenure,");
                    _sbSql4.AppendLine("@BirthDate,");
                    _sbSql4.AppendLine("@Gender,");
                    _sbSql4.AppendLine("@VehicleType,");
                    _sbSql4.AppendLine("@VEODCode,");
                    _sbSql4.AppendLine("@CertTypeCode,");
                    _sbSql4.AppendLine("@Rate,");
                    _sbSql4.AppendLine("@ParentTxnSysID,");
                    _sbSql4.AppendLine("@OpolTxnSysID,");
                    _sbSql4.AppendLine("@InsuranceTypeCode,");
                    _sbSql4.AppendLine("@CommisionRate,");
                    _sbSql4.AppendLine("@MobileNumber,");
                    _sbSql4.AppendLine("@ResNumber,");
                    _sbSql4.AppendLine("@OfficeNumber,");
                    _sbSql4.AppendLine("@EmailAddress,");
                    _sbSql4.AppendLine("@Deductible,");
                    _sbSql4.AppendLine("@ContractMatDate,");
                    _sbSql4.AppendLine("@RatingFactor,");
                    _sbSql4.AppendLine("@Contribution)");


                    _cmdSql4 = new SqlCommand(_sbSql4.ToString(), _conSql4);




                    DateTime da = DateTime.Now;
                    da.ToString("MM-dd-yyyy h:mm tt");

                    _cmdSql4.Parameters.AddWithValue("@TxnSysDate", Convert.ToDateTime(da));
                    _cmdSql4.Parameters.AddWithValue("@ParentTxnSysID", _TxnSysId);
                    int _userCode = GlobalDataLayer.GetUserCodeById(_VehicleDetailMdl.UserCode);
                    _cmdSql4.Parameters.AddWithValue("@UserCode", _userCode);

                    _cmdSql4.Parameters.AddWithValue("@SerialNo", _SerialNumber1);

                    //----------To be changed by non financial endorsemnet----------//


                    _cmdSql4.Parameters.AddWithValue("@ParticipantName", _VehicleDetailMdl1.ParticipantName ?? _VehicleDetailMdl.ParticipantName);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantAddress", _VehicleDetailMdl1.ParticipantAddress ?? _VehicleDetailMdl.ParticipantAddress);
                    _cmdSql4.Parameters.AddWithValue("@CityCode", _VehicleDetailMdl1.CityCode ?? _VehicleDetailMdl.CityCode);
                    _cmdSql4.Parameters.AddWithValue("@AreaCode", _VehicleDetailMdl1.AreaCode);
                    _cmdSql4.Parameters.AddWithValue("@CNICNumber", _VehicleDetailMdl1.CNICNumber ?? _VehicleDetailMdl.CNICNumber);
                    _cmdSql4.Parameters.AddWithValue("@MobileNumber", _VehicleDetailMdl1.MobileNumber ?? _VehicleDetailMdl.MobileNumber);
                    _cmdSql4.Parameters.AddWithValue("@ResNumber", _VehicleDetailMdl1.ResNumber ?? _VehicleDetailMdl.ResNumber);
                    _cmdSql4.Parameters.AddWithValue("@OfficeNumber", _VehicleDetailMdl1.OfficeNumber ?? _VehicleDetailMdl.OfficeNumber);
                    _cmdSql4.Parameters.AddWithValue("@EmailAddress", _VehicleDetailMdl1.EmailAddress ?? _VehicleDetailMdl.EmailAddress);
                    _cmdSql4.Parameters.AddWithValue("@BirthDate", _VehicleDetailMdl1.BirthDate);
                    _cmdSql4.Parameters.AddWithValue("@Gender", _VehicleDetailMdl1.Gender);

                    //Add Remarks for addition
                    _cmdSql4.Parameters.AddWithValue("@Remarks", _VehicleDetailMdl1.Remarks ?? DBNull.Value.ToString());

                    //----------To be changed by non financial endorsemnet ----------//

                    _cmdSql4.Parameters.AddWithValue("@VehicleCode", _VehicleDetailMdl.VehicleCode);
                    _cmdSql4.Parameters.AddWithValue("@VehicleModel", _VehicleDetailMdl.VehicleModel);
                    _cmdSql4.Parameters.AddWithValue("@ColorCode", _VehicleDetailMdl.ColorCode);
                    _cmdSql4.Parameters.AddWithValue("@RegistrationNumber", _VehicleDetailMdl.RegistrationNumber ?? _VehicleDetailMdl.RegistrationNumber);
                    _cmdSql4.Parameters.AddWithValue("@EngineNumber", _VehicleDetailMdl.EngineNumber ?? _VehicleDetailMdl.EngineNumber);
                    _cmdSql4.Parameters.AddWithValue("@ChasisNumber", _VehicleDetailMdl.ChasisNumber ?? _VehicleDetailMdl.ChasisNumber);
                    _cmdSql4.Parameters.AddWithValue("@VehicleType", _VehicleDetailMdl.VehicleType ?? _VehicleDetailMdl.VehicleType);
                    _cmdSql4.Parameters.AddWithValue("@VEODCode", _VehicleDetailMdl.VEODCode);
                    _cmdSql4.Parameters.AddWithValue("@Mileage", _VehicleDetailMdl.Mileage);
                    _cmdSql4.Parameters.AddWithValue("@UpdatedValue", _VehicleDetailMdl.UpdatedValue);
                    _cmdSql4.Parameters.AddWithValue("@PreviousValue", _VehicleDetailMdl.ParticipantValue);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantValue", Convert.ToInt32(0));
                    _cmdSql4.Parameters.AddWithValue("@Tenure", _VehicleDetailMdl.Tenure);
                    _cmdSql4.Parameters.AddWithValue("@PODate", _VehicleDetailMdl.PODate);
                    _cmdSql4.Parameters.AddWithValue("@PONumber", _VehicleDetailMdl.PONumber);
                    _cmdSql4.Parameters.AddWithValue("@CertTypeCode", _VehicleDetailMdl.CertTypeCode);
                    _cmdSql4.Parameters.AddWithValue("@Rate", _VehicleDetailMdl.Rate);
                    _cmdSql4.Parameters.AddWithValue("@InsuranceTypeCode", _VehicleDetailMdl.InsuranceTypeCode);
                    _cmdSql4.Parameters.AddWithValue("@Contribution", Convert.ToDecimal(0));
                    _cmdSql4.Parameters.AddWithValue("@CommisionRate", _VehicleDetailMdl.CommisionRate);
                    _cmdSql4.Parameters.AddWithValue("@Deductible", _VehicleDetailMdl.Deductible);
                    _cmdSql4.Parameters.AddWithValue("@ContractMatDate", _VehicleDetailMdl.ContractMatDate);
                    _cmdSql4.Parameters.AddWithValue("@OpolTxnSysID", _VehicleDetailMdl.OpolTxnSysID);
                    _cmdSql4.Parameters.AddWithValue("@RatingFactor", _VehicleDetailMdl.RatingFactor);
                    _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_VehicleDetailMdl.RatingFactor);



                    _VehicleDetailMdl.SerialNo = _SerialNumber;

                    _VehicleDetailMdl.TxnSysDate = DateTime.Now;

                    //int _TxnSysId2;
                    //_conSql4.Open();
                    //_TxnSysId2 = (Int32)_cmdSql4.ExecuteScalar();
                    //_conSql4.Close();
                    //_VehicleDetailMdl.IsValidTxn = true;
                }

                else
                if (_EndtReasonMdl1.EndtReasonCode == 6)
                {
                    //Insert Into Vehicle Details
                    //SqlConnection _conSql4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    //StringBuilder _sbSql4 = new StringBuilder();
                    //SqlCommand _cmdSql4;
                    //int _SerialNumber1 = GetSerialNo1(_VehicleDetailMdl);


                    _sbSql4.AppendLine("INSERT INTO MtrVehicleDetails(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql4.AppendLine("TxnSysDate,");
                    _sbSql4.AppendLine("UserCode,");
                    _sbSql4.AppendLine("SerialNo,");
                    _sbSql4.AppendLine("VehicleCode,");
                    _sbSql4.AppendLine("VehicleModel,");
                    _sbSql4.AppendLine("UpdatedValue,");
                    _sbSql4.AppendLine("PreviousValue,");
                    _sbSql4.AppendLine("Mileage,");
                    _sbSql4.AppendLine("ParticipantValue,");
                    _sbSql4.AppendLine("ColorCode,");
                    _sbSql4.AppendLine("ParticipantName,");
                    _sbSql4.AppendLine("ParticipantAddress,");
                    // _sbSql.AppendLine("ModelNumber,");
                    _sbSql4.AppendLine("RegistrationNumber,");
                    _sbSql4.AppendLine("CityCode,");
                    _sbSql4.AppendLine("EngineNumber,");
                    _sbSql4.AppendLine("AreaCode,");
                    _sbSql4.AppendLine("ChasisNumber,");
                    _sbSql4.AppendLine("Remarks,");
                    _sbSql4.AppendLine("PODate,");
                    _sbSql4.AppendLine("PONumber,");
                    _sbSql4.AppendLine("CNICNumber,");
                    _sbSql4.AppendLine("Tenure,");
                    _sbSql4.AppendLine("BirthDate,");
                    _sbSql4.AppendLine("Gender,");
                    _sbSql4.AppendLine("VehicleType,");
                    _sbSql4.AppendLine("VEODCode,");
                    _sbSql4.AppendLine("CertTypeCode,");
                    _sbSql4.AppendLine("Rate,");
                    _sbSql4.AppendLine("ParentTxnSysID,");
                    _sbSql4.AppendLine("OpolTxnSysID,");
                    _sbSql4.AppendLine("InsuranceTypeCode,");
                    _sbSql4.AppendLine("CommisionRate,");
                    _sbSql4.AppendLine("MobileNumber,");
                    _sbSql4.AppendLine("ResNumber,");
                    _sbSql4.AppendLine("OfficeNumber,");
                    _sbSql4.AppendLine("EmailAddress,");
                    _sbSql4.AppendLine("Deductible,");
                    _sbSql4.AppendLine("ContractMatDate,");
                    _sbSql4.AppendLine("RatingFactor,");
                    _sbSql4.AppendLine("Contribution)");


                    _sbSql4.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                    // _sbSql.AppendLine("@TxnSysID,");
                    _sbSql4.AppendLine("@TxnSysDate,");
                    _sbSql4.AppendLine("@UserCode,");
                    _sbSql4.AppendLine("@SerialNo,");
                    _sbSql4.AppendLine("@VehicleCode,");
                    _sbSql4.AppendLine("@VehicleModel,");
                    _sbSql4.AppendLine("@UpdatedValue,");
                    _sbSql4.AppendLine("@PreviousValue,");
                    _sbSql4.AppendLine("@Mileage,");
                    _sbSql4.AppendLine("@ParticipantValue,");
                    _sbSql4.AppendLine("@ColorCode,");
                    _sbSql4.AppendLine("@ParticipantName,");
                    _sbSql4.AppendLine("@ParticipantAddress,");
                    // _sbSql.AppendLine("@ModelNumber,");
                    _sbSql4.AppendLine("@RegistrationNumber,");
                    _sbSql4.AppendLine("@CityCode,");
                    _sbSql4.AppendLine("@EngineNumber,");
                    _sbSql4.AppendLine("@AreaCode,");
                    _sbSql4.AppendLine("@ChasisNumber,");
                    _sbSql4.AppendLine("@Remarks,");
                    _sbSql4.AppendLine("@PODate,");
                    _sbSql4.AppendLine("@PONumber,");
                    _sbSql4.AppendLine("@CNICNumber,");
                    _sbSql4.AppendLine("@Tenure,");
                    _sbSql4.AppendLine("@BirthDate,");
                    _sbSql4.AppendLine("@Gender,");
                    _sbSql4.AppendLine("@VehicleType,");
                    _sbSql4.AppendLine("@VEODCode,");
                    _sbSql4.AppendLine("@CertTypeCode,");
                    _sbSql4.AppendLine("@Rate,");
                    _sbSql4.AppendLine("@ParentTxnSysID,");
                    _sbSql4.AppendLine("@OpolTxnSysID,");
                    _sbSql4.AppendLine("@InsuranceTypeCode,");
                    _sbSql4.AppendLine("@CommisionRate,");
                    _sbSql4.AppendLine("@MobileNumber,");
                    _sbSql4.AppendLine("@ResNumber,");
                    _sbSql4.AppendLine("@OfficeNumber,");
                    _sbSql4.AppendLine("@EmailAddress,");
                    _sbSql4.AppendLine("@Deductible,");
                    _sbSql4.AppendLine("@ContractMatDate,");
                    _sbSql4.AppendLine("@RatingFactor,");
                    _sbSql4.AppendLine("@Contribution)");


                    _cmdSql4 = new SqlCommand(_sbSql4.ToString(), _conSql4);




                    DateTime da = DateTime.Now;
                    da.ToString("MM-dd-yyyy h:mm tt");

                    _cmdSql4.Parameters.AddWithValue("@TxnSysDate", Convert.ToDateTime(da));
                    _cmdSql4.Parameters.AddWithValue("@ParentTxnSysID", _TxnSysId);
                    int _userCode = GlobalDataLayer.GetUserCodeById(_VehicleDetailMdl.UserCode);
                    _cmdSql4.Parameters.AddWithValue("@UserCode", _userCode);

                    _cmdSql4.Parameters.AddWithValue("@SerialNo", _SerialNumber1);

                    //----------To be changed by non financial endorsemnet----------//

                    _cmdSql4.Parameters.AddWithValue("@VehicleCode", _VehicleDetailMdl1.VehicleCode);
                    _cmdSql4.Parameters.AddWithValue("@VehicleModel", _VehicleDetailMdl1.VehicleModel);
                    _cmdSql4.Parameters.AddWithValue("@ColorCode", _VehicleDetailMdl1.ColorCode);
                    _cmdSql4.Parameters.AddWithValue("@RegistrationNumber", _VehicleDetailMdl1.RegistrationNumber ?? _VehicleDetailMdl.RegistrationNumber);
                    _cmdSql4.Parameters.AddWithValue("@EngineNumber", _VehicleDetailMdl1.EngineNumber ?? _VehicleDetailMdl.EngineNumber);
                    _cmdSql4.Parameters.AddWithValue("@ChasisNumber", _VehicleDetailMdl1.ChasisNumber ?? _VehicleDetailMdl.ChasisNumber);
                    _cmdSql4.Parameters.AddWithValue("@VehicleType", _VehicleDetailMdl1.VehicleType ?? _VehicleDetailMdl.VehicleType);
                    _cmdSql4.Parameters.AddWithValue("@Mileage", _VehicleDetailMdl1.Mileage);
                    _cmdSql4.Parameters.AddWithValue("@VEODCode", _VehicleDetailMdl1.VEODCode);

                    //Add Remarks for addition
                    _cmdSql4.Parameters.AddWithValue("@Remarks", _VehicleDetailMdl1.Remarks ?? DBNull.Value.ToString());

                    //----------To be changed by non financial endorsemnet----------//

                    _cmdSql4.Parameters.AddWithValue("@CityCode", _VehicleDetailMdl1.CityCode ?? _VehicleDetailMdl.CityCode);
                    _cmdSql4.Parameters.AddWithValue("@AreaCode", _VehicleDetailMdl1.AreaCode);
                    _cmdSql4.Parameters.AddWithValue("@CNICNumber", _VehicleDetailMdl1.CNICNumber ?? _VehicleDetailMdl.CNICNumber);
                    _cmdSql4.Parameters.AddWithValue("@MobileNumber", _VehicleDetailMdl1.MobileNumber ?? _VehicleDetailMdl.MobileNumber);
                    _cmdSql4.Parameters.AddWithValue("@ResNumber", _VehicleDetailMdl1.ResNumber ?? _VehicleDetailMdl.ResNumber);
                    _cmdSql4.Parameters.AddWithValue("@OfficeNumber", _VehicleDetailMdl1.OfficeNumber ?? _VehicleDetailMdl.OfficeNumber);
                    _cmdSql4.Parameters.AddWithValue("@EmailAddress", _VehicleDetailMdl1.EmailAddress ?? _VehicleDetailMdl.EmailAddress);



                    _cmdSql4.Parameters.AddWithValue("@ParticipantName", _VehicleDetailMdl.ParticipantName);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantAddress", _VehicleDetailMdl.ParticipantAddress);
                    _cmdSql4.Parameters.AddWithValue("@Gender", _VehicleDetailMdl.Gender);
                    _cmdSql4.Parameters.AddWithValue("@UpdatedValue", _VehicleDetailMdl.UpdatedValue);
                    _cmdSql4.Parameters.AddWithValue("@PreviousValue", _VehicleDetailMdl.ParticipantValue);
                    _cmdSql4.Parameters.AddWithValue("@ParticipantValue", Convert.ToInt32(0));
                    _cmdSql4.Parameters.AddWithValue("@Tenure", _VehicleDetailMdl.Tenure);
                    _cmdSql4.Parameters.AddWithValue("@BirthDate", _VehicleDetailMdl.BirthDate);
                    _cmdSql4.Parameters.AddWithValue("@PODate", _VehicleDetailMdl.PODate);
                    _cmdSql4.Parameters.AddWithValue("@PONumber", _VehicleDetailMdl.PONumber);
                    _cmdSql4.Parameters.AddWithValue("@CertTypeCode", _VehicleDetailMdl.CertTypeCode);
                    _cmdSql4.Parameters.AddWithValue("@Rate", _VehicleDetailMdl.Rate);
                    _cmdSql4.Parameters.AddWithValue("@InsuranceTypeCode", _VehicleDetailMdl.InsuranceTypeCode);
                    _cmdSql4.Parameters.AddWithValue("@Contribution", Convert.ToDecimal(0));
                    _cmdSql4.Parameters.AddWithValue("@CommisionRate", _VehicleDetailMdl.CommisionRate);
                    _cmdSql4.Parameters.AddWithValue("@Deductible", _VehicleDetailMdl.Deductible);
                    _cmdSql4.Parameters.AddWithValue("@ContractMatDate", _VehicleDetailMdl.ContractMatDate);
                    _cmdSql4.Parameters.AddWithValue("@OpolTxnSysID", _VehicleDetailMdl.OpolTxnSysID);
                    _cmdSql4.Parameters.AddWithValue("@RatingFactor", _VehicleDetailMdl.RatingFactor);
                    _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_VehicleDetailMdl.RatingFactor);



                    _VehicleDetailMdl.SerialNo = _SerialNumber;

                    _VehicleDetailMdl.TxnSysDate = DateTime.Now;

                    //int _TxnSysId2;
                    //_conSql4.Open();
                    //_TxnSysId2 = (Int32)_cmdSql4.ExecuteScalar();
                    //_conSql4.Close();
                    //_VehicleDetailMdl.IsValidTxn = true;
                }

                int _TxnSysId2;
                _conSql4.Open();
                _TxnSysId2 = (Int32)_cmdSql4.ExecuteScalar();
                _conSql4.Close();
                _VehicleDetailMdl.IsValidTxn = true;

                if (_MtrInsPolicyMdl.EndoSerial > 0)
                {
                    //Get values From Ins Update Contribution
                    SqlConnection _conSql5 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    DataTable _tblSqla5 = new DataTable();
                    // MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
                    List<MtrVContributionMdl> _MtrVContributionMdlList = new List<MtrVContributionMdl>();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM InsUpdateContribution iuc INNER JOIN InsContribution ic ON ic.RiskTxnID = iuc.RiskTxnID WHERE ic.TxnSysID = @TxnSysID", conn);

                        command.Parameters.Add(new SqlParameter("@TxnSysID", ConTxnID));

                        SqlDataAdapter _adpSql5 = new SqlDataAdapter(command);


                        _adpSql5.Fill(_tblSqla5);
                    }



                    if (_tblSqla5.Rows.Count > 0)
                    {
                        _MtrVContributionMdl = new MtrVContributionMdl();
                        for (int i = 0; i < _tblSqla5.Rows.Count; i++)
                        {

                            _MtrVContributionMdl.TxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["TxnSysID"]);
                            _MtrVContributionMdl.TxnSysDate = Convert.ToDateTime(_tblSqla5.Rows[i]["TxnSysDate"]);
                            _MtrVContributionMdl.UserCode = Convert.ToInt32(_tblSqla5.Rows[i]["UserCode"]);
                            _MtrVContributionMdl.SumCovered = Convert.ToInt32(_tblSqla5.Rows[i]["SumCovered"]);
                            _MtrVContributionMdl.Rate = Convert.ToDecimal(_tblSqla5.Rows[i]["Rate"]);
                            _MtrVContributionMdl.NetContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["NetContribution"]);
                            _MtrVContributionMdl.GrossContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["GrossContribution"]);
                            _MtrVContributionMdl.FIF = Convert.ToDecimal(_tblSqla5.Rows[i]["FIF"]);
                            _MtrVContributionMdl.FED = Convert.ToDecimal(_tblSqla5.Rows[i]["FED"]);
                            _MtrVContributionMdl.Stamp = Convert.ToDecimal(_tblSqla5.Rows[i]["Stamp"]);
                            _MtrVContributionMdl.BasicContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["BasicContribution"]);
                            _MtrVContributionMdl.PEV = Convert.ToDecimal(_tblSqla5.Rows[i]["PEV"]);
                            _MtrVContributionMdl.BeforePEV = Convert.ToDecimal(_tblSqla5.Rows[i]["BeforePEV"]);
                            _MtrVContributionMdl.TerrorContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["TerrorContribution"]);
                            _MtrVContributionMdl.RiskTxnID = Convert.ToInt32(_tblSqla5.Rows[i]["RiskTxnID"]);
                            _MtrVContributionMdl.PerDayContribution = Convert.ToInt32(_tblSqla5.Rows[i]["PerDayContribution"]);
                            _MtrVContributionMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["OpolTxnSysID"]);

                        }


                    }


                    else
                    {

                    }
                }


                else
                {
                    //Get values From Ins Contribution
                    SqlConnection _conSql5 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    DataTable _tblSqla5 = new DataTable();
                    // MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
                    List<MtrVContributionMdl> _MtrVContributionMdlList = new List<MtrVContributionMdl>();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM InsContribution ic WHERE ic.TxnSysID = @TxnSysID", conn);

                        command.Parameters.Add(new SqlParameter("@TxnSysID", ConTxnID));

                        SqlDataAdapter _adpSql5 = new SqlDataAdapter(command);


                        _adpSql5.Fill(_tblSqla5);
                    }



                    if (_tblSqla5.Rows.Count > 0)
                    {
                        _MtrVContributionMdl = new MtrVContributionMdl();
                        for (int i = 0; i < _tblSqla5.Rows.Count; i++)
                        {

                            _MtrVContributionMdl.TxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["TxnSysID"]);
                            _MtrVContributionMdl.TxnSysDate = Convert.ToDateTime(_tblSqla5.Rows[i]["TxnSysDate"]);
                            _MtrVContributionMdl.UserCode = Convert.ToInt32(_tblSqla5.Rows[i]["UserCode"]);
                            _MtrVContributionMdl.SumCovered = Convert.ToInt32(_tblSqla5.Rows[i]["SumCovered"]);
                            _MtrVContributionMdl.Rate = Convert.ToDecimal(_tblSqla5.Rows[i]["Rate"]);
                            _MtrVContributionMdl.NetContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["NetContribution"]);
                            _MtrVContributionMdl.GrossContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["GrossContribution"]);
                            _MtrVContributionMdl.FIF = Convert.ToDecimal(_tblSqla5.Rows[i]["FIF"]);
                            _MtrVContributionMdl.FED = Convert.ToDecimal(_tblSqla5.Rows[i]["FED"]);
                            _MtrVContributionMdl.Stamp = Convert.ToDecimal(_tblSqla5.Rows[i]["Stamp"]);
                            _MtrVContributionMdl.BasicContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["BasicContribution"]);
                            _MtrVContributionMdl.PEV = Convert.ToDecimal(_tblSqla5.Rows[i]["PEV"]);
                            _MtrVContributionMdl.BeforePEV = Convert.ToDecimal(_tblSqla5.Rows[i]["BeforePEV"]);
                            _MtrVContributionMdl.TerrorContribution = Convert.ToDecimal(_tblSqla5.Rows[i]["TerrorContribution"]);
                            _MtrVContributionMdl.RiskTxnID = Convert.ToInt32(_tblSqla5.Rows[i]["RiskTxnID"]);
                            _MtrVContributionMdl.PerDayContribution = Convert.ToInt32(_tblSqla5.Rows[i]["PerDayContribution"]);
                            _MtrVContributionMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla5.Rows[i]["OpolTxnSysID"]);

                        }


                    }


                    else
                    {

                    }
                }


                //Insert values in to InsUpdateContribution
                SqlConnection _conSql6 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql6 = new StringBuilder();
                SqlCommand _cmdSql6;

                _sbSql6.AppendLine("INSERT INTO InsUpdateContribution(");
                // _sbSql.AppendLine("TxnSysID,");
                _sbSql6.AppendLine("TxnSysDate,");
                _sbSql6.AppendLine("UserCode,");
                _sbSql6.AppendLine("SumCovered,");
                _sbSql6.AppendLine("Rate,");
                _sbSql6.AppendLine("NetContribution,");
                _sbSql6.AppendLine("GrossContribution,");
                _sbSql6.AppendLine("FIF,");
                _sbSql6.AppendLine("FED,");
                _sbSql6.AppendLine("Stamp,");
                _sbSql6.AppendLine("BasicContribution,");
                _sbSql6.AppendLine("PEV,");
                _sbSql6.AppendLine("BeforePEV,");
                _sbSql6.AppendLine("TerrorContribution,");
                _sbSql6.AppendLine("RiskTxnID,");
                _sbSql6.AppendLine("OpolTxnSysID,");
                _sbSql6.AppendLine("PerDayContribution)");

                _sbSql6.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                //_sbSql.AppendLine("@TxnSysID,");
                _sbSql6.AppendLine("@TxnSysDate,");
                _sbSql6.AppendLine("@UserCode,");
                _sbSql6.AppendLine("@SumCovered,");
                _sbSql6.AppendLine("@Rate,");
                _sbSql6.AppendLine("@NetContribution,");
                _sbSql6.AppendLine("@GrossContribution,");
                _sbSql6.AppendLine("@FIF,");
                _sbSql6.AppendLine("@FED,");
                _sbSql6.AppendLine("@Stamp,");
                _sbSql6.AppendLine("@BasicContribution,");
                _sbSql6.AppendLine("@PEV,");
                _sbSql6.AppendLine("@BeforePEV,");
                _sbSql6.AppendLine("@TerrorContribution,");
                _sbSql6.AppendLine("@RiskTxnID,");
                _sbSql6.AppendLine("@OpolTxnSysID,");
                _sbSql6.AppendLine("@PerDayContribution)");

                _cmdSql6 = new SqlCommand(_sbSql6.ToString(), _conSql6);

                _cmdSql6.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                _cmdSql6.Parameters.AddWithValue("@RiskTxnID", _TxnSysId2);
 
                _cmdSql6.Parameters.AddWithValue("@SumCovered", _MtrVContributionMdl.SumCovered);

                int _userCode1 = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl.UserCode);

                _cmdSql6.Parameters.AddWithValue("@UserCode", _userCode1);

                _cmdSql6.Parameters.AddWithValue("@Rate", _MtrVContributionMdl.Rate);
                _cmdSql6.Parameters.AddWithValue("@NetContribution", _MtrVContributionMdl.NetContribution);
                _cmdSql6.Parameters.AddWithValue("@GrossContribution", _MtrVContributionMdl.GrossContribution);
                _cmdSql6.Parameters.AddWithValue("@FIF", _MtrVContributionMdl.FIF);
                _cmdSql6.Parameters.AddWithValue("@FED", _MtrVContributionMdl.FED);
                _cmdSql6.Parameters.AddWithValue("@Stamp", _MtrVContributionMdl.Stamp);
                _cmdSql6.Parameters.AddWithValue("@BasicContribution", _MtrVContributionMdl.BasicContribution);
                _cmdSql6.Parameters.AddWithValue("@PEV", _MtrVContributionMdl.PEV);
                _cmdSql6.Parameters.AddWithValue("@BeforePEV", _MtrVContributionMdl.BeforePEV);
                _cmdSql6.Parameters.AddWithValue("@TerrorContribution", _MtrVContributionMdl.TerrorContribution);
                _cmdSql6.Parameters.AddWithValue("@PerDayContribution", _MtrVContributionMdl.PerDayContribution);

                _cmdSql6.Parameters.AddWithValue("@OpolTxnSysID", _MtrVContributionMdl.OpolTxnSysID);


                int _TxnSysId3;
                _conSql6.Open();
                _TxnSysId3 = (Int32)_cmdSql6.ExecuteScalar();
                _conSql6.Close();

                _MtrVContributionMdl1.TxnSysID = _TxnSysId3;
                _MtrVContributionMdl1.IsValidTxn = true;


                //Insert values in to InsContribution
                SqlConnection _conSql10 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql10 = new StringBuilder();
                SqlCommand _cmdSql10;

                _sbSql10.AppendLine("INSERT INTO InsContribution(");
                // _sbSql.AppendLine("TxnSysID,");
                _sbSql10.AppendLine("TxnSysDate,");
                _sbSql10.AppendLine("UserCode,");
                _sbSql10.AppendLine("SumCovered,");
                _sbSql10.AppendLine("Rate,");
                _sbSql10.AppendLine("NetContribution,");
                _sbSql10.AppendLine("GrossContribution,");
                _sbSql10.AppendLine("FIF,");
                _sbSql10.AppendLine("FED,");
                _sbSql10.AppendLine("Stamp,");
                _sbSql10.AppendLine("BasicContribution,");
                _sbSql10.AppendLine("PEV,");
                _sbSql10.AppendLine("BeforePEV,");
                _sbSql10.AppendLine("TerrorContribution,");
                _sbSql10.AppendLine("RiskTxnID,");
                _sbSql10.AppendLine("OpolTxnSysID,");
                _sbSql10.AppendLine("PerDayContribution)");

                _sbSql10.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                //_sbSql.AppendLine("@TxnSysID,");
                _sbSql10.AppendLine("@TxnSysDate,");
                _sbSql10.AppendLine("@UserCode,");
                _sbSql10.AppendLine("@SumCovered,");
                _sbSql10.AppendLine("@Rate,");
                _sbSql10.AppendLine("@NetContribution,");
                _sbSql10.AppendLine("@GrossContribution,");
                _sbSql10.AppendLine("@FIF,");
                _sbSql10.AppendLine("@FED,");
                _sbSql10.AppendLine("@Stamp,");
                _sbSql10.AppendLine("@BasicContribution,");
                _sbSql10.AppendLine("@PEV,");
                _sbSql10.AppendLine("@BeforePEV,");
                _sbSql10.AppendLine("@TerrorContribution,");
                _sbSql10.AppendLine("@RiskTxnID,");
                _sbSql10.AppendLine("@OpolTxnSysID,");
                _sbSql10.AppendLine("@PerDayContribution)");

                _cmdSql10 = new SqlCommand(_sbSql10.ToString(), _conSql10);

                _cmdSql10.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                _cmdSql10.Parameters.AddWithValue("@RiskTxnID", _TxnSysId2);

                _cmdSql10.Parameters.AddWithValue("@SumCovered", Convert.ToInt32(0));

                int _userCode2 = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl.UserCode);

                _cmdSql10.Parameters.AddWithValue("@UserCode", _userCode2);

                _cmdSql10.Parameters.AddWithValue("@Rate", Convert.ToInt32(0));
                _cmdSql10.Parameters.AddWithValue("@NetContribution", Convert.ToInt32(0));
                _cmdSql10.Parameters.AddWithValue("@GrossContribution", Convert.ToInt32(0));
                _cmdSql10.Parameters.AddWithValue("@FIF", Convert.ToInt32(0));
                _cmdSql10.Parameters.AddWithValue("@FED", Convert.ToInt32(0));
                _cmdSql10.Parameters.AddWithValue("@Stamp", Convert.ToInt32(0));
                _cmdSql10.Parameters.AddWithValue("@BasicContribution", Convert.ToInt32(0));
                _cmdSql10.Parameters.AddWithValue("@PEV", Convert.ToInt32(0));
                _cmdSql10.Parameters.AddWithValue("@BeforePEV", Convert.ToInt32(0));
                _cmdSql10.Parameters.AddWithValue("@TerrorContribution", Convert.ToInt32(0));
                _cmdSql10.Parameters.AddWithValue("@PerDayContribution", Convert.ToInt32(0));

                _cmdSql10.Parameters.AddWithValue("@OpolTxnSysID", _MtrVContributionMdl.OpolTxnSysID);

                int _TxnSysId4;
                _conSql10.Open();
                _TxnSysId4 = (Int32)_cmdSql10.ExecuteScalar();
                _conSql10.Close();

                _MtrVContributionMdl1.TxnSysID = _TxnSysId4;

                _MtrVContributionMdl1.IsValidTxn = true;



                //For Co-insurance
                if (_VehicleDetailMdl.InsuranceTypeCode == 2 || _VehicleDetailMdl.InsuranceTypeCode == 3)
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
                            _InsCoInsuranceA1.TerrorContribution = Convert.ToDecimal(_tblSqlaA1.Rows[i]["TerrorContribution "]);


                            _InsCoInsuranceListA1.Add(_InsCoInsuranceA1);
                        }

                        //Insert InTo CoInsurance for Endorsement
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
                            _sbSqlA2.AppendLine("@RiskTxnID,");
                            _sbSqlA2.AppendLine("@OpolTxnSysID,");
                            _sbSqlA2.AppendLine("@PerDayContribution,");
                            _sbSqlA2.AppendLine("@CoInsuranceCode,");
                            _sbSqlA2.AppendLine("@CoInsuranceShare)");


                            _cmdSqlA2 = new SqlCommand(_sbSqlA2.ToString(), _conSqlA2);

                            _cmdSqlA2.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                            _cmdSqlA2.Parameters.AddWithValue("@RiskTxnID", _TxnSysId2);
                            _cmdSqlA2.Parameters.AddWithValue("@SumCovered", Convert.ToInt32(0));

                            int _userCodeA2 = GlobalDataLayer.GetUserCodeById(ConInsList[i].UserCode);

                            _cmdSqlA2.Parameters.AddWithValue("@UserCode", _userCodeA2);


                            _cmdSqlA2.Parameters.AddWithValue("@Rate", Convert.ToInt32(0));
                            _cmdSqlA2.Parameters.AddWithValue("@NetContribution", Convert.ToInt32(0));
                            _cmdSqlA2.Parameters.AddWithValue("@GrossContribution", Convert.ToInt32(0));
                            _cmdSqlA2.Parameters.AddWithValue("@FIF", Convert.ToInt32(0));
                            _cmdSqlA2.Parameters.AddWithValue("@FED", Convert.ToInt32(0));
                            _cmdSqlA2.Parameters.AddWithValue("@Stamp", Convert.ToInt32(0));
                            _cmdSqlA2.Parameters.AddWithValue("@BasicContribution", Convert.ToInt32(0));
                            _cmdSqlA2.Parameters.AddWithValue("@PEV", Convert.ToInt32(0));
                            _cmdSqlA2.Parameters.AddWithValue("@BeforePEV", Convert.ToInt32(0));
                            _cmdSqlA2.Parameters.AddWithValue("@TerrorContribution", Convert.ToInt32(0));
                            // _cmdSqlA2.Parameters.AddWithValue("@RiskTxnID", ConInsList[i].RiskTxnID);
                            _cmdSqlA2.Parameters.AddWithValue("@OpolTxnSysID", ConInsList[i].OpolTxnSysID);
                            _cmdSqlA2.Parameters.AddWithValue("@PerDayContribution", Convert.ToInt32(0));
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


                SqlConnection _conSql9 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                DataTable _tblSqla9 = new DataTable();
                VehicleDetailMdl _VehicleDetailMdl2;
                List<VehicleDetailMdl> _VehicleDetailMdlList2 = new List<VehicleDetailMdl>();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT TOP 1 mvd.TxnSysID, mvd.TxnSysDate, mvd.UserCode, mvd.SerialNo, " +
                        "mvd.VehicleCode, mvd.VehicleModel,  mvd.UpdatedValue, mvd.PreviousValue, mvd.Mileage, mvd.ParticipantValue, " +
                        "mvd.ColorCode, mvd.ParticipantName, mvd.ParticipantAddress, mvd.RegistrationNumber, mvd.CityCode, " +
                        "mvd.EngineNumber, mvd.AreaCode, mvd.ChasisNumber, mvd.Remarks, mvd.PODate, mvd.PONumber, mvd.CNICNumber, " +
                        "mvd.Tenure, mvd.BirthDate, mvd.Gender, mvd.VehicleType, mvd.VEODCode, mvd.CertTypeCode, mvd.Rate, " +
                        "mvd.Contribution, mvd.InsuranceTypeCode, mvd.CommisionRate, mvd.IsActive, mvd.IsCanceled, mvd.OpolTxnSysID, " +
                        "mvd.MobileNumber, mvd.ResNumber, mvd.OfficeNumber, mvd.EmailAddress, mvd.Deductible, mvd.ContractMatDate, " +
                        "mvd.ParentTxnSysID, mvd.ContractMatDate, " +
                        "ip.ParentTxnSysID InsPolicyID, ip.DocMonth, ip.DocString, ip.DocYear, ip.DocNo, ip.DocType, ip.GenerateAgainst," +
                        " ip.ProductCode, ip.PolicyTypeCode, ip.ClientCode, ip.AgencyCode, ip.CertInsureCode, ip.Remarks Remarks1, ip.BrchCoverNoteNo,ip.BrchCode, " +
                        "ip.LeaderPolicyNo, ip.LeaderEndNo, ip.IsFiler, ip.CalcType, ip.IsAuto, ip.EffectiveDate, ip.ExpiryDate, ip.SerialNo SerialNo1, " +
                        "ip.UWYear, ip.CreatedBy, ip.PostedBy, ip.IsPosted, ip.PostDate, ip.OpolTxnSysID OpolTxnSysID1, ip.RenewSysID, ip.PolSysID, " +
                        "ip.IsRenewal, ip.CommisionRate CommisionRate1, ic.TxnSysID ConTxnID, ic.SumCovered, ic.Rate Rate2, ic.NetContribution," +
                        " ic.GrossContribution, ic.FIF, ic.FED, ic.Stamp, ic.BasicContribution, ic.PEV, ic.BeforePEV, ic.TerrorContribution, ic.RiskTxnID, " +
                        "ic.PerDayContribution, ic.OpolTxnSysID OpolTxnSysID2, ic.IsActive, " +
                        "ip.DocString, ip.PolicyTypeCode ," +
                        "pp.RatingFactor FROM MtrVehicleDetails mvd " +
                        "INNER JOIN InsPolicy ip ON mvd.ParentTxnSysID = ip.ParentTxnSysID " +
                        "INNER JOIN InsContribution ic ON ic.RiskTxnID = mvd.TxnSysID " +
                        //"INNER JOIN MtrOpenPolicy mop ON mop.TxnSysID = mvd.OpolTxnSysID " +
                        "INNER JOIN MasterProductSetup mp ON mp.ProductCode = ip.ProductCode " +
                        "INNER JOIN ProductRatingFactorsProductSetup pp ON pp.PrdStpTxnSysId = mp.TxnSysID " +
                        "WHERE ip.IsActive <> 0 AND mvd.TxnSysID = (SELECT MAX(TxnSysID) FROM MtrVehicleDetails)"
                        , conn);



                    SqlDataAdapter _adpSql9 = new SqlDataAdapter(command);


                    _adpSql9.Fill(_tblSqla9);
                }


                if (_tblSqla9.Rows.Count > 0)
                {
                    _VehicleDetailMdl2 = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla9.Rows.Count; i++)
                    {

                        //Getting Vehicle Details
                        _VehicleDetailMdl2.TxnSysID = Convert.ToInt32(_tblSqla9.Rows[i]["TxnSysID"]);
                        _VehicleDetailMdl2.TxnSysDate = Convert.ToDateTime(_tblSqla9.Rows[i]["TxnSysDate"]);
                        _VehicleDetailMdl2.UserCode = Convert.ToInt32(_tblSqla9.Rows[i]["UserCode"]);
                        _VehicleDetailMdl2.SerialNo = Convert.ToInt32(_tblSqla9.Rows[i]["SerialNo"].ToString());
                        _VehicleDetailMdl2.VehicleCode = Convert.ToInt32(_tblSqla9.Rows[i]["VehicleCode"].ToString());
                        _VehicleDetailMdl2.VehicleModel = Convert.ToInt32(_tblSqla9.Rows[i]["VehicleModel"].ToString());
                        _VehicleDetailMdl2.UpdatedValue = Convert.ToDecimal(_tblSqla9.Rows[i]["UpdatedValue"]);
                        _VehicleDetailMdl2.PreviousValue = Convert.ToDecimal(_tblSqla9.Rows[i]["PreviousValue"]);
                        _VehicleDetailMdl2.Mileage = Convert.ToInt32(_tblSqla9.Rows[i]["Mileage"].ToString());
                        _VehicleDetailMdl2.ParticipantValue = Convert.ToDecimal(_tblSqla9.Rows[i]["ParticipantValue"]);
                        _VehicleDetailMdl2.ColorCode = Convert.ToInt32(_tblSqla9.Rows[i]["ColorCode"].ToString());
                        _VehicleDetailMdl2.ParticipantName = _tblSqla9.Rows[i]["ParticipantName"].ToString();
                        _VehicleDetailMdl2.ParticipantAddress = _tblSqla9.Rows[i]["ParticipantAddress"].ToString();
                        _VehicleDetailMdl2.ContractMatDate = Convert.ToDateTime(_tblSqla9.Rows[i]["ContractMatDate"]);

                        _VehicleDetailMdl2.RegistrationNumber = _tblSqla9.Rows[i]["RegistrationNumber"].ToString();
                        _VehicleDetailMdl2.CityCode = _tblSqla9.Rows[i]["CityCode"].ToString();
                        _VehicleDetailMdl2.EngineNumber = _tblSqla9.Rows[i]["EngineNumber"].ToString();
                        _VehicleDetailMdl2.AreaCode = Convert.ToInt32(_tblSqla9.Rows[i]["AreaCode"].ToString());
                        _VehicleDetailMdl2.ChasisNumber = _tblSqla9.Rows[i]["ChasisNumber"].ToString();
                        _VehicleDetailMdl2.Remarks = _tblSqla9.Rows[i]["Remarks"].ToString();
                        // _VehicleDetailMdl2.PODate = Convert.ToDateTime(_tblSqla9.Rows[i]["PODate"]);
                        _VehicleDetailMdl2.PONumber = (_tblSqla9.Rows[i]["PONumber"].ToString());
                        _VehicleDetailMdl2.CNICNumber = _tblSqla9.Rows[i]["CNICNumber"].ToString();
                        _VehicleDetailMdl2.Tenure = _tblSqla9.Rows[i]["Tenure"].ToString();
                        _VehicleDetailMdl2.BirthDate = Convert.ToDateTime(_tblSqla9.Rows[i]["BirthDate"]);
                        _VehicleDetailMdl2.Gender = _tblSqla9.Rows[i]["Gender"].ToString();
                        _VehicleDetailMdl2.VehicleType = _tblSqla9.Rows[i]["VehicleType"].ToString();
                        _VehicleDetailMdl2.VEODCode = Convert.ToInt32(_tblSqla9.Rows[i]["VEODCode"]);
                        _VehicleDetailMdl2.CertTypeCode = _tblSqla9.Rows[i]["CertTypeCode"].ToString();
                        _VehicleDetailMdl2.Rate = Convert.ToInt32(_tblSqla9.Rows[i]["Rate"]);
                        _VehicleDetailMdl2.Contribution = Convert.ToInt32(_tblSqla9.Rows[i]["Contribution"]);
                        _VehicleDetailMdl2.ParentTxnSysID = Convert.ToInt32(_tblSqla9.Rows[i]["ParentTxnSysID"]);
                        _VehicleDetailMdl2.OpolTxnSysID = Convert.ToInt32(_tblSqla9.Rows[i]["OpolTxnSysID"]);

                        _VehicleDetailMdl2.VEODName = GlobalDataLayer.GetVEODNameByCode(Convert.ToInt32(_tblSqla9.Rows[i]["VEODCode"]));
                        _VehicleDetailMdl2.VehicleTypeName = GlobalDataLayer.GetVehicleTypeNameByCode(_tblSqla9.Rows[i]["VehicleType"].ToString());

                        _VehicleDetailMdl2.InsuranceTypeCode = Convert.ToInt32(_tblSqla9.Rows[i]["InsuranceTypeCode"]);
                        _VehicleDetailMdl2.IsActive = Convert.ToBoolean(_tblSqla9.Rows[i]["IsActive"]);
                        _VehicleDetailMdl2.IsCanceled = Convert.ToBoolean(_tblSqla9.Rows[i]["IsCanceled"]);
                        _VehicleDetailMdl2.CommisionRate = Convert.ToDecimal(_tblSqla9.Rows[i]["CommisionRate"]);
                        _VehicleDetailMdl2.MobileNumber = _tblSqla9.Rows[i]["MobileNumber"].ToString();
                        _VehicleDetailMdl2.ResNumber = _tblSqla9.Rows[i]["ResNumber"].ToString();
                        _VehicleDetailMdl2.OfficeNumber = _tblSqla9.Rows[i]["OfficeNumber"].ToString();

                        _VehicleDetailMdl2.EmailAddress = _tblSqla9.Rows[i]["EmailAddress"].ToString();
                        _VehicleDetailMdl2.Deductible = Convert.ToDecimal(_tblSqla9.Rows[i]["Deductible"]);

                        _VehicleDetailMdl2.ContractMatDate = Convert.ToDateTime(_tblSqla9.Rows[i]["ContractMatDate"]);


                        _VehicleDetailMdl2.GenderName = GlobalDataLayer.GetGenderNameByCode(_tblSqla9.Rows[i]["Gender"].ToString());
                        _VehicleDetailMdl2.CityName = GlobalDataLayer.GetCityNameByCode(_tblSqla9.Rows[i]["CityCode"].ToString());
                        _VehicleDetailMdl2.ColorName = GlobalDataLayer.GetVehicleColorNameByCode(Convert.ToInt32(_tblSqla9.Rows[i]["ColorCode"].ToString()));
                        _VehicleDetailMdl2.VehicleName = GlobalDataLayer.GetVehicleNameByCode(Convert.ToInt32(_tblSqla9.Rows[i]["VehicleCode"].ToString()));
                        _VehicleDetailMdl2.AreaName = GlobalDataLayer.GetAreaNameByCode(Convert.ToInt32(_tblSqla9.Rows[i]["AreaCode"].ToString()));
                        _VehicleDetailMdl2.CertTypeName = GlobalDataLayer.GetCertTypeByCode(_tblSqla9.Rows[i]["CertTypeCode"].ToString());
                        _VehicleDetailMdl2.InsuranceTypeName = GlobalDataLayer.GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla9.Rows[i]["InsuranceTypeCode"]));

                        _VehicleDetailMdl2.total = GlobalDataLayer.calculate(_VehicleDetailMdl);

                        //For InsPolicy
                        _VehicleDetailMdl2.InsPolicyID = Convert.ToInt32(_tblSqla9.Rows[i]["InsPolicyID"]);
                        _VehicleDetailMdl2.CertMonth = _tblSqla9.Rows[i]["DocMonth"].ToString();
                        _VehicleDetailMdl2.CertString = _tblSqla9.Rows[i]["DocString"].ToString();
                        _VehicleDetailMdl2.CertYear = _tblSqla9.Rows[i]["DocYear"].ToString();
                        _VehicleDetailMdl2.CertNo = Convert.ToInt32(_tblSqla9.Rows[i]["DocNo"]);
                        _VehicleDetailMdl2.DocType = _tblSqla9.Rows[i]["DocType"].ToString();
                        _VehicleDetailMdl2.GenerateAgainst = _tblSqla9.Rows[i]["GenerateAgainst"].ToString();
                        _VehicleDetailMdl2.ProductCode = Convert.ToInt32(_tblSqla9.Rows[i]["ProductCode"]);
                        _VehicleDetailMdl2.PolicyTypeCode = _tblSqla9.Rows[i]["PolicyTypeCode"].ToString();
                        _VehicleDetailMdl2.ClientCode = _tblSqla9.Rows[i]["ClientCode"].ToString();
                        _VehicleDetailMdl2.AgencyCode = _tblSqla9.Rows[i]["AgencyCode"].ToString();
                        _VehicleDetailMdl2.CertInsureCode = _tblSqla9.Rows[i]["CertInsureCode"].ToString();
                        _VehicleDetailMdl2.Remarks1 = _tblSqla9.Rows[i]["Remarks1"].ToString();
                        _VehicleDetailMdl2.BrchCoverNoteNo = _tblSqla9.Rows[i]["BrchCoverNoteNo"].ToString();
                        _VehicleDetailMdl2.BrchCode = _tblSqla9.Rows[i]["BrchCode"].ToString();
                        _VehicleDetailMdl2.LeaderPolicyNo = _tblSqla9.Rows[i]["LeaderPolicyNo"].ToString();
                        _VehicleDetailMdl2.LeaderEndNo = _tblSqla9.Rows[i]["LeaderEndNo"].ToString();
                        _VehicleDetailMdl2.IsFiler = _tblSqla9.Rows[i]["IsFiler"].ToString();
                        _VehicleDetailMdl2.CalcType = _tblSqla9.Rows[i]["CalcType"].ToString();
                        _VehicleDetailMdl2.IsAuto = _tblSqla9.Rows[i]["IsAuto"].ToString();
                        _VehicleDetailMdl2.EffectiveDate = Convert.ToDateTime(_tblSqla9.Rows[i]["EffectiveDate"]);
                        _VehicleDetailMdl2.ExpiryDate = Convert.ToDateTime(_tblSqla9.Rows[i]["ExpiryDate"]);
                        _VehicleDetailMdl2.SerialNo1 = Convert.ToInt32(_tblSqla9.Rows[i]["SerialNo1"]);
                        _VehicleDetailMdl2.UWYear = _tblSqla9.Rows[i]["UWYear"].ToString();
                        _VehicleDetailMdl2.CreatedBy = _tblSqla9.Rows[i]["CreatedBy"].ToString();
                        _VehicleDetailMdl2.PostedBy = _tblSqla9.Rows[i]["PostedBy"].ToString();
                        _VehicleDetailMdl2.IsPosted = Convert.ToBoolean(_tblSqla9.Rows[i]["IsPosted"]);
                        // _VehicleDetailMdl2.PostDate = Convert.ToDateTime(_tblSqla9.Rows[i]["PostDate"]);
                        _VehicleDetailMdl2.OpolTxnSysID1 = Convert.ToInt32(_tblSqla9.Rows[i]["OpolTxnSysID1"]);
                        // _VehicleDetailMdl2.RenewSysID = Convert.ToInt32(_tblSqla9.Rows[i]["RenewSysID"]);
                        _VehicleDetailMdl2.PolSysID = Convert.ToInt32(_tblSqla9.Rows[i]["PolSysID"]);
                        _VehicleDetailMdl2.IsRenewal = Convert.ToBoolean(_tblSqla9.Rows[i]["IsRenewal"]);
                        _VehicleDetailMdl2.CommisionRate1 = Convert.ToDecimal(_tblSqla9.Rows[i]["CommisionRate1"]);

                        _VehicleDetailMdl2.RatingFactor = _tblSqla9.Rows[i]["RatingFactor"].ToString();
                        _VehicleDetailMdl2.RatingFactorShText = GetRaitingFactorByCode(_tblSqla9.Rows[i]["RatingFactor"].ToString());

                        _VehicleDetailMdl2.IsValidTxn = true;


                        _VehicleDetailMdl2.ProductName = GlobalDataLayer.GetProductNameByProductCode(_tblSqla9.Rows[i]["ProductCode"].ToString());
                        _VehicleDetailMdl2.PolicyTypeName = GlobalDataLayer.GetPolicyTypeNameByPolicyTypeCode(_tblSqla9.Rows[i]["PolicyTypeCode"].ToString());
                        _VehicleDetailMdl2.ClientName = GlobalDataLayer.GetClientNameByClientCode(_tblSqla9.Rows[i]["ClientCode"].ToString());
                        _VehicleDetailMdl2.AgentName = GlobalDataLayer.GetAgentNameByAgentCode(_tblSqla9.Rows[i]["AgencyCode"].ToString());
                        _VehicleDetailMdl2.CertInsureName = GlobalDataLayer.GetCertInsNameByCertInsCode(_tblSqla9.Rows[i]["CertInsureCode"].ToString());

                        _VehicleDetailMdl2.DocTypeName = GlobalDataLayer.GetDocTypeNameByDocTypeCode(_tblSqla9.Rows[i]["DocType"].ToString());
                        _VehicleDetailMdl2.IsFilerName = GlobalDataLayer.GetIsFilerNameByIsFilerCode(_tblSqla9.Rows[i]["IsFiler"].ToString());
                        _VehicleDetailMdl2.CalcName = GlobalDataLayer.GetCalcNameByCalcCode(_tblSqla9.Rows[i]["CalcType"].ToString());
                        _VehicleDetailMdl2.IsAutoName = GlobalDataLayer.GetIsAutoNameByIsAutoCode(_tblSqla9.Rows[i]["IsAuto"].ToString());


                        //For Contribution
                        _VehicleDetailMdl2.ConTxnID = Convert.ToInt32(_tblSqla9.Rows[i]["ConTxnID"]);

                        _VehicleDetailMdl2.SumCovered = Convert.ToInt32(_tblSqla9.Rows[i]["SumCovered"]);
                        _VehicleDetailMdl2.Rate2 = Convert.ToDecimal(_tblSqla9.Rows[i]["Rate2"]);
                        _VehicleDetailMdl2.NetContribution = Convert.ToDecimal(_tblSqla9.Rows[i]["NetContribution"]);
                        _VehicleDetailMdl2.GrossContribution = Convert.ToDecimal(_tblSqla9.Rows[i]["GrossContribution"]);
                        _VehicleDetailMdl2.FIF = Convert.ToDecimal(_tblSqla9.Rows[i]["FIF"]);
                        _VehicleDetailMdl2.FED = Convert.ToDecimal(_tblSqla9.Rows[i]["FED"]);
                        _VehicleDetailMdl2.Stamp = Convert.ToDecimal(_tblSqla9.Rows[i]["Stamp"]);
                        _VehicleDetailMdl2.BasicContribution = Convert.ToDecimal(_tblSqla9.Rows[i]["BasicContribution"]);
                        _VehicleDetailMdl2.PEV = Convert.ToDecimal(_tblSqla9.Rows[i]["PEV"]);
                        _VehicleDetailMdl2.BeforePEV = Convert.ToDecimal(_tblSqla9.Rows[i]["BeforePEV"]);
                        _VehicleDetailMdl2.TerrorContribution = Convert.ToDecimal(_tblSqla9.Rows[i]["TerrorContribution"]);
                        _VehicleDetailMdl2.RiskTxnID = Convert.ToInt32(_tblSqla9.Rows[i]["RiskTxnID"]);
                        _VehicleDetailMdl2.PerDayContribution = Convert.ToInt32(_tblSqla9.Rows[i]["PerDayContribution"]);
                        _VehicleDetailMdl2.OpolTxnSysID2 = Convert.ToInt32(_tblSqla9.Rows[i]["OpolTxnSysID2"]);



                        _VehicleDetailMdl2.GrossContribution = Decimal.Round(Convert.ToDecimal(_tblSqla9.Rows[i]["GrossContribution"]), MidpointRounding.ToEven);
                        _VehicleDetailMdl2.PEV = Decimal.Round(Convert.ToDecimal(_tblSqla9.Rows[i]["PEV"]), MidpointRounding.ToEven);
                        // _VehicleDetailMdl2.SumCovered = Decimal.Round(_MtrVContributionMdl.SumCovered,  MidpointRounding.ToEven);
                        _VehicleDetailMdl2.NetContribution = Decimal.Round(Convert.ToDecimal(_tblSqla9.Rows[i]["NetContribution"]), MidpointRounding.ToEven);
                        _VehicleDetailMdl2.BeforePEV = Decimal.Round(Convert.ToDecimal(_tblSqla9.Rows[i]["BeforePEV"]), MidpointRounding.ToEven);


                        _VehicleDetailMdl2.PolicyString = _tblSqla9.Rows[i]["DocString"].ToString();

                        //Difference of added value and previous value
                        decimal diff1 = _VehicleDetailMdl2.NetContribution - Convert.ToDecimal(_tblSqla9.Rows[i]["NetContribution"]); ;
                        _VehicleDetailMdl2.Difference = diff1;

                        _VehicleDetailMdlList2.Add(_VehicleDetailMdl2);

                    }
                    return _VehicleDetailMdl2;

                }


                else
                {

                    return null;

                }



            }

            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return null;
            }

        }

        //Get Endorsement Type For Non Financial Endorsemnt
        public List<EndtReasonMdl> GetNonFEndtReasonMdl()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM EndtReason WHERE  EndtTypeCode = 3";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<EndtReasonMdl> _EndtReasonMdlList = new List<EndtReasonMdl>();
                EndtReasonMdl _EndtReasonMdl;


                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _EndtReasonMdl = new EndtReasonMdl();

                        _EndtReasonMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _EndtReasonMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _EndtReasonMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _EndtReasonMdl.EndtReasonCode = Convert.ToInt32(_tblSqla.Rows[i]["EndtReasonCode"]);
                        _EndtReasonMdl.EndtReasonName = _tblSqla.Rows[i]["EndtReasonName"].ToString();
                        _EndtReasonMdl.EndtTypeCode = Convert.ToInt32(_tblSqla.Rows[i]["EndtTypeCode"]);

                        _EndtReasonMdlList.Add(_EndtReasonMdl);
                    }

                    return _EndtReasonMdlList;
                }
                else
                {

                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return null;
            }
        }


        //---------------- Non Financial Endorsement ---------------------//

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
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return 0;
            }

        }

        //For Increment of Serial Numbers for Vehicle Details
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
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return 0;
            }

        }

        //For Increment Endorsement Serial of InsPolicy
        public static int GetEndoSerial(int _EndoSerial)
        {
            try
            {
                //SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //string _sqlString = "SELECT MAX(EndoSerial) LastEndoSerial FROM InsPolicy";
                //SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                //DataTable _tbl = new DataTable();
               
                int _result;

               // _adpSql.Fill(_tbl);

                if (_EndoSerial == 0)
                {
                    _result = 1;
                }
                else
                {
                    int _tmpNumber = _EndoSerial + 1;
                    _result = _tmpNumber;
                }

                return _result;
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return 0;
            }

        }

        //Get all EndtType
        public List<EndtTypeMdl> GetEndtTypeMdl()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM EndtType WHERE EndtTypeCode <> 3";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<EndtTypeMdl> _EndtTypeMdlList = new List<EndtTypeMdl>();
                EndtTypeMdl _EndtTypeMdl;


                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _EndtTypeMdl = new EndtTypeMdl();

                        _EndtTypeMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _EndtTypeMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _EndtTypeMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _EndtTypeMdl.EndtTypeCode = Convert.ToInt32(_tblSqla.Rows[i]["EndtTypeCode"]);
                        _EndtTypeMdl.EndtTypeName = _tblSqla.Rows[i]["EndtTypeName"].ToString();





                        _EndtTypeMdlList.Add(_EndtTypeMdl);
                    }

                    return _EndtTypeMdlList;
                }
                else
                {

                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return null;
            }
        }

        //Get all Endt Reason
        public List<EndtReasonMdl> GetEndtReasonMdl(EndtTypeMdl _EndtTypeMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM EndtReason WHERE EndtTypeCode = "+_EndtTypeMdl.EndtTypeCode;
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<EndtReasonMdl> _EndtReasonMdlList = new List<EndtReasonMdl>();
                EndtReasonMdl _EndtReasonMdl;


                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _EndtReasonMdl = new EndtReasonMdl();

                        _EndtReasonMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _EndtReasonMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _EndtReasonMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _EndtReasonMdl.EndtReasonCode = Convert.ToInt32(_tblSqla.Rows[i]["EndtReasonCode"]);
                        _EndtReasonMdl.EndtReasonName = _tblSqla.Rows[i]["EndtReasonName"].ToString();
                        _EndtReasonMdl.EndtTypeCode = Convert.ToInt32(_tblSqla.Rows[i]["EndtTypeCode"]);






                        _EndtReasonMdlList.Add(_EndtReasonMdl);
                    }

                    return _EndtReasonMdlList;
                }
                else
                {

                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return null;
            }
        }

        //For Creation of Cert String
        public string GetCertString(string _BranchCode, string InsuranceType, string _DocType, int _PolicyTypeCode, int _SerialNumber, string _PolicyMonth, string _PolicyYear)
        {
            string PolicyString = _BranchCode + "-" + InsuranceType + "-2-" + _DocType + "-000" + _PolicyTypeCode + "-00" + _SerialNumber + "-" + _PolicyMonth + "-" + _PolicyYear;
            return PolicyString;
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return null;
            }
        }

        //Get Rating Factor By Rate and Product Code
        public string GetRatingFactor(int productCode, decimal Rate) {

            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM ProductRatingFactorsProductSetup prfps  INNER JOIN MasterProductSetup mps ON mps.TxnSysID = prfps.PrdStpTxnSysId WHERE mps.ProductCode = " +productCode+" AND prfps.Rate = " +Rate;
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _ProductRatingFactorSetUpMdl = new ProductRatingFactorSetUpMdl();
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {

                        _ProductRatingFactorSetUpMdl.RatingFactor = _tbl.Rows[i]["RatingFactor"].ToString();

                    }
                    return _ProductRatingFactorSetUpMdl.RatingFactor;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Endorsement DataLayer");
                return null;
            }

        }

    }

} 
