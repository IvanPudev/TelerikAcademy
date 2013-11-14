/// <reference path="../js/PrimeCalculator.js" />
/// <reference path="../js/Helpers/Utilities.js" />
(function () {
    "use strict";
    var temporaryFolder = Windows.Storage.ApplicationData.current.temporaryFolder;
    var localSettings = Windows.Storage.ApplicationData.current.localSettings;
    

    var workers = localSettings.values["workers"] || 0;
    if (!workers) {
        workers = 3;
    }

    var primeCalculator = new Math.PrimeNumbers(workers);

    var viewModel = WinJS.Binding.as({
        endResult: '',
        endNumber: 0,
        fromToResult: '',
        fromNumber: 0,
        toNumber: 0,
        countResult: '',
        countNumber: 0,
        workerNumber: workers,
        setWorkerNumber: function (ev) {
            var value = ev.srcElement.value | 0;
            if (value < 1) {
                value = 1;
            }

            viewModel.workerNumber = value;
            localSettings.values["workers"] = viewModel.workerNumber;
            primeCalculator = new Math.PrimeNumbers(viewModel.workerNumber);
        },
        setEndNumber: function (ev) {
            viewModel.endNumber = ev.srcElement.value;
        },
        setFromNumber: function (ev) {
            viewModel.fromNumber = ev.srcElement.value;
        },
        setToNumber: function (ev) {
            viewModel.toNumber = ev.srcElement.value;
        },
        setCount: function (ev) {
            viewModel.countNumber = ev.srcElement.value;
        },
        calculateEnd: function () {
            var fileName = "end" + viewModel.endNumber + ".crs";
            viewModel._getResult(fileName, viewModel._calculateEnd, "endResult");
        },
        calculateFromTo: function () {
            var fileName = "from" + viewModel.fromNumber + "to" + viewModel.toNumber + ".crs";
            viewModel._getResult(fileName, viewModel._calculateFromTo, "fromToResult");
        },
        calculateN: function () {
            var fileName = "n" + viewModel.countNumber + ".crs";
            viewModel._getResult(fileName, viewModel._calculateN, "countResult");
        },
        _calculateEnd: function (fileName) {
            primeCalculator.calculatePrimerNumbersTo(viewModel.endNumber)
            .then(function (result) {
                viewModel.endResult = result.data.toString();
                viewModel._saveResult(fileName, viewModel.endResult);
            }, function (e) {
                viewModel.endResult = e.message;
            });
        },
        _calculateFromTo: function (fileName) {
            primeCalculator.calculatePrimeNumberBetween(viewModel.fromNumber, viewModel.toNumber)
            .then(function (result) {
                viewModel.fromToResult = result.data.toString();
                viewModel._saveResult(fileName, viewModel.fromToResult);
            }, function (e) {
                viewModel.fromToResult = e.message;
            });
        },
        _calculateN: function (fileName) {
            primeCalculator.calculateFirstNPrimeNumbers(viewModel.countNumber)
            .then(function (result) {
                viewModel.countResult = result.data.toString();
                viewModel._saveResult(fileName, viewModel.countResult);
            }, function (e) {
                viewModel.countResult = e.message;
            });
        },
        _saveResult: function (fileName, result) {
            temporaryFolder.createFileAsync(fileName, Windows.Storage.CreationCollisionOption.replaceExisting)
                .then(function (file) {
                    Windows.Storage.FileIO.writeTextAsync(file, result);
                });
        },
        _getResult: function (fileName, func, property) {
            temporaryFolder.getFileAsync(fileName).done(function (file) {
                Windows.Storage.FileIO.readTextAsync(file)
                    .then(function (text) {
                        viewModel[ property] = text;
                    });
            }, function () {
                func(fileName);
            });
        }
    });
    
    WinJS.Utilities.markSupportedForProcessing(viewModel.setEndNumber);
    WinJS.Utilities.markSupportedForProcessing(viewModel.setFromNumber);
    WinJS.Utilities.markSupportedForProcessing(viewModel.setToNumber);
    WinJS.Utilities.markSupportedForProcessing(viewModel.setCount);
    WinJS.Utilities.markSupportedForProcessing(viewModel.calculateEnd);
    WinJS.Utilities.markSupportedForProcessing(viewModel.calculateFromTo);
    WinJS.Utilities.markSupportedForProcessing(viewModel.calculateN);
    WinJS.Utilities.markSupportedForProcessing(viewModel.setWorkerNumber);

    WinJS.Namespace.define("ViewModel", {
        PrimeCalculator: viewModel
    });
}());