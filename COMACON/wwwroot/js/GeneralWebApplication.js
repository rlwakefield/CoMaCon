/* Core Web App Server variables, items, and more. */
/* Static Variables */
const hiddenPasswordEyeball = `<svg width="18" height="18" fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                            <path d="M6.873 17.129c-1.845-1.31-3.305-3.014-4.13-4.09a1.693 1.693 0 0 1 0-2.077C4.236 9.013 7.818 5 12 5c1.876 0 3.63.807 5.13 1.874"></path>
                            <path d="M14.13 9.887a3 3 0 1 0-4.243 4.242"></path>
                            <path d="M4 20 20 4"></path>
                            <path d="M10 18.704A7.124 7.124 0 0 0 12 19c4.182 0 7.764-4.013 9.257-5.962a1.694 1.694 0 0 0-.001-2.078A22.939 22.939 0 0 0 19.57 9"></path>
                            </svg>`;

const shownPasswordEyeball = `<svg width="18" height="18" fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                            <path d="M21.257 10.962c.474.62.474 1.457 0 2.076C19.764 14.987 16.182 19 12 19c-4.182 0-7.764-4.013-9.257-5.962a1.692 1.692 0 0 1 0-2.076C4.236 9.013 7.818 5 12 5c4.182 0 7.764 4.013 9.257 5.962z"></path>
                            <path d="M12 9a3 3 0 1 0 0 6 3 3 0 1 0 0-6z"></path>
                            </svg>`;

const greenCheckMark = `<svg name="Green-Check-Mark" class="FieldVarificationIcon" width="20" height="20" fill="none" stroke="#33a531" stroke-linecap="round" stroke-linejoin="round" stroke-width="6" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                        <path d="M20 6 9 17l-5-5"></path>
                        </svg>`;

const redX = `<svg name="Red-X" class="FieldVarificationIcon" width="20" height="20" fill="none" stroke="#ff0000" stroke-linecap="round" stroke-linejoin="round" stroke-width="6" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
            <path d="M18 6 6 18"></path>
            <path d="m6 6 12 12"></path>
            </svg>`;

const blackQuestionMark = `<svg name="Black-Question-Mark" class="FieldVarificationIcon" width="20" height="20" fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="3.5" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                        <path d="M8 8c0-.796.369-1.559 1.025-2.121C9.681 5.316 10.572 5 11.5 5h1c.928 0 1.819.316 2.475.879C15.63 6.44 16 7.204 16 8a3 3 0 0 1-2 3c-.614.288-1.14.833-1.501 1.555A5.04 5.04 0 0 0 12 15"></path>
                        <path d="M12 19v.01"></path>
                        </svg>`;

const errorOctagonSVG = `<svg width="20" height="20" fill="#ff0000" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                        <path d="M16.325 2.183A.625.625 0 0 0 15.884 2H8.116a.625.625 0 0 0-.441.183L2.183 7.675A.625.625 0 0 0 2 8.116v7.768c0 .165.066.324.183.441l5.492 5.492a.625.625 0 0 0 .441.183h7.768a.625.625 0 0 0 .441-.183l5.492-5.492a.625.625 0 0 0 .183-.441V8.116a.625.625 0 0 0-.183-.441l-5.492-5.492ZM12 7a1.13 1.13 0 0 1 1.125 1.244l-.438 4.383a.69.69 0 0 1-1.374 0l-.438-4.383A1.131 1.131 0 0 1 12 7Zm.002 7.5a1.25 1.25 0 1 1 0 2.5 1.25 1.25 0 0 1 0-2.5Z"></path>
                        </svg>`

const requiredOctagonSVG = `<svg width="20" height="20" fill="#ff0000" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" class="requiredField">
                        <path d="M16.325 2.183A.625.625 0 0 0 15.884 2H8.116a.625.625 0 0 0-.441.183L2.183 7.675A.625.625 0 0 0 2 8.116v7.768c0 .165.066.324.183.441l5.492 5.492a.625.625 0 0 0 .441.183h7.768a.625.625 0 0 0 .441-.183l5.492-5.492a.625.625 0 0 0 .183-.441V8.116a.625.625 0 0 0-.183-.441l-5.492-5.492ZM12 7a1.13 1.13 0 0 1 1.125 1.244l-.438 4.383a.69.69 0 0 1-1.374 0l-.438-4.383A1.131 1.131 0 0 1 12 7Zm.002 7.5a1.25 1.25 0 1 1 0 2.5 1.25 1.25 0 0 1 0-2.5Z"></path>
                        </svg>`



/* Arrays for building page elements live */
const DiagnosticsSettingsProfiles = [];

/* Error Arrays */
//["errorId", "Location", "Title", "Description"];
//const folderingHeightErrorArray = ["folderingHeightPercentage", "Foldering", "Height Percentage", "All 3 height values must equal a sum of 100% exactly."];
//const keywordTypeaheadCharacterCountArray = ["keywordTypeaheadCharacterCount", "Miscellaneous", "Keyword Typeahead", "No duplicate Keyword ID numbers allowed"];
//const agendaOnlineDuplicateFormFieldNamesArray = ["agendaOnlineDuplicateFormFieldNames", "PublicCommentIntegration", "Field Name", "No duplicate Unity Form Field Names are allowed."];
//const agendaOnlineDuplicateMeetingTypeNamesArray = ["agendaOnlineDuplicateMeetingTypeNames", "PublicCommentIntegration", "Duplicate Meeting Type Name", "Duplicate Meeting Type Names are not allowed."];
//const connectionStringDataSourceNameErrorArray = ["connectionStringDataSourceName", "ConnectionStrings", "Data Source Name", "You have a duplicate Data Source Name or an incomplete Connection String."];
//const diagnosticSettingsRouteNameErrorArray = [diagnosticSettingsRouteName"", "DiagnosticsSettings", "Duplicate Route Name", "You have a duplicate Diagnostics Route Name. All Route Names need to be unique."];
//const applicationPoolMissingCredentialsErrorArray = ["applicationPoolMissingCredentials", "IISApplicationPool", "Missing Username/Password", "The username or password fields are not filled in. Please fill in to allow saving."];
//const customValidationApplicationLevelIncompleteFieldsErrorArray = ["customValidationApplicationLevelIncompleteFields", "CustomValidationApplicationLevel", "IncompleteFields", "You have incomplete fields on one or more of your Application Level Custom Validation Keywords configuration."];
//const customValidationPageLevelIncompleteFieldsErrorArray = ["customValidationPageLevelIncompleteFields", "CustomValidationPageLevel", "IncompleteFields", "You have incomplete fields on one or more of your Page Level Custom Validation Keywords configuration."];
//const diskGroupAliasesIncompleteFieldsErrorArray = ["diskGroupAliasesIncompleteFields", "PlatterManagementDiskGroupAlias", "IncompleteFields", "You have incomplete fields on one or more of your Disk Group Aliases configurations."];
//const trustedClientsIncompleteFieldsErrorArray = ["trustedClientsIncompleteFields", "AuthenticationTrustedCertificates", "IncompleteFields", "You have incomplete fields on one or more of your Trusted Clients configurations."];
//const keywordTypeaheadCharacterCountErrorArray = ["keywordTypeaheadCharacterCount", "Miscellaneous", "Keyword Typeahead", "There is a duplicate Keyword ID number entered or a configuration that is incomplete."];
//const webServerIdentityProviderIncompleteFieldsErrorArray = ["webServerIdentityProviderIncompleteFields", "Login", "Incomplete Identity Server", "Please make sure you complete all of the Identity Provider fields."];
//const healthcareFormManagerIdentityProviderIncompleteFieldsErrorArray = ["healthcareFormManagerIdentityProviderIncompleteFields", "Login", "Incomplete Identity Server", "Please make sure you complete all of the Identity Provider fields."];
//const onbasePatientWindowIdentityProviderIncompleteFieldsErrorArray = ["onbasePatientWindowIdentityProviderIncompleteFields", "Login", "Incomplete Identity Server", "Please make sure you complete all of the Identity Provider fields."];
//const reportingViewerIdentityProviderIncompleteFieldsErrorArray = ["reportingViewerIdentityProviderIncompleteFields", "Login", "Incomplete Identity Server", "Please make sure you complete all of the Identity Provider fields."];
let errorArrays = [
    {
        "Name": "folderingHeightPercentage",
        "Array": ["folderingHeightPercentage","Foldering","Height Percentage","All 3 height values must equal a sum of 100% exactly."]
    },
    {
        "Name": "keywordTypeaheadCharacterCount",
        "Array": ["keywordTypeaheadCharacterCount","Miscellaneous","Keyword Typeahead","No duplicate Keyword ID numbers allowed"]
    },
    {
        "Name": "agendaOnlineDuplicateFormFieldNames",
        "Array": ["agendaOnlineDuplicateFormFieldNames","PublicCommentIntegration","Field Name","No duplicate Unity Form Field Names are allowed."]
    },
    {
        "Name": "agendaOnlineDuplicateMeetingTypeNames",
        "Array": ["agendaOnlineDuplicateMeetingTypeNames","PublicCommentIntegration","Duplicate Meeting Type Name","Duplicate Meeting Type Names are not allowed."]
    },
    {
        "Name": "connectionStringDataSourceName",
        "Array": ["connectionStringDataSourceName","ConnectionStrings","Data Source Name","You have a duplicate Data Source Name or an incomplete Connection String."]
    },
    {
        "Name": "diagnosticSettingsRouteName",
        "Array": ["diagnosticSettingsRouteName","DiagnosticsSettings","Duplicate Route Name","You have a duplicate Diagnostics Route Name. All Route Names need to be unique."]
    },
    {
        "Name": "applicationPoolMissingCredentials",
        "Array": ["applicationPoolMissingCredentials","IISApplicationPool","Missing Username/Password","The username or password fields are not filled in. Please fill in to allow saving."]
    },
    {
        "Name": "customValidationApplicationLevelIncompleteFields",
        "Array": ["customValidationApplicationLevelIncompleteFields","CustomValidationApplicationLevel","IncompleteFields","You have incomplete fields on one or more of your Application Level Custom Validation Keywords configuration."]
    },
    {
        "Name": "customValidationPageLevelIncompleteFields",
        "Array": ["customValidationPageLevelIncompleteFields","CustomValidationPageLevel","IncompleteFields","You have incomplete fields on one or more of your Page Level Custom Validation Keywords configuration."]
    },
    {
        "Name": "diskGroupAliasesIncompleteFields",
        "Array": ["diskGroupAliasesIncompleteFields","PlatterManagementDiskGroupAlias","IncompleteFields","You have incomplete fields on one or more of your Disk Group Aliases configurations."]
    },
    {
        "Name": "trustedClientsIncompleteFields",
        "Array": ["trustedClientsIncompleteFields","AuthenticationTrustedCertificates","IncompleteFields","You have incomplete fields on one or more of your Trusted Clients configurations."]
    },
    {
        "Name": "keywordTypeaheadCharacterCount",
        "Array": ["keywordTypeaheadCharacterCount","Miscellaneous","Keyword Typeahead","There is a duplicate Keyword ID number entered or a configuration that is incomplete."]
    },
    {
        "Name": "webServerIdentityProviderIncompleteFields",
        "Array": ["webServerIdentityProviderIncompleteFields","Login","Incomplete Identity Server","Please make sure you complete all of the Identity Provider fields."]
    },
    {
        "Name": "healthcareFormManagerIdentityProviderIncompleteFields",
        "Array": ["healthcareFormManagerIdentityProviderIncompleteFields","Login","Incomplete Identity Server","Please make sure you complete all of the Identity Provider fields."]
    },
    {
        "Name": "onbasePatientWindowIdentityProviderIncompleteFields",
        "Array": ["onbasePatientWindowIdentityProviderIncompleteFields","Login","Incomplete Identity Server","Please make sure you complete all of the Identity Provider fields."]
    },
    {
        "Name": "reportingViewerIdentityProviderIncompleteFields",
        "Array": ["reportingViewerIdentityProviderIncompleteFields","Login","Incomplete Identity Server","Please make sure you complete all of the Identity Provider fields."]
    },
    {
        "Name": "cachePathCannotBeAUncPath",
        "Array": ["cachePathCannotBeAUncPath","GatewayCachingServer","Cache Path","The Cache Path cannot be a UNC path. Please enter a local path."]
    }
]

/* Known Deprecated web.confg keys per version */
const knownDeprecatedConfigurationKeys = [{}];

/* Generic Variables */
let hylandLoggingDiagnosticsRoutesDetails = "";
let hylandLoggingDiagnosticsRoutes = [];
let diagnosticsSettingsRoutesIdNumber = 0;
let requiredKeywordsArray = [];
let coreConfigData = "";
let errorsArray = [];
let webApplications = "";
let optimizeForWindowsAuth = [];
let tdIdValue = 0;
let apiRootUrl = "";
let configurationChanged = false;

/* ADFS Settings Variables */
let audienceUrisIdNumber = 0;
let audienceUrisData = [];
let trustedIssuersIdNumber = 0;
let trustedIssuersData = [];

/* Diagnostics Settings Routes V2 */
let diagnosticsRoutes = [];
let diagnosticsRoutesIdNumber = 0;
let diagnosticsSettingsElementIds = ["Source-Details-Name", "Source-Details-Source-Radio-Diagnostics-Events", "Source-Details-Source-Radio-Audit-Events", "Enable-IP-Address-Masking", "Filtering-Options-Minimum-Error-Level", "Filtering-Options-Maximum-Error-Level", "Filter-Options-Neither-Profiles-Radio", "Filter-Options-Included-Profiles-Radio", "Filter-Options-Excluded-Profiles-Radio", "Destination-Type"];

/* Connection Strings Variables */
let connectionStringIdNumber = 0;
let ConnectionStringsArray = [];
let connectionStringsCoreElementIds = ["Data-Source-Name", "Data-Provider", "Integrated-Security", "User-ID", "Password", "Additional-Options"];
let connectionStringsSqlElementIds = ["Sql-Data-Source", "Sql-Database"];
let connectionStringsOracleElementIds = ["Oracle-Fields-TNS-Connection-String", "Host", "Protocol", "Oracle-Database", "Port"];
let connectionStringAction = "";

/* Hyland Authentication Variables */
let trustedClients = [];
let trustedClientIdNumber = 0;

/* Hyland Platter Management Variables */
let diskGroupAliasIdNumber = 0;
let diskGroupAliases = [];

/* Navigation Panel Variables */
let NavigationPanelContexts = [];
let NavigationPanelContextsIdNumber = 1;

/* Keyword Drop Down Type Ahead Character Minimums Variables */
let keywordTypeAheadArray = [];
let keywordTypeAheadIdNumber = 0;


/********************************************************
 *                  Page Load SCript
 ********************************************************/
async function onPageLoadLogic() {
    console.log(localStorage.getItem("darkModeState"));
    if (localStorage.getItem("darkModeState") != null) {
        if (localStorage.getItem("darkModeState") == "true") {
            document.getElementById("checkbox").checked = true;
        } else {
            document.getElementById("checkbox").checked = false;
        }
        toggleDarkLightMode(document.getElementById("checkbox"));
    }
    if (sessionStorage.getItem('WebApplicationChosenArray') != null && sessionStorage.getItem('WebApplicationChosenArray') != undefined) {
        let object = JSON.parse(sessionStorage.getItem('WebApplicationChosenArray'));
        sessionStorage.removeItem('WebApplicationChosenArray');
        apiRootUrl = sessionStorage.getItem('apiRootUrl');

        document.getElementById("ProcessingWebConfig-Label").innerText = "Loading " + object[0].name + " Web Application...";
        document.getElementById("ProcessingWebConfigValuesProgress").style.display = "block";
        loadWebApplicationConfiguration(object[0].webConfigPhysicalPath, object[0].type, object[0].version, object[0].site, object[0].name, object[0].path, object[0].physicalPath, object[0].bitness);
    } else {
        //Need to redirect the user back to the home page.
    }
}


/********************************************************
 *       Load Web Application Configuration Script
 ********************************************************/
function loadWebApplicationConfiguration(webConfigPhysicalPathVariable, webApplicationType, webApplicationVersion, webApplicationSiteName, webApplicationName, webApplicationPath, physicalPath, bitness) {
    fetch(apiRootUrl + '/api/Endpoint/GetConfiguration?webconfig=' + encodeURIComponent(webConfigPhysicalPathVariable) +
        "&type=" + encodeURIComponent(webApplicationType) +
        "&version=" + encodeURIComponent(webApplicationVersion) +
        "&siteName=" + encodeURIComponent(webApplicationSiteName) +
        "&applicationName=" + encodeURIComponent(webApplicationName) +
        "&applicationPath=" + encodeURIComponent(webApplicationPath) +
        "&physicalPath=" + encodeURIComponent(physicalPath) +
        "&bitness=" + encodeURIComponent(bitness), {
        method: "GET",
    })
        .then(response => response.json())
        .then(data => checkWhatWebApplicationToParse(data, "LoadWebApplication"));
}

async function checkWhatWebApplicationToParse(config, executionMethod) {
    console.log(config);

    if (config["processingErrors"]["CriticalErrors"].length > 0) {
        populateErrorLoadModal(config["processingErrors"]["CriticalErrors"], "Critical");
    }
    else
    {
        if (config["processingErrors"]["NonCriticalErrors"].length > 0) {
            populateErrorLoadModal(config["processingErrors"]["NonCriticalErrors"], "Non-Critical");
        }

        coreConfigData = config;
        await parseData(config);
        document.getElementById("LoadedApplicationName").innerText = coreConfigData["ApplicationName"] + " (" + coreConfigData["Version"] + ")";
        document.getElementById("LoadedApplicationType").innerText = coreConfigData["Type"];

        switch (executionMethod) {
            case "LoadWebApplication":
                updateButtons();
                break;
            case "CopyWebApplication":
                document.getElementById("AlertModal-Text-Paragraph").innerText = "Your " + coreConfigData["ApplicationName"] + " Application is ready. Click OK to start updating the configuration."
                document.getElementById("ProcessingWebConfigValuesProgress").style.display = "none";
                document.getElementById("OnBase-Configuration-Main-Button").click();
                document.getElementById("AlertModal").style.display = "block";
                break;
        }
    }
}


/********************************************************
 *            Load Available Web Applications
 ********************************************************/
function loadWebApplications() {
    document.getElementById("Open-Button").disabled = true;
    document.getElementById("Loading-Web-Applications-Progress-Section").style.display = "flex";
    document.getElementById("chooseWebApplicationModal-Table-Buttons-Container").style.display = "none";
    let webAppTable = document.getElementById("webApplicationTable");
    let tbody = document.getElementById("webApplicationTable").getElementsByTagName('tbody')[0];
    if (tbody != null) {
        webAppTable.removeChild(webAppTable.getElementsByTagName('tbody')[0]);
    }
    fetch(apiRootUrl + "/api/Endpoint/GetApplications", {
        method: "GET",
    })
        .then(response => response.json())
        .then(data => parseWebApplicationsResponse(data));
}

async function parseWebApplicationsResponse(applications) {
    webApplications = applications["webApps"];
    await createAvailableWebApplicationsTable(webApplications);
    document.getElementById("Loading-Web-Applications-Progress-Section").style.display = "none";
    document.getElementById("chooseWebApplicationModal-Table-Buttons-Container").style.display = "block";
}

