/* General Web Server Variables V2 */
let customValidationApplicationLevel = [];
let applicationLevelIdNumber = 0;
let customValidationPageLevelData = [];
let pageLevelIdNumber = 0;
let hwvSourceOriginWhiteList = [];
let hwvSourceOriginWhiteListIdNumber = 0;



/********************************************************
 *              Core Script Functions
 ********************************************************/
function resetBorderStyling(field) {
    field.currentTarget.classList.remove("invalidUrl","validUrl");
}

function folderingHeightPercentageCalculations(){
    let totalHeightPercentageCombined = parseInt(document.getElementById("Folder-Tree-Height").value) + parseInt(document.getElementById("Document-List-Height").value) + parseInt(document.getElementById("Folder-List-Height").value);
    document.getElementById("Foldering-Total-Percentage-Number-Value").innerText = totalHeightPercentageCombined;
    if(totalHeightPercentageCombined != 100){
        document.getElementById("Foldering-Total-Percentage-Number-Value").classList.add("folderingPercentageTooHigh");
        if(!verifyErrorNotInArrayAlready("folderingHeightPercentage")){
            pushErrorToArray(folderingHeightErrorArray);
        }
    }else{
        document.getElementById("Foldering-Total-Percentage-Number-Value").classList.remove("folderingPercentageTooHigh");
        spliceErrorFromArray("folderingHeightPercentage");
    }
    (totalHeightPercentageCombined != 100) ? document.getElementById("Foldering-Total-Percentage-Number-Value").classList.add("folderingPercentageTooHigh") : document.getElementById("Foldering-Total-Percentage-Number-Value").classList.remove("folderingPercentageTooHigh");
}

function setElementDisabled(id,value){
    document.getElementById(id).disabled = value;
}

function checkNumericBoundaries(field){
    switch(field.id){
        case "Destination-Type-File-Retained-Files-Count":
            (field.value<0) ? field.value=0: "";
            break;
    }
}

function closeAlertModal(){
    document.getElementById("AlertModal").style.display = "none";
}

function optimizeForWindowsAuthChangedWebServer(field){
    switch(field.id){
        case "OptimizeForWindowsAuth-WebClient":
            if(field.checked){
                optimizeForWindowsAuth.push(field.id.substring(field.id.indexOf("-")+1));
                document.getElementById("Autologin").checked = true;
            } else {
                optimizeForWindowsAuth.splice(optimizeForWindowsAuth.indexOf(field.id.substring(field.id.indexOf("-") + 1)), 1);
            }
            break;
        case "OptimizeForWindowsAuth-DocPop":
            if(field.checked){
                optimizeForWindowsAuth.push(field.id.substring(field.id.indexOf("-")+1));
                document.getElementById("DocPop-Auto-Login").checked = true;
            }else{
                optimizeForWindowsAuth.splice(optimizeForWindowsAuth.indexOf(field.id.substring(field.id.indexOf("-")+1)),1);
            }
            break;
        case "OptimizeForWindowsAuth-PdfPop":
            if (field.checked) {
                optimizeForWindowsAuth.push(field.id.substring(field.id.indexOf("-")+1));
                document.getElementById("PdfPop-Auto-Login").checked = true;
            }else{
                optimizeForWindowsAuth.splice(optimizeForWindowsAuth.indexOf(field.id.substring(field.id.indexOf("-")+1)),1);
            }
            break;
        case "OptimizeForWindowsAuth-FormPop":
            if(field.checked){
                optimizeForWindowsAuth.push(field.id.substring(field.id.indexOf("-")+1));
                document.getElementById("FormPop-Auto-Login").checked = true;
            }else{
                optimizeForWindowsAuth.splice(optimizeForWindowsAuth.indexOf(field.id.substring(field.id.indexOf("-")+1)),1);
            }
            break;
        case "OptimizeForWindowsAuth-FolderPop":
            if(field.checked){
                optimizeForWindowsAuth.push(field.id.substring(field.id.indexOf("-")+1));
                document.getElementById("FolderPop-Auto-Login").checked = true;
            }else{
                optimizeForWindowsAuth.splice(optimizeForWindowsAuth.indexOf(field.id.substring(field.id.indexOf("-")+1)),1);
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
 *              Healthcare Web Viewer
 ********************************************************/
async function sourceOriginSelected() {
    document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist").value = document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist-SelectList").options[document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist-SelectList").selectedIndex].innerText;
    document.getElementById("HealthcareWebViewer-SourceOrigin-DeleteButton").disabled = false;
    document.getElementById("HealthcareWebViewer-SourceOrigin-NewButton").disabled = false;
    document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist").disabled = false;
}

async function sourceOriginUrlFieldUpdated() {
    let result = hwvSourceOriginWhiteList.filter(sourl => sourl.id == document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist-SelectList").value);
    document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist-SelectList").options[document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist-SelectList").selectedIndex].innerText = document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist").value;
    result[0].origin = document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist").value;
}

async function newSourceOrigin() {
    configurationChanged = true;
    //Resets the default value of the input field to blank.
    document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist").value = ""
    let opt = document.createElement("option");
    opt.value = "HCWVSourceOrigin" + hwvSourceOriginWhiteListIdNumber;
    opt.innerText = "";
    document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist-SelectList").append(opt);
    document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist-SelectList").selectedIndex = hwvSourceOriginWhiteList.length;

    let optionToArray = {
        origin: "",
        id: "HCWVSourceOrigin" + hwvSourceOriginWhiteListIdNumber
    };
    hwvSourceOriginWhiteList.push(optionToArray);

    hwvSourceOriginWhiteListIdNumber++;
    document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist").disabled = false;
    document.getElementById("HealthcareWebViewer-SourceOrigin-DeleteButton").disabled = false;
}

async function deleteSourceOrigin() {
    for (let i = 0; i < hwvSourceOriginWhiteList.length; i++) {
        if (hwvSourceOriginWhiteList[i].id == document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist-SelectList").value) {
            hwvSourceOriginWhiteList.splice(i, 1);
        }
    }

    document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist-SelectList").remove(document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist-SelectList").selectedIndex);
    document.getElementById("HealthcareWebViewer-SourceOrigin-DeleteButton").disabled = true;
    document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist").disabled = true;
    //Resets the default value of the input field to blank.
    document.getElementById("Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Source-Origin-Whitelist").value = ""
}


