/// <reference path="//Microsoft.WinJS.1.0/js/ui.js" />
/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
(function () {
    "use strict";

    WinJS.Namespace.defineWithParent(WinJS, "Utilities", {
        isFunction: function (obj) {
            return !!(obj && obj.constructor && obj.call && obj.apply);
        }
    });
}());