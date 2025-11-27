package utils

import (
	"os"
	"strings"
)

func ReadLines(path string) []string {
	data, _ := os.ReadFile(path)
	return strings.Split(strings.TrimSpace(string(data)), "\n")
}
