let AgendaOnlineAgendaFields = [];
let AgendaOnlineIntegrations = [];
let AgendaOnlineIntegrationsIdNumber = 0;
let AgendaOnlineIntegrationsUnityFormsFieldsIdNumber = 0;
let AgendaOnlineIntegrationsMeetingTypesIdNumber = 0;
let AgendaOnlineIntegrationsAllFieldIds = ["Integration-Name", "Integration-URL", "Integration-Token", "Availability-From-Meeting-Start", "Form-Field-Name", "Form-Field-Name", "Form-Field-ID", "Meeting-Type-Name"];
let AgendaOnlineIntegrationsCoreFieldIds = ["Integration-Name", "Integration-URL", "Integration-Token", "Availability-From-Meeting-Start"];
let AgendaOnlineIntegrationsUnityFormsFieldIds = ["Form-Field-Name", "Form-Field-ID"];
let AgendaOnlineIntegrationsMeetingTypesFieldIds = ["Meeting-Type-Name"];
let AgendaOnlineIntegrationsRequiredMeetingTypes = ["meeting_name", "meeting_date", "item_id", "item_title"];
let AgendaOnlineIntegrationsNewIntegrationObject = { "meetingTypes": [], "agendaUnityFormFields": [{ "Name": "meeting_name", "FormFieldID": "", "id": "" }, { "Name": "meeting_date", "FormFieldID": "", "id": "" }, { "Name": "item_id", "FormFieldID": "", "id": "" }, { "Name": "item_title", "FormFieldID": "", "id": "" }], "Name": "[Integration Name]", "URL": "[URL from Unity forms config]", "Token": "[Token from Unity forms config]", "AvailabilityFromMeetingStart": "0", "id": "" };
let AgendaOnlineIntegrationsNewUnityFormFieldObject = { "Name": "[Name]", "FormFieldID": "[Field ID from Unity Form]", "id": "" };
let AgendaOnlineIntegrationsNewMeetingTypeObject = { "Name": "[Name]", "id": "" };

/********************************************************
 *              Agenda Form Field Functions
 ********************************************************/
function formFieldSelected(selection) {
    //console.log(AgendaOnlineAgendaFields);
    //console.log(selection.value);
    let foundObject = AgendaOnlineAgendaFields.find(item => item.Name === selection.value);
    let fieldName = document.getElementById("Form-Field-Name").value;
    let fieldId = document.getElementById("Form-Field-ID").value;

    if (foundObject != null) {
        if (fieldName != "" && fieldId != "") {
            updateAgendaOnlineFormFieldsFieldIDInArray(fieldName, fieldId)
                .then(() => {
                    document.getElementById("Form-Field-Name").value = foundObject.Name;
                    document.getElementById("Form-Field-ID").value = foundObject.FormFieldID;
                });
        } else {
            document.getElementById("Form-Field-Name").value = foundObject.Name;
            document.getElementById("Form-Field-ID").value = foundObject.FormFieldID;
        }
    }

    setAOAddButtonDisabled(false);
    setAODeleteButtonDisabled(false);
}

function updateAgendaOnlineFormFieldsFieldIDInArray(fieldName, fieldId) {
    let foundObject = AgendaOnlineAgendaFields.find(item => item.name === fieldName);
    if (foundObject != null) {
        if (foundObject.FormFieldID != fieldId) {
            foundObject.FormFieldID = fieldId;
        } else {
            //Currently just disposing the values input. Might need to add a warning that there are values not saved.
        }
    }

    return new Promise((resolve) => {
        // Simulate an asynchronous operation
        setTimeout(function () {
            resolve();
        }, 50);
    });
}

function setAOAddButtonDisabled(value) {
    document.getElementById("FormFieldSelectList-AddButton").disabled = value;
}

function setAODeleteButtonDisabled(value) {
    document.getElementById("FormFieldSelectList-DeleteButton").disabled = value;
}

