DevExpress.viewPort($(".dx-viewport"));
DevExpress.utils.initMobileViewport({ allowZoom: true, allowPan: false, allowSelection: false });

// Force Device to be "Desktop"
// DevExpress.devices.current("Desktop");

$(document).on("deviceready", function () {
    navigator.splashscreen.hide();

    if (window.devextremeaddon) {
        window.devextremeaddon.setup();
    }
});