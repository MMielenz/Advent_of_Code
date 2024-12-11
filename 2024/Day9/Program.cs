using System.Text;

namespace Day9;

class Program
{
    public static int Part1()
    {
        int result = 0;
        var compresedLine = File.ReadAllLines("sample.txt")[0].ToCharArray();
        StringBuilder sb = new();
        int id = 0;
        bool isFile = true;
        foreach (var v in compresedLine)
        {
            int value = int.Parse(v.ToString());
            for (int i = 0; i < value; i++)
            {
                sb.Append((isFile ? id.ToString() : '.'));
            }
            isFile = !isFile;
            id = isFile ? id+1 : id;
        }
        string decompressLine = sb.ToString();

        return result;
    }

    public static int Part2()
    {
        int result = 0;
        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 9");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
    }
}
