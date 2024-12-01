using System.Runtime.Versioning;

namespace aoc2023_04;

class Program
{
    static void Part1()
    {
        int sum = 0;
        string input;

        StreamReader sr = new StreamReader("input.txt");
        input = sr.ReadLine();
        do
        {
            string[] halves = input.Split('|');
            halves[0] = halves[0].Substring(halves[0].IndexOf(':') + 1);

            List<int> winningNumb = new List<int>();
            List<int> myNumb = new List<int>();
            ExtractingNumbers(halves, 0, winningNumb);
            ExtractingNumbers(halves, 1, myNumb);

            int win = 0;
            for (int i = 0; i < winningNumb.Count; i++)
            {
                for (int j = 0; j < myNumb.Count; j++)
                {
                    if (winningNumb[i] == myNumb[j])
                    {
                        win = win == 0 ? 1 : win * 2;
                    }
                }
            }
            sum += win;

            input = sr.ReadLine();
        }
        while (input != null);
        sr.Close();

        Console.WriteLine(sum);


        static void ExtractingNumbers(string[] halves, int index, List<int> numbers)
        {
            string[] halve = halves[index].Split(' ');
            for (int i = 0; i < halve.Length; i++)
            {
                int number = 0;
                bool isNumb = int.TryParse(halve[i], out number);
                if (isNumb)
                {
                    numbers.Add(number);
                }
            }
        }
    }





    static void Part2()
    {

    }



    static void Main(string[] args)
    {
        Part1();
        Part2();
        Console.ReadKey();
    }
}