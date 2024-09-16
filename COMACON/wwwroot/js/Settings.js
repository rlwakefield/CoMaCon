let allusers = [];
let rolesdata = [];

let actionscellhtml = `<td class="actionscell">
                                    <button id="ViewUser" onclick="displayNewAndEditUserModal('view',event)">
                                        <svg width="20" height="20" fill="none" stroke="#000000" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" class="dark_mode_svg">
                                            <path d="M21.257 10.962c.474.62.474 1.457 0 2.076C19.764 14.987 16.182 19 12 19c-4.182 0-7.764-4.013-9.257-5.962a1.692 1.692 0 0 1 0-2.076C4.236 9.013 7.818 5 12 5c4.182 0 7.764 4.013 9.257 5.962z"></path>
                                            <path d="M12 9a3 3 0 1 0 0 6 3 3 0 1 0 0-6z"></path>
                                        </svg>
                                    </button>
                                    <button id="EditUser" onclick="displayNewAndEditUserModal('edit',event)">
                                        <svg width="16" height="16" fill="none" stroke="#000000" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" class="dark_mode_svg">
                                            <path d="M4.333 16.048 16.57 3.81a2.56 2.56 0 0 1 3.62 3.619L7.951 19.667a2 2 0 0 1-1.022.547L3 21l.786-3.93a2 2 0 0 1 .547-1.022z"></path>
                                            <path d="m14.5 6.5 3 3"></path>
                                        </svg>
                                    </button>`;
                                //    <!-- Hamburger SVG -->
                                //    <!-- <svg width="16" height="16" fill="none" stroke="#000000" stroke-linecap="round" stroke-linejoin="round" stroke-width="2.5" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                                //        <path d="M3 6h18M3 12h18M3 18h18"></path>
                                //    </svg> -->
                                //</td>
//`<button id="DeleteUser" onclick="displayDeleteUserConfirmationModal(event)">
//                                        <svg width="16" height="16" fill="none" stroke="#000000" stroke-linecap="round" stroke-linejoin="round" stroke-width="2.5" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
//                                            <path d="M4 6h16l-1.58 14.22A2 2 0 0 1 16.432 22H7.568a2 2 0 0 1-1.988-1.78L4 6z"></path><path d="M7.345 3.147A2 2 0 0 1 9.154 2h5.692a2 2 0 0 1 1.81 1.147L18 6H6l1.345-2.853z"></path>
//                                            <path d="M2 6h20"></path>
//                                            <path d="M10 11v5"></path>
//                                            <path d="M14 11v5"></path>
//                                        </svg>
//                                    </button>`

