function hasProperty(obj, prop) {
    if (obj.hasOwnProperty) {
        return obj.hasOwnProperty(prop);
    }
    return prop in obj;
}