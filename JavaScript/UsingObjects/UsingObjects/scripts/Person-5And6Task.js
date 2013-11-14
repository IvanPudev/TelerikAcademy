function person(firstName, lastName, age) {
    return {
        firstName: firstName,
        lastName: lastName,
        age: age,
        toString: function () {
            return "First name: " + this.firstName + ", Last name: " + this.lastName + ", Age: " + this.age;
        }
    }
}
function findYoungest(arr) {
    var youngest = arr[0];
    for (var i = 1; i < arr.length; i++) {
        if (arr[i].age < youngest.age) {
            youngest = arr[i];
        }
    }
    return youngest;
}
function groupBy(arr, prop) {
    switch (prop) {
        case "firstName":
        case "lastName":
        case "age":
            {
                var sorted = {};
                for (var i = 0; i < arr.length; i++) {
                    if (!sorted[prop]) {
                        sorted[prop] = [];
                    }
                    if (arr[i][prop]) {
                        sorted[prop].push(arr[i]);
                    }
                }
                return sorted;
            } 
        default:
            throw new Error("Error message."); break;
    }
}