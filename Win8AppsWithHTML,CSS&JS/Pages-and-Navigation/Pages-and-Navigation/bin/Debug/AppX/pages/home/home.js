/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="//Microsoft.WinJS.1.0/js/ui.js" />
// For an introduction to the Page Control template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232511
(function () {
    "use strict";

    WinJS.UI.Pages.define("/pages/home/home.html", {
        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
        ready: function (element, options) {
            var pageHolder = document.getElementById("container");
            WinJS.Utilities.query(".article-holder").listen("click", function (event) {
                var target = event.target;
                var imageSrc = String(target.src);
                var firstIndex = imageSrc.indexOf("pages/");
                var secondIndex = imageSrc.indexOf("/", firstIndex + 6);
                var pageName = imageSrc.substring(firstIndex + 6, secondIndex);
                var pagePath = "/pages/" + pageName + "/" + pageName + ".html";
                pageHolder.innerHTML = "";
                WinJS.UI.Pages.render(pagePath, pageHolder);
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