async function createAvailableWebApplicationsTable(webApplications) {
    let table = document.getElementById("webApplicationTable");
    let tbody = document.createElement("tbody");
    Array.from(webApplications).forEach((element) => {
        let tr = document.createElement('tr');
        tr.setAttribute("class", "webApplicationTableRowBody");
        let tdName = document.createElement('td');
        tdName.innerText = element.name;
        tdName.setAttribute("id", "tdName");
        tdName.addEventListener("click", tableRowSelected);
        tdName.addEventListener("dblclick", okButtonClicked);
        let tdType = document.createElement('td');
        tdType.innerText = element.type;
        tdType.setAttribute("id", "tdType");
        tdType.addEventListener("click", tableRowSelected);
        tdType.addEventListener("dblclick", okButtonClicked);
        let tdVersion = document.createElement('td');
        tdVersion.innerText = element.version;
        tdVersion.setAttribute("id", "tdVersion");
        tdVersion.addEventListener("click", tableRowSelected);
        tdVersion.addEventListener("dblclick", okButtonClicked);
        let tdSite = document.createElement('td');
        tdSite.innerText = element.site;
        tdSite.setAttribute("id", "tdSite");
        tdSite.addEventListener("click", tableRowSelected);
        tdSite.addEventListener("dblclick", okButtonClicked);
        let tdLocation = document.createElement('td');
        tdLocation.innerText = element.path;
        tdLocation.setAttribute("id", "tdLocation");
        tdLocation.addEventListener("click", tableRowSelected);
        tdLocation.addEventListener("dblclick", okButtonClicked);
        let tdBitness = document.createElement('td');
        tdBitness.innerText = element.bitness;
        tdBitness.setAttribute("id", "tdBitness");
        tdBitness.addEventListener("click", tableRowSelected);
        tdBitness.addEventListener("dblclick", okButtonClicked);
        tr.appendChild(tdName);
        tr.appendChild(tdType);
        tr.appendChild(tdVersion);
        tr.appendChild(tdSite);
        tr.appendChild(tdLocation);
        tr.appendChild(tdBitness);
        tbody.appendChild(tr);
        tdIdValue++;
    })

    table.appendChild(tbody);
    await sortTable(0, "webApplicationTable");
}

function okButtonClicked() {
    configurationChanged = false;
    let applicationSelectedToLoad = document.getElementsByClassName("applicationSelected")[0];
    Array.from(applicationSelectedToLoad.children).forEach((element) => {
        if (element.id === "tdName") {
            let object = webApplications.filter(path => path.name === element.innerHTML);
            sessionStorage.setItem('WebApplicationChosenArray', JSON.stringify(object));
            switch (object[0].type) {
                case "Application Server":
                    window.location.href = apiRootUrl + "/Core/ApplicationServer";
                    break;
                case "Agenda Online":
                    window.location.href = apiRootUrl + "/Core/AgendaOnlineServer";
                    break;
                case "Electronic Plan Review":
                    window.location.href = apiRootUrl + "/Core/ElectronicPlanReview";
                    break;
                case "Gateway Caching Server":
                    window.location.href = apiRootUrl + "/Core/GatewayCachingServer";
                    break;
                case "Healthcare Form Manager":
                    window.location.href = apiRootUrl + "/Core/HealthcareFormManager";
                    break;
                case "Patient Window":
                    window.location.href = apiRootUrl + "/Core/OnBasePatientWindow";
                    break;
                case "Public Access - Legacy":
                    window.location.href = apiRootUrl + "/Core/PublicAccessViewerLegacy"
                    break;
                case "Public Access - Next Gen":
                    window.location.href = apiRootUrl + "/Core/PublicAccessViewerNextGen"
                    break;
                case "Reporting Viewer":
                    window.location.href = apiRootUrl + "/Core/ReportingWebViewer";
                    break;
                case "Web Server":
                    window.location.href = apiRootUrl + "/Core/WebServer";
                    break;
            }
        }
    });
}


/********************************************************
*                  General Functions
********************************************************/
async function getBooleanFieldValue(config, elementID, booleanKeyName) {
    //console.log(config);
    //console.log("The element ID is {0} and the boolean key name is {1}.", elementID, booleanKeyName);
    //console.log(booleanKeyName);
    if (document.getElementById(elementID).checked != (config[booleanKeyName]?.toLowerCase() === 'true')) {
        config[booleanKeyName] = document.getElementById(elementID).checked.toString();
    }
}

function getOtherFieldValue(config, elementID, otherKeyName) {
    //console.log(config);
    //console.log("The element ID is {0} and the other key name is {1}.", elementID, otherKeyName);
    //console.log(otherKeyName);
    if (document.getElementById(elementID).value != config[otherKeyName]) {
        config[otherKeyName] = document.getElementById(elementID).value;
    }
}

async function setBooleanFieldValue(config, elementID, booleanKeyName) {
    //console.log(config);
    //console.log("The element ID is {0} and the boolean key name is {1}.", elementID, booleanKeyName);
    //console.log(booleanKeyName);
    document.getElementById(elementID).checked = (config[booleanKeyName].toLowerCase() === 'true');
}

async function setOtherFieldValue(config, elementID, otherKeyName) {
    //console.log((config["minimumValue"]) != undefined);
    //console.log((config["maximumValue"]) != undefined);
    //console.log(config);
    document.getElementById(elementID).value = config[otherKeyName];
    if (config["minimumValue"] != "" && config["minimumValue"] != undefined) {
        if (config["maximumValue"] != "") {
            document.getElementById(elementID).setAttribute("min", config["minimumValue"]);
            document.getElementById(elementID).setAttribute("max", config["maximumValue"]);
            //Need to add a brand new listener to the element to validate the value.
            document.getElementById(elementID).addEventListener("input", function () {
                validateNumericValue(document.getElementById(elementID));
            });
            await validateNumericValue(document.getElementById(elementID));
        } else {
            document.getElementById(elementID).setAttribute("min", config["minimumValue"]);
            document.getElementById(elementID).addEventListener("input", function () {
                validateNumericValue(document.getElementById(elementID));
            });
            await validateNumericValue(document.getElementById(elementID));
        }
    } else if (config["maximumValue"] != "" && config["minimumValue"] != undefined) {
        document.getElementById(elementID).setAttribute("max", config["maximumValue"]);
        document.getElementById(elementID).addEventListener("input", function () {
            validateNumericValue(document.getElementById(elementID));
        });
        await validateNumericValue(document.getElementById(elementID));
    }
}

async function adfsEnabledCheckbox(checkbox) {
    if (checkbox.checked == true) {
        document.getElementById("Authentication-Mode").value = "None";
        document.getElementById("Request-Validation-Mode").value = "4.0";
    } else {
        document.getElementById("Authentication-Mode").value = "Windows";
        document.getElementById("Request-Validation-Mode").value = "2.0";
    }
}

async function validateNumericValue(field) {
    //console.log(field);
    if (field.attributes["min"]?.value != null || field.attributes["min"]?.value != undefined) {
        if (parseFloat(field.value) < field.attributes["min"].value) {
            document.querySelectorAll("[id$='Section']").forEach((element) => {
                if (element.contains(field)) {
                    pushErrorToArray([field.id, element.id.replace(/Section$/, ''), "Value below the minimum", "The value input is below the minimum value of " + field.attributes["min"].value + ". Correct to allow saving."]);
                    //document.getElementById(currentErrorSelected[1].innerText + "Link").click();
                }
            });
        } else {
            spliceErrorFromArray(field.id);
        }
    }

    if(field.attributes["max"]?.value != null || field.attributes["max"]?.value != undefined)
    {
        if (parseFloat(field.value) > field.attributes["max"].value) {
            field.value = field.attributes["max"].value;
            document.querySelectorAll("[id$='Section']").forEach((element) => {
                if (element.contains(field)) {
                    pushErrorToArray([field.id, element.id.replace(/Section$/, ''), "Value above the maximum", "The value input is above the maximum value of " + field.attributes["max"].value + ". Correct to allow saving."]);
                }
            });
        } else {
            spliceErrorFromArray(field.id);
        }
    }
}


/********************************************************
*                 Template Name Header
********************************************************/
function updateButtons() {
    document.getElementById("ProcessingWebConfigValuesProgress").style.display = "none";
    document.getElementById("CoreSectionsButtons").style.display = "block";
}

function passwordFieldShowHide(field, button) {
    if (document.getElementById(field).type == "text") {
        document.getElementById(field).type = "password";
        button.removeChild(button.children[0]);
        button.insertAdjacentHTML("beforeend", hiddenPasswordEyeball);
    } else {
        document.getElementById(field).type = "text";
        button.removeChild(button.children[0]);
        button.insertAdjacentHTML("beforeend", shownPasswordEyeball);
    }
}


