using System;




namespace SlotMachine
{
    internal class Program
    {
        
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
              
                int userCentralBet = 0;
                int userHorizontalBet = 0;
                int userVerticalDiagonalBet = 0;
                UIMethods.AskCentralBet(userCentralBet);
                int centralBet = Methods.GetBet(userBank);
                userBank -= centralBet;
                Console.WriteLine($"You have now {userBank} Credits!");
                UIMethods.AskHorizontalBet(userHorizontalBet);
                int horizontalBet = Methods.GetBet(userBank);
                userBank -= horizontalBet;
                Console.WriteLine($"You have now {userBank} Credits!");
                UIMethods.AskVerticalDiagonalBet(userVerticalDiagonalBet);
                int verticalBet = Methods.GetBet(userBank);
                userBank -= verticalBet;
                Console.WriteLine($"You have now {userBank} Credits!");
                Random rand = new Random();
                string[,] grid = new string[3,3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        grid[i,j] = Methods.RandomSymbol(rand);
                    }
                }
                Methods.PrintGrid(grid);
                int wins = 0;
                wins += Methods.CheckCentral(grid) * CENTRAL_MULTIPLIER * centralBet;
                wins += Methods.CheckHorizontal(grid) * HORIZONTAL_MULTIPLIER * horizontalBet;
                wins += Methods.CheckVerticalandDiagonal(grid) * VERTICAL_MULTIPLIER * verticalBet;

                Console.WriteLine("You won {0} credits", wins);
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

