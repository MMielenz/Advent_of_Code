namespace Day7;

class Program
{
    // public class Term(ulong value, )
    public static ulong Part1()
    {
        ulong result = 0;
        var data = File.ReadAllLines("sample.txt");
        ulong[] values = data.Select(x => ulong.Parse(x.Split(":")[0])).ToArray();
        var test = data.Select(x => x.Split(": ")[1]);
        List<int>[] numbers = data.Select(x => x.Split(": ")[1].Split(" ").Select(x => int.Parse(x)).ToList()).ToArray();

        string[] operators = { "+", "*" };

        for (int i = 0; i < values.Length; i++)
        {
            int possibleCombos = (int)Math.Pow(operators.Length, numbers[i].Count);
            int dualLength = Convert.ToString(possibleCombos, 2).Length;
            ulong erg = 0;
            for (int j = 0; j < possibleCombos; j++)
            {
                var operatorList = Convert.ToString(j, 2);
                operatorList = new string('0', dualLength- operatorList.Length) + operatorList;
                for(int k = 0; k < operatorList.Length; k++)
                {
                    switch(operatorList[k])
                    {
                        case '0':
                            erg += (ulong)numbers[i][k];
                            break;
                        case '1':
                            erg *= (ulong)numbers[i][k];
                            break;
                    }
                }
                if (erg == values[i])
                {
                    result += erg;
                }
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
        Console.WriteLine("Advent of Code Day 7");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
    }
}
