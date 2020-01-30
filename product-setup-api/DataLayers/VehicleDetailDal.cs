using ProductSetupApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Globalization;

using System.Web;
using static ProductSetupApi.Models.InsPolicyMdl;
using static ProductSetupApi.Models.MtrVehicleDetailMdl;
using static ProductSetupApi.Models.OpenPolicyMdl;

namespace ProductSetupApi.DataLayers
{
    public class VehicleDetailDal
    {

        //---------------- CRUD Starts From Here -------------------//


        //for getting all Motor Vehicle Certificates For Open Policy
        public List<VehicleDetailMdl> GetVehicleDetail(MtrOpenPolicyMdl _MtrOpenPolicyMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrVehicleDetails mvd INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE ip.IsActive <> 0 AND mvd.OpolTxnSysID = " + _MtrOpenPolicyMdl.TxnSysID;
                // string _sqlString = "SELECT mvd.* FROM MtrVehicleDetails mvd INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE ip.ParentTxnSysID = "+_MtrInsPolicyMdl.ParentTxnSysID;
                // string _sqlString = "SELECT mvd.* FROM MtrVehicleDetails mvd";
                //+ " WHERE  FORMAT(TxnSysDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + 
                // "AND FORMAT(EffectiveDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + "AND FORMAT(ExpiryDate, 'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(), 'yyyy-MM-dd'))";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<VehicleDetailMdl> _VehicleDetailMdlList = new List<VehicleDetailMdl>();
                VehicleDetailMdl _VehicleDetailMdl;

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
                        _VehicleDetailMdl.Rate = Convert.ToDecimal(_tblSqla.Rows[i]["Rate"]);
                        _VehicleDetailMdl.Contribution = Convert.ToInt32(_tblSqla.Rows[i]["Contribution"]);
                        _VehicleDetailMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["ParentTxnSysID"]);
                        _VehicleDetailMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["OpolTxnSysID"]);

