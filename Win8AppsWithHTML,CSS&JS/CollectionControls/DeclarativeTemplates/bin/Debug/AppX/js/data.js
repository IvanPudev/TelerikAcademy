(function () {
    var computer = {
        name: "",
        imageUrl: "",
        price: 0,
        manufacturer: 0,
        processor: {
            modelName: "",
            frequencyGHz: 0
        }
    }

    var ObservableComputer = WinJS.Binding.define(computer);

    WinJS.Namespace.define("Data", {
        getComputer: function (name, price, imageUrl, processorName, processorGHz, manufacturer) {
            return new ObservableComputer({
                name: name,
                imageUrl: imageUrl,
                price: price,
                manufacturer: manufacturer,
                processor: {
                    modelName: processorName,
                    frequencyGHz: processorGHz
                }
            });
        }
    });
})();