function addAgendaOnlineFormField() {
    configurationChanged = true;
    let fieldName = document.getElementById("Form-Field-Name").value;
    let fieldId = document.getElementById("Form-Field-ID").value;
    let arrayToInsert = { "FormFieldName": "", "FormFieldId": "" };
    let selectListFieldsDropDown = document.getElementById("Form-Field-Select-List");
    arrayToInsert.FormFieldName = fieldName;
    arrayToInsert.FormFieldId = fieldId;
    AgendaOnlineAgendaFields.push(arrayToInsert);

    let newOption = document.createElement("option");
    newOption.value = fieldName;
    newOption.text = fieldName;
    selectListFieldsDropDown.add(newOption);
    selectListFieldsDropDown.selectedIndex = selectListFieldsDropDown.length - 1;
    setAOAddButtonDisabled(false);
    setAODeleteButtonDisabled(false);
}

function deleteAgendaOnlineFormField() {
    let selectedFieldNameValue = document.getElementById("Form-Field-Select-List").value;
    let selectListFieldsDropDown = document.getElementById("Form-Field-Select-List");
    for (let i = 0; i < AgendaOnlineAgendaFields.length; i++) {
        if (AgendaOnlineAgendaFields[i].name == selectedFieldNameValue) {
            AgendaOnlineAgendaFields.splice(i, 1);
            let selectedIndex = selectListFieldsDropDown.selectedIndex;
            selectListFieldsDropDown.remove(selectedIndex);
            if (selectListFieldsDropDown.length == 0) {
                setAOAddButtonDisabled(true);
                setAODeleteButtonDisabled(true);
            } else {
                if (selectedIndex == 0) {
                    selectListFieldsDropDown.selectedIndex = selectedIndex + 1;
                } else {
                    selectListFieldsDropDown.selectedIndex = selectedIndex - 1;
                }
            }
        }
    }
}

async function validateNoDuplicateFieldNames() {
    let currentFieldNameValue = document.getElementById("Form-Field-Name").value;
    let foundObject = AgendaOnlineAgendaFields.find(item => item.FormFieldName === currentFieldNameValue);
    if (foundObject != undefined) {
        //Disable the add button.
        setAddButtonDisabled(true);
        //validates that the error SVG isn't already there. If it isn't, it adds it. If it is, then it does nothing.
        if (document.getElementById("Form-Field-Name").parentNode.firstElementChild.tagName != "svg") {
            // Create a temporary container element (a <div> in this case)
            var container = document.createElement('div');
            // Set the HTML content of the container to your SVG string
            container.innerHTML = errorOctagonSVG;
            document.getElementById("Form-Field-Name").parentNode.insertBefore(container.firstChild, document.getElementById("Form-Field-Name").parentNode.firstChild);
        }
        pushErrorToArray(await findErrorArrayToSet("agendaOnlineDuplicateFormFieldNames"));
    } else {
        //Check if the error SVG is the first child. If yes, then remove it.
        if (document.getElementById("Form-Field-Name").parentNode.firstElementChild.tagName === "svg") {
            //let firstChild = document.getElementById("Form-Field-Name").parentNode.firstChild;
            //let parentNode = document.getElementById("Form-Field-Name").parentNode;
            document.getElementById("Form-Field-Name").parentNode.removeChild(document.getElementById("Form-Field-Name").parentNode.firstChild);
        }
        validateRequiredFieldsInputForAdd();
        spliceErrorFromArray("agendaOnlineDuplicateFormFieldNames");
    }
}

function validateRequiredAgendaFieldsInputForAdd() {
    if ((document.getElementById("Form-Field-Name").value != "")
        && (document.getElementById("Form-Field-Name").value != "")
        && (document.getElementById("Form-Field-Name").parentNode.firstElementChild.tagName != "svg")) {
        setAddButtonDisabled(false);
    } else {
        setAddButtonDisabled(true);
    }
}


/********************************************************
 *         Agenda Online Integrations Functions
 ********************************************************/
function integrationSelected(selection) {
    let objectFound = AgendaOnlineIntegrations.find(item => item.id === selection.value);
    setIntegrationFields(objectFound);
}

