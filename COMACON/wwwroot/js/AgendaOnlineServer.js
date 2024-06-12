let AgendaOnlineAgendaFields = [];
let AgendaOnlineIntegrations = [];
let AgendaOnlineIntegrationsIdNumber = 0;
let AgendaOnlineIntegrationsAllFieldIds = ["Integration-Name", "Integration-URL", "Integration-Token", "Availability-From-Meeting-Start", "Form-Field-Name", "Form-Field-Name", "Form-Field-ID", "Meeting-Type-Name"];
let AgendaOnlineIntegrationsCoreFieldIds = ["Integration-Name", "Integration-URL", "Integration-Token", "Availability-From-Meeting-Start"];
let AgendaOnlineIntegrationsUnityFormsFieldIds = ["Form-Field-Name", "Form-Field-ID"];
let AgendaOnlineIntegrationsMeetingTypesFieldIds = ["Meeting-Type-Name"];

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

function validateNoDuplicateFieldNames() {
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
        pushErrorToArray(agendaOnlineDuplicateFormFieldNamesArray);
    } else {
        //Check if the error SVG is the first child. If yes, then remove it.
        if (document.getElementById("Form-Field-Name").parentNode.firstElementChild.tagName === "svg") {
            let firstChild = document.getElementById("Form-Field-Name").parentNode.firstChild;
            let parentNode = document.getElementById("Form-Field-Name").parentNode;
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
    console.log(objectFound);

    setIntegrationFields(objectFound);
    setAgendaOnlineIntegrationsButtons("PublicCommentIntegrations-CopyButton", true);
    setAgendaOnlineIntegrationsButtons("PublicCommentIntegrations-DeleteButton", true);
}

async function setIntegrationFields(integration) {
    document.getElementById("Integration-Name").value = integration.Name;
    document.getElementById("Integration-URL").value = integration.URL;
    document.getElementById("Integration-Token").value = integration.Token;
    document.getElementById("Availability-From-Meeting-Start").value = integration.AvailabilityFromMeetingStart;
    await setAgendaUnityFormFieldsSelectList(integration.agendaUnityFormFields);
    await setMeetingTypesSelectList(integration.meetingTypes);
    await disableAllAgendaOnlineIntegrationsFields(AgendaOnlineIntegrationsCoreFieldIds,false);
}

async function setAgendaUnityFormFieldsSelectList(AgendaOnlineAgendaFields) {
    console.log(AgendaOnlineAgendaFields);
    let selectListFieldsDropDown = document.getElementById("Form-Field-Select-List");
    for (let i = 0; i < AgendaOnlineAgendaFields.length; i++) {
        let newFieldDropDownOption = document.createElement("option");
        newFieldDropDownOption.value = AgendaOnlineAgendaFields[i]["Name"];
        newFieldDropDownOption.text = AgendaOnlineAgendaFields[i]["Name"];
        selectListFieldsDropDown.append(newFieldDropDownOption);
    }
}

async function setMeetingTypesSelectList(meetingTypes) {
    let meetingTypeNames = "";
    for (let i = 0; i < meetingTypes.length; i++) {
        if (i == 0) {
            meetingTypeNames += meetingTypes[i]["Name"];
        } else {
            meetingTypeNames += "," + meetingTypes[i]["Name"];
        }
    }
    document.getElementById("Meeting-Type-Name").value = meetingTypeNames;
}

async function setAgendaOnlineIntegrationsButtons(buttonId, elementStatus) {
    document.getElementById(buttonId).disabled = elementStatus;
}

async function disableAllAgendaOnlineIntegrationsFields(arrayOfFields, status) {
    arrayOfFields.forEach(element => {
        document.getElementById(element).disabled = status;
    });
}