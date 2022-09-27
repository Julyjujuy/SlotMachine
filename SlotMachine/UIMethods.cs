using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SlotMachine
{
    internal class UIMethods
    {
        public static void InitiateSession(int userBank)
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
            return Methods.GetBet(userHorizontalBet);
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
            Console.WriteLine("You won {0} credits", wins);
        }
        public static string AskAnotherRound(string question)
        {
            Console.WriteLine("Wanna play another round? Type 'n' to exit. Type anything else to continue.");
            return question;
        }
    }
}
