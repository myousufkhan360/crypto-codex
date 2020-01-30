var $TblDetailDescription;
var $TxnSysId;
var $txtTxnSysID;
var $clickSysId;
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

//Datatable for getting particular user's History with pagging and searching option.
$(document).ready(function () {
	var $MotorOpenPolicy = $("#tblMotorOpenPolicy").DataTable({
		"order": [
			[0, "desc"]
		],
		"paging": true,
		"searching": true,
	});

	//Getting data from focused row of datatable in to datafields of form
	$('#tblMotorOpenPolicy tbody').on('click', 'tr', function () {
		$('#myModal').modal('hide');
		var $selValue = $MotorOpenPolicy.row(this).data();
		$rowIdx = $MotorOpenPolicy.row(this).index;
		$("#RowIndex").val($rowIdx);
		$row = $MotorOpenPolicy.row(this).node();
		$($row).addClass('ready');
		$("#txtUserCode").val($selValue[0]);
		$PolicyType = $selValue[1];
		$('#ddlPolicyTypeCode').val($PolicyType).trigger('change');
		$CertificateTypeCode = $selValue[2];
		$('#ddlCertificateTypeCode').val($CertificateTypeCode).trigger('change');
		$ClientCode = $selValue[3];
		$('#ddlClientCode').val($ClientCode).trigger('change');
		$AgencyCode = $selValue[4];
		$('#ddlAgencyCode').val($AgencyCode).trigger('change');
		$PolicyPeriodFrom = $selValue[5];
		$('#txtPolicyPeriodFrom').val($PolicyPeriodFrom);
		$PolicyPeriodTo = $selValue[6];
		$('#txtPolicyPeriodTo').val($PolicyPeriodTo);
		$ConditionCode = $selValue[7];
		$('#ddlConditionCode').val($ConditionCode).trigger('change');
		$WarrantyCode = $selValue[8];
		$('#ddlWarrantyCode').val($WarrantyCode).trigger('change');
		$('#myModal').on('hidden.bs.modal', function () {
			$("#ddlPolicyTypeCode").focus();
		});
	});
});

