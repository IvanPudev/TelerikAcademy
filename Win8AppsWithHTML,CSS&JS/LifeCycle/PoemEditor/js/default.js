// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
            } else {
                var editor = document.getElementById("editor");
                var text = Windows.Storage.ApplicationData.current.localSettings.values["currentPoem"] || '';
                WinJS.Utilities.setInnerHTML(editor, text);
                document.getElementById("result").innerText = app.sessionState["result"];
                document.getElementById("error").innerText = app.sessionState["error"];
            }

            load();
            args.setPromise(WinJS.UI.processAll());
        }
    };

    app.oncheckpoint = function (args) {
        var editor = document.getElementById("editor");
        Windows.Storage.ApplicationData.current.localSettings.values["currentPoem"] = editor.innerText;
        app.sessionState["result"] = document.getElementById("result").innerText;
        app.sessionState["error"] = document.getElementById("error").innerText;
        //args.setPromise();
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. You might use the
        // WinJS.Application.sessionState object, which is automatically
        // saved and restored across suspension. If you need to complete an
        // asynchronous operation before your application is suspended, call
        // args.setPromise().
    };

    function checkRhymeSentence(sentence) {
        var rhymesCount = 0;
        var words = sentence.split(' ');
        for (var i = 1; i < words.length; i++) {
            if (words[i - 1].substr(-2) == words[i].substr(-2)) {
                rhymesCount++;
            }
        }
        if (words.length == 1) {
            return true;
        }

        return rhymesCount > 0;
    }

    function checkRhymeSentances(sentence, secondSentence) {
        return sentence.substr(-2) == secondSentence.substr(-2);
    }

    function checkForSequenceRhymes(text) {
        var sentences = text.split("\r\n");

        for (var i = 1; i < sentences.length; i += 2) {
            if (!checkRhymeSentances(sentences[i - 1], sentences[i])) {
                return { line: i, secondLine: i + 1, msg: "No rhymes are found." };
            }
        }
    }

    function checkForSkipRhymes(text) {
        var sentences = text.split("\r\n");

        var lines = 0;
        for (var i = 2; i < sentences.length; i++) {
            if (!checkRhymeSentances(sentences[i - 2], sentences[i])) {
                return { line: i - 1, secondLine: i + 1,  msg: "No rhymes are found." };
            }

            lines++;
            if (lines == 2) {
                lines = 0;
                i+= 2;
            }
        }
    }

    function performFormating(text, paragraphsValue) {
        var sentences = text.split("\r\n");
        var sentencesCount = 0;
        var textForPrint = [];
        for (var i = 0; i < sentences.length; i++) {
            if (sentences[i].length > 0) {
                sentencesCount++;
                textForPrint.push(sentences[i]);
                if (sentencesCount == paragraphsValue) {
                    textForPrint.push("");
                    sentencesCount = 0;
                }
            } else {
                sentencesCount = 0;
            }
        }

        if (sentencesCount % paragraphsValue == 0) {
            WinJS.Utilities.setInnerHTMLUnsafe(document.getElementById("result"), textForPrint.join("<br />"));
        }
    }

    function load() {
        var paragraphs = document.getElementById("paragraphs");
        var editor = document.getElementById("editor");
        editor.addEventListener("keyup", function (ev) {
            var key = window.event.keyCode;

            // If the user has pressed enter
            if (key == 13) {
                var paragraphsValue = paragraphs.value | 0;
                if (paragraphsValue < 1) {
                    paragraphsValue = 4;
                }

                performFormating(ev.srcElement.innerText, paragraphsValue);
            }
        });

        var seqBtn = document.getElementById("seqCheck");
        seqBtn.addEventListener("click", function (ev) {
            var error = checkForSequenceRhymes(editor.innerText);
            var errorElement = document.getElementById("error");
            if (error) {
                WinJS.Utilities.setInnerHTML(errorElement, "Lines: " + error.line + " - " + error.secondLine + ". Desctiption: " + error.msg);
            } else {
                WinJS.Utilities.setInnerHTML(errorElement, '');
            }
        });


        var skipBtn = document.getElementById("skipCheck");
        skipBtn.addEventListener("click", function (ev) {
            var error = checkForSkipRhymes(editor.innerText);
            var errorElement = document.getElementById("error");
            if (error) {
                WinJS.Utilities.setInnerHTML(errorElement, "Lines: " + error.line + " - " + error.secondLine + ". Desctiption: " + error.msg);
            } else {
                WinJS.Utilities.setInnerHTML(errorElement, '');
            }
        });

        var saveBtn = document.getElementById("save");
        saveBtn.addEventListener("click", function () {
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.defaultFileExtension = ".ptxt";
            savePicker.fileTypeChoices.insert("Video Playlist", [".ptxt"]);
            savePicker.suggestedFileName = "New Poem";

            savePicker.pickSaveFileAsync().then(function (file) {
                if (file) {
                    var poem = editor.innerText;
                    Windows.Storage.FileIO.writeTextAsync(file, poem);
                }
            });
        });

        var loadBtn = document.getElementById("load");
        loadBtn.addEventListener("click", function () {
            var pickable = true;
            var msg = new Windows.UI.Popups.MessageDialog("You will lose current poem.", "Do you want to load poem without save?");
            msg.commands.append(new Windows.UI.Popups.UICommand("yes", function () {
                pickable = true;
            }));
            msg.commands.append(new Windows.UI.Popups.UICommand("no", function () {
                pickable = false;
            }));

            msg.showAsync().then(function () {
                if (pickable) {
                    var openPicker = Windows.Storage.Pickers.FileOpenPicker();
                    openPicker.fileTypeFilter.append(".ptxt");
                    openPicker.pickSingleFileAsync().then(function (file) {
                        if (file) {
                            Windows.Storage.FileIO.readTextAsync(file).then(function (text) {
                                WinJS.Utilities.setInnerHTML(editor, text);
                                var paragraphsValue = paragraphs.value | 0;
                                if (paragraphsValue < 1) {
                                    paragraphsValue = 4;
                                }
                                performFormating(text, paragraphsValue);
                            });
                        }
                    });
                }
            });
        });
    }

    app.start();
})();
