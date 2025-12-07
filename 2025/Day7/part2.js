import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./sample.txt", { encoding: "utf-8" })).split(
  "\r\n"
);

const map = new Map();
const makeKey = (x, y) => `${x} ${y}`;
const getMap = (x, y) => map.get(makeKey(x, y));
const setMap = (x, y, value) => {
    const current = getMap(x, y);
    if (current && current.value === '|') {
        map.set(makeKey(x, y), {value: value, beamCount: current.beamCount + 1});
    } else {
        map.set(makeKey(x, y), {value: value, beamCount: 0});
    }
} 

let startX = 0;
const height = data.length;
const width = data[0].length;

for (let y = 0; y < height; y++) {
  for (let x = 0; x < width; x++) {
    const value = data[y][x];
    if (value === "S") startX = x;
    setMap(x, y, value);
  }
}

const searchRow = (y, pattern) => {
  const matches = [];
  for (let x = 0; x < width; x++) {
    const field = getMap(x, y);
    if (field === pattern) matches.push({ x, y });
  }
  return matches;
};

// simulate Beam
setMap(startX, 1, "|");
for (let y = 2; y < height; y++) {
  const beams = searchRow(y - 1, "|");
  const splitters = searchRow(y, "^");

  beams.forEach((b) => {
    const splitter = splitters.find((s) => s.y - 1 === b.y && s.x === b.x);
    if (splitter) {
      setMap(splitter.x - 1, splitter.y, "|");
      setMap(splitter.x + 1, splitter.y, "|");
      result++;
    } else {
      setMap(b.x, b.y + 1, "|");
    }
  });
}

console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
