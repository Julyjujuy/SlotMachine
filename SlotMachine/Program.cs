using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Net;



namespace SlotMachine
{
    internal class Program
    {
        /// <summary>
        /// Pick a random number from a list of random generated numbers
        /// </summary>
        /// <param name="min">set minimum parameter</param>
        /// <param name="max">set maximum parameter</param>
        /// <param name="rng">generated random number</param>
        /// <returns>a random generated number</returns>
        static int Generatenumber(int min, int max, Random rng)
        {
            var number = rng.Next(min, max);
            return number;
        }
        /// <summary>
        /// Pick a random symbol from a list 
        /// </summary>
        /// <param name="random_Point">generated random number for the pick</param>
        /// <returns>a symbol randomly picked</returns>
        static string RandomSymbol(Random random_Point)
        {
            string[] symbols = { "   Dice   ", "Watermelon", "  Heart   ", "    7     ", "  Rocket  ", "  Cherry  ", "  Banana  ", "  Ananas  ", "   Coin   " };
            int randomnumber = Generatenumber(0, symbols.Length, random_Point);
            return symbols[randomnumber];
        }
        /// <summary>
        /// prints the grid of jagged arrays string
        /// </summary>
        /// <param name="grid2Print"></param>
        static void PrintGrid(string[][] grid2Print)
        {
            foreach (string[] row in grid2Print)
            {
                foreach (string word in row)
                {
                    Console.Write(word);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// it checks the matches in each line combination that it's given 
        /// </summary>
        /// <param name="first">first element of the line</param>
        /// <param name="second">second element of the line</param>
        /// <param name="third">third element of the line</param>
        /// <returns>points for matches checked</returns>
        static int CheckLine(string first, string second, string third)
        {
            if (first == second && second == third)
            {
                return 2;
            }
            if (first == second || first == third || second == third)
            {
                return 1;
            }

            return 0;

        }
        /// <summary>
        /// it checks the matches for the central line using the checkline method
        /// </summary>
        /// <param name="gridToCheck"></param>
        /// <returns></returns>
        static int CheckCentral(string[][] gridToCheck)
        {
            return CheckLine(gridToCheck[1][0], gridToCheck[1][1], gridToCheck[1][2]);
        }
        /// <summary>
        /// it checks the matches for the horizontal line using the checkline method
        /// </summary>
        /// <param name="gridToCheck"></param>
        /// <returns></returns>
        static int CheckHorizontal(string[][] gridToCheck)
        {
            int horizontalWins = 0;
            horizontalWins += CheckLine(gridToCheck[0][0], gridToCheck[0][1], gridToCheck[0][2]);
            horizontalWins += CheckLine(gridToCheck[1][0], gridToCheck[1][1], gridToCheck[1][2]);
            horizontalWins += CheckLine(gridToCheck[2][0], gridToCheck[2][1], gridToCheck[2][2]);
            return horizontalWins;
        }
        /// <summary>
        /// it checks the matches for the vertical and diagonal lines using the checkline method
        /// </summary>
        /// <param name="gridToCheck"></param>
        /// <returns></returns>
        static int CheckVerticalandDiagonal(string[][] gridToCheck)
        {
            int verticalWins = 0;
            verticalWins += CheckLine(gridToCheck[0][0], gridToCheck[1][0], gridToCheck[2][0]);
            verticalWins += CheckLine(gridToCheck[0][1], gridToCheck[1][1], gridToCheck[2][1]);
            verticalWins += CheckLine(gridToCheck[0][2], gridToCheck[1][2], gridToCheck[2][2]);
            verticalWins += CheckLine(gridToCheck[0][0], gridToCheck[1][1], gridToCheck[2][2]);
            verticalWins += CheckLine(gridToCheck[0][2], gridToCheck[1][1], gridToCheck[2][0]);
            return verticalWins;
        }
        /// <summary>
        /// take the bet of the user and checks it with the current credit
        /// </summary>
        /// <param name="moneyInTheBank">current credits parameter</param>
        /// <returns>the amount of current credits after the bet</returns>
        static int GetBet(int moneyInTheBank)
        {
            bool invalid = true;
            int bet = 0;
            while (invalid)
            {
                if (int.TryParse(Console.ReadLine(), out bet))
                {
                    bet = Math.Abs(bet);
                    if (moneyInTheBank >= bet)
                    {
                        invalid = false;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you don't have that much credits!");
                    }
                }
                else
                {
                    Console.WriteLine("You must imput a valid number please.");
                }

            }
            return bet;
        }
        static void Main(string[] args)
        {
            int userBank = 100;
            const int CENTRAL_MULTIPLIER = 5;
            const int HORIZONTAL_MULTIPLIER = 2;
            const int VERTICAL_MULTIPLIER = 1;

            Console.WriteLine($"Hello, Welcome to my Slot Machine. You start with {userBank} Credits!");
            bool wannaPlay = true;
            while (wannaPlay)
            {
                Console.WriteLine($"How much do you want to bet on the central Line?");
                int centralBet = GetBet(userBank);
                userBank -= centralBet;
                Console.WriteLine($"You have now {userBank} Credits!");
                Console.WriteLine("How much do you want to bet on the horizontal Lines?");
                int horizontalBet = GetBet(userBank);
                userBank -= horizontalBet;
                Console.WriteLine($"You have now {userBank} Credits!");
                Console.WriteLine("How much do you want to bet on the Vertical and Diagonal Lines?");
                int verticalBet = GetBet(userBank);
                userBank -= verticalBet;
                Console.WriteLine($"You have now {userBank} Credits!");

                Random rand = new Random();

                string[][] grid = new string[3][] { new string[3], new string[3], new string[3] };
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        grid[i][j] = RandomSymbol(rand);
                    }
                }
                PrintGrid(grid);

                int wins = 0;
                wins += CheckCentral(grid) * CENTRAL_MULTIPLIER * centralBet;
                wins += CheckHorizontal(grid) * HORIZONTAL_MULTIPLIER * horizontalBet;
                wins += CheckVerticalandDiagonal(grid) * VERTICAL_MULTIPLIER * verticalBet;

                Console.WriteLine("You won {0} credits", wins);
                Console.WriteLine($"You won {wins} credits");
                userBank += wins;
                Console.WriteLine("You have now {0} Credits!", userBank);

                Console.WriteLine("Wanna play another round? Type 'n' to exit. Type anything else to continue.");
                string wannaExit = Console.ReadLine().ToLower();
                if (wannaExit == "n")
                {
                    wannaPlay = false;
                }

            }

            
        }
    }
}

