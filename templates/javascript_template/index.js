import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = await fs.readFile("./input.txt", { encoding: "utf-8" });




console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
