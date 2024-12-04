namespace Day4;

class Program
{
    public static int Part1()
    {
        int result = 0;
        var letters = ReadData("input.txt");
        string searchedWord = "XMAS";

        for (int i = 0; i < letters.Count; i++)
        {
            for (int j = 0; j < letters[i].Count; j++)
            {
                if (letters[i][j] != 'X') continue;

                result = SearchForWord(searchedWord, letters, i, j, 1, 0) ? result + 1 : result;
                result = SearchForWord(searchedWord, letters, i, j, 1, 1) ? result + 1 : result;
                result = SearchForWord(searchedWord, letters, i, j, 0, 1) ? result + 1 : result;
                result = SearchForWord(searchedWord, letters, i, j, -1, 1) ? result + 1 : result;
                result = SearchForWord(searchedWord, letters, i, j, -1, 0) ? result + 1 : result;
                result = SearchForWord(searchedWord, letters, i, j, -1, -1) ? result + 1 : result;
                result = SearchForWord(searchedWord, letters, i, j, 0, -1) ? result + 1 : result;
                result = SearchForWord(searchedWord, letters, i, j, 1, -1) ? result + 1 : result;
            }
        }

        return result;
    }


    public static int Part2()
    {
        int result = 0;
        var letters = ReadData("input.txt");
        string searchedWord = "MAS";

        for (int i = 0; i < letters.Count; i++)
        {
            for (int j = 0; j < letters[i].Count; j++)
            {
                if (letters[i][j] != 'A') continue;

                if ((SearchForWord(searchedWord, letters, i - 1, j - 1, 1, 1)
                    || SearchForWord(Reverse(searchedWord), letters, i - 1, j - 1, 1, 1))
                    && (SearchForWord(searchedWord, letters, i + 1, j - 1, -1, 1)
                    || SearchForWord(Reverse(searchedWord), letters, i + 1, j - 1, -1, 1)))
                {
                    result++;
                }
            }
        }

        return result;
    }

    private static List<List<char>> ReadData(string path)
    {
        List<List<char>> letters = [];
        using (StreamReader sr = new(path))
        {
            while (!sr.EndOfStream)
            {
                char[] line = (sr.ReadLine() ?? "").ToCharArray();
                letters.Add(new(line));
            }
        }

        return letters;
    }

    private static bool SearchForWord(string searchWord, List<List<char>> letters, int startY, int startX, int up, int right)
    {
        char[] searchedLetters = searchWord.ToCharArray();
        for (int i = 0; i < searchedLetters.Length; i++)
        {
            int newIndexY = startY + up * i;
            int newIndexX = startX + right * i;
            if (newIndexY < 0 || newIndexY >= letters.Count || newIndexX < 0
                || newIndexX >= letters[newIndexY].Count || searchedLetters[i] != letters[newIndexY][newIndexX])
            {
                return false;
            }
        }
        return true;
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code Day 4");
        Console.WriteLine($"Part 1: {Part1()}");
        Console.WriteLine($"Part 2: {Part2()}");
    }
}