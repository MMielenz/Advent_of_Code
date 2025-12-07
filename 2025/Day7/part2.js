import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./input.txt", { encoding: "utf-8" })).split(
  "\r\n"
);

const map = new Map();
const makeKey = (x, y) => `${x} ${y}`;
const getMap = (x, y) => map.get(makeKey(x, y));
const setMap = (x, y, value) => {
  const current = getMap(x, y);
  if (current && current.symbol === "|") {
    map.set(makeKey(x, y), {
      symbol: value.symbol,
      beamCount: current.beamCount + value.beamCount,
    });
  } else {
    map.set(makeKey(x, y), value);
  }
};

let startX = 0;
const height = data.length;
const width = data[0].length;

for (let y = 0; y < height; y++) {
  for (let x = 0; x < width; x++) {
    const value = data[y][x];
    if (value === "S") startX = x;
    setMap(x, y, { symbol: value });
  }
}

const searchRow = (y, pattern) => {
  const matches = [];
  for (let x = 0; x < width; x++) {
    const field = getMap(x, y);
    if (field.symbol === pattern)
      matches.push({ x, y, beamCount: field.beamCount });
  }
  return matches;
};

// simulate Beam
setMap(startX, 1, { symbol: "|", beamCount: 1 });
for (let y = 2; y < height; y++) {
  const beams = searchRow(y - 1, "|");
  const splitters = searchRow(y, "^");

  beams.forEach((b) => {
    const splitter = splitters.find((s) => s.y - 1 === b.y && s.x === b.x);
    if (splitter) {
      setMap(splitter.x - 1, splitter.y, {
        symbol: "|",
        beamCount: b.beamCount,
      });
      setMap(splitter.x + 1, splitter.y, {
        symbol: "|",
        beamCount: b.beamCount,
      });
    } else {
      setMap(b.x, b.y + 1, { symbol: "|", beamCount: b.beamCount });
    }
  });
}


searchRow(height-1, '|').forEach(b => {
  result += b.beamCount
});

console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