/********************************************************
*               V2 Web Server Functions
********************************************************/
async function parseCustomValidation(config) {
    let appLevelSelectList = document.getElementById("CustomValidation-ApplicationLevel-SelectList");
    customValidationApplicationLevel = config["application"]["keywords"];

    document.getElementById("Application-Script-Location").value = config["application"]["scriptLocation"];

    if (customValidationApplicationLevel.length > 0) {
        for (let i = 0; i < customValidationApplicationLevel.length; i++) {
            let opt = document.createElement("option");
            opt.value = "customValidationAppLevel" + applicationLevelIdNumber;
            opt.innerText = customValidationApplicationLevel[i]["keywordId"] + " (" + customValidationApplicationLevel[i]["validator"] + ")";
            opt.setAttribute("error-text-to-append", "");
            opt.setAttribute("class", "customValidationAppLevelOption");
            appLevelSelectList.append(opt);
            customValidationApplicationLevel[i]["id"] = "customValidationAppLevel" + applicationLevelIdNumber;
            applicationLevelIdNumber++;
        }
    }

    let pageLevelSelectList = document.getElementById("CustomValidation-PageLevel-SelectList");
    customValidationPageLevelData = config["pages"];

    for (let j = 0; j < customValidationPageLevelData.length; j++) {
        let opt = document.createElement("option");
        opt.value = customValidationPageLevelData[j]["htmlId"];
        opt.innerText = customValidationPageLevelData[j]["name"];
        pageLevelSelectList.append(opt);
    }

    document.getElementById("customValidationPagesAddKeywordButton").disabled = true;
    await lockCustomValidationButtons("Page");
    await lockCustomValidationButtons("Application");
    await lockCustomValidationFields("Application");
    await lockCustomValidationFields("Page");
}

async function customValidationSelectionChanged(level) {
    switch (level) {
        case "Application":
            let result = customValidationApplicationLevel.filter(kwconf => kwconf.id == document.getElementById("CustomValidation-ApplicationLevel-SelectList").value);
            document.getElementById("Application-Keyword-ID").value = result[0].keywordId;
            document.getElementById("Application-Keyword-Validator").value = result[0].validator;
            await checkIncompleteFieldValues(level);
            await lockCustomValidationFields(level, "None");
            break;
        case "Page":
            let pageKeywordsSelectList = document.getElementById("CustomValidation-PageLevel-Keywords-SelectList");

            if (pageKeywordsSelectList.options.length > 0) {
                pageKeywordsSelectList.innerHTML = "";
                await resetCustomValidationFields(level);
                await clearCustomValidationRequired(level);
            }

            let kwconfigresult = customValidationPageLevelData.filter(kwconf => kwconf.htmlId == document.getElementById("CustomValidation-PageLevel-SelectList").value);
            await lockCustomValidationFields(level, "Fields");
            for (let i = 0; i < kwconfigresult[0]["keywords"].length; i++) {
                if (kwconfigresult[0]["keywords"][i]["id"] == null) {
                    let opt = document.createElement("option");
                    opt.value = "customValidationPageLevel" + pageLevelIdNumber;
                    opt.setAttribute("class", "customValidationPageLevelOptionKeyword");
                    if (kwconfigresult[0]["keywords"][i]["keywordId"] == "" || kwconfigresult[0]["keywords"][i]["validator"] == "") {
                        opt.setAttribute("error-text-to-append", " (Incomplete)");
                    } else {
                        opt.setAttribute("error-text-to-append", "");
                    }
                    kwconfigresult[0]["keywords"][i]["id"] = "customValidationPageLevel" + pageLevelIdNumber;
                    opt.innerText = kwconfigresult[0]["keywords"][i]["keywordId"] + " (" + kwconfigresult[0]["keywords"][i]["validator"] + ")";
                    pageKeywordsSelectList.append(opt);
                    pageLevelIdNumber++;
                } else {
                    let opt = document.createElement("option");
                    opt.value = kwconfigresult[0]["keywords"][i]["id"];
                    opt.setAttribute("class", "customValidationPageLevelOptionKeyword");
                    if (kwconfigresult[0]["keywords"][i]["keywordId"] == "" || kwconfigresult[0]["keywords"][i]["validator"] == "") {
                        opt.setAttribute("error-text-to-append", " (Incomplete)");
                    } else {
                        opt.setAttribute("error-text-to-append", "");
                    }
                    opt.innerText = kwconfigresult[0]["keywords"][i]["keywordId"] + " (" + kwconfigresult[0]["keywords"][i]["validator"] + ")";
                    pageKeywordsSelectList.append(opt);
                }
            }
            await lockCustomValidationButtons(level, "Delete");
            document.getElementById("Page-Location").value = kwconfigresult[0]["location"];
            document.getElementById("Page-Script-Location").vaue = kwconfigresult[0]["scriptLocation"];
            break;
    }
}

