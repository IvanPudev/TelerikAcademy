/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
WinJS.Namespace.define(
    "BindingTools",
    {
        Repeater: WinJS.Class.define(
            //constructor 
            function (data, domElement, href) {

                this._href = href;
                this._data = data;
                this._domElement = domElement;
            },
            //instance members
            {
                render: function (template) {
                    for (var i = 0; i < this._data.length; i++) {
                        var div = document.createElement('div');
                        div.classList.add('inlinestyle');
                        var template = new WinJS.Binding.Template(null, {
                            href: this._href
                        });
                        template.render(this._data[i], div).done();
                        this._domElement.appendChild(div);
                    }
                }
            },
            //static members
            {}),
        SingleBind: WinJS.Class.define(
            function (data, domElement, href) {
                this._href = href;
                this._data = data;
                this._domElement = domElement;
            },
            {
                render: function () {
                    var div = document.createElement('div');
                    div.classList.add('inlinestyle');
                    var template = new WinJS.Binding.Template(null, {
                        href: this._href
                    });
                    template.render(this._data, div).done();
                    this._domElement.appendChild(div);
                }
            }, {}
            )
    });