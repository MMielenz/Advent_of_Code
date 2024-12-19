int Part1()
{
    int result = 0;
    List<char[]> data = File.ReadAllLines("input.txt").Select(x => x.ToCharArray()).ToList();
    Dictionary<string, char> field = [];
    for (int y = 0; y < data.Count; y++)
    {
        for (int x = 0; x < data[y].Length; x++)
        {
            field.Add($"{y}:{x}", data[y][x]);
        }
    }
    foreach (var key in field.Keys)
    {
        List<string> alreadyFound = [];
        int area = 0;
        int perimeter = 0;
        result += CalculateFences(field, alreadyFound, key, "", ref area,ref perimeter);
        foreach (var v in alreadyFound)
        {
            field.Remove(v);
        }
    }

    return result;
}

int CalculateFences(Dictionary<string, char> field, List<string> alreadyFound, string key, string oldKey, ref int area, ref int perimeter)
{
    alreadyFound.Add(key);
    List<string> workingKeys = [];
    var possibleKeys = PossibleKeys(key);
    foreach (var newKey in possibleKeys)
    {
        if (field.TryGetValue(newKey, out char value) && value == field[key])
        {
            workingKeys.Add(newKey);
        }
    }
    area++;
    perimeter += 4 - workingKeys.Count;
    if (workingKeys.Count == 0) return area * perimeter;
    
    foreach (var workingKey in workingKeys)
    {
        if (alreadyFound.Contains(workingKey)) continue;
        CalculateFences(field, alreadyFound, workingKey, key, ref area, ref perimeter);
    }

    return area * perimeter;
}



string[] PossibleKeys(string key)
{
    int y = int.Parse(key.Split(":")[0]);
    int x = int.Parse(key.Split(":")[1]);
    string[] keys = [$"{y + 1}:{x}", $"{y - 1}:{x}", $"{y}:{x + 1}", $"{y}:{x - 1}"];
    return keys;
}


int Part2()
{
    int result = 0;

    return result;
}


DateTime start = DateTime.Now;
Console.WriteLine($"Part 1: {Part1()}");
Console.WriteLine($"Execution Time: {DateTime.Now - start}");
start = DateTime.Now;
Console.WriteLine($"Part 2: {Part2()}");
Console.WriteLine($"Execution Time: {DateTime.Now - start}");
Console.ReadKey();