async function checkIncompleteFieldValues(level) {
    switch (level) {
        case "Application":
            if (document.getElementById("Application-Keyword-ID").value == "") {
                document.getElementById("Application-Keyword-ID" + "-RequiredSvg").style.display = "block";
                document.getElementById("CustomValidation-ApplicationLevel-SelectList").options[document.getElementById("CustomValidation-ApplicationLevel-SelectList").selectedIndex].setAttribute("error-text-to-append", " (incomplete)");
                document.getElementById("CustomValidation-ApplicationLevel-SelectList").options[document.getElementById("CustomValidation-ApplicationLevel-SelectList").selectedIndex].classList.add("IncompleteCustomValidationApplicationLevelKeywordConfigurationOption");
                if (document.getElementsByClassName("IncompleteCustomValidationApplicationLevelKeywordConfigurationOption").length > 0) {
                    pushErrorToArray(customValidationApplicationLevelIncompleteFieldsErrorArray);
                }
                if (document.getElementById("Application-Keyword-Validator").value == "") {
                    document.getElementById("Application-Keyword-Validator" + "-RequiredSvg").style.display = "block";
                    document.getElementById("CustomValidation-ApplicationLevel-SelectList").options[document.getElementById("CustomValidation-ApplicationLevel-SelectList").selectedIndex].setAttribute("error-text-to-append", " (incomplete)");
                    document.getElementById("CustomValidation-ApplicationLevel-SelectList").options[document.getElementById("CustomValidation-ApplicationLevel-SelectList").selectedIndex].classList.add("IncompleteCustomValidationApplicationLevelKeywordConfigurationOption");
                    if (document.getElementsByClassName("IncompleteCustomValidationApplicationLevelKeywordConfigurationOption").length > 0) {
                        pushErrorToArray(customValidationApplicationLevelIncompleteFieldsErrorArray);
                    }
                } else {
                    document.getElementById("Application-Keyword-Validator" + "-RequiredSvg").style.display = "none";
                }
            } else {
                document.getElementById("Application-Keyword-ID" + "-RequiredSvg").style.display = "none";
                if (document.getElementById("Application-Keyword-Validator").value == "") {
                    document.getElementById("Application-Keyword-Validator" + "-RequiredSvg").style.display = "block";
                    document.getElementById("CustomValidation-ApplicationLevel-SelectList").options[document.getElementById("CustomValidation-ApplicationLevel-SelectList").selectedIndex].setAttribute("error-text-to-append", " (incomplete)");
                    document.getElementById("CustomValidation-ApplicationLevel-SelectList").options[document.getElementById("CustomValidation-ApplicationLevel-SelectList").selectedIndex].classList.add("IncompleteCustomValidationApplicationLevelKeywordConfigurationOption");
                    if (document.getElementsByClassName("IncompleteCustomValidationApplicationLevelKeywordConfigurationOption").length > 0) {
                        pushErrorToArray(customValidationApplicationLevelIncompleteFieldsErrorArray);
                    }
                } else {
                    document.getElementById("Application-Keyword-Validator" + "-RequiredSvg").style.display = "none";
                    document.getElementById("CustomValidation-ApplicationLevel-SelectList").options[document.getElementById("CustomValidation-ApplicationLevel-SelectList").selectedIndex].setAttribute("error-text-to-append", "");
                    document.getElementById("CustomValidation-ApplicationLevel-SelectList").options[document.getElementById("CustomValidation-ApplicationLevel-SelectList").selectedIndex].classList.remove("IncompleteCustomValidationApplicationLevelKeywordConfigurationOption");
                    if (document.getElementsByClassName("IncompleteCustomValidationApplicationLevelKeywordConfigurationOption").length > 0) {
                        pushErrorToArray(customValidationApplicationLevelIncompleteFieldsErrorArray);
                    } else {
                        spliceErrorFromArray("customValidationApplicationLevelIncompleteFields");
                    }
                }
            }
            break;
        case "Page":
            if (document.getElementById("Page-Keyword-ID").value == "") {
                document.getElementById("Page-Keyword-ID" + "-RequiredSvg").style.display = "block";
                document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").options[document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").selectedIndex].setAttribute("error-text-to-append", " (incomplete)");
                document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").options[document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").selectedIndex].classList.add("IncompleteCustomValidationPageLevelKeywordConfigurationOption");
                if (document.getElementsByClassName("IncompleteCustomValidationPageLevelKeywordConfigurationOption").length > 0) {
                    pushErrorToArray(customValidationPageLevelIncompleteFieldsErrorArray);
                }
                if (document.getElementById("Page-Keyword-Validator").value == "") {
                    document.getElementById("Page-Keyword-Validator" + "-RequiredSvg").style.display = "block";
                    document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").options[document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").selectedIndex].setAttribute("error-text-to-append", " (incomplete)");
                    document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").options[document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").selectedIndex].classList.add("IncompleteCustomValidationPageLevelKeywordConfigurationOption");
                    if (document.getElementsByClassName("IncompleteCustomValidationPageLevelKeywordConfigurationOption").length > 0) {
                        pushErrorToArray(customValidationPageLevelIncompleteFieldsErrorArray);
                    }
                } else {
                    document.getElementById("Page-Keyword-Validator" + "-RequiredSvg").style.display = "none";
                }
            } else {
                document.getElementById("Page-Keyword-ID" + "-RequiredSvg").style.display = "none";
                if (document.getElementById("Page-Keyword-Validator").value == "") {
                    document.getElementById("Page-Keyword-Validator" + "-RequiredSvg").style.display = "block";
                    document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").options[document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").selectedIndex].setAttribute("error-text-to-append", " (incomplete)");
                    document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").options[document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").selectedIndex].classList.add("IncompleteCustomValidationPageLevelKeywordConfigurationOption");
                    if (document.getElementsByClassName("IncompleteCustomValidationPageLevelKeywordConfigurationOption").length > 0) {
                        pushErrorToArray(customValidationPageLevelIncompleteFieldsErrorArray);
                    }
                } else {
                    document.getElementById("Page-Keyword-Validator" + "-RequiredSvg").style.display = "none";
                    document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").options[document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").selectedIndex].setAttribute("error-text-to-append", "");
                    document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").options[document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").selectedIndex].classList.remove("IncompleteCustomValidationPageLevelKeywordConfigurationOption");
                    if (document.getElementsByClassName("IncompleteCustomValidationPageLevelKeywordConfigurationOption").length > 0) {
                        pushErrorToArray(customValidationPageLevelIncompleteFieldsErrorArray);
                    } else {
                        spliceErrorFromArray("customValidationPageLevelIncompleteFields");
                    }
                }
            }
            break;
    }
}

