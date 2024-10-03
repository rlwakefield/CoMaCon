/********************************************************
*              Login/Logout Page Functions
********************************************************/
function resetLoginErrorTextFields() {
    Array.from(document.getElementsByClassName("loginerrortext")).forEach(element => {
        element.innerText = "";
    });
}

function login(event) {
    event.preventDefault(); // Prevent the default form submission
    let loginCredentials = {
        username: document.getElementById("username").value,
        password: document.getElementById("password").value
    };

    fetch(sessionStorage.getItem('apiRootUrl') + '/api/Endpoint/Authentication', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(loginCredentials)
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                return response.json().then(errorData => {
                    switch (errorData.error) {
                        case "1":
                            //Missing Username
                            document.getElementById("username-errortext").innerText = errorData.message;
                            break;
                        case "2":
                            //Missing Password
                            document.getElementById("password-errortext").innerText = errorData.message;
                            break;
                        case "3":
                            //Invalid Username or Password
                            document.getElementById("genericloginerror").innerText = errorData.message;
                            break;
                        case "4":
                            //Multiple users found with the same username/password.
                            document.getElementById("genericloginerror").innerText = errorData.message;
                            break;
                        case "5":
                            //Account is disabled.
                            document.getElementById("genericloginerror").innerText = errorData.message;
                            break;
                        case "9":
                            //User required to reset password.
                            document.getElementById("passwordresetformcontainer-outer").style.display = "block";
                            document.getElementById("currentpassword").focus();
                            break;
                        default:
                            //Unknown error occured.
                            document.getElementById("genericloginerror").innerText = errorData.message;
                            break;
                    }
                    throw errorData;
                });
            }
        })
        .then(data => {
            sessionStorage.setItem("comaconbearertoken", data.access_token);
            window.location.href = sessionStorage.getItem('apiRootUrl') + '/core/home';
        })
        .catch(error => {
            console.error('Error:', error.message);
        });
}

function logout() {
    const logoutFetchOptions = {
        method: "GET",
        headers: {
            'Authorization': 'Bearer ' + sessionStorage.getItem('comaconbearertoken')
        }
    };
    if (configurationChanged == true) {
        if (confirm("You have unsaved changes. Are you sure you want to ignore them?") == true) {
            //true = Yes/Ok
            fetch(apiRootUrl + "/api/Endpoint/Logout", logoutFetchOptions)
                .then(response => {
                    if (response.redirected) {
                        sessionStorage.removeItem('comaconbearertoken');
                        // Handle the redirect
                        window.location.href = sessionStorage.getItem('apiRootUrl') + response.url;
                    }
                })
                .catch(error => console.error('Error:', error));
        }
    } else {
        //false = No/Cancel
        fetch(apiRootUrl + "/api/Endpoint/Logout", logoutFetchOptions)
            .then(response => {
                if (response.redirected) {
                    sessionStorage.removeItem('comaconbearertoken');
                    // Handle the redirect
                    console.log(response.url);
                    window.location.href = response.url;
                }
            })
            .catch(error => console.error('Error:', error));
    }
}

function checkPasswordMatch(input) {
    const newPassword = document.getElementsByName("newpassword")[0].value;
    const confirmPassword = input.value;

    if (newPassword === confirmPassword && document.getElementById("newpassword").validity.valid) {
        document.getElementById("passwordMatchMessage").textContent = "Passwords match";
        document.getElementById("passwordMatchMessage").style.color = "green";
        document.getElementById("resetpasswordbutton").disabled = false;
    } else {
        document.getElementById("passwordMatchMessage").textContent = "Passwords do not match";
        document.getElementById("passwordMatchMessage").style.color = "red";
        document.getElementById("resetpasswordbutton").disabled = true;
    }
}

function closePasswordResetModal() {
    document.getElementById("passwordresetformcontainer-outer").style.display = "none";
    document.getElementById("passwordMatchMessage").textContent = "";
    document.getElementById("confirmpassword").style.border = "inherit";
}

function resetpassword(event) {
    event.preventDefault();
    let userobject = {
        username: document.getElementById("username").value,
        currentpassword: document.getElementById("currentpassword").value,
        newpassword: document.getElementById("newpassword").value
    };

    const passwordresetoptions = {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userobject),
    };
    fetch(sessionStorage.getItem('apiRootUrl') + "/api/Endpoint/ResetPassword", passwordresetoptions)
        .then(response => {
            if (!response.ok) {
                return response.json().then(data => {
                    document.getElementById("passwordreseterror").textContent = data["message"];
                    document.getElementById("passwordresetform").reset();
                    document.getElementById("currentpassword").focus();
                    document.getElementById("passwordMatchMessage").textContent = "";
                });
            } else {
                closePasswordResetModal();
                successfulSave();
                document.getElementById("passwordresetform").reset();
                document.getElementById("login-form").reset();
            }
        })
        .catch(error => console.error('Error:', error));
}

//function forgotpassword(event) {
//    event.preventDefault();
//    let forgotpasswordobject = {
//        username: document.getElementById("forgotpasswordusername").value,
//        emailaddress: document.getElementById("forgotpasswordemail").value
//    };

//    const forgotpasswordoptions = {
//        method: "POST",
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify(forgotpasswordobject),
//    };
//    fetch(sessionStorage.getItem('apiRootUrl') + "/api/Endpoint/ForgotPassword", forgotpasswordoptions)
//        .then(response => response.json())
//        .then(data => console.log(data))
//        .catch(error => console.error('Error:', error));
//}

//function openForgotPasswordModal() {
//    document.getElementById("forgotpasswordformcontainer-outer").style.display = "block";
//}

//function closeForgotPasswordModal() {
//    document.getElementById("forgotpasswordformcontainer-outer").style.display = "none";
//}

//function validateForgotPasswordFieldsAreFilledIn() {
//    if (document.getElementById("forgotpasswordusername").value != "" && document.getElementById("forgotpasswordemail").checkValidity() == true) {
//        document.getElementById("forgotpasswordbutton").disabled = false;
//    } else {
//        document.getElementById("forgotpasswordbutton").disabled = true;
//    }
//}

function resetpasswordreseterrorfield() {
    document.getElementById("passwordreseterror").textContent = "";
}