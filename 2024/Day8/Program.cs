namespace Day8;

class Program
{
    public static int Part1()
    {
        var data = File.ReadAllLines("input.txt");
        int fieldHeight = data.Length;
        int fieldWidth = data[0].Length;

        Dictionary<string, char> field = [];
        for (int y = 0; y < fieldHeight; y++)
        {
            for (int x = 0; x < fieldWidth; x++)
            {
                char location = data[y][x];
                if (location != '.')
                {
                    field.Add($"{y}:{x}", location);
                }
            }
        }

        HashSet<string> antinodes = [];
        foreach (var key in field.Keys)
        {
            foreach (var key2 in field.Keys)
            {
                if (field[key] == field[key2] && key != key2)
                {
                    int antenna2Y = int.Parse(key2.Split(":")[0]);
                    int antenna2X = int.Parse(key2.Split(":")[1]);
                    int antinodeY = 2 * antenna2Y - int.Parse(key.Split(":")[0]);
                    int antinodeX = 2 * antenna2X - int.Parse(key.Split(":")[1]);
                    if (antinodeY < 0 || antinodeY >= fieldHeight || antinodeX < 0 || antinodeX >= fieldWidth) continue;
                    antinodes.Add($"{antinodeY}:{antinodeX}");
                }
            }
        }
        return antinodes.Count;
    }

    public static int Part2()
    {
        var data = File.ReadAllLines("input.txt");
        int fieldHeight = data.Length;
        int fieldWidth = data[0].Length;

        Dictionary<string, char> field = [];
        for (int y = 0; y < fieldHeight; y++)
        {
            for (int x = 0; x < fieldWidth; x++)
            {
                char location = data[y][x];
                if (location != '.')
                {
                    field.Add($"{y}:{x}", location);
                }
            }
        }

        HashSet<string> antinodes = [];
        foreach (var key in field.Keys)
        {
            foreach (var key2 in field.Keys)
            {
                if (field[key] == field[key2] && key != key2)
                {
                    antinodes.Add(key);
                    antinodes.Add(key2);
                    int antenna2Y = int.Parse(key2.Split(":")[0]);
                    int antenna2X = int.Parse(key2.Split(":")[1]);
                    int yDiff = antenna2Y - int.Parse(key.Split(":")[0]);
                    int xDiff = antenna2X - int.Parse(key.Split(":")[1]);
                    int antinodeY = antenna2Y;
                    int antinodeX = antenna2X;
                    while (true)
                    {
                        antinodeY += yDiff;
                        antinodeX += xDiff;
                        if (antinodeY < 0 || antinodeY >= fieldHeight || antinodeX < 0 || antinodeX >= fieldWidth) break;
                        antinodes.Add($"{antinodeY}:{antinodeX}");
                    }
                }
            }
        }
        return antinodes.Count;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 7");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
    }
}