/********************************************************
*               IIS Configuration Script
********************************************************/
function processModelIdentityTypeChanged(field) {
    switch (field.value) {
        case "SpecificUser":
            document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Username").disabled = false;
            document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Password").disabled = false;
            validateApplicationPoolCredentialsLength(document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Username"));
            validateApplicationPoolCredentialsLength(document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Password"));
            break;
        default:
            document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Username").disabled = true;
            document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Password").disabled = true;
            document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Username-RequiredSvg").style.display = "none";
            document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Password-RequiredSvg").style.display = "none";
            break;
    }
    checkApplicationPoolCredentialsFieldsForErrors();
}

async function validateApplicationPoolCredentialsLength(field) {
    if (document.getElementById(field.id).value.length > 0) {
        document.getElementById(field.id + "-RequiredSvg").style.display = "none";
    } else {
        document.getElementById(field.id + "-RequiredSvg").style.display = "block";
    }

    //Check if the last character is a dollar sign.
    if (field.id === "Iis-Configuration-Application-AppPool-Process-Model-Identity-Username") {
        if (field.value.slice(-1) === "$") {
            document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Password-RequiredSvg").style.display = "none";
            document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Password").disabled = true;
        } else {
            document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Password-RequiredSvg").style.display = "block";
            document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Password").disabled = false;
        }
    }

    await checkApplicationPoolCredentialsFieldsForErrors();
}

async function checkApplicationPoolCredentialsFieldsForErrors() {
    if (document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Username-RequiredSvg").style.display == "block" || document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Password-RequiredSvg").style.display == "block") {
        pushErrorToArray(await findErrorArrayToSet("applicationPoolMissingCredentials"));
    } else {
        spliceErrorFromArray("applicationPoolMissingCredentials");
    }
}

async function AuthenticationToggled(field) {
    if (coreConfigData.Type == "Application Server" || coreConfigData.Type == "Web Server") {
        if (!field.checked && optimizeForWindowsAuth.length > 0) {
            for (let i = 0; i < optimizeForWindowsAuth.length; i++) {
                document.getElementById("OptimizeForWindowsAuth-" + optimizeForWindowsAuth[i]).checked = false;
            }
            optimizeForWindowsAuth.length = 0;
        }
    }
}


/********************************************************
*            Parse IIS Configuration Settings
********************************************************/
function parseIisConfiguration(config) {
    parseIisConfigurationApplication(config["application"]);
    parseIisConfigurationApplicationPool(config["applicationPool"]);
}

function parseIisConfigurationApplication(config) {
    setOtherFieldValue(config, "IIS-Configuration-Application-Application-Pool", "applicationPoolName");
    setOtherFieldValue(config, "IIS-Configuration-Application-Default-Document", "defaultDocument");
    setBooleanFieldValue(config, "IIS-Configuration-Application-PreLoad-Enabled", "preLoadEnabled");
    setBooleanFieldValue(config, "IIS-Configuration-Application-Anonymous-Authentication-RootSpecific", "anonymousAuthentication");
    setBooleanFieldValue(config, "IIS-Configuration-Application-ASPNET-Impersonation-RootSpecific", "aspNetImpersonation");
    setBooleanFieldValue(config, "IIS-Configuration-Application-Windows-Authentication-RootSpecific", "windowsAuthentication");
    setBooleanFieldValue(config, "IIS-Configuration-Application-Use-Application-Pool-Credentials", "useAppPoolCredentials");
}

function parseIisConfigurationApplicationPool(config) {
    setOtherFieldValue(config, "Iis-Configuration-Application-AppPool-General-Net-CLR-Version", "generalNetClrVerson");
    if (coreConfigData["Bitness"] == "32-Bit") {
        document.getElementById("Iis-Configuration-Application-AppPool-General-Enable-32-Bit-Applications").checked = true;
        document.getElementById("Iis-Configuration-Application-AppPool-General-Enable-32-Bit-Applications").disabled = true;
    }
    else if (coreConfigData["Bitness"] == "64-Bit") {
        document.getElementById("Iis-Configuration-Application-AppPool-General-Enable-32-Bit-Applications").checked = false;
        document.getElementById("Iis-Configuration-Application-AppPool-General-Enable-32-Bit-Applications").disabled = true;
    }
    setOtherFieldValue(config, "Iis-Configuration-Application-AppPool-General-Managed-Pipeline-Mode", "generalManagedPilelineMode");
    setOtherFieldValue(config, "Iis-Configuration-Application-AppPool-General-Queue-Length", "generalQueueLength");
    setOtherFieldValue(config, "Iis-Configuration-Application-AppPool-General-Start-Mode", "generalStartMode");
    setOtherFieldValue(config, "Iis-Configuration-Application-AppPool-Process-Model-Identity-Type", "processModelIdentityType");
    setOtherFieldValue(config, "Iis-Configuration-Application-AppPool-Process-Model-Identity-Username", "processModelIdentityUsername");
    setOtherFieldValue(config, "Iis-Configuration-Application-AppPool-Process-Model-Identity-Password", "processModelIdentityPassword");
    setOtherFieldValue(config, "Iis-Configuration-Application-AppPool-Process-Model-Idle-Time-out", "processModelIdleTimeOut");
    setBooleanFieldValue(config, "Iis-Configuration-Application-AppPool-Process-Model-Ping-Enabled", "processModelPingEnabled");
    setOtherFieldValue(config, "Iis-Configuration-Application-AppPool-Cpu-Limit-Interval", "cpuLimitInterval");
    setBooleanFieldValue(config, "Iis-Configuration-Application-AppPool-Rapid-Fail-Protection-Enabled", "rapidFailProtectionEnabled");
    setOtherFieldValue(config, "Iis-Configuration-Application-AppPool-Regular-Time-Interval", "recyclingRegularTimeInterval");
    processModelIdentityTypeChanged(document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Type"));
}


/********************************************************
*           Create Web Application Functions
********************************************************/
function createWebApplication() {
    window.alert("This will be released in a future build.");
}


/********************************************************
*            Saving Web Application Functions
********************************************************/
async function configOkToSave() {
    if (coreConfigData["Type"] === "Application Server") {
        let verification = await preSaveValidationV2();
        if (verification) {
            document.getElementById("ProcessingWebConfig-Label").innerText = "Saving " + coreConfigData["ApplicationName"] + " Web Application...";
            document.getElementById("ProcessingWebConfigValuesProgress").style.display = "block";
            await saveData();
            pushWebApplicationConfiguration();
        } else {
            //TODO Need to find a way to alert the end user about the incorrectly configured Connection String.
            document.getElementById('modalOverlay').style.display = 'block';
            document.getElementById('modalOverlay').style.opacity = '1';
            document.getElementById("successfulSave").style.display = "none";
            document.getElementById("erroredSave").style.display = "block";

            setTimeout(() => {
                document.getElementById('modalOverlay').style.opacity = '0';
                setTimeout(() => {
                    document.getElementById('modalOverlay').style.display = 'none';
                }, 1500);
            }, 1000);
        }
    } else {
        document.getElementById("ProcessingWebConfig-Label").innerText = "Saving " + coreConfigData["ApplicationName"] + " Web Application...";
        document.getElementById("ProcessingWebConfigValuesProgress").style.display = "block";
        await saveData();
        pushWebApplicationConfiguration();
    }
}

async function checkIfOkToIgnoreChangedFields() {
    if (configurationChanged == true) {
        if (confirm("You have unsaved changes. Are you sure you want to ignore them?") == true) {
            //true = Yes/Ok
            return true;
        } else {
            //false = No/Cancel
            return false;
        }
    } else {
        //false = No/Cancel
        return true;
    }
}

function pushWebApplicationConfiguration() {
    console.log(JSON.stringify(coreConfigData));
    const fetchOptions = {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(coreConfigData)
    };
    let stringifiedDataStructure = JSON.stringify(coreConfigData);
    fetch(apiRootUrl + "/api/Endpoint/SaveWebApplication", fetchOptions)
        .then(response => response.json())
        .then(data => processWebApplicationSaveResponse(data));
}

function processWebApplicationSaveResponse(data) {
    document.getElementById("ProcessingWebConfigValuesProgress").style.display = "none";
    successfulSave();
    configurationChanged = false;
}

function saveIisConfiguration(config) {
    saveIisConfigurationApplication(config["application"]);
    saveIisConfigurationApplicationPool(config["applicationPool"]);
}

function saveIisConfigurationApplication(config) {
    getOtherFieldValue(config, "IIS-Configuration-Application-Application-Pool", "applicationPoolName");
    getOtherFieldValue(config, "IIS-Configuration-Application-Default-Document", "defaultDocument");
    getBooleanFieldValue(config, "IIS-Configuration-Application-PreLoad-Enabled", "preLoadEnabled");
    getBooleanFieldValue(config, "IIS-Configuration-Application-Anonymous-Authentication-RootSpecific", "anonymousAuthentication");
    getBooleanFieldValue(config, "IIS-Configuration-Application-ASPNET-Impersonation-RootSpecific", "aspNetImpersonation");
    getBooleanFieldValue(config, "IIS-Configuration-Application-Windows-Authentication-RootSpecific", "windowsAuthentication");
    getBooleanFieldValue(config, "IIS-Configuration-Application-Use-Application-Pool-Credentials", "useAppPoolCredentials");
}

function saveApplicationServerAdminSessionManagerConfiguration(config) {
    getOtherFieldValue(config, "Iis-Configuration-Application-Session-Administration-Users", "sessionAdministrationsUsers");
    getOtherFieldValue(config, "Iis-Configuration-Application-Session-Administration-Roles", "sessionAdministrationsRoles");
}

function saveIisConfigurationApplicationPool(config) {
    getOtherFieldValue(config, "Iis-Configuration-Application-AppPool-General-Net-CLR-Version", "generalNetClrVerson");
    getBooleanFieldValue(config, "Iis-Configuration-Application-AppPool-General-Enable-32-Bit-Applications", "generalEnable32BitApplications");
    getOtherFieldValue(config, "Iis-Configuration-Application-AppPool-General-Managed-Pipeline-Mode", "generalManagedPilelineMode");
    getOtherFieldValue(config, "Iis-Configuration-Application-AppPool-General-Queue-Length", "generalQueueLength");
    getOtherFieldValue(config, "Iis-Configuration-Application-AppPool-General-Start-Mode", "generalStartMode");
    getOtherFieldValue(config, "Iis-Configuration-Application-AppPool-Process-Model-Identity-Type", "processModelIdentityType");
    getOtherFieldValue(config, "Iis-Configuration-Application-AppPool-Process-Model-Identity-Username", "processModelIdentityUsername");
    getOtherFieldValue(config, "Iis-Configuration-Application-AppPool-Process-Model-Identity-Password", "processModelIdentityPassword");
    getOtherFieldValue(config, "Iis-Configuration-Application-AppPool-Process-Model-Idle-Time-out", "processModelIdleTimeOut");
    getBooleanFieldValue(config, "Iis-Configuration-Application-AppPool-Process-Model-Ping-Enabled", "processModelPingEnabled");
    getOtherFieldValue(config, "Iis-Configuration-Application-AppPool-Cpu-Limit-Interval", "cpuLimitInterval");
    getBooleanFieldValue(config, "Iis-Configuration-Application-AppPool-Rapid-Fail-Protection-Enabled", "rapidFailProtectionEnabled");
    getOtherFieldValue(config, "Iis-Configuration-Application-AppPool-Regular-Time-Interval", "recyclingRegularTimeInterval");
    processModelIdentityTypeChanged(document.getElementById("Iis-Configuration-Application-AppPool-Process-Model-Identity-Type"));
}


/********************************************************
 *              COMACON Save Results Modal
 ********************************************************/
function successfulSave() {
    document.getElementById('modalOverlay').style.display = 'block';
    document.getElementById('modalOverlay').style.opacity = '1';
    document.getElementById("successfulSave").style.display = "block";
    document.getElementById("erroredSave").style.display = "none";

    setTimeout(() => {
        document.getElementById('modalOverlay').style.opacity = '0';
        setTimeout(() => {
            document.getElementById('modalOverlay').style.display = 'none';
        }, 1500);
    }, 1000);
}


/********************************************************
 *          COMACON Copy Web Application Modal
 ********************************************************/
function openCopyWebApplicationModal() {
    checkIfOkToIgnoreChangedFields().then((result) => {
        if (result == true) {
            //Yes, the changes can be ignored.
            switch (coreConfigData["Type"]) {
                case "Application Server":
                    document.getElementById("CopyWebApplicationModal-ApplicationServerURLField").style.display = "none";
                    break;
                default:
                    document.getElementById("CopyWebApplicationModal-ApplicationServerURLField").style.display = "flex";
                    break;
            }
            document.getElementById("NewApplicationPoolName-ResultContainer").replaceChildren();
            document.getElementById("NewApplicationName-ResultContainer").replaceChildren();
            document.getElementById("ApplicationServerUrl-ResultContainer").replaceChildren();
            clearCopyApplicationFields('CopyWebApplicationModal-NewApplicationName');
            clearCopyApplicationFields('CopyWebApplicationModal-NewApplicationPoolName');
            clearCopyApplicationFields('CopyWebApplicationModal-ApplicationServerUrl');
            document.getElementById("CopyWebApplicationModal").style.display = "flex";
            document.getElementById("CopyWebApplicationModal-NewApplicationName").focus();
            document.getElementById("CopyWebApplicationModal-NewApplicationName").select();
            checkValidFieldValuesToEnableCopyButton();
        } else {
            //No, the changes cannot be ignored.
            //Do Nothing
        }
    });
}

function closeCopyWebApplicationModal() {
    document.getElementById("CopyWebApplicationModal").style.display = "none";
}

function copyWebApplication() {
    document.getElementById("CopyWebApplicationModal").style.display = "none";
    document.getElementById("ProcessingWebConfig-Label").innerText = "Copying " + coreConfigData["ApplicationName"] + " Web Application...";
    document.getElementById("ProcessingWebConfigValuesProgress").style.display = "block";
    fetch(apiRootUrl + "/api/Endpoint/CopyWebApplication?webApplicationType=" + encodeURIComponent(coreConfigData["Type"]) +
        "&newApplicationPoolName=" + encodeURIComponent(document.getElementById("CopyWebApplicationModal-NewApplicationPoolName").value) +
        "&newApplicationName=" + encodeURIComponent(document.getElementById("CopyWebApplicationModal-NewApplicationName").value) +
        "&newApplicationPathName=" + encodeURIComponent(coreConfigData["Path"]) +
        "&newApplicationSiteName=" + encodeURIComponent(coreConfigData["SiteName"]) +
        "&newApplicationServerUrl=" + encodeURIComponent(document.getElementById("CopyWebApplicationModal-ApplicationServerUrl").value) +
        "&currentApplicationPoolName=" + encodeURIComponent(coreConfigData["IisConfiguration"]["application"]["applicationPoolName"]) +
        "&currentApplicationName=" + encodeURIComponent(coreConfigData["ApplicationName"]) +
        "&currentApplicationPathName=" + encodeURIComponent(coreConfigData["Path"]) +
        "&currentSiteName=" + encodeURIComponent(coreConfigData["SiteName"]) +
        "&currentPhysicalPath=" + encodeURIComponent(coreConfigData["PhysicalPath"]) +
        "&webApplicationVersion=" + encodeURIComponent(coreConfigData["Version"]) +
        "&bitness=" + encodeURIComponent(coreConfigData["bitness"]), {
        method: "GET",
    })
        .then(response => response.json())
        .then(data => checkWhatWebApplicationToParse(data, "CopyWebApplication"));
}

function validateNoDuplicateApplicationName(field) {
    if (field.value != "") {
        fetch(apiRootUrl + "/api/Endpoint/DuplicateApplicationCheck?applicationName=" + encodeURI(field.value) +
            "&siteName=" + encodeURI(coreConfigData["SiteName"]) +
            "&applicationPath=" + encodeURI(coreConfigData["Path"]) +
            "&physicalPath=" + encodeURI(coreConfigData["PhysicalPath"] +
                "&currentApplicationName=" + coreConfigData["ApplicationName"]), {
            method: "GET",
        })
            .then(response => response.json())
            .then(data => parseValidateNoDuplicateApplicationName(data));
    } else {
        checkValidFieldValuesToEnableCopyButton();
    }
}

function parseValidateNoDuplicateApplicationName(data) {
    let section = document.getElementById("NewApplicationName-ResultContainer");
    if (data) {
        section.replaceChildren();
        section.insertAdjacentHTML("beforeend", greenCheckMark);
    } else {
        section.replaceChildren();
        section.insertAdjacentHTML("beforeend", redX);
    }
    checkValidFieldValuesToEnableCopyButton();
}

function validateNoDuplicateApplicationPoolName(field) {
    if (field.value != "") {
        fetch(apiRootUrl + "/api/Endpoint/DuplicateAppPoolCheck?appPoolName=" + encodeURI(field.value), {
            method: "GET",
        })
            .then(response => response.json())
            .then(data => parseValidateNoDuplicateApplicationPoolName(data));
    } else {
        checkValidFieldValuesToEnableCopyButton();
    }
}

function parseValidateNoDuplicateApplicationPoolName(data) {
    let section = document.getElementById("NewApplicationPoolName-ResultContainer");
    if (data) {
        section.replaceChildren();
        section.insertAdjacentHTML("beforeend", greenCheckMark);
    } else {
        section.replaceChildren();
        section.insertAdjacentHTML("beforeend", redX);
    }
    checkValidFieldValuesToEnableCopyButton();
}

function validateApplicationServerURL(field) {
    if (field.value != "") {
        fetch(apiRootUrl + "/api/Endpoint/UrlValidation?url=" + encodeURIComponent(field.value), {
            method: "GET",
        })
            .then(response => response.json())
            .then(data => parseValidateApplicationServerURL(data));
    } else {
        checkValidFieldValuesToEnableCopyButton();
    }
}

function parseValidateApplicationServerURL(data) {
    let section = document.getElementById("ApplicationServerUrl-ResultContainer");
    if (data != '200') {
        section.replaceChildren();
        section.insertAdjacentHTML("beforeend", blackQuestionMark);
    } else {
        section.replaceChildren();
        section.insertAdjacentHTML("beforeend", greenCheckMark);
    }
    checkValidFieldValuesToEnableCopyButton();
}

function resetCopyApplicationFieldContainerStatusSvg(containerId) {
    let section = document.getElementById(containerId);
    section.replaceChildren();
    section.insertAdjacentHTML("beforeend", blackQuestionMark);
    checkValidFieldValuesToEnableCopyButton();
}

function clearCopyApplicationFields(fieldId) {
    document.getElementById(fieldId).value = "";
}

function checkValidFieldValuesToEnableCopyButton() {
    let ApplicationNameCheck = false;
    let ApplicationPoolNameCheck = false;
    let ApplicationUrlCheck = false;

    if (document?.getElementById("NewApplicationName-ResultContainer")?.children[0]?.attributes["name"]?.value == "Green-Check-Mark") {
        ApplicationNameCheck = true;
    } else {
        ApplicationNameCheck = false;
    }

    //Checks if the New Application Pool Name field value is valid or not.
    if (document?.getElementById("NewApplicationPoolName-ResultContainer")?.children[0]?.attributes["name"]?.value == "Green-Check-Mark") {
        ApplicationPoolNameCheck = true;
    } else {
        ApplicationPoolNameCheck = false;
    }

    //Checks if the Application Server URL is at least filled in.
    if (document?.getElementById("CopyWebApplicationModal-ApplicationServerUrl")?.value != "") {
        ApplicationUrlCheck = true;
    } else {
        ApplicationUrlCheck = false;
    }

    //Checks if all of the fields are valid/filled in. If so, it enables the Copy button. Otherwise, it disables it.
    switch (coreConfigData["Type"]) {
        case "Application Server":
            if ((ApplicationNameCheck && ApplicationPoolNameCheck) || ApplicationUrlCheck) {
                document.getElementById("Copy-Button").disabled = false;
            } else {
                document.getElementById("Copy-Button").disabled = true;
            }
            break;
        default:
            if (ApplicationNameCheck && ApplicationPoolNameCheck && ApplicationUrlCheck) {
                document.getElementById("Copy-Button").disabled = false;
            } else {
                document.getElementById("Copy-Button").disabled = true;
            }
            break;
    }

}


/********************************************************
 *         COMACON Application Choosing Scripts
 ********************************************************/
async function sortTable(n, table) {
    var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
    table = document.getElementById(table);
    switching = true;
    //Set the sorting direction to ascending:
    dir = "asc";
    /*Make a loop that will continue until
    no switching has been done:*/
    while (switching) {
        //start by saying: no switching is done:
        switching = false;
        rows = table.rows;
        /*Loop through all table rows (except the
        first, which contains table headers):*/
        for (i = 1; i < (rows.length - 1); i++) {
            //start by saying there should be no switching:
            shouldSwitch = false;
            /*Get the two elements you want to compare,
            one from current row and one from the next:*/
            x = rows[i].getElementsByTagName("TD")[n];
            y = rows[i + 1].getElementsByTagName("TD")[n];
            /*check if the two rows should switch place,
            based on the direction, asc or desc:*/
            if (dir == "asc") {
                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                    //if so, mark as a switch and break the loop:
                    shouldSwitch = true;
                    break;
                }
            } else if (dir == "desc") {
                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                    //if so, mark as a switch and break the loop:
                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {
            /*If a switch has been marked, make the switch
            and mark that a switch has been done:*/
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            //Each time a switch is done, increase this count by 1:
            switchcount++;
        } else {
            /*If no switching has been done AND the direction is "asc",
            set the direction to "desc" and run the while loop again.*/
            if (switchcount == 0 && dir == "asc") {
                dir = "desc";
                switching = true;
            }
        }
    }
}

async function openModal() {
    checkIfOkToIgnoreChangedFields().then((result) => {
        if (result == true) {
            //Yes, the changes can be ignored.
            console.log("The changes can be ignored.");
            loadWebApplications();
            document.getElementById("chooseWebApplicationModal").style.display = "block";
        } else {
            //No, the changes cannot be ignored.
            //Do Nothing
            console.log("The changes cannot be ignored.");
        }
    });
}

function closeModalX() {
    document.getElementById("chooseWebApplicationModal").style.display = "none";
}

function tableRowSelected(cell) {
    let currentSelectedRow = document.getElementsByClassName("applicationSelected");
    if (currentSelectedRow.length > 0) {
        currentSelectedRow[0].classList.remove("applicationSelected");
    } else {
        cell.srcElement.parentElement.classList.add("applicationSelected");
    }
    cell.srcElement.parentElement.classList.add("applicationSelected");
    document.getElementById("Open-Button").disabled = false;
}


/********************************************************
*           Testing V2 of Core link calling
********************************************************/
function openSection(tabtoopen) {
    //Hide the current view open.
    let openSections = document.getElementsByClassName("tabcontent");
    for (let i = 0; i < openSections.length; i++) {
        openSections[i].style.display = "none";
    }

    //Set the Title
    document.getElementById("SectionTitle").innerText = document.getElementById(tabtoopen + "Link").innerText;

    //Display the section
    document.getElementById(tabtoopen + "Section").style.display = "block";
}



/********************************************************
*                 Testing URL's Functions
********************************************************/
function testUrl(field) {
    if (!field.currentTarget.classList.contains("validUrl", "invalidUrl")) {
        let id = field.currentTarget.id;
        field.currentTarget.disabled = true;
        document.getElementById(id + "-Loader").style.display = "block";
        fetch(apiRootUrl + "/api/Endpoint/UrlValidation?url=" + encodeURIComponent(field.currentTarget.value))
            .then(response => response.json())
            .then(data => parseTestUrlResponse(data, id));
    }
}

function parseTestUrlResponse(data, id) {
    if (data != '200') {
        document.getElementById(id).classList.add("invalidUrl");
    } else {
        document.getElementById(id).classList.add("validUrl");
    }
    document.getElementById(id + "-Loader").style.display = "none";
    document.getElementById(id).disabled = false;
}



/********************************************************
*          Error Notification Bell Functions
********************************************************/
function showErrorModal() {
    const tbody = document.getElementById("SaveErrorsTable").getElementsByTagName("tbody")[0];

    //Clears any previous table tbody elements.
    while (tbody.firstChild) {
        tbody.removeChild(tbody.firstChild);
    }

    //Adds all of the errors to the tbody element.
    for (let i = 0; i < errorsArray.length; i++) {
        let tr = document.createElement('tr');
        tr.setAttribute("class", "SaveErrorsTableBodyRow");
        let errorNumber = document.createElement('td');
        errorNumber.innerText = i + 1;
        errorNumber.addEventListener("click", errorRowSelected);
        errorNumber.addEventListener("dblclick", viewButtonClicked);
        let section = document.createElement('td');
        section.innerText = errorsArray[i][1];
        section.addEventListener("click", errorRowSelected);
        section.addEventListener("dblclick", viewButtonClicked);
        let title = document.createElement('td');
        title.innerText = errorsArray[i][2];
        title.addEventListener("click", errorRowSelected);
        title.addEventListener("dblclick", viewButtonClicked);
        let reason = document.createElement('td');
        reason.innerText = errorsArray[i][3];
        reason.addEventListener("click", errorRowSelected);
        reason.addEventListener("dblclick", viewButtonClicked);
        tr.appendChild(errorNumber);
        tr.appendChild(section);
        tr.appendChild(title);
        tr.appendChild(reason);
        tbody.appendChild(tr);
    }
    document.getElementById("SaveErrors-Modal").style.display = "block";
    document.getElementById("SaveErrors-ViewButton").disabled = true;
}

function closeErrorModal() {
    document.getElementById("SaveErrors-Modal").style.display = "none";
}

function errorRowSelected(cell) {
    let currentErrorSelected = document.getElementsByClassName("errorSelected");

    if (currentErrorSelected.length > 0) {
        currentErrorSelected[0].classList.remove("errorSelected");
    } else {
        cell.srcElement.parentElement.classList.add("errorSelected");
    }
    document.getElementById("SaveErrors-ViewButton").disabled = false;
}

function viewButtonClicked() {
    const currentErrorSelected = document.getElementsByClassName("errorSelected")[0].childNodes;

    document.getElementById(currentErrorSelected[1].innerText + "Link").click();
    document.getElementById("SaveErrors-Modal").style.display = "none";
    //Will work on implementing this another time.
    //console.log(errorsArray);
    //console.log(currentErrorSelected[1].innerText);
    //console.log(currentErrorSelected[2].innerText);
    //console.log(currentErrorSelected[3].innerText);
    for (let i = 0; i < errorsArray.length; i++) {
        //console.log(errorsArray[i][0]);
        //console.log(errorsArray[i][1] == currentErrorSelected[1].innerText);
        //console.log(errorsArray[i][1]);
        //console.log(errorsArray[i][2] == currentErrorSelected[2].innerText);
        //console.log(errorsArray[i][2]);
        //console.log(errorsArray[i][3] == currentErrorSelected[3].innerText);
        //console.log(errorsArray[i][3]);
        if (errorsArray[i][1] == currentErrorSelected[1].innerText && errorsArray[i][2] == currentErrorSelected[2].innerText && errorsArray[i][3] == currentErrorSelected[3].innerText) {
            try {
                flashBorderForErrorAlert(document.getElementById(errorsArray[i][0]), 5);
            } catch {

            }
        }
    }
}

function flashBorderForErrorAlert(element, times) {
    let count = 0;

    function changeToRed() {
        element.style.border = '5px solid red';
        setTimeout(changeToBlack, 500);
    }

    function changeToBlack() {
        element.style.border = '2px solid black';
        count++;
        if (count < times) {
            setTimeout(changeToRed, 500);
        }
    }

    // Perform the initial change immediately
    changeToRed();

    // Set up the interval for subsequent changes
    const intervalId = setInterval(() => {
        if (count >= times) {
            clearInterval(intervalId);
        } else {
            changeToRed();
        }
    }, 1000);
}



function clickButton(id) {
    return new Promise((resolve) => {
        // Simulate an asynchronous operation
        setTimeout(function () {
            document.getElementById(id).click();
            resolve();
        }, 250);
    });
}

async function pushErrorToArray(array) {
    if (!verifyErrorNotInArrayAlready(array[0])) {
        errorsArray.push(array);
        updateNotificationCount();
    }
}

function updateNotificationCount() {
    if (errorsArray.length == 0) {
        document.getElementById("notification-count").style.display = "none";
        document.getElementById("notification-span").innerText = "";
        setElementDisabled("Save-Web-Application-Core-Action-Button", false);
    } else {
        document.getElementById("notification-count").style.display = "block";
        document.getElementById("notification-span").innerText = errorsArray.length;
        setElementDisabled("Save-Web-Application-Core-Action-Button", true);
    }
}

async function spliceErrorFromArray(value) {
    for (let i = 0; i < errorsArray.length; i++) {
        (errorsArray[i][0] == value) ? errorsArray.splice(i, 1) : null;
    }
    updateNotificationCount();
}

function verifyErrorNotInArrayAlready(ErrorName) {
    for (let i = 0; i < errorsArray.length; i++) {
        if (errorsArray[i][0] === ErrorName) {
            return true;
        }
    }

    return false;
}

async function validateDataSourceFieldSelectionToConnectionStringArrayV2() {
    try {
        let selIndex = document.getElementById("Data-Source").selectedIndex;
        let dsvalue = document.getElementById("Data-Source").options[selIndex].text;
        let validDSName = ConnectionStringsArray.filter(dsname => dsname.Name === dsvalue);
        if (validDSName.length == 0) {
            return false;
        } else {
            return true;
        }
    } catch {
        return false;
    }
}


/********************************************************
*               Save Validation Functions
********************************************************/
async function preSaveValidationV2() {
    console.log(ConnectionStringsArray.length);
    if (ConnectionStringsArray.length > 0) {
        if (await validateDataSourceFieldSelectionToConnectionStringArrayV2()) {
            return true;
        } else {
            return false;
        }
    } else {
        return true;
    }
}


/********************************************************
*          Unknown Configuration Keys Functions
********************************************************/
function openUnknownConfigurationKeysModal() {
    document.getElementById("UnknownConfigurationKeys-Modal").style.display = "block";
}

function closeUnknownConfigurationKeysModal() {
    document.getElementById("UnknownConfigurationKeys-Modal").style.display = "none";
}

function copyToClipboardPreparation(TableName) {
    let textToCopy = "";

    switch (TableName) {
        case "Elements":
            copyToClipboard(document.getElementById("UnknownConfigurationKeysElementsTable").outerHTML);
            break;
        case "Attributes":
            copyToClipboard(document.getElementById("UnknownConfigurationKeysAttributesTable").outerHTML);
            break;
    }
}

function copyToClipboard(text) {
    // Use the Clipboard API to copy text to the clipboard
    navigator.clipboard.writeText(text)
        .then(() => {
            console.log('Text successfully copied to clipboard');
        })
        .catch(err => {
            console.error('Unable to copy text to clipboard', err);
        });
}

function sendUnknowAttributesElementsEmail(TableName) {
    let mailtoLink = document.createElement('a');

    // Set the href attribute with the mailto: link
    mailtoLink.href = 'mailto:recipient@example.com';

    // Simulate a click on the anchor tag
    mailtoLink.click()
}



/********************************************************
*               Parsing web.config data V2
********************************************************/
async function parseData(config) {
    configurationChanged = false;
    await parseKnownElements(config["knownKeys"]);
    await parseKnownElements(config["translatorKnownKeys"]);
    await parseUnknownKeys(config["unknownElementKeys"], "UnknownConfigurationKeysElementsTable");
    await parseUnknownKeys(config["unknownAttributeKeys"], "UnknownConfigurationKeysAttributesTable");
    await parseIisConfiguration(config["IisConfiguration"]);
    await parseHylandLogging(config["hylandLogging"]);
    await parseElementsToHide(config["elementsToHide"]);
    await parseTooltips(config["tooltips"]);

    switch (config["Type"]) {
        case "Agenda Online":
            //await parseHylandApplicationsAgendaPubAccessPublicComment(config["hylandApplicationsAgendaPubAccessPublicComment"]);
            await parseHylandApplicationsAgendaPubAccessPublicCommentIntegrations(config);
            break;
        case "Application Server":
            await parseADFS(config["hylandAuthenticationADFS"]);
            await parseConnectionStrings(config["connectionStrings"]);
            await parseHylandAuthentication(config["hylandAuthentication"]);
            await parseHylandPlatterManagement(config["hylandPlatterManagement"]);
            await parseWindowsAuthOptimization(config["WindowsAuthOptimizeFor"]);
            await parseSessionAdministration(config["sessionAdministration"]);
            await parseResponsiveAppsApp(config["hylandResponsiveApps"]);
            break;
        case "Electronic Plan Review":
            await prepareAndSetDefaultTimeZoneOptions();
            break;
        case "Gateway Caching Server":
            break;
        case "Healthcare Form Manager":
            await parseHylandIdentityProvider(config["hylandIdentityProviderUrl"]);
            break;
        case "Patient Window":
            await parseHylandIdentityProvider(config["hylandIdentityProviderUrl"]);
            await parseADFS(config["hylandAuthenticationADFS"]);
            break;
        case "Public Access - Legacy":
            await parseRequiredKeywords(config["requiredKeywords"]);
            break;
        case "Public Access - Next Gen":
            await parseRequiredKeywords(config["requiredKeywords"]);
            break;
        case "Reporting Viewer":
            await parseWindowsAuthOptimization(config["WindowsAuthOptimizeFor"]);
            await parseHylandIdentityProvider(config["hylandIdentityProviderUrl"]);
            break;
        case "Web Server":
            await parseHylandIdentityProvider(config["hylandIdentityProviderUrl"]);
            await parseADFS(config["hylandAuthenticationADFS"]);
            await parseCustomValidation(config["customValidation"]);
            await parseWindowsAuthOptimization(config["WindowsAuthOptimizeFor"]);
            await parseNavigationPanel(config["navigationPanel"]);
            await parseKeywordDropDownTypeAhead(config["keywordDropdownTypeAhead"]);
            await parseHealthcareWebViewerSourceOrigins(config["healthcareWebViewer"]);
            break;
    }

    if (config["unknownElementKeys"].length == 0 && config["unknownAttributeKeys"].length == 0) {
        document.getElementById("Unknown-Configuration-Keys-Link").style.display = "none";
    } else if (config["unknownElementKeys"].length == 0 && config["unknownAttributeKeys"].length > 0) {
        document.getElementById("UnknownConfigurationKeysElements-Section").style.display = "none";
        document.getElementById("UnknownConfigurationKeysAttributes-Section").style.display = "block";
    } else if (config["unknownElementKeys"].length > 0 && config["unknownAttributeKeys"].length == 0) {
        document.getElementById("UnknownConfigurationKeysElements-Section").style.display = "block";
        document.getElementById("UnknownConfigurationKeysAttributes-Section").style.display = "none";
    }

    // Add event listener to the form element
    const body = document.getElementById('myBody');

    body.addEventListener('input', function (event) {
        // Check if the event target is an input element
        if (event.target.tagName.toLowerCase() === 'input') {
            //console.log(`Input changed: ${event.target.name}, Value: ${event.target.value}`);
            // Perform your desired operations here
            if (event.target.id != "checkbox") {
                configurationChanged = true;
            }
        }
    });

    body.addEventListener('change', function (event) {
        // Check if the event target is an input element
        if (event.target.tagName.toLowerCase() === 'select') {
            //console.log(`Input changed: ${event.target.name}, Value: ${event.target.value}`);
            // Perform your desired operations here
            configurationChanged = true;
        }
    });

    window.addEventListener('beforeunload', function (event) {
        if (configurationChanged) {
            // Standard message (not customizable in most browsers)
            const confirmationMessage = 'You have unsaved changes. Are you sure you want to leave this page?';

            // Some older browsers might require event.returnValue to be set
            event.returnValue = confirmationMessage;
            return confirmationMessage;
        }
    });
}

async function parseResponsiveAppsApp(config) {
    //console.log(config);
    responsiveAppsApps = config["responsiveApps"];
    let responsiveAppsAppsSelectList = document.getElementById("ResponsiveAppsApp-SelectList");
    for (let i = 0; i < responsiveAppsApps.length; i++) {
        let opt = document.createElement("option");
        opt.value = "ResponsiveAppsApp" + responsiveAppsAppsIdNumber;
        opt.innerText = responsiveAppsApps[i].Name;
        responsiveAppsApps[i].id = "ResponsiveAppsApp" + responsiveAppsAppsIdNumber;
        responsiveAppsAppsSelectList.append(opt);
        responsiveAppsAppsIdNumber++;
    }
}

async function parseTooltips(config) {
    for (let i = 0; i < config.length; i++) {
        //console.log(config[i]);
        if (config[i]["tooltip"].includes("<br>")) {
            document.getElementById(config[i]["htmlId"]).innerHTML = config[i]["tooltip"];
        } else {
            document.getElementById(config[i]["htmlId"]).innerText = config[i]["tooltip"];
        }
    }
}

async function parseElementsToHide(config) {
    if (config["elements"].length > 0) {
        for (let i = 0; i < config["elements"].length; i++) {
            document.getElementById(config["elements"][i]["HtmlName"]).style.display = "none";
        }
    }
}

async function parseSessionAdministration(config) {
    sessionadministrationusers = config["users"];
    sessionadministrationroles = config["roles"];
    sessionadministrationusersidnumber = sessionadministrationusers.length;
    sessionadministrationrolesidnumber = sessionadministrationroles.length;

    if (sessionadministrationusers.length > 0) {
        for (let i = 0; i < sessionadministrationusers.length; i++) {
            let opt = document.createElement("option");
            opt.value = "SessionAdministrationUser" + i;
            opt.innerText = sessionadministrationusers[i].user;
            document.getElementById("SessionAdministration-User-SelectList").append(opt);
            sessionadministrationusers[i].id = "SessionAdministrationUser" + i;
        }
    }

    if (sessionadministrationroles.length > 0) {
        for (let i = 0; i < sessionadministrationroles.length; i++) {
            let opt = document.createElement("option");
            opt.value = "SessionAdministrationRole" + i;
            opt.innerText = sessionadministrationroles[i].role;
            document.getElementById("SessionAdministration-Role-SelectList").append(opt);
            sessionadministrationroles[i].id = "SessionAdministrationRole" + i;
        }
    }
}

async function parseHealthcareWebViewerSourceOrigins(config) {
    hwvSourceOriginWhiteList = config["Origins"];
    let hwvSourceOriginWhiteListSelectList = document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist-SelectList");
    for (let i = 0; i < hwvSourceOriginWhiteList.length; i++) {
        let originOption = document.createElement("option");
        originOption.setAttribute("value", "HCWVSourceOrigin" + i);
        originOption.innerText = hwvSourceOriginWhiteList[i].origin;
        hwvSourceOriginWhiteListSelectList.append(originOption);
        hwvSourceOriginWhiteList[i].id = "HCWVSourceOrigin" + i;
    }
    hwvSourceOriginWhiteListIdNumber = hwvSourceOriginWhiteList.length;
}

async function parseKeywordDropDownTypeAhead(config) {
    let kwddtaSelectList = document.getElementById("KeywordTypeahead-SelectList");
    keywordTypeAheadArray = config["characterMinimums"];

    for (let i = 0; i < keywordTypeAheadArray.length; i++) {
        let opt = document.createElement("option");
        opt.setAttribute("value", "keywordtypeahead" + keywordTypeAheadIdNumber);
        opt.setAttribute("error-text-to-append", "");
        opt.innerText = keywordTypeAheadArray[i]["KeywordID"] + " (" + keywordTypeAheadArray[i]["CharacterCount"] + ")";
        keywordTypeAheadArray[i].id = "keywordtypeahead" + keywordTypeAheadIdNumber;
        kwddtaSelectList.append(opt);
        keywordTypeAheadIdNumber++;
    }
}

async function parseHylandPlatterManagement(config) {
    diskGroupAliases = config["diskGroupAliases"];
    let diskGroupAliasesSelectList = document.getElementById("DiskGroupAliases-SelectList");

    for (let i = 0; i < diskGroupAliases.length; i++) {
        let opt = document.createElement("option");
        opt.setAttribute("value", "diskgroupalias" + diskGroupAliasIdNumber);
        opt.innerText = diskGroupAliases[i]["oldname"];
        diskGroupAliases[i].id = "diskgroupalias" + diskGroupAliasIdNumber;
        diskGroupAliasesSelectList.append(opt);
        diskGroupAliasIdNumber++;
    }

    await lockDiskGroupAliasesFields('true');
}

async function parseHylandAuthentication(config) {
    setBooleanFieldValue(config, "Trust-Mode", "TrustMode");

    let trustedClientsSelectList = document.getElementById("TrustedClients-SelectList");
    trustedClients = config["trustedClients"];
    for (let i = 0; i < trustedClients.length; i++) {
        let opt = document.createElement("option");
        opt.setAttribute("value", "trustedclient" + trustedClientIdNumber);
        opt.innerText = trustedClients[i]["Description"];
        trustedClients[i].id = "trustedclient" + trustedClientIdNumber;
        trustedClientsSelectList.append(opt);
        trustedClientIdNumber++;
    }
}

async function parseNavigationPanel(config) {
    NavigationPanelContexts = config["Contexts"];
    let navPanelSelectList = document.getElementById("NavigationPanel-SelectList");
    let DefaultContextSelectList = document.getElementById("Default-Context");
    for (let i = 0; i < NavigationPanelContexts.length; i++) {
        let opt = document.createElement("option");
        opt.value = "NavigationPanel" + NavigationPanelContextsIdNumber;
        opt.innerText = NavigationPanelContexts[i]["contextInfo"]["displayName"];
        opt.style.padding = "0 5px";
        NavigationPanelContexts[i]["id"] = "NavigationPanel" + NavigationPanelContextsIdNumber;
        navPanelSelectList.append(opt);
        DefaultContextSelectList.append(opt.cloneNode(true));

        NavigationPanelContextsIdNumber++;
    }

    let DefaultContextSelectListValue = "";
    let DefaultControlBars = "";
    if (config["defaultContext"] != "") {
        DefaultContextSelectListValue = NavigationPanelContexts.filter(context => context["contextInfo"]["name"] == config["defaultContext"]);
        DefaultControlBars = DefaultContextSelectListValue[0]["ControlBars"];
        document.getElementById("Default-Context").value = DefaultContextSelectListValue[0]["id"];
    }

    await defaultContextChanged();
    document.getElementById("Default-Control-Bar").value = config["defaultControlBar"];
    document.getElementById("Default-Context-ID").value = config["defaultContextID"];
}

async function parseWindowsAuthOptimization(config) {
    config.forEach(element => {
        document.getElementById("OptimizeForWindowsAuth-" + element).checked = true;
    });
    optimizeForWindowsAuth = config;
}

async function parseConnectionStrings(config) {
    ConnectionStringsArray = config["connectionStrings"];
    if (ConnectionStringsArray.length > 0) {
        let cstringSelectList = document.getElementById("ConnectionStrings-SelectList");
        for (let i = 0; i < ConnectionStringsArray.length; i++) {
            let opt = document.createElement("option");
            opt.setAttribute("value", "connectionstring" + connectionStringIdNumber);
            opt.setAttribute("class", "connectionStringOption");
            opt.setAttribute("error-text-to-append", "");
            opt.setAttribute("related-duplicates", "");
            opt.innerText = ConnectionStringsArray[i].Name;
            ConnectionStringsArray[i].id = "connectionstring" + connectionStringIdNumber;
            cstringSelectList.append(opt);
            connectionStringIdNumber++;
        }

        await disableConnectionStringFieldsV3("true");
        await createDataSourceOptionsV2();
        let datasourceknownkeyvalue = coreConfigData["knownKeys"].filter(result => result.htmlIdName === "Data-Source");
        let datasourceobject = ConnectionStringsArray.filter(res => res.Name === datasourceknownkeyvalue[0]["Value"])

        
        if (datasourceobject.length > 0) {
            document.getElementById(datasourceknownkeyvalue[0]["htmlIdName"]).value = "DataSource" + datasourceobject[0]["id"];
        } else {
            document.getElementById(datasourceknownkeyvalue[0]["htmlIdName"]).value = "";
        }
        
        setBooleanFieldValue(config, "Encrypt-Connection-Strings", "EncryptConnectionStrings");
    }
}

async function createDataSourceOptionsV2() {
    let dataSourceElement = document.getElementById("Data-Source");

    //Adds options back based upon what is in the ConnectionStringsArray array variable.
    for (let i = 0; i < ConnectionStringsArray.length; i++) {
        let opt = document.createElement('option');
        opt.innerText = ConnectionStringsArray[i]["Name"];
        opt.setAttribute("value", "DataSource" + ConnectionStringsArray[i]["id"]);
        dataSourceElement.appendChild(opt);
    }
}

async function parseHylandIdentityProvider(config) {
    document.getElementById("IdP-Server-Location").value = config["ServerLocation"];
    document.getElementById("IdP-Tenant").value = config["Tenant"];
    document.getElementById("IdP-Client").value = config["Client"];
    document.getElementById("IdP-Secret").value = config["Secret"];
}

async function parseRequiredKeywords(config) {
    requiredKeywordsArray = config;
    let tbody = document.getElementById("Required-Keywords-Table-Tbody");

    Array.from(config).forEach((element) => {
        let tr = document.createElement('tr');
        let tdQueryID = document.createElement('td');
        tdQueryID.innerText = element.QueryID;
        tdQueryID.setAttribute("id", "tdQueryID");
        tdQueryID.addEventListener("click", requiredKeywordRowSelected);
        let tdKeywordID = document.createElement('td');
        tdKeywordID.innerText = element.KeywordID;
        tdKeywordID.setAttribute("id", "tdKeywordID");
        tdKeywordID.addEventListener("click", requiredKeywordRowSelected);
        tr.appendChild(tdQueryID);
        tr.appendChild(tdKeywordID);
        tbody.appendChild(tr);
    })
}

async function parseHylandApplicationsAgendaPubAccessPublicComment(config) {
    let meetingtypes = config["meetingTypes"];
    let meetingtypenames = "";
    for (let i = 0; i < meetingtypes.length; i++) {
        if (i == 0) {
            meetingtypenames += meetingtypes[i]["Name"];
        } else {
            meetingtypenames += "," + meetingtypes[i]["Name"];
        }
    }
    document.getElementById("Meeting-Type-Name").value = meetingtypenames;

    AgendaOnlineAgendaFields = config["agendaFields"];
    let selectListFieldsDropDown = document.getElementById("Form-Field-Select-List");
    for (let i = 0; i < AgendaOnlineAgendaFields.length; i++) {
        let newFieldDropDownOption = document.createElement("option");
        newFieldDropDownOption.value = AgendaOnlineAgendaFields[i]["Name"];
        newFieldDropDownOption.text = AgendaOnlineAgendaFields[i]["Name"];
        selectListFieldsDropDown.append(newFieldDropDownOption);
    }
}

async function parseHylandApplicationsAgendaPubAccessPublicCommentIntegrations(config) {
    AgendaOnlineIntegrations = config["publicCommentIntegrations"];

    if (AgendaOnlineIntegrations.length > 0) {
        for (let i = 0; i < AgendaOnlineIntegrations.length; i++) {
            let opt = document.createElement("option");
            opt.value = "AgendaOnlineIntegration" + AgendaOnlineIntegrationsIdNumber;
            opt.innerText = AgendaOnlineIntegrations[i].Name;
            document.getElementById("PublicCommentIntegrations-SelectList").append(opt);
            AgendaOnlineIntegrations[i].id = "AgendaOnlineIntegration" + AgendaOnlineIntegrationsIdNumber;
            AgendaOnlineIntegrationsIdNumber++;
        }
    }

    await disableAllAgendaOnlineIntegrationsFields(AgendaOnlineIntegrationsAllFieldIds, true);
    await setAgendaOnlineIntegrationsButtons(["PublicCommentIntegrations-CopyButton", "PublicCommentIntegrations-DeleteButton"], true);
}

async function parseHylandLogging(config) {
    if (config != null) {
        document.getElementById("DiagnosticsSettings-TruncateLogValues").value = config["truncateloggingcharacters"];
        document.getElementById("DiagnosticsSettings-WindowsEventLogging-SourceName").value = config["windowsEventLogging"]["SourceName"];
        await parseHylandLoggingProfiles(config["profilesForHTML"]);
        await parseDiagnosticsSettingsRoutes(config["Routes"]);        
    }
}

async function parseHylandLoggingProfiles(config) {
    for (let i = 0; i < config.length; i++) {
        let div = document.createElement("div");
        div.setAttribute("class", "profile-element");
        let input = document.createElement("input");
        input.setAttribute("type", "checkbox");
        input.setAttribute("name", config[i]);
        input.setAttribute("id", config[i]);
        input.setAttribute("class", "Profiles");
        input.setAttribute("onclick", "profileCheckedUncheckedV2(this)");
        let label = document.createElement("label");
        label.setAttribute("for", config[i]);
        label.innerText = config[i];
        div.appendChild(input);
        div.appendChild(label);

        if (i % 2 == 0) {
            document.getElementById("ProfilesPanel-Column1").appendChild(div);
        } else {
            document.getElementById("ProfilesPanel-Column2").appendChild(div);
        }
    }
}

async function parseDiagnosticsSettingsRoutes(config) {
    let RoutesSelectList = document.getElementById("DiagnosticsSettingsRoutes-SelectList");
    if (config.length > 0) {
        for (let i = 0; i < config.length; i++) {
            let opt = document.createElement("option");
            opt.value = "Route" + diagnosticsSettingsRoutesIdNumber;
            opt.text = config[i]["Name"];
            RoutesSelectList.append(opt);
            diagnosticsSettingsRoutesIdNumber++;
            config[i]["id"] = opt.value;
        }
    }
    diagnosticsRoutes = config;
    await lockUnlockAllDiagnosticsSettingsFields("true");
    await lockAllDiagnosticsProfileFields("true");
    await checkForBadProfiles();
}

async function checkForBadProfiles() {
    let errorMessageText = ``;
    let errorMessageTextToAppend = ``;
    let badProfiles = false;
    diagnosticsRoutes.forEach(route => {
        errorMessageTextToAppend = ``;
        badProfiles = false;
        for(let i = route.filter.Profiles.length - 1; i >= 0; i--) {
            let profile = route.filter.Profiles[i];
            if (document.getElementById(profile) == null) {
                badProfiles = true;
                if (errorMessageTextToAppend == "") {
                    errorMessageTextToAppend = `The following profiles on the ${route.Name} are invalid and will be deleted once you save: \n-"${profile}"\n`;
                } else {
                    errorMessageTextToAppend += `-"${profile}"\n`;
                }
                route.filter.Profiles.splice(i, 1);
            }
        }
        if (errorMessageText == "") {
            errorMessageText = errorMessageTextToAppend;
        } else if (badProfiles) {
            errorMessageText += `\n` + errorMessageTextToAppend;
        }

    });

    if (errorMessageText != "") {
        errorMessageText += `\nIf you believe that this is in error, please support an issue here: https://github.com/rlwakefield/COMACON-MVC/issues`;
        window.alert(errorMessageText);
    }
}

async function parseADFS(config) {
    await setBooleanFieldValue(config, "ADFS-Enabled", "ADFSEnabled");
    await setOtherFieldValue(config, "Request-Validation-Mode", "RequestValidationMode");
    await setOtherFieldValue(config, "Authentication-Mode", "AuthenticationMode");
    await setBooleanFieldValue(config, "Synchronize-User-Attributes", "SynchronizeUserAttributes");
    await setBooleanFieldValue(config, "Authentication-Only", "AuthenticationOnly");

    await parseSystemIdentityModelServices(config["systemIdentityModelServices"]);
    await parseSystemIdentityModel(config["systemIdentityModel"]);
}

async function parseSystemIdentityModelServices(config) {
    await setOtherFieldValue(config["wsFederation"], "wsFederation-Issuer", "Issuer");
    await setOtherFieldValue(config["wsFederation"], "wsFederation-Realm", "Realm");
    await setOtherFieldValue(config["serviceCertificate"], "Certificate-X509-Find-Type", "X509FindType");
    await setOtherFieldValue(config["serviceCertificate"], "Certificate-Find-Value", "FindValue");
    await setOtherFieldValue(config["serviceCertificate"], "Certificate-Store-Location", "StoreLocation");
    await setOtherFieldValue(config["serviceCertificate"], "Certificate-Store-Name", "StoreName");
    await setBooleanFieldValue(config, "Cookie-Handler-Require-SSL", "CookieHandlerRequireSSL");
}

async function parseSystemIdentityModel(config) {
    audienceUrisData = config["audienceUris"];
    let audienceUrisSelectList = document.getElementById("AudienceURI-SelectList");
    for (let i = 0; i < audienceUrisData.length; i++) {
        let opt = document.createElement("option");
        opt.setAttribute("value", "audienceuri" + audienceUrisIdNumber);
        opt.innerText = audienceUrisData[i]["URI"];
        audienceUrisSelectList.append(opt);
        audienceUrisData[i]["id"] = "audienceuri" + audienceUrisIdNumber;
        audienceUrisIdNumber++;
    }

    trustedIssuersData = config["trustedIssuers"];
    let trustedIssuersSelectList = document.getElementById("TrustedIssuers-SelectList");
    for (let j = 0; j < trustedIssuersData.length; j++) {
        let opt1 = document.createElement("option");
        opt1.setAttribute("value", "trustedissuer" + trustedIssuersIdNumber);
        opt1.innerText = trustedIssuersData[j]["Name"];
        trustedIssuersSelectList.append(opt1);
        trustedIssuersData[j]["id"] = "trustedissuer" + trustedIssuersIdNumber;
        trustedIssuersIdNumber++;
    }
}

async function parseKnownElements(config) {
    if (config.length > 0) {
        for (let i = 0; i < config.length; i++) {
            if (config[i]["AttributeName"] != "IdPUrl") {
                if (config[i]["AttributeName"] == "FolderTreeWidth" || config[i]["AttributeName"] == "FolderTreeHeight" || config[i]["AttributeName"] == "DocumentListHeight" || config[i]["AttributeName"] == "FolderListHeight") {
                    const parsedValue = parseFloat(config[i]["Value"].trim().replace('%', ''));
                    document.getElementById(config[i]["htmlIdName"]).value = parsedValue;
                } else if (config[i]["htmlIdName"] == "Service-Client-Type") {
                    config[i]["Value"] = config[i]["Value"].charAt(0).toUpperCase() + config[i]["Value"].slice(1);
                    await setOtherFieldValue(config[i], config[i]["htmlIdName"], "Value");
                } else {
                    switch (config[i]["type"]) {
                        case "1":
                            await setBooleanFieldValue(config[i], config[i]["htmlIdName"], "Value");
                            break;
                        case "2":
                            await setOtherFieldValue(config[i], config[i]["htmlIdName"], "Value");
                            break
                    }
                }
            }
        }
    }
}

async function parseUnknownKeys(config, id) {
    if (config.length > 0) {
        let tbody = document.getElementById(id).getElementsByTagName("tbody");

        for (let i = 0; i < config.length; i++) {
            let tr = document.createElement('tr');
            let tdsection = document.createElement('td');
            tdsection.innerText = config[i]["Section"];
            let tdpathname = document.createElement('td');
            tdpathname.innerText = config[i]["PathName"];
            let tdattributename = document.createElement('td');
            tdattributename.innerText = config[i]["AttributeName"];
            let tdtype = document.createElement('td');
            tdtype.innerText = config[i]["type"];
            let tdhtmlidname = document.createElement('td');
            tdhtmlidname.innerText = config[i]["htmlIdName"];
            let tdvalue = document.createElement('td');
            tdvalue.innerText = config[i]["Value"];
            let tdversion = document.createElement('td');
            tdversion.innerText = config[i]["Version"];
            tr.appendChild(tdsection);
            tr.appendChild(tdpathname);
            tr.appendChild(tdattributename);
            tr.appendChild(tdtype);
            tr.appendChild(tdhtmlidname);
            tr.appendChild(tdvalue);
            tr.appendChild(tdversion);
            tbody[0].appendChild(tr);
        }
    }
}




/********************************************************
*                Saving web.config data
********************************************************/
async function saveData() {
    await saveRequiredKeywords(coreConfigData["requiredKeywords"])
    await saveKnownElements(coreConfigData["knownKeys"]);
    await saveKnownElements(coreConfigData["translatorKnownKeys"]);
    await saveIisConfiguration(coreConfigData["IisConfiguration"]);
    //console.log(optimizeForWindowsAuth);
    coreConfigData["WindowsAuthOptimizeFor"] = optimizeForWindowsAuth;
    if (diagnosticsRoutes.length > 0) {
        await saveHylandLogging();
    }

    switch (coreConfigData["Type"]) {
        case "Application Server":
            await saveAdfs();
            await saveHylandAuthentication();
            await saveHylandPlatterManagement();
            //Validates that there are connection strings to save.
            if (ConnectionStringsArray.length > 0) {
                await saveConnectionStringsV2();
            }
            await saveSessionAdministration();
            await saveHylandResponsiveAppsAppArray();
            break;
        case "Agenda Online":
            await saveHylandApplicationsAgendaPubAccessPublicComment();
            break;
        case "Electronic Plan Review":
            break;
        case "Gateway Caching Server":
            break;
        case "Healthcare Form Manager":
            await saveHylandIdentityProvider();
            break;
        case "Patient Window":
            await saveHylandIdentityProvider();
            await saveAdfs();
            break;
        case "Public Access - Legacy":
            await saveRequiredKeywords();
            break;
        case "Public Access - Next Gen":
            await saveRequiredKeywords();
            break;
        case "Reporting Viewer":
            await saveHylandIdentityProvider();
            break;
        case "Web Server":
            await saveHylandIdentityProvider();
            await saveAdfs();
            await saveCustomValidation();
            await saveNavigationPanel();
            await saveKeywordDropDownTypeAhead();
            await saveHealthcareWebViewerSourceOrigins();
            break;
    }
}

async function saveHylandResponsiveAppsAppArray() {
    coreConfigData["hylandResponsiveApps"]["responsiveApps"] = responsiveAppsApps;
}

async function saveHylandApplicationsAgendaPubAccessPublicComment() {
    coreConfigData["publicCommentIntegrations"] = AgendaOnlineIntegrations;
}

async function saveSessionAdministration() {
    coreConfigData["sessionAdministration"]["users"] = sessionadministrationusers;
    coreConfigData["sessionAdministration"]["roles"] = sessionadministrationroles;
}

async function saveHealthcareWebViewerSourceOrigins() {
    coreConfigData["healthcareWebViewer"]["Origins"] = hwvSourceOriginWhiteList;
}

async function saveKeywordDropDownTypeAhead() {
    coreConfigData["keywordDropdownTypeAhead"]["characterMinimums"] = keywordTypeAheadArray;
}

async function saveKnownElements(config) {
    if (config.length > 0) {
        for (let i = 0; i < config.length; i++) {
            if (config[i]["AttributeName"] != "IdPUrl") {
                if (config[i]["AttributeName"] == "FolderTreeWidth" || config[i]["AttributeName"] == "FolderTreeHeight" || config[i]["AttributeName"] == "DocumentListHeight" || config[i]["AttributeName"] == "FolderListHeight") {
                    config[i]["Value"] = document.getElementById(config[i]["htmlIdName"]).value + "%";
                } else {
                    switch (config[i]["type"]) {
                        case "1":
                            await getBooleanFieldValue(config[i], config[i]["htmlIdName"], "Value");
                            break;
                        case "2":
                            await getOtherFieldValue(config[i], config[i]["htmlIdName"], "Value");
                            break
                    }
                }
            }
        }
    }
}

async function saveHylandPlatterManagement() {
    coreConfigData["hylandPlatterManagement"]["diskGroupAliases"] = diskGroupAliases;
}

async function saveHylandAuthentication() {
    coreConfigData["hylandAuthentication"]["TrustMode"] = document.getElementById("Trust-Mode").value;
    coreConfigData["hylandAuthentication"]["trustedClients"] = trustedClients;
}

async function saveNavigationPanel() {
    coreConfigData["navigationPanel"]["Contexts"] = NavigationPanelContexts;
    if (document.getElementById("Default-Context").value == "NavigationPanel0") {
        coreConfigData["navigationPanel"]["defaultContext"] = "";
        coreConfigData["navigationPanel"]["defaultControlBar"] = "";
        coreConfigData["navigationPanel"]["defaultContextID"] = "";
    } else {
        let navPanelContextSelected = NavigationPanelContexts.filter(context => context.id == document.getElementById("Default-Context").value);
        coreConfigData["navigationPanel"]["defaultContext"] = navPanelContextSelected[0]["contextInfo"]["name"];
        coreConfigData["navigationPanel"]["defaultControlBar"] = document.getElementById("Default-Control-Bar").value;
        coreConfigData["navigationPanel"]["defaultContextID"] = document.getElementById("Default-Context-ID").value;
    }
}

async function saveHylandIdentityProvider() {
    coreConfigData["hylandIdentityProviderUrl"]["ServerLocation"] = document.getElementById("IdP-Server-Location").value;
    coreConfigData["hylandIdentityProviderUrl"]["Tenant"] = document.getElementById("IdP-Tenant").value;
    coreConfigData["hylandIdentityProviderUrl"]["Client"] = document.getElementById("IdP-Client").value;
    coreConfigData["hylandIdentityProviderUrl"]["Secret"] = document.getElementById("IdP-Secret").value;
}

async function saveRequiredKeywords() {
    await finalSaveRequiredKeywordsData();
}

async function saveHylandLogging() {
    coreConfigData["hylandLogging"]["Routes"] = diagnosticsRoutes;
    coreConfigData["hylandLogging"]["truncateloggingcharacters"] = document.getElementById("DiagnosticsSettings-TruncateLogValues").value;
    coreConfigData["hylandLogging"]["windowsEventLogging"]["SourceName"] = document.getElementById("DiagnosticsSettings-WindowsEventLogging-SourceName").value;
}

//async function saveHylandApplicationsAgendaPubAccessPublicComment() {
//    let meetingtypenames = document.getElementById("Meeting-Type-Name").value;

//    if (meetingtypenames.includes(',')) {
//        let resultingArray = meetingtypenames.split(',');
//        coreConfigData["hylandApplicationsAgendaPubAccessPublicComment"]["meetingTypes"] = [];
//        for (let i = 0; i < resultingArray.length; i++) {
//            let obj = {
//                Name: resultingArray[0]
//            };
//            coreConfigData["hylandApplicationsAgendaPubAccessPublicComment"]["meetingTypes"].push(obj);
//        }
//    } else {
//        coreConfigData["hylandApplicationsAgendaPubAccessPublicComment"]["meetingTypes"][0].Name = meetingtypenames;
//    }

//    //Save the Agenda Fields elements and values and all.
//    coreConfigData["hylandApplicationsAgendaPubAccessPublicComment"]["agendaFields"] = AgendaOnlineAgendaFields;
//}

async function saveAdfs() {
    coreConfigData["hylandAuthenticationADFS"]["systemIdentityModel"]["audienceUris"] = audienceUrisData;
    coreConfigData["hylandAuthenticationADFS"]["systemIdentityModel"]["trustedIssuers"] = trustedIssuersData;
    getBooleanFieldValue(coreConfigData["hylandAuthenticationADFS"], "ADFS-Enabled", "ADFSEnabled");
    getOtherFieldValue(coreConfigData["hylandAuthenticationADFS"], "Request-Validation-Mode", "RequestValidationMode");
    getOtherFieldValue(coreConfigData["hylandAuthenticationADFS"], "Authentication-Mode", "AuthenticationMode");
    getBooleanFieldValue(coreConfigData["hylandAuthenticationADFS"], "Cookie-Handler-Require-SSL", "CookieHandlerRequireSSL");
    getBooleanFieldValue(coreConfigData["hylandAuthenticationADFS"], "Synchronize-User-Attributes", "SynchronizeUserAttributes");
    getBooleanFieldValue(coreConfigData["hylandAuthenticationADFS"], "Authentication-Only", "AuthenticationOnly");

    getOtherFieldValue(coreConfigData["hylandAuthenticationADFS"]["systemIdentityModelServices"]["wsFederation"], "wsFederation-Issuer", "Issuer");
    getOtherFieldValue(coreConfigData["hylandAuthenticationADFS"]["systemIdentityModelServices"]["wsFederation"], "wsFederation-Realm", "Realm");
    getOtherFieldValue(coreConfigData["hylandAuthenticationADFS"]["systemIdentityModelServices"]["serviceCertificate"], "Certificate-X509-Find-Type", "X509FindType");
    getOtherFieldValue(coreConfigData["hylandAuthenticationADFS"]["systemIdentityModelServices"]["serviceCertificate"], "Certificate-Find-Value", "FindValue");
    getOtherFieldValue(coreConfigData["hylandAuthenticationADFS"]["systemIdentityModelServices"]["serviceCertificate"], "Certificate-Store-Location", "StoreLocation");
    getOtherFieldValue(coreConfigData["hylandAuthenticationADFS"]["systemIdentityModelServices"]["serviceCertificate"], "Certificate-Store-Name", "StoreName");
}

async function saveConnectionStringsV2() {
    await getBooleanFieldValue(coreConfigData["connectionStrings"], "Encrypt-Connection-Strings", "EncryptConnectionStrings");
    
    coreConfigData["connectionStrings"]["connectionStrings"] = ConnectionStringsArray;

    for (let i = 0; i < coreConfigData["knownKeys"].length; i++) {
        if (coreConfigData["knownKeys"][i]["htmlIdName"] == "Data-Source") {
            coreConfigData["knownKeys"][i]["Value"] = document.getElementById("Data-Source").options[document.getElementById("Data-Source").selectedIndex].text;
        }
    }
}

async function saveCustomValidation() {
    getOtherFieldValue(coreConfigData["customValidation"]["application"], "Application-Script-Location", "scriptLocation");
    coreConfigData["customValidation"]["application"]["keywords"] = customValidationApplicationLevel;
    coreConfigData["customValidation"]["pages"] = customValidationPageLevelData;
}


/********************************************************
*          Diagnostics Settings Functions V2
********************************************************/
async function diagnosticsSettingRouteSelected(selectlist) {
    await lockUnlockAllDiagnosticsSettingsFields("false");
    let object = diagnosticsRoutes.filter(obj => obj.id == selectlist.value);

    document.getElementById("Source-Details-Name").value = object[0]["Name"];
    switch (object[0]["SourceEvents"]) {
        case "Diagnostics Events":
            document.getElementById("Source-Details-Source-Radio-Diagnostics-Events").checked = true;
            break;
        case "Audit Events":
            document.getElementById("Source-Details-Source-Radio-Audit-Events").checked = true;
            break;
    }
    document.getElementById("Enable-IP-Address-Masking").checked = (object[0]["EnableIpAddressMasking"].toLowerCase() === 'true');
    document.getElementById("Filtering-Options-Minimum-Error-Level").value = object[0]["filter"]["MinimumErrorLevel"];
    document.getElementById("Filtering-Options-Maximum-Error-Level").value = object[0]["filter"]["MaximumErrorLevel"];
    switch (object[0]["filter"]["FilterProfilesIncludeExcludeNeither"]) {
        case "Neither":
            document.getElementById("Filter-Options-Neither-Profiles-Radio").checked = true;
            document.getElementById("Filter-Options-Neither-Profiles-Radio").click();
            break;
        case "Include":
            document.getElementById("Filter-Options-Included-Profiles-Radio").checked = true;
            document.getElementById("Filter-Options-Included-Profiles-Radio").click();
            (object[0].filter.Profiles).forEach(element => {
                document.getElementById(element).checked = true;
            });
            break;
        case "Exclude":
            document.getElementById("Filter-Options-Excluded-Profiles-Radio").checked = true;
            document.getElementById("Filter-Options-Excluded-Profiles-Radio").click();
            (object[0].filter.Profiles).forEach(element => {
                document.getElementById(element).checked = true;
            });
            break;
    }

    document.getElementById("Destination-Type").value = object[0]["RouteType"]
    DestinationTypeChange(document.getElementById("Destination-Type"));
    switch (object[0]["RouteType"]) {
        case "Console":
            document.getElementById("Destination-Type-Console-Output-Format").value = object[0]["console"]["OutputFormat"];
            break;
        case "Http":
            document.getElementById("Destination-Type-Http-Server-URL").value = object[0]["http"]["URL"];
            break;
        case "DurableHttp":
            document.getElementById("Destination-Type-DurableHttp-Server-URL").value = object[0]["durablehttp"]["URL"];
            break;
        case "File":
            document.getElementById("Destination-Type-File-File-Path").value = object[0]["file"]["FilePath"];
            document.getElementById("Destination-Type-File-File-Size-Limit").value = object[0]["file"]["FileSizeLimit"];
            document.getElementById("Destination-Type-File-Roll-When-Limit-Reached").checked = (object[0]["file"]["RollWhenLimitReached"].toLowerCase() === 'true');
            document.getElementById("Destination-Type-File-Roll-Interval").value = object[0]["file"]["RollInterval"];
            document.getElementById("Destination-Type-File-Retained-Files-Count").value = object[0]["file"]["RetainedFilesCount"];
            document.getElementById("Destination-Type-File-Output-Format").value = object[0]["file"]["OutputFormat"];
            break;
        case "Splunk":
            document.getElementById("Destination-Type-Splunk-Server-URL").value = object[0]["splunk"]["ServerUrl"];
            document.getElementById("Destination-Type-Splunk-Token").value = object[0]["splunk"]["SplunkToken"];
            document.getElementById("Destination-Type-Splunk-Index").value = object[0]["splunk"]["SplunkIndex"];
            document.getElementById("Destination-Type-Splunk-Source").value = object[0]["splunk"]["SplunkSource"];
            document.getElementById("Destination-Type-Splunk-Source-Type").value = object[0]["splunk"]["SplunkSourceType"];
            document.getElementById("Destination-Type-Splunk-Host").value = object[0]["splunk"]["SplunkHost"];
            break;
        case "EventLog":
            document.getElementById("Destination-Type-EventLog-SourceName").value = object[0]["eventlog"]["SourceName"];
            break;
    }
}

async function DestinationTypeChange(optionSelected) {
    var i, destinationTypeFields;
    destinationTypeFields = document.getElementsByClassName("DestinationTypeFields");
    for (i = 0; i < destinationTypeFields.length; i++) {
        destinationTypeFields[i].style.display = "none";
    }

    document.getElementById("Destination-Type-" + optionSelected.value).style.display = "block";
}

function profilesReviewV2(optionChosen) {
    var i, profiles;
    let objectToUpdate = diagnosticsRoutes.filter(route => route.id == document.getElementById("DiagnosticsSettingsRoutes-SelectList").value);

    if (objectToUpdate.length > 0) {
        switch (optionChosen.id) {
            case "Filter-Options-Neither-Profiles-Radio":
                objectToUpdate[0].filter.FilterProfilesIncludeExcludeNeither = "Neither";
                lockAllDiagnosticsProfileFields('true');
                break;
            case "Filter-Options-Included-Profiles-Radio":
                objectToUpdate[0].filter.FilterProfilesIncludeExcludeNeither = "Include";
                lockAllDiagnosticsProfileFields('false');
                break;
            case "Filter-Options-Excluded-Profiles-Radio":
                objectToUpdate[0].filter.FilterProfilesIncludeExcludeNeither = "Exclude";
                lockAllDiagnosticsProfileFields('false');
                break;
        }
    }
}

async function lockAllDiagnosticsProfileFields(action) {
    profiles = document.getElementsByClassName("Profiles");
    for (i = 0; i < profiles.length; i++) {
        profiles[i].disabled = (action === 'true');
    }
}

async function diagnosticsSettingRouteNameChanged(inputText, excludeSelf = true) {
    let selectedOption = document.getElementById("DiagnosticsSettingsRoutes-SelectList").options[document.getElementById("DiagnosticsSettingsRoutes-SelectList").selectedIndex];
    let objectToUpdate = diagnosticsRoutes.filter(route => route.id == document.getElementById("DiagnosticsSettingsRoutes-SelectList").value);
    if (excludeSelf) {
        let result = diagnosticsRoutes.filter(route => route.Name === inputText.value && route.id != selectedOption.value);
        if (result.length > 0) {
            selectedOption.innerText = inputText.value;
            selectedOption.innerHTML += '<span class="duplicateDiagnosticSettingsRouteName"> (duplicate)</span>';
            pushErrorToArray(await findErrorArrayToSet("diagnosticSettingsRouteName"));
        } else {
            selectedOption.innerText = inputText.value;
            spliceErrorFromArray("diagnosticSettingsRouteName");
        }
    } else {
        let result = diagnosticsRoutes.filter(route => route.Name === inputText.value);
        if (result.length > 0) {
            selectedOption.innerHTML += '<span class="duplicateDiagnosticSettingsRouteName"> (duplicate)</span>';
            pushErrorToArray(await findErrorArrayToSet("diagnosticSettingsRouteName"));
        } else {
            selectedOption.innerText = inputText.value;
            spliceErrorFromArray("diagnosticSettingsRouteName");
        }
    }
    objectToUpdate[0].Name = inputText.value;
}

async function addDiagnosticsRouteV2() {
    configurationChanged = true;
    let AddRouteName = "Console";
    let existingCheck = diagnosticsRoutes.filter(route => route.Name === AddRouteName);
    if (existingCheck.length > 0) {
        let foundNumber = 1;
        let copyNumber = 1;
        while (foundNumber > 0) {
            let checkValue = "Console(" + copyNumber + ")";
            let existingCheck = diagnosticsRoutes.filter(route => route.Name === checkValue);
            if (existingCheck.length == 0) {
                AddRouteName = checkValue;
                foundNumber = 0;
            }
            copyNumber++;
        }
    }

    document.getElementById("Source-Details-Name").value = AddRouteName;
    document.getElementById("Source-Details-Source-Radio-Diagnostics-Events").checked = true;
    document.getElementById("Enable-IP-Address-Masking").checked = true;
    document.getElementById("Filtering-Options-Minimum-Error-Level").selectedIndex = "2";
    document.getElementById("Filtering-Options-Maximum-Error-Level").value = "6";
    document.getElementById("Filter-Options-Neither-Profiles-Radio").checked = true;
    profilesReview(document.getElementById("Filter-Options-Neither-Profiles-Radio"));
    document.getElementById("Destination-Type").value = "Console";
    document.getElementById("Source-Details-Name").focus();
    document.getElementById("Source-Details-Name").select();
    DestinationTypeChange(document.getElementById("Destination-Type"));
    document.getElementById("Destination-Type-Console-Output-Format").value = "Minimal";


    var RouteObj = {
        filter: {
            "Profiles": [],
            "MinimumErrorLevel": "2",
            "MaximumErrorLevel": "6",
            "FilterProfilesIncludeExcludeNeither": "Neither"
        },
        eventlog: null,
        splunk: null,
        file: null,
        http: null,
        durablehttp: null,
        console: {
            OutputFormat: "Minimal"
        },
        RouteType: "Console",
        Name: AddRouteName,
        SourceEvents: "Diagnostics Events",
        EnableIpAddressMasking: "true",
        id: "Route" + diagnosticsSettingsRoutesIdNumber
    };
    diagnosticsRoutes.push(RouteObj);

    let diagnosticsSettingsRoutesSelectList = document.getElementById("DiagnosticsSettingsRoutes-SelectList");
    let opt = document.createElement("option");
    opt.setAttribute("value", "Route" + diagnosticsSettingsRoutesIdNumber);
    opt.innerText = AddRouteName;
    diagnosticsSettingsRoutesSelectList.append(opt);
    diagnosticsSettingsRoutesSelectList.selectedIndex = diagnosticsSettingsRoutesSelectList.length - 1;

    //Increase the Routes ID Number value by 1 to avoid duplicate Route id names.
    diagnosticsSettingsRoutesIdNumber++;
    await lockUnlockAllDiagnosticsSettingsFields("false");
}

async function updateAuditEventsSourceOnRoute() {
    let objectToUpdate = diagnosticsRoutes.filter(route => route.id == document.getElementById("DiagnosticsSettingsRoutes-SelectList").value);
    let selectedSourceDetailsRadioButton = document.querySelector('input[name="Source-Details-Source-Radio"]:checked');
    switch (selectedSourceDetailsRadioButton.id) {
        case "Source-Details-Source-Radio-Diagnostics-Events":
            objectToUpdate[0].SourceEvents = "Diagnostics Events";
            break;
        case "Source-Details-Source-Radio-Audit-Events":
            objectToUpdate[0].SourceEvents = "Audit Events";
            break;
    }
}

async function udpateEnableIpAddressMaskingOnRoute(checkbox) {
    let objectToUpdate = diagnosticsRoutes.filter(route => route.id == document.getElementById("DiagnosticsSettingsRoutes-SelectList").value);
    if (checkbox.checked) {
        objectToUpdate[0].EnableIpAddressMasking = "true";
    } else {
        objectToUpdate[0].EnableIpAddressMasking = "false";
    }
}

async function errorLevelChanged(selectChanged) {
    var otherValue;
    let objectToUpdate = diagnosticsRoutes.filter(route => route.id == document.getElementById("DiagnosticsSettingsRoutes-SelectList").value);
    if (selectChanged.id.match("Filtering-Options-Minimum-Error-Level")) {
        objectToUpdate[0].filter.MinimumErrorLevel = selectChanged.value;
        otherValue = document.getElementById("Filtering-Options-Maximum-Error-Level").value;
        if (otherValue < selectChanged.value) {
            document.getElementById("Filtering-Options-Maximum-Error-Level").value = selectChanged.value;
            objectToUpdate[0].filter.MaximumErrorLevel = selectChanged.value;
        }
    } else {
        objectToUpdate[0].filter.MaximumErrorLevel = selectChanged.value;
        otherValue = document.getElementById("Filtering-Options-Minimum-Error-Level").value;
        if (otherValue > selectChanged.value) {
            document.getElementById("Filtering-Options-Minimum-Error-Level").value = selectChanged.value;
            objectToUpdate[0].filter.MinimumErrorLevel = selectChanged.value;
        }
    }
}

async function profileCheckedUncheckedV2(profile) {
    let objectToUpdate = diagnosticsRoutes.filter(route => route.id == document.getElementById("DiagnosticsSettingsRoutes-SelectList").value);
    if (profile.checked == true) {
        objectToUpdate[0].filter.Profiles.push(profile.id.toString())
    } else {
        let index = objectToUpdate[0].filter.Profiles.indexOf(profile.id);
        if (index !== -1) {
            objectToUpdate[0].filter.Profiles.splice(index, 1);
        }
    }
}

async function updateDestinationDetails() {
    let objectToUpdate = diagnosticsRoutes.filter(route => route.id == document.getElementById("DiagnosticsSettingsRoutes-SelectList").value);
    let destinationSelected = document.getElementById("Destination-Type").value;

    switch (destinationSelected) {
        case "Console":
            objectToUpdate[0].console.OutputFormat = document.getElementById("Destination-Type-Console-Output-Format").options[document.getElementById("Destination-Type-Console-Output-Format").selectedIndex].value;
            break;
        case "DurableHttp":
            objectToUpdate[0].durablehttp.URL = document.getElementById("Destination-Type-DurableHttp-Server-URL").value;
            break;
        case "EventLog":
            objectToUpdate[0].eventlog.SourceName = document.getElementById("Destination-Type-EventLog-SourceName").value;
            break;
        case "File":
            objectToUpdate[0].file.FilePath = document.getElementById("Destination-Type-File-File-Path").value;
            objectToUpdate[0].file.FileSizeLimit = document.getElementById("Destination-Type-File-File-Size-Limit").value;
            objectToUpdate[0].file.RollWhenLimitReached = document.getElementById("Destination-Type-File-Roll-When-Limit-Reached").checked.toString();
            objectToUpdate[0].file.RollInterval = document.getElementById("Destination-Type-File-Roll-Interval").options[document.getElementById("Destination-Type-File-Roll-Interval").selectedIndex].value;
            objectToUpdate[0].file.RetainedFilesCount = document.getElementById("Destination-Type-File-Retained-Files-Count").value;
            objectToUpdate[0].file.OutputFormat = document.getElementById("Destination-Type-File-Output-Format").options[document.getElementById("Destination-Type-File-Output-Format").selectedIndex].value;
            break;
        case "Http":
            objectToUpdate[0].http.URL = document.getElementById("Destination-Type-Http-Server-URL").value;
            break;
        case "Splunk":
            objectToUpdate[0].splunk.ServerUrl = document.getElementById("Destination-Type-Splunk-Server-URL").value;
            objectToUpdate[0].splunk.SplunkToken = document.getElementById("Destination-Type-Splunk-Token").value;
            objectToUpdate[0].splunk.SplunkIndex = document.getElementById("Destination-Type-Splunk-Index").value;
            objectToUpdate[0].splunk.SplunkSource = document.getElementById("Destination-Type-Splunk-Source").value;
            objectToUpdate[0].splunk.SplunkSourceType = document.getElementById("Destination-Type-Splunk-Source-Type").value;
            objectToUpdate[0].splunk.SplunkHost = document.getElementById("Destination-Type-Splunk-Host").value;
            break;
        case "EventLog":
            objectToUpdate[0].eventlog.SourceName = document.getElementById("Destination-Type-EventLog-SourceName").value;
            break;
    }
}

function destinationFileTypeRollOnIntervalCheckbox(checkbox) {
    if (checkbox.checked == true) {
        document.getElementById("Destination-Type-File-Roll-Interval").disabled = false;
    } else {
        document.getElementById("Destination-Type-File-Roll-Interval").disabled = true;
    }
}

async function deleteDiagnosticsRouteV2() {
    let objectToUpdate = diagnosticsRoutes.filter(route => route.id == document.getElementById("DiagnosticsSettingsRoutes-SelectList").value);

    for (let i = 0; i < diagnosticsRoutes.length; i++) {
        if (diagnosticsRoutes[i].id == document.getElementById("DiagnosticsSettingsRoutes-SelectList").value) {
            diagnosticsRoutes.splice(i, 1);
        }
    }

    await removeDiagnosticsSettingsRouteFromSelectList();
    await resetAllDiagnosticsSettingsFields();
    //Locks all fields
    await lockUnlockAllDiagnosticsSettingsFields("true");
}

function copyDiagnosticsRouteV2() {
    //Get the current object that is selected.
    let objectToCopy = diagnosticsRoutes.filter(route => route.id == document.getElementById("DiagnosticsSettingsRoutes-SelectList").value);

    //Append the classic "(#)" to the end of the Route Name.
    let copiedRouteDetails = JSON.parse(JSON.stringify(objectToCopy[0]))
    let foundNumber = 1;
    let copyNumber = 1;
    while (foundNumber > 0) {
        let checkValue = copiedRouteDetails["Name"] + "(" + copyNumber + ")";
        let existingCheck = diagnosticsRoutes.filter(route => route.RouteName === checkValue);
        if (existingCheck.length == 0) {
            copiedRouteDetails["Name"] = copiedRouteDetails["Name"] + "(" + copyNumber + ")";
            foundNumber = 0;
        }
        copyNumber++;
    }
    copiedRouteDetails["id"] = "Route" + diagnosticsSettingsRoutesIdNumber;

    let diagnosticsSettingsRoutesSelectList = document.getElementById("DiagnosticsSettingsRoutes-SelectList");
    let opt = document.createElement("option");
    opt.setAttribute("value", "Route" + diagnosticsSettingsRoutesIdNumber);
    opt.innerText = copiedRouteDetails["Name"];
    diagnosticsSettingsRoutesSelectList.append(opt);
    diagnosticsSettingsRoutesSelectList.selectedIndex = diagnosticsSettingsRoutesSelectList.length - 1;
    //Increase the Routes ID Number value by 1 to avoid duplicate Route id names.
    diagnosticsSettingsRoutesIdNumber++;

    //Push the copied routes values to the array.
    diagnosticsRoutes.push(copiedRouteDetails);

    //Make the copied route the selected one.
    document.getElementById("DiagnosticsSettingsRoutes-SelectList").value = "Route" + (diagnosticsSettingsRoutesIdNumber - 1);
    diagnosticsSettingRouteSelected(document.getElementById("DiagnosticsSettingsRoutes-SelectList"));
}

async function lockUnlockAllDiagnosticsSettingsFields(action) {
    var boolValue = action === "true" ? true : (action === "false" ? false : null);
    for (let i = 0; i < diagnosticsSettingsElementIds.length; i++) {
        document.getElementById(diagnosticsSettingsElementIds[i]).disabled = boolValue;
    }
}

async function resetAllDiagnosticsSettingsFields() {
    document.getElementById("Source-Details-Name").value = "";
    document.getElementById("Source-Details-Source-Radio-Diagnostics-Events").checked = true;
    document.getElementById("Enable-IP-Address-Masking").checked = true;
    document.getElementById("Filtering-Options-Minimum-Error-Level").value = "3";
    document.getElementById("Filtering-Options-Maximum-Error-Level").value = "6";
    document.getElementById("Filter-Options-Neither-Profiles-Radio").click();
    switch (document.getElementById("Destination-Type").value) {
        case "Console":
            document.getElementById("Destination-Type-Console").style.display = "none";
            break;
        case "Http":
            document.getElementById("Destination-Type-Http").style.display = "none";
            break;
        case "DurableHttp":
            document.getElementById("Destination-Type-DurableHttp").style.display = "none";
            break;
        case "File":
            document.getElementById("Destination-Type-File").style.display = "none";
            break;
        case "Splunk":
            document.getElementById("Destination-Type-Splunk").style.display = "none";
            break;
        case "EventLog":
            document.getElementById("Destination-Type-EventLog").style.display = "none";
            break;
    }
    document.getElementById("Destination-Type").value = "Console";
}

async function removeDiagnosticsSettingsRouteFromSelectList() {
    document.getElementById("DiagnosticsSettingsRoutes-SelectList").remove(document.getElementById("DiagnosticsSettingsRoutes-SelectList").selectedIndex);
}

function profilesReview(optionChosen) {
    var i, profiles;
    profiles = document.getElementsByClassName("Profiles");
    if (optionChosen.id != "Filter-Options-Neither-Profiles-Radio") {
        for (i = 0; i < profiles.length; i++) {
            profiles[i].disabled = false;
        }
    } else {
        for (i = 0; i < profiles.length; i++) {
            profiles[i].disabled = true;
        }
    }
}


/********************************************************
*                 ADFS Functions
********************************************************/
function audienceUriChanged(SelectList) {
    let result = audienceUrisData.filter(uri => uri["id"] === SelectList.value);
    document.getElementById("Audience-URI").value = result[0]["URI"];
    unlockLockAudienceUriButtons("unlock");
    unlockLockUriField("unlock");
}

function unlockLockAudienceUriButtons(action) {
    switch (action) {
        case "lock":
            document.getElementById("AudienceURI-DeleteButton").disabled = true;
            break;
        case "unlock":
            document.getElementById("AudienceURI-DeleteButton").disabled = false;
            break;
    }
}

function unlockLockUriField(action) {
    switch (action) {
        case "lock":
            document.getElementById("Audience-URI").disabled = true;
            break;
        case "unlock":
            document.getElementById("Audience-URI").disabled = false;
            break;
    }
}

function updateAudienceUri(field) {
    let selectedOption = document.getElementById("AudienceURI-SelectList").options[document.getElementById("AudienceURI-SelectList").selectedIndex];
    let result = audienceUrisData.filter(element => element.id == selectedOption.value);
    result[0]["URI"] = field.value;
    selectedOption.innerText = field.value;
}

function deleteAudienceUri() {
    let SelectedIndex = document.getElementById("AudienceURI-SelectList").selectedIndex;
    let selectedOption = document.getElementById("AudienceURI-SelectList").options[document.getElementById("AudienceURI-SelectList").selectedIndex];
    for (let i = 0; i < audienceUrisData.length; i++) {
        if (audienceUrisData[i]["id"] == selectedOption.value) {
            audienceUrisData.splice(i, 1);
        }
    }
    document.getElementById("AudienceURI-SelectList").remove(SelectedIndex);
    document.getElementById("AudienceURI-SelectList").selectedIndex = "-1";
    document.getElementById("Audience-URI").value = "";
    unlockLockAudienceUriButtons("lock");
    unlockLockUriField("lock");
}

function addAudienceUri() {
    configurationChanged = true;
    let SelectList = document.getElementById("AudienceURI-SelectList");
    let opt = document.createElement("option");
    opt.setAttribute("value", "audienceuri" + audienceUrisIdNumber);
    opt.innerText = "[URL]";
    SelectList.append(opt);
    let objectToPush = {
        URI: "[URL]",
        id: "audienceuri" + audienceUrisIdNumber
    };
    document.getElementById("Audience-URI").value = "[URL]";
    SelectList.selectedIndex = SelectList.options.length - 1;
    audienceUrisData.push(objectToPush);
    audienceUrisIdNumber++;
    unlockLockUriField("unlock");
    unlockLockAudienceUriButtons("unlock");

}

function trustedIssuerChanged(SelectList) {
    let result = trustedIssuersData.filter(uri => uri["id"] === SelectList.value);
    document.getElementById("Trusted-Issuer-Thumbprint").value = result[0]["Thumbprint"];
    document.getElementById("Trusted-Issuer-Name").value = result[0]["Name"];
    unlockLockTrustedIssuersButtons("unlock");
    unlockLockTrustedIssuersFields("unlock");
}

function unlockLockTrustedIssuersButtons(action) {
    switch (action) {
        case "lock":
            document.getElementById("TrustedIssuer-DeleteButton").disabled = true;
            break;
        case "unlock":
            document.getElementById("TrustedIssuer-DeleteButton").disabled = false;
            break;
    }
}

function unlockLockTrustedIssuersFields(action) {
    switch (action) {
        case "lock":
            document.getElementById("Trusted-Issuer-Name").disabled = true;
            document.getElementById("Trusted-Issuer-Thumbprint").disabled = true;
            break;
        case "unlock":
            document.getElementById("Trusted-Issuer-Name").disabled = false;
            document.getElementById("Trusted-Issuer-Thumbprint").disabled = false;
            break;
    }
}

function updateTrustedIssuerThumbprint(field) {
    let selectedOption = document.getElementById("TrustedIssuers-SelectList").options[document.getElementById("TrustedIssuers-SelectList").selectedIndex];
    let result = trustedIssuersData.filter(element => element.id == selectedOption.value);
    result[0]["Thumbprint"] = field.value;
}

function updateTrustedIssuerName(field) {
    let selectedOption = document.getElementById("TrustedIssuers-SelectList").options[document.getElementById("TrustedIssuers-SelectList").selectedIndex];
    let result = trustedIssuersData.filter(element => element.id == selectedOption.value);
    result[0]["Name"] = field.value;
    selectedOption.innerText = field.value;
}

function deleteTrustedIssuer() {
    let SelectedIndex = document.getElementById("TrustedIssuers-SelectList").selectedIndex;
    let selectedOption = document.getElementById("TrustedIssuers-SelectList").options[document.getElementById("TrustedIssuers-SelectList").selectedIndex];
    for (let i = 0; i < trustedIssuersData.length; i++) {
        if (trustedIssuersData[i]["id"] == selectedOption.value) {
            trustedIssuersData.splice(i, 1);
        }
    }
    document.getElementById("Trusted-Issuer-Thumbprint").value = "";
    document.getElementById("Trusted-Issuer-Name").value = "";
    document.getElementById("AudienceURI-SelectList").remove(SelectedIndex);
    document.getElementById("AudienceURI-SelectList").selectedIndex = "-1";
    unlockLockTrustedIssuersButtons("lock");
    unlockLockTrustedIssuersFields("lock");
}

function addTrustedIssuer() {
    configurationChanged = true;
    let SelectList = document.getElementById("TrustedIssuers-SelectList");
    let opt = document.createElement("option");
    opt.setAttribute("value", "trustedissuer" + trustedIssuersIdNumber);
    opt.innerText = "[Name]";
    SelectList.append(opt);
    let objectToPush = {
        Thumbprint: "[Thumbprint]",
        Name: "[Name]",
        id: "trustedissuer" + trustedIssuersIdNumber
    };
    document.getElementById("Trusted-Issuer-Thumbprint").value = "[Thumbprint]";
    document.getElementById("Trusted-Issuer-Name").value = "[Name]";
    SelectList.selectedIndex = trustedIssuersIdNumber;
    trustedIssuersData.push(objectToPush);
    trustedIssuersIdNumber++;
    unlockLockTrustedIssuersFields("unlock");
    unlockLockTrustedIssuersButtons("unlock");
    document.getElementById("Trusted-Issuer-Thumbprint").select;
}


/********************************************************
*            Connection Strings Functions V3
********************************************************/
async function connectionStringSelectedV3() {
    let result = ConnectionStringsArray.filter(cstring => cstring.id === document.getElementById("ConnectionStrings-SelectList").value);
    
    await disableConnectionStringFieldsV3("false");

    await (function () {
        document.getElementById("Data-Source-Name").value = result[0]["Name"];
        document.getElementById("Data-Provider").value = result[0]["Provider"];
        //document.getElementById("Additional-Options").value = result[0]["AdditionalOptions"];
        document.getElementById("Integrated-Security").checked = (result[0]["IntegratedSecurity"].toLowerCase() === 'true');
        document.getElementById("User-ID").value = result[0]["UserId"];
        document.getElementById("Password").value = result[0]["Password"];
        document.getElementById("Sql-Data-Source").value = result[0]["sql"]["DataSource"];
        document.getElementById("Sql-Database").value = result[0]["sql"]["Database"];
        document.getElementById("Oracle-Fields-TNS-Connection-String").checked = (result[0]["oracle"]["TNSConnectionString"].toLowerCase() === 'true');
        document.getElementById("Host").value = result[0]["oracle"]["Host"];
        document.getElementById("Protocol").value = result[0]["oracle"]["Protocol"];
        document.getElementById("Oracle-Database").value = result[0]["oracle"]["Database"];
        document.getElementById("Port").value = result[0]["oracle"]["Port"];
        document.getElementById("Additional-Options").value = result[0]["AdditionalOptions"];
    })();

    await dataProviderV3(document.getElementById("Data-Provider"));
    await integratedSecurityCheckboxV3(document.getElementById("Integrated-Security"));
    await tnsConnectionStringCheckCheckboxV3(document.getElementById("Oracle-Fields-TNS-Connection-String"));
    try {
        if (document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].classList.contains("duplicateConnectionStringName")) {
            document.getElementById("DuplicateConnectionString-Alert").style.display = "block";
        } else {
            document.getElementById("DuplicateConnectionString-Alert").style.display = "none";
        }
    } catch { }

    await setRequiredFieldAlertsV3(["name"]);
    await disableConnectionStringButtonsV3("false");
}

async function disableConnectionStringFieldsV3(value) {
    let coreConnectionStringFieldsHtmlIds = ["Data-Source-Name", "Data-Provider", "Integrated-Security", "User-ID", "Password", "Sql-Data-Source", "Sql-Database", "Oracle-Fields-TNS-Connection-String", "Host", "Protocol", "Oracle-Database", "Port" , "Additional-Options"];
    
    for (let i = 0; i < coreConnectionStringFieldsHtmlIds.length; i++) {
        document.getElementById(coreConnectionStringFieldsHtmlIds[i]).disabled = (value === 'true');
    }
}

async function dataProviderV3(selection) {
    let arrayObject = ConnectionStringsArray.filter(cstring => cstring.id === document.getElementById("ConnectionStrings-SelectList").value);
    
    switch (selection.value) {
        case "System.Data.SqlClient":
            document.getElementById(selection.value + ".Fields").style.display = "flex";
            document.getElementById("Oracle.ManagedDataAccess.Client.Fields").style.display = "none";
            arrayObject[0].sql.DataSource = document.getElementById("Sql-Data-Source").value;
            arrayObject[0].sql.Database = document.getElementById("Sql-Database").value;
            await setRequiredFieldAlertsV3(["sql"]);
            //document.getElementById("Sql-AdditionalOptions").style.display = "block";
            //document.getElementById("Oracle-AdditionalOptions").style.display = "none";
            break;
        case "Oracle.ManagedDataAccess.Client":
            document.getElementById(selection.value + ".Fields").style.display = "block"
            document.getElementById("System.Data.SqlClient.Fields").style.display = "none";
            arrayObject[0].oracle.TNSConnectionString = document.getElementById("Oracle-Fields-TNS-Connection-String").checked.toString();
            arrayObject[0].oracle.Host = document.getElementById("Host").value;
            arrayObject[0].oracle.Database = document.getElementById("Oracle-Database").value;
            arrayObject[0].oracle.Protocol = document.getElementById("Protocol").value;
            arrayObject[0].oracle.Port = document.getElementById("Port").value;
            
            if (document.getElementById("Oracle-Fields-TNS-Connection-String").checked) {
                await setRequiredFieldAlertsV3(["oracle1"]);
            } else {
                await setRequiredFieldAlertsV3(["oracle2"]);
            }
            //document.getElementById("Sql-AdditionalOptions").style.display = "none";
            //document.getElementById("Oracle-AdditionalOptions").style.display = "block";
            break;
    }
}

async function setRequiredFieldAlertsV3(situations) {
    let fields = ["Data-Source-Name"];
    let useridFields = ["User-ID", "Password"];
    let oracleFields = ["Host", "Oracle-Database", "Port"];
    let sqlFields = ["Sql-Data-Source", "Sql-Database"];
    //Need to create an array that nests the above 4 arrays into one. Not sure if I will use this yet or not.
    let allFields = [fields, useridFields, oracleFields, sqlFields];

    for (let x = 0; x < situations.length; x++) {
        switch (situations[x]) {
            case "userid":
                useridFields.forEach(field => {
                    (document.getElementById(field).value.length == 0 && document.getElementById("Integrated-Security").checked == false) ? document.getElementById(field + "-RequiredSvg").style.display = "block" : document.getElementById(field + "-RequiredSvg").style.display = "none";
                });
                break;
            case "sql":
                sqlFields.forEach(field => {
                    (document.getElementById(field).value.length > 0) ? document.getElementById(field + "-RequiredSvg").style.display = "none" : document.getElementById(field + "-RequiredSvg").style.display = "block";
                });
                oracleFields.forEach(field => {
                    (document.getElementById(field).value.length > 0) ? document.getElementById(field + "-RequiredSvg").style.display = "none" : document.getElementById(field + "-RequiredSvg").style.display = "block";
                });
                break;
            case "oracle1":
                oracleFields.forEach(field => {
                    (document.getElementById(field).value.length > 0) ? document.getElementById(field + "-RequiredSvg").style.display = "none" : document.getElementById(field + "-RequiredSvg").style.display = "block";
                });
                sqlFields.forEach(field => {
                    (document.getElementById(field).value.length > 0) ? document.getElementById(field + "-RequiredSvg").style.display = "none" : document.getElementById(field + "-RequiredSvg").style.display = "block";
                });
                break;
            case "oracle2":
                (document.getElementById("Host").value.length > 0) ? document.getElementById("Host-RequiredSvg").style.display = "none" : document.getElementById("Host-RequiredSvg").style.display = "block";
                document.getElementById("Oracle-Database-RequiredSvg").style.display = "none";
                document.getElementById("Port-RequiredSvg").style.display = "none";
                sqlFields.forEach(field => {
                    (document.getElementById(field).value.length > 0) ? document.getElementById(field + "-RequiredSvg").style.display = "none" : document.getElementById(field + "-RequiredSvg").style.display = "block";
                });
                break;
            case "name":
                fields.forEach(field => {
                    (document.getElementById(field).value.length > 0) ? document.getElementById(field + "-RequiredSvg").style.display = "none" : document.getElementById(field + "-RequiredSvg").style.display = "block";
                });
                break;
            case "none":
                allFields.forEach(array => {
                    array.forEach(field => {
                        document.getElementById(field + "-RequiredSvg").style.display = "none";
                    });
                });
                break;
        }
    }
}

async function integratedSecurityCheckboxV3(field) {
    if (field.checked == true) {
        document.getElementById("User-ID").disabled = true;
        document.getElementById("Password").disabled = true;
        setRequiredFieldAlertsV3(["userid"]);
    } else {
        document.getElementById("User-ID").disabled = false;
        document.getElementById("Password").disabled = false;
        setRequiredFieldAlertsV3(["userid"]);
    }

    connectionStringTextInputFieldUpdatedV3(field);
}

async function connectionStringTextInputFieldUpdatedV3(field) {
    let cstringToUpdate = ConnectionStringsArray.filter(cstring => cstring.id === document.getElementById("ConnectionStrings-SelectList").value);

    switch (field.id) {
        case "Data-Source-Name":
            document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].innerText = field.value;
            if (document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].classList.contains("duplicateConnectionStringName")) {
                document.getElementById("DuplicateConnectionString-Alert").style.display = "block";
            } else {
                document.getElementById("DuplicateConnectionString-Alert").style.display = "none";
            }
            cstringToUpdate[0].Name = field.value;
            await validateConnectionStringFieldLengthV3(field);
            break;
        case "Sql-Data-Source":
            cstringToUpdate[0].sql.DataSource = field.value;
            await validateConnectionStringFieldLengthV3(field);
            break;
        case "Sql-Database":
            cstringToUpdate[0].sql.Database = field.value;
            await validateConnectionStringFieldLengthV3(field);
            break;
        case "Oracle-Fields-TNS-Connection-String":
            cstringToUpdate[0].oracle.TNSConnectionString = field.checked.toString();
            break;
        case "Host":
            cstringToUpdate[0].oracle.Host = field.value;
            await validateConnectionStringFieldLengthV3(field);
            break;
        case "Oracle-Database":
            cstringToUpdate[0].oracle.Database = field.value;
            await validateConnectionStringFieldLengthV3(field);
            break;
        case "Protocol":
            cstringToUpdate[0].oracle.Protocol = field.value;
            break;
        case "Port":
            cstringToUpdate[0].oracle.Port = field.value;
            await validateConnectionStringFieldLengthV3(field);
            break;
        case "Integrated-Security":
            cstringToUpdate[0].IntegratedSecurity = field.checked.toString();
            break;
        case "User-ID":
            cstringToUpdate[0].UserId = field.value;
            await validateConnectionStringFieldLengthV3(field);
            break;
        case "Password":
            cstringToUpdate[0].Password = field.value;
            await validateConnectionStringFieldLengthV3(field);
            break;
        case "Additional-Options":
            cstringToUpdate[0].AdditionalOptions = field.value;
            break;
    }
    document.getElementById("TestConnectionString-Alert").innerText = "";
    //await checkSetAppendedTextErrorV3();
}

