Array.prototype.removeElement = function (number) {
    var result = [];
    for (var i = 0; i < this.length; i++) {
        if (this[i] !== number) {
            result.push(this[i])
        }
    }
    return result;
}