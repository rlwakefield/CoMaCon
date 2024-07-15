let sessionadministrationusers = [];
let sessionadministrationusersidnumber = 0;
let sessionadministrationroles = [];
let sessionadministrationrolesidnumber = 0;
let responsiveAppsApps = [];
let responsiveAppsAppsIdNumber = 0;
let responsiveAppsAppNewAppDataStructure = { "Name": "[appName]", "IconURL": "[urlToAppIcon]", "URL": "[urlToApp]", "id": "" };


/********************************************************
 *                 General Scripting
 ********************************************************/
function sessionTimeoutChecked(checkbox, editablefield) {
    //window.confirm("Warning! This setting is a hard cutoff. Please make sure you are aware the implications this could cause to your solution.")
    if (checkbox.checked == true) {
        if (window.confirm("Warning! This setting is a hard cutoff. Please make sure you are aware the implications this could cause to your solution.")) {
            //document.getElementById(editablefield).disabled = false;
            checkbox.checked = true;
        } else {
            checkbox.checked = false;
        }
    }
}


/********************************************************
*                 General Functions
********************************************************/
function hylandIdpUrlUpdated(field) {
    document.getElementById("Audience-URL").value = field.value + "\\resources";
}

function documentQueryWarningThresholdChanged() {
    if (document.getElementById("Document-Query-Limit").value < document.getElementById("Document-Query-Warning-Threshold").value) {
        window.confirm("The Document Query Warning Threshold cannot be larger than the Document Query Limit, so the Document Query Limit has been set to the same value as the Document Query Warning Threshold.");
        document.getElementById("Document-Query-Limit").value = document.getElementById("Document-Query-Warning-Threshold").value;
    }
}

function documentQueryLimitChanged() {
    if (document.getElementById("Document-Query-Limit").value < document.getElementById("Document-Query-Warning-Threshold").value) {
        window.confirm("The Document Query Limit cannot be less than the Document Query Warning Threshold, so the Document Query Warning Threshold has been set to the same value as the Document Query Limit.");
        document.getElementById("Document-Query-Warning-Threshold").value = document.getElementById("Document-Query-Limit").value;
    }
}


/********************************************************
 *   Hyland Authentication - Trusted Client Functions
 ********************************************************/
async function trustedClientChanged(selectList) {
    let trustedClientLookupResult = trustedClients.filter(result => result.id == selectList.value);
    if (trustedClientLookupResult.length > 0) {
        document.getElementById("Store-Location").value = trustedClientLookupResult[0].StoreLocation;
        document.getElementById("Store-Name").value = trustedClientLookupResult[0].StoreName;
        document.getElementById("Find-Value").value = trustedClientLookupResult[0].FindValue;
        document.getElementById("Find-Type").value = trustedClientLookupResult[0].FindType;
        document.getElementById("Description").value = trustedClientLookupResult[0].Description;
        lockTrustedClientFields('false');
    } else {
        //Still need to figure out what to do here.
    }

    await checkIncompleteTrustedClientsFields();
}

async function checkIncompleteTrustedClientsFields() {
    if (document.getElementById("Find-Value").value == "") {
        document.getElementById("Find-Value-RequiredSvg").style.display = "block";
        pushErrorToArray(await findErrorArrayToSet("trustedClientsIncompleteFields"));
    } else {
        document.getElementById("Find-Value-RequiredSvg").style.display = "none";
        spliceErrorFromArray("trustedClientsIncompleteFields");
    }
}

async function trustedClientFieldUpdated(field) {
    let trustedClientLookupResult = trustedClients.filter(result => result.id == document.getElementById("TrustedClients-SelectList").value);
    switch (field) {
        case "StoreLocation":
            trustedClientLookupResult[0].StoreLocation = document.getElementById("Store-Location").value;
            break;
        case "StoreName":
            trustedClientLookupResult[0].StoreName = document.getElementById("Store-Name").value;
            break;
        case "FindType":
            trustedClientLookupResult[0].FindType = document.getElementById("Find-Type").value;
            break;
        case "FindValue":
            trustedClientLookupResult[0].FindValue = document.getElementById("Find-Value").value;
            await checkIncompleteTrustedClientsFields();
            break;
        case "Description":
            if (document.getElementById("Description").value == "") {
                trustedClientLookupResult[0].Description = "<Blank>";
                document.getElementById("TrustedClients-SelectList").options[document.getElementById("TrustedClients-SelectList").selectedIndex].innerText = "<Blank>";
            } else {
                trustedClientLookupResult[0].Description = document.getElementById("Description").value;
                document.getElementById("TrustedClients-SelectList").options[document.getElementById("TrustedClients-SelectList").selectedIndex].innerText = document.getElementById("Description").value;
            }
            break;
    }
}

