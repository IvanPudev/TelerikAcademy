/// <reference path="repeater.js" />
// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {

            var computers = [];
            for (var i = 0; i < 10; i++) {
                if (i % 2 == 0) {
                    computers.push(Data.getComputer("Dell Studio " + i, 2000 + i, "/images/studio-1535.png", "Core i5", 2.0));
                }
                else {
                    computers.push(Data.getComputer("Dell Studio " + i, 2000 + i, "/images/hp-650.jpg", "Core i5", 2.0));
                }
            }



            WinJS.UI.processAll().then(function () {
                var container = document.getElementById("container");

                var createComputerBtn = document.getElementById("create-computer");
                createComputerBtn.addEventListener("click", function () {
                    var compName = document.getElementById("name").value;
                    var compPrice = document.getElementById("price").value;
                    var procModel = document.getElementById("model").value;
                    var procFreq = document.getElementById("freq").value;
                    var image = document.getElementById("image").value;

                    var newComp = Data.getComputer(compName, compPrice, image, procModel, procFreq);
                    var singleBind = new BindingTools.SingleBind(newComp, container, "ms-appx:///templates/computer-template.html");
                    singleBind.render();

                    //proof of binding
                    setInterval(function () {
                        newComp.price -= 10;
                    }, 1000);
                })

                var repeater = new BindingTools.Repeater(computers, container, "ms-appx:///templates/computer-template.html");
                repeater.render();

            });

            //proof of binding
            setInterval(function () {
                computers[0].price -= 10;
            }, 1000);

            setInterval(function () {
                computers[1].price += 10;
            }, 2000);
        }
    };


    app.start();
})();