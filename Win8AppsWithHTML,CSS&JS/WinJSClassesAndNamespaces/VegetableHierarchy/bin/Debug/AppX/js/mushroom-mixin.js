/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.define("Mixins", {
    Mushroom: {
        watering: function (waterDrop) {
            this._size += waterDrop;
        }
    }
});