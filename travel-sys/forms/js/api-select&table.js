/* For Deleting Row in Family Section Table */
function deleteRow(btn) {
  var row = btn.parentNode.parentNode;
  row.parentNode.removeChild(row);
}
/* Calling Select2 Function */
$(document).ready(function () {
  $('.js-example-basic-single').select2();
});

/*API Integration In Category Dropdown*/
let dropdown = $('#Category-dropdown');
dropdown.empty();
dropdown.append('<option selected="" value="">Choose Category</option>');
dropdown.prop('selectedIndex', 0);
const url = "http://192.168.1.6/ddlapi/ddltravel/GetTravelCategoryList";
var Mydata;
$.ajax({
  url: url,
  type: "GET",
  crossDomain: true,
  dataType: "JSONP",
  success: function (data) {
    $.each(data, function (key, entry) {
      dropdown.append($('<option></option>').attr('value', entry.TravelCategoryCode).text(entry.TravelCategoryName));
    })
  },
  error: function (xhr, status, error) {
    alert(status);
  }
});


/* API Integration In Plan Dropdown */
$("#Category-dropdown").change(function () {
  var Categorycode = $(this).val();
  let dropdown1 = $('#Plan-Dropdown');
  dropdown1.empty();
  dropdown1.append('<option selected="true" disabled>Choose Plan</option>');
  dropdown1.prop('selectedIndex', 0);
  dropdown1.val();
  $.ajax({
    url: "http://192.168.1.6/ddlapi/ddltravel/getTravelPlansByCategory/?_travelcategorycode=" + Categorycode,
    type: "GET",
    crossDomain: true,
    dataType: "JSONP",
    success: function (data) {
      $.each(data, function (key, entry) {
        dropdown1.append($('<option></option>').attr('value', entry.TravelPlanCode).text(entry.TravelPlanName));
      })
    },
    error: function (xhr, status, error) {
      alert(status);
    }
  });
});
  // Payment Method Dropdown Div
  $("#paymentmethod").change(function () {
    var PaymentMethodValue = $(this).val();
    $("#card").hide();
    $("#debit").hide();
    $("#cheque").hide();
    $("#cash").hide();
    if(PaymentMethodValue == "credit"){
      $("#card").show();
    }
    if(PaymentMethodValue == "debit"){
      $("#debit").show();
    }
    if(PaymentMethodValue == "cheque"){
      $("#cheque").show();
    }
    if(PaymentMethodValue == "cash"){
      $("#cash").show();
    }
  });


/* Onclick Family Detail Section Show*/
$("#relation").change(function () {
  var RelationValue = $(this).val();
  //console.log(RelationValue);
  $("#familydetails").hide();
  if (RelationValue == "family") {
    $("#familydetails").show();
  }
});

/*API Integration In Cover limit Table*/
$("#Plan-Dropdown").change(function () {
  var PlanCode = $(this).val();
  if ($.fn.DataTable.isDataTable('#coverlimittable')) {
    $('#coverlimittable').DataTable().destroy();
  }
  $('#coverlimittable tbody').empty();
  var $CoverLimitTable = $("#coverlimittable").DataTable({
    "order": [
      [0, "desc"]
    ],
    "paging": false,
    "searching": false,
  });
  $.ajax({
    url: "http://192.168.1.6/ddlapi/gridTravel/getTravelCoversSetupByPlan/?_TravelPlanCode=" + PlanCode,
    type: 'get',
    dataType: "JSONP",
    success: function (response) {
      var len = response.length;
      for (var i = 0; i < len; i++) {
        var $TravelCoverName = response[i].TravelCoverName;
        var $TravelCoverLimitText = response[i].TravelCoverLimitText;
        $CoverLimitTable.row.add([$TravelCoverName, $TravelCoverLimitText]).draw(false);
      }
    }
  });
});

/*API Integration In Contribution limit Table*/
$("#Plan-Dropdown").change(function () {
  var PlanCode = $(this).val();
  if ($.fn.DataTable.isDataTable('#contributiotable')) {
    $('#contributiotable').DataTable().destroy();
  }
  $('#contributiotable tbody').empty();
  var $ContribuTiotable = $("#contributiotable").DataTable({
    "order": [
      [0, "desc"]
    ],
    "paging": false,
    "searching": false,
  });
  $.ajax({
    url: "http://192.168.1.6/ddlapi/gridTravel/getTravelContributionSetup/?_travelcategorycode=1&_TravelPlanCode=" + PlanCode,
    type: 'get',
    dataType: "JSONP",
    success: function (response) {
      var len = response.length;
      for (var i = 0; i < len; i++) {
        var $TravelCoverageTypeName = response[i].TravelCoverageTypeName;
        var $TravelTanureText = response[i].TravelTanureText;
        var $TravelContribution = response[i].TravelContribution;
        $ContribuTiotable.row.add([$TravelCoverageTypeName, $TravelTanureText, $TravelContribution]).draw(false);
      }
    }
  });
});

/*For Realtion Dropdown in Family Details Section*/
$(document).ready(function () {
  $('relationtable').dataTable({
    searching: false,
    paging: false
  });
});
var table = document.getElementById('relationtable');
$('#relationtable').click(function () {
  $('#fname').focus();
});
for (var i = 1; i < table.rows.length; i++) {
  table.rows[i].onclick = function () {
    document.getElementById("fname").value = this.cells[0].innerHTML;
    document.getElementById("dob").value = this.cells[1].innerHTML;
    RelationVlaue = this.cells[3].innerHTML;
    id = document.getElementById("relation").value = RelationVlaue;
    $('#relationdropdown').val(RelationVlaue).trigger('change');
  };
}