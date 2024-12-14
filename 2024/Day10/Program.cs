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

    public static int GetScore(List<Position>[] positions, int height, Position lastPosition, int score)
    {
        if (height == 10)
        {
            positions[9].Remove(lastPosition);
            return score + 1;
        }
        for (int i = positions[height].Count - 1; i >= 0; i--)
        {
            if(lastPosition.GetDiffOfPositions(positions[height][i]) == 1)
            {
                score = GetScore(positions, height + 1, positions[height][i], score);
            }
        }
        return score;
    }

    public static int Part2()
    {
        int result = 0;
        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 10");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
        Console.ReadKey();
    }
}
