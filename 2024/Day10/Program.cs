namespace Day10;

class Program
{
    public record Position(int X, int Y)
    {
        public int GetDiffOfPositions(Position other)
        {
            return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
        }
    }
    public static int Part1()
    {
        int result = 0;
        var data = File.ReadAllLines("input.txt");
        List<Position>[] positions = new List<Position>[10];
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                if (data[i][j] == '.') continue;
                int height = int.Parse(data[i][j].ToString());
                if (positions[height] is null) positions[height] = [];
                positions[height].Add(new(j, i));
            }
        }
        List<Position> trailheads = [.. positions[9]];
        for (int i = 0; i < positions[0].Count; i++)
        {
            result += GetScore(positions, 1, positions[0][i], 0);
            positions[9] = [.. trailheads];
        }

        return result;
    }


    public static int Part2()
    {
        int result = 0;
        var data = File.ReadAllLines("input.txt");
        List<Position>[] positions = new List<Position>[10];
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                if (data[i][j] == '.') continue;
                int height = int.Parse(data[i][j].ToString());
                if (positions[height] is null) positions[height] = [];
                positions[height].Add(new(j, i));
            }
        }
        for (int i = 0; i < positions[0].Count; i++)
        {
            result += GetScore(positions, 1, positions[0][i], 0, false);
        }

        return result;
    }

    public static int GetScore(List<Position>[] positions, int nextHeight, Position lastPosition, int score, bool distinctTrailheads = true)
    {
        if (nextHeight == 10)
        {
            if (distinctTrailheads)
            {
                positions[9].Remove(lastPosition);
            }
            return score + 1;
        }
        for (int i = positions[nextHeight].Count - 1; i >= 0; i--)
        {
            if (lastPosition.GetDiffOfPositions(positions[nextHeight][i]) == 1)
            {
                score = GetScore(positions, nextHeight + 1, positions[nextHeight][i], score, distinctTrailheads);
            }
        }
        return score;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 10");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.ReadKey();
    }
}