async function addNewTrustedClient() {
    configurationChanged = true;
    let tcIdNumber = "trustedclient" + trustedClientIdNumber;
    let tcSelectList = document.getElementById("TrustedClients-SelectList");
    let objToAdd = {
        "StoreLocation": "CurrentUser",
        "StoreName": "TrustedPeople",
        "FindType": "FindByThumbprint",
        "FindValue": "",
        "Description": "",
        "id": tcIdNumber
    }

    let opt = document.createElement("option");
    opt.value = tcIdNumber;
    opt.innerText = "<Blank>";
    tcSelectList.appendChild(opt);
    tcSelectList.value = tcIdNumber;
    await lockTrustedClientFields('false');
    await disableTrustedClientButtons("None");
    await checkIncompleteTrustedClientsFields();

    trustedClientIdNumber++;
}

async function removeTrustedClient() {
    for (let i = 0; i < trustedClients.length; i++) {
        if (trustedClients[i].id == document.getElementById("TrustedClients-SelectList").value) {
            trustedClients.splice(i, 1);
            break;
        }
    }
    document.getElementById("TrustedClients-SelectList").removeChild(document.getElementById("TrustedClients-SelectList").options[document.getElementById("TrustedClients-SelectList").selectedIndex]);
    lockTrustedClientFields('true');
    await disableTrustedClientButtons("All");
    await resetIncompleteTrustedClientsFields();
}

async function resetTrustedClientFields() {
    document.getElementById("Store-Location").value = "CurrentUser";
    document.getElementById("Store-Name").value = "TrustedPeople";
    document.getElementById("Find-Value").value = "";
    document.getElementById("Find-Type").value = "FindByThumbprint";
    document.getElementById("Description").value = "";
}

async function resetIncompleteTrustedClientsFields() {
    document.getElementById("Find-Value-RequiredSvg").style.display = "none";
}

async function disableTrustedClientButtons(action) {
    switch (action) {
        case "All":
            document.getElementById("Remove-Trusted-Client-Button").disabled = true;
            break;
        case "None":
            document.getElementById("Remove-Trusted-Client-Button").disabled = false;
            break;
    }
}

async function lockTrustedClientFields(action) {
    document.getElementById("Store-Location").disabled = (action === 'true');
    document.getElementById("Store-Name").disabled = (action === 'true');
    document.getElementById("Find-Value").disabled = (action === 'true');
    document.getElementById("Find-Type").disabled = (action === 'true');
    document.getElementById("Description").disabled = (action === 'true');
}


/********************************************************
*              Disk Group Aliases Functions
********************************************************/

async function diskGroupAliasesChanged(selectList) {
    let diskGroupAliasesLookupResult = diskGroupAliases.filter(result => result.id == selectList.value);
if (diskGroupAliasesLookupResult.length > 0) {
        document.getElementById("Alias-Old-Name").value = diskGroupAliasesLookupResult[0].oldname;
        document.getElementById("Alias-New-Name").value = diskGroupAliasesLookupResult[0].newname;
        document.getElementById("Alias-Type").value = diskGroupAliasesLookupResult[0].type;
        lockDiskGroupAliasesFields('false');
    } else {
        //Still need to figure out what to do here.
    }
}

async function addDiskGroupAlias() {
    configurationChanged = true;
    let diskGroupAliasSelectList = document.getElementById("DiskGroupAliases-SelectList");
    let idNumber = "diskgroupalias" + diskGroupAliasIdNumber;
    let objToAdd = {
        "oldname": "",
        "newname": "",
        "type": "unc",
        "id": idNumber
    }

    let opt = document.createElement("option");
    opt.value = idNumber;
    opt.innerText = "";
    diskGroupAliasSelectList.appendChild(opt);
    diskGroupAliasSelectList.value = idNumber;
    await lockDiskGroupAliasesFields('false');
    await lockDiskGroupAliasesButtons("None");
    diskGroupAliases.push(objToAdd);
    checkIncompleteDiskGroupAliasesFields(document.getElementById("Alias-Old-Name"));
    checkIncompleteDiskGroupAliasesFields(document.getElementById("Alias-New-Name"));

    diskGroupAliasIdNumber++;
}

