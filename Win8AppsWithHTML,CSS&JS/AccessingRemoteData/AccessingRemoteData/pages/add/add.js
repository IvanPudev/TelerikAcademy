﻿// For an introduction to the Page Control template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232511
(function () {
    "use strict";

    WinJS.UI.Pages.define("/pages/add/add.html", {
        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
        ready: function (element, options) {
            document.getElementById("submit")
            .addEventListener("click", function () {
                WinJS.xhr({
                    url: "http://posted.apphb.com/api/posts",
                    type: "post",
                    headers: { "Content-type": "application/json" },
                    data: JSON.stringify({
                        "Author": document.getElementById("author").value,
                        "Content": document.getElementById("content").innerText
                    })
                }).then(function () {
                    document.getElementById("result").innerText = "Your post was successfuly added.";
                }, function (e) {
                    document.getElementById("result").innerText = "There is a problem with the post.";
                });
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
