// Event handling
document.addEventListener("DOMContentLoaded",
  function (event) {
    
    // Unobtrusive event binding
    document.querySelector("button")
      .addEventListener("click", function () {
        var self = this;
        var name = '';
        // Call server to get the name
        $ajaxUtils
          .sendGetRequest("data/name.txt", 
            function (request) {
              name = request.responseText;
              console.log('this',self);
          });
            setTimeout(() => {
               document.querySelector("#content")
              .innerHTML = "<h2>Hello " + name + "!</h2>";
            }, 2000);

            
        
      });
  }
);





