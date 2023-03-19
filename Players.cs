using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DruncKard
{
    internal class _3_players
    {
        List<_3_players> cards = new List<_3_players>();
        List<_3_players> player1 = new List<_3_players>();
        List<_3_players> player2 = new List<_3_players>();
        List<_3_players> player3 = new List<_3_players>();
        string[] Suits = { "\u2660", "\u2665", "\u2666", "\u2663" };
        public _3_players() { }
        private int _rank;
        private string _suit;
        short moves = 6;
        public _3_players(int rank, string suit)
        {
            _rank = rank;
            _suit = suit;
        }
        public override string ToString()
        {
            if (_suit == "\u2666" || _suit == "\u2665")
                ForegroundColor = ConsoleColor.Red;
            else
                ForegroundColor = ConsoleColor.Black;
            if (_rank == 11)
                return $"{"B"}{_suit}";
            else if (_rank == 12)
                return $"{"D"}{_suit}";
            else if (_rank == 13)
                return $"{"K"}{_suit}";
            else if (_rank == 14)
                return $"{"T"}{_suit}";
            else
                return $"{_rank}{_suit}";
        }
        public void draw()
        {
            for (int i = 0; i < 4; i++)
                for (int q = 6; q < 15; q++)
                    cards.Add(new _3_players(q, Suits[i]) { });

            Random random = new Random();
            for (int i = cards.Count - 5; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                (cards[j], cards[i]) = (cards[i], cards[j]);
            }

            for (int i = 0; i < 12; i++)
            {
                player1.Add(cards[i]);
                cards.RemoveAt(i);
            }
            for (int i = 0; i < 12; i++)
            {
                player2.Add(cards[i]);
                cards.RemoveAt(i);
            }

            for (int i = 0; i < 12; i++)
                player3.Add(cards[i]);
            cards.Clear();
            WriteLine("\t\tCard 1 player");
            for (int i = 0; i < player1.Count; i++)
                Write(player1[i] + " ");
            WriteLine();
            WriteLine("\t\tCard 2 player");
            for (int i = 0; i < player1.Count; i++)
                Write(player2[i] + " ");
            WriteLine();
            WriteLine("\t\tCard 3 player");
            for (int i = 0; i < player1.Count; i++)
                Write(player3[i] + " ");
            WriteLine();
            WriteLine("\t\t\nLet's begin");
            ReadLine();
        }

        public void GameIn_3players()
        {

            for (int i = 0; i < moves; i++)
            {
                Clear();
                if (player1[i]._suit == "\u2666" || player1[i]._suit == "\u2665")
                    ForegroundColor = ConsoleColor.Red;
                else
                    ForegroundColor = ConsoleColor.Red;
                Write(player1[i] + " ");
                if (player2[i]._suit == "\u2660" || player2[i]._suit == "\u2663")
                    ForegroundColor = ConsoleColor.Black;
                else
                    ForegroundColor = ConsoleColor.Black;
                Write(player2[i] + " ");
                if (player3[i]._suit == "\u2666" || player3[i]._suit == "\u2665")
                    ForegroundColor = ConsoleColor.Red;
                else
                    ForegroundColor = ConsoleColor.Red;
                WriteLine(player3[i]);
                ForegroundColor = ConsoleColor.Black;
                if (player1[i]._rank > player2[i]._rank && player1[i]._rank > player3[i]._rank)
                {
                    WriteLine("Player 1 win");
                    player1.Add(player2[i]);
                    player1.Add(player3[i]);
                    player2.RemoveAt(i);
                    player3.RemoveAt(i);
                }
                else if (player2[i]._rank > player1[i]._rank && player2[i]._rank > player3[i]._rank)
                {
                    WriteLine("Player 2 win");
                    player2.Add(player1[i]);
                    player2.Add(player3[i]);
                    player1.RemoveAt(i);
                    player3.RemoveAt(i);
                }

                else if (player3[i]._rank > player1[i]._rank && player3[i]._rank > player2[i]._rank)
                {
                    WriteLine("Player 3 win");
                    player3.Add(player1[i]);
                    player3.Add(player2[i]);
                    player1.RemoveAt(i);
                    player2.RemoveAt(i);
                }
                else if (player1[i]._rank == player2[i]._rank && player1[i]._rank == player3[i]._rank && player2[i]._rank == player3[i]._rank)
                {
                    WriteLine("Draw");
                    player1.Add(player1[i]);
                    player1.RemoveAt(i);
                    player2.Add(player2[i]);
                    player2.RemoveAt(i);
                    player3.Add(player2[i]);
                    player3.RemoveAt(i);
                }
                else if (player1[i]._rank == player2[i]._rank && player1[i]._rank > player3[i]._rank)
                {
                    WriteLine("1 and 2 draw");
                    do
                    {
                        WriteLine(player1[i + 1] + " " + player2[i + 1] + " " + player3[i]);
                        if (player1[i + 1]._rank > player2[i + 1]._rank)
                        {
                            player3.RemoveAt(i);
                            WriteLine("Player 1 win");
                            player1.Add(player2[i + 1]);
                            player1.Add(player3[i]);
                        }
                        else if (player1[i + 1]._rank < player2[i + 1]._rank)
                        {
                            player3.RemoveAt(i);
                            WriteLine("Player 2 win");
                            player2.Add(player1[i + 1]);
                            player2.Add(player3[i]);
                        }
                        if (i == 11)
                            i = 0;
                        else
                            i++;
                    } while (player1[i]._rank == player2[i]._rank);
                }
                else if (player1[i]._rank == player3[i]._rank && player1[i]._rank > player2[i]._rank)
                {
                    WriteLine("1 and 3 draw");
                    do
                    {
                        WriteLine(player1[i + 1] + " " + player2[i] + " " + player3[i + 1]);
                        if (player1[i + 1]._rank > player3[i + 1]._rank)
                        {
                            player2.RemoveAt(i);
                            WriteLine("Player 1 win");
                            player1.Add(player3[i + 1]);
                            player1.Add(player2[i]);
                        }
                        else if (player1[i + 1]._rank < player3[i + 1]._rank)
                        {
                            player2.RemoveAt(i);
                            WriteLine("Player 2 win");
                            player3.Add(player1[i + 1]);
                            player3.Add(player2[i]);
                        }
                        if (i == 11)
                            i = 0;
                        else
                            i++;
                    } while (player1[i]._rank == player3[i]._rank);
                }
                else if (player2[i]._rank == player3[i]._rank && player2[i]._rank > player1[i]._rank)
                {
                    WriteLine("2 and 3 draw");
                    do
                    {
                        WriteLine(player1[i] + " " + player2[i + 1] + " " + player3[i + 1]);
                        if (player2[i + 1]._rank > player3[i + 1]._rank)
                        {
                            player1.RemoveAt(i);
                            WriteLine("Player 2 win");
                            player2.Add(player3[i + 1]);
                            player2.Add(player1[i]);
                        }
                        else if (player2[i + 1]._rank < player3[i + 1]._rank)
                        {
                            player1.RemoveAt(i);
                            WriteLine("Player 3 win");
                            player3.Add(player2[i + 1]);
                            player3.Add(player1[i]);
                        }
                        if (i == 11)
                            i = 0;
                        else
                            i++;
                    } while (player2[i]._rank == player3[i]._rank);
                }
                if (player1.Count == 0)
                {
                    WriteLine("PLAYER 1 lose");
                    WriteLine($"{"Player 2 have"} {player2.Count} {"cards"}");
                    WriteLine($"{"Player 3 have"} {player3.Count} {"cards"}");

                }
                else if (player2.Count == 0)
                {
                    WriteLine("PLAYER 2 lose");
                    WriteLine($"{"Player 1 have"} {player1.Count} {"cards"}");
                    WriteLine($"{"Player 3 have"} {player3.Count} {"cards"}");
                }
                else if (player3.Count == 0)
                {
                    WriteLine("PLAYER 3 lose");
                    WriteLine($"{"Player 1 have"} {player1.Count} {"cards"}");
                    WriteLine($"{"Player 2 have"} {player2.Count} {"cards"}");
                }
                ReadLine();
            }
            Clear();
            WriteLine($"{"After"} {moves} {"moves"}");
            WriteLine($"{"Player 1 have"} {player1.Count} {"cards"}");
            foreach (var item in player1)
                Write(item + " ");
            WriteLine();
            ForegroundColor = ConsoleColor.Black;
            WriteLine($"{"Player 2 have"} {player2.Count} {"cards"}");
            foreach (var item in player2)
                Write(item + " ");
            WriteLine();
            ForegroundColor = ConsoleColor.Black;
            WriteLine($"{"Player 3 have"} {player3.Count} {"cards"}");
            foreach (var item in player3)
                Write(item + " ");
            WriteLine();
            ReadLine();
            Clear();
            ForegroundColor = ConsoleColor.Black;
            if (player1.Count > player2.Count && player1.Count > player3.Count) { WriteLine("Player 1 WIN!!!!"); }
            else if (player2.Count > player1.Count && player2.Count > player3.Count) { WriteLine("Player 2 WIN!!!!"); }
            else if (player3.Count > player1.Count && player3.Count > player2.Count) { WriteLine("Player 3 WIN!!!!"); }
            else if (player1.Count == player2.Count && player1.Count == player3.Count && player2.Count == player3.Count) { WriteLine("Friendship WIN!!!!"); }
            else if (player1.Count == player2.Count && player1.Count > player3.Count) { WriteLine("Player 3 LOSE!!!!"); }
            else if (player1.Count == player3.Count && player1.Count > player2.Count) { WriteLine("Player 2 LOSE!!!!"); }
            else if (player2.Count == player3.Count && player2.Count > player2.Count) { WriteLine("Player 1 LOSE!!!!"); }

        }
    }
}