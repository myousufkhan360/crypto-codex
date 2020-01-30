$( "#bttn" ).click(function(event) {
   event.preventDefault();
  var $username=$("input[name='username']").val();
  var $password =$("input[name='pass']").val();
  var $Credentialobj = { 
     UserId :$username,
     UserPassword:$password,
  }
  var $Credential = JSON.stringify($Credentialobj);
  $.get( "http://207.180.200.121/crmapi/Users/ValidateUserCredentials/?_userinfo=" +$Credential , function( data ) {
      $Token=data.Token;
      if($Token){
        window.location = "motorproductsetup.html?token="+ $Token +"&userid=" +$username;
      }else{
        document.getElementById("errorsec").innerHTML = '<span class="error-text">Username or Password is Incorrect</span>';
      }
  });
});