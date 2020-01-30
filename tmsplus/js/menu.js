//Get Url Parameters
$.urlParam = function(name){
   var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
   if (results==null) {
      return null;
   }
   return decodeURI(results[1]) || 0;
}
var $tokenparameters=$.urlParam('token');
var $useridparameters=$.urlParam('userid');


//  Menu Links


var MotorProductSetupLink = "motorproductsetup.html";
var MotorProductSetupParameter = "?token=" + $tokenparameters+ "&userid=" +$useridparameters;
var result = MotorProductSetupLink + MotorProductSetupParameter;
$('#MotorProductSetupLink').attr('href', result);

var MasterCodeLink = "mastercodes.html";
var MasterCodeLinkParameter = "?token=" + $tokenparameters+ "&userid=" +$useridparameters;
var result = MasterCodeLink + MasterCodeLinkParameter;
$('#MasterCodeLink').attr('href', result);

var OpPolicyLink = "openpolicy.html";
var OpPolicyLinkParameter = "?token=" + $tokenparameters+ "&userid=" +$useridparameters;
var result = OpPolicyLink + OpPolicyLinkParameter;
$('#OpPolicyLink').attr('href', result);

var MotorPolicyLink = "motorpolicy.html";
var MotorPolicyLinkParameter = "?token=" + $tokenparameters+ "&userid=" +$useridparameters;
var result = MotorPolicyLink + MotorPolicyLinkParameter;
$('#MotorPolicyLink').attr('href', result);


var EndorsementLink = "endorsement.html";
var EndorsementLinkParameter = "?token=" + $tokenparameters+ "&userid=" +$useridparameters;
var result = EndorsementLink + EndorsementLinkParameter;
$('#EndorsementLink').attr('href', result);

var CertificateLink = "certificate.html";
var CertificateParameter = "?token=" + $tokenparameters+ "&userid=" +$useridparameters;
var result = CertificateLink + CertificateParameter;
$('#CertificateLink').attr('href', result);


var RenewalLink = "renewal.html";
var RenewalLinkParameter = "?token=" + $tokenparameters+ "&userid=" +$useridparameters;
var result = RenewalLink + RenewalLinkParameter;
$('#RenewalLink').attr('href', result);

var NFendorsement = "nfendorsement.html";
var NFendorsementLinkParameter = "?token=" + $tokenparameters+ "&userid=" +$useridparameters;
var result = NFendorsement + NFendorsementLinkParameter;
$('#nfEndorsementLink').attr('href', result);