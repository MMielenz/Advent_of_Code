import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./input.txt", { encoding: "utf-8" })).split("\r\n");
let dialValue = 50;

for (let i = 0; i < data.length; i++) {
    const direction = data[i].substring(0, 1);
    const value = parseInt(data[i].substring(1)) % 100;

    let zeroPassed = Math.floor(parseInt(data[i].substring(1)) / 100);

    if (direction === 'L') {
        const newValue = dialValue - value;
        if (newValue < 0) {
            zeroPassed = dialValue === 0 ? zeroPassed : zeroPassed + 1;
            dialValue = 100 + newValue;
        } else {
            dialValue = newValue;
        }
        zeroPassed = dialValue === 0 ? zeroPassed + 1 : zeroPassed
    } else {
        const newValue = dialValue + value;
        if (newValue > 99) {
            zeroPassed = dialValue === 0 ? zeroPassed : zeroPassed + 1;
            dialValue = newValue - 100;
        } else {
            dialValue = newValue;
        }
    }
    result += zeroPassed;
}


console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
