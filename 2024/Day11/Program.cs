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


ulong Part2()
{
    ulong result = 0;
    List<ulong> AllStones = File.ReadAllLines("input.txt")[0].Split(" ").Select(x => ulong.Parse(x)).ToList();
    Dictionary<string, ulong> alreadyComputed = [];

    foreach (ulong stone in AllStones)
    {
        result += CalculateAmount(stone, 75, alreadyComputed);
    }

    return result;
}

ulong CalculateAmount(ulong stoneValue, int blink, Dictionary<string, ulong> alreadyComputed)
{
    string key = $"{stoneValue}:{blink}";

    if (alreadyComputed.ContainsKey(key))
    {
        return alreadyComputed[key];
    }

    if (blink == 1)
    {
        var stones = CalculateStones(stoneValue);
        ulong stonesCount = (ulong)stones.Count;
        alreadyComputed.Add(key, stonesCount);
        return stonesCount;
    }

    ulong result = 0;
    var stonesNow = CalculateStones(stoneValue);
    foreach (var stone in stonesNow)
    {
        ulong amount = CalculateAmount(stone, blink - 1, alreadyComputed);
        result += amount;
        string newKey = $"{stone}:{blink - 1}";
        if (alreadyComputed.ContainsKey(newKey)) continue;
        alreadyComputed.Add(newKey, amount);
    }

    return result;
}

List<ulong> CalculateStones(ulong stone)
{
    if (stone == 0)
    {
        return [1];
    }

    string number = stone.ToString();
    if (number.Length % 2 == 0)
    {
        ulong num1 = ulong.Parse(number[..(number.Length / 2)]);
        ulong num2 = ulong.Parse(number.Substring(number.Length / 2, number.Length / 2));
        return [num1, num2];
    }

    return [stone * 2024];
}

Console.WriteLine("Advent of Code Day 11");
DateTime start = DateTime.Now;
Console.WriteLine($"Part 1: {Part1()}");
Console.WriteLine($"Execution Time: {DateTime.Now - start}");
start = DateTime.Now;
Console.WriteLine($"Part 2: {Part2()}");
Console.WriteLine($"Execution Time: {DateTime.Now - start}");
Console.ReadKey();