namespace Day10;

class Program
{
    public record Position(int X, int Y);
    public static int Part1()
    {
        int result = 0;
        var data = File.ReadAllLines("sample.txt");
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
        // Console.Clear();


        // List<Position> trailheads = [.. positions[9]];
        List<Position> trailhead = positions[9].Select(x => x).ToList();
        for (int i = 0; i < positions[0].Count; i++)
        {
            var test = GetScore(positions, 1, positions[0][i], 0); 
            // result += GetScore(positions, 1, positions[0][i], 0);
            result += test;
            // Console.Clear();
            Console.WriteLine("");
            positions[9] = trailhead.Select(x => x).ToList();
        }


        return result;
    }

    public static int GetScore(List<Position>[] positions, int height, Position lastPosition, int score)
    {
        if (height == 10)
        {
            positions[9].Remove(lastPosition);
            // Console.Clear();
            return score + 1;

        }
        for (int i = 0; i < positions[height].Count; i++)
        {
            Position p = positions[height][i];
            // if (score == 2 && p.X == 6 && p.Y == 1 && lastPosition.X == 6 && lastPosition.Y == 2)
            // {
            //     Console.WriteLine("");
            // }
            if (p.Y == 4 && p.X == 5)
            {
                Console.WriteLine("");
            }
            if (p.X == lastPosition.X + 1 && p.Y == lastPosition.Y)
            {
                // Console.SetCursorPosition(p.X, p.Y);
                // Console.WriteLine(height);
                score = GetScore(positions, height + 1, p, score);
            }
            if (p.X == lastPosition.X - 1 && p.Y == lastPosition.Y)
            {
                // Console.SetCursorPosition(p.X, p.Y);
                // Console.WriteLine(height);
                score = GetScore(positions, height + 1, p, score);
            }
            if (p.X == lastPosition.X && p.Y == lastPosition.Y + 1)
            {
                // Console.SetCursorPosition(p.X, p.Y);
                // Console.WriteLine(height);
                score = GetScore(positions, height + 1, p, score);
            }
            if (p.X == lastPosition.X && p.Y == lastPosition.Y - 1)
            {
                // Console.SetCursorPosition(p.X, p.Y);
                // Console.WriteLine(height);
                score = GetScore(positions, height + 1, p, score);
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
