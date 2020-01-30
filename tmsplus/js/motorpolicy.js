
$("#txtResidenceNum").keypress(function (event) {
    var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
    if((keyCode>=65 && keyCode<=90) || (keyCode>=97 && keyCode<=122))
        return false;
    else return true;
});
$("#txtOfficeNum").keypress(function (event) {
    var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
    if((keyCode>=65 && keyCode<=90) || (keyCode>=97 && keyCode<=122))
        return false;
    else return true;
});
$("#txtMileage").keypress(function (event) {
    var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
    if((keyCode>=65 && keyCode<=90) || (keyCode>=97 && keyCode<=122))
        return false;
    else return true;
});
$('#txtEngineNumber').keyup(function(){
    var yourInput = $(this).val();
    re = /[`~!@#$%^&*()_|+\=?;:'",.<>\{\}\[\]\\\/]/gi;
    var isSplChar = re.test(yourInput);
    if(isSplChar)
    {
        var no_spl_char = yourInput.replace(/[`~!@#$%^&*()_|+\=?;:'",.<>\{\}\[\]\\\/]/gi, '');
        $(this).val(no_spl_char);
    }
});
$('#txtChasisNumber').keyup(function(){
    var yourInput = $(this).val();
    re = /[`~!@#$%^&*()_|+\=?;:'",.<>\{\}\[\]\\\/]/gi;
    var isSplChar = re.test(yourInput);
    if(isSplChar)
    {
        var no_spl_char = yourInput.replace(/[`~!@#$%^&*()_|+\=?;:'",.<>\{\}\[\]\\\/]/gi, '');
        $(this).val(no_spl_char);
    }
});
$('#txtMileage').keyup(function(){
    var yourInput = $(this).val();
    re = /[`~!@#$%^&*()_|+\=?;:'",.<>\{\}\[\]\\\/]/gi;
    var isSplChar = re.test(yourInput);
    if(isSplChar)
    {
        var no_spl_char = yourInput.replace(/[`~!@#$%^&*()_|+\=?;:'",.<>\{\}\[\]\\\/]/gi, '');
        $(this).val(no_spl_char);
    }
});
$('#txtOfficeNum').keyup(function(){
    var yourInput = $(this).val();
    re = /[`~!@#$%^&*()_|+\=?;:'",.<>\{\}\[\]\\\/]/gi;
    var isSplChar = re.test(yourInput);
    if(isSplChar)
    {
        var no_spl_char = yourInput.replace(/[`~!@#$%^&*()_|+\=?;:'",.<>\{\}\[\]\\\/]/gi, '');
        $(this).val(no_spl_char);
    }
});
$('#txtResidenceNum').keyup(function(){
    var yourInput = $(this).val();
    re = /[`~!@#$%^&*()_|+\=?;:'",.<>\{\}\[\]\\\/]/gi;
    var isSplChar = re.test(yourInput);
    if(isSplChar)
    {
        var no_spl_char = yourInput.replace(/[`~!@#$%^&*()_|+\=?;:'",.<>\{\}\[\]\\\/]/gi, '');
        $(this).val(no_spl_char);
    }
});
//Number Mask
$('input[name="txtPersonalNum"]').mask('(0000) 000-0000');
//date mask
$("#txtBirthDate").inputmask();
$("#txtPoDate").inputmask();
$("#txtContractMaturityDate").inputmask();
$("#form").validate();
var $InsPolicyTxnId;
//Cnic Num mask
$("#txtCnicNum").inputmask();
//Contribution Integer Format
$('input#txtContribution').keyup(function (event) {
    // skip for arrow keys
    if (event.which >= 37 && event.which <= 40) return;

    // format number
    $(this).val(function (index, value) {
        return value
            .replace(/\D/g, "")
            .replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    });
});
$('input#txtVehicleValue').keyup(function (event) {
    // skip for arrow keys
    if (event.which >= 37 && event.which <= 40) return;

    // format number
    $(this).val(function (index, value) {
        return value
            .replace(/\D/g, "")
            .replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    });
});