async function deleteDiskGroupAlias() {
    for (let i = 0; i < diskGroupAliases.length; i++) {
        if (diskGroupAliases[i].id == document.getElementById("DiskGroupAliases-SelectList").value) {
            diskGroupAliases.splice(i, 1);
            document.getElementById("DiskGroupAliases-SelectList").removeChild(document.getElementById("DiskGroupAliases-SelectList").options[document.getElementById("DiskGroupAliases-SelectList").selectedIndex]);
        }
    }

    lockDiskGroupAliasesFields('true');
    await lockDiskGroupAliasesButtons("All");
    await resetDiskGroupAliasesFields();
}

async function resetDiskGroupAliasesFields() {
    document.getElementById("Alias-Old-Name").value = "";
    document.getElementById("Alias-New-Name").value = "";
    document.getElementById("Alias-Type").value = "unc";
}

async function diskGroupAliasesFieldUpdated(field) {
    let diskGroupAliasesLookupResult = diskGroupAliases.filter(result => result.id == document.getElementById("DiskGroupAliases-SelectList").value);
    switch (field.id) {
        case "Alias-Old-Name":
            diskGroupAliasesLookupResult[0].oldname = field.value;
            document.getElementById("DiskGroupAliases-SelectList").options[document.getElementById("DiskGroupAliases-SelectList").selectedIndex].innerText = field.value;
            break;
        case "Alias-New-Name":
            diskGroupAliasesLookupResult[0].newname = field.value;
            document.getElementById("DiskGroupAliases-SelectList").options[document.getElementById("DiskGroupAliases-SelectList").selectedIndex].innerText = document.getElementById("Alias-Old-Name").value;
            break;
        case "Alias-Type":
            diskGroupAliasesLookupResult[0].type = field.value;
            document.getElementById("DiskGroupAliases-SelectList").options[document.getElementById("DiskGroupAliases-SelectList").selectedIndex].innerText = document.getElementById("Alias-Old-Name").value;
            break;
    }
    await checkIncompleteDiskGroupAliasesFields(field);
}

async function lockDiskGroupAliasesFields(action) {
    document.getElementById("Alias-Old-Name").disabled = (action === 'true');
    document.getElementById("Alias-New-Name").disabled = (action === 'true');
    document.getElementById("Alias-Type").disabled = (action === 'true');
}

async function lockDiskGroupAliasesButtons(action) {
    switch (action) {
        case "All":
            document.getElementById("Delete-DiskGroup-Alias-Button").disabled = true;
            break;
        case "None":
            document.getElementById("Delete-DiskGroup-Alias-Button").disabled = false;
            break;
    }
}

async function checkIncompleteDiskGroupAliasesFields(field) {
    if (field.value == "") {
        document.getElementById(field.id + "-RequiredSvg").style.display = "block";
        pushErrorToArray(await findErrorArrayToSet("diskGroupAliasesIncompleteFields"));
    } else {
        document.getElementById(field.id + "-RequiredSvg").style.display = "none";

        switch (field.id) {
            case "Alias-Old-Name":
                if (document.getElementById("Alias-New-Name").value != "") {
                    spliceErrorFromArray("diskGroupAliasesIncompleteFields");
                }
                break;
            case "Alias-New-Name":
                if (document.getElementById("Alias-Old-Name").value != "") {
                    spliceErrorFromArray("diskGroupAliasesIncompleteFields");
                }
                break;
        }
    }
}

function optimizeForWindowsAuthChangedApplicationServer(field) {
    switch (field.id) {
        case "OptimizeForWindowsAuth-ApplicationServer":
            if (field.checked) {
                optimizeForWindowsAuth.push(field.id.substring(field.id.indexOf("-") + 1));
            } else {
                optimizeForWindowsAuth.splice(optimizeForWindowsAuth.indexOf(field.id.substring(field.id.indexOf("-") + 1)), 1);
            }
            break;
    }

    if (optimizeForWindowsAuth.length != 0) {
        document.getElementById("IIS-Configuration-Application-Anonymous-Authentication-RootSpecific").checked = true;
        document.getElementById("IIS-Configuration-Application-Windows-Authentication-RootSpecific").checked = true;
        document.getElementById("IIS-Configuration-Application-Use-Application-Pool-Credentials").checked = true;
    }
}


