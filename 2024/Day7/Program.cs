namespace Day7;

class Program
{
    public static ulong Part1()
    {
        ulong result = 0;
        var data = File.ReadAllLines("input.txt");
        ulong[] values = data.Select(x => ulong.Parse(x.Split(":")[0])).ToArray();
        List<int>[] numbers = data.Select(x => x.Split(": ")[1].Split(" ").Select(x => int.Parse(x)).ToList()).ToArray();
        string[] operators = ["+", "*"];

        for (int i = 0; i < values.Length; i++)
        {
            int possibleCombos = (int)Math.Pow(operators.Length, numbers[i].Count - 1);
            for (int j = 0; j < possibleCombos; j++)
            {
                ulong erg = (ulong)numbers[i][0];
                var operatorList = Int32ToString(j, operators.Length);
                operatorList = new string('0', numbers[i].Count - 1 - operatorList.Length) + operatorList;
                for (int k = 0; k < operatorList.Length; k++)
                {
                    switch (operatorList[k])
                    {
                        case '0':
                            erg += (ulong)numbers[i][k + 1];
                            break;
                        case '1':
                            erg *= (ulong)numbers[i][k + 1];
                            break;
                    }
                }
                if (erg == values[i])
                {
                    result += erg;
                    break;
                }
            }
        }

        return result;
    }

    public static ulong Part2()
    {
        ulong result = 0;
        var data = File.ReadAllLines("input.txt");
        ulong[] values = data.Select(x => ulong.Parse(x.Split(":")[0])).ToArray();
        List<int>[] numbers = data.Select(x => x.Split(": ")[1].Split(" ").Select(x => int.Parse(x)).ToList()).ToArray();
        string[] operators = ["+", "*", "||"];

        for (int i = 0; i < values.Length; i++)
        {
            int possibleCombos = (int)Math.Pow(operators.Length, numbers[i].Count - 1);
            for (int j = 0; j < possibleCombos; j++)
            {
                ulong erg = (ulong)numbers[i][0];
                var operatorList = Int32ToString(j, operators.Length);
                operatorList = new string('0', numbers[i].Count - 1 - operatorList.Length) + operatorList;
                for (int k = 0; k < operatorList.Length; k++)
                {
                    switch (operatorList[k])
                    {
                        case '0':
                            erg += (ulong)numbers[i][k + 1];
                            break;
                        case '1':
                            erg *= (ulong)numbers[i][k + 1];
                            break;
                        case '2':
                            erg = ulong.Parse(erg.ToString() + numbers[i][k + 1].ToString());
                            break;
                    }
                }
                if (erg == values[i])
                {
                    result += erg;
                    break;
                }
            }
        }

        return result;
    }

    private static string Int32ToString(int value, int toBase)
    {
        string result = string.Empty;
        do
        {
            result = "0123456789ABCDEF"[value % toBase] + result;
            value /= toBase;
        }
        while (value > 0);

        return result;
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 7");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
    }
}