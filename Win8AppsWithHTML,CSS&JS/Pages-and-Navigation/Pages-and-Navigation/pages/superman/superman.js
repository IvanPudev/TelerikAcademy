// For an introduction to the Page Control template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232511
(function () {
    "use strict";

    WinJS.UI.Pages.define("/pages/superman/superman.html", {
        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
        ready: function (element, options) {
            var pageHolder = document.getElementById("container");
            var backButton = document.getElementsByClassName("win-backbutton")[0];
            backButton.addEventListener("click", function () {
                pageHolder.innerHTML = "";
                WinJS.UI.Pages.render("/pages/home/home.html", pageHolder);
            });
        },

        unload: function () {
            // TODO: Respond to navigations away from this page.
        },

        updateLayout: function (element, viewState, lastViewState) {
            /// <param name="element" domElement="true" />

            // TODO: Respond to changes in viewState.
        }
    });
})();
