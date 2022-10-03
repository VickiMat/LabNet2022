function validateRequiredField(fieldId, fieldName, errorMessage) {
    field = document.querySelector("#" + fieldId);

    if (field?.value == null || field?.value?.length == 0){
        field = document.querySelector("#" + errorMessage).innerHTML = fieldName + " is required!";
        return false;
    }
    field = document.querySelector("#" + errorMessage).innerHTML = "";
    return true;
}


function validatePasswordLong(fieldId, password, errorMessage){
    
    if (validateRequiredField(fieldId, password, errorMessage)){
        field = document.querySelector("#" + fieldId);

        if(field.value.length < 6){
            field = document.querySelector("#" + errorMessage).innerHTML = "The password must be at least 6 characters!";
            return false;
        }
        field = document.querySelector("#" + errorMessage).innerHTML = "";
        return true;
    }
}

function validateMail(emailField, email, errorMessage){
    if (validateRequiredField(emailField ,email, errorMessage)){
        email = document.getElementById(emailField);
        var validRegex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        if (!email.value.match(validRegex)){
            document.getElementById(errorMessage).innerHTML = "Invalid e-mail format.";
            return false;
        } else{
            document.getElementById(errorMessage).innerHTML = "";
            return true;
        }
    }
}

function validateForm() 
{                 
    validFirstName = validateRequiredField("first-name","First name", "messageFN");
    validLastName = validateRequiredField("last-name", "Last name", "messageLN");
    validUsername = validateRequiredField("username", "User name", "messageUN");
    validPassword = validatePasswordLong("password", "Password", "messageP")
    validEmail = validateMail("mail", "E-mail", "messageM");
  

    if(validFirstName && validLastName && validEmail && validUsername && validPassword) {
        location.href = "submit.html"
    } else { 
        return false; 
    }
}

function resetForm(){
    document.querySelector("#contact").reset();
}



function getGift(){
    location.href = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
}