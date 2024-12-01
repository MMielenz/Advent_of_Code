namespace Tag5;

using System.Globalization;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

class Program
{
    static void Part1()
    {
        StreamReader sr = new StreamReader("sample.txt");

        List<List<string>> ship = new List<List<string>>();

        string line;

        string pattern = @"(\d+)";
        int amountOfCrates;
        int fromHere;
        int toHere;


        line = sr.ReadLine();

        CreateEnoughStacks(line, ref ship);

        WriteStacksValueToTheShip(ref line, ref ship, sr);


        // will skip the free line
        if (line == "")
        {
            line = sr.ReadLine();
        }


        while (line != null)
        {
            // filters the relevant numbers out of the commands
            MatchCollection matches = Regex.Matches(line, pattern);

            amountOfCrates = int.Parse(matches[0].Value);
            fromHere = int.Parse(matches[1].Value) - 1;
            toHere = int.Parse(matches[2].Value) - 1;

            for (int i = 0; i < amountOfCrates; i++)
            {
                // checks if the part in the List is free
                int j = 0;

                while (ship[fromHere][j] == "   ")
                {
                    j++;
                }


                int k = 0;
                bool finished = false;

                if (ship[toHere].Last() == "  ")
                {
                    k = ship[toHere].Count - 1;
                }
                else
                {
                    while (!finished)
                    {
                        if (ship[toHere][k + 1] == "   ")
                        {
                            k++;

                        }
                        finished = true;
                    }
                }


                // will either replace a free string or will insert it at the first place
                if (ship[toHere][k] != "   ")
                {
                    ship[toHere].Insert(0, ship[fromHere][j]);
                    ship[fromHere][j] = "   ";
                }
                else
                {
                    ship[toHere][k] = ship[fromHere][j];
                    ship[fromHere][j] = "   ";
                }
            }

            line = sr.ReadLine();
        }


        List<string> HighestCrates = new List<string>();

        foreach (List<string> stack in ship)
        {
            int i = 0;
            while (stack[i] == "   ")
            {
                i++;
            }

            string crate = stack[i].Replace("[", "").Replace("]", "");

            HighestCrates.Add(crate);
        }

        foreach (string s in HighestCrates)
        {
            Console.Write(s);
        }
    }




    static void Part2()
    {
        StreamReader sr = new StreamReader("input.txt");

        List<List<string>> ship = new List<List<string>>();

        string line;

        string pattern = @"(\d+)";
        int amountOfCrates;
        int fromHere;
        int toHere;


        line = sr.ReadLine();

        CreateEnoughStacks(line, ref ship);

        WriteStacksValueToTheShip(ref line, ref ship, sr);


        // will skip the free line
        if (line == "")
        {
            line = sr.ReadLine();
        }

        int durchlaufe = 0;
        while (line != null)
        {
            // filters the relevant numbers out of the commands
            MatchCollection matches = Regex.Matches(line, pattern);

            amountOfCrates = int.Parse(matches[0].Value);
            fromHere = int.Parse(matches[1].Value) - 1;
            toHere = int.Parse(matches[2].Value) - 1;

            durchlaufe++;
            while (0 < amountOfCrates)
            {
                amountOfCrates--;


                int j = 0;


                while (ship[fromHere][j] == "   " && ship[fromHere].Count > j + 1)
                {
                    j++;
                }
                j += amountOfCrates;

                if (j + 1 > ship[fromHere].Count)
                {
                    j = 0;
                }


                int k = 0;
                bool finished = false;

                if (ship[toHere].Last() == "  ")
                {
                    k = ship[toHere].Count - 1;
                }
                else
                {
                    while (!finished)
                    {
                        if (ship[toHere][k + 1] == "   ")
                        {
                            k++;

                        }
                        finished = true;
                    }
                }


                // will either replace a free string or will insert it at the first place
                if (ship[toHere][k] != "   ")
                {
                    ship[toHere].Insert(0, ship[fromHere][j]);
                    ship[fromHere][j] = "   ";
                }
                else
                {
                    ship[toHere][k] = ship[fromHere][j];
                    ship[fromHere][j] = "   ";
                }


            }

            line = sr.ReadLine();
        }


        List<string> HighestCrates = new List<string>();

        foreach (List<string> stack in ship)
        {
            int i = 0;


            while (stack[i] == "   ")
            {
                if (i + 1 < stack.Count)
                {
                    break;
                }
                i++;
            }


            string crate = stack[i].Replace("[", "").Replace("]", "");

            HighestCrates.Add(crate);
        }

        foreach (string s in HighestCrates)
        {
            Console.Write(s);
        }
    }
    static void Main(string[] args)
    {
        // Part1();
        Part2();
        Console.ReadKey();
    }


    static void CreateEnoughStacks(string line, ref List<List<string>> ship)
    {
        for (int i = 0; i < (line.Length + 1) / 4; i++)
        {
            ship.Add(new List<string>());
        }
    }



    static void WriteStacksValueToTheShip(ref string line, ref List<List<string>> ship, StreamReader sr)
    {
        bool finished = false;

        string crate;
        int crateStart = 0;
        int crateEnd = 3;

        do
        {
            for (int i = 0; line.Length > crateStart; i++)
            {
                crate = line.Substring(crateStart, crateEnd);

                ship[i].Add(crate);

                crateStart += 4;
            }

            line = sr.ReadLine();
            crateStart = 0;

            string stackEnd = line.Substring(1, 1);
            if (stackEnd == "1")
            {
                finished = true;
                line = sr.ReadLine();
            }
        }
        while (!finished);
    }
}