function activateSettingsButton(button) {
    switch (button.id) {
        case 'General':
            document.getElementById("settings-content-users").style.display = "none";
            break;
        case "Users":
            document.getElementById("settings-content-users").style.display = "flex";
            document.getElementById("all").checked = true;
            break;
    }
    let settingsButtons = document.querySelectorAll('.settings-category');
    settingsButtons.forEach((settingsButton) => {
        settingsButton.classList.remove('active');
    });
    button.classList.add('active');

    const getAllusersFetchOptions = {
        method: "GET",
        headers: {
            'Authorization': 'Bearer ' + sessionStorage.getItem('comaconbearertoken'),
            'Content-Type': 'application/json'
        }
    };
    fetch(apiRootUrl + "/api/Endpoint/GetAllUsers?version=v1", getAllusersFetchOptions)
        .then(response => response.json())
        .then(data => {
            //console.log(data["users"]);
            allusers = data["users"];
            //Clear the table.
            let table = document.getElementById("UsersTable");
            let tbody = table.querySelector("tbody");
            tbody.innerHTML = "";
            //Add the users to the table.
            Array.from(data["users"]).forEach((user) => {
                let row = tbody.insertRow();
                //Add the usernum cell to the row.
                let usernumcell = row.insertCell();
                usernumcell.classList.add("usernumcell");
                usernumcell.innerText = user.usernum;
                //Add the lastname cell to the row.
                let lastnamecell = row.insertCell();
                lastnamecell.classList.add("lastnamecell");
                lastnamecell.innerText = user.lastname;
                //Add the firstname cell to the row.
                let firstnamecell = row.insertCell();
                firstnamecell.classList.add("firstnamecell");
                firstnamecell.innerText = user.firstname;
                //Add the username cell to the row.
                let usernamecell = row.insertCell();
                usernamecell.classList.add("usernamecell");
                usernamecell.innerText = user.username;
                //Add the role cell to the row.
                let rolecell = row.insertCell();
                rolecell.classList.add("rolecell");
                rolecell.innerText = "Admin";
                //Add the enabled cell to the row.
                let enabledcell = row.insertCell();
                enabledcell.classList.add("enabledcell");
                enabledcell.innerText = user.enabled == 1 ? "Yes" : "No";
                //Add the actions cell to the row.
                let actionscell = row.insertCell();
                actionscell.classList.add("actionscell");
                actionscell.innerHTML = actionscellhtml;
            });
        })
        .catch(error => {
            console.error('Error:', error);
        });

    const getRolesFetchOptions = {
        method: "GET",
        headers: {
            'Authorization': 'Bearer ' + sessionStorage.getItem('comaconbearertoken'),
            'Content-Type': 'application/json'
        }
    };
    fetch(apiRootUrl + '/api/Endpoint/GetRoles?version=v1', getRolesFetchOptions)
        .then(response => response.json())
        .then(data => {
            if (data["roles"].length > 0) {
                let roleselect = document.getElementById("Role");
                roleselect.innerHTML = "";
                rolesdata = data["roles"];
                Array.from(data["roles"]).forEach((role) => {
                    let roleoption = document.createElement("option");
                    roleoption.value = role.roleid;
                    roleoption.innerText = role.rolename;
                    roleselect.appendChild(roleoption);
                });
            }
        })
        .catch(error => console.error('Error:', error));
}

