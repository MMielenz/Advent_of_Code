import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./input.txt", { encoding: "utf-8" })).split("\r\n\r\n");

const ranges = data[0].split("\r\n").map(line => {
    const values = line.split('-');
    return ([parseInt(values[0]), parseInt(values[1])]);
});

for (let i = 0; i < ranges.length; i++) {
    for (let j = 0; j < ranges.length; j++) {
        if (i === j) continue;
        if (ranges[i][0] >= ranges[j][0] && ranges[i][1] <= ranges[j][1]) {
            ranges[i] = [0, 0];
        } else if (ranges[i][0] > ranges[j][0] && ranges[i][0] < ranges[j][1]
            && ranges[i][1] > ranges[j][1] || ranges[i][0] === ranges[j][1]) {
            ranges[i][0] = ranges[j][1] + 1
        } else if (ranges[i][1] > ranges[j][0] && ranges[i][1] < ranges[j][1]
            && ranges[i][0] < ranges[j][0] || ranges[i][1] === ranges[j][0]) {
            ranges[i][1] = ranges[j][0] - 1
        }
    }
}
ranges.forEach(range => {
    result += range[1] - range[0] + 1
})






console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
