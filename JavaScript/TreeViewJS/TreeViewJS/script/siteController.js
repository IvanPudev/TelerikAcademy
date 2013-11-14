(function () {

    var SiteController = function (param) {
        this.param = param;
        this.treeViewContainer = document.getElementById(param.treeViewContainer);
    }

    SiteController.prototype = {
        init: function () {
            initTreeView();
        },
        initTreeView: function () {
            this.treeView = new TreeView({
                treeViewContainer: this.treeViewContainer,
            });
            this.treeView.init();
        }
    };


    document.querySelector("body").addEventListener("load", function () {
        var siteController = new SiteController({
            treeViewContainer: "treeViewContainer"
        });
        siteController.init();
    }, false);
})();