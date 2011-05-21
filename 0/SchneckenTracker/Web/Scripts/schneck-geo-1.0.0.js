/// <reference path="jquery-1.5.1-vsdoc.js"/>

var geoTracker = (function ($) {

    var watchId;

    var state = {
        stop: function () { clearWatch(); },
        start: function () { startWatch(); }
    };

    var recordPosition = function (position) {
        $.post("TrackLocation", position.coords, updateStatusPanel("updated"), "json");
    }

    var handleError = function (error) {
        updateStatusPanel(error);
    }

    var updateStatusPanel = function (text) {
        $("#tracking-status")
            .html(text)
            .fadeIn()
            .delay(1000)
            .fadeOut();
    }

    var startWatch = function () {
        watchId = navigator.geolocation.watchPosition(recordPosition, handleError, { enableHighAccuracy: true });
        $("#app-logo").addClass("active");
    }

    var clearWatch = function () {
        navigator.geolocation.clearWatch(watchId);
        watchId = 0;
        $("#app-logo").removeClass("active");
    }

    $(function () {
        $("#tracking-status").hide();
    });

    return state;
} (jQuery));