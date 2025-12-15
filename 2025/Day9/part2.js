import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./input.txt", { encoding: "utf-8" })).split("\r\n");

class Cache {
    maxSize = 1_000_000
    constructor() {
        this.maps = [new Map()];
    }



    getValue(key) {
        let value = undefined;
        for (let i = 0; i < this.maps.length; i++) {
            value = this.maps[i].get(key);
            if (value !== undefined) {
                return value;
            }
        }
        return value;


    }

    setValue(key, value) {
        const map = this.maps[this.maps.length - 1];
        map.set(key, value);
        if (map.size > this.maxSize) {
            this.maps.push(new Map())
            console.log("New Map")
        }
    }
}

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

const cache = new Cache();


// const makeKey(x, y) {
//     return `${x}-${y}`
// }

for (const { x, y } of tiles) {
    if (cache.getValue(y) === undefined) cache.setValue(y, []);
    cache.getValue(y).push(x);
}

// const row = getRow(y);
// if (row.find(p => p.x === x)) {
//     value = true;
// } else {
//     const bordersCrossed = row.filter(p => p.x >= x).length;
//     value = bordersCrossed % 2 === 1
// }

// return value;

// const validTiles = [...tiles];
// // compute the outline
// for (let i = 0; i < tiles.length; i++) {
//     const redTile = tiles[i];
//     const xNeighbour = tiles.find(t => t.x > redTile.x && t.y === redTile.y);
//     const yNeighbour = tiles.find(t => t.y > redTile.y && t.x === redTile.x);


//     if (xNeighbour) {
//         // horizontalLines.push([redTile.y, redTile.x, xNeighbour.x])
//         for (let x = redTile.x + 1; x < xNeighbour.x; x++) {
//             validTiles.push({ x, y: redTile.y });
//         }
//     }

//     if (yNeighbour) {
//         // verticalLines.push([redTile.x, redTile.y, yNeighbour.y])
//         for (let y = redTile.y + 1; y < yNeighbour.y; y++) {
//             validTiles.push({ x: redTile.x, y });
//         }
//     }
// }

const cacheRows = new Map();
function getRow(y) {
    let row = cacheRows.get(y)
    if (!row) {
        row = validTiles.filter(t => t.y === y).sort((a, b) => a.x - b.x);
        cacheRows.set(y, row);
    }
    return row;
}



const megaCache = new Cache();
const isSideValid = (point1, point2) => {
    const sameHeight = point1.y === point2.y ? true : false;
    const distance = sameHeight ? point1.x - point2.x : point1.y - point2.y;
    const abs = Math.abs(distance) + 1;
    for (let i = 0; i < abs; i++) {
        if (sameHeight) {
            if (!megaCache.isFieldValid({ x: distance < 0 ? point1.x + i : point1.x - i, y: point1.y })) {
                return false;
            }
        } else {
            if (!megaCache.isFieldValid({ x: point1.x, y: distance < 0 ? point1.y + i : point1.y - i })) {
                return false;
            }
        }
    }
    return true;
}


let distances = [];
for (let i = 0; i < tiles.length; i++) {
    for (let j = i + 1; j < tiles.length; j++) {
        if (i === j) continue;
        distances.push({ p1: tiles[i], p2: tiles[j], d: Math.abs(tiles[i].x - tiles[j].x) + Math.abs(tiles[i].y - tiles[j].y) })
    }
}
distances.sort((a, b) => b.d - a.d);
// distances = distances.filter((_, index) => index % 2 === 0)
for (let i = 0; i < distances.length; i++) {
    const { p1, p2 } = distances[i];
    const otherCorner1 = { x: p1.x, y: p2.y }
    const otherCorner2 = { x: p2.x, y: p1.y }

    if (isSideValid(p1, otherCorner1) && isSideValid(p1, otherCorner2)
        && isSideValid(p2, otherCorner1) && isSideValid(p2, otherCorner2)) {
        const rect = new Rectangle(p1.x, p1.y, p2.x, p2.y);
        result = rect.area;
        break;
    }
}


console.log(result);
// 4620654558 too high
// 214512750  too low
// 214108934  too low


const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
