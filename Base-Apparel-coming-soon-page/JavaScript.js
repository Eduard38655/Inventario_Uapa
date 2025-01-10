function submit() {
   let take_tex = document.getElementById("take_text")
     let input_container = document.getElementById("input-container")
 
     let insert=document.getElementById("insert");
     let message=document.getElementById("error_mes")
     let isValid = true;  
     let take=take_tex.value;
 
   if (take === "" || take.length <= 15 || !take.includes("@") || !take.includes(".com") || !take.includes("gmail")) {
     isValid = false;  
   }
    
   if (isValid) {
      alert("Válid");
 
    } else {
      message.classList.add("error_me");
    insert.innerHTML="Please provide a valid email";
      input_container.classList.add("box-input-container");
      alert("Error: Text must be less than 10 in length, contain the characters '@' and '.'")
    }
 }
  
  
 