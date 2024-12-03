using System.Text.RegularExpressions;

namespace Day3;

class Program
{
    public static int Part1()
    {
        string line = ReadData("sample.txt");
        int result = 0;
        string pat = @"mul\([0-9]+,[0-9]+\)";

        MatchCollection matches = Regex.Matches(line, pat);
        for (int i = 0; i < matches.Count; i++)
        {
            var extractedNumbers = matches[i].Value.Replace("mul(", "").Replace(")", "").Split(",");
            result += int.Parse(extractedNumbers[0]) * int.Parse(extractedNumbers[1]);
        }

        return result;
    }

    // public static int Part2()
    // {

    // }

    private static string ReadData(string path)
    {
        string line = "";
        using (StreamReader sr = new(path))
        {
            while (!sr.EndOfStream)
            {
                var data = sr.ReadLine() ?? "";
                line = data;
            }
        }
        return line;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 2");
        Console.WriteLine($"Part 1: {Part1()}");
        // Console.WriteLine($"Part 2: {Part2()}");
    }
}