async function checkForDuplicateConnectionStringNamesV3() {
    let duplicate = ConnectionStringsArray.filter(cstring => cstring.Name === document.getElementById("Data-Source-Name").value && cstring.id != document.getElementById("ConnectionStrings-SelectList").value);

    if (duplicate.length > 0) {
        duplicate.forEach(dup => {
            //Need to select the option element where the dup.id value is equal to the option value.
            let options = document.getElementById("ConnectionStrings-SelectList").options;

            for (let i = 0; i < options.length; i++) {
                if (options[i].value === dup.id) {
                    options[i].classList.add("duplicateConnectionStringName");
                    //Checks to verify that the error text to append does not already contain the word duplicate.
                    if (!options[i].attributes["error-text-to-append"].value.includes(" (duplicate)")){
                        options[i].attributes["error-text-to-append"].value += " (duplicate)";
                    }
                    //Checks to verify that currently selected option does not already contain the value of the current option[i].value.
                    if (!document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].attributes["related-duplicates"].value.includes(options[i].value)) {
                        document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].attributes["related-duplicates"].value = options[i].value;
                    }
                    //Checks to verify that the related-duplicates attribute does not already contain the the currently selected Connection Strings value.
                    if (!options[i].attributes["related-duplicates"].value.includes(document.getElementById("ConnectionStrings-SelectList").value)) {
                        let relatedDuplicatesArray = [];
                        if (options[i].attributes["related-duplicates"].value == "") {
                            options[i].attributes["related-duplicates"].value = document.getElementById("ConnectionStrings-SelectList").value;
                        } else {
                            relatedDuplicatesArray = options[i].attributes["related-duplicates"].value.split(",");
                            relatedDuplicatesArray.push(document.getElementById("ConnectionStrings-SelectList").value);
                            options[i].attributes["related-duplicates"].value = relatedDuplicatesArray.join(",");
                        }
                    }
                }

                if (options[i].attributes["related-duplicates"].value == document.getElementById("ConnectionStrings-SelectList").value && options[i].value != dup.id && options[i].innerText == dup.Name) {
                    options[i].attributes["related-duplicates"].value.replace(document.getElementById("ConnectionStrings-SelectList").value, "");
                    options[i].classList.remove("duplicateConnectionStringName");
                    options[i].attributes["error-text-to-append"].value = options[i].attributes["error-text-to-append"].value.replace(" (duplicate)", "");
                }
            }
        });
        await updateDataSourceOptionsV3();
        return true;
    } else {
        let relatedDuplicates = document.getElementById("ConnectionStrings-SelectList").options;
        for (let i = 0; i < relatedDuplicates.length; i++) {
            if (relatedDuplicates[i].attributes["related-duplicates"].value == document.getElementById("ConnectionStrings-SelectList").value) {
                relatedDuplicates[i].classList.remove("duplicateConnectionStringName");
                document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].attributes["related-duplicates"].value = "";
                relatedDuplicates[i].attributes["related-duplicates"].value = relatedDuplicates[i].attributes["related-duplicates"].value.replace(document.getElementById("ConnectionStrings-SelectList").value, "");
                relatedDuplicates[i].attributes["error-text-to-append"].value = relatedDuplicates[i].attributes["error-text-to-append"].value.replace(" (duplicate)", "");
            }
        }

        await updateDataSourceOptionsV3();
        return false;
    }
}

