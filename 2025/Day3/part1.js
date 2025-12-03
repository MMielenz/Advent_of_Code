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

for (let i = 0; i < data.length; i++) {
    const [firstNumber, index] = findBiggestNumber(data[i].substring(0, data[i].length - 1));
    const [secondNumber] = findBiggestNumber(data[i].substring(index + 1));
    result += parseInt(firstNumber + secondNumber);
}



console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
