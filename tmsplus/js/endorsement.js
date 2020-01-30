
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
// Endorsement Type Dropdown Api
let ddlEndorsementType = $('#ddlEndorsementType');
ddlEndorsementType.empty();
ddlEndorsementType.append('<option selected="" value="">Choose Endorsement Type</option>');
ddlEndorsementType.prop('selectedIndex', 0);
ddlEndorsementTypeUrl = "http://207.180.200.121/mtrprodsetup/EndtType/GetEndtType";
var Mydata;
$.ajax({
	url: ddlEndorsementTypeUrl,
	type: "GET",
	crossDomain: true,
	dataType: "JSON",
	success: function (data) {
		$.each(data, function (key, entry) {
			ddlEndorsementType.append($('<option></option>').attr('value', entry.EndtTypeCode).text(entry.EndtTypeName));
		})
	},
});
// Endorsement Reason Dropdown Api
$('#ddlEndorsementType').change(function () {
	var $ddlEndorsementType = $('#ddlEndorsementType').val();
	let ddlEndorsementReason = $('#ddlEndorsementReason');
	ddlEndorsementReason.empty();
	ddlEndorsementReason.append('<option selected="" value="">Choose Endorsement Reason</option>');
	ddlEndorsementReason.prop('selectedIndex', 0);
	ddlEndorsementReasonUrl = 'http://207.180.200.121/mtrprodsetup/EndtReason/GetEndtReason?_Json={"EndtTypeCode":'+$ddlEndorsementType+'}';
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
	});
});
// Policy Header Js
$(document).ready(function () {
	//On Click Btn Endorsement Search Clear All Values
	$("#BtnEndorsementSearchNew").on("click", function () {
		$('#ddlEndorsementSearchByCert').focus();
		$("#ddlEndorsementSearchByCert").select2("val", 0);
		$("#txtEndorsementSearchCertInfo").val('');
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
							$EndorsementTbl.row.add([$TxnSysID,$SerialNo, $ChasisNumber, $RegistrationNumber, $VehicleModel, $ParticipantName, $ParticipantValue,$GrossContribution,$NetContribution,$Rate,]).draw(false);
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
			// Getting All Values For Endorsement Tbl on Table Click
			$('#EndorsementTbl').off( 'click.rowClick' ).on('click.rowClick', 'tr', function () {
				$('#EndorsementSec').show();
				$('#greater').hide();
				$('#less').hide();
				$('#BtnCalculation').show();
				$('#BtnCalcSave').show();
				$("#txtEndorsementValue").val('');	
				$("#EndorsementCalcRowIndex").val("-1");
				var $sellValue = $EndorsementTbl.row(this).data();
				$rowIdx = $EndorsementTbl.row(this).index;
				$("#EndorsementTbl").val($rowIdx);
				$row = $EndorsementTbl.row(this).node();
				$($row).addClass('ready');
				$("#EndorsementCertificateTxnSysID").val($sellValue[0]);
				document.getElementById("txnSysId").innerHTML = $sellValue[0];
				//On Click BtnSearch Clear All Values
				$("#BtnEndorsementClear").on("click", function () {
					$('#ddlEndorsementType').focus();
					$("#ddlEndorsementType").select2("val", 0);
					$("#ddlEndorsementReason").select2("val", 0);
					$("#txtEndorsementValue").val('');
					$("#txtRemarks").val('');
					$("#EndorsementCalcRowIndex").val("-1");
				});

				$('#txtEndorsementValue').change(function () {
					var $ddlEndorsementReason = $("#ddlEndorsementReason").find('option:selected').text();
					var $ddlEndorsementReasonValue = $("#ddlEndorsementReason").find('option:selected').val();
					var $txtEndorsementValue = $('#txtEndorsementValue').val();
					if($ddlEndorsementReasonValue == 1){
						if($txtEndorsementValue <= $sellValue[9]){
							$('#greater').show();
							$('#less').hide();
							document.getElementById("greater").innerHTML = "Please Enter Value Greater Than " + $sellValue[9];
							$('#BtnCalculation').hide();
							$('#BtnCalcSave').hide();
						}else{
							$('#greater').hide();
							$('#BtnCalculation').show();
							$('#BtnCalcSave').show();
							$('#less').hide();
						}
					}else if($ddlEndorsementReasonValue == 2){
						if($txtEndorsementValue <= $sellValue[6]){
							$('#greater').show();
							$('#less').hide();
							document.getElementById("greater").innerHTML = "Please Enter Value Greater Than " + $sellValue[6];
							$('#BtnCalculation').hide();
							$('#BtnCalcSave').hide();
						}else{
							$('#greater').hide();
							$('#BtnCalculation').show();
							$('#BtnCalcSave').show();
							$('#less').hide();
						}
					}else if($ddlEndorsementReasonValue == 3){
						if($txtEndorsementValue >= $sellValue[9]){
							$('#greater').hide();
							$('#less').show();
							document.getElementById("less").innerHTML = "Please Enter Value less Than " + $sellValue[9];
							$('#BtnCalculation').hide();
							$('#BtnCalcSave').hide();
						}else{
							$('#BtnCalculation').show();
							$('#greater').hide();
							$('#BtnCalcSave').show();
							$('#less').hide();
						}
					}else if($ddlEndorsementReasonValue == 4){
						if($txtEndorsementValue >= $sellValue[6]){
							$('#greater').hide();
							$('#less').show();
							document.getElementById("less").innerHTML = "Please Enter Value less Than " + $sellValue[6];
							$('#BtnCalculation').hide();
							$('#BtnCalcSave').hide();
						}else{
							$('#BtnCalculation').show();
							$('#greater').hide();
							$('#BtnCalcSave').show();
							$('#less').hide();
						}
					}
				});

				$("#BtnCalculation").on("click", function () {
					
					var $ddlEndorsementTypeValue = $("#ddlEndorsementType").find('option:selected').val();
					var $ddlEndorsementType = $("#ddlEndorsementType").find('option:selected').text();

					var $ddlEndorsementReasonValue = $("#ddlEndorsementReason").find('option:selected').val();
					var $ddlEndorsementReason = $("#ddlEndorsementReason").find('option:selected').text();

					var $txtEndorsementValue = $('#txtEndorsementValue').val();

					var $txtRemarks = $('#txtRemarks').val();

					var $EndorsementCertificateTxnSysID = $('#EndorsementCertificateTxnSysID').val();
					if ($ddlEndorsementTypeValue == 'Choose Endorsement Type' || $ddlEndorsementTypeValue == '') {
						$("select[name='ddlEndorsementType']").addClass("reqirederror");
						return false;
					}
					if ($ddlEndorsementReasonValue == 'Choose Endorsement Reason' || $ddlEndorsementReasonValue == '') {
						$("select[name='ddlEndorsementReason']").addClass("reqirederror");
						return false;
					}
					if (!$txtEndorsementValue) {
						$("input[name='txtEndorsementValue']").addClass("reqirederror");
						return false;
					}else{
						if ($("#EndorsementCalcRowIndex").val() == "-1") {
							
							if($ddlEndorsementReasonValue == "1" || $ddlEndorsementReasonValue == "3"){
								var $BtnEndorsementCalcNew = {
									TxnSysID: $EndorsementCertificateTxnSysID,
									Remarks: $txtRemarks,
									EndtReasonCode: $ddlEndorsementReasonValue,
									Rate: $txtEndorsementValue,
								};
								var $BtnEndorsementCalcNew = JSON.stringify($BtnEndorsementCalcNew);
								//Destroy EndorsementCalcTbl
								$('#EndorsementCalcTbl').DataTable().clear().destroy();
								var $EndorsementCalcTbl = $("#EndorsementCalcTbl").DataTable({
									"order": [
										[0, "desc"]
									],
									"paging": false,
									"pageLength": 5,
									"searching": false,
								});
								$.ajax({
									url: "http://207.180.200.121/mtrprodsetup/Calculation/GetCalcForEndor/?_Json=" + $BtnEndorsementCalcNew,
									type: 'get',
									dataType: "JSON",
									success: function (response) {
										var len = response.length;
										for (var i = 0; i < len; i++) {
											var $differenceU = response[i].differenceU;
											var $GrossContributionU = response[i].GrossContributionU;
											var $NetContributionU = response[i].NetContributionU;
											var $FEDU = response[i].FEDU;
											var $FIFU = response[i].FIFU;
											var $BeforePEVU = response[i].BeforePEVU;
											$EndorsementCalcTbl.row.add([$differenceU,$GrossContributionU,$NetContributionU,$FEDU,$FIFU,$BeforePEVU]).draw(false);
										}
									}
								});

								//Destroy EndorsementCalcTblPrevious
								$('#EndorsementCalcTblPrevious').DataTable().clear().destroy();
								var $EndorsementCalcTblPrevious = $("#EndorsementCalcTblPrevious").DataTable({
									"order": [
										[0, "desc"]
									],
									"paging": false,
									"pageLength": 5,
									"searching": false,
								});
								$.ajax({
									url: "http://207.180.200.121/mtrprodsetup/Calculation/GetCalcForEndor/?_Json=" + $BtnEndorsementCalcNew,
									type: 'get',
									dataType: "JSON",
									success: function (response) {
										var len = response.length;
										for (var i = 0; i < len; i++) {
											var $differenceU= response[i].differenceU;
											var $GrossContributionP = response[i].GrossContributionP;
											var $NetContributionP = response[i].NetContributionP;
											var $FEDP = response[i].FEDP;
											var $FIFP = response[i].FIFP;
											var $BeforePEVP = response[i].BeforePEVP;
											$EndorsementCalcTblPrevious.row.add([$differenceU,$GrossContributionP,$NetContributionP,$FEDP,$FIFP,$BeforePEVP]).draw(false);
										}
									}
								});
								$('#EndorsementCalcTblVariance').DataTable().clear().destroy();
								var $EndorsementCalcTblVariance = $("#EndorsementCalcTblVariance").DataTable({
									"order": [
										[0, "desc"]
									],
									"paging": false,
									"pageLength": 5,
									"searching": false,
								});
								$.ajax({
									url: "http://207.180.200.121/mtrprodsetup/Calculation/GetCalcForEndor/?_Json=" + $BtnEndorsementCalcNew,
									type: 'get',
									dataType: "JSON",
									success: function (response) {
										var len = response.length;
										for (var i = 0; i < len; i++) {
											var $differenceV= response[i].differenceV;
											var $GrossContributionV = response[i].GrossContributionV;
											var $NetContributionV = response[i].NetContributionV;
											var $FEDV = response[i].FEDV;
											var $FIFV = response[i].FIFV;
											var $BeforePEVV = response[i].BeforePEVV;
											$EndorsementCalcTblVariance.row.add([$differenceV,$GrossContributionV,$NetContributionV,$FEDV,$FIFV,$BeforePEVV]).draw(false);
										}
									}
								});
							}else{
								var $BtnEndorsementCalcNew = {
									TxnSysID: $EndorsementCertificateTxnSysID,
									Remarks: $txtRemarks,
									EndtReasonCode: $ddlEndorsementReasonValue,
									ParticipantValue: $txtEndorsementValue,
								};
								var $BtnEndorsementCalcNew = JSON.stringify($BtnEndorsementCalcNew);
								//Destroy EndorsementCalcTbl
								$('#EndorsementCalcTbl').DataTable().clear().destroy();
								var $EndorsementCalcTbl = $("#EndorsementCalcTbl").DataTable({
									"order": [
										[0, "desc"]
									],
									"paging": false,
									"pageLength": 5,
									"searching": false,
								});
								$.ajax({
									url: "http://207.180.200.121/mtrprodsetup/Calculation/GetCalcForEndor/?_Json=" + $BtnEndorsementCalcNew,
									type: 'get',
									dataType: "JSON",
									success: function (response) {
										var len = response.length;
										for (var i = 0; i < len; i++) {
											var $differenceU = response[i].differenceU;
											var $GrossContributionU = response[i].GrossContributionU;
											var $NetContributionU = response[i].NetContributionU;
											var $FEDU = response[i].FEDU;
											var $FIFU = response[i].FIFU;
											var $BeforePEVU = response[i].BeforePEVU;
											$EndorsementCalcTbl.row.add([$differenceU,$GrossContributionU,$NetContributionU,$FEDU,$FIFU,$BeforePEVU]).draw(false);
										}
									}
								});

								//Destroy EndorsementCalcTblPrevious
								$('#EndorsementCalcTblPrevious').DataTable().clear().destroy();
								var $EndorsementCalcTblPrevious = $("#EndorsementCalcTblPrevious").DataTable({
									"order": [
										[0, "desc"]
									],
									"paging": false,
									"pageLength": 5,
									"searching": false,
								});
								$.ajax({
									url: "http://207.180.200.121/mtrprodsetup/Calculation/GetCalcForEndor/?_Json=" + $BtnEndorsementCalcNew,
									type: 'get',
									dataType: "JSON",
									success: function (response) {
										var len = response.length;
										for (var i = 0; i < len; i++) {
											var $differenceU= response[i].differenceU;
											var $GrossContributionP = response[i].GrossContributionP;
											var $NetContributionP = response[i].NetContributionP;
											var $FEDP = response[i].FEDP;
											var $FIFP = response[i].FIFP;
											var $BeforePEVP = response[i].BeforePEVP;
											$EndorsementCalcTblPrevious.row.add([$differenceU,$GrossContributionP,$NetContributionP,$FEDP,$FIFP,$BeforePEVP]).draw(false);
										}
									}
								});
								$('#EndorsementCalcTblVariance').DataTable().clear().destroy();
								var $EndorsementCalcTblVariance = $("#EndorsementCalcTblVariance").DataTable({
									"order": [
										[0, "desc"]
									],
									"paging": false,
									"pageLength": 5,
									"searching": false,
								});
								$.ajax({
									url: "http://207.180.200.121/mtrprodsetup/Calculation/GetCalcForEndor/?_Json=" + $BtnEndorsementCalcNew,
									type: 'get',
									dataType: "JSON",
									success: function (response) {
										var len = response.length;
										for (var i = 0; i < len; i++) {
											var $differenceU= response[i].differenceU;
											var $GrossContributionV = response[i].GrossContributionV;
											var $NetContributionV = response[i].NetContributionV;
											var $FEDV = response[i].FEDV;
											var $FIFV = response[i].FIFV;
											var $BeforePEVV = response[i].BeforePEVV;
											$EndorsementCalcTblVariance.row.add([$differenceU,$GrossContributionV,$NetContributionV,$FEDV,$FIFV,$BeforePEVV]).draw(false);
										}
									}
								});
							}
						}
					}
				});
				$("#BtnCalcSave").on("click", function () {
					$('#Endorsementmodel').modal('hide');
					var $ddlEndorsementTypeValue = $("#ddlEndorsementType").find('option:selected').val();
					var $ddlEndorsementType = $("#ddlEndorsementType").find('option:selected').text();

					var $ddlEndorsementReasonValue = $("#ddlEndorsementReason").find('option:selected').val();
					var $ddlEndorsementReason = $("#ddlEndorsementReason").find('option:selected').text();

					var $txtEndorsementValue = $('#txtEndorsementValue').val();

					var $txtRemarks = $('#txtRemarks').val();

					var $EndorsementCertificateTxnSysID = $('#EndorsementCertificateTxnSysID').val();
					if ($ddlEndorsementTypeValue == 'Choose Endorsement Type' || $ddlEndorsementTypeValue == '') {
						$("select[name='ddlEndorsementType']").addClass("reqirederror");
						return false;
					}
					if ($ddlEndorsementReasonValue == 'Choose Endorsement Reason' || $ddlEndorsementReasonValue == '') {
						$("select[name='ddlEndorsementReason']").addClass("reqirederror");
						return false;
					}
					if (!$txtEndorsementValue) {
						$("input[name='txtEndorsementValue']").addClass("reqirederror");
						return false;
					}
					if (!$txtRemarks) {
						$("input[name='txtRemarks']").addClass("reqirederror");
						return false;
					}else{
							
						if($ddlEndorsementReasonValue == "1" || $ddlEndorsementReasonValue == "3"){
							var $BtnEndorsementCalcNew = {
								TxnSysID: $EndorsementCertificateTxnSysID,
								Remarks: $txtRemarks,
								EndtReasonCode: $ddlEndorsementReasonValue,
								Rate: $txtEndorsementValue,
							};
							var $BtnEndorsementCalcNew = JSON.stringify($BtnEndorsementCalcNew);
							
							$.get("http://207.180.200.121/mtrprodsetup/MtrVContribution/GetMtrVDForEndt/?_Json=" + $BtnEndorsementCalcNew, function (data) {
								console.log(data);
								if(data.ClientCode){
									$('#ddlCertificateClientCode').val(data.ClientCode).trigger('change');
								}
								if(data.GenerateAgainst){
									document.getElementById("ddlCertificateOpenPolicy").setAttribute("value", data.GenerateAgainst);
								}
								if(data.PolicyString){
									document.getElementById("txtPolicyString").setAttribute("value", data.PolicyString);
								}
								if(data.AgentName){
									document.getElementById("ddlAgencyCode").setAttribute("value", data.AgentName);
								}
								if(data.CommisionRate){
									document.getElementById("txtCommissionRate").setAttribute("value", data.CommisionRate);
								}
								if(data.EffectiveDate){
									var $EffectiveDate = data.EffectiveDate;
									var $EffectiveDate = $EffectiveDate.substring(0, 10);
									var $Effective=$EffectiveDate;
									var $DateEffective = $Effective.replace(/\//g, '-')
									document.getElementById("txtCertificateEffectiveDate").setAttribute("value", $DateEffective);
								}
								if(data.EffectiveDate){
									var $ExpiryDate = data.ExpiryDate;
									var $ExpiryDate = $ExpiryDate.substring(0, 10);
									var $Expiry=$ExpiryDate;
									var $DateExpiry = $Expiry.replace(/\//g, '-')
									document.getElementById("txtCerticateExpiryDate").setAttribute("value", $DateExpiry);
								}
								if(data.ProductName){
									document.getElementById("ddlCertificateProductCode").setAttribute("value", data.ProductName);
								}
								if(data.PolicyTypeName){
									document.getElementById("ddlCertificatePolicyTypeCode").setAttribute("value", data.PolicyTypeName);
								}
								if(data.ParticipantName){
									document.getElementById("txtParticipantName").setAttribute("value", data.ParticipantName);
								}
								if(data.ParticipantAddress){
									document.getElementById("txtParticipantAddress").setAttribute("value", data.ParticipantAddress);
								}
								if(data.EmailAddress){
									document.getElementById("txtEmail").setAttribute("value", data.EmailAddress);
								}
								if(data.CityCode){
									$('#ddlCityCode').val(data.CityCode).trigger('change')
								}
								if(data.AreaName){
									document.getElementById("ddlAreaCode").setAttribute("value", data.AreaName);
								}
								if(data.CNICNumber){
									document.getElementById("txtCnicNum").setAttribute("value", data.CNICNumber);
								}
								if(data.MobileNumber){
									document.getElementById("txtPersonalNum").setAttribute("value", data.MobileNumber);
								}
								if(data.OfficeNumber){
									document.getElementById("txtOfficeNum").setAttribute("value", data.OfficeNumber);
								}
								if(data.OfficeNumber){
									document.getElementById("txtResidenceNum").setAttribute("value", data.OfficeNumber);
								}
								if(data.BirthDate){
									var $BirthDate = data.BirthDate;
									var $BirthDate = $BirthDate.substring(0, 10);
									var $DateBirth=$BirthDate;
									document.getElementById("txtBirthDate").setAttribute("value",$DateBirth);
								}
								if(data.Gender){
									$('#ddlGender').val(data.Gender).trigger('change')
								}
								if(data.PODate){
									var $PODate = data.PODate;
									var $PODate = $PODate.substring(0, 10);
									var $DatePO=$PODate;
									document.getElementById("txtPoDate").setAttribute("value",$DatePO);
								}
								if(data.PONumber){
									document.getElementById("txtPoNumber").setAttribute("value", data.PONumber);
								}
								if(data.VehicleCode){
									$('#ddlVehicleName').val(data.VehicleCode).trigger('change');
								}
								if(data.VehicleModel){
									document.getElementById("txtVehicleModel").setAttribute("value", data.VehicleModel);
								}
								if(data.VehicleType){
									$('#ddlVehicleType').val(data.VehicleType).trigger('change');
								}
								if(data.InsuranceTypeCode){
									$('#ddlTakafulType').val(data.InsuranceTypeCode).trigger('change');
								}
								if(data.ColorCode){
									$('#ddlColorName').val(data.ColorCode).trigger('change');
								}
								if(data.RegistrationNumber){
									document.getElementById("txtRegistrationNumber").setAttribute("value", data.RegistrationNumber);
								}
								if(data.EngineNumber){
									document.getElementById("txtEngineNumber").setAttribute("value", data.EngineNumber);
								}
								if(data.ChasisNumber){
									document.getElementById("txtChasisNumber").setAttribute("value", data.ChasisNumber);
								}
								if(data.Mileage){
									document.getElementById("txtMileage").setAttribute("value", data.Mileage);
								}
								if(data.VEODCode){
									$('#ddlVEODCode').val(data.VEODCode).trigger('change');
								}
								if(data.Remarks){
									document.getElementById("txtRemarks").setAttribute("value", data.Remarks);
								}
								if(data.Tenure){
									document.getElementById("txtTenure").setAttribute("value", data.Tenure);
								}
								if(data.CertTypeCode){
									$('#ddlOpCerTypeCode').val(data.CertTypeCode).trigger('change');
								}
								if(data.RatingFactor){
									$('#ddlRatingFactor').val(data.RatingFactor).trigger('change');
								}
								if(data.ParticipantValue){
									document.getElementById("txtVehicleValue").setAttribute("value", data.ParticipantValue);
								}
								if(data.Rate){
									document.getElementById("txtRate").setAttribute("value", data.Rate);
								}
								if(data.Contribution){
									document.getElementById("txtContribution").setAttribute("value", data.Contribution);
								}
								if(data.ContractMatDate){
									var $ContractMatDate = data.ContractMatDate;
									var $ContractMatDate = $ContractMatDate.substring(0, 10);
									var $Contract=$ContractMatDate;
									var $DateContract = $Contract.replace(/\//g, '-')
									document.getElementById("txtContractMaturityDate").setAttribute("value", $DateContract);
								}
								if(data.Deductible){
									document.getElementById("txtDeductible").setAttribute("value", data.Deductible);
								}
							});
						}else{
							var $BtnEndorsementCalcNew = {
								TxnSysID: $EndorsementCertificateTxnSysID,
								Remarks: $txtRemarks,
								EndtReasonCode: $ddlEndorsementReasonValue,
								ParticipantValue: $txtEndorsementValue,
							};
							var $BtnEndorsementCalcNew = JSON.stringify($BtnEndorsementCalcNew);
							$.get("http://207.180.200.121/mtrprodsetup/MtrVContribution/GetMtrVDForEndt/?_Json=" + $BtnEndorsementCalcNew, function (data) {
								if(data.ClientCode){
									$('#ddlCertificateClientCode').val(data.ClientCode).trigger('change');
								}
								if(data.GenerateAgainst){
									document.getElementById("ddlCertificateOpenPolicy").setAttribute("value", data.GenerateAgainst);
								}
								if(data.PolicyString){
									document.getElementById("txtPolicyString").setAttribute("value", data.PolicyString);
								}
								if(data.AgentName){
									document.getElementById("ddlAgencyCode").setAttribute("value", data.AgentName);
								}
								if(data.CommisionRate){
									document.getElementById("txtCommissionRate").setAttribute("value", data.CommisionRate);
								}
								if(data.EffectiveDate){
									var $EffectiveDate = data.EffectiveDate;
									var $EffectiveDate = $EffectiveDate.substring(0, 10);
									var $Effective=$EffectiveDate;
									var $DateEffective = $Effective.replace(/\//g, '-')
									document.getElementById("txtCertificateEffectiveDate").setAttribute("value", $DateEffective);
								}
								if(data.EffectiveDate){
									var $ExpiryDate = data.ExpiryDate;
									var $ExpiryDate = $ExpiryDate.substring(0, 10);
									var $Expiry=$ExpiryDate;
									var $DateExpiry = $Expiry.replace(/\//g, '-')
									document.getElementById("txtCerticateExpiryDate").setAttribute("value", $DateExpiry);
								}
								if(data.ProductName){
									document.getElementById("ddlCertificateProductCode").setAttribute("value", data.ProductName);
								}
								if(data.PolicyTypeName){
									document.getElementById("ddlCertificatePolicyTypeCode").setAttribute("value", data.PolicyTypeName);
								}
								if(data.ParticipantName){
									document.getElementById("txtParticipantName").setAttribute("value", data.ParticipantName);
								}
								if(data.ParticipantAddress){
									document.getElementById("txtParticipantAddress").setAttribute("value", data.ParticipantAddress);
								}
								if(data.EmailAddress){
									document.getElementById("txtEmail").setAttribute("value", data.EmailAddress);
								}
								if(data.CityCode){
									$('#ddlCityCode').val(data.CityCode).trigger('change')
								}
								if(data.AreaName){
									document.getElementById("ddlAreaCode").setAttribute("value", data.AreaName);
								}
								if(data.CNICNumber){
									document.getElementById("txtCnicNum").setAttribute("value", data.CNICNumber);
								}
								if(data.MobileNumber){
									document.getElementById("txtPersonalNum").setAttribute("value", data.MobileNumber);
								}
								if(data.OfficeNumber){
									document.getElementById("txtOfficeNum").setAttribute("value", data.OfficeNumber);
								}
								if(data.OfficeNumber){
									document.getElementById("txtResidenceNum").setAttribute("value", data.OfficeNumber);
								}
								if(data.BirthDate){
									var $BirthDate = data.BirthDate;
									var $BirthDate = $BirthDate.substring(0, 10);
									var $DateBirth=$BirthDate;
									document.getElementById("txtBirthDate").setAttribute("value",$DateBirth);
								}
								if(data.Gender){
									$('#ddlGender').val(data.Gender).trigger('change')
								}
								if(data.PODate){
									var $PODate = data.PODate;
									var $PODate = $PODate.substring(0, 10);
									var $DatePO=$PODate;
									document.getElementById("txtPoDate").setAttribute("value",$DatePO);
								}
								if(data.PONumber){
									document.getElementById("txtPoNumber").setAttribute("value", data.PONumber);
								}
								if(data.VehicleCode){
									$('#ddlVehicleName').val(data.VehicleCode).trigger('change');
								}
								if(data.VehicleModel){
									document.getElementById("txtVehicleModel").setAttribute("value", data.VehicleModel);
								}
								if(data.VehicleType){
									$('#ddlVehicleType').val(data.VehicleType).trigger('change');
								}
								if(data.InsuranceTypeCode){
									$('#ddlTakafulType').val(data.InsuranceTypeCode).trigger('change');
								}
								if(data.ColorCode){
									$('#ddlColorName').val(data.ColorCode).trigger('change');
								}
								if(data.RegistrationNumber){
									document.getElementById("txtRegistrationNumber").setAttribute("value", data.RegistrationNumber);
								}
								if(data.EngineNumber){
									document.getElementById("txtEngineNumber").setAttribute("value", data.EngineNumber);
								}
								if(data.ChasisNumber){
									document.getElementById("txtChasisNumber").setAttribute("value", data.ChasisNumber);
								}
								if(data.Mileage){
									document.getElementById("txtMileage").setAttribute("value", data.Mileage);
								}
								if(data.VEODCode){
									$('#ddlVEODCode').val(data.VEODCode).trigger('change');
								}
								if(data.Remarks){
									document.getElementById("txtRemarks").setAttribute("value", data.Remarks);
								}
								if(data.Tenure){
									document.getElementById("txtTenure").setAttribute("value", data.Tenure);
								}
								if(data.CertTypeCode){
									$('#ddlOpCerTypeCode').val(data.CertTypeCode).trigger('change');
								}
								if(data.RatingFactor){
									$('#ddlRatingFactor').val(data.RatingFactor).trigger('change');
								}
								if(data.ParticipantValue){
									document.getElementById("txtVehicleValue").setAttribute("value", data.ParticipantValue);
								}
								if(data.Rate){
									document.getElementById("txtRate").setAttribute("value", data.Rate);
								}
								if(data.Contribution){
									document.getElementById("txtContribution").setAttribute("value", data.Contribution);
								}
								if(data.ContractMatDate){
									var $ContractMatDate = data.ContractMatDate;
									var $ContractMatDate = $ContractMatDate.substring(0, 10);
									var $Contract=$ContractMatDate;
									var $DateContract = $Contract.replace(/\//g, '-')
									document.getElementById("txtContractMaturityDate").setAttribute("value", $DateContract);
								}
								if(data.Deductible){
									document.getElementById("txtDeductible").setAttribute("value", data.Deductible);
								}
							});
						}
					}
				});
			});
		}
	});

});
