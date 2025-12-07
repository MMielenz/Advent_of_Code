import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./input.txt", { encoding: "utf-8" })).split(
  "\r\n"
);


const worksheet = new Map();
const getWorksheetField = (x, y) => worksheet.get(`${x}-${y}`);

const width = data[0].length;
const height = data.length;

for (let y = 0; y < height - 1; y++) {
  const row = data[y].split("");
  for (let x = 0; x < width; x++) {
    worksheet.set(`${x}-${y}`, row[x]);
  }
}

const operatorsLine = data[data.length - 1];
const operators = operatorsLine.match(/[+*]/g);
const operatorIndeces = [];
for (let i = 0; i < operatorsLine.length; i++) {
  if (operatorsLine[i] !== " ") {
    operatorIndeces.push(i);
  }
}

let operatorIndex = operators.length - 1;

let operationNumbers = [];
for (let x = width - 1; x >= 0; x--) {
  let number = "";
  for (let y = 0; y < height - 1; y++) {
    number += getWorksheetField(x, y);
  }
  operationNumbers.push(parseInt(number.trim()));
  if (operatorIndeces.includes(x)) {
    if (operators[operatorIndex] === "+") {
      operationNumbers.forEach((n) => (result += n));
    } else {
      let product = 1;
      for (let i = 0; i < operationNumbers.length; i++) {
        product *= operationNumbers[i];
      }
      result += product;
    }
    operationNumbers = [];
    operatorIndex--;
    x--;
  }
}

console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
