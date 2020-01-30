
 $(document).ready(function(){ 
     $(window).scroll(function(){ 
         if ($(this).scrollTop() > 100) { 
             $('#topscroll').fadeIn(); 
         } else { 
             $('#topscroll').fadeOut(); 
         } 
     }); 
     $('#topscroll').click(function(){ 
         $("html, body").animate({ scrollTop: 0 }, 800); 
         return false; 
     }); 
 });
 $(document).ready(function(){ 
     $(window).scroll(function(){ 
         if ($(this).scrollTop() > 50) { 
             $('#bottomscroll').fadeIn(); 
         } else { 
             $('#bottomscroll').fadeOut(); 
         } 
     }); 
     $('#bottomscroll').click(function(){ 
         $("html, body").animate({ scrollTop: 5000 }, 600); 
         return false; 
     }); 
 });