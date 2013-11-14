/// <reference path="vegetable.js" />
/// <reference path="gmo.js" />
// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;

    app.onactivated = function (args) {
        var gmoTomato = new Plants.GMO.TomatoGmo(5);
        gmoTomato.descriptionString();
        gmoTomato.watering(5);
        gmoTomato.descriptionString();

        var gmoCucumber = new Plants.GMO.CucumberGmo(2);
        gmoCucumber.descriptionString();
        gmoCucumber.watering(2);
        gmoCucumber.descriptionString();
    }
    app.start();
})();
