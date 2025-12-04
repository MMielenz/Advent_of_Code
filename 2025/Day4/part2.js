import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./input.txt", { encoding: "utf-8" })).split('\r\n');

// vektor rotation
const computeNewVektor = (x, y, alpha) => {
    const newX = Math.round(x * Math.cos(alpha) - y * Math.sin(alpha));
    const newY = Math.round(x * Math.sin(alpha) + y * Math.cos(alpha));
    return [newX, newY];
}

const field = data.map(line => [...line]);
const height = field.length;
const width = field[0].length;

let removedSomePaper = false;

do {
    removedSomePaper = false;
    for (let y = 0; y < height; y++) {
        for (let x = 0; x < width; x++) {

            if (field[y][x] === '@') {
                let vektorX = 1;
                let vektorY = 1;
                let neigbouredRoles = 0;
                const rotations = 8;

                for (let i = 0; i < rotations; i++) {
                    const neighborX = x + vektorX;
                    const neighborY = y + vektorY;
                    if (neighborX >= 0 && neighborX < width
                        && neighborY >= 0 && neighborY < height
                        && field[neighborY][neighborX] === '@'
                    ) {
                        neigbouredRoles++;
                    }
                    [vektorX, vektorY] = computeNewVektor(vektorX, vektorY, 360 / rotations);
                }
                if (neigbouredRoles < 4) {
                    field[y][x] = '.'
                    result++;
                    removedSomePaper = true
                }
            }
        }
    }
} while (removedSomePaper)


console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
