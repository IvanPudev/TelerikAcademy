(function () {
    "use strict";

    WinJS.UI.Pages.define("/pages/home/home.html", {
        _data: null,
        _updatePosts: function () {
            WinJS.xhr({
                type: "get",
                url: "http://posted.apphb.com/api/posts",
                responseType: "json"
            }).then(function (result) {
                var data = JSON.parse(result.response);
                this._data.splice(0, this._data.length);
                this._data.length = 0;
                data.forEach(function (item) {
                    this._data.push(item);
                }.bind(this));
            }.bind(this));
        },
        init: function (element, options) {
            this._data = new WinJS.Binding.List([], { binding: true });
            WinJS.Namespace.define("Posted", {
                posts: this._data
            });

            this._updatePosts();
            setInterval(this._updatePosts.bind(this), 30000);
        },
        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
        ready: function (element, options) {
            
        }
    });
})();
