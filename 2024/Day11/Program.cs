using Day11;

int Part1()
{
    List<Stone> stones = File.ReadAllLines("input.txt")[0].Split(" ").Select(x => new Stone(ulong.Parse(x))).ToList();
    for (int i = 0; i < 25; i++)
    {
        for (int j = 0; j < stones.Count; j++)
        {
            if (stones[j].Number == 0)
            {
                stones[j].Number = 1;
                continue;
            }

            string number = stones[j].Number.ToString();
            if (number.Length % 2 == 0)
            {
                stones[j].Number = ulong.Parse(number[..(number.Length / 2)]);
                stones.Insert(j + 1, new Stone(ulong.Parse(number.Substring(number.Length / 2, number.Length / 2))));
                j++;
                continue;
            }

            stones[j].Number *= 2024;
        }
    }

    return stones.Count;
}


int Part2()
{
    int result = 0;
    return result;
}


Console.WriteLine("Advent of Code Day 11");
Console.WriteLine($"Part 1: {Part1()}");
Console.WriteLine($"Part 2: {Part2()}");
Console.ReadKey();