namespace Day6;

class Program
{
    class Player(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public Direction Dir { get; set; } = Direction.Up;

        public Player() : this(0, 0) { }

        public void Move(List<List<char>> field)
        {
            field[Y][X] = 'X';
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
                        
                    }
                    X++;
                    break;
                case Direction.Down:
                    if (field[Y + 1][X] == '#') Dir = Direction.Down;
                    Y++;
                    break;
                case Direction.Left:
                    if (field[Y][X - 1] == '#') Dir = Direction.Up;
                    X--;
                    break;
            }
        }

        public enum Direction
        {
            Up, Right, Down, Left
        }
    }

    public static int Part1()
    {
        int result = 0;
        List<List<char>> field = File.ReadAllLines("sample.txt").Select(x => x.ToCharArray().ToList()).ToList();
        Player p = new();
        for (int i = 0; i < field.Count; i++)
        {
            for (int j = 0; j < field[i].Count; j++)
            {
                if (field[i][j] == '^')
                {
                    p = new(j, i);
                    break;
                }
            }
        }

        try
        {
            while (true)
            {
                p.Move(field);
            }
        }
        catch { }


        result = field.Sum(x => x.Count(x => x == 'X'));
        return result;
    }


    public static int Part2()
    {
        int result = 0;

        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 6");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
    }
}