                        _VehicleDetailMdl.VEODName = GetVEODNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["VEODCode"]));
                        _VehicleDetailMdl.VehicleTypeName = GetVehicleTypeNameByCode(_tblSqla.Rows[i]["VehicleType"].ToString());

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


                        _VehicleDetailMdl.GenderName = GetGenderNameByCode(_tblSqla.Rows[i]["Gender"].ToString());
                        _VehicleDetailMdl.CityName = GetCityNameByCode(_tblSqla.Rows[i]["CityCode"].ToString());
                        _VehicleDetailMdl.ColorName = GetVehicleColorNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["ColorCode"].ToString()));
                        _VehicleDetailMdl.VehicleName = GetVehicleNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["VehicleCode"].ToString()));
                        _VehicleDetailMdl.AreaName = GetAreaNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["AreaCode"].ToString()));
                        _VehicleDetailMdl.CertTypeName = GetCertTypeByCode(_tblSqla.Rows[i]["CertTypeCode"].ToString());
                        _VehicleDetailMdl.InsuranceTypeName = GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]));

                        _VehicleDetailMdl.RatingFactor = _tblSqla.Rows[i]["RatingFactor"].ToString();
                        _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_tblSqla.Rows[i]["RatingFactor"].ToString());

                        _VehicleDetailMdl.total = calculate(_VehicleDetailMdl);


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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //for getting all Motor Vehicle Certificates For Policy
        public List<VehicleDetailMdl> GetVehicleDetailForPol(MtrInsPolicyMdl _MtrInsPolicyMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrVehicleDetails mvd WHERE mvd.ParentTxnSysID =  " + _MtrInsPolicyMdl.ParentTxnSysID;
                // string _sqlString = "SELECT mvd.* FROM MtrVehicleDetails mvd INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE ip.ParentTxnSysID = "+_MtrInsPolicyMdl.ParentTxnSysID;
                // string _sqlString = "SELECT mvd.* FROM MtrVehicleDetails mvd";
                //+ " WHERE  FORMAT(TxnSysDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + 
                // "AND FORMAT(EffectiveDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + "AND FORMAT(ExpiryDate, 'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(), 'yyyy-MM-dd'))";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<VehicleDetailMdl> _VehicleDetailMdlList = new List<VehicleDetailMdl>();
                VehicleDetailMdl _VehicleDetailMdl;

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
                        // _VehicleDetailMdl.ModelNumber = Convert.ToInt32(_tblSqla.Rows[i]["ModelNumber"]);
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
                        _VehicleDetailMdl.Rate = Convert.ToDecimal(_tblSqla.Rows[i]["Rate"]);
                        _VehicleDetailMdl.Contribution = Convert.ToInt32(_tblSqla.Rows[i]["Contribution"]);
                        _VehicleDetailMdl.ParentTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["ParentTxnSysID"]);
                        _VehicleDetailMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["OpolTxnSysID"]);

                        _VehicleDetailMdl.VEODName = GetVEODNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["VEODCode"]));
                        _VehicleDetailMdl.VehicleTypeName = GetVehicleTypeNameByCode(_tblSqla.Rows[i]["VehicleType"].ToString());

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


                        _VehicleDetailMdl.GenderName = GetGenderNameByCode(_tblSqla.Rows[i]["Gender"].ToString());
                        _VehicleDetailMdl.CityName = GetCityNameByCode(_tblSqla.Rows[i]["CityCode"].ToString());
                        _VehicleDetailMdl.ColorName = GetVehicleColorNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["ColorCode"].ToString()));
                        _VehicleDetailMdl.VehicleName = GetVehicleNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["VehicleCode"].ToString()));
                        _VehicleDetailMdl.AreaName = GetAreaNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["AreaCode"].ToString()));
                        _VehicleDetailMdl.CertTypeName = GetCertTypeByCode(_tblSqla.Rows[i]["CertTypeCode"].ToString());
                        _VehicleDetailMdl.InsuranceTypeName = GetInsuranceTypeNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]));

                        _VehicleDetailMdl.total = calculate(_VehicleDetailMdl);

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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //for adding new Motor Vehicle Certificates For Open Policy
        public VehicleDetailMdl AddVehicleDetail(VehicleDetailMdl _VehicleDetailMdl)
        {
            try

            {

                _VehicleDetailMdl.SerialNo = _VehicleDetailMdl.SerialNo == 0 ? _VehicleDetailMdl.SerialNo++ : _VehicleDetailMdl.SerialNo++;

                //if (IsDuplicateVehicleDetails(_VehicleDetailMdl) == true)
                //{
                //    List<TxnError> _txnErrors = new List<TxnError>();
                //    TxnError _txnError = new TxnError();
                //    _VehicleDetailMdl.IsValidTxn = false;
                //    _txnError.ErrorCode = "1001";
                //    _txnError.Error = "Duplicate Transaction";
                //    _txnError.TxnSysDate = DateTime.Now;

                //    _txnErrors.Add(_txnError);
                //    _txnErrors.Add(_txnError);

                //    //    //To Return model
                //    _VehicleDetailMdl.TxnErrors = _txnErrors;
                //    _VehicleDetailMdl.TxnSysDate = DateTime.Now;

                //    return _VehicleDetailMdl;

                //}

                ////if (IsUnique(_VehicleDetailMdl) == true)
                ////{
                ////    List<TxnError> _txnErrors = new List<TxnError>();
                ////    TxnError _txnError = new TxnError();
                ////    _VehicleDetailMdl.IsValidTxn = false;
                ////    _txnError.ErrorCode = "1005";
                ////    _txnError.Error = "Certificate for Given Open Policy is already exists";
                ////    _txnError.TxnSysDate = DateTime.Now;

                ////    _txnErrors.Add(_txnError);
                ////    _txnErrors.Add(_txnError);

                ////    //    //To Return model
                ////    _VehicleDetailMdl.TxnErrors = _txnErrors;
                ////    _VehicleDetailMdl.TxnSysDate = DateTime.Now;

                ////    return _VehicleDetailMdl;

                ////}

                //else
                //{


                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;
                    int _SerialNumber = GetSerialNo(_VehicleDetailMdl);


                    _sbSql.AppendLine("INSERT INTO MtrVehicleDetails(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql.AppendLine("TxnSysDate,");
                    _sbSql.AppendLine("UserCode,");
                    _sbSql.AppendLine("SerialNo,");
                    _sbSql.AppendLine("VehicleCode,");
                    _sbSql.AppendLine("VehicleModel,");
                    _sbSql.AppendLine("UpdatedValue,");
                    _sbSql.AppendLine("PreviousValue,");
                    _sbSql.AppendLine("Mileage,");
                    _sbSql.AppendLine("ParticipantValue,");
                    _sbSql.AppendLine("ColorCode,");
                    _sbSql.AppendLine("ParticipantName,");
                    _sbSql.AppendLine("ParticipantAddress,");
                    // _sbSql.AppendLine("ModelNumber,");
                    _sbSql.AppendLine("RegistrationNumber,");
                    _sbSql.AppendLine("CityCode,");
                    _sbSql.AppendLine("EngineNumber,");
                    _sbSql.AppendLine("AreaCode,");
                    _sbSql.AppendLine("ChasisNumber,");
                    _sbSql.AppendLine("Remarks,");
                    _sbSql.AppendLine("PODate,");
                    _sbSql.AppendLine("PONumber,");
                    _sbSql.AppendLine("CNICNumber,");
                    _sbSql.AppendLine("Tenure,");
                    _sbSql.AppendLine("BirthDate,");
                    _sbSql.AppendLine("Gender,");
                    _sbSql.AppendLine("VehicleType,");
                    _sbSql.AppendLine("VEODCode,");
                    _sbSql.AppendLine("CertTypeCode,");
                    _sbSql.AppendLine("Rate,");
                    _sbSql.AppendLine("ParentTxnSysID,");
                    _sbSql.AppendLine("OpolTxnSysID,");
                    _sbSql.AppendLine("InsuranceTypeCode,");
                    _sbSql.AppendLine("CommisionRate,");
                    _sbSql.AppendLine("MobileNumber,");
                    _sbSql.AppendLine("ResNumber,");
                    _sbSql.AppendLine("OfficeNumber,");
                    _sbSql.AppendLine("EmailAddress,");
                    _sbSql.AppendLine("Deductible,");
                    _sbSql.AppendLine("ContractMatDate,");
                    _sbSql.AppendLine("RatingFactor,");
                    _sbSql.AppendLine("Contribution)");


                    _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                    // _sbSql.AppendLine("@TxnSysID,");
                    _sbSql.AppendLine("@TxnSysDate,");
                    _sbSql.AppendLine("@UserCode,");
                    _sbSql.AppendLine("@SerialNo,");
                    _sbSql.AppendLine("@VehicleCode,");
                    _sbSql.AppendLine("@VehicleModel,");
                    _sbSql.AppendLine("@UpdatedValue,");
                    _sbSql.AppendLine("@PreviousValue,");
                    _sbSql.AppendLine("@Mileage,");
                    _sbSql.AppendLine("@ParticipantValue,");
                    _sbSql.AppendLine("@ColorCode,");
                    _sbSql.AppendLine("@ParticipantName,");
                    _sbSql.AppendLine("@ParticipantAddress,");
                    // _sbSql.AppendLine("@ModelNumber,");
                    _sbSql.AppendLine("@RegistrationNumber,");
                    _sbSql.AppendLine("@CityCode,");
                    _sbSql.AppendLine("@EngineNumber,");
                    _sbSql.AppendLine("@AreaCode,");
                    _sbSql.AppendLine("@ChasisNumber,");
                    _sbSql.AppendLine("@Remarks,");
                    _sbSql.AppendLine("@PODate,");
                    _sbSql.AppendLine("@PONumber,");
                    _sbSql.AppendLine("@CNICNumber,");
                    _sbSql.AppendLine("@Tenure,");
                    _sbSql.AppendLine("@BirthDate,");
                    _sbSql.AppendLine("@Gender,");
                    _sbSql.AppendLine("@VehicleType,");
                    _sbSql.AppendLine("@VEODCode,");
                    _sbSql.AppendLine("@CertTypeCode,");
                    _sbSql.AppendLine("@Rate,");
                    _sbSql.AppendLine("(SELECT MAX(ParentTxnSysID) FROM InsPolicy),");
                    _sbSql.AppendLine("(SELECT ip.OpolTxnSysID FROM InsPolicy ip WHERE ip.ParentTxnSysID = (SELECT MAX([ParentTxnSysID]) FROM InsPolicy)),");
                    _sbSql.AppendLine("@InsuranceTypeCode,");
                    _sbSql.AppendLine("@CommisionRate,");
                    _sbSql.AppendLine("@MobileNumber,");
                    _sbSql.AppendLine("@ResNumber,");
                    _sbSql.AppendLine("@OfficeNumber,");
                    _sbSql.AppendLine("@EmailAddress,");
                    _sbSql.AppendLine("@Deductible,");
                    _sbSql.AppendLine("@ContractMatDate,");
                    _sbSql.AppendLine("@RatingFactor,");
                    _sbSql.AppendLine("@Contribution)");


                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);




                    DateTime da = DateTime.Now;
                    da.ToString("MM-dd-yyyy h:mm tt");

                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", Convert.ToDateTime(da));
                    int _userCode = GlobalDataLayer.GetUserCodeById(_VehicleDetailMdl.UserCode);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);

                    _cmdSql.Parameters.AddWithValue("@SerialNo", _SerialNumber);
                    _cmdSql.Parameters.AddWithValue("@VehicleCode", _VehicleDetailMdl.VehicleCode);
                    _cmdSql.Parameters.AddWithValue("@VehicleModel", _VehicleDetailMdl.VehicleModel);
                    _cmdSql.Parameters.AddWithValue("@UpdatedValue", _VehicleDetailMdl.UpdatedValue);
                    _cmdSql.Parameters.AddWithValue("@PreviousValue", _VehicleDetailMdl.PreviousValue);
                    _cmdSql.Parameters.AddWithValue("@Mileage", _VehicleDetailMdl.Mileage);
                    _cmdSql.Parameters.AddWithValue("@ParticipantValue", _VehicleDetailMdl.ParticipantValue);
                    _cmdSql.Parameters.AddWithValue("@ColorCode", _VehicleDetailMdl.ColorCode);
                    _cmdSql.Parameters.AddWithValue("@ParticipantName", _VehicleDetailMdl.ParticipantName ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@ParticipantAddress", _VehicleDetailMdl.ParticipantAddress ?? DBNull.Value.ToString());
                    // _cmdSql.Parameters.AddWithValue("@ModelNumber", _VehicleDetailMdl.ModelNumber);
                    _cmdSql.Parameters.AddWithValue("@RegistrationNumber", _VehicleDetailMdl.RegistrationNumber ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@CityCode", _VehicleDetailMdl.CityCode ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@EngineNumber", (_VehicleDetailMdl.EngineNumber ?? DBNull.Value.ToString()));
                    _cmdSql.Parameters.AddWithValue("@AreaCode", _VehicleDetailMdl.AreaCode);
                    _cmdSql.Parameters.AddWithValue("@ChasisNumber", _VehicleDetailMdl.ChasisNumber ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@Remarks", _VehicleDetailMdl.Remarks ?? DBNull.Value.ToString());

                    if (_VehicleDetailMdl.PODate == null)
                    {
                        _cmdSql.Parameters.AddWithValue("@PODate", " ");
                    }
                    else
                    {
                        _cmdSql.Parameters.AddWithValue("@PODate", _VehicleDetailMdl.PODate);
                    }


                   // _cmdSql.Parameters.AddWithValue("@PODate", _VehicleDetailMdl.PODate);
                    _cmdSql.Parameters.AddWithValue("@PONumber", _VehicleDetailMdl.PONumber ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@CNICNumber", _VehicleDetailMdl.CNICNumber ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@Tenure", _VehicleDetailMdl.Tenure ?? DBNull.Value.ToString());


                    if (_VehicleDetailMdl.BirthDate == null)
                    {
                        _cmdSql.Parameters.AddWithValue("@BirthDate", " ");
                    }
                    else
                    {
                        _cmdSql.Parameters.AddWithValue("@BirthDate", _VehicleDetailMdl.BirthDate);
                    }

                   // _cmdSql.Parameters.AddWithValue("@BirthDate", _VehicleDetailMdl.BirthDate);
                    
                    _cmdSql.Parameters.AddWithValue("@Gender", _VehicleDetailMdl.Gender ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@VehicleType", _VehicleDetailMdl.VehicleType ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@VEODCode", _VehicleDetailMdl.VEODCode);
                    _cmdSql.Parameters.AddWithValue("@CertTypeCode", _VehicleDetailMdl.CertTypeCode ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@Rate", _VehicleDetailMdl.Rate);
                    _cmdSql.Parameters.AddWithValue("@InsuranceTypeCode", _VehicleDetailMdl.InsuranceTypeCode);
                    _cmdSql.Parameters.AddWithValue("@Contribution", _VehicleDetailMdl.Contribution);
                    _cmdSql.Parameters.AddWithValue("@CommisionRate", _VehicleDetailMdl.CommisionRate);
                    _cmdSql.Parameters.AddWithValue("@MobileNumber", _VehicleDetailMdl.MobileNumber ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@ResNumber", _VehicleDetailMdl.ResNumber ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@OfficeNumber", _VehicleDetailMdl.OfficeNumber ?? DBNull.Value.ToString());

                    _cmdSql.Parameters.AddWithValue("@EmailAddress", _VehicleDetailMdl.EmailAddress ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@Deductible", _VehicleDetailMdl.Deductible);

                    _cmdSql.Parameters.AddWithValue("@RatingFactor", _VehicleDetailMdl.RatingFactor ?? DBNull.Value.ToString());



                    //if (_VehicleDetailMdl.ContractMatDate == null)
                    //{
                    //    _cmdSql.Parameters.AddWithValue("@ContractMatDate", " ");
                    //}
                    //else
                    //{
                    //    _cmdSql.Parameters.AddWithValue("@ContractMatDate", _VehicleDetailMdl.ContractMatDate);
                    //}

                    _cmdSql.Parameters.AddWithValue("@ContractMatDate", Convert.ToDateTime("01/01/1900"));

                    _VehicleDetailMdl.SerialNo = _SerialNumber;

                    _VehicleDetailMdl.TxnSysDate = DateTime.Now;

                    _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_VehicleDetailMdl.RatingFactor);
                   _VehicleDetailMdl.VEODName = GetVEODNameByCode(_VehicleDetailMdl.VEODCode);
                    _VehicleDetailMdl.VehicleTypeName = GetVehicleTypeNameByCode(_VehicleDetailMdl.VehicleType);
                    _VehicleDetailMdl.GenderName = GetGenderNameByCode(_VehicleDetailMdl.Gender);
                    _VehicleDetailMdl.CityName = GetCityNameByCode(_VehicleDetailMdl.CityCode);
                    _VehicleDetailMdl.ColorName = GetVehicleColorNameByCode(_VehicleDetailMdl.ColorCode);
                    _VehicleDetailMdl.VehicleName = GetVehicleNameByCode(_VehicleDetailMdl.VehicleCode);
                    _VehicleDetailMdl.AreaName = GetAreaNameByCode(_VehicleDetailMdl.AreaCode);
                    _VehicleDetailMdl.CertTypeName = GetCertTypeByCode(_VehicleDetailMdl.CertTypeCode);
                    _VehicleDetailMdl.InsuranceTypeName = GetInsuranceTypeNameByCode(_VehicleDetailMdl.InsuranceTypeCode);


                    _VehicleDetailMdl.total = calculate(_VehicleDetailMdl);


                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();
                    _VehicleDetailMdl.IsValidTxn = true;

                    _VehicleDetailMdl.TxnSysID = _TxnSysId;
                    _VehicleDetailMdl.ParentTxnSysID = GetMaxParentTxnSysID();


                    //-------------- Insert In To Warranties and Conditions --------------//

                    // Get Product code From Max ParentTxnSysID of InsPolicy 
                    int ProductCode = 0;
                    SqlConnection _conSql1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    string _sqlString1 = "SELECT ProductCode FROM InsPolicy WHERE ParentTxnSysID = (SELECT MAX(ParentTxnSysID) FROM InsPolicy)";

                    SqlDataAdapter _adpSql1 = new SqlDataAdapter(_sqlString1, _conSql1);
                    DataTable _tblSqla1 = new DataTable();
                    MtrInsPolicyMdl _MtrInsPolicyMdl;

                    _adpSql1.Fill(_tblSqla1);

                    if (_tblSqla1.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla1.Rows.Count; i++)
                        {
                            _MtrInsPolicyMdl = new MtrInsPolicyMdl();

                            _MtrInsPolicyMdl.ProductCode = Convert.ToInt32(_tblSqla1.Rows[i]["ProductCode"]);
                            ProductCode = Convert.ToInt32(_tblSqla1.Rows[i]["ProductCode"]);
                        }


                    }
                    else
                    {

                    }

                    //Get Conditions By Product Code For Insertion in InsConditions 
                    SqlConnection _conSql2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());

                    DataTable _tblSqla2 = new DataTable();
                    List<ProductConditionsSetupMdl> _ProductConditionsSetupMdlList = new List<ProductConditionsSetupMdl>();
                    ProductConditionsSetupMdl _ProductConditionsSetupMdl;

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM MasterProductSetup mps INNER JOIN ProductConditionsProductSetup pts ON mps.TxnSysID = pts.PrdStpTxnSysId WHERE mps.ProductCode = @ProductCode", conn);

                        command.Parameters.Add(new SqlParameter("@ProductCode", ProductCode));

                        SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                        _adpSql.Fill(_tblSqla2);
                    }

                    //  _adpSql.Fill(_tblSqla);

                    if (_tblSqla2.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla2.Rows.Count; i++)
                        {
                            _ProductConditionsSetupMdl = new ProductConditionsSetupMdl();

                            //For Conditions
                            _ProductConditionsSetupMdl.Condition = _tblSqla2.Rows[i]["Condition"].ToString();
                            _ProductConditionsSetupMdl.ConditionShText = GlobalDataLayer.GetConditionByCode(_tblSqla2.Rows[i]["Condition"].ToString());



                            _ProductConditionsSetupMdlList.Add(_ProductConditionsSetupMdl);
                        }


                    

                    //Insert In To InsConditions
                    SqlConnection _conSql3 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql3 = new StringBuilder();
                    SqlCommand _cmdSql3;


                    ProductConditionsSetupMdl[] ConditionsArray = _ProductConditionsSetupMdlList.ToArray();

                    for (int j = 0; j < ConditionsArray.Length; j++)
                    {
                        _sbSql3 = new StringBuilder();

                        _sbSql3.AppendLine("INSERT INTO InsMtrConditions(");
                        _sbSql3.AppendLine("ParentTxnSysID,");
                        _sbSql3.AppendLine("Condition)");

                        _sbSql3.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                        _sbSql3.AppendLine("(SELECT MAX(ParentTxnSysID) FROM InsPolicy),");
                        _sbSql3.AppendLine("@Condition)");

                        _cmdSql3 = new SqlCommand(_sbSql3.ToString(), _conSql3);

                        _cmdSql3.Parameters.AddWithValue("@Condition", ConditionsArray[j].Condition.ToString());

                        int _TxnSysId1;
                        _conSql3.Open();
                        _TxnSysId1 = (Int32)_cmdSql3.ExecuteScalar();
                        _conSql3.Close();
                    }

                    }
                    else
                    {

                    }

                    //Get Warranties By Product Code For Insertion in Ins Warranties
                    SqlConnection _conSql4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());

                    DataTable _tblSqla4 = new DataTable();
                    List<ProductWarrantiesSetupMdl> _ProductWarrantiesSetupMdlList = new List<ProductWarrantiesSetupMdl>();
                    ProductWarrantiesSetupMdl _ProductWarrantiesSetupMdl;

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM MasterProductSetup mps INNER JOIN ProductWarrantiesProductSetup pts ON mps.TxnSysID = pts.PrdStpTxnSysId WHERE mps.ProductCode = @ProductCode", conn);

                        command.Parameters.Add(new SqlParameter("@ProductCode", ProductCode));

                        SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                        _adpSql.Fill(_tblSqla4);
                    }

                    //  _adpSql.Fill(_tblSqla);

                    if (_tblSqla4.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla4.Rows.Count; i++)
                        {
                            _ProductWarrantiesSetupMdl = new ProductWarrantiesSetupMdl();

                            //For Warranties
                            _ProductWarrantiesSetupMdl.Warranty = _tblSqla4.Rows[i]["Warranty"].ToString();
                            _ProductWarrantiesSetupMdl.WarrantyShText = GlobalDataLayer.GetWarrantyTextByCode(_tblSqla4.Rows[i]["Warranty"].ToString());

                            _ProductWarrantiesSetupMdlList.Add(_ProductWarrantiesSetupMdl);
                        }
                   
                    //Insert In To InsWarranties
                    SqlConnection _conSql5 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql5 = new StringBuilder();
                    SqlCommand _cmdSql5;



                    _cmdSql5 = new SqlCommand(_sbSql5.ToString(), _conSql5);

                    ProductWarrantiesSetupMdl[] WarrantyArray = _ProductWarrantiesSetupMdlList.ToArray();

                    for (int j = 0; j < WarrantyArray.Length; j++)
                    {
                        _sbSql5 = new StringBuilder();

                        _sbSql5.AppendLine("INSERT INTO InsMtrWarranties(");
                        _sbSql5.AppendLine("ParentTxnSysID,");
                        _sbSql5.AppendLine("Warranty)");

                        _sbSql5.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                        _sbSql5.AppendLine("(SELECT MAX(ParentTxnSysID) FROM InsPolicy),");
                        _sbSql5.AppendLine("@Warranty)");

                        _cmdSql5 = new SqlCommand(_sbSql5.ToString(), _conSql5);

                        _cmdSql5.Parameters.AddWithValue("@Warranty", WarrantyArray[j].Warranty.ToString());

                        int _TxnSysId3;
                        _conSql5.Open();
                        _TxnSysId3 = (Int32)_cmdSql5.ExecuteScalar();
                        _conSql5.Close();
                    }

                    }
                    else
                    {

                    }




                    //-------------- Insert In To Warranties and Conditions --------------//



                    return _VehicleDetailMdl;
               // }
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }

        }

        //for adding new Motor Vehicle Certificates For Policy
        public VehicleDetailMdl AddVehicleDetailForPol(VehicleDetailMdl _VehicleDetailMdl)
        {
            try

            {

                _VehicleDetailMdl.SerialNo = _VehicleDetailMdl.SerialNo == 0 ? _VehicleDetailMdl.SerialNo++ : _VehicleDetailMdl.SerialNo++;

                //if (IsDuplicateVehicleDetails(_VehicleDetailMdl) == true)
                //{
                //    List<TxnError> _txnErrors = new List<TxnError>();
                //    TxnError _txnError = new TxnError();
                //    _VehicleDetailMdl.IsValidTxn = false;
                //    _txnError.ErrorCode = "1001";
                //    _txnError.Error = "Duplicate Transaction";
                //    _txnError.TxnSysDate = DateTime.Now;

                //    _txnErrors.Add(_txnError);
                //    _txnErrors.Add(_txnError);

                //    //To Return model
                //    _VehicleDetailMdl.TxnErrors = _txnErrors;
                //    _VehicleDetailMdl.TxnSysDate = DateTime.Now;

                //    return _VehicleDetailMdl;

                //}

                //else if (IsUnique(_VehicleDetailMdl) == true)
                //{
                //    List<TxnError> _txnErrors = new List<TxnError>();
                //    TxnError _txnError = new TxnError();
                //    _VehicleDetailMdl.IsValidTxn = false;
                //    _txnError.ErrorCode = "1005";
                //    _txnError.Error = "Certificate for Given Open Policy is already exists";
                //    _txnError.TxnSysDate = DateTime.Now;

                //    _txnErrors.Add(_txnError);
                //    _txnErrors.Add(_txnError);

                //    //    //To Return model
                //    _VehicleDetailMdl.TxnErrors = _txnErrors;
                //    _VehicleDetailMdl.TxnSysDate = DateTime.Now;

                //    return _VehicleDetailMdl;

                //}

                //else
                //{


                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;
                    int _SerialNumber = GetSerialNo(_VehicleDetailMdl);


                    _sbSql.AppendLine("INSERT INTO MtrVehicleDetails(");
                    // _sbSql.AppendLine("TxnSysID,");
                    _sbSql.AppendLine("TxnSysDate,");
                    _sbSql.AppendLine("UserCode,");
                    _sbSql.AppendLine("RatingFactor,");
                    _sbSql.AppendLine("SerialNo,");
                    _sbSql.AppendLine("VehicleCode,");
                    _sbSql.AppendLine("VehicleModel,");
                    _sbSql.AppendLine("UpdatedValue,");
                    _sbSql.AppendLine("PreviousValue,");
                    _sbSql.AppendLine("Mileage,");
                    _sbSql.AppendLine("ParticipantValue,");
                    _sbSql.AppendLine("ColorCode,");
                    _sbSql.AppendLine("ParticipantName,");
                    _sbSql.AppendLine("ParticipantAddress,");
                    // _sbSql.AppendLine("ModelNumber,");
                    _sbSql.AppendLine("RegistrationNumber,");
                    _sbSql.AppendLine("CityCode,");
                    _sbSql.AppendLine("EngineNumber,");
                    _sbSql.AppendLine("AreaCode,");
                    _sbSql.AppendLine("ChasisNumber,");
                    _sbSql.AppendLine("Remarks,");
                   _sbSql.AppendLine("PODate,");
                    _sbSql.AppendLine("PONumber,");
                    _sbSql.AppendLine("CNICNumber,");
                    _sbSql.AppendLine("Tenure,");
                    _sbSql.AppendLine("BirthDate,");
                    _sbSql.AppendLine("Gender,");
                    _sbSql.AppendLine("VehicleType,");
                    _sbSql.AppendLine("VEODCode,");
                    _sbSql.AppendLine("CertTypeCode,");
                    _sbSql.AppendLine("Rate,");
                    _sbSql.AppendLine("ParentTxnSysID,");
                    _sbSql.AppendLine("OpolTxnSysID,");
                    _sbSql.AppendLine("InsuranceTypeCode,");
                    _sbSql.AppendLine("CommisionRate,");
                    _sbSql.AppendLine("MobileNumber,");
                    _sbSql.AppendLine("ResNumber,");
                    _sbSql.AppendLine("OfficeNumber,");
                    _sbSql.AppendLine("EmailAddress,");
                    _sbSql.AppendLine("Deductible,");
                    _sbSql.AppendLine("ContractMatDate,");
                    _sbSql.AppendLine("Contribution)");


                    _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                    // _sbSql.AppendLine("@TxnSysID,");
                    _sbSql.AppendLine("@TxnSysDate,");
                    _sbSql.AppendLine("@UserCode,");
                    _sbSql.AppendLine("@RatingFactor,");
                    _sbSql.AppendLine("@SerialNo,");
                    _sbSql.AppendLine("@VehicleCode,");
                    _sbSql.AppendLine("@VehicleModel,");
                    _sbSql.AppendLine("@UpdatedValue,");
                    _sbSql.AppendLine("@PreviousValue,");
                    _sbSql.AppendLine("@Mileage,");
                    _sbSql.AppendLine("@ParticipantValue,");
                    _sbSql.AppendLine("@ColorCode,");
                    _sbSql.AppendLine("@ParticipantName,");
                    _sbSql.AppendLine("@ParticipantAddress,");
                    // _sbSql.AppendLine("@ModelNumber,");
                    _sbSql.AppendLine("@RegistrationNumber,");
                    _sbSql.AppendLine("@CityCode,");
                    _sbSql.AppendLine("@EngineNumber,");
                    _sbSql.AppendLine("@AreaCode,");
                    _sbSql.AppendLine("@ChasisNumber,");
                    _sbSql.AppendLine("@Remarks,");
                   _sbSql.AppendLine("@PODate,");
                    _sbSql.AppendLine("@PONumber,");
                    _sbSql.AppendLine("@CNICNumber,");
                    _sbSql.AppendLine("@Tenure,");
                    _sbSql.AppendLine("@BirthDate,");
                    _sbSql.AppendLine("@Gender,");
                    _sbSql.AppendLine("@VehicleType,");
                    _sbSql.AppendLine("@VEODCode,");
                    _sbSql.AppendLine("@CertTypeCode,");
                    _sbSql.AppendLine("@Rate,");
                    _sbSql.AppendLine("(SELECT MAX(ParentTxnSysID) FROM InsPolicy),");
                    _sbSql.AppendLine("-1,");
                    _sbSql.AppendLine("@InsuranceTypeCode,");
                    _sbSql.AppendLine("@CommisionRate,");
                    _sbSql.AppendLine("@MobileNumber,");
                    _sbSql.AppendLine("@ResNumber,");
                    _sbSql.AppendLine("@OfficeNumber,");
                    _sbSql.AppendLine("@EmailAddress,");
                    _sbSql.AppendLine("@Deductible,");
                    _sbSql.AppendLine("-1,");
                    _sbSql.AppendLine("@Contribution)");


                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);




                    DateTime da = DateTime.Now;
                    da.ToString("MM-dd-yyyy h:mm tt");

                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", Convert.ToDateTime(da));
                    int _userCode = GlobalDataLayer.GetUserCodeById(_VehicleDetailMdl.UserCode);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);

                    _cmdSql.Parameters.AddWithValue("@SerialNo", _SerialNumber);
                    _cmdSql.Parameters.AddWithValue("@VehicleCode", _VehicleDetailMdl.VehicleCode);
                    _cmdSql.Parameters.AddWithValue("@VehicleModel", _VehicleDetailMdl.VehicleModel);
                    _cmdSql.Parameters.AddWithValue("@UpdatedValue", _VehicleDetailMdl.UpdatedValue);
                    _cmdSql.Parameters.AddWithValue("@PreviousValue", _VehicleDetailMdl.PreviousValue);
                    _cmdSql.Parameters.AddWithValue("@Mileage", _VehicleDetailMdl.Mileage);
                    _cmdSql.Parameters.AddWithValue("@ParticipantValue", _VehicleDetailMdl.ParticipantValue);
                    _cmdSql.Parameters.AddWithValue("@ColorCode", _VehicleDetailMdl.ColorCode);
                    _cmdSql.Parameters.AddWithValue("@ParticipantName", _VehicleDetailMdl.ParticipantName);
                    _cmdSql.Parameters.AddWithValue("@ParticipantAddress", _VehicleDetailMdl.ParticipantAddress);
                    // _cmdSql.Parameters.AddWithValue("@ModelNumber", _VehicleDetailMdl.ModelNumber);
                    _cmdSql.Parameters.AddWithValue("@RegistrationNumber", _VehicleDetailMdl.RegistrationNumber);
                    _cmdSql.Parameters.AddWithValue("@CityCode", _VehicleDetailMdl.CityCode ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@EngineNumber", _VehicleDetailMdl.EngineNumber);
                    _cmdSql.Parameters.AddWithValue("@AreaCode", _VehicleDetailMdl.AreaCode);
                    _cmdSql.Parameters.AddWithValue("@ChasisNumber", _VehicleDetailMdl.ChasisNumber);
                    _cmdSql.Parameters.AddWithValue("@Remarks", _VehicleDetailMdl.Remarks ?? DBNull.Value.ToString());


                   // _cmdSql.Parameters.AddWithValue("@PODate", !(_VehicleDetailMdl.PODate == Convert.ToDateTime("01-01-1900")) ? _VehicleDetailMdl.PODate : Convert.ToDateTime(SqlDbType.DateTime));
                    _cmdSql.Parameters.AddWithValue("@PONumber", _VehicleDetailMdl.PONumber ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@CNICNumber", _VehicleDetailMdl.CNICNumber);
                    _cmdSql.Parameters.AddWithValue("@Tenure", _VehicleDetailMdl.Tenure ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@RatingFactor", _VehicleDetailMdl.RatingFactor ?? DBNull.Value.ToString());



                    var myDate = "1900-01-01";


                    CultureInfo enUS = new CultureInfo("en-US");

                    DateTime _myDate =  DateTime.ParseExact(myDate.Replace("-", "/"), "yyyy/MM/dd", enUS.DateTimeFormat, DateTimeStyles.AllowInnerWhite);
                    // DateTime date = DateTime.Parse(myDate);
                    //DateTime _myDate;

                    //_myDate = myDate.ToDate

                    //_cmdSql.Parameters.AddWithValue("@BirthDate", !(_VehicleDetailMdl.BirthDate == _myDate) ? _VehicleDetailMdl.BirthDate : (null));

                    if(_VehicleDetailMdl.BirthDate == null)
                    {
                        _cmdSql.Parameters.AddWithValue("@BirthDate", " ");
                    }
                    else
                    {
                        _cmdSql.Parameters.AddWithValue("@BirthDate", _VehicleDetailMdl.BirthDate);
                    }

                    //_cmdSql.Parameters.AddWithValue("@BirthDate", _VehicleDetailMdl.BirthDate);


                    if (_VehicleDetailMdl.PODate == null)
                    {
                        _cmdSql.Parameters.AddWithValue("@PODate", " ");
                    }
                    else
                    {
                        _cmdSql.Parameters.AddWithValue("@PODate", _VehicleDetailMdl.PODate);
                    }



                    // _cmdSql.Parameters.AddWithValue("@PODate", !(_VehicleDetailMdl.PODate == date) ? _VehicleDetailMdl.PODate : Convert.ToDateTime(SqlDbType.DateTime));
                    _cmdSql.Parameters.AddWithValue("@Gender", _VehicleDetailMdl.Gender ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@VehicleType", _VehicleDetailMdl.VehicleType ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@VEODCode", _VehicleDetailMdl.VEODCode);
                    _cmdSql.Parameters.AddWithValue("@CertTypeCode", _VehicleDetailMdl.CertTypeCode ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@Rate", _VehicleDetailMdl.Rate);
                    _cmdSql.Parameters.AddWithValue("@InsuranceTypeCode", _VehicleDetailMdl.InsuranceTypeCode);
                    _cmdSql.Parameters.AddWithValue("@Contribution", _VehicleDetailMdl.Contribution);
                    _cmdSql.Parameters.AddWithValue("@CommisionRate", _VehicleDetailMdl.CommisionRate);
                    _cmdSql.Parameters.AddWithValue("@MobileNumber", _VehicleDetailMdl.MobileNumber ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@ResNumber", _VehicleDetailMdl.ResNumber ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@OfficeNumber", _VehicleDetailMdl.OfficeNumber ?? DBNull.Value.ToString());

                    _cmdSql.Parameters.AddWithValue("@EmailAddress", _VehicleDetailMdl.EmailAddress ?? DBNull.Value.ToString());
                    _cmdSql.Parameters.AddWithValue("@Deductible", _VehicleDetailMdl.Deductible);
                    // _cmdSql.Parameters.AddWithValue("@ContractMatDate", _VehicleDetailMdl.ContractMatDate);

                    _VehicleDetailMdl.SerialNo = _SerialNumber;

                    _VehicleDetailMdl.TxnSysDate = DateTime.Now;


                    //_cmdSql.Parameters.AddWithValue("@PODate", !(_VehicleDetailMdl.PODate == date) ? _VehicleDetailMdl.PODate : Convert.ToDateTime(SqlDbType.DateTime));

                    _VehicleDetailMdl.VEODName = GetVEODNameByCode(_VehicleDetailMdl.VEODCode);
                    _VehicleDetailMdl.VehicleTypeName = GetVehicleTypeNameByCode(_VehicleDetailMdl.VehicleType);
                    _VehicleDetailMdl.GenderName = GetGenderNameByCode(_VehicleDetailMdl.Gender);
                    _VehicleDetailMdl.CityName = GetCityNameByCode(_VehicleDetailMdl.CityCode);
                    _VehicleDetailMdl.ColorName = GetVehicleColorNameByCode(_VehicleDetailMdl.ColorCode);
                    _VehicleDetailMdl.VehicleName = GetVehicleNameByCode(_VehicleDetailMdl.VehicleCode);
                    _VehicleDetailMdl.AreaName = GetAreaNameByCode(_VehicleDetailMdl.AreaCode);
                    _VehicleDetailMdl.CertTypeName = GetCertTypeByCode(_VehicleDetailMdl.CertTypeCode);
                    _VehicleDetailMdl.InsuranceTypeName = GetInsuranceTypeNameByCode(_VehicleDetailMdl.InsuranceTypeCode);
                    _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_VehicleDetailMdl.RatingFactor);

                   _VehicleDetailMdl.total = calculate(_VehicleDetailMdl);

                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();
                    _VehicleDetailMdl.IsValidTxn = true;

                    _VehicleDetailMdl.TxnSysID = _TxnSysId;
                    _VehicleDetailMdl.ParentTxnSysID = GetMaxParentTxnSysID();

                    //-------------- Insert In To Warranties and Conditions --------------//

                    // Get Product code From Max ParentTxnSysID of InsPolicy 
                    int ProductCode = 0;
                    SqlConnection _conSql1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    string _sqlString1 = "SELECT ProductCode FROM InsPolicy WHERE ParentTxnSysID = (SELECT MAX(ParentTxnSysID) FROM InsPolicy)";

                    SqlDataAdapter _adpSql1 = new SqlDataAdapter(_sqlString1, _conSql1);
                    DataTable _tblSqla1 = new DataTable();
                    MtrInsPolicyMdl _MtrInsPolicyMdl;

                    _adpSql1.Fill(_tblSqla1);

                    if (_tblSqla1.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla1.Rows.Count; i++)
                        {
                            _MtrInsPolicyMdl = new MtrInsPolicyMdl();

                            _MtrInsPolicyMdl.ProductCode = Convert.ToInt32(_tblSqla1.Rows[i]["ProductCode"]);
                            ProductCode = Convert.ToInt32(_tblSqla1.Rows[i]["ProductCode"]);
                        }


                    }
                    else
                    {

                    }

                    //Get Conditions By Product Code For Insertion in InsConditions 
                    SqlConnection _conSql2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());

                    DataTable _tblSqla2 = new DataTable();
                    List<ProductConditionsSetupMdl> _ProductConditionsSetupMdlList = new List<ProductConditionsSetupMdl>();
                    ProductConditionsSetupMdl _ProductConditionsSetupMdl;

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM MasterProductSetup mps INNER JOIN ProductConditionsProductSetup pts ON mps.TxnSysID = pts.PrdStpTxnSysId WHERE mps.ProductCode = @ProductCode", conn);

                        command.Parameters.Add(new SqlParameter("@ProductCode", ProductCode));

                        SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                        _adpSql.Fill(_tblSqla2);
                    }

                    //  _adpSql.Fill(_tblSqla);

                    if (_tblSqla2.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla2.Rows.Count; i++)
                        {
                            _ProductConditionsSetupMdl = new ProductConditionsSetupMdl();

                            //For Conditions
                            _ProductConditionsSetupMdl.Condition = _tblSqla2.Rows[i]["Condition"].ToString();
                            _ProductConditionsSetupMdl.ConditionShText = GlobalDataLayer.GetConditionByCode(_tblSqla2.Rows[i]["Condition"].ToString());



                            _ProductConditionsSetupMdlList.Add(_ProductConditionsSetupMdl);
                        }


                    

                    //Insert In To InsConditions
                    SqlConnection _conSql3 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql3 = new StringBuilder();
                    SqlCommand _cmdSql3;


                    ProductConditionsSetupMdl[] ConditionsArray = _ProductConditionsSetupMdlList.ToArray();

                    for (int j = 0; j < ConditionsArray.Length; j++)
                    {
                        _sbSql3 = new StringBuilder();

                        _sbSql3.AppendLine("INSERT INTO InsMtrConditions(");
                        _sbSql3.AppendLine("ParentTxnSysID,");
                        _sbSql3.AppendLine("Condition)");

                        _sbSql3.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                        _sbSql3.AppendLine("(SELECT MAX(ParentTxnSysID) FROM InsPolicy),");
                        _sbSql3.AppendLine("@Condition)");

                        _cmdSql3 = new SqlCommand(_sbSql3.ToString(), _conSql3);

                        _cmdSql3.Parameters.AddWithValue("@Condition", ConditionsArray[j].Condition.ToString());

                        int _TxnSysId1;
                        _conSql3.Open();
                        _TxnSysId1 = (Int32)_cmdSql3.ExecuteScalar();
                        _conSql3.Close();
                    }

                    }
                    else
                    {

                    }

                    //Get Warranties By Product Code For Insertion in Ins Warranties
                    SqlConnection _conSql4 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());

                    DataTable _tblSqla4 = new DataTable();
                    List<ProductWarrantiesSetupMdl> _ProductWarrantiesSetupMdlList = new List<ProductWarrantiesSetupMdl>();
                    ProductWarrantiesSetupMdl _ProductWarrantiesSetupMdl;

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT * FROM MasterProductSetup mps INNER JOIN ProductWarrantiesProductSetup pts ON mps.TxnSysID = pts.PrdStpTxnSysId WHERE mps.ProductCode = @ProductCode", conn);

                        command.Parameters.Add(new SqlParameter("@ProductCode", ProductCode));

                        SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                        _adpSql.Fill(_tblSqla4);
                    }

                    //  _adpSql.Fill(_tblSqla);

                    if (_tblSqla4.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla4.Rows.Count; i++)
                        {
                            _ProductWarrantiesSetupMdl = new ProductWarrantiesSetupMdl();

                            //For Warranties
                            _ProductWarrantiesSetupMdl.Warranty = _tblSqla4.Rows[i]["Warranty"].ToString();
                            _ProductWarrantiesSetupMdl.WarrantyShText = GlobalDataLayer.GetWarrantyTextByCode(_tblSqla4.Rows[i]["Warranty"].ToString());

                            _ProductWarrantiesSetupMdlList.Add(_ProductWarrantiesSetupMdl);
                        }


                   
                    //Insert In To InsWarranties
                    SqlConnection _conSql5 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql5 = new StringBuilder();
                    SqlCommand _cmdSql5;



                    _cmdSql5 = new SqlCommand(_sbSql5.ToString(), _conSql5);

                    ProductWarrantiesSetupMdl[] WarrantyArray = _ProductWarrantiesSetupMdlList.ToArray();

                    for (int j = 0; j < WarrantyArray.Length; j++)
                    {
                        _sbSql5 = new StringBuilder();

                        _sbSql5.AppendLine("INSERT INTO InsMtrWarranties(");
                        _sbSql5.AppendLine("ParentTxnSysID,");
                        _sbSql5.AppendLine("Warranty)");

                        _sbSql5.AppendLine("output INSERTED. TxnSysID VALUES ( ");
                        _sbSql5.AppendLine("(SELECT MAX(ParentTxnSysID) FROM InsPolicy),");
                        _sbSql5.AppendLine("@Warranty)");

                        _cmdSql5 = new SqlCommand(_sbSql5.ToString(), _conSql5);

                        _cmdSql5.Parameters.AddWithValue("@Warranty", WarrantyArray[j].Warranty.ToString());

                        int _TxnSysId3;
                        _conSql5.Open();
                        _TxnSysId3 = (Int32)_cmdSql5.ExecuteScalar();
                        _conSql5.Close();
                    }

                    }
                    else
                    {

                    }


                    //-------------- Insert In To Warranties and Conditions --------------//


                    return _VehicleDetailMdl;
               // }
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }

        }

        //for updating existing Motor Vehicle Certificates For OpenPolicy And Policy
        public VehicleDetailMdl UpdateVehicleDetail(VehicleDetailMdl _VehicleDetailMdl)
        {
            try
            {

                _VehicleDetailMdl.SerialNo = _VehicleDetailMdl.SerialNo == 0 ? _VehicleDetailMdl.SerialNo += 1 : _VehicleDetailMdl.SerialNo;


                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();
                SqlCommand _cmdSql;
                VehicleDetailMdl _VehicleDetailMdlA = new VehicleDetailMdl();

                _sbSql.AppendLine("Update  MtrVehicleDetails SET");
                _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
                // _sbSql.AppendLine("UserCode= @UserCode,");
                _sbSql.AppendLine("VehicleCode= @VehicleCode,");
                _sbSql.AppendLine("VehicleModel= @VehicleModel,");
                _sbSql.AppendLine("UpdatedValue= @UpdatedValue,");
                _sbSql.AppendLine("PreviousValue = @PreviousValue,");
                _sbSql.AppendLine("Mileage= @Mileage,");
                _sbSql.AppendLine("ParticipantValue= @ParticipantValue,");
                _sbSql.AppendLine("ColorCode= @ColorCode,");
                _sbSql.AppendLine("ParticipantName= @ParticipantName,");
                _sbSql.AppendLine("ParticipantAddress= @ParticipantAddress,");
                //  _sbSql.AppendLine("ModelNumber= @ModelNumber,");

                _sbSql.AppendLine("RegistrationNumber= @RegistrationNumber,");
                _sbSql.AppendLine("CityCode= @CityCode,");

                _sbSql.AppendLine("EngineNumber= @EngineNumber,");
                _sbSql.AppendLine("AreaCode= @AreaCode,");
                _sbSql.AppendLine("ChasisNumber= @ChasisNumber,");
                _sbSql.AppendLine("Remarks= @Remarks,");
                _sbSql.AppendLine("PODate= @PODate,");

                _sbSql.AppendLine("PONumber = @PONumber,");
                _sbSql.AppendLine("CNICNumber = @CNICNumber,");
                _sbSql.AppendLine("Tenure= @Tenure,");
                _sbSql.AppendLine("BirthDate= @BirthDate,");
                _sbSql.AppendLine("RatingFactor= @RatingFactor,");
                _sbSql.AppendLine("Gender= @Gender,");
                _sbSql.AppendLine("VehicleType= @VehicleType,");
                _sbSql.AppendLine("VEODCode= @VEODCode,");
                _sbSql.AppendLine("CertTypeCode= @CertTypeCode,");
                _sbSql.AppendLine("Rate= @Rate,");
                _sbSql.AppendLine("InsuranceTypeCode= @InsuranceTypeCode,");
                _sbSql.AppendLine("CommisionRate= @CommisionRate,");
                _sbSql.AppendLine("Contribution= @Contribution");


                _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");

                _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);




                _cmdSql.Parameters.AddWithValue("@TxnSysID", _VehicleDetailMdl.TxnSysID);


                DateTime da = DateTime.Now;
                da.ToString("MM-dd-yyyy h:mm tt");


                _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);

                int _SerialNumber = GetSerialNo(_VehicleDetailMdl);

                _cmdSql.Parameters.AddWithValue("@VehicleCode", _VehicleDetailMdl.VehicleCode);
                _cmdSql.Parameters.AddWithValue("@VehicleModel", _VehicleDetailMdl.VehicleModel);
                _cmdSql.Parameters.AddWithValue("@UpdatedValue", _VehicleDetailMdl.UpdatedValue);
                _cmdSql.Parameters.AddWithValue("@PreviousValue", _VehicleDetailMdl.PreviousValue);
                _cmdSql.Parameters.AddWithValue("@Mileage", _VehicleDetailMdl.Mileage);
                _cmdSql.Parameters.AddWithValue("@ParticipantValue", _VehicleDetailMdl.ParticipantValue);
                _cmdSql.Parameters.AddWithValue("@ColorCode", _VehicleDetailMdl.ColorCode);
                _cmdSql.Parameters.AddWithValue("@ParticipantName", _VehicleDetailMdl.ParticipantName);
                _cmdSql.Parameters.AddWithValue("@ParticipantAddress", _VehicleDetailMdl.ParticipantAddress);
                // _cmdSql.Parameters.AddWithValue("@ModelNumber", _VehicleDetailMdl.ModelNumber);
                _cmdSql.Parameters.AddWithValue("@RegistrationNumber", _VehicleDetailMdl.RegistrationNumber);
                _cmdSql.Parameters.AddWithValue("@CityCode", _VehicleDetailMdl.CityCode ?? DBNull.Value.ToString());
                _cmdSql.Parameters.AddWithValue("@EngineNumber", _VehicleDetailMdl.EngineNumber ?? DBNull.Value.ToString());
                _cmdSql.Parameters.AddWithValue("@AreaCode", _VehicleDetailMdl.AreaCode);
                _cmdSql.Parameters.AddWithValue("@ChasisNumber", _VehicleDetailMdl.ChasisNumber ?? DBNull.Value.ToString());
                _cmdSql.Parameters.AddWithValue("@Remarks", _VehicleDetailMdl.Remarks ?? DBNull.Value.ToString());
                _cmdSql.Parameters.AddWithValue("@PODate", _VehicleDetailMdl.PODate);
                _cmdSql.Parameters.AddWithValue("@PONumber", _VehicleDetailMdl.PONumber ?? DBNull.Value.ToString());
                _cmdSql.Parameters.AddWithValue("@CNICNumber", _VehicleDetailMdl.CNICNumber ?? DBNull.Value.ToString());
                _cmdSql.Parameters.AddWithValue("@Tenure", _VehicleDetailMdl.Tenure);
                _cmdSql.Parameters.AddWithValue("@BirthDate", _VehicleDetailMdl.BirthDate);
                _cmdSql.Parameters.AddWithValue("@Gender", _VehicleDetailMdl.Gender ?? DBNull.Value.ToString());
                _cmdSql.Parameters.AddWithValue("@VehicleType", _VehicleDetailMdl.VehicleType);
                _cmdSql.Parameters.AddWithValue("@VEODCode", _VehicleDetailMdl.VEODCode);
                _cmdSql.Parameters.AddWithValue("@CertTypeCode", _VehicleDetailMdl.CertTypeCode);
                _cmdSql.Parameters.AddWithValue("@Rate", _VehicleDetailMdl.Rate);
                _cmdSql.Parameters.AddWithValue("@InsuranceTypeCode", _VehicleDetailMdl.InsuranceTypeCode);
                _cmdSql.Parameters.AddWithValue("@Contribution", _VehicleDetailMdl.Contribution);
                _cmdSql.Parameters.AddWithValue("@CommisionRate", _VehicleDetailMdl.CommisionRate);

                _cmdSql.Parameters.AddWithValue("@RatingFactor", _VehicleDetailMdl.RatingFactor);


                _VehicleDetailMdl.IsValidTxn = true;

                _VehicleDetailMdl.TxnSysDate = DateTime.Now;
                _VehicleDetailMdl.SerialNo = _SerialNumber;
                _VehicleDetailMdl.VEODName = GetVEODNameByCode(_VehicleDetailMdl.VEODCode);
                _VehicleDetailMdl.VehicleTypeName = GetVehicleTypeNameByCode(_VehicleDetailMdl.VehicleType);
                _VehicleDetailMdl.GenderName = GetGenderNameByCode(_VehicleDetailMdl.Gender);
                _VehicleDetailMdl.CityName = GetCityNameByCode(_VehicleDetailMdl.CityCode);
                _VehicleDetailMdl.ColorName = GetVehicleColorNameByCode(_VehicleDetailMdl.ColorCode);
                _VehicleDetailMdl.VehicleName = GetVehicleNameByCode(_VehicleDetailMdl.VehicleCode);
                _VehicleDetailMdl.AreaName = GetAreaNameByCode(_VehicleDetailMdl.AreaCode);
                _VehicleDetailMdl.CertTypeName = GetCertTypeByCode(_VehicleDetailMdl.CertTypeCode);
                _VehicleDetailMdl.InsuranceTypeName = GetInsuranceTypeNameByCode(_VehicleDetailMdl.InsuranceTypeCode);
                _VehicleDetailMdl.RatingFactorShText = GlobalDataLayer.GetRaitingFactorByCode(_VehicleDetailMdl.RatingFactor);

                _VehicleDetailMdl.total = calculate(_VehicleDetailMdl);

                _conSql.Open();
                _cmdSql.ExecuteNonQuery();
                _conSql.Close();

                //To get ParentTxnSysId after updation of vehicle
                SqlConnection _conSqlA = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlStringA = "SELECT ParentTxnSysID FROM MtrVehicleDetails mvd WHERE  mvd.TxnSysID = " + _VehicleDetailMdl.TxnSysID;
               
                SqlDataAdapter _adpSqlA = new SqlDataAdapter(_sqlStringA, _conSqlA);
                DataTable _tblSqlaA = new DataTable();
                List<VehicleDetailMdl> _VehicleDetailMdlListA = new List<VehicleDetailMdl>();
                

                _adpSqlA.Fill(_tblSqlaA);

                if (_tblSqlaA.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqlaA.Rows.Count; i++)
                    {
                        _VehicleDetailMdlA = new VehicleDetailMdl();

                        _VehicleDetailMdlA.ParentTxnSysID = Convert.ToInt32(_tblSqlaA.Rows[i]["ParentTxnSysID"]);



                      //  _VehicleDetailMdlA.total = calculate(_VehicleDetailMdlA);


                        _VehicleDetailMdlListA.Add(_VehicleDetailMdlA);


                    }

                   
                }
                else
                {
                    
                }

                _VehicleDetailMdl.ParentTxnSysID = _VehicleDetailMdlA.ParentTxnSysID;

                return _VehicleDetailMdl;
                //}
                // }

                //else if (IsDuplicateVehicleDetails(_VehicleDetailMdl) == true)
                //{

                //    List<TxnError> _txnErrors = new List<TxnError>();
                //    TxnError _txnError = new TxnError();
                //   _VehicleDetailMdl.IsValidTxn = false;
                //    _txnError.ErrorCode = "1002";
                //   _txnError.Error = "Active Transaction";
                //   _txnError.TxnSysDate = DateTime.Now;


                //    List<TxnError> _txnErrors2 = new List<TxnError>();
                //    TxnError _txnError2 = new TxnError();

                //          _txnError2.ErrorCode = "1001";
                //    _txnError2.Error = "Duplicate  Transaction";
                //    _txnError2.TxnSysDate = DateTime.Now;

                //    _txnErrors.Add(_txnError);
                //    _txnErrors.Add(_txnError2);

                //    //    //To Return model
                //    _VehicleDetailMdl.TxnErrors = _txnErrors;



                //    _VehicleDetailMdl.TxnSysDate = DateTime.Now;

                //    return _VehicleDetailMdl;
                //}

                //    else if (IsUnique(_VehicleDetailMdl) == true)
                //{
                //    List<TxnError> _txnErrors = new List<TxnError>();
                //    TxnError _txnError = new TxnError();
                //    _VehicleDetailMdl.IsValidTxn = false;
                //    _txnError.ErrorCode = "1005";
                //    _txnError.Error = "Certificate for Given Open Policy is already exists";
                //    _txnError.TxnSysDate = DateTime.Now;

                //    _txnErrors.Add(_txnError);
                //    _txnErrors.Add(_txnError);

                //    //    //To Return model
                //    _VehicleDetailMdl.TxnErrors = _txnErrors;
                //    _VehicleDetailMdl.TxnSysDate = DateTime.Now;

                //    return _VehicleDetailMdl;

                //}

                // else
                //{
                    //      return null;
                    //  }

              //  }
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }
     
        //For cancelling Motor Vehicle Certificates
        public VehicleDetailMdl CancelVehicleDetail(VehicleDetailMdl _VehicleDetailMdl)
        {
            try
            {

              

                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;


                    _sbSql.AppendLine("Update  MtrVehicleDetails SET");
            
                _sbSql.AppendLine("IsActive= @IsActive,");

                _sbSql.AppendLine("IsCanceled= @IsCanceled");

                _sbSql.AppendLine("WHERE TxnSysID = @TxnSysID ");

                _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);



                _cmdSql.Parameters.AddWithValue("@TxnSysID", _VehicleDetailMdl.TxnSysID);


                _VehicleDetailMdl.IsActive = false;
                _VehicleDetailMdl.IsCanceled = true;


                _cmdSql.Parameters.AddWithValue("@IsActive", false);
                _cmdSql.Parameters.AddWithValue("@IsCanceled", true);




                _VehicleDetailMdl.IsValidTxn = true;




                _conSql.Open();
                _cmdSql.ExecuteNonQuery();
                _conSql.Close();

               

                return _VehicleDetailMdl;

                

                

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Calculate Contribution for Vehicle Open Policy
        public List<MtrVContributionMdl> CalcContribution(VehicleDetailMdl _VehicleDetailMdl)
        {


            decimal _SumCovered = _VehicleDetailMdl.ParticipantValue;
            decimal _Rate = _VehicleDetailMdl.Rate;

            decimal FED = 0, FIF = 0;
            int BranchCode = 0, OpolTxnSysID = 0;


            MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
            List<MtrVContributionMdl> _MtrVContributionMdlList = new List<MtrVContributionMdl>();

            //Get OPolTxnSysID
            
            DataTable _tbl3 = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
            {
                SqlCommand command =
                    new SqlCommand("SELECT mvd.OpolTxnSysID FROM MtrVehicleDetails mvd WHERE mvd.TxnSysID = @TxnSysID", conn);

                command.Parameters.Add(new SqlParameter("@TxnSysID", _VehicleDetailMdl.TxnSysID));

                SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                _adpSql.Fill(_tbl3);
            }

            // _adpSql.Fill(_tbl);

            if (_tbl3.Rows.Count > 0)
            {
                for (int i = 0; i < _tbl3.Rows.Count; i++)
                {
                    _MtrVContributionMdl = new MtrVContributionMdl();
                    _MtrVContributionMdl.OpolTxnSysID = Convert.ToInt32(_tbl3.Rows[i]["OpolTxnSysID"]);
                    
                    OpolTxnSysID = _MtrVContributionMdl.OpolTxnSysID;

                }


            }
            else
            {
                _MtrVContributionMdl.OpolTxnSysID = 0;
            }

            //Get Branch Code
            DataTable _tbl1 = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
            {
                SqlCommand command =
                    new SqlCommand("SELECT ip.BrchCoverNoteNo BranchCode FROM InsPolicy ip INNER JOIN MtrVehicleDetails mvd ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE mvd.TxnSysID = @TxnSysID", conn);

                command.Parameters.Add(new SqlParameter("@TxnSysID", _VehicleDetailMdl.TxnSysID));

                SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                _adpSql.Fill(_tbl1);
            }

            // _adpSql.Fill(_tbl);

            if (_tbl1.Rows.Count > 0)
            {
                for (int i = 0; i < _tbl1.Rows.Count; i++)
                {
                    _MtrVContributionMdl = new MtrVContributionMdl();
                    _MtrVContributionMdl.BranchCode = Convert.ToInt32(_tbl1.Rows[i]["BranchCode"]);
                    BranchCode = _MtrVContributionMdl.BranchCode;

                }


            }
            else
            {
                _MtrVContributionMdl.BranchCode = 0;
            }


            //Compare Branch code with Tax percent Branch code to get FED and FIF
            DataTable _tbl2 = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
            {
                SqlCommand command =
                    new SqlCommand("SELECT mtp.FIFValue , mtp.FEDValue FROM MtrTaxPer mtp WHERE mtp.BrchCode = @BrchCode", conn);

                command.Parameters.Add(new SqlParameter("@BrchCode", _MtrVContributionMdl.BranchCode));

                SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                _adpSql.Fill(_tbl2);
            }

            // _adpSql.Fill(_tbl);

            if (_tbl2.Rows.Count > 0)
            {
                for (int i = 0; i < _tbl2.Rows.Count; i++)
                {
                    _MtrVContributionMdl = new MtrVContributionMdl();
                    _MtrVContributionMdl.FIF = Convert.ToInt32(_tbl2.Rows[i]["FIFValue"]);
                    _MtrVContributionMdl.FED = Convert.ToInt32(_tbl2.Rows[i]["FEDValue"]);

                    FED = _MtrVContributionMdl.FED;
                    FIF = _MtrVContributionMdl.FIF;

                }


            }
            else
            {
                _MtrVContributionMdl.FIF = 1;
                _MtrVContributionMdl.FED = 13;

                FED = _MtrVContributionMdl.FED;
                FIF = _MtrVContributionMdl.FIF;
            }


            //To get Tenure
            DataTable _tbl = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
            {
                SqlCommand command =
                    new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip INNER JOIN MtrVehicleDetails mvd ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE mvd.TxnSysID = @TxnSysID", conn);

                command.Parameters.Add(new SqlParameter("@TxnSysID", _VehicleDetailMdl.TxnSysID));

                SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                _adpSql.Fill(_tbl);
            }

            // _adpSql.Fill(_tbl);

            if (_tbl.Rows.Count > 0)
            {
                for (int i = 0; i < _tbl.Rows.Count; i++)
                {
                    _MtrVContributionMdl = new MtrVContributionMdl();
                    _MtrVContributionMdl.Tenure = Convert.ToInt32(_tbl.Rows[i]["tenure"]);

                }


            }
            else
            {
                _MtrVContributionMdl.Tenure = 1;
            }


            _MtrVContributionMdl.SumCovered = _SumCovered;
            _MtrVContributionMdl.Rate = _Rate;

           // _MtrVContributionMdl.FIF = 1;
           // _MtrVContributionMdl.FED = 10;

           

            _MtrVContributionMdl.Stamp = 50;

            _MtrVContributionMdl.BasicContribution = 1000;
            _MtrVContributionMdl.NetContribution = (_SumCovered * (_Rate/100));
            _MtrVContributionMdl.GrossContribution = (_MtrVContributionMdl.NetContribution - _MtrVContributionMdl.Stamp) /(((FED + FIF) / 100)+1);

            if(_SumCovered > 10000000)
            {
                _MtrVContributionMdl.TerrorContribution = 1000;
            }

            else
            {
                _MtrVContributionMdl.TerrorContribution = 400;
            }

            _MtrVContributionMdl.BeforePEV = (_MtrVContributionMdl.GrossContribution - _MtrVContributionMdl.TerrorContribution);
            _MtrVContributionMdl.PEV = (_MtrVContributionMdl.BeforePEV - _MtrVContributionMdl.BasicContribution);
            _MtrVContributionMdl.RiskTxnID = _VehicleDetailMdl.TxnSysID;
            _MtrVContributionMdl.BranchCode = BranchCode;
            _MtrVContributionMdl.FED = FED;
            _MtrVContributionMdl.FIF = FIF;
            _MtrVContributionMdl.OpolTxnSysID = OpolTxnSysID;

            _MtrVContributionMdl.PerDayContribution = _MtrVContributionMdl.GrossContribution / _MtrVContributionMdl.Tenure;
            _MtrVContributionMdl.TxnSysDate = DateTime.Now;

            //Insert into database
            SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
            StringBuilder _sbSql = new StringBuilder();
            SqlCommand _cmdSql;

            _sbSql.AppendLine("INSERT INTO InsContribution(");
           // _sbSql.AppendLine("TxnSysID,");
            _sbSql.AppendLine("TxnSysDate,");
            _sbSql.AppendLine("UserCode,");
            _sbSql.AppendLine("SumCovered,");
            _sbSql.AppendLine("Rate,");
            _sbSql.AppendLine("NetContribution,");
            _sbSql.AppendLine("GrossContribution,");
            _sbSql.AppendLine("FIF,");
            _sbSql.AppendLine("FED,");
            _sbSql.AppendLine("Stamp,");
            _sbSql.AppendLine("BasicContribution,");
            _sbSql.AppendLine("PEV,");
            _sbSql.AppendLine("BeforePEV,");
            _sbSql.AppendLine("TerrorContribution,");
            _sbSql.AppendLine("RiskTxnID,");
            _sbSql.AppendLine("OpolTxnSysID,");
            _sbSql.AppendLine("PerDayContribution)");

            _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");

            //_sbSql.AppendLine("@TxnSysID,");
            _sbSql.AppendLine("@TxnSysDate,");
            _sbSql.AppendLine("@UserCode,");
            _sbSql.AppendLine("@SumCovered,");
            _sbSql.AppendLine("@Rate,");
            _sbSql.AppendLine("@NetContribution,");
            _sbSql.AppendLine("@GrossContribution,");
            _sbSql.AppendLine("@FIF,");
            _sbSql.AppendLine("@FED,");
            _sbSql.AppendLine("@Stamp,");
            _sbSql.AppendLine("@BasicContribution,");
            _sbSql.AppendLine("@PEV,");
            _sbSql.AppendLine("@BeforePEV,");
            _sbSql.AppendLine("@TerrorContribution,");
            _sbSql.AppendLine("@RiskTxnID,");
            _sbSql.AppendLine("@OpolTxnSysID,");
            _sbSql.AppendLine("@PerDayContribution)");

            _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

            _cmdSql.Parameters.AddWithValue("@TxnSysDate",DateTime.Now);
            _cmdSql.Parameters.AddWithValue("@SumCovered", _MtrVContributionMdl.SumCovered);

            int _userCode = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl.UserCode);

            _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
           
            _cmdSql.Parameters.AddWithValue("@Rate", _MtrVContributionMdl.Rate);
            _cmdSql.Parameters.AddWithValue("@NetContribution", _MtrVContributionMdl.NetContribution);
            _cmdSql.Parameters.AddWithValue("@GrossContribution", _MtrVContributionMdl.GrossContribution);
            _cmdSql.Parameters.AddWithValue("@FIF", FIF);
            _cmdSql.Parameters.AddWithValue("@FED", FED);
            _cmdSql.Parameters.AddWithValue("@Stamp", _MtrVContributionMdl.Stamp);
            _cmdSql.Parameters.AddWithValue("@BasicContribution", _MtrVContributionMdl.BasicContribution);
            _cmdSql.Parameters.AddWithValue("@PEV", _MtrVContributionMdl.PEV);
            _cmdSql.Parameters.AddWithValue("@BeforePEV", _MtrVContributionMdl.BeforePEV);
            _cmdSql.Parameters.AddWithValue("@TerrorContribution", _MtrVContributionMdl.TerrorContribution);
            _cmdSql.Parameters.AddWithValue("@PerDayContribution",_MtrVContributionMdl.PerDayContribution);
            _cmdSql.Parameters.AddWithValue("@RiskTxnID", _MtrVContributionMdl.RiskTxnID);
            _cmdSql.Parameters.AddWithValue("@OpolTxnSysID", _MtrVContributionMdl.OpolTxnSysID);

            _MtrVContributionMdl.GrossContribution = Decimal.Round(_MtrVContributionMdl.GrossContribution);
            _MtrVContributionMdl.PEV = Decimal.Round(_MtrVContributionMdl.PEV, MidpointRounding.ToEven);
            _MtrVContributionMdl.SumCovered = Decimal.Round(_MtrVContributionMdl.SumCovered, MidpointRounding.ToEven);
            _MtrVContributionMdl.NetContribution = Decimal.Round(_MtrVContributionMdl.NetContribution, MidpointRounding.ToEven);
            _MtrVContributionMdl.BeforePEV = Decimal.Round(_MtrVContributionMdl.BeforePEV, MidpointRounding.ToEven);

            int _TxnSysId;
            _conSql.Open();
            _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
            _conSql.Close();

            _MtrVContributionMdl.TxnSysID = _TxnSysId;
            //  _ProductConditionsSetupMdl.ConditionShText = GetConditionByCode(_ProductConditionsSetupMdl.Condition);
            _MtrVContributionMdl.IsValidTxn = true;


            //To update Contribution of Vehicle Certificate
            SqlConnection _conSql1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
            StringBuilder _sbSql1 = new StringBuilder();
            SqlCommand _cmdSql1;

            _sbSql1.AppendLine("Update  MtrVehicleDetails SET");
            _sbSql1.AppendLine("Contribution= @Contribution");
            _sbSql1.AppendLine("WHERE TxnSysId=@TxnSysId ");

            _cmdSql1 = new SqlCommand(_sbSql1.ToString(), _conSql1);

            _cmdSql1.Parameters.AddWithValue("@TxnSysID", _MtrVContributionMdl.RiskTxnID);
            _cmdSql1.Parameters.AddWithValue("@Contribution", _MtrVContributionMdl.NetContribution);

            _conSql1.Open();
            _cmdSql1.ExecuteNonQuery();
            _conSql1.Close();


            _MtrVContributionMdlList.Add(_MtrVContributionMdl);
            return _MtrVContributionMdlList;

        }

        //Get Contribution by Vehicle TxnSysID
        public List<MtrVContributionMdl> GetContributionByTxnSysID(VehicleDetailMdl _VehicleDetailMdl)
        {

            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                DataTable _tblSqla = new DataTable();
                MtrVContributionMdl _MtrVContributionMdl;
                List<MtrVContributionMdl> _MtrVContributionMdlList = new List<MtrVContributionMdl>();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM InsContribution Where RiskTxnID = @RiskTxnID", conn);

                    command.Parameters.Add(new SqlParameter("@RiskTxnID", _VehicleDetailMdl.TxnSysID));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _MtrVContributionMdl = new MtrVContributionMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _MtrVContributionMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrVContributionMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrVContributionMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrVContributionMdl.SumCovered = Convert.ToInt32(_tblSqla.Rows[i]["SumCovered"]);
                        _MtrVContributionMdl.Rate = Convert.ToDecimal(_tblSqla.Rows[i]["Rate"]);
                        _MtrVContributionMdl.NetContribution = Convert.ToDecimal(_tblSqla.Rows[i]["NetContribution"]);
                        _MtrVContributionMdl.GrossContribution = Convert.ToDecimal(_tblSqla.Rows[i]["GrossContribution"]);
                        _MtrVContributionMdl.FIF = Convert.ToDecimal(_tblSqla.Rows[i]["FIF"]);
                        _MtrVContributionMdl.FED = Convert.ToDecimal(_tblSqla.Rows[i]["FED"]);
                        _MtrVContributionMdl.Stamp = Convert.ToDecimal(_tblSqla.Rows[i]["Stamp"]);
                        _MtrVContributionMdl.BasicContribution = Convert.ToDecimal(_tblSqla.Rows[i]["BasicContribution"]);
                        _MtrVContributionMdl.PEV = Convert.ToDecimal(_tblSqla.Rows[i]["PEV"]);
                        _MtrVContributionMdl.BeforePEV = Convert.ToDecimal(_tblSqla.Rows[i]["BeforePEV"]);
                        _MtrVContributionMdl.TerrorContribution = Convert.ToDecimal(_tblSqla.Rows[i]["TerrorContribution"]);
                        _MtrVContributionMdl.RiskTxnID = Convert.ToInt32(_tblSqla.Rows[i]["RiskTxnID"]);
                        _MtrVContributionMdl.PerDayContribution = Convert.ToInt32(_tblSqla.Rows[i]["PerDayContribution"]);
                        _MtrVContributionMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["OpolTxnSysID"]);


                        _MtrVContributionMdl.GrossContribution = Decimal.Round(Convert.ToDecimal(_tblSqla.Rows[i]["GrossContribution"]),  MidpointRounding.ToEven);
                        _MtrVContributionMdl.PEV = Decimal.Round(Convert.ToDecimal(_tblSqla.Rows[i]["PEV"]),  MidpointRounding.ToEven);
                        _MtrVContributionMdl.NetContribution = Decimal.Round(Convert.ToDecimal(_tblSqla.Rows[i]["NetContribution"]),  MidpointRounding.ToEven);
                        _MtrVContributionMdl.BeforePEV = Decimal.Round(Convert.ToDecimal(_tblSqla.Rows[i]["BeforePEV"]),  MidpointRounding.ToEven);



                        _MtrVContributionMdlList.Add(_MtrVContributionMdl);
                    }
                    return _MtrVContributionMdlList;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }





        }

        //Calculate Contribution for Vehicle Policy
        public List<MtrVContributionMdl> CalcContributionForPol(VehicleDetailMdl _VehicleDetailMdl)
        {


            decimal _SumCovered = _VehicleDetailMdl.ParticipantValue;
            decimal _Rate = _VehicleDetailMdl.Rate;

            decimal FED = 13, FIF = 1;
            int BranchCode = 101, OpolTxnSysID = -1;


            MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
            List<MtrVContributionMdl> _MtrVContributionMdlList = new List<MtrVContributionMdl>();

            ////Get OPolTxnSysID

            //DataTable _tbl3 = new DataTable();

            //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
            //{
            //    SqlCommand command =
            //        new SqlCommand("SELECT mvd.OpolTxnSysID FROM MtrVehicleDetails mvd WHERE mvd.TxnSysID = @TxnSysID", conn);

            //    command.Parameters.Add(new SqlParameter("@TxnSysID", _VehicleDetailMdl.TxnSysID));

            //    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


            //    _adpSql.Fill(_tbl3);
            //}

            //// _adpSql.Fill(_tbl);

            //if (_tbl3.Rows.Count > 0)
            //{
            //    for (int i = 0; i < _tbl3.Rows.Count; i++)
            //    {
            //        _MtrVContributionMdl = new MtrVContributionMdl();
            //        _MtrVContributionMdl.OpolTxnSysID = Convert.ToInt32(_tbl3.Rows[i]["OpolTxnSysID"]);
            //        OpolTxnSysID = _MtrVContributionMdl.OpolTxnSysID;

            //    }


            //}
            //else
            //{
            //    _MtrVContributionMdl.OpolTxnSysID = 0;
            //}

            ////Get Branch Code
            //DataTable _tbl1 = new DataTable();

            //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
            //{
            //    SqlCommand command =
            //        new SqlCommand("SELECT ip.BrchCoverNoteNo BranchCode FROM InsPolicy ip INNER JOIN MtrVehicleDetails mvd ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE mvd.TxnSysID = @TxnSysID", conn);

            //    command.Parameters.Add(new SqlParameter("@TxnSysID", _VehicleDetailMdl.TxnSysID));

            //    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


            //    _adpSql.Fill(_tbl1);
            //}

            //// _adpSql.Fill(_tbl);

            //if (_tbl1.Rows.Count > 0)
            //{
            //    for (int i = 0; i < _tbl1.Rows.Count; i++)
            //    {
            //        _MtrVContributionMdl = new MtrVContributionMdl();
            //        _MtrVContributionMdl.BranchCode = Convert.ToInt32(_tbl1.Rows[i]["BranchCode"]);
            //        BranchCode = _MtrVContributionMdl.BranchCode;

            //    }


            //}
            //else
            //{
            //    _MtrVContributionMdl.BranchCode = 0;
            //}


            ////Compare Branch code with Tax percent Branch code to get FED and FIF
            //DataTable _tbl2 = new DataTable();

            //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
            //{
            //    SqlCommand command =
            //        new SqlCommand("SELECT mtp.FIFValue , mtp.FEDValue FROM MtrTaxPer mtp WHERE mtp.BrchCode = @BrchCode", conn);

            //    command.Parameters.Add(new SqlParameter("@BrchCode", _MtrVContributionMdl.BranchCode));

            //    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


            //    _adpSql.Fill(_tbl2);
            //}

            //// _adpSql.Fill(_tbl);

            //if (_tbl2.Rows.Count > 0)
            //{
            //    for (int i = 0; i < _tbl2.Rows.Count; i++)
            //    {
            //        _MtrVContributionMdl = new MtrVContributionMdl();
            //        _MtrVContributionMdl.FIF = Convert.ToInt32(_tbl2.Rows[i]["FIFValue"]);
            //        _MtrVContributionMdl.FED = Convert.ToInt32(_tbl2.Rows[i]["FEDValue"]);

            //        FED = _MtrVContributionMdl.FED;
            //        FIF = _MtrVContributionMdl.FIF;

            //    }


            //}
            //else
            //{
            //    _MtrVContributionMdl.FIF = 1;
            //    _MtrVContributionMdl.FED = 1;
            //}


            //To get Tenure
            DataTable _tbl = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
            {
                SqlCommand command =
                    new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip INNER JOIN MtrVehicleDetails mvd ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE mvd.TxnSysID = @TxnSysID", conn);

                command.Parameters.Add(new SqlParameter("@TxnSysID", _VehicleDetailMdl.TxnSysID));

                SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                _adpSql.Fill(_tbl);
            }

            // _adpSql.Fill(_tbl);

            if (_tbl.Rows.Count > 0)
            {
                for (int i = 0; i < _tbl.Rows.Count; i++)
                {
                    _MtrVContributionMdl = new MtrVContributionMdl();
                    _MtrVContributionMdl.Tenure = Convert.ToInt32(_tbl.Rows[i]["tenure"]);

                }


            }
            else
            {
                _MtrVContributionMdl.Tenure = 1;
            }


            _MtrVContributionMdl.SumCovered = _SumCovered;
            _MtrVContributionMdl.Rate = _Rate;

             _MtrVContributionMdl.FIF = 1;
            _MtrVContributionMdl.FED = 13;

            _MtrVContributionMdl.Stamp = 50;

            _MtrVContributionMdl.BasicContribution = 1000;
            _MtrVContributionMdl.NetContribution = (_SumCovered * (_Rate / 100));
            _MtrVContributionMdl.GrossContribution = (_MtrVContributionMdl.NetContribution - _MtrVContributionMdl.Stamp) / (((_MtrVContributionMdl.FED + _MtrVContributionMdl.FIF) / 100) + 1);

            if (_SumCovered > 10000000)
            {
                _MtrVContributionMdl.TerrorContribution = 1000;
            }

            else
            {
                _MtrVContributionMdl.TerrorContribution = 400;
            }

            _MtrVContributionMdl.BeforePEV = (_MtrVContributionMdl.GrossContribution - _MtrVContributionMdl.TerrorContribution);
            _MtrVContributionMdl.PEV = (_MtrVContributionMdl.BeforePEV - _MtrVContributionMdl.BasicContribution);
            _MtrVContributionMdl.RiskTxnID = _VehicleDetailMdl.TxnSysID;
            _MtrVContributionMdl.BranchCode = BranchCode;
            _MtrVContributionMdl.FED = FED;
            _MtrVContributionMdl.FIF = FIF;
            _MtrVContributionMdl.OpolTxnSysID = OpolTxnSysID;

            _MtrVContributionMdl.PerDayContribution = _MtrVContributionMdl.GrossContribution / _MtrVContributionMdl.Tenure;
            _MtrVContributionMdl.TxnSysDate = DateTime.Now;

            //Insert into  InsContribution database
            SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
            StringBuilder _sbSql = new StringBuilder();
            SqlCommand _cmdSql;

            _sbSql.AppendLine("INSERT INTO InsContribution(");
            // _sbSql.AppendLine("TxnSysID,");
            _sbSql.AppendLine("TxnSysDate,");
            _sbSql.AppendLine("UserCode,");
            _sbSql.AppendLine("SumCovered,");
            _sbSql.AppendLine("Rate,");
            _sbSql.AppendLine("NetContribution,");
            _sbSql.AppendLine("GrossContribution,");
            _sbSql.AppendLine("FIF,");
            _sbSql.AppendLine("FED,");
            _sbSql.AppendLine("Stamp,");
            _sbSql.AppendLine("BasicContribution,");
            _sbSql.AppendLine("PEV,");
            _sbSql.AppendLine("BeforePEV,");
            _sbSql.AppendLine("TerrorContribution,");
            _sbSql.AppendLine("RiskTxnID,");
            _sbSql.AppendLine("OpolTxnSysID,");
            _sbSql.AppendLine("PerDayContribution)");

            _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");

            //_sbSql.AppendLine("@TxnSysID,");
            _sbSql.AppendLine("@TxnSysDate,");
            _sbSql.AppendLine("@UserCode,");
            _sbSql.AppendLine("@SumCovered,");
            _sbSql.AppendLine("@Rate,");
            _sbSql.AppendLine("@NetContribution,");
            _sbSql.AppendLine("@GrossContribution,");
            _sbSql.AppendLine("@FIF,");
            _sbSql.AppendLine("@FED,");
            _sbSql.AppendLine("@Stamp,");
            _sbSql.AppendLine("@BasicContribution,");
            _sbSql.AppendLine("@PEV,");
            _sbSql.AppendLine("@BeforePEV,");
            _sbSql.AppendLine("@TerrorContribution,");
            _sbSql.AppendLine("@RiskTxnID,");
            _sbSql.AppendLine("@OpolTxnSysID,");
            _sbSql.AppendLine("@PerDayContribution)");

            _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

            _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
            _cmdSql.Parameters.AddWithValue("@SumCovered", _MtrVContributionMdl.SumCovered);

            int _userCode = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl.UserCode);

            _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);

            _cmdSql.Parameters.AddWithValue("@Rate", _MtrVContributionMdl.Rate);
            _cmdSql.Parameters.AddWithValue("@NetContribution", _MtrVContributionMdl.NetContribution);
            _cmdSql.Parameters.AddWithValue("@GrossContribution", _MtrVContributionMdl.GrossContribution);
            _cmdSql.Parameters.AddWithValue("@FIF", _MtrVContributionMdl.FIF);
            _cmdSql.Parameters.AddWithValue("@FED", _MtrVContributionMdl.FED);
            _cmdSql.Parameters.AddWithValue("@Stamp", _MtrVContributionMdl.Stamp);
            _cmdSql.Parameters.AddWithValue("@BasicContribution", _MtrVContributionMdl.BasicContribution);
            _cmdSql.Parameters.AddWithValue("@PEV", _MtrVContributionMdl.PEV);
            _cmdSql.Parameters.AddWithValue("@BeforePEV", _MtrVContributionMdl.BeforePEV);
            _cmdSql.Parameters.AddWithValue("@TerrorContribution", _MtrVContributionMdl.TerrorContribution);
            _cmdSql.Parameters.AddWithValue("@PerDayContribution", _MtrVContributionMdl.PerDayContribution);
            _cmdSql.Parameters.AddWithValue("@RiskTxnID", _MtrVContributionMdl.RiskTxnID);
            _cmdSql.Parameters.AddWithValue("@OpolTxnSysID", -1);



            int _TxnSysId;
            _conSql.Open();
            _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
            _conSql.Close();

            _MtrVContributionMdl.GrossContribution = Decimal.Round(_MtrVContributionMdl.GrossContribution,  MidpointRounding.ToEven);
            _MtrVContributionMdl.PEV = Decimal.Round(_MtrVContributionMdl.PEV,  MidpointRounding.ToEven);
            _MtrVContributionMdl.SumCovered = Decimal.Round(_MtrVContributionMdl.SumCovered,  MidpointRounding.ToEven);
            _MtrVContributionMdl.NetContribution = Decimal.Round(_MtrVContributionMdl.NetContribution,  MidpointRounding.ToEven);
            _MtrVContributionMdl.BeforePEV = Decimal.Round(_MtrVContributionMdl.BeforePEV,  MidpointRounding.ToEven);

            _MtrVContributionMdl.TxnSysID = _TxnSysId;
            //  _ProductConditionsSetupMdl.ConditionShText = GetConditionByCode(_ProductConditionsSetupMdl.Condition);
            _MtrVContributionMdl.IsValidTxn = true;


            //To update Contribution of Vehicle Certificate
            SqlConnection _conSql1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
            StringBuilder _sbSql1 = new StringBuilder();
            SqlCommand _cmdSql1;

            _sbSql1.AppendLine("Update  MtrVehicleDetails SET");
            _sbSql1.AppendLine("Contribution= @Contribution");
            _sbSql1.AppendLine("WHERE TxnSysId=@TxnSysId ");

            _cmdSql1 = new SqlCommand(_sbSql1.ToString(), _conSql1);

            _cmdSql1.Parameters.AddWithValue("@TxnSysID", _MtrVContributionMdl.RiskTxnID);
            _cmdSql1.Parameters.AddWithValue("@Contribution", _MtrVContributionMdl.NetContribution);

            _conSql1.Open();
            _cmdSql1.ExecuteNonQuery();
            _conSql1.Close();


            //Insert into  InsUpdateContribution database
            SqlConnection _conSql2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
            StringBuilder _sbSql2 = new StringBuilder();
            SqlCommand _cmdSql2;

            _sbSql2.AppendLine("INSERT INTO InsUpdateContribution(");
            // _sbSql.AppendLine("TxnSysID,");
            _sbSql2.AppendLine("TxnSysDate,");
            _sbSql2.AppendLine("UserCode,");
            _sbSql2.AppendLine("SumCovered,");
            _sbSql2.AppendLine("Rate,");
            _sbSql2.AppendLine("NetContribution,");
            _sbSql2.AppendLine("GrossContribution,");
            _sbSql2.AppendLine("FIF,");
            _sbSql2.AppendLine("FED,");
            _sbSql2.AppendLine("Stamp,");
            _sbSql2.AppendLine("BasicContribution,");
            _sbSql2.AppendLine("PEV,");
            _sbSql2.AppendLine("BeforePEV,");
            _sbSql2.AppendLine("TerrorContribution,");
            _sbSql2.AppendLine("RiskTxnID,");
            _sbSql2.AppendLine("OpolTxnSysID,");
            _sbSql2.AppendLine("PerDayContribution)");

            _sbSql2.AppendLine("output INSERTED. TxnSysID VALUES ( ");

            //_sbSql.AppendLine("@TxnSysID,");
            _sbSql2.AppendLine("@TxnSysDate,");
            _sbSql2.AppendLine("@UserCode,");
            _sbSql2.AppendLine("@SumCovered,");
            _sbSql2.AppendLine("@Rate,");
            _sbSql2.AppendLine("@NetContribution,");
            _sbSql2.AppendLine("@GrossContribution,");
            _sbSql2.AppendLine("@FIF,");
            _sbSql2.AppendLine("@FED,");
            _sbSql2.AppendLine("@Stamp,");
            _sbSql2.AppendLine("@BasicContribution,");
            _sbSql2.AppendLine("@PEV,");
            _sbSql2.AppendLine("@BeforePEV,");
            _sbSql2.AppendLine("@TerrorContribution,");
            _sbSql2.AppendLine("@RiskTxnID,");
            _sbSql2.AppendLine("@OpolTxnSysID,");
            _sbSql2.AppendLine("@PerDayContribution)");

            _cmdSql2 = new SqlCommand(_sbSql2.ToString(), _conSql2);

            _cmdSql2.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
            _cmdSql2.Parameters.AddWithValue("@SumCovered", _MtrVContributionMdl.SumCovered);

            int _userCode2 = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl.UserCode);

            _cmdSql2.Parameters.AddWithValue("@UserCode", _userCode2);

            _cmdSql2.Parameters.AddWithValue("@Rate", _MtrVContributionMdl.Rate);
            _cmdSql2.Parameters.AddWithValue("@NetContribution", _MtrVContributionMdl.NetContribution);
            _cmdSql2.Parameters.AddWithValue("@GrossContribution", _MtrVContributionMdl.GrossContribution);
            _cmdSql2.Parameters.AddWithValue("@FIF", _MtrVContributionMdl.FIF);
            _cmdSql2.Parameters.AddWithValue("@FED", _MtrVContributionMdl.FED);
            _cmdSql2.Parameters.AddWithValue("@Stamp", _MtrVContributionMdl.Stamp);
            _cmdSql2.Parameters.AddWithValue("@BasicContribution", _MtrVContributionMdl.BasicContribution);
            _cmdSql2.Parameters.AddWithValue("@PEV", _MtrVContributionMdl.PEV);
            _cmdSql2.Parameters.AddWithValue("@BeforePEV", _MtrVContributionMdl.BeforePEV);
            _cmdSql2.Parameters.AddWithValue("@TerrorContribution", _MtrVContributionMdl.TerrorContribution);
            _cmdSql2.Parameters.AddWithValue("@PerDayContribution", _MtrVContributionMdl.PerDayContribution);
            _cmdSql2.Parameters.AddWithValue("@RiskTxnID", _MtrVContributionMdl.RiskTxnID);
            _cmdSql2.Parameters.AddWithValue("@OpolTxnSysID", -1);



            int _TxnSysId2;
            _conSql2.Open();
            _TxnSysId2 = (Int32)_cmdSql2.ExecuteScalar();
            _conSql2.Close();

            _MtrVContributionMdl.TxnSysID = _TxnSysId2;
            //  _ProductConditionsSetupMdl.ConditionShText = GetConditionByCode(_ProductConditionsSetupMdl.Condition);
            _MtrVContributionMdl.IsValidTxn = true;




            _MtrVContributionMdlList.Add(_MtrVContributionMdl);
            return _MtrVContributionMdlList;

        }

        //To Update Contribution for Vehicle Open Policy And Policy
        public List<MtrVContributionMdl> UpdateCalcContribution(VehicleDetailMdl _VehicleDetailMdl)
        {


            decimal _SumCovered = _VehicleDetailMdl.ParticipantValue;
            decimal _Rate = _VehicleDetailMdl.Rate;

           

            MtrVContributionMdl _MtrVContributionMdl = new MtrVContributionMdl();
            List<MtrVContributionMdl> _MtrVContributionMdlList = new List<MtrVContributionMdl>();

            MtrVContributionMdl _MtrVContributionMdl1 = new MtrVContributionMdl();
            List<MtrVContributionMdl> _MtrVContributionMdlList1 = new List<MtrVContributionMdl>();

            SqlConnection _conSql1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
            DataTable _tblSqla1 = new DataTable();          
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
            {
                SqlCommand command =
                    new SqlCommand("SELECT *  FROM InsContribution Where RiskTxnID = @RiskTxnID", conn);

                command.Parameters.Add(new SqlParameter("@RiskTxnID", _VehicleDetailMdl.TxnSysID));

                SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                _adpSql.Fill(_tblSqla1);
            }

            //  _adpSql.Fill(_tblSqla);

            if (_tblSqla1.Rows.Count > 0)
            {
                _MtrVContributionMdl = new MtrVContributionMdl();
                for (int i = 0; i < _tblSqla1.Rows.Count; i++)
                {


                    _MtrVContributionMdl.UserCode = Convert.ToInt32(_tblSqla1.Rows[i]["UserCode"]);
                    _MtrVContributionMdl.SumCovered = Convert.ToInt32(_tblSqla1.Rows[i]["SumCovered"]);
                    _MtrVContributionMdl.FIF = Convert.ToDecimal(_tblSqla1.Rows[i]["FIF"]);
                    _MtrVContributionMdl.FED = Convert.ToDecimal(_tblSqla1.Rows[i]["FED"]);
                    _MtrVContributionMdl.Stamp = Convert.ToDecimal(_tblSqla1.Rows[i]["Stamp"]);
                    _MtrVContributionMdl.BasicContribution = Convert.ToDecimal(_tblSqla1.Rows[i]["BasicContribution"]);
                    _MtrVContributionMdl.TerrorContribution = Convert.ToDecimal(_tblSqla1.Rows[i]["TerrorContribution"]);
                    _MtrVContributionMdl.RiskTxnID = Convert.ToInt32(_tblSqla1.Rows[i]["RiskTxnID"]);
                    _MtrVContributionMdl.OpolTxnSysID = Convert.ToInt32(_tblSqla1.Rows[i]["OpolTxnSysID"]);

                    _MtrVContributionMdlList.Add(_MtrVContributionMdl);
                }
               

            }

            else
            {

            }


            //To get Tenure
            DataTable _tbl = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
            {
                SqlCommand command =
                    new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip INNER JOIN MtrVehicleDetails mvd ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE mvd.TxnSysID = @TxnSysID", conn);

                command.Parameters.Add(new SqlParameter("@TxnSysID", _VehicleDetailMdl.TxnSysID));

                SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                _adpSql.Fill(_tbl);
            }

            // _adpSql.Fill(_tbl);

            if (_tbl.Rows.Count > 0)
            {
                for (int i = 0; i < _tbl.Rows.Count; i++)
                {
                    _MtrVContributionMdl1 = new MtrVContributionMdl();
                    _MtrVContributionMdl1.Tenure = Convert.ToInt32(_tbl.Rows[i]["tenure"]);

                }


            }
            else
            {
                _MtrVContributionMdl1.Tenure = 1;
            }


            decimal net, gross,BeforePEV,PEV,PerDay;
            int terror;

           net = (_SumCovered * (_Rate / 100));
           gross = (net - _MtrVContributionMdl.Stamp) / (((_MtrVContributionMdl.FED + _MtrVContributionMdl.FIF) / 100) + 1);

            if (_SumCovered > 10000000)
            {
                terror = 1000;
            }

            else
            {
                terror = 400;
            }

            BeforePEV = (gross - terror);
            PEV = (BeforePEV - _MtrVContributionMdl.BasicContribution);
           

            PerDay = gross/ _MtrVContributionMdl1.Tenure;


            //Update Contribution database
            SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
            StringBuilder _sbSql = new StringBuilder();
            SqlCommand _cmdSql;

            _sbSql.AppendLine("Update  InsContribution SET");
            _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
            _sbSql.AppendLine("UserCode= @UserCode,");
            _sbSql.AppendLine("SumCovered=@SumCovered,");
            _sbSql.AppendLine("Rate=@Rate,");
            _sbSql.AppendLine("NetContribution=@NetContribution,");
            _sbSql.AppendLine("GrossContribution=@GrossContribution,");
            _sbSql.AppendLine("PEV=@PEV,");
            _sbSql.AppendLine("BeforePEV=@BeforePEV,");
            _sbSql.AppendLine("TerrorContribution=@TerrorContribution,");
            _sbSql.AppendLine("PerDayContribution=@PerDayContribution");
            _sbSql.AppendLine("WHERE RiskTxnID=@RiskTxnID");

            _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

            int _userCode = GlobalDataLayer.GetUserCodeById(_MtrVContributionMdl.UserCode);

          

            _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
            _cmdSql.Parameters.AddWithValue("@SumCovered", _SumCovered);

            _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);

            _cmdSql.Parameters.AddWithValue("@Rate", _Rate);
            _cmdSql.Parameters.AddWithValue("@NetContribution", net);
            _cmdSql.Parameters.AddWithValue("@GrossContribution", gross);
            _cmdSql.Parameters.AddWithValue("@PEV", PEV);
            _cmdSql.Parameters.AddWithValue("@BeforePEV", BeforePEV);
            _cmdSql.Parameters.AddWithValue("@TerrorContribution", terror);
            _cmdSql.Parameters.AddWithValue("@PerDayContribution", PerDay);
            _cmdSql.Parameters.AddWithValue("@RiskTxnID", _VehicleDetailMdl.TxnSysID);

            _conSql.Open();
            _cmdSql.ExecuteNonQuery();
            _conSql.Close();
            _MtrVContributionMdl.IsValidTxn = true;


            //To update Contribution of Vehicle Certificate
            SqlConnection _conSql1A = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
            StringBuilder _sbSql1A = new StringBuilder();
            SqlCommand _cmdSql1A;

            _sbSql1A.AppendLine("Update  MtrVehicleDetails SET");
            _sbSql1A.AppendLine("Contribution= @Contribution");
            _sbSql1A.AppendLine("WHERE TxnSysId=@TxnSysId ");

            _cmdSql1A = new SqlCommand(_sbSql1A.ToString(), _conSql1A);

            _cmdSql1A.Parameters.AddWithValue("@TxnSysID", _VehicleDetailMdl.TxnSysID);
            _cmdSql1A.Parameters.AddWithValue("@Contribution", net);

            _conSql1A.Open();
            _cmdSql1A.ExecuteNonQuery();
            _conSql1A.Close();

            List<MtrVContributionMdl> _MtrVContributionMdlListA = new List<MtrVContributionMdl>();
            MtrVContributionMdl _MtrVContributionMdlA = new MtrVContributionMdl();



            _MtrVContributionMdlA.SumCovered = Decimal.Round(Convert.ToDecimal(_SumCovered), MidpointRounding.ToEven); 
            _MtrVContributionMdlA.Rate = Decimal.Round(Convert.ToDecimal(_Rate), MidpointRounding.ToEven); 
            _MtrVContributionMdlA.NetContribution = Decimal.Round(Convert.ToDecimal(net), MidpointRounding.ToEven);
            _MtrVContributionMdlA.GrossContribution = Decimal.Round(Convert.ToDecimal(gross), MidpointRounding.ToEven);
            _MtrVContributionMdlA.PEV = Decimal.Round(Convert.ToDecimal(PEV), MidpointRounding.ToEven); 
            _MtrVContributionMdlA.BeforePEV = Decimal.Round(Convert.ToDecimal(BeforePEV), MidpointRounding.ToEven);
            _MtrVContributionMdlA.TerrorContribution = Decimal.Round(Convert.ToDecimal(terror), MidpointRounding.ToEven);
            _MtrVContributionMdlA.PerDayContribution = Decimal.Round(Convert.ToDecimal(PerDay), MidpointRounding.ToEven);
            _MtrVContributionMdlA.FED = Decimal.Round(Convert.ToDecimal(_MtrVContributionMdl.FED), MidpointRounding.ToEven);
            _MtrVContributionMdlA.FIF = Decimal.Round(Convert.ToDecimal(_MtrVContributionMdl.FIF), MidpointRounding.ToEven);
            _MtrVContributionMdlA.BasicContribution = Decimal.Round(Convert.ToDecimal(_MtrVContributionMdl.BasicContribution), MidpointRounding.ToEven);
            _MtrVContributionMdlA.Stamp = (_MtrVContributionMdl.Stamp);
           _MtrVContributionMdlA.RiskTxnID = _VehicleDetailMdl.TxnSysID;

            _MtrVContributionMdlListA.Add(_MtrVContributionMdlA);
            return _MtrVContributionMdlListA;

        }

        //for checking duplicate in Motor Vehicle Certificates
        public bool IsDuplicateVehicleDetails(VehicleDetailMdl _VehicleDetailMdl)

        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();

                string _sqlString = "SELECT * FROM MtrVehicleDetails  WHERE UPPER(EngineNumber)='" + _VehicleDetailMdl.EngineNumber.ToString().ToUpper() + "' AND UPPER(RegistrationNumber)= '" + _VehicleDetailMdl.RegistrationNumber.ToString().ToUpper()+ "' AND UPPER(ChasisNumber)='"+ _VehicleDetailMdl.ChasisNumber.ToString().ToUpper() +"'";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<VehicleDetailMdl> _VehicleDetailMdlList = new List<VehicleDetailMdl>();
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return false;
            }
        }

        //for Adding only one Certificate against one Open Policy
        public bool IsUnique(VehicleDetailMdl _VehicleDetailMdl)

        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();

                string _sqlString = "SELECT mvd.* FROM MtrVehicleDetails mvd INNER JOIN InsPolicy ip ON ip.ParentTxnSysID = mvd.ParentTxnSysID INNER JOIN MtrOpenPolicy mop ON mop.TxnSysID = ip.OpolTxnSysID WHERE mvd.ParentTxnSysID = (SELECT MAX(ParentTxnSysID) FROM InsPolicy)";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                List<VehicleDetailMdl> _VehicleDetailMdlList = new List<VehicleDetailMdl>();
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return true;
            }
        }

        //for getting all Vehicle Colors
        public List<VColorMdl> GetVehicleColor()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrVColors";
                //+ " WHERE  FORMAT(TxnSysDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + 
                // "AND FORMAT(EffectiveDate,'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(),'yyyy-MM-dd'))" + "AND FORMAT(ExpiryDate, 'yyyy-MM-dd') = (SELECT FORMAT(GETDATE(), 'yyyy-MM-dd'))";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<VColorMdl> _VColorMdlList = new List<VColorMdl>();
                VColorMdl _VColorMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _VColorMdl = new VColorMdl();

                        _VColorMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _VColorMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _VColorMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _VColorMdl.COLOR_CODE = Convert.ToInt32(_tblSqla.Rows[i]["COLOR_CODE"]);
                        _VColorMdl.COLOR_NAME = _tblSqla.Rows[i]["COLOR_NAME"].ToString();
                        _VColorMdl.COLOR_SHORT_NAME = _tblSqla.Rows[i]["COLOR_SHORT_NAME"].ToString();


                        _VColorMdlList.Add(_VColorMdl);


                    }

                    return _VColorMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }


        //for adding new Motor Vehicle Colors
        public VColorMdl AddVehicleColor(VColorMdl _VColorMdl)
        {
            try

            {

                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();
                SqlCommand _cmdSql;
               


                _sbSql.AppendLine("INSERT INTO MtrVColors(");
                //_sbSql.AppendLine("TxnSysID,");
                _sbSql.AppendLine("TxnSysDate,");
                _sbSql.AppendLine("UserCode,");
                _sbSql.AppendLine("COLOR_CODE,");
                _sbSql.AppendLine("COLOR_NAME,");
                _sbSql.AppendLine("COLOR_SHORT_NAME)");


                _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");
              //  _sbSql.AppendLine("@TxnSysID,");
                _sbSql.AppendLine("@TxnSysDate,");
                _sbSql.AppendLine("@UserCode,");
                _sbSql.AppendLine("@COLOR_CODE,");
                _sbSql.AppendLine("@COLOR_NAME,");
                _sbSql.AppendLine("@COLOR_SHORT_NAME)");



                _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);




                DateTime da = DateTime.Now;
                da.ToString("MM-dd-yyyy h:mm tt");

                _cmdSql.Parameters.AddWithValue("@TxnSysDate", Convert.ToDateTime(da));
                int _userCode = GlobalDataLayer.GetUserCodeById(_VColorMdl.UserCode);
                _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                _cmdSql.Parameters.AddWithValue("@COLOR_CODE", _VColorMdl.COLOR_CODE);
                _cmdSql.Parameters.AddWithValue("@COLOR_NAME", _VColorMdl.COLOR_NAME);
                _cmdSql.Parameters.AddWithValue("@COLOR_SHORT_NAME", _VColorMdl.COLOR_SHORT_NAME ?? DBNull.Value.ToString());

                _VColorMdl.TxnSysDate = DateTime.Now;

                int _TxnSysId;
                _conSql.Open();
                _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                _conSql.Close();

                _VColorMdl.IsValidTxn = true;
                _VColorMdl.TxnSysID = _TxnSysId;

              
                return _VColorMdl;
                
            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }

        }

        //for updating existing Motor Vehicle Colors
        public VColorMdl UpdateMasterProductSetup(VColorMdl _VColorMdl)
        {
            try
            {

                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("Update  MtrVColors SET");
                    _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
                    _sbSql.AppendLine("UserCode= @UserCode,");
                    _sbSql.AppendLine("COLOR_CODE=@COLOR_CODE,");
                    _sbSql.AppendLine("COLOR_NAME=@COLOR_NAME,");
                    _sbSql.AppendLine("COLOR_SHORT_NAME=@COLOR_SHORT_NAME");
                    
                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_VColorMdl.UserCode);


                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _VColorMdl.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@COLOR_CODE", _VColorMdl.COLOR_CODE);
                    _cmdSql.Parameters.AddWithValue("@COLOR_NAME", _VColorMdl.COLOR_NAME);
                    _cmdSql.Parameters.AddWithValue("@COLOR_SHORT_NAME", _VColorMdl.COLOR_SHORT_NAME);

                _VColorMdl.IsValidTxn = true;

                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    return _VColorMdl;

                

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Getting Motor Vehicle Colors Name By Code
        public string GetVehicleColorNameByCode(int _COLOR_CODE)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                VehicleDetailMdl _VehicleDetailMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrVColors Where COLOR_CODE = @COLOR_CODE", conn);

                    command.Parameters.Add(new SqlParameter("@COLOR_CODE", _COLOR_CODE));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.ColorName = _tblSqla.Rows[i]["COLOR_SHORT_NAME"].ToString();

                    }
                    return _VehicleDetailMdl.ColorName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Get all Cities
        public List<MtrCityMdl> GetCity()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrCity";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrCityMdl> _MtrCityMdlList = new List<MtrCityMdl>();
                MtrCityMdl _MtrCityMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrCityMdl = new MtrCityMdl();

                        _MtrCityMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrCityMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrCityMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrCityMdl.CITY_CODE = Convert.ToInt32(_tblSqla.Rows[i]["CITY_CODE"]);
                        _MtrCityMdl.CITY_NAME = _tblSqla.Rows[i]["CITY_NAME"].ToString();
                        //  _MtrCityMdl.STATE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["STATE_CODE"]);
                        // _MtrCityMdl.CRESTA_CODE = Convert.ToInt32(_tblSqla.Rows[i]["CRESTA_CODE"]);
                        // _MtrCityMdl.CRESTA_NAME = _tblSqla.Rows[i]["CRESTA_NAME"].ToString();
                        // _MtrCityMdl.ENT_BY = _tblSqla.Rows[i]["ENT_BY"].ToString();
                        // _MtrCityMdl.ENT_DATE = Convert.ToDateTime(_tblSqla.Rows[i]["ENT_DATE"]);
                        // _MtrCityMdl.Active = _tblSqla.Rows[i]["Active"].ToString();




                        _MtrCityMdlList.Add(_MtrCityMdl);


                    }

                    return _MtrCityMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //for adding new City
        public MtrCityMdl AddCity(MtrCityMdl _MtrCityMdl)
        {
            try

            {

                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();
                SqlCommand _cmdSql;



                _sbSql.AppendLine("INSERT INTO MtrCity(");
                // _sbSql.AppendLine("TxnSysID,");
                _sbSql.AppendLine("TxnSysDate,");
                _sbSql.AppendLine("UserCode,");
                _sbSql.AppendLine("CITY_CODE,");
                _sbSql.AppendLine("CITY_NAME,");
                _sbSql.AppendLine("STATE_CODE,");
                // _sbSql.AppendLine("CRESTA_CODE,");
                _sbSql.AppendLine("CRESTA_NAME,");
                _sbSql.AppendLine("ENT_BY,");
                _sbSql.AppendLine("ENT_DATE,");
                _sbSql.AppendLine("Active)");



                _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                //_sbSql.AppendLine("@TxnSysID,");
                _sbSql.AppendLine("@TxnSysDate,");
                _sbSql.AppendLine("@UserCode,");
                _sbSql.AppendLine("@CITY_CODE,");
                _sbSql.AppendLine("@CITY_NAME,");
                _sbSql.AppendLine("@STATE_CODE,");
                // _sbSql.AppendLine("@CRESTA_CODE,");
                _sbSql.AppendLine("@CRESTA_NAME,");
                _sbSql.AppendLine("@ENT_BY,");
                _sbSql.AppendLine("@ENT_DATE,");
                _sbSql.AppendLine("@Active)");





                _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);




                DateTime da = DateTime.Now;
                da.ToString("MM-dd-yyyy h:mm tt");

                _cmdSql.Parameters.AddWithValue("@TxnSysDate", Convert.ToDateTime(da));
                int _userCode = GlobalDataLayer.GetUserCodeById(_MtrCityMdl.UserCode);

                _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);

                _cmdSql.Parameters.AddWithValue("@CITY_CODE", _MtrCityMdl.CITY_CODE);
                _cmdSql.Parameters.AddWithValue("@CITY_NAME", _MtrCityMdl.CITY_NAME);
                _cmdSql.Parameters.AddWithValue("@STATE_CODE", _MtrCityMdl.STATE_CODE);

                // _cmdSql.Parameters.AddWithValue("@CRESTA_CODE", _MtrCityMdl.CRESTA_CODE);
                _cmdSql.Parameters.AddWithValue("@CRESTA_NAME", _MtrCityMdl.CRESTA_NAME ?? DBNull.Value.ToString());
                _cmdSql.Parameters.AddWithValue("@ENT_BY", _MtrCityMdl.ENT_BY);
                _cmdSql.Parameters.AddWithValue("@ENT_DATE", DateTime.Now);
                _cmdSql.Parameters.AddWithValue("@Active", "Y");


                _MtrCityMdl.TxnSysDate = DateTime.Now;

                int _TxnSysId;
                _conSql.Open();
                _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                _conSql.Close();

                _MtrCityMdl.IsValidTxn = true;
                _MtrCityMdl.TxnSysID = _TxnSysId;


                return _MtrCityMdl;

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }

        }

        //for updating existing City
        public MtrCityMdl UpdateCity(MtrCityMdl _MtrCityMdl)
        {
            try
            {

                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();
                SqlCommand _cmdSql;

                _sbSql.AppendLine("Update  MtrCity SET");
                _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
                _sbSql.AppendLine("UserCode= @UserCode,");
                _sbSql.AppendLine("CITY_CODE=@CITY_CODE,");
                _sbSql.AppendLine("CITY_NAME=@CITY_NAME,");
                _sbSql.AppendLine("STATE_CODE=@STATE_CODE");
                

                _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");

                _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                int _userCode = GlobalDataLayer.GetUserCodeById(_MtrCityMdl.UserCode);


                _cmdSql.Parameters.AddWithValue("@TxnSysId", _MtrCityMdl.TxnSysID);
                _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);

                _cmdSql.Parameters.AddWithValue("@CITY_CODE", _MtrCityMdl.CITY_CODE);
                _cmdSql.Parameters.AddWithValue("@CITY_NAME", _MtrCityMdl.CITY_NAME);
                _cmdSql.Parameters.AddWithValue("@STATE_CODE", _MtrCityMdl.STATE_CODE);
         

                _MtrCityMdl.IsValidTxn = true;

                _conSql.Open();
                _cmdSql.ExecuteNonQuery();
                _conSql.Close();

                return _MtrCityMdl;



            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Getting City Name By Code
        public string GetCityNameByCode(string _CityCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                VehicleDetailMdl _VehicleDetailMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrCity Where CITY_CODE = @CityCode", conn);

                    command.Parameters.Add(new SqlParameter("@CityCode", _CityCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.CityName = _tblSqla.Rows[i]["CITY_NAME"].ToString();

                    }
                    return _VehicleDetailMdl.CityName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }


     //---------------- CRUD Ends From Here -------------------//

        //For Increment of Serial Numbers
        public int GetSerialNo(VehicleDetailMdl _VehicleDetailMdl)
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

        //For Getting all VEOD Codes and Names
        public List<MtrVEODMdl> GetVEOD()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrVEOD";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrVEODMdl> _MtrVEODMdlList = new List<MtrVEODMdl>();
                MtrVEODMdl _MtrVEODMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrVEODMdl = new MtrVEODMdl();

                        _MtrVEODMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrVEODMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrVEODMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrVEODMdl.VEODCode = Convert.ToInt32(_tblSqla.Rows[i]["VEODCode"]);
                        _MtrVEODMdl.VEODName = _tblSqla.Rows[i]["VEODName"].ToString();


                        _MtrVEODMdlList.Add(_MtrVEODMdl);


                    }

                    return _MtrVEODMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Getting VEOD Name By Code
        public string GetVEODNameByCode(int _VEODCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                VehicleDetailMdl _VehicleDetailMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrVEOD Where VEODCode = @VEODCode", conn);

                    command.Parameters.Add(new SqlParameter("@VEODCode", _VEODCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.VEODName = _tblSqla.Rows[i]["VEODName"].ToString();

                    }
                    return _VehicleDetailMdl.VEODName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //For Getting all Vehicle Type Codes and Names
        public List<MtrVehicleTypeMdl> GetVehicleType()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrVehicleType";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrVehicleTypeMdl> _MtrVehicleTypeMdlList = new List<MtrVehicleTypeMdl>();
                MtrVehicleTypeMdl _MtrVehicleTypeMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrVehicleTypeMdl = new MtrVehicleTypeMdl();

                        _MtrVehicleTypeMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrVehicleTypeMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrVehicleTypeMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrVehicleTypeMdl.VehicleTypeCode = _tblSqla.Rows[i]["VehicleTypeCode"].ToString();
                        _MtrVehicleTypeMdl.VehicleTypeName = _tblSqla.Rows[i]["VehicleTypeName"].ToString();



                        _MtrVehicleTypeMdlList.Add(_MtrVehicleTypeMdl);


                    }

                    return _MtrVehicleTypeMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Getting Vehicle Type Names by Codes
        public string GetVehicleTypeNameByCode(string _VehicleTypeCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                VehicleDetailMdl _VehicleDetailMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrVehicleType Where VehicleTypeCode = @VehicleTypeCode", conn);

                    command.Parameters.Add(new SqlParameter("@VehicleTypeCode", _VehicleTypeCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.VehicleTypeName = _tblSqla.Rows[i]["VehicleTypeName"].ToString();

                    }
                    return _VehicleDetailMdl.VehicleTypeName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Get All Vehicles Concatinated
        public List<MtrVehicleMdl> GetMtrVehicle()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = 
                "SELECT MM.MAKE_NAME + ' | ' + MV.VEHICLE_NAME  +' | ' + mbt.BODY_NAME +' | '+(CASE WHEN  icc.TYPE = 'H' THEN 'Horse Power' WHEN icc.TYPE = 'C' THEN 'Cubic Capacity' ELSE '' END) + ' | ' + icc.CUBIC_HORSE_TITLE VEHICLE_TEXT, mv.VEHICLE_CODE FROM TmsPlusDB.dbo.MtrVehicle mv INNER JOIN TmsPlusDB.dbo.MtrVMake mm ON mv.MAKE_CODE = mm.MAKE_CODE INNER JOIN TmsPlusDB.dbo.MtrVBodyType mbt ON mv.BODY_TYPE_CODE = mbt.BODY_TYPE_CODE INNER JOIN TmsPlusDB.dbo.MtrVCubicCapacity icc ON mv.CUBIC_HORSE_CODE = icc.CUBIC_HORSE_CODE";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrVehicleMdl> _MtrVehicleMdlList = new List<MtrVehicleMdl>();
                MtrVehicleMdl _MtrVehicleMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrVehicleMdl = new MtrVehicleMdl();

                       // _MtrVehicleMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        //_MtrVehicleMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrVehicleMdl.VEHICLE_TEXT = _tblSqla.Rows[i]["VEHICLE_TEXT"].ToString();
                        _MtrVehicleMdl.VEHICLE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["VEHICLE_CODE"]);


                        _MtrVehicleMdlList.Add(_MtrVehicleMdl);


                    }

                    return _MtrVehicleMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Getting Vehical Name By Code
        public string GetVehicleNameByCode(int _VEHICLE_CODE)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                VehicleDetailMdl _VehicleDetailMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrVehicle Where VEHICLE_CODE = @VEHICLE_CODE", conn);

                    command.Parameters.Add(new SqlParameter("@VEHICLE_CODE", _VEHICLE_CODE));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.VehicleName = _tblSqla.Rows[i]["VEHICLE_NAME"].ToString();

                    }
                    return _VehicleDetailMdl.VehicleName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //To get All Genders
        public List<GendersMdl> GetGenders()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM Genders";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<GendersMdl> _GendersMdlList = new List<GendersMdl>();
                GendersMdl _GendersMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _GendersMdl = new GendersMdl();

                        _GendersMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _GendersMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _GendersMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _GendersMdl.GenderCode = _tblSqla.Rows[i]["GenderCode"].ToString();
                        _GendersMdl.GenderName = _tblSqla.Rows[i]["GenderName"].ToString();



                        _GendersMdlList.Add(_GendersMdl);


                    }

                    return _GendersMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Getting Gender Name By Code
        public string GetGenderNameByCode(string _GenderCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                VehicleDetailMdl _VehicleDetailMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM Genders Where GenderCode = @GenderCode", conn);

                    command.Parameters.Add(new SqlParameter("@GenderCode", _GenderCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.GenderName = _tblSqla.Rows[i]["GenderName"].ToString();

                    }
                    return _VehicleDetailMdl.GenderName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Getting All District/Area By City Code
        public List<MtrDistrictMdl> GetArea(MtrCityMdl _MtrCityMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //string _sqlString = "SELECT * FROM MtrDistrict ";
               // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrDistrictMdl> _MtrDistrictMdlList = new List<MtrDistrictMdl>();
                MtrDistrictMdl _MtrDistrictMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrDistrict Where CITY_CODE = @CITY_CODE", conn);

                    command.Parameters.Add(new SqlParameter("@CITY_CODE", _MtrCityMdl.CITY_CODE));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

               // _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrDistrictMdl = new MtrDistrictMdl();

                       // _MtrDistrictMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        //_MtrDistrictMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                       // _MtrDistrictMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrDistrictMdl.DISTRICT_CODE = Convert.ToInt32(_tblSqla.Rows[i]["DISTRICT_CODE"]);
                        _MtrDistrictMdl.DISTRICT_NAME = _tblSqla.Rows[i]["DISTRICT_NAME"].ToString();
                        _MtrDistrictMdl.CITY_CODE = Convert.ToInt32(_tblSqla.Rows[i]["CITY_CODE"]);
                       // _MtrDistrictMdl.ENT_BY = _tblSqla.Rows[i]["ENT_BY"].ToString();
                       // _MtrDistrictMdl.ENT_DATE = Convert.ToDateTime(_tblSqla.Rows[i]["ENT_DATE"]);





                        _MtrDistrictMdlList.Add(_MtrDistrictMdl);


                    }

                    return _MtrDistrictMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Get District/Area Name by Code
        public string GetAreaNameByCode(int _DISTRICT_CODE)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                VehicleDetailMdl _VehicleDetailMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrDistrict Where DISTRICT_CODE = @DISTRICT_CODE", conn);

                    command.Parameters.Add(new SqlParameter("@DISTRICT_CODE", _DISTRICT_CODE));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.AreaName = _tblSqla.Rows[i]["DISTRICT_NAME"].ToString();

                    }
                    return _VehicleDetailMdl.AreaName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Get all Certificate Types
        public List<MtrInsCertMdl> GetCert()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrCertificateInsurance";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrInsCertMdl> _MtrInsCertMdlList = new List<MtrInsCertMdl>();
                MtrInsCertMdl _MtrInsCertMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrInsCertMdl = new MtrInsCertMdl();

                        //_MtrInsCertMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        //_MtrInsCertMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        //_MtrInsCertMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        //_MtrInsCertMdl.CERTIFICATE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["CERTIFICATE_CODE"]);
                        //_MtrInsCertMdl.DRIVER = _tblSqla.Rows[i]["DRIVER"].ToString();
                        //_MtrInsCertMdl.USAGE_LIMITATION = _tblSqla.Rows[i]["USAGE_LIMITATION"].ToString();
                        //_MtrInsCertMdl.CERTIFICATE_TYPE = _tblSqla.Rows[i]["CERTIFICATE_TYPE"].ToString();

                        _MtrInsCertMdl.CertInsureCode = _tblSqla.Rows[i]["CertInsureCode"].ToString();
                        _MtrInsCertMdl.CertInsureName = _tblSqla.Rows[i]["CertInsureName"].ToString();
                        _MtrInsCertMdl.PolicyTypeCode = _tblSqla.Rows[i]["PolicyTypeCode"].ToString();


                        _MtrInsCertMdlList.Add(_MtrInsCertMdl);


                    }

                    return _MtrInsCertMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Get Cert Type Name by Code
        public string GetCertTypeByCode(string _CERTIFICATE_CODE)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                // string _sqlString = "SELECT* FROM MasterProductSetup Where ProductCode = "+ _MasterProductSetupMdl.ProductCode;
                //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                VehicleDetailMdl _VehicleDetailMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrInsCert Where CERTIFICATE_CODE = @CERTIFICATE_CODE", conn);

                    command.Parameters.Add(new SqlParameter("@CERTIFICATE_CODE", _CERTIFICATE_CODE));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.CertTypeName = _tblSqla.Rows[i]["CERTIFICATE_TYPE"].ToString();

                    }
                    return _VehicleDetailMdl.CertTypeName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
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
                VehicleDetailMdl _VehicleDetailMdl;

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
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.InsuranceTypeName = _tblSqla.Rows[i]["INSURANCE_TYPE_TITLE"].ToString();

                    }
                    return _VehicleDetailMdl.InsuranceTypeName;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //To Calculate Net Value
        public decimal calculate(VehicleDetailMdl _VehicleDetailMdl)
        {

            decimal rate = _VehicleDetailMdl.Rate;
            decimal SumCovered = _VehicleDetailMdl.PreviousValue;

            decimal net = SumCovered * (rate / 100);
            decimal stamp = 50;

            decimal total1 = net - stamp;
            decimal gross = total1 / Convert.ToDecimal(1.14);

            decimal fif = gross * Convert.ToDecimal(0.01);
            decimal fed = gross * Convert.ToDecimal(0.13);

            decimal total = gross + fif + fed + stamp;

            return total;



        }

        //Get Rate from rating factor by using Open Policy TxnSysID
        public ProductRatingFactorSetUpMdl GetRatingFactor(MtrOpenPolicyMdl _MtrOpenPolicyMdl) {

            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //string _sqlString = "SELECT * FROM MtrDistrict ";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MtrDistrictMdl> _MtrDistrictMdlList = new List<MtrDistrictMdl>();
                ProductRatingFactorSetUpMdl _ProductRatingFactorSetUpMdl = new ProductRatingFactorSetUpMdl();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT pp.* FROM ProductRatingFactorsProductSetup pp INNER JOIN MasterProductSetup mp ON pp.PrdStpTxnSysId = mp.TxnSysID  INNER JOIN MtrOpenPolicy mop ON mop.ProductCode = mp.ProductCode WHERE mop.TxnSysID = @TxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@TxnSysID", _MtrOpenPolicyMdl.TxnSysID));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                // _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductRatingFactorSetUpMdl = new ProductRatingFactorSetUpMdl();

                        _ProductRatingFactorSetUpMdl.Rate = Convert.ToInt32(_tblSqla.Rows[i]["Rate"]);
                        _ProductRatingFactorSetUpMdl.RatingFactor = _tblSqla.Rows[i]["RatingFactor"].ToString();
                        _ProductRatingFactorSetUpMdl.IsEditable= _tblSqla.Rows[i]["IsEditable"].ToString();

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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }

        }

        //Get Conditions from product set up By Client Code
        public List<ProductConditionsSetupMdl> GetConditionByClient(ProductClientMdl _ProductClientMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //string _sqlString = "SELECT * FROM MtrDistrict ";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MtrDistrictMdl> _MtrDistrictMdlList = new List<MtrDistrictMdl>();
                ProductConditionsSetupMdl _ProductConditionsSetupMdl = new ProductConditionsSetupMdl();
                List<ProductConditionsSetupMdl> _ProductConditionsSetupMdlList = new List<ProductConditionsSetupMdl>();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT pcps.* FROM ProductConditionsProductSetup pcps INNER JOIN MasterProductSetup mps ON mps.TxnSysID = pcps.PrdStpTxnSysId WHERE mps.Client = @Client", conn);

                    command.Parameters.Add(new SqlParameter("@Client", _ProductClientMdl.ClientCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                // _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductConditionsSetupMdl = new ProductConditionsSetupMdl();

                        _ProductConditionsSetupMdl = new ProductConditionsSetupMdl();
                        _ProductConditionsSetupMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _ProductConditionsSetupMdl.PrdStpTxnSysId = Convert.ToInt32(_tblSqla.Rows[i]["PrdStpTxnSysId"]);
                        _ProductConditionsSetupMdl.Condition = _tblSqla.Rows[i]["Condition"].ToString();
                        _ProductConditionsSetupMdl.ConditionShText = GetConditionByCode(_tblSqla.Rows[i]["Condition"].ToString());
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }

        }


        //Get Waranties from product set up By Client Code
        public List<ProductWarrantiesSetupMdl> GetWarrantyByClient(ProductClientMdl _ProductClientMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //string _sqlString = "SELECT * FROM MtrDistrict ";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MtrDistrictMdl> _MtrDistrictMdlList = new List<MtrDistrictMdl>();
                ProductWarrantiesSetupMdl _ProductWarrantiesSetupMdl = new ProductWarrantiesSetupMdl();
                List<ProductWarrantiesSetupMdl> _ProductWarrantiesSetupMdlList = new List<ProductWarrantiesSetupMdl>();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT pcps.* FROM ProductWarrantiesProductSetup pcps INNER JOIN MasterProductSetup mps ON mps.TxnSysID = pcps.PrdStpTxnSysId WHERE mps.Client = @Client", conn);

                    command.Parameters.Add(new SqlParameter("@Client", _ProductClientMdl.ClientCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                // _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductWarrantiesSetupMdl = new ProductWarrantiesSetupMdl();

                        _ProductWarrantiesSetupMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _ProductWarrantiesSetupMdl.PrdStpTxnSysId = Convert.ToInt32(_tblSqla.Rows[i]["PrdStpTxnSysId"]);
                        _ProductWarrantiesSetupMdl.Warranty = _tblSqla.Rows[i]["Warranty"].ToString();
                        _ProductWarrantiesSetupMdl.WarrantyShText = GetWarrantyTextByCode(_tblSqla.Rows[i]["Warranty"].ToString());
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }

        }


        //Get Trackers from product set up By Client Code
        public List<ProductTrackerSetupMdl> GetTrackerByClient(ProductClientMdl _ProductClientMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //string _sqlString = "SELECT * FROM MtrDistrict ";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
              
                ProductTrackerSetupMdl _ProductTrackerSetupMdl = new ProductTrackerSetupMdl();
                List<ProductTrackerSetupMdl> _ProductTrackerSetupMdlList = new List<ProductTrackerSetupMdl>();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT pcps.* FROM ProductTrackerSetup pcps INNER JOIN MasterProductSetup mps ON mps.TxnSysID = pcps.PrdStpTxnSysId WHERE mps.Client = @Client", conn);

                    command.Parameters.Add(new SqlParameter("@Client", _ProductClientMdl.ClientCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                // _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductTrackerSetupMdl = new ProductTrackerSetupMdl();

                       // _ProductTrackerSetupMdl.TxnSysID = Convert.ToInt32(_tblSql.Rows[i]["TxnSysID"]);
                       // _ProductTrackerSetupMdl.TxnSysDate = Convert.ToDateTime(_tblSql.Rows[i]["TxnSysDate"]);
                       // _ProductTrackerSetupMdl.UserCode = Convert.ToInt32(_tblSql.Rows[i]["UserCode"]);
                        _ProductTrackerSetupMdl.TrackerCode = Convert.ToInt32(_tblSqla.Rows[i]["TrackerCode"]);
                        _ProductTrackerSetupMdl.TrackerName = _tblSqla.Rows[i]["TrackerName"].ToString();
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }

        }

        //Get Rider from product set up By Client Code
        public List<ProductRiderSetupMdl> GetRidersByClient(ProductClientMdl _ProductClientMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                //string _sqlString = "SELECT * FROM MtrDistrict ";
                // SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();

                ProductRiderSetupMdl _ProductRiderSetupMdl = new ProductRiderSetupMdl();
                List<ProductRiderSetupMdl> _ProductRiderSetupMdlList = new List<ProductRiderSetupMdl>();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT pcps.* FROM ProductRiderSetup pcps INNER JOIN MasterProductSetup mps ON mps.TxnSysID = pcps.PrdStpTxnSysId WHERE mps.Client = @Client", conn);

                    command.Parameters.Add(new SqlParameter("@Client", _ProductClientMdl.ClientCode));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                // _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _ProductRiderSetupMdl = new ProductRiderSetupMdl();


                       // _ProductRiderSetupMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                      //  _ProductRiderSetupMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                      //  _ProductRiderSetupMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }

        }

        //Calculate Contribution by rate and value
        public Calc GetCalc(Calc _calc)
        {
            _calc.total = _calc.value * (_calc.rate/100);
            return _calc;
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
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
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Get uniquue Serial number for different policy number
        public static int GetUniqueSerialNo(MtrInsPolicyMdl _MtrInsPolicyMdl1)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(mvd.SerialNo) MaxSerialNo FROM MtrVehicleDetails mvd WHERE mvd.ParentTxnSysID = (SELECT MAX(ParentTxnSysID) FROM InsPolicy)";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                MtrInsPolicyMdl _MtrInsPolicyMdl;


                int _result = 0;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrInsPolicyMdl = new MtrInsPolicyMdl();

                        if (Convert.ToInt32(_tblSqla.Rows[i]["MaxOpolTxnSysID"]) == _MtrInsPolicyMdl1.OpolTxnSysID)

                            _result = 1;


                    }


                }
                else
                {
                    int _tmpNumber = Convert.ToInt32(_tblSqla.Rows[0][0]) + 1;
                    _result = _tmpNumber;
                }

                return _result;
            }
            catch (Exception ex)
            {

                return 0;
            }

        }

        //for getting Warranty Text From Warranty Code (200 or 201) 
        public int GetMaxParentTxnSysID()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(ParentTxnSysID) LastParentID FROM InsPolicy";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                VehicleDetailMdl _VehicleDetailMdl;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _VehicleDetailMdl = new VehicleDetailMdl();
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {

                        _VehicleDetailMdl.ParentTxnSysID = Convert.ToInt32(_tbl.Rows[i]["LastParentID"]);

                    }
                    return _VehicleDetailMdl.ParentTxnSysID;

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

    //----------------- For Co Insurance ----------------//


        //for checking Insurance Type / Takaful Type in Motor Vehicle Certificates
        public bool IsCo(VehicleDetailMdl _VehicleDetailMdl)

        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();

                string _sqlString = "SELECT InsuranceTypeCode FROM MtrVehicleDetails WHERE TxnSysID = " + _VehicleDetailMdl.TxnSysID;
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<VehicleDetailMdl> _VehicleDetailMdlList = new List<VehicleDetailMdl>();
                DuplicationCheck _duplicationCheck = new DuplicationCheck();
                int InsTypeCode = 0;



                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _VehicleDetailMdl = new VehicleDetailMdl();
                        _VehicleDetailMdl.InsuranceTypeCode = Convert.ToInt32(_tblSqla.Rows[i]["InsuranceTypeCode"]);
                        InsTypeCode = _VehicleDetailMdl.InsuranceTypeCode;
                    }

                    if (InsTypeCode == 1 || InsTypeCode == 4)
                    {
                        return false;
                    }

                    else if (InsTypeCode == 2 || InsTypeCode == 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }



            }
            catch (Exception ex)
            {
                return true;
            }
        }


        //Get All CoInsurance by Vehicle TxnSysID
        public List<InsCoInsurance> GetAllCoContribution(VehicleDetailMdl _VehicleDetailMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                 string _sqlString = "SELECT *  FROM InsCoInsuance Where RiskTxnID =" + _VehicleDetailMdl.TxnSysID;
                  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                // List<MasterProductSetupMdl> _MasterProductSetupMdlList = new List<MasterProductSetupMdl>();
                // MasterProductSetupMdl masterProductSetupMdl;
                InsCoInsurance _InsCoInsurance = new InsCoInsurance();
                List<InsCoInsurance> _InsCoInsuranceList = new List<InsCoInsurance>();

                //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                //{
                //    SqlCommand command =
                //        new SqlCommand("SELECT *  FROM InsCoInsuance Where RiskTxnID = @RiskTxnID", conn);

                //    command.Parameters.Add(new SqlParameter("@RiskTxnID", _VehicleDetailMdl.TxnSysID));

                //    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                //    _adpSql.Fill(_tblSqla);
                //}

                 _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                   
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {

                        _InsCoInsurance = new InsCoInsurance();

                        _InsCoInsurance.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _InsCoInsurance.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _InsCoInsurance.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);


                       // _InsCoInsurance.NetContribution = Convert.ToDecimal(_tblSqla.Rows[i]["NetContribution"]);
                       // _InsCoInsurance.GrossContribution = Convert.ToDecimal(_tblSqla.Rows[i]["GrossContribution"]);
                        _InsCoInsurance.FIF = Convert.ToDecimal(_tblSqla.Rows[i]["FIF"]);
                        _InsCoInsurance.FED = Convert.ToDecimal(_tblSqla.Rows[i]["FED"]);
                        _InsCoInsurance.CoInsuranceCode = Convert.ToInt32(_tblSqla.Rows[i]["CoInsuranceCode"]);
                        _InsCoInsurance.CoInsuranceShare = Convert.ToDecimal(_tblSqla.Rows[i]["CoInsuranceShare"]);


                        _InsCoInsurance.PartTakerName = GetParttakerNameByCode(Convert.ToInt32(_tblSqla.Rows[i]["CoInsuranceCode"]));

                        _InsCoInsurance.GrossContribution = Decimal.Round(Convert.ToDecimal(_tblSqla.Rows[i]["GrossContribution"]),  MidpointRounding.ToEven);
                      //  _InsCoInsurance.PEV = Decimal.Round(Convert.ToDecimal(_tblSqla.Rows[i]["PEV"]),  MidpointRounding.ToEven);
                        _InsCoInsurance.NetContribution = Decimal.Round(Convert.ToDecimal(_tblSqla.Rows[i]["NetContribution"]),  MidpointRounding.ToEven);
                     //   _InsCoInsurance.BeforePEV = Decimal.Round(Convert.ToDecimal(_tblSqla.Rows[i]["BeforePEV"]),  MidpointRounding.ToEven);


                        _InsCoInsuranceList.Add(_InsCoInsurance);
                    }
                    return _InsCoInsuranceList;

                }


                else
                {

                    return null;

                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Insert into CoInsurance Contribution
        public InsCoInsurance CalcCoContribution(VehicleDetailMdl _VehicleDetailMdl, InsCoInsurance _InsCoInsurance1)
            
        {

            List<InsCoInsurance> _InsCoInsuranceList = new List<InsCoInsurance>();


            InsCoInsurance _InsCoInsurance = new InsCoInsurance();

            if (IsHundred(_VehicleDetailMdl, _InsCoInsurance1) == true)
            {
                List<TxnError> _txnErrors = new List<TxnError>();
                TxnError _txnError = new TxnError();
                _InsCoInsurance.IsValidTxn = false;
                _txnError.ErrorCode = "1006";
                _txnError.Error = "The CoInsurers share can not be more than 100";
                _txnError.TxnSysDate = DateTime.Now;

                _txnErrors.Add(_txnError);
                _txnErrors.Add(_txnError);

                //To Return model
                _InsCoInsurance.TxnErrors = _txnErrors;
                _InsCoInsurance.TxnSysDate = DateTime.Now;

                return _InsCoInsurance;

            }

            

            else
            {

                int userCode = 0, SumCovered = 0, RiskID = 0, CoInsCode = 0, OpolTxnSysID = 0,SumC = 0;
                decimal rate = 0, NetC = 0, GrossC = 0, FIF = 0, FED = 0, Stamp = 0, BasicC = 0, PEV = 0, BPEV = 0, TerrC = 0, CoInsShare = 0, PerDay = 0,CoNet = 0,CoGross = 0;

                //Get Data from Ins Contribution
                DataTable _tblSqla = new DataTable();

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT * FROM InsContribution mic INNER JOIN MtrVehicleDetails mvd ON mvd.TxnSysID = mic.RiskTxnID WHERE mvd.TxnSysID =  @TxnSysID", conn);

                    command.Parameters.Add(new SqlParameter("@TxnSysID", _VehicleDetailMdl.TxnSysID));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }

                // _adpSql.Fill(_tbl);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _InsCoInsurance = new InsCoInsurance();


                        _InsCoInsurance.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        userCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);

                        _InsCoInsurance.SumCovered = Convert.ToInt32(_tblSqla.Rows[i]["SumCovered"]);
                        SumCovered = Convert.ToInt32(_tblSqla.Rows[i]["SumCovered"]);

                        _InsCoInsurance.Rate = Convert.ToDecimal(_tblSqla.Rows[i]["Rate"]);
                        rate = Convert.ToDecimal(_tblSqla.Rows[i]["Rate"]);

                        _InsCoInsurance.NetContribution = Convert.ToDecimal(_tblSqla.Rows[i]["NetContribution"]);
                        NetC = Convert.ToDecimal(_tblSqla.Rows[i]["NetContribution"]);

                        _InsCoInsurance.GrossContribution = Convert.ToDecimal(_tblSqla.Rows[i]["GrossContribution"]);
                        GrossC = Convert.ToDecimal(_tblSqla.Rows[i]["GrossContribution"]);

                        _InsCoInsurance.FIF = Convert.ToDecimal(_tblSqla.Rows[i]["FIF"]);
                        FIF = Convert.ToDecimal(_tblSqla.Rows[i]["FIF"]);

                        _InsCoInsurance.FED = Convert.ToDecimal(_tblSqla.Rows[i]["FED"]);
                        FED = Convert.ToDecimal(_tblSqla.Rows[i]["FED"]);

                        _InsCoInsurance.Stamp = Convert.ToDecimal(_tblSqla.Rows[i]["Stamp"]);
                        Stamp = Convert.ToDecimal(_tblSqla.Rows[i]["Stamp"]);

                        _InsCoInsurance.BasicContribution = Convert.ToDecimal(_tblSqla.Rows[i]["BasicContribution"]);
                        BasicC = Convert.ToDecimal(_tblSqla.Rows[i]["BasicContribution"]);

                        _InsCoInsurance.PEV = Convert.ToDecimal(_tblSqla.Rows[i]["PEV"]);
                        PEV = Convert.ToDecimal(_tblSqla.Rows[i]["PEV"]);

                        _InsCoInsurance.BeforePEV = Convert.ToDecimal(_tblSqla.Rows[i]["BeforePEV"]);
                        BPEV = Convert.ToDecimal(_tblSqla.Rows[i]["BeforePEV"]);

                        _InsCoInsurance.TerrorContribution = Convert.ToDecimal(_tblSqla.Rows[i]["TerrorContribution"]);
                        TerrC = Convert.ToDecimal(_tblSqla.Rows[i]["TerrorContribution"]);

                        _InsCoInsurance.RiskTxnID = Convert.ToInt32(_tblSqla.Rows[i]["RiskTxnID"]);
                        RiskID = Convert.ToInt32(_tblSqla.Rows[i]["RiskTxnID"]);



                        _InsCoInsurance.PerDayContribution = Convert.ToDecimal(_tblSqla.Rows[i]["PerDayContribution"]);
                        PerDay = Convert.ToDecimal(_tblSqla.Rows[i]["PerDayContribution"]);

                        _InsCoInsurance.OpolTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["OpolTxnSysID"]);
                        OpolTxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["OpolTxnSysID"]);

                        //  _InsCoInsuranceList.Add(_InsCoInsurance);


                    }



                    //To get Tenure
                    DataTable _tbl = new DataTable();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                    {
                        SqlCommand command =
                            new SqlCommand("SELECT DATEDIFF(DAY, ip.EffectiveDate,ip.ExpiryDate ) tenure FROM InsPolicy ip INNER JOIN MtrVehicleDetails mvd ON ip.ParentTxnSysID = mvd.ParentTxnSysID WHERE mvd.TxnSysID = @TxnSysID", conn);

                        command.Parameters.Add(new SqlParameter("@TxnSysID", _VehicleDetailMdl.TxnSysID));

                        SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                        _adpSql.Fill(_tbl);
                    }

                    // _adpSql.Fill(_tbl);

                    if (_tbl.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tbl.Rows.Count; i++)
                        {
                            _InsCoInsurance = new InsCoInsurance();
                            _InsCoInsurance.Tenure = Convert.ToInt32(_tbl.Rows[i]["tenure"]);

                        }


                    }
                    else
                    {
                        _InsCoInsurance.Tenure = 1;
                    }


                    _InsCoInsurance.UserCode = userCode;
                    _InsCoInsurance.Rate = rate;
                    _InsCoInsurance.FIF = FIF;
                    _InsCoInsurance.FED = FED;
                    _InsCoInsurance.Stamp = Stamp;
                    _InsCoInsurance.BasicContribution = BasicC;
                    _InsCoInsurance.PEV = PEV;
                    _InsCoInsurance.BeforePEV = BPEV;
                    _InsCoInsurance.TerrorContribution = TerrC;
                    _InsCoInsurance.RiskTxnID = RiskID;
                    _InsCoInsurance.OpolTxnSysID = OpolTxnSysID;

                    CoInsCode = _InsCoInsurance1.CoInsuranceCode;
                    CoInsShare = _InsCoInsurance1.CoInsuranceShare;

                    int SumCo = Convert.ToInt32(SumCovered * (CoInsShare / 100));
                    decimal NetCo = NetC * (CoInsShare / 100);
                    decimal GrossCo = GrossC * (CoInsShare / 100);
                    decimal PerDayCo = GrossCo / _InsCoInsurance.Tenure;


                    _InsCoInsurance.SumCovered = SumCo;
                    _InsCoInsurance.NetContribution = NetCo;
                    _InsCoInsurance.GrossContribution = GrossCo;
                    _InsCoInsurance.PerDayContribution = PerDayCo;

                    _InsCoInsurance.CoInsuranceCode = CoInsCode;
                    _InsCoInsurance.CoInsuranceShare = CoInsShare;

                    _InsCoInsurance.PartTakerName = GetParttakerNameByCode(_InsCoInsurance1.CoInsuranceCode);
                    _InsCoInsurance.IsValidTxn = true;


                    //Insert into database
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("INSERT INTO InsCoInsuance(");
                    //_sbSql.AppendLine("TxnSysID,");
                    _sbSql.AppendLine("TxnSysDate,");
                    _sbSql.AppendLine("UserCode,");
                    _sbSql.AppendLine("SumCovered,");
                    _sbSql.AppendLine("Rate,");
                    _sbSql.AppendLine("NetContribution,");
                    _sbSql.AppendLine("GrossContribution,");
                    _sbSql.AppendLine("FIF,");
                    _sbSql.AppendLine("FED,");
                    _sbSql.AppendLine("Stamp,");
                    _sbSql.AppendLine("BasicContribution,");
                    _sbSql.AppendLine("PEV,");
                    _sbSql.AppendLine("BeforePEV,");
                    _sbSql.AppendLine("TerrorContribution,");
                    _sbSql.AppendLine("RiskTxnID,");
                    _sbSql.AppendLine("OpolTxnSysID,");
                    _sbSql.AppendLine("PerDayContribution,");

                    _sbSql.AppendLine("CoInsuranceCode,");
                    _sbSql.AppendLine("CoInsuranceShare)");


                    _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");

                    //_sbSql.AppendLine("@TxnSysID,");
                    _sbSql.AppendLine("@TxnSysDate,");
                    _sbSql.AppendLine("@UserCode,");
                    _sbSql.AppendLine("@SumCovered,");
                    _sbSql.AppendLine("@Rate,");
                    _sbSql.AppendLine("@NetContribution,");
                    _sbSql.AppendLine("@GrossContribution,");
                    _sbSql.AppendLine("@FIF,");
                    _sbSql.AppendLine("@FED,");
                    _sbSql.AppendLine("@Stamp,");
                    _sbSql.AppendLine("@BasicContribution,");
                    _sbSql.AppendLine("@PEV,");
                    _sbSql.AppendLine("@BeforePEV,");
                    _sbSql.AppendLine("@TerrorContribution,");
                    _sbSql.AppendLine("@RiskTxnID,");
                    _sbSql.AppendLine("@OpolTxnSysID,");
                    _sbSql.AppendLine("@PerDayContribution,");
                    _sbSql.AppendLine("@CoInsuranceCode,");
                    _sbSql.AppendLine("@CoInsuranceShare)");


                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql.Parameters.AddWithValue("@SumCovered", SumCo);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_InsCoInsurance.UserCode);

                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);


                    _cmdSql.Parameters.AddWithValue("@Rate", _InsCoInsurance.Rate);
                    _cmdSql.Parameters.AddWithValue("@NetContribution", NetCo);
                    _cmdSql.Parameters.AddWithValue("@GrossContribution", GrossCo);
                    _cmdSql.Parameters.AddWithValue("@FIF", _InsCoInsurance.FIF);
                    _cmdSql.Parameters.AddWithValue("@FED", _InsCoInsurance.FED);
                    _cmdSql.Parameters.AddWithValue("@Stamp", _InsCoInsurance.Stamp);
                    _cmdSql.Parameters.AddWithValue("@BasicContribution", _InsCoInsurance.BasicContribution);
                    _cmdSql.Parameters.AddWithValue("@PEV", _InsCoInsurance.PEV);
                    _cmdSql.Parameters.AddWithValue("@BeforePEV", _InsCoInsurance.BeforePEV);
                    _cmdSql.Parameters.AddWithValue("@TerrorContribution", _InsCoInsurance.TerrorContribution);
                    _cmdSql.Parameters.AddWithValue("@RiskTxnID", _InsCoInsurance.RiskTxnID);
                    _cmdSql.Parameters.AddWithValue("@OpolTxnSysID", _InsCoInsurance.OpolTxnSysID);
                    _cmdSql.Parameters.AddWithValue("@PerDayContribution", PerDayCo);
                    _cmdSql.Parameters.AddWithValue("@CoInsuranceCode", _InsCoInsurance.CoInsuranceCode);
                    _cmdSql.Parameters.AddWithValue("@CoInsuranceShare", _InsCoInsurance.CoInsuranceShare);


                    int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();


                    _InsCoInsurance.GrossContribution = Decimal.Round(_InsCoInsurance.GrossContribution,  MidpointRounding.ToEven);
                    _InsCoInsurance.PEV = Decimal.Round(_InsCoInsurance.PEV,  MidpointRounding.ToEven);
                   // _InsCoInsurance.SumCovered = Decimal.Round(_InsCoInsurance.SumCovered,  MidpointRounding.ToEven);
                    _InsCoInsurance.NetContribution = Decimal.Round(_InsCoInsurance.NetContribution,  MidpointRounding.ToEven);
                    _InsCoInsurance.BeforePEV = Decimal.Round(_InsCoInsurance.BeforePEV,  MidpointRounding.ToEven);

                    _InsCoInsurance.IsValidTxn = true;

                    _InsCoInsurance.TxnSysID = _TxnSysId;

                    _InsCoInsurance.IsValidTxn = true;


                    _InsCoInsuranceList.Add(_InsCoInsurance);

                    //return _InsCoInsuranceList;

                    return _InsCoInsurance;
                }
                else
                {
                    return null;
                }
            }

        }

        //Update CoInsurance Contribution
        public InsCoInsurance UpdateCalcCoContribution(InsCoInsurance _InsCoInsurance)
        {
            try
            {


                if (IsHundredU(_InsCoInsurance) == true)
                {
                    List<TxnError> _txnErrors = new List<TxnError>();
                    TxnError _txnError = new TxnError();
                    _InsCoInsurance.IsValidTxn = false;
                    _txnError.ErrorCode = "1006";
                    _txnError.Error = "The CoInsurers share can not be more than 100";
                    _txnError.TxnSysDate = DateTime.Now;

                    _txnErrors.Add(_txnError);
                    _txnErrors.Add(_txnError);

                    //To Return model
                    _InsCoInsurance.TxnErrors = _txnErrors;
                    _InsCoInsurance.TxnSysDate = DateTime.Now;

                    return _InsCoInsurance;

                }

                else
                {
                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;

                    _sbSql.AppendLine("Update InsCoInsuance SET");
                    _sbSql.AppendLine("TxnSysDate= @TxnSysDate,");
                    _sbSql.AppendLine("UserCode= @UserCode,");
                    _sbSql.AppendLine("CoInsuranceCode=@CoInsuranceCode,");
                    _sbSql.AppendLine("CoInsuranceShare=@CoInsuranceShare,");
                    _sbSql.AppendLine("NetContribution=@NetContribution");

                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");

                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_InsCoInsurance.UserCode);

                    decimal GrossC = _InsCoInsurance.GrossContribution;
                    decimal NetC = GrossC * (_InsCoInsurance.CoInsuranceShare / 100);

                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _InsCoInsurance.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", DateTime.Now);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);
                    _cmdSql.Parameters.AddWithValue("@CoInsuranceCode", _InsCoInsurance.CoInsuranceCode);
                    _cmdSql.Parameters.AddWithValue("@CoInsuranceShare", _InsCoInsurance.CoInsuranceShare);
                    _cmdSql.Parameters.AddWithValue("@NetContribution", NetC);

                    _InsCoInsurance.IsValidTxn = true;

                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    _InsCoInsurance.GrossContribution = Decimal.Round(_InsCoInsurance.GrossContribution,  MidpointRounding.ToEven);
                    _InsCoInsurance.PEV = Decimal.Round(_InsCoInsurance.PEV,  MidpointRounding.ToEven);
                    // _InsCoInsurance.SumCovered = Decimal.Round(_InsCoInsurance.SumCovered,  MidpointRounding.ToEven);
                    _InsCoInsurance.NetContribution = Decimal.Round(_InsCoInsurance.NetContribution,  MidpointRounding.ToEven);
                    _InsCoInsurance.BeforePEV = Decimal.Round(_InsCoInsurance.BeforePEV,  MidpointRounding.ToEven);


                    return _InsCoInsurance;

               }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Get CoInsElement DDL
        public List<CoInsElementMdl> GetCoInsElement()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM CoInsElement";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<CoInsElementMdl> _CoInsElementMdlList = new List<CoInsElementMdl>();
                CoInsElementMdl _CoInsElementMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _CoInsElementMdl = new CoInsElementMdl();

                        _CoInsElementMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _CoInsElementMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _CoInsElementMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _CoInsElementMdl.ElemetID = Convert.ToInt32(_tblSqla.Rows[i]["ElemetID"]);
                        _CoInsElementMdl.ElementName = _tblSqla.Rows[i]["ElementName"].ToString();
                        _CoInsElementMdl.ElementCode = Convert.ToInt32(_tblSqla.Rows[i]["ElementCode"]);

                        _CoInsElementMdlList.Add(_CoInsElementMdl);


                    }

                    return _CoInsElementMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Detail DataLayer");
                return null;
            }
        }

        //Update FIF , FED , Gross or Net in CoInsurance Contribution
        public InsCoInsurance UpdateCalcCoContributionByElement(InsCoInsurance _InsCoInsurance, CoInsElementMdl _CoInsElementMdl)
        {
            try
            {

                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();
                SqlCommand _cmdSql;

                decimal Net = 0, Gross = 0;
               

                SqlConnection _conSql1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                DataTable _tblSqla1 = new DataTable();
                InsCoInsurance _InsCoInsurance2 = new InsCoInsurance(); 
               

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM InsCoInsuance Where TxnSysId = @TxnSysId", conn);

                    command.Parameters.Add(new SqlParameter("@TxnSysId", _InsCoInsurance.TxnSysID));

                    SqlDataAdapter _adpSql1 = new SqlDataAdapter(command);


                    _adpSql1.Fill(_tblSqla1);
                }

                //  _adpSql.Fill(_tblSqla);

                if (_tblSqla1.Rows.Count > 0)
                {
                    _InsCoInsurance2 = new InsCoInsurance();
                    for (int i = 0; i < _tblSqla1.Rows.Count; i++)
                    {

                        _InsCoInsurance2.TxnSysID = Convert.ToInt32(_tblSqla1.Rows[i]["TxnSysID"]);
                        _InsCoInsurance2.TxnSysDate = Convert.ToDateTime(_tblSqla1.Rows[i]["TxnSysDate"]);
                        _InsCoInsurance2.UserCode = Convert.ToInt32(_tblSqla1.Rows[i]["UserCode"]);


                        _InsCoInsurance2.NetContribution = Convert.ToDecimal(_tblSqla1.Rows[i]["NetContribution"]);
                        _InsCoInsurance2.GrossContribution = Convert.ToDecimal(_tblSqla1.Rows[i]["GrossContribution"]);
                        _InsCoInsurance2.FIF = Convert.ToDecimal(_tblSqla1.Rows[i]["FIF"]);
                        _InsCoInsurance2.FED = Convert.ToDecimal(_tblSqla1.Rows[i]["FED"]);
                        _InsCoInsurance2.CoInsuranceCode = Convert.ToInt32(_tblSqla1.Rows[i]["CoInsuranceCode"]);
                        _InsCoInsurance2.CoInsuranceShare = Convert.ToDecimal(_tblSqla1.Rows[i]["CoInsuranceShare"]);


                        _InsCoInsurance2.PartTakerName = GetParttakerNameByCode(Convert.ToInt32(_tblSqla1.Rows[i]["CoInsuranceCode"]));

                        _InsCoInsurance2.GrossContribution = Decimal.Round(Convert.ToDecimal(_tblSqla1.Rows[i]["GrossContribution"]),  MidpointRounding.ToEven);
                        _InsCoInsurance2.PEV = Decimal.Round(Convert.ToDecimal(_tblSqla1.Rows[i]["PEV"]),  MidpointRounding.ToEven);
                        _InsCoInsurance2.NetContribution = Decimal.Round(Convert.ToDecimal(_tblSqla1.Rows[i]["NetContribution"]),  MidpointRounding.ToEven);
                        _InsCoInsurance2.BeforePEV = Decimal.Round(Convert.ToDecimal(_tblSqla1.Rows[i]["BeforePEV"]),  MidpointRounding.ToEven);

                    }
                    
                }


                else
                {

                    

                }


                //Update Gross
                if (_CoInsElementMdl.ElementCode == 1)
                {

                    _sbSql.AppendLine("Update InsCoInsuance SET");
                    _sbSql.AppendLine("GrossContribution=@GrossContribution,");
                    _sbSql.AppendLine("NetContribution=@NetContribution,");
                    _sbSql.AppendLine("FIF=@FIF,");
                    _sbSql.AppendLine("FED=@FED");
                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");


                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_InsCoInsurance.UserCode);


                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _InsCoInsurance.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@GrossContribution", _InsCoInsurance.GrossContribution);

                    Net = (_InsCoInsurance.GrossContribution + _InsCoInsurance2.Stamp) * (((_InsCoInsurance2.FIF + _InsCoInsurance2.FED) / 100) + 1);

                    _cmdSql.Parameters.AddWithValue("@NetContribution", Net);
                    _cmdSql.Parameters.AddWithValue("@FIF", _InsCoInsurance2.FIF);
                    _cmdSql.Parameters.AddWithValue("@FED", _InsCoInsurance2.FED);

                    _InsCoInsurance.IsValidTxn = true;

                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    return _InsCoInsurance;

                }

                //Update Net Contribution
                else
                if (_CoInsElementMdl.ElementCode == 2)
                {
                    _sbSql.AppendLine("Update InsCoInsuance SET");
                    _sbSql.AppendLine("GrossContribution=@GrossContribution");
                    _sbSql.AppendLine("NetContribution=@NetContribution,");
                    _sbSql.AppendLine("FIF=@FIF,");
                    _sbSql.AppendLine("FED=@FED");
                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");


                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_InsCoInsurance.UserCode);


                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _InsCoInsurance.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@NetContribution", _InsCoInsurance.NetContribution);

                    Gross = (_InsCoInsurance.NetContribution - _InsCoInsurance2.Stamp)/(((_InsCoInsurance2.FIF + _InsCoInsurance2.FED)/100)+1);

                    _cmdSql.Parameters.AddWithValue("@GrossContribution", Gross);
                    _cmdSql.Parameters.AddWithValue("@FIF", _InsCoInsurance2.FIF);
                    _cmdSql.Parameters.AddWithValue("@FED", _InsCoInsurance2.FED);
                    _InsCoInsurance.IsValidTxn = true;

                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    return _InsCoInsurance;
                }

                else
                if (_CoInsElementMdl.ElementCode == 3)
                {

                    //Get Gross Value from InsCoInsurance
                    string _sqlString = "SELECT * FROM InsCoInsuance WHERE TxnSysId="+_InsCoInsurance.TxnSysID;
                    SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                    DataTable _tblSqla = new DataTable();
                    List<InsCoInsurance> _InsCoInsuranceList = new List<InsCoInsurance>();
                    InsCoInsurance _InsCoInsurance1;
                    decimal GrossC=0, NetC=0,FED=0;

                    _adpSql.Fill(_tblSqla);

                    if (_tblSqla.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla.Rows.Count; i++)
                        {
                            _InsCoInsurance1 = new InsCoInsurance();

                            _InsCoInsurance1.GrossContribution = Convert.ToDecimal(_tblSqla.Rows[i]["GrossContribution"]);
                            GrossC = _InsCoInsurance1.GrossContribution;
                           
                            

                            _InsCoInsurance1.NetContribution = Convert.ToDecimal(_tblSqla.Rows[i]["FED"]);
                            FED = _InsCoInsurance1.FED;

                            _InsCoInsuranceList.Add(_InsCoInsurance1);


                        }

                        
                    }


                    NetC = GrossC * (((_InsCoInsurance.FIF + FED) / 100) + 1);

                    _sbSql.AppendLine("Update InsCoInsuance SET");
                    _sbSql.AppendLine("NetContribution=@NetContribution,");
                    _sbSql.AppendLine("FIF=@FIF");
                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");


                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_InsCoInsurance.UserCode);


                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _InsCoInsurance.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@NetContribution", NetC);
                    _cmdSql.Parameters.AddWithValue("@FIF", _InsCoInsurance.FIF);



                    _InsCoInsurance.IsValidTxn = true;

                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    return _InsCoInsurance;
                   
                }

                else
                if (_CoInsElementMdl.ElementCode == 4)
                {

                    //Get Gross Value from InsCoInsurance
                    string _sqlString = "SELECT * FROM InsCoInsuance WHERE TxnSysId="+_InsCoInsurance.TxnSysID;
                    SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                    DataTable _tblSqla = new DataTable();
                    List<InsCoInsurance> _InsCoInsuranceList = new List<InsCoInsurance>();
                    InsCoInsurance _InsCoInsurance1;
                    decimal GrossC = 0, NetC = 0, FIF = 0;

                    _adpSql.Fill(_tblSqla);

                    if (_tblSqla.Rows.Count > 0)
                    {
                        for (int i = 0; i < _tblSqla.Rows.Count; i++)
                        {
                            _InsCoInsurance1 = new InsCoInsurance();

                            _InsCoInsurance1.GrossContribution = Convert.ToDecimal(_tblSqla.Rows[i]["GrossContribution"]);
                            GrossC = _InsCoInsurance1.GrossContribution;



                            _InsCoInsurance1.NetContribution = Convert.ToDecimal(_tblSqla.Rows[i]["FIF"]);
                            FIF = _InsCoInsurance1.FIF;

                            _InsCoInsuranceList.Add(_InsCoInsurance1);


                        }


                    }


                    NetC = GrossC * (((_InsCoInsurance.FED + FIF) / 100) + 1);

                    _sbSql.AppendLine("Update InsCoInsuance SET");
                    _sbSql.AppendLine("NetContribution=@NetContribution,");
                    _sbSql.AppendLine("FED=@FED");
                    _sbSql.AppendLine("WHERE TxnSysId=@TxnSysId ");


                    _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);

                    int _userCode = GlobalDataLayer.GetUserCodeById(_InsCoInsurance.UserCode);


                    _cmdSql.Parameters.AddWithValue("@TxnSysId", _InsCoInsurance.TxnSysID);
                    _cmdSql.Parameters.AddWithValue("@NetContribution", NetC);
                    _cmdSql.Parameters.AddWithValue("@FED", _InsCoInsurance.FED);


                    _InsCoInsurance.IsValidTxn = true;

                    _conSql.Open();
                    _cmdSql.ExecuteNonQuery();
                    _conSql.Close();

                    return _InsCoInsurance;

                }

                return _InsCoInsurance;


            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer");
                return null;
            }
        }

        //Validation that coinsurers share does not exceed 100 for Insert
        public bool IsHundred(VehicleDetailMdl _VehicleDetailMdl1, InsCoInsurance _InsCoInsurance1)

        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();

                string _sqlString = "SELECT mic.CoInsuranceShare FROM InsCoInsuance mic INNER JOIN MtrVehicleDetails mvd ON mvd.TxnSysID = mic.RiskTxnID WHERE mvd.TxnSysID = "+ _VehicleDetailMdl1.TxnSysID;
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<InsCoInsurance> _InsCoInsuranceList = new List<InsCoInsurance>();
                InsCoInsurance _InsCoInsurance = new InsCoInsurance();
                DuplicationCheck _duplicationCheck = new DuplicationCheck();
                int sum = 0;


                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)

                {

                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _InsCoInsurance = new InsCoInsurance();

                        _InsCoInsurance.CoInsuranceShare = Convert.ToInt32(_tblSqla.Rows[i]["CoInsuranceShare"]);

                        sum  = sum + Convert.ToInt32(_tblSqla.Rows[i]["CoInsuranceShare"]);

                        _InsCoInsuranceList.Add(_InsCoInsurance);


                    }

                    if (sum == 100)
                    {
                        return true;
                    }
                    else
                    if (sum + _InsCoInsurance1.CoInsuranceShare > 100)
                    {
                        return true;
                    }

                    else if(sum < 100)
                    {
                        return false;
                    }

                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }



            }
            catch (Exception ex)
            {
                return true;
            }
        }

        //Validation that coinsurers share does not exceed 100 for update
        public bool IsHundredU(InsCoInsurance _InsCoInsurance1)

        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                StringBuilder _sbSql = new StringBuilder();

                string _sqlString = "SELECT mic.CoInsuranceShare FROM InsCoInsuance mic WHERE mic.TxnSysID = " + _InsCoInsurance1.TxnSysID;
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<InsCoInsurance> _InsCoInsuranceList = new List<InsCoInsurance>();
                InsCoInsurance _InsCoInsurance = new InsCoInsurance();
                DuplicationCheck _duplicationCheck = new DuplicationCheck();
                int sum = 0;


                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)

                {

                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _InsCoInsurance = new InsCoInsurance();

                        _InsCoInsurance.CoInsuranceShare = Convert.ToInt32(_tblSqla.Rows[i]["CoInsuranceShare"]);

                        sum = sum + Convert.ToInt32(_tblSqla.Rows[i]["CoInsuranceShare"]);

                        _InsCoInsuranceList.Add(_InsCoInsurance);


                    }

                    if (sum == 100)
                    {
                        return true;
                    }

                    if (sum > 100)
                    {
                        return true;
                    }

                    else if (sum < 100)
                    {
                        return false;
                    }

                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }



            }
            catch (Exception ex)
            {
                return true;
            }
        }

        //Get all Part taker
        public List<InsPartTakerMdl> GetPartTaker()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM InsPartTaker";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<InsPartTakerMdl> _InsPartTakerMdlList = new List<InsPartTakerMdl>();
                InsPartTakerMdl _InsPartTakerMdl = new InsPartTakerMdl() ;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _InsPartTakerMdl = new InsPartTakerMdl();

                       // _InsPartTakerMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                       // _InsPartTakerMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                       // _InsPartTakerMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _InsPartTakerMdl.PARTTAKER_CODE = Convert.ToInt32(_tblSqla.Rows[i]["PARTTAKER_CODE"]);
                        _InsPartTakerMdl.CATEGORY_PARTTAKER_CODE = _tblSqla.Rows[i]["CATEGORY_PARTTAKER_CODE"].ToString();
                        _InsPartTakerMdl.ABBREVIATION = _tblSqla.Rows[i]["ABBREVIATION"].ToString();
                       // _InsPartTakerMdl.ADDRESS = _tblSqla.Rows[i]["ADDRESS"].ToString();
                       // _InsPartTakerMdl.CONTACT_PERSON = _tblSqla.Rows[i]["CONTACT_PERSON"].ToString();
                      //  _InsPartTakerMdl.PHONE_NO = Convert.ToInt32(_tblSqla.Rows[i]["PHONE_NO"]);
                      //  _InsPartTakerMdl.START_DATE = Convert.ToDateTime(_tblSqla.Rows[i]["START_DATE"]);
                      //  _InsPartTakerMdl.FAX_NO = Convert.ToInt32(_tblSqla.Rows[i]["FAX_NO"]);
                      //  _InsPartTakerMdl.REG_NO = _tblSqla.Rows[i]["REG_NO"].ToString();
                      //  _InsPartTakerMdl.NTN_NO = _tblSqla.Rows[i]["NTN_NO"].ToString();
                      //  _InsPartTakerMdl.EMAIL_ADDRESS = _tblSqla.Rows[i]["EMAIL_ADDRESS"].ToString();
                        _InsPartTakerMdl.ACTIVE = _tblSqla.Rows[i]["ACTIVE"].ToString();
                        _InsPartTakerMdl.PARTTAKER_NAME = _tblSqla.Rows[i]["PARTTAKER_NAME"].ToString();
                        //_InsPartTakerMdl.NIC = _tblSqla.Rows[i]["NIC"].ToString();
                        //_InsPartTakerMdl.TAX_DED = _tblSqla.Rows[i]["TAX_DED"].ToString();
                       // _InsPartTakerMdl.DISTRICT_CODE = Convert.ToInt32(_tblSqla.Rows[i]["DISTRICT_CODE"]);
                        _InsPartTakerMdl.PARTTAKER_TYPE = _tblSqla.Rows[i]["PARTTAKER_TYPE"].ToString();
                       // _InsPartTakerMdl.ENT_BY = _tblSqla.Rows[i]["ENT_BY"].ToString();
                       // _InsPartTakerMdl.ENT_DATE = Convert.ToDateTime(_tblSqla.Rows[i]["ENT_DATE"]);




                        _InsPartTakerMdlList.Add(_InsPartTakerMdl);


                    }

                    return _InsPartTakerMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer");
                return null;
            }
        }

        //Get Part taker name by Code
       public string GetParttakerNameByCode(int _ParttakerCode)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM InsPartTaker WHERE PARTTAKER_CODE = " + _ParttakerCode;
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tbl = new DataTable();
                InsCoInsurance _InsCoInsurance;

                _adpSql.Fill(_tbl);

                if (_tbl.Rows.Count > 0)
                {
                    _InsCoInsurance = new InsCoInsurance();
                    for (int i = 0; i < _tbl.Rows.Count; i++)
                    {

                        _InsCoInsurance.PartTakerName = _tbl.Rows[i]["PARTTAKER_NAME"].ToString();

                    }
                    return _InsCoInsurance.PartTakerName;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer");
                return null;
            }
        }



     //----------------- For Co Insurance ----------------//


    //-------------------------------Extras---------------------------------//

        //Get All Vehicle Make
        public List<MtrVMakeMdl> GetVMake()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrVMake";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrVMakeMdl> _MtrVMakeMdlList = new List<MtrVMakeMdl>();
                MtrVMakeMdl _MtrVMakeMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrVMakeMdl = new MtrVMakeMdl();

                        _MtrVMakeMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrVMakeMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrVMakeMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrVMakeMdl.MAKE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["MAKE_CODE"]);
                        _MtrVMakeMdl.ENT_BY = _tblSqla.Rows[i]["ENT_BY"].ToString();
                        _MtrVMakeMdl.MAKE_NAME = _tblSqla.Rows[i]["MAKE_NAME"].ToString();
                        _MtrVMakeMdl.MAKE_SHORT_NAME = _tblSqla.Rows[i]["MAKE_SHORT_NAME"].ToString();
                        _MtrVMakeMdl.MAKE_TYPE = _tblSqla.Rows[i]["MAKE_TYPE"].ToString();



                        _MtrVMakeMdlList.Add(_MtrVMakeMdl);


                    }

                    return _MtrVMakeMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer");
                return null;
            }
        }

        //Get  All Vehicle Sub Makes By V Make Code
        public List<MtrVSubMakeMdl> GetVSubMake(MtrVMakeMdl _MtrVMakeMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
               // string _sqlString = "SELECT * FROM MtrVSubMake ";
              //  SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrVSubMakeMdl> _MtrVSubMakeMdlList = new List<MtrVSubMakeMdl>();
                MtrVSubMakeMdl _MtrVSubMakeMdl;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString()))
                {
                    SqlCommand command =
                        new SqlCommand("SELECT *  FROM MtrVSubMake Where MAKE_CODE = @MAKE_CODE", conn);

                    command.Parameters.Add(new SqlParameter("@MAKE_CODE", _MtrVMakeMdl.MAKE_CODE));

                    SqlDataAdapter _adpSql = new SqlDataAdapter(command);


                    _adpSql.Fill(_tblSqla);
                }


               // _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrVSubMakeMdl = new MtrVSubMakeMdl();

                        _MtrVSubMakeMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrVSubMakeMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrVSubMakeMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrVSubMakeMdl.MAKE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["MAKE_CODE"]);
                        _MtrVSubMakeMdl.SUB_MAKE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["SUB_MAKE_CODE"]);
                        _MtrVSubMakeMdl.SUB_MAKE_NAME = _tblSqla.Rows[i]["SUB_MAKE_NAME"].ToString();
                        _MtrVSubMakeMdl.SUB_MAKE_SHORT_NAME = _tblSqla.Rows[i]["SUB_MAKE_SHORT_NAME"].ToString();
                        _MtrVSubMakeMdl.REMARKS = _tblSqla.Rows[i]["REMARKS"].ToString();
                        _MtrVSubMakeMdl.ENT_BY = _tblSqla.Rows[i]["ENT_BY"].ToString();
                        _MtrVSubMakeMdl.ENT_DATE = Convert.ToDateTime(_tblSqla.Rows[i]["ENT_DATE"]);




                        _MtrVSubMakeMdlList.Add(_MtrVSubMakeMdl);


                    }

                    return _MtrVSubMakeMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer");
                return null;
            }
        }

        //Get All Vehicle Classes
        public List<MtrVClassMdl> GetVClass()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrVClass";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrVClassMdl> _MtrVClassMdlList = new List<MtrVClassMdl>();
                MtrVClassMdl _MtrVClassMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrVClassMdl = new MtrVClassMdl();

                        _MtrVClassMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrVClassMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrVClassMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrVClassMdl.VCLASS_CODE = Convert.ToInt32(_tblSqla.Rows[i]["VCLASS_CODE"]);
                        _MtrVClassMdl.VCLASS_NAME = _tblSqla.Rows[i]["VCLASS_NAME"].ToString();
                        _MtrVClassMdl.VCLASS_SHORT_NAME = _tblSqla.Rows[i]["VCLASS_SHORT_NAME"].ToString();
                        _MtrVClassMdl.RATE = Convert.ToInt32(_tblSqla.Rows[i]["RATE"]);


                        

                        _MtrVClassMdlList.Add(_MtrVClassMdl);


                    }

                    return _MtrVClassMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer");
                return null;
            }
        }

        //Get All Cubic Capacity
        public List<MtrVCubicCapacityMdl> GetCC()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT mvc.CUBIC_HORSE_CODE, (CASE WHEN  mvc.TYPE = 'H' THEN 'HP' WHEN mvc.TYPE = 'C' THEN 'CC' ELSE '' END) +' '+ mvc.CUBIC_HORSE_SHORT_NAME+ ' C.C' CUBIC_HORSE_POWER FROM MtrVCubicCapacity mvc";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrVCubicCapacityMdl> _MtrVCubicCapacityMdlList = new List<MtrVCubicCapacityMdl>();
                MtrVCubicCapacityMdl _MtrVCubicCapacityMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrVCubicCapacityMdl = new MtrVCubicCapacityMdl();

                        _MtrVCubicCapacityMdl.CUBIC_HORSE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["CUBIC_HORSE_CODE"]);
                        _MtrVCubicCapacityMdl.CUBIC_STRING = _tblSqla.Rows[i]["CUBIC_HORSE_POWER"].ToString();


                        _MtrVCubicCapacityMdlList.Add(_MtrVCubicCapacityMdl);


                    }

                    return _MtrVCubicCapacityMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer");
                return null;
            }
        }

        //Get All Vehicle Body Type
        public List<MtrVBodyTypeMdl> GetVBodyType()
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT * FROM MtrVBodyType";
                SqlDataAdapter _adpSql = new SqlDataAdapter(_sqlString, _conSql);
                DataTable _tblSqla = new DataTable();
                List<MtrVBodyTypeMdl> _MtrVBodyTypeMdlList = new List<MtrVBodyTypeMdl>();
                MtrVBodyTypeMdl _MtrVBodyTypeMdl;

                _adpSql.Fill(_tblSqla);

                if (_tblSqla.Rows.Count > 0)
                {
                    for (int i = 0; i < _tblSqla.Rows.Count; i++)
                    {
                        _MtrVBodyTypeMdl = new MtrVBodyTypeMdl();

                        _MtrVBodyTypeMdl.TxnSysID = Convert.ToInt32(_tblSqla.Rows[i]["TxnSysID"]);
                        _MtrVBodyTypeMdl.TxnSysDate = Convert.ToDateTime(_tblSqla.Rows[i]["TxnSysDate"]);
                        _MtrVBodyTypeMdl.UserCode = Convert.ToInt32(_tblSqla.Rows[i]["UserCode"]);
                        _MtrVBodyTypeMdl.BODY_TYPE_CODE = Convert.ToInt32(_tblSqla.Rows[i]["BODY_TYPE_CODE"]);
                        _MtrVBodyTypeMdl.BODY_NAME = _tblSqla.Rows[i]["BODY_NAME"].ToString();
                        _MtrVBodyTypeMdl.SHORT_NAME = _tblSqla.Rows[i]["SHORT_NAME"].ToString();
                        _MtrVBodyTypeMdl.ENT_BY = _tblSqla.Rows[i]["ENT_BY"].ToString();



                        _MtrVBodyTypeMdlList.Add(_MtrVBodyTypeMdl);


                    }

                    return _MtrVBodyTypeMdlList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer");
                return null;
            }
        }

        //Adding New Vehicle
        public MtrVehicleMdl AddVehicle(MtrVehicleMdl _MtrVehicleMdl)
        {
            try

            {

                    SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                    StringBuilder _sbSql = new StringBuilder();
                    SqlCommand _cmdSql;
                   


                    _sbSql.AppendLine("INSERT INTO MtrVehicle(");
                //_sbSql.AppendLine("TxnSysID,");
                _sbSql.AppendLine("TxnSysDate,");
                _sbSql.AppendLine("UserCode,");
                _sbSql.AppendLine("VEHICLE_CODE,");
                _sbSql.AppendLine("MAKE_CODE,");
                _sbSql.AppendLine("VEHICLE_NAME,");
                _sbSql.AppendLine("VEHICLE_SHORT_NAME,");
                _sbSql.AppendLine("MARKET_VALUE,");
                _sbSql.AppendLine("VALUE_DATE,");
                _sbSql.AppendLine("SEATING_CAPACITY,");
                _sbSql.AppendLine("BODY_TYPE_CODE,");
                _sbSql.AppendLine("CUBIC_HORSE_CODE,");
                _sbSql.AppendLine("VEHICLE_CLASSIFICATION_CODE,");
                _sbSql.AppendLine("SUB_MAKE_CODE)");



                _sbSql.AppendLine("output INSERTED. TxnSysID VALUES ( ");
               // _sbSql.AppendLine("@TxnSysID,");
                _sbSql.AppendLine("@TxnSysDate,");
                _sbSql.AppendLine("@UserCode,");
                _sbSql.AppendLine("@VEHICLE_CODE,");
                _sbSql.AppendLine("@MAKE_CODE,");
                _sbSql.AppendLine("@VEHICLE_NAME,");
                _sbSql.AppendLine("@VEHICLE_SHORT_NAME,");
                _sbSql.AppendLine("@MARKET_VALUE,");
                _sbSql.AppendLine("@VALUE_DATE,");
                _sbSql.AppendLine("@SEATING_CAPACITY,");
                _sbSql.AppendLine("@BODY_TYPE_CODE,");
                _sbSql.AppendLine("@CUBIC_HORSE_CODE,");
                _sbSql.AppendLine("@VEHICLE_CLASSIFICATION_CODE,");
                _sbSql.AppendLine("@SUB_MAKE_CODE)");



                _cmdSql = new SqlCommand(_sbSql.ToString(), _conSql);




                    DateTime da = DateTime.Now;
                    da.ToString("MM-dd-yyyy h:mm tt");

                    _cmdSql.Parameters.AddWithValue("@TxnSysDate", Convert.ToDateTime(da));
                    int _userCode = GlobalDataLayer.GetUserCodeById(_MtrVehicleMdl.UserCode);
                    _cmdSql.Parameters.AddWithValue("@UserCode", _userCode);


                int _VEHICLE_CODE = GetVehicleCode(_MtrVehicleMdl);



                _cmdSql.Parameters.AddWithValue("@VEHICLE_CODE", _VEHICLE_CODE);

                _cmdSql.Parameters.AddWithValue("@MAKE_CODE", _MtrVehicleMdl.MAKE_CODE);
                _cmdSql.Parameters.AddWithValue("@VEHICLE_NAME", _MtrVehicleMdl.VEHICLE_NAME);
                _cmdSql.Parameters.AddWithValue("@VEHICLE_SHORT_NAME", _MtrVehicleMdl.VEHICLE_SHORT_NAME ?? DBNull.Value.ToString());
                _cmdSql.Parameters.AddWithValue("@MARKET_VALUE",_MtrVehicleMdl.MARKET_VALUE);
                _cmdSql.Parameters.AddWithValue("@VALUE_DATE", _MtrVehicleMdl.VALUE_DATE);
                _cmdSql.Parameters.AddWithValue("@SEATING_CAPACITY", _MtrVehicleMdl.SEATING_CAPACITY);
                _cmdSql.Parameters.AddWithValue("@BODY_TYPE_CODE", _MtrVehicleMdl.BODY_TYPE_CODE);
                _cmdSql.Parameters.AddWithValue("@CUBIC_HORSE_CODE", _MtrVehicleMdl.CUBIC_HORSE_CODE);
                _cmdSql.Parameters.AddWithValue("@VEHICLE_CLASSIFICATION_CODE", _MtrVehicleMdl.VEHICLE_CLASSIFICATION_CODE);
                _cmdSql.Parameters.AddWithValue("@SUB_MAKE_CODE", _MtrVehicleMdl.SUB_MAKE_CODE);


                int _TxnSysId;
                    _conSql.Open();
                    _TxnSysId = (Int32)_cmdSql.ExecuteScalar();
                    _conSql.Close();
                     _MtrVehicleMdl.IsValidTxn = true;

                    _MtrVehicleMdl.TxnSysID = _TxnSysId;

              

                return _MtrVehicleMdl;
                }
            
            catch (Exception ex)
            {
                //For creating Log file
                string _logFileName = GlobalDataLayer.CreateExceptionLog(ex.Message, "Vehicle Details DataLayer");
                return null;
            }

        }

        //Creating new Vehicle code
        public static int GetVehicleCode(MtrVehicleMdl _MtrVehicleMdl)
        {
            try
            {
                SqlConnection _conSql = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConString"].ToString());
                string _sqlString = "SELECT MAX(VEHICLE_CODE) LAST_VEHICLE_CODE FROM MtrVehicle";
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

     //-------------------------------Extras---------------------------------//

    }
}