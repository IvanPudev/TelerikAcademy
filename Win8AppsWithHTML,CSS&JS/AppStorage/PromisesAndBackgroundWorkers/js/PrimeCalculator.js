/// <reference path="//Microsoft.WinJS.1.0/js/ui.js" />
/// <reference path="DedicatedWorker.js" />
/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
(function () {
    "use strict";

    var PrimeCalculator = WinJS.Class.define(function (workers) {
        for (var i = 0; i < workers; i++) {
            this._dedicatedWorkers.push(new Workers.DedicatedWorker("/js/PrimeWorker.js"));
        }
    }, {
        _dedicatedWorkers: [],
        _getFreeWorker: function () {
            for (var i = 0; i < this._dedicatedWorkers.length; i++) {
                if (this._dedicatedWorkers[i].available) {
                    return this._dedicatedWorkers[i];
                }
            }

            throw Error("All dedicated workers are already busy. You can do 3 async call simultaneously.");
        },
        _constructMessage: function (start, end, count) {
            if (count == undefined && start == undefined) {
                start = 0;
            }

            var message = {
                start: start | 0,
                end: end | 0,
                count: count | 0
            };
            return message;
        },
        _calculatePrimerNumbers: function (start, end, count) {
            return new WinJS.Promise(function (success, error) {
                try {
                    var worker = this._getFreeWorker();
                    var message = this._constructMessage(start, end, count);
                    var promise = worker.postMessage(message);
                    promise.done(success, error);
                } catch (e) {
                    error(e);
                }
            }.bind(this));
        },
        calculatePrimerNumbersTo: function (end) {
            return this._calculatePrimerNumbers(2, end);
        },
        calculatePrimeNumberBetween: function (start, end) {
            return this._calculatePrimerNumbers(start, end);
        },
        calculateFirstNPrimeNumbers: function (count) {
            return this._calculatePrimerNumbers(2, 5000000, count);
        }
    });
    
    WinJS.Namespace.define("Math", {
        PrimeNumbers: PrimeCalculator
    });
}());