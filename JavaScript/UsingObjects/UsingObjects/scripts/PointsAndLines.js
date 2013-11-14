function point(x, y) {
    return {
        x: x,
        y: y,
        toString: function () {
            return "Point(" + this.x + ", " + this.y + ")";
        }
    }
}

function line(startPoint, endPoint) {
    return {
        startPoint: startPoint,
        endPoint: endPoint,
        toString: function () {
            return "Line(" + this.startPoint + ", " + this.endPoint + ")";
        }
    }
}

function calculateDistance(startPoint, endPoint) {
    return Math.sqrt((endPoint.x - startPoint.x) * (endPoint.x - startPoint.x) + (endPoint.y - startPoint.y) * (endPoint.y - startPoint.y));
}

function checkTriangleForm(firstLine, secondLine, thirdLine) {
    var a = calculateDistance(firstLine.startPoint, firstLine.endPoint);
    var b = calculateDistance(secondLine.startPoint, secondLine.endPoint);
    var c = calculateDistance(thirdLine.startPoint, thirdLine.endPoint);
    if (a + b > c && a + c > b && b + c > a) {
        return true;
    }
    return false;
}