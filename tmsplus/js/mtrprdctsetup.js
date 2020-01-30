var $clickSysId;
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
/*Motor Product Setup JS*/
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
    success: function(data) {
        $.each(data, function(key, entry) {
            DdlWarranty.append($('<option></option>').attr('value', entry.WarrantyCode).text(entry.WarrantyShText));
        })
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});
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
    success: function(data) {
        $.each(data, function(key, entry) {
            DdlRatingFactor.append($('<option></option>').attr('value', entry.RatingFactorCode).text(entry.RatingFactorName));
        })
    },
    error: function(xhr, status, error) {
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
    success: function(data) {
        $.each(data, function(key, entry) {
            DdlCondition.append($('<option></option>').attr('value', entry.ConditionCode).text(entry.ConditionShText));
        })
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});
// Is Editable  Dropdown Api
let DdlRatingEditable = $('#ddlRatingEditable');
DdlRatingEditable.empty();
DdlRatingEditable.append('<option selected="" value="">Choose Client Rating Editable</option>');
DdlRatingEditable.prop('selectedIndex', 0);
const DdlRatingEditableBasedUrl = "http://207.180.200.121/mtrprodsetup/YesNo/GetYesNo";
var Mydata;
$.ajax({
    url: DdlRatingEditableBasedUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function(data) {
        $.each(data, function(key, entry) {
            DdlRatingEditable.append($('<option></option>').attr('value', entry.YesNoText).text(entry.YesNoText));
        })
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});

// Is Client Based Dropdown Api
let DdlIsClientBased = $('#ddlIsClientBased');
DdlIsClientBased.empty();
DdlIsClientBased.append('<option selected="" value="">Choose Client Based</option>');
DdlIsClientBased.prop('selectedIndex', 0);
const DdlIsClientBasedUrl = "http://207.180.200.121/mtrprodsetup/YesNo/GetYesNo";
var Mydata;
$.ajax({
    url: DdlIsClientBasedUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function(data) {
        $.each(data, function(key, entry) {
            DdlIsClientBased.append($('<option></option>').attr('value', entry.YesNoText).text(entry.YesNoText));
        })
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});


// Client Dropdown Api
let DdlClient = $('#ddlClient');
DdlClient.empty();
DdlClient.append('<option selected="" value="">Choose Client</option>');
DdlClient.prop('selectedIndex', 0);
const DdlClientUrl = "http://207.180.200.121/mtrprodsetup/ProductClient/GetProductClient";
var Mydata;
$.ajax({
    url: DdlClientUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function(data) {
        $.each(data, function(key, entry) {
            DdlClient.append($('<option></option>').attr('value', entry.ClientCode).text(entry.ClientName));
        })
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});

// Agent Dropdown Api
let DdlAgent = $('#ddlAgent');
DdlAgent.empty();
DdlAgent.append('<option selected="" value="">Choose Agent</option>');
DdlAgent.prop('selectedIndex', 0);
const DdlAgentUrl = "http://207.180.200.121/mtrprodsetup/ProductAgent/GetProductAgent";
var Mydata;
$.ajax({
    url: DdlAgentUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function(data) {
        $.each(data, function(key, entry) {
            DdlAgent.append($('<option></option>').attr('value', entry.AgentCode).text(entry.AgentName));
        })
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});

// Policy Type Dropdown Api
let ddlPolicyType = $('#ddlPolicyType');
ddlPolicyType.empty();
ddlPolicyType.append('<option selected="" value="">Choose Policy Type</option>');
ddlPolicyType.prop('selectedIndex', 0);
ddlPolicyTypeUrl = "http://207.180.200.121/mtrprodsetup/ProductPolicyType/GetProductPolicyType";
var Mydata;
$.ajax({
    url: ddlPolicyTypeUrl,
    type: "GET",
    crossDomain: true,
    dataType: "JSON",
    success: function(data) {
        $.each(data, function(key, entry) {
            ddlPolicyType.append($('<option></option>').attr('value', entry.PolicyTypeCode).text(entry.PolicyTypeName));
        })
    },
    error: function(xhr, status, error) {
        alert(status);
    }
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
    success: function(data) {
        $.each(data, function(key, entry) {
            ddlTrackerCompany.append($('<option></option>').attr('value', entry.ACCESSORY_CODE).text(entry.ACCESSORY_SHORT_NAME));
        })
    },
    error: function(xhr, status, error) {
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
    success: function(data) {
        $.each(data, function(key, entry) {
            ddlRider.append($('<option></option>').attr('value', entry.RECORD_ID).text(entry.RIDER_NAME));
        })
    },
    error: function(xhr, status, error) {
        alert(status);
    }
});
//Product Setup Table 

$(document).ready(function() {
    // By Default  ProductRowIndex is -1
    $("#ProductRowIndex").val("-1");
    var $TblProductSetup = $("#TblProductSetup").DataTable({
        "order": [
            [0, "desc"]
        ],
        "paging": true,
        "pageLength": 5,
        "searching": true,
    });
    // Calling Master Products Setup Values in table by Ajax
    $.ajax({
        url: "http://207.180.200.121/mtrprodsetup/MasterProductSetUp/GetMasterProductSetUp",
        type: 'get',
        dataType: "JSON",
        success: function(response) {
            var len = response.length;
            for (var i = 0; i < len; i++) {
                var $ProductCode = response[i].ProductCode;
                var $ProductName = response[i].ProductName;
                var $ClientName = response[i].ClientName;
                var $Client = response[i].Client;
                var $AgentName = response[i].AgentName;
                var $Agent = response[i].Agent;
                var $TxnSysID = response[i].TxnSysID;
                var $AgentCommPct = response[i].AgentCommPct;
                var $IsClientBased = response[i].IsClientBased;
                var $PolicyTypeCode = response[i].PolicyTypeCode;
                var $PolicyTypeName = response[i].PolicyTypeName;
                $TblProductSetup.row.add([$ProductCode, $ProductName, $ClientName, $Client, $AgentName, $Agent, $TxnSysID, $AgentCommPct, $IsClientBased, $PolicyTypeCode, $PolicyTypeName]).draw(false);
            }
        }
    });
    $( "#ddlIsClientBased").change(function() {
        if($("#ddlIsClientBased").find('option:selected').val() == 'No'){
            $("#txtAgentCommission").val(0);
            $("#txtAgentCommission").prop('disabled', true);
            var $NA = 'N/A';
            $('#ddlClient').val($NA).trigger('change');
            $('#ddlAgent').val($NA).trigger('change');
            $('#show').attr('id', 'disable');
        }else{
            $('#disable').attr('id', 'show');
            $("#txtAgentCommission").prop('disabled', false);
        }
    });
    // On Click Listener for New Empty Input Value and Focus On User Code
    $("#BtnProductNew").on("click", function() {
        $("#ProductRowIndex").val("-1");
        $('#txtProductName').focus();
        $('#txtUserCode').val('');
        $('#txtTxnSysID').val('');
        $("#txtProductCode").val('');
        $("#txtProductName").val('');
        $("#txtAgentCommission").val('');
        $("#ddlIsClientBased").select2("val", 0);
        $("#ddlPolicyType").select2("val", 0);
        $("#ddlClient").select2("val", 0);
        $("#ddlAgent").select2("val", 0);
    });
    // On Click Listener of Save Button to Add or Update Database
    $("#BtnProductSave").on("click", function() {
        //Getting Value From Product Setup
        var $txtTxnSysID = $("#txtTxnSysID").val();
        var $txtUserCode = $("#txtUserCode").val($useridparameters);
        var $txtProductCode = $("#txtProductCode").val();
        var $txtProductName = $("#txtProductName").val();
        var $txtAgentCommission = $("#txtAgentCommission").val();
        var $AgentCommPct = $("#txtAgentCommission").val();
        var $ddlIsClientBased = $("#ddlIsClientBased").find('option:selected').text();
        var $ddlIsClientBasedValue = $("#ddlIsClientBased").find('option:selected').val();
        var $ddlClient = $("#ddlClient").find('option:selected').text();
        var $ddlClientValue = $("#ddlClient").find('option:selected').val();
        var $ddlAgent = $("#ddlAgent").find('option:selected').text();
        var $ddlAgentValue = $("#ddlAgent").find('option:selected').val();
        var $ddlPolicyType = $("#ddlPolicyType").find('option:selected').text();
        var $ddlPolicyTypeValue = $("#ddlPolicyType").find('option:selected').val();
        if($ddlIsClientBasedValue == 'No'){
            var $AgentCommPct = $("#txtAgentCommission").val(0);
            $ddlClientValue='N/A';
            $ddlAgentValue='N/A';
            $AgentCommPct=0;
        }else if($ddlIsClientBasedValue == 'Yes'){
            if($("#ddlClient").find('option:selected').val() == 'N/A'){
                document.getElementById("test").innerHTML = "Please Select Correct Client Based";
                $('#ErrorModalValidate').modal('show');
                setTimeout(function() {
                    $('#ErrorModalValidate').modal('hide')
                }, 2000);
                $('#ddlClient').focus().val($('#ddlClient').val());
                return false;
            }
            if($("#ddlAgent").find('option:selected').val() == 'N/A'){
                document.getElementById("test").innerHTML = "Please Select Correct Client Based";
                $('#ErrorModalValidate').modal('show');
                setTimeout(function() {
                    $('#ErrorModalValidate').modal('hide')
                }, 2000);
                $('#ddlAgent').focus().val($('#ddlAgent').val());
                return false;
            }if ($("#txtAgentCommission").val() == 0) {
                document.getElementById("test").innerHTML = "Please Fill Comission";
                $('#ErrorModalValidate').modal('show');
                setTimeout(function() {
                    $('#ErrorModalValidate').modal('hide')
                }, 2000);
                $('#txtAgentCommission').focus().val($('#txtAgentCommission').val());
                return false;
            } 
        }
        if (!$txtProductName) {
            document.getElementById("test").innerHTML = "Please Fill Product Name";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function() {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtProductName').focus().val($('#txtProductName').val());
            return false;
        }
        if (!$ddlIsClientBasedValue) {
            document.getElementById("test").innerHTML = "Please Select Client Based";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function() {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlIsClientBased').focus().val($('#ddlIsClientBased').val());
            return false;
        }
        if (!$ddlClientValue) {
            document.getElementById("test").innerHTML = "Please Select Client";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function() {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlClient').focus().val($('#ddlClient').val());
            return false;
        }
        if (!$ddlAgentValue) {
            document.getElementById("test").innerHTML = "Please Select Agent";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function() {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlAgent').focus().val($('#ddlAgent').val());
            return false;
        }
        if (!$ddlPolicyTypeValue) {
            document.getElementById("test").innerHTML = "Please Select Policy Type";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function() {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#ddlPolicyType').focus().val($('#ddlPolicyType').val());
            return false;
        }
        if (!$txtAgentCommission) {
            document.getElementById("test").innerHTML = "Please Fill Correct Comission";
            $('#ErrorModalValidate').modal('show');
            setTimeout(function() {
                $('#ErrorModalValidate').modal('hide')
            }, 2000);
            $('#txtAgentCommission').focus().val($('#txtAgentCommission').val());
            return false;
        } else {
            // If ProductRowIndex is -1 add new row on table
            if ($("#ProductRowIndex").val() == "-1") {
                var $BtnProductNew = {
                    ProductName: $txtProductName,
                    Client: $ddlClientValue,
                    Agent: $ddlAgentValue,
                    AgentCommPct: $AgentCommPct,
                    IsClientBased: $ddlIsClientBased,
                    PolicyTypeCode: $ddlPolicyTypeValue,
                };
                var $BtnProductNew = JSON.stringify($BtnProductNew);
                $.get("http://207.180.200.121/mtrprodsetup/MasterProductSetUp/AddMasterProductSetUp/?_json=" + $BtnProductNew, function(data) {
                    var $rowIdxx = $TblProductSetup.row(this).index;
                    $("#ProductRowIndex").val($rowIdxx);
                    $txtTxnSysID = data.TxnSysID;
                    $ValidTxn = data.IsValidTxn;
                    if ($ValidTxn == true) {
                        var rowNodes = $TblProductSetup.row.add([data.ProductCode, data.ProductName, data.ClientName, data.Client, data.AgentName, data.Agent, data.TxnSysID, data.AgentCommPct, data.IsClientBased, data.PolicyTypeCode, data.PolicyTypeName]).draw();
                        $('#SubmitModal').modal('show');
                        setTimeout(function() {
                            $('#SubmitModal').modal('hide')
                        }, 2000);
                        document.getElementById('MasterProduct').innerHTML = $txtTxnSysID + "-" + data.ProductName;
                        $("#header").show();
                        $("#accordion").show();
                        /*Rating Factor JS Start*/
                        $(".submit").css("display", "block");
                        $(".tables").css("display", "none");
                        $("#RatingProductRowIndex").val("-1");
                        $('#TblRatingProductSetup').DataTable().clear().destroy();
                        var $TblRatingProductSetup = $("#TblRatingProductSetup").DataTable({
                            "order": [
                                [0, "desc"]
                            ],
                            "paging": true,
                            "pageLength": 5,
                            "searching": true,
                        });
                        // Calling Rating Factor Values in table by Ajax
                        $.ajax({
                            url: 'http://207.180.200.121/mtrprodsetup/ProductRatingFactorSetUp/GetProductRatingFactorSetUp?_Json={"PrdStpTxnSysID":' + data.TxnSysID + "}",
                            type: 'get',
                            dataType: "JSON",
                            success: function(response) {
                                var len = response.length;
                                for (var i = 0; i < len; i++) {
                                    var $TxnSysID = response[i].TxnSysID
                                    var $PrdStpTxnSysId = response[i].PrdStpTxnSysId
                                    var $RatingFactorShText = response[i].RatingFactorShText;
                                    var $IsEditable = response[i].IsEditable;
                                    var $Rate = response[i].Rate;
                                    var $RatingFactor = response[i].RatingFactor;
                                    $TblRatingProductSetup.row.add([$TxnSysID, $PrdStpTxnSysId, $RatingFactorShText, $IsEditable, $Rate, $RatingFactor]).draw(false);
                                }
                            }
                        });

                        // On Click Listener for New Empty Input Value and Focus On User Code
                        $("#BtnRatingProductNew").on("click", function() {
                            $("#RatingProductRowIndex").val("-1");
                            $('#ddlRatingFactor').focus();
                            $('#txtRatingUserCode').val('');
                            $('#txtRatingTxnSysID').val('');
                            $("#ddlRatingFactor").select2("val", 0);
                            $("#txtRate").val('');
                            $("#ddlRatingEditable").select2("val", 0);
                        });
                        // On Click Listener of Save Button to Add or Update Database
                        $("#BtnRatingProductSave").on("click", function() {
                            var $txtRatingUserCode = $('#txtRatingUserCode').val($useridparameters);
                            var txtTxnSysID = $clickSysId;
                            document.getElementById("txtRatingPrdStpTxnSysId").setAttribute("value", txtTxnSysID);
                            var $txtRatingTxnSysID = $('#txtRatingTxnSysID').val();
                            var $txtRatingPrdStpTxnSysId = $('#txtRatingPrdStpTxnSysId').val();
                            var $ddlRatingFactor = $("#ddlRatingFactor").find('option:selected').text();
                            var $ddlRatingFactorValue = $("#ddlRatingFactor").find('option:selected').val();
                            var $ddlRatingEditable = $("#ddlRatingEditable").find('option:selected').text();
                            var $ddlRatingEditableValue = $("#ddlRatingEditable").find('option:selected').val();
                            var $txtRate = $("#txtRate").val();
                            //Custom Validation
                            if (!$ddlRatingFactorValue) {
                                document.getElementById("test").innerHTML = "Please Select Rating Factor";
                                $('#ErrorModalValidate').modal('show');
                                setTimeout(function() {
                                    $('#ErrorModalValidate').modal('hide')
                                }, 2000);
                                $('#ddlRatingFactor').focus().val($('#ddlRatingFactor').val());
                                return false;
                            }
                            if (!$txtRate) {
                                document.getElementById("test").innerHTML = "Please Fill Rate";
                                $('#ErrorModalValidate').modal('show');
                                setTimeout(function() {
                                    $('#ErrorModalValidate').modal('hide')
                                }, 2000);
                                $('#txtRate').focus().val($('#txtRate').val());
                                return false;
                            }
                            if (!$ddlRatingEditableValue) {
                                document.getElementById("test").innerHTML = "Please Select Is Editable";
                                $('#ErrorModalValidate').modal('show');
                                setTimeout(function() {
                                    $('#ErrorModalValidate').modal('hide')
                                }, 2000);
                                $('#ddlRatingEditable').focus().val($('#ddlRatingEditable').val());
                                return false;
                            } else {
                                // If RatingProductRowIndex is -1 add new row on table
                                if ($("#RatingProductRowIndex").val() == "-1") {
                                    var $BtnRatingProductsNew = {
                                        PrdStpTxnSysId: data.TxnSysID,
                                        RatingFactor: $ddlRatingFactorValue,
                                        IsEditable: $ddlRatingEditable,
                                        Rate: $txtRate,
                                    };
                                    var $BtnRatingProductsNew = JSON.stringify($BtnRatingProductsNew);
                                    $.get("http://207.180.200.121/mtrprodsetup/ProductRatingFactorSetUp/AddProductRatingFactorSetUp?_Json=" + $BtnRatingProductsNew, function(data) {
                                        $('#txtRatingTxnSysID').val(data.TxnSysID);
                                        $ValidTxn = data.IsValidTxn;
                                        if ($ValidTxn == true) {
                                            /*var test = $("#RatingProductRowIndex").val($TblRatingProductSetup.row(this).index);
                                            console.log(test);*/
                                            var rowNodes = $TblRatingProductSetup.row.add([data.TxnSysID, data.PrdStpTxnSysId, data.RatingFactorShText, data.IsEditable, data.Rate, data.RatingFactor]).draw();
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
                                }
                                // If RatingProductRowIndex is 1 update row on table
                                else {
                                    var $RatingProductRowIndex = $("#RatingProductRowIndex").val();
                                    var array = $TblRatingProductSetup.row($RatingProductRowIndex).data();
                                    var $BtnRatingProductUpdate = {
                                        TxnSysID: $txtRatingTxnSysID,
                                        PrdStpTxnSysId: data.TxnSysID,
                                        RatingFactor: $ddlRatingFactorValue,
                                        IsEditable: $ddlRatingEditable,
                                        Rate: $txtRate,
                                    };
                                    var $BtnRatingProductUpdate = JSON.stringify($BtnRatingProductUpdate);
                                    $.get("http://207.180.200.121/mtrprodsetup/ProductRatingFactorSetUp/UpdateProductRatingFactorSetUp?_Json=" + $BtnRatingProductUpdate, function(data) {
                                        $ValidTxn = data.IsValidTxn;
                                        if ($ValidTxn == true) {
                                            $('#UpdatedModal').modal('show');
                                            setTimeout(function() {
                                                $('#UpdatedModal').modal('hide')
                                            }, 2000);
                                            array[0] = $txtRatingTxnSysID;
                                            array[1] = $txtRatingTxnSysID;
                                            array[2] = $ddlRatingFactor;
                                            array[3] = $ddlRatingEditable;
                                            array[4] = $txtRate;
                                            array[5] = $ddlRatingFactorValue;
                                            $TblRatingProductSetup.row($RatingProductRowIndex).data(array);
                                            $TblRatingProductSetup.row($RatingProductRowIndex).invalidate();
                                            $TblRatingProductSetup.draw(false);
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

                        $('#TblRatingProductSetup tbody').on('click', 'tr', function() {
                            var $selValue = $TblRatingProductSetup.row(this).data();
                            $rowIdx = $TblRatingProductSetup.row(this).index;

                            $("#RatingProductRowIndex").val($rowIdx);
                            $row = $TblRatingProductSetup.row(this).node();
                            $($row).addClass('ready');
                            $("#txtRatingTxnSysID").val($selValue[0]);
                            $("#txtRatingPrdStpTxnSysId").val($selValue[1]);
                            $RatingFactor = $selValue[5];
                            $('#ddlRatingFactor').val($RatingFactor).trigger('change');
                            $("#txtRate").val($selValue[4]);
                            $ddlRatingEditable = $selValue[3];
                            $('#ddlRatingEditable').val($ddlRatingEditable).trigger('change');
                        });
                        /*Rating Factor JS End*/
                        /*Condition JS Start*/
                        $("#ConditionProductRowIndex").val("-1");
                        $('#TblConditionProductSetup').DataTable().clear().destroy();
                        var $TblConditionProductSetup = $("#TblConditionProductSetup").DataTable({
                            "order": [
                                [0, "desc"]
                            ],
                            "paging": true,
                            "pageLength": 5,
                            "searching": true,
                        });
                        // Calling Condition Values in table by Ajax
                        $.ajax({
                            url: 'http://207.180.200.121/mtrprodsetup/ProductConditionsSetUp/GetProductConditionsSetUp?_Json={"PrdStpTxnSysID":' + data.TxnSysID + "}",
                            type: 'get',
                            dataType: "JSON",
                            success: function(response) {
                                var len = response.length;
                                for (var i = 0; i < len; i++) {
                                    var $TxnSysID = response[i].TxnSysID
                                    var $ConditionShText = response[i].ConditionShText;
                                    var $TxnSysID = response[i].TxnSysID;
                                    var $Condition = response[i].Condition;
                                    var $PrdStpTxnSysId = response[i].PrdStpTxnSysId
                                    $TblConditionProductSetup.row.add([$ConditionShText, $TxnSysID, $Condition, $PrdStpTxnSysId]).draw(false);
                                }
                            }
                        });
                        // On Click Listener for New Empty Input Value and Focus On User Code
                        $("#BtnConditionProductNew").on("click", function() {
                            $("#ConditionProductRowIndex").val("-1");
                            $('#ddlCondition').focus();
                            $("#ddlCondition").select2("val", 0);
                        });
                        // On Click Listener of Save Button to Add or Update Database
                        $("#BtnConditionProductSave").on("click", function() {
                            var $txtConditionUserCode = $('#txtConditionUserCode').val($useridparameters);
                            var txtTxnSysID = $clickSysId;
                            document.getElementById("txtConditionPrdStpTxnSysId").setAttribute("value", txtTxnSysID);
                            var $txtConditionPrdStpTxnSysId = $('#txtConditionPrdStpTxnSysId').val();
                            var $txtConditionTxnSysID = $('#txtConditionTxnSysID').val();
                            var $ddlCondition = $("#ddlCondition").find('option:selected').text();
                            var $ddlConditionValue = $("#ddlCondition").find('option:selected').val();
                            if (!$ddlConditionValue) {
                                 document.getElementById("test").innerHTML = "Please Select Condition";
                                $('#ErrorModalValidate').modal('show');
                                setTimeout(function() {
                                    $('#ErrorModalValidate').modal('hide')
                                }, 2000);
                                $('#ddlCondition').focus().val($('#ddlCondition').val());
                                return false;
                            } else {
                                // If RatingProductRowIndex is -1 add new row on table
                                if ($("#ConditionProductRowIndex").val() == "-1") {
                                    var $BtnConditionProductNew = {
                                        PrdStpTxnSysId: data.TxnSysID,
                                        Condition: $ddlConditionValue,
                                    };
                                    var $BtnConditionProductNew = JSON.stringify($BtnConditionProductNew);
                                    $.get("http://207.180.200.121/mtrprodsetup/ProductConditionsSetUp/AddProductConditionsSetUp?_Json=" + $BtnConditionProductNew, function(data) {
                                        $ValidTxn = data.IsValidTxn;
                                        var $txtConditionTxnSysID = $('#txtConditionTxnSysID').val(data.TxnSysID);
                                        if ($ValidTxn == true) {
                                            var rowNodes = $TblConditionProductSetup.row.add([data.ConditionShText, data.TxnSysID, data.Condition, data.PrdStpTxnSysId]).draw();
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
                                }
                                // If ConditionProductRowIndex is 1 update row on table
                                else {
                                    var $ConditionProductRowIndex = $("#ConditionProductRowIndex").val();
                                    var array = $TblConditionProductSetup.row($ConditionProductRowIndex).data();
                                    var $BtnConditionProductUpdate = {
                                        TxnSysID: $txtConditionTxnSysID,
                                        PrdStpTxnSysId: $txtTxnSysID,
                                        Condition: $ddlConditionValue,
                                    };
                                    var $BtnConditionProductUpdate = JSON.stringify($BtnConditionProductUpdate);
                                    $.get("http://207.180.200.121/mtrprodsetup/ProductConditionsSetUp/UpdateProductConditionsSetUp?_Json=" + $BtnConditionProductUpdate, function(data) {
                                        $ValidTxn = data.IsValidTxn;
                                        if ($ValidTxn == true) {
                                            $('#UpdatedModal').modal('show');
                                            setTimeout(function() {
                                                $('#UpdatedModal').modal('hide')
                                            }, 2000);
                                            array[0] = $ddlCondition;
                                            array[1] = $txtConditionTxnSysID;
                                            array[2] = $ddlConditionValue;
                                            array[3] = $txtTxnSysID;
                                            $TblConditionProductSetup.row($ConditionProductRowIndex).data(array);
                                            $TblConditionProductSetup.row($ConditionProductRowIndex).invalidate();
                                            $TblConditionProductSetup.draw(false);
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
                        $('#TblConditionProductSetup tbody').on('click', 'tr', function() {

                            // console.log($TblConditionProductSetup.page.info().recordsTotal);
                            var $selValue = $TblConditionProductSetup.row(this).data();
                            var test = $("#ConditionProductRowIndex").val($TblConditionProductSetup.row(this).index);

                            $rowIdx = $TblConditionProductSetup.row(this).index;

                            $("#TblConditionProductSetup").val($rowIdx);
                            $row = $TblConditionProductSetup.row(this).node();
                            $($row).addClass('ready');
                            $("#txtConditionTxnSysID").val($selValue[1]);
                            $ddlCondition = $selValue[2];
                            $('#ddlCondition').val($ddlCondition).trigger('change');
                            $("#txtConditionPrdStpTxnSysId").val($selValue[3]);
                        });
                        /*Condition JS End*/
                        /*Warranty JS Start*/
                        $("#WarrantyProductRowIndex").val("-1");
                        $('#TblWarrantyProductSetup').DataTable().clear().destroy();
                        var $TblWarrantyProductSetup = $("#TblWarrantyProductSetup").DataTable({
                            "order": [
                                [0, "desc"]
                            ],
                            "paging": true,
                            "pageLength": 5,
                            "searching": true,
                        });
                        // Calling Warranty Values in table by Ajax
                        $.ajax({
                            url: 'http://207.180.200.121/mtrprodsetup/ProductWarrantiesSetup/GetProductWarrantiesSetup?_Json={"PrdStpTxnSysID":' + data.TxnSysID + "}",
                            type: 'get',
                            dataType: "JSON",
                            success: function(response) {
                                var len = response.length;
                                for (var i = 0; i < len; i++) {
                                    var $Warranty = response[i].Warranty
                                    var $WarrantyPrdStpTxnSysId = response[i].PrdStpTxnSysId
                                    var $TxnSysID = response[i].TxnSysID;
                                    var $TxnSysID = response[i].TxnSysID;
                                    var $WarrantyShText = response[i].WarrantyShText;
                                    $TblWarrantyProductSetup.row.add([$WarrantyShText, $WarrantyPrdStpTxnSysId, $TxnSysID, $Warranty]).draw(false);
                                }
                            }
                        });
                        $("#BtnWarrantyProductNew").on("click", function() {
                            $('#ddlWarranty').focus();
                            $('#txtWarrantyText').val('');
                            $("#txWarrantyTxnSysID").val('');
                            $("#ddlWarranty").select2("val", 0);
                            $("#WarrantyProductRowIndex").val("-1");
                        });
                        // On Click Listener of Save Button to Add or Update Database
                        $("#BtnWarrantyProductSave").on("click", function() {
                            var $txtWarrantyUserCode = $('#txtWarrantyUserCode').val($useridparameters);
                            var txtTxnSysID = $clickSysId;
                            document.getElementById("txtWarrantyPrdStpTxnSysId").setAttribute("value", txtTxnSysID);
                            var $txtWarrantyPrdStpTxnSysId = $('#txtWarrantyPrdStpTxnSysId').val();
                            var $txWarrantyTxnSysID = $('#txWarrantyTxnSysID').val();
                            var $ddlWarranty = $("#ddlWarranty").find('option:selected').text();
                            var $ddlWarrantyValue = $("#ddlWarranty").find('option:selected').val();
                            if (!$ddlWarrantyValue) {
                                document.getElementById("test").innerHTML = "Please Select Warranty";
                                $('#ErrorModalValidate').modal('show');
                                setTimeout(function() {
                                    $('#ErrorModalValidate').modal('hide')
                                }, 2000);
                                $('#ddlWarranty').focus().val($('#ddlWarranty').val());
                                return false;
                            } else {
                                // If WarrantyProductRowIndex is -1 add new row on table
                                if ($("#WarrantyProductRowIndex").val() == "-1") {
                                    var $BtnWarrantyProductNew = {
                                        PrdStpTxnSysId: data.TxnSysID,
                                        Warranty: $ddlWarrantyValue,
                                    };
                                    var $BtnWarrantyProductNew = JSON.stringify($BtnWarrantyProductNew);
                                    $.get("http://207.180.200.121/mtrprodsetup/ProductWarrantiesSetup/AddProductWarrantiesSetup?_Json=" + $BtnWarrantyProductNew, function(data) {
                                        $ValidTxn = data.IsValidTxn;
                                        if ($ValidTxn == true) {
                                            var rowNodes = $TblWarrantyProductSetup.row.add([data.WarrantyShText, data.PrdStpTxnSysId, data.TxnSysID, data.Warranty]).draw();
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
                                    var $WarrantyProductRowIndex = $("#WarrantyProductRowIndex").val();
                                    var array = $TblWarrantyProductSetup.row($WarrantyProductRowIndex).data();
                                    var $BtnWarrantyProductUpdate = {
                                        TxnSysID: $txWarrantyTxnSysID,
                                        PrdStpTxnSysId: $txtTxnSysID,
                                        Warranty: $ddlWarranty,
                                    };
                                    var $BtnWarrantyProductUpdate = JSON.stringify($BtnWarrantyProductUpdate);
                                    $.get("http://207.180.200.121/mtrprodsetup/ProductWarrantiesSetup/UpdateProductWarrantiesSetup?_Json=" + $BtnWarrantyProductUpdate, function(data) {
                                        $ValidTxn = data.IsValidTxn;
                                        if ($ValidTxn == true) {
                                            $('#UpdatedModal').modal('show');
                                            setTimeout(function() {
                                                $('#UpdatedModal').modal('hide')
                                            }, 2000);
                                            array[0] = $ddlWarranty;
                                            array[1] = $txtTxnSysID;
                                            array[2] = $txWarrantyTxnSysID;
                                            array[3] = $ddlWarrantyValue;
                                            $TblWarrantyProductSetup.row($WarrantyProductRowIndex).data(array);
                                            $TblWarrantyProductSetup.row($WarrantyProductRowIndex).invalidate();
                                            $TblWarrantyProductSetup.draw(false);
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
                        $('#TblWarrantyProductSetup tbody').on('click', 'tr', function() {
                            $("#WarrantyProductRowIndex").val($TblWarrantyProductSetup.row(this).index);
                            var $selValue = $TblWarrantyProductSetup.row(this).data();
                            $rowIdx = $TblWarrantyProductSetup.row(this).index;
                            $("#TblConditionProductSetup").val($rowIdx);
                            $row = $TblWarrantyProductSetup.row(this).node();
                            $($row).addClass('ready');

                            $ddlWarranty = $selValue[3];
                            $('#ddlWarranty').val($ddlWarranty).trigger('change');

                            $("#txtWarrantyPrdStpTxnSysId").val($selValue[1]);
                            $("#txWarrantyTxnSysID").val($selValue[2]);

                        });
                        /*Warranty JS End*/
                        /*Tracker JS Start*/
                        $("#TrackerProductRowIndex").val("-1");
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
                            url: 'http://207.180.200.121/mtrprodsetup/ProductTrackerSetup/GetProductTrackerSetupMdl?_Json={"PrdStpTxnSysID":' + data.TxnSysID + "}",
                            type: 'get',
                            dataType: "JSON",
                            success: function(response) {
                                var len = response.length;
                                for (var i = 0; i < len; i++) {
                                    var $TrackerCode = response[i].TrackerCode
                                    var $TrackerName = response[i].TrackerName
                                    var $TrackerRate = response[i].TrackerRate;
                                    var $PrdStpTxnSysId = response[i].PrdStpTxnSysId;
                                    var $TxnSysID = response[i].TxnSysID;
                                    $TblTrackerProductSetup.row.add([$TrackerCode, $TrackerName, $TrackerRate, $PrdStpTxnSysId, $TxnSysID]).draw(false);
                                }
                            }
                        });
                        $("#BtnTrackerProductNew").on("click", function() {
                            $('#ddlTrackerCompany').focus();
                            $('#ddlTrackerAmount').val('');
                            $("#txTrackerTxnSysID").val('');
                            $("#ddlTrackerCompany").select2("val", 0);
                            $("#TrackerProductRowIndex").val("-1");
                        });
                        // On Click Listener of Save Button to Add or Update Database
                        $("#BtnTrackerProductSave").on("click", function() {
                            /*var $txtWarrantyUserCode = $('#txtWarrantyUserCode').val($useridparameters);*/
                            var txtTxnSysID = $clickSysId;
                            document.getElementById("txtTrackerPrdStpTxnSysId").setAttribute("value", txtTxnSysID);
                            var $txtTrackerPrdStpTxnSysId = $('#txtTrackerPrdStpTxnSysId').val();
                            var $txTrackerTxnSysID = $('#txTrackerTxnSysID').val();
                            var $ddlTrackerCompany = $("#ddlTrackerCompany").find('option:selected').text();
                            var $ddlTrackerCompanyValue = $("#ddlTrackerCompany").find('option:selected').val();
                            var $ddlTrackerAmount = $('#ddlTrackerAmount').val();
                            if (!$ddlTrackerCompanyValue) {
                                document.getElementById("test").innerHTML = "Please Select Tracker Company";
                                $('#ErrorModalValidate').modal('show');
                                setTimeout(function() {
                                    $('#ErrorModalValidate').modal('hide')
                                }, 2000);
                                $('#$ddlTrackerCompanyValue').focus().val($('#$ddlTrackerCompanyValue').val());
                                return false;
                            }
                            if (!$ddlTrackerAmount) {
                                document.getElementById("test").innerHTML = "Please Fill Tracker Amount";
                                $('#ErrorModalValidate').modal('show');
                                setTimeout(function() {
                                    $('#ErrorModalValidate').modal('hide')
                                }, 2000);
                                $('#$ddlTrackerAmount').focus().val($('#$ddlTrackerAmount').val());
                                return false;
                            } else {
                                // If TrackerProductRowIndex is -1 add new row on table
                                if ($("#TrackerProductRowIndex").val() == "-1") {
                                    var $BtnTrackerProductNew = {
                                        PrdStpTxnSysId: $txtTxnSysID,
                                        TrackerCode: $ddlTrackerCompanyValue,
                                        TrackerRate: $ddlTrackerAmount,
                                    };
                                    var $BtnTrackerProductNew = JSON.stringify($BtnTrackerProductNew);
                                    $.get("http://207.180.200.121/mtrprodsetup/ProductTrackerSetup/AddProductTrackerSetupMdl?_Json=" + $BtnTrackerProductNew, function(data) {
                                        $ValidTxn = data.IsValidTxn;
                                        if ($ValidTxn == true) {
                                            var rowNodes = $TblTrackerProductSetup.row.add([data.TrackerCode, data.TrackerName, data.TrackerRate, data.PrdStpTxnSysId, data.TxnSysID]).draw();
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
                                    var $TrackerProductRowIndex = $("#TrackerProductRowIndex").val();
                                    var array = $TblTrackerProductSetup.row($TrackerProductRowIndex).data();
                                    var $BtnTrackerProductUpdate = {
                                        TxnSysID: $txTrackerTxnSysID,
                                        PrdStpTxnSysId: $txtTxnSysID,
                                        TrackerCode: $ddlTrackerCompanyValue,
                                        TrackerRate: $ddlTrackerAmount,
                                    };
                                    var $BtnTrackerProductUpdate = JSON.stringify($BtnTrackerProductUpdate);
                                    $.get("http://207.180.200.121/mtrprodsetup/ProductTrackerSetup/UpdateProductTrackerSetupMdl?_Json=" + $BtnTrackerProductUpdate, function(data) {
                                        $ValidTxn = data.IsValidTxn;
                                        if ($ValidTxn == true) {
                                            $('#UpdatedModal').modal('show');
                                            setTimeout(function() {
                                                $('#UpdatedModal').modal('hide')
                                            }, 2000);
                                            array[0] = $ddlTrackerCompanyValue;
                                            array[1] = $ddlTrackerCompany;
                                            array[2] = $ddlTrackerAmount;
                                            array[3] = $txtTxnSysID;
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
                                            setTimeout(function() {
                                                $('#ErrorModal').modal('hide')
                                            }, 2000);
                                        }
                                    });

                                }
                            }
                        });
                        $('#TblTrackerProductSetup tbody').on('click', 'tr', function() {
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
                        /*Tracker JS End*/
                        /*Rider JS Start*/
                        $("#RiderProductRowIndex").val("-1");
                        $('#TblRiderProductSetup').DataTable().clear().destroy();
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
                            url: 'http://207.180.200.121/mtrprodsetup/ProductRiderSetup/GetProductRiderSetup?_Json={"PrdStpTxnSysID":' + data.TxnSysID + "}",
                            type: 'get',
                            dataType: "JSON",
                            success: function(response) {
                                var len = response.length;
                                for (var i = 0; i < len; i++) {
                                    var $RiderCode = response[i].RiderCode
                                    var $RiderName = response[i].RiderName
                                    var $RiderRate = response[i].RiderRate;
                                    var $PrdStpTxnSysId = response[i].PrdStpTxnSysId;
                                    var $TxnSysID = response[i].TxnSysID;
                                    $TblRiderProductSetup.row.add([$RiderCode, $RiderName, $RiderRate, $PrdStpTxnSysId, $TxnSysID]).draw(false);
                                }
                            }
                        });
                        $("#BtnRiderProductNew").on("click", function() {
                            $('#ddlRider').focus();
                            $('#ddlRiderAmount').val('');
                            $("#txRiderTxnSysID").val('');
                            $("#ddlRider").select2("val", 0);
                            $("#RiderProductRowIndex").val("-1");
                        });
                        // On Click Listener of Save Button to Add or Update Database
                        $("#BtnRiderProductSave").on("click", function() {
                            /*var $txtWarrantyUserCode = $('#txtWarrantyUserCode').val($useridparameters);*/
                            var txtTxnSysID = $clickSysId;
                            document.getElementById("txtRiderPrdStpTxnSysId").setAttribute("value", txtTxnSysID);
                            var $txtRiderPrdStpTxnSysId = $('#txtRiderPrdStpTxnSysId').val();
                            var $txRiderTxnSysID = $('#txRiderTxnSysID').val();
                            var $ddlRider = $("#ddlRider").find('option:selected').text();
                            var $ddlRiderValue = $("#ddlRider").find('option:selected').val();
                            var $ddlRiderAmount = $('#ddlRiderAmount').val();
                            if (!$ddlRiderValue) {
                                 document.getElementById("test").innerHTML = "Please Select Rider";
                                $('#ErrorModalValidate').modal('show');
                                setTimeout(function() {
                                    $('#ErrorModalValidate').modal('hide')
                                }, 2000);
                                $('#$ddlRider').focus().val($('#$ddlRider').val());
                                return false;
                            }
                            if (!$ddlRiderAmount) {
                                 document.getElementById("test").innerHTML = "Please Fill Amount";
                                $('#ErrorModalValidate').modal('show');
                                setTimeout(function() {
                                    $('#ErrorModalValidate').modal('hide')
                                }, 2000);
                                $('#$ddlRiderAmount').focus().val($('#$ddlRiderAmount').val());
                                return false;
                            } else {
                                // If RiderProductRowIndex is -1 add new row on table
                                if ($("#RiderProductRowIndex").val() == "-1") {
                                    var $BtnRiderProductNew = {
                                        PrdStpTxnSysId: $txtTxnSysID,
                                        RiderCode: $ddlRiderValue,
                                        RiderRate: $ddlRiderAmount,
                                    };
                                    var $BtnRiderProductNew = JSON.stringify($BtnRiderProductNew);
                                    $.get("http://207.180.200.121/mtrprodsetup/ProductRiderSetup/AddProductRiderSetup?_Json=" + $BtnRiderProductNew, function(data) {
                                        $ValidTxn = data.IsValidTxn;
                                        if ($ValidTxn == true) {
                                            var rowNodes = $TblRiderProductSetup.row.add([data.RiderCode, data.RiderName, data.RiderRate, data.PrdStpTxnSysId, data.TxnSysID]).draw();
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
                                    var $RiderProductRowIndex = $("#RiderProductRowIndex").val();
                                    var array = $TblRiderProductSetup.row($RiderProductRowIndex).data();
                                    var $BtnRiderProductUpdate = {
                                        TxnSysID: $txRiderTxnSysID,
                                        PrdStpTxnSysId: $txtTxnSysID,
                                        RiderCode: $ddlRiderValue,
                                        RiderRate: $ddlRiderAmount,
                                    };
                                    var $BtnRiderProductUpdate = JSON.stringify($BtnRiderProductUpdate);
                                    $.get("http://207.180.200.121/mtrprodsetup/ProductRiderSetup/AddProductRiderSetup?_Json=" + $BtnRiderProductUpdate, function(data) {
                                        $ValidTxn = data.IsValidTxn;
                                        if ($ValidTxn == true) {
                                            $('#UpdatedModal').modal('show');
                                            setTimeout(function() {
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
                                            setTimeout(function() {
                                                $('#ErrorModal').modal('hide')
                                            }, 2000);
                                        }
                                    });

                                }
                            }
                        });
                        $('#TblRiderProductSetup tbody').on('click', 'tr', function() {
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
                        /*Rider JS End*/
                    }
                });
            }
            // If ProductRowIndex is 1 update row on table
            else {
                var $ProductRowId = $("#ProductRowIndex").val();
                var array = $TblProductSetup.row($ProductRowId).data();
                var $BtnProductUpdate = {
                    TxnSysId: $txtTxnSysID,
                    ProductCode: $txtProductCode,
                    ProductName: $txtProductName,
                    Client: $ddlClientValue,
                    Agent: $ddlAgentValue,
                    AgentCommPct: $AgentCommPct,
                    IsClientBased: $ddlIsClientBased,
                    PolicyTypeCode: $ddlPolicyTypeValue,
                };
                var $BtnProductUpdate = JSON.stringify($BtnProductUpdate);
                $.get("http://207.180.200.121/mtrprodsetup/MasterProductSetUp/UpdateMasterProductSetUp/?_json=" + $BtnProductUpdate, function(data) {
                    var $ValidTxn = data.IsValidTxn;
                    if ($ValidTxn == true) {
                        $('#UpdatedModal').modal('show');
                        setTimeout(function() {
                            $('#UpdatedModal').modal('hide')
                        }, 2000);
                        array[0] = $txtProductCode;
                        array[1] = $txtProductName;
                        array[2] = $ddlClient;
                        array[3] = $ddlClientValue;
                        array[4] = $ddlAgent;
                        array[5] = $ddlAgentValue;
                        array[6] = $txtTxnSysID;
                        array[7] = $AgentCommPct;
                        array[8] = $ddlIsClientBased;
                        array[9] = $ddlPolicyTypeValue;
                        array[10] = $ddlPolicyType;
                        $TblProductSetup.row($ProductRowId).data(array);
                        $TblProductSetup.row($ProductRowId).invalidate();
                        $TblProductSetup.draw(false);
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
                /*document.getElementById('code-username').innerHTML="<h1>"+$txtProductName+"-"+$txtProductCode+"</h1>";*/
                /*$("#ProductRowIndex").val("-1");*/
            }
        }
    });
    // On Single Table Row Click  
    $('#TblProductSetup tbody').on('click', 'tr', function() {
        $(".submit").css("display", "none");
        $(".tables").css("display", "block");
        var $selValue = $TblProductSetup.row(this).data();
        $rowIdx = $TblProductSetup.row(this).index;
        $("#ProductRowIndex").val($rowIdx);
        $row = $TblProductSetup.row(this).node();
        $($row).addClass('ready');


        $("#txtProductCode").val($selValue[0]);

        $("#txtProductName").val($selValue[1]);

        $ClientValue = $selValue[3];
        $('#ddlClient').val($ClientValue).trigger('change');

        $AgentValue = $selValue[5];
        $('#ddlAgent').val($AgentValue).trigger('change');

        $("#txtTxnSysID").val($selValue[6]);

        $("#txtAgentCommission").val($selValue[7]);

        $ddlIsClientBased = $selValue[8];
        $('#ddlIsClientBased').val($ddlIsClientBased).trigger('change');

        $txtTxnSysID = $("#txtTxnSysID").val($selValue[6]);

        $ddlPolicyType = $selValue[9];
        $('#ddlPolicyType').val($ddlPolicyType).trigger('change');

        $clickSysId = $selValue[6];
        $("#accordion").show();
        document.getElementById('MasterProduct').innerHTML = $selValue[0] + "-" + $selValue[1];
        $("#header").show();
        $("#TableRatingProductRowIndex").val("-1");
        $("#TableConditionProductRowIndex").val("-1");
        $("#TableWarrantyProductRowIndex").val("-1");
        $("#TableTrackerProductRowIndex").val("-1");
        $("#TableRiderProductRowIndex").val("-1");

    });

});
//Product Rating Factor
$(document).ready(function() {
    // By Default  TableRatingProductRowIndex is -1
    $('#TblProductSetup tbody').on('click', 'tr', function() {
        $("#TableRatingProductRowIndex").val("-1");

        $('#TblTableRatingProductSetup').DataTable().clear().destroy();
        $TblTableRatingProductSetup = $("#TblTableRatingProductSetup").DataTable({
            "order": [
                [0, "desc"]
            ],
            "paging": true,
            "pageLength": 5,
            "searching": true,
        });
        // Calling Rating Factor Values in table by Ajax
        $.ajax({
            url: 'http://207.180.200.121/mtrprodsetup/ProductRatingFactorSetUp/GetProductRatingFactorSetUp?_Json={"PrdStpTxnSysID":' + $clickSysId + "}",
            type: 'get',
            dataType: "JSON",
            success: function(response) {
                var len = response.length;
                for (var i = 0; i < len; i++) {
                    var $TxnSysID = response[i].TxnSysID
                    var $PrdStpTxnSysId = response[i].PrdStpTxnSysId
                    var $RatingFactorShText = response[i].RatingFactorShText;
                    var $IsEditable = response[i].IsEditable;
                    var $Rate = response[i].Rate;
                    var $RatingFactor = response[i].RatingFactor;
                    $TblTableRatingProductSetup.row.add([$TxnSysID, $PrdStpTxnSysId, $RatingFactorShText, $IsEditable, $Rate, $RatingFactor]).draw(false);
                }
            }
        });

        // On Click Listener for New Empty Input Value and Focus On User Code
        $("#BtnRatingProductNew").on("click", function() {
            $("#TableRatingProductRowIndex").val("-1");
            $('#ddlRatingFactor').focus();
            $('#txtRatingUserCode').val('');
            $('#txtRatingTxnSysID').val('');
            $("#ddlRatingFactor").select2("val", 0);
            $("#txtRate").val('');
            $("#ddlRatingEditable").select2("val", 0);
        });
        // On Click Listener of Save Button to Add or Update Database
        $("#BtnTableRatingProductSave").on("click", function() {
            var $txtRatingUserCode = $('#txtRatingUserCode').val($useridparameters);
            var txtTxnSysID = $clickSysId;
            document.getElementById("txtRatingPrdStpTxnSysId").setAttribute("value", txtTxnSysID);
            var $txtRatingTxnSysID = $('#txtRatingTxnSysID').val();
            var $txtRatingPrdStpTxnSysId = $('#txtRatingPrdStpTxnSysId').val();
            var $ddlRatingFactor = $("#ddlRatingFactor").find('option:selected').text();
            var $ddlRatingFactorValue = $("#ddlRatingFactor").find('option:selected').val();
            var $ddlRatingEditable = $("#ddlRatingEditable").find('option:selected').text();
            var $ddlRatingEditableValue = $("#ddlRatingEditable").find('option:selected').val();
            var $txtRate = $("#txtRate").val();
            //Custom Validation
            if (!$ddlRatingFactorValue) {
                document.getElementById("test").innerHTML = "Please Select Rating Factor";
                $('#ErrorModalValidate').modal('show');
                setTimeout(function() {
                    $('#ErrorModalValidate').modal('hide')
                }, 2000);
                $('#ddlRatingFactor').focus().val($('#ddlRatingFactor').val());
                return false;
            }
            if (!$txtRate) {
                document.getElementById("test").innerHTML = "Please Fill Rate";
                $('#ErrorModalValidate').modal('show');
                setTimeout(function() {
                    $('#ErrorModalValidate').modal('hide')
                }, 2000);
                $('#txtRate').focus().val($('#txtRate').val());
                return false;
            }
            if (!$ddlRatingEditableValue) {
                 document.getElementById("test").innerHTML = "Please Fill Is Editable";
                $('#ErrorModalValidate').modal('show');
                setTimeout(function() {
                    $('#ErrorModalValidate').modal('hide')
                }, 2000);
                $('#ddlRatingEditable').focus().val($('#ddlRatingEditable').val());
                return false;
            } else {
                // If TableRatingProductRowIndex is -1 add new row on table
                if ($("#TableRatingProductRowIndex").val() == "-1") {
                    var $BtnRatingProductNew = {
                        PrdStpTxnSysId: $txtRatingPrdStpTxnSysId,
                        RatingFactor: $ddlRatingFactorValue,
                        IsEditable: $ddlRatingEditable,
                        Rate: $txtRate,
                    };
                    var $BtnRatingProductNew = JSON.stringify($BtnRatingProductNew);
                    $.get("http://207.180.200.121/mtrprodsetup/ProductRatingFactorSetUp/AddProductRatingFactorSetUp?_Json=" + $BtnRatingProductNew, function(data) {
                        $('#txtRatingTxnSysID').val(data.TxnSysID);
                        $ValidTxn = data.IsValidTxn;
                        if ($ValidTxn == true) {
                            /*var test = $("#RatingProductRowIndex").val($TblRatingProductSetup.row(this).index);
                            console.log(test);*/
                            var rowNodes = $TblTableRatingProductSetup.row.add([data.TxnSysID, data.PrdStpTxnSysId, data.RatingFactorShText, data.IsEditable, data.Rate, data.RatingFactor]).draw();
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
                }
                // If TableRatingProductRowIndex is 1 update row on table
                else {
                    var $TableRatingProductRowIndex = $("#TableRatingProductRowIndex").val();
                    var array = $TblTableRatingProductSetup.row($TableRatingProductRowIndex).data();
                    var $BtnRatingProductUpdate = {
                        TxnSysID: $txtRatingTxnSysID,
                        PrdStpTxnSysId: $txtRatingPrdStpTxnSysId,
                        RatingFactor: $ddlRatingFactorValue,
                        IsEditable: $ddlRatingEditable,
                        Rate: $txtRate,
                    };
                    var $BtnRatingProductUpdate = JSON.stringify($BtnRatingProductUpdate);
                    $.get("http://207.180.200.121/mtrprodsetup/ProductRatingFactorSetUp/UpdateProductRatingFactorSetUp?_Json=" + $BtnRatingProductUpdate, function(data) {
                        $ValidTxn = data.IsValidTxn;
                        if ($ValidTxn == true) {
                            $('#UpdatedModal').modal('show');
                            setTimeout(function() {
                                $('#UpdatedModal').modal('hide')
                            }, 2000);
                            array[0] = $txtRatingTxnSysID;
                            array[1] = $txtRatingPrdStpTxnSysId;
                            array[2] = $ddlRatingFactor;
                            array[3] = $ddlRatingEditable;
                            array[4] = $txtRate;
                            array[5] = $ddlRatingFactorValue;
                            $TblTableRatingProductSetup.row($TableRatingProductRowIndex).data(array);
                            $TblTableRatingProductSetup.row($TableRatingProductRowIndex).invalidate();
                            $TblTableRatingProductSetup.draw(false);
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

        $('#TblTableRatingProductSetup tbody').on('click', 'tr', function() {
            var $RatingselValue = $TblTableRatingProductSetup.row(this).data();
            $rowIdx = $TblTableRatingProductSetup.row(this).index;
            $("#TableRatingProductRowIndex").val($rowIdx);
            $row = $TblTableRatingProductSetup.row(this).node();
            $($row).addClass('ready');
            $("#txtRatingTxnSysID").val($RatingselValue[0]);
            $("#txtRatingPrdStpTxnSysId").val($RatingselValue[1]);
            $RatingFactor = $RatingselValue[5];
            $('#ddlRatingFactor').val($RatingFactor).trigger('change');
            $("#txtRate").val($RatingselValue[4]);
            $ddlRatingEditable = $RatingselValue[3];
            $('#ddlRatingEditable').val($ddlRatingEditable).trigger('change');
        });
    });
});
//Product Condition
$(document).ready(function() {
    // By Default  TableConditionProductRowIndex is -1
    $("#TableConditionProductRowIndex").val("-1");
    $('#TblProductSetup tbody').on('click', 'tr', function() {
        $('#TblTableConditionProductSetup').DataTable().clear().destroy();
        $TblTableConditionProductSetup = $("#TblTableConditionProductSetup").DataTable({
            "order": [
                [0, "desc"]
            ],
            "paging": true,
            "pageLength": 5,
            "searching": true,
        });
        // Calling Condition Values in table by Ajax
        $.ajax({
            url: 'http://207.180.200.121/mtrprodsetup/ProductConditionsSetUp/GetProductConditionsSetUp?_Json={"PrdStpTxnSysID":' + $clickSysId + "}",
            type: 'get',
            dataType: "JSON",
            success: function(response) {
                var len = response.length;
                for (var i = 0; i < len; i++) {
                    var $TxnSysID = response[i].TxnSysID
                    var $ConditionShText = response[i].ConditionShText;
                    var $TxnSysID = response[i].TxnSysID;
                    var $Condition = response[i].Condition;
                    var $PrdStpTxnSysId = response[i].PrdStpTxnSysId
                    $TblTableConditionProductSetup.row.add([$ConditionShText, $TxnSysID, $Condition, $PrdStpTxnSysId]).draw(false);
                }
            }
        });
        // On Click Listener for New Empty Input Value and Focus On User Code
        $("#BtnConditionProductNew").on("click", function() {
            $("#TableConditionProductRowIndex").val("-1");
            $('#ddlCondition').focus();
            $("#ddlCondition").select2("val", 0);
        });
        // On Click Listener of Save Button to Add or Update Database
        $("#BtnTableConditionProductSave").on("click", function() {
            var $txtConditionUserCode = $('#txtConditionUserCode').val($useridparameters);
            var txtTxnSysID = $clickSysId;
            document.getElementById("txtConditionPrdStpTxnSysId").setAttribute("value", txtTxnSysID);
            var $txtConditionPrdStpTxnSysId = $('#txtConditionPrdStpTxnSysId').val();
            var $txtConditionTxnSysID = $('#txtConditionTxnSysID').val();
            var $ddlCondition = $("#ddlCondition").find('option:selected').text();
            var $ddlConditionValue = $("#ddlCondition").find('option:selected').val();
            if (!$ddlConditionValue) {
                document.getElementById("test").innerHTML = "Please Select Condition";
                $('#ErrorModalValidate').modal('show');
                setTimeout(function() {
                    $('#ErrorModalValidate').modal('hide')
                }, 2000);
                $('#ddlCondition').focus().val($('#ddlCondition').val());
                return false;
            } else {
                // If TableConditionProductRowIndex is -1 add new row on table
                if ($("#TableConditionProductRowIndex").val() == "-1") {

                    var $BtnConditionProductNew = {
                        PrdStpTxnSysId: $txtConditionPrdStpTxnSysId,
                        Condition: $ddlConditionValue,
                    };
                    var $BtnConditionProductNew = JSON.stringify($BtnConditionProductNew);
                    $.get("http://207.180.200.121/mtrprodsetup/ProductConditionsSetUp/AddProductConditionsSetUp?_Json=" + $BtnConditionProductNew, function(data) {
                        $ValidTxn = data.IsValidTxn;
                        var $txtConditionTxnSysID = $('#txtConditionTxnSysID').val(data.TxnSysID);
                        if ($ValidTxn == true) {
                            var rowNodes = $TblTableConditionProductSetup.row.add([data.ConditionShText, data.TxnSysID, data.Condition, data.PrdStpTxnSysId]).draw();
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
                }
                // If TableConditionProductRowIndex is 1 update row on table
                else {
                    var $TableConditionProductRowIndex = $("#TableConditionProductRowIndex").val();
                    var array = $TblTableConditionProductSetup.row($TableConditionProductRowIndex).data();
                    var $BtnConditionProductUpdate = {
                        TxnSysID: $txtConditionTxnSysID,
                        PrdStpTxnSysId: $txtConditionPrdStpTxnSysId,
                        Condition: $ddlConditionValue,
                    };
                    var $BtnConditionProductUpdate = JSON.stringify($BtnConditionProductUpdate);
                    $.get("http://207.180.200.121/mtrprodsetup/ProductConditionsSetUp/UpdateProductConditionsSetUp?_Json=" + $BtnConditionProductUpdate, function(data) {
                        $ValidTxn = data.IsValidTxn;
                        if ($ValidTxn == true) {
                            $('#UpdatedModal').modal('show');
                            setTimeout(function() {
                                $('#UpdatedModal').modal('hide')
                            }, 2000);
                            array[0] = $ddlCondition;
                            array[1] = $txtConditionTxnSysID;
                            array[2] = $ddlConditionValue;
                            array[3] = $txtConditionPrdStpTxnSysId;
                            $TblTableConditionProductSetup.row($TableConditionProductRowIndex).data(array);
                            $TblTableConditionProductSetup.row($TableConditionProductRowIndex).invalidate();
                            $TblTableConditionProductSetup.draw(false);
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
        $('#TblTableConditionProductSetup tbody').on('click', 'tr', function() {

            // console.log($TblConditionProductSetup.page.info().recordsTotal);
            var $selValue = $TblTableConditionProductSetup.row(this).data();
            var test = $("#TableConditionProductRowIndex").val($TblTableConditionProductSetup.row(this).index);

            $rowIdx = $TblTableConditionProductSetup.row(this).index;

            $("#TblTableConditionProductSetup").val($rowIdx);
            $row = $TblTableConditionProductSetup.row(this).node();
            $($row).addClass('ready');
            $("#txtConditionTxnSysID").val($selValue[1]);
            $ddlCondition = $selValue[2];
            $('#ddlCondition').val($ddlCondition).trigger('change');
            $("#txtConditionPrdStpTxnSysId").val($selValue[3]);
        });
    });
});
//Product WarrantyCode
$(document).ready(function() {
    // By Default  TableWarrantyProductRowIndex is -1
    $("#TableWarrantyProductRowIndex").val("-1");
    $('#TblProductSetup tbody').on('click', 'tr', function() {
        $('#TblTableWarrantyProductSetup').DataTable().clear().destroy();
        $TblTableWarrantyProductSetup = $("#TblTableWarrantyProductSetup").DataTable({
            "order": [
                [0, "desc"]
            ],
            "paging": true,
            "pageLength": 5,
            "searching": true,
        });
        // Calling Warranty Values in table by Ajax
        $.ajax({
            url: 'http://207.180.200.121/mtrprodsetup/ProductWarrantiesSetup/GetProductWarrantiesSetup?_Json={"PrdStpTxnSysID":' + $clickSysId + "}",
            type: 'get',
            dataType: "JSON",
            success: function(response) {
                var len = response.length;
                for (var i = 0; i < len; i++) {
                    var $Warranty = response[i].Warranty
                    var $WarrantyPrdStpTxnSysId = response[i].PrdStpTxnSysId
                    var $TxnSysID = response[i].TxnSysID;
                    var $TxnSysID = response[i].TxnSysID;
                    var $WarrantyShText = response[i].WarrantyShText;
                    $TblTableWarrantyProductSetup.row.add([$WarrantyShText, $WarrantyPrdStpTxnSysId, $TxnSysID, $Warranty]).draw(false);
                }
            }
        });
        $("#BtnWarrantyProductNew").on("click", function() {
            $('#ddlWarranty').focus();
            $('#txtWarrantyText').val('');
            $("#txWarrantyTxnSysID").val('');
            $("#ddlWarranty").select2("val", 0);
            $("#TableWarrantyProductRowIndex").val("-1");
        });
        // On Click Listener of Save Button to Add or Update Database
        $("#BtnTableWarrantyProductSave").on("click", function() {
            var $txtWarrantyUserCode = $('#txtWarrantyUserCode').val($useridparameters);
            var txtTxnSysID = $clickSysId;
            document.getElementById("txtWarrantyPrdStpTxnSysId").setAttribute("value", txtTxnSysID);
            var $txtWarrantyPrdStpTxnSysId = $('#txtWarrantyPrdStpTxnSysId').val();
            var $txWarrantyTxnSysID = $('#txWarrantyTxnSysID').val();
            var $ddlWarranty = $("#ddlWarranty").find('option:selected').text();
            var $ddlWarrantyValue = $("#ddlWarranty").find('option:selected').val();
            if (!$ddlWarrantyValue) {
                 document.getElementById("test").innerHTML = "Please Select Warranty";
                $('#ErrorModalValidate').modal('show');
                setTimeout(function() {
                    $('#ErrorModalValidate').modal('hide')
                }, 2000);
                $('#ddlWarranty').focus().val($('#ddlWarranty').val());
                return false;
            } else {
                // If TableWarrantyProductRowIndex is -1 add new row on table
                if ($("#TableWarrantyProductRowIndex").val() == "-1") {
                    var $BtnWarrantyProductNew = {
                        PrdStpTxnSysId: $txtWarrantyPrdStpTxnSysId,
                        Warranty: $ddlWarrantyValue,
                    };
                    var $BtnWarrantyProductNew = JSON.stringify($BtnWarrantyProductNew);
                    $.get("http://207.180.200.121/mtrprodsetup/ProductWarrantiesSetup/AddProductWarrantiesSetup?_Json=" + $BtnWarrantyProductNew, function(data) {
                        $ValidTxn = data.IsValidTxn;
                        if ($ValidTxn == true) {
                            var rowNodes = $TblTableWarrantyProductSetup.row.add([data.WarrantyShText, data.PrdStpTxnSysId, data.TxnSysID, data.Warranty]).draw();
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
                    var $TableWarrantyProductRowIndex = $("#TableWarrantyProductRowIndex").val();
                    var array = $TblTableWarrantyProductSetup.row($TableWarrantyProductRowIndex).data();
                    var $BtnWarrantyProductUpdate = {
                        TxnSysID: $txWarrantyTxnSysID,
                        PrdStpTxnSysId: $txtWarrantyPrdStpTxnSysId,
                        Warranty: $ddlWarranty,
                    };
                    var $BtnWarrantyProductUpdate = JSON.stringify($BtnWarrantyProductUpdate);
                    $.get("http://207.180.200.121/mtrprodsetup/ProductWarrantiesSetup/UpdateProductWarrantiesSetup?_Json=" + $BtnWarrantyProductUpdate, function(data) {
                        $ValidTxn = data.IsValidTxn;
                        if ($ValidTxn == true) {
                            $('#UpdatedModal').modal('show');
                            setTimeout(function() {
                                $('#UpdatedModal').modal('hide')
                            }, 2000);
                            array[0] = $ddlWarranty;
                            array[1] = $txtWarrantyPrdStpTxnSysId;
                            array[2] = $txWarrantyTxnSysID;
                            array[3] = $ddlWarrantyValue;
                            $TblTableWarrantyProductSetup.row($TableWarrantyProductRowIndex).data(array);
                            $TblTableWarrantyProductSetup.row($TableWarrantyProductRowIndex).invalidate();
                            $TblTableWarrantyProductSetup.draw(false);
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
        $('#TblTableWarrantyProductSetup tbody').on('click', 'tr', function() {
            $("#TableWarrantyProductRowIndex").val($TblTableWarrantyProductSetup.row(this).index);
            var $selValue = $TblTableWarrantyProductSetup.row(this).data();
            $rowIdx = $TblTableWarrantyProductSetup.row(this).index;
            $("#TblConditionProductSetup").val($rowIdx);
            $row = $TblTableWarrantyProductSetup.row(this).node();
            $($row).addClass('ready');

            $ddlWarranty = $selValue[3];
            $('#ddlWarranty').val($ddlWarranty).trigger('change');

            $("#txtWarrantyPrdStpTxnSysId").val($selValue[1]);
            $("#txWarrantyTxnSysID").val($selValue[2]);

        });
    });
});
//Product Tracker
$(document).ready(function() {
    // By Default  TableTrackerProductRowIndex is -1
    $("#TableTrackerProductRowIndex").val("-1");
    $('#TblProductSetup tbody').on('click', 'tr', function() {
        $('#TblTableTrackerProductSetup').DataTable().clear().destroy();
        $TblTableTrackerProductSetup = $("#TblTableTrackerProductSetup").DataTable({
            "order": [
                [0, "desc"]
            ],
            "paging": true,
            "pageLength": 5,
            "searching": true,
        });
        // Calling Tracker Values in table by Ajax
        $.ajax({
            url: 'http://207.180.200.121/mtrprodsetup/ProductTrackerSetup/GetProductTrackerSetupMdl?_Json={"PrdStpTxnSysID":' + $clickSysId + "}",
            type: 'get',
            dataType: "JSON",
            success: function(response) {
                var len = response.length;
                for (var i = 0; i < len; i++) {
                    var $TrackerCode = response[i].TrackerCode
                    var $TrackerName = response[i].TrackerName
                    var $TrackerRate = response[i].TrackerRate;
                    var $PrdStpTxnSysId = response[i].PrdStpTxnSysId;
                    var $TxnSysID = response[i].TxnSysID;
                    $TblTableTrackerProductSetup.row.add([$TrackerCode, $TrackerName, $TrackerRate, $PrdStpTxnSysId, $TxnSysID]).draw(false);
                }
            }
        });
        $("#BtnTrackerProductNew").on("click", function() {
            $('#ddlTrackerCompany').focus();
            $('#ddlTrackerAmount').val('');
            $("#txTrackerTxnSysID").val('');
            $("#ddlTrackerCompany").select2("val", 0);
            $("#TableTrackerProductRowIndex").val("-1");
        });
        // On Click Listener of Save Button to Add or Update Database
        $("#BtnTableTrackerProductSave").on("click", function() {
            /*var $txtWarrantyUserCode = $('#txtWarrantyUserCode').val($useridparameters);*/
            var txtTxnSysID = $clickSysId;
            document.getElementById("txtTrackerPrdStpTxnSysId").setAttribute("value", txtTxnSysID);
            var $txtTrackerPrdStpTxnSysId = $('#txtTrackerPrdStpTxnSysId').val();
            var $txTrackerTxnSysID = $('#txTrackerTxnSysID').val();
            var $ddlTrackerCompany = $("#ddlTrackerCompany").find('option:selected').text();
            var $ddlTrackerCompanyValue = $("#ddlTrackerCompany").find('option:selected').val();
            var $ddlTrackerAmount = $('#ddlTrackerAmount').val();
            if (!$ddlTrackerCompanyValue) {
                document.getElementById("test").innerHTML = "Please Select Company";
                $('#ErrorModalValidate').modal('show');
                setTimeout(function() {
                    $('#ErrorModalValidate').modal('hide')
                }, 2000);
                $('#ddlTrackerCompany').focus().val($('#ddlTrackerCompany').val());
                return false;
            }
            if (!$ddlTrackerAmount) {
                document.getElementById("test").innerHTML = "Please Fill Tracker Amount";
                $('#ErrorModalValidate').modal('show');
                setTimeout(function() {
                    $('#ErrorModalValidate').modal('hide')
                }, 2000);
                $('#ddlTrackerAmount').focus().val($('#ddlTrackerAmount').val());
                return false;
            } else {
                // If TableTrackerProductRowIndex is -1 add new row on table
                if ($("#TableTrackerProductRowIndex").val() == "-1") {
                    var $BtnTrackerProductNew = {
                        PrdStpTxnSysId: $txtTrackerPrdStpTxnSysId,
                        TrackerCode: $ddlTrackerCompanyValue,
                        TrackerRate: $ddlTrackerAmount,
                    };
                    var $BtnTrackerProductNew = JSON.stringify($BtnTrackerProductNew);
                    $.get("http://207.180.200.121/mtrprodsetup/ProductTrackerSetup/AddProductTrackerSetupMdl?_Json=" + $BtnTrackerProductNew, function(data) {
                        $ValidTxn = data.IsValidTxn;
                        if ($ValidTxn == true) {
                            var rowNodes = $TblTableTrackerProductSetup.row.add([data.TrackerCode, data.TrackerName, data.TrackerRate, data.PrdStpTxnSysId, data.TxnSysID]).draw();
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
                    var $TableTrackerProductRowIndex = $("#TableTrackerProductRowIndex").val();
                    var array = $TblTableTrackerProductSetup.row($TableTrackerProductRowIndex).data();
                    var $BtnTrackerProductUpdate = {
                        TxnSysID: $txTrackerTxnSysID,
                        PrdStpTxnSysId: $txtTrackerPrdStpTxnSysId,
                        TrackerCode: $ddlTrackerCompanyValue,
                        TrackerRate: $ddlTrackerAmount,
                    };
                    var $BtnTrackerProductUpdate = JSON.stringify($BtnTrackerProductUpdate);
                    $.get("http://207.180.200.121/mtrprodsetup/ProductTrackerSetup/UpdateProductTrackerSetupMdl?_Json=" + $BtnTrackerProductUpdate, function(data) {
                        $ValidTxn = data.IsValidTxn;
                        if ($ValidTxn == true) {
                            $('#UpdatedModal').modal('show');
                            setTimeout(function() {
                                $('#UpdatedModal').modal('hide')
                            }, 2000);
                            array[0] = $ddlTrackerCompanyValue;
                            array[1] = $ddlTrackerCompany;
                            array[2] = $ddlTrackerAmount;
                            array[3] = $txtTrackerPrdStpTxnSysId;
                            array[4] = $txTrackerTxnSysID;
                            $TblTableTrackerProductSetup.row($TableTrackerProductRowIndex).data(array);
                            $TblTableTrackerProductSetup.row($TableTrackerProductRowIndex).invalidate();
                            $TblTableTrackerProductSetup.draw(false);
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
        $('#TblTableTrackerProductSetup tbody').on('click', 'tr', function() {
            $("#TableTrackerProductRowIndex").val($TblTableTrackerProductSetup.row(this).index);
            var $selValue = $TblTableTrackerProductSetup.row(this).data();
            $rowIdx = $TblTableTrackerProductSetup.row(this).index;
            $("#TblConditionProductSetup").val($rowIdx);
            $row = $TblTableTrackerProductSetup.row(this).node();
            $($row).addClass('ready');
            $("#txtTrackerPrdStpTxnSysId").val($selValue[3]);
            $("#txTrackerTxnSysID").val($selValue[4]);
            $("#ddlTrackerAmount").val($selValue[2]);
            $ddlTrackerCompany = $selValue[0];
            $('#ddlTrackerCompany').val($ddlTrackerCompany).trigger('change');

        });
    });
});
//Product Rider
$(document).ready(function() {
    // By Default  TableRiderProductRowIndex is -1
    $("#TableRiderProductRowIndex").val("-1");
    $('#TblProductSetup tbody').on('click', 'tr', function() {
        $('#TblTableRiderProductSetup').DataTable().clear().destroy();
        $TblTableRiderProductSetup = $("#TblTableRiderProductSetup").DataTable({
            "order": [
                [0, "desc"]
            ],
            "paging": true,
            "pageLength": 5,
            "searching": true,
        });
        // Calling Rider Values in table by Ajax
        $.ajax({
            url: 'http://207.180.200.121/mtrprodsetup/ProductRiderSetup/GetProductRiderSetup?_Json={"PrdStpTxnSysID":' + $clickSysId + "}",
            type: 'get',
            dataType: "JSON",
            success: function(response) {
                var len = response.length;
                for (var i = 0; i < len; i++) {
                    var $RiderCode = response[i].RiderCode
                    var $RiderName = response[i].RiderName
                    var $RiderRate = response[i].RiderRate;
                    var $PrdStpTxnSysId = response[i].PrdStpTxnSysId;
                    var $TxnSysID = response[i].TxnSysID;
                    $TblTableRiderProductSetup.row.add([$RiderCode, $RiderName, $RiderRate, $PrdStpTxnSysId, $TxnSysID]).draw(false);
                }
            }
        });
        $("#BtnRiderProductNew").on("click", function() {
            $('#ddlRider').focus();
            $('#ddlRiderAmount').val('');
            $("#txRiderTxnSysID").val('');
            $("#ddlRider").select2("val", 0);
            $("#TableRiderProductRowIndex").val("-1");
        });
        // On Click Listener of Save Button to Add or Update Database
        $("#BtnTableRiderProductSave").on("click", function() {
            /*var $txtWarrantyUserCode = $('#txtWarrantyUserCode').val($useridparameters);*/
            var txtTxnSysID = $clickSysId;
            document.getElementById("txtRiderPrdStpTxnSysId").setAttribute("value", txtTxnSysID);
            var $txtRiderPrdStpTxnSysId = $('#txtRiderPrdStpTxnSysId').val();
            var $txRiderTxnSysID = $('#txRiderTxnSysID').val();
            var $ddlRider = $("#ddlRider").find('option:selected').text();
            var $ddlRiderValue = $("#ddlRider").find('option:selected').val();
            var $ddlRiderAmount = $('#ddlRiderAmount').val();
            if (!$ddlRiderValue || $ddlRider == "Choose Rider") {
                document.getElementById("test").innerHTML = "Please Select Rider";
                $('#ErrorModalValidate').modal('show');
                setTimeout(function() {
                    $('#ErrorModalValidate').modal('hide')
                }, 2000);
                $('#ddlRider').focus().val($('#ddlRider').val());
                return false;
            }
            if (!$ddlRiderAmount) {
                document.getElementById("test").innerHTML = "Please Fill Rider Amount";
                $('#ErrorModalValidate').modal('show');
                setTimeout(function() {
                    $('#ErrorModalValidate').modal('hide')
                }, 2000);
                $('#ddlRiderAmount').focus().val($('#ddlRiderAmount').val());
                return false;
            } else {
                // If TableRiderProductRowIndex is -1 add new row on table
                if ($("#TableRiderProductRowIndex").val() == "-1") {
                    if($ddlRiderValue == 5 || $ddlRiderValue == 3){
                        var $BtnRiderProductNew = {
                        PrdStpTxnSysId: $txtRiderPrdStpTxnSysId,
                        RiderCode: $ddlRiderValue,
                        RiderRate: $ddlRiderAmount,
                        };
                        var $BtnRiderProductNew = JSON.stringify($BtnRiderProductNew);
                        $.get("http://207.180.200.121/mtrprodsetup/ProductRiderSetup/AddProductRiderSetup?_Json=" + $BtnRiderProductNew, function(data) {
                            $ValidTxn = data.IsValidTxn;
                            if ($ValidTxn == true) {
                                var rowNodes = $TblTableRiderProductSetup.row.add([data.RiderCode, data.RiderName, data.RiderRate, data.PrdStpTxnSysId, data.TxnSysID]).draw();
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
                    }
                    var $BtnRiderProductNew = {
                        PrdStpTxnSysId: $txtRiderPrdStpTxnSysId,
                        RiderCode: $ddlRiderValue,
                        RiderRate: $ddlRiderAmount,
                    };
                    var $BtnRiderProductNew = JSON.stringify($BtnRiderProductNew);
                    $.get("http://207.180.200.121/mtrprodsetup/ProductRiderSetup/AddProductRiderSetup?_Json=" + $BtnRiderProductNew, function(data) {
                        $ValidTxn = data.IsValidTxn;
                        if ($ValidTxn == true) {
                            var rowNodes = $TblTableRiderProductSetup.row.add([data.RiderCode, data.RiderName, data.RiderRate, data.PrdStpTxnSysId, data.TxnSysID]).draw();
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
                    var $TableRiderProductRowIndex = $("#TableRiderProductRowIndex").val();
                    var array = $TblTableRiderProductSetup.row($TableRiderProductRowIndex).data();
                    var $BtnRiderProductUpdate = {
                        TxnSysID: $txRiderTxnSysID,
                        PrdStpTxnSysId: $txtRiderPrdStpTxnSysId,
                        RiderCode: $ddlRiderValue,
                        RiderRate: $ddlRiderAmount,
                    };
                    var $BtnRiderProductUpdate = JSON.stringify($BtnRiderProductUpdate);
                    $.get("http://207.180.200.121/mtrprodsetup/ProductRiderSetup/AddProductRiderSetup?_Json=" + $BtnRiderProductUpdate, function(data) {
                        $ValidTxn = data.IsValidTxn;
                        if ($ValidTxn == true) {
                            $('#UpdatedModal').modal('show');
                            setTimeout(function() {
                                $('#UpdatedModal').modal('hide')
                            }, 2000);
                            array[0] = $ddlRiderValue;
                            array[1] = $ddlRider;
                            array[2] = $ddlRiderAmount;
                            array[3] = $txtRiderPrdStpTxnSysId;
                            array[4] = $txRiderTxnSysID;
                            $TblTableRiderProductSetup.row($TableRiderProductRowIndex).data(array);
                            $TblTableRiderProductSetup.row($TableRiderProductRowIndex).invalidate();
                            $TblTableRiderProductSetup.draw(false);
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
        $('#TblTableRiderProductSetup tbody').on('click', 'tr', function() {
            $("#TableRiderProductRowIndex").val($TblTableRiderProductSetup.row(this).index);
            var $selValue = $TblTableRiderProductSetup.row(this).data();
            $rowIdx = $TblTableRiderProductSetup.row(this).index;
            $("#TblConditionProductSetup").val($rowIdx);
            $row = $TblTableRiderProductSetup.row(this).node();
            $($row).addClass('ready');
            $("#txtRiderPrdStpTxnSysId").val($selValue[3]);
            $("#txRiderTxnSysID").val($selValue[4]);
            $("#ddlRiderAmount").val($selValue[2]);
            $ddlRider = $selValue[0];
            $('#ddlRider').val($ddlRider).trigger('change');

        });
    });
});