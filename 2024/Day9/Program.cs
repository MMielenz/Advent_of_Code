namespace Day9;

class Program
{
    public static ulong Part1()
    {
        ulong result = 0;
        var compresedLine = File.ReadAllLines("input.txt")[0].ToCharArray();
        int id = 0;
        bool isFile = true;
        List<int> decompressedValues = [];
        foreach (var v in compresedLine)
        {
            int value = int.Parse(v.ToString());
            for (int i = 0; i < value; i++)
            {
                decompressedValues.Add(isFile ? id : -1);
            }
            isFile = !isFile;
            id = isFile ? id + 1 : id;
        }

        for (int i = decompressedValues.Count - 1; i >= 0; i--)
        {
            if (decompressedValues[i] == -1) continue;
            int indexFree = decompressedValues.IndexOf(-1);
            if (indexFree > i) break;
            decompressedValues[indexFree] = decompressedValues[i];
            decompressedValues[i] = -1;
        }

        for (int i = 0; i < decompressedValues.Count; i++)
        {
            if (decompressedValues[i] == -1) break;
            result += (ulong)(i * decompressedValues[i]);
        }

        return result;
    }

    public static ulong Part2()
    {
        ulong result = 0;
        var compresedLine = File.ReadAllLines("input.txt")[0].ToCharArray();
        int id = 0;
        bool isFile = true;
        List<int> decompressedValues = [];
        foreach (var v in compresedLine)
        {
            int value = int.Parse(v.ToString());
            for (int i = 0; i < value; i++)
            {
                decompressedValues.Add(isFile ? id : -1);
            }
            isFile = !isFile;
            id = isFile ? id + 1 : id;
        }


        for (int i = decompressedValues.Count - 1; i >= 0; i--)
        {
            if (decompressedValues[i] == -1) continue;
            
            int lengthOfFile = 1;
            while (i - lengthOfFile >= 0 && decompressedValues[i - lengthOfFile] == decompressedValues[i])
            {
                lengthOfFile++;
            }

            // find suitable free space
            bool found = false;
            int startIndexFreeSpace = 0;
            for (int j = 0; j < decompressedValues.Count; j++)
            {
                if (decompressedValues[j] != -1) continue;
                if (j > i)
                {
                    found = false;
                    break;
                }
                found = true;
                startIndexFreeSpace = j;
                for (int k = 0; k < lengthOfFile; k++)
                {
                    if (decompressedValues[j + k] != -1)
                    {
                        found = false;
                        break;
                    }
                }
                if (found) break;
            }

            if (found)
            {
                for (int j = 0; j < lengthOfFile; j++)
                {
                    decompressedValues[startIndexFreeSpace + j] = decompressedValues[i - j];
                    decompressedValues[i - j] = -1;
                }
            }
            i -= lengthOfFile - 1;
        }

        for (int i = 0; i < decompressedValues.Count; i++)
        {
            if (decompressedValues[i] == -1) continue;
            result += (ulong)(i * decompressedValues[i]);
        }

        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 9");
        Console.WriteLine($"Part 1: {Part1()}");
        DateTime start = DateTime.Now;
        Console.WriteLine($"Part 2: {Part2()}");
        Console.WriteLine($"Execution time: {DateTime.Now - start}");
        Console.ReadKey();
    }
}