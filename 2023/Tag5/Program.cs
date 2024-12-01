namespace aoc2023_05;

class Program
{
    static void Part1()
    {
        StreamReader sr = new("input.txt");

        string[] seeds = sr.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        List<long> values = new List<long>();
        for (int i = 1; i < seeds.Length; i++)
        {
            int.TryParse(seeds[i], out int seedNumber);
            values.Add(seedNumber);
        }


        List<List<Map>> maps = new List<List<Map>>();

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine()!;

            if (line == "")
            {
                maps.Add(new List<Map>());
                sr.ReadLine();
                continue;
            }

            string[] input = line.Split(" ");
            maps[maps.Count - 1].Add(new Map(input[0], input[1], input[2]));
        }
        sr.Close();



        for (int i = 0; i < values.Count; i++)
        {
            for (int j = 0; j < maps.Count; j++)
            {
                for (int k = 0; k < maps[j].Count; k++)
                {
                    if (values[i] >= maps[j][k].SourceRange && values[i] <= maps[j][k].SourceRange + maps[j][k].RangeLength)
                    {
                        values[i] = maps[j][k].DestRange + values[i] - maps[j][k].SourceRange;
                        break;
                    }
                }
            }
        }

        Console.WriteLine($"Closest location: {values.Min()}");
    }



    static void Main(string[] args)
    {
        Part1();
    }
}