async function setIntegrationFields(integration) {
    await resetAllIntegrationFields();
    document.getElementById("Integration-Name").value = integration.Name;
    document.getElementById("Integration-URL").value = integration.URL;
    document.getElementById("Integration-Token").value = integration.Token;
    document.getElementById("Availability-From-Meeting-Start").value = integration.AvailabilityFromMeetingStart;
    await setAgendaUnityFormFieldsSelectList(integration.agendaUnityFormFields);
    await setMeetingTypesSelectList(integration.meetingTypes);
    await disableAllAgendaOnlineIntegrationsFields(AgendaOnlineIntegrationsCoreFieldIds, false);
    await setAgendaOnlineIntegrationsButtons(["PublicCommentIntegrations-CopyButton", "PublicCommentIntegrations-DeleteButton"], false);
    await setAgendaOnlineIntegrationsUnityFormsFieldsButtons(["FormFieldSelectList-AddButton"], false);
    await setAgendaOnlineIntegrationsMeetingTypesButtons(["Meeting-Type-Name-Select-List-AddButton"], false);
}

async function setAgendaUnityFormFieldsSelectList(AgendaOnlineAgendaFields) {
    //console.log(AgendaOnlineAgendaFields);
    let selectListFieldsDropDown = document.getElementById("Form-Field-Select-List");
    for (let i = 0; i < AgendaOnlineAgendaFields.length; i++) {
        let newFieldDropDownOption = document.createElement("option");
        newFieldDropDownOption.text = AgendaOnlineAgendaFields[i]["Name"];
        if (AgendaOnlineAgendaFields[i].id == "") {
            newFieldDropDownOption.value = "AgendaOnlineIntegrationsUnityFormsFields" + AgendaOnlineIntegrationsUnityFormsFieldsIdNumber
            AgendaOnlineAgendaFields[i].id = "AgendaOnlineIntegrationsUnityFormsFields" + AgendaOnlineIntegrationsUnityFormsFieldsIdNumber;
        } else {
            newFieldDropDownOption.value = AgendaOnlineAgendaFields[i].id;
        }
        newFieldDropDownOption.classList.add("unityFormFieldOption");
        newFieldDropDownOption.setAttributeNode(document.createAttribute("error-text-to-append"));
        AgendaOnlineIntegrationsUnityFormsFieldsIdNumber++;
        selectListFieldsDropDown.append(newFieldDropDownOption);
    }
}

async function setMeetingTypesSelectList(meetingTypes) {
    //console.log(meetingTypes);
    let selectListMeetingTypesDropDown = document.getElementById("Meeting-Type-Name-Select-List");
    for (let i = 0; i < meetingTypes.length; i++) {
        let newFieldDropDownOption = document.createElement("option");
        newFieldDropDownOption.text = meetingTypes[i]["Name"];
        if (meetingTypes[i].id == "") {
            newFieldDropDownOption.value = "AgendaOnlineIntegrationsMeetingTypes" + AgendaOnlineIntegrationsMeetingTypesIdNumber;
            meetingTypes[i].id = "AgendaOnlineIntegrationsMeetingTypes" + AgendaOnlineIntegrationsMeetingTypesIdNumber;
        } else {
            newFieldDropDownOption.value = meetingTypes[i].id;
        }
        newFieldDropDownOption.classList.add("meetingTypeOption");
        newFieldDropDownOption.setAttributeNode(document.createAttribute("error-text-to-append"));
        AgendaOnlineIntegrationsMeetingTypesIdNumber++;
        selectListMeetingTypesDropDown.append(newFieldDropDownOption);
    }
}

async function setAgendaOnlineIntegrationsButtons(buttonIdArrays, elementStatus) {
    buttonIdArrays.forEach(element => {
        document.getElementById(element).disabled = elementStatus;
    });
}

async function setAgendaOnlineIntegrationsUnityFormsFieldsButtons(buttonIdArrays, elementStatus) {
    buttonIdArrays.forEach(element => {
        document.getElementById(element).disabled = elementStatus;
    });
}

async function setAgendaOnlineIntegrationsMeetingTypesButtons(buttonIdArrays, elementStatus) {
    buttonIdArrays.forEach(element => {
        document.getElementById(element).disabled = elementStatus;
    });
}

