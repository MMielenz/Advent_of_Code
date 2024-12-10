namespace Day6;

class Program
{
    class Guard(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public Direction Dir { get; set; } = Direction.Up;

        public Guard() : this(0, 0) { }
        public Guard(Guard g) : this(g.X, g.Y) { }

        public bool Move(List<List<char>> field)
        {
            switch (Dir)
            {
                case Direction.Up:
                    if (Y - 1 < 0) return false;
                    if (field[Y - 1][X] == '#')
                    {
                        Dir = Direction.Right;
                        break;
                    }
                    Y--;
                    break;
                case Direction.Right:
                    if (X + 1 == field[X].Count) return false;
                    if (field[Y][X + 1] == '#')
                    {
                        Dir = Direction.Down;
                        break;
                    }
                    X++;
                    break;
                case Direction.Down:
                    if (Y + 1 == field.Count) return false;
                    if (field[Y + 1][X] == '#')
                    {
                        Dir = Direction.Left;
                        break;
                    }
                    Y++;
                    break;
                case Direction.Left:
                    if (X - 1 < 0) return false;
                    if (field[Y][X - 1] == '#')
                    {
                        Dir = Direction.Up;
                        break;
                    }
                    X--;
                    break;
            }
            return true;
        }
    }
    public enum Direction
    {
        Up, Right, Down, Left
    }
    public record VisitedPlace(int X, int Y, Direction Dir);

    public static int Part1()
    {
        List<List<char>> field = File.ReadAllLines("input.txt").Select(x => x.ToCharArray().ToList()).ToList();
        Guard g = new();
        for (int i = 0; i < field.Count; i++)
        {
            for (int j = 0; j < field[i].Count; j++)
            {
                if (field[i][j] == '^')
                {
                    g = new(j, i);
                    break;
                }
            }
        }
        do
        {
            field[g.Y][g.X] = 'X';
        }
        while (g.Move(field));

        return field.Sum(x => x.Count(x => x == 'X'));
    }

    /// <summary>
    /// Bad Performance
    /// </summary>
    /// <returns></returns>
    public static int Part2()
    {
        DateTime start = DateTime.Now;
        int result = 0;
        List<List<char>> field = File.ReadAllLines("input.txt").Select(x => x.ToCharArray().ToList()).ToList();
        Guard g = new();
        for (int i = 0; i < field.Count; i++)
        {
            for (int j = 0; j < field[i].Count; j++)
            {
                if (field[i][j] == '^')
                {
                    g = new(j, i);
                    break;
                }
            }
        }
        Guard originalGuard = new(g);
        List<VisitedPlace> normalyVisited = [];
        do
        {
            normalyVisited.Add(new(g.X, g.Y, g.Dir));
        } while (g.Move(field));
        normalyVisited = normalyVisited.GroupBy(x => new { x.X, x.Y }).Select(x => x.First()).ToList();
        g = new(originalGuard);

        foreach (VisitedPlace v in normalyVisited)
        {
            List<VisitedPlace> visitedPlaces = [];
            field[v.Y][v.X] = '#';
            do
            {
                VisitedPlace newVisitedPlace = new(g.X, g.Y, g.Dir);
                if (visitedPlaces.Contains(newVisitedPlace))
                {
                    result++;
                    break;
                }
                visitedPlaces.Add(newVisitedPlace);
            }
            while (g.Move(field));

            field[v.Y][v.X] = '.';
            g = new(originalGuard);
        }
        Console.WriteLine($"Dauer: {(DateTime.Now - start).TotalMinutes}");
        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 6");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
    }
}
