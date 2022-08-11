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
                int centralBet = UIMethods.GetBet(userBank);
                userBank -= centralBet;
                Console.WriteLine($"You have now {userBank} Credits!");
                Console.WriteLine("How much do you want to bet on the horizontal Lines?");
                int horizontalBet = UIMethods.GetBet(userBank);
                userBank -= horizontalBet;
                Console.WriteLine($"You have now {userBank} Credits!");
                Console.WriteLine("How much do you want to bet on the Vertical and Diagonal Lines?");
                int verticalBet = UIMethods.GetBet(userBank);
                userBank -= verticalBet;
                Console.WriteLine($"You have now {userBank} Credits!");

                Random rand = new Random();

                string[][] grid = new string[3][] { new string[3], new string[3], new string[3] };
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        grid[i][j] = UIMethods.RandomSymbol(rand);
                    }
                }
                UIMethods.PrintGrid(grid);

                int wins = 0;
                wins += UIMethods.CheckCentral(grid) * CENTRAL_MULTIPLIER * centralBet;
                wins += UIMethods.CheckHorizontal(grid) * HORIZONTAL_MULTIPLIER * horizontalBet;
                wins += UIMethods.CheckVerticalandDiagonal(grid) * VERTICAL_MULTIPLIER * verticalBet;

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

