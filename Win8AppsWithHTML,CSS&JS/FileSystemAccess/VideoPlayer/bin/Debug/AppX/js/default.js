///
// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var playList;
    var videoPlayer;

    app.onactivated = function (args) {
        args.setPromise(WinJS.UI.processAll());

        videoPlayer = document.getElementById("video-player");
        playList = document.getElementById("video-playlist");

        var accsessCache = Windows.Storage.AccessCache;
        var futureAccessList = accsessCache.StorageApplicationPermissions.futureAccessList;

        WinJS.Utilities.id("bn_addvideo").listen("click", function (event) {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();

            picker.fileTypeFilter(".mp4");
            picker.fileTypeFilter(".avi");
            picker.fileTypeFilter(".wmv");

            picker.pickSingleFileAsync().then(function (video) {
                addVideoToPlaylist(video);
                futureAccessList.addOrReplace(video);
            });
        });

        WinJS.Utilities.id("bn_removevideo").listen("click", function (event) {
            var selected = document.getElementsByClassName("selected");

            while (selected.length > 0) {

                if (videoPlayer.src == selected[0].getAtribute("data-url")) {
                    videoPlayer.src = "";
                }

                playList.removeChild(selected[0]);
            }
        });

        WinJS.Utilities.id("bn_saveplaylist").listen("click", function (event) {
            var picker = new Windows.Storage.Pickers.FileSavePicker();
            picker.defaultFileExtension = ".txt";
            picker.fileTypeChoices.insert("JSON file", [".json"]);
            picker.suggestedFileName("New playlist");

            picker.pickSaveFileAsync().then(function (file) {
                var text = getElementFromPlaylist();
                Windows.Storage.FileIO.writeTextAsync(file, text);
            });
        });

        WinJS.Utilities.id("bn_loadplaylist").listen("click", function () {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.fileTypeFilter.append(".json");
            picker.pickSingleFileAsync().then(function () {
                Windows.Storage.FileIO.readTextAsync(file).done(function (text) {
                    var videos = JSON.parse(text);
                 
                    for (var i = 0; i < videos.length; i++) {
                        var element = videos[i];

                        futureAccessList.getFileAsync(element.name).then(function (video) {
                            var fileUrl = URL.createObjectURL(video);
                            var li = document.createElement("li");
                            li.draggable = true;
                            li.innerHTML = "<span>" + element.name + " " + element.duration + "</span>";
                            li.setAttribute("data-url", fileUrl);
                            li.setAttribute("data-path", element.path);
                            playlist.appendChild(li);
                        });
                    }
                });
            });
        });
    };

    var addVideoToPlaylist = function (video) {
        video.properties.getVideoPropertiesAsync().then(function (properties) {
            var duration = properties.duration / 1000;
            var hours = duration / 3600 | 0;
            var minutes = (duration - hours * 3600) / 60 | 0;
            var seconds = (duration - hours * 3600 - minutes * 60) / 60 | 0;

            var durationString =
                (hours == 0 ? "00" : hours) + ":" + (minutes == 0 ? "00" : minutes) + ":" + (seconds == 0 ? "00" : seconds);
            addElementToPlaylist(video, durationString);
        })
    };

    var addElementToPlaylist = function (video, duration) {
        var fileUrl = URL.createObjectURL(video);
        var path = video.path;
        var li = document.createElement("li");

        li.draggable = true;
        li.innerHTML = "<span>" + video.name + " " + duration + "</span>";
        li.setAttribute("data-url", fileUrl);
        li.setAttribute("data-path", path);

        playList.appendChild(li);
    };

    var getElementFromPlaylist = function () {
        var array = [];
        var count = playList.childNodes.length;

        for (var i = 0; i < count; i++) {
            var jsonObject = elementToJson(playList.childNodes[i]);
            array.push(jsonObject);
        }

        return JSON.stringify(array);
    };

    var elementToJson = function (element) {
        var path = element.getAtribute("data-path");
        var name = element.childNodes[0].childNodes[0].innerHTML;
        var duration = element.childNodes[0].childNodes[0].nextSibling.nodeValue;

        var jsonObject = { path: path, name: name, duration: duration };

        return jsonObject;
    };

    app.oncheckpoint = function (args) {

    };

    app.start();

    
})();
