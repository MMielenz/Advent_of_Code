namespace aoc2023_06;

class Program
{
    static void Part1()
    {
        StreamReader sr = new("input.txt");

        string[] times = sr.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] records = sr.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        List<Race> races = new List<Race>();

        for (int i = 1; i < times.Length; i++)
        {
            races.Add(new(times[i], records[i]));
        }

        int result = 1;

        for (int i = 0; i < races.Count; i++)
        {
            int posWins = 0;
            for (int j = 1; j < races[i].RaceTime; j++)
            {
                int distance = (races[i].RaceTime - j) * j;
                posWins = distance > races[i].RecordDistance ? posWins + 1 : posWins;
            }
            result = posWins > 0 ? result * posWins : result;
        }

        Console.WriteLine($"Result: {result}");
    }


    static void Main(string[] args)
    {
        Part1();
    }
}



class Race
{
    public int RaceTime { get; set; }
    public int RecordDistance { get; set; }

    public Race(string raceTime, string recordDistance)
    {
        RaceTime = int.Parse(raceTime);
        RecordDistance = int.Parse(recordDistance);
    }
}
