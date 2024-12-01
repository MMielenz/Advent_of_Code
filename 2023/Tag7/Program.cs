namespace aoc2023_07;

class Program
{
    static void Part1()
    {
        List<Hand> hands = new List<Hand>();

        StreamReader sr = new("test.txt");
        while (!sr.EndOfStream)
        {
            string[] values = sr.ReadLine()!.Split(" ");
            hands.Add(new(values[0], values[1]));
        }
        sr.Close();

        // hands.Sort(x => x.Cards[0] == x.Cards[1] && x.Cards[0] == x.Cards[2] && x.Cards[0] == x.Cards[4] && x.Cards[0] == x.Cards[4]);


        for (int i = 0; i < hands.Count; i++)
        {
            for (int j = 0; j < hands[i].Cards.Count; j++)
            {
                Console.Write(hands[i].Cards[j] + "  ");
            }
            Console.WriteLine("");
        }


        Console.WriteLine("\n\n\n");

        hands.OrderBy(x => Bewertung(x)); // x.Cards[0] == x.Cards[1] && x.Cards[0] == x.Cards[2] && x.Cards[0] == x.Cards[4] && x.Cards[0] == x.Cards[4]);
        // hands.Sort((a, b) => Vergleich(a, b));

        for (int i = 0; i < hands.Count; i++)
        {
            for (int j = 0; j < hands[i].Cards.Count; j++)
            {
                Console.Write(hands[i].Cards[j] + "  ");
            }
            Console.WriteLine("");
        }
    }

    static int Bewertung(Hand x)
    {
        // if (x.Cards[0] == x.Cards[1] && x.Cards[0] == x.Cards[2] && x.Cards[0] == x.Cards[4] && x.Cards[0] == x.Cards[4]) { return 5; }
        List<int> amounts = new List<int>();

        for (int i = 0; i < x.Cards.Count; i++)
        {
            amounts.Add(0);
            int startIndex = 0;

            while (x.Cards.IndexOf(x.Cards[i], startIndex) != -1)
            {
                amounts[i] += 1;
                startIndex++;
            }
        }
        amounts.OrderDescending();


        if (amounts[0] == 5)
        {
            return 7;
        }
        else if(amounts[0] == 4)
        {
            return 6;
        }
        else if (amounts[0] == 3 && amounts[1] == 2)
        {
            return 5;
        }
        else if (amounts[0] == 3)
        {
            return 4;
        }
        else if (amounts[0] == 2 && amounts[1] == 2)
        {
            return 3;
        }
        else if (amounts[0] == 2)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    // static int Vergleich(Hand x, Hand y)
    // {
    //     // -1, 0, 1
    //     return 1;
    // }

    static void Main(string[] args)
    {
        Part1();
        Console.ReadKey();
    }
}
