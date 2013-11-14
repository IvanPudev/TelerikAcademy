if (!Object.create) {
    Object.create = function (obj) {
        function f() { };
        f.prototype = obj;
        return new f();
    }
}

if (!Object.prototype.extend) {
    Object.prototype.extend = function (properties) {
        function f() { };
        f.prototype = Object.create(this);
        for (var prop in properties) {
            f.prototype[prop] = properties[prop];
        }
        f.prototype._super = this;
        return new f();
    }
}

var SchoolRepository = (function () {
    var School = {
        init: function (name, town) {
            this.name = name;
            this.town = town;
            this.classes = [];
        },

        addClass: function (schoolClass) {
            this.classes.push(schoolClass);
        },

        toString: function () {
            return "Name: " + this.name + ", Town: " + this.town;
        }
    };

    var SchoolClass = {
        init: function (name, formTeacher, capacity) {
            this.name = name;
            this.formTeacher = formTeacher;
            this.capacity = capacity;
            this.students = [];
        },

        addStudent: function (student) {
            if (this.students.length < this.capacity) {
                this.students.push(student);
            }
            else {
                alert("This class is already full! " + student.printID() + " didn't make it!");
            }
        },

        toString: function () {
            return "Name: " + this.name + ", Form Teacher: " + this.formTeacher.fname + " " + this.formTeacher.lname;
        }
    };

    var Person = {
        init: function (fname, lname, age) {
            this.fname = fname;
            this.lname = lname;
            this.age = age;
        },

        printID: function () {
            return "Name: " + this.fname + " " + this.lname + ", Age: " + this.age;
        }
    };

    var Teacher = Person.extend({
        init: function (fname, lname, age, speciality) {
            Person.init.apply(this, arguments);
            this.speciality = speciality;
        },

        printID: function () {

            return Person.printID.apply(this) + ", Speciality: " + this.speciality;
        }
    });

    var Student = Person.extend({
        init: function (fname, lname, age, grade) {
            Person.init.apply(this, arguments);
            this.grade = grade;
        },

        printID: function () {

            return Person.printID.apply(this) + ", Grade: " + this.grade;
        }
    });

    return {
        School: School,
        SchoolClass: SchoolClass,
        Teacher: Teacher,
        Student: Student,
    };
}());

var student1 = Object.create(SchoolRepository.Student);
student1.init("Ivan", "Ivanov", 18, 12);

var student2 = Object.create(SchoolRepository.Student);
student2.init("Georgi", "Georgiev", 17, 11);

console.log(student1.printID());
console.log(student2.printID());

var teacher = Object.create(SchoolRepository.Teacher);
teacher.init("Daskal", "Daskalov", 40, "Informatics");
console.log(teacher.printID());

var js = Object.create(SchoolRepository.SchoolClass);
js.init("JavaScript", teacher, 2);
console.log(js.toString());
js.addStudent(student1);
js.addStudent(student2);
console.log("Number of students in JS class: " + js.students.length);

var theLateOne = Object.create(SchoolRepository.Student);
theLateOne.init("Too", "Late", 75, 2);
js.addStudent(theLateOne);

var academy = Object.create(SchoolRepository.School);
academy.init("Telerik Academy", "Sofia");
academy.addClass(js);
console.log(academy.toString());

student1.fname = "Dragan";
console.log(student1.printID());