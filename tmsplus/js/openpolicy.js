//Get Url Parameters
//To Get User ID and Token To be displayed on the top
$.urlParam = function(name) {
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    if (results == null) {
        return null;
    }
    return decodeURI(results[1]) || 0;
}

// Getting User Information
var $tokenparameters = $.urlParam('token');
var $useridparameters = $.urlParam('userid');
document.getElementById("username").innerHTML = "<i class='fa fa-user-circle' aria-hidden='true'></i>" + $useridparameters;
$("input[name='hiddentoken']").val($tokenparameters);
$("input[name='hiddenusername']").val($useridparameters);
var $ParameterObj = {
    UserId: $useridparameters,
    Token: $tokenparameters,
};
// Parameter Validation
//Passing User Information through Verification Parameter
var $Verification = JSON.stringify($ParameterObj);
// Logout 
$("#logout").on("click", function() {
    //Passing Verification variable through logout API
    $.get("http://207.180.200.121/crmapi/Users/TokenExpiry/?_userinfo=" + $Verification, function(data) {
        window.location = "login.html";
    });
});
//Passing Verification variable through  ValidateUserToken API and checking for validation of fields
$.get("http://207.180.200.121/crmapi/Users/ValidateUserToken/?_userinfo=" + $Verification, function(data) {
    $Valid = data.IsValid;
    if ($Valid == false) {
        window.location = "login.html";
    }
});

/* Calling Select2 Function */
$(document).ready(function() {
    $('.js-example-basic-single').select2();
});