async function addCustomValidationKeywordConfiguration(level) {
    configurationChanged = true;
    let idValue = "";
    switch (level) {
        case "Application":
            let appLevelSelectList = document.getElementById("CustomValidation-ApplicationLevel-SelectList");
            idValue = "customValidationAppLevel" + applicationLevelIdNumber;
            let kwConfigToAdd = {
                keywordId: "0",
                validator: "",
                id: idValue
            };

            let opt = document.createElement("option");
            opt.value = idValue;
            opt.innerText = "0 ()";
            opt.setAttribute("class", "customValidationAppLevelOption");
            opt.setAttribute("error-text-to-append", "");
            appLevelSelectList.append(opt);
            applicationLevelIdNumber++;
            await lockCustomValidationButtons(level, "None");
            customValidationApplicationLevel.push(kwConfigToAdd);
            document.getElementById("Application-Keyword-ID").value = "0";
            document.getElementById("Application-Keyword-Validator").value = "";
            appLevelSelectList.value = idValue;
            await lockCustomValidationFields(level, "None");
            await lockCustomValidationButtons(level, "None");
            break;
        case "Page":
            let pageSelectList = document.getElementById("CustomValidation-PageLevel-Keywords-SelectList");
            let kwconfigresult = customValidationPageLevelData.filter(kwconf => kwconf.htmlId == document.getElementById("CustomValidation-PageLevel-SelectList").value);
            idValue = "customValidationPageLevel" + pageLevelIdNumber;
            let pageLevelKwConfigToAdd = {
                keywordId: "0",
                validator: "",
                id: idValue
            };

            let pageopt = document.createElement("option");
            pageopt.value = idValue;
            pageopt.innerText = "0 ()";
            pageopt.setAttribute("class", "customValidationPageLevelOptionKeyword");
            kwconfigresult[0]["keywords"].push(pageLevelKwConfigToAdd);
            document.getElementById("Page-Keyword-ID").value = "0";
            document.getElementById("Page-Keyword-Validator").value = "";
            pageSelectList.append(pageopt);
            pageLevelIdNumber++;
            pageSelectList.value = idValue;
            await lockCustomValidationFields(level, "None");
            await lockCustomValidationButtons(level, "None");
            await checkIncompleteFieldValues(level);
            break;
    }
}

