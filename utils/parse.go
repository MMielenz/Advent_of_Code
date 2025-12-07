package utils

import (
	"fmt"
	"strconv"
)

func ParseInt(s string) int {
	value, err := strconv.Atoi(s)
	if err != nil {
		fmt.Println("Could not parse: " + s + err.Error())
	}
	return value
}
