window.WebClientNextechCodeAssessment = window.WebClientNextechCodeAssessment || {};

$(function() {
    // Uncomment the line below to disable platform-specific look and feel and to use the Generic theme for all devices
    // DevExpress.devices.current({ platform: "generic" });
    // To customize the Generic theme, use the DevExtreme Theme Builder (http://js.devexpress.com/ThemeBuilder)
    // For details on how to use themes and the Theme Builder, refer to the http://js.devexpress.com/Documentation/Guide/#themes article

    var isDeviceReady = false,
        isViewShown = false;

    function hideSplashScreen() {
        if(isDeviceReady && isViewShown) {
            navigator.splashscreen.hide();
        }
    }

    $(document).on("deviceready", function() {
        isDeviceReady = true;
        hideSplashScreen();
        $(document).on("backbutton", function() {
            DevExpress.processHardwareBackButton();
        });
    });

    function onViewShown() {
        isViewShown = true;
        hideSplashScreen();
        WebClientNextechCodeAssessment.app.off("viewShown", onViewShown);
    }

    function onNavigatingBack(e) {
        if(e.isHardwareButton && !WebClientNextechCodeAssessment.app.canBack()) {
            e.cancel = true;
            exitApp();
        }
    }

    function exitApp() {
        switch(DevExpress.devices.real().platform) {
            case "android":
                navigator.app.exitApp();
                break;
            case "win":
                MSApp.terminateApp('');
                break;
        }
    }

    WebClientNextechCodeAssessment.app = new DevExpress.framework.html.HtmlApplication({
        namespace: WebClientNextechCodeAssessment,
        layoutSet: DevExpress.framework.html.layoutSets[WebClientNextechCodeAssessment.config.layoutSet],
        navigation: WebClientNextechCodeAssessment.config.navigation,
        commandMapping: WebClientNextechCodeAssessment.config.commandMapping
    });
    WebClientNextechCodeAssessment.app.router.register(":view/:id", { view: "grid", id: undefined });
    WebClientNextechCodeAssessment.app.on("viewShown", onViewShown);
    WebClientNextechCodeAssessment.app.on("navigatingBack", onNavigatingBack);
    WebClientNextechCodeAssessment.app.navigate();
});