async function deleteCustomValidationKeywordConfiguration(level) {
    let idvalue = "";
    switch (level) {
        case "Application":
            for (let i = 0; i < customValidationApplicationLevel.length; i++) {
                if (customValidationApplicationLevel[i].id == document.getElementById("CustomValidation-ApplicationLevel-SelectList").value) {
                    idvalue = customValidationApplicationLevel[i].id;
                    customValidationApplicationLevel.splice(i, 1);
                }
            }

            document.getElementById("CustomValidation-ApplicationLevel-SelectList").querySelector('option[value="' + idvalue + '"]').remove();
            await checkIncompleteFieldValues(level);
            await lockCustomValidationFields(level);
            await lockCustomValidationButtons(level);
            await resetCustomValidationFields(level);
            await clearCustomValidationRequired(level);
            await checkIncompleteFieldsFromKeywords(level);
            break;
        case "Page":
            let pageIdValue = "";
            let pageSelected = customValidationPageLevelData.filter(kwconf => kwconf.htmlId == document.getElementById("CustomValidation-PageLevel-SelectList").value);

            for (let j = 0; j < pageSelected[0]["keywords"].length; j++) {
                if (pageSelected[0]["keywords"][j].id == document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").value) {
                    pageIdValue = pageSelected[0]["keywords"][j].id;
                    pageSelected[0]["keywords"].splice(j, 1);
                }
            }

            document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").querySelector('option[value="' + pageIdValue + '"]').remove();
            await lockCustomValidationFields(level, "Fields");
            await lockCustomValidationButtons(level, "Delete");
            await resetCustomValidationFields(level);
            await clearCustomValidationRequired(level);
            await checkIncompleteFieldsFromKeywords(level);
            break;
    }
}

async function checkIncompleteFieldsFromKeywords(level) {
    switch (level) {
        case "Application":
            if (document.getElementsByClassName("IncompleteCustomValidationApplicationLevelKeywordConfigurationOption").length > 0) {
                pushErrorToArray(customValidationApplicationLevelIncompleteFieldsErrorArray);
            } else {
                spliceErrorFromArray("customValidationApplicationLevelIncompleteFields");
            }
            break;
        case "Page":
            if (document.getElementsByClassName("IncompleteCustomValidationPageLevelKeywordConfigurationOption").length > 0) {
                pushErrorToArray(customValidationPageLevelIncompleteFieldsErrorArray);
            } else {
                spliceErrorFromArray("customValidationPageLevelIncompleteFields");
            }
            break;
    }
}

async function clearCustomValidationRequired(level) {
    switch (level) {
        case "Application":
            document.getElementById("Application-Keyword-ID-RequiredSvg").style.display = "none";
            document.getElementById("Application-Keyword-Validator-RequiredSvg").style.display = "none";
            break;
        case "Page":
            document.getElementById("Page-Keyword-ID-RequiredSvg").style.display = "none";
            document.getElementById("Page-Keyword-Validator-RequiredSvg").style.display = "none";
            break;
    }
}

async function lockCustomValidationButtons(level, action = 'All') {
    switch (level) {
        case "Application":
            switch (action) {
                case "Delete":
                    document.getElementById("Custom-Validation-Application-Delete-Button").disabled = true;
                    break;
                case "All":
                    document.getElementById("Custom-Validation-Application-Delete-Button").disabled = true;
                    break;
                case "None":
                    document.getElementById("Custom-Validation-Application-Delete-Button").disabled = false;
                    break;
            }
            break;
        case "Page":
            switch (action) {
                case "Delete":
                    document.getElementById("customValidationPagesAddKeywordButton").disabled = false;
                    document.getElementById("customValidationPagesDeleteKeywordButton").disabled = true;
                    break;
                case "All":
                    document.getElementById("customValidationPagesAddKeywordButton").disabled = true;
                    document.getElementById("customValidationPagesDeleteKeywordButton").disabled = true;
                    break;
                case "None":
                    document.getElementById("customValidationPagesAddKeywordButton").disabled = false;
                    document.getElementById("customValidationPagesDeleteKeywordButton").disabled = false;
                    break;
            }
            break;
    }
}

async function lockCustomValidationFields(level, action = 'All') {
    switch (level) {
        case "Application":
            switch (action) {
                case "All":
                    document.getElementById("Application-Keyword-ID").disabled = true;
                    document.getElementById("Application-Keyword-Validator").disabled = true;
                    break;
                case "None":
                    document.getElementById("Application-Keyword-ID").disabled = false;
                    document.getElementById("Application-Keyword-Validator").disabled = false;
                    break;
            }
            break;
        case "Page":
            switch (action) {
                case "Fields":
                    document.getElementById("Page-Keyword-ID").disabled = true;
                    document.getElementById("Page-Keyword-Validator").disabled = true;
                    document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").disabled = false;
                    break;
                case "All":
                    document.getElementById("Page-Keyword-ID").disabled = true;
                    document.getElementById("Page-Keyword-Validator").disabled = true;
                    document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").disabled = true;
                    break;
                case "None":
                    document.getElementById("Page-Keyword-ID").disabled = false;
                    document.getElementById("Page-Keyword-Validator").disabled = false;
                    document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").disabled = false;
                    break;
            }
            break;
    }
}

