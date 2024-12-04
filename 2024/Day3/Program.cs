using System.Text;
using System.Text.RegularExpressions;

namespace Day3;

class Program
{
    public static int Part1()
    {
        int result = 0;
        string[] lines = ReadData("input.txt");
        string pat = @"mul\([0-9]+,[0-9]+\)";

        foreach (string line in lines)
        {
            MatchCollection matches = Regex.Matches(line, pat);
            for (int i = 0; i < matches.Count; i++)
            {
                var extractedNumbers = matches[i].Value.Replace("mul(", "").Replace(")", "").Split(",");
                result += int.Parse(extractedNumbers[0]) * int.Parse(extractedNumbers[1]);
            }
        }

        return result;
    }

    public static int Part2()
    {
        int result = 0;
        string[] lines = ReadData("input.txt");
        string pat = @"mul\([0-9]+,[0-9]+\)|don't\(\)|do\(\)";
        bool enabled = true;

        foreach (string line in lines)
        {
            MatchCollection matches = Regex.Matches(line, pat);
            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].Value.Contains("mul") && enabled)
                {
                    var extractedNumbers = matches[i].Value.Replace("mul(", "").Replace(")", "").Split(",");
                    result += int.Parse(extractedNumbers[0]) * int.Parse(extractedNumbers[1]);
                }
                else
                {
                    enabled = matches[i].Value == "do()";
                }
            }
        }

        return result;
    }

    private static string[] ReadData(string path)
    {
        return File.ReadAllLines(path, Encoding.UTF8);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 3");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
    }
}