function displayNewAndEditUserModal(action, event) {
    switch (action) {
        case "new":
            document.getElementById("NewAndEditingUserModal").style.display = "block";
            Array.from(document.getElementsByClassName("UserDetails-InputField")).forEach((inputField) => {
                inputField.required = true;
            });
            document.getElementById("NewAndEditingUserModal-Action").innerText = "Create New User";
            document.getElementById("Usernum-Paragraph").style.display = "none";
            document.getElementById("CreationDateCreatedBy-Paragraph").style.display = "none";
            document.getElementById("LastEditedOnLastEditedBy-Paragraph").style.display = "none";
            document.getElementById("SaveViewAndEditUserModal").innerText = "Create";
            break;
        case "view":
            // Find the closest table row (tr) from the clicked button
            var row = event.target.closest("tr");
            // Get the Usernum value from the first cell in the row
            var usernum = row.querySelector(".usernumcell").textContent.trim();
            // Output the Usernum value (for example, to the console)
            let viewUserfound = allusers.find(user => user.usernum == usernum);
            document.getElementById("NewAndEditingUserModal-Action").innerText = "Viewing User";
            document.getElementById("Usernum-Paragraph").style.display = "inline";
            document.getElementById("CreationDateCreatedBy-Paragraph").style.display = "block";
            document.getElementById("LastEditedOnLastEditedBy-Paragraph").style.display = "block";
            document.getElementById("Usernum").innerText = viewUserfound.usernum;
            document.getElementById("CreatedBy").innerText = viewUserfound.createdby;
            document.getElementById("CreationDate").innerText = viewUserfound.creationdate;
            document.getElementById("LastEditedBy").innerText = viewUserfound.lasteditedby;
            document.getElementById("LastEditedDate").innerText = viewUserfound.lastediteddate;
            document.getElementById("Username").value = viewUserfound.username;
            document.getElementById("FirstName").value = viewUserfound.firstname;
            document.getElementById("LastName").value = viewUserfound.lastname;
            document.getElementById("Email").value = viewUserfound.emailaddress;
            document.getElementById("Password").value = "";
            document.getElementById("Enabled").checked = viewUserfound.enabled == 1 ? true : false;
            document.getElementById("ResetPasswordonNextLogin").checked = viewUserfound.passwordresetonnextlogin == 1 ? true : false;
            document.getElementById("AuthMethod").value = viewUserfound.authmethod;
            document.getElementById("NewAndEditingUserModal").style.display = "block";
            Array.from(document.getElementsByClassName("UserDetails-InputField")).forEach((inputField) => {
                let inputelement = inputField.querySelector("input");
                if (inputelement != null) {
                    if (inputelement.type === "checkbox") {
                        inputelement.disabled = true;
                    } else {
                        inputelement.readOnly = true;
                    }
                } else {
                    inputelement = inputField.querySelector("select");
                    inputelement.disabled = true;
                }
            });
            document.getElementById("SaveViewAndEditUserModal").style.display = "none";
            document.getElementById("CancelViewAndEditUserModal").innerText = "Close";
            break;
        case "edit":
            // Find the closest table row (tr) from the clicked button
            var row = event.target.closest("tr");
            // Get the Usernum value from the first cell in the row
            var usernum = row.querySelector(".usernumcell").textContent.trim();
            // Output the Usernum value (for example, to the console)
            let editUserfound = allusers.find(user => user.usernum == usernum);
            document.getElementById("NewAndEditingUserModal-Action").innerText = "Editing User";
            document.getElementById("Usernum-Paragraph").style.display = "inline";
            document.getElementById("CreationDateCreatedBy-Paragraph").style.display = "block";
            document.getElementById("LastEditedOnLastEditedBy-Paragraph").style.display = "block";
            document.getElementById("Usernum").innerText = editUserfound.usernum;
            document.getElementById("CreatedBy").innerText = editUserfound.createdby;
            document.getElementById("CreationDate").innerText = editUserfound.creationdate;
            document.getElementById("LastEditedBy").innerText = editUserfound.lasteditedby;
            document.getElementById("LastEditedDate").innerText = editUserfound.lastediteddate;
            document.getElementById("Username").value = editUserfound.username;
            document.getElementById("FirstName").value = editUserfound.firstname;
            document.getElementById("LastName").value = editUserfound.lastname;
            document.getElementById("Email").value = editUserfound.emailaddress;
            document.getElementById("Password").value = "";
            document.getElementById("Enabled").checked = editUserfound.enabled == 1 ? true : false;
            document.getElementById("ResetPasswordonNextLogin").checked = editUserfound.passwordresetonnextlogin == 1 ? true : false;
            document.getElementById("AuthMethod").value = editUserfound.authmethod;
            document.getElementById("NewAndEditingUserModal").style.display = "block";
            document.getElementById("SaveViewAndEditUserModal").innerText = "Update";
            //Add the appropriate event listeners to the input fields so that when one is changed, it enables the Save button.
            Array.from(document.getElementsByClassName("UserDetails-InputField")).forEach((inputField) => {
                let inputelement = inputField.querySelector("input");
                if (inputelement != null) {
                    if (inputelement.type === "checkbox") {
                        inputelement.addEventListener("click", function () {
                            document.getElementById("SaveViewAndEditUserModal").disabled = false;
                        });
                    }
                } else {
                    inputelement = inputField.querySelector("select");
                    inputelement.addEventListener("input", function () {
                        document.getElementById("SaveViewAndEditUserModal").disabled = false;
                    });
                }
            });
            break;
    }
}

async function closeNewAndEditUserModal() {
    document.getElementById("NewAndEditingUserModal").style.display = "none";
    Array.from(document.getElementsByClassName("UserDetails-InputField")).forEach((inputField) => {
        let inputelement = inputField.querySelector("input");
        if (inputelement != null) {
            if (inputelement.type === "checkbox") {
                inputelement.disabled = false;
            } else {
                inputelement.readOnly = false;
            }
        } else {
            inputelement = inputField.querySelector("select");
            inputelement.disabled = false;
        }
    });
    document.getElementById("Usernum-Paragraph").style.display = "none";
    document.getElementById("CreationDateCreatedBy-Paragraph").style.display = "none";
    document.getElementById("LastEditedOnLastEditedBy-Paragraph").style.display = "none";
    document.getElementById("Usernum").innerText = "";
    document.getElementById("CreatedBy").innerText = "";
    document.getElementById("CreationDate").innerText = "";
    document.getElementById("LastEditedBy").innerText = "";
    document.getElementById("LastEditedDate").innerText = "";
    document.getElementById("CancelViewAndEditUserModal").innerText = "Cancel";
    document.getElementById("SaveViewAndEditUserModal").innerHTML = "";
    document.getElementById("SaveViewAndEditUserModal").innerText = "Save";
    document.getElementById("SaveViewAndEditUserModal").style.display = "block";
}