//Get Url Parameters
//To Get User ID and Token To be displayed on the top
$.urlParam = function (name) {
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
$("#logout").on("click", function () {
    //Passing Verification variable through logout API
    $.get("http://207.180.200.121/crmapi/Users/TokenExpiry/?_userinfo=" + $Verification, function (data) {
        window.location = "login.html";
    });
});
//Passing Verification variable through  ValidateUserToken API and checking for validation of fields
$.get("http://207.180.200.121/crmapi/Users/ValidateUserToken/?_userinfo=" + $Verification, function (data) {
    $Valid = data.IsValid;
    if ($Valid == false) {
        window.location = "login.html";
    }
});

/* Calling Select2 Function */
$(document).ready(function () {
    $('.js-example-basic-single').select2();
});

// Certificate Page Js


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
    success: function (data) {
        $.each(data, function (key, entry) {
            ddlTakafulType.append($('<option></option>').attr('value', entry.INSURANCE_TYPE_CODE).text(entry.INSURANCE_TYPE_TITLE));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});

// Warranty Api
$('#ddlMotorProductCode').change(function () {
    var $ddlMotorProductCode = $('#ddlMotorProductCode').val();
    let DdlWarranty = $('#ddlWarranty');
    DdlWarranty.empty();
    DdlWarranty.append('<option selected="" value="">Choose Warranty</option>');
    DdlWarranty.prop('selectedIndex', 0);
    const DdlWarrantyUrl = 'http://207.180.200.121/mtrprodsetup/ProductWarrantiesSetup/GetWarrantiesByPCode/?_Json={"ProductCode":"' + $ddlMotorProductCode + '"}';
    var Mydata;
    $.ajax({
        url: DdlWarrantyUrl,
        type: "GET",
        crossDomain: true,
        dataType: "JSON",
        success: function (data) {
            $.each(data, function (key, entry) {
                DdlWarranty.append($('<option></option>').attr('value', entry.Warranty).text(entry.WarrantyShText));
            })
        },
        error: function (xhr, status, error) {
            alert(status);
        }
    });
});
// Condition Api
$('#ddlMotorProductCode').change(function () {
    var $ddlMotorProductCode = $('#ddlMotorProductCode').val();
    let DdlCondition = $('#ddlCondition');
    DdlCondition.empty();
    DdlCondition.append('<option selected="" value="">Choose Condition</option>');
    DdlCondition.prop('selectedIndex', 0);
    const DdlConditionUrl = 'http://207.180.200.121/mtrprodsetup/ProductConditionsSetUp/GetConditionsByPCode/?_Json={"ProductCode":"' + $ddlMotorProductCode + '"}';
    var Mydata;
    $.ajax({
        url: DdlConditionUrl,
        type: "GET",
        crossDomain: true,
        dataType: "JSON",
        success: function (data) {
            $.each(data, function (key, entry) {
                DdlCondition.append($('<option></option>').attr('value', entry.Condition).text(entry.ConditionShText));
            })
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
});

// Agent Dropdown Api
let DdlAgencyCode = $('#ddlPolicyAgencyCode');
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
    success: function (data) {
        $.each(data, function (key, entry) {
            DdlAgencyCode.append($('<option></option>').attr('value', entry.AgentCode).text(entry.AgentName));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});
// Client Dropdown Api
let DdlCertificateClientCode = $('#ddlCertificateClientCode');
DdlCertificateClientCode.empty();
DdlCertificateClientCode.append('<option>Choose Client</option>');
DdlCertificateClientCode.prop('selectedIndex', 0);
const DdlCertificateClientCodeUrl = "http://207.180.200.121/mtrprodsetup/ProductClient/GetProductClient";
var Mydata;
$.ajax({
    url: DdlCertificateClientCodeUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function (data) {
        $.each(data, function (key, entry) {
            DdlCertificateClientCode.append($('<option></option>').attr('value', entry.ClientCode).text(entry.ClientName));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});
// Product Code Api
let ddlMotorProductCode = $('#ddlMotorProductCode');
ddlMotorProductCode.empty();
ddlMotorProductCode.append('<option>Choose Product</option>');
ddlMotorProductCode.prop('selectedIndex', 0);
var $ddlCertificateClientCode = $('#ddlCertificateClientCode').val();
const ddlMotorProductCodeUrl = 'http://207.180.200.121/mtrprodsetup/MasterProductSetUp/ProductCodeByClientNo';
var Mydata;
$.ajax({
    url: ddlMotorProductCodeUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function (data) {
        $.each(data, function (key, entry) {
            ddlMotorProductCode.append($('<option></option>').attr('value', entry.ProductCode).text(entry.ProductName));
        })

        $('#ddlMotorProductCode').change(function () {
            var $ddlMotorProductCode = $('#ddlMotorProductCode').val();
            $.get('http://207.180.200.121/mtrprodsetup/MasterProductSetUp/GetMasterProductSetUpByPCode/?_Json={"ProductCode":"' + $ddlMotorProductCode + '"}', function (data) {

                //Getting Certificate Code By Motor Product Code
                $CertificateCode = data.CertInsureCode;
                $('#ddlOpCerTypeCode').val($CertificateCode).trigger('change');
                // Getting Commision Rate By Motor Product Code
                $AgentCommPct = data.AgentCommPct;
                document.getElementById("txtCommissionRate").setAttribute("value", $AgentCommPct);
                // Getting TxnSysId Rate By Motor Product Code
                /*$TxnSysID = data.TxnSysID;
                document.getElementById("txtTxnSysID").setAttribute("value", $TxnSysID);*/
                $ProductCode = data.ProductCode;
                $PolicyTypeCode = data.PolicyTypeCode;
                $('#ddlPolicyTypeCode').val($PolicyTypeCode).trigger('change');
                //Getting RateFactor and Rate By Motor Product Code
                $.get('http://207.180.200.121/mtrprodsetup/MasterProductSetUp/GetMasterProductSetUpByCodeForPol?_Json={"ProductCode":' + $ddlMotorProductCode + '}', function (data) {

                    $ddlRatingFactor = data.RatingFactor;
                    $('#ddlRatingFactor').val($ddlRatingFactor).trigger('change');
                });
            });
        });
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});
$('#ddlRatingFactor').change(function () {
    var $ddlMotorProductCodes = $('#ddlMotorProductCode').val();
    var $ddlRatingFactor = $('#ddlRatingFactor').val();
    $.get('http://207.180.200.121/mtrprodsetup/ProductRatingFactorSetUp/GetRatingFactorRate/?_Json={"ProductCode":' + $ddlMotorProductCodes + ',"RatingFactor":' + $ddlRatingFactor + '}', function (data) {
        $TxtRate = data.Rate,
            $IsEditable = data.IsEditable,
            document.getElementById("txtRate").setAttribute("value", $TxtRate);
        //contribution calculation
        var $CalVehicleValue = $('#txtVehicleValue').val();
        var $CalRate = $('#txtRate').val();
        $CalVehicleValue = parseInt($CalVehicleValue.replace(/,/g, ""))
        var CalculatedResult = $CalVehicleValue * ($CalRate / 100);

        document.getElementById("txtContribution").setAttribute("value", Math.round(CalculatedResult));
        if ($IsEditable == "No") {
            $("#txtRate").prop('disabled', true);
        }
    });
});
// Rating Factors Api
$('#ddlMotorProductCode').change(function () {
    var $ddlMotorProductCodes = $('#ddlMotorProductCode').val();
    let DdlRatingFactor = $('#ddlRatingFactor');
    DdlRatingFactor.empty();
    DdlRatingFactor.append('<option selected="" value="">Choose Rating Factor</option>');
    DdlRatingFactor.prop('selectedIndex', 0);
    const DdlRatingFactorUrl = 'http://207.180.200.121/mtrprodsetup/ProductRatingFactorSetUp/GetRatingFactorByPCode/?_Json={"ProductCode":"' + $ddlMotorProductCodes + '"}';
    var Mydata;
    $.ajax({
        url: DdlRatingFactorUrl,
        type: "GET",
        crossDomain: true,
        dataType: "JSON",
        success: function (data) {
            $.each(data, function (key, entry) {
                DdlRatingFactor.append($('<option></option>').attr('value', entry.RatingFactor).text(entry.RatingFactorShText));
            })

        },
        error: function (xhr, status, error) {
            alert(status);
        }
    });
});
// Policy Type Dropdown Api
let ddlCertificatePolicyTypeCode = $('#ddlPolicyTypeCode');
ddlCertificatePolicyTypeCode.empty();
ddlCertificatePolicyTypeCode.append('<option>Choose Policy Code</option>');
ddlCertificatePolicyTypeCode.prop('selectedIndex', 0);
const ddlCertificatePolicyTypeCodeUrl = "http://207.180.200.121/mtrprodsetup/ProductPolicyType/GetProductPolicyType";
var Mydata;
$.ajax({
    url: ddlCertificatePolicyTypeCodeUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function (data) {
        $.each(data, function (key, entry) {
            ddlCertificatePolicyTypeCode.append($('<option></option>').attr('value', entry.PolicyTypeCode).text(entry.PolicyTypeName));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});

// Vehicle Dropdown Api
let ddlVehicleName = $('#ddlVehicleName');
ddlVehicleName.empty();
ddlVehicleName.append('<option>Choose Vehicle</option>');
ddlVehicleName.prop('selectedIndex', 0);
const ddlVehicleNameUrl = "http://207.180.200.121/mtrprodsetup/MtrVehicle/GetMtrVehicle";
var Mydata;
$.ajax({
    url: ddlVehicleNameUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function (data) {
        $.each(data, function (key, entry) {
            ddlVehicleName.append($('<option></option>').attr('value', entry.VEHICLE_CODE).text(entry.VEHICLE_TEXT));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});

// Gender Dropdown Api
let ddlGender = $('#ddlGender');
ddlGender.empty();
ddlGender.append('<option>Choose Gender</option>');
ddlGender.prop('selectedIndex', 0);
const ddlGenderUrl = "http://207.180.200.121/mtrprodsetup/Genders/GetGenders";
var Mydata;
$.ajax({
    url: ddlGenderUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function (data) {
        $.each(data, function (key, entry) {
            ddlGender.append($('<option></option>').attr('value', entry.GenderCode).text(entry.GenderName));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});

// Color Dropdown Api
let ddlColorName = $('#ddlColorName');
ddlColorName.empty();
ddlColorName.append('<option>Choose Color</option>');
ddlColorName.prop('selectedIndex', 0);
const ddlColorNameUrl = "http://207.180.200.121/mtrprodsetup/MtrVColor/GetMtrVColor";
var Mydata;
$.ajax({
    url: ddlColorNameUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function (data) {
        $.each(data, function (key, entry) {
            ddlColorName.append($('<option></option>').attr('value', entry.COLOR_CODE).text(entry.COLOR_SHORT_NAME));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});

// Vehicle Type Dropdown Api
let ddlVehicleType = $('#ddlVehicleType');
ddlVehicleType.empty();
ddlVehicleType.append('<option>Choose Vehicle Type</option>');
ddlVehicleType.prop('selectedIndex', 0);
const ddlVehicleTypeUrl = "http://207.180.200.121/mtrprodsetup/MtrVehicleType/GetMtrVehicleType";
var Mydata;
$.ajax({
    url: ddlVehicleTypeUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function (data) {
        $.each(data, function (key, entry) {
            ddlVehicleType.append($('<option></option>').attr('value', entry.VehicleTypeCode).text(entry.VehicleTypeName));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});

// Vehicle Type Dropdown Api
let ddlVEODCode = $('#ddlVEODCode');
ddlVEODCode.empty();
ddlVEODCode.append('<option>Choose VEOD</option>');
ddlVEODCode.prop('selectedIndex', 0);
const ddlVEODCodeeUrl = "http://207.180.200.121/mtrprodsetup/MtrVEOD/GetMtrVEOD";
var Mydata;
$.ajax({
    url: ddlVEODCodeeUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function (data) {
        $.each(data, function (key, entry) {
            ddlVEODCode.append($('<option></option>').attr('value', entry.VEODCode).text(entry.VEODName));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});
// CerTypeCode Type Dropdown Api
let ddlOpCerTypeCode = $('#ddlOpCerTypeCode');
ddlOpCerTypeCode.empty();
ddlOpCerTypeCode.append('<option>Choose Certificate Type</option>');
ddlOpCerTypeCode.prop('selectedIndex', 0);
const ddlOpCerTypeCodeUrl = "http://207.180.200.121/mtrprodsetup/CertType/GetCertType";
var Mydata;
$.ajax({
    url: ddlOpCerTypeCodeUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function (data) {
        $.each(data, function (key, entry) {
            ddlOpCerTypeCode.append($('<option></option>').attr('value', entry.CertInsureCode).text(entry.CertInsureName));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});
// Search Dropdown Api
let ddlSearchByCert = $('#ddlSearchByCert');
ddlSearchByCert.empty();
ddlSearchByCert.append('<option>Choose Search By Certificate</option>');
ddlSearchByCert.prop('selectedIndex', 0);
const ddlSearchByCertUrl = "http://207.180.200.121/mtrprodsetup/MtrSearchBy/GetMtrSearchBy";
var Mydata;
$.ajax({
    url: ddlSearchByCertUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function (data) {
        $.each(data, function (key, entry) {
            ddlSearchByCert.append($('<option></option>').attr('value', entry.SeByCertCode).text(entry.SeByCertName));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});
// GetInsParttaker Dropdown Api
let ddlParttaker = $('#ddlParttaker');
ddlParttaker.empty();
ddlParttaker.append('<option>Choose Search Part Taker Code</option>');
ddlParttaker.prop('selectedIndex', 0);
const ddlParttakerUrl = "http://207.180.200.121/mtrprodsetup/InsParttaker/GetInsParttaker";
var Mydata;
$.ajax({
    url: ddlParttakerUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function (data) {
        $.each(data, function (key, entry) {
            ddlParttaker.append($('<option></option>').attr('value', entry.PARTTAKER_CODE).text(entry.PARTTAKER_NAME));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});
// GetInsParttaker Dropdown Api
let ddlUpdateParttaker = $('#ddlUpdateParttaker');
ddlUpdateParttaker.empty();
ddlUpdateParttaker.append('<option>Choose Search Part Taker Code</option>');
ddlUpdateParttaker.prop('selectedIndex', 0);
const ddlUpdateParttakerUrl = "http://207.180.200.121/mtrprodsetup/InsParttaker/GetInsParttaker";
var Mydata;
$.ajax({
    url: ddlUpdateParttakerUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function (data) {
        $.each(data, function (key, entry) {
            ddlUpdateParttaker.append($('<option></option>').attr('value', entry.PARTTAKER_CODE).text(entry.PARTTAKER_NAME));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});
// City Dropdown Api
let ddlCityCode = $('#ddlCityCode');
ddlCityCode.empty();
ddlCityCode.append('<option>Choose City</option>');
ddlCityCode.prop('selectedIndex', 0);
const ddlCityCodeUrl = "http://207.180.200.121/mtrprodsetup/MtrCity/GetMtrCity";
var Mydata;
$.ajax({
    url: ddlCityCodeUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function (data) {
        $.each(data, function (key, entry) {
            ddlCityCode.append($('<option></option>').attr('value', entry.CITY_CODE).text(entry.CITY_NAME));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});
$('#ddlCityCode').change(function () {
    var $ddlCityCode = $('#ddlCityCode').val();
    var ddlAreaCode = $('#ddlAreaCode');
    ddlAreaCode.empty();
    ddlAreaCode.append('<option>Choose Area</option>');
    ddlAreaCode.prop('selectedIndex', 0);
    const ddlAreaCodeUrl = 'http://207.180.200.121/mtrprodsetup/MtrArea/GetMtrArea?_Json={"CITY_CODE":"' + $ddlCityCode + '"}';
    var Mydata;
    $.ajax({
        url: ddlAreaCodeUrl,
        type: "GET",
        crossDomain: true,
        dataType: "JSON",
        success: function (data) {
            $.each(data, function (key, entry) {
                ddlAreaCode.append($('<option></option>').attr('value', entry.DISTRICT_CODE).text(entry.DISTRICT_NAME));
            })
        },
    });
});
// Tracker Company Dropdown Api
$('#ddlMotorProductCode').change(function () {
    var $ddlMotorProductCode = $('#ddlMotorProductCode').val();
    let ddlTrackerCompany = $('#ddlTrackerCompany');
    ddlTrackerCompany.empty();
    ddlTrackerCompany.append('<option selected="" value="">Choose Tracker Company</option>');
    ddlTrackerCompany.prop('selectedIndex', 0);
    ddlTrackerCompanyUrl = 'http://207.180.200.121/mtrprodsetup/ProductTrackerSetup/GetTrackerByPCode/?_Json={"ProductCode":"' + $ddlMotorProductCode + '"}';
    var Mydata;
    $.ajax({
        url: ddlTrackerCompanyUrl,
        type: "GET",
        crossDomain: true,
        dataType: "JSON",
        success: function (data) {
            $.each(data, function (key, entry) {
                ddlTrackerCompany.append($('<option></option>').attr('value', entry.TrackerCode).text(entry.TrackerName));
            })
            $('#ddlTrackerCompany').change(function () {
                var $ddlMotorProductCode = $('#ddlMotorProductCode').val();
                var $ddlTrackerCompany = $('#ddlTrackerCompany').val();
                $.get('http://207.180.200.121/mtrprodsetup/ProductTrackerSetup/GetTrackerAmount/?_Json={"ProductCode":' + $ddlMotorProductCode + ',"TrackerCode":' + $ddlTrackerCompany + '}', function (data) {
                    $TrackerAmount = data.TrackerRate;
                    document.getElementById("ddlTrackerAmount").setAttribute("value", $TrackerAmount);
                });
            });
        },
        error: function (xhr, status, error) {
            alert(status);
        }
    });
});

// Rider Company Dropdown Api
$('#ddlMotorProductCode').change(function () {
    var $ddlMotorProductCode = $('#ddlMotorProductCode').val();
    let ddlRider = $('#ddlRider');
    ddlRider.empty();
    ddlRider.append('<option selected="" value="">Choose Rider</option>');
    ddlRider.prop('selectedIndex', 0);
    ddlRiderUrl = 'http://207.180.200.121/mtrprodsetup/ProductRiderSetup/GetRiderByPCode/?_Json={"ProductCode":"' + $ddlMotorProductCode + '"}';
    var Mydata;
    $.ajax({
        url: ddlRiderUrl,
        type: "GET",
        crossDomain: true,
        dataType: "JSON",
        success: function (data) {
            $.each(data, function (key, entry) {
                ddlRider.append($('<option></option>').attr('value', entry.RiderCode).text(entry.RiderName));
            })
            $('#ddlRider').change(function () {
                var $ddlMotorProductCode = $('#ddlMotorProductCode').val();
                var $ddlRider = $('#ddlRider').val();
                $.get('http://207.180.200.121/mtrprodsetup/ProductRiderSetup/GetRiderAmount/?_Json={"ProductCode":' + $ddlMotorProductCode + ',"RiderCode":' + $ddlRider + '}', function (data) {
                    $RiderRate = data.RiderRate;
                    document.getElementById("ddlRiderAmount").setAttribute("value", $RiderRate);
                });
            });
        },
        error: function (xhr, status, error) {
            alert(status);
        }
    });
});
// Element Dropdown Api
let ddlCoInsElement = $('#ddlCoInsElement');
ddlCoInsElement.empty();
ddlCoInsElement.append('<option selected="" value="">Choose Element</option>');
ddlCoInsElement.prop('selectedIndex', 0);
ddlCoInsElementUrl = "http://207.180.200.121/mtrprodsetup/CoInsElement/GetCoInsElement";
var Mydata;
$.ajax({
    url: ddlCoInsElementUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function (data) {
        $.each(data, function (key, entry) {
            ddlCoInsElement.append($('<option></option>').attr('value', entry.ElementCode).text(entry.ElementName));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});
// UpdateElement Dropdown Api
let ddlUpdateCoInsElement = $('#ddlUpdateCoInsElement');
ddlUpdateCoInsElement.empty();
ddlUpdateCoInsElement.append('<option selected="" value="">Choose Element</option>');
ddlUpdateCoInsElement.prop('selectedIndex', 0);
ddlUpdateCoInsElementUrl = "http://207.180.200.121/mtrprodsetup/CoInsElement/GetCoInsElement";
var Mydata;
$.ajax({
    url: ddlUpdateCoInsElementUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function (data) {
        $.each(data, function (key, entry) {
            ddlUpdateCoInsElement.append($('<option></option>').attr('value', entry.ElementCode).text(entry.ElementName));
        })
    },
    error: function (xhr, status, error) {
        alert(status);
    }
});
// Policy Header Js
$(document).ready(function () {
    $("#SubmitCoInsurer").hide();
    $("#VechicleInsuranceRowIndex").val("-1");
    $("#txtContribution").prop('disabled', true);
    //Contribution Calculation
    $('input[name=txtVehicleValue]').change(function () {
        var $CalVehicleValue = $('#txtVehicleValue').val();
        var $CalRate = $('#txtRate').val();
        $CalVehicleValue = parseInt($CalVehicleValue.replace(/,/g, ""))
        var CalculatedResult = $CalVehicleValue * ($CalRate / 100);
        document.getElementById("txtContribution").setAttribute("value", Math.round(CalculatedResult));
    });

    document.getElementById("txtCertificateEffectiveDate").valueAsDate = new Date()
    var date = new Date($('#txtCertificateEffectiveDate').val());
    day = date.getDate();
    month = date.getMonth();
    year = date.getFullYear() + 1;
    document.getElementById("txtCerticateExpiryDate").valueAsDate = new Date(year, month, day);
    //Get date function
    $("#txtCertificateEffectiveDate").change(function () {
        var date = new Date($('#txtCertificateEffectiveDate').val());
        day = date.getDate();
        month = date.getMonth();
        year = date.getFullYear() + 1;
        document.getElementById("txtCerticateExpiryDate").valueAsDate = new Date(year, month, day);
    });
    //On Click BtnVehicleNew Clear All Fields
    $("#BtnVehicleNew").on("click", function () {
        $('#TblVechicleInsurance').DataTable().clear().destroy();
        $("#VechicleInsuranceRowIndex").val("-1");

        //Vechile Insurance Section Values
        $('#txtParticipantName').focus();
        $("#txtPolicyString").val('');
        $("#txtPersonalNum").val('');
        $("#txtOfficeNum").val('');
        $("#txtResidenceNum").val('');
        $("#txtParticipantName").val('');
        $("#txtParticipantAddress").val('');
        $("#txtCnicNum").val('');
        $("#txtBirthDate").val('');
        $("#txtPoDate").val('');
        $("#txtPoNumber").val('');
        $("#txtVehicleModel").val('');
        $("#txtModelNumber").val('');
        $("#txtRegistrationNumber").val('');
        $("#txtEngineNumber").val('');
        $("#txtChasisNumber").val('');
        $("#txtMileage").val('');
        $("#txtUpdatedValue").val('');
        $("#txtPreviousValue").val('');
        $('#txtContribution').attr("value", "");
        $("#txtContractMaturityDate").val('');
        $("#txtDeductible").val('');
        $("#txtEmail").val('');
        $("#txtRemarks").val('');
        $("#txtTenure").val('');
        $("#txtVehicleValue").val('');
        $("#ddlAreaCode").select2("val", 0);
        $("#ddlCityCode").select2("val", 0);
        $("#ddlGender").select2("val", 0);
        $("#ddlVehicleName").select2("val", 0);
        $("#ddlVehicleType").select2("val", 0);
        $("#ddlColorName").select2("val", 0);
        $("#ddlVEODCode").select2("val", 0);
        $("#ddlOpCerTypeCode").select2("val", 0);
        $("#ddlTakafulType").select2("val", 0);
        $("#ddlRatingFactor").select2("val", 0);

        document.getElementById("txtCertificateEffectiveDate").valueAsDate = new Date()
        var date = new Date($('#txtCertificateEffectiveDate').val());
        day = date.getDate();
        month = date.getMonth();
        year = date.getFullYear() + 1;
        document.getElementById("txtCerticateExpiryDate").valueAsDate = new Date(year, month, day);
        //Get date function
        $("#txtCertificateEffectiveDate").change(function () {
            console.log("hello");
            var date = new Date($('#txtCertificateEffectiveDate').val());
            day = date.getDate();
            month = date.getMonth();
            year = date.getFullYear() + 1;
            document.getElementById("txtCerticateExpiryDate").valueAsDate = new Date(year, month, day);
        });

    });
    //On Click BtnCertificatePolicySave Get All Fields Value & Insert All Fields into Api
    $("#BtnVehicleSave").on("click", function () {
        var $ddlCertificateClientCodeValue = $("#ddlCertificateClientCode").find('option:selected').val();
        var $ddlCertificateClientCode = $("#ddlCertificateClientCode").find('option:selected').text();

        var $ddlCertificateOpenPolicyValue = $("#ddlCertificateOpenPolicy").find('option:selected').val();
        var $ddlCertificateOpenPolicy = $("#ddlCertificateOpenPolicy").find('option:selected').text();

        var $ddlMotorProductCodeValue = $("#ddlMotorProductCode").find('option:selected').val();
        var $ddlMotorProductCode = $("#ddlMotorProductCode").find('option:selected').text();

        var $ddlCertificatePolicyTypeCodeValue = $("#ddlPolicyTypeCode").find('option:selected').val();
        var $ddlCertificatePolicyTypeCode = $("#ddlPolicyTypeCode").find('option:selected').text();

        var $txtCertificateEffectiveDate = $('#txtCertificateEffectiveDate').val();
        var $txtCerticateExpiryDate = $('#txtCerticateExpiryDate').val();
        var $txtTxnSysID = $('#txtTxnSysID').val();
        var $txtCertificateEffectiveDate = $('#txtCertificateEffectiveDate').val();
        var $txtCerticateExpiryDate = $('#txtCerticateExpiryDate').val();
        var $CreatedById = $useridparameters;
        document.getElementById("txtCertificateCreatedBy").setAttribute("value", $CreatedById);
        var $txtCertificateCreatedBy = $('#txtCertificateCreatedBy').val();

        //Certificate Header Values
        var $txtCertificateTxnSysID = $('#txtCertificateTxnSysID').val();
        var $txtParticipantName = $('#txtParticipantName').val();
        var encode =$('#txtParticipantAddress').val();
        var $txtParticipantAddress = encodeURIComponent(encode);
        var $txtVehicleValue = $('#txtVehicleValue').val();

        var $ddlCityCodeValue = $("#ddlCityCode").find('option:selected').val();
        var $ddlCityCode = $("#ddlCityCode").find('option:selected').text();

        var $ddlAreaCodeValue = $("#ddlAreaCode").find('option:selected').val();
        var $ddlAreaCode = $("#ddlAreaCode").find('option:selected').text();

        var $txtCnicNum = $('#txtCnicNum').val();
        //For  Birth Date Format
        var $txtBirthDate = $('#txtBirthDate').val();
        var $DateBirth = $txtBirthDate;
        var $txtBirthDate = $DateBirth.replace(/\//g, '-')

        var $txtBirthDate = $txtBirthDate.split('-');
        var $txtBirthDate = $txtBirthDate[1] + '-' + $txtBirthDate[0] + '-' + $txtBirthDate[2];


        var $ddlGenderValue = $("#ddlGender").find('option:selected').val();
        var $ddlGender = $("#ddlGender").find('option:selected').text();

        //For  PO Date Format
        var $txtPoDate = $('#txtPoDate').val();
        var $DatePO = $txtPoDate;
        var $txtPoDate = $DatePO.replace(/\//g, '-')

        var $txtPoDate = $txtPoDate.split('-');
        var $txtPoDate = $txtPoDate[1] + '-' + $txtPoDate[0] + '-' + $txtPoDate[2];


        var $ddlTakafulTypeValue = $("#ddlTakafulType").find('option:selected').val();
        var $ddlTakafulType = $("#ddlTakafulType").find('option:selected').text();

        var $ddlAgencyCodeValue = $("#ddlPolicyAgencyCode").find('option:selected').val();
        var $ddlAgencyCode = $("#ddlPolicyAgencyCode").find('option:selected').text();

        var $ddlVehicleNameValue = $("#ddlVehicleName").find('option:selected').val();
        var $ddlVehicleName = $("#ddlVehicleName").find('option:selected').text();

        var $txtVehicleModel = $('#txtVehicleModel').val();

        var $ddlVehicleTypeValue = $("#ddlVehicleType").find('option:selected').val();
        var $ddlVehicleType = $("#ddlVehicleType").find('option:selected').text();

        var $ddlColorNameValue = $("#ddlColorName").find('option:selected').val();
        var $ddlColorName = $("#ddlColorName").find('option:selected').text();

        var $ddlRatingFactorValue = $("#ddlRatingFactor").find('option:selected').val();
        var $ddlRatingFactor = $("#ddlRatingFactor").find('option:selected').text();

        var $txtRegistrationNumber = $('#txtRegistrationNumber').val();
        var $txtEngineNumber = $('#txtEngineNumber').val();
        var $txtChasisNumber = $('#txtChasisNumber').val();
        var $txtMileage = $('#txtMileage').val();

        var $ddlVEODCodeValue = $("#ddlVEODCode").find('option:selected').val();
        var $ddlVEODCode = $("#ddlVEODCode").find('option:selected').text();

        var $txtCommissionRate = $('#txtCommissionRate').val();
        var $txtContribution = $('#txtContribution').val();
        var $txtRate = $('#txtRate').val();
        var encodeRemarks =$('#txtRemarks').val();
        var $txtRemarks = encodeURIComponent(encodeRemarks);
        var $txtTenure = $('#txtTenure').val();
        var $txtPersonalNum = $('#txtPersonalNum').val();
        var $txtOfficeNum = $('#txtOfficeNum').val();
        var $txtResidenceNum = $('#txtResidenceNum').val();
        var $txtPoNumber = $('#txtPoNumber').val();

        var $ddlOpCerTypeCodeValue = $("#ddlOpCerTypeCode").find('option:selected').val();
        var $ddlOpCerTypeCode = $("#ddlOpCerTypeCode").find('option:selected').text();

        var $txtEmail = $('#txtEmail').val();
        var $txtDeductible = $('#txtDeductible').val();
        if (!$ddlMotorProductCodeValue || $ddlMotorProductCode == 'Choose Product') {
            document.getElementById("test").innerHTML = "Please Select Product";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlMotorProductCode').focus().val($('#ddlMotorProductCode').val());
            return false;
        }
        if ($ddlCertificateClientCodeValue == 'Choose Client' || $ddlCertificateClientCodeValue == '') {
            document.getElementById("test").innerHTML = "Please Select Client";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlCertificateClientCode').focus().val($('#ddlCertificateClientCode').val());
            return false;
        }
        
        if (!$ddlAgencyCodeValue || $ddlAgencyCode == 'Choose Agent') {
            document.getElementById("test").innerHTML = "Please Select Agent";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlPolicyAgencyCode').focus().val($('#ddlPolicyAgencyCode').val());
            return false;
        }
        if (!$txtCommissionRate) {
            document.getElementById("test").innerHTML = "Please Fill Commision";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtCommissionRate').focus().val($('#txtCommissionRate').val());
            return false;
        }
        if (!$ddlCertificatePolicyTypeCodeValue || $ddlCertificatePolicyTypeCode == 'Choose Policy Code') {
            document.getElementById("test").innerHTML = "Please Select Policy Type";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlCertificateOpenPolicy').focus().val($('#ddlCertificateOpenPolicy').val());
            return false;
        }
        if (!$txtCertificateEffectiveDate) {
            document.getElementById("test").innerHTML = "Please Fill Effective Date";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtCertificateEffectiveDate').focus().val($('#txtCertificateEffectiveDate').val());
            return false;
        }
        if (!$txtCerticateExpiryDate) {
            document.getElementById("test").innerHTML = "Please Fill Expiry Date";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtCerticateExpiryDate').focus().val($('#txtCerticateExpiryDate').val());
            return false;
        }
        //Certificate Header Validation
        if (!$txtParticipantName) {
            document.getElementById("test").innerHTML = "Please Fill Participant Name";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtParticipantName').focus().val($('#txtParticipantName').val());
            return false;
        }
        if (!$txtParticipantAddress) {
            document.getElementById("test").innerHTML = "Please Fill Participant Address";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtParticipantAddress').focus().val($('#txtParticipantAddress').val());
            return false;
        }
        if ($txtBirthDate) {
            var date = new Date($txtBirthDate);
            var year = date.getFullYear();
            var CurrentYear = new Date().getFullYear();
            if(year > CurrentYear){
                document.getElementById("test").innerHTML = "Please Enter Correct Year in Date of Birth";
                $('#ErrorModalValidate').modal('show');
                setTimeout(function() {
                    $('#ErrorModalValidate').modal('hide')
                }, 2000);
                $('#txtBirthDate').focus().val($('#txtBirthDate').val());
                return false;
            }
        }
        if ($txtCnicNum.length < 13) {
            document.getElementById("test").innerHTML = "Only 13 numbers are allowed";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtCnicNum').focus().val($('#txtCnicNum').val());
            return false;
        }
        if (!$ddlVehicleNameValue || $ddlVehicleNameValue == 'Choose Vehicle') {
            document.getElementById("test").innerHTML = "Please Select Vechicle";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlVehicleName').focus().val($('#ddlVehicleName').val());
            return false;
        }
        if (!$txtVehicleModel) {
            document.getElementById("test").innerHTML = "Please Fill Vehicle Model";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtVehicleModel').focus().val($('#txtVehicleModel').val());
            return false;
        }
        var CurrentYear = new Date().getFullYear();
        if ($txtVehicleModel > CurrentYear) {
            document.getElementById("test").innerHTML = "Please Fill Vehicle Model less than or Equal to 2019";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtVehicleModel').focus().val($('#txtVehicleModel').val());
            return false;
        }
        if (!$txtCerticateExpiryDate) {
            document.getElementById("test").innerHTML = "Please Fill Expiry Date";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtCerticateExpiryDate').focus().val($('#txtCerticateExpiryDate').val());
            return false;
        }
        if (!$ddlColorNameValue || $ddlColorNameValue == 'Choose Color') {
            document.getElementById("test").innerHTML = "Please Select Color";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlColorName').focus().val($('#ddlColorName').val());
            return false;
        }

        if (!$txtRegistrationNumber) {
            document.getElementById("test").innerHTML = "Please Fill Registration Number";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtRegistrationNumber').focus().val($('#txtRegistrationNumber').val());
            return false;
        }
        if (!$txtEngineNumber) {
            document.getElementById("test").innerHTML = "Please Fill Engine Number";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtEngineNumber').focus().val($('#txtEngineNumber').val());
            return false;
        }
        if (!$txtChasisNumber) {
            document.getElementById("test").innerHTML = "Please Fill Chasis Number Number";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtChasisNumber').focus().val($('#txtChasisNumber').val());
            return false;
        }
        if (!$ddlOpCerTypeCodeValue || $ddlOpCerTypeCode == 'Choose Certificate Type') {
            document.getElementById("test").innerHTML = "Please Select Certificate Type";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlOpCerTypeCode').focus().val($('#ddlOpCerTypeCode').val());
            return false;
        }
        if (!$ddlRatingFactorValue || $ddlRatingFactor == 'Choose Rating Factor') {
            document.getElementById("test").innerHTML = "Please Select Rating Factor";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlRatingFactor').focus().val($('#ddlRatingFactor').val());
            return false;
        }
        if (!$txtVehicleValue) {
            document.getElementById("test").innerHTML = "Please Fill Vehicle Value";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtVehicleValue').focus().val($('#txtVehicleValue').val());
            return false;
        }
        if (!$txtContribution) {
            document.getElementById("test").innerHTML = "Please Fill Contribution";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function () {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtContribution').focus().val($('#txtContribution').val());
            return false;
        } 
        else {
            var $BtnPolicyHeaderNew = {
                ProductCode: $ddlMotorProductCodeValue,
                ClientCode: $ddlCertificateClientCodeValue,
                CreatedBy: $txtCertificateCreatedBy,
                EffectiveDate: $txtCertificateEffectiveDate,
                ExpiryDate: $txtCerticateExpiryDate,
                CommisionRate: $txtCommissionRate,
                AgencyCode:$ddlAgencyCodeValue,
            };
            var $BtnPolicyHeaderNew = JSON.stringify($BtnPolicyHeaderNew);
            $.get("http://207.180.200.121/mtrprodsetup/MtrInsPolicy/AddInsPolicyForPol?_Json=" + $BtnPolicyHeaderNew, function (data) {
                $InsPolicyTxnId = data.ParentTxnSysID;
                $CertString = data.ParentTxnSysID;
                document.getElementById("txtTxnSysID").setAttribute("value", $InsPolicyTxnId);
                document.getElementById('Certificate').innerHTML = $CertString;
                document.getElementById("txtPolicyString").setAttribute("value", $CertString);
                $("#header").show();
                $ValidTxn = data.IsValidTxn;
                // Print
                /*$("#BtnVehiclePrint").on("click", function () {
                    $.urlParam = function (name) {
                        var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
                        if (results == null) {
                            return null;
                        }
                        return decodeURI(results[1]) || 0;
                    }
                    var link = "http://207.180.200.121/takafulprint/Index/";
                    var parameter = "?rptname=mtrInvoice&ParentTxnSysId=" + $InsPolicyTxnId;
                    var result = link + parameter;
                    $('#printbttn').attr('href', result);
                });*/
                //Getting All Records For Vechicle Insurance
                $('#TblVechicleInsurance').DataTable().clear().destroy();
                $TblVechicleInsurance = $("#TblVechicleInsurance").DataTable({
                    "order": [
                        [0, "desc"]
                    ],
                    "paging": true,
                    "pageLength": 5,
                    "searching": true,
                });
                $.ajax({
                    url: 'http://207.180.200.121/mtrprodsetup/MtrVehicleDetails/GetMtrVehicleDetails/?_Json={"TxnSysID":' + $InsPolicyTxnId + '}',
                    type: 'get',
                    dataType: "JSON",
                    success: function (response) {
                        var len = response.length;
                        for (var i = 0; i < len; i++) {
                            var $SerialNo = response[i].SerialNo;
                            var $VehicleCode = response[i].VehicleCode;
                            var $VehicleName = response[i].VehicleName;
                            var $VehicleModel = response[i].VehicleModel;
                            var $ColorCode = response[i].ColorCode;
                            var $ColorName = response[i].ColorName;
                            var $VehicleType = response[i].VehicleType;
                            var $VehicleTypeName = response[i].VehicleTypeName;
                            var $RegistrationNumber = response[i].RegistrationNumber;
                            var $EngineNumber = response[i].EngineNumber;
                            var $ChasisNumber = response[i].ChasisNumber;
                            var $Mileage = response[i].Mileage;
                            var $Deductible = response[i].Deductible;
                            var $UpdatedValue = response[i].UpdatedValue;
                            var $PreviousValue = response[i].PreviousValue;
                            var $ParticipantValue = response[i].ParticipantValue;
                            var $Rate = response[i].Rate;
                            var $Contribution = response[i].Contribution;
                            var $InsuranceTypeCode = response[i].InsuranceTypeCode;
                            var $InsuranceTypeName = response[i].InsuranceTypeName;
                            var $Tenure = response[i].Tenure;
                            var $CertTypeCode = response[i].CertTypeCode;
                            var $CertTypeName = response[i].CertTypeName;
                            var $CommisionRate = response[i].CommisionRate;
                            var $Remarks = response[i].Remarks;
                            var $ParticipantName = response[i].ParticipantName;
                            var $ParticipantAddress = response[i].ParticipantAddress;
                            var $EmailAddress = response[i].EmailAddress;
                            var $AreaCode = response[i].AreaCode;
                            var $AreaName = response[i].AreaName;
                            var $CityCode = response[i].CityCode;
                            var $CityName = response[i].CityName;
                            var $BirthDate = response[i].BirthDate;
                            var $Gender = response[i].Gender;
                            var $CNICNumber = response[i].CNICNumber;
                            var $MobileNumber = response[i].MobileNumber;
                            var $ResNumber = response[i].ResNumber;
                            var $OfficeNumber = response[i].OfficeNumber;
                            var $PODate = response[i].PODate;
                            var $PONumber = response[i].PONumber;
                            var $TxnSysID = response[i].TxnSysID;
                            var $VEODCode = response[i].VEODCode;
                             var $RatingFactor = response[i].RatingFactor;
                            $TblVechicleInsurance.row.add([$SerialNo, $VehicleCode, $VehicleName, $VehicleModel, $ColorCode, $ColorName, $VehicleType, $VehicleTypeName, $RegistrationNumber, $EngineNumber, $ChasisNumber, $Mileage, $Deductible, $UpdatedValue, $PreviousValue, $ParticipantValue, $Rate, $Contribution, $InsuranceTypeCode, $InsuranceTypeName, $Tenure, $CertTypeCode, $CertTypeName, $CommisionRate, $Remarks, $ParticipantName, $ParticipantAddress, $EmailAddress, $AreaCode, $AreaName, $CityCode, $CityName, $BirthDate, $Gender, $CNICNumber, $MobileNumber, $ResNumber, $OfficeNumber, $PODate, $PONumber, $TxnSysID, $VEODCode,$RatingFactor]).draw(false);
                        }
                    }
                });
                if ($ValidTxn == true) {

                    if ($("#VechicleInsuranceRowIndex").val() == "-1") {
                        //no validation numeric fields -1
                        var $ddlCityCodeValue = $("#ddlCityCode").find('option:selected').val();
                        var $ddlCityCode = $("#ddlCityCode").find('option:selected').text();

                        var $ddlAreaCodeValue = $("#ddlAreaCode").find('option:selected').val();
                        var $ddlAreaCode = $("#ddlAreaCode").find('option:selected').text();

                        //For  Birth Date Format
                        var $txtBirthDate = $('#txtBirthDate').val();
                        var $DateBirth = $txtBirthDate;
                        var $txtBirthDate = $DateBirth.replace(/\//g, '-')

                        var $txtBirthDate = $txtBirthDate.split('-');
                        var $txtBirthDate = $txtBirthDate[1] + '-' + $txtBirthDate[0] + '-' + $txtBirthDate[2];

                        var $ddlGenderValue = $("#ddlGender").find('option:selected').val();
                        var $ddlGender = $("#ddlGender").find('option:selected').text();

                        var $txtPoDate = $('#txtPoDate').val();
                        //For  PO Date Format
                        var $DatePO = $txtPoDate;
                        var $txtPoDate = $DatePO.replace(/\//g, '-')

                        var $txtPoDate = $txtPoDate.split('-');
                        var $txtPoDate = $txtPoDate[1] + '-' + $txtPoDate[0] + '-' + $txtPoDate[2];

                        var $ddlVehicleTypeValue = $("#ddlVehicleType").find('option:selected').val();
                        var $ddlVehicleType = $("#ddlVehicleType").find('option:selected').text();

                        var $ddlTakafulTypeValue = $("#ddlTakafulType").find('option:selected').val();
                        var $ddlTakafulType = $("#ddlTakafulType").find('option:selected').text();

                        var $txtMileage = $('#txtMileage').val();

                        var $ddlVEODCodeValue = $("#ddlVEODCode").find('option:selected').val();
                        var $ddlVEODCode = $("#ddlVEODCode").find('option:selected').text();


                        var $txtDeductible = $('#txtDeductible').val();
                        //no validation numeric fields -1
                        if (!$ddlCityCodeValue || $ddlCityCode == 'Choose City') {
                            var $ddlCityCodeValue = -1;
                        }
                        if (!$ddlAreaCodeValue || $ddlAreaCode == 'Choose Area') {
                            var $ddlAreaCodeValue = -1;
                        }
                        if (!$txtBirthDate || $txtBirthDate == "undefined-undefined-") {
                            var $txtBirthDate = "1900-01-01";
                        }
                        if (!$ddlGenderValue || $ddlGender == 'Choose Gender') {
                            var $ddlGenderValue = -1;
                        }
                        if (!$txtPoDate || $txtPoDate == "undefined-undefined-") {
                            var $txtPoDate = "1900-01-01";
                        }
                        if (!$ddlVehicleTypeValue || $ddlVehicleType == 'Choose Vehicle Type') {
                            var $ddlVehicleTypeValue = -1;
                        }
                        if (!$ddlTakafulTypeValue || $ddlTakafulType == 'Choose Takaful Type') {
                            var $ddlTakafulTypeValue = -1;
                        }
                        if (!$txtMileage) {
                            var $txtMileage = -1;
                        }
                        if (!$ddlVEODCodeValue || $ddlVEODCode == 'Choose VEOD') {
                            var $ddlVEODCodeValue = -1;
                        }
                        if (!$txtContractMaturityDate || $txtContractMaturityDate == "undefined-undefined-") {
                            var $txtContractMaturityDate = "1900-01-01";
                        }
                        if (!$txtDeductible) {
                            var $txtDeductible = -1;
                        }
                        var $BtnInsuredCertificateNew = {
                            VehicleCode: $ddlVehicleNameValue,
                            VehicleModel: $txtVehicleModel,
                            UpdatedValue: 0,
                            PreviousValue: 0,
                            Mileage: $txtMileage,
                            ParticipantValue: $txtVehicleValue,
                            ColorCode: $ddlColorNameValue,
                            ParticipantName: $txtParticipantName,
                            ParticipantAddress: $txtParticipantAddress,
                            RegistrationNumber: $txtRegistrationNumber,
                            AreaCode: $ddlAreaCodeValue,
                            CityCode: $ddlCityCodeValue,
                            EngineNumber: $txtEngineNumber,
                            ChasisNumber: $txtChasisNumber,
                            Remarks: $txtRemarks,
                            PODate: $txtPoDate,
                            PONumber: $txtPoNumber,
                            CNICNumber: $txtCnicNum,
                            Tenure: $txtTenure,
                            BirthDate: $txtBirthDate,
                            Gender: $ddlGenderValue,
                            VehicleType: $ddlVehicleTypeValue,
                            VEODCode: $ddlVEODCodeValue,
                            CertTypeCode: $ddlOpCerTypeCodeValue,
                            Rate: $txtRate,
                            Contribution: $txtContribution,
                            InsuranceTypeCode: $ddlTakafulTypeValue,
                            CommisionRate: $txtCommissionRate,
                            MobileNumber: $txtPersonalNum,
                            ResNumber: $txtOfficeNum,
                            OfficeNumber: $txtResidenceNum,
                            EmailAddress: $txtEmail,
                            Deductible: $txtDeductible,
                            RatingFactor: $ddlRatingFactorValue,
                        };
                        var $BtnInsuredCertificateNew = JSON.stringify($BtnInsuredCertificateNew);
                        $.get("http://207.180.200.121/mtrprodsetup/MtrVehicleDetails/AddMtrVehicleDetailsForPol?_Json=" + $BtnInsuredCertificateNew, function (data) {
                            $ValidTxn = data.IsValidTxn;
                            CoInsurer = data.TxnSysID;
                            document.getElementById("TxnSysIDVehicle").setAttribute("value", data.TxnSysID);
                            if ($ValidTxn == true) {
                                var rowNodes = $TblVechicleInsurance.row.add([data.SerialNo, data.VehicleCode, data.VehicleName, data.VehicleModel, data.ColorCode, data.ColorName, data.VehicleType, data.VehicleTypeName, data.RegistrationNumber, data.EngineNumber, data.ChasisNumber, data.Mileage, data.Deductible, data.UpdatedValue, data.PreviousValue, data.ParticipantValue, data.Rate, data.Contribution, data.InsuranceTypeCode, data.InsuranceTypeName, data.Tenure, data.CertTypeCode, data.CertTypeName, data.CommisionRate, data.Remarks, data.ParticipantName, data.ParticipantAddress, data.EmailAddress, data.AreaCode, data.AreaName, data.CityCode, data.CityName, data.BirthDate, data.Gender, data.CNICNumber, data.MobileNumber, data.ResNumber, data.OfficeNumber, data.PODate, data.PONumber, data.TxnSysID, data.VEODCode,data.RatingFactor]).draw();
                                $('#SubmitModal').modal('show');
                                setTimeout(function () {
                                    $('#SubmitModal').modal('hide')
                                }, 2000);
                                $("#UpdateCoInsurer").hide();
                                if ($ddlTakafulTypeValue == '2' || $ddlTakafulTypeValue == '3') {
                                    $("#SubmitCoInsurer").show();
                                }

                                //Product Tracker
                                $(document).ready(function () {
                                    // By Default  TrackerProductRowIndex is -1
                                    $("#TrackerProductRowIndex").val("-1");
                                    var $ddlCertificateClientCode = $('#ddlCertificateClientCode').val();
                                    $('#TblTrackerProductSetup').DataTable().clear().destroy();
                                    var $TblTrackerProductSetup = $("#TblTrackerProductSetup").DataTable({
                                        "order": [
                                            [0, "desc"]
                                        ],
                                        "paging": true,
                                        "pageLength": 5,
                                        "searching": true,
                                    });
                                    // Calling Tracker Values in table by Ajax
                                    $.ajax({
                                        url: 'http://207.180.200.121/mtrprodsetup/InsMtrTracker/GetInsMtrTracker?_Json={"ParentTxnSysID":"' + $InsPolicyTxnId + '"}',
                                        type: 'get',
                                        dataType: "JSON",
                                        success: function (response) {
                                            var len = response.length;
                                            for (var i = 0; i < len; i++) {
                                                var $TrackerCode = response[i].TrackerCode
                                                var $TrackerName = response[i].TrackerName
                                                var $TrackerRate = response[i].TrackerRate;
                                                var $PrdStpTxnSysId = response[i].ParentTxnSysID;
                                                var $TxnSysID = response[i].TxnSysID;
                                                $TblTrackerProductSetup.row.add([$TrackerCode, $TrackerName, $TrackerRate, $PrdStpTxnSysId, $TxnSysID]).draw(false);
                                            }
                                        }
                                    });
                                    $("#BtnTrackerProductNew").on("click", function () {
                                        $('#ddlTrackerCompany').focus();
                                        $('#ddlTrackerAmount').val('');
                                        $("#txTrackerTxnSysID").val('');
                                        $("#ddlTrackerCompany").select2("val", 0);
                                        $("#TrackerProductRowIndex").val("-1");
                                    });
                                    // On Click Listener of Save Button to Add or Update Database
                                    $("#BtnTrackerProductSave").on("click", function () {
                                        var txtTxnSysID = $('#txtTxnSysID').val();
                                        document.getElementById("txtTrackerPrdStpTxnSysId").setAttribute("value", txtTxnSysID);
                                        var $txtTrackerPrdStpTxnSysId = $('#txtTrackerPrdStpTxnSysId').val();
                                        var $txTrackerTxnSysID = $('#txTrackerTxnSysID').val();
                                        var $ddlTrackerCompany = $("#ddlTrackerCompany").find('option:selected').text();
                                        var $ddlTrackerCompanyValue = $("#ddlTrackerCompany").find('option:selected').val();
                                        var $ddlTrackerAmount = $('#ddlTrackerAmount').val();
                                        if (!$ddlTrackerCompanyValue) {
                                            document.getElementById("test").innerHTML = "Please Select Tracker Company";
                                            $('#ErrorModalValidate').modal('show');
                                            setTimeout(function () {
                                                $('#ErrorModalValidate').modal('hide')
                                            }, 2000);
                                            $('#ddlTrackerCompany').focus().val($('#ddlTrackerCompany').val());
                                            return false;
                                        }
                                        if (!$ddlTrackerAmount) {
                                            document.getElementById("test").innerHTML = "Please Fill Tracker Amount";
                                            $('#ErrorModalValidate').modal('show');
                                            setTimeout(function () {
                                                $('#ErrorModalValidate').modal('hide')
                                            }, 2000);
                                            $('#ddlTrackerAmount').focus().val($('#ddlTrackerAmount').val());
                                            return false;
                                        } else {
                                            // If TrackerProductRowIndex is -1 add new row on table
                                            if ($("#TrackerProductRowIndex").val() == "-1") {
                                                var $BtnTrackerProductNew = {
                                                    ParentTxnSysID: $txtTrackerPrdStpTxnSysId,
                                                    TrackerCode: $ddlTrackerCompanyValue,
                                                    TrackerName: $ddlTrackerCompany,
                                                    TrackerRate: $ddlTrackerAmount,
                                                };
                                                var $BtnTrackerProductNew = JSON.stringify($BtnTrackerProductNew);
                                                $.get("http://207.180.200.121/mtrprodsetup/InsMtrTracker/AddInsTracker?_Json=" + $BtnTrackerProductNew, function (data) {
                                                    $ValidTxn = data.IsValidTxn;
                                                    if ($ValidTxn == true) {
                                                        var rowNodes = $TblTrackerProductSetup.row.add([data.TrackerCode, data.TrackerName, data.TrackerRate, data.ParentTxnSysID, data.TxnSysID]).draw();
                                                        $('#SubmitModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#SubmitModal').modal('hide')
                                                        }, 2000);
                                                    } else {
                                                        $TxnErrors = data.TxnErrors;
                                                        for (var i = 0; i < $TxnErrors.length; i++) {
                                                            $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                                                        }
                                                        $('#ErrorModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#ErrorModal').modal('hide')
                                                        }, 2000);
                                                    }
                                                });
                                            } else {
                                                var $TrackerProductRowIndex = $("#TrackerProductRowIndex").val();
                                                var array = $TblTrackerProductSetup.row($TrackerProductRowIndex).data();
                                                var $BtnTrackerProductUpdate = {
                                                    TxnSysID: $txTrackerTxnSysID,
                                                    ParentTxnSysID: $txtTrackerPrdStpTxnSysId,
                                                    TrackerCode: $ddlTrackerCompanyValue,
                                                    TrackerName: $ddlTrackerCompany,
                                                    TrackerRate: $ddlTrackerAmount,
                                                };
                                                var $BtnTrackerProductUpdate = JSON.stringify($BtnTrackerProductUpdate);
                                                $.get("http://207.180.200.121/mtrprodsetup/InsMtrTracker/UpdateInsTracker?_Json=" + $BtnTrackerProductUpdate, function (data) {
                                                    $ValidTxn = data.IsValidTxn;
                                                    if ($ValidTxn == true) {
                                                        $('#UpdatedModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#UpdatedModal').modal('hide')
                                                        }, 2000);
                                                        array[0] = $ddlTrackerCompanyValue;
                                                        array[1] = $ddlTrackerCompany;
                                                        array[2] = $ddlTrackerAmount;
                                                        array[3] = $txtTrackerPrdStpTxnSysId;
                                                        array[4] = $txTrackerTxnSysID;
                                                        $TblTrackerProductSetup.row($TrackerProductRowIndex).data(array);
                                                        $TblTrackerProductSetup.row($TrackerProductRowIndex).invalidate();
                                                        $TblTrackerProductSetup.draw(false);
                                                    } else {
                                                        $TxnErrors = data.TxnErrors;
                                                        for (var i = 0; i < $TxnErrors.length; i++) {
                                                            $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].ErrorCode + '-' + $TxnErrors[i].Error + '</span>');
                                                        }
                                                        $('#ErrorModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#ErrorModal').modal('hide')
                                                        }, 2000);
                                                    }
                                                });

                                            }
                                        }
                                    });
                                    $('#TblTrackerProductSetup tbody').on('click', 'tr', function () {
                                        $("#TrackerProductRowIndex").val($TblTrackerProductSetup.row(this).index);
                                        var $selValue = $TblTrackerProductSetup.row(this).data();
                                        $rowIdx = $TblTrackerProductSetup.row(this).index;
                                        $("#TblConditionProductSetup").val($rowIdx);
                                        $row = $TblTrackerProductSetup.row(this).node();
                                        $($row).addClass('ready');
                                        $("#txtTrackerPrdStpTxnSysId").val($selValue[3]);
                                        $("#txTrackerTxnSysID").val($selValue[4]);
                                        $("#ddlTrackerAmount").val($selValue[2]);
                                        $ddlTrackerCompany = $selValue[0];
                                        $('#ddlTrackerCompany').val($ddlTrackerCompany).trigger('change');

                                    });
                                });
                                //Insurance Condition
                                $(document).ready(function () {
                                    // By Default  ConditionInsuranceRowIndex is -1
                                    $("#ConditionInsuranceRowIndex").val("-1");
                                    $('#TblCertificateCondition').DataTable().clear().destroy();
                                    var $ddlCertificateClientCode = $('#ddlCertificateClientCode').val();
                                    var $TblCertificateCondition = $("#TblCertificateCondition").DataTable({
                                        "order": [
                                            [0, "desc"]
                                        ],
                                        "paging": true,
                                        "pageLength": 5,
                                        "searching": true,
                                    });
                                    // Calling Condition Values in table by Ajax
                                    $.ajax({
                                        url: 'http://207.180.200.121/mtrprodsetup/InsMtrConditions/GetInsConditions?_Json={"ParentTxnSysID":"' + $InsPolicyTxnId + '"}',
                                        type: 'get',
                                        dataType: "JSON",
                                        success: function (response) {
                                            var len = response.length;
                                            for (var i = 0; i < len; i++) {
                                                var $ConditionShText = response[i].ConditionShText;
                                                var $TxnSysID = response[i].TxnSysID;
                                                var $Condition = response[i].Condition;
                                                var $PrdStpTxnSysId = response[i].ParentTxnSysID
                                                $TblCertificateCondition.row.add([$ConditionShText, $TxnSysID, $Condition, $PrdStpTxnSysId]).draw(false);
                                            }
                                        }
                                    });
                                    // On Click Listener for New Empty Input Value and Focus On User Code
                                    $("#BtnCertificateConditionNew").on("click", function () {
                                        $("#ConditionInsuranceRowIndex").val("-1");
                                        $('#ddlCondition').focus();
                                        $("#ddlCondition").select2("val", 0);
                                    });
                                    // On Click Listener of Save Button to Add or Update Database
                                    $("#BtnCertificateConditionSave").on("click", function () {
                                        var $txtConditionUserCode = $('#txtConditionUserCode').val($useridparameters);
                                        var txtTxnSysID = $('#txtTxnSysID').val();
                                        document.getElementById("txtConditionPrdStpTxnSysId").setAttribute("value", txtTxnSysID);
                                        var $txtConditionPrdStpTxnSysId = $('#txtConditionPrdStpTxnSysId').val();
                                        var $txtConditionTxnSysID = $('#txtConditionTxnSysID').val();
                                        var $ddlCondition = $("#ddlCondition").find('option:selected').text();
                                        var $ddlConditionValue = $("#ddlCondition").find('option:selected').val();
                                        if (!$ddlConditionValue) {
                                            document.getElementById("test").innerHTML = "Please Select Condition";
                                            $('#ErrorModalValidate').modal('show');
                                            setTimeout(function () {
                                                $('#ErrorModalValidate').modal('hide')
                                            }, 2000);
                                            $('#ddlCondition').focus().val($('#ddlCondition').val());
                                            return false;
                                        } else {
                                            // If RatingProductRowIndex is -1 add new row on table
                                            if ($("#ConditionInsuranceRowIndex").val() == "-1") {
                                                var $BtnConditionProductNew = {
                                                    ParentTxnSysID: $txtConditionPrdStpTxnSysId,
                                                    Condition: $ddlConditionValue,
                                                };
                                                var $BtnConditionProductNew = JSON.stringify($BtnConditionProductNew);
                                                $.get("http://207.180.200.121/mtrprodsetup/InsMtrConditions/AddInsConditions?_Json=" + $BtnConditionProductNew, function (data) {
                                                    $ValidTxn = data.IsValidTxn;
                                                    var $txtConditionTxnSysID = $('#txtConditionTxnSysID').val(data.TxnSysID);
                                                    if ($ValidTxn == true) {
                                                        var rowNodes = $TblCertificateCondition.row.add([data.ConditionShText, data.TxnSysID, data.Condition, data.ParentTxnSysID]).draw();
                                                        $('#SubmitModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#SubmitModal').modal('hide')
                                                        }, 2000);
                                                    } else {
                                                        $TxnErrors = data.TxnErrors;
                                                        for (var i = 0; i < $TxnErrors.length; i++) {
                                                            $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                                                        }
                                                        $('#ErrorModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#ErrorModal').modal('hide')
                                                        }, 2000);
                                                    }
                                                });
                                            }
                                            // If ConditionProductRowIndex is 1 update row on table
                                            else {
                                                var $ConditionInsuranceRowIndex = $("#ConditionInsuranceRowIndex").val();
                                                var array = $TblCertificateCondition.row($ConditionInsuranceRowIndex).data();
                                                var $BtnConditionProductUpdate = {
                                                    TxnSysID: $txtConditionTxnSysID,
                                                    ParentTxnSysID: $txtConditionPrdStpTxnSysId,
                                                    Condition: $ddlConditionValue,
                                                };
                                                var $BtnConditionProductUpdate = JSON.stringify($BtnConditionProductUpdate);
                                                $.get("http://207.180.200.121/mtrprodsetup/InsMtrConditions/UpdateInsConditions?_Json=" + $BtnConditionProductUpdate, function (data) {
                                                    $ValidTxn = data.IsValidTxn;
                                                    if ($ValidTxn == true) {
                                                        $('#UpdatedModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#UpdatedModal').modal('hide')
                                                        }, 2000);
                                                        array[0] = $ddlCondition;
                                                        array[1] = $txtConditionTxnSysID;
                                                        array[2] = $ddlConditionValue;
                                                        array[3] = $txtConditionPrdStpTxnSysId;
                                                        $TblCertificateCondition.row($ConditionInsuranceRowIndex).data(array);
                                                        $TblCertificateCondition.row($ConditionInsuranceRowIndex).invalidate();
                                                        $TblCertificateCondition.draw(false);
                                                    } else {
                                                        $TxnErrors = data.TxnErrors;
                                                        for (var i = 0; i < $TxnErrors.length; i++) {
                                                            $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].ErrorCode + '-' + $TxnErrors[i].Error + '</span>');
                                                        }
                                                        $('#ErrorModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#ErrorModal').modal('hide')
                                                        }, 2000);
                                                    }
                                                });
                                            }
                                        }
                                    });
                                    $('#TblCertificateCondition tbody').on('click', 'tr', function () {
                                        var $selValue = $TblCertificateCondition.row(this).data();
                                        var test = $("#ConditionInsuranceRowIndex").val($TblCertificateCondition.row(this).index);

                                        $rowIdx = $TblCertificateCondition.row(this).index;

                                        $("#TblCertificateCondition").val($rowIdx);
                                        $row = $TblCertificateCondition.row(this).node();
                                        $($row).addClass('ready');
                                        $("#txtConditionTxnSysID").val($selValue[1]);
                                        $ddlCondition = $selValue[2];
                                        $('#ddlCondition').val($ddlCondition).trigger('change');
                                        $("#txtConditionPrdStpTxnSysId").val($selValue[3]);
                                    });

                                });
                                //Insurance WarrantyCode
                                $(document).ready(function () {
                                    // By Default  WarrantyCertificateRowIndex is -1
                                    $("#WarrantyCertificateRowIndex").val("-1");
                                    $('#TblCertificateWarranty').DataTable().clear().destroy();
                                    var $ddlCertificateClientCode = $('#ddlCertificateClientCode').val();
                                    var $TblCertificateWarranty = $("#TblCertificateWarranty").DataTable({
                                        "order": [
                                            [0, "desc"]
                                        ],
                                        "paging": true,
                                        "pageLength": 5,
                                        "searching": true,
                                    });
                                    // Calling Warranty Values in table by Ajax
                                    $.ajax({
                                        url: 'http://207.180.200.121/mtrprodsetup/InsMtrWarranties/GetMtrWarranties?_Json={"ParentTxnSysID":"' + $InsPolicyTxnId + '"}',
                                        type: 'get',
                                        dataType: "JSON",
                                        success: function (response) {
                                            var len = response.length;
                                            for (var i = 0; i < len; i++) {
                                                var $Warranty = response[i].Warranty
                                                var $WarrantyPrdStpTxnSysId = response[i].ParentTxnSysID
                                                var $TxnSysID = response[i].TxnSysID;
                                                var $TxnSysID = response[i].TxnSysID;
                                                var $WarrantyShText = response[i].WarrantyShText;
                                                $TblCertificateWarranty.row.add([$WarrantyShText, $WarrantyPrdStpTxnSysId, $TxnSysID, $Warranty]).draw(false);
                                            }
                                        }
                                    });

                                    $("#BtnCertificateWarrantyNew").on("click", function () {
                                        $('#ddlWarranty').focus();
                                        $('#txtWarrantyText').val('');
                                        $("#txWarrantyTxnSysID").val('');
                                        $("#ddlWarranty").select2("val", 0);
                                        $("#WarrantyCertificateRowIndex").val("-1");
                                    });
                                    // On Click Listener of Save Button to Add or Update Database
                                    $("#BtnCertificateWarrantySave").on("click", function () {
                                        var $txtWarrantyUserCode = $('#txtWarrantyUserCode').val($useridparameters);
                                        var txtTxnSysID = $('#txtTxnSysID').val();
                                        document.getElementById("txtWarrantyPrdStpTxnSysId").setAttribute("value", txtTxnSysID);
                                        var $txtWarrantyPrdStpTxnSysId = $('#txtWarrantyPrdStpTxnSysId').val();
                                        var $txWarrantyTxnSysID = $('#txWarrantyTxnSysID').val();
                                        var $ddlWarranty = $("#ddlWarranty").find('option:selected').text();
                                        var $ddlWarrantyValue = $("#ddlWarranty").find('option:selected').val();
                                        if (!$ddlWarrantyValue) {
                                            $("select[name='ddlWarranty']").addClass("reqirederror");
                                            return false;
                                            document.getElementById("test").innerHTML = "Please Select Warranty";
                                            $('#ErrorModalValidate').modal('show');
                                            setTimeout(function () {
                                                $('#ErrorModalValidate').modal('hide')
                                            }, 2000);
                                            $('#ddlWarranty').focus().val($('#ddlWarranty').val());
                                            return false;
                                        } else {
                                            // If WarrantyCertificateRowIndex is -1 add new row on table
                                            if ($("#WarrantyCertificateRowIndex").val() == "-1") {
                                                var $BtnWarrantyProductNew = {
                                                    ParentTxnSysID: $txtWarrantyPrdStpTxnSysId,
                                                    Warranty: $ddlWarrantyValue,
                                                };
                                                var $BtnWarrantyProductNew = JSON.stringify($BtnWarrantyProductNew);
                                                $.get("http://207.180.200.121/mtrprodsetup/InsMtrWarranties/AddInsMtrWarranties?_Json=" + $BtnWarrantyProductNew, function (data) {
                                                    $ValidTxn = data.IsValidTxn;
                                                    if ($ValidTxn == true) {
                                                        var rowNodes = $TblCertificateWarranty.row.add([data.WarrantyShText, data.ParentTxnSysID, data.TxnSysID, data.Warranty]).draw();
                                                        $('#SubmitModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#SubmitModal').modal('hide')
                                                        }, 2000);
                                                    } else {
                                                        $TxnErrors = data.TxnErrors;
                                                        for (var i = 0; i < $TxnErrors.length; i++) {
                                                            $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                                                        }
                                                        $('#ErrorModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#ErrorModal').modal('hide')
                                                        }, 2000);
                                                    }
                                                });
                                            } else {
                                                var $WarrantyCertificateRowIndex = $("#WarrantyCertificateRowIndex").val();
                                                var array = $TblCertificateWarranty.row($WarrantyCertificateRowIndex).data();
                                                var $BtnWarrantyProductUpdate = {
                                                    TxnSysID: $txWarrantyTxnSysID,
                                                    ParentTxnSysID: $txtWarrantyPrdStpTxnSysId,
                                                    Warranty: $ddlWarranty,
                                                };
                                                var $BtnWarrantyProductUpdate = JSON.stringify($BtnWarrantyProductUpdate);
                                                $.get("http://207.180.200.121/mtrprodsetup/InsMtrWarranties/UpdateInsMtrWarranties?_Json=" + $BtnWarrantyProductUpdate, function (data) {
                                                    $ValidTxn = data.IsValidTxn;
                                                    if ($ValidTxn == true) {
                                                        $('#UpdatedModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#UpdatedModal').modal('hide')
                                                        }, 2000);
                                                        array[0] = $ddlWarranty;
                                                        array[1] = $txtWarrantyPrdStpTxnSysId;
                                                        array[2] = $txWarrantyTxnSysID;
                                                        array[3] = $ddlWarrantyValue;
                                                        $TblCertificateWarranty.row($WarrantyCertificateRowIndex).data(array);
                                                        $TblCertificateWarranty.row($WarrantyCertificateRowIndex).invalidate();
                                                        $TblCertificateWarranty.draw(false);
                                                    } else {
                                                        $TxnErrors = data.TxnErrors;
                                                        for (var i = 0; i < $TxnErrors.length; i++) {
                                                            $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].ErrorCode + '-' + $TxnErrors[i].Error + '</span>');
                                                        }
                                                        $('#ErrorModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#ErrorModal').modal('hide')
                                                        }, 2000);
                                                    }
                                                });

                                            }
                                        }
                                    });
                                    $('#TblCertificateWarranty tbody').on('click', 'tr', function () {
                                        $("#WarrantyCertificateRowIndex").val($TblCertificateWarranty.row(this).index);
                                        var $selValue = $TblCertificateWarranty.row(this).data();
                                        $rowIdx = $TblCertificateWarranty.row(this).index;
                                        $("#TblConditionProductSetup").val($rowIdx);
                                        $row = $TblCertificateWarranty.row(this).node();
                                        $($row).addClass('ready');

                                        $ddlWarranty = $selValue[3];
                                        $('#ddlWarranty').val($ddlWarranty).trigger('change');

                                        $("#txtWarrantyPrdStpTxnSysId").val($selValue[1]);
                                        $("#txWarrantyTxnSysID").val($selValue[2]);

                                    });
                                });
                                //Product Rider
                                $(document).ready(function () {
                                    // By Default  RiderProductRowIndex is -1
                                    $("#RiderProductRowIndex").val("-1");
                                    $('#TblRiderProductSetup').DataTable().clear().destroy();
                                    var $ddlCertificateClientCode = $('#ddlCertificateClientCode').val();
                                    var $TblRiderProductSetup = $("#TblRiderProductSetup").DataTable({
                                        "order": [
                                            [0, "desc"]
                                        ],
                                        "paging": true,
                                        "pageLength": 5,
                                        "searching": true,
                                    });
                                    // Calling Rider Values in table by Ajax
                                    $.ajax({
                                        url: 'http://207.180.200.121/mtrprodsetup/InsMtrRider/GetInsMtrRider?_Json={"ParentTxnSysID":"' + $InsPolicyTxnId + '"}',
                                        type: 'get',
                                        dataType: "JSON",
                                        success: function (response) {
                                            var len = response.length;
                                            for (var i = 0; i < len; i++) {
                                                var $RiderCode = response[i].RiderCode
                                                var $RiderName = response[i].RiderName
                                                var $RiderRate = response[i].RiderRate;
                                                var $PrdStpTxnSysId = response[i].ParentTxnSysID;
                                                var $TxnSysID = response[i].TxnSysID;
                                                $TblRiderProductSetup.row.add([$RiderCode, $RiderName, $RiderRate, $PrdStpTxnSysId, $TxnSysID]).draw(false);
                                            }
                                        }
                                    });
                                    $("#BtnRiderProductNew").on("click", function () {
                                        $('#ddlRider').focus();
                                        $('#ddlRiderAmount').val('');
                                        $("#txRiderTxnSysID").val('');
                                        $("#ddlRider").select2("val", 0);
                                        $("#RiderProductRowIndex").val("-1");
                                    });
                                    // On Click Listener of Save Button to Add or Update Database
                                    $("#BtnRiderProductSave").on("click", function () {
                                        var txtTxnSysID = $('#txtTxnSysID').val();
                                        document.getElementById("txtRiderPrdStpTxnSysId").setAttribute("value", txtTxnSysID);
                                        var $txtRiderPrdStpTxnSysId = $('#txtRiderPrdStpTxnSysId').val();
                                        var $txRiderTxnSysID = $('#txRiderTxnSysID').val();
                                        var $ddlRider = $("#ddlRider").find('option:selected').text();
                                        var $ddlRiderValue = $("#ddlRider").find('option:selected').val();
                                        var $ddlRiderAmount = $('#ddlRiderAmount').val();
                                        if (!$ddlRiderValue) {
                                            document.getElementById("test").innerHTML = "Please Select Rider";
                                            $('#ErrorModalValidate').modal('show');
                                            setTimeout(function () {
                                                $('#ErrorModalValidate').modal('hide')
                                            }, 2000);
                                            $('#ddlRiderValue').focus().val($('#ddlRiderValue').val());
                                            return false;
                                        }
                                        if (!$ddlRiderAmount) {
                                            document.getElementById("test").innerHTML = "Please Fill Rider Amount";
                                            $('#ErrorModalValidate').modal('show');
                                            setTimeout(function () {
                                                $('#ErrorModalValidate').modal('hide')
                                            }, 2000);
                                            $('#ddlRiderAmount').focus().val($('#ddlRiderAmount').val());
                                            return false;
                                        } else {
                                            // If RiderProductRowIndex is -1 add new row on table
                                            if ($("#RiderProductRowIndex").val() == "-1") {
                                                var $BtnRiderProductNew = {
                                                    ParentTxnSysID: $txtRiderPrdStpTxnSysId,
                                                    RiderCode: $ddlRiderValue,
                                                    RiderName: $ddlRider,
                                                    RiderRate: $ddlRiderAmount,
                                                };
                                                var $BtnRiderProductNew = JSON.stringify($BtnRiderProductNew);
                                                $.get("http://207.180.200.121/mtrprodsetup/InsMtrRider/AddInsRider?_Json=" + $BtnRiderProductNew, function (data) {
                                                    $ValidTxn = data.IsValidTxn;
                                                    if ($ValidTxn == true) {
                                                        var rowNodes = $TblRiderProductSetup.row.add([data.RiderCode, data.RiderName, data.RiderRate, data.ParentTxnSysID, data.TxnSysID]).draw();
                                                        $('#SubmitModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#SubmitModal').modal('hide')
                                                        }, 2000);
                                                    } else {
                                                        $TxnErrors = data.TxnErrors;
                                                        for (var i = 0; i < $TxnErrors.length; i++) {
                                                            $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                                                        }
                                                        $('#ErrorModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#ErrorModal').modal('hide')
                                                        }, 2000);
                                                    }
                                                });
                                            } else {
                                                var $RiderProductRowIndex = $("#RiderProductRowIndex").val();
                                                var array = $TblRiderProductSetup.row($RiderProductRowIndex).data();
                                                var $BtnRiderProductUpdate = {
                                                    TxnSysID: $txRiderTxnSysID,
                                                    ParentTxnSysID: $txtRiderPrdStpTxnSysId,
                                                    RiderCode: $ddlRiderValue,
                                                    RiderName: $ddlRider,
                                                    RiderRate: $ddlRiderAmount,
                                                };
                                                var $BtnRiderProductUpdate = JSON.stringify($BtnRiderProductUpdate);
                                                $.get("http://207.180.200.121/mtrprodsetup/InsMtrRider/UpdateInsRider?_Json=" + $BtnRiderProductUpdate, function (data) {
                                                    $ValidTxn = data.IsValidTxn;
                                                    if ($ValidTxn == true) {
                                                        $('#UpdatedModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#UpdatedModal').modal('hide')
                                                        }, 2000);
                                                        array[0] = $ddlRiderValue;
                                                        array[1] = $ddlRider;
                                                        array[2] = $ddlRiderAmount;
                                                        array[3] = $txtRiderPrdStpTxnSysId;
                                                        array[4] = $txRiderTxnSysID;
                                                        $TblRiderProductSetup.row($RiderProductRowIndex).data(array);
                                                        $TblRiderProductSetup.row($RiderProductRowIndex).invalidate();
                                                        $TblRiderProductSetup.draw(false);
                                                    } else {
                                                        $TxnErrors = data.TxnErrors;
                                                        for (var i = 0; i < $TxnErrors.length; i++) {
                                                            $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].ErrorCode + '-' + $TxnErrors[i].Error + '</span>');
                                                        }
                                                        $('#ErrorModal').modal('show');
                                                        setTimeout(function () {
                                                            $('#ErrorModal').modal('hide')
                                                        }, 2000);
                                                    }
                                                });

                                            }
                                        }
                                    });
                                    $('#TblRiderProductSetup tbody').on('click', 'tr', function () {
                                        $("#RiderProductRowIndex").val($TblRiderProductSetup.row(this).index);
                                        var $selValue = $TblRiderProductSetup.row(this).data();
                                        $rowIdx = $TblRiderProductSetup.row(this).index;
                                        $("#TblConditionProductSetup").val($rowIdx);
                                        $row = $TblRiderProductSetup.row(this).node();
                                        $($row).addClass('ready');
                                        $("#txtRiderPrdStpTxnSysId").val($selValue[3]);
                                        $("#txRiderTxnSysID").val($selValue[4]);
                                        $("#ddlRiderAmount").val($selValue[2]);
                                        $ddlRider = $selValue[0];
                                        $('#ddlRider').val($ddlRider).trigger('change');

                                    });
                                });
                                var $CalculatedSysId = data.TxnSysID;
                                //Destroy TblCalculatedContribution
                                $('#TblCalculatedContribution').DataTable().clear().destroy();
                                // Getting All Records For Calculated Contribution
                                var $TblCalculatedContribution = $("#TblCalculatedContribution").DataTable({
                                    "order": [
                                        [0, "desc"]
                                    ],
                                    "paging": false,
                                    "pageLength": 5,
                                    "searching": false,
                                });
                                var $CalculatedContributionApi = {
                                    ParticipantValue: $txtVehicleValue,
                                    Rate: $txtRate,
                                    TxnSysID: $CalculatedSysId,
                                };
                                var $CalculatedContributionApi = JSON.stringify($CalculatedContributionApi);
                                $.ajax({
                                    url: 'http://207.180.200.121/mtrprodsetup/MtrVContribution/GetMtrVContributionForPol?_Json=' + $CalculatedContributionApi,
                                    type: 'get',
                                    dataType: "JSON",
                                    success: function (response) {
                                        var len = response.length;
                                        for (var i = 0; i < len; i++) {
                                            var $Stamp = response[i].Stamp;
                                            var $Rate = response[i].Rate;
                                            /*var $BasicContribution = response[i].BasicContribution;*/
                                            var $PEV = response[i].PEV;
                                            /*var $TerrorContribution = response[i].TerrorContribution;*/
                                            var $GrossContribution = response[i].GrossContribution;
                                            /*var $BeforePEV = response[i].BeforePEV;*/
                                            /*var $FIF = response[i].FIF;
                                            var $FED = response[i].FED;*/
                                            var $NetContribution = response[i].NetContribution;
                                            /*var $RiskTxnID = response[i].RiskTxnID;*/
                                            var $SumCovered = response[i].SumCovered;
                                            /*var $PerDayContribution = response[i].PerDayContribution;*/
                                            $TblCalculatedContribution.row.add([$Stamp, $Rate, $GrossContribution, $SumCovered, $NetContribution, $PEV]).draw(false);
                                        }
                                    }
                                });
                                //Destroy TblCalculatedContribution
                                $('#insurerTbl').DataTable().clear().destroy();
                                // Getting All Records For Calculated Contribution
                                $("#CoInsuranceRowIndex").val("-1");
                                $insurerTbl = $("#insurerTbl").DataTable({
                                    "order": [
                                        [0, "desc"]
                                    ],
                                    "paging": false,
                                    "pageLength": 5,
                                    "searching": false,
                                });
                                $("#BtnCoInsuranceNew").on("click", function () {
                                    $('#ddlParttaker').focus();
                                    $("#txtCoInsuranceShare").val('');
                                    $("#ddlParttaker").select2("val", 0);
                                    $("#CoInsuranceRowIndex").val("-1");
                                });
                                $("#BbtnCoInsuranceSave").on("click", function () {

                                    var $txtCoInsuranceCodeValue = $("#ddlParttaker").find('option:selected').val();
                                    var $txtCoInsuranceCode = $("#ddlParttaker").find('option:selected').text();
                                    var $txtCoInsuranceShare = $('#txtCoInsuranceShare').val();
                                    if ($txtCoInsuranceCodeValue == 'txtCoInsuranceCodeValue' || $txtCoInsuranceCodeValue == '') {
                                        $("select[name='ddlParttaker']").addClass("reqirederror");
                                        return false;
                                    }
                                    if (!$txtCoInsuranceShare) {
                                        $("input[name='txtCoInsuranceShare']").addClass("reqirederror");
                                        return false;
                                    }
                                    if ($txtCoInsuranceShare > 100) {
                                        $("input[name='txtCoInsuranceShare']").addClass("reqirederror");
                                        return false;
                                    } else {
                                        if ($("#CoInsuranceRowIndex").val() == "-1") {
                                            var $BtnCoInsuranceNew = {
                                                TxnSysID: $CalculatedSysId,
                                                CoInsuranceCode: $txtCoInsuranceCodeValue,
                                                CoInsuranceShare: $txtCoInsuranceShare,
                                            };
                                            var $BtnCoInsuranceNew = JSON.stringify($BtnCoInsuranceNew);
                                            $.get("http://207.180.200.121/mtrprodsetup/InsCoInsurance/GetInsCoInsurance/?_Json=" + $BtnCoInsuranceNew, function (data) {
                                                $ValidTxnInsurer = data.IsValidTxn;
                                                $CoInsuranceTxnSysID = data.TxnSysID;
                                                if ($ValidTxnInsurer == true) {
                                                    var rowNodes = $insurerTbl.row.add([data.TxnSysID, data.CoInsuranceCode, data.PartTakerName, data.CoInsuranceShare, data.GrossContribution, data.FED, data.FIF, data.NetContribution]).draw();
                                                    $('#SubmitModal').modal('show');
                                                    setTimeout(function () {
                                                        $('#SubmitModal').modal('hide')
                                                    }, 2000);
                                                } else {
                                                    $TxnErrors = data.TxnErrors;
                                                    for (var i = 0; i < $TxnErrors.length; i++) {
                                                        $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                                                    }
                                                    $('#ErrorModal').modal('show');
                                                    setTimeout(function () {
                                                        $('#ErrorModal').modal('hide')
                                                    }, 2000);
                                                }
                                            });
                                        } else {
                                            var $CoInsuranceRowIndex = $("#CoInsuranceRowIndex").val();
                                            var array = $insurerTbl.row($CoInsuranceRowIndex).data();
                                            var $BtnCoInsuranceUpdate = {
                                                TxnSysID: $CoInsuranceTxnSysID,
                                                CoInsuranceCode: $txtCoInsuranceCodeValue,
                                                CoInsuranceShare: $txtCoInsuranceShare,
                                            };
                                            var $BtnCoInsuranceUpdate = JSON.stringify($BtnCoInsuranceUpdate);
                                            $.get("http://207.180.200.121/mtrprodsetup/InsCoInsurance/UpdateInsCoInsurance/?_Json=" + $BtnCoInsuranceUpdate, function (data) {
                                                $ValidTxn = data.IsValidTxn;
                                                if ($ValidTxn == true) {
                                                    $('#UpdatedModal').modal('show');
                                                    setTimeout(function () {
                                                        $('#UpdatedModal').modal('hide')
                                                    }, 2000);
                                                    array[1] = $txtCoInsuranceCodeValue;
                                                    array[2] = $txtCoInsuranceCode;
                                                    array[3] = $txtCoInsuranceShare;
                                                    $insurerTbl.row($CoInsuranceRowIndex).data(array);
                                                    $insurerTbl.row($CoInsuranceRowIndex).invalidate();
                                                    $insurerTbl.draw(false);
                                                } else {
                                                    $TxnErrors = data.TxnErrors;
                                                    for (var i = 0; i < $TxnErrors.length; i++) {
                                                        $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].ErrorCode + '-' + $TxnErrors[i].Error + '</span>');
                                                    }
                                                    $('#ErrorModal').modal('show');
                                                    setTimeout(function () {
                                                        $('#ErrorModal').modal('hide')
                                                    }, 2000);
                                                }
                                            });
                                        }

                                        $('#insurerTbl tbody').on('click', 'tr', function () {
                                            $("#CoInsuranceRowIndex").val($insurerTbl.row(this).index);
                                            var $selValues = $insurerTbl.row(this).data();
                                            $rowIdx = $insurerTbl.row(this).index;
                                            $("#insurerTbl").val($rowIdx);
                                            $row = $insurerTbl.row(this).node();
                                            $($row).addClass('ready');

                                            $ddlParttaker = $selValues[1];
                                            $('#ddlParttaker').val($ddlParttaker).trigger('change');
                                            $("#txtCoInsuranceShare").val($selValues[3]);
                                            $('#Correction').show();
                                            $("#InsuranceRowIndex").val("-1");
                                            $("#BtnCorrection").on("click", function () {
                                                $('#DivOne').show();
                                                $('#DiveTwo').show();
                                                $('#BtnOne').show();
                                                $('#BtnTwo').show();
                                            });
                                            $("#BtnInsuranceNew").on("click", function () {
                                                $('#ddlCoInsElement').focus();
                                                $("#txtAmount").val('');
                                                $("#ddlCoInsElement").select2("val", 0);
                                                $("#InsuranceRowIndex").val("-1");
                                            });
                                            $("#BtnInsuranceSave").on("click", function () {
                                                var $ddlCoInsElementValue = $("#ddlCoInsElement").find('option:selected').val();
                                                var $ddlCoInsElement = $("#ddlCoInsElement").find('option:selected').text();
                                                var $txtAmount = $('#txtAmount').val();
                                                if ($ddlCoInsElementValue == 'Choose Element' || $ddlCoInsElementValue == '') {
                                                    $("select[name='ddlCoInsElement']").addClass("reqirederror");
                                                    return false;
                                                }
                                                if (!$txtAmount) {
                                                    $("input[name='txtAmount']").addClass("reqirederror");
                                                    return false;
                                                }
                                                if ($("#InsuranceRowIndex").val() == "-1") {
                                                    if ($ddlCoInsElementValue == '1') {
                                                        var $BtnInsuranceNew = {
                                                            TxnSysID: $selValues[0],
                                                            ElementCode: $ddlCoInsElementValue,
                                                            GrossContribution: $txtAmount,
                                                        };
                                                        var $BtnInsuranceNew = JSON.stringify($BtnInsuranceNew);
                                                        $.get("http://207.180.200.121/mtrprodsetup/InsCoInsurance/UpdateInsCoInsuranceByElement/?_Json=" + $BtnInsuranceNew, function (data) {
                                                            $ValidTxnInsurer = data.IsValidTxn;
                                                            if ($ValidTxnInsurer == true) {

                                                                //Destroy TblCalculatedContribution
                                                                $('#insurerTbl').DataTable().clear().destroy();
                                                                // Getting All Records For Calculated Contribution
                                                                var $insurerTbl = $("#insurerTbl").DataTable({
                                                                    "order": [
                                                                        [0, "desc"]
                                                                    ],
                                                                    "paging": false,
                                                                    "pageLength": 5,
                                                                    "searching": false,
                                                                });
                                                                $.ajax({
                                                                    url: 'http://207.180.200.121/mtrprodsetup/InsCoInsurance/GetAllInsCoInsurance?_Json={"TxnSysID":' + $CalculatedSysId + '}',
                                                                    type: 'get',
                                                                    dataType: "JSON",
                                                                    success: function (response) {
                                                                        var len = response.length;
                                                                        for (var i = 0; i < len; i++) {
                                                                            var $TxnSysID = response[i].TxnSysID;
                                                                            var $CoInsuranceCode = response[i].CoInsuranceCode;
                                                                            var $PartTakerName = response[i].PartTakerName;
                                                                            var $CoInsuranceShare = response[i].CoInsuranceShare;
                                                                            var $GrossContribution = response[i].GrossContribution;
                                                                            var $FED = response[i].FED;
                                                                            var $FIF = response[i].FIF;
                                                                            var $NetContribution = response[i].NetContribution;
                                                                            $insurerTbl.row.add([$TxnSysID, $CoInsuranceCode, $PartTakerName, $CoInsuranceShare, $GrossContribution, $FED, $FIF, $NetContribution]).draw(false);
                                                                        }
                                                                    }
                                                                });
                                                                $('#SubmitModal').modal('show');
                                                                setTimeout(function () {
                                                                    $('#SubmitModal').modal('hide')
                                                                }, 2000);
                                                            } else {
                                                                $TxnErrors = data.TxnErrors;
                                                                for (var i = 0; i < $TxnErrors.length; i++) {
                                                                    $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                                                                }
                                                                $('#ErrorModal').modal('show');
                                                                setTimeout(function () {
                                                                    $('#ErrorModal').modal('hide')
                                                                }, 2000);
                                                            }
                                                        });
                                                    }
                                                    if ($ddlCoInsElementValue == '2') {
                                                        var $BtnInsuranceNew = {
                                                            TxnSysID: $selValues[0],
                                                            ElementCode: $ddlCoInsElementValue,
                                                            NetContribution: $txtAmount,
                                                        };
                                                        var $BtnInsuranceNew = JSON.stringify($BtnInsuranceNew);
                                                        $.get("http://207.180.200.121/mtrprodsetup/InsCoInsurance/UpdateInsCoInsuranceByElement/?_Json=" + $BtnInsuranceNew, function (data) {
                                                            $ValidTxnInsurer = data.IsValidTxn;
                                                            if ($ValidTxnInsurer == true) {
                                                                //Destroy TblCalculatedContribution
                                                                $('#insurerTbl').DataTable().clear().destroy();
                                                                // Getting All Records For Calculated Contribution
                                                                var $insurerTbl = $("#insurerTbl").DataTable({
                                                                    "order": [
                                                                        [0, "desc"]
                                                                    ],
                                                                    "paging": false,
                                                                    "pageLength": 5,
                                                                    "searching": false,
                                                                });
                                                                $.ajax({
                                                                    url: 'http://207.180.200.121/mtrprodsetup/InsCoInsurance/GetAllInsCoInsurance?_Json={"TxnSysID":' + $CalculatedSysId + '}',
                                                                    type: 'get',
                                                                    dataType: "JSON",
                                                                    success: function (response) {
                                                                        var len = response.length;
                                                                        for (var i = 0; i < len; i++) {
                                                                            var $TxnSysID = response[i].TxnSysID;
                                                                            var $CoInsuranceCode = response[i].CoInsuranceCode;
                                                                            var $PartTakerName = response[i].PartTakerName;
                                                                            var $CoInsuranceShare = response[i].CoInsuranceShare;
                                                                            var $GrossContribution = response[i].GrossContribution;
                                                                            var $FED = response[i].FED;
                                                                            var $FIF = response[i].FIF;
                                                                            var $NetContribution = response[i].NetContribution;
                                                                            $insurerTbl.row.add([$TxnSysID, $CoInsuranceCode, $PartTakerName, $CoInsuranceShare, $GrossContribution, $FED, $FIF, $NetContribution]).draw(false);
                                                                        }
                                                                    }
                                                                });
                                                                $('#SubmitModal').modal('show');
                                                                setTimeout(function () {
                                                                    $('#SubmitModal').modal('hide')
                                                                }, 2000);
                                                            } else {
                                                                $TxnErrors = data.TxnErrors;
                                                                for (var i = 0; i < $TxnErrors.length; i++) {
                                                                    $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                                                                }
                                                                $('#ErrorModal').modal('show');
                                                                setTimeout(function () {
                                                                    $('#ErrorModal').modal('hide')
                                                                }, 2000);
                                                            }
                                                        });
                                                    }
                                                    if ($ddlCoInsElementValue == '3') {
                                                        var $BtnInsuranceNew = {
                                                            TxnSysID: $selValues[0],
                                                            ElementCode: $ddlCoInsElementValue,
                                                            FIF: $txtAmount,
                                                        };
                                                        var $BtnInsuranceNew = JSON.stringify($BtnInsuranceNew);
                                                        $.get("http://207.180.200.121/mtrprodsetup/InsCoInsurance/UpdateInsCoInsuranceByElement/?_Json=" + $BtnInsuranceNew, function (data) {
                                                            $ValidTxnInsurer = data.IsValidTxn;
                                                            if ($ValidTxnInsurer == true) {
                                                                //Destroy TblCalculatedContribution
                                                                $('#insurerTbl').DataTable().clear().destroy();
                                                                // Getting All Records For Calculated Contribution
                                                                var $insurerTbl = $("#insurerTbl").DataTable({
                                                                    "order": [
                                                                        [0, "desc"]
                                                                    ],
                                                                    "paging": false,
                                                                    "pageLength": 5,
                                                                    "searching": false,
                                                                });
                                                                $.ajax({
                                                                    url: 'http://207.180.200.121/mtrprodsetup/InsCoInsurance/GetAllInsCoInsurance?_Json={"TxnSysID":' + $CalculatedSysId + '}',
                                                                    type: 'get',
                                                                    dataType: "JSON",
                                                                    success: function (response) {
                                                                        var len = response.length;
                                                                        for (var i = 0; i < len; i++) {
                                                                            var $TxnSysID = response[i].TxnSysID;
                                                                            var $CoInsuranceCode = response[i].CoInsuranceCode;
                                                                            var $PartTakerName = response[i].PartTakerName;
                                                                            var $CoInsuranceShare = response[i].CoInsuranceShare;
                                                                            var $GrossContribution = response[i].GrossContribution;
                                                                            var $FED = response[i].FED;
                                                                            var $FIF = response[i].FIF;
                                                                            var $NetContribution = response[i].NetContribution;
                                                                            $insurerTbl.row.add([$TxnSysID, $CoInsuranceCode, $PartTakerName, $CoInsuranceShare, $GrossContribution, $FED, $FIF, $NetContribution]).draw(false);
                                                                        }
                                                                    }
                                                                });
                                                                $('#SubmitModal').modal('show');
                                                                setTimeout(function () {
                                                                    $('#SubmitModal').modal('hide')
                                                                }, 2000);
                                                            } else {
                                                                $TxnErrors = data.TxnErrors;
                                                                for (var i = 0; i < $TxnErrors.length; i++) {
                                                                    $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                                                                }
                                                                $('#ErrorModal').modal('show');
                                                                setTimeout(function () {
                                                                    $('#ErrorModal').modal('hide')
                                                                }, 2000);
                                                            }
                                                        });
                                                    }
                                                    if ($ddlCoInsElementValue == '4') {
                                                        var $BtnInsuranceNew = {
                                                            TxnSysID: $selValues[0],
                                                            ElementCode: $ddlCoInsElementValue,
                                                            FED: $txtAmount,
                                                        };
                                                        var $BtnInsuranceNew = JSON.stringify($BtnInsuranceNew);
                                                        $.get("http://207.180.200.121/mtrprodsetup/InsCoInsurance/UpdateInsCoInsuranceByElement/?_Json=" + $BtnInsuranceNew, function (data) {
                                                            $ValidTxnInsurer = data.IsValidTxn;
                                                            if ($ValidTxnInsurer == true) {
                                                                //Destroy TblCalculatedContribution
                                                                $('#insurerTbl').DataTable().clear().destroy();
                                                                // Getting All Records For Calculated Contribution
                                                                var $insurerTbl = $("#insurerTbl").DataTable({
                                                                    "order": [
                                                                        [0, "desc"]
                                                                    ],
                                                                    "paging": false,
                                                                    "pageLength": 5,
                                                                    "searching": false,
                                                                });
                                                                $.ajax({
                                                                    url: 'http://207.180.200.121/mtrprodsetup/InsCoInsurance/GetAllInsCoInsurance?_Json={"TxnSysID":' + $CalculatedSysId + '}',
                                                                    type: 'get',
                                                                    dataType: "JSON",
                                                                    success: function (response) {
                                                                        var len = response.length;
                                                                        for (var i = 0; i < len; i++) {
                                                                            var $TxnSysID = response[i].TxnSysID;
                                                                            var $CoInsuranceCode = response[i].CoInsuranceCode;
                                                                            var $PartTakerName = response[i].PartTakerName;
                                                                            var $CoInsuranceShare = response[i].CoInsuranceShare;
                                                                            var $GrossContribution = response[i].GrossContribution;
                                                                            var $FED = response[i].FED;
                                                                            var $FIF = response[i].FIF;
                                                                            var $NetContribution = response[i].NetContribution;
                                                                            $insurerTbl.row.add([$TxnSysID, $CoInsuranceCode, $PartTakerName, $CoInsuranceShare, $GrossContribution, $FED, $FIF, $NetContribution]).draw(false);
                                                                        }
                                                                    }
                                                                });
                                                                $('#SubmitModal').modal('show');
                                                                setTimeout(function () {
                                                                    $('#SubmitModal').modal('hide')
                                                                }, 2000);
                                                            } else {
                                                                $TxnErrors = data.TxnErrors;
                                                                for (var i = 0; i < $TxnErrors.length; i++) {
                                                                    $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                                                                }
                                                                $('#ErrorModal').modal('show');
                                                                setTimeout(function () {
                                                                    $('#ErrorModal').modal('hide')
                                                                }, 2000);
                                                            }
                                                        });
                                                    }

                                                }
                                            });
                                        });
                                    }

                                });

                            } else {
                                $TxnErrors = data.TxnErrors;
                                for (var i = 0; i < $TxnErrors.length; i++) {
                                    $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                                }
                                $('#ErrorModal').modal('show');
                                setTimeout(function () {
                                    $('#ErrorModal').modal('hide')
                                }, 2000);
                            }
                        });
                    } else {
                        $.fn.dataTable.ext.errMode = 'none';
                        var $txtMileage = $('#txtMileage').val();
                        var $ddlCityCodeValue = $("#ddlCityCode").find('option:selected').val();
                        var $txtBirthDate = $('#txtBirthDate').val();
                        //For  Birth Date Format
                        var $DateBirth = $txtBirthDate;
                        var $txtBirthDate = $DateBirth.replace(/\//g, '-')

                        var $txtBirthDate = $txtBirthDate.split('-');
                        var $txtBirthDate = $txtBirthDate[1] + '-' + $txtBirthDate[0] + '-' + $txtBirthDate[2];

                        var $ddlGenderValue = $("#ddlGender").find('option:selected').val();

                        //For  Contract Maturity Datee Format
                        var $txtContractMaturityDate = $('#txtBirthDate').val();
                        var $DateContract = $txtContractMaturityDate;
                        var $txtContractMaturityDate = $DateContract.replace(/\//g, '-')

                        var $txtContractMaturityDate = $txtContractMaturityDate.split('-');
                        var $txtContractMaturityDate = $txtContractMaturityDate[1] + '-' + $txtContractMaturityDate[0] + '-' + $txtContractMaturityDate[2];

                        var $txtDeductible = $('#txtDeductible').val();

                        var $ddlTakafulTypeValue = $("#ddlTakafulType").find('option:selected').val();
                        var $ddlTakafulType= $("#ddlTakafulType").find('option:selected').text();

                        var $ddlVEODCodeValue = $("#ddlVEODCode").find('option:selected').val();

                        var $ddlVehicleTypeValue = $("#ddlVehicleType").find('option:selected').val();
                        var $ddlVehicleType = $("#ddlVehicleType").find('option:selected').text();

                        var $txtPoDate = $('#txtPoDate').val();
                        //For  PO Date Format
                        var $DatePO = $txtPoDate;
                        var $txtPoDate = $DatePO.replace(/\//g, '-')

                        var $txtPoDate = $txtPoDate.split('-');
                        var $txtPoDate = $txtPoDate[1] + '-' + $txtPoDate[0] + '-' + $txtPoDate[2];
                        /*PO Date Format*/
                        var $txtPoDates = $txtPoDate;
                        var date = new Date($txtPoDates);
                        var day = date.getDate();
                        var month = date.getMonth() + 1;
                        var year = date.getFullYear();
                        /*Birth Date  Format*/
                        var $txtBirthDates = $txtBirthDate;
                        var date = new Date($txtBirthDates);
                        var day = date.getDate();
                        var month = date.getMonth() + 1;
                        var year = date.getFullYear();

                        var $txtCertificateAreaCode = $('#txtCertificateAreaCode').val();
                        $AreaCode = $txtCertificateAreaCode;
                        $('#ddlAreaCode').val($AreaCode).trigger('change');
                        var $ddlUpdateAreaCodeValue = $("#ddlAreaCode").find('option:selected').val();
                        var $ddlAreaCode = $("#ddlAreaCode").find('option:selected').text();
                        var $VechicleInsuranceRowIndex = $("#VechicleInsuranceRowIndex").val();
                        var array = $TblVechicleInsurance.row($VechicleInsuranceRowIndex).data();
                        var $BtnInsuredCertificateUpdate = {
                            TxnSysID: $txtCertificateTxnSysID,
                            VehicleCode: $ddlVehicleNameValue,
                            VehicleModel: $txtVehicleModel,
                            UpdatedValue: 0,
                            PreviousValue: 0,
                            Mileage: $txtMileage,
                            ParticipantValue: $txtVehicleValue,
                            ColorCode: $ddlColorNameValue,
                            ParticipantName: $txtParticipantName,
                            ParticipantAddress: $txtParticipantAddress,
                            RegistrationNumber: $txtRegistrationNumber,
                            CityCode: $ddlCityCodeValue,
                            EngineNumber: $txtEngineNumber,
                            AreaCode: $ddlUpdateAreaCodeValue,
                            ChasisNumber: $txtChasisNumber,
                            Remarks: $txtRemarks,
                            PODate: $txtPoDates,
                            PONumber: $txtPoNumber,
                            CNICNumber: $txtCnicNum,
                            Tenure: $txtTenure,
                            BirthDate: $txtBirthDates,
                            Gender: $ddlGenderValue,
                            VehicleType: $ddlVehicleTypeValue,
                            VEODCode: $ddlVEODCodeValue,
                            CertTypeCode: $ddlOpCerTypeCodeValue,
                            Rate: $txtRate,
                            Contribution: $txtContribution,
                            InsuranceTypeCode: $ddlTakafulTypeValue,
                            CommisionRate: $txtCommissionRate,
                            RatingFactor: $ddlRatingFactorValue,
                        };
                        var $BtnInsuredCertificateUpdate = JSON.stringify($BtnInsuredCertificateUpdate);
                        $.get("http://207.180.200.121/mtrprodsetup/MtrVehicleDetails/UpdateMtrVehicleDetails?_Json=" + $BtnInsuredCertificateUpdate, function (data) {
                            $ValidTxn = data.IsValidTxn;
                            if ($ValidTxn == true) {
                                
                                $('#TblVechicleInsurance').DataTable().clear().destroy();
                                $TblVechicleInsurance = $("#TblVechicleInsurance").DataTable({
                                    "order": [
                                        [0, "desc"]
                                    ],
                                    "paging": true,
                                    "pageLength": 5,
                                    "searching": true,
                                });
                                $.ajax({
                                    url: 'http://207.180.200.121/mtrprodsetup/MtrVehicleDetails/GetMtrVehicleDetailsForPol/?_Json={"ParentTxnSysID":' + data.ParentTxnSysID + '}',
                                    type: 'get',
                                    dataType: "JSON",
                                    success: function (response) {
                                        var len = response.length;
                                        for (var i = 0; i < len; i++) {
                                            var $SerialNo = response[i].SerialNo;
                                            var $VehicleCode = response[i].VehicleCode;
                                            var $VehicleName = response[i].VehicleName;
                                            var $VehicleModel = response[i].VehicleModel;
                                            var $ColorCode = response[i].ColorCode;
                                            var $ColorName = response[i].ColorName;
                                            var $VehicleType = response[i].VehicleType;
                                            var $VehicleTypeName = response[i].VehicleTypeName;
                                            var $RegistrationNumber = response[i].RegistrationNumber;
                                            var $EngineNumber = response[i].EngineNumber;
                                            var $ChasisNumber = response[i].ChasisNumber;
                                            var $Mileage = response[i].Mileage;
                                            var $Deductible = response[i].Deductible;
                                            var $UpdatedValue = response[i].UpdatedValue;
                                            var $PreviousValue = response[i].PreviousValue;
                                            var $ParticipantValue = response[i].ParticipantValue;
                                            var $Rate = response[i].Rate;
                                            var $Contribution = response[i].Contribution;
                                            var $InsuranceTypeCode = response[i].InsuranceTypeCode;
                                            var $InsuranceTypeName = response[i].InsuranceTypeName;
                                            var $Tenure = response[i].Tenure;
                                            var $CertTypeCode = response[i].CertTypeCode;
                                            var $CertTypeName = response[i].CertTypeName;
                                            var $CommisionRate = response[i].CommisionRate;
                                            var $Remarks = response[i].Remarks;
                                            var $ParticipantName = response[i].ParticipantName;
                                            var $ParticipantAddress = response[i].ParticipantAddress;
                                            var $EmailAddress = response[i].EmailAddress;
                                            var $AreaCode = response[i].AreaCode;
                                            var $AreaName = response[i].AreaName;
                                            var $CityCode = response[i].CityCode;
                                            var $CityName = response[i].CityName;
                                            var $BirthDate = response[i].BirthDate;
                                            var $Gender = response[i].Gender;
                                            var $CNICNumber = response[i].CNICNumber;
                                            var $MobileNumber = response[i].MobileNumber;
                                            var $ResNumber = response[i].ResNumber;
                                            var $OfficeNumber = response[i].OfficeNumber;
                                            var $PODate = response[i].PODate;
                                            var $PONumber = response[i].PONumber;
                                            var $TxnSysID = response[i].TxnSysID;
                                            var $VEODCode = response[i].VEODCode;
                                             var $RatingFactor = response[i].RatingFactor;
                                            $TblVechicleInsurance.row.add([$SerialNo, $VehicleCode, $VehicleName, $VehicleModel, $ColorCode, $ColorName, $VehicleType, $VehicleTypeName, $RegistrationNumber, $EngineNumber, $ChasisNumber, $Mileage, $Deductible, $UpdatedValue, $PreviousValue, $ParticipantValue, $Rate, $Contribution, $InsuranceTypeCode, $InsuranceTypeName, $Tenure, $CertTypeCode, $CertTypeName, $CommisionRate, $Remarks, $ParticipantName, $ParticipantAddress, $EmailAddress, $AreaCode, $AreaName, $CityCode, $CityName, $BirthDate, $Gender, $CNICNumber, $MobileNumber, $ResNumber, $OfficeNumber, $PODate, $PONumber, $TxnSysID, $VEODCode,$RatingFactor]).draw(false);
                                        }
                                    }
                                });
                                //Destroy TblCalculatedContribution
                                $('#TblCalculatedContribution').DataTable().clear().destroy();
                                // Getting All Records For Calculated Contribution
                                var $TblCalculatedContribution = $("#TblCalculatedContribution").DataTable({
                                    "order": [
                                        [0, "desc"]
                                    ],
                                    "paging": false,
                                    "pageLength": 5,
                                    "searching": false,
                                });
                                var $CalculatedContributionApi = {
                                    ParticipantValue: $txtVehicleValue,
                                    Rate: $txtRate,
                                    TxnSysID: data.TxnSysID,
                                };
                                var $CalculatedContributionApi = JSON.stringify($CalculatedContributionApi);
                               
                                $.ajax({
                                    url: 'http://207.180.200.121/mtrprodsetup/MtrVContribution/UpdateMtrVContribution/?_Json=' + $CalculatedContributionApi,
                                    type: 'get',
                                    dataType: "JSON",
                                    success: function (response) {
                                        var len = response.length;
                                        for (var i = 0; i < len; i++) {
                                            var $Stamp = response[i].Stamp;
                                            var $Rate = response[i].Rate;
                                            /*var $BasicContribution = response[i].BasicContribution;*/
                                            var $PEV = response[i].PEV;
                                            /*var $TerrorContribution = response[i].TerrorContribution;*/
                                            var $GrossContribution = response[i].GrossContribution;
                                            /*var $BeforePEV = response[i].BeforePEV;*/
                                            /*var $FIF = response[i].FIF;
                                            var $FED = response[i].FED;*/
                                            var $NetContribution = response[i].NetContribution;
                                            /*var $RiskTxnID = response[i].RiskTxnID;*/
                                            var $SumCovered = response[i].SumCovered;
                                            /*var $PerDayContribution = response[i].PerDayContribution;*/
                                            $TblCalculatedContribution.row.add([$Stamp, $Rate, $GrossContribution, $SumCovered, $NetContribution, $PEV]).draw(false);
                                        }
                                    }
                                });
                                $('#UpdatedModal').modal('show');
                                setTimeout(function () {
                                    $('#UpdatedModal').modal('hide')
                                }, 2000);
                                array[1] = $ddlVehicleNameValue;
                                array[2] = $ddlVehicleName;
                                array[3] = $txtVehicleModel;
                                array[4] = $ddlColorNameValue;
                                array[5] = $ddlColorName;
                                array[6] = $ddlVehicleTypeValue;
                                array[7] = $ddlVehicleType;
                                array[8] = $txtRegistrationNumber;
                                array[9] = $txtEngineNumber;
                                array[10] = $txtChasisNumber;
                                array[11] = $txtMileage;
                                array[12] = $txtDeductible;
                                array[13] = 0;
                                array[14] = 0;
                                array[15] = $txtVehicleValue;
                                array[16] = $txtRate;
                                array[17] = $txtContribution;
                                array[18] = $ddlTakafulTypeValue;
                                array[19] = $ddlTakafulType;
                                array[20] = $txtTenure;
                                array[21] = $ddlOpCerTypeCodeValue;
                                array[22] = $ddlOpCerTypeCode;
                                array[23] = $txtCommissionRate;
                                array[24] = $txtRemarks;
                                array[25] = $txtParticipantName;
                                array[26] = $txtParticipantAddress;
                                array[27] = $txtEmail;
                                array[28] = $ddlAreaCode;
                                array[29] = $ddlUpdateAreaCodeValue;
                                array[30] = $ddlCityCodeValue;
                                array[31] = $ddlCityCode;
                                array[32] = $txtBirthDate;
                                array[33] = $ddlGenderValue;
                                array[34] = $txtCnicNum;
                                array[35] = $txtPersonalNum;
                                array[36] = $txtResidenceNum;
                                array[37] = $txtOfficeNum;
                                array[38] = $txtPoDate;
                                array[39] = $txtPoNumber;
                                array[40] = $txtCertificateTxnSysID;
                                array[41] = $ddlVEODCodeValue;
                                $TblVechicleInsurance.row($VechicleInsuranceRowIndex).data(array);
                                $TblVechicleInsurance.row($VechicleInsuranceRowIndex).invalidate();
                                $TblVechicleInsurance.draw(false);
                            } else {
                                $TxnErrors = data.TxnErrors;
                                for (var i = 0; i < $TxnErrors.length; i++) {
                                    $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].ErrorCode + '-' + $TxnErrors[i].Error + '</span>');
                                }
                                $('#ErrorModal').modal('show');
                                setTimeout(function () {
                                    $('#ErrorModal').modal('hide')
                                }, 2000);
                            }
                        });
                    }


                } else {
                    $TxnErrors = data.TxnErrors;
                    for (var i = 0; i < $TxnErrors.length; i++) {
                        $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                    }
                    $('#ErrorModal').modal('show');
                    setTimeout(function () {
                        $('#ErrorModal').modal('hide')
                    }, 2000);
                }

            });
        }
    });
    $('#TblVechicleInsurance tbody').on('click', 'tr', function () {
        $("#UpdateCoInsurer").show();
        $("#SubmitCoInsurer").hide();
        $("#VechicleInsuranceRowIndex").val($TblVechicleInsurance.row(this).index);
        var $selValue = $TblVechicleInsurance.row(this).data();
        $rowIdx = $TblVechicleInsurance.row(this).index;
        $("#TblVechicleInsurance").val($rowIdx);
        $row = $TblVechicleInsurance.row(this).node();
        $($row).addClass('ready');
        $ddlVehicleName = $selValue[1];
        $('#ddlVehicleName').val($ddlVehicleName).trigger('change');

        $("#txtVehicleModel").val($selValue[3]);

        $ddlColorName = $selValue[4];
        $('#ddlColorName').val($ddlColorName).trigger('change');

        $ddlVehicleType = $selValue[6];
        $('#ddlVehicleType').val($ddlVehicleType).trigger('change');

        $("#txtRegistrationNumber").val($selValue[8]);

        $("#txtEngineNumber").val($selValue[9]);

        $("#txtChasisNumber").val($selValue[10]);

        $("#txtMileage").val($selValue[11]);

        $("#txtDeductible").val($selValue[12]);

        $("#txtUpdatedValue").val($selValue[13]);

        $("#txtPreviousValue").val($selValue[14]);

        $("#txtVehicleValue").val($selValue[15]);

        $("#txtRate").val($selValue[16]);

        $("#txtContribution").val($selValue[17]);
        var UpdateContribution = $selValue[17];
        $("#txtUpdateContribution").val($selValue[17]);
        $ddlTakafulType = $selValue[18];
        $('#ddlTakafulType').val($ddlTakafulType).trigger('change');

        $("#txtTenure").val($selValue[20]);

        $ddlOpCerTypeCode = $selValue[21];
        $('#ddlOpCerTypeCode').val($ddlOpCerTypeCode).trigger('change');

        $("#txtCommissionRate").val($selValue[23]);


        $("#txtRemarks").val($selValue[24]);

        $("#txtParticipantName").val($selValue[25]);

        $("#txtParticipantAddress").val($selValue[26]);

        $("#txtEmail").val($selValue[27]);

        $("#txtCertificateAreaCode").val($selValue[28]);

        $ddlCityCode = $selValue[30];
        $('#ddlCityCode').val($ddlCityCode).trigger('change');

        var $BirthDateDate = $selValue[32];
        var $BirthDateDate = $BirthDateDate.substring(0, 10);
        var $BirthDateDate = $BirthDateDate.substring(0, 10);
        //For  Birth Date Format
        var $txtBirthDate = $BirthDateDate.replace(/\//g, '-')
        var $txtBirthDate = $txtBirthDate.split('-');
        var $txtBirthDate = $txtBirthDate[2] + '-' + $txtBirthDate[1] + '-' + $txtBirthDate[0];
        var $DateBirth = $txtBirthDate;
        $("#txtBirthDate").val($DateBirth);


        $ddlGender = $selValue[33];
        $('#ddlGender').val($ddlGender).trigger('change');

        $("#txtCnicNum").val($selValue[34]);

        $("#txtPersonalNum").val($selValue[35]);

        $("#txtResidenceNum").val($selValue[36]);

        $("#txtOfficeNum").val($selValue[37]);
        var $PoDate = $selValue[38];
        var $PoDate = $PoDate.substring(0, 10);
        var $DatePO = $PoDate;
        var $txtPoDate = $DatePO.replace(/\//g, '-')

        var $txtPoDate = $txtPoDate.split('-');
        var $txtPoDate = $txtPoDate[2] + '-' + $txtPoDate[1] + '-' + $txtPoDate[0];
        $("#txtPoDate").val($txtPoDate);

        $("#txtPoNumber").val($selValue[39]);

        $("#txtCertificateTxnSysID").val($selValue[40]);
        $UpdateCertificateTxnSysID = $selValue[40];
        $("#txtVechicleId").val($UpdateCertificateTxnSysID);
        $ddlVEODCode = $selValue[41];
        $('#ddlVEODCode').val($ddlVEODCode).trigger('change');
        $ddlRatingFactor = $selValue[42];
        $('#ddlRatingFactor').val($ddlRatingFactor).trigger('change');

        //Destroy TblCalculatedContribution
        $('#TblCalculatedContribution').DataTable().clear().destroy();
        // Getting All Records For Calculated Contribution
        var $TblCalculatedContribution = $("#TblCalculatedContribution").DataTable({
            "order": [
                [0, "desc"]
            ],
            "paging": false,
            "pageLength": 5,
            "searching": false,
        });
        $.ajax({
            url: 'http://207.180.200.121/mtrprodsetup/MtrVContribution/GetAllMtrVContribution?_Json={"TxnSysID":' + $UpdateCertificateTxnSysID + '}',
            type: 'get',
            dataType: "JSON",
            success: function (response) {
                var len = response.length;
                for (var i = 0; i < len; i++) {
                var $Stamp = response[i].Stamp;
                var $Rate = response[i].Rate;
                /*var $BasicContribution = response[i].BasicContribution;*/
                var $PEV = response[i].PEV;
                /*var $TerrorContribution = response[i].TerrorContribution;*/
                var $GrossContribution = response[i].GrossContribution;
                /*var $BeforePEV = response[i].BeforePEV;*/
                /*var $FIF = response[i].FIF;
                var $FED = response[i].FED;*/
                var $NetContribution = response[i].NetContribution;
                /*var $RiskTxnID = response[i].RiskTxnID;*/
                var $SumCovered = response[i].SumCovered;
                /*var $PerDayContribution = response[i].PerDayContribution;*/
                $TblCalculatedContribution.row.add([$Stamp, $Rate, $GrossContribution, $SumCovered, $NetContribution, $PEV]).draw(false);
                }
            }
        });

        //Destroy TblCalculatedContribution
        $('#UpdateinsurerTbl').DataTable().clear().destroy();
        // Getting All Records For insurer Tbl on Table Click
        $("#CoUpdateInsuranceRowIndex").val("-1");
        var $UpdateinsurerTbl = $("#UpdateinsurerTbl").DataTable({
            "order": [
                [0, "desc"]
            ],
            "paging": false,
            "pageLength": 5,
            "searching": false,
        });
        $.ajax({
            url: 'http://207.180.200.121/mtrprodsetup/InsCoInsurance/GetAllInsCoInsurance?_Json={"TxnSysID":' + $UpdateCertificateTxnSysID + '}',
            type: 'get',
            dataType: "JSON",
            success: function (response) {
                var len = response.length;
                for (var i = 0; i < len; i++) {
                    var $TxnSysID = response[i].TxnSysID;
                    var $CoInsuranceCode = response[i].CoInsuranceCode;
                    var $PartTakerName = response[i].PartTakerName;
                    var $CoInsuranceShare = response[i].CoInsuranceShare;
                    var $GrossContribution = response[i].GrossContribution;
                    var $FED = response[i].FED;
                    var $FIF = response[i].FIF;
                    var $NetContribution = response[i].NetContribution;
                    $UpdateinsurerTbl.row.add([$TxnSysID, $CoInsuranceCode, $PartTakerName, $CoInsuranceShare, $GrossContribution, $FED, $FIF, $NetContribution]).draw(false);
                }
            }
        });
        // Getting All Values For insurer Tbl on Table Click
        $('#UpdateinsurerTbl tbody').on('click', 'tr', function () {
            // Getting All Records For insurer Tbl on Table Click
            $.fn.dataTable.ext.errMode = 'none';
            var $UpdateinsurerTbl = $("#UpdateinsurerTbl").DataTable({
                "order": [
                    [0, "desc"]
                ],
                "paging": false,
                "pageLength": 5,
                "searching": false,
            });
            $("#CoUpdateInsuranceRowIndex").val($UpdateinsurerTbl.row(this).index);
            var $UpdatesellsValue = $UpdateinsurerTbl.row(this).data();
            $rowIdx = $UpdateinsurerTbl.row(this).index;
            $("#UpdateinsurerTbl").val($rowIdx);
            $row = $UpdateinsurerTbl.row(this).node();
            $($row).addClass('ready');

            $ddlUpdateParttaker = $UpdatesellsValue[1];
            $('#ddlUpdateParttaker').val($ddlUpdateParttaker).trigger('change');
            $("#txtCoUpdateInsuranceShare").val($UpdatesellsValue[3]);
            $('#UpdateCorrection').show();
            $("#UpdateInsuranceRowIndex").val("-1");
            $("#BtnUpdateCorrection").on("click", function () {
                $('#DivUpdateOne').show();
                $('#DivUpdateTwo').show();
                $('#BtnUpdateOne').show();
                $('#BtnUpdateTwo').show();
            });
            $("#BtnUpdateInsuranceNew").on("click", function () {
                $('#ddlUpdateCoInsElement').focus();
                $("#txtUpdateAmount").val('');
                $("#ddlUpdateCoInsElement").select2("val", 0);
                $("#UpdateInsuranceRowIndex").val("-1");
            });
            $("#BtnUpdateInsuranceSave").on("click", function () {
                var $ddlUpdateCoInsElementValue = $("#ddlUpdateCoInsElement").find('option:selected').val();
                var $ddlUpdateCoInsElement = $("#ddlUpdateCoInsElement").find('option:selected').text();
                var $txtUpdateAmount = $('#txtUpdateAmount').val();
                if ($ddlUpdateCoInsElementValue == 'Choose Element' || $ddlUpdateCoInsElementValue == '') {
                    $("select[name='ddlUpdateCoInsElement']").addClass("reqirederror");
                    return false;
                }
                if (!$txtUpdateAmount) {
                    $("input[name='txtUpdateAmount']").addClass("reqirederror");
                    return false;
                }
                if ($("#UpdateInsuranceRowIndex").val() == "-1") {
                    if ($ddlUpdateCoInsElementValue == '1') {
                        var $BtnInsuranceNew = {
                            TxnSysID: $UpdatesellsValue[0],
                            ElementCode: $ddlUpdateCoInsElementValue,
                            GrossContribution: $txtUpdateAmount,
                        };
                        var $BtnInsuranceNew = JSON.stringify($BtnInsuranceNew);
                        $.get("http://207.180.200.121/mtrprodsetup/InsCoInsurance/UpdateInsCoInsuranceByElement/?_Json=" + $BtnInsuranceNew, function (data) {
                            $ValidTxnInsurer = data.IsValidTxn;
                            if ($ValidTxnInsurer == true) {
                                //Destroy TblCalculatedContribution
                                $('#UpdateinsurerTbl').DataTable().clear().destroy();
                                var $aUpdateinsurerTbl = $("#UpdateinsurerTbl").DataTable({
                                    "order": [
                                        [0, "desc"]
                                    ],
                                    "paging": false,
                                    "pageLength": 5,
                                    "searching": false,
                                });
                                $.ajax({
                                    url: 'http://207.180.200.121/mtrprodsetup/InsCoInsurance/GetAllInsCoInsurance?_Json={"TxnSysID":' + $UpdateCertificateTxnSysID + '}',
                                    type: 'get',
                                    dataType: "JSON",
                                    success: function (response) {
                                        var len = response.length;
                                        for (var i = 0; i < len; i++) {
                                            var $TxnSysID = response[i].TxnSysID;
                                            var $CoInsuranceCode = response[i].CoInsuranceCode;
                                            var $PartTakerName = response[i].PartTakerName;
                                            var $CoInsuranceShare = response[i].CoInsuranceShare;
                                            var $GrossContribution = response[i].GrossContribution;
                                            var $FED = response[i].FED;
                                            var $FIF = response[i].FIF;
                                            var $NetContribution = response[i].NetContribution;
                                            $aUpdateinsurerTbl.row.add([$TxnSysID, $CoInsuranceCode, $PartTakerName, $CoInsuranceShare, $GrossContribution, $FED, $FIF, $NetContribution]).draw(false);
                                        }
                                    }
                                });
                                $('#SubmitModal').modal('show');
                                setTimeout(function () {
                                    $('#SubmitModal').modal('hide')
                                }, 2000);
                            } else {
                                $TxnErrors = data.TxnErrors;
                                for (var i = 0; i < $TxnErrors.length; i++) {
                                    $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                                }
                                $('#ErrorModal').modal('show');
                                setTimeout(function () {
                                    $('#ErrorModal').modal('hide')
                                }, 2000);
                            }
                        });
                    }
                    if ($ddlUpdateCoInsElementValue == '2') {
                        var $BtnInsuranceNew = {
                            TxnSysID: $UpdatesellsValue[0],
                            ElementCode: $ddlUpdateCoInsElementValue,
                            NetContribution: $txtUpdateAmount,
                        };
                        var $BtnInsuranceNew = JSON.stringify($BtnInsuranceNew);
                        $.get("http://207.180.200.121/mtrprodsetup/InsCoInsurance/UpdateInsCoInsuranceByElement/?_Json=" + $BtnInsuranceNew, function (data) {
                            $ValidTxnInsurer = data.IsValidTxn;
                            if ($ValidTxnInsurer == true) {
                                //Destroy TblCalculatedContribution
                                $('#UpdateinsurerTbl').DataTable().clear().destroy();
                                var $aUpdateinsurerTbl = $("#UpdateinsurerTbl").DataTable({
                                    "order": [
                                        [0, "desc"]
                                    ],
                                    "paging": false,
                                    "pageLength": 5,
                                    "searching": false,
                                });
                                $.ajax({
                                    url: 'http://207.180.200.121/mtrprodsetup/InsCoInsurance/GetAllInsCoInsurance?_Json={"TxnSysID":' + $UpdateCertificateTxnSysID + '}',
                                    type: 'get',
                                    dataType: "JSON",
                                    success: function (response) {
                                        var len = response.length;
                                        for (var i = 0; i < len; i++) {
                                            var $TxnSysID = response[i].TxnSysID;
                                            var $CoInsuranceCode = response[i].CoInsuranceCode;
                                            var $PartTakerName = response[i].PartTakerName;
                                            var $CoInsuranceShare = response[i].CoInsuranceShare;
                                            var $GrossContribution = response[i].GrossContribution;
                                            var $FED = response[i].FED;
                                            var $FIF = response[i].FIF;
                                            var $NetContribution = response[i].NetContribution;
                                            $aUpdateinsurerTbl.row.add([$TxnSysID, $CoInsuranceCode, $PartTakerName, $CoInsuranceShare, $GrossContribution, $FED, $FIF, $NetContribution]).draw(false);
                                        }
                                    }
                                });
                                $('#SubmitModal').modal('show');
                                setTimeout(function () {
                                    $('#SubmitModal').modal('hide')
                                }, 2000);
                            } else {
                                $TxnErrors = data.TxnErrors;
                                for (var i = 0; i < $TxnErrors.length; i++) {
                                    $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                                }
                                $('#ErrorModal').modal('show');
                                setTimeout(function () {
                                    $('#ErrorModal').modal('hide')
                                }, 2000);
                            }
                        });
                    }
                    if ($ddlUpdateCoInsElementValue == '3') {
                        var $BtnInsuranceNew = {
                            TxnSysID: $UpdatesellsValue[0],
                            ElementCode: $ddlUpdateCoInsElementValue,
                            FIF: $txtUpdateAmount,
                        };
                        var $BtnInsuranceNew = JSON.stringify($BtnInsuranceNew);
                        $.get("http://207.180.200.121/mtrprodsetup/InsCoInsurance/UpdateInsCoInsuranceByElement/?_Json=" + $BtnInsuranceNew, function (data) {
                            $ValidTxnInsurer = data.IsValidTxn;
                            if ($ValidTxnInsurer == true) {
                                //Destroy TblCalculatedContribution
                                $('#UpdateinsurerTbl').DataTable().clear().destroy();
                                var $aUpdateinsurerTbl = $("#UpdateinsurerTbl").DataTable({
                                    "order": [
                                        [0, "desc"]
                                    ],
                                    "paging": false,
                                    "pageLength": 5,
                                    "searching": false,
                                });
                                $.ajax({
                                    url: 'http://207.180.200.121/mtrprodsetup/InsCoInsurance/GetAllInsCoInsurance?_Json={"TxnSysID":' + $UpdateCertificateTxnSysID + '}',
                                    type: 'get',
                                    dataType: "JSON",
                                    success: function (response) {
                                        var len = response.length;
                                        for (var i = 0; i < len; i++) {
                                            var $TxnSysID = response[i].TxnSysID;
                                            var $CoInsuranceCode = response[i].CoInsuranceCode;
                                            var $PartTakerName = response[i].PartTakerName;
                                            var $CoInsuranceShare = response[i].CoInsuranceShare;
                                            var $GrossContribution = response[i].GrossContribution;
                                            var $FED = response[i].FED;
                                            var $FIF = response[i].FIF;
                                            var $NetContribution = response[i].NetContribution;
                                            $aUpdateinsurerTbl.row.add([$TxnSysID, $CoInsuranceCode, $PartTakerName, $CoInsuranceShare, $GrossContribution, $FED, $FIF, $NetContribution]).draw(false);
                                        }
                                    }
                                });
                                $('#SubmitModal').modal('show');
                                setTimeout(function () {
                                    $('#SubmitModal').modal('hide')
                                }, 2000);
                            } else {
                                $TxnErrors = data.TxnErrors;
                                for (var i = 0; i < $TxnErrors.length; i++) {
                                    $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                                }
                                $('#ErrorModal').modal('show');
                                setTimeout(function () {
                                    $('#ErrorModal').modal('hide')
                                }, 2000);
                            }
                        });
                    }
                    if ($ddlUpdateCoInsElementValue == '4') {
                        var $BtnInsuranceNew = {
                            TxnSysID: $UpdatesellsValue[0],
                            ElementCode: $ddlUpdateCoInsElementValue,
                            FED: $txtUpdateAmount,
                        };
                        var $BtnInsuranceNew = JSON.stringify($BtnInsuranceNew);
                        $.get("http://207.180.200.121/mtrprodsetup/InsCoInsurance/UpdateInsCoInsuranceByElement/?_Json=" + $BtnInsuranceNew, function (data) {
                            $ValidTxnInsurer = data.IsValidTxn;
                            if ($ValidTxnInsurer == true) {
                                //Destroy TblCalculatedContribution
                                $('#UpdateinsurerTbl').DataTable().clear().destroy();
                                var $aUpdateinsurerTbl = $("#UpdateinsurerTbl").DataTable({
                                    "order": [
                                        [0, "desc"]
                                    ],
                                    "paging": false,
                                    "pageLength": 5,
                                    "searching": false,
                                });
                                $.ajax({
                                    url: 'http://207.180.200.121/mtrprodsetup/InsCoInsurance/GetAllInsCoInsurance?_Json={"TxnSysID":' + $UpdateCertificateTxnSysID + '}',
                                    type: 'get',
                                    dataType: "JSON",
                                    success: function (response) {
                                        var len = response.length;
                                        for (var i = 0; i < len; i++) {
                                            var $TxnSysID = response[i].TxnSysID;
                                            var $CoInsuranceCode = response[i].CoInsuranceCode;
                                            var $PartTakerName = response[i].PartTakerName;
                                            var $CoInsuranceShare = response[i].CoInsuranceShare;
                                            var $GrossContribution = response[i].GrossContribution;
                                            var $FED = response[i].FED;
                                            var $FIF = response[i].FIF;
                                            var $NetContribution = response[i].NetContribution;
                                            $aUpdateinsurerTbl.row.add([$TxnSysID, $CoInsuranceCode, $PartTakerName, $CoInsuranceShare, $GrossContribution, $FED, $FIF, $NetContribution]).draw(false);
                                        }
                                    }
                                });
                                $('#SubmitModal').modal('show');
                                setTimeout(function () {
                                    $('#SubmitModal').modal('hide')
                                }, 2000);
                            } else {
                                $TxnErrors = data.TxnErrors;
                                for (var i = 0; i < $TxnErrors.length; i++) {
                                    $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                                }
                                $('#ErrorModal').modal('show');
                                setTimeout(function () {
                                    $('#ErrorModal').modal('hide')
                                }, 2000);
                            }
                        });
                    }
                }
            });
        });
    });
    $("#BtnUpdateCoInsuranceNew").on("click", function () {
        $('#ddlUpdateParttaker').focus();
        $("#txtCoUpdateInsuranceShare").val('');
        $("#ddlUpdateParttaker").select2("val", 0);
        $("#CoUpdateInsuranceRowIndex").val("-1");
    });
    //Save Insurer Table On Table Click
    $("#BtnUpdateCoInsuranceSave").on("click", function () {
        var $id = $('#txtVechicleId').val();
        var $txtUpdateContribution = $('#txtUpdateContribution').val();
        $('#UpdateinsurerTbl').DataTable().clear().destroy();
        $("#CoUpdateInsuranceRowIndex").val("-1");
        var $UpdateinsurerTbl = $("#UpdateinsurerTbl").DataTable({
            "order": [
                [0, "desc"]
            ],
            "paging": false,
            "pageLength": 5,
            "searching": false,
        });
        $.ajax({
            url: 'http://207.180.200.121/mtrprodsetup/InsCoInsurance/GetAllInsCoInsurance?_Json={"TxnSysID":' + $id + '}',
            type: 'get',
            dataType: "JSON",
            success: function (response) {
                var len = response.length;
                for (var i = 0; i < len; i++) {
                    var $TxnSysID = response[i].TxnSysID;
                    var $CoInsuranceCode = response[i].CoInsuranceCode;
                    var $PartTakerName = response[i].PartTakerName;
                    var $CoInsuranceShare = response[i].CoInsuranceShare;
                    var $GrossContribution = response[i].GrossContribution;
                    var $FED = response[i].FED;
                    var $FIF = response[i].FIF;
                    var $NetContribution = response[i].NetContribution;
                    $UpdateinsurerTbl.row.add([$TxnSysID, $CoInsuranceCode, $PartTakerName, $CoInsuranceShare, $GrossContribution, $FED, $FIF, $NetContribution]).draw(false);
                }
            }
        });
        var $txtCoInsuranceCodeValue = $("#ddlUpdateParttaker").find('option:selected').val();
        var $txtCoInsuranceCode = $("#ddlUpdateParttaker").find('option:selected').text();
        var $txtCoUpdateInsuranceShare = $('#txtCoUpdateInsuranceShare').val();
        if (!$txtCoInsuranceCode) {
            $("select[name='ddlUpdateParttaker']").addClass("reqirederror");
            return false;
        }
        if (!$txtCoUpdateInsuranceShare) {
            $("input[name='txtCoUpdateInsuranceShare']").addClass("reqirederror");
            return false;
        }
        if ($txtCoUpdateInsuranceShare > 100) {
            $("input[name='txtCoUpdateInsuranceShare']").addClass("reqirederror");
            return false;
        } else {
            if ($("#CoUpdateInsuranceRowIndex").val() == "-1") {
                var $BtnCoInsuranceNew = {
                    TxnSysID: $id,
                    CoInsuranceCode: $txtCoInsuranceCodeValue,
                    CoInsuranceShare: $txtCoUpdateInsuranceShare,
                    GrossContribution: $txtUpdateContribution,
                };
                var $BtnCoInsuranceNew = JSON.stringify($BtnCoInsuranceNew);
                $.get("http://207.180.200.121/mtrprodsetup/InsCoInsurance/GetInsCoInsurance/?_Json=" + $BtnCoInsuranceNew, function (data) {
                    $ValidTxnInsurer = data.IsValidTxn;
                    $CoInsuranceTxnSysID = data.TxnSysID;
                    if ($ValidTxnInsurer == true) {
                        var rowNodes = $UpdateinsurerTbl.row.add([data.TxnSysID, data.CoInsuranceCode, data.PartTakerName, data.CoInsuranceShare, data.GrossContribution, data.FED, data.FIF, data.NetContribution]).draw();
                        $('#SubmitModal').modal('show');
                        setTimeout(function () {
                            $('#SubmitModal').modal('hide')
                        }, 2000);
                    } else {
                        $TxnErrors = data.TxnErrors;
                        for (var i = 0; i < $TxnErrors.length; i++) {
                            $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].Error + '-' + $TxnErrors[i].ErrorCode + '</span>');
                        }
                        $('#ErrorModal').modal('show');
                        setTimeout(function () {
                            $('#ErrorModal').modal('hide')
                        }, 2000);
                    }
                });
            } else {
                var $CoUpdateInsuranceRowIndex = $("#CoUpdateInsuranceRowIndex").val();
                var array = $UpdateinsurerTbl.row($CoUpdateInsuranceRowIndex).data();
                var $BtnCoInsuranceUpdate = {
                    TxnSysID: $id,
                    CoInsuranceCode: $txtCoInsuranceCodeValue,
                    CoInsuranceShare: $txtCoUpdateInsuranceShare,
                    GrossContribution: $txtUpdateContribution,
                };
                var $BtnCoInsuranceUpdate = JSON.stringify($BtnCoInsuranceUpdate);
                $.get("http://207.180.200.121/mtrprodsetup/InsCoInsurance/UpdateInsCoInsurance/?_Json=" + $BtnCoInsuranceUpdate, function (data) {
                    $ValidTxn = data.IsValidTxn;
                    if ($ValidTxn == true) {
                        $('#UpdatedModal').modal('show');
                        setTimeout(function () {
                            $('#UpdatedModal').modal('hide')
                        }, 2000);
                        array[1] = $txtCoInsuranceCodeValue;
                        array[2] = $txtCoInsuranceCode;
                        array[3] = $txtCoUpdateInsuranceShare;
                        $UpdateinsurerTbl.row($CoUpdateInsuranceRowIndex).data(array);
                        $UpdateinsurerTbl.row($CoUpdateInsuranceRowIndex).invalidate();
                        $UpdateinsurerTbl.draw(false);
                    } else {
                        $TxnErrors = data.TxnErrors;
                        for (var i = 0; i < $TxnErrors.length; i++) {
                            $("#ModalError").append("<span class='ErrorMsg'>" + $TxnErrors[i].ErrorCode + '-' + $TxnErrors[i].Error + '</span>');
                        }
                        $('#ErrorModal').modal('show');
                        setTimeout(function () {
                            $('#ErrorModal').modal('hide')
                        }, 2000);
                    }
                });
            }

        }

    });
    //On Click BtnSearch Clear All Values
    $("#BtnSearchNew").on("click", function () {
        $('#ddlSearchByCert').focus();
        $("#ddlSearchByCert").select2("val", 0);
        $("#txtSearchCertInfo").val('');
    });
    //On Click BtnSearch Get All Values
    $("#BtnSearch").on("click", function () {
        var $ddlSearchByCertValue = $("#ddlSearchByCert").find('option:selected').val();
        var $ddlSearchByCert = $("#ddlSearchByCert").find('option:selected').text();
        var $txtSearchCertInfo = $('#txtSearchCertInfo').val();
        if (!$ddlSearchByCertValue) {
            $("select[name='ddlSearchByCert']").addClass("reqirederror");
            return false;
        }
        if (!$txtSearchCertInfo) {
            $("input[name='txtSearchCertInfo']").addClass("reqirederror");
            return false;
        } else {
            if ($ddlSearchByCertValue == 1) {
                var $BtnCertSearchBy = {
                    ChasisNumber: $txtSearchCertInfo,
                    SeByCertCode: $ddlSearchByCertValue,
                };
                $BtnCertSearchBy = JSON.stringify($BtnCertSearchBy);
            }
            if ($ddlSearchByCertValue == 2) {
                var $BtnCertSearchBy = {
                    RegistrationNumber: $txtSearchCertInfo,
                    SeByCertCode: $ddlSearchByCertValue,
                };
                $BtnCertSearchBy = JSON.stringify($BtnCertSearchBy);
            }
            if ($ddlSearchByCertValue == 3) {
                var $BtnCertSearchBy = {
                    VechicleModel: $txtSearchCertInfo,
                    SeByCertCode: $ddlSearchByCertValue,
                };
                $BtnCertSearchBy = JSON.stringify($BtnCertSearchBy);
            }
            if ($ddlSearchByCertValue == 4) {
                var $BtnCertSearchBy = {
                    ParticipantName: $txtSearchCertInfo,
                    SeByCertCode: $ddlSearchByCertValue,
                };
                $BtnCertSearchBy = JSON.stringify($BtnCertSearchBy);
            }
            if ($ddlSearchByCertValue == 5) {
                var $BtnCertSearchBy = {
                    ParentTxnSysID: $txtSearchCertInfo,
                    SeByCertCode: $ddlSearchByCertValue,
                };
                $BtnCertSearchBy = JSON.stringify($BtnCertSearchBy);
            }
            $('#SearchTbl').DataTable().clear().destroy();
            var $SearchTbl = $("#SearchTbl").DataTable({
                "order": [
                    [0, "desc"]
                ],
                "paging": false,
                "pageLength": 5,
                "searching": false,
            });
            $.ajax({
                url: "http://207.180.200.121/mtrprodsetup/MtrVehicleDetails/GetMtrVDByInfoForPol/?_Json=" + $BtnCertSearchBy,
                type: 'get',
                dataType: "JSON",
                success: function (response) {
                    var len = response.length;
                    for (var i = 0; i < len; i++) {
                        var $SerialNo = response[i].SerialNo;
                        var $ProductCode = response[i].ProductCode;
                        var $ClientCode = response[i].ClientCode;
                        var $CertString = response[i].CertString;
                        var $AgencyCode = response[i].AgencyCode;
                        var $CommisionRate = response[i].CommisionRate;
                        var $EffectiveDate = response[i].EffectiveDate;
                        var $ExpiryDate = response[i].ExpiryDate;
                        var $ProductCode = response[i].ProductCode;
                        var $ParticipantName = response[i].ParticipantName;
                        var $ParticipantAddress = response[i].ParticipantAddress;
                        var $EmailAddress = response[i].EmailAddress;
                        var $CityCode = response[i].CityCode;
                        var $AreaCode = response[i].AreaCode;
                        var $CNICNumber = response[i].CNICNumber;
                        var $MobileNumber = response[i].MobileNumber;
                        var $OfficeNumber = response[i].OfficeNumber;
                        var $ResNumber = response[i].ResNumber;
                        var $BirthDate = response[i].BirthDate;
                        var $Gender = response[i].Gender;
                        var $PODate = response[i].PODate;
                        var $PONumber = response[i].PONumber;
                        var $LeaderPolicyNo = response[i].LeaderPolicyNo;
                        var $LeaderEndNo = response[i].LeaderEndNo;
                        var $VehicleCode = response[i].VehicleCode;
                        var $VehicleModel = response[i].VehicleModel;
                        var $VehicleType = response[i].VehicleType;
                        var $InsuranceTypeCode = response[i].InsuranceTypeCode;
                        var $ColorCode = response[i].ColorCode;
                        var $RegistrationNumber = response[i].RegistrationNumber;
                        var $EngineNumber = response[i].EngineNumber;
                        var $ChasisNumber = response[i].ChasisNumber;
                        var $Mileage = response[i].Mileage;
                        var $VEODCode = response[i].VEODCode;
                        var $Remarks = response[i].Remarks;
                        var $Tenure = response[i].Tenure;
                        var $CertTypeCode = response[i].CertTypeCode;
                        var $RatingFactor  = response[i].RatingFactor;
                        var $ParticipantValue  = response[i].ParticipantValue;
                        var $Rate  = response[i].Rate;
                        var $Contribution  = response[i].Contribution;
                        var $ContractMatDate  = response[i].ContractMatDate;
                        var $Deductible  = response[i].Deductible;
                        var $TxnSysID  = response[i].TxnSysID;
                        $SearchTbl.row.add([$SerialNo,$ProductCode,$ClientCode,$CertString,$AgencyCode,$CommisionRate,$EffectiveDate,$ExpiryDate,$ProductCode,$ParticipantName,$ParticipantAddress,$EmailAddress,$CityCode,$AreaCode,$CNICNumber,$MobileNumber,$OfficeNumber,$ResNumber,$BirthDate,$Gender,$PODate,$PONumber,$LeaderPolicyNo,$LeaderEndNo,$VehicleCode,$VehicleModel,$VehicleType,$InsuranceTypeCode,$ColorCode,$RegistrationNumber,$EngineNumber,$ChasisNumber,$Mileage,$VEODCode,$Remarks,$Tenure,$CertTypeCode,$RatingFactor,$ParticipantValue,$Rate,$Contribution,$ContractMatDate,$Deductible,$TxnSysID]).draw(false);
                    }
                }
            });
        }
        $('#SearchTbl').off( 'click.rowClick' ).on('click.rowClick', 'tr', function () {
            $("#VechicleInsuranceRowIndex").val("2");
            var $SearchsellsValue = $SearchTbl.row(this).data();
            $rowIdx = $SearchTbl.row(this).index;
            $("#UpdateinsurerTbl").val($rowIdx);
            $row = $SearchTbl.row(this).node();
            $($row).addClass('ready');
            $('#ddlMotorProductCode').val($SearchsellsValue[1]).trigger('change');
            $('#ddlCertificateClientCode').val($SearchsellsValue[2]).trigger('change');
            $("#ddlCertificateClientCode").val($SearchsellsValue[2]);

            $('#txtPolicyString').val($SearchsellsValue[3]).trigger('change');
            $('#ddlPolicyAgencyCode').val($SearchsellsValue[4]).trigger('change');
            $("#txtParticipantName").val($SearchsellsValue[9]);
            $("#txtParticipantAddress").val($SearchsellsValue[10]);
            $("#txtEmail").val($SearchsellsValue[11]);
            $('#ddlCityCode').val($SearchsellsValue[12]).trigger('change');
            $("#txtAreaCodeHidden").val($SearchsellsValue[13]);
            $("#txtCnicNum").val($SearchsellsValue[14]);
            $("#txtPersonalNum").val($SearchsellsValue[15]);
            $("#txtOfficeNum").val($SearchsellsValue[16]);
            $("#txtResidenceNum").val($SearchsellsValue[17]);
            var $BirthDateDate = $SearchsellsValue[18];
            var $BirthDateDate = $BirthDateDate.substring(0, 10);
            //For  Birth Date Format
            var $txtBirthDate = $BirthDateDate.replace(/\//g, '-')
            var $txtBirthDate = $txtBirthDate.split('-');
            var $txtBirthDate = $txtBirthDate[2] + '-' + $txtBirthDate[1] + '-' + $txtBirthDate[0];
            var $DateBirth = $txtBirthDate;
            $("#txtBirthDate").val($DateBirth);
            $('#ddlGender').val($SearchsellsValue[19]).trigger('change');
            var $txtPoDate = $SearchsellsValue[20];
            var $txtPoDate = $txtPoDate.substring(0, 10);
            //For  Birth Date Format
            var $PoDate = $txtPoDate.replace(/\//g, '-')
            var $PoDate = $PoDate.split('-');
            var $PoDate = $PoDate[2] + '-' + $PoDate[1] + '-' + $PoDate[0];
            var $PoDate = $PoDate;
            $("#txtPoDate").val($PoDate);
            $("#txtPoNumber").val($SearchsellsValue[21]);
            $('#ddlVehicleName').val($SearchsellsValue[24]).trigger('change');
            $("#txtVehicleModel").val($SearchsellsValue[25]);
            $('#ddlVehicleType').val($SearchsellsValue[26]).trigger('change');
            $('#ddlTakafulType').val($SearchsellsValue[27]).trigger('change');
            $('#ddlColorName').val($SearchsellsValue[28]).trigger('change');
            $("#txtRegistrationNumber").val($SearchsellsValue[29]);
            $("#txtEngineNumber").val($SearchsellsValue[30]);
            $("#txtChasisNumber").val($SearchsellsValue[31]);
            $("#txtMileage").val($SearchsellsValue[32]);
            $('#ddlVEODCode').val($SearchsellsValue[33]).trigger('change');
            $("#txtRemarks").val($SearchsellsValue[34]);
            $("#txtTenure").val($SearchsellsValue[35]);
            $("#txtVehicleValue").val($SearchsellsValue[38]);
            $("#ddlRatingFactor").val($SearchsellsValue[37]);
            $("#txtRate").val($SearchsellsValue[39]);
            $("#txtContribution").val($SearchsellsValue[40]);
            var $ContractMaturityDate = $SearchsellsValue[41];
            var $ContractMaturityDate = $ContractMaturityDate.substring(0, 10);
            //For  Birth Date Format
            var $txtContractMaturityDate = $ContractMaturityDate.replace(/\//g, '-')
            var $txtContractMaturityDate = $txtContractMaturityDate.split('-');
            var $txtContractMaturityDate = $txtContractMaturityDate[2] + '-' + $txtContractMaturityDate[1] + '-' + $txtContractMaturityDate[0];
            var $ContractMaturity = $txtContractMaturityDate;
            $("#txtContractMaturityDate").val($ContractMaturity);
            $("#txtDeductible").val($SearchsellsValue[42]);
            $("#txtCertificateTxnSysID").val($SearchsellsValue[43]);
            $('#myModal').modal('hide');
        });
    });
    
});