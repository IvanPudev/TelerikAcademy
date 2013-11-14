(function () {
    var map;
    var currentCity = 0;
    var cities = [
        { x: 42.69959, y: 23.31985, name: "Sofia" },
        { x: 55.76421, y: 37.62222, name: "Moscow" },
        { x: 51.51216, y: -0.12519, name: "London" },
        { x: 48.85906, y: 2.35239, name: "Paris" },
        { x: 52.53711, y: 13.40171, name: "Berlin" },
        { x: 50.07058, y: 14.44291, name: "Prague" },
        { x: 59.43739, y: 24.75254, name: "Talin" },
        { x: 59.91579, y: 10.75126, name: "Oslo" },
        { x: 41.34021, y: 19.82259, name: "Tirana" },
        { x: 45.81552, y: 15.98167, name: "Zagreb" },
    ];
    var x = cities[0].x;
    var y = cities[0].y;
    var z = 10;

    function initialize() {
        var mapOptions = {
            zoom: z,
            center: new google.maps.LatLng(x, y),
            mapTypeId: google.maps.MapTypeId.HYBRID
        };
        map = new google.maps.Map(document.getElementById('map-canvas'),
            mapOptions);
    }

    document.getElementById('get-previous').addEventListener('click', function () {
        if (currentCity == 0) {
            currentCity = cities.length - 1;
        }
        else {
            currentCity--;
        }
        goToCity();
    }, false);

    document.getElementById('get-next').addEventListener('click', function () {
        if (currentCity == cities.length - 1) {
            currentCity = 0;
        }
        else {
            currentCity++;
        }
        goToCity();
    }, false);

    goToCity = function () {

        x = cities[currentCity].x;
        y = cities[currentCity].y;

        var pos = new google.maps.LatLng(x, y);
        map.panTo(pos);
        map.setZoom(z);

        new google.maps.InfoWindow({
            map: map,
            position: pos,
            content: cities[currentCity].name + " Coordinates<br />Latidude: " + cities[currentCity].x + "<br />Longitude: " + cities[currentCity].y
        });
    }
    google.maps.event.addDomListener(window, 'load', initialize());

    (function () {
        var container = document.getElementById("cities");
        for (var i = 0; i < cities.length; i++) {
            var link = document.createElement("a");
            link.id = cities[i].name;
            link.style.display = "block";
            link.innerHTML = cities[i].name;
            container.appendChild(link);
            link.addEventListener('click', function (e) {
                for (var j = 0; j < cities.length; j++) {
                    if (cities[j].name == e.target.id) {
                        currentCity = j;
                        break;
                    }
                }
                goToCity();
            }, false);
        }
    })();
}());