import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./input.txt", { encoding: "utf-8" })).split("\r\n");

class Rectangle {
    constructor(x1, y1, x2, y2) {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        this.area = (Math.abs(x1 - x2) + 1) * (Math.abs(y1 - y2) + 1)
    }
}

const tiles = [];
data.forEach(line => {
    const values = line.split(",");
    tiles.push({ x: parseInt(values[0]), y: parseInt(values[1]) });
})


const rectangles = [];
for (let i = 0; i < tiles.length; i++) {
    for (let j = 0; j < tiles.length; j++) {
        if (i === j) continue;
        rectangles.push(new Rectangle(tiles[i].x, tiles[i].y, tiles[j].x, tiles[j].y));
    }
}

rectangles.sort((a, b) => b.area - a.area);
result = rectangles[0].area;


console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
