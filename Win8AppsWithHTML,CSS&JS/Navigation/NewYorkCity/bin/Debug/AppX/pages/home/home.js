﻿(function () {
    "use strict";

    var appViewState = Windows.UI.ViewManagement.ApplicationViewState;
    var ui = WinJS.UI;

    ui.Pages.define("/pages/home/home.html", {
        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
        ready: function (element, options) {
            var items = [
                { title: "History", backgroundImage: 'http://upload.wikimedia.org/wikipedia/commons/thumb/f/fb/The_Purchase_of_Manhattan_Island.png/250px-The_Purchase_of_Manhattan_Island.png' },
                { title: "Geography", backgroundImage: 'http://upload.wikimedia.org/wikipedia/commons/thumb/4/4f/Aster_newyorkcity_lrg.jpg/170px-Aster_newyorkcity_lrg.jpg' },
                { title: "Architecture", backgroundImage: 'http://upload.wikimedia.org/wikipedia/commons/thumb/d/d3/Greenpoint_Houses.JPG/220px-Greenpoint_Houses.JPG' },
            ];
            var list = new WinJS.Binding.List(items);
            var listView = element.querySelector(".itemslist").winControl;
            listView.itemDataSource = list.dataSource;
            listView.itemTemplate = element.querySelector(".itemtemplate");
            listView.oniteminvoked = this._itemInvoked.bind(this);

            this._initializeLayout(listView, Windows.UI.ViewManagement.ApplicationView.value);
            listView.element.focus();
        },

        // This function updates the page layout in response to viewState changes.
        updateLayout: function (element, viewState, lastViewState) {
            /// <param name="element" domElement="true" />

            var listView = element.querySelector(".itemslist").winControl;
            if (lastViewState !== viewState) {
                if (lastViewState === appViewState.snapped || viewState === appViewState.snapped) {
                    var handler = function (e) {
                        listView.removeEventListener("contentanimating", handler, false);
                        e.preventDefault();
                    }
                    listView.addEventListener("contentanimating", handler, false);
                    var firstVisible = listView.indexOfFirstVisible;
                    this._initializeLayout(listView, viewState);
                    if (firstVisible >= 0 && listView.itemDataSource.list.length > 0) {
                        listView.indexOfFirstVisible = firstVisible;
                    }
                }
            }
        },

        // This function updates the ListView with new layouts
        _initializeLayout: function (listView, viewState) {
            if (viewState === appViewState.snapped) {
                listView.layout = new ui.ListLayout();
            } else {
                listView.layout = new ui.GridLayout();
            }
        },

        _itemInvoked: function (args) {
            var items = [
                "/pages/history/history.html",
                "/pages/geography/geography.html",
                "/pages/architecture/architecture.html",
            ];
            var url = items[args.detail.itemIndex];
            WinJS.Navigation.navigate(url);
        }
    });
})();