async function disableAllAgendaOnlineIntegrationsFields(arrayOfFields, status) {
    arrayOfFields.forEach(element => {
        document.getElementById(element).disabled = status;
    });
}

function unityFormFieldSelected(fieldSelected) {
    let objectFound = AgendaOnlineIntegrations.find(item => item.id === document.getElementById("PublicCommentIntegrations-SelectList").value);
    let formFieldObject = (objectFound.agendaUnityFormFields).find(item => item.id === fieldSelected.value);
    document.getElementById("Form-Field-Name").value = formFieldObject.Name;
    document.getElementById("Form-Field-ID").value = formFieldObject.FormFieldID;
    
    if (AgendaOnlineIntegrationsRequiredMeetingTypes.includes(formFieldObject.Name)) {
        disableAllAgendaOnlineIntegrationsFields(["Form-Field-ID"], false);
        disableAllAgendaOnlineIntegrationsFields(["Form-Field-Name"], true);
        setAgendaOnlineIntegrationsUnityFormsFieldsButtons(["FormFieldSelectList-DeleteButton"], true);
    } else {
        disableAllAgendaOnlineIntegrationsFields(AgendaOnlineIntegrationsUnityFormsFieldIds, false);
        setAgendaOnlineIntegrationsUnityFormsFieldsButtons(["FormFieldSelectList-DeleteButton"], false);
    }
}

function meetingtypeSelected(meetingTypeSelected) {
    let objectFound = AgendaOnlineIntegrations.find(item => item.id === document.getElementById("PublicCommentIntegrations-SelectList").value);
    let meetingTypeObject = (objectFound.meetingTypes).find(item => item.id === meetingTypeSelected.value);
    document.getElementById("Meeting-Type-Name").value = meetingTypeObject.Name;
    disableAllAgendaOnlineIntegrationsFields(AgendaOnlineIntegrationsMeetingTypesFieldIds, false);
}

async function addNewIntegration() {
    let newIntegrationObject = JSON.parse(JSON.stringify(AgendaOnlineIntegrationsNewIntegrationObject));
    newIntegrationObject.id = "AgendaOnlineIntegration" + AgendaOnlineIntegrationsIdNumber;
    AgendaOnlineIntegrationsIdNumber++;
    AgendaOnlineIntegrations.push(newIntegrationObject);
    let newIntegrationOption = document.createElement("option");
    newIntegrationOption.value = newIntegrationObject.id;
    newIntegrationOption.text = newIntegrationObject.Name;
    document.getElementById("PublicCommentIntegrations-SelectList").append(newIntegrationOption);
    document.getElementById("PublicCommentIntegrations-SelectList").selectedIndex = document.getElementById("PublicCommentIntegrations-SelectList").length - 1;
    await resetAllIntegrationFields();
    setIntegrationFields(newIntegrationObject);
}

function deleteIntegration() {
    let selectedIntegrationId = document.getElementById("PublicCommentIntegrations-SelectList").value;
    for (let i = 0; i < AgendaOnlineIntegrations.length; i++) {
        if (AgendaOnlineIntegrations[i].id == selectedIntegrationId) {
            AgendaOnlineIntegrations.splice(i, 1);
        }
    }
    let selectListDropDown = document.getElementById("PublicCommentIntegrations-SelectList");
    selectListDropDown.remove(selectListDropDown.selectedIndex);
    resetAllIntegrationFields();
    disableAllAgendaOnlineIntegrationsFields(AgendaOnlineIntegrationsAllFieldIds, true);
    setAgendaOnlineIntegrationsButtons(["PublicCommentIntegrations-CopyButton", "PublicCommentIntegrations-DeleteButton"], true);
    setAgendaOnlineIntegrationsUnityFormsFieldsButtons(["FormFieldSelectList-AddButton"], true);
    setAgendaOnlineIntegrationsMeetingTypesButtons(["Meeting-Type-Name-Select-List-AddButton"], true);
}

