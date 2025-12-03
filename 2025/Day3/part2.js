import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./input.txt", { encoding: "utf-8" })).split('\r\n');

const findBiggestNumber = (text) => {
    for (let j = 9; j >= 1; j--) {
        const index = text.indexOf(j.toString());
        if (index !== -1) {
            const number = text.substring(index, index + 1);
            return [number, index];
        }
    }
}

const numberLength = 12;

for (let i = 0; i < data.length; i++) {
    const bank = data[i];
    let numbers = [];
    let start = 0;
    let buffer = bank.length - numberLength;
    let end = start + buffer + 1

    for (let j = 0; j < numberLength; j++) {
        if (buffer <= 0) {
            numbers.push(bank.substring(start))
            break;
        }
        const potentialNumbers = bank.substring(start, end)
        const [number, index] = findBiggestNumber(potentialNumbers);

        buffer -= index;
        start += index + 1;
        end = start + buffer + 1;

        numbers.push(number);
    }
    let finalNumber = "";
    numbers.forEach(n => finalNumber += n);
    result += parseInt(finalNumber);
}


console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