//Open Policy Dropdown Api
// Cert Insure Dropdown Api
let DdlCertInsureCode = $('#ddlCertInsureCode');
DdlCertInsureCode.empty();
DdlCertInsureCode.append('<option>Choose Cert Insure Code</option>');
DdlCertInsureCode.prop('selectedIndex', 0);
const DdlCertInsureCodeUrl = "http://207.180.200.121/mtrprodsetup/MtrCertInsurance/GetAllMtrCertInsuranceCode";
var Mydata;
$.ajax({
    url: DdlCertInsureCodeUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function(data) {
        $.each(data, function(key, entry) {
            DdlCertInsureCode.append($('<option></option>').attr('value', entry.CertInsureCode).text(entry.CertInsureName));
        })
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});

// Is FilerApi
let DdlIsFiler = $('#ddlIsFiler');
DdlIsFiler.empty();
DdlIsFiler.append('<option>Choose Is Filer</option>');
DdlIsFiler.prop('selectedIndex', 0);
const DdlIsFilerUrl = "http://207.180.200.121/mtrprodsetup/IsFiler/GetIsFiler";
var Mydata;
$.ajax({
    url: DdlIsFilerUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function(data) {
        $.each(data, function(key, entry) {
            DdlIsFiler.append($('<option></option>').attr('value', entry.IsFilerCode).text(entry.IsFilerName));
        })
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});


// Is FilerApi
let DdlCalcType = $('#ddlCalcType');
DdlCalcType.empty();
DdlCalcType.append('<option>Choose Calc Type</option>');
DdlCalcType.prop('selectedIndex', 0);
const DdlCalcTypeUrl = "http://207.180.200.121/mtrprodsetup/CalcType/GetCalcType";
var Mydata;
$.ajax({
    url: DdlCalcTypeUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function(data) {
        $.each(data, function(key, entry) {
            DdlCalcType.append($('<option></option>').attr('value', entry.CalcCode).text(entry.CalcName));
        })
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});


// Is FilerApi
let DdlIsAuto = $('#ddlIsAuto');
DdlIsAuto.empty();
DdlIsAuto.append('<option>Choose Is Auto</option>');
DdlIsAuto.prop('selectedIndex', 0);
const DdlIsAutoUrl = "http://207.180.200.121/mtrprodsetup/IsAuto/GetIsAuto";
var Mydata;
$.ajax({
    url: DdlIsAutoUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function(data) {
        $.each(data, function(key, entry) {
            DdlIsAuto.append($('<option></option>').attr('value', entry.IsAutoCode).text(entry.IsAutoName));
        })
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});

// Agent Dropdown Api
let DdlAgencyCode = $('#ddlAgencyCode');
DdlAgencyCode.empty();
DdlAgencyCode.append('<option>Choose Agent</option>');
DdlAgencyCode.prop('selectedIndex', 0);
const DdlAgencyCodeUrl = "http://207.180.200.121/mtrprodsetup/ProductAgent/GetProductAgent";
var Mydata;
$.ajax({
    url: DdlAgencyCodeUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function(data) {
        $.each(data, function(key, entry) {
            DdlAgencyCode.append($('<option></option>').attr('value', entry.AgentCode).text(entry.AgentName));
        })
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});


// Client Dropdown Api
let DdlClientCode = $('#ddlClientCode');
DdlClientCode.empty();
DdlClientCode.append('<option>Choose Client</option>');
DdlClientCode.prop('selectedIndex', 0);
const DdlClientCodeUrl = "http://207.180.200.121/mtrprodsetup/ProductClient/GetProductClient";
var Mydata;
$.ajax({
    url: DdlClientCodeUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function(data) {
        $.each(data, function(key, entry) {
            DdlClientCode.append($('<option></option>').attr('value', entry.ClientCode).text(entry.ClientName));
        })
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});


// Takaful Type Dropdown Api
let ddlTakafulType = $('#ddlTakafulType');
ddlTakafulType.empty();
ddlTakafulType.append('<option>Choose Takaful Type</option>');
ddlTakafulType.prop('selectedIndex', 0);
const ddlTakafulTypeUrl = "http://207.180.200.121/mtrprodsetup/TakafulType/GetTakafulType";
var Mydata;
$.ajax({
    url: ddlTakafulTypeUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function(data) {
        $.each(data, function(key, entry) {
            ddlTakafulType.append($('<option></option>').attr('value', entry.INSURANCE_TYPE_CODE).text(entry.INSURANCE_TYPE_TITLE));
        })
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});

// Product Code Api
let DdlProductCodeApi = $('#ddlProductCode');
DdlProductCodeApi.empty();
DdlProductCodeApi.append('<option>Choose Product Code</option>');
DdlProductCodeApi.prop('selectedIndex', 0);
const DdlProductCodeApiUrl = 'http://207.180.200.121/mtrprodsetup/MasterProductSetUp/GetAllProductCodeOfMasterProductSetUp';
var Mydata;
$.ajax({
    url: DdlProductCodeApiUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function(data) {
        $.each(data, function(key, entry) {
            DdlProductCodeApi.append($('<option></option>').attr('value', entry.ProductCode).text(entry.ProductName));
        })
        $('#ddlProductCode').change(function() {
            var $ddlProductCode = $("#ddlProductCode").find('option:selected').val();
            var $GetProduct = {
                ProductCode: $ddlProductCode
            };
            var $GetProduct = JSON.stringify($GetProduct);
            $.get('http://207.180.200.121/mtrprodsetup/MasterProductSetUp/GetMasterProductSetUpByCode?_Json={"ProductCode": ' + $ddlProductCode + '}', function(data) {
                $ddlAgencyCode = data.Agent;
                $('#ddlAgencyCode').val($ddlAgencyCode).trigger('change');

                $ddlClientCode = data.Client;
                $('#ddlClientCode').val($ddlClientCode).trigger('change');

                $ddlPolicyTypeCode = data.PolicyTypeCode;
                $('#ddlPolicyTypeCode').val($ddlPolicyTypeCode).trigger('change');

                $ddlAgentCommPct = data.AgentCommPct;
                document.getElementById("txtCommissionRate").setAttribute("value", $ddlAgentCommPct);
            });
        });
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});

// Policy Type Dropdown Api
let DdlPolicyTypeCode = $('#ddlPolicyTypeCode');
DdlPolicyTypeCode.empty();
DdlPolicyTypeCode.append('<option>Choose Policy Code</option>');
DdlPolicyTypeCode.prop('selectedIndex', 0);
const DdlPolicyTypeCodeUrl = "http://207.180.200.121/mtrprodsetup/ProductPolicyType/GetProductPolicyType";
var Mydata;
$.ajax({
    url: DdlPolicyTypeCodeUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function(data) {
        $.each(data, function(key, entry) {
            DdlPolicyTypeCode.append($('<option></option>').attr('value', entry.PolicyTypeCode).text(entry.PolicyTypeName));
        })
        $('#ddlPolicyTypeCode').change(function() {
            var $ddlPolicyTypeCode = $("#ddlPolicyTypeCode").find('option:selected').val();
            var $GetInsureCode = {
                PolicyTypeCode: $ddlPolicyTypeCode,
            };
            var $GetInsureCode = JSON.stringify($GetInsureCode);
            $.get('http://207.180.200.121/mtrprodsetup//ProductPolicyType/GetMtrCertInsuranceCode?_Json= ' + $GetInsureCode, function(data) {
                $ddlCertInsureCode = data.CertInsureCode;
                $('#ddlCertInsureCode').val($ddlCertInsureCode).trigger('change');
            });
        });
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});

//Open Policy DataTable Api

$(document).ready(function() {

    //-1 is set by default for OpenPolicyRowIndex for the Update of databse 
    $("#OpenPolicyRowIndex").val("-1");
    //Get date function
    document.getElementById("txtEffectiveDate").valueAsDate = new Date()
    var date = new Date($('#txtEffectiveDate').val());
    day = date.getDate();
    month = date.getMonth();
    year = date.getFullYear() + 1;
    document.getElementById("txtExpiryDate").valueAsDate = new Date(year, month, day);
    //Get date function
    $("#txtEffectiveDate").change(function () {
        var date = new Date($('#txtEffectiveDate').val());
        day = date.getDate();
        month = date.getMonth();
        year = date.getFullYear() + 1;
        document.getElementById("txtExpiryDate").valueAsDate = new Date(year, month, day);
    });
    $("#OpenPolicyRowIndex").val("-1");
    $('#TblOpenPolicy').DataTable().clear().destroy();
    $('#TblOpenPolicy').DataTable().clear().destroy();
    var $TblOpenPolicy = $("#TblOpenPolicy").DataTable({
        "order": [
            [0, "desc"]
        ],
        "paging": true,
        "pageLength": 5,
        "searching": true,
    });
    $.ajax({
        url: "http://207.180.200.121/mtrprodsetup/MtrOpenPolicy/GetOpenPolicy",
        type: 'get',
        dataType: "JSON",
        success: function(response) {
            var len = response.length;
            for (var i = 0; i < len; i++) {
                var $SerialNo = response[i].SerialNo;
                var $AgencyCode = response[i].AgencyCode;
                var $AgentName = response[i].AgentName;
                var $BrchCoverNoteNo = response[i].BrchCoverNoteNo;
                var $CalcType = response[i].CalcType;
                var $CalcName = response[i].CalcName;
                var $CertInsureCode = response[i].CertInsureCode;
                var $CertInsureName = response[i].CertInsureName;
                var $ClientCode = response[i].ClientCode;
                var $ClientName = response[i].ClientName;
                var $DocType = response[i].DocType;
                var $DocTypeName = response[i].DocTypeName;
                var $GenerateAgainst = response[i].GenerateAgainst;
                var $IsAuto = response[i].IsAuto;
                var $IsAutoName = response[i].IsAutoName
                var $IsFiler = response[i].IsFiler;
                var $IsFilerName = response[i].IsFilerName;
                var $LeaderEndNo = response[i].LeaderEndNo;
                var $LeaderPolicyNo = response[i].LeaderPolicyNo;
                var $PolicyMonth = response[i].PolicyMonth;
                var $PolicyNo = response[i].PolicyNo;
                var $PolicyString = response[i].PolicyString;
                var $PolicyTypeCode = response[i].PolicyTypeCode;
                var $PolicyTypeName = response[i].PolicyTypeName;
                var $PolicyYear = response[i].PolicyYear;
                var $ProductCode = response[i].ProductCode;
                var $ProductName = response[i].ProductName;
                var $Remarks = response[i].Remarks;
                var $TxnSysDate = response[i].TxnSysDate;
                var $TxnSysID = response[i].TxnSysID;
                var $UWYear = response[i].UWYear;
                var $EffectiveDate = response[i].EffectiveDate;
                var $ExpiryDate = response[i].ExpiryDate;
                var $CreatedBy = response[i].CreatedBy;
                var $IsPosted = response[i].IsPosted;
                var $InsuranceTypeCode = response[i].InsuranceTypeCode;
                var $InsuranceTypeName = response[i].InsuranceTypeName;
                var $CommisionRate = response[i].CommisionRate;
                $TblOpenPolicy.row.add([$SerialNo, $AgencyCode, $AgentName, $BrchCoverNoteNo, $CalcType, $CalcName, $CertInsureCode, $CertInsureName, $ClientCode, $ClientName, $DocType, $DocTypeName, $GenerateAgainst, $IsAuto, $IsAutoName, $IsFiler, $IsFilerName, $LeaderEndNo, $LeaderPolicyNo, $PolicyMonth, $PolicyNo, $PolicyString, $PolicyTypeCode, $PolicyTypeName, $PolicyYear, $ProductCode, $ProductName, $Remarks, $TxnSysDate, $TxnSysID, $UWYear, $EffectiveDate, $ExpiryDate, $CreatedBy, $IsPosted, $InsuranceTypeCode, $InsuranceTypeName, $CommisionRate]).draw(false);
            }
        }
    });
    $("#BtnPolicyNew").on("click", function() {
        $('#txtEffectiveDate').focus();
        $('#txtTxnSysID').val('');
        $('#txtCreatedBy').val('');
        $('#txtPostedBy').val('');
        $("#txtTxnSysDate").val('');
        $("#txtPolicyMonth").val('');
        $("#txtPolicyString").val('');
        $("#txtPolicyYear").val('');
        $("#txtPolicyNo").val('');
        $("#txtGenerateAgainst").val('');
        $("#ddlProductCode").select2("val", 0);
        $("#ddlPolicyTypeCode").select2("val", 0);
        $("#ddlClientCode").select2("val", 0);
        $("#ddlAgencyCode").select2("val", 0);
        $("#ddlCertInsureCode").select2("val", 0);
        $("#txtRemarks").val('');
        $("#txtLeaderPolicyNo").val('');
        $("#txtLeaderEndNo").val('');
        $("#ddlIsFiler").select2("val", 0);
        $("#ddlCalcType").select2("val", 0);
        $("#ddlTakafulType").select2("val", 0);
        $("#ddlIsAuto").select2("val", 0);
        $("#txtEffectiveDate").val('');
        $("#txtExpiryDate").val('');
        $("#OpenPolicyRowIndex").val("-1");

        document.getElementById("txtEffectiveDate").valueAsDate = new Date()
        var date = new Date($('#txtEffectiveDate').val());
        day = date.getDate();
        month = date.getMonth() + 1;
        year = date.getFullYear();
        document.getElementById("txtExpiryDate").valueAsDate = new Date(year, 11, 32)
    });
    var $txtBrchCoverNoteNo = 101;
    document.getElementById("txtBrchCoverNoteNo").setAttribute("value", $txtBrchCoverNoteNo);
    $("#BtnPolicySave").on("click", function() {
        var $CreatedById = $useridparameters;
        document.getElementById("txtCreatedBy").setAttribute("value", $CreatedById);
        var $txtCreatedBy = $('#txtCreatedBy').val();
        var $txtTxnSysID = $('#txtTxnSysID').val();
        var $txtTxnSysDate = $('#txtTxnSysDate').val();
        var $txtDocValue = $('#txtDocValue').val();
        var $txtDocText = $('#txtDocText').val();

        var $txtPolicyMonth = $('#txtPolicyMonth').val();
        var $txtPolicyYear = $('#txtPolicyYear').val();
        var $txtPolicyNo = $('#txtPolicyNo').val();
        var $txtPolicyString = $('#txtPolicyString').val();

        var $ddlDoctypeValue = $("#ddlDoctype").find('option:selected').val();
        var $ddlDoctype = $("#ddlDoctype").find('option:selected').text();

        var $ddlTakafulTypeValue = $("#ddlTakafulType").find('option:selected').val();
        var $ddlTakafulType = $("#ddlTakafulType").find('option:selected').text();

        var $txtGenerateAgainst = $('#txtGenerateAgainst').val();

        var $ddlProductValue = $("#ddlProductCode").find('option:selected').val();
        var $ddlProductCode = $("#ddlProductCode").find('option:selected').text();

        var $ddlPolicyTypeValue = $("#ddlPolicyTypeCode").find('option:selected').val();
        var $ddlPolicyTypeCode = $("#ddlPolicyTypeCode").find('option:selected').text();

        var $ddlClientValue = $("#ddlClientCode").find('option:selected').val();
        var $ddlClientCode = $("#ddlClientCode").find('option:selected').text();

        var $ddlAgencyValue = $("#ddlAgencyCode").find('option:selected').val();
        var $ddlAgencyCode = $("#ddlAgencyCode").find('option:selected').text();

        var $txtCommissionRate = $('#txtCommissionRate').val();

        var $ddlCertInsureValue = $('#ddlCertInsureCode').find('option:selected').val();
        var $ddlCertInsureCode = $('#ddlCertInsureCode').find('option:selected').text();

        var $txtRemarks = $('#txtRemarks').val();

        var $txtBrchCoverNoteNo = $('#txtBrchCoverNoteNo').val();
        var $txtLeaderPolicyNo = $('#txtLeaderPolicyNo').val();
        var $txtLeaderEndNo = $('#txtLeaderEndNo').val();

        var $ddlIsFilerValue = $("#ddlIsFiler").find('option:selected').val();
        var $ddlIsFiler = $("#ddlIsFiler").find('option:selected').text();

        var $ddlCalcTypeValue = $("#ddlCalcType").find('option:selected').val();
        var $ddlCalcType = $("#ddlCalcType").find('option:selected').text();

        var $ddlIsAutoValue = $("#ddlIsAuto").find('option:selected').val();
        var $ddlIsAuto = $("#ddlIsAuto").find('option:selected').text();

        var $txtEffectiveDate = $('#txtEffectiveDate').val();
        var $txtExpiryDate = $('#txtExpiryDate').val();
        var $txtUWYear = $('#txtUWYear').val();
        if (!$txtEffectiveDate) {
            document.getElementById("test").innerHTML = "Please Fill Effective Date";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function() {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtEffectiveDate').focus().val($('#txtEffectiveDate').val());
            return false;
        }
        if ($ddlProductCode == 'Choose Product Code' || $ddlProductCode == '') {
            document.getElementById("test").innerHTML = "Please Select Product";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function() {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlProductCode').focus().val($('#ddlProductCode').val());
            return false;
        }

        if ($ddlIsFilerValue == 'Choose Is Filer' || $ddlIsFilerValue == '') {
            document.getElementById("test").innerHTML = "Please Select Is Filer";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function() {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlIsFiler').focus().val($('#ddlIsFiler').val());
            return false;
        }
        if ($ddlCalcTypeValue == 'Choose Calc Type' || $ddlCalcTypeValue == '') {
            document.getElementById("test").innerHTML = "Please Select Calc Type";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function() {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlCalcType').focus().val($('#ddlCalcType').val());
            return false;
        }
        if ($ddlIsAutoValue == 'Choose Is Auto' || $ddlIsAutoValue == '') {
            document.getElementById("test").innerHTML = "Please Select Is Auto";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function() {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlIsAuto').focus().val($('#ddlIsAuto').val());
            return false;
        } else {
            if ($("#OpenPolicyRowIndex").val() == "-1") {
                var $BtnOpenPolicyNew = {
                    ProductCode: $ddlProductValue,
                    PolicyTypeCode: $ddlPolicyTypeValue,
                    ClientCode: $ddlClientValue,
                    AgencyCode: $ddlAgencyValue,
                    CertInsureCode: $ddlCertInsureValue,
                    Remarks: $txtRemarks,
                    BrchCoverNoteNo: $txtBrchCoverNoteNo,
                    LeaderPolicyNo: $txtLeaderPolicyNo,
                    LeaderEndNo: $txtLeaderEndNo,
                    IsFiler: $ddlIsFilerValue,
                    CalcType: $ddlCalcTypeValue,
                    IsAuto: $ddlIsAutoValue,
                    EffectiveDate: $txtEffectiveDate,
                    ExpiryDate: $txtExpiryDate,
                    CreatedBy: $txtCreatedBy,
                    InsuranceTypeCode: $ddlTakafulTypeValue,
                    CommisionRate: $txtCommissionRate,
                };
                var $BtnOpenPolicyNew = JSON.stringify($BtnOpenPolicyNew);
                $.get("http://207.180.200.121/mtrprodsetup/MtrOpenPolicy/AddOpenPolicy?_Json=" + $BtnOpenPolicyNew, function(data) {
                    document.getElementById("txtPolicyNo").setAttribute("value", data.PolicyNo);
                    document.getElementById("txtPolicyString").setAttribute("value", data.PolicyString);
                    $ValidTxn = data.IsValidTxn;
                    if ($ValidTxn == true) {
                        var rowNodes = $TblOpenPolicy.row.add([data.SerialNo, data.AgencyCode, data.AgentName, data.BrchCoverNoteNo, data.CalcType, data.CalcName, data.CertInsureCode, data.CertInsureName, data.ClientCode, data.ClientName, data.DocType, data.DocTypeName, data.GenerateAgainst, data.IsAuto, data.IsAutoName, data.IsFiler, data.IsFilerName, data.LeaderEndNo, data.LeaderPolicyNo, data.PolicyMonth, data.PolicyNo, data.PolicyString, data.PolicyTypeCode, data.PolicyTypeName, data.PolicyYear, data.ProductCode, data.ProductName, data.Remarks, data.TxnSysDate, data.TxnSysID, data.UWYear, data.EffectiveDate, data.ExpiryDate, data.CreatedBy, data.IsPosted, data.InsuranceTypeCode, data.InsuranceTypeName, data.CommisionRate]).draw();
                        $('#SubmitModal').modal('show');
                        setTimeout(function() {
                            $('#SubmitModal').modal('hide')
                        }, 2000);
                    } else {
                        $TxnErrors = data.TxnErrors;
                        for (var i = 0; i < $TxnErrors.length; i++) {
                            $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                        }
                        $('#ErrorModal').modal('show');
                        setTimeout(function() {
                            $('#ErrorModal').modal('hide')
                        }, 2000);
                    }
                });
            } else {
                var $OpenPolicyRowIndex = $("#OpenPolicyRowIndex").val();
                var array = $TblOpenPolicy.row($OpenPolicyRowIndex).data();
                var $BtnOpenPolicyUpdate = {
                    TxnSysID: $txtTxnSysID,
                    TxnSysDate: $txtTxnSysDate,
                    PolicyMonth: $txtPolicyMonth,
                    PolicyYear: $txtPolicyYear,
                    PolicyNo: $txtPolicyNo,
                    DocType: $ddlDoctypeValue,
                    GenerateAgainst: $txtGenerateAgainst,
                    ProductCode: $ddlProductValue,
                    PolicyTypeCode: $ddlPolicyTypeValue,
                    ClientCode: $ddlClientValue,
                    AgencyCode: $ddlAgencyValue,
                    CertInsureCode: $ddlCertInsureValue,
                    Remarks: $txtRemarks,
                    BrchCoverNoteNo: $txtBrchCoverNoteNo,
                    LeaderPolicyNo: $txtLeaderPolicyNo,
                    LeaderEndNo: $txtLeaderEndNo,
                    IsFiler: $ddlIsFilerValue,
                    CalcType: $ddlCalcTypeValue,
                    IsAuto: $ddlIsAutoValue,
                    EffectiveDate: $txtEffectiveDate,
                    ExpiryDate: $txtExpiryDate,
                    UWYear: $txtUWYear,
                    InsuranceTypeCode: $ddlTakafulTypeValue,
                    CommisionRate: $txtCommissionRate,
                };
                var $BtnOpenPolicyUpdate = JSON.stringify($BtnOpenPolicyUpdate);
                $.get("http://207.180.200.121/mtrprodsetup/MtrOpenPolicy/UpdateOpenPolicy?_Json=" + $BtnOpenPolicyUpdate, function(data) {
                    $ValidTxn = data.IsValidTxn;

                    if ($ValidTxn == true) {
                        $('#UpdatedModal').modal('show');
                        setTimeout(function() {
                            $('#UpdatedModal').modal('hide')
                        }, 2000);
                        array[1] = $ddlAgencyValue;
                        array[2] = $ddlAgencyCode;
                        array[3] = $txtBrchCoverNoteNo;
                        array[4] = $ddlCalcTypeValue;
                        array[5] = $ddlCalcType;
                        array[6] = $ddlCertInsureValue;
                        array[7] = $ddlCertInsureCode;
                        array[8] = $ddlClientValue;
                        array[9] = $ddlClientCode;
                        array[10] = $txtDocValue;
                        array[11] = $txtDocText;
                        array[12] = $txtGenerateAgainst;
                        array[13] = $ddlIsAutoValue;
                        array[14] = $ddlIsAuto;
                        array[15] = $ddlIsFilerValue;
                        array[16] = $ddlIsFiler;
                        array[17] = $txtLeaderEndNo;
                        array[18] = $txtLeaderPolicyNo;
                        array[19] = $txtPolicyMonth;
                        array[20] = $txtPolicyNo;
                        array[21] = $txtPolicyString;
                        array[22] = $ddlPolicyTypeValue;
                        array[23] = $ddlPolicyTypeCode;
                        array[24] = $txtPolicyYear;
                        array[25] = $ddlProductValue;
                        array[26] = $ddlProductCode;
                        array[27] = $txtRemarks;
                        array[28] = $txtTxnSysDate;
                        array[29] = $txtTxnSysID;
                        array[30] = 2019;
                        array[31] = $txtEffectiveDate;
                        array[32] = $txtExpiryDate;
                        array[33] = $txtCreatedBy;
                        array[34] = $ddlTakafulTypeValue;
                        array[35] = $ddlTakafulType;
                        array[36] = $txtCommissionRate;
                        $TblOpenPolicy.row($OpenPolicyRowIndex).data(array);
                        $TblOpenPolicy.row($OpenPolicyRowIndex).invalidate();
                        $TblOpenPolicy.draw(false);
                    } else {
                        $TxnErrors = data.TxnErrors;
                        for (var i = 0; i < $TxnErrors.length; i++) {
                            $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].ErrorCode + '-' + $TxnErrors[i].Error + '</span>');
                        }
                        $('#ErrorModal').modal('show');
                        setTimeout(function() {
                            $('#ErrorModal').modal('hide')
                        }, 2000);
                    }
                });
            }
        }
    });
    $('#TblOpenPolicy tbody').on('click', 'tr', function() {
        $("#OpenPolicyRowIndex").val($TblOpenPolicy.row(this).index);
        var $selValue = $TblOpenPolicy.row(this).data();
        $rowIdx = $TblOpenPolicy.row(this).index;
        $("#TblOpenPolicy").val($rowIdx);
        $row = $TblOpenPolicy.row(this).node();
        $($row).addClass('ready');

        $ddlAgencyCode = $selValue[1];
        $('#ddlAgencyCode').val($ddlAgencyCode).trigger('change');

        $("#txtBrchCoverNoteNo").val($selValue[3]);

        $ddlCalcType = $selValue[4];
        $('#ddlCalcType').val($ddlCalcType).trigger('change');

        $ddlCertInsureValue = $selValue[6];
        $('#ddlCertInsureCode').val($ddlCertInsureValue).trigger('change');

        $ddlClientCode = $selValue[8];
        $('#ddlClientCode').val($ddlClientCode).trigger('change');


        $("#txtDocValue").val($selValue[10]);
        $("#txtDocText").val($selValue[11]);

        $("#txtGenerateAgainst").val($selValue[12]);

        $ddlIsAuto = $selValue[13];
        $('#ddlIsAuto').val($ddlIsAuto).trigger('change');

        $ddlIsFiler = $selValue[15];
        $('#ddlIsFiler').val($ddlIsFiler).trigger('change');

        $("#txtLeaderEndNo").val($selValue[17]);

        $("#txtLeaderPolicyNo").val($selValue[18]);

        $("#txtPolicyMonth").val($selValue[19]);

        $("#txtPolicyNo").val($selValue[20]);

        $("#txtPolicyString").val($selValue[21]);

        $ddlPolicyTypeCodes = $selValue[22];
        $('#ddlPolicyTypeCode').val($ddlPolicyTypeCodes).trigger('change');

        $("#txtPolicyYear").val($selValue[24]);

        $ddlProductCode = $selValue[25];
        $('#ddlProductCode').val($ddlProductCode).trigger('change');

        $("#txtRemarks").val($selValue[27]);

        var $SysDate = $selValue[28];
        var $SysDate = $SysDate.substring(0, 10);
        $("#txtTxnSysDate").val($SysDate);


        $("#txtTxnSysID").val($selValue[29]);



        $("#txtUWYear").val($selValue[30]);

        var $txtEffectiveDate = $selValue[31];
        var $txtEffectiveDate = $txtEffectiveDate.substring(0, 10);
        $("#txtEffectiveDate").val($txtEffectiveDate);

        var $txtExpiryDate = $selValue[32];
        var $txtExpiryDate = $txtExpiryDate.substring(0, 10);
        $("#txtExpiryDate").val($txtExpiryDate);

        $("#txtCreatedBy").val($selValue[33]);
        if ($selValue[34] == true) {
            $("input").prop('disabled', true);
            $('select').attr('disabled', true);
            $("#BtnPostedBy").hide();
            $("#BtnPolicySave").hide();
        } else {
            $("input").prop('disabled', false);
            $('select').attr('disabled', false);
            $("#BtnPostedBy").show();
            $("#BtnPolicySave").show();
        }

        $ddlTakafulType = $selValue[35];
        $('#ddlTakafulType').val($ddlTakafulType).trigger('change');

        $("#txtCommissionRate").val($selValue[37]);
    });
    $("#BtnPostedBy").on("click", function() {
        var $txtPostedBy = $useridparameters;
        document.getElementById("txtPostedBy").setAttribute("value", $txtPostedBy);
        var $txtTxnSysID = $('#txtTxnSysID').val();
        var $txtPostedBy = $('#txtPostedBy').val();
        var $BtnPostedBy = {
            TxnSysID: $txtTxnSysID,
            PostedBy: $txtPostedBy,
        };
        var $BtnPostedBy = JSON.stringify($BtnPostedBy);
        $.get("http://207.180.200.121/mtrprodsetup//MtrOpenPolicy/PostOpenPolicy?_Json=" + $BtnPostedBy, function(data) {
            $IsPosted = data.IsPosted;
            if ($IsPosted == true) {
                $('#PostedModal').modal('show');
                setTimeout(function() {
                    $('#PostedModal').modal('hide')
                }, 2000);
            } else {
                $TxnErrors = data.TxnErrors;
                for (var i = 0; i < $TxnErrors.length; i++) {
                    $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                }
                $('#ErrorModal').modal('show');
                setTimeout(function() {
                    $('#ErrorModal').modal('hide')
                }, 2000);
            }
        });
    });
});