/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="vegetable.js" />

WinJS.Namespace.defineWithParent(Plants, "DirectlyEatable", {
    Tomato: WinJS.Class.derive(Plants.Vegetable, function(dim) {
        Plants.Vegetable.call(this, "red", true, dim);
        this.name = "tomato";
    })
});