//Datatable for getting Code and Code Description from Master table with pagging and searching option.
$(document).ready(function () {

	//-1 is set by default for RowsIndex for the Update of databse 
	$("#RowsIndex").val("-1");
	var $TblMasterDescription = $("#TblMasterDescription").DataTable({
		"order": [
			[0, "desc"]
		],
		"paging": true,
		"pageLength": 3,
		"searching": true,
	});


	//Setting rows of Data Table using Mastercodes API
	$.ajax({
		url: "http://207.180.200.121/tmsddlapi/mastercodes/getmastercodes",
		type: 'get',
		dataType: "JSON",
		success: function (response) {
			var len = response.length;
			for (var i = 0; i < len; i++) {
				var $CodeDescription = response[i].CodeDescription;
				var $MasterCodeId = response[i].MasterCodeId;
				$TblMasterDescription.row.add([$MasterCodeId, $CodeDescription]).draw(false);
			}
		}
	});

	//On click Listener for New button to vanish all existing fields inside form
	$("#BtnMasterNew").on("click", function () {
		$('#txtMasterCodeId').val('');
		$("#txtCodeDescription").val('');
		$("#txtUserId").val('');
		$("#txtCodeDescription").focus();
	});

	//On click Listener for New button to Insert or Update the Database
	$("#BtnMasterSave").on("click", function () {
		var $txtMasterCodeId = $("#txtMasterCodeId").val();
		var $txtCodeDescription = $("#txtCodeDescription").val();
		var $SaveDeletIcon = '<i class="fa fa-window-close" aria-hidden="true" ></i><i class="fa fa-pencil-square-o" aria-hidden="true" id="btnUpdate"></i>';

		//if rowIndex == -1 then add new row
		if ($("#MasterRowsIndex").val() == "-1") {
			$("#txtUserId").val($txtMasterCodeId);
			var $BtnMasterNew = {
				CodeDescription: $txtCodeDescription,
				UserId: $useridparameters,
			};
			var $BtnMasterNew = JSON.stringify($BtnMasterNew);
			$.get("http://207.180.200.121/tmsddlapi/mastercodes/addmastercodes/?_json=" + $BtnMasterNew, function (data) {

				var rowNode = $TblMasterDescription.row.add([data.MasterCodeId, data.CodeDescription]).draw();
			});
		}
		//if rowIndex not -1 then add update row
		else {
			$txtUserId = $("#txtUserId").val($txtMasterCodeId);
			var $rowsIdx = $("#MasterRowsIndex").val();
			var arr = $TblMasterDescription.row($rowsIdx).data();
			var $BtnMasterUpdate = {
				MasterCodeId: $txtMasterCodeId,
				UserId: $useridparameters,
				CodeDescription: $txtCodeDescription,
			};
			var $BtnMasterUpdate = JSON.stringify($BtnMasterUpdate);
			$.get("http://207.180.200.121/tmsddlapi/mastercodes/updatemastercodes/?_json=" + $BtnMasterUpdate, function (data) {});

			//For showing updated or inserted data in table
			arr[0] = $txtMasterCodeId;
			arr[1] = $txtCodeDescription;
			$TblMasterDescription.row($rowsIdx).data(arr);
			$TblMasterDescription.row($rowsIdx).invalidate();
			$TblMasterDescription.draw(false);
			//Again RowsIndex is set -1 to update the databse if form is filled with new data
			$("#MasterRowsIndex").val("-1");
		}
		// On Click Remove Table Row
		$('#TblMasterDescription').on("click", "i.fa-window-close", function () {
			$TblMasterDescription.row($(this).parents('tr')).remove().draw(false);
		});
	});
	//For adding Focused data in Input Fields
	$('#TblMasterDescription tbody').on('click', 'tr', function () {
		$("#DetailSec").show();
		var $selValue = $TblMasterDescription.row(this).data();
		$rowIdx = $TblMasterDescription.row(this).index;
		$("#MasterRowsIndex").val($rowIdx);
		$row = $TblMasterDescription.row(this).node();
		$($row).addClass('ready');
		$("#txtMasterCodeId").val($selValue[0]);
		$("#txtCodeDescription").val($selValue[1]);

		$('#TblDetailDescription').DataTable().clear().destroy();
		$TblDetailDescription = $("#TblDetailDescription").DataTable({
			"order": [
				[0, "desc"]
			],
			"paging": true,
			//Only Three records shown of detail code
			"pageLength": 3,
			"searching": true,
		});
		//Getting master code id from first form
		var $MasterCodeId = $("input[name='txtMasterCodeId']").val();
		$.ajax({
			url: "http://207.180.200.121/tmsddlapi/detailcodes/getdetailcodes/?_mastercodeid=" + $MasterCodeId,
			type: 'get',
			dataType: "JSON",
			success: function (response) {
				var len = response.length;
				for (var i = 0; i < len; i++) {
					var $CodeDescription = response[i].CodeDescription;
					var $DetailCodeId = response[i].DetailCodeId;
					var $DetailReference = response[i].Reference;
					var $TxnSysId = response[i].TxnSysId;
					$TblDetailDescription.row.add([$DetailCodeId, $CodeDescription, $DetailReference, $TxnSysId]).draw(false);
				}
			}
		});
	});

});
//Setting RowIndex to -1
$("#DetailRowIndex").val("-1");
$(document).ready(function () {

	//On Click Listener To add new Records in Details table
	$("#BtnDetailNew").on("click", function () {
		$('#txtDetailCodeDescription').focus();
		$('#txtDetailCodeDescription').val('');
		$("#txtRefrence").val('');
		$("#txtDetailCodeId").val('');
	});

	//On Click Listener To Save or Update Records in Details table
	$("#BtnDetailSave").on("click", function () {
		var $txtMasterCodeId = $("#txtMasterCodeId").val();
		var $txtDetailCodeId = $("#txtDetailCodeId").val();
		$("#txtUserId").val($txtMasterCodeId);
		var $txtDetailCodeDescription = $("#txtDetailCodeDescription").val();
		var $txtRefrence = $("#txtRefrence").val();
		$TxnSysId = $("#txtTxnSysId").val();
		var $SaveDeletIcon = '<i class="fa fa-window-close" aria-hidden="true" ></i><i class="fa fa-pencil-square-o" aria-hidden="true" id="btnUpdate"></i>';

		//if rowIndex -1 then insert row
		if ($("#DetailRowIndex").val() == "-1") {
			var $BtnDetailNew = {
				UserId: $useridparameters,
				CodeDescription: $txtDetailCodeDescription,
				MasterCodeId: $txtMasterCodeId,
				Reference: $txtRefrence,
			};
			var $BtnDetailNew = JSON.stringify($BtnDetailNew);
			$.get("http://207.180.200.121/tmsddlapi/detailcodes/adddetailcodes/?_json=" + $BtnDetailNew, function (data) {
				var rowNode = $TblDetailDescription.row.add([data.DetailCodeId, data.CodeDescription, data.Reference, data.TxnSysId]).draw();
			});
		}
		//if rowIndex not -1 then add update row
		else {
			var $rowsIdx = $("#DetailRowIndex").val();
			var arr = $TblDetailDescription.row($rowsIdx).data();
			var $BtnDetailUpdate = {
				UserId: $useridparameters,
				TxnSysId: $TxnSysId,
				CodeDescription: $txtDetailCodeDescription,
				MasterCodeId: $txtMasterCodeId,
				Reference: $txtRefrence,
			};
			var $BtnDetailUpdate = JSON.stringify($BtnDetailUpdate);
			$.get("http://207.180.200.121/tmsddlapi/detailcodes/updatedetailcodes/?_json=" + $BtnDetailUpdate, function (data) {

			});
			arr[0] = $txtDetailCodeId;
			arr[1] = $txtDetailCodeDescription;
			arr[2] = $txtRefrence;
			$TblDetailDescription.row($rowsIdx).data(arr);
			$TblDetailDescription.row($rowsIdx).invalidate();
			$TblDetailDescription.draw(false);
		}
	});
	$('#TblDetailDescription tbody').on('click', 'tr', function () {
		var $selValue = $TblDetailDescription.row(this).data();
		$rowIdx = $TblDetailDescription.row(this).index;
		$("#DetailRowIndex").val($rowIdx);
		$row = $TblDetailDescription.row(this).node();
		$($row).addClass('ready');
		$("#txtDetailCodeId").val($selValue[0]);
		$("#txtDetailCodeDescription").val($selValue[1]);
		$("#txtRefrence").val($selValue[2]);
		$("#txtTxnSysId").val($selValue[3]);
	});
});
