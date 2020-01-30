$(window).load(function () {
    $("#login").validate();
});

function scroll_to_class(element_class, removed_height) {
    var scroll_to = $(element_class).offset().top - removed_height;
    if ($(window).scrollTop() != scroll_to) {
        $('html, body').stop().animate({
            scrollTop: scroll_to
        }, 0);
    }
}

function bar_progress(progress_line_object, direction) {
    var number_of_steps = progress_line_object.data('number-of-steps');
    var now_value = progress_line_object.data('now-value');
    var new_value = 0;
    if (direction == 'right') {
        new_value = now_value + (100 / number_of_steps);
    } else if (direction == 'left') {
        new_value = now_value - (100 / number_of_steps);
    }
    progress_line_object.attr('style', 'width: ' + new_value + '%;').data('now-value', new_value);
}

jQuery(document).ready(function () {

    /*
        Fullscreen background
    */


    $('#top-navbar-1').on('shown.bs.collapse', function () {
        $.backstretch("resize");
    });
    $('#top-navbar-1').on('hidden.bs.collapse', function () {
        $.backstretch("resize");
    });

    /*
        Form
    */
    $('.f1 fieldset:first').fadeIn('slow');

    
    // next step
    /* Next Step Form Validation Function */
    $('.f1 .btn-next').on('click', function () {
        var parent_fieldset = $(this).parents('fieldset');
        var next_step = true;
        // navigation steps / progress steps
        var current_active_step = $(this).parents('.f1').find('.f1-step.active');
        var progress_line = $(this).parents('.f1').find('.f1-progress-line');
        
        /*Validation For Category Dropdown*/
        var CategoryId = document.getElementById("Category-dropdown");
        if (!$(CategoryId).val() ) {
            $("select[name='category']").addClass("reqirederror");
            var disable = 1; //still disable 
            next_step = false;
        }

        /* Validation For Plan Dropdown*/
        var PlanId = document.getElementById("Plan-Dropdown");
        if (!$(PlanId).val() ) {
            $("select[name='plan']").addClass("reqirederror");
            var disable = 1; //still disable 
            next_step = false;
        }

        
        // fields validation
        parent_fieldset.find('input[type="text"], input[type="password"], textarea, input[type="number"], .select2-results__option').each(function () {
            var disable = 0; //buy default set true 
            //get value from Category
            var category=$("select[name='category']").find("option:selected").val();
            //get value from name
            var name = $("input[name='name']").val();
            //get value from Date
            var dateofbirth = $("input[name='dateofbirth']").val();
            //get value from Family Date of birth
            var familydateofbirth = $("input[name='familydateofbirth']").val();
            //get value from email
            var email = $("input[name='email']").val();
            //get value from number input
            var num = $("input[name='num']").val();
            //get value from Family Section Name input
            var fname = $("input[name='fname']").val();
            //get value from destination
            var destination = $("select[name='destination']").find("option:selected").val();
            //get value from tenure
            var tenure = $("select[name='tenure']").find("option:selected").val();
            //get value from travelling with
            var travellingwith = $("select[name='travellingwith']").find("option:selected").val();
            //get value from relationship 
            var relationship = $("select[name='relationship']").find("option:selected").val();
            //get value from travellingdate
            var travellingdate = $("input[name='travellingdate']").val();

            /* Num Max Length*/
              if( num.length >= 12 ||  num.length < 11){
                  $('#error').show();
                    var disable = 1; //still disable 
                    next_step = false;
              }
            if (travellingwith == null || travellingwith == "") {
                //add error classes on input fileds
                $("select[name='travellingwith']").addClass("reqirederror"); //by duplicate this you can add class on other fileds
                var disable = 1; //still disable 
                next_step = false;
            }
            if (destination == null || destination == "") {
                //add error classes on input fileds
                $("select[name='destination']").addClass("reqirederror"); //by duplicate this you can add class on other fileds
                var disable = 1; //still disable 
                next_step = false;
            }
            if (num == null || num == "") {
                $("input[name='num']").addClass("reqirederror"); //by duplicate this you can add class on other fileds
                var disable = 1; //still disable 
                next_step = false;
            }
            if (name == null || name == "") {
                $("input[name='name']").addClass("reqirederror"); //by duplicate this you can add class on other fileds
                var disable = 1; //still disable 
                next_step = false;
            }
            if (!dateofbirth) {
                $("input[name='dateofbirth']").addClass("reqirederror"); //by duplicate this you can add class on other fileds
                var disable = 1; //still disable 
                next_step = false;
            }
            if (!travellingdate) {
                 $("input[name='travellingdate']").addClass("reqirederror"); //by duplicate this you can add class on other fileds
                var disable = 1; //still disable 
                next_step = false;
            }
            if (tenure == null || tenure == "") {
                $("select[name='tenure']").addClass("reqirederror"); //by duplicate this you can add class on other fileds
                var disable = 1; //still disable 
                next_step = false;
            }
            var id=document.getElementById('familydetails');
            if ($("#familydetails").css("display") == "flex") {
                if (fname == null || fname == "") {
                    $("input[name='fname']").addClass("reqirederror"); //by duplicate this you can add class on other fileds
                    var disable = 1; //still disable 
                    next_step = false;
                }
                if (relationship == null || relationship == "") {
                    $("select[name='relationship']").addClass("reqirederror"); //by duplicate this you can add class on other fileds
                    var disable = 1; //still disable 
                    next_step = false;
                }
                if (!familydateofbirth) {
                    $("input[name='familydateofbirth']").addClass("reqirederror"); //by duplicate this you can add class on other fileds
                    var disable = 1; //still disable 
                    next_step = false;
                }
            }
            if(disable==0){
                $("input[name='name']").removeClass("reqirederror");//by duplicate this you can remove class
                return true;

            } 
        });
        // fields validation

        if (next_step) {
            parent_fieldset.fadeOut(400, function () {
                // change icons
                current_active_step.removeClass('active').addClass('activated').next().addClass('active');
                // progress bar
                bar_progress(progress_line, 'right');
                // show next step
                $(this).next().fadeIn();
                // scroll window to beginning of the form
                scroll_to_class($('.f1'), 20);
            });
        }

    });

    // previous step
    $('.f1 .btn-previous').on('click', function () {
        // navigation steps / progress steps
        var current_active_step = $(this).parents('.f1').find('.f1-step.active');
        var progress_line = $(this).parents('.f1').find('.f1-progress-line');

        $(this).parents('fieldset').fadeOut(400, function () {
            // change icons
            current_active_step.removeClass('active').prev().removeClass('activated').addClass('active');
            // progress bar
            bar_progress(progress_line, 'left');
            // show previous step
            $(this).prev().fadeIn();
            // scroll window to beginning of the form
            scroll_to_class($('.f1'), 20);
        });
    });

    // submit Validation
    $('.f1').on('submit', function (e) {

        // fields validation
        $(this).find('input[type="text"], input[type="password"], textarea, .f1 input[type="number"]').each(function () {
            var disable = 0; //buy default set true 
            // Payment Dropdown validation
            var PaymentMethod = $("select[name='method']").find("option:selected").val();
            // Payment Card Number validation
            var CardNum = $("input[name='card']").val();
            // Bank Name validation
            var BankName = $("input[name='bankname']").val();
            // Bank Name validation
            var ChequeBankName = $("input[name='chequebankname']").val();
            // Cheque Num validation
            var ChequeNum = $("input[name='chequeno']").val();
            // Payment Date validation
            var PaymentDate = $("input[name='paymentdate']").val();
            // Payment Date validation
            var ChequePaymentDate = $("input[name='chequepaymentdate']").val();
            // Payment Date validation
            var CashPaymentDate = $("input[name='cashpaymentdate']").val();

            if (PaymentMethod == null || PaymentMethod == "") {
                $("select[name='method']").addClass("reqirederror");
                e.preventDefault();
                return
            }
            if ($("#card").css("display") == "flex") {
                if (CardNum == null || CardNum == "") {
                    $("input[name='card']").addClass("reqirederror"); 
                    e.preventDefault();
                    disable = 1;
                }
                if (BankName == null || BankName == "") {
                    $("input[name='bankname']").addClass("reqirederror"); 
                    e.preventDefault();
                    disable = 1;
                }
                if (!PaymentDate) {
                    $("input[name='paymentdate']").addClass("reqirederror"); //by duplicate this you can add class on other fileds
                    e.preventDefault();
                    disable = 1;
                }
            }
            if ($("#debit").css("display") == "flex") {
                if (CardNum == null || CardNum == "") {
                    $("input[name='card']").addClass("reqirederror"); 
                    e.preventDefault();
                    disable = 1;
                }
                if (BankName == null || BankName == "") {
                    $("input[name='bankname']").addClass("reqirederror"); 
                    e.preventDefault();
                    disable = 1;
                }
                if (!PaymentDate) {
                    $("input[name='paymentdate']").addClass("reqirederror"); //by duplicate this you can add class on other fileds
                    e.preventDefault();
                    disable = 1;
                }
            }
            if ($("#cheque").css("display") == "flex") {
                if (ChequeNum == null || ChequeNum == "") {
                    $("input[name='chequeno']").addClass("reqirederror"); 
                    e.preventDefault();
                    disable = 1;
                }
                if (ChequeBankName == null || ChequeBankName == "") {
                    $("input[name='chequebankname']").addClass("reqirederror"); 
                    e.preventDefault();
                    disable = 1;
                }
                if (!ChequePaymentDate) {
                    $("input[name='chequepaymentdate']").addClass("reqirederror"); //by duplicate this you can add class on other fileds
                    e.preventDefault();
                    disable = 1;
                }
            }
            if ($("#cash").css("display") == "flex") {
                if (!CashPaymentDate) {
                    $("input[name='cashpaymentdate']").addClass("reqirederror"); //by duplicate this you can add class on other fileds
                    e.preventDefault();
                    disable = 1;
                }
            }
            if(disable == 0){
                consile.log("hello");
            }
        });
        // fields validation

    });


});