/********************************************************
*            Session Administration Functions
********************************************************/
/* Users Functions */
async function newSessionAdministrationUser() {
    configurationChanged = true;
    document.getElementById("SessionAdministration-User").disabled = false;
    document.getElementById("SessionAdministration-User-DeleteButton").disabled = false;
    document.getElementById("SessionAdministration-User").value = "";
    document.getElementById("SessionAdministration-User").focus();
    let opt = document.createElement("option");
    opt.value = "SessionAdministrationUser" + sessionadministrationusersidnumber;
    opt.innerText = "";
    document.getElementById("SessionAdministration-User-SelectList").append(opt);
    document.getElementById("SessionAdministration-User-SelectList").value = "SessionAdministrationUser" + sessionadministrationusersidnumber;

    let objectToAdd = {
        user: "",
        id: "SessionAdministrationUser" + sessionadministrationusersidnumber
    };
    sessionadministrationusers.push(objectToAdd);
    sessionadministrationusersidnumber++;
}

async function deleteSessionAdministrationUser() {
    let result = sessionadministrationusers.filter(result => result.id == document.getElementById("SessionAdministration-User-SelectList").value);
    let index = sessionadministrationusers.indexOf(result[0]);
    sessionadministrationusers.splice(index, 1);
    document.getElementById("SessionAdministration-User-SelectList").removeChild(document.getElementById("SessionAdministration-User-SelectList").options[document.getElementById("SessionAdministration-User-SelectList").selectedIndex]);
    document.getElementById("SessionAdministration-User").value = "";
    document.getElementById("SessionAdministration-User").disabled = true;
    document.getElementById("SessionAdministration-User-DeleteButton").disabled = true;
}

async function sessionAdministrationUserFieldUpdated(field) {
    let result = sessionadministrationusers.filter(result => result.id == document.getElementById("SessionAdministration-User-SelectList").value);
    result[0].user = document.getElementById("SessionAdministration-User").value;
    document.getElementById("SessionAdministration-User-SelectList").options[document.getElementById("SessionAdministration-User-SelectList").selectedIndex].innerText = document.getElementById("SessionAdministration-User").value;
}

async function sessionAdministrationUserSelected(selectList) {
    let result = sessionadministrationusers.filter(result => result.id == selectList.value);
    document.getElementById("SessionAdministration-User").value = result[0].user;
    document.getElementById("SessionAdministration-User").disabled = false;
    document.getElementById("SessionAdministration-User-DeleteButton").disabled = false;
}

/* Roles Functions */
async function newSessionAdministrationRole() {
    configurationChanged = true;
    document.getElementById("SessionAdministration-Role").disabled = false;
    document.getElementById("SessionAdministration-Role-DeleteButton").disabled = false;
    document.getElementById("SessionAdministration-Role").value = "";
    document.getElementById("SessionAdministration-Role").focus();
    let opt = document.createElement("option");
    opt.value = "SessionAdministrationRole" + sessionadministrationrolesidnumber;
    opt.innerText = "";
    document.getElementById("SessionAdministration-Role-SelectList").append(opt);
    document.getElementById("SessionAdministration-Role-SelectList").value = "SessionAdministrationRole" + sessionadministrationrolesidnumber;

    let objectToAdd = {
        role: "",
        id: "SessionAdministrationRole" + sessionadministrationrolesidnumber
    };
    sessionadministrationroles.push(objectToAdd);
    sessionadministrationrolesidnumber++;
}

async function deleteSessionAdministrationRole() {
    let result = sessionadministrationroles.filter(result => result.id == document.getElementById("SessionAdministration-Role-SelectList").value);
    let index = sessionadministrationroles.indexOf(result[0]);
    sessionadministrationroles.splice(index, 1);
    document.getElementById("SessionAdministration-Role-SelectList").removeChild(document.getElementById("SessionAdministration-Role-SelectList").options[document.getElementById("SessionAdministration-Role-SelectList").selectedIndex]);
    document.getElementById("SessionAdministration-Role").value = "";
    document.getElementById("SessionAdministration-Role").disabled = true;
    document.getElementById("SessionAdministration-Role-DeleteButton").disabled = true;
}