async function customValidationKeywordConfigurationFieldUpdated(level) {
    switch (level) {
        case "Application":
            let result = customValidationApplicationLevel.filter(kwconf => kwconf.id == document.getElementById("CustomValidation-ApplicationLevel-SelectList").value);

            result[0].keywordId = document.getElementById("Application-Keyword-ID").value;
            result[0].validator = document.getElementById("Application-Keyword-Validator").value;

            await updateCustomValidationOptionInnerTextValue(level);
            await checkIncompleteFieldValues(level);
            break;
        case "Page":
            let pageresult = customValidationPageLevelData.filter(kwconf => kwconf.htmlId == document.getElementById("CustomValidation-PageLevel-SelectList").value)[0]["keywords"].filter(kwconf2 => kwconf2.id == document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").value);

            pageresult[0].keywordId = document.getElementById("Page-Keyword-ID").value;
            pageresult[0].validator = document.getElementById("Page-Keyword-Validator").value;

            await updateCustomValidationOptionInnerTextValue(level);
            await checkIncompleteFieldValues(level);
            break;
    }
}

async function updateCustomValidationOptionInnerTextValue(level) {
    switch (level) {
        case "Application":
            document.getElementById("CustomValidation-ApplicationLevel-SelectList").options[document.getElementById("CustomValidation-ApplicationLevel-SelectList").selectedIndex].innerText = document.getElementById("Application-Keyword-ID").value + " (" + document.getElementById("Application-Keyword-Validator").value + ")";
            break;
        case "Page":
            document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").options[document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").selectedIndex].innerText = document.getElementById("Page-Keyword-ID").value + " (" + document.getElementById("Page-Keyword-Validator").value + ")";
            break;
    }
}

async function resetCustomValidationFields(level) {
    switch (level) {
        case "Application":
            document.getElementById("Application-Keyword-ID").value = "";
            document.getElementById("Application-Keyword-Validator").value = "";
            break;
        case "Page":
            document.getElementById("Page-Keyword-ID").value = "";
            document.getElementById("Page-Keyword-Validator").value = "";
            break;
    }
}


/********************************************************
*            Custom Validation - Page Level
********************************************************/
async function customValidationPageLevelKeywordSelectionChanged() {
    let pageresult = customValidationPageLevelData.filter(kwconf => kwconf.htmlId == document.getElementById("CustomValidation-PageLevel-SelectList").value)[0]["keywords"].filter(kwconf2 => kwconf2.id == document.getElementById("CustomValidation-PageLevel-Keywords-SelectList").value);
    document.getElementById("Page-Keyword-ID").value = pageresult[0]["keywordId"];
    document.getElementById("Page-Keyword-Validator").value = pageresult[0]["validator"];
    await lockCustomValidationFields("Page", "None");
    await checkIncompleteFieldValues("Page");
    await lockCustomValidationButtons("Page", "None");
}



/********************************************************
*                Navigation Panel
********************************************************/
async function navigationPanelSelectionChanged() {
    let navPanelContextSelected = NavigationPanelContexts.filter(context => context.id == document.getElementById("NavigationPanel-SelectList").value);
    document.getElementById("NavPanel-Name").value = navPanelContextSelected[0]["contextInfo"]["name"];
    document.getElementById("NavPanel-DisplayName").value = navPanelContextSelected[0]["contextInfo"]["displayName"];
    document.getElementById("NavPanel-DisplayOrder").value = navPanelContextSelected[0]["contextInfo"]["displayOrder"];
    document.getElementById("NavPanel-Icon").value = navPanelContextSelected[0]["contextInfo"]["icon"];
    document.getElementById("NavPanel-ContextEnabled").checked = (navPanelContextSelected[0]["contextInfo"]["enabled"].toLowerCase() === 'true');
    

    let navPanelContextSelectedControlBars = navPanelContextSelected[0]["ControlBars"];

    let innerHTMLString1 = "";
    let innerHTMLString2 = "";
    for (let i = 0; i < navPanelContextSelectedControlBars.length; i++) {
        if (i % 2 == 0) {
            if (navPanelContextSelectedControlBars[i]["enabled"].toLowerCase() === 'true') {
                innerHTMLString1 += `<div class="settingElement">
            <div class="labelElement">
                                <span>` + navPanelContextSelectedControlBars[i]["displayName"] + `:<img class="tooltipimage" src="/images/blue question mark icon - extra small.png" alt="Blue Tooltip Question Mark"> </span>
                                <span class="tooltiptext">This is the help text.</span>
                            </div>
                            <div>
                                <label for="` + navPanelContextSelectedControlBars[i]["name"] + `" class="switch">
                                    <input id="` + navPanelContextSelectedControlBars[i]["name"] + `" type="checkbox" onclick="navPanelControlBarCheckboxChanged(this)" checked>
                                    <span class="slider round"></span>
                                </label>
                            </div>
                        </div>`
            } else {
                innerHTMLString1 += `<div class="settingElement">
            <div class="labelElement">
                                <span>` + navPanelContextSelectedControlBars[i]["displayName"] + `:<img class="tooltipimage" src="/images/blue question mark icon - extra small.png" alt="Blue Tooltip Question Mark"> </span>
                                <span class="tooltiptext">This is the help text.</span>
                            </div>
                            <div>
                                <label for="` + navPanelContextSelectedControlBars[i]["name"] + `" class="switch">
                                    <input id="` + navPanelContextSelectedControlBars[i]["name"] + `" type="checkbox" onclick="navPanelControlBarCheckboxChanged(this)">
                                    <span class="slider round"></span>
                                </label>
                            </div>
                        </div>`
            }
        } else {
            if (navPanelContextSelectedControlBars[i]["enabled"].toLowerCase() === 'true') {
                innerHTMLString2 += `<div class="settingElement">
            <div class="labelElement">
                                <span>` + navPanelContextSelectedControlBars[i]["displayName"] + `:<img class="tooltipimage" src="/images/blue question mark icon - extra small.png" alt="Blue Tooltip Question Mark"> </span>
                                <span class="tooltiptext">This is the help text.</span>
                            </div>
                            <div>
                                <label for="` + navPanelContextSelectedControlBars[i]["name"] + `" class="switch">
                                    <input id="` + navPanelContextSelectedControlBars[i]["name"] + `" type="checkbox" onclick="navPanelControlBarCheckboxChanged(this)" checked>
                                    <span class="slider round"></span>
                                </label>
                            </div>
                        </div>`
            } else {
                innerHTMLString2 += `<div class="settingElement">
            <div class="labelElement">
                                <span>` + navPanelContextSelectedControlBars[i]["displayName"] + `:<img class="tooltipimage" src="/images/blue question mark icon - extra small.png" alt="Blue Tooltip Question Mark"> </span>
                                <span class="tooltiptext">This is the help text.</span>
                            </div>
                            <div>
                                <label for="` + navPanelContextSelectedControlBars[i]["name"] + `" class="switch">
                                    <input id="` + navPanelContextSelectedControlBars[i]["name"] + `" type="checkbox" onclick="navPanelControlBarCheckboxChanged(this)">
                                    <span class="slider round"></span>
                                </label>
                            </div>
                        </div>`
            }
        }
    }

    document.getElementById("NavPanel-ControlsBarsSection-Col0").innerHTML = innerHTMLString1;
    document.getElementById("NavPanel-ControlsBarsSection-Col1").innerHTML = innerHTMLString2;
    await disableContextFields("false");
}

