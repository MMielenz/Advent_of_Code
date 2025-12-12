import fs from "fs/promises";

const startTime = performance.now();
let result = 0;

const data = (await fs.readFile("./sample.txt", { encoding: "utf-8" })).split('\r\n');

const stripParantheses = (str) => str.substring(1, str.length - 1);

const buttonPush = (current, button) => {
    let newState = '';
    for (let i = 0; i < current.length; i++) {
        if (button[i] === '#') {
            newState += current[i] === '#' ? '.' : '#';
        } else {
            newState += current[i];
        }
    }
    return newState;
    button.forEach(index => {
        current[i] = !current[i];
    })
    return current;
}

const search = (state, buttons, goal, searchDetph) => {
    const newStates = [];
    for (let i = 0; i < buttons.length; i++) {
        const newState = buttonPush(state, buttons[i]);
        if (newState === goal) {
            return searchDetph;

        }newStates.push();
    }
    newStates.forEach(s => search(s, buttons, goal, searchDetph + 1))
}

data.forEach(line => {
    const values = line.split(" ").map(v => stripParantheses(v));
    // const goal = values[0].split('').map(c => c === '.' ? false : true);
    const goal = values[0]

    const buttons = [];
    for (let i = 1; i < values.length - 1; i++) {
        // buttons.push(values[i].split(",").map(v => parseInt(v)));
        const indeces = values[i].split(",").map(v => parseInt(v));
        let buttonState = "";
        for (let j = 0; j < goal.length; j++) {
            buttonState += indeces.includes(j) ? '#' : '.';
        }
        buttons.push(buttonState);
    }

    for (let i = 0; i < buttons.length; i++) {
        result = search(buttons[i], buttons, goal, 1);
    }

    console.log("")

})



console.log(result);
const endTime = performance.now();
console.log(`The script took ${(endTime - startTime).toFixed(2)} milliseconds`);
