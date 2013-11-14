/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="vegetable.js" />

WinJS.Namespace.defineWithParent(Plants, "IndirectlyEatable", {
    Cucumber: WinJS.Class.derive(Plants.Vegetable, function (dim) {
        Plants.Vegetable.call(this, "green", false, dim);
        this.name = "cucumber";
    })
});