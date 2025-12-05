import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./input.txt", { encoding: "utf-8" })).split("\r\n\r\n");

const ranges = data[0].split("\r\n").map(line => {
    const values = line.split('-');
    return ([parseInt(values[0]), parseInt(values[1])]);
});
const ids = data[1].split("\r\n").map(line => parseInt(line));

ids.forEach(id => {
    let isFresh = false;
    ranges.forEach(range => {
        if (id >= range[0] && id <= range[1]) {
            isFresh = true;
            return;
        }
    })

    result = isFresh ? result + 1 : result;
})


console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
