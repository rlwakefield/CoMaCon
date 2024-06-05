/********************************************************
 *                 General Functions
 ********************************************************/
async function requiredKeywordRowSelected(cell) {
    let currentSelectedRow = document.getElementsByClassName("requiredKeywordSelected");
    if (currentSelectedRow.length > 0) {
        await saveRequiredKeywordsData();
        currentSelectedRow[0].classList.remove("requiredKeywordSelected");
        cell.srcElement.parentElement.classList.add("requiredKeywordSelected");
    } else {
        if (document.getElementById("Query-ID").value != "" && document.getElementById("Keyword-ID").value != "") {
            await saveRequiredKeywordsData();
        }
        cell.srcElement.parentElement.classList.add("requiredKeywordSelected");
    }
    loadRequiredKeywordsData();
}

async function loadRequiredKeywordsData() {
    let currentSelectedRow = document.getElementsByClassName("requiredKeywordSelected");
    let tdElements = currentSelectedRow[0].getElementsByTagName("td");
    let foundObject = "";

    if (tdElements[0].id == "tdQueryID") {
        foundObject = requiredKeywordsArray.filter(element => (element.QueryID === tdElements[0].innerText) && (element.KeywordID === tdElements[1].innerText));
    } else {
        foundObject = requiredKeywordsArray.filter(element => (element.QueryID === tdElements[1].innerText) && (element.KeywordID === tdElements[0].innerText));
    }

    document.getElementById("Query-ID").value = foundObject[0].QueryID;
    document.getElementById("Keyword-ID").value = foundObject[0].KeywordID;
    await checkToEnableRequiredKeywordsSaveButton();
}

async function saveRequiredKeywordsData(event) {
    let currentSelectedRow = document.getElementsByClassName("requiredKeywordSelected");
    if (currentSelectedRow.length > 0) {
        let tdElements = currentSelectedRow[0].getElementsByTagName("td");
        let foundObject = "";

        if (tdElements[0].id == "tdQueryID") {
            foundObject = requiredKeywordsArray.filter(element => (element.QueryID === tdElements[0].innerText) && (element.KeywordID === tdElements[1].innerText));
        } else {
            foundObject = requiredKeywordsArray.filter(element => (element.QueryID === tdElements[1].innerText) && (element.KeywordID === tdElements[0].innerText));
        }

        foundObject[0].QueryID = document.getElementById("Query-ID").value;
        foundObject[0].KeywordID = document.getElementById("Keyword-ID").value;
        await updateRequiredKeywordsTableDataRow();
        return Promise.resolve();
    } else {
        let tbody = document.getElementById("Required-Keywords-Table-Tbody");
        let tr = document.createElement('tr');
        if (event.type === "click") {
            tr.setAttribute("class", "requiredKeywordSelected");
        }
        let tdQueryID = document.createElement('td');
        tdQueryID.innerText = document.getElementById("Query-ID").value;
        tdQueryID.setAttribute("id", "tdQueryID");
        tdQueryID.addEventListener("click", requiredKeywordRowSelected);
        let tdKeywordID = document.createElement('td');
        tdKeywordID.innerText = document.getElementById("Keyword-ID").value;
        tdKeywordID.setAttribute("id", "tdKeywordID");
        tdKeywordID.addEventListener("click", requiredKeywordRowSelected);
        tr.appendChild(tdQueryID);
        tr.appendChild(tdKeywordID);
        tbody.appendChild(tr);

        requiredKeywordsArray.push({ "QueryID": document.getElementById("Query-ID").value, "KeywordID": document.getElementById("Keyword-ID").value });
        return Promise.resolve();
    }
}

async function finalSaveRequiredKeywordsData() {
    let currentSelectedRow = document.getElementsByClassName("requiredKeywordSelected");
    if (currentSelectedRow.length > 0) {
        let tdElements = currentSelectedRow[0].getElementsByTagName("td");
        let foundObject = "";

        if (tdElements[0].id == "tdQueryID") {
            foundObject = requiredKeywordsArray.filter(element => (element.QueryID === tdElements[0].innerText) && (element.KeywordID === tdElements[1].innerText));
        } else {
            foundObject = requiredKeywordsArray.filter(element => (element.QueryID === tdElements[1].innerText) && (element.KeywordID === tdElements[0].innerText));
        }

        foundObject[0].QueryID = document.getElementById("Query-ID").value;
        foundObject[0].KeywordID = document.getElementById("Keyword-ID").value;
        await updateRequiredKeywordsTableDataRow();
        return Promise.resolve();
    }
}

function resetRequiredKeywordsFields() {
    document.getElementById("Query-ID").value = "";
    document.getElementById("Keyword-ID").value = "";
}

function clearRequiredKeywordsSelectClass() {
    let currentSelectedRow = document.getElementsByClassName("requiredKeywordSelected");
    if (currentSelectedRow.length > 0) {
        currentSelectedRow[0].classList.remove("requiredKeywordSelected");
    }
}

async function newRequiredKeywordsData() {
    configurationChanged = true;
    resetRequiredKeywordsFields();
    clearRequiredKeywordsSelectClass();
    await checkToEnableRequiredKeywordsSaveButton();
}

function deleteRequiredKeywordsData() {
    let currentSelectedRow = document.getElementsByClassName("requiredKeywordSelected");
    document.getElementById("Required-Keywords-Table-Tbody").removeChild(currentSelectedRow[0]);
    resetRequiredKeywordsFields();
    checkToEnableRequiredKeywordsSaveButton();
}

async function updateRequiredKeywordsTableDataRow() {
    let currentSelectedRow = document.getElementsByClassName("requiredKeywordSelected");
    let tdElements = currentSelectedRow[0].getElementsByTagName("td");
    if (tdElements[0].id == "tdQueryID") {
        tdElements[0].innerText = document.getElementById("Query-ID").value;
        tdElements[1].innerText = document.getElementById("Keyword-ID").value;
    } else {
        tdElements[1].innerText = document.getElementById("Query-ID").value;
        tdElements[0].innerText = document.getElementById("Keyword-ID").value;
    }
    return Promise.resolve();
}

async function checkToEnableRequiredKeywordsSaveButton() {
    if (document.getElementById("Query-ID").value != "" && document.getElementById("Keyword-ID").value != "") {
        document.getElementById("RequiredKeywords-SaveButton").disabled = false;
    } else {
        document.getElementById("RequiredKeywords-SaveButton").disabled = true;
    }
    return Promise.resolve();
}