async function updateDataSourceOptionsV3() {
    let dataSourceElement = document.getElementById("Data-Source");

    for (let i = 0; i < dataSourceElement.options.length; i++) {
        let res = ConnectionStringsArray.filter(result => ("DataSource" + result.id) === dataSourceElement.options[i].value)
        dataSourceElement.options[i].text = res[0]["Name"];
    }
}

async function checkSetAppendedTextErrorV3() {
    let incompletefields = await checkIncompleteFieldsV3();
    let duplicatename = await checkForDuplicateConnectionStringNamesV3();

    if (incompletefields) {
        if (duplicatename) {
            document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].classList.add("incompleteConnectionString");
            document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].classList.add("duplicateConnectionStringName");
            document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].setAttribute("error-text-to-append", " (duplicate) (incomplete)");
            document.getElementById("DuplicateConnectionString-Alert").style.display = "block";
            checkErroredConnectionStrings();
        } else {
            document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].classList.add("incompleteConnectionString");
            document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].classList.remove("duplicateConnectionStringName");
            document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].setAttribute("error-text-to-append", " (incomplete)");
            document.getElementById("DuplicateConnectionString-Alert").style.display = "none";
            checkErroredConnectionStrings();
        }
    } else {
        if (duplicatename) {
            document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].classList.remove("incompleteConnectionString");
            document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].classList.add("duplicateConnectionStringName");
            document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].setAttribute("error-text-to-append", " (duplicate)");
            document.getElementById("DuplicateConnectionString-Alert").style.display = "block";
            checkErroredConnectionStrings();
        } else {
            document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].classList.remove("incompleteConnectionString");
            document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].classList.remove("duplicateConnectionStringName");
            document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].setAttribute("error-text-to-append", "");
            document.getElementById("DuplicateConnectionString-Alert").style.display = "none";
            checkErroredConnectionStrings();
        }
    }
}

