using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Day9;

class Program
{
    public static ulong Part1()
    {
        ulong result = 0;
        var compresedLine = File.ReadAllLines("input.txt")[0].ToCharArray();
        int id = 0;
        bool isFile = true;
        List<int> decompressedValues = [];
        foreach (var v in compresedLine)
        {
            int value = int.Parse(v.ToString());
            for (int i = 0; i < value; i++)
            {
                decompressedValues.Add(isFile ? id : -1);
            }
            isFile = !isFile;
            id = isFile ? id + 1 : id;
        }

        for (int i = decompressedValues.Count - 1; i >= 0; i--)
        {
            if (decompressedValues[i] == -1) continue;
            int indexFree = decompressedValues.IndexOf(-1);
            if (indexFree > i) break;
            decompressedValues[indexFree] = decompressedValues[i];
            decompressedValues[i] = -1;
        }

        for (int i = 0; i < decompressedValues.Count; i++)
        {
            if (decompressedValues[i] == -1) break;
            result += (ulong)(i * decompressedValues[i]);
        }

        return result;
    }

    public static string ListOfIntsToString(List<int> values)
    {
        StringBuilder sb = new();
        // string s = "";
        foreach (var v in values)
        {
            // s += v;
            sb.Append(v == -1 ? "." : v);
        }
        // return s;
        return sb.ToString();
    }

    // public static string debugHelp(List<int> values)
    // {
    //     return ListOfIntsToString(values).Replace("-1", ".");
    // }

    public static ulong Part2()
    {
        ulong result = 0;
        var compresedLine = File.ReadAllLines("input.txt")[0].ToCharArray();
        int id = 0;
        bool isFile = true;
        List<int> decompressedValues = [];
        foreach (var v in compresedLine)
        {
            int value = int.Parse(v.ToString());
            for (int i = 0; i < value; i++)
            {
                decompressedValues.Add(isFile ? id : -1);
            }
            isFile = !isFile;
            id = isFile ? id + 1 : id;
        }

        for (int i = decompressedValues.Count - 1; i >= 0; i--)
        {
            if (decompressedValues[i] == -1) continue;
            int lengthOfFile = 1;
            while (i - lengthOfFile >= 0 && decompressedValues[i - lengthOfFile] == decompressedValues[i])
            {
                lengthOfFile++;
            }
            StringBuilder sb = new();
            for (int j = 0; j < lengthOfFile; j++)
            {
                sb.Append(@"\.");
            }
            var test = ListOfIntsToString(decompressedValues);
            MatchCollection matches = Regex.Matches(ListOfIntsToString(decompressedValues), sb.ToString());
            if (matches.Count > 0)
            {
                if (matches[0].Index > i)
                {
                    i -= lengthOfFile - 1;

                    continue;
                }

                for (int j = 0; j < lengthOfFile; j++)
                {
                    decompressedValues[matches[0].Index + j] = decompressedValues[i - j];
                    decompressedValues[i - j] = -1;
                }

            }
            i -= lengthOfFile - 1;
        }

        for (int i = 0; i < decompressedValues.Count; i++)
        {
            if (decompressedValues[i] == -1) continue;
            result += (ulong)(i * decompressedValues[i]);
        }

        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 9");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.ReadKey();
    }
}
