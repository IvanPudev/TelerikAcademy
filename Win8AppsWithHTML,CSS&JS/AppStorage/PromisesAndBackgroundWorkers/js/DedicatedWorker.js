/// <reference path="//Microsoft.WinJS.1.0/js/ui.js" />
/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
(function () {
    "use strict";

    WinJS.Namespace.define("Workers", {
        DedicatedWorker: WinJS.Class.define(function (scriptUrl) {
            this._available = true;
            this._worker = new Worker(scriptUrl);
        }, {
            available: {
                get: function () {
                    return this._available;
                }
            },
            postMessage: function (message, ports) {
                var self = this;
                var promise = new WinJS.Promise(function (success, error) {
                    self._worker.onmessage = function (data) {
                        success(data);
                        self._available = true;
                    };
                    self._worker.onerror = function (data) {
                        self._available = true;
                        error(data);
                    }
                });
                var messageClone = JSON.parse(JSON.stringify(message));
                var portsClone = ports != undefined ? JSON.parse(JSON.stringify(ports)) : null;
                this._worker.postMessage(messageClone, portsClone);
                this._available = false;
                return promise;
            }
        })
    });
}());