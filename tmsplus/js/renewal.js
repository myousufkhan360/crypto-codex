
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

$(document).ready(function() {
    $("#depericatesec").hide();
    $("#OnlyForRenew").hide();
    $("#BtnRenewalAll").on("click", function() {
        $('#TblRenewal td:first-child').each(function() {
           var $TxnSysId=$(this).text();
            $.get('http://207.180.200.121/mtrprodsetup/MtrInsPolicy/AddInsPolicyForRenw/?_Json={"ParentTxnSysID":'+ $TxnSysId+ '}', function(data) {
                $('#RenewModal').modal('show');
                setTimeout(function() {
                    $('#RenewModal').modal('hide')
                }, 2000);
            });
        }); 
    });
    // On Click BtnRenewable 
	$("#BtnRenewable").on("click", function() {
        $("#OnlyForRenew").show();
        $('#TblRenewal').DataTable().clear().destroy();
        var $txtStartDate = $('#txtStartDate').val();
        var $txtEndDate = $('#txtEndDate').val();
        $Zero=0;
        $TblRenewal = $("#TblRenewal").DataTable({
            "order": [
                [0, "desc"]
            ],
            "paging": true,
            "pageLength": 5,
            "searching": true,
            "columnDefs": [ {
                "targets": -1,
                "data": null,
                "defaultContent": "<i class='fa fa-usd' aria-hidden='true' id='depreciate'></i>"
            } ]
        });
        $.ajax({
            url: 'http://207.180.200.121/mtrprodsetup/MtrInsPolicy/GetInsByDate?_Json={"EffectiveDate":"' + $txtStartDate + '","ExpiryDate":"'+$txtEndDate+ '","RenewalType":"'+$Zero+'"}',
            type: 'get',
            dataType: "JSON",
            success: function(response) {
                var len = response.length;
                for (var i = 0; i < len; i++) {
                    var $ParentTxnSysID = response[i].ParentTxnSysID;
                    var $CertString = response[i].CertString;
                    var $ParticipantName = response[i].ParticipantName;
                    var $ParticipantValue = response[i].ParticipantValue;
                    var $InsuranceTypeName = response[i].InsuranceTypeName;
                    var $TxnSysDate = response[i].TxnSysDate;
                    var $EffectiveDate = response[i].EffectiveDate;
                    var $ExpiryDate = response[i].ExpiryDate;
                    $TblRenewal.row.add([$ParentTxnSysID,$CertString, $ParticipantName,$ParticipantValue,$InsuranceTypeName, $TxnSysDate,$EffectiveDate,$ExpiryDate]).draw(false);
                }
            }
        });
	});
    // On Click BtnAlreadyRenewal 
    $("#BtnAlreadyRenewal").on("click", function() {
        $("#OnlyForRenew").hide();
        $('#TblRenewal').DataTable().clear().destroy();
        var $txtStartDate = $('#txtStartDate').val();
        var $txtEndDate = $('#txtEndDate').val();
        $One=1;

        $TblRenewal = $("#TblRenewal").DataTable({
            "order": [
                [0, "desc"]
            ],
            "paging": true,
            "pageLength": 5,
            "searching": true,
            "columnDefs": [ {
                "targets": -1,
                "data": null,
                "defaultContent": "<i class='fa fa-usd' aria-hidden='true' id='depreciate'></i>"
            } ]
        });
       
        $.ajax({
            url: 'http://207.180.200.121/mtrprodsetup/MtrInsPolicy/GetInsByDate?_Json={"EffectiveDate":"' + $txtStartDate + '","ExpiryDate":"'+$txtEndDate+ '","RenewalType":"'+$One+'"}',
            type: 'get',
            dataType: "JSON",
            success: function(response) {
                var len = response.length;
                for (var i = 0; i < len; i++) {
                    var $ParentTxnSysID = response[i].ParentTxnSysID;
                    var $CertString = response[i].CertString;
                    var $ParticipantName = response[i].ParticipantName;
                    var $ParticipantValue = response[i].ParticipantValue;
                    var $InsuranceTypeName = response[i].InsuranceTypeName;
                    var $TxnSysDate = response[i].TxnSysDate;
                    var $EffectiveDate = response[i].EffectiveDate;
                    var $ExpiryDate = response[i].ExpiryDate;
                    $TblRenewal.row.add([$ParentTxnSysID,   $CertString, $ParticipantName,$ParticipantValue,$InsuranceTypeName, $TxnSysDate,$EffectiveDate,$ExpiryDate]).draw(false);
                }
            }
        });
    });
    $('#TblRenewal tbody').on('click', 'tr', function() {
        $("#depericatesec").show();
        $('#ContributionTbl').DataTable().clear().destroy();
        var $RenewaselValue = $TblRenewal.row(this).data();
        $rowIdx = $TblRenewal.row(this).index;
        $("#TblRenewal").val($rowIdx);
        $row = $TblRenewal.row(this).node();
        $('#TxnSysId').val($RenewaselValue[0]);
        $('#txtdepreciatevalue').val($RenewaselValue[3]);
    });
    $('#txtdepreciaterate').change(function() {
        var $txtdepreciatevalue = $('#txtdepreciatevalue').val();
        var $txtdepreciaterate = $('#txtdepreciaterate').val(); 
        var $CalculatedAmount=$txtdepreciatevalue - (($txtdepreciatevalue * $txtdepreciaterate) / 100);
        var $txtdepreciateamount = $('#txtdepreciateamount').val(Math.round($CalculatedAmount));
    });
    $('#txtdepreciateamount').change(function() {
        var $txtdepreciateamount = $('#txtdepreciateamount').val(); 
        var $txtdepreciatevalue = $('#txtdepreciatevalue').val();
        var $CalculatedRate=(($txtdepreciatevalue - $txtdepreciateamount) / $txtdepreciatevalue) * 100;
        var $txtdepreciaterate = $('#txtdepreciaterate').val(Math.round($CalculatedRate));
    });
    $("#BtndepreciateSave").on("click", function() {
        var $txtdepreciaterate = $('#txtdepreciaterate').val();
        var $TxnSysId=$('#TxnSysId').val();
        $('#ContributionTbl').DataTable().clear().destroy();
        $ContributionTbl = $("#ContributionTbl").DataTable({
            "order": [
                [0, "desc"]
            ],
            "paging": false,
            "pageLength": 5,
            "searching": false,
        });
        $.ajax({
            url: 'http://207.180.200.121/mtrprodsetup/MtrInsPolicy/AddInsPolicyForDedut/?_Json={"ParentTxnSysID":' + $TxnSysId + ',"Deduct":'+$txtdepreciaterate+ '}',
            type: 'get',
            dataType: "JSON",
            success: function(response) {
                var len = response.length;
                for (var i = 0; i < len; i++) {
                    var $GrossContribution = response[i].GrossContribution;
                    var $FIF = response[i].FIF;
                    var $FED = response[i].FED;
                    var $NetContribution = response[i].NetContribution;
                    $ContributionTbl.row.add([$GrossContribution, $FIF,$FED,$NetContribution]).draw(false);
                }
            }
        });
    });
    $("#BtndepreciateNew").on("click", function() {
        var $txtdepreciaterate = $('#txtdepreciaterate').val('');
        var $txtdepreciateamount = $('#txtdepreciateamount').val(''); 
    });
    $("#BtndepreciatePolicy").on("click", function() {
       var $TxnSysId = $('#TxnSysId').val();  
           $.get('http://207.180.200.121/mtrprodsetup/MtrInsPolicy/AddInsPolicyForConv/?_Json={"ParentTxnSysID":'+ $TxnSysId+ '}', function(data) {
            $('#ConvertModal').modal('show');
            setTimeout(function() {
                $('#ConvertModal').modal('hide')
            }, 2000);
        });
    });
    $("#BtndepreciateRenewOne").on("click", function() {
       var $TxnSysId = $('#TxnSysId').val();  
           $.get('http://207.180.200.121/mtrprodsetup/MtrInsPolicy/AddInsPolicyForRenw/?_Json={"ParentTxnSysID":'+ $TxnSysId+ '}', function(data) {
            $('#RenewModal').modal('show');
            setTimeout(function() {
                $('#RenewModal').modal('hide')
            }, 2000);
        });
    });
});
	