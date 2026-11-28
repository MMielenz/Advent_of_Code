package main

import (
	"flag"
	"fmt"
	"time"

	"github.com/MMielenz/aoc/utils"
)

func part1(inputFile string) int {
	result := 0
	lines := utils.ReadLines(inputFile)

	return result
}

func part2(inputFile string) int {
	result := 0
	lines := utils.ReadLines(inputFile)

	return result
}

func main() {
	useSample := flag.Bool("sample", false, "Use sample.txt instead of input.txt")
	flag.Parse()

	inputFile := "input.txt"
	if *useSample {
		inputFile = "sample.txt"
	}

	start := time.Now()
	resultP1 := part1(inputFile)
	elapsed := time.Since(start)

	fmt.Printf("Part 1: %d (%s)\n", resultP1, elapsed)

	start = time.Now()
	resultP2 := part2(inputFile)
	elapsed = time.Since(start)

	fmt.Printf("Part 2: %d (%s)\n", resultP2, elapsed)
}