async function tnsConnectionStringCheckCheckboxV3(field) {
    if (field.checked == true) {
        document.getElementById("Oracle-Database").disabled = false;
        document.getElementById("Port").disabled = false;
        document.getElementById("Protocol").disabled = false;
        setRequiredFieldAlertsV3(["oracle1"]);
    } else {
        document.getElementById("Oracle-Database").disabled = true;
        document.getElementById("Port").disabled = true;
        document.getElementById("Protocol").disabled = true;
        setRequiredFieldAlertsV3(["oracle2"]);
    }

    connectionStringTextInputFieldUpdatedV3(field);
}

async function disableConnectionStringButtonsV3(value) {
    document.getElementById("Copy-ConnectionString").disabled = (value === 'true');
    document.getElementById("Delete-ConnectionString").disabled = (value === 'true');
    document.getElementById("TestConnectionString").disabled = (value === 'true');
}

async function newConnectionStringV3() {
    configurationChanged = true;
    await disableConnectionStringFieldsV3("false");

    let ConnectionStringSelectList = document.getElementById("ConnectionStrings-SelectList");
    let opt = document.createElement("option");
    opt.setAttribute("value", "connectionstring" + connectionStringIdNumber);
    opt.setAttribute("class", "connectionStringOption");
    opt.setAttribute("error-text-to-append", "");
    opt.setAttribute("related-duplicates", "");
    opt.innerText = "";
    ConnectionStringSelectList.append(opt);

    let objectToAddToArray = {
        sql: {
            DataSource: "",
            Database: ""
        },
        oracle: {
            TNSConnectionString: "true",
            Host: "",
            Database: "",
            Protocol: "TCP",
            Port: ""
        },
        Name: "",
        Provider: "System.Data.SqlClient",
        IntegratedSecurity: "True",
        UserId: "",
        Password: "",
        AdditionalOptions: "",
        id: opt.value
    };
    ConnectionStringsArray.push(objectToAddToArray);

    connectionStringIdNumber++;

    ConnectionStringSelectList.value = opt.value;
    await addDataSourceOptionV3(opt.value);
    await resetConnectionStringFieldsV3();
    await setRequiredFieldAlertsV3(["sql", "name"]);
    await disableConnectionStringButtonsV3("false");
    await checkSetAppendedTextErrorV3();
}

