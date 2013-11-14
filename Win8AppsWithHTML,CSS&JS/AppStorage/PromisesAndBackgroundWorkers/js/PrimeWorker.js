/// <reference group="Dedicated Worker" />
(function () {
    function isPrimeNumber(number) {
        for (var i = 2; i < number; i++) {
            if (number % i == 0) {
                return false;
            }
        }

        return true;
    }

    function isCountReached(number, count) {
        if (count) {
            if (count == number) {
                return true;
            }
        }

        return false;
    }

    function calculatePrimesWithinRange(start, end, count) {
        var primesList = [];
        for (var i = start; i < end; i++) {
            if (isPrimeNumber(i)) {
                primesList.push(i);
                if (isCountReached(primesList.length, count)) {
                    break;
                }
            }
        }

        return primesList;
    }

    this.onmessage = function (event) {
        var start = event.data.start;
        var end = event.data.end;
        var count = event.data.count;

        try {
            var result = calculatePrimesWithinRange(start, end, count);
            this.postMessage(result);
        } catch (e) {
            this.postMessage(e.message);
        }
    }

    this.onerror = function (e) {
        this.postMessage(e);
    }
}());