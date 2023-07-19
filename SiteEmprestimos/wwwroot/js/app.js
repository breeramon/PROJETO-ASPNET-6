document.addEventListener('DOMContentLoaded', function () {
    var modeSwitch = document.getElementById('mode-switch');
    modeSwitch.addEventListener('change', function () {
        document.body.classList.toggle('dark-mode');
    });
});