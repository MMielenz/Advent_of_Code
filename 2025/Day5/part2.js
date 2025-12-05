import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./input.txt", { encoding: "utf-8" })).split("\r\n\r\n");

const ranges = data[0].split("\r\n").map(line => {
    const values = line.split('-');
    return ([parseInt(values[0]), parseInt(values[1])]);
}).sort((a, b) => a[0] - b[0]);


let lastRange = 0;
for (let i = 0; i < ranges.length; i++) {
    const start = lastRange + 1 > ranges[i][0] ? lastRange + 1 : ranges[i][0];
    if (start > ranges[i][1]) continue;
    result += ranges[i][1] - start + 1
    lastRange = ranges[i][1];
}


console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
