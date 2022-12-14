using System;

namespace SlotMachine
{
    internal class UIMethods
    {
        public static void StartSession(int userBank)
        {
            Console.WriteLine($"Hello, Welcome to my Slot Machine. You start with {userBank} Credits!");
        }
        public static int AskCentralBet(int userCentralBet)
        {
            Console.WriteLine($"How much do you want to bet on the central Line?");
            return userCentralBet;
        }
        public static int AskHorizontalBet(int userHorizontalBet)
        {
            Console.WriteLine("How much do you want to bet on the horizontal Lines?");
            return (userHorizontalBet);
        }
        public static int AskVerticalDiagonalBet(int userVerticalDiagonalBet)
        {
            Console.WriteLine("How much do you want to bet on the Vertical and Diagonal Lines?");
            return userVerticalDiagonalBet;
        }
        public static void TellUserAccount(int userBank)
        {
            Console.WriteLine($"You have now {userBank} Credits!");
        }
        public static void TellWins(int wins)
        {
            Console.WriteLine($"You won {wins} credits");
        }
        public static string AskAnotherRound()
        {
            Console.WriteLine("Do you want to continue? Type 'y', otherwise type 'n'");
            string wannaExit = Console.ReadLine().ToLower();
            return wannaExit;
        }


        /// <summary>
        /// take the bet of the user and checks it with the current credit
        /// </summary>
        /// <param name="moneyInTheBank">current credit parameter</param>
        /// <returns>the amount of current credits after the bet</returns>
        public static int GetBet(int moneyInTheBank)
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
                    Console.WriteLine("Input.");
                }

            }
            return bet;
        }
        public static void PrintGrid(string[,] elements2Print)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(elements2Print[i, j]);
                }
                Console.WriteLine();
            }
            //foreach (string[] row in elements2Print)
            //{
            //    foreach (string word in elements2Print)
            //    {
            //        Console.Write(word);
            //        Console.Write(" ");
            //    }
            //    Console.WriteLine();
            //}
        }
        public static string[,] RandomGrid(int width, int length)
        {
            Random rand = new Random();
            string[,] grid = new string[width, length];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    grid[i, j] = Methods.RandomSymbol(rand);
                }
            }

            return grid;
            }
        public static int CheckAllWins(string[,] grid, int centralBet, int horizontalBet, int verticalBet)
        {
            const int CENTRAL_MULTIPLIER = 5;
            const int HORIZONTAL_MULTIPLIER = 2;
            const int VERTICAL_MULTIPLIER = 1;
            int wins = 0;
            wins += Methods.CheckCentral(grid) * CENTRAL_MULTIPLIER * centralBet;
            wins += Methods.CheckHorizontal(grid) * HORIZONTAL_MULTIPLIER * horizontalBet;
            wins += Methods.CheckVerticalandDiagonal(grid) * VERTICAL_MULTIPLIER * verticalBet;

            return wins;
}
    }
}



