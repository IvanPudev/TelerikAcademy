/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="vegetable.js" />
/// <reference path="tomato.js" />
/// <reference path="cucumber.js" />
/// <reference path="mushroom-mixin.js" />

WinJS.Namespace.defineWithParent(Plants, "GMO", {
    TomatoGmo: WinJS.Class.mix(Plants.DirectlyEatable.Tomato, Mixins.Mushroom),
    CucumberGmo: WinJS.Class.mix(Plants.IndirectlyEatable.Cucumber, Mixins.Mushroom)
});