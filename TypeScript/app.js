"use strict";
// npm init -y
// npm install typescript --save-dev
// npx tsc --init
Object.defineProperty(exports, "__esModule", { value: true });
var arr = [1, 2, 3, 4, 5, 6];
console.log(arr);
var arr1 = ["hello", "hi"];
console.log(arr1[0]);
//Tuple
// coordinate pair x,y
const coord = [1, "2"];
console.log(coord[1]);
const coord1 = [
    [10, [20, 30]],
    [50, [30, 50]],
    [60, [30, -5]]
];
console.log(coord1[0][1]);
//literal
let responseCode;
responseCode = 200;
//enum
var Size;
(function (Size) {
    Size[Size["small"] = 0] = "small";
    Size[Size["Medium"] = 1] = "Medium";
    Size[Size["Large"] = 2] = "Large";
})(Size || (Size = {}));
var size = Size.small;
if (size === Size.small) {
    console.log("Yes");
}
//unknow, Any and Typecasting
//any
let x = 10;
console.log(x.length);
//Unknown
let y = 1;
if (typeof y == "number") {
    let sum = 10 + y;
    console.log(sum);
}
else if (typeof y == "string") {
    var result = y.length;
    console.log(result);
}
//casting
console.log(y + 1);
//Optional Chaining (?.) and Bang Operator (!)
//Optional Chaning
const arr2 = [{ name: "uday" }, { name: "Kella" }];
const el = arr2.pop()?.name;
arr2.forEach(element => {
    const el = arr2.pop()?.name;
    console.log("Element:" + el);
});
console.log("Element:" + el);
const el1 = arr2.pop()?.name;
console.log("Element:" + el1);
//Best example of use of Optional Chaining (?.) and Bang Operator (!)
const arr3 = [[{ name: "Name" }, { age: 10 }]];
const res = arr3.pop()?.pop()?.age;
console.log("First ? pop = " + res);
const res1 = arr3.pop()?.pop()?.age;
console.log("Second ? pop = " + res1);
const arr4 = [[{ name: "Name" }, { age: 10 }]];
const res2 = arr4.pop().pop().age;
console.log("First ! pop = " + res2);
const res3 = arr4.pop()?.pop().age;
console.log("Second ! pop = " + res3);
// Flow:
// arr4.pop() → undefined
// ?. detects undefined
// chain stops immediately
// .pop()!.age never executes
// result becomes undefined safely
//Basic Function Types
function add(x, y) {
    if (typeof x === "number" && typeof y === "number") {
        return `${x + y}`;
    }
    return "Invalid Input...";
}
console.log(add(10, 20));
function makeName(firstName, lastName, middleName) {
    if (!middleName) {
        return `${firstName + " " + lastName}`;
    }
    return `${firstName + " " + middleName + " " + lastName}`;
}
console.log(makeName("uday", "Kella"));
// function chain
function mul(x, y) {
    return x * y;
}
function div(x, y) {
    return x / y;
}
function applyFun(fun, values) {
    for (let i = 0; i < fun.length; i++) {
        const args = values[i];
        const operation = fun[i];
        if (args && operation) {
            const result = operation(args[0], args[1]);
            console.log(result);
        }
    }
}
applyFun([mul, div], [[1, 2], [2, 3]]);
/////Advanced Function Types
//rest parameters
function sum(str, ...numbers) {
    console.log(str + "-" + numbers);
}
sum("Hello", 1, 2, 3);
sum("Hello", 1);
function getOver(name) {
    if (typeof name === "number") {
        return "hi";
    }
    else if (typeof name === "string") {
        return 10;
    }
    return 0;
}
console.log(getOver(1));
const person = {
    name: "tim",
    age: 20,
    hello: function () {
        console.log(this.name);
    }
};
person.hello();
const worker = {
    name: "tim",
    age: 20,
    employeeId: 1,
    hello: function () {
        console.log(this.name + " WorkerId- " + this.employeeId);
    }
};
worker.hello();
//# sourceMappingURL=app.js.map