/// <reference group="Dedicated Worker" />

var isPrime = function (number) {
    for (var i = 2; i < number; i++) {
        if (number % i == 0) {
            return false;
        }

        return true;
    }
};

var calculatePrimes = function (startNum, endNum, countNum) {
    var primes = [];
    var primesCount = 0;

    for (var i = startNum; i <= endNum; i++) {
        if (isPrime(i)) {
            primesCount++;
            primes.push(i);
        }
        else if (countNum && primesCount >= countNum) {
            break;
        }
    }

    return primes;
};

onmessage = function (event) {
    var startNumber = event.data.srartNumber | 0;
    var endNumber = event.data.endNumber | 0;
    var countNumber = event.data.countNumber | 0;

    var primesList = calculatePrimes(startNumber, endNumber, countNumber);

    postMessage(primesList);
};
