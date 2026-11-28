package main

import (
	"flag"
	"fmt"
	"strings"
	"time"

	"github.com/MMielenz/aoc/utils"
)

type Range struct {
	Start, End int
}

func part1(inputFile string) int {
	result := 0
	lines := utils.ReadLines(inputFile)
	ranges := []Range{}
	ids := []int{}
	isReadingRanges := true

	for _, line := range lines {
		if line == "" {
			isReadingRanges = false
			continue
		}
		if isReadingRanges {
			rangeParts := strings.Split(line, "-")
			ranges = append(ranges, Range{Start: utils.ParseInt(rangeParts[0]), End: utils.ParseInt(rangeParts[1])})
		} else {
			ids = append(ids, utils.ParseInt(line))
		}
	}

	for _, id := range ids {
		for _, r := range ranges {
			if id >= r.Start && id <= r.End {
				result++
				break
			}
		}
	}

	return result
}

func part2(inputFile string) int {
	result := 0
	lines := utils.ReadLines(inputFile)
	ranges := []Range{}

	for _, line := range lines {
		if line == "" {
			break
		}
		rangeParts := strings.Split(line, "-")
		ranges = append(ranges, Range{Start: utils.ParseInt(rangeParts[0]), End: utils.ParseInt(rangeParts[1])})
	}

	drop := make([]bool, len(ranges))

	for i := range ranges {
		if drop[i] {
			continue
		}
		for j := range ranges {
			if i == j || drop[j] {
				continue
			}

			if ranges[j].Start >= ranges[i].Start && ranges[j].Start <= ranges[i].End {
				if ranges[j].End <= ranges[i].End {
					drop[j] = true
				} else {
					ranges[j].Start = ranges[i].End + 1
				}
			}
		}
	}

	var filtered []Range
	for i, r := range ranges {
		if !drop[i] {
			filtered = append(filtered, r)
		}
	}

	for _, r := range filtered {
		result += r.End - r.Start + 1
	}

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
