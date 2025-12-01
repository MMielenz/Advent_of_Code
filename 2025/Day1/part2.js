import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./sample.txt", { encoding: "utf-8" })).split("\r\n");
let dialValue = 50;
for (let i = 0; i < data.length; i++) {
    const direction = data[i].substring(0, 1);
    const value = parseInt(data[i].substring(1)) % 100;


    let extraRotations = Math.floor(parseInt(data[i].substring(1)) / 100);


    if (direction === 'L') {
        const newValue = dialValue - value;
        if (newValue < 0) {
            extraRotations = dialValue === 0 ? extraRotations : extraRotations + 1;
            dialValue = 100 + newValue;
        } else {
            dialValue = newValue;
        }
    } else {
        const newValue = dialValue + value;
        if (newValue > 99) {
            extraRotations = dialValue === 0 ? extraRotations : extraRotations + 1;
            dialValue = newValue - 100;
        } else {
            dialValue = newValue;
        }
    }
    console.log(extraRotations);

    result += extraRotations;
}


console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
