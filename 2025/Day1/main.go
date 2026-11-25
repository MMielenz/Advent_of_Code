package main

import (
	"fmt"
	"time"

	"github.com/MMielenz/aoc/utils"
)

func part1() int {
	result := 0
	lines := utils.ReadLines("input.txt")
	dial := 50

	for _, line := range lines {
		dir := line[0:1]
		value := utils.ParseInt(line[1:])
		value = value % 100
		if dir == "L" {
			newValue := dial - value
			if newValue < 0 {
				dial = newValue + 100
			} else {
				dial = newValue
			}
		} else {
			newValue := dial + value
			if newValue > 99 {
				dial = newValue - 100
			} else {
				dial = newValue
			}
		}
		if dial == 0 {
			result++
		}
	}

	return result
}

func part2() int {
	result := 0
	lines := utils.ReadLines("input.txt")
	dial := 50

	for _, line := range lines {
		dir := line[0:1]
		value := utils.ParseInt(line[1:])
		additionalRotations := value / 100
		result += additionalRotations
		value = value % 100
		if dir == "L" {
			newValue := dial - value
			if newValue == 0 {
				result++
				dial = newValue
			} else if newValue < 0 {
				// if its already 0, dont count again
				if dial != 0 {
					result++
				}
				dial = newValue + 100
			} else {
				dial = newValue
			}
		} else {
			newValue := dial + value
			if newValue > 99 {
				result++
				dial = newValue - 100
			} else {
				dial = newValue
			}
		}
	}

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
