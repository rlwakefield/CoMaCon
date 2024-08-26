function activateSettingsButton(button) {
    switch (button.id) {
        case 'General':
            document.getElementById("settings-content-users").style.display = "none";
            break;
        case "Users":
            document.getElementById("settings-content-users").style.display = "block";
            break;
    }
    let settingsButtons = document.querySelectorAll('.settings-category');
    settingsButtons.forEach((settingsButton) => {
        settingsButton.classList.remove('active');
        settingsButton.style.fontWeight = 'normal';
        settingsButton.style.fontSize = 'initial';
    });
    button.classList.add('active');
    button.style.fontWeight = 'bold';
    button.style.fontSize = 'large';
}