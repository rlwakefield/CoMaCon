function optimizeForWindowsAuthChangedReportingViewer(field) {
    console.log(field);
    switch (field.id) {
        case "OptimizeForWindowsAuth-ReportingViewer":
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