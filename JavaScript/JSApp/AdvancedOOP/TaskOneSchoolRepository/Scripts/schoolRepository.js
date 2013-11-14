var Class = (function () {
    function createClass(properties) {
        var f = function () {
            
            if (this._superConstructor) {
                this._super = new this._superConstructor(arguments);
            }

            this.init.apply(this, arguments);
        }
        for (var prop in properties) {
            f.prototype[prop] = properties[prop];
        }
        if (!f.prototype.init) {
            f.prototype.init = function () { }
        }
        return f;
    }

    Function.prototype.inherit = function (parent) {
        var oldPrototype = this.prototype;
        this.prototype = new parent();
        this.prototype._superConstructor = parent;
        for (var prop in oldPrototype) {
            this.prototype[prop] = oldPrototype[prop];
        }
    }

    return {
        create: createClass,
    };
}());

var SchoolRepository = (function () {
    
    var School = Class.create({
        init: function (name, city) {
            this.name = name;
            this.city = city;
            this.classes = [];
        },

        addClass: function (schoolClass) {
            this.classes.push(schoolClass);
        },

        toString: function () {
            return "Name: " + this.name + ", City: " + this.city;
        }
    });

    var SchoolClass = Class.create({
        init: function (name, formTeacher, classCapacity) {
            this.name = name;
            this.formTeacher = formTeacher;
            this.classCapacity = classCapacity;
            this.studentsSet = [];
        },

        addStudent: function(student){
            if (this.studentsSet.lenght < this.classCapacity) {
                this.studentsSet.push(student);
            }
            else {
                alert("the class is awlready full. " +
                    student.PrintID() + "cannot be added to this class.");
            }
        },

        toString: function () {
            return "Name: " + this.name + ", Form Teacher: " + this.formTeacher.fname + " " + this.formTeacher.lname;
        }
    });

    var Person = Class.create({
        init: function (fName, lName, age) {
            this.fName = fName;
            this.lName = lName;
            this.age = age;
        },

        printID: function () {
            return "Name: " + this.fName + " " + this.lName +
                ", Age: " + this.age;
        }
    });

    var Teacher = Class.create({
        init: function (fName, lName, age, specialty) {
            this._super.init(fName, lName, age);
            this.specialty = specialty;
        },

        PrintID: function () {
            return this._super.printID() + ", Specialty: " + this.specialty;
        }
    });

    Teacher.inherit(Person);

    var Student = Class.create({
        init: function (fName, lName, age, grade) {
            this._super.init(fName, lName, age);
            this.grade = grade;
        },

        PrintID: function () {
            return this._super.printID() + ", Grade: " + this.grade;
        }
    });

    Student.inherit(Person);

    return {
        School: School,
        SchoolClass: SchoolClass,
        Person: Person,
        Teacher: Teacher,
        Student: Student
    };
}());

var student1 = new SchoolRepository.Student("Ivan", "Ivanov", 18, 12);
var student2 = new SchoolRepository.Student("Georgi", "Georgiev", 17, 11);
console.log(student1.printID());
console.log(student2.printID());

var teacher = new SchoolRepository.Teacher("Daskal", "Daskalov", 40, "Informatics");
console.log(teacher.printID());

var js = new SchoolRepository.SchoolClass("JavaScript", teacher, 2);
console.log(js.toString());
js.addStudent(student1);
js.addStudent(student2);
console.log("Number of students in JS class: " + js.students.lenght);

var theLateOne = new SchoolRepository.Student("Too", "Late", 75, 2);
js.addStudent(theLateOne);

var academy = new SchoolRepository.School("Telerik Academy", "Sofia");
academy.addClass(js);
console.log(academy.toString());

student1.fName = "Dragan";
console.log(student1.printID());