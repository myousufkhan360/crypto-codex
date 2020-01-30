<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %> 

<!DOCTYPE html>

<html>

<head runat="server">

    <meta name="viewport" content="width=device-width" />

    <title>Images</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">

</head>

<body>

<div class="container" style="background-color: #E0E0E0; margin-top: 10px;">

    <%

        using (Html.BeginForm("", "home", FormMethod.Post, new { enctype = 

            "multipart/form-data" }))

        {%>
        
        <h2>Uploading Images to Server Via WebAPI</h2>
        
        <br/>
        
      <p>Uplodaing Multiple Images at a once: </p>
        
        <br/>
    
        <label> Image#1 :
        <input type="file" name="FileUpload1" />
        </label>
        <br />
        <br/>
        

        <label> Image#2 :
        <input type="file" name="FileUpload2" />
        </label>
        <br />
        <br/>
        
        <label> Image#3 :
        <input type="file" name="FileUpload3" /><br />
        </label>
        
        <br/>


        <input type="submit" name="Submit" id="Submit" value="SendToServer" class="btn btn-dark" /><br />

    <% }%>
    <br/>

</div>
    
    <hr/>

    <div class="container">

    <h5 style="color: red"><a href="/Home/DownloadImage">Downloading Image from Server</a></h5>

    </div>
    
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>

</body>

</html>