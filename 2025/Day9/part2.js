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


const cacheRows = new Map();
const cacheColoums = new Map();
const getRow = (y) => {
    let row = cacheRows.get(y)
    if (!row) {
        row = validTiles.filter(t => t.y === y).sort((a, b) => a.x - b.x);
        cacheRows.set(y, row);
    }
    return row;
}
const getColoumn = (x) => {
    let coloumn = cacheColoums.get(x)
    if (!coloumn) {
        coloumn = validTiles.filter(t => t.x === x).sort((a, b) => a.y - b.y);
        cacheColoums.set(x, coloumn);
    }
    return coloumn;
}


const tiles = [];
data.forEach(line => {
    const values = line.split(",");
    tiles.push({ x: parseInt(values[0]), y: parseInt(values[1]) });
})


const horizontalLines = [];
const verticalLines = [];

const validTiles = [...tiles];
// compute the outline
for (let i = 0; i < tiles.length; i++) {
    const redTile = tiles[i];
    const xNeighbour = tiles.find(t => t.x > redTile.x && t.y === redTile.y);
    const yNeighbour = tiles.find(t => t.y > redTile.y && t.x === redTile.x);


    if (xNeighbour) {
        horizontalLines.push([redTile.y, redTile.x, xNeighbour.x])
        for (let x = redTile.x + 1; x < xNeighbour.x; x++) {
            validTiles.push({ x, y: redTile.y });
        }
    }

    if (yNeighbour) {
        verticalLines.push([redTile.x, redTile.y, yNeighbour.y])
        for (let y = redTile.y + 1; y < yNeighbour.y; y++) {
            validTiles.push({ x: redTile.x, y });
        }
    }
}

console.log("eingelesen")

// // // fill the rest
// const startY = validTiles.sort((a, b) => a.y - b.y)[0].y + 1;
// const endY = validTiles.sort((a, b) => b.y - a.y)[0].y;


// const filledTiles = [];
// console.log("tets")
// for (let y = startY; y < endY; y++) {
//     const row = getRow(y);
//     let x = row[0].x + 1;
//     while (x < row[row.length - 1].x) {
//         if (!row.find(r => r.x === x)) {
//             filledTiles.push({ x, y });
//         }
//         x++;
//     }
// }
// console.log("akjasf")



// const stuff = []
// for (let i = 0; i < 9; i++) {
//     stuff.push([]);
//     for (let j = 0; j < 14; j++) {
//         stuff[i].push('.')
//     }
// }
// validTiles.forEach(t => stuff[t.y][t.x] = 'X');
// stuff.forEach(s => {
//     let string = "";
//     s.forEach(s => string += s);
//     console.log(string);
// })




const cacheValidFields = new Map();
const makekey = (x, y) => `${x}-${y}`;

const isInField = ({ x, y }) => {
    // return true;
    const key = makekey(x, y);
    let result = cacheValidFields.get(key);
    if (result === undefined) {
        const row = getRow(y);
        if (row.find(p => p.x === x)) {
            cacheValidFields.set(key, true);
            return true;
        }
        const bordersCrossed = row.filter(p => p.x >= x).length;
        result = bordersCrossed % 2 === 1
        cacheValidFields.set(key, result);
    }
    return result;

    if (row.find(r => r.x === x)) {
        return true;
    }
    return false;

    if (x == 9 && y == 5) {
        console.log
    }


    // return true;
    // return x >= row[0] && x <= row[row.length - 1] && y >= coloumn[0] && y <= coloumn[coloumn.length - 1]

    let isInRow = false;
    for (let i = 1; i < row.length; i++) {
        if (x <= row[i].x && x >= row[i - 1].x) {
            isInRow = true;
            break;
        }
    }

    if (!isInRow) return false;
    const coloumn = getColoumn(x);

    let isInColoumn = false;
    for (let i = 1; i < coloumn.length; i++) {
        if (y <= coloumn[i].y && y >= coloumn[i - 1].y) {
            isInColoumn = true;
            break;
        }
    }

    if (!isInColoumn) return false;

    return true;
}

const isSideValid = (point1, point2) => {
    // const horizontal = point1.y === point2.y
    // if (point1.x === point2.x && point1.y === point2.y) {
    //     return true;
    // }

    // if (horizontal) {
    //     let left;
    //     let right;
    //     if (point1.x < point2.x) {
    //         left = point1.x
    //         right = point2.x;
    //     } else {
    //         left = point2.x
    //         right = point1.x;
    //     }
    //     return horizontalLines.findIndex(l => l[0] === point1.y && l[1] <= left && l[2] >= right) !== -1
    // } else {
    //     let top;
    //     let bottom;
    //     if (point1.y < point2.y) {
    //         top = point1.y;
    //         bottom = point2.y;
    //     } else {
    //         top = point2.y;
    //         bottom = point1.y;
    //     }
    //     return verticalLines.findIndex(l => l[0] === point1.x && l[1] <= top && l[2] >= bottom) !== -1
    // }





    const sameHeight = point1.y === point2.y ? true : false;
    const distance = sameHeight ? point1.x - point2.x : point1.y - point2.y;
    const abs = Math.abs(distance) + 1;
    for (let i = 0; i < abs; i++) {
        if (sameHeight) {
            if (!isInField({ x: distance < 0 ? point1.x + i : point1.x - i, y: point1.y })) {
                return false;
            }
        } else {
            if (!isInField({ x: point1.x, y: distance < 0 ? point1.y + i : point1.y - i })) {
                return false;
            }
        }
    }
    return true;
}


const rectangles = [];
for (let i = 0; i < tiles.length; i++) {
    for (let j = 0; j < tiles.length; j++) {
        if (i === j) continue;

        // let vektor = { x: tiles[i].x - tiles[j].x, y: tiles[i].y - tiles[j].y };
        // for (let x = 0; x < Math.abs(vektor.x); x++) {
        //     if (!isInField({ x: tiles[i].x + x, y: tiles[i].y })) {
        //         continue;
        //    }
        // }
        // for (let y = 0; y < Math.abs(vektor.y); y++) {
        //     if (!isInField({ x: tiles[i].x + x, y: tiles[i].y })) {
        //         continue;
        //     }
        // }
        // for (let x = 0; x < Math.abs(vektor.x); x++) {
        //     if (!isInField({ x: tiles[j].x + x, y: tiles[j].y })) {
        //         continue;
        //     }
        // }
        // for (let y = 0; y < Math.abs(vektor.y); y++) {
        //     if (!isInField({ x: tiles[i].x + x, y: tiles[i].y })) {
        //         continue;
        //     }
        // }

        // if (tiles[i].y > tiles[j].y) {

        // }

        // for (let x = 0; x < Math.abs(tiles[i].x - tiles[j].x); x++) {

        // }

        if (tiles[i].x === 9 && tiles[i].y === 5 && tiles[j].x === 2 && tiles[j].y === 3) {
            console.log()
        }

        const otherCorner1 = { x: tiles[i].x, y: tiles[j].y }
        const otherCorner2 = { x: tiles[j].x, y: tiles[i].y }

        if (isSideValid(tiles[i], otherCorner1) && isSideValid(tiles[i], otherCorner2)
            && isSideValid(tiles[j], otherCorner1) && isSideValid(tiles[j], otherCorner2)) {
            rectangles.push(new Rectangle(tiles[i].x, tiles[i].y, tiles[j].x, tiles[j].y));
            console.log("valid rectangle");
        }
    }
}

rectangles.sort((a, b) => b.area - a.area);
result = rectangles[0].area;


console.log(result);
// 4620654558 too high
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