async function addDataSourceOptionV3(idvalue) {
    let dataSourceElement = document.getElementById("Data-Source");

    let dataSourceOption = ConnectionStringsArray.filter(result => result.id === idvalue);

    let opt = document.createElement('option');
    opt.innerText = dataSourceOption[0]["Name"];
    opt.setAttribute("value", "DataSource" + dataSourceOption[0]["id"]);
    dataSourceElement.appendChild(opt);
}

async function resetConnectionStringFieldsV3() {
    document.getElementById("Data-Source-Name").value = "";
    document.getElementById("Data-Provider").value = "System.Data.SqlClient";
    //document.getElementById("Additional-Options").value = "";
    document.getElementById("Integrated-Security").checked = true;
    document.getElementById("User-ID").value = "";
    document.getElementById("User-ID").disabled = true;
    document.getElementById("Password").value = "";
    document.getElementById("Password").disabled = true;
    document.getElementById("Sql-Data-Source").value = "";
    document.getElementById("Sql-Database").value = "";
    document.getElementById("Oracle-Fields-TNS-Connection-String").checked = true;
    document.getElementById("Host").value = "";
    document.getElementById("Protocol").value = "TCP";
    document.getElementById("Oracle-Database").value = "";
    document.getElementById("Port").value = "";
    document.getElementById("DuplicateConnectionString-Alert").style.display = "none";
    document.getElementById("Additional-Options").value = "";
}

