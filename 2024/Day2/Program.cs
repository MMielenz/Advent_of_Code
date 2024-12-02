namespace Day2;

class Program
{
    public static int Part1()
    {
        List<Report> reports = ReadData("input.txt");
        int result = 0;

        foreach (var report in reports)
        {
            bool valid = true;
            for (int i = 0; i < report.Levels.Count - 1; i++)
            {
                int diff = Math.Abs(report.Levels[i] - report.Levels[i + 1]);
                if (diff <= 0 || diff > 3
                || report.Order == OrderOfLevels.Increasing && report.Levels[i] > report.Levels[i + 1]
                || report.Order == OrderOfLevels.Decreasing && report.Levels[i] < report.Levels[i + 1])
                {
                    valid = false;
                    break;
                }
            }
            result = valid ? result + 1 : result;
        }

        return result;
    }

    public static int Part2()
    {
        List<Report> reports = ReadData("input.txt");
        int result = 0;

        foreach (var report in reports)
        {
            bool valid = true;
            int indexOfProblem = 0;
            var originalReportLevles = new List<int>(report.Levels);

            for (int i = 0; i < report.Levels.Count - 1; i++)
            {
                int diff = Math.Abs(report.Levels[i] - report.Levels[i + 1]);
                if (diff <= 0 || diff > 3
                || report.Order == OrderOfLevels.Increasing && report.Levels[i] > report.Levels[i + 1]
                || report.Order == OrderOfLevels.Decreasing && report.Levels[i] < report.Levels[i + 1])
                {
                    if (indexOfProblem < originalReportLevles.Count)
                    {
                        report.Levels = new List<int>(originalReportLevles);
                        report.Levels.RemoveAt(indexOfProblem);
                        indexOfProblem++;
                        i = -1;
                        continue;
                    }

                    valid = false;
                    break;
                }
            }
            result = valid ? result + 1 : result;
        }

        return result;
    }

    private static List<Report> ReadData(string path)
    {
        List<Report> reports = [];
        using (StreamReader sr = new(path))
        {
            while (!sr.EndOfStream)
            {
                var data = (sr.ReadLine() ?? "").Split(" ");
                Report report = new();
                foreach (var level in data)
                {
                    report.Levels.Add(int.Parse(level));
                }
                reports.Add(report);
            }
        }
        return reports;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 2");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
    }
}

class Report
{
    public List<int> Levels { get; set; } = [];
    public OrderOfLevels Order => Levels[0] < Levels[1] ? OrderOfLevels.Increasing : OrderOfLevels.Decreasing;
}

enum OrderOfLevels
{
    Increasing,
    Decreasing
}