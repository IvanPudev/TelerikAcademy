// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        var firstComputerObservable = Data.getComputer("Dell Studio 1535", 2000, "/images/studio-1535.png", "Core i5", 2.0, "Dell");
        var firstDellComputerObservable = Data.getComputer("Dell Pesho 9999", 700000, "/images/studio-1535.png", "Core i9", 7.0, "Dell");
        var secondComputerObservable = Data.getComputer("HP 650", 1500, "/images/hp-650.jpg", "Intel 1000M", 1.8, "HP");
        var list = new WinJS.Binding.List([firstComputerObservable, firstDellComputerObservable, secondComputerObservable]);
        // Sorts the groups
        function compareGroups(leftKey, rightKey) {
            return 0;
        }

        function getGroupKey(dataItem) {
            return dataItem.manufacturer;
        }

        // Returns the title for a group
        function getGroupData(dataItem) {
            return {
                manufacturer: dataItem.manufacturer
            };
        }

        // Create the groups for the ListView from the item data and the grouping functions
        var groupedItemsList = list.createGrouped(getGroupKey, getGroupData, compareGroups);

        WinJS.Namespace.define("Me", {
            computers: groupedItemsList
        });

        WinJS.UI.processAll().then(function () {
            document.getElementById("add").addEventListener("click", function () {
                var name = document.getElementById("name").value;
                var imgUrl = document.getElementById("imgUrl").value;
                var frequencyGHz = document.getElementById("frequencyGHz").value;
                var modelName = document.getElementById("modelName").value;
                var manufacturer = document.getElementById("manufacturer").value;
                var price = document.getElementById("price").value;

                Me.computers.push(Data.getComputer(name, price, imgUrl, modelName, frequencyGHz, manufacturer));
            });
        });
    };

    app.start();
})();