function copyIntegration() {
    let currentlySelectedObject = JSON.parse(JSON.stringify(AgendaOnlineIntegrations.find(item => item.id === document.getElementById("PublicCommentIntegrations-SelectList").value)));
    currentlySelectedObject.id = "AgendaOnlineIntegrations" + AgendaOnlineIntegrationsIdNumber;
    AgendaOnlineIntegrationsIdNumber++;
    AgendaOnlineIntegrations.push(currentlySelectedObject);
    let newIntegrationOption = document.createElement("option");
    newIntegrationOption.value = currentlySelectedObject.id;
    newIntegrationOption.text = currentlySelectedObject.Name;
    document.getElementById("PublicCommentIntegrations-SelectList").append(newIntegrationOption);
    document.getElementById("PublicCommentIntegrations-SelectList").selectedIndex = document.getElementById("PublicCommentIntegrations-SelectList").length - 1;
}

async function resetAllIntegrationFields() {
    AgendaOnlineIntegrationsAllFieldIds.forEach(element => {
        document.getElementById(element).value = "";
    });
    document.getElementById("Form-Field-Select-List").innerHTML = "";
    document.getElementById("Meeting-Type-Name-Select-List").innerHTML = "";
}

async function resetUnityFormFields() {
    AgendaOnlineIntegrationsUnityFormsFieldIds.forEach(element => {
        document.getElementById(element).value = "";
    });
}

async function resetMeetingTypesFields() {
    AgendaOnlineIntegrationsMeetingTypesFieldIds.forEach(element => {
        document.getElementById(element).value = "";
    });
}

function addNewUnityFormField() {
    let currentlySelectedObject = AgendaOnlineIntegrations.find(item => item.id === document.getElementById("PublicCommentIntegrations-SelectList").value);
    let newUnityFormFieldObject = JSON.parse(JSON.stringify(AgendaOnlineIntegrationsNewUnityFormFieldObject));
    newUnityFormFieldObject.id = "AgendaOnlineIntegrationsUnityFormsFields" + AgendaOnlineIntegrationsUnityFormsFieldsIdNumber;
    AgendaOnlineIntegrationsUnityFormsFieldsIdNumber++;
    let selectListDropDown = document.getElementById("Form-Field-Select-List");
    document.getElementById("Form-Field-Name").value = newUnityFormFieldObject.Name;
    document.getElementById("Form-Field-ID").value = newUnityFormFieldObject.FormFieldID;
    let newOption = document.createElement("option");
    newOption.value = newUnityFormFieldObject.id;
    newOption.classList.add("unityFormFieldOption");
    newOption.setAttributeNode(document.createAttribute("error-text-to-append"));
    newOption.innerText = newUnityFormFieldObject.Name;
    selectListDropDown.append(newOption);
    disableAllAgendaOnlineIntegrationsFields(AgendaOnlineIntegrationsUnityFormsFieldIds, false);
    currentlySelectedObject.agendaUnityFormFields.push(newUnityFormFieldObject);
    document.getElementById("Form-Field-Select-List").selectedIndex = document.getElementById("Form-Field-Select-List").length - 1;
    setAgendaOnlineIntegrationsUnityFormsFieldsButtons(["FormFieldSelectList-DeleteButton"], false);
}

function deleteUnityFormField() {
    resetUnityFormFields();
    setAgendaOnlineIntegrationsUnityFormsFieldsButtons(["FormFieldSelectList-DeleteButton"], true);
    disableAllAgendaOnlineIntegrationsFields(AgendaOnlineIntegrationsUnityFormsFieldIds, true);
    let currentlySelectedObject = AgendaOnlineIntegrations.find(item => item.id === document.getElementById("PublicCommentIntegrations-SelectList").value);
    let currentUnityFormFieldId = document.getElementById("Form-Field-Select-List").value;
    for (let i = 0; i < currentlySelectedObject.agendaUnityFormFields.length; i++) {
        if (currentlySelectedObject.agendaUnityFormFields[i].id == currentUnityFormFieldId) {
            currentlySelectedObject.agendaUnityFormFields.splice(i, 1);
        }
    }
    //Delete the current selected option from the select list.
    let selectListDropDown = document.getElementById("Form-Field-Select-List");
    selectListDropDown.remove(selectListDropDown.selectedIndex);
}

