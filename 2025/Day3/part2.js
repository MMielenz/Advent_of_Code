import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./sample.txt", { encoding: "utf-8" })).split('\r\n');

const findBiggestNumber = (text) => {
    for (let j = 9; j >= 1; j--) {
        const index = text.indexOf(j.toString());
        if (index !== -1) {
            const number = text.substring(index, index + 1);
            return [number, index];
        }
    }
}

for (let i = 0; i < data.length; i++) {
    let numbers = [];
    let start = 0;
    let buffer = data[i].length - 12;
    let end = start + buffer
    for (let j = 0; j < 12; j++) {
        const text = data[i].substring(start, end)
        const [number, index] = findBiggestNumber(text);
        start += index + 1;
        buffer -= index;
        end = start + buffer + 1;
        if (end >= data[i].length) {
            numbers.push(data[i].substring(start, end))
            break;
        }
        numbers.push(number);
    }
    let finalNumber = "";
    numbers.forEach(n => finalNumber += n);
    console.log(finalNumber);
    result += parseInt(finalNumber);
}



console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
