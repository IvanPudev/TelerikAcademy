/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.define("Plants", {
    Vegetable: WinJS.Class.define(
        function (color, eatDirectly, size) {
            this.color = color;
            this.eatDirectly = eatDirectly;
            this._size = size;
            this.name = name;
        }, {
            size: {
                get: function () {
                    return this._size;
                },
                set: function (value) {
                    this._size = value;
                }
            },
            descriptionString: function () {
                console.log("Name: " + this.name);
                console.log("Color: " + this.color);
                console.log("Can be eaten directly: " + (this.eatDirectly ? "yes" : "no"));
                console.log("Size: " + this.size);
            }
        })

});