async function deleteDataSourceOptionV3(idvalue) {
    if (document.getElementById("Data-Source").value == "DataSource" + idvalue) {
        document.getElementById("Data-Source").querySelector('option[value="DataSource' + idvalue + '"]').remove()
        document.getElementById("Data-Source").value = "";
    } else {
        document.getElementById("Data-Source").querySelector('option[value="DataSource' + idvalue + '"]').remove()
    }
}

async function copyConnectionStringV3() {
    //Lookup the details of the current route selected in the hylandLoggingDiagnosticsRoutesDetails array and set it to a variable.
    let cstringSelected = ConnectionStringsArray.filter(cstring => cstring.id === document.getElementById("ConnectionStrings-SelectList").value);

    //Create the templated object to update and then add to the main array.
    let newCString = {
        sql: {
            DataSource: cstringSelected[0].sql.DataSource,
            Database: cstringSelected[0].sql.Database
        },
        oracle: {
            TNSConnectionString: cstringSelected[0].oracle.TNSConnectionString,
            Host: cstringSelected[0].oracle.Host,
            Database: cstringSelected[0].oracle.Database,
            Protocol: cstringSelected[0].oracle.Protocol,
            Port: cstringSelected[0].oracle.Port
        },
        Name: "",
        Provider: cstringSelected[0]["Provider"],
        IntegratedSecurity: cstringSelected[0].IntegratedSecurity,
        UserId: cstringSelected[0].UserId,
        Password: cstringSelected[0].Password,
        AdditionalOptions: cstringSelected[0].AdditionalOptions,
        id: "connectionstring" + connectionStringIdNumber
    };
    connectionStringIdNumber++;

    //Append the classic "(#)" to the end of the Route Name.
    let foundNumber = 1;
    let copyNumber = 1;
    while (foundNumber > 0) {
        let existingCheck = ConnectionStringsArray.filter(cstring2 => cstring2.DataSourceName === (cstringSelected[0]["Name"] + "(" + copyNumber + ")"));
        if (existingCheck.length == 0) {
            newCString.Name = cstringSelected[0].Name + "(" + copyNumber + ")";
            foundNumber = 0;
        }
        copyNumber++;
    }

    let opt = document.createElement("option");
    opt.setAttribute("value", newCString["id"]);
    opt.setAttribute("class", "connectionStringOption");
    opt.innerText = newCString["Name"];
    opt.setAttribute("error-text-to-append", "");
    document.getElementById("ConnectionStrings-SelectList").append(opt);
    ConnectionStringsArray.push(newCString);

    document.getElementById("ConnectionStrings-SelectList").value = newCString.id;
    document.getElementById("Data-Source-Name").value = newCString.Name;
    await addDataSourceOptionV3(newCString.id);
}

async function deleteConnectionStringV3() {
    if (document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].attributes["related-duplicate"] != "") {
        let relatedDuplicates = document.getElementById("ConnectionStrings-SelectList").options[document.getElementById("ConnectionStrings-SelectList").selectedIndex].attributes["related-duplicates"].value.split(",");
        //console.log("Related Duplicates: " + relatedDuplicates.length);
        if (relatedDuplicates.length > 0) {
            //This means that it has more than 1 related duplicate.
            //Going to find each of the related items and perform the appropriate logic.
            for (let i = 0; i < relatedDuplicates.length; i++) {
                //Gets the options from the ConnectionStrings-SelectList element.
                let options = document.getElementById("ConnectionStrings-SelectList").options;
                //Parses over each of the options to find the related duplicates.
                for (let i = 0; i < options.length; i++) {
                    //Once we find the related duplicate, we need to remove the current selected value from the related-duplicates attribute.
                    if (options[i].attributes["related-duplicates"].value.includes(document.getElementById("ConnectionStrings-SelectList").value)) {
                        //Now that we found the option, we will replace the current selected value with an empty string.
                        options[i].attributes["related-duplicates"].value = options[i].attributes["related-duplicates"].value.replace(document.getElementById("ConnectionStrings-SelectList").value, "");
                        //Now we will check and see if there are any other related duplicates or not. If there are not, we will remove the duplicate class from the option as well as update the error-text-to-append attribute to no longer include the (duplicate) string. If there is, then we will leave it alone.
                        if (options[i].attributes["related-duplicates"].value == "") {
                            //Now we will remove the duplicate class from the option.
                            options[i].classList.remove("duplicateConnectionStringName");
                            //Now we will remove the error text to append from the option.
                            options[i].attributes["error-text-to-append"].value = options[i].attributes["error-text-to-append"].value.replace(" (duplicate)", "");
                        }
                    }
                }
            }
        }
    }
    await deleteDataSourceOptionV3(document.getElementById("ConnectionStrings-SelectList").value);
    for (let i = 0; i < ConnectionStringsArray.length; i++) {
        if (ConnectionStringsArray[i].id == document.getElementById("ConnectionStrings-SelectList").value) {
            ConnectionStringsArray.splice(i, 1);
        }
    }
    document.getElementById("ConnectionStrings-SelectList").querySelector('option[value="' + document.getElementById("ConnectionStrings-SelectList").value + '"]').remove();
    await resetConnectionStringFieldsV3();
    await disableConnectionStringFieldsV3("true");
    await disableConnectionStringButtonsV3("true");
    await setRequiredFieldAlertsV3(["none"]);
}

async function deleteDataSourceOptionV3(idvalue) {
    if (document.getElementById("Data-Source").value == "DataSource" + idvalue) {
        document.getElementById("Data-Source").querySelector('option[value="DataSource' + idvalue + '"]').remove()
        document.getElementById("Data-Source").value = "";
    } else {
        document.getElementById("Data-Source").querySelector('option[value="DataSource' + idvalue + '"]').remove()
    }
}

async function checkIncompleteFieldsV3() {
    var visibleErrorElements = "";

    switch (document.getElementById("Data-Provider").value) {
        case "System.Data.SqlClient":
            visibleErrorElements = document.querySelectorAll('.sqlConnectionStringRequiredAlertSvg:is([style*="display: block"]), .coreConnectionStringRequiredAlertSvg:is([style*="display: block"])');
            break;
        case "Oracle.ManagedDataAccess.Client":
            visibleErrorElements = document.querySelectorAll('.oracleConnectionStringRequiredAlertSvg:is([style*="display: block"]), .coreConnectionStringRequiredAlertSvg:is([style*="display: block"])');
            break;
    }

    if (visibleErrorElements.length > 0) {
        return true;
    } else {
        return false;
    }
}

async function validateConnectionStringFieldLengthV3(field) {
    if (connectionStringAction != "delete") {
        if (document.getElementById(field.id).value.length > 0) {
            document.getElementById(field.id + "-RequiredSvg").style.display = "none";
        } else {
            document.getElementById(field.id + "-RequiredSvg").style.display = "block";
        }

        await checkSetAppendedTextErrorV3();
    }
}

async function checkErroredConnectionStrings() {
    let incompleteConnectionStrings = document.getElementsByClassName("incompleteConnectionString");
    let duplicateConnectionStrings = document.getElementsByClassName("duplicateConnectionStringName");

    if (incompleteConnectionStrings.length > 0 || duplicateConnectionStrings.length > 0) {
        await pushErrorToArray(await findErrorArrayToSet("connectionStringDataSourceName"));
    } else {
        await spliceErrorFromArray("connectionStringDataSourceName");
    }
}

async function testConnectionString() {
    //Get the selected connection string from the ConnectionStringsArray.
    let selectedConnectionString = ConnectionStringsArray.filter(cstring => cstring.id === document.getElementById("ConnectionStrings-SelectList").value);
    console.log(selectedConnectionString);
    document.getElementById("connectionStringTestModal").style.display = "flex";
    const fetchOptions = {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(selectedConnectionString[0])
    };
    fetch(apiRootUrl + "/api/Endpoint/TestConnectionString?cstringobject=" + JSON.stringify(selectedConnectionString[0]))
        .then(response => response.json())
        .then(data => {
            document.getElementById("connectionStringTestModal").style.display = "none";
            console.log(data);
            console.log(data["ResultCode"] == "1");
            let testconnectionalert = document.getElementById("TestConnectionString-Alert");
            console.log(testconnectionalert);
            if (data["ResultCode"] == "0") {
                testconnectionalert.innerText = data["ResultMessage"];
                testconnectionalert.style.color = "green";
            } else if (data["ResultCode"] == "1") {
                testconnectionalert.innerText = data["ResultMessage"];
                testconnectionalert.style.color = "red";
            }
        });
}


/********************************************************
*          Error Loading Web Application Modal
********************************************************/
async function closeErrorLoadModal() {
    document.getElementById("errorLoadModal").style.display = "none";
}

async function populateErrorLoadModal(errorArray,errorType) {
    for (let i = 0; i < errorArray.length; i++) {
        let li = document.createElement("li");
        li.innerText = errorArray[i];
        document.getElementById("errorLoadModal-ErrorList").appendChild(li);
    }

    showErrorLoadModal();
}

async function showErrorLoadModal() {
    document.getElementById("ProcessingWebConfigValuesProgress").style.display = "none";
    document.getElementById("errorLoadModal").style.display = "flex";
}



/********************************************************
*               Identity Provider Functions
********************************************************/
async function validateIdentityProviderFields(field) {
    let idpFields = ["IdP-Server-Location", "IdP-Tenant", "IdP-Client", "IdP-Secret"];
    let allIdpFieldsEmpty = true;
    //Check if any of the fields in the idpFields array are empty or not.
    for (let i = 0; i < idpFields.length; i++) {
        if (document.getElementById(idpFields[i]).value.length > 0) {
            //console.log("Field Length: "+document.getElementById(idpFields[i]).value.length);
            allIdpFieldsEmpty = false;
        }
    }

    //If all of the fields are empty, then we will not display the error icon for each of the fields.
    if (!allIdpFieldsEmpty) {
        //All of the fields are not empty, so I need to check each field and see if it is empty or not.
        for (let i = 0; i < idpFields.length; i++) {
            if (document.getElementById(idpFields[i]).value.length == 0) {
                document.getElementById(idpFields[i] + "-RequiredSvg").style.display = "block";
            } else {
                document.getElementById(idpFields[i] + "-RequiredSvg").style.display = "none";
            }
        }
    } else {
        //All of the fields are empty, so I need to remove the error icon for each of the fields.
        for (let i = 0; i < idpFields.length; i++) {
            document.getElementById(idpFields[i] + "-RequiredSvg").style.display = "none";
        }
    }

    //Still need to add the code to push an error to the error array if any of the -RequiredSvg elements are visible.
    //Query all of the elements with a class of "idpRequiredAlertSvg" and check if any of them are visible. If they are, then push an error to the error array.
    const visibleElements = Array.from(document.querySelectorAll('.idpRequiredAlertSvg')).filter(element => element.style.display == "block");
    
    if (visibleElements.length > 0) {
        switch (coreConfigData.Type) {
            case "Web Server":
                pushErrorToArray(await findErrorArrayToSet("webServerIdentityProviderIncompleteFields"));
                break;
            case "Healthcare Form Manager":
                pushErrorToArray(await findErrorArrayToSet("healthcareFormManagerIdentityProviderIncompleteFields"));
                break;
            case "Patient Window":
                pushErrorToArray(await findErrorArrayToSet("onbasePatientWindowIdentityProviderIncompleteFields"));
                break;
            case "Reporting Viewer":
                pushErrorToArray(await findErrorArrayToSet("reportingViewerIdentityProviderIncompleteFields"));
                break;
        }
    } else {
        switch (coreConfigData.Type) {
            case "Web Server":
                spliceErrorFromArray("webServerIdentityProviderIncompleteFields");
                break;
            case "Healthcare Form Manager":
                spliceErrorFromArray("healthcareFormManagerIdentityProviderIncompleteFields");
                break;
            case "Patient Window":
                spliceErrorFromArray("onbasePatientWindowIdentityProviderIncompleteFields");
                break;
            case "Reporting Viewer":
                spliceErrorFromArray("reportingViewerIdentityProviderIncompleteFields");
                break;
        }
    }
}


/********************************************************
*            Dark/Light Mode Toggle Functions
********************************************************/
function toggleDarkLightMode(checkbox) {
    console.log(checkbox.checked);
    if (checkbox.checked) {
        localStorage.setItem("darkModeState", true);
        //Elements to add "dark_mode" class to:
        document.body.classList.add('dark_mode');
        document.getElementById("chooseWebApplicationModal-Table-Buttons-Container").classList.add('dark_mode');
        document.getElementById("Loading-Web-Applications-Progress-Section").classList.add('dark_mode');
        document.getElementById("CopyWebApplicationModal-Container").classList.add('dark_mode');
        document.getElementById("SaveErrors-Content").classList.add('dark_mode');
        document.getElementById("ProcessingWebConfigValuesProgress-Content").classList.add('dark_mode');
        document.getElementById("errorLoadModal-content").classList.add('dark_mode');

        //Elements to add "dark_mode_titlebar" class to:
        document.getElementById("h1-container").classList.add('dark_mode_titlebar');
        document.getElementById("core-action-buttons-div").classList.add('dark_mode_titlebar');
        document.getElementById("ChooseApplicationTitleBar").classList.add('dark_mode_titlebar');
        Array.from(document.getElementsByClassName("titleBar")).forEach(element => {
            element.classList.add('dark_mode_titlebar')
        });
        Array.from(document.getElementsByClassName("CopyWebApplicationModal-TitleBar-Container-Styling")).forEach(element => {
            element.classList.add('dark_mode_titlebar');
        });

        //Elements to add "dark_mode_button" class to:
        Array.from(document.getElementsByClassName("core-action-buttons")).forEach(element => {
            element.classList.add('dark_mode_button')
        });

        //Elements to add "dark_mode_select" class to:
        Array.from(document.getElementsByTagName("select")).forEach(element => {
            element.classList.add('dark_mode_select');
        });

        //Elements to add "dark_mode_links" class to:
        Array.from(document.getElementsByClassName("sectionLinks")).forEach(element => {
            element.classList.add('dark_mode_links');
        });
    } else {
        localStorage.setItem("darkModeState", false);
        //Elements to remove "dark_mode" class to:
        document.body.classList.remove('dark_mode');
        document.getElementById("chooseWebApplicationModal-Table-Buttons-Container").classList.remove('dark_mode');
        document.getElementById("Loading-Web-Applications-Progress-Section").classList.remove('dark_mode');
        document.getElementById("CopyWebApplicationModal-Container").classList.remove('dark_mode');
        document.getElementById("SaveErrors-Content").classList.remove('dark_mode');
        document.getElementById("ProcessingWebConfigValuesProgress-Content").classList.remove('dark_mode');
        document.getElementById("errorLoadModal-content").classList.remove('dark_mode');

        //Elements to add "dark_mode_titlebar" class to:
        document.getElementById("h1-container").classList.remove('dark_mode_titlebar');
        document.getElementById("core-action-buttons-div").classList.remove('dark_mode_titlebar');
        document.getElementById("ChooseApplicationTitleBar").classList.remove('dark_mode_titlebar');
        Array.from(document.getElementsByClassName("titleBar")).forEach(element => {
            element.classList.remove('dark_mode_titlebar')
        });
        Array.from(document.getElementsByClassName("CopyWebApplicationModal-TitleBar-Container-Styling")).forEach(element => {
            element.classList.remove('dark_mode_titlebar');
        });

        //Elements to add "dark_mode_button" class to:
        Array.from(document.getElementsByClassName("core-action-buttons")).forEach(element => {
            element.classList.remove('dark_mode_button')
        });

        //Elements to add "dark_mode_select" class to:
        Array.from(document.getElementsByTagName("select")).forEach(element => {
            element.classList.remove('dark_mode_select');
        });
        Array.from(document.getElementsByClassName("sectionLinks")).forEach(element => {
            element.classList.remove('dark_mode_links');
        });
    }

    console.log(localStorage.getItem("darkModeState"));
}



/********************************************************
*                 Generic Functions
********************************************************/
async function findErrorArrayToSet(name) {
    return errorArrays.find(errorArray => errorArray.Name == name).Array;
}

async function groupDuplicateObjectsFromArray(array,groupingKeyName) {
    return array.reduce((result, currentItem) => {
        // Extract the 'Name' value
        const key = groupingKeyName;

        // If the key doesn't exist in the result object, create an array for it
        if (!result[key]) {
            result[key] = [];
        }

        // Push the current item to the array for the key
        result[key].push(currentItem);

        return result;
    }, {}); // Initial value is an empty object
}


/********************************************************
*                 Template Name Header
********************************************************/