async function sessionAdministrationRoleFieldUpdated(field) {
    let result = sessionadministrationroles.filter(result => result.id == document.getElementById("SessionAdministration-Role-SelectList").value);
    result[0].role = document.getElementById("SessionAdministration-Role").value;
    document.getElementById("SessionAdministration-Role-SelectList").options[document.getElementById("SessionAdministration-Role-SelectList").selectedIndex].innerText = document.getElementById("SessionAdministration-Role").value;
}

async function sessionAdministrationRoleSelected(selectList) {
    let result = sessionadministrationroles.filter(result => result.id == selectList.value);
    document.getElementById("SessionAdministration-Role").value = result[0].role;
    document.getElementById("SessionAdministration-Role").disabled = false;
    document.getElementById("SessionAdministration-Role-DeleteButton").disabled = false;
}


/********************************************************
*            Responsive Apps App Functions
********************************************************/
async function responsiveAppsAppChanged(selectList) {
    let responsiveAppsAppLookupResult = responsiveAppsApps.filter(result => result.id == selectList.value);
    console.log(responsiveAppsAppLookupResult);
    if (responsiveAppsAppLookupResult.length > 0) {
        document.getElementById("App-Name").value = responsiveAppsAppLookupResult[0].Name;
        document.getElementById("App-Icon-URL").value = responsiveAppsAppLookupResult[0].IconURL;
        document.getElementById("App-URL").value = responsiveAppsAppLookupResult[0].URL;
    }

    await setResponsiveAppsAppFieldDisabledStatus(false);
    await setResponsiveAppsAppButtonDisabledStatus(false);
}

async function setResponsiveAppsAppFieldDisabledStatus(status) {
    document.getElementById("App-Name").disabled = status;
    document.getElementById("App-Icon-URL").disabled = status;
    document.getElementById("App-URL").disabled = status;
}

async function setResponsiveAppsAppButtonDisabledStatus(status) {
    document.getElementById("Delete-ResponsiveApps-App-Button").disabled = status;
}

async function addResponsiveAppsApp() {
    let newApp = JSON.parse(JSON.stringify(responsiveAppsAppNewAppDataStructure));
    newApp.id = "ResponsiveAppsApp" + responsiveAppsAppsIdNumber;
    responsiveAppsApps.push(newApp);
    let opt = document.createElement("option");
    opt.value = newApp.id;
    opt.innerText = newApp.Name;
    document.getElementById("ResponsiveAppsApp-SelectList").append(opt);
    responsiveAppsAppsIdNumber++;

    await setResponsiveAppsAppFieldDisabledStatus(false);
    await setResponsiveAppsAppButtonDisabledStatus(false);
    //Set the select list to the new app
    document.getElementById("ResponsiveAppsApp-SelectList").value = newApp.id;
    document.getElementById("App-Name").value = newApp.Name;
    document.getElementById("App-Icon-URL").value = newApp.IconURL;
    document.getElementById("App-URL").value = newApp.URL;
    console.log(responsiveAppsApps);
}

async function deleteResponsiveAppsApp() {
    let appToDelete = responsiveAppsApps.filter(result => result.id == document.getElementById("ResponsiveAppsApp-SelectList").value);
    let index = responsiveAppsApps.indexOf(appToDelete[0]);
    responsiveAppsApps.splice(index, 1);
    document.getElementById("ResponsiveAppsApp-SelectList").removeChild(document.getElementById("ResponsiveAppsApp-SelectList").options[document.getElementById("ResponsiveAppsApp-SelectList").selectedIndex]);
    await setResponsiveAppsAppFieldDisabledStatus(true);
    await setResponsiveAppsAppButtonDisabledStatus(true);
    await resetResponsiveAppsAppFields();
    console.log(responsiveAppsApps);
}

async function resetResponsiveAppsAppFields() {
    document.getElementById("App-Name").value = "";
    document.getElementById("App-Icon-URL").value = "";
    document.getElementById("App-URL").value = "";
}