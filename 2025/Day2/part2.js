import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./input.txt", { encoding: "utf-8" })).split(',');

for (let i = 0; i < data.length; i++) {
    const start = parseInt(data[i].split("-")[0]);
    const end = parseInt(data[i].split("-")[1]);

    for (let j = start; j <= end; j++) {
        const value = j.toString();
        const indexHalf = Math.floor(value.length / 2);

        for (let k = 1; k <= indexHalf; k++) {
            const remainingHalf = value.substring(k);
            const searchPattern = value.substring(0, k);
            if (remainingHalf.split(searchPattern).findIndex(s => s !== '') === -1) {
                result += j;
                break;
            }
        }
    }
}

console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
