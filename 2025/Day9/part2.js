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


const validTiles = [...tiles];
// compute the outline
for (let i = 0; i < tiles.length; i++) {
    const redTile = tiles[i];
    const xNeighbour = tiles.find(t => t.x > redTile.x && t.y === redTile.y);
    const yNeighbour = tiles.find(t => t.y > redTile.y && t.x === redTile.x);

    if (xNeighbour) {
        for (let x = redTile.x + 1; x < xNeighbour.x; x++) {
            validTiles.push({ x, y: redTile.y });
        }
    }

    if (yNeighbour) {
        for (let y = redTile.y + 1; y < yNeighbour.y; y++) {
            validTiles.push({ x: redTile.x, y });
        }
    }
}

// fill the rest
const startY = validTiles.sort((a, b) => a.y - b.y)[0].y + 1;
const endY = validTiles.sort((a, b) => b.y - a.y)[0].y - 1;

for (let y = startY; y < endY; y++) {
    const startX = validTiles.filter(t => t.y === y).sort((a, b) => a.x - b.x)[0].x + 1;
    const endX = validTiles.filter(t => t.y === y).sort((a, b) => b.x - a.x)[0].x - 1;
    for (let x = startX; x < endX; x++) {
        validTiles.push({ x, y });
    }
}



const rectangles = [];
for (let i = 0; i < tiles.length; i++) {
    for (let j = 0; j < tiles.length; j++) {
        if (i === j) continue;
        const otherCorner1 = { x: tiles[i].x, y: tiles[j].y }
        const otherCorner2 = { x: tiles[j].x, y: tiles[i].y }

        if (validTiles.findIndex(t => t.x === otherCorner1.x && t.y === otherCorner1.y) !== -1
            && validTiles.findIndex(t => t.x === otherCorner2.x && t.y === otherCorner2.y) !== -1) {
            rectangles.push(new Rectangle(tiles[i].x, tiles[i].y, tiles[j].x, tiles[j].y));
        }
    }
}

rectangles.sort((a, b) => b.area - a.area);
result = rectangles[0].area;


console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
