namespace Day6;

class Program
{
    class Player(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public Direction Dir { get; set; } = Direction.Up;

        public void Move()
        {
            switch(Dir)
            {
                // case Direction.Up:  
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
        Player p;
        for (int i = 0; i < field.Count; i++)
        {
            for (int j = 0; j < field[i].Count; j++)
            {
                if (field[i][j] == '^') p = new(j, i); break;
            }
        }

        
        

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
