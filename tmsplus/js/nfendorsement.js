$("#txtMileage").keypress(function (event) {
    var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
    if((keyCode>=65 && keyCode<=90) || (keyCode>=97 && keyCode<=122))
        return false;
    else return true;
});
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
//phone number mask
$('input[name="txtPersonalNum"]').mask('(0000) 000-0000');
//date mask
$("#txtBirthDate").inputmask();
$("#txtPoDate").inputmask();
$("#txtContractMaturityDate").inputmask();
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

// Rating Factors Api
let DdlRatingFactor = $('#ddlRatingFactor');
DdlRatingFactor.empty();
DdlRatingFactor.append('<option selected="" value="">Choose Rating Factor</option>');
DdlRatingFactor.prop('selectedIndex', 0);
const DdlRatingFactorUrl = "http://207.180.200.121/mtrprodsetup/RatingFactor/GetRatingFactor";
var Mydata;
$.ajax({
	url: DdlRatingFactorUrl,
	type: "GET",
	crossDomain: true,
	dataType: "JSON",
	success: function (data) {
		$.each(data, function (key, entry) {
			DdlRatingFactor.append($('<option></option>').attr('value', entry.RatingFactorCode).text(entry.RatingFactorName));
		})
	},
	error: function (xhr, status, error) {
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
let DdlWarranty = $('#ddlWarranty');
DdlWarranty.empty();
DdlWarranty.append('<option selected="" value="">Choose Warranty</option>');
DdlWarranty.prop('selectedIndex', 0);
const DdlWarrantyUrl = "http://207.180.200.121/mtrprodsetup/Warranties/GetWarranties";
var Mydata;
$.ajax({
	url: DdlWarrantyUrl,
	type: "GET",
	crossDomain: true,
	dataType: "JSON",
	success: function (data) {
		$.each(data, function (key, entry) {
			DdlWarranty.append($('<option></option>').attr('value', entry.WarrantyCode).text(entry.WarrantyShText));
		})
	},
	error: function (xhr, status, error) {
		alert(status);
	}
});
// Condition Api
let DdlCondition = $('#ddlCondition');
DdlCondition.empty();
DdlCondition.append('<option selected="" value="">Choose Condition</option>');
DdlCondition.prop('selectedIndex', 0);
const DdlConditionUrl = "http://207.180.200.121/mtrprodsetup/ProductConditions/GetProductConditions";
var Mydata;
$.ajax({
	url: DdlConditionUrl,
	type: "GET",
	crossDomain: true,
	dataType: "JSON",
	success: function (data) {
		$.each(data, function (key, entry) {
			DdlCondition.append($('<option></option>').attr('value', entry.ConditionCode).text(entry.ConditionShText));
		})
	},
	error: function (xhr, status, error) {
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
// OpenPolicy Dropdown Api
$('#ddlCertificateClientCode').change(function () {
	var $ddlCertificateClientCode = $('#ddlCertificateClientCode').val();
	let ddlCertificateOpenPolicy = $('#ddlCertificateOpenPolicy');
	ddlCertificateOpenPolicy.empty();
	ddlCertificateOpenPolicy.append('<option>Choose Open Policy</option>');
	ddlCertificateOpenPolicy.prop('selectedIndex', 0);
	const ddlCertificateOpenPolicyUrl = 'http://207.180.200.121/mtrprodsetup/MtrOpenPolicy/GetOPolicyByClient?_Json={"ClientCode":"' + $ddlCertificateClientCode + '"}';
	var Mydataa;
	$.ajax({
		url: ddlCertificateOpenPolicyUrl,
		type: "GET",
		crossDomain: true,
		dataType: "JSON",
		success: function (data) {
			$.each(data, function (key, entry) {
				ddlCertificateOpenPolicy.append($('<option></option>').attr('value', entry.TxnSysID).text(entry.PolicyString));
			})
			$('#ddlCertificateOpenPolicy').change(function () {
				var $ddlCertificateOpenPolicy = $('#ddlCertificateOpenPolicy').val();
				$.get('http://207.180.200.121/mtrprodsetup/MtrOpenPolicy/GetOPolicyByTxnID?_Json={"TxnSysID":' + $ddlCertificateOpenPolicy + '}', function (data) {
					//Getting Certificate Code By Open Policy
					$CertificateCode = data.CertInsureCode;
					$('#ddlOpCerTypeCode').val($CertificateCode).trigger('change');
					//Getting Ageny Code By OpenPolicy
					$AgenyCode = data.AgencyCode;
					$('#ddlAgencyCode').val($AgenyCode).trigger('change');
					// Getting Commision Rate By OpenPolicy
					$CommisionRate = data.CommisionRate;
					document.getElementById("txtCommissionRate").setAttribute("value", $CommisionRate);
					// Getting TxnSysId Rate By OpenPolicy
					$TxnSysID = data.TxnSysID;
					document.getElementById("txtTxnSysID").setAttribute("value", $TxnSysID);
					$ProductCode = data.ProductCode;
					$PolicyTypeCode = data.PolicyTypeCode;
					$('#ddlCertificateProductCode').val($ProductCode).trigger('change');
					$('#ddlCertificatePolicyTypeCode').val($PolicyTypeCode).trigger('change');
					//Getting RateFactor and Rate By Open Policy
					$.get('http://207.180.200.121/mtrprodsetup/ProductRatingFactorSetUp/GetRatingFactorByOpol?_Json={"TxnSysId":' + $TxnSysID + '}', function (data) {
						$TxtRate = data.Rate,
						$IsEditable = data.IsEditable,
						document.getElementById("txtRate").setAttribute("value", $TxtRate);
						$ddlRatingFactor = data.RatingFactor;
						$('#ddlRatingFactor').val($ddlRatingFactor).trigger('change');
						if ($IsEditable == "No") {
							$("#txtRate").prop('disabled', true);
						}
					});
				});
			});
			$txtOpenPolicyHidden=$("#txtOpenPolicyHidden").val();
            if($txtOpenPolicyHidden){
                $('#ddlCertificateOpenPolicy').val($txtOpenPolicyHidden).trigger('change');
                $("#txtOpenPolicyHidden").val('');
            }
		},
		error: function (xhr, status, error) {
			alert(status);
		}
	});
});

// Product Code Api
let ddlCertificateProductCode = $('#ddlCertificateProductCode');
ddlCertificateProductCode.empty();
ddlCertificateProductCode.append('<option>Choose Product</option>');
ddlCertificateProductCode.prop('selectedIndex', 0);
const ddlCertificateProductCodeUrl = 'http://207.180.200.121/mtrprodsetup/MasterProductSetUp/GetAllProductCodeOfMasterProductSetUp';
var Mydata;
$.ajax({
	url: ddlCertificateProductCodeUrl,
	type: "GET",
	crossDomain: true,
	dataType: "JSON",
	success: function (data) {
		$.each(data, function (key, entry) {
			ddlCertificateProductCode.append($('<option></option>').attr('value', entry.ProductCode).text(entry.ProductName));
		})
	},
	error: function (xhr, status, error) {
		alert(status);
	}
});

// Policy Type Dropdown Api
let ddlCertificatePolicyTypeCode = $('#ddlCertificatePolicyTypeCode');
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
// Endorsement Search Dropdown Api
let ddlEndorsementSearchByCert = $('#ddlEndorsementSearchByCert');
ddlEndorsementSearchByCert.empty();
ddlEndorsementSearchByCert.append('<option>Choose Search By Certificate</option>');
ddlEndorsementSearchByCert.prop('selectedIndex', 0);
const ddlEndorsementSearchByCertUrl = "http://207.180.200.121/mtrprodsetup/MtrSearchBy/GetMtrSearchBy";
var Mydata;
$.ajax({
	url: ddlEndorsementSearchByCertUrl,
	type: "GET",
	crossDomain: true,
	dataType: "JSON",
	success: function (data) {
		$.each(data, function (key, entry) {
			ddlEndorsementSearchByCert.append($('<option></option>').attr('value', entry.SeByCertCode).text(entry.SeByCertName));
		})
	},
	error: function (xhr, status, error) {
		alert(status);
	}
});
// GetInsParttaker Dropdown Api
let ddlParttaker = $('#ddlParttaker');
ddlParttaker.empty();
ddlParttaker.append('<option>Choose Search Co Insurance Code</option>');
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
ddlUpdateParttaker.append('<option>Choose Search Co Insurance Code</option>');
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
			$txtAreaCodeHidden=$("#txtAreaCodeHidden").val();
            if($txtAreaCodeHidden){
                $('#ddlAreaCode').val($txtAreaCodeHidden).trigger('change');
                $("#txtAreaCodeHidden").val('');
            }
		},
	});
});
// Tracker Company Dropdown Api
let ddlTrackerCompany = $('#ddlTrackerCompany');
ddlTrackerCompany.empty();
ddlTrackerCompany.append('<option selected="" value="">Choose Tracker Company</option>');
ddlTrackerCompany.prop('selectedIndex', 0);
ddlTrackerCompanyUrl = "http://207.180.200.121/mtrprodsetup/InsAccessories/GetInsAccessories";
var Mydata;
$.ajax({
	url: ddlTrackerCompanyUrl,
	type: "GET",
	crossDomain: true,
	dataType: "JSON",
	success: function (data) {
		$.each(data, function (key, entry) {
			ddlTrackerCompany.append($('<option></option>').attr('value', entry.ACCESSORY_CODE).text(entry.ACCESSORY_SHORT_NAME));
		})
	},
	error: function (xhr, status, error) {
		alert(status);
	}
});

// Rider Company Dropdown Api
let ddlRider = $('#ddlRider');
ddlRider.empty();
ddlRider.append('<option selected="" value="">Choose Rider</option>');
ddlRider.prop('selectedIndex', 0);
ddlRiderUrl = "http://207.180.200.121/mtrprodsetup/PerilRiders/GetPerilRiders";
var Mydata;
$.ajax({
	url: ddlRiderUrl,
	type: "GET",
	crossDomain: true,
	dataType: "JSON",
	success: function (data) {
		$.each(data, function (key, entry) {
			ddlRider.append($('<option></option>').attr('value', entry.RECORD_ID).text(entry.RIDER_NAME));
		})
	},
	error: function (xhr, status, error) {
		alert(status);
	}
});

// Endorsement Reason Dropdown Api
let ddlEndorsementReason = $('#ddlEndorsementReason');
ddlEndorsementReason.empty();
ddlEndorsementReason.append('<option selected="" value="">Choose Endorsement Reason</option>');
ddlEndorsementReason.prop('selectedIndex', 0);
ddlEndorsementReasonUrl = "http://207.180.200.121/mtrprodsetup/EndtReason/GetEndtReasonForNonF";
var Mydata;
$.ajax({
	url: ddlEndorsementReasonUrl,
	type: "GET",
	crossDomain: true,
	dataType: "JSON",
	success: function (data) {
		$.each(data, function (key, entry) {
			ddlEndorsementReason.append($('<option></option>').attr('value', entry.EndtReasonCode).text(entry.EndtReasonName));
		})
	},
	error: function (xhr, status, error) {
		alert(status);
	}
});
// Policy Header Js
$(document).ready(function () {
	//On Click Btn Endorsement Search Clear All Values
	$("#BtnEndorsementSearchNew").on("click", function () {
		$('#ddlEndorsementSearchByCert').focus();
		$("#ddlEndorsementSearchByCert").select2("val", 0);
		$("#txtEndorsementSearchCertInfo").val('');

	});
	$("#BtnProceed").on("click", function () {
		var $ddlEndorsementReason = $("#ddlEndorsementReason").find('option:selected').val();
		if (!$ddlEndorsementReason) {
			$("select[name='ddlEndorsementReason']").addClass("reqirederror");
			return false;
		}
		$("#Endorsementmodel").hide();
		
		document.getElementById("EndorsementReasonCode").setAttribute("value", $ddlEndorsementReason);
		if($ddlEndorsementReason == 5){
			$("#VehicleSec").hide();
			$("#ClientSec").show();
		}else{
			$("#ClientSec").hide();
			$("#VehicleSec").show();
		}
	});
	//On Click Btn Endorsement Search  Get All Values
	$("#BtnEndorsementSearch").on("click", function () {

		var $ddlEndorsementSearchByCertValue = $("#ddlEndorsementSearchByCert").find('option:selected').val();
		var $ddlEndorsementSearchByCert = $("#ddlEndorsementSearchByCert").find('option:selected').text();
		var $txtEndorsementSearchCertInfo = $('#txtEndorsementSearchCertInfo').val();
		if (!$ddlEndorsementSearchByCertValue) {
			$("select[name='ddlEndorsementSearchByCertValue']").addClass("reqirederror");
			return false;
		}
		if (!$txtEndorsementSearchCertInfo) {
			$("input[name='txtEndorsementSearchCertInfo']").addClass("reqirederror");
			return false;
		} else {
			if ($ddlEndorsementSearchByCertValue == 1) {
				$('#EndorsementTbl').DataTable().clear().destroy();
				var $EndorsementTbl = $("#EndorsementTbl").DataTable({
					"order": [
						[0, "desc"]
					],
					"paging": false,
					"pageLength": 5,
					"searching": false,
				});
				$.ajax({
					url: 'http://207.180.200.121/mtrprodsetup/MtrVehicleDetails/GetMtrVDByInfo/?_Json={"ChasisNumber":"'+$txtEndorsementSearchCertInfo+'","SeByCertCode":'+$ddlEndorsementSearchByCertValue+'}',
					type: 'get',
					dataType: "JSON",
					success: function (response) {
						var len = response.length;
						for (var i = 0; i < len; i++) {
							var $SerialNo = response[i].SerialNo;
							var $ChasisNumber = response[i].ChasisNumber;
							var $RegistrationNumber = response[i].RegistrationNumber;
							var $VehicleModel = response[i].VehicleModel;
							var $ParticipantName = response[i].ParticipantName;
							var $ParticipantValue = response[i].ParticipantValue;
							var $GrossContribution = response[i].GrossContribution;
							var $NetContribution = response[i].NetContribution;
							var $TxnSysID = response[i].TxnSysID;
							var $Rate = response[i].Rate;
							$EndorsementTbl.row.add([$TxnSysID,$SerialNo, $ChasisNumber, $RegistrationNumber, $VehicleModel, $ParticipantName, $ParticipantValue,$GrossContribution,$NetContribution,$Rate]).draw(false);
						}
					}
				});
			}
			if ($ddlEndorsementSearchByCertValue == 2) {
				$('#EndorsementTbl').DataTable().clear().destroy();
				var $EndorsementTbl = $("#EndorsementTbl").DataTable({
					"order": [
						[0, "desc"]
					],
					"paging": false,
					"pageLength": 5,
					"searching": false,
				});
				$.ajax({
					url: 'http://207.180.200.121/mtrprodsetup/MtrVehicleDetails/GetMtrVDByInfo/?_Json={"RegistrationNumber":"'+$txtEndorsementSearchCertInfo+'","SeByCertCode":'+$ddlEndorsementSearchByCertValue+'}',
					type: 'get',
					dataType: "JSON",
					success: function (response) {
						var len = response.length;
						for (var i = 0; i < len; i++) {
							var $SerialNo = response[i].SerialNo;
							var $ChasisNumber = response[i].ChasisNumber;
							var $RegistrationNumber = response[i].RegistrationNumber;
							var $VehicleModel = response[i].VehicleModel;
							var $ParticipantName = response[i].ParticipantName;
							var $ParticipantValue = response[i].ParticipantValue;
							var $GrossContribution = response[i].GrossContribution;
							var $NetContribution = response[i].NetContribution;
							var $TxnSysID = response[i].TxnSysID;
							var $Rate = response[i].Rate;
							$EndorsementTbl.row.add([$TxnSysID,$SerialNo, $ChasisNumber, $RegistrationNumber, $VehicleModel, $ParticipantName, $ParticipantValue,$GrossContribution,$NetContribution,$Rate]).draw(false);
						}
					}
				});
			}
			if ($ddlEndorsementSearchByCertValue == 3) {
				$('#EndorsementTbl').DataTable().clear().destroy();
				var $EndorsementTbl = $("#EndorsementTbl").DataTable({
					"order": [
						[0, "desc"]
					],
					"paging": false,
					"pageLength": 5,
					"searching": false,
				});
				$.ajax({
					url: 'http://207.180.200.121/mtrprodsetup/MtrVehicleDetails/GetMtrVDByInfo/?_Json={"ModelNumber":"'+$txtEndorsementSearchCertInfo+'","SeByCertCode":'+$ddlEndorsementSearchByCertValue+'}',
					type: 'get',
					dataType: "JSON",
					success: function (response) {
						var len = response.length;
						for (var i = 0; i < len; i++) {
							var $SerialNo = response[i].SerialNo;
							var $ChasisNumber = response[i].ChasisNumber;
							var $RegistrationNumber = response[i].RegistrationNumber;
							var $VehicleModel = response[i].VehicleModel;
							var $ParticipantName = response[i].ParticipantName;
							var $ParticipantValue = response[i].ParticipantValue;
							var $GrossContribution = response[i].GrossContribution;
							var $NetContribution = response[i].NetContribution;
							var $TxnSysID = response[i].TxnSysID;
							var $Rate = response[i].Rate;
							$EndorsementTbl.row.add([$TxnSysID,$SerialNo, $ChasisNumber, $RegistrationNumber, $VehicleModel, $ParticipantName, $ParticipantValue,$GrossContribution,$NetContribution,$Rate]).draw(false);
						}
					}
				});
			}
			if ($ddlEndorsementSearchByCertValue == 4) {
				$('#EndorsementTbl').DataTable().clear().destroy();
				var $EndorsementTbl = $("#EndorsementTbl").DataTable({
					"order": [
						[0, "desc"]
					],
					"paging": false,
					"pageLength": 5,
					"searching": false,
				});
				$.ajax({
					url: 'http://207.180.200.121/mtrprodsetup/MtrVehicleDetails/GetMtrVDByInfo/?_Json={"ParticipantName":"'+$txtEndorsementSearchCertInfo+'","SeByCertCode":'+$ddlEndorsementSearchByCertValue+'}',
					type: 'get',
					dataType: "JSON",
					success: function (response) {
						var len = response.length;
						for (var i = 0; i < len; i++) {
							var $SerialNo = response[i].SerialNo;
							var $ChasisNumber = response[i].ChasisNumber;
							var $RegistrationNumber = response[i].RegistrationNumber;
							var $VehicleModel = response[i].VehicleModel;
							var $ParticipantName = response[i].ParticipantName;
							var $ParticipantValue = response[i].ParticipantValue;
							var $GrossContribution = response[i].GrossContribution;
							var $NetContribution = response[i].NetContribution;
							var $TxnSysID = response[i].TxnSysID;
							var $Rate = response[i].Rate2;

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
							var $Remarks = response[i].Remarks;


							var $VehicleCode = response[i].VehicleCode;
							var $VehicleType = response[i].VehicleType;
							var $InsuranceTypeCode = response[i].InsuranceTypeCode;
							var $ColorCode = response[i].ColorCode;
							var $EngineNumber = response[i].EngineNumber;
							var $Mileage = response[i].Mileage;
							var $VEODCode = response[i].VEODCode;
							var $Remarks = response[i].Remarks;
							var $Tenure = response[i].Tenure;
							var $CertTypeCode = response[i].CertTypeCode;
							var $RatingFactor = response[i].RatingFactor;
							var $Contribution = response[i].Contribution;
							var $ContractMatDate = response[i].ContractMatDate;
							var $Deductible = response[i].Deductible;

							var $ClientCode = response[i].ClientCode;
							var $OpolTxnSysID = response[i].OpolTxnSysID;
							var $CertString = response[i].CertString;
							var $EffectiveDate = response[i].EffectiveDate;
							var $ExpiryDate = response[i].ExpiryDate;
							$EndorsementTbl.row.add([$ParticipantAddress,$EmailAddress,$CityCode,$AreaCode,$CNICNumber,$MobileNumber,$OfficeNumber,$ResNumber,$BirthDate,$Gender,$PODate,$PONumber,$Remarks,$VehicleCode,$VehicleType,$InsuranceTypeCode,$ColorCode,$EngineNumber,$Mileage,$VEODCode,$Tenure,$CertTypeCode,$RatingFactor,$Contribution,$ContractMatDate,$Deductible,$ClientCode,$OpolTxnSysID,$CertString,$TxnSysID,$SerialNo, $ChasisNumber, $RegistrationNumber, $VehicleModel, $ParticipantName, $ParticipantValue,$GrossContribution,$NetContribution,$Rate,$EffectiveDate,$ExpiryDate]).draw(false);
						}
					}
				});
			}
			if ($ddlEndorsementSearchByCertValue == 5) {
				$('#EndorsementTbl').DataTable().clear().destroy();
				var $EndorsementTbl = $("#EndorsementTbl").DataTable({
					"order": [
						[0, "desc"]
					],
					"paging": false,
					"pageLength": 5,
					"searching": false,

				});
				$.ajax({
					url: 'http://207.180.200.121/mtrprodsetup/MtrVehicleDetails/GetMtrVDByInfo/?_Json={"ParentTxnSysID":"'+$txtEndorsementSearchCertInfo+'","SeByCertCode":'+$ddlEndorsementSearchByCertValue+'}',
					type: 'get',
					dataType: "JSON",
					success: function (response) {
						var len = response.length;
						for (var i = 0; i < len; i++) {
							var $SerialNo = response[i].SerialNo;
							var $ChasisNumber = response[i].ChasisNumber;
							var $RegistrationNumber = response[i].RegistrationNumber;
							var $VehicleModel = response[i].VehicleModel;
							var $ParticipantName = response[i].ParticipantName;
							var $ParticipantValue = response[i].ParticipantValue;
							var $GrossContribution = response[i].GrossContribution;
							var $NetContribution = response[i].NetContribution;
							var $TxnSysID = response[i].TxnSysID;
							var $Rate = response[i].Rate;
							$EndorsementTbl.row.add([$TxnSysID,$SerialNo, $ChasisNumber, $RegistrationNumber, $VehicleModel, $ParticipantName, $ParticipantValue,$GrossContribution,$NetContribution]).draw(false);
						}
					}
				});
			}

			//Getting All Values For Endorsement Tbl on Table Click
			$('#EndorsementTbl').off( 'click.rowClick' ).on('click.rowClick', 'tr', function () {
				$("#EndorsementSec").show();
				var $sellValue = $EndorsementTbl.row(this).data();
				$rowIdx = $EndorsementTbl.row(this).index;
				$("#EndorsementTbl").val($rowIdx);
				$row = $EndorsementTbl.row(this).node();
				$($row).addClass('ready');
				document.getElementById("txnSysId").innerHTML = $sellValue[29];
				$("#txtParticipantName").val($sellValue[34]);
				$("#txtParticipantAddress").val($sellValue[0]);
				$("#txtEmail").val($sellValue[1]);
				$('#ddlCityCode').val($sellValue[2]).trigger('change');
				$("#txtAreaCodeHidden").val($sellValue[3]);
				$("#txtCnicNum").val($sellValue[4]);
				$("#txtPersonalNum").val($sellValue[5]);
				$("#txtOfficeNum").val($sellValue[6]);
				$("#txtResidenceNum").val($sellValue[7]);
				var $BirthDateDate = $sellValue[8];
		        var $BirthDateDate = $BirthDateDate.substring(0, 10);
		        //For  Birth Date Format
		        var $txtBirthDate = $BirthDateDate.replace(/\//g, '-')
		        var $txtBirthDate = $txtBirthDate.split('-');
		        var $txtBirthDate = $txtBirthDate[2] + '-' + $txtBirthDate[1] + '-' + $txtBirthDate[0];
		        var $DateBirth = $txtBirthDate;
		        $("#txtBirthDate").val($DateBirth);
				$('#ddlGender').val($sellValue[9]).trigger('change');
				var $PoDate = $sellValue[10];
		        var $PoDate = $PoDate.substring(0, 10);
		        var $DatePO = $PoDate;
		        var $txtPoDate = $DatePO.replace(/\//g, '-')

		        var $txtPoDate = $txtPoDate.split('-');
		        var $txtPoDate = $txtPoDate[2] + '-' + $txtPoDate[1] + '-' + $txtPoDate[0];
		        $("#txtPoDate").val($txtPoDate);
				$("#txtPoNumber").val($sellValue[11]);
				$("#txtRemarksClient").val($sellValue[12]);
				$("#txtTxnSysID").val($sellValue[29]);
				$("#txtRemarks").val($sellValue[12]);

				$('#ddlVehicleName').val($sellValue[13]).trigger('change');
				$("#txtVehicleModel").val($sellValue[33]);
				$('#ddlVehicleType').val($sellValue[14]).trigger('change');
				$('#ddlTakafulType').val($sellValue[15]).trigger('change');
				$('#ddlColorName').val($sellValue[16]).trigger('change');
				$("#txtRegistrationNumber").val($sellValue[32]);
				$("#txtEngineNumber").val($sellValue[17]);
				$("#txtChasisNumber").val($sellValue[31]);
				$("#txtMileage").val($sellValue[18]);
				$('#ddlVEODCode').val($sellValue[19]).trigger('change');

				
				$("#txtTenure").val($sellValue[20]);
				$('#ddlOpCerTypeCode').val($sellValue[21]).trigger('change');
				$('#ddlRatingFactor').val($sellValue[22]).trigger('change');
				$("#txtVehicleValue").val($sellValue[35]);
				$("#txtRate").val($sellValue[38	]);
				$("#txtContribution").val($sellValue[23]);
				var $ContractMaturityDate = $sellValue[24];
		        var $ContractMaturityDate = $ContractMaturityDate.substring(0, 10);
		        var $DateContract = $ContractMaturityDate;
		        var $txtContractMaturityDate = $DateContract.replace(/\//g, '-')

		        var $txtContractMaturityDate = $txtContractMaturityDate.split('-');
		        var $txtContractMaturityDate = $txtContractMaturityDate[2] + '-' + $txtContractMaturityDate[1] + '-' + $txtContractMaturityDate[0];
		        $("#txtContractMaturityDate").val($txtContractMaturityDate);
				$("#txtDeductible").val($sellValue[25]);
				$('#ddlCertificateClientCode').val($sellValue[26]).trigger('change');
				$("#txtOpenPolicyHidden").val($sellValue[27]);
				$("#txtPolicyString").val($sellValue[28]);

				$Effective=$sellValue[39];
				var $EffectiveDate = $Effective.substring(0, 10);
				$("#txtCertificateEffectiveDate").val($EffectiveDate);

				$Expiry=$sellValue[40];
				var $ExpiryDate = $Expiry.substring(0, 10);
				$("#txtCerticateExpiryDate").val($ExpiryDate);
				//on click save 
				$("#BtnVehicleSave").on("click", function () {
					var $EndorsementReasonCode = $('#EndorsementReasonCode').val();
			       	if($EndorsementReasonCode == 5){
				       	var $txtParticipantName = $('#txtParticipantName').val();
						var $txtParticipantAddress = $('#txtParticipantAddress').val();
						var $txtEmail = $('#txtEmail').val();
						var $EndorsementReasonCode = $('#EndorsementReasonCode').val();
						var $ddlCityCodeValue = $("#ddlCityCode").find('option:selected').val();
				        var $ddlCityCode = $("#ddlCityCode").find('option:selected').text();
				        var $ddlAreaCodeValue = $("#ddlAreaCode").find('option:selected').val();
				        var $ddlAreaCode = $("#ddlAreaCode").find('option:selected').text();
				        var $txtCnicNum = $('#txtCnicNum').val();
				        var $txtPersonalNum = $('#txtPersonalNum').val();
				        var $txtOfficeNum = $('#txtOfficeNum').val();
				        var $txtResidenceNum = $('#txtResidenceNum').val();
				        var $txtTxnSysID = $('#txtTxnSysID').val();
				        //For  Birth Date Format
				        var $txtBirthDate = $('#txtBirthDate').val();
				        var $DateBirth = $txtBirthDate;
				        var $txtBirthDate = $DateBirth.replace(/\//g, '-')

				        var $txtBirthDate = $txtBirthDate.split('-');
				        var $txtBirthDate = $txtBirthDate[1] + '-' + $txtBirthDate[0] + '-' + $txtBirthDate[2];
				        var $ddlGenderValue = $("#ddlGender").find('option:selected').val();
				        var $ddlGender = $("#ddlGender").find('option:selected').text();
				        var $txtRemarksClient = $('#txtRemarksClient').val();
				        //For  PO Date Format
				        var $txtPoDate = $('#txtPoDate').val();
				        var $DatePO = $txtPoDate;
				        var $txtPoDate = $DatePO.replace(/\//g, '-')

				        var $txtPoDate = $txtPoDate.split('-');
				        var $txtPoDate = $txtPoDate[1] + '-' + $txtPoDate[0] + '-' + $txtPoDate[2];
				        var $txtPoDate = $('#txtPoDate').val();
				        var $txtPoNumber = $('#txtPoNumber').val();
				        if (!$txtParticipantName) {
				            document.getElementById("test").innerHTML = "Please Fill Participant Name";
				            $('#ErrorModalValidate').modal('show');
				            setTimeout(function() {
				                $('#ErrorModalValidate').modal('hide')
				            }, 2000);
				            $('#txtParticipantName').focus().val($('#txtParticipantName').val());
				            return false;
				        }
				        if (!$txtParticipantAddress) {
				            document.getElementById("test").innerHTML = "Please Fill Participant Address";
				            $('#ErrorModalValidate').modal('show');
				            setTimeout(function() {
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
				            setTimeout(function() {
				                $('#ErrorModalValidate').modal('hide')
				            }, 2000);
				            $('#txtCnicNum').focus().val($('#txtCnicNum').val());
				            return false;
				        }
				        if(!$ddlCityCodeValue || $ddlCityCode == 'Choose City'){
                            var $ddlCityCodeValue = -1;
                        }
                        if(!$ddlAreaCodeValue || $ddlAreaCode == 'Choose Area'){
                            var $ddlAreaCodeValue = -1;
                        }
                        if(!$txtBirthDate || $txtBirthDate == "undefined-undefined-"){
                            var $txtBirthDate ="1900-01-01";
                        }
                        if(!$ddlGenderValue || $ddlGender == 'Choose Gender'){
                            var $ddlGenderValue = -1;
                        }
                        if(!$txtPoDate || $txtPoDate == "undefined-undefined-"){
                            var $txtPoDate ="1900-01-01";
                        }
				        var $BtnClientNew = {
				            EndtReasonCode: $EndorsementReasonCode,
				            TxnSysID: $txtTxnSysID,
				            ParticipantName: $txtParticipantName,
				            ParticipantAddress: $txtParticipantAddress,
				            CityCode: $ddlCityCodeValue,
				            AreaCode: $ddlAreaCodeValue,
				            CNICNumber: $txtCnicNum,
				            MobileNumber: $txtPersonalNum,
				            ResNumber: $txtResidenceNum,
				            OfficeNumber: $txtOfficeNum,
				            EmailAddress: $txtEmail,
				            BirthDate: $txtBirthDate,
				            Gender: $ddlGender,
				            Remarks:$txtRemarksClient,
				        };
				        var $BtnClientNew = JSON.stringify($BtnClientNew);
				        $.get("http://207.180.200.121/mtrprodsetup/MtrVehicleDetails/ForNonFEndorsement/?_Json=" + $BtnClientNew, function(data) {
							$ValidTxn = data.IsValidTxn;
							console.log(data);
							if ($ValidTxn == true) {
								$('#SubmitModal').modal('show');
		                        setTimeout(function() {
		                            $('#SubmitModal').modal('hide')
		                        }, 2000);
							}
						});
					}else{
                        if(!$ddlVehicleTypeValue || $ddlVehicleType == 'Choose Vehicle Type'){
                            var $ddlVehicleTypeValue = -1;
                        }
                        if(!$txtMileage){
                            var $txtMileage = -1;
                        }
                        if(!$ddlVEODCodeValue || $ddlVEODCode == 'Choose VEOD'){
                            var $ddlVEODCodeValue = -1;
                        }
						var $EndorsementReasonCode = $('#EndorsementReasonCode').val();
						var $ddlVehicleNameValue = $("#ddlVehicleName").find('option:selected').val();
        				var $txtVehicleModel = $('#txtVehicleModel').val();
						var $ddlTakafulTypeValue = $("#ddlTakafulType").find('option:selected').val();
						var $ddlColorNameValue = $("#ddlColorName").find('option:selected').val();
						var $txtRegistrationNumber = $('#txtRegistrationNumber').val();
						var $txtEngineNumber = $('#txtEngineNumber').val();
        				var $txtChasisNumber = $('#txtChasisNumber').val();
        				var $txtMileage = $('#txtMileage').val();
        				var $ddlVehicleTypeValue = $("#ddlVehicleType").find('option:selected').val();
        				var $ddlVEODCodeValue = $("#ddlVEODCode").find('option:selected').val();
        				var $txtRemarks=$('#txtRemarks').val();
        				var $txtTxnSysID = $('#txtTxnSysID').val();
        				if (!$ddlVehicleNameValue || $ddlVehicleNameValue == 'Choose Vehicle') {
				            document.getElementById("test").innerHTML = "Please Select Vechicle";
				            $('#ErrorModalValidate').modal('show');
				            setTimeout(function () {
				                $('#ErrorModalValidate').modal('hide')
				            }, 2000);
				            $('#ddlVehicleName').focus().val($('#ddlVehicleName').val());
				            return false;
				        }
				        if (!$ddlColorNameValue) {
				            $document.getElementById("test").innerHTML = "Please Select Color";
				            $('#ErrorModalValidate').modal('show');
				            setTimeout(function() {
				                $('#ErrorModalValidate').modal('hide')
				            }, 2000);
				            $('#ddlColorName').focus().val($('#ddlColorName').val());
				            return false;
				        }
				        if (!$txtVehicleModel) {
				            document.getElementById("test").innerHTML = "Please Fill Vehicle Model";
				            $('#ErrorModalValidate').modal('show');
				            setTimeout(function() {
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
				        if (!$txtRegistrationNumber) {
				            document.getElementById("test").innerHTML = "Please Fill Registration Number";
				            $('#ErrorModalValidate').modal('show');
				            setTimeout(function() {
				                $('#ErrorModalValidate').modal('hide')
				            }, 2000);
				            $('#txtRegistrationNumber').focus().val($('#txtRegistrationNumber').val());
				            return false;
				        }
				        if (!$txtEngineNumber) {
				            document.getElementById("test").innerHTML = "Please Fill Engine Number";
				            $('#ErrorModalValidate').modal('show');
				            setTimeout(function() {
				                $('#ErrorModalValidate').modal('hide')
				            }, 2000);
				            $('#txtEngineNumber').focus().val($('#txtEngineNumber').val());
				            return false;
				        }
				        if (!$txtChasisNumber) {
				            document.getElementById("test").innerHTML = "Please Fill Chasis Number Number";
				            $('#ErrorModalValidate').modal('show');
				            setTimeout(function() {
				                $('#ErrorModalValidate').modal('hide')
				            }, 2000);
				            $('#txtChasisNumber').focus().val($('#txtChasisNumber').val());
				            return false;
				        } 
						var $BtnVehicleNew = {
				            EndtReasonCode: $EndorsementReasonCode,
				            TxnSysID: $txtTxnSysID,
				            VehicleCode: $ddlVehicleNameValue,
				            VehicleModel: $txtVehicleModel,
				            ColorCode: $ddlColorNameValue,
				            RegistrationNumber: $txtRegistrationNumber,
				            EngineNumber: $txtEngineNumber,
				            ChasisNumber: $txtChasisNumber,
				            VehicleType: $ddlVehicleTypeValue,
				            Mileage: $txtMileage,
				            VEODCode: $ddlVEODCodeValue,
				            Remarks:$txtRemarks,
				        };	
				        var $BtnVehicleNew = JSON.stringify($BtnVehicleNew);
				        $.get("http://207.180.200.121/mtrprodsetup/MtrVehicleDetails/ForNonFEndorsement/?_Json=" + $BtnVehicleNew, function(data) {
							console.log(data);
							$ValidTxn = data.IsValidTxn;
							if ($ValidTxn == true) {
								$('#SubmitModal').modal('show');
		                        setTimeout(function() {
		                            $('#SubmitModal').modal('hide')
		                        }, 2000);
							}
						});
					}
				});
			});
			
		}
	});

});
