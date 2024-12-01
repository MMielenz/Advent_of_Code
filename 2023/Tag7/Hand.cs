using System;

namespace aoc2023_07;

public class Hand
{
    // private enum Strength
    // {
    //     A, K, Q, J, T, 9, 8, 7, 6
    //     }

    // (string, string, string, string, string, string, string, string, string, string, string, string, string) strength = ("A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2");
    // private static readonly List<string> strength = new List<string> { "A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2" };
    private static readonly List<string> strength = new List<string> { "2", "3","4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A" };

    public List<int> Cards { get; set; } = new List<int>();
    public int Bidding { get; set; }

    public Hand(string cards, string bidding)
    {
        char[] cardsForHand = cards.ToCharArray();
        for (int i = 0; i < cardsForHand.Length; i++)
        {
            // Cards.Add(Array.IndexOf(strength, cardsForHand[i].ToString()));
            Cards.Add(strength.IndexOf(cardsForHand[i].ToString()));
        }
        Bidding = int.Parse(bidding);
    }
}
