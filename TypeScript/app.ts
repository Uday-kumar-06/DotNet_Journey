// npm init -y
// npm install typescript --save-dev
// npx tsc --init

var arr = [1,2,3,4,5,6];

console.log(arr);

var arr1: string [] = ["hello","hi"];
console.log(arr1[0]);

//Tuple
// coordinate pair x,y
const coord: [number,string] = [1,"2"];
console.log(coord[1]);

const coord1: [number, number[]][] = [
    [10, [20, 30]],
    [50, [30, 50]],
    [60, [30, -5]]
];
console.log(coord1[0]![1]);


//literal
let responseCode: 200| 404 | 201;

responseCode = 200;

//enum
enum Size{
    small,
    Medium,
    Large
}

var size : Size = Size.small

if(size === Size.small){
    console.log("Yes");
}

//unknow, Any and Typecasting
//any
let x :any = 10;
console.log(x.length);

//Unknown
let y : unknown = 1;
if(typeof y == "number"){
    let sum: number = 10 +y;
    console.log(sum);
}else if(typeof y == "string"){
    var result = y.length
    console.log(result);
}

//casting
console.log((y as number)+1);


//Optional Chaining (?.) and Bang Operator (!)

//Optional Chaning
const arr2 = [{name: "uday"},{name: "Kella"}];

const el =  arr2.pop()?.name;

arr2.forEach(element => {
    const el =  arr2.pop()?.name;
    console.log("Element:"+el);
});
console.log("Element:"+el); 
const el1 =  arr2.pop()?.name;
console.log("Element:"+el1);

//Best example of use of Optional Chaining (?.) and Bang Operator (!)
const arr3 = [[{name:"Name"},{age:10}]];

const res = arr3.pop()?.pop()?.age;
console.log("First ? pop = "+res);

const res1 = arr3.pop()?.pop()?.age;
console.log("Second ? pop = "+res1);

const arr4 = [[{name:"Name"},{age:10}]];
const res2 = arr4.pop()!.pop()!.age;
console.log("First ! pop = "+res2);

const res3 = arr4.pop()?.pop()!.age;
console.log("Second ! pop = "+res3);
// Flow:
// arr4.pop() → undefined
// ?. detects undefined
// chain stops immediately
// .pop()!.age never executes
// result becomes undefined safely

//Basic Function Types
function add(x: unknown ,y:unknown):string{
    if(typeof x === "number" && typeof y === "number"){
        return `${x+y}`;
    }
    return "Invalid Input...";
}

console.log(add(10,20));

function makeName(firstName:string, lastName:string, middleName?:string): string{
    if(!middleName){
        return `${firstName +" "+ lastName}`;
    }
    return `${firstName +" "+ middleName+" "+ lastName}`;
}

console.log(makeName("uday","Kella"));
// function chain
function mul(x : number, y: number): number{
    return x*y;
}
function div(x : number, y: number): number{
    return x/y;
}
function applyFun(fun: ((n1:number,n2:number)=>number)[], values: [number,number][]): void{
    for (let i: number = 0; i < fun.length; i++) {

        const args = values[i];
        const operation = fun[i];

        if (args && operation) {

            const result = operation(args[0], args[1]);

            console.log(result);
        }
    }
}

applyFun([mul,div],[[1,2],[2,3]]);

/////Advanced Function Types

//rest parameters
function sum(str:string,...numbers: number[]){
    console.log(str+"-"+numbers);
}

sum("Hello",1,2,3);
sum("Hello",1);

//overloaded
function getOver(name:string):number;
function getOver(name:number):string;
function getOver(name:unknown):unknown{
    if(typeof name === "number"){
        return "hi";
    }else if(typeof name === "string"){
        return 10;
    }
    return 0;
}

console.log(getOver(1));

///Interface
interface Person{
    name :string;
    age: number;
    height?: number;
    hello: ()=>void;
}

const person: Person ={
    name : "tim",
    age:20,
    hello: function(){
        console.log(this.name);
    }
}
person.hello();

interface Employees extends Person{
    employeeId: number;
}

const worker: Employees={
    name : "Tim",
    age:20,
    employeeId:1,
    hello: function(){
        console.log(this.name+" WorkerId- "+ this.employeeId);
    }
}
worker.hello();

//Generic
class DataStore<T>{
    private items: T [] = [];
}

const data = new DataStore<string>();

//Type alias
type stringOrNumber = string | number;

let n : stringOrNumber = 1;

//Type Gaurd
function add1(value: stringOrNumber): number{
    if(typeof value === "number"){
        return 1;
    }
    return 0;
}

//Utility Types
interface Todo{
    title:string;
    description:string;
}

//Todo

const updateTodo = (todo: Partial<Todo>) =>{
    todo.description = "hetear";
};

//Record
interface PageInfo{
    title:string;
}

const pages: Record<string, PageInfo> = {
    home : {title:"Hello"},
    about :{title:"World"}
}