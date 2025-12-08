import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./input.txt", { encoding: "utf-8" })).split('\r\n');

class JunctionBox {
    constructor(x, y, z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    calculateDiff(other) {
        return Math.sqrt(Math.pow(this.x - other.x, 2) + Math.pow(this.y - other.y, 2) + Math.pow(this.z - other.z, 2))
    }
}

class Distance {
    constructor(box1, box2) {
        this.box1 = box1;
        this.box2 = box2;
        this.distance = box1.calculateDiff(box2);
    }
}


const boxes = [];
data.forEach(line => {
    const cords = line.split(",");
    boxes.push(new JunctionBox(parseInt(cords[0]), parseInt(cords[1]), parseInt(cords[2])))
})

let distances = [];
for (let i = 0; i < boxes.length; i++) {
    for (let j = 0; j < boxes.length; j++) {
        if (i === j) continue;
        distances.push(new Distance(boxes[i], boxes[j]));
    }
}

distances.sort((a, b) => a.distance - b.distance);

const numberConnections = 1000;
const uniqueDistances = [];
for (let i = 0; i < numberConnections; i++) {
    uniqueDistances.push(distances[i * 2])
}

let circuits = [...boxes.map(b => [b])];
for (let i = 0; i < numberConnections; i++) {
    const circuitBox1 = circuits.find(c => c.includes(uniqueDistances[i].box1))
    const circuitBox2 = circuits.find(c => c.includes(uniqueDistances[i].box2))

    if (circuitBox1 === circuitBox2) continue;
    circuits = circuits.filter(c => c !== circuitBox1 && c !== circuitBox2)
    circuits.push([...circuitBox1, ...circuitBox2])
}

circuits.sort((a, b) => b.length - a.length);
result = 1;
for (let i = 0; i < 3; i++) {
    result *= circuits[i].length;
}

console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