async function navPanelContextFieldUpdated(field) {
    let navPanelContextSelected = NavigationPanelContexts.filter(context => context.id == document.getElementById("NavigationPanel-SelectList").value);
    switch (field.id) {
        case "NavPanel-ContextEnabled":
            navPanelContextSelected[0]["contextInfo"]["enabled"] = field.checked.toString();
            break;
    }
}

async function navPanelControlBarCheckboxChanged(field) {
    let navPanelContextSelected = NavigationPanelContexts.filter(context => context.id == document.getElementById("NavigationPanel-SelectList").value);
    let navPanelContextSelectedControlBars = navPanelContextSelected[0]["ControlBars"];
    let checkedControlBar = navPanelContextSelectedControlBars.filter(controlBar => controlBar.name == field.id);
    checkedControlBar[0]["enabled"] = field.checked.toString();
}

async function defaultContextChanged() {
    if (document.getElementById("Default-Context").value == "NavigationPanel0") {
        document.getElementById("Default-Control-Bar").innerHTML = "";
    } else {
        let navPanelContextSelected = NavigationPanelContexts.filter(context => context.id == document.getElementById("Default-Context").value);
        let navPanelContextSelectedControlBars = navPanelContextSelected[0]["ControlBars"];
        document.getElementById("Default-Control-Bar").innerHTML = "";
        let option = document.createElement("option");
        option.value = "";
        option.innerText = "";
        document.getElementById("Default-Control-Bar").append(option);
        for (let i = 0; i < navPanelContextSelectedControlBars.length; i++) {
            let option = document.createElement("option");
            option.value = navPanelContextSelectedControlBars[i]["name"];
            option.innerText = navPanelContextSelectedControlBars[i]["displayName"];
            document.getElementById("Default-Control-Bar").append(option);
        }
    }
}

async function disableContextFields(action) {
    document.getElementById("NavPanel-ContextEnabled").disabled = (action === 'true');
}


/********************************************************
*     Keyword Drop Down Type Ahead Character Minimum
********************************************************/
async function keywordTypeAheadMinimumCharactersChanged(selectList) {
    let result = keywordTypeAheadArray.filter(kwconf => kwconf.id == selectList.value);
    //console.log(result);
    document.getElementById("KeywordTypeahead-KeywordIDNumber").value = result[0].KeywordID;
    document.getElementById("KeywordTypeahead-TypeaheadCharacterCount").value = result[0].CharacterCount;

    await disableKeywordDropDownTypeAheadFields("false");
    await disableKeywordDropDownTypeAheadButtons("false");
}

async function disableKeywordDropDownTypeAheadButtons(action) {
    document.getElementById("KeywordTypeahead-DeleteButton").disabled = (action === 'true');
}

async function disableKeywordDropDownTypeAheadFields(action) {
    document.getElementById("KeywordTypeahead-KeywordIDNumber").disabled = (action === 'true');
    document.getElementById("KeywordTypeahead-TypeaheadCharacterCount").disabled = (action === 'true');
}

async function keywordDropDownTypeAheadFieldUpdated(field) {
    let result = keywordTypeAheadArray.filter(kwconf => kwconf.id == document.getElementById("KeywordTypeahead-SelectList").value);
    switch (field.id) {
        case "KeywordTypeahead-KeywordIDNumber":
            result[0].KeywordID = field.value;
            break;
        case "KeywordTypeahead-TypeaheadCharacterCount":
            result[0].CharacterCount = field.value;
            break;
    }

    document.getElementById("KeywordTypeahead-SelectList").querySelector('option[value="' + result[0].id + '"]').innerText = result[0].KeywordID + " (" + result[0].CharacterCount + ")";
    await checkIncompleteFieldValuesKeywordTypeAhead();
}

