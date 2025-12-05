import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./input.txt", { encoding: "utf-8" })).split("\r\n\r\n");

const ranges = data[0].split("\r\n").map(line => {
    const values = line.split('-');
    return ([parseInt(values[0]), parseInt(values[1])]);
});


const starts = ranges.map(r => r[0]);
const ends = ranges.map(r => r[1])


const start = Math.min(...starts);
const end = Math.max(...ends);

for (let i = start; i <= end; i++) {
    // if (ends.indexOf(i) !== -1) {
    //     count = false;
    // }
    const test = starts.indexOf(i);
    if (test !== -1) {
        result += ranges[test][1] - ranges[test][0] + 1
        console.log(result);
        i = test + 1;
    }
}

// const rangesUsed = [];



// for (let i = 0; i < ranges.length; i++) {
//     let from = ranges[i][0];
//     let to = ranges[i][1];

//     for (let j = 0; j < rangesUsed.length; j++) {
//         if (from >= ranges[j][0] && from <= ranges[j][1]) {
//             from = ranges[j][1] + 1;
//             isNewField = false;
//             j = 0;
//         }
//     }

//     for (let j = 0; j < rangesUsed.length; j++) {
//         if (to >= ranges[j][0] && to <= ranges[j][1]) {
//             to = ranges[j][0] - 1;
//             j = 0;
//         }
//     }

//     if (from > to) continue;

//     let rangesBetween = 0;
//     for (let j = 0; j < rangesUsed.length; j++) {
//         if (ranges[j][0] >= from && ranges[j][1] <= to) {
//             rangesBetween += ranges[j][1] - ranges[j][0] + 1
//         }
//     }


//     result += to - from + 1 - rangesBetween
//     rangesUsed.push([from, to])



//     // for (let j = 0; j < ranges.length; j++) {
//     //     if (i === j) continue;
//     //     if (ranges[i][0] >= ranges[j][0] && ranges[i][1] <= ranges[j][1]) {
//     //         ranges[i] = [1, 0];
//     //     } else if (ranges[i][0] > ranges[j][0] && ranges[i][0] < ranges[j][1]
//     //         && ranges[i][1] > ranges[j][1] || ranges[i][0] === ranges[j][1]) {
//     //         ranges[i][0] = ranges[j][1] + 1
//     //     } else if (ranges[i][1] > ranges[j][0] && ranges[i][1] < ranges[j][1]
//     //         && ranges[i][0] < ranges[j][0] || ranges[i][1] === ranges[j][0]) {
//     //         ranges[i][1] = ranges[j][0] - 1
//     //     }
//     // }
// }



// ranges.forEach(range => {
//     result += range[1] - range[0] + 1
// })






console.log(result);
// 352770295514926 too high
// 352770295514895 wrong
// 359861622131172 wrong
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
