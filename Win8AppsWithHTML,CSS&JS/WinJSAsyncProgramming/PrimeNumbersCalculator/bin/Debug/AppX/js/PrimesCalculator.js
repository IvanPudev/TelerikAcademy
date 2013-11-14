/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.define("PrimeNumbersCalculator", {
    PrimesCalculator: WinJS.Class.define(function(){
        this._freeWorkers = [];
        this._primesWorkers = [];

        this._freeWorkers[0] = true;
        this._freeWorkers[1] = true;
        this._freeWorkers[2] = true;

        this._primesWorkers[0] = new Worker("/js/primesWorker.js");
        this._primesWorkers[1] = new Worker("/js/primesWorker.js");
        this._primesWorkers[2] = new Worker("/js/primesWorker.js");
    }, {
        calculate: function(srartNumber, endNumber, countNumber){
            var freeWorkersCount = -1;
            for (var i = 0; i <= 2 ; i++) {
                if (this._freeWorkers[i] == true) {
                    freeWorkersCount = i;
                    break;
                }
            }

            if (freeWorkersCount != -1) {
                var self = this;
                return new WinJS.Promise(function(complete) {
                    var primes = {};

                    self._primesWorkers[freeWorkersCount].onmessage = function(event) {
                        self._freeWorkers[freeWorkersCount] = true;
                        self._primesWorkers[freeWorkersCount].onmessage = null;
                        primes = event.data;
                        complete(primes);
                    }
                    self._freeWorkers[freeWorkersCount] = false;
                    self._primesWorkers[freeWorkersCount].postMessage({
                        startNumber: srartNumber, endNumber: endNumber, countNumber: countNumber
                    });
                });
            }
            else {
                return new WinJS.Promise(function(complete, error) {
                    error("All three workers are busy...");
                });
            }
        }
    })
})