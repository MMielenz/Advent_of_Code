package main

import (
	"fmt"
	"time"

	"github.com/MMielenz/aoc/utils"
)

func part1() int {
	result := 0
	utils.ReadLines("sample.txt")

	return result
}

func part2() int {
	result := 0
	utils.ReadLines("sample.txt")

	return result
}

func main() {
	start := time.Now()
	fmt.Println(part1())
	elapsed := time.Since(start)
	fmt.Println("Time: " + elapsed.String())

	start = time.Now()
	fmt.Println(part2())
	elapsed = time.Since(start)
	fmt.Println("Time: " + elapsed.String())
}