function addNewMeetingType() {
    let currentlySelectedObject = AgendaOnlineIntegrations.find(item => item.id === document.getElementById("PublicCommentIntegrations-SelectList").value);
    let newMeetingTypeObject = JSON.parse(JSON.stringify(AgendaOnlineIntegrationsNewMeetingTypeObject));
    newMeetingTypeObject.id = "AgendaOnlineIntegrationsMeetingTypes" + AgendaOnlineIntegrationsMeetingTypesIdNumber;
    AgendaOnlineIntegrationsMeetingTypesIdNumber++;
    let selectListDropDown = document.getElementById("Meeting-Type-Name-Select-List");
    document.getElementById("Meeting-Type-Name").value = newMeetingTypeObject.Name;
    let newOption = document.createElement("option");
    newOption.value = newMeetingTypeObject.id;
    newOption.innerText = newMeetingTypeObject.Name;
    newOption.classList.add("meetingTypeOption");
    newOption.setAttributeNode(document.createAttribute("error-text-to-append"));
    selectListDropDown.append(newOption);
    disableAllAgendaOnlineIntegrationsFields(AgendaOnlineIntegrationsMeetingTypesFieldIds, false);
    currentlySelectedObject.meetingTypes.push(newMeetingTypeObject);
    document.getElementById("Meeting-Type-Name-Select-List").selectedIndex = document.getElementById("Meeting-Type-Name-Select-List").length - 1;
    setAgendaOnlineIntegrationsMeetingTypesButtons(["Meeting-Type-Name-Select-List-DeleteButton"], false);
    //checkForDuplicateMeetingTypes(currentlySelectedObject, newMeetingTypeObject, newMeetingTypeObject.Name);
    checkForDuplicateMeetingTypes(currentlySelectedObject)
}

function deleteMeetingType() {
    resetMeetingTypesFields();
    setAgendaOnlineIntegrationsMeetingTypesButtons(["Meeting-Type-Name-Select-List-DeleteButton"], true);
    disableAllAgendaOnlineIntegrationsFields(AgendaOnlineIntegrationsMeetingTypesFieldIds, true);
    let currentlySelectedObject = AgendaOnlineIntegrations.find(item => item.id === document.getElementById("PublicCommentIntegrations-SelectList").value);
    let currentMeetingTypeId = document.getElementById("Meeting-Type-Name-Select-List").value;
    for (let i = 0; i < currentlySelectedObject.meetingTypes.length; i++) {
        if (currentlySelectedObject.meetingTypes[i].id == currentMeetingTypeId) {
            currentlySelectedObject.meetingTypes.splice(i, 1);
            checkForDuplicateMeetingTypes(currentlySelectedObject, currentlySelectedObject.meetingTypes[i], "");
        }
    }
    //Delete the current selected option from the select list.
    let selectListDropDown = document.getElementById("Meeting-Type-Name-Select-List");
    selectListDropDown.remove(selectListDropDown.selectedIndex);
    checkForDuplicateMeetingTypes(currentlySelectedObject);
}

