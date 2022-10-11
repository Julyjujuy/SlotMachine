using Microsoft.Office.SharePoint.Tools;
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
            UIMethods.StartSession(userBank);
            bool wannaPlay = true;
            while (wannaPlay)
            {
                int userCentralBet = 0;
                int userHorizontalBet = 0;
                int userVerticalDiagonalBet = 0;
                UIMethods.AskCentralBet(userCentralBet);
                int centralBet = UIMethods.GetBet(userBank);
                userBank -= centralBet;
                UIMethods.TellUserAccount(userBank);
                UIMethods.AskHorizontalBet(userHorizontalBet);
                int horizontalBet = UIMethods.GetBet(userBank);
                userBank -= horizontalBet;
                UIMethods.TellUserAccount(userBank);
                UIMethods.AskVerticalDiagonalBet(userVerticalDiagonalBet);
                int verticalBet = UIMethods.GetBet(userBank);
                userBank -= verticalBet;
                UIMethods.TellUserAccount(userBank);
                Random rand = new Random();
                string[,] grid = new string[3,3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        grid[i,j] = Methods.RandomSymbol(rand);
                    }
                }
                UIMethods.PrintGrid(grid);
                int wins = 0;
                wins += Methods.CheckCentral(grid) * CENTRAL_MULTIPLIER * centralBet;
                wins += Methods.CheckHorizontal(grid) * HORIZONTAL_MULTIPLIER * horizontalBet;
                wins += Methods.CheckVerticalandDiagonal(grid) * VERTICAL_MULTIPLIER * verticalBet;
                UIMethods.TellWins(wins);
                userBank += wins;
                UIMethods.TellUserAccount(userBank);

                UIMethods.AskAnotherRound();
                string wannaExit = Console.ReadLine().ToLower();
                if (wannaExit == "n")
                {
                   break;
                }

            }
        }
    }
}

