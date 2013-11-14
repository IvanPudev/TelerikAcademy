(function ($) {
    $.fn.treeView = function () {
        $("a").on("click", function () {
            $(this).next("ul").toggle();
        });
        return $(this);
    }
})(jQuery);

$(document).ready(function () {
    $("ul").hide();
    $('#treeView').treeView().show();
    $("ul").parent().children("a").css("color", "green");
});