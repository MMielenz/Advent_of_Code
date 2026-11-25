package utils

import (
	"os"
	"strings"
)

func ReadLines(path string) []string {
	data, _ := os.ReadFile(path)
	// normalize clrf
	clean := strings.ReplaceAll(string(data), "\r\n", "\n")
	return strings.Split(strings.TrimSpace(clean), "\n")
}