function integrationfieldUpdated(field) {
    let currentlySelectedObject = AgendaOnlineIntegrations.find(item => item.id === document.getElementById("PublicCommentIntegrations-SelectList").value);
    switch (field.id) {
        case "Integration-Name":
            //Update the name of the integration in the object.
            currentlySelectedObject.Name = field.value;
            //Update the name of the integration in the select list.
            document.getElementById("PublicCommentIntegrations-SelectList").options[document.getElementById("PublicCommentIntegrations-SelectList").selectedIndex].text = field.value;
            break;
        case "Integration-URL":
            //Update the URL of the integration in the object.
            currentlySelectedObject.URL = field.value;
            break;
        case "Integration-Token":
            //Update the Token of the integration in the object.
            currentlySelectedObject.Token = field.value;
            break;
        case "Availability-From-Meeting-Start":
            //Update the Availability From Meeting Start of the integration in the object.
            currentlySelectedObject.AvailabilityFromMeetingStart = field.value;
            break;
        case "Form-Field-Name":
            //Get the currently selected object from the Unity Form Fields array of the currently selected object.
            let unityFormFieldObject = (currentlySelectedObject.agendaUnityFormFields).find(item => item.id === document.getElementById("Form-Field-Select-List").value);
            //Update the name of the Unity Form Field in the object.
            unityFormFieldObject.Name = field.value;
            //Update the name of the Unity Form Field in the select list.
            document.getElementById("Form-Field-Select-List").options[document.getElementById("Form-Field-Select-List").selectedIndex].text = field.value;
            break;
        case "Form-Field-ID":
            //Get the currently selected object from the Unity Form Fields array of the currently selected object.
            let unityFormFieldObjectID = (currentlySelectedObject.agendaUnityFormFields).find(item => item.id === document.getElementById("Form-Field-Select-List").value);
            //Update the ID of the Unity Form Field in the object.
            unityFormFieldObjectID.FormFieldID = field.value;
            break;
        case "Meeting-Type-Name":
            //Get the currently selected object from the Meeting Types array of the currently selected object.
            let meetingTypeObject = (currentlySelectedObject.meetingTypes).find(item => item.id === document.getElementById("Meeting-Type-Name-Select-List").value);
            //Update the name of the Meeting Type in the object.
            meetingTypeObject.Name = field.value;
            //Update the name of the Meeting Type in the select list.
            document.getElementById("Meeting-Type-Name-Select-List").options[document.getElementById("Meeting-Type-Name-Select-List").selectedIndex].text = field.value;
            //checkForDuplicateMeetingTypes(currentlySelectedObject, meetingTypeObject, field.value);
            checkForDuplicateMeetingTypes(currentlySelectedObject);
            break;
    }
    console.log(AgendaOnlineIntegrations);
}

async function checkForDuplicateMeetingTypes(currentlySelectedIntegration) {
    let groupedByName = await groupByNameKey(currentlySelectedIntegration.meetingTypes,"Name");
    //console.log(groupedByName);

    let selectList = document.getElementById("Meeting-Type-Name-Select-List");
    Object.keys(groupedByName).forEach(key => {
        if (groupedByName[key].length > 1) {
            //Loop over the array and add the text " (Duplicate)" to the error-text-to-append attribute.
            groupedByName[key].forEach(item => {
                //Loop over the options in the select list.
                for (let i = 0; i < selectList.length; i++) {
                    //If the option is the one that is duplicated, then add the class "duplicateMeetingTypeName" to it.
                    if (selectList.options[i].value === item.id) {
                        selectList.options[i].classList.add("duplicateMeetingTypeName");
                        //Add the text " (Duplicate)" to the error-text-to-append attribute.
                        selectList.options[i].setAttribute("error-text-to-append", " (Duplicate)");
                    }
                }
            });
        } else {
            groupedByName[key].forEach(item => {
                //Loop over the options in the select list.
                for (let i = 0; i < selectList.length; i++) {
                    //Once the option is found, remove the class "duplicateMeetingTypeName" from it.
                    if (selectList.options[i].value === item.id) {
                        selectList.options[i].classList.remove("duplicateMeetingTypeName");
                        //Replace the text " (Duplicate)" with "" in error-text-to-append attribute.
                        let errorTextToReplace = selectList.options[i].attributes["error-text-to-append"].value;
                        //Replace the string " (Duplicate)" with "" on the errorTextToReplace variable.
                        selectList.options[i].attributes["error-text-to-append"].value = errorTextToReplace.replace(' (Duplicate)', '');
                        //selectList.options[i].attributes["error-text-to-append"].value.replace(' (Duplicate)', '');
                    }
                }
            });
        }
    });

    if (document.getElementsByClassName("duplicateMeetingTypeName").length > 0) {
        pushErrorToArray(await findErrorArrayToSet("agendaOnlineDuplicateMeetingTypeNames"));
    } else {
        spliceErrorFromArray("agendaOnlineDuplicateMeetingTypeNames");
    }
}