namespace Day1;

class Program
{
    public static int Part1()
    {
        var data = ReadData("input.txt");
        List<int> leftSide = data[0];
        List<int> rightSide = data[1];
        leftSide.Sort();
        rightSide.Sort();

        List<int> distances = [];
        for (int i = 0; i < leftSide.Count; i++)
        {
            int distance = leftSide[i] - rightSide[i];
            distances.Add(Math.Abs(leftSide[i] - rightSide[i]));
        }

        return distances.Sum();
    }

    public static int Part2()
    {
        var data = ReadData("input.txt");
        List<int> leftSide = data[0];
        List<int> rightSide = data[1];

        int simScore = 0;
        foreach (int id in leftSide)
        {
            simScore += id * rightSide.Count(x => x == id);
        }
        return simScore;
    }

    private static List<int>[] ReadData(string path)
    {
        List<int>[] sides = [[], []];
        using (StreamReader sr = new(path))
        {
            while (!sr.EndOfStream)
            {
                var data = (sr.ReadLine() ?? "").Split("   ");
                sides[0].Add(int.Parse(data[0]));
                sides[1].Add(int.Parse(data[1]));
            }
        }

        return sides;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 1");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
    }
}
