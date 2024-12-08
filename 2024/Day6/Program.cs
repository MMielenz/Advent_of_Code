namespace Day6;

class Program
{
    class Guard(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public Direction Dir { get; set; } = Direction.Up;
        public int InitialX { get; } = x;
        public int InitialY { get; } = y;

        public Guard() : this(0, 0) { }

        public void Move(List<List<char>> field)
        {
            switch (Dir)
            {
                case Direction.Up:
                    if (field[Y - 1][X] == '#')
                    {
                        Dir = Direction.Right;
                        break;
                    }
                    Y--;
                    break;
                case Direction.Right:
                    if (field[Y][X + 1] == '#')
                    {
                        Dir = Direction.Down;
                        break;
                    }
                    X++;
                    break;
                case Direction.Down:
                    if (field[Y + 1][X] == '#')
                    {
                        Dir = Direction.Left;
                        break;
                    }
                    Y++;
                    break;
                case Direction.Left:
                    if (field[Y][X - 1] == '#')
                    {
                        Dir = Direction.Up;
                        break;
                    }
                    X--;
                    break;
            }
            if (X == InitialX && Y == InitialY)
            {
                throw new LoopException();
            }
        }

        public enum Direction
        {
            Up, Right, Down, Left
        }
    }
    class LoopException : Exception
    {
        public LoopException()
        {
        }
    }

    public static int Part1()
    {
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
        try
        {
            while (true)
            {
                field[g.Y][g.X] = 'X';
                g.Move(field);
            }
        }
        catch { }

        result = field.Sum(x => x.Count(x => x == 'X'));
        return result;
    }


    public static int Part2()
    {
        int result = 0;
        List<List<char>> field = File.ReadAllLines("sample.txt").Select(x => x.ToCharArray().ToList()).ToList();
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

        List<List<char>> originalField = new List<List<char>>(field);
        for (int i = 0; i < field.Count; i++)
        {
            for (int j = 0; j < field[i].Count; j++)
            {
                field[i][j] = '#';
                if (i == 6 && j == 4)
                {
                    Console.WriteLine("");
                }
                try
                {
                    while (true)
                    {
                        g.Move(field);
                    }
                }
                catch (LoopException)
                {
                    result++;
                    field = new List<List<char>>(originalField);
                }
                catch
                {
                    field = new List<List<char>>(originalField);
                }
                // finally
                // {
                //     field = new List<List<char>>(originalField);
                // }
            }
        }
        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 6");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
    }
}
