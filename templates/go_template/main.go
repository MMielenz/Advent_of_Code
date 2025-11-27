package main

import (
	"fmt"

	"github.com/MMielenz/aoc/utils"
)

func part1() int {
	lines := utils.ReadLines("input.txt")
	return len(lines)
}

func part2() int {
	lines := utils.ReadLines("input.txt")
	return len(lines)
}

func main() {
	fmt.Println(part1())
	fmt.Println(part2())
}
