import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./input.txt", { encoding: "utf-8" })).split(
  "\r\n"
);

const equations = [];
for (let i = 0; i < data.length - 1; i++) {
  const matches = data[i].match(/\d+/g).map(m => parseInt(m));
  if (i === 0) {
    for (let j = 0; j < matches.length; j++) {
      equations.push({ numbers: [matches[j]] });
    }
    continue;
  }
  for (let j = 0; j < matches.length; j++) {
    equations[j].numbers.push(matches[j]);
  }
}

const operators = data[data.length - 1].match(/[+*]/g);
for (let i = 0; i < operators.length; i++) {
    if (operators[i] === '+') {
        for (let j = 0; j < equations[i].numbers.length; j++) {
            result += equations[i].numbers[j];
        }
    } else {
        let product = 1;
        for (let j = 0; j < equations[i].numbers.length; j++) {
            product *= equations[i].numbers[j];
        }
        result += product;
    }
}

console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
