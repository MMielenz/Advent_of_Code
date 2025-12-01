import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./input.txt", { encoding: "utf-8" })).split("\r\n");
let dialValue = 50;
for (let i = 0; i < data.length; i++) {
    const direction = data[i].substring(0, 1);
    const value = parseInt(data[i].substring(1)) % 100;

    if (direction === 'L') {
        const newValue = dialValue - value;
        dialValue = newValue < 0 ? 100 + newValue : newValue;
    } else {
        const newValue = dialValue + value;
        dialValue = newValue > 99 ? newValue - 100 : newValue;
    }

    result = dialValue === 0 ? result + 1 : result;
}


console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
