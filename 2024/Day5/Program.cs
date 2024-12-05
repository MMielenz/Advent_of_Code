using System.Linq;

namespace Day5;

class Program
{
    public static int Part1()
    {
        int result = 0;

        List<Rule> rules = [];
        List<Level> levels = [];

        using (StreamReader sr = new("input.txt"))
        {
            bool firstSection = true;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine()!;
                if (line == "")
                {
                    firstSection = false;
                    continue;
                }
                if (firstSection)
                {
                    string[] data = line.Split('|');
                    rules.Add(new(int.Parse(data[0]), int.Parse(data[1])));
                }
                else
                {
                    string[] data = line.Split(',');
                    Level newLevel = new();
                    foreach (var page in data)
                    {
                        newLevel.Pages.Add(int.Parse(page));
                    }
                    levels.Add(newLevel);
                }
            }
        }

        foreach (Level level in levels)
        {
            bool levelIsValid = true;
            foreach (Rule rule in rules)
            {
                if (!rule.RuleApplys(level))
                {
                    levelIsValid = false;
                    break;
                }
            }
            result = levelIsValid ? result + level.Pages[level.Pages.Count / 2] : result;
        }

        return result;
    }


    public static int Part2()
    {
        List<Rule> rules = [];
        List<Level> levels = [];

        using (StreamReader sr = new("input.txt"))
        {
            bool firstSection = true;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine()!;
                if (line == "")
                {
                    firstSection = false;
                    continue;
                }
                if (firstSection)
                {
                    string[] data = line.Split('|');
                    rules.Add(new(int.Parse(data[0]), int.Parse(data[1])));
                }
                else
                {
                    string[] data = line.Split(',');
                    Level newLevel = new();
                    foreach (var page in data)
                    {
                        newLevel.Pages.Add(int.Parse(page));
                    }
                    levels.Add(newLevel);
                }
            }
        }

        List<Level> incorrectLevels = [];
        foreach (var level in levels)
        {
            foreach (var rule in rules)
            {
                if (!rule.RuleApplys(level))
                {
                    incorrectLevels.Add(level);
                    break;
                }
            }
        }

        foreach (Level l in incorrectLevels)
        {
            for (int i = 0; i < rules.Count; i++)
            {
                if (!rules[i].RuleApplys(l))
                {
                    int indexPageBefore = l.Pages.IndexOf(rules[i].PageBefore);
                    int indexPageAfter = l.Pages.IndexOf(rules[i].PageAfter);
                    var wrongPage = l.Pages.ElementAt(indexPageBefore);
                    l.Pages.Remove(wrongPage);
                    l.Pages.Insert(indexPageAfter - 1 < 0 ? 0 : indexPageAfter - 1, wrongPage);
                    i = -1;
                    continue;
                }
            }
        }

        return incorrectLevels.Sum(x => x.Pages[x.Pages.Count / 2]);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 5");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
    }
}