async function saveUser(event) {
    event.preventDefault();
    let table = document.getElementById("UsersTable");
    let tbody = table.querySelector("tbody");
    switch (document.getElementById("NewAndEditingUserModal-Action").innerText) {
        case "Create New User":
            //Add new user to the allusers array.
            let newuser = {
                usernum: allusers.length + 1, //This will need to be changed to the next available usernum from the database.
                username: document.getElementById("Username").value,
                firstname: document.getElementById("FirstName").value,
                lastname: document.getElementById("LastName").value,
                password: document.getElementById("Password").value,
                emailaddress: document.getElementById("Email").value,
                enabled: document.getElementById("Enabled").checked ? 1 : 0,
                passwordresetonnextlogin: document.getElementById("ResetPasswordonNextLogin").checked ? 1 : 0,
                passwordlastchanged: "",
                authmethod: document.getElementById("AuthMethod").value,
                creationdate: "",
                createdby: "",
                lastediteddate: "",
                lasteditedby: "",
                roleid: document.getElementById("Role").value
            };
            //console.log(JSON.stringify(newuser));
            //console.log(sessionStorage.getItem('comaconbearertoken'));
            const createUserFetchOptions = {
                method: "POST",
                headers: {
                    'Authorization': 'Bearer ' + sessionStorage.getItem('comaconbearertoken'),
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(newuser)
            }
            fetch(apiRootUrl + "/api/Endpoint/CreateUser?version=v1", createUserFetchOptions)
                .then(response => {
                    if (response.ok) {
                        return response.json().then(data => {
                            newuserdatareturned = data["users"][0];
                            console.log(data);
                            newuser.usernum = newuserdatareturned.usernum;
                            newuser.username = newuserdatareturned.username;
                            newuser.firstname = newuserdatareturned.firstname;
                            newuser.lastname = newuserdatareturned.lastname;
                            newuser.emailaddress = newuserdatareturned.emailaddress;
                            newuser.enabled = newuserdatareturned.enabled;
                            newuser.passwordresetonnextlogin = newuserdatareturned.passwordresetonnextlogin;
                            newuser.authmethod = newuserdatareturned.authmethod;
                            newuser.creationdate = newuserdatareturned.creationdate;
                            newuser.createdby = newuserdatareturned.createdby;
                            newuser.lastediteddate = newuserdatareturned.lastediteddate;
                            newuser.lasteditedby = data.lasteditedby;
                            newuser.roleid = newuserdatareturned.roleid;

                            allusers.push(newuser);
                            (async () => {
                                await addNewUserToTable(newuser, tbody)
                                document.getElementById("CancelViewAndEditUserModal").click();
                            })();
                        })
                    }
                })
                .catch(error => console.error('Error:', error));
            break;
        case "Editing User":
            //Find the user in the allusers array.
            let editUserfound = allusers.find(user => user.usernum == document.getElementById("Usernum").innerText);
            document.getElementById("SaveViewAndEditUserModal").innerHTML = '<div class="neweditinguserloader"></div>';
            document.getElementById("SaveViewAndEditUserModal").disabled = true;
            let usertoupdate = {
                usernum: editUserfound.usernum,
                username: editUserfound.username == document.getElementById("Username").value ? null : document.getElementById("Username").value,
                firstname: editUserfound.firstname == document.getElementById("FirstName").value ? null : document.getElementById("FirstName").value,
                lastname: editUserfound.lastname == document.getElementById("LastName").value ? null : document.getElementById("LastName").value,
                password: document.getElementById("Password").value == "" ? null : document.getElementById("Password").value,
                emailaddress: editUserfound.emailaddress == document.getElementById("Email").value ? null : document.getElementById("Email").value,
                passwordresetonnextlogin: editUserfound.passwordresetonnextlogin == (document.getElementById("ResetPasswordonNextLogin").checked ? 1 : 0) ? null : (document.getElementById("ResetPasswordonNextLogin").checked ? 1 : 0),
                enabled: editUserfound.enabled == (document.getElementById("Enabled").checked ? 1 : 0) ? null : (document.getElementById("Enabled").checked ? 1 : 0),
                authmethod: editUserfound.authmethod == document.getElementById("AuthMethod").value ? null : document.getElementById("AuthMethod").value,
                roleid: editUserfound.roleid == document.getElementById("Role").value ? null : document.getElementById("Role").value
            }
            console.log("User to update: ");
            console.log(usertoupdate);

            const updateUserFetchOptions = {
                method: "PUT",
                headers: {
                    'Authorization': 'Bearer ' + sessionStorage.getItem('comaconbearertoken'),
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(usertoupdate)
            };
            console.log(apiRootUrl + "/api/Endpoint/UpdateUser?version=v1");
            fetch(apiRootUrl + "/api/Endpoint/UpdateUser?version=v1", updateUserFetchOptions)
                .then(response => {
                    if (response.ok) {
                        return response.json().then(data => {
                            console.log(data["users"]);
                            //Update the user's details in the allusers array.
                            datatoupdatefrom = data["users"][0];
                            (async () => {
                                await updateUserDetailsInAllUsersArray(editUserfound, datatoupdatefrom);
                                await updateUserDetailsInTable(editUserfound, tbody);
                                document.getElementById("CancelViewAndEditUserModal").click();
                            })();
                            //Update the user's details in the table.
                            (async () => {
                                await updateUserDetailsInTable(editUserfound, tbody);
                            })();
                        })
                    }
                })
                .catch(error => console.error('Error:', error));
    }
}

async function addNewUserToTable(newuser, tbody) {
    //Add new user to the table.
    let row = tbody.insertRow();
    //Add the usernum cell to the row.
    let usernumcell = row.insertCell();
    usernumcell.classList.add("usernumcell");
    usernumcell.innerText = newuser.usernum;
    //Add the lastname cell to the row.
    let lastnamecell = row.insertCell();
    lastnamecell.classList.add("lastnamecell");
    lastnamecell.innerText = newuser.lastname;
    //Add the firstname cell to the row.
    let firstnamecell = row.insertCell();
    firstnamecell.classList.add("firstnamecell");
    firstnamecell.innerText = newuser.firstname;
    //Add the username cell to the row.
    let usernamecell = row.insertCell();
    usernamecell.classList.add("usernamecell");
    usernamecell.innerText = newuser.username;
    //Add the role cell to the row.
    let rolecell = row.insertCell();
    rolecell.classList.add("rolecell");
    rolecell.innerText = "Admin";
    //Add the enabled cell to the row.
    let enabledcell = row.insertCell();
    enabledcell.classList.add("enabledcell");
    enabledcell.innerText = newuser.enabled == 1 ? "Yes" : "No";
    //Add the actions cell to the row.
    let actionscell = row.insertCell();
    actionscell.classList.add("actionscell");
    actionscell.innerHTML = actionscellhtml;
}

async function updateUserDetailsInAllUsersArray(editUserfound, datatoupdatefrom) {
    editUserfound.username = datatoupdatefrom.username;
    editUserfound.firstname = datatoupdatefrom.firstname;
    editUserfound.lastname = datatoupdatefrom.lastname;
    editUserfound.emailaddress = datatoupdatefrom.emailaddress;
    editUserfound.enabled = datatoupdatefrom.enabled;
    editUserfound.passwordresetonnextlogin = datatoupdatefrom.passwordresetonnextlogin;
    editUserfound.authmethod = datatoupdatefrom.authmethod;
    editUserfound.lastediteddate = datatoupdatefrom.lastediteddate;
    editUserfound.lasteditedby = datatoupdatefrom.lasteditedby;
    editUserfound.roleid = datatoupdatefrom.roleid;
}

async function updateUserDetailsInTable(editUserfound, tbody) {
    let rows = tbody.querySelectorAll("tr");
    rows.forEach((row) => {
        let cell = row.querySelector(".usernumcell");
        if (cell.textContent.trim() == editUserfound.usernum) {
            let cells = row.querySelectorAll("td");
            cells[1].innerText = editUserfound.lastname;
            cells[2].innerText = editUserfound.firstname;
            cells[3].innerText = editUserfound.username;
            cells[4].innerText = rolesdata.find(role => role.roleid == editUserfound.roleid).rolename;
            cells[5].innerText = editUserfound.enabled == 1 ? "Yes" : "No";
        }
    });
}

function validateNotADuplicateUsername(field) {
    let found = allusers.find(user => user.username == field.value);
    if (found != null) {
        document.getElementById("UsernameError").innerText = "Username already exists.";
        //Disable the Save button.
        document.getElementById("SaveViewAndEditUserModal").disabled = true;
        //Remove the bottom margin from the Username input field's parent div.
        field.parentElement.style.margin = "1rem 1rem 0 1rem";
        //Add the margin of 1rem to the UsernameError element.
        document.getElementById("UsernameError").style.margin = "1rem";
    } else {
        document.getElementById("UsernameError").innerText = "";
        //Enable the Save button.
        document.getElementById("SaveViewAndEditUserModal").disabled = false;
        //Add the bottom margin back to the Username input field's parent div.
        field.parentElement.style.margin = "1rem";
        //Remove the margin of 1rem from the UsernameError element.
        document.getElementById("UsernameError").style.margin = "0";
    }
}

function filterUsers(filterValue) {
    //This function is called when the radio buttons are clicked.
    let table = document.getElementById("UsersTable");
    let tbody = table.querySelector("tbody");
    //Clear the table.
    tbody.innerHTML = "";
    switch (filterValue) {
        case "all":
            Array.from(allusers).forEach((user) => {
                let row = tbody.insertRow();
                //Add the usernum cell to the row.
                let usernumcell = row.insertCell();
                usernumcell.classList.add("usernumcell");
                usernumcell.innerText = user.usernum;
                //Add the lastname cell to the row.
                let lastnamecell = row.insertCell();
                lastnamecell.classList.add("lastnamecell");
                lastnamecell.innerText = user.lastname;
                //Add the firstname cell to the row.
                let firstnamecell = row.insertCell();
                firstnamecell.classList.add("firstnamecell");
                firstnamecell.innerText = user.firstname;
                //Add the username cell to the row.
                let usernamecell = row.insertCell();
                usernamecell.classList.add("usernamecell");
                usernamecell.innerText = user.username;
                //Add the role cell to the row.
                let rolecell = row.insertCell();
                rolecell.classList.add("rolecell");
                rolecell.innerText = "Admin";
                //Add the enabled cell to the row.
                let enabledcell = row.insertCell();
                enabledcell.classList.add("enabledcell");
                enabledcell.innerText = user.enabled == 1 ? "Yes" : "No";
                //Add the actions cell to the row.
                let actionscell = row.insertCell();
                actionscell.classList.add("actionscell");
                actionscell.innerHTML = actionscellhtml;
            });
            break;
        default:
            //Add the users to the table.
            Array.from(allusers.filter(user => user.enabled == (filterValue == "enabled" ? 1 : 0))).forEach((user) => {
                let row = tbody.insertRow();
                //Add the usernum cell to the row.
                let usernumcell = row.insertCell();
                usernumcell.classList.add("usernumcell");
                usernumcell.innerText = user.usernum;
                //Add the lastname cell to the row.
                let lastnamecell = row.insertCell();
                lastnamecell.classList.add("lastnamecell");
                lastnamecell.innerText = user.lastname;
                //Add the firstname cell to the row.
                let firstnamecell = row.insertCell();
                firstnamecell.classList.add("firstnamecell");
                firstnamecell.innerText = user.firstname;
                //Add the username cell to the row.
                let usernamecell = row.insertCell();
                usernamecell.classList.add("usernamecell");
                usernamecell.innerText = user.username;
                //Add the role cell to the row.
                let rolecell = row.insertCell();
                rolecell.classList.add("rolecell");
                rolecell.innerText = "Admin";
                //Add the enabled cell to the row.
                let enabledcell = row.insertCell();
                enabledcell.classList.add("enabledcell");
                enabledcell.innerText = user.enabled == 1 ? "Yes" : "No";
                //Add the actions cell to the row.
                let actionscell = row.insertCell();
                actionscell.classList.add("actionscell");
                actionscell.innerHTML = actionscellhtml;
            });
    }
}