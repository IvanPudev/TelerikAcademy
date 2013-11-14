/// <reference path="PrimesCalculator.js" />
/// <reference path="primesWorker.js" />

// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var calculator;

    app.onactivated = function (args) {
        calculator = new PrimeNumbersCalculator.PrimesCalculator();

        var calcPrimesButton = document.getElementById("calculate");
        var primesStart = document.getElementById("start-number");
        var primesEnd = document.getElementById("end-number");
        var primesCount = document.getElementById("count-number");

        calcPrimesButton.addEventListener("click", function () {
            calculator.calculate(primesStart.value, primesEnd.value, primesCount.value)
            .then(function (primes) {
                var resultContainer = document.getElementById("result-container");
                var innerHTML = "</br> Primes are: ";

                for (var i = 0; i < primes.length; i++) {
                    innerHTML += primes[i] + " ";
                }

                resultContainer.innerHTML += innerHTML;
            }, function (error) {
                var resultContainer = document.getElementById("result-container");
                var innerHTML = "</br> Primes are: " + error;
                resultContainer.innerHTML += innerHTML;
            })
        })

    };

    app.start();
})();
