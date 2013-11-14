// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    
    app.onactivated = function (args) {
        WinJS.UI.processAll();
       
        var calcButton = document.getElementById("calculate-button");
        var switchControl = document.getElementById("switcher");
        var calcDays = document.getElementById("calculate-days");
        var calcHours = document.getElementById("calculate-hours");
        var calcDaysHours = document.getElementById("calculate-days-hours");

        calcButton.addEventListener("click", showMenu);
        switchControl.addEventListener("click", showTimeMenu);
        calcDays.addEventListener("click", calculateDays);
        calcHours.addEventListener("click", calculateHours);
        calcDaysHours.addEventListener("click", calculateDaysHours);
    };

    var showMenu = function () {
        var menu = document.getElementById("menu").winControl;
        menu.show();
    };

    var showTimeMenu = function () {
        var switchButton = document.getElementById("switcher").winControl;
        

        if (switchButton.checked) {
            var timePickers = document.getElementsByClassName("win-timepicker");
            timePickers[0].style.display = "";
            timePickers[1].style.display = "";
        }
        else {
            var timePickers = document.getElementsByClassName("win-timepicker");
            timePickers[0].style.display = "none";
            timePickers[1].style.display = "none";
        }
    };

    var calculateDays = function () {
        var hours = parseInt(getMinutes() / 60);
        var days = parseInt(hours / 24);
        printResult(days + " days");
    }

    var calculateHours = function(){
        var minutes = getMinutes();
        var hours = parseInt(minutes / 60);

        printResult(hours + " hours and " + (minutes - (hours * 60)) + " minutes");
    }

    var calculateDaysHours = function () {
        var minutes = getMinutes();
        var hours = parseInt(minutes / 60);
        var days = parseInt(hours / 24);

        var result = days + " days or " + hours + " hours ";
        printResult(result);
    };

    var getMinutes = function () {
        var switchButton = document.getElementById("switcher").winControl;

        var timePickers = document.getElementsByClassName("win-timepicker");
        var datePickers = document.getElementsByClassName("win-datepicker");

        var firstDate = new Date((datePickers[0].winControl).current);
        var secondDate = new Date((datePickers[1].winControl).current);

        if (switchButton.checked) {
            var firstTime = new Date((timePickers[0].winControl).current);
            var secondTime = new Date((timePickers[1].winControl).current);

            firstDate.setHours(firstTime.getHours());
            firstDate.setMinutes(firstTime.getMinutes());
            firstDate.setSeconds(0);

            secondDate.setHours(secondTime.getHours());
            secondDate.setMinutes(secondTime.getMinutes());
            secondDate.setSeconds(0);
        }
        var MINUTE = 60 * 1000;
        var daysInMilliseconds = Math.abs(firstDate.getTime() - secondDate.getTime());
        var minutes = Math.round(daysInMilliseconds / MINUTE);
        return minutes;
    };

    var printResult = function (calcResults) {
        var datePickers = document.getElementsByClassName("win-datepicker");
        var firstDate = new Date((datePickers[0].winControl).current);
        var lastDate = new Date((datePickers[1].winControl).current);

        var result = "Time between " + firstDate.toDateString() + " and " + lastDate.toDateString() + " is: " + calcResults;
        var newLi = document.createElement("li");
        newLi.innerText = result;
        document.getElementById("results").appendChild(newLi);
    };

    app.start();
})();
