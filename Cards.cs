using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;

namespace DruncKard
{
    public class Cards
    {
        private int _num;
        private string _suit;
        short rounds = 10;
        List<Cards> cards = new List<Cards>();
        List<Cards> player1 = new List<Cards>();
        List<Cards> player2 = new List<Cards>();
        string[] Suits = { "\u2660", "\u2665", "\u2666", "\u2663" };
        public Cards() { }

        public Cards(int num, string suit)
        {
            _num = num;
            _suit = suit;
        }
        public override string ToString()
        {
            if (_suit == "\u2666" || _suit == "\u2665")
                ForegroundColor = ConsoleColor.Red;
            else
                ForegroundColor = ConsoleColor.Black;
            if (_num == 11)
                return $"{"B"}{_suit}";
            else if (_num == 12)
                return $"{"D"}{_suit}";
            else if (_num == 13)
                return $"{"K"}{_suit}";
            else if (_num == 14)
                return $"{"T"}{_suit}";
            else
                return $"{_num}{_suit}";
        }

        public void Distribution()
        {
            for (int i = 0; i < 4; i++)
                for (int q = 6; q < 15; q++)
                    cards.Add(new Cards(q, Suits[i]) { });

            Random random = new Random();
            for (int i = cards.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;

            }

            for (int i = 0; i < 18; i++)
            {
                player1.Add(cards[i]);
                cards.RemoveAt(i);
            }

            for (int i = 0; i < 18; i++)
                player2.Add(cards[i]);
            cards.Clear();
            WriteLine("\t\tCard 1 player");
            for (int i = 0; i < player1.Count; i++)
                Write(player1[i] + " ");
            WriteLine();
            WriteLine("\t\tCard 2 player");
            for (int i = 0; i < player1.Count; i++)
                Write(player2[i] + " ");
            WriteLine();
            ForegroundColor = ConsoleColor.Black;
            WriteLine("\t\t\nPress enter to begin");
            ReadLine();
        }
        public void Game()
        {

            for (int i = 0; i < rounds; i++)
            {
                Clear();
                if (player1[i]._suit == "\u2666" || player1[i]._suit == "\u2665")
                    ForegroundColor = ConsoleColor.Red;
                else if (player2[i]._suit == "\u2666" || player2[i]._suit == "\u2665")
                    ForegroundColor = ConsoleColor.Red;
                Write(player1[i] + " ");
                if (player1[i]._suit == "\u2660" || player1[i]._suit == "\u2663")
                    ForegroundColor = ConsoleColor.Black;
                if (player2[i]._suit == "\u2660" || player2[i]._suit == "\u2663")
                    ForegroundColor = ConsoleColor.Black;
                WriteLine(player2[i]);
                ForegroundColor = ConsoleColor.Black;
                if (player1[i]._num < player2[i]._num)
                {
                    WriteLine("Second player wins");
                    player1.RemoveAt(i);
                    player2.Add(player1[i]);
                }
                else if (player1[i]._num > player2[i]._num)
                {
                    WriteLine("First player wins");
                    player2.RemoveAt(i);
                    player1.Add(player2[i]);
                }
                else if (player1[i]._num == player2[i]._num)
                {
                    WriteLine("Equal cards");
                    player1.Add(player1[i]);
                    player1.RemoveAt(i);
                    player2.Add(player2[i]);
                    player2.RemoveAt(i);
                }
                ReadLine();
            }
            Clear();
            WriteLine($"{"After"} {rounds} {"rounds"}\n\n");
            ForegroundColor = ConsoleColor.Black;
            WriteLine($"{"First player's set:"} {player1.Count} {"cards"}");
            foreach (var item in player1)
                Write(item + " ");
            WriteLine("\n\n");
            ForegroundColor = ConsoleColor.Black;
            WriteLine($"{"Second player's set:"} {player2.Count} {"cards"}");
            foreach (var item in player2)
                Write(item + " ");
            WriteLine();
            ReadLine();
            Clear();
            ForegroundColor = ConsoleColor.Red;
            if (player1.Count > player2.Count) { WriteLine("First player wins!!!!"); }
            else if (player2.Count > player1.Count) { WriteLine("Second player wins!!!!"); }
            else if (player2.Count == player1.Count) { WriteLine("Nobody wins!!!!"); }
            ForegroundColor = ConsoleColor.Black;
        }
    }
}