async function addKeywordDropDownTypeAhead() {
    configurationChanged = true;
    let idValue = "keywordTypeAhead" + keywordTypeAheadIdNumber;
    let kwConfigToAdd = {
        KeywordID: "",
        CharacterCount: "",
        id: idValue
    };

    let opt = document.createElement("option");
    opt.value = idValue;
    opt.innerText = " ()";
    opt.setAttribute("class", "keywordTypeAheadOption");
    opt.setAttribute("error-text-to-append", "");
    document.getElementById("KeywordTypeahead-SelectList").append(opt);
    keywordTypeAheadIdNumber++;
    keywordTypeAheadArray.push(kwConfigToAdd);
    document.getElementById("KeywordTypeahead-SelectList").value = idValue;
    await disableKeywordDropDownTypeAheadButtons("false");
    await resetKeywordDropDownTypeAheadFields();
    await disableKeywordDropDownTypeAheadFields("false");
    await checkIncompleteFieldValuesKeywordTypeAhead();
}

async function deleteKeywordDropDownTypeAhead() {
    let result = keywordTypeAheadArray.filter(kwconf => kwconf.id == document.getElementById("KeywordTypeahead-SelectList").value);
    keywordTypeAheadArray.splice(keywordTypeAheadArray.indexOf(result[0]), 1);
    document.getElementById("KeywordTypeahead-SelectList").querySelector('option[value="' + result[0].id + '"]').remove();
    await disableKeywordDropDownTypeAheadButtons("true");
    await resetKeywordDropDownTypeAheadFields();
    await disableKeywordDropDownTypeAheadFields("true");
    //console.log(keywordTypeAheadArray);
}

async function resetKeywordDropDownTypeAheadFields() {
    document.getElementById("KeywordTypeahead-KeywordIDNumber").value = "";
    document.getElementById("KeywordTypeahead-TypeaheadCharacterCount").value = "";
}

async function checkIncompleteFieldValuesKeywordTypeAhead() {
    if (document.getElementById("KeywordTypeahead-KeywordIDNumber").value == "" || document.getElementById("KeywordTypeahead-TypeaheadCharacterCount").value == "") {
        if (await checkDuplicateKeywordTypeAhead()) {
            document.getElementById("KeywordTypeahead-SelectList").options[document.getElementById("KeywordTypeahead-SelectList").selectedIndex].setAttribute("error-text-to-append", " (duplicate) (incomplete)");
            pushErrorToArray(keywordTypeaheadCharacterCountErrorArray);
        } else {
            document.getElementById("KeywordTypeahead-SelectList").options[document.getElementById("KeywordTypeahead-SelectList").selectedIndex].setAttribute("error-text-to-append", " (incomplete)");
            pushErrorToArray(keywordTypeaheadCharacterCountErrorArray);
        }
    } else {
        if (await checkDuplicateKeywordTypeAhead()) {
            document.getElementById("KeywordTypeahead-SelectList").options[document.getElementById("KeywordTypeahead-SelectList").selectedIndex].setAttribute("error-text-to-append", " (duplicate)");
            pushErrorToArray(keywordTypeaheadCharacterCountErrorArray);
        } else {
            document.getElementById("KeywordTypeahead-SelectList").options[document.getElementById("KeywordTypeahead-SelectList").selectedIndex].setAttribute("error-text-to-append", "");
            spliceErrorFromArray("keywordTypeaheadCharacterCount");
        }
    }
}

async function checkDuplicateKeywordTypeAhead() {
    let result = keywordTypeAheadArray.filter(kwconf => kwconf.KeywordID == document.getElementById("KeywordTypeahead-KeywordIDNumber").value);
    if (result.length > 1) {
        return true;
    } else {
        return false;
    }
}


/********************************************************
*                   General Methods
********************************************************/
async function autoLoginCheckAgainstOptimized(field) {
    switch (field.id) {
        case "Autologin":
            if (field.checked == false && document.getElementById("OptimizeForWindowsAuth-WebClient").checked == true) {
                document.getElementById("OptimizeForWindowsAuth-WebClient").checked = false;
            }
            break;
        case "DocPop-Auto-Login":
            if (field.checked == false && document.getElementById("OptimizeForWindowsAuth-DocPop").checked == true) {
                document.getElementById("OptimizeForWindowsAuth-DocPop").checked = false;
            }
            break;
        case "PdfPop-Auto-Login":
            if (field.checked == false && document.getElementById("OptimizeForWindowsAuth-PdfPop").checked == true) {
                document.getElementById("OptimizeForWindowsAuth-PdfPop").checked = false;
            }
            break;
        case "FormPop-Auto-Login":
            if (field.checked == false && document.getElementById("OptimizeForWindowsAuth-FormPop").checked == true) {
                document.getElementById("OptimizeForWindowsAuth-FormPop").checked = false;
            }
            break;
        case "FolderPop-Auto-Login":
            if (field.checked == false && document.getElementById("OptimizeForWindowsAuth-FolderPop").checked == true) {
                document.getElementById("OptimizeForWindowsAuth-FolderPop").checked = false;
            }